using BooksAndMovie.Data;
using BooksAndMovie.Model;
using BooksAndMovie2._0.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndMovie.Logic
{
    public class DataBaseInitialser
    {
        public void Initialize(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasData(GenerateBooks().ToArray());
        }
        private List<Book> GenerateBooks()
        {
            string[] lines = new string[300];

            string path = @"D:\My projects\BooksAndMovie\BooksAndMovie\wwwroot\boooks.txt";
            int count = 0;
            List<Book> books = new List<Book>();
            string text;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines[count] = line;

                    count++;
                }
            }

            count = 0;

            while (lines[count] != null)
            {
                text = lines[count];
                string ch = "—";
                text = text.Replace("-", "—");
                int index = text.IndexOf(ch);
                string autor = text.Substring(index + 1);
                string name = text.Substring(0, index);
                books.Add(new BookBuilder(name, autor, count + 1).Creat());

                count = count + 1;
            }

            return books;
        }
    }
}
