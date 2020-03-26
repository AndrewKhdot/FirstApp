using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Model
{
    interface IMediaContent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Year { get; set; }
    }
}
