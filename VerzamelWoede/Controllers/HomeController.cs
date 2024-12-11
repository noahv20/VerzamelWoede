using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VerzamelWoede.Data;
using VerzamelWoede.Models;
using VerzamelWoede.ViewModels;

namespace VerzamelWoede.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            if (userId == null)
            {
                return NotFound();
            }
            if (categoryId != null)
            {
                var items = await _context.Items
                    .Include(i => i.Category)
                    .Where(c => c.CategoryId == categoryId)
                    .Include(i => i.Collections)
                    .Where(i => i.Collections.Any(c => c.UserId == userId))
                    .ToListAsync();

                var categories = await _context.Categories.ToListAsync();

                var vm = new CategoryItem()
                {
                    Items = items,
                    Categories = categories
                };
                return View(vm);
            }
            else
            {
                var items = await _context.Items
                    .Include(i => i.Category)
                    .Include(i => i.Collections)
                    .Where(i => i.Collections.Any(c => c.UserId == userId))
                    .ToListAsync();

                var categories = await _context.Categories.ToListAsync();

                var vm = new CategoryItem()
                {
                    Items = items,
                    Categories = categories
                };
                return View(vm);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
