# Project State

## Current Milestone

**Milestone 1:** Biine MVP — end-to-end working app

## Current Position

**Phase:** 05 — Swipe Deck  
**Status:** Phases 01–04 complete. Writing plans for Phase 05.

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
- ✅ Biine.WEB/ scaffolded — Astro + React + Mantine v7 + @vite-pwa/astro
- ✅ AppShell.tsx — root island owning MantineProvider (all Mantine children go here)
- ✅ OnboardingOverlay.tsx — 3 slides, skip, localStorage flag (biine_onboarding_done)
- Key pattern: ALL Mantine components must be children of AppShell (not separate client:load islands)

### Database (Neon PostgreSQL)
- ✅ Schema deployed — 5 tables: `Recipes`, `Restaurants`, `Interactions`, `Translations`, `__EFMigrationsHistory`
- ✅ 25 recipes seeded
- ✅ 28 translation strings seeded
- ✅ 42 restaurants seeded (3 × 14 cuisines via Google Places)

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

- [ ] Execute Phase 05: swipe deck with react-tinder-card + recipe card UI + POST /api/interactions

## Known Issues / Concerns

- LSP errors on `AppDbContext.cs` and `Program.cs` are false positives — `dotnet build` succeeds with 0 errors
- Neon connection string must be in ADO.NET key-value format, not URI format (already corrected in user-secrets)
