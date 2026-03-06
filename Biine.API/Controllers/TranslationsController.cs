using Biine.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TranslationsController(AppDbContext db) : ControllerBase
{
    // GET /api/translations?lang=sv
    // Returns all translation strings as a flat key→value dictionary.
    // Frontend caches this on first load.
    [HttpGet]
    public async Task<ActionResult<Dictionary<string, string>>> GetAll(
        [FromQuery] string lang = "sv")
    {
        var translations = await db.Translations.ToListAsync();

        var dict = translations.ToDictionary(
            t => t.Key,
            t => lang == "en" ? t.TextEn : t.TextSv
        );

        return Ok(dict);
    }
}
