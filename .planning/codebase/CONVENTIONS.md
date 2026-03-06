# Code Conventions

## C# / Backend

### Controllers
```csharp
[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public RecipesController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("next")]
    public async Task<ActionResult<RecipeDto>> GetNext([FromQuery] string sessionId, [FromQuery] string lang = "sv")
    {
        // ...
    }
}
```

### Models
```csharp
// Biine.API/Models/Recipe.cs
namespace Biine.API.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];  // Npgsql array support
    // Bilingual fields: *Sv and *En suffix
}
```

### AppDbContext
```csharp
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Interaction> Interactions => Set<Interaction>();
    public DbSet<Translation> Translations => Set<Translation>();
}
```

### Naming
- Controllers: `PascalCase` + `Controller` suffix
- Models: `PascalCase`, singular (Recipe not Recipes)
- Properties: `PascalCase`
- DTOs: `RecipeDto`, `RestaurantDto` — suffix with `Dto`
- Migrations: auto-generated names are fine

## TypeScript / Frontend

### API Calls
```typescript
const API_URL = import.meta.env.VITE_API_URL;
const sessionId = localStorage.getItem('biine_session_id') ?? generateSessionId();

const recipe = await fetch(`${API_URL}/api/recipes/next?sessionId=${sessionId}&lang=${lang}`)
  .then(r => r.json());
```

### Session ID Generation
```typescript
function generateSessionId(): string {
  const id = crypto.randomUUID();
  localStorage.setItem('biine_session_id', id);
  return id;
}
```

### Component Naming
- React components: `PascalCase.jsx` (JSX, not TSX for simplicity)
- Astro pages: `lowercase.astro`
- All Islands must have `client:load` or `client:visible` directive

## Git

- Commit messages: `type(phase): description`
  - Types: `feat`, `fix`, `docs`, `chore`, `refactor`
  - Example: `feat(01): add Recipe and Restaurant models`
- One commit per plan execution

## Environment Variables

### Backend
- Never commit `appsettings.Development.json` with real values
- Use `dotnet user-secrets` for local dev
- Variable names: `ConnectionStrings:DefaultConnection`, `GooglePlaces:ApiKey`

### Frontend
- `.env` file with `VITE_API_URL=http://localhost:5000` for local dev
- Never commit `.env`
- Vercel env vars set in dashboard for production
