namespace Biine.API.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Cuisine { get; set; } = string.Empty;
    public int PriceLevel { get; set; }
    public decimal Rating { get; set; }
    public string GooglePlaceId { get; set; } = string.Empty;
    public string GoogleMapsUrl { get; set; } = string.Empty;
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}
