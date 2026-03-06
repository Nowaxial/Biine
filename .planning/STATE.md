# Project State

## Current Milestone

**Milestone 1:** Biine MVP — end-to-end working app

## Current Position

**Phase:** 03 — Restaurant Seeder  
**Status:** Phases 01 + 02 complete. Ready to execute Phase 03.

## What Exists

### Backend (Biine.API)
- .NET 10 Web API project scaffolded
- `AppDbContext` with all 4 DbSets + `OnModelCreating` (JSONB, decimal precision, FK, seed data)
- `Program.cs` with EF Core + Swagger + Npgsql wired up
- Models: `Recipe`, `Restaurant`, `Interaction`, `Translation`
- Seeders: `RecipeSeedData` (25 recipes), `TranslationSeedData` (28 UI strings)
- Migration: `InitialCreate` applied
- Controllers: `RecipesController`, `InteractionsController`, `DecisionsController`, `RestaurantsController`, `TranslationsController`
- CORS configured (`Frontend` policy, localhost:4321 + *.vercel.app)
- Rate limiting: 30 req/min per session (fixed window)
- EF Core retry on failure (3 retries, 5s delay) for Neon cold starts

### Frontend
- Nothing yet

### Database (Neon PostgreSQL)
- ✅ Schema deployed — 5 tables: `Recipes`, `Restaurants`, `Interactions`, `Translations`, `__EFMigrationsHistory`
- ✅ 25 recipes seeded
- ✅ 28 translation strings seeded

## Locked Decisions

| Decision | Value | Reason |
|----------|-------|--------|
| Backend framework | ASP.NET Core 10 Web API | PRD spec |
| ORM | Entity Framework Core Code First | PRD spec |
| Database | PostgreSQL on Neon | PRD spec |
| Frontend | Astro + React Islands | PRD spec |
| Styling | Mantine UI | PRD spec |
| PWA | Vite PWA plugin | PRD spec |
| Restaurant source | Google Places API → DB cache | PRD spec |
| Image source | Unsplash free URLs | PRD spec |
| Language default | Swedish (sv) | PRD spec |
| Session tracking | localStorage session ID | PRD spec |
| Hosting | Vercel (FE) + Render (BE) | PRD spec |

## Pending Items

- [ ] Google Places API key in use — verify it works when Restaurant seeder runs (Phase 03)

## Known Issues / Concerns

- LSP errors on `AppDbContext.cs` and `Program.cs` are false positives — `dotnet build` succeeds with 0 errors
- Neon connection string must be in ADO.NET key-value format, not URI format (already corrected in user-secrets)
