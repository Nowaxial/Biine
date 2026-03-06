using Biine.API.Data;
using Biine.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InteractionsController(AppDbContext db) : ControllerBase
{
    // POST /api/interactions
    // Body: { sessionId, recipeId, action }
    // action values: "like" | "dislike"
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InteractionRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.SessionId))
            return BadRequest(new { error = "sessionId is required" });

        if (req.RecipeId <= 0)
            return BadRequest(new { error = "recipeId must be a positive integer" });

        if (req.Action is not ("like" or "dislike"))
            return BadRequest(new { error = "action must be 'like' or 'dislike'" });

        var interaction = new Interaction
        {
            SessionId = req.SessionId,
            RecipeId = req.RecipeId,
            Action = req.Action,
            CreatedAt = DateTime.UtcNow
        };

        db.Interactions.Add(interaction);
        await db.SaveChangesAsync();

        return Created(string.Empty, new { id = interaction.Id });
    }
}

public record InteractionRequest(string SessionId, int RecipeId, string Action);
