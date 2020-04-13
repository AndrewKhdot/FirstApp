using BooksAndMovie.Data;
using BooksAndMovie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository (Context context)
        {
            _context = context;
        }


        public void AddUser(User user)
        {
            //using(Context db = new Context())
            //{
            _context.Users.Add(user);
            _context.SaveChanges();
            //}
        }

     

        public void DeleteUser(User user)
        {
            //using (Context db = new Context())
            //{
            _context.Users.Remove(user);
            _context.SaveChanges();
            //}

        }
        public IList<User> ReadAllUsers()
        {
            //using (Context db = new Context())
            //{
                var users = _context.Users.ToList();
                return users;
            //}
        }

      

        public User ReadUser(int id)
        {
            //using (Context db = new Context())
            //{
                var user = _context.Users.Find(id);
                return user;
            //}
        }


        public void UpdateUser(User user)
        {
            //using (Context db = new Context())
            //{
                var u = _context.Users.Find(user.Id);
              
                u = user;
            _context.SaveChanges();
            //}
        }
    }
}
