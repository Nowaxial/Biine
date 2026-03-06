using Biine.API.Models;

namespace Biine.API.Seeders;

public static class TranslationSeedData
{
    public static Translation[] GetTranslations() =>
    [
        // Onboarding
        new Translation { Id = 1, Key = "onboarding.title", TextSv = "Vad är du sugen på?", TextEn = "What are you craving?" },
        new Translation { Id = 2, Key = "onboarding.subtitle", TextSv = "Svajpa för att hitta din match", TextEn = "Swipe to find your match" },
        new Translation { Id = 3, Key = "onboarding.start", TextSv = "Starta", TextEn = "Start" },

        // Swipe actions
        new Translation { Id = 4, Key = "swipe.like", TextSv = "Gillar", TextEn = "Like" },
        new Translation { Id = 5, Key = "swipe.dislike", TextSv = "Inte idag", TextEn = "Not today" },
        new Translation { Id = 6, Key = "swipe.empty", TextSv = "Du har sett allt! Dra nedåt för att börja om.", TextEn = "You've seen it all! Pull down to restart." },

        // Match modal
        new Translation { Id = 7, Key = "match.title", TextSv = "Det är en match!", TextEn = "It's a match!" },
        new Translation { Id = 8, Key = "match.subtitle", TextSv = "Vad vill du göra?", TextEn = "What would you like to do?" },
        new Translation { Id = 9, Key = "match.cook", TextSv = "Laga hemma", TextEn = "Cook at home" },
        new Translation { Id = 10, Key = "match.restaurant", TextSv = "Hitta restaurang", TextEn = "Find a restaurant" },
        new Translation { Id = 11, Key = "match.skip", TextSv = "Fortsätt svajpa", TextEn = "Keep swiping" },

        // Recipe detail
        new Translation { Id = 12, Key = "recipe.ingredients", TextSv = "Ingredienser", TextEn = "Ingredients" },
        new Translation { Id = 13, Key = "recipe.instructions", TextSv = "Instruktioner", TextEn = "Instructions" },
        new Translation { Id = 14, Key = "recipe.cookingTime", TextSv = "Tillagningstid", TextEn = "Cooking time" },
        new Translation { Id = 15, Key = "recipe.difficulty", TextSv = "Svårighetsgrad", TextEn = "Difficulty" },
        new Translation { Id = 16, Key = "recipe.difficulty.easy", TextSv = "Lätt", TextEn = "Easy" },
        new Translation { Id = 17, Key = "recipe.difficulty.medium", TextSv = "Medel", TextEn = "Medium" },
        new Translation { Id = 18, Key = "recipe.difficulty.hard", TextSv = "Svår", TextEn = "Hard" },
        new Translation { Id = 19, Key = "recipe.minutes", TextSv = "min", TextEn = "min" },

        // Restaurant section
        new Translation { Id = 20, Key = "restaurant.title", TextSv = "Restauranger i närheten", TextEn = "Nearby restaurants" },
        new Translation { Id = 21, Key = "restaurant.noResults", TextSv = "Inga restauranger hittades", TextEn = "No restaurants found" },
        new Translation { Id = 22, Key = "restaurant.open", TextSv = "Öppet nu", TextEn = "Open now" },
        new Translation { Id = 23, Key = "restaurant.closed", TextSv = "Stängt", TextEn = "Closed" },

        // Error states
        new Translation { Id = 24, Key = "error.network", TextSv = "Något gick fel. Försök igen.", TextEn = "Something went wrong. Please try again." },
        new Translation { Id = 25, Key = "error.rateLimit", TextSv = "Lugna dig lite! Vänta en stund.", TextEn = "Slow down! Wait a moment." },
        new Translation { Id = 26, Key = "error.noSession", TextSv = "Sessionen gick ut. Laddar om...", TextEn = "Session expired. Reloading..." },

        // Language toggle
        new Translation { Id = 27, Key = "lang.switch", TextSv = "English", TextEn = "Svenska" },

        // Footer / misc
        new Translation { Id = 28, Key = "app.tagline", TextSv = "Hitta din matmatch", TextEn = "Find your food match" },
    ];
}
