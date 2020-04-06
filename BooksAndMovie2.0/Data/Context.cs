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

        
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUser { get; set; }
        public DbSet<Film> Films { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public Context()
        {
            Database.EnsureCreated();
        }
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
        }
    }
}