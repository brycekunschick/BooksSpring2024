using BooksSpring2024_sec02.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksSpring2024_sec02.Data
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; } //corresponds to the SQL table that will be created in the database. Each row in this table will be a category and the table will be called Categories

        public DbSet<Book> Books { get; set; } //adds the Books table to the db


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { 
                    CategoryId = 1, 
                    Name = "Travel", 
                    Description = "This is the description for the travel category" },

                new Category { 
                    CategoryId = 2, 
                    Name = "Fiction", 
                    Description = "This is the description for the fiction category" },

                new Category { 
                    CategoryId = 3, 
                    Name = "Technology", 
                    Description = "This is the description for the technology category" }

                );
        }
    }
}
