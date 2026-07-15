using CoffeeHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalCategories = await _context.Categories.CountAsync();

            ViewBag.DrinksCount = await _context.Products
                .CountAsync(p =>
                    p.Category != null &&
                    (p.Category.Name.Contains("Coffee") ||
                     p.Category.Name.Contains("Drink")));

            ViewBag.DessertsCount = await _context.Products
                .CountAsync(p =>
                    p.Category != null &&
                    p.Category.Name.Contains("Dessert"));

            var featuredProducts = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .Take(3)
                .ToListAsync();

            return View(featuredProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}