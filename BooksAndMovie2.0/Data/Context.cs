using BooksAndMovie.Logic;
using BooksAndMovie2._0.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BooksAndMovie.Model
{
    public class Context : IdentityDbContext<User>
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


        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUser { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmUser> FilmUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<FilmUser>()
               .HasKey(t => new { t.UserId, t.FilmId });

            modelBuilder.Entity<FilmUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.FilmUser)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<FilmUser>()
                .HasOne(sc => sc.Film)
                .WithMany(c => c.FilmUser)
                .HasForeignKey(sc => sc.FilmId);

            _dataBaseInitialser.Initialize(modelBuilder);

        }
    }
}