using DoAn1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DoAn1Context _context;
        public CategoryController(DoAn1Context context)
        {
            _context = context;
        }

        public IActionResult ManageCategories()
        {
            var query = from category in _context.Categories
                        select new Category
                        {
                            CategoryName = category.CategoryName,
                            CategoryId = category.CategoryId,
                            Description = category.Description
                        };
            return View(query);
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ManageCategories));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int CategoryId)
        {
            Category category = await _context.Categories.FindAsync(CategoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(ManageCategories));
        }

        [HttpGet]
        public async Task<IActionResult> DetailCategory(int CategoryId)
        {
            Category category = await _context.Categories.FindAsync(CategoryId);
            if (category == null) return NotFound();
            else return View(category);
        }
        public async Task<IActionResult> DeleteCategory(int? CategoryId, bool? saveChangesError = false)
        {
            if (CategoryId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CategoryId == CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageCategories));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(DeleteCategory), new { CategoryId = CategoryId, saveChangesError = true });
            }

        }
    }
}
