using BooksAndMovie.Logic;
using BooksAndMovie2._0.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BooksAndMovie.Model
{
    public class Context : DbContext
    {

        private static readonly object _lock = new object();
        private static bool _initialized = false;

        readonly DataBaseInitialser _dataBaseInitialser;

        public Context(DbContextOptions<Context> options, DataBaseInitialser dataBaseInitialser) : base(options)
        {
            _dataBaseInitialser = dataBaseInitialser;
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (!_initialized)
                    {
                        Database.EnsureCreated();
                        _initialized = true;
                    }
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUser { get; set; }
        public DbSet<Film> Films { get; set; }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookUser>()
                .HasKey(t => new { t.UserId, t.BookId });

            modelBuilder.Entity<BookUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.BookUser)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<BookUser>()
                .HasOne(sc => sc.Book)
                .WithMany(c => c.BookUser)
                .HasForeignKey(sc => sc.BookId);

            _dataBaseInitialser.Initialize(modelBuilder);

        }
    }
}