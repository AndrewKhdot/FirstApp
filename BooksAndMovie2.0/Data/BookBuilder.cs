using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie2._0.Data
{
    public class BookBuilder
    {
        int Id { get; set; }
        string Name { get; set; }
        string Autor { get; set; }

        public BookBuilder ( string name, string autor, int id)
        {
           this.Id = id;
            this.Name = name;
            this.Autor = autor;
        }
        public Book Creat()
        {
            Book book = new Book();
            book.Id = Id;
            book.Name = Name;
            book.Autor = Autor;
            return book;
        }
    }
}


