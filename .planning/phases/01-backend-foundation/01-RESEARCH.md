# Phase 01 Research: Backend Foundation

## Summary

Everything needed is already in the project. EF Core 10 + Npgsql 10 are installed and `dotnet ef` tools are at 10.0.3. The research confirms patterns, gotchas, and the exact approach for each model.

---

## Standard Stack

| Concern | Choice | Why |
|---------|--------|-----|
| ORM | EF Core 10 Code First | Already installed, PRD spec |
| DB Provider | Npgsql.EntityFrameworkCore.PostgreSQL 10.0.0 | Already in .csproj |
| Array columns | `string[]` with `.HasColumnType("text[]")` | Npgsql native support |
| JSONB columns | `string` property + `.HasColumnType("jsonb")` | Simplest; no JsonDocument overhead |
| Migration | `dotnet ef migrations add` + `dotnet ef database update` | Standard EF Core flow |
| Seed data | `modelBuilder.Entity<T>().HasData(...)` in OnModelCreating | Built-in, no extra libraries |
| Connection | `appsettings.json` key `ConnectionStrings:DefaultConnection` | Already wired in Program.cs |

---

## EF Core 10 + Npgsql Patterns

### string[] Array Support
```csharp
// Model property
public string[] Tags { get; set; } = [];

// OnModelCreating (optional — Npgsql auto-detects)
entity.Property(e => e.Tags).HasColumnType("text[]");
```
Npgsql 10 maps `string[]` to `text[]` automatically. No explicit column type needed unless ambiguous.

### JSONB Columns
```csharp
// Model property — use string for simplicity
public string IngredientsSv { get; set; } = "[]";

// OnModelCreating
entity.Property(e => e.IngredientsSv).HasColumnType("jsonb");
```
Using `string` over `JsonDocument` avoids disposal complexity. Frontend receives raw JSON string — fine for MVP.

### Timestamps
```csharp
public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
```
Always use `DateTime.UtcNow` with PostgreSQL — Npgsql stores as `timestamp with time zone`.

### Decimal Precision (Rating, Lat, Lng)
```csharp
entity.Property(e => e.Rating).HasColumnType("decimal(3,2)");
entity.Property(e => e.Lat).HasColumnType("decimal(10,7)");
entity.Property(e => e.Lng).HasColumnType("decimal(10,7)");
```

---

## Model Design

### Recipe
```csharp
public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PersonaTextSv { get; set; } = string.Empty;
    public string PersonaTextEn { get; set; } = string.Empty;
    public string IngredientsSv { get; set; } = "[]"; // jsonb
    public string IngredientsEn { get; set; } = "[]"; // jsonb
    public string InstructionsSv { get; set; } = string.Empty;
    public string InstructionsEn { get; set; } = string.Empty;
    public int CookingTime { get; set; }
    public string Difficulty { get; set; } = string.Empty; // Easy/Medium/Hard
    public string Cuisine { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public string? ImageUrl { get; set; }
    
    public ICollection<Interaction> Interactions { get; set; } = [];
}
```

### Restaurant
```csharp
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
```

### Interaction
```csharp
public class Interaction
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public string Action { get; set; } = string.Empty; // "like" or "pass"
    public string? Decision { get; set; } // null, "cook", "eat_out"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
```

### Translation
```csharp
public class Translation
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string TextSv { get; set; } = string.Empty;
    public string TextEn { get; set; } = string.Empty;
}
```

---

## AppDbContext Update Pattern
```csharp
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Interaction> Interactions => Set<Interaction>();
    public DbSet<Translation> Translations => Set<Translation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // JSONB columns
        modelBuilder.Entity<Recipe>()
            .Property(r => r.IngredientsSv).HasColumnType("jsonb");
        modelBuilder.Entity<Recipe>()
            .Property(r => r.IngredientsEn).HasColumnType("jsonb");
        
        // Unique constraint on Translation key
        modelBuilder.Entity<Translation>()
            .HasIndex(t => t.Key).IsUnique();
        
        // Decimal precision
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Rating).HasColumnType("decimal(3,2)");
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Lat).HasColumnType("decimal(10,7)");
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Lng).HasColumnType("decimal(10,7)");
        
        // Seed data
        modelBuilder.Entity<Recipe>().HasData(RecipeSeedData.GetRecipes());
        modelBuilder.Entity<Translation>().HasData(TranslationSeedData.GetTranslations());
    }
}
```

---

## Migration Commands

```bash
# Create migration
cd Biine.API
dotnet ef migrations add InitialCreate

# Apply to Neon (requires connection string set in user-secrets)
dotnet ef database update
```

**Verify:** `dotnet build` must pass before `dotnet ef migrations add`.

---

## Seed Data Strategy

**24 recipes exist in PRD** — need 1 more to hit 25.  
Add: **Köttbullar med gräddsås** variant OR a 25th recipe (e.g., **Wonton Soup** Chinese).

**Seed data class pattern:**
```csharp
// Biine.API/Seeders/RecipeSeedData.cs
public static class RecipeSeedData
{
    public static Recipe[] GetRecipes() => [
        new Recipe { Id = 1, Name = "Carbonara", ... },
        // ...
    ];
}
```

**HasData requirement:** All seed entities MUST have explicit `Id` values set. EF Core requires this for `HasData`.

---

## Validation Architecture

### What to test in this phase
Phase 01 is pure data layer — no HTTP endpoints. Verification is:
1. `dotnet build` passes
2. `dotnet ef migrations add InitialCreate` succeeds (generates migration file)
3. `dotnet ef database update` applies to Neon (requires real connection string)
4. SQL: `SELECT COUNT(*) FROM "Recipes"` returns 25
5. SQL: `SELECT COUNT(*) FROM "Translations"` returns expected count

### Automated verification
```bash
dotnet build Biine.API/Biine.API.csproj
```
This is the primary automated gate. Migration and DB commands require user secrets.

---

## Common Pitfalls

| Pitfall | Fix |
|---------|-----|
| `HasData` without explicit `Id` | Always set `Id = N` in seed data |
| DateTime as local time | Use `DateTime.UtcNow` always |
| string[] not mapped | Npgsql auto-detects; no extra config needed |
| Migration fails on JSONB | Ensure `HasColumnType("jsonb")` in OnModelCreating |
| Neon SSL | Connection string must include `?sslmode=require` (or `;SSL Mode=Require`) |
| EF Core tools not found | `dotnet tool install --global dotnet-ef` (already at 10.0.3) |

---

## Don't Hand-Roll

- **No manual SQL** — EF Core migrations handle all schema creation
- **No custom connection pool** — Npgsql + EF Core handles pooling
- **No Dapper** — EF Core only (PRD spec)
- **No Fluent Validation** — simple `[Required]` annotations sufficient for MVP models
