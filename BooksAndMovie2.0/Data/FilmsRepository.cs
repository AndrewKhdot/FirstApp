using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public class FilmsRepository : IFilmRepository
    {
        private readonly Context _context;

        public FilmsRepository (Context context)
        {
            _context = context;
        }


        public void AddFilm(Film film)
        {
            //using (Context db = new Context())
            //{
                _context.Films.Add(film);
                _context.SaveChanges();
            //}
        }

        public void AddFilms(IList<Film> films)
        {
            //using (Context db = new Context())
            //{
                foreach (Film f in films)
                {
                _context.Films.Add(f);
                }
            _context.SaveChanges();
            //}
        }

       
        public void DeleteFilm(Film film)
        {
            //using (Context db = new Context())
            //{
            _context.Films.Remove(film);
            _context.SaveChanges();
            //}
        }

       
        public IList<Film> ReadFilms()
        {
            //using (Context db = new Context())
            //{
                var films = _context.Films.ToList();
                return films;
            //}
        }

               

        public void UpdateFilm(Film film)
        {
            //using (Context db = new Context())
            //{
                var f = _context.Films.Find(film.Id);
                f.Name = film.Name;
                f.Director = film.Director;
                f.Year = film.Year;
            _context.SaveChanges();
            //}
        }

    }
}
