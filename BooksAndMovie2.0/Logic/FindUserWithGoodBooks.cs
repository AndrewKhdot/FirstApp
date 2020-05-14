using BooksAndMovie.Data;
using BooksAndMovie.Model;
using BooksAndMovie2._0.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie2._0.Logic
{
    public class FindUserWithGoodBooks
    {
        //private readonly IBookRepository _bookrep;
        //private readonly IUserRepository _userrep;
        //private readonly IBookUserRepository _burep;
        private readonly Context _context;

        //public FindUserWithGoodBooks(IBookRepository bookrep, IUserRepository userrep, IBookUserRepository burep)
        //{
        //    _bookrep = bookrep;
        //    _userrep = userrep;
        //    _burep = burep;
        //}
        public FindUserWithGoodBooks(Context context)
        {
            _context = context;            
        }
        public IList<User> FindUsers (string userid)
        {
            List<User> users = new List<User>();
            var userbooks = _context.BookUser.Where(p => p.UserId ==userid); 
            
            return users;
        }
    }
}
