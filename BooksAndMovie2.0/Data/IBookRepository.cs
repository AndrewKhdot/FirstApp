using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public interface IBookRepository
    {
        
        // Добавление книги
        public void AddBook(Book book);

        // Добавление книг
        public void AddBooks(IList<Book> books);
               
        // Просмотр всех книг
        public IList<Book> ReadBooks();
               
        // Изменение книги
        public void UpdateBook(Book book);
               
        // Удаление книги
        public void DeleteBook(Book book);

       
    }
}
