using Biine.API.Data;
using Biine.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biine.API.Seeders;

/// <summary>
/// Seeds restaurants from Google Places API (Text Search v1).
/// Run via: dotnet run --project Biine.API -- --seed-restaurants
/// 
/// Optional arguments:
///   --lat <value>      Latitude for search center (default: 57.7089 Göteborg)
///   --lng <value>      Longitude for search center (default: 11.9746)
///   --radius <value>  Search radius in meters (default: 8000)
///   --city <name>     City name for search query (default: Göteborg Sweden)
/// 
/// Example:
///   dotnet run --project Biine.API -- --seed-restaurants --lat 59.3293 --lng 18.0686 --radius 15000 --city "Stockholm Sweden"
/// </summary>
public static class RestaurantSeeder
{
    // 14 cuisines matching our recipe data — 3 restaurants each = 42 total
    private static readonly string[] Cuisines =
    [
        "American", "Chinese", "German", "Greek", "Hawaiian",
        "Indian", "Italian", "Japanese", "Korean", "Mexican",
        "Middle Eastern", "Swedish", "Thai", "Vietnamese"
    ];

    public static async Task SeedAsync(
        AppDbContext db, 
        string apiKey,
        double? lat = null,
        double? lng = null,
        double? radius = null,
        string? city = null)
    {
        // Default to Göteborg if not specified
        var centerLat = lat ?? 57.7089;
        var centerLng = lng ?? 11.9746;
        var searchRadius = radius ?? 8000.0;
        var cityQuery = city ?? "Göteborg Sweden";

        Console.WriteLine("=== Restaurant Seeder ===");
        Console.WriteLine($"  Location: {centerLat}, {centerLng} (radius: {searchRadius}m)");
        Console.WriteLine($"  City query: {cityQuery}");

        // Clear existing restaurants to allow re-runs
        var existing = await db.Restaurants.CountAsync();
        if (existing > 0)
        {
            Console.WriteLine($"Clearing {existing} existing restaurants...");
            await db.Restaurants.ExecuteDeleteAsync();
        }

        using var http = new HttpClient();
        http.DefaultRequestHeaders.Add("X-Goog-Api-Key", apiKey);
        http.DefaultRequestHeaders.Add(
            "X-Goog-FieldMask",
            "places.id,places.displayName,places.formattedAddress,places.rating,places.priceLevel,places.location,places.googleMapsUri"
        );

        var allRestaurants = new List<Restaurant>();
        int totalAdded = 0;

        foreach (var cuisine in Cuisines)
        {
            Console.Write($"  Searching {cuisine,-15} ... ");

            try
            {
                var results = await SearchPlacesAsync(http, cuisine, centerLat, centerLng, searchRadius, cityQuery);
                var restaurants = results
                    .Take(3)
                    .Select(p => MapToRestaurant(p, cuisine))
                    .Where(r => r != null)
                    .Cast<Restaurant>()
                    .ToList();

                allRestaurants.AddRange(restaurants);
                Console.WriteLine($"{restaurants.Count} found");

                // Small delay to avoid hitting rate limits
                await Task.Delay(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        if (allRestaurants.Count > 0)
        {
            db.Restaurants.AddRange(allRestaurants);
            await db.SaveChangesAsync();
            totalAdded = allRestaurants.Count;
        }

        Console.WriteLine($"\n✅ Seeded {totalAdded} restaurants across {Cuisines.Length} cuisines.");
    }

    private static async Task<List<PlaceResult>> SearchPlacesAsync(
        HttpClient http, 
        string cuisine,
        double centerLat,
        double centerLng,
        double radius,
        string cityQuery)
    {
        var body = new
        {
            textQuery = $"{cuisine} restaurant {cityQuery}",
            languageCode = "sv",
            locationBias = new
            {
                circle = new
                {
                    center = new { latitude = centerLat, longitude = centerLng },
                    radius = radius
                }
            },
            maxResultCount = 5
        };

        var response = await http.PostAsJsonAsync(
            "https://places.googleapis.com/v1/places:searchText",
            body
        );

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            throw new Exception($"HTTP {(int)response.StatusCode}: {err[..Math.Min(200, err.Length)]}");
        }

        var result = await response.Content.ReadFromJsonAsync<PlacesSearchResponse>();
        return result?.Places ?? [];
    }

    private static Restaurant? MapToRestaurant(PlaceResult place, string cuisine)
    {
        if (string.IsNullOrEmpty(place.Id)) return null;

        return new Restaurant
        {
            Name = place.DisplayName?.Text ?? "Unknown",
            Address = place.FormattedAddress ?? "",
            Cuisine = cuisine,
            PriceLevel = ParsePriceLevel(place.PriceLevel),
            Rating = (decimal)(place.Rating ?? 0),
            GooglePlaceId = place.Id,
            GoogleMapsUrl = place.GoogleMapsUri ?? $"https://www.google.com/maps/place/?q=place_id:{place.Id}",
            Lat = (decimal)(place.Location?.Latitude ?? 0),
            Lng = (decimal)(place.Location?.Longitude ?? 0),
            LastUpdated = DateTime.UtcNow
        };
    }

    private static int ParsePriceLevel(string? priceLevel) => priceLevel switch
    {
        "PRICE_LEVEL_FREE"          => 0,
        "PRICE_LEVEL_INEXPENSIVE"   => 1,
        "PRICE_LEVEL_MODERATE"      => 2,
        "PRICE_LEVEL_EXPENSIVE"     => 3,
        "PRICE_LEVEL_VERY_EXPENSIVE"=> 4,
        _                           => 2  // default to moderate
    };
}

// ─── Google Places API v1 response models ────────────────────────────────────

public class PlacesSearchResponse
{
    [JsonPropertyName("places")]
    public List<PlaceResult> Places { get; set; } = [];
}

public class PlaceResult
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("displayName")]
    public DisplayName? DisplayName { get; set; }

    [JsonPropertyName("formattedAddress")]
    public string? FormattedAddress { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("priceLevel")]
    public string? PriceLevel { get; set; }

    [JsonPropertyName("location")]
    public LatLng? Location { get; set; }

    [JsonPropertyName("googleMapsUri")]
    public string? GoogleMapsUri { get; set; }
}

public class DisplayName
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public class LatLng
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
