# Project Structure

## Current State

```
Biine/
├── .planning/                    # GSD planning files
│   ├── PROJECT.md
│   ├── ROADMAP.md
│   ├── STATE.md
│   ├── codebase/
│   │   ├── STACK.md
│   │   ├── STRUCTURE.md
│   │   ├── ARCHITECTURE.md
│   │   └── CONVENTIONS.md
│   └── phases/
├── Biine.API/                    # ASP.NET Core 10 backend
│   ├── Controllers/              # Empty — to be created
│   ├── Data/
│   │   └── AppDbContext.cs       # EF Core context (stub)
│   ├── Models/                   # To be created
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Biine.API.csproj
│   └── Program.cs
├── biine-web/                    # Astro frontend — TO BE CREATED
│   ├── src/
│   │   ├── components/           # React Islands
│   │   ├── pages/
│   │   └── layouts/
│   └── public/
├── Biine.slnx                   # .NET solution
├── CLAUDE.md
└── PRD.md
```

## Planned Backend Structure

```
Biine.API/
├── Controllers/
│   ├── RecipesController.cs
│   ├── RestaurantsController.cs
│   ├── InteractionsController.cs
│   ├── DecisionsController.cs
│   └── TranslationsController.cs
├── Data/
│   └── AppDbContext.cs           # With DbSets for all models
├── Models/
│   ├── Recipe.cs
│   ├── Restaurant.cs
│   ├── Interaction.cs
│   └── Translation.cs
├── Migrations/
│   └── [auto-generated]
├── Seeders/
│   ├── RecipeSeedData.cs
│   └── RestaurantSeeder.cs       # Google Places fetcher
└── Program.cs
```

## Planned Frontend Structure

```
biine-web/
├── src/
│   ├── components/
│   │   ├── SwipeIsland.jsx       # Main React island
│   │   ├── RecipeCard.jsx        # Single recipe card
│   │   ├── MatchModal.jsx        # Match popup
│   │   ├── RecipeReveal.jsx      # Cook at home view
│   │   ├── RestaurantCard.jsx    # Eat out view
│   │   └── OnboardingOverlay.jsx # 3-slide intro
│   ├── pages/
│   │   └── index.astro           # Entry point
│   ├── layouts/
│   │   └── Layout.astro
│   └── env.d.ts
├── public/
│   ├── icon-192.png
│   └── icon-512.png
├── astro.config.mjs
├── package.json
└── .env                          # VITE_API_URL (never commit)
```
