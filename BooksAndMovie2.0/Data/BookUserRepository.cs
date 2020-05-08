using BooksAndMovie.Model;
using BooksAndMovie2._0.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie2._0.Data
{
    public class BookUserRepository : IBookUserRepository
    {
        private readonly Context _context;

        public BookUserRepository(Context context)
        {
            _context = context;
        }

        public void AddBook(int id, Book book, int? _rating)
        {
            //int count = 0;
            //int rating = 0;
            //int mark = 0;

            //{
            //    Book _book = _context.Books.Find(book.Id);
            //    User _user = _context.Users.Find(id);                
            //    var bookusers = _context.BookUser.Where(p => p.BookId == book.Id&&p.Rating!=null);
            //    if (bookusers.Any() && _rating!= null)
            //    {                    
            //            foreach (BookUser bu in bookusers)
            //            {  
            //                    mark = (int)bu.Rating;
            //                    count = count + 1;
            //                    rating = rating + mark;

            //            }
            //            mark = (int)_rating;
            //            rating = rating + mark;
            //            count = count + 1;
            //            rating = rating / count;
            //            _book.Rating = rating;

            //    }
            //    else if (_rating != null)
            //    {
            //        _book.Rating = _rating;

            //    }

           
            //_context.Books.Update(_book);
                BookUser _bu = new BookUser();
                _bu.UserId = id;                
                _bu.BookId = book.Id;
                _bu.Rating = _rating;
                _context.BookUser.Add(_bu);
                _context.SaveChanges();
            ChangeRating(id, book, _rating);
            //}
        }
        public void ChangeRating(int id, Book book, int? _rating)
        {
            int count = 0;            
            int mark = 0;
            int rating = 0;

            {
                Book _book = _context.Books.Find(book.Id);
                BookUser _bookuser = _context.BookUser.First(p => p.BookId == book.Id&&p.UserId == id);
                var bookusers = _context.BookUser.Where(p => p.BookId == book.Id && p.Rating != null);
                if (bookusers.Any())
                {
                    foreach (BookUser bu in bookusers)
                    {
                            mark = (int)bu.Rating;
                            count = count + 1;
                            rating = rating + mark;
                        
                    }
                    if (_rating != null&& _bookuser.Rating != null)
                    {
                       
                            mark = (int)_rating;
                            rating = rating + mark -(int)_bookuser.Rating;                            
                            rating = rating / count;
                            _book.Rating = rating;

                    }
                    else if (_bookuser.Rating != null)
                    {
                        
                        rating = rating  - (int)_bookuser.Rating;
                        count = count - 1;
                        if (count < 1)
                        {
                            _book.Rating = null;                            
                            
                        }
                        else
                        {
                            rating = rating / count;
                            _book.Rating = rating;
                        }                        
                    }
                    else if (_rating != null)
                    {
                        mark = (int)_rating;
                        rating = rating + mark;
                        count = count + 1;
                        rating = rating / count;
                    }
                    else
                    {
                        _book.Rating = null;
                    }
                }
                else
                {                    
                    _book.Rating = _rating;                 
                }


                _context.Books.Update(_book);
                _bookuser.Rating = _rating;
                _context.BookUser.Update(_bookuser);
                _context.SaveChanges();
            }
        }

        public void RemoveBook (int id, Book book)
        {
            //int count = 0;
            //int rating = 0;
            //int mark = 0;

            //{
            BookUser _bookuser = _context.BookUser.First(p => p.BookId == book.Id && p.UserId == id);
            //    if (_bookuser.Rating != null)
            //    {
            //        var bookusers = _context.BookUser.Where(p => p.BookId == book.Id && p.Rating != null && p.UserId != id);

            //        if (bookusers.Any())
            //        {
            //            foreach (BookUser bu in bookusers)
            //            {
            //                mark = (int)bu.Rating;
            //                count = count + 1;
            //                rating = rating + mark;
            //            }                        
            //            rating = rating / count;

            //        }
            //        else
            //        {
            //            book.Rating = null;
            //        }
            //    }
            //    else
            //    {

            //    }

            ChangeRating(id, book, null);
                

                _context.BookUser.Remove(_bookuser);
                //_context.SaveChanges();
                //_context.Books.Update(book);
                _context.SaveChanges();
            //}
        }
        public IList<BookUser> ReadBooks()
        {
            //using (Context db = new Context())
            //{
            var books = _context.BookUser
                .Include(u=>u.Book)
                .Include(u => u.User).ToList();
            return books;
            //}
        }
    }
}
