﻿// <auto-generated />
using BooksSpring2024_sec02.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksSpring2024_sec02.Migrations
{
    [DbContext(typeof(BooksDBContext))]
    partial class BooksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksSpring2024_sec02.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "David Grann",
                            BookTitle = "The Wager",
                            CategoryId = 1,
                            Description = "A Tale of Shipwreck, mutiny and murder",
                            Price = 19.99m
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Amy McCulloch",
                            BookTitle = "Midnight",
                            CategoryId = 2,
                            Description = "In this pulse-pounding thriller, a once-in-a-lifetime trip to Antarctica",
                            Price = 15.99m
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Ray Naylor",
                            BookTitle = "The Tusks of Extinction",
                            CategoryId = 3,
                            Description = "Moscow has resurrected the mammoth. But someone must teach them how to be mammoth, or they are doomed to die out again.",
                            Price = 25.99m
                        });
                });

            modelBuilder.Entity("BooksSpring2024_sec02.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "This is the description for the travel category",
                            Name = "Travel"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "This is the description for the fiction category",
                            Name = "Fiction"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "This is the description for the technology category",
                            Name = "Technology"
                        });
                });

            modelBuilder.Entity("BooksSpring2024_sec02.Models.Book", b =>
                {
                    b.HasOne("BooksSpring2024_sec02.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
