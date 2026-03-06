namespace Biine.API.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PersonaTextSv { get; set; } = string.Empty;
    public string PersonaTextEn { get; set; } = string.Empty;
    public string IngredientsSv { get; set; } = "[]";
    public string IngredientsEn { get; set; } = "[]";
    public string InstructionsSv { get; set; } = string.Empty;
    public string InstructionsEn { get; set; } = string.Empty;
    public int CookingTime { get; set; }
    public string Difficulty { get; set; } = string.Empty;
    public string Cuisine { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public string? ImageUrl { get; set; }

    public ICollection<Interaction> Interactions { get; set; } = [];
}
