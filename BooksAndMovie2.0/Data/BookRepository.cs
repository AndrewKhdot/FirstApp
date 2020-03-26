using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            using (Context db = new Context())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public void AddBooks(IList<Book> books)
        {
            using (Context db = new Context())
            {
                //foreach (Book b in books)
                //{
                    db.Books.AddRange(books);
                //}
                db.SaveChanges();
            }
        }


        public void DeleteBook(Book book)
        {
            using (Context db = new Context())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

       
        public IList<Book> ReadBooks()
        {
            using (Context db = new Context())
            {
                var books = db.Books.ToList();
                return books;
            }
        }


        public void UpdateBook(Book book)
        {
            using (Context db = new Context())
            {
                var b = db.Books.Find(book.Id);
                b.Name = book.Name;
                b.Autor = book.Autor;
                b.Year = book.Year;
                db.SaveChanges();
            }
        }
                
    }
}

