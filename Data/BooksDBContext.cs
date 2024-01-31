﻿using BooksSpring2024_sec02.Models;
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


            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    BookId = 1,
                    BookTitle = "The Wager",
                    Author = "David Grann",
                    Description = "A Tale of Shipwreck, mutiny and murder",
                    Price = 19.99m,
                    CategoryId = 1
                },

                new Book
                {
                    BookId = 2,
                    BookTitle = "Midnight",
                    Author = "Amy McCulloch",
                    Description = "In this pulse-pounding thriller, a once-in-a-lifetime trip to Antarctica",
                    Price = 15.99m,
                    CategoryId = 2
                },

                new Book
                {
                    BookId = 3,
                    BookTitle = "The Tusks of Extinction",
                    Author = "Ray Naylor",
                    Description = "Moscow has resurrected the mammoth. But someone must teach them how to be mammoth, or they are doomed to die out again.",
                    Price = 25.99m,
                    CategoryId = 3
                }

                );

        }
    }
}
