using Biine.API.Models;

namespace Biine.API.Seeders;

public static class RecipeSeedData
{
    public static Recipe[] GetRecipes() =>
    [
        new Recipe
        {
            Id = 1,
            Name = "Carbonara",
            Cuisine = "Italian",
            Difficulty = "Medium",
            CookingTime = 25,
            Tags = ["Pasta", "Cheesy", "Roman", "Quick"],
            PersonaTextSv = "Jag är krämig, trygg och förlåter inte fuskare. Född i Rom, krossar hjärtan. Tagliatelle är mitt kärleksspråk — ja, jag dömer dig om du tillsätter grädde.",
            PersonaTextEn = "I'm creamy, comforting, and unforgiving to cheaters. Roman born, hearts broken. Tagliatelle is my love language — and yes, I judge if you add cream.",
            IngredientsSv = "[{\"namn\":\"Pasta\",\"mängd\":\"400 g\"},{\"namn\":\"Ägg\",\"mängd\":\"4 st\"},{\"namn\":\"Pancetta\",\"mängd\":\"150 g\"},{\"namn\":\"Parmesanost\",\"mängd\":\"80 g\"},{\"namn\":\"Svartpeppar\",\"mängd\":\"efter smak\"}]",
            IngredientsEn = "[{\"name\":\"Pasta\",\"amount\":\"400 g\"},{\"name\":\"Eggs\",\"amount\":\"4\"},{\"name\":\"Pancetta\",\"amount\":\"150 g\"},{\"name\":\"Parmesan\",\"amount\":\"80 g\"},{\"name\":\"Black pepper\",\"amount\":\"to taste\"}]",
            InstructionsSv = "1. Koka pasta al dente.\n2. Stek pancetta knaprig.\n3. Blanda ägg och riven parmesan i en skål.\n4. Blanda den varma pastan med pancettan av värmen.\n5. Häll äggblandningen och rör snabbt. Krydda med svartpeppar.",
            InstructionsEn = "1. Cook pasta al dente.\n2. Fry pancetta until crispy.\n3. Mix eggs and grated parmesan in a bowl.\n4. Toss hot pasta with pancetta off the heat.\n5. Pour egg mixture and stir quickly. Season with black pepper.",
            ImageUrl = "https://images.unsplash.com/photo-1612874742237-6526221588e3?w=800"
        },
        new Recipe
        {
            Id = 2,
            Name = "Tacos al Pastor",
            Cuisine = "Mexican",
            Difficulty = "Medium",
            CookingTime = 35,
            Tags = ["Tacos", "Spicy", "Pineapple", "Street Food"],
            PersonaTextSv = "Söker någon som tål värme. Jag är söt, kryddig och har ananas. Bäst njuten stående i solnedgången. Inga vekling.",
            PersonaTextEn = "Looking for someone who can handle heat. I'm sweet, spicy, and pineapple'd. Best enjoyed standing up, watching the sunset. No quitters.",
            IngredientsSv = "[{\"namn\":\"Fläskkött\",\"mängd\":\"500 g\"},{\"namn\":\"Ananas\",\"mängd\":\"1/2\"},{\"namn\":\"Chilepeppar\",\"mängd\":\"3 st\"},{\"namn\":\"Tortillas\",\"mängd\":\"8 st\"},{\"namn\":\"Koriander\",\"mängd\":\"1 knippe\"}]",
            IngredientsEn = "[{\"name\":\"Pork\",\"amount\":\"500 g\"},{\"name\":\"Pineapple\",\"amount\":\"1/2\"},{\"name\":\"Chili peppers\",\"amount\":\"3\"},{\"name\":\"Tortillas\",\"amount\":\"8\"},{\"name\":\"Cilantro\",\"amount\":\"1 bunch\"}]",
            InstructionsSv = "1. Marinera fläsket i chili, achiote och ananassaft i 2 timmar.\n2. Grilla köttet på hög värme tills karamelliserat.\n3. Skär i tunna skivor.\n4. Servera i varma tortillas med färsk ananas och koriander.",
            InstructionsEn = "1. Marinate pork in chili, achiote, and pineapple juice for 2 hours.\n2. Grill meat on high heat until caramelized.\n3. Slice thinly.\n4. Serve in warm tortillas with fresh pineapple and cilantro.",
            ImageUrl = "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?w=800"
        },
        new Recipe
        {
            Id = 3,
            Name = "Pad Thai",
            Cuisine = "Thai",
            Difficulty = "Easy",
            CookingTime = 20,
            Tags = ["Noodles", "Peanuts", "Tangy", "Quick"],
            PersonaTextSv = "Jag är den vännen som alltid är balanserad — söt, sur, syrlig och lite fräck. Jordnötter är mitt kärleksspråk. Förstör all annan Thai för dig för evigt.",
            PersonaTextEn = "I'm that friend who's always balanced — sweet, sour, tangy, and a little sassy. Peanuts are my love language. Will ruin other Thai for you forever.",
            IngredientsSv = "[{\"namn\":\"Risnudlar\",\"mängd\":\"200 g\"},{\"namn\":\"Räkor\",\"mängd\":\"200 g\"},{\"namn\":\"Ägg\",\"mängd\":\"2 st\"},{\"namn\":\"Jordnötter\",\"mängd\":\"50 g\"},{\"namn\":\"Fisksås\",\"mängd\":\"3 msk\"},{\"namn\":\"Tamarind\",\"mängd\":\"2 msk\"}]",
            IngredientsEn = "[{\"name\":\"Rice noodles\",\"amount\":\"200 g\"},{\"name\":\"Shrimp\",\"amount\":\"200 g\"},{\"name\":\"Eggs\",\"amount\":\"2\"},{\"name\":\"Peanuts\",\"amount\":\"50 g\"},{\"name\":\"Fish sauce\",\"amount\":\"3 tbsp\"},{\"name\":\"Tamarind\",\"amount\":\"2 tbsp\"}]",
            InstructionsSv = "1. Blötlägg nudlarna i varmt vatten 15 min.\n2. Stek räkor i wok, lägg åt sidan.\n3. Vispa ägg i woken.\n4. Tillsätt nudlar, fisksås, tamarind.\n5. Lägg tillbaka räkorna. Toppa med jordnötter och lime.",
            InstructionsEn = "1. Soak noodles in warm water 15 min.\n2. Stir-fry shrimp in wok, set aside.\n3. Scramble eggs in wok.\n4. Add noodles, fish sauce, tamarind.\n5. Return shrimp. Top with peanuts and lime.",
            ImageUrl = "https://images.unsplash.com/photo-1559314809-0d155014e29e?w=800"
        },
        new Recipe
        {
            Id = 4,
            Name = "Butter Chicken",
            Cuisine = "Indian",
            Difficulty = "Medium",
            CookingTime = 40,
            Tags = ["Curry", "Creamy", "Mild", "Comfort"],
            PersonaTextSv = "Rik, sammetsmjuk och inte rädd för åtaganden. Jag är mild men kan bli het om du förtjänar det. Kom med naan, stanna för alltid.",
            PersonaTextEn = "Rich, velvety, and not afraid of commitment. I'm mild but can go spicy if you earn it. Garam masala? More like full-body aroma. Come with naan, stay forever.",
            IngredientsSv = "[{\"namn\":\"Kycklingfilé\",\"mängd\":\"600 g\"},{\"namn\":\"Krossade tomater\",\"mängd\":\"400 g\"},{\"namn\":\"Grädde\",\"mängd\":\"200 ml\"},{\"namn\":\"Smör\",\"mängd\":\"3 msk\"},{\"namn\":\"Garam masala\",\"mängd\":\"2 tsk\"},{\"namn\":\"Ingefära\",\"mängd\":\"1 msk\"}]",
            IngredientsEn = "[{\"name\":\"Chicken breast\",\"amount\":\"600 g\"},{\"name\":\"Crushed tomatoes\",\"amount\":\"400 g\"},{\"name\":\"Cream\",\"amount\":\"200 ml\"},{\"name\":\"Butter\",\"amount\":\"3 tbsp\"},{\"name\":\"Garam masala\",\"amount\":\"2 tsp\"},{\"name\":\"Ginger\",\"amount\":\"1 tbsp\"}]",
            InstructionsSv = "1. Marinera kyckling i yoghurt och kryddor 30 min.\n2. Grilla eller stek kyckling.\n3. Fräs lök, ingefära, vitlök i smör.\n4. Tillsätt tomater och kryddor, koka 10 min.\n5. Tillsätt grädde och kyckling. Låt puttra 10 min.",
            InstructionsEn = "1. Marinate chicken in yoghurt and spices 30 min.\n2. Grill or pan-fry chicken.\n3. Sauté onion, ginger, garlic in butter.\n4. Add tomatoes and spices, simmer 10 min.\n5. Add cream and chicken. Simmer 10 min.",
            ImageUrl = "https://images.unsplash.com/photo-1603894584373-5ac82b2ae398?w=800"
        },
        new Recipe
        {
            Id = 5,
            Name = "Sushi Roll",
            Cuisine = "Japanese",
            Difficulty = "Hard",
            CookingTime = 60,
            Tags = ["Rice", "Sushi", "Fresh", "Elegant"],
            PersonaTextSv = "Elegant, precis och lite mystisk. Kall utanpå men varm inuti. Wasabi är bara mitt sinne för humor. Seriös om fräschhet, avslappnad om stämningen.",
            PersonaTextEn = "Elegant, precise, and a little mysterious. I'm cold on the outside but warm inside. Wasabi is just my sense of humor. Serious about freshness, casual about vibes.",
            IngredientsSv = "[{\"namn\":\"Sushiris\",\"mängd\":\"300 g\"},{\"namn\":\"Nori-alger\",\"mängd\":\"4 ark\"},{\"namn\":\"Lax\",\"mängd\":\"200 g\"},{\"namn\":\"Avokado\",\"mängd\":\"1 st\"},{\"namn\":\"Risvinäger\",\"mängd\":\"3 msk\"},{\"namn\":\"Wasabi\",\"mängd\":\"efter smak\"}]",
            IngredientsEn = "[{\"name\":\"Sushi rice\",\"amount\":\"300 g\"},{\"name\":\"Nori sheets\",\"amount\":\"4\"},{\"name\":\"Salmon\",\"amount\":\"200 g\"},{\"name\":\"Avocado\",\"amount\":\"1\"},{\"name\":\"Rice vinegar\",\"amount\":\"3 tbsp\"},{\"name\":\"Wasabi\",\"amount\":\"to taste\"}]",
            InstructionsSv = "1. Koka riset och blanda med risvinäger.\n2. Lägg norin på bambumatten.\n3. Bred ut riset jämnt.\n4. Lägg fyllning längs kanten.\n5. Rulla tight och skär i bitar.",
            InstructionsEn = "1. Cook rice and mix with rice vinegar.\n2. Place nori on bamboo mat.\n3. Spread rice evenly.\n4. Place filling along the edge.\n5. Roll tight and cut into pieces.",
            ImageUrl = "https://images.unsplash.com/photo-1617196034183-421b4040ed20?w=800"
        },
        new Recipe
        {
            Id = 6,
            Name = "Burger",
            Cuisine = "American",
            Difficulty = "Easy",
            CookingTime = 20,
            Tags = ["Beef", "Cheesy", "Classic", "BBQ"],
            PersonaTextSv = "Klassisk, ingen drama. Jag är hela paketet — biff, ost, pickles, drama. Bäst med pommes och inga frågor. Tjock, saftig, pålitlig.",
            PersonaTextEn = "Classic, no drama. I'm the whole package — patty, cheese, pickle, drama. Best with fries on the side and no questions asked. Thick, juicy, reliable.",
            IngredientsSv = "[{\"namn\":\"Nötfärs\",\"mängd\":\"500 g\"},{\"namn\":\"Cheddarost\",\"mängd\":\"4 skivor\"},{\"namn\":\"Briochebröd\",\"mängd\":\"4 st\"},{\"namn\":\"Sallad\",\"mängd\":\"4 blad\"},{\"namn\":\"Tomat\",\"mängd\":\"1 st\"},{\"namn\":\"Gurka\",\"mängd\":\"4 skivor\"}]",
            IngredientsEn = "[{\"name\":\"Ground beef\",\"amount\":\"500 g\"},{\"name\":\"Cheddar\",\"amount\":\"4 slices\"},{\"name\":\"Brioche buns\",\"amount\":\"4\"},{\"name\":\"Lettuce\",\"amount\":\"4 leaves\"},{\"name\":\"Tomato\",\"amount\":\"1\"},{\"name\":\"Pickles\",\"amount\":\"4 slices\"}]",
            InstructionsSv = "1. Forma 4 biffar av nötfärsen. Krydda generöst.\n2. Grilla på hög värme 3-4 min per sida.\n3. Lägg ost på sista minuten.\n4. Rosta brödet lätt.\n5. Bygg burgaren med alla tillbehör.",
            InstructionsEn = "1. Form 4 patties from ground beef. Season generously.\n2. Grill on high heat 3-4 min per side.\n3. Add cheese in the last minute.\n4. Lightly toast the buns.\n5. Build the burger with all toppings.",
            ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800"
        },
        new Recipe
        {
            Id = 7,
            Name = "Pho",
            Cuisine = "Vietnamese",
            Difficulty = "Hard",
            CookingTime = 180,
            Tags = ["Soup", "Aromatic", "Herbs", "Noodles"],
            PersonaTextSv = "Komplex, aromatisk och värd väntan. Tar 8 timmar att laga och 10 minuter att förälska sig i. Örter är min personlighet. Tröst i en skål.",
            PersonaTextEn = "Complex, aromatic, and worth the wait. I take 8 hours to make and 10 minutes to fall in love with. Herbs are my personality. Comfort in a bowl.",
            IngredientsSv = "[{\"namn\":\"Nötben\",\"mängd\":\"1 kg\"},{\"namn\":\"Risnudlar\",\"mängd\":\"300 g\"},{\"namn\":\"Stjärnanis\",\"mängd\":\"4 st\"},{\"namn\":\"Kanel\",\"mängd\":\"1 pinne\"},{\"namn\":\"Fisksås\",\"mängd\":\"4 msk\"},{\"namn\":\"Färska örter\",\"mängd\":\"1 knippe\"}]",
            IngredientsEn = "[{\"name\":\"Beef bones\",\"amount\":\"1 kg\"},{\"name\":\"Rice noodles\",\"amount\":\"300 g\"},{\"name\":\"Star anise\",\"amount\":\"4\"},{\"name\":\"Cinnamon\",\"amount\":\"1 stick\"},{\"name\":\"Fish sauce\",\"amount\":\"4 tbsp\"},{\"name\":\"Fresh herbs\",\"amount\":\"1 bunch\"}]",
            InstructionsSv = "1. Rosta kryddorna torrt i en gryta.\n2. Koka benen med kryddor i 6-8 timmar.\n3. Sila buljongen.\n4. Koka nudlarna.\n5. Servera nudlar i het buljong med färska örter, böngroddar och lime.",
            InstructionsEn = "1. Dry roast spices in a pot.\n2. Simmer bones with spices for 6-8 hours.\n3. Strain the broth.\n4. Cook the noodles.\n5. Serve noodles in hot broth with fresh herbs, bean sprouts, and lime.",
            ImageUrl = "https://images.unsplash.com/photo-1614333626528-04b3de0bdb4e?w=800"
        },
        new Recipe
        {
            Id = 8,
            Name = "Gyros",
            Cuisine = "Greek",
            Difficulty = "Easy",
            CookingTime = 30,
            Tags = ["Pita", "Tzatziki", "Mediterranean", "Grilled"],
            PersonaTextSv = "Medelhavscharme med tzatziki-swagger. Jag är välkryddad och serveras med värme. Pita rekommenderas. Feta är mitt kärleksspråk.",
            PersonaTextEn = "Mediterranean charm with tzatziki swagger. I'm stacked, seasoned, and served with warmth. Pita not required but recommended. Feta is my love language.",
            IngredientsSv = "[{\"namn\":\"Kycklinglår\",\"mängd\":\"600 g\"},{\"namn\":\"Pita\",\"mängd\":\"4 st\"},{\"namn\":\"Tzatziki\",\"mängd\":\"200 g\"},{\"namn\":\"Tomat\",\"mängd\":\"2 st\"},{\"namn\":\"Rödlök\",\"mängd\":\"1 st\"},{\"namn\":\"Paprika\",\"mängd\":\"1 tsk\"}]",
            IngredientsEn = "[{\"name\":\"Chicken thighs\",\"amount\":\"600 g\"},{\"name\":\"Pita\",\"amount\":\"4\"},{\"name\":\"Tzatziki\",\"amount\":\"200 g\"},{\"name\":\"Tomato\",\"amount\":\"2\"},{\"name\":\"Red onion\",\"amount\":\"1\"},{\"name\":\"Paprika\",\"amount\":\"1 tsp\"}]",
            InstructionsSv = "1. Marinera kyckling i olivolja, vitlök, paprika, oregano.\n2. Grilla på hög värme tills genomstekt.\n3. Värm pitan.\n4. Skär köttet i remsor.\n5. Servera i pitan med tzatziki, tomat och lök.",
            InstructionsEn = "1. Marinate chicken in olive oil, garlic, paprika, oregano.\n2. Grill on high heat until cooked through.\n3. Warm the pita.\n4. Slice meat into strips.\n5. Serve in pita with tzatziki, tomato, and onion.",
            ImageUrl = "https://images.unsplash.com/photo-1599487488170-d11ec9c172f0?w=800"
        },
        new Recipe
        {
            Id = 9,
            Name = "Pizza Margherita",
            Cuisine = "Italian",
            Difficulty = "Easy",
            CookingTime = 25,
            Tags = ["Pizza", "Tomato", "Basil", "Classic"],
            PersonaTextSv = "Enkel, ikonisk och sviker aldrig. Jag är röd, vit, grön och ren. Neapel lärde mig att mindre är mer.",
            PersonaTextEn = "Simple, iconic, and will never let you down. I'm red, white, green, and clean. Naples taught me less is more.",
            IngredientsSv = "[{\"namn\":\"Pizzadeg\",\"mängd\":\"300 g\"},{\"namn\":\"Krossade tomater\",\"mängd\":\"150 g\"},{\"namn\":\"Mozzarella\",\"mängd\":\"200 g\"},{\"namn\":\"Basilika\",\"mängd\":\"1 knippe\"},{\"namn\":\"Olivolja\",\"mängd\":\"2 msk\"}]",
            IngredientsEn = "[{\"name\":\"Pizza dough\",\"amount\":\"300 g\"},{\"name\":\"Crushed tomatoes\",\"amount\":\"150 g\"},{\"name\":\"Mozzarella\",\"amount\":\"200 g\"},{\"name\":\"Basil\",\"amount\":\"1 bunch\"},{\"name\":\"Olive oil\",\"amount\":\"2 tbsp\"}]",
            InstructionsSv = "1. Värm ugnen till 250°C.\n2. Kavla ut degen tunt.\n3. Bred tomatsås.\n4. Lägg på mozzarella i bitar.\n5. Grädda 8-10 min. Toppa med färsk basilika.",
            InstructionsEn = "1. Preheat oven to 250°C.\n2. Roll dough thinly.\n3. Spread tomato sauce.\n4. Add torn mozzarella.\n5. Bake 8-10 min. Top with fresh basil.",
            ImageUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=800"
        },
        new Recipe
        {
            Id = 10,
            Name = "Ramen",
            Cuisine = "Japanese",
            Difficulty = "Hard",
            CookingTime = 120,
            Tags = ["Soup", "Noodles", "Broth", "Umami"],
            PersonaTextSv = "Jag är mörk, själfull och djup. Den typ av kärlekshistoria som börjar med hunger och slutar med tillfredsställelse. Mjukt ägg frivilligt men uppskattat.",
            PersonaTextEn = "I'm moody, soulful, and deep. The kind of love story that starts with hunger and ends with contentment. Soft egg optional but appreciated. Slurp responsibly.",
            IngredientsSv = "[{\"namn\":\"Fläskben\",\"mängd\":\"500 g\"},{\"namn\":\"Ramennudlar\",\"mängd\":\"300 g\"},{\"namn\":\"Sojasamn\",\"mängd\":\"4 msk\"},{\"namn\":\"Miso\",\"mängd\":\"2 msk\"},{\"namn\":\"Ägg\",\"mängd\":\"4 st\"},{\"namn\":\"Nori\",\"mängd\":\"4 ark\"}]",
            IngredientsEn = "[{\"name\":\"Pork bones\",\"amount\":\"500 g\"},{\"name\":\"Ramen noodles\",\"amount\":\"300 g\"},{\"name\":\"Soy sauce\",\"amount\":\"4 tbsp\"},{\"name\":\"Miso paste\",\"amount\":\"2 tbsp\"},{\"name\":\"Eggs\",\"amount\":\"4\"},{\"name\":\"Nori\",\"amount\":\"4 sheets\"}]",
            InstructionsSv = "1. Koka benen i vatten 2 timmar för en rik buljong.\n2. Koka äggen 6 min, kyl och skala.\n3. Marinera äggen i soja och mirin.\n4. Koka nudlarna.\n5. Blanda buljong med miso. Servera med nudlar, ägg och nori.",
            InstructionsEn = "1. Simmer bones in water for 2 hours for rich broth.\n2. Boil eggs 6 min, cool, and peel.\n3. Marinate eggs in soy and mirin.\n4. Cook noodles.\n5. Mix broth with miso. Serve with noodles, egg, and nori.",
            ImageUrl = "https://images.unsplash.com/photo-1569050467447-ce54b3bbc37d?w=800"
        },
        new Recipe
        {
            Id = 11,
            Name = "Enchiladas",
            Cuisine = "Mexican",
            Difficulty = "Medium",
            CookingTime = 45,
            Tags = ["Cheese", "Spicy", "Saucy", "Comfort"],
            PersonaTextSv = "Tajt inrullad och full av överraskningar. Jag är sårande, ostaktig och hettan är min personlighet. Öppna inte förrän du är redo för åtaganden.",
            PersonaTextEn = "Wrapped up tight and full of surprises. I'm saucy, cheesy, and heat is my personality. Don't unwrap until you're ready for commitment.",
            IngredientsSv = "[{\"namn\":\"Tortillas\",\"mängd\":\"8 st\"},{\"namn\":\"Kycklingkött\",\"mängd\":\"400 g\"},{\"namn\":\"Enchiladas-sås\",\"mängd\":\"400 g\"},{\"namn\":\"Cheddarost\",\"mängd\":\"200 g\"},{\"namn\":\"Chipotle\",\"mängd\":\"1 msk\"}]",
            IngredientsEn = "[{\"name\":\"Tortillas\",\"amount\":\"8\"},{\"name\":\"Chicken\",\"amount\":\"400 g\"},{\"name\":\"Enchilada sauce\",\"amount\":\"400 g\"},{\"name\":\"Cheddar\",\"amount\":\"200 g\"},{\"name\":\"Chipotle\",\"amount\":\"1 tbsp\"}]",
            InstructionsSv = "1. Koka och strimla kycklingen.\n2. Blanda kyckling med hälften av osten och chipotle.\n3. Fyll tortillas och rulla ihop.\n4. Lägg i ugnsform, häll sås över.\n5. Täck med resten av osten och grädda 20 min på 200°C.",
            InstructionsEn = "1. Cook and shred the chicken.\n2. Mix chicken with half the cheese and chipotle.\n3. Fill tortillas and roll up.\n4. Place in baking dish, pour sauce over.\n5. Top with remaining cheese and bake 20 min at 200°C.",
            ImageUrl = "https://images.unsplash.com/photo-1534352956036-cd81e27dd615?w=800"
        },
        new Recipe
        {
            Id = 12,
            Name = "Tikka Masala",
            Cuisine = "Indian",
            Difficulty = "Medium",
            CookingTime = 40,
            Tags = ["Curry", "Creamy", "Aromatic", "Naan"],
            PersonaTextSv = "Storbritanniens favorit, född av kärlek över kulturer. Jag är krämig, aromatisk och alltid en bra idé. Naan är min kompis.",
            PersonaTextEn = "Britain's favorite, born from love across cultures. I'm creamy, aromatic, and always a good idea. Naan is my wingman.",
            IngredientsSv = "[{\"namn\":\"Kycklingfilé\",\"mängd\":\"600 g\"},{\"namn\":\"Krossade tomater\",\"mängd\":\"400 g\"},{\"namn\":\"Grädde\",\"mängd\":\"200 ml\"},{\"namn\":\"Tikka masala-krydda\",\"mängd\":\"3 msk\"},{\"namn\":\"Lök\",\"mängd\":\"1 st\"}]",
            IngredientsEn = "[{\"name\":\"Chicken breast\",\"amount\":\"600 g\"},{\"name\":\"Crushed tomatoes\",\"amount\":\"400 g\"},{\"name\":\"Cream\",\"amount\":\"200 ml\"},{\"name\":\"Tikka masala spice\",\"amount\":\"3 tbsp\"},{\"name\":\"Onion\",\"amount\":\"1\"}]",
            InstructionsSv = "1. Marinera kyckling i yoghurt och tikka-krydda.\n2. Grilla kyckling tills brynt.\n3. Fräs lök och vitlök.\n4. Tillsätt tomater och krydda, koka 10 min.\n5. Tillsätt grädde och kyckling, koka 10 min.",
            InstructionsEn = "1. Marinate chicken in yoghurt and tikka spice.\n2. Grill chicken until charred.\n3. Sauté onion and garlic.\n4. Add tomatoes and spice, simmer 10 min.\n5. Add cream and chicken, simmer 10 min.",
            ImageUrl = "https://images.unsplash.com/photo-1565557623262-b51c2513a641?w=800"
        },
        new Recipe
        {
            Id = 13,
            Name = "Dumplings",
            Cuisine = "Chinese",
            Difficulty = "Medium",
            CookingTime = 60,
            Tags = ["Steamed", "Pork", "Dipping Sauce", "Dim Sum"],
            PersonaTextSv = "Liten, söt och full av hemligheter. Jag är ångad, stekt eller båda. Doppa mig i sås och se gnistorna flyga.",
            PersonaTextEn = "Small, sweet, and full of secrets. I'm steamed, pan-fried, or both. Dip me in sauce and watch sparks fly. One bite, and you're mine.",
            IngredientsSv = "[{\"namn\":\"Dumplingsdegjbitar\",\"mängd\":\"30 st\"},{\"namn\":\"Fläskfärs\",\"mängd\":\"300 g\"},{\"namn\":\"Kål\",\"mängd\":\"150 g\"},{\"namn\":\"Ingefära\",\"mängd\":\"1 msk\"},{\"namn\":\"Sesamolja\",\"mängd\":\"1 msk\"}]",
            IngredientsEn = "[{\"name\":\"Dumpling wrappers\",\"amount\":\"30\"},{\"name\":\"Ground pork\",\"amount\":\"300 g\"},{\"name\":\"Cabbage\",\"amount\":\"150 g\"},{\"name\":\"Ginger\",\"amount\":\"1 tbsp\"},{\"name\":\"Sesame oil\",\"amount\":\"1 tbsp\"}]",
            InstructionsSv = "1. Blanda fläskfärs med kål, ingefära och sesamolja.\n2. Lägg fyllning i mitten av varje degbit.\n3. Vik och nyp ihop kanterna.\n4. Ånga 8 min eller stek i olja med lock.",
            InstructionsEn = "1. Mix ground pork with cabbage, ginger, and sesame oil.\n2. Place filling in center of each wrapper.\n3. Fold and crimp the edges.\n4. Steam for 8 min or pan-fry with a lid.",
            ImageUrl = "https://images.unsplash.com/photo-1563245372-f21724e3856d?w=800"
        },
        new Recipe
        {
            Id = 14,
            Name = "Schnitzel",
            Cuisine = "German",
            Difficulty = "Medium",
            CookingTime = 25,
            Tags = ["Crispy", "Pork", "Breaded", "Classic"],
            PersonaTextSv = "Krispig, gyllene och rättfram. Jag är den mörka främlingen i köttvärlden. Bankad platt för maximal räckvidd.",
            PersonaTextEn = "Crispy, golden, and no-nonsense. I'm the tall, dark stranger of the meat world. Hammered flat for maximum reach.",
            IngredientsSv = "[{\"namn\":\"Fläskschnitzel\",\"mängd\":\"4 st\"},{\"namn\":\"Ströbröd\",\"mängd\":\"100 g\"},{\"namn\":\"Ägg\",\"mängd\":\"2 st\"},{\"namn\":\"Mjöl\",\"mängd\":\"50 g\"},{\"namn\":\"Smör\",\"mängd\":\"4 msk\"}]",
            IngredientsEn = "[{\"name\":\"Pork cutlets\",\"amount\":\"4\"},{\"name\":\"Breadcrumbs\",\"amount\":\"100 g\"},{\"name\":\"Eggs\",\"amount\":\"2\"},{\"name\":\"Flour\",\"amount\":\"50 g\"},{\"name\":\"Butter\",\"amount\":\"4 tbsp\"}]",
            InstructionsSv = "1. Banka köttet tunt med en köttklubba.\n2. Panera i mjöl, ägg och ströbröd.\n3. Stek i smör på medelhög värme tills gyllengul.\n4. Servera med citron och potatis.",
            InstructionsEn = "1. Pound meat thin with a mallet.\n2. Bread in flour, egg, and breadcrumbs.\n3. Fry in butter on medium heat until golden.\n4. Serve with lemon and potatoes.",
            ImageUrl = "https://images.unsplash.com/photo-1599921841143-819065a55cc6?w=800"
        },
        new Recipe
        {
            Id = 15,
            Name = "Currywurst",
            Cuisine = "German",
            Difficulty = "Easy",
            CookingTime = 15,
            Tags = ["Sausage", "Curry", "Street Food", "Berlin"],
            PersonaTextSv = "Berlin-legend inom gatumat. Jag är sårande, tillfredsställande och bryr mig inte om dina planer. Currykryddad korv? Snarare currykryddade känslor.",
            PersonaTextEn = "Berlin street food legend. I'm saucy, satisfying, and don't care about your plans. Curried sausage? More like curried feelings.",
            IngredientsSv = "[{\"namn\":\"Bratwurst\",\"mängd\":\"4 st\"},{\"namn\":\"Ketchup\",\"mängd\":\"200 g\"},{\"namn\":\"Currykrydda\",\"mängd\":\"3 tsk\"},{\"namn\":\"Paprikapulver\",\"mängd\":\"1 tsk\"}]",
            IngredientsEn = "[{\"name\":\"Bratwurst\",\"amount\":\"4\"},{\"name\":\"Ketchup\",\"amount\":\"200 g\"},{\"name\":\"Curry powder\",\"amount\":\"3 tsp\"},{\"name\":\"Paprika\",\"amount\":\"1 tsp\"}]",
            InstructionsSv = "1. Grilla eller stek bratwursten.\n2. Blanda ketchup med currykrydda och paprika.\n3. Skär korven i bitar.\n4. Häll såsen över. Servera med pommes.",
            InstructionsEn = "1. Grill or fry the bratwurst.\n2. Mix ketchup with curry powder and paprika.\n3. Slice the sausage.\n4. Pour sauce over. Serve with fries.",
            ImageUrl = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?w=800"
        },
        new Recipe
        {
            Id = 16,
            Name = "Falafel",
            Cuisine = "Middle Eastern",
            Difficulty = "Easy",
            CookingTime = 30,
            Tags = ["Vegetarian", "Crispy", "Tahini", "Wrap"],
            PersonaTextSv = "Knaprig utanpå, örtrik inuti. Jag är vegetarisk men kan förföra vem som helst. Tahini är min parfym.",
            PersonaTextEn = "Crispy on the outside, herbaceous on the inside. I'm vegetarian but can seduce anyone. Tahini is my perfume.",
            IngredientsSv = "[{\"namn\":\"Kikärtor\",\"mängd\":\"400 g\"},{\"namn\":\"Koriander\",\"mängd\":\"1 knippe\"},{\"namn\":\"Persilja\",\"mängd\":\"1 knippe\"},{\"namn\":\"Vitlök\",\"mängd\":\"3 klyftor\"},{\"namn\":\"Spiskummin\",\"mängd\":\"2 tsk\"},{\"namn\":\"Tahini\",\"mängd\":\"3 msk\"}]",
            IngredientsEn = "[{\"name\":\"Chickpeas\",\"amount\":\"400 g\"},{\"name\":\"Cilantro\",\"amount\":\"1 bunch\"},{\"name\":\"Parsley\",\"amount\":\"1 bunch\"},{\"name\":\"Garlic\",\"amount\":\"3 cloves\"},{\"name\":\"Cumin\",\"amount\":\"2 tsp\"},{\"name\":\"Tahini\",\"amount\":\"3 tbsp\"}]",
            InstructionsSv = "1. Mixa kikärtor, örter, vitlök och kryddor grovt.\n2. Forma till bollar.\n3. Fritera i olja på 180°C tills gyllengula.\n4. Servera i pita med tahini och sallad.",
            InstructionsEn = "1. Coarsely blend chickpeas, herbs, garlic, and spices.\n2. Shape into balls.\n3. Deep fry at 180°C until golden.\n4. Serve in pita with tahini and salad.",
            ImageUrl = "https://images.unsplash.com/photo-1593001872095-7d5b3868fb1d?w=800"
        },
        new Recipe
        {
            Id = 17,
            Name = "Bibimbap",
            Cuisine = "Korean",
            Difficulty = "Medium",
            CookingTime = 40,
            Tags = ["Rice", "Korean", "Spicy", "Colorful"],
            PersonaTextSv = "Färgglad, kreativ och blandad med anledning. Jag är allt i en skål. Lägg ditt ägg på toppen och se magi hända.",
            PersonaTextEn = "Colorful, creative, and mixed for a reason. I'm everything in one bowl — sweet, spicy, savory, fresh. Put your egg on top and watch magic happen.",
            IngredientsSv = "[{\"namn\":\"Ris\",\"mängd\":\"300 g\"},{\"namn\":\"Nötkött\",\"mängd\":\"200 g\"},{\"namn\":\"Spenat\",\"mängd\":\"100 g\"},{\"namn\":\"Morötter\",\"mängd\":\"2 st\"},{\"namn\":\"Ägg\",\"mängd\":\"4 st\"},{\"namn\":\"Gochujang\",\"mängd\":\"2 msk\"}]",
            IngredientsEn = "[{\"name\":\"Rice\",\"amount\":\"300 g\"},{\"name\":\"Beef\",\"amount\":\"200 g\"},{\"name\":\"Spinach\",\"amount\":\"100 g\"},{\"name\":\"Carrots\",\"amount\":\"2\"},{\"name\":\"Eggs\",\"amount\":\"4\"},{\"name\":\"Gochujang\",\"amount\":\"2 tbsp\"}]",
            InstructionsSv = "1. Koka riset.\n2. Marinera och stek nötköttet i soja och sesamolja.\n3. Blanchera spenat, stek morötter.\n4. Stek ägg med rinnande gula.\n5. Lägg allt i skål, toppa med ägg och gochujang.",
            InstructionsEn = "1. Cook the rice.\n2. Marinate and stir-fry beef in soy and sesame oil.\n3. Blanch spinach, stir-fry carrots.\n4. Fry eggs sunny side up.\n5. Arrange everything in bowl, top with egg and gochujang.",
            ImageUrl = "https://images.unsplash.com/photo-1553163147-622ab57be1c7?w=800"
        },
        new Recipe
        {
            Id = 18,
            Name = "Lasagna",
            Cuisine = "Italian",
            Difficulty = "Hard",
            CookingTime = 90,
            Tags = ["Pasta", "Baked", "Layers", "Comfort"],
            PersonaTextSv = "Lager. Varje ett av dem meningsfullt. Jag är tålmodig, rik och värd varje minut. Inga genvägar, inga substitut.",
            PersonaTextEn = "Layers. Every one of them meaningful. I'm patient, rich, and worth every minute. No shortcuts, no substitutes.",
            IngredientsSv = "[{\"namn\":\"Lasagneplattor\",\"mängd\":\"12 st\"},{\"namn\":\"Nötfärs\",\"mängd\":\"500 g\"},{\"namn\":\"Krossade tomater\",\"mängd\":\"400 g\"},{\"namn\":\"Béchamelsås\",\"mängd\":\"500 ml\"},{\"namn\":\"Parmesanost\",\"mängd\":\"100 g\"}]",
            IngredientsEn = "[{\"name\":\"Lasagna sheets\",\"amount\":\"12\"},{\"name\":\"Ground beef\",\"amount\":\"500 g\"},{\"name\":\"Crushed tomatoes\",\"amount\":\"400 g\"},{\"name\":\"Béchamel sauce\",\"amount\":\"500 ml\"},{\"name\":\"Parmesan\",\"amount\":\"100 g\"}]",
            InstructionsSv = "1. Gör köttfärssåsen med lök, tomat och köttfärs.\n2. Gör béchamelsås.\n3. Varva lasagneplattor, köttfärssås och béchamel.\n4. Toppa med parmesan.\n5. Grädda 40 min på 180°C.",
            InstructionsEn = "1. Make the meat sauce with onion, tomato, and beef.\n2. Make béchamel sauce.\n3. Layer lasagna sheets, meat sauce, and béchamel.\n4. Top with parmesan.\n5. Bake 40 min at 180°C.",
            ImageUrl = "https://images.unsplash.com/photo-1574894709920-11b28e7367e3?w=800"
        },
        new Recipe
        {
            Id = 19,
            Name = "Chicken Wings",
            Cuisine = "American",
            Difficulty = "Easy",
            CookingTime = 40,
            Tags = ["Chicken", "Buffalo", "Crispy", "Party"],
            PersonaTextSv = "Stökig, beroendeframkallande och alltid festens stjärna. Buffalo är mitt mellannamn. Sås överallt, glädje i hjärtat.",
            PersonaTextEn = "Messy, addictive, and always the life of the party. Buffalo is my middle name. Sauce everywhere, joy in my heart.",
            IngredientsSv = "[{\"namn\":\"Kycklingvingar\",\"mängd\":\"1 kg\"},{\"namn\":\"Buffalosås\",\"mängd\":\"100 ml\"},{\"namn\":\"Smör\",\"mängd\":\"50 g\"},{\"namn\":\"Vitlök\",\"mängd\":\"2 klyftor\"},{\"namn\":\"Salt\",\"mängd\":\"1 tsk\"}]",
            IngredientsEn = "[{\"name\":\"Chicken wings\",\"amount\":\"1 kg\"},{\"name\":\"Buffalo sauce\",\"amount\":\"100 ml\"},{\"name\":\"Butter\",\"amount\":\"50 g\"},{\"name\":\"Garlic\",\"amount\":\"2 cloves\"},{\"name\":\"Salt\",\"amount\":\"1 tsp\"}]",
            InstructionsSv = "1. Torka vingarna och krydda med salt.\n2. Grädda på 220°C i 35-40 min, vänd halvvägs.\n3. Smält smör med buffalosås och vitlök.\n4. Slå såsen över de heta vingarna.",
            InstructionsEn = "1. Pat wings dry and season with salt.\n2. Bake at 220°C for 35-40 min, flipping halfway.\n3. Melt butter with buffalo sauce and garlic.\n4. Toss hot wings in the sauce.",
            ImageUrl = "https://images.unsplash.com/photo-1567620832903-9fc6debc209f?w=800"
        },
        new Recipe
        {
            Id = 20,
            Name = "Poke Bowl",
            Cuisine = "Hawaiian",
            Difficulty = "Easy",
            CookingTime = 15,
            Tags = ["Rice", "Tuna", "Fresh", "Healthy"],
            PersonaTextSv = "Fräsch, cool och lite romantisk. Jag är matens lugna söndagsmorgon. Ahi tuna, ris och stämning. Ingen matlagning krävs.",
            PersonaTextEn = "Fresh, cool, and low-key romantic. I'm the slow Sunday morning of food. Ahi tuna, rice, and vibes. No cooking required, just vibes.",
            IngredientsSv = "[{\"namn\":\"Sushiris\",\"mängd\":\"300 g\"},{\"namn\":\"Tonfisk sashimikvalitet\",\"mängd\":\"200 g\"},{\"namn\":\"Avokado\",\"mängd\":\"1 st\"},{\"namn\":\"Edamame\",\"mängd\":\"100 g\"},{\"namn\":\"Sojasamn\",\"mängd\":\"3 msk\"},{\"namn\":\"Sesamfrön\",\"mängd\":\"2 tsk\"}]",
            IngredientsEn = "[{\"name\":\"Sushi rice\",\"amount\":\"300 g\"},{\"name\":\"Sashimi tuna\",\"amount\":\"200 g\"},{\"name\":\"Avocado\",\"amount\":\"1\"},{\"name\":\"Edamame\",\"amount\":\"100 g\"},{\"name\":\"Soy sauce\",\"amount\":\"3 tbsp\"},{\"name\":\"Sesame seeds\",\"amount\":\"2 tsp\"}]",
            InstructionsSv = "1. Koka riset.\n2. Skär tonfisken i kuber, marinera i soja och sesamolja.\n3. Skiva avokado.\n4. Bygg skålen med ris, tonfisk, avokado och edamame.\n5. Toppa med sesamfrön och söt soja.",
            InstructionsEn = "1. Cook the rice.\n2. Cube tuna, marinate in soy and sesame oil.\n3. Slice avocado.\n4. Build bowl with rice, tuna, avocado, and edamame.\n5. Top with sesame seeds and sweet soy.",
            ImageUrl = "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?w=800"
        },
        new Recipe
        {
            Id = 21,
            Name = "Köttbullar",
            Cuisine = "Swedish",
            Difficulty = "Easy",
            CookingTime = 30,
            Tags = ["Swedish", "Beef", "Lingonberry", "Comfort"],
            PersonaTextSv = "Köttiga, trygga och redo att umgås med lingonsylt. Jag är IKEA-resan du inte visste att du behövde.",
            PersonaTextEn = "Meaty, comforting, and ready to mingle with lingonberry. I'm the IKEA trip you didn't know you needed.",
            IngredientsSv = "[{\"namn\":\"Nötfärs\",\"mängd\":\"500 g\"},{\"namn\":\"Lök\",\"mängd\":\"1 st\"},{\"namn\":\"Ägg\",\"mängd\":\"1 st\"},{\"namn\":\"Ströbröd\",\"mängd\":\"3 msk\"},{\"namn\":\"Lingonsylt\",\"mängd\":\"100 g\"},{\"namn\":\"Grädde\",\"mängd\":\"200 ml\"}]",
            IngredientsEn = "[{\"name\":\"Ground beef\",\"amount\":\"500 g\"},{\"name\":\"Onion\",\"amount\":\"1\"},{\"name\":\"Egg\",\"amount\":\"1\"},{\"name\":\"Breadcrumbs\",\"amount\":\"3 tbsp\"},{\"name\":\"Lingonberry jam\",\"amount\":\"100 g\"},{\"name\":\"Cream\",\"amount\":\"200 ml\"}]",
            InstructionsSv = "1. Blanda färsen med hackad lök, ägg och ströbröd.\n2. Rulla till jämna bollar.\n3. Stek i smör tills genomstekta.\n4. Gör gräddsås i pannan.\n5. Servera med potatismos och lingonsylt.",
            InstructionsEn = "1. Mix ground beef with chopped onion, egg, and breadcrumbs.\n2. Roll into even balls.\n3. Fry in butter until cooked through.\n4. Make cream sauce in the same pan.\n5. Serve with mashed potatoes and lingonberry jam.",
            ImageUrl = "https://images.unsplash.com/photo-1529543544282-ea669407fca3?w=800"
        },
        new Recipe
        {
            Id = 22,
            Name = "Smörgåstårta",
            Cuisine = "Swedish",
            Difficulty = "Medium",
            CookingTime = 60,
            Tags = ["Swedish", "Sandwich", "Mayonnaise", "Party"],
            PersonaTextSv = "Lager av bröd, fyllningar och majonnäsmagi. Jag är smörgåstårtan som ifrågasätter din diet. Gjord för kalas och sommarluncher.",
            PersonaTextEn = "Layers of bread, fillings, and mayo magic. I'm the sandwich cake that questions your diet. Made for birthdays and summer lunches.",
            IngredientsSv = "[{\"namn\":\"Formbröd\",\"mängd\":\"1 limpa\"},{\"namn\":\"Räkor\",\"mängd\":\"200 g\"},{\"namn\":\"Lax\",\"mängd\":\"150 g\"},{\"namn\":\"Majonnäs\",\"mängd\":\"200 g\"},{\"namn\":\"Grädde\",\"mängd\":\"200 ml\"},{\"namn\":\"Gurka\",\"mängd\":\"1 st\"}]",
            IngredientsEn = "[{\"name\":\"Sandwich bread\",\"amount\":\"1 loaf\"},{\"name\":\"Shrimp\",\"amount\":\"200 g\"},{\"name\":\"Salmon\",\"amount\":\"150 g\"},{\"name\":\"Mayonnaise\",\"amount\":\"200 g\"},{\"name\":\"Cream\",\"amount\":\"200 ml\"},{\"name\":\"Cucumber\",\"amount\":\"1\"}]",
            InstructionsSv = "1. Skär brödet i lager.\n2. Blanda fyllningar med majonnäs.\n3. Bred fyllning mellan brödlagren.\n4. Vispa grädden och täck utsidan.\n5. Dekorera med räkor, lax och gurka.",
            InstructionsEn = "1. Slice bread into layers.\n2. Mix fillings with mayonnaise.\n3. Spread filling between bread layers.\n4. Whip cream and cover the outside.\n5. Decorate with shrimp, salmon, and cucumber.",
            ImageUrl = "https://images.unsplash.com/photo-1565958011703-44f9829ba187?w=800"
        },
        new Recipe
        {
            Id = 23,
            Name = "Köttfarslimpa",
            Cuisine = "Swedish",
            Difficulty = "Easy",
            CookingTime = 60,
            Tags = ["Swedish", "Meatloaf", "Comfort", "Lingonberry"],
            PersonaTextSv = "Svensk köttfarslimpa — mysig, pålitlig och alltid där för dig. Lingonsylt på sidan, inga frågor.",
            PersonaTextEn = "Swedish meatloaf — cozy, reliable, and always there for you. Lingonberry on the side, no questions asked.",
            IngredientsSv = "[{\"namn\":\"Nötfärs\",\"mängd\":\"600 g\"},{\"namn\":\"Ägg\",\"mängd\":\"2 st\"},{\"namn\":\"Lök\",\"mängd\":\"1 st\"},{\"namn\":\"Mjölk\",\"mängd\":\"100 ml\"},{\"namn\":\"Ströbröd\",\"mängd\":\"4 msk\"},{\"namn\":\"Lingonsylt\",\"mängd\":\"100 g\"}]",
            IngredientsEn = "[{\"name\":\"Ground beef\",\"amount\":\"600 g\"},{\"name\":\"Eggs\",\"amount\":\"2\"},{\"name\":\"Onion\",\"amount\":\"1\"},{\"name\":\"Milk\",\"amount\":\"100 ml\"},{\"name\":\"Breadcrumbs\",\"amount\":\"4 tbsp\"},{\"name\":\"Lingonberry jam\",\"amount\":\"100 g\"}]",
            InstructionsSv = "1. Blanda alla ingredienser utom lingonsylt.\n2. Forma en limpa i en ugnsform.\n3. Grädda på 175°C i 50-60 min.\n4. Servera med potatismos och lingonsylt.",
            InstructionsEn = "1. Mix all ingredients except lingonberry jam.\n2. Shape into a loaf in a baking dish.\n3. Bake at 175°C for 50-60 min.\n4. Serve with mashed potatoes and lingonberry jam.",
            ImageUrl = "https://images.unsplash.com/photo-1529543544282-ea669407fca3?w=800"
        },
        new Recipe
        {
            Id = 24,
            Name = "Pytt i Panna",
            Cuisine = "Swedish",
            Difficulty = "Easy",
            CookingTime = 20,
            Tags = ["Swedish", "Potatoes", "Pan", "Retro"],
            PersonaTextSv = "Kubformad tröst i en panna. Jag är potatis och historia — bäst med stekt ägg ovanpå och inlagda rödbetor.",
            PersonaTextEn = "Cube-shaped comfort in a pan. I'm potatoes and history — best with a fried egg on top and pickled beets.",
            IngredientsSv = "[{\"namn\":\"Potatis\",\"mängd\":\"400 g\"},{\"namn\":\"Köttfärs eller korv\",\"mängd\":\"300 g\"},{\"namn\":\"Lök\",\"mängd\":\"1 st\"},{\"namn\":\"Ägg\",\"mängd\":\"4 st\"},{\"namn\":\"Inlagda rödbetor\",\"mängd\":\"100 g\"}]",
            IngredientsEn = "[{\"name\":\"Potatoes\",\"amount\":\"400 g\"},{\"name\":\"Ground beef or sausage\",\"amount\":\"300 g\"},{\"name\":\"Onion\",\"amount\":\"1\"},{\"name\":\"Eggs\",\"amount\":\"4\"},{\"name\":\"Pickled beets\",\"amount\":\"100 g\"}]",
            InstructionsSv = "1. Koka och tärna potatisen.\n2. Stek potatis och lök i smör tills gyllengula.\n3. Tillsätt köttet, stek tills genomstekt.\n4. Stek äggen separat.\n5. Servera med ägg ovanpå och rödbetor på sidan.",
            InstructionsEn = "1. Boil and dice the potatoes.\n2. Fry potatoes and onion in butter until golden.\n3. Add meat, fry until cooked through.\n4. Fry eggs separately.\n5. Serve with egg on top and beets on the side.",
            ImageUrl = "https://images.unsplash.com/photo-1518779578993-ec3579fee39f?w=800"
        },
        new Recipe
        {
            Id = 25,
            Name = "Wonton Soup",
            Cuisine = "Chinese",
            Difficulty = "Medium",
            CookingTime = 45,
            Tags = ["Soup", "Dumplings", "Broth", "Comfort"],
            PersonaTextSv = "Delikat, värmande och förvånansvärt djup. Mina wontons håller hemligheter. En sked och du är hemma.",
            PersonaTextEn = "Delicate, warming, and surprisingly deep. My wontons hold secrets. One spoonful and you're home.",
            IngredientsSv = "[{\"namn\":\"Wontonskinn\",\"mängd\":\"24 st\"},{\"namn\":\"Fläskfärs\",\"mängd\":\"200 g\"},{\"namn\":\"Räkor\",\"mängd\":\"100 g\"},{\"namn\":\"Kycklingbuljong\",\"mängd\":\"1 liter\"},{\"namn\":\"Ingefära\",\"mängd\":\"1 msk\"},{\"namn\":\"Salladslök\",\"mängd\":\"2 st\"}]",
            IngredientsEn = "[{\"name\":\"Wonton wrappers\",\"amount\":\"24\"},{\"name\":\"Ground pork\",\"amount\":\"200 g\"},{\"name\":\"Shrimp\",\"amount\":\"100 g\"},{\"name\":\"Chicken broth\",\"amount\":\"1 liter\"},{\"name\":\"Ginger\",\"amount\":\"1 tbsp\"},{\"name\":\"Spring onion\",\"amount\":\"2\"}]",
            InstructionsSv = "1. Blanda fläskfärs med hackade räkor, ingefära och soja.\n2. Lägg fyllning i varje wontonskinn och vik ihop.\n3. Koka kycklingbuljong med ingefära.\n4. Koka wontons i buljongen 4-5 min.\n5. Servera garnerat med salladslök.",
            InstructionsEn = "1. Mix ground pork with chopped shrimp, ginger, and soy.\n2. Place filling in each wrapper and fold.\n3. Bring chicken broth to boil with ginger.\n4. Cook wontons in broth for 4-5 min.\n5. Serve garnished with spring onion.",
            ImageUrl = "https://images.unsplash.com/photo-1612929633738-8fe44f7ec841?w=800"
        }
    ];
}
