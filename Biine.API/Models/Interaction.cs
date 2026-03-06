namespace Biine.API.Models;

public class Interaction
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string Action { get; set; } = string.Empty;
    public string? Decision { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
