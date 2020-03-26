using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Model
{
    public class Book : IMediaContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set ; }

        public string Autor { get; set; }

       
    }
}
