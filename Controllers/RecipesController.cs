using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcRecipeApp.Data;
using MvcRecipeApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRecipeApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context; // 

        public RecipesController(AppDbContext context)
        {
            _context = context; // assignment done because _context is read only
                                // to prevent any direct changes 
        }

        
        public async Task<IActionResult> Index(string search)
        {
            var recipes = _context.Recipes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                recipes = recipes.Where(r =>
                    r.Title.Contains(search) || r.Ingredients.Contains(search));
            }

            return View(await recipes.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (!ModelState.IsValid) return View(recipe);

            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Edit/5 invoked when pressing edit manually or from the url
        public async Task<IActionResult> Edit(int? id) // edit a recipe
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }

        // POST: Recipes/Edit/5 go in page manually then press edit then this function will run
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe recipe) // submit the edit form
        {
            if (id != recipe.Id) return NotFound();
            if (!ModelState.IsValid) return View(recipe);

            try
            {
                _context.Update(recipe);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Recipes.Any(r => r.Id == recipe.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
