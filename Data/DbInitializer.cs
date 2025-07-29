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
                },

                // ✅ Desserts
                new Recipe
                {
                    Title = "Chocolate Cake",
                    Ingredients = "Flour, Cocoa, Sugar, Eggs, Butter",
                    Instructions = "Mix ingredients. Bake at 350°F for 30 mins.",
                    Category = "Desserts",
                    Picture = "https://www.allrecipes.com/thmb/zb8muWE6CQ5XjclY_LQ2i-QwxN0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/17981-one-bowl-chocolate-cake-iii-DDMFS-beauty-4x3-d2e182087e4b42a3a281a0a355ea60d1.jpg"
                },
                new Recipe
                {
                    Title = "Cheesecake",
                    Ingredients = "Cream Cheese, Sugar, Eggs, Graham Cracker Crust",
                    Instructions = "Blend ingredients. Bake and chill.",
                    Category = "Desserts",
                    Picture = "https://cdn.apartmenttherapy.info/image/upload/f_auto,q_auto:eco,c_fill,g_auto,w_1500,ar_3:2/k%2FPhoto%2FSeries%2F2024-07-how-to-make-perfect-cheesecake%2Fhow-to-make-perfect-cheesecake-319"
                },
                new Recipe
                {
                    Title = "Apple Pie",
                    Ingredients = "Apples, Sugar, Butter, Flour",
                    Instructions = "Prepare crust. Fill with apples. Bake until golden.",
                    Category = "Desserts",
                    Picture = "https://www.recipetineats.com/tachyon/2022/11/Apple-Pie_8.jpg?resize=500%2C500"
                },
                new Recipe
                {
                    Title = "Tiramisu",
                    Ingredients = "Mascarpone, Coffee, Cocoa, Ladyfingers",
                    Instructions = "Layer ingredients. Chill before serving.",
                    Category = "Desserts",
                    Picture = "https://www.kingarthurbaking.com/sites/default/files/2023-03/Tiramisu_1426.jpg"
                },
                new Recipe
                {
                    Title = "Brownies",
                    Ingredients = "Chocolate, Butter, Sugar, Eggs, Flour",
                    Instructions = "Mix ingredients. Bake until fudgy.",
                    Category = "Desserts",
                    Picture = "https://www.allrecipes.com/thmb/GSiVp8ogaeOvWDua-AJ_S9QaN_s=/0x512/filters:no_upscale():max_bytes(150000):strip_icc()/AR-9599-Quick-Easy-Brownies-ddmfs-4x3-697df57aa40a45f8a7bdb3a089eee2e5.jpg"
                },
                new Recipe
                {
                    Title = "Ice Cream Sundae",
                    Ingredients = "Ice Cream, Chocolate Syrup, Nuts, Whipped Cream",
                    Instructions = "Scoop ice cream. Add toppings and serve.",
                    Category = "Desserts",
                    Picture = "https://www.southernliving.com/thmb/B74rDMrcDg4M0aXrcopZzDHi0do=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Hot-Fudge_step6_-074-f46b36d441984931b6f9d0b055c8f56b.jpg"
                }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
