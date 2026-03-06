using Biine.API.Data;
using Biine.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController(AppDbContext db) : ControllerBase
{
    // GET /api/recipes/next?sessionId=xxx&lang=sv
    // Returns the next unseen recipe for this session.
    // "Unseen" = no Interaction row exists with this sessionId + recipeId.
    // Returns 404 when all recipes have been seen.
    [HttpGet("next")]
    public async Task<ActionResult<RecipeDto>> GetNext(
        [FromQuery] string sessionId,
        [FromQuery] string lang = "sv")
    {
        if (string.IsNullOrWhiteSpace(sessionId))
            return BadRequest(new { error = "sessionId is required" });

        // Get IDs already seen by this session
        var seenIds = await db.Interactions
            .Where(i => i.SessionId == sessionId)
            .Select(i => i.RecipeId)
            .Distinct()
            .ToListAsync();

        // Pick a random unseen recipe
        var recipe = await db.Recipes
            .Where(r => !seenIds.Contains(r.Id))
            .OrderBy(_ => EF.Functions.Random())
            .FirstOrDefaultAsync();

        if (recipe == null)
            return NotFound(new { error = "no_more_recipes" });

        return Ok(MapToDto(recipe, lang));
    }

    private static RecipeDto MapToDto(Recipe r, string lang) => new(
        Id: r.Id,
        Name: r.Name,
        PersonaText: lang == "en" ? r.PersonaTextEn : r.PersonaTextSv,
        Ingredients: lang == "en" ? r.IngredientsEn : r.IngredientsSv,
        Instructions: lang == "en" ? r.InstructionsEn : r.InstructionsSv,
        CookingTime: r.CookingTime,
        Difficulty: r.Difficulty,
        Cuisine: r.Cuisine,
        Tags: r.Tags,
        ImageUrl: r.ImageUrl
    );
}

public record RecipeDto(
    int Id,
    string Name,
    string PersonaText,
    string Ingredients,   // raw JSON string
    string Instructions,
    int CookingTime,
    string Difficulty,
    string Cuisine,
    string[] Tags,
    string? ImageUrl
);
