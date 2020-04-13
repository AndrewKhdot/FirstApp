using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Data
{
    public interface IUserRepository
    {
        // Добавление пользователя
        public void AddUser(User user);
                
        // Просмотр пользователя
        public User ReadUser(int id);

        // Просмотр всех пользователей
        public IList<User> ReadAllUsers();
               
        // Изменение пользователя
        public void UpdateUser(User user);
                
        // Удаление пользователя
        public void DeleteUser(User user);
               
    }
}
