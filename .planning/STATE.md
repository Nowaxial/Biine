# Project State

## Current Milestone

**Milestone 1:** Biine MVP — end-to-end working app

## Current Position

**Phase:** Not started  
**Status:** Planning complete, ready to execute

## What Exists

### Backend (Biine.API)
- .NET 10 Web API project scaffolded
- `AppDbContext` stub (no models yet)
- `Program.cs` with EF Core + Swagger + Npgsql wired up
- NuGet packages: Npgsql.EF, Swashbuckle, Microsoft.AspNetCore.OpenApi
- UserSecretsId configured for local dev secrets
- **No controllers, no models, no migrations**

### Frontend
- Nothing yet

### Database
- Neon account needed (user to set up)
- No schema deployed

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

- [ ] Neon database connection string (user must create Neon project)
- [ ] Google Places API key (user must enable in Google Cloud Console)
- [ ] Unsplash source URLs for recipe images

## Known Issues / Concerns

- EF Core packages installed but `dotnet restore` not run → LSP errors (not a real problem, just needs restore)
- 24 recipes in PRD; MVP target is 25 — 1 more recipe needed in seed data
