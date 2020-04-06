using BooksAndMovie.Data;
using BooksAndMovie.Model;
using BooksAndMovie2._0.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Logic
{
    public   class BooksAdder
    {
        private readonly IBookRepository _context;

        public BooksAdder (IBookRepository context)
        {
            _context = context;
        }
        public void Initialize()
        {
            var l = _context.ReadBooks();
            if (!l.Any())
            {
                string[] lines = new string[300];

                string path = @"D:\My projects\BooksAndMovie\BooksAndMovie\wwwroot\boooks.txt";
                int count = 0;
                List<Book> books = new List<Book>();
                string text;

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines[count] = line;

                        count++;
                    }
                }

                count = 0;

                while (lines[count] != null)
                {
                    text = lines[count];
                    string ch = "—";
                    text = text.Replace("-", "—");
                    int index = text.IndexOf(ch);
                    string autor = text.Substring(index + 1);
                    string name = text.Substring(0, index);                    
                    books.Add(new BookBuilder(name, autor).Creat());

                    count = count + 1;
                }
                _context.AddBooks(books);
                
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
