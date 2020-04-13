using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAndMovie.Data;
using BooksAndMovie.Logic;
using BooksAndMovie.Model;
using BooksAndMovie2._0.Data;
using BooksAndMovie2._0.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Schema;

namespace BooksAndMovie2._0.Controllers
{
    public class TestController : Controller
    {
        private readonly IBookRepository _bookrep;
        private readonly IUserRepository _userrep;
        private readonly IBookUserRepository _burep;

        public TestController (IBookRepository bookrep, IUserRepository userrep, IBookUserRepository burep)
        {
            _bookrep = bookrep;
            _userrep = userrep;
            _burep = burep;
        }
       
        public IActionResult Index()
        {
            IList<User> users = _userrep.ReadAllUsers();
            //BooksDeleter ba = new BooksDeleter(_bookrep);
            //ba.Initialize();
            //DataBaseInitialser ba = new DataBaseInitialser(_bookrep);
            //ba.Initialize();
            return View(users);
        }

        public IActionResult ChooseUser()
        {
           
            IList<User> users = _userrep.ReadAllUsers();
            
            SelectList Users = new SelectList(users, "Id", "Name");
            
            //BooksAdder ba = new BooksAdder();
            //ba.Run();
            //_context.Books.AddRange(ba.Run());
            ////Book book = new Book() { Id = 1, Name = "Дом в котором", Autor = "Мариам Петросян" };
            ////_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            return View(users);
        }

        [HttpPost, ActionName("ChosenUser")]
        public IActionResult ChosenUser(int id)
        {

            IList<User> users = _userrep.ReadAllUsers();
            User user = users.First(p => p.Id == id);
            //BooksAdder ba = new BooksAdder();
            //ba.Run();
            //_context.Books.AddRange(ba.Run());
            //Book book = new Book() { Id = 1, Name = "Дом в котором", Autor = "Мариам Петросян" };
            //_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            return View(user);
            //return Content(id.ToString());
        }

        

        public IActionResult AddMyBooks(int id)
        {                          
            IList<Book> books = _bookrep.ReadBooks();
            IList<User> users = _userrep.ReadAllUsers();
            //IList<BookUser> bookuser = _burep.ReadBooks();
            User user = users.First(p => p.Id == id);
            //List<Book> _books = new List<Book>();
            //foreach (BookUser bu in bookuser)
            //{
            //    if (bu.UserId != id)
            //        _books.Add(books.First(p => p.Id == bu.BookId));
            //}
            ViewBag.User = user;
            
            return View(books);

        }

        [HttpPost, ActionName("AddMyBooks")]

        public IActionResult AddMyBooks(int id, IList<string> check)
        {
            IList<Book> books = _bookrep.ReadBooks();
            IList<User> users = _userrep.ReadAllUsers();
            User _user = users.First(p => p.Id == id);
            List<string> booknames = new List<string>();
            foreach (string c in check)
            {
                int bookid = Int32.Parse(c);
                Book book = books.First(p => p.Id == bookid);
                _burep.AddBook(id, book, null);
                booknames.Add(book.Name);
            }
            //List<int> bookids = Int32.Parse(check.FirstOrDefault());
            //IList<Book> books = _bookrep.ReadBooks();
            
            //int id = ViewBag.id;
            //_burep.AddBook(_user.Id, book, null);


            //int sum = 0;            
            //foreach (string ids in check)
            //        {

            //          id = Int32.Parse(ids);
            //         sum = sum + id;
            //        }
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
            //return Content(_user.Id.ToString());
            return Content(booknames.ToString() + _user.Name);

        }
        public IActionResult MyBooks(int id)
        {
            IList<User> users = _userrep.ReadAllUsers();
            User user = users.First(p => p.Id == id);
            IList<BookUser> bookusers = _burep.ReadBooks();
            var _bookusers = bookusers.Where(p => p.UserId == id);
            IList<Book> _books = _bookrep.ReadBooks();
            IList<Book> books = new List<Book>();
            foreach (BookUser bu in _bookusers)
            {
                books.Add(_books.First(p => p.Id == bu.BookId));
            }
            
            ViewBag.User = user;
            int?[] rt = new int?[12];
            for (int i = 0; i < 11; i++)
                {
                   rt[i] = i;
                }
            
            ViewBag.List = rt;
            return View(books);

        }

        [HttpPost, ActionName("ChangeMyBooks")]

        public IActionResult ChangeMyBooks(int id, IList<int> bookid)
        {
            IList<Book> books = _bookrep.ReadBooks();
            IList<User> users = _userrep.ReadAllUsers();
            User _user = users.First(p => p.Id == id);
            List<string> booknames = new List<string>();
            List<string> bookr = new List<string>();
            foreach (int i in bookid)
            {
                Book book =  books.First(p => p.Id == i);
                int? _rating = null;
                string s = Request.Form[i.ToString()];
                    switch (s)
                {
                    case "Любимая":
                        _rating = 10;
                        break;
                    case "Хорошая" :
                        _rating = 7;
                        break;
                    case "Плохая":
                        _rating = 2;
                        break;
                    default:
                        _rating = null;
                        break;
                }
                _burep.ChangeRating(id, book, _rating);
            }
            //foreach (int j in del)
            //{
            //    Book book = books.First(p => p.Id == j);
            //    _burep.RemoveBook(id, book);
            //}
            //foreach (string r in rating)
            //{
            //    _burep.ChangeRating(_user.Id, b, b.Rating);
            //    booknames.Add(b.Name);
            //    bookr.Add(b.Rating.ToString());
            //}
            //foreach (Book b in check)
            //{             
            //    _burep.ChangeRating(_user.Id, b, b.Rating);
            //    booknames.Add(b.Name);
            //    bookr.Add(b.Rating.ToString());
            //}
            return Content("chek");
        }
        public IActionResult DeleteBooks(int id)
        {
            IList<User> users = _userrep.ReadAllUsers();
            User user = users.First(p => p.Id == id);
            IList<BookUser> bookusers = _burep.ReadBooks();
            var _bookusers = bookusers.Where(p => p.UserId == id);
            IList<Book> _books = _bookrep.ReadBooks();
            IList<Book> books = new List<Book>();
            foreach (BookUser bu in _bookusers)
            {
                books.Add(_books.First(p => p.Id == bu.BookId));
            }

            ViewBag.User = user;

            return View(books);

        }

        [HttpPost, ActionName("DeleteBooks")]

        public IActionResult DeleteBooks (int id, IList<string> del)
        {
            IList<Book> books = _bookrep.ReadBooks();
            IList<User> users = _userrep.ReadAllUsers();
            User _user = users.First(p => p.Id == id);
            List<string> booknames = new List<string>();
            foreach (string c in del)
            {
                int bookid = Int32.Parse(c);
                Book book = books.First(p => p.Id == bookid);
                _burep.RemoveBook(id, book);
                booknames.Add(book.Name);
            }            
            return Content(booknames.ToString() + _user.Name);

        }
        public IActionResult ChangeBookRating()
        {            
            IList<User> users = _userrep.ReadAllUsers();
            
            return View(users);
        }

    }
}