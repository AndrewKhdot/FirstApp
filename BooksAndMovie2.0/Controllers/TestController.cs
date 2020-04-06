using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAndMovie.Data;
using BooksAndMovie.Logic;
using BooksAndMovie.Model;
using BooksAndMovie2._0.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAndMovie2._0.Controllers
{
    public class TestController : Controller
    {
        private readonly IBookRepository _context;

        public TestController (IBookRepository context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            //BooksDeleter ba = new BooksDeleter(_context);
            //ba.Initialize();
            //BooksAdder ba = new BooksAdder(_context);
            //ba.Initialize();
            return View();
        }

       

        public IActionResult AddMyBooks()
        {
            IList<Book> books = _context.ReadBooks();
            //BooksAdder ba = new BooksAdder();
            //ba.Run();
            //_context.Books.AddRange(ba.Run());
            ////Book book = new Book() { Id = 1, Name = "Дом в котором", Autor = "Мариам Петросян" };
            ////_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            return View(books);
        }

        [HttpPost, ActionName("AddMyBooks")]

        public IActionResult AddMyBooks(string user, IList<string> check)
        {
            string numbers = user;
            int id = 0;
            int sum = 0;
            //if (check!=null)
            //{
            //    try
            //    {
            foreach (string ids in check)
                    {

                      id = Int32.Parse(ids);
                     sum = sum + id;
                    }
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //            throw;

            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //BooksAdder ba = new BooksAdder();
            //ba.Run();
            //_context.Books.AddRange(ba.Run());
            ////Book book = new Book() { Id = 1, Name = "Дом в котором", Autor = "Мариам Петросян" };
            ////_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            numbers = numbers + sum.ToString();
            return Content( numbers);
        }

    }
}