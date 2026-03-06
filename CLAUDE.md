# Biine — Claude Instructions

## Project

**Biine** is a Tinder-for-food PWA. Backend: ASP.NET Core 10 Web API. Frontend: Astro + React + Mantine UI. Database: PostgreSQL on Neon via EF Core.

## Key Conventions

### Backend (C#)
- Use `[ApiController]` attribute + `ControllerBase` for all controllers
- EF Core Code First — models in `Biine.API/Models/`, context in `Biine.API/Data/AppDbContext.cs`
- Use `Npgsql.EntityFrameworkCore.PostgreSQL` provider
- Secrets via `dotnet user-secrets` locally, never committed
- Swagger auto-discovered via `AddControllers()` + `MapControllers()`
- Return types: `ActionResult<T>` for typed responses
- Use `string[]` for Tags column (EF Core array support with Npgsql)
- Use `JsonDocument` or `string` for JSONB columns (ingredients)

### Frontend (TypeScript / Astro)
- Astro pages in `src/pages/`, layouts in `src/layouts/`
- React components (Islands) in `src/components/`
- Mantine UI for ALL styling — no raw CSS unless unavoidable
- Mobile-first: test at 375px width
- Session ID: generate UUID in client JS, store in `localStorage` as `biine_session_id`

### API Integration
- Frontend calls backend at `VITE_API_URL` env var
- All fetch calls include `?sessionId=xxx&lang=sv` (or `en`)
- Handle 429 (rate limit) and network errors gracefully

### Language
- Default: Swedish (`sv`)
- All recipe content has `Sv` and `En` variants
- UI strings come from `/api/translations` or are hardcoded in both languages

## File Structure

```
Biine/
├── .planning/           # GSD planning files
├── Biine.API/           # ASP.NET Core backend
│   ├── Controllers/     # API controllers
│   ├── Data/            # AppDbContext
│   ├── Models/          # EF Core entities
│   └── Program.cs
└── biine-web/           # Astro frontend (to be created)
    ├── src/
    │   ├── components/  # React islands
    │   ├── pages/
    │   └── layouts/
    └── public/
```

## Do Not

- Do not add user authentication (not in MVP scope)
- Do not add geolocation (not in MVP scope)
- Do not add push notifications (not in MVP scope)
- Do not store personal data — session IDs only
- Do not commit `.env` files or `appsettings.Development.json` with real secrets
- Do not use Supabase client SDK — use direct EF Core + Npgsql connection to Neon
