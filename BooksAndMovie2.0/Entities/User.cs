using BooksAndMovie2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<FilmUser> FilmUser { get; set; }
        public List<BookUser> BookUser { get; set; }
      
        public User()
        {
            BookUser = new List<BookUser>();

            FilmUser = new List<FilmUser>();

        }



    }
}
