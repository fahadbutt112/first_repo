using MvcRecipeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcRecipeApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Recipes.Any())
                return;

            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Title = "Spaghetti Bolognese",
                    Ingredients = "Spaghetti, Beef, Tomato Sauce",
                    Instructions = "Boil pasta. Cook beef. Mix with sauce.",
                    Category = "Italian",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZnnZa7F68lZfdDadgCS8BRaKbRs1kDeklAA&s"
                },
                new Recipe
                {
                    Title = "Chicken Biryani",
                    Ingredients = "Chicken, Rice, Spices",
                    Instructions = "Marinate chicken. Cook rice. Layer and steam.",
                    Category = "Asian",
                    Picture = "https://www.cubesnjuliennes.com/wp-content/uploads/2020/07/Chicken-Biryani-Recipe.jpg"
                },
                new Recipe
                {
                    Title = "Pancakes",
                    Ingredients = "Flour, Eggs, Milk, Sugar",
                    Instructions = "Mix ingredients. Cook on griddle.",
                    Category = "Breakfast",
                    Picture = "https://www.bhg.com/thmb/B1Mbx1q9AgIEJ8PbQpPq0QPs820=/4000x0/filters:no_upscale():strip_icc()/bhg-recipe-pancakes-waffles-pancakes-Hero-01-372c4cad318d4373b6288e993a60ca62.jpg"
                },
                new Recipe
                {
                    Title = "Tacos",
                    Ingredients = "Tortilla, Beef, Lettuce, Cheese",
                    Instructions = "Prepare filling. Stuff tortillas.",
                    Category = "Mexican",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzdxrfVemv2SMp8msuEWfrHnSjpAzxD0zfBw&s"
                },
                new Recipe
                {
                    Title = "Greek Salad",
                    Ingredients = "Cucumber, Tomato, Feta, Olives",
                    Instructions = "Chop ingredients. Mix together.",
                    Category = "Salad",
                    Picture = "https://www.simplyrecipes.com/thmb/0NrKQlJ691l6L9tZXpL06uOuWis=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-Easy-Greek-Salad-LEAD-2-4601eff771fd4de38f9722e8cafc897a.jpg"
                }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
