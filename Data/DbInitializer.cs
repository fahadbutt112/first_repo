using MvcRecipeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcRecipeApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            // Apply any pending migrations (optional but useful during dev)
            context.Database.Migrate();

            // Skip seeding if recipes already exist
            if (context.Recipes.Any())
                return;

            var recipes = new List<Recipe>
            {
                new Recipe { Title = "Spaghetti Bolognese", Ingredients = "Spaghetti, Beef, Tomato Sauce", Instructions = "Boil pasta. Cook beef. Mix with sauce.", Category = "Italian" },
                new Recipe { Title = "Chicken Biryani", Ingredients = "Chicken, Rice, Spices", Instructions = "Marinate chicken. Cook rice. Layer and steam.", Category = "Asian" },
                new Recipe { Title = "Pancakes", Ingredients = "Flour, Eggs, Milk, Sugar", Instructions = "Mix ingredients. Cook on griddle.", Category = "Breakfast" },
                new Recipe { Title = "Tacos", Ingredients = "Tortilla, Beef, Lettuce, Cheese", Instructions = "Prepare filling. Stuff tortillas.", Category = "Mexican" },
                new Recipe { Title = "Greek Salad", Ingredients = "Cucumber, Tomato, Feta, Olives", Instructions = "Chop ingredients. Mix together.", Category = "Salad" }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
