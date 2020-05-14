using BooksAndMovie2._0.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Model
{
    public class User : IdentityUser
    {
        
        public string Name { get; set; }
        public List<FilmUser> FilmUser { get; set; }
        public List<BookUser> BookUser { get; set; }
      
        public User()
        {
            BookUser = new List<BookUser>();

            FilmUser = new List<FilmUser>();

        }



    }
}
