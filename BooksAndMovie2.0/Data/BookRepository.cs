using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public class BookRepository : IBookRepository

    {
        private readonly Context _context;

        public BookRepository (Context context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
        }

        public void AddBooks(IList<Book> books)
        {
            
            
                //foreach (Book b in books)
                //{
                _context.Books.AddRange(books);
                //}
                _context.SaveChanges();
            
        }


        public void DeleteBook(Book book)
        {
            
                _context.Books.Remove(book);
                _context.SaveChanges();
           
        }

       
        public IList<Book> ReadBooks()
        {
            //using (Context db = new Context())
            //{
                var books = _context.Books.ToList();
                return books;
            //}
        }


        public void UpdateBook(Book book)
        {
            //using (Context db = new Context())
            //{
                _context.Books.Update(book);
                
            _context.SaveChanges();
            //}
        }
                
    }
}

