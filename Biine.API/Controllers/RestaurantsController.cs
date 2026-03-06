using Biine.API.Data;
using Biine.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(AppDbContext db, IConfiguration config) : ControllerBase
{
    private static readonly HttpClient _http = new();

    // GET /api/restaurants/match?cuisine=Italian&lang=sv&lat=57.7&lng=11.9
    // When lat/lng provided: queries Google Places API in real-time (like Google Maps!)
    // Otherwise: falls back to seeded database
    [HttpGet("match")]
    public async Task<ActionResult<RestaurantDto>> GetMatch(
        [FromQuery] string cuisine,
        [FromQuery] string lang = "sv",
        [FromQuery] double? lat = null,
        [FromQuery] double? lng = null)
    {
        if (string.IsNullOrWhiteSpace(cuisine))
            return BadRequest(new { error = "cuisine is required" });

        // If user provided location, query Google Places API in real-time
        if (lat.HasValue && lng.HasValue)
        {
            var apiKey = config["GooglePlaces:ApiKey"];
            if (!string.IsNullOrEmpty(apiKey))
            {
                try
                {
                    var result = await SearchGooglePlacesAsync(apiKey, cuisine, lat.Value, lng.Value, lang);
                    if (result != null)
                        return Ok(result);
                }
                catch
                {
                    // Fall through to database if API fails
                }
            }
        }

        // Fallback: use seeded database
        var restaurants = await db.Restaurants
            .Where(r => r.Cuisine.ToLower() == cuisine.ToLower())
            .ToListAsync();

        if (restaurants.Count == 0)
            return NotFound(new { error = "no_restaurants_found" });

        Restaurant? restaurant;

        // If user provided location, find closest from database
        if (lat.HasValue && lng.HasValue)
        {
            restaurant = restaurants
                .OrderBy(r => CalculateDistance(lat.Value, lng.Value, (double)r.Lat, (double)r.Lng))
                .First();
        }
        else
        {
            restaurant = restaurants[Random.Shared.Next(restaurants.Count)];
        }

        return Ok(MapToDto(restaurant));
    }

    // Query Google Places API Nearby Search for real-time results
    private async Task<RestaurantDto?> SearchGooglePlacesAsync(string apiKey, string cuisine, double lat, double lng, string lang)
    {
        var languageCode = lang == "en" ? "en" : "sv";

        var body = new Dictionary<string, object>
        {
            ["includedTypes"] = new[] { "restaurant" },
            ["maxResultCount"] = 10,
            ["locationRestriction"] = new Dictionary<string, object>
            {
                ["circle"] = new Dictionary<string, object>
                {
                    ["center"] = new Dictionary<string, double> { ["latitude"] = lat, ["longitude"] = lng },
                    ["radius"] = 5000.0
                }
            },
            ["textQuery"] = $"{cuisine} restaurant",
            ["languageCode"] = languageCode
        };

        _http.DefaultRequestHeaders.Clear();
        _http.DefaultRequestHeaders.Add("X-Goog-Api-Key", apiKey);
        _http.DefaultRequestHeaders.Add("X-Goog-FieldMask", "places.id,places.displayName,places.formattedAddress,places.rating,places.priceLevel,places.location,places.googleMapsUri");

        var response = await _http.PostAsJsonAsync(
            "https://places.googleapis.com/v1/places:searchText",
            body
        );

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<GooglePlacesResponse>();
        var place = result?.Places?.FirstOrDefault();

        if (place == null)
            return null;

        return new RestaurantDto(
            Id: 0,
            Name: place.DisplayName?.Text ?? "Unknown",
            Address: place.FormattedAddress ?? "",
            Cuisine: cuisine,
            PriceLevel: ParsePriceLevel(place.PriceLevel),
            Rating: (decimal)(place.Rating ?? 0),
            GoogleMapsUrl: place.GoogleMapsUri ?? $"https://www.google.com/maps/place/?q=place_id:{place.Id}",
            DistanceKm: CalculateDistance(lat, lng, place.Location?.Latitude ?? 0, place.Location?.Longitude ?? 0)
        );
    }

    private static int ParsePriceLevel(string? priceLevel) => priceLevel switch
    {
        "PRICE_LEVEL_FREE" => 0,
        "PRICE_LEVEL_INEXPENSIVE" => 1,
        "PRICE_LEVEL_MODERATE" => 2,
        "PRICE_LEVEL_EXPENSIVE" => 3,
        "PRICE_LEVEL_VERY_EXPENSIVE" => 4,
        _ => 2
    };

    // Haversine formula to calculate distance between two points in km
    private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double R = 6371;
        var dLat = ToRad(lat2 - lat1);
        var dLon = ToRad(lon2 - lon1);
        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }

    private static double ToRad(double deg) => deg * Math.PI / 180;

    private static RestaurantDto MapToDto(Restaurant r) => new(
        Id: r.Id,
        Name: r.Name,
        Address: r.Address,
        Cuisine: r.Cuisine,
        PriceLevel: r.PriceLevel,
        Rating: r.Rating,
        GoogleMapsUrl: r.GoogleMapsUrl,
        DistanceKm: null
    );
}

public record RestaurantDto(
    int Id,
    string Name,
    string Address,
    string Cuisine,
    int PriceLevel,
    decimal Rating,
    string GoogleMapsUrl,
    double? DistanceKm = null
);

// Google Places API response models
public class GooglePlacesResponse
{
    [JsonPropertyName("places")]
    public List<GooglePlace>? Places { get; set; }
}

public class GooglePlace
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("displayName")]
    public GoogleDisplayName? DisplayName { get; set; }

    [JsonPropertyName("formattedAddress")]
    public string? FormattedAddress { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("priceLevel")]
    public string? PriceLevel { get; set; }

    [JsonPropertyName("location")]
    public GoogleLocation? Location { get; set; }

    [JsonPropertyName("googleMapsUri")]
    public string? GoogleMapsUri { get; set; }
}

public class GoogleDisplayName
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public class GoogleLocation
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
