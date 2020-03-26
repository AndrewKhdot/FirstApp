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
       
        public void AddUser(User user)
        {
            using(Context db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

     

        public void DeleteUser(User user)
        {
            using (Context db = new Context())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }
        public IList<User> ReadAllUsers()
        {
            using (Context db = new Context())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

      

        public User ReadUser(int id)
        {
            using (Context db = new Context())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }


        public void UpdateUser(User user)
        {
            using (Context db = new Context())
            {
                var u = db.Users.Find(user.Id);
              
                u = user;
                db.SaveChanges();
            }
        }
    }
}
