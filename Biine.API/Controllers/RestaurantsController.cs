using Biine.API.Data;
using Biine.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(AppDbContext db) : ControllerBase
{
    // GET /api/restaurants/match?cuisine=Italian&lang=sv&lat=57.7&lng=11.9
    // Returns a random restaurant matching the cuisine, or closest if lat/lng provided.
    // If no match found (cuisine not seeded yet), returns 404.
    [HttpGet("match")]
    public async Task<ActionResult<RestaurantDto>> GetMatch(
        [FromQuery] string cuisine,
        [FromQuery] string lang = "sv",
        [FromQuery] double? lat = null,
        [FromQuery] double? lng = null)
    {
        if (string.IsNullOrWhiteSpace(cuisine))
            return BadRequest(new { error = "cuisine is required" });

        // Get all restaurants matching the cuisine
        var restaurants = await db.Restaurants
            .Where(r => r.Cuisine.ToLower() == cuisine.ToLower())
            .ToListAsync();

        if (restaurants.Count == 0)
            return NotFound(new { error = "no_restaurants_found" });

        Restaurant? restaurant;

        // If user provided location, find closest
        if (lat.HasValue && lng.HasValue)
        {
            restaurant = restaurants
                .OrderBy(r => CalculateDistance(lat.Value, lng.Value, (double)r.Lat, (double)r.Lng))
                .First();
        }
        else
        {
            // Random if no location
            restaurant = restaurants[Random.Shared.Next(restaurants.Count)];
        }

        return Ok(MapToDto(restaurant));
    }

    // Haversine formula to calculate distance between two points in km
    private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double R = 6371; // Earth's radius in km
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
        DistanceKm: r.Lat != 0 && r.Lng != 0 ? null : null // will be calculated on frontend if needed
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
