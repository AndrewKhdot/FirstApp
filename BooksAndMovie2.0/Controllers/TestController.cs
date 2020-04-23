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
            return View(users);
        }

        public IActionResult ChooseUser()
        {
           
            IList<User> users = _userrep.ReadAllUsers();
            
            SelectList Users = new SelectList(users, "Id", "Name");
            
            return View(users);
        }

        //[HttpGet, ActionName("ChosenUser")]
        public IActionResult ChosenUser(int id)
        {

            //IList<User> users = _userrep.ReadAllUsers();
            //User user = users.First(p => p.Id == id);
            IList<BookUser> _bookusers = _burep.ReadBooks();
            IEnumerable<BookUser> bookusers = _bookusers.Where(p => p.UserId == id);
            //IList<Book> _books = _bookrep.ReadBooks();
            //List<Book> books = new List<Book>();
            //foreach (BookUser bu in bookusers)
            //{
            //    books.Add(_books.First(p => p.Id == bu.BookId ));
            //}
            //ViewBag.User = user;
            //BooksAdder ba = new BooksAdder();
            //ba.Run();
            //_context.Books.AddRange(ba.Run());
            //Book book = new Book() { Id = 1, Name = "Дом в котором", Autor = "Мариам Петросян" };
            //_context.Books.Add(book);
            //await _context.SaveChangesAsync();
            return View(bookusers);
            //return Content(id.ToString());
        }

        

        public IActionResult AddMyBooks(int id)
        {                          
            IList<Book> books = _bookrep.ReadBooks();
            IList<User> users = _userrep.ReadAllUsers();
            IList<BookUser> booksuser = _burep.ReadBooks();
            var _bookusers = booksuser.Where((p => p.UserId == id));
            foreach(BookUser bu in _bookusers)
            {
                Book book = books.First(p => p.Id == bu.BookId);
                books.Remove(book);
            }            
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
            return RedirectToAction("ChosenUser", "Test", new { id = id }); 

        }
        public IActionResult MyBooks(int id)
        {
            //IList<User> users = _userrep.ReadAllUsers();
            //User user = users.First(p => p.Id == id);
            IList<BookUser> bookusers = _burep.ReadBooks();
            var _bookusers = bookusers.Where(p => p.UserId == id);
            //IList<Book> _books = _bookrep.ReadBooks();
            //IList<Book> books = new List<Book>();
            //foreach (BookUser bu in _bookusers)
            //{
            //    books.Add(_books.First(p => p.Id == bu.BookId));
            //}
            
            //ViewBag.User = user;
            //int?[] rt = new int?[12];
            //for (int i = 0; i < 11; i++)
            //    {
            //       rt[i] = i;
            //    }
            
            //ViewBag.List = rt;
            return View(_bookusers);

        }

        [HttpPost, ActionName("ChangeMyBooks")]

        public IActionResult ChangeMyBooks(int id, IList<int> bookid)
        {
            IList<Book> books = _bookrep.ReadBooks();
            //IList<User> users = _userrep.ReadAllUsers();
            //User _user = users.First(p => p.Id == id);
            //List<string> booknames = new List<string>();
            //List<string> bookr = new List<string>();
            foreach (int i in bookid)
            {
                Book book =  books.First(p => p.Id == i);
                int _rating;
                string s = Request.Form[i.ToString()];
                if (s == "" || s == "null")
                {
                    _burep.ChangeRating(id, book, null);
                }
                else
                {
                    _rating = Int32.Parse(s);
                    _burep.ChangeRating(id, book, _rating);
                }
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
            return RedirectToAction("ChosenUser", "Test", new { id = id });
        }
        public IActionResult DeleteBook(int bookid, int userid)
        {
            //IList<User> users = _userrep.ReadAllUsers();
            //User user = users.First(p => p.Id == userid);
            IList<BookUser> bookusers = _burep.ReadBooks();
            //var _bookusers = bookusers.Where(p => p.UserId == userid);
            //IList<Book> books = _bookrep.ReadBooks();
            BookUser book = bookusers.First(p => p.BookId == bookid && p.UserId == userid);          
            //ViewBag.User = user;
            return View(book);
        }
        //[HttpPost, ActionName("DeleteMyBooks")]
        public IActionResult DeleteMyBook(int bookid, int userid)
        {
            IList<User> users = _userrep.ReadAllUsers();
            User user = users.First(p => p.Id == userid);
            IList<BookUser> bookusers = _burep.ReadBooks();
            var _bookusers = bookusers.Where(p => p.UserId == userid);
            IList<Book> books = _bookrep.ReadBooks();
            Book book = books.First(p => p.Id == bookid);
            _burep.RemoveBook(userid, book);
            return RedirectToAction("ChosenUser", "Test", new { id = userid });
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

        public IActionResult FindIntrestingUsers(int id)
        {
            IList<User> _users = _userrep.ReadAllUsers();
            User user = _users.First(p => p.Id == id);
            IList<BookUser> bookusers = _burep.ReadBooks();
            var _bookusers = bookusers.Where(p => p.UserId == id);
            Dictionary<int, int> sumrating = new Dictionary<int, int>();
            foreach (BookUser bu in _bookusers)
            {
                var _booksus = bookusers.Where(p => p.BookId == bu.BookId&&p.Rating!=null&&p.UserId!=id);
                foreach (BookUser _bu in _booksus)
                {
                    if(sumrating.ContainsKey(_bu.UserId))
                    {
                        sumrating[_bu.UserId] = sumrating[_bu.UserId] + (int)_bu.Rating;
                    }
                    else
                    {
                        sumrating.Add(_bu.UserId, (int)_bu.Rating);
                    }
                }
            }
            int i = 0;
            int[] usersid = new int[3];
            IList<User> users = new List<User>();
            sumrating.OrderBy(p => p.Value);
            for (i=0; i<2; i++)
            {
                //if (i < 2)
                //{
                int ids = sumrating.First().Key;
                    User _user = _users.First(p => p.Id == ids);
                    users.Add(_user);
                sumrating.Remove(ids);
                //    i++;
                //}
                //else
                //{
                //    break;
                //}
            }
            int rang = users.Count;

            ViewBag.User = user;
            return View(users);
        }

        
             public IActionResult AddUsersBooks(int myid, int userid)
        {
            IList<User> users = _userrep.ReadAllUsers();
            IList<Book> _books = _bookrep.ReadBooks();
            IList<int> usersbooks = new List<int>();
            IList<int> mybooks = new List<int>();            
            IList<BookUser> booksuser = _burep.ReadBooks();
            IList<Book> books = new List<Book>();
            var _bookusers = booksuser.Where(p => p.UserId == userid );
            var _bookusersmy = booksuser.Where(p => p.UserId == myid);
            foreach (BookUser bu in _bookusers)
            {
                usersbooks.Add(bu.BookId);               
            }
            foreach (BookUser bu in _bookusersmy)
            {
               mybooks.Add(bu.BookId);
            }
            var showbooks = usersbooks.Except(mybooks);
            foreach (int sb in showbooks)
            {
                books.Add(_books.First(p => p.Id == sb));
            }
            User user = users.First(p => p.Id == myid);
            
            ViewBag.User = user;

            return View(books);

        }
        

        
        public IActionResult ChangeBookRating()
        {            
            IList<User> users = _userrep.ReadAllUsers();
            
            return View(users);
        }

    }
}