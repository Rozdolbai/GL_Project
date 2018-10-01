using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLib.Models;
using BookLib.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BookLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _context = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Books = _context
                .Books
                .OrderByDescending(b => b.BookId)
                .ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Show(int id)
        {
            var book = _context.Books.Find(id);
            var comments = _context.Comments.Where(c => c.BookId == book.BookId).ToList();
            ViewBag.User = _context.Users.Find(book.UserId);
            ViewBag.Comments = comments;

            return View(book);
        }
        
        [HttpPost]
        public async Task<IActionResult> Show([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (comment != null)
                {
                    var userId = _userManager.GetUserId(HttpContext.User);
                    comment.User = _context.Users.Find(userId);
                    comment.Date = DateTime.Now;
                    _context.Comments.Add(comment);
                    await _context.SaveChangesAsync();
                }
            }

            return Redirect(comment.BookId.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
