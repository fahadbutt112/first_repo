using Microsoft.EntityFrameworkCore;
using MvcRecipeApp.Models;

namespace MvcRecipeApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
