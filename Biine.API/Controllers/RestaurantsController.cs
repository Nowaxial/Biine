using Biine.API.Data;
using Biine.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(AppDbContext db) : ControllerBase
{
    // GET /api/restaurants/match?cuisine=Italian&lang=sv
    // Returns a random restaurant matching the cuisine.
    // If no match found (cuisine not seeded yet), returns 404.
    [HttpGet("match")]
    public async Task<ActionResult<RestaurantDto>> GetMatch(
        [FromQuery] string cuisine,
        [FromQuery] string lang = "sv")
    {
        if (string.IsNullOrWhiteSpace(cuisine))
            return BadRequest(new { error = "cuisine is required" });

        var restaurant = await db.Restaurants
            .Where(r => r.Cuisine.ToLower() == cuisine.ToLower())
            .OrderBy(_ => EF.Functions.Random())
            .FirstOrDefaultAsync();

        if (restaurant == null)
            return NotFound(new { error = "no_restaurants_found" });

        return Ok(MapToDto(restaurant));
    }

    private static RestaurantDto MapToDto(Restaurant r) => new(
        Id: r.Id,
        Name: r.Name,
        Address: r.Address,
        Cuisine: r.Cuisine,
        PriceLevel: r.PriceLevel,
        Rating: r.Rating,
        GoogleMapsUrl: r.GoogleMapsUrl
    );
}

public record RestaurantDto(
    int Id,
    string Name,
    string Address,
    string Cuisine,
    int PriceLevel,
    decimal Rating,
    string GoogleMapsUrl
);
