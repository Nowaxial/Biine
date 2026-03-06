# Biine — Milestone 1 Roadmap

## Milestone Goal

**Ship a working Biine MVP** that can be demo'd on a mobile browser:
- Swipe through food personas
- Match → choose cook or eat out
- Recipe reveal with ingredients + instructions
- Restaurant card with Google Maps link
- Anonymous session tracking for analytics

---

## Phase Overview

| # | Phase | Focus | Status |
|---|-------|-------|--------|
| 01 | Backend Foundation | EF Core models, migrations, DB schema | ✅ Complete |
| 02 | Backend API | All 4 API endpoints with business logic | ✅ Complete |
| 03 | Restaurant Seeder | Google Places → PostgreSQL seed script | ✅ Complete |
| 04 | Frontend Shell | Astro + Mantine + PWA scaffold | ✅ Complete |
| 05 | Swipe Deck | react-tinder-card + recipe fetch + session | Planned |
| 06 | Match Flow | Match modal + recipe reveal + restaurant card | Planned |
| 07 | Polish & Deploy | Bilingual UI, error states, deploy Vercel + Render | Planned |

---

## Phase Details

### Phase 01: Backend Foundation

**Goal:** Database schema deployed to Neon with all models and seed data.

**Requirements:** FOUND-01, FOUND-02, FOUND-03, FOUND-04

**Plans:** 2 plans

Plans:
- [x] 01-01-PLAN.md — EF Core models (Recipe, Restaurant, Interaction, Translation)
- [x] 01-02-PLAN.md — EF migration + Neon deploy + recipe seed data (25 recipes)

---

### Phase 02: Backend API

**Goal:** All 4 API endpoints functional with correct business logic, tested via Swagger.

**Requirements:** API-01, API-02, API-03, API-04, API-05

**Plans:** 2 plans

Plans:
- [x] 02-01-PLAN.md — RecipesController + InteractionsController + DecisionsController
- [x] 02-02-PLAN.md — RestaurantsController + TranslationsController + CORS + rate limiting

---

### Phase 03: Restaurant Seeder

**Goal:** 30+ Göteborg restaurants seeded across 11 cuisines into the database.

**Requirements:** SEED-01, SEED-02

**Plans:** 1 plan

Plans:
- [x] 03-01-PLAN.md — Google Places seeder script (dotnet run seeder, cuisines list) — 42 restaurants seeded

---

### Phase 04: Frontend Shell

**Goal:** Astro project with Mantine, PWA manifest, onboarding overlay scaffolded.

**Requirements:** FE-01, FE-02, FE-03

**Plans:** 2 plans

Plans:
- [x] 04-01-PLAN.md — Astro init + Mantine + React integration + PWA plugin
- [x] 04-02-PLAN.md — Onboarding overlay (3 slides, skip button, localStorage flag)

---

### Phase 05: Swipe Deck

**Goal:** Working swipe deck that fetches recipes and logs interactions.

**Requirements:** SWIPE-01, SWIPE-02, SWIPE-03

**Plans:** 2 plans

Plans:
- [ ] 05-01-PLAN.md — SwipeIsland.jsx with react-tinder-card + session ID generation
- [ ] 05-02-PLAN.md — Recipe card UI (persona text, image, tags) + POST /api/interactions

---

### Phase 06: Match Flow

**Goal:** Full match → choice → reveal flow working end-to-end.

**Requirements:** MATCH-01, MATCH-02, MATCH-03, MATCH-04

**Plans:** 2 plans

Plans:
- [ ] 06-01-PLAN.md — Match modal + "Cook at Home" recipe reveal component
- [ ] 06-02-PLAN.md — "Eat Out" restaurant card + POST /api/decisions + "Keep Swiping"

---

### Phase 07: Polish & Deploy

**Goal:** Bilingual UI, error states handled, app deployed and accessible on mobile.

**Requirements:** POLISH-01, POLISH-02, DEPLOY-01, DEPLOY-02

**Plans:** 3 plans

Plans:
- [ ] 07-01-PLAN.md — Language toggle (sv/en), Translation table UI integration
- [ ] 07-02-PLAN.md — Error states (no recipes, no restaurants, API error)
- [ ] 07-03-PLAN.md — Deploy backend to Render, frontend to Vercel, smoke test

---

## Requirement Registry

### Foundation
- **FOUND-01** — Recipe model with all PRD fields (bilingual)
- **FOUND-02** — Restaurant model with Google Places fields
- **FOUND-03** — Interaction model (sessionId, recipeId, action, decision)
- **FOUND-04** — Translation model (key, sv, en)

### API
- **API-01** — GET /api/recipes/next returns next unseen recipe for session
- **API-02** — GET /api/restaurants/match returns random restaurant by cuisine
- **API-03** — POST /api/interactions logs swipe action
- **API-04** — POST /api/decisions logs cook/eat_out choice
- **API-05** — CORS configured for frontend domain

### Seeding
- **SEED-01** — 25+ recipes seeded with persona texts (sv+en), images
- **SEED-02** — 30+ Göteborg restaurants seeded across 11 cuisines

### Frontend
- **FE-01** — Astro project with Mantine UI and React Islands
- **FE-02** — PWA manifest + app icon + standalone display
- **FE-03** — Onboarding overlay (3 slides, skip, localStorage flag)

### Swipe
- **SWIPE-01** — Session ID generated on first visit, stored in localStorage
- **SWIPE-02** — Swipe deck fetches recipes, shows one at a time
- **SWIPE-03** — Swipe left/right gesture works on mobile

### Match
- **MATCH-01** — Swipe right triggers match modal
- **MATCH-02** — "Cook at Home" reveals recipe with ingredients + instructions
- **MATCH-03** — "Eat Out" shows restaurant card with Maps link
- **MATCH-04** — "Keep Swiping" returns to deck, same recipe not shown again

### Polish
- **POLISH-01** — Bilingual: Swedish default, English toggle
- **POLISH-02** — Error states: no recipes, no restaurants, API error
- **DEPLOY-01** — Backend live on Render with Neon DB
- **DEPLOY-02** — Frontend live on Vercel, PWA installable on mobile
