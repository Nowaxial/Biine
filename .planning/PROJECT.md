# Biine — Project Overview

## What We're Building

**Biine** ("bye-neen") is a Tinder-like dating app for food. Recipes are presented as playful "food personas." Swiping right triggers a match — the user then chooses: **Cook at home** (full recipe reveal) or **Eat out** (show a matching local restaurant in Göteborg).

**Tagline:** "Where Bite meets Dine."

## Core Thesis

Validate the **"swipe → match → choose"** funnel. Does the food persona engagement model work? Do users prefer cooking or eating out? Answer that with MVP data before building more.

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Astro (SSG/SSR) + React Islands |
| Styling | Mantine UI |
| PWA | Vite PWA plugin |
| Backend | ASP.NET Core 10 Web API |
| ORM | Entity Framework Core (Code First) |
| Database | PostgreSQL on Neon |
| Hosting | Vercel (Frontend) + Render (Backend) |
| Language | TypeScript (Frontend) + C# (Backend) |

## External Services

| Service | Purpose |
|---------|---------|
| Neon | PostgreSQL hosting (free tier) |
| Google Places API | Restaurant seeding for Göteborg |
| Unsplash | Free recipe images |

## Key Constraints

- **No user accounts** — anonymous sessions via localStorage
- **No real-time** — simple REST API, no WebSockets
- **Mobile-first** — PWA, looks native on phone
- **Göteborg-specific** — restaurants seeded for Göteborg only (MVP)
- **25 recipes minimum** for MVP launch (24 exist in PRD)
- **Bilingual** — Swedish (default) and English

## Data Model (Summary)

- **Recipes** — name, persona texts (sv/en), ingredients (sv/en), instructions, cookingTime, difficulty, cuisine, tags, imageUrl
- **Restaurants** — name, address, cuisine, priceLevel, rating, googlePlaceId, googleMapsUrl, lat, lng
- **Interactions** — sessionId, recipeId, action (like/pass), decision (cook/eat_out)
- **Translations** — key, textSv, textEn (UI strings)

## API Endpoints

| Method | Path | Purpose |
|--------|------|---------|
| GET | /api/recipes/next | Next unseen recipe for session |
| GET | /api/restaurants/match | Random restaurant by cuisine |
| POST | /api/interactions | Log swipe (like/pass) |
| POST | /api/decisions | Log choice (cook/eat_out) |

## Milestone 1 Goal

**A working end-to-end Biine MVP** — backend API with data + frontend swipe experience — that can be demo'd on a phone and used to validate the funnel.
