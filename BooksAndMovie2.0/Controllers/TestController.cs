using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAndMovie.Logic;
using BooksAndMovie.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndMovie2._0.Controllers
{
    public class TestController : Controller
    {
        private readonly Context _context;

        public TestController (Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddConfirmed()
        {
            BooksAdder ba = new BooksAdder();
            _context.AddRange(ba.Run());
            await _context.SaveChangesAsync();
            return View("Books/Index");
        }

    }
}