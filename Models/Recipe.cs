using System.ComponentModel.DataAnnotations;

namespace MvcRecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        [Required]
        public required string Category { get; set; }
        public string? Picture { get; set; } 
    }
    }
       
