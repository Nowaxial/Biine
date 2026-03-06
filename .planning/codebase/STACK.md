# Tech Stack

## Backend

| Item | Value |
|------|-------|
| Framework | ASP.NET Core 10 Web API |
| Language | C# 13 |
| ORM | Entity Framework Core 10 |
| DB Provider | Npgsql.EntityFrameworkCore.PostgreSQL 10.0.0 |
| API Docs | Swashbuckle.AspNetCore 10.1.4 |
| Secrets | dotnet user-secrets (local), Render env vars (prod) |

## Frontend

| Item | Value |
|------|-------|
| Framework | Astro (to be initialized) |
| UI Lib | Mantine UI |
| Islands | React |
| Swipe | react-tinder-card |
| PWA | @vite-pwa/astro |
| Language | TypeScript |

## Database

| Item | Value |
|------|-------|
| Provider | Neon (neon.tech) |
| Engine | PostgreSQL 16 |
| Connection | Pooled connection string (port 5432) |
| SSL | ?sslmode=require |

## Hosting

| Layer | Platform |
|-------|---------|
| Frontend | Vercel |
| Backend | Render |
| Database | Neon |

## External APIs

| Service | Key Needed | Purpose |
|---------|-----------|---------|
| Google Places API | Yes (GOOGLE_PLACES_API_KEY) | Restaurant seeding |
| Unsplash | No (free URLs) | Recipe images |
