using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public class FilmsRepository : IFilmRepository
    {
       

        public void AddFilm(Film film)
        {
            using (Context db = new Context())
            {
                db.Films.Add(film);
                db.SaveChanges();
            }
        }

        public void AddFilms(IList<Film> films)
        {
            using (Context db = new Context())
            {
                foreach (Film f in films)
                {
                    db.Films.Add(f);
                }
                db.SaveChanges();
            }
        }

       
        public void DeleteFilm(Film film)
        {
            using (Context db = new Context())
            {
                db.Films.Remove(film);
                db.SaveChanges();
            }
        }

       
        public IList<Film> ReadFilms()
        {
            using (Context db = new Context())
            {
                var films = db.Films.ToList();
                return films;
            }
        }

               

        public void UpdateFilm(Film film)
        {
            using (Context db = new Context())
            {
                var f = db.Films.Find(film.Id);
                f.Name = film.Name;
                f.Director = film.Director;
                f.Year = film.Year;
                db.SaveChanges();
            }
        }

    }
}
