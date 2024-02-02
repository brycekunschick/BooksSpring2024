﻿using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
using BooksSpring2024_sec02.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksSpring2024_sec02.Controllers
{
    public class BookController : Controller
    {
        private BooksDBContext _dbContext;

        public BookController(BooksDBContext context)
        {
            _dbContext = context; // passes the dbContext object to the instance variable. this is how you inject your database into the controller, called dependency injection

        }

        public IActionResult Index()//list or fetch all objects (books)
        {
            var listOfBooks = _dbContext.Books.ToList();

            return View(listOfBooks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> listOfCategories = _dbContext.Categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });

            //PROJECTION: allows us to project a category object to a SelectListItem object, where the name of the category is used as the text and the CategoryID is used as the value of the SelectListItem

            //1. ViewBag: allows us to transfer some data from the controller to the view. Much more simple
            //ViewBag.ListOfCategories = listOfCategories;

            //2. ViewData: allows us to pass data from the controller to the view (not vice versa)
            //ViewData["ListOfCategoriesVD"] = listOfCategories;

            //3. ViewModel: Make an additional model folder in the solution explorer.  (2/1 lecture) ... more complex
            BookWithCategoriesVM bookWithCategoriesVMobj = new BookWithCategoriesVM();

            bookWithCategoriesVMobj.Book = new Book();

            bookWithCategoriesVMobj.ListOfCategories = listOfCategories;

            return View(bookWithCategoriesVMobj);

        }

        [HttpPost]
        public IActionResult Create(BookWithCategoriesVM BookWithCategoriesVMobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(BookWithCategoriesVMobj.Book);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Book");
            }

            return View(BookWithCategoriesVMobj);
        }

    }
}
