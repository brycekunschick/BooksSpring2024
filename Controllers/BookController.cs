using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
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

        public IActionResult Index() //do this individually
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> listOfCategories = _dbContext.Categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });

            return View();

        }

        [HttpPost]
        public IActionResult Create(Book bookObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(bookObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Book");
            }

            return View(bookObj);
        }

    }
}
