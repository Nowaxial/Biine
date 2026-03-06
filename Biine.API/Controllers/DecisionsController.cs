using Biine.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DecisionsController(AppDbContext db) : ControllerBase
{
    // POST /api/decisions
    // Body: { sessionId, recipeId, decision }
    // decision values: "cook" | "eat_out"
    // Updates the most recent "like" interaction for this session+recipe with the decision.
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DecisionRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.SessionId))
            return BadRequest(new { error = "sessionId is required" });

        if (req.RecipeId <= 0)
            return BadRequest(new { error = "recipeId must be a positive integer" });

        if (req.Decision is not ("cook" or "eat_out"))
            return BadRequest(new { error = "decision must be 'cook' or 'eat_out'" });

        // Find the most recent like interaction for this session+recipe
        var interaction = await db.Interactions
            .Where(i => i.SessionId == req.SessionId
                     && i.RecipeId == req.RecipeId
                     && i.Action == "like")
            .OrderByDescending(i => i.CreatedAt)
            .FirstOrDefaultAsync();

        if (interaction == null)
            return NotFound(new { error = "no matching interaction found" });

        interaction.Decision = req.Decision;
        await db.SaveChangesAsync();

        return Ok(new { id = interaction.Id, decision = req.Decision });
    }
}

public record DecisionRequest(string SessionId, int RecipeId, string Decision);
