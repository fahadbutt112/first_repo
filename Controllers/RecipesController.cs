using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcRecipeApp.Data;
using MvcRecipeApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MvcRecipeApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe, IFormFile imageFile)
        {
            if (!ModelState.IsValid) return View(recipe);

            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var fullPath = Path.Combine(imagePath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                recipe.Picture = "/images/" + fileName;
            }

            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe recipe, IFormFile imageFile)
        {
            if (id != recipe.Id) return NotFound();
            if (!ModelState.IsValid) return View(recipe);

            var existingRecipe = await _context.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecipe == null) return NotFound();

            // Keep the existing picture unless replaced
            recipe.Picture = existingRecipe.Picture;

            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                // Delete old image if it exists
                if (!string.IsNullOrEmpty(existingRecipe.Picture))
                {
                    var oldImageFullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingRecipe.Picture.TrimStart('/'));
                    if (System.IO.File.Exists(oldImageFullPath))
                        System.IO.File.Delete(oldImageFullPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var fullPath = Path.Combine(imagePath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                recipe.Picture = "/images/" + fileName;
            }

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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                // Optionally delete image file on deletion (optional logic)
                if (!string.IsNullOrEmpty(recipe.Picture))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", recipe.Picture.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                }

                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
