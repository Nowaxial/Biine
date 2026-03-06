# Product Requirements Document (PRD): Biine

## 1. Project Overview

**Name:** Biine  
**Project Name:** biine  
**Concept:** A "Tinder-like" dating app for food. Recipes are presented as "personas" with playful descriptions. A match gives the user a choice: "Cook at Home" (view recipe) or "Eat Out" (find similar local restaurants).  
**Target Audience:** Young adults/foodies in Göteborg who struggle with "what to eat" decisions.  
**Primary Goal:** MVP to validate the "recipe-to-restaurant" funnel and the "food persona" engagement model.

---

## 2. Brand Summary

**Name:** Biine  
**Pronunciation:** "bye-neen"

**Brand Story:**
> "Where *Bite* meets *Dine*."

It's a fusion — the moment your appetite (bite) meets your decision (dine). The double "i" represents the two paths: cook at home, or eat out.

**Why it works:**
- **5 characters** — ultra-short, app-icon friendly
- **Invented word** — ownable trademark, no competing SEO
- **Phonetically smooth** — rolls off the tongue
- **Double "ii"** — visually distinctive, memorable pattern

**Tagline Options:**
1. "Where Bite meets Dine"
2. "Cook it or book it"
3. "Your next meal, decided"

---

## 2.1 Visual Identity

**App Icon:** To be created
- Minimal, clean, memorable design
- Reflects "Biine" (bite + dine fusion) concept
- Double "ii" as potential visual element
- Warm, appetizing colors
- Food-related but playful, not literal food photos

**Color Palette:** To be defined
- Primary: Warm food tones (orange, coral, warm red)
- Accent: Playful contrast color
- Background: Clean white/light for readability

**Typography:** Mantine UI default (clean, modern)

**Inspiration:** Tinder flame, food delivery apps (Uber Eats, Wolt), dating apps

---

## 3. Tech Stack & Architecture

**Frontend:** Astro (SSG/SSR) + React (Islands for swipe logic)  
**Styling:** Mantine UI  
**PWA:** Vite PWA plugin (Zero-config strategy)  
**Backend:** ASP.NET Core 10 Web API with Swagger  
**Database:** PostgreSQL (hosted on Neon)  
**ORM:** Entity Framework Core  
**Hosting:** Vercel (Frontend), Render (Backend)  
**Language:** TypeScript (Frontend), C# (Backend)

### External Services

| Service | Purpose | Free Tier |
|---------|---------|-----------|
| Neon | PostgreSQL database | 0.5GB storage, 100 CU-hrs/month, no pausing |
| Google Places API | Restaurant data for seeding | 10,000 requests/month (Essentials) |
| Unsplash | Recipe images | Free with attribution |

---

## 4. Core Features (MVP Scope)

> **MVP Principle:** Validate the core "swipe → match → choose" funnel first. No preferences, no auth, no geolocation.

### 4.1 Onboarding (Mobile-First)

**Onboarding Overlay:** 2-3 slides explaining the concept
- Slide 1: "Swipe right to cook at home"
- Slide 2: "Swipe left to find a restaurant"
- Slide 3: "It's a match! Choose your date night"

**Skip Button:** Available for returning users.

**Session:** Generated on first visit, stored in localStorage. Passed to API for interaction tracking.

**Language:**
- Auto-detect browser language (navigator.language)
- Default: Swedish (sv) if detection fails
- Toggle available to switch between Swedish/English
- All content bilingual in database

> **No landing page** — Go straight to swipe deck. Mobile users want immediate value.

### 4.2 The "Dating" Deck (Swipe Interface)

**Component:** SwipeIsland.jsx (React)  
**UI:** Card stack

**Content per Card:**
- **Persona Text:** Creative description (e.g., "I'm cheesy, warm, and Italian. I promise to treat you right tonight.")
- **Visuals:** Abstract or blurred food image (optional), emphasizing text first
- **Tags:** Hidden metadata (e.g., Italian, Comfort Food, Pasta)

**Interaction:**
- Swipe Right (Like) → Triggers Match Logic
- Swipe Left (Pass) → Show next card

### 4.3 The Match & Decision Flow

**Trigger:** Every swipe right triggers a "It's a Match!" modal.

**Decision Modal:**
- **Option A:** "My Place?" (Cook at home) → Reveal full recipe, ingredients, instructions
- **Option B:** "Your Place?" (Eat out) → Show 1 random restaurant matching the recipe's Cuisine

**Restaurant Card Display:**
- Name, Address, Cuisine
- Price Level ($ - $$$$)
- Rating (★ 4.5)
- Open/Closed status
- Tap opens Google Maps

**Recipe Display:**
- Recipe name
- Persona text (reminds why they matched)
- Cooking time + Difficulty
- Ingredients with checkboxes
- Numbered instructions

**After Viewing:**
- User sees "Keep Swiping" button
- Returns to deck for next card
- Same recipe won't appear twice (tracked in Interactions)

**End of Deck:**
- Show "That's all for now!" message
- Option to restart or come back later

**Tracking:**
- All swipes logged (like/pass) in Interactions table
- Decision (cook vs. eat out) logged for analytics

### 4.4 Error States

| Scenario | User Message | Action |
|----------|--------------|--------|
| **No more recipes** | "That's all for now! Come back tomorrow for fresh picks." | Show restart button |
| **No restaurants found** | "No [Cuisine] spots nearby. How about cooking instead?" | Show recipe as fallback |
| **API error** | "Oops! Something went wrong. Try again?" | Retry button |

### 4.5 Analytics (MVP)

**Goal:** Validate the "swipe → match → choose" funnel.

**Metrics to Track:**

| Metric | Why |
|--------|-----|
| **Total swipes** | Engagement |
| **Like %** | % right swipes — recipe appeal |
| **Decision split** | Cook vs. Eat Out |
| **Sessions per user** | Retention |

**Data Logged:**

| Table | What's Stored |
|-------|---------------|
| Interactions | sessionId, recipeId, action (like/pass), decision (cook/eat_out) |

> **No dashboard needed.** Query Supabase directly for MVP metrics.

---

## 5. Data Model (Schema)

### Recipes Table

| Column | Type | Description |
|--------|------|-------------|
| Id | int | PK |
| Name | string | e.g., "Carbonara" |
| PersonaTextSv | string | Swedish persona text (TBD) |
| PersonaTextEn | string | English persona text |
| IngredientsSv | jsonb | Swedish ingredients (TBD) |
| IngredientsEn | jsonb | English ingredients |
| InstructionsSv | text | Swedish instructions (TBD) |
| InstructionsEn | text | English instructions |
| CookingTime | int | Minutes |
| Difficulty | string | Easy/Medium/Hard |
| Cuisine | string | e.g., "Italian" |
| Tags | string[] | e.g., ["Pasta", "Cheesy", "Quick"] |
| ImageUrl | string | URL to image (Unsplash) |

### Restaurants Table

| Column | Type | Description |
|--------|------|-------------|
| Id | int | PK |
| Name | string | Name of the place |
| Address | string | Local address in Göteborg |
| Cuisine | string | Matches Recipe Cuisine |
| PriceLevel | int | 1-4 ($ to $$$$) |
| Rating | decimal | Google rating (0-5) |
| GooglePlaceId | string | Google Places reference ID |
| GoogleMapsUrl | string | Deep link |
| Lat | decimal | Latitude |
| Lng | decimal | Longitude |
| LastUpdated | DateTime | When data was fetched from Google |

### Translations Table

| Column | Type | Description |
|--------|------|-------------|
| Id | int | PK |
| Key | string | Unique key (e.g., "onboarding.slide1") |
| TextSv | string | Swedish text |
| TextEn | string | English text |

> **Note:** Stores all UI text (buttons, labels, error messages) in both languages.

### Interactions Table

| Column | Type | Description |
|--------|------|-------------|
| Id | int | PK |
| SessionId | string | From localStorage |
| RecipeId | int | FK to Recipes |
| Action | string | "like" or "pass" |
| Decision | string | null, "cook", or "eat_out" (filled after like) |
| CreatedAt | DateTime | Timestamp |

---

## 6. Data Seeding (MVP)

### Recipes
Target: 65+ recipes (minimum 5 per cuisine), hand-written. Use free Unsplash URLs for images.

> **Current:** 24 recipes. **MVP target:** 25 recipes. **Future:** 65+ recipes.

### Recipe Persona Templates

Randomly select from these 5 templates:

| # | Template | Example |
|---|----------|---------|
| 1 | "I'm [adjective], [adjective], and [cuisine]. I [promise/will] [something]." | "I'm cheesy, warm, and Italian. I promise to treat you right tonight." |
| 2 | "Looking for someone who [preference]. Must love [ingredient/vibe]. [Cuisine] is my love language." | "Looking for someone who takes it slow. Must love slow Sundays. Comfort food is my love language." |
| 3 | "I’m [adjective] but can be [adjective] if you’re lucky. [Cuisine] enthusiast. [Flavor] enthusiast. You?" | "I'm chill but can be spicy if you're lucky. Thai enthusiast. Garlic enthusiast. You?" |
| 4 | "Perfect for [situation]. Won’t judge if you [guilty pleasure]. [Cuisine] for the soul." | "Perfect for movie night. Won't judge if you eat the whole thing. Mexican for the soul." |
| 5 | "Not to be dramatic, but I’m the [compliment]. [Cuisine]. Best paired with [pairing]." | "Not to be dramatic, but I'm the whole vibe. Japanese. Best paired with sake and good company." |

### Recipe Personas (20)

| # | Recipe | Cuisine | Persona Text |
|---|--------|---------|---------------|
| 1 | Carbonara | Italian | "I'm creamy, comforting, and unforgiving to cheaters. Roman born, hearts broken. Tagliatelle is my love language — and yes, I judge if you add cream." |
| 2 | Tacos al Pastor | Mexican | "Looking for someone who can handle heat. I’m sweet, spicy, and pineapple’d. Best enjoyed standing up, watching the sunset. No quitters." |
| 3 | Pad Thai | Thai | "I'm that friend who’s always balanced — sweet, sour, tangy, and a little sassy. Peanuts are my love language. Will ruin other Thai for you forever." |
| 4 | Butter Chicken | Indian | "Rich, velvety, and not afraid of commitment. I’m mild but can go spicy if you earn it. Garam masala? More like full-body aroma. Come with naan, stay forever." |
| 5 | Sushi Roll | Japanese | "Elegant, precise, and a little mysterious. I’m cold on the outside but warm inside. Wasabi is just my sense of humor. Serious about freshness, casual about vibes." |
| 6 | Burger | American | "Classic, no drama. I’m the whole package — patty, cheese, pickle, drama. Best with fries on the side and no questions asked. Thick, juicy, reliable." |
| 7 | Pho | Vietnamese | "Complex, aromatic, and worth the wait. I take 8 hours to make and 10 minutes to fall in love with. Herbs are my personality. Comfort in a bowl." |
| 8 | Gyros | Greek | "Mediterranean charm with tzatziki swagger. I’m stacked, seasoned, and served with warmth. Pita not required but recommended. Feta is my love language." |
| 9 | Pizza Margherita | Italian | "Simple, iconic, and will never let you down. I’m red, white, green, and clean. Naples taught me less is more. Basilic baskid." |
| 10 | Ramen | Japanese | "I’m moody, soulful, and deep. The kind of love story that starts with hunger and ends with contentment. Soft egg optional but appreciated. Slurp responsibly." |
| 11 | Enchiladas | Mexican | "Wrapped up tight and full of surprises. I’m saucy, cheesy, and heat is my personality. Don’t unwrap until you’re ready for commitment. Rice and beans forever." |
| 12 | Tikka Masala | Indian | "Britain’s favorite, born from love across cultures. I’m creamy, aromatic, and always a good idea. Naan is my wingman. Dinner and a movie? I'll bring the flavor." |
| 13 | Dumplings | Chinese | "Small, sweet, and full of secrets. I’m steamed, pan-fried, or both. Dip me in sauce and watch sparks fly. One bite, and you’re mine." |
| 14 | Schnitzel | German | "Crispy, golden, and no-nonsense. I’m the tall, dark stranger of the meat world. Hammered flat for maximum reach. Potatoes welcome, optional." |
| 15 | Currywurst | German | "Berlin street food legend. I’m saucy, satisfying, and don’t care about your plans. Curried sausage? More like curried feelings. Best after midnight or a night out." |
| 16 | Falafel | Middle Eastern | "Crispy on the outside, herbaceous on the inside. I’m vegetarian but can seduce anyone. Tahini is my perfume. Mediterranean vibes only." |
| 17 | Bibimbap | Korean | "Colorful, creative, and mixed for a reason. I’m everything in one bowl — sweet, spicy, savory, fresh. Put your egg on top and watch magic happen." |
| 18 | Lasagna | Italian | "Layers. Every one of them meaningful. I’m patient, rich, and worth every minute. No shortcuts, no substitutes. Bechamel doesn’t judge." |
| 19 | Chicken Wings | American | "Messy, addictive, and always the life of the party. Buffalo is my middle name. Sauce everywhere, joy in my heart. Watch the game, eat the wings." |
| 20 | Poke Bowl | Hawaiian | "Fresh, cool, and low-key romantic. I'm the slow Sunday morning of food. Ahi tuna, rice, and vibes. No cooking required, just vibes." |
| 21 | Köttbullar | Swedish | "Meaty, comforting, and ready to mingle with lingonberry. I'm the IKEA trip you didn't know you needed. Fry up some potatoes, we're doing this Swedish style." |
| 22 | Smörgåstårta | Swedish | "Layers of carbs, carbs, and more carbs with mayo in between. I'm the sandwich cake that judges your diet. Birthday parties and summer lunches are." |
| 23 | Köttfarslimpa | Swedish | "Meatloaf the Swedish way — cozy, reliable, and always there for you. Lingonberry on the side, no questions asked. Keso, actually." |
| 24 | Pytt i Panna | Swedish | "Cube-shaped comfort in a pan. I'm potatoes and history — best with a fried egg on top and pickled beets on the side. Retro vibes, modern taste." |

> **Future expansion:** Target 65+ recipes (5+ per cuisine). Cuisines to add: Spanish, French, Brazilian, Ethiopian, Lebanese, Caribbean.

---

### Recipe Persona Topics

| Category | Examples |
|----------|----------|
| **Cuisine** | Italian, Thai, Mexican, Indian, Japanese, American, Swedish |
| **Flavor** | Cheesy, spicy, smoky, creamy, fresh, tangy |
| **Vibe** | Comfort, date night, party, quick, lazy Sunday |
| **Mood** | Romantic, cozy, adventurous, indulgent |
| **Texture** | Crispy, gooey, chewy, melt-in-mouth |
| **Time** | 15-minute miracle vs. Sunday project |
| **Pairings** | Wine, beer, hot sauce, good company |

### Restaurants: Google Places API → Database

**Pattern:** API → Cache in DB (free at MVP scale)

> **Database hosting:** Neon (neon.tech). Free tier. No project pausing. EU region. Pure PostgreSQL — compatible with all existing schema and EF Core setup.

| Step | What happens |
|------|--------------|
| 1. Seed | Call Google Places API for each cuisine → store in PostgreSQL |
| 2. App runs | Queries Supabase (no external API calls) |
| 3. Update | Re-fetch monthly via cron or manual trigger |

**Cuisines to seed (Göteborg):**
- Italian, Japanese, Mexican, Thai, Indian, American, Chinese, Vietnamese, Greek, Turkish, Swedish

**Data fetched from Google Places:**
- Name, address, cuisine type
- Rating, price level
- Google Maps URL
- Coordinates (lat/lng)
- Place ID
- **Open/Closed status** (fetched live per request — not cached)

**Why this approach:**
- Effectively free (under 10k requests/month threshold)
- Full control over data
- Fast for users (query local DB)
- Scalable for growth

### Images
Free stock photos from Unsplash. Store full URLs in database.

---

### Recipe API Opportunity (Future)

**Problem:** Hand-writing 15+ recipe personas takes time.  
**Opportunity:** Pull recipes from external APIs and auto-generate personas.

**Candidates:**

| API | Free Tier | Notes |
|-----|-----------|-------|
| TheMealDB | Unlimited | 1000+ recipes, simple |
| Spoonacular | 150/day | Rich data, ingredients |
| Tasty (RapidAPI) | Limited | BuzzFeed recipes |

**Potential workflow:**
1. Fetch restaurant cuisines from Google Places
2. Query recipe API for popular dishes by cuisine
3. Auto-generate persona text from recipe metadata
4. Store in local DB

**MVP Decision:** Skip for now. Hand-written personas are higher quality and more "on-brand."

---

## 7. API Endpoints (ASP.NET Core)

### GET /api/recipes/next

**Query Params:** `?sessionId=abc123&lang=sv`  
- sessionId: required
- lang: optional (defaults to browser language detection)
- Supported: sv (Swedish), en (English)

**Response:** JSON object of the next card to show (persona, ingredients, instructions in requested language)  
**Logic:** Randomly select a recipe not yet swiped by this session.

### GET /api/restaurants/match

**Query Params:** `?cuisine=Italian`  
**Response:** JSON object of 1 random restaurant matching the cuisine. Open/Closed status fetched live from Google Places API (not cached).

### POST /api/interactions

**Body:** `{ "sessionId": "abc123", "recipeId": 1, "action": "like" | "pass" }`  
**Purpose:** Track swipes to avoid showing same recipe twice.

### POST /api/decisions

**Body:** `{ "sessionId": "abc123", "recipeId": 1, "decision": "cook" | "eat_out" }`  
**Purpose:** Log user choice (cook at home vs eat out) for analytics.

---

## 8. Non-Functional Requirements

**Performance:** The swipe deck must load instantly (Astro Islands)  
**Mobile-First:** UI must look native on mobile (PWA manifest included)  
**Security:**
- CORS configured for frontend domain
- Input validation on all API endpoints
- Sanitized database queries (EF Core handles this)
- No personal data stored — session IDs only

**Privacy (GDPR):**
- No user accounts required
- Session IDs stored in localStorage (random, not personally identifiable)
- No cross-device tracking
- Swipe data is anonymous
- Simple privacy notice: "Biine stores your session locally. Swipe data is anonymous and used only to improve your experience."

**PWA (Progressive Web App):**
- Vite PWA plugin (zero-config)
- Add to home screen capability
- Offline mode: Not required for MVP (cache recipe images only)
- Push notifications: Not for MVP
- App icon and splash screen
- Standalone display (looks like native app)

**Rate Limiting:**
- 100 requests/minute per session
- Implemented via ASP.NET Core middleware
- Response: 429 Too Many Requests when exceeded
- Headers include: X-RateLimit-Limit, X-RateLimit-Remaining

**Environment Variables (never committed to repo):**
- DATABASE_URL — Neon PostgreSQL connection string (pooled)
- GOOGLE_PLACES_API_KEY — For restaurant seeding
- Stored in:
  - **Local dev:** .NET User Secrets (`dotnet user-secrets`) — never touches the repo
  - **Production:** Render environment variables

**User Secrets setup (local dev):**
```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your-neon-connection-string"
dotnet user-secrets set "GooglePlaces:ApiKey" "your-google-api-key"
```
> User Secrets are stored in `%APPDATA%\Microsoft\UserSecrets\` on Windows — outside the project folder entirely.

---

## 9. Development Phases (Roadmap)

| Phase | Focus |
|-------|-------|
| **Phase 1** | Backend Skeleton: Set up .NET solution, EF Core, Supabase connection. Create models. |
| **Phase 1b** | Google Places Seeder: Build seed script to fetch Göteborg restaurants by cuisine → store in Supabase. |
| **Phase 2** | Frontend Shell: Initialize Astro + React + Mantine. Build onboarding and swipe deck. |
| **Phase 3** | The Deck: Implement react-tinder-card and fetch logic. |
| **Phase 4** | The Logic: Connect "Like" action to "Match Modal" and Restaurant lookup. |
| **Phase 5** | Polish: Add PWA config, icons, and creative copy for the first 10 recipes. |

---

## 10. Instructions for AI Assistant

Use this context when generating code:

> "We are building Biine, a PWA using Astro and React for the frontend, and .NET 10 Web API for the backend. The database is PostgreSQL on Supabase."

> "Use Mantine UI for styling. Focus on mobile-first, responsive components."

> "Use ASP.NET Core Controllers with the [ApiController] attribute. Each resource (Recipes, Restaurants, Interactions, Decisions) gets its own controller class inheriting from ControllerBase. Swagger auto-discovers all endpoints via AddControllers() and MapControllers() in Program.cs."

> "When defining the database, use Entity Framework Core Code First approach."

> "For restaurant data, fetch from Google Places API and cache in Supabase. The seeder should query by cuisine and location (Göteborg)."

> "Use Npgsql.EntityFrameworkCore.PostgreSQL for EF Core + Neon. Use the pooled connection string from the Neon dashboard (port 5432, with ?sslmode=require appended)."
