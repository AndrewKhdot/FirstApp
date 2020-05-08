using BooksAndMovie.Data;
using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie2._0.Data
{
    public class BooksDeleter
    {
        private readonly IBookRepository _context;

        public BooksDeleter (IBookRepository context)
        {
            _context = context;
        }
        public void Initialize()
        {
            var l = _context.ReadBooks();
            if (l.Any())
            {                                
                int count = 0;                                                                   
                while (l[count] != null)
                {                    
                    _context.DeleteBook(l[count]);
                    count = count + 1;
                }
                

            }

            //return books;


            //BookRepository br = new BookRepository();
            //_br.AddBooks(books);
        }

        internal static void Initialize(int v, object context)
        {
            throw new NotImplementedException();
        }
    }
}
