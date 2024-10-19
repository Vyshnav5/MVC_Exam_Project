using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project4.Data;
using MVC_Project4.Models;

namespace MVC_Project4.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Movie_tb != null ?
            View(await _context.Movie_tb.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.movie' is null.");
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.Movie_tb == null)
            {
                return NotFound();
            }
            var Movie_tb = await _context.Movie_tb.FindAsync(Id);
            if (Movie_tb == null)
            {
                return NotFound();
            }
            return View(Movie_tb);
        }
        [HttpPost]
        public async Task<IActionResult> Createins(movie mov)
        {
            if (ModelState.IsValid)
            {
                _context.Movie_tb.Add(mov);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, movie movie)
        {
            if (Id != movie.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!MovieExists(movie.Id))
                    //{
                    //    return NotFound();
                    //}
                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null || _context.Movie_tb == null)
            {
                return NotFound();
            }
            var Movie_tb = await _context.Movie_tb.FindAsync(Id);
            if (Movie_tb == null)
            {
                return NotFound();
            }
            return View(Movie_tb);
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.Movie_tb == null)
            {
                return NotFound();
            }
            var Movie_tb = await _context.Movie_tb.FindAsync(Id);
            if (Movie_tb == null)
            {
                return NotFound();
            }
            return View(Movie_tb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            {
                if (_context.Movie_tb == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.movie' is null.");
                }
                var category = await _context.Movie_tb.FindAsync(Id);
                if (category != null)
                {
                    _context.Movie_tb.Remove(category);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }




        }
    }
}
