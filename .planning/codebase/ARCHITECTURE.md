# Architecture

## System Overview

```
[Mobile Browser / PWA]
       |
       | HTTPS
       v
[Vercel CDN — Astro SSG]
       |
       | REST API calls (VITE_API_URL)
       v
[Render — ASP.NET Core 10]
       |
       | EF Core / Npgsql
       v
[Neon — PostgreSQL 16]

                    [Google Places API]
                           ^
                           | (seeder only)
                    [dotnet run seeder]
```

## Key Architecture Decisions

### Session Tracking (No Auth)
- Session ID = UUID generated client-side on first visit
- Stored in `localStorage` as `biine_session_id`
- Passed on every API call: `?sessionId=xxx`
- Used to prevent showing same recipe twice
- No server-side sessions, no cookies, no auth

### Recipe Filtering Logic
- `GET /api/recipes/next` checks Interactions table for current sessionId
- Returns random recipe WHERE RecipeId NOT IN (swiped recipes for this session)
- Returns 204 No Content when all recipes swiped

### Restaurant Lookup
- Restaurants pre-seeded from Google Places API (batch, not real-time)
- `GET /api/restaurants/match?cuisine=Italian` returns random restaurant by cuisine
- Open/Closed status: NOTE — PRD says fetch live from Google, but MVP may skip this for simplicity

### Bilingual Content Strategy
- All recipe content has `Sv` and `En` columns in DB
- `lang` query param determines which fields are returned
- API returns single-language response based on `lang` param
- Frontend passes `lang` based on user preference (default `sv`)

### Rate Limiting
- 100 requests/minute per session ID
- Implemented as ASP.NET Core middleware
- 429 response with `X-RateLimit-Limit` and `X-RateLimit-Remaining` headers

### CORS
- Backend allows requests from Vercel frontend domain
- Configured in `Program.cs` with `app.UseCors()`

## Data Flow: Swipe Right → Match → Cook

```
1. User swipes right on "Carbonara" card
2. SwipeIsland.jsx calls POST /api/interactions
   Body: { sessionId, recipeId: 1, action: "like" }
3. API saves Interaction record
4. Client shows MatchModal
5. User clicks "Cook at Home"
6. Client calls POST /api/decisions
   Body: { sessionId, recipeId: 1, decision: "cook" }
7. API updates Interaction.Decision = "cook"
8. RecipeReveal component shows full recipe data
   (already in memory from the recipe card)
```

## Data Flow: Swipe Right → Match → Eat Out

```
1-4. Same as above
5. User clicks "Eat Out"
6. Client calls GET /api/restaurants/match?cuisine=Italian
7. API returns random Italian restaurant
8. Client calls POST /api/decisions
   Body: { sessionId, recipeId: 1, decision: "eat_out" }
9. RestaurantCard shows restaurant with Google Maps link
```
