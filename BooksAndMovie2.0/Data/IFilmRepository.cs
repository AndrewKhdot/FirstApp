using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    interface IFilmRepository
    {
        // Добавление фильма
        public void AddFilm(Film film);

        // Добавление фильмов
        public void AddFilms(IList<Film> films);

        
        // Просмотр всех фильмов
        public IList<Film> ReadFilms();

        // Изменение фильма
        public void UpdateFilm(Film film);

        // Удаление фильма
        public void DeleteFilm(Film film);
    }
}
