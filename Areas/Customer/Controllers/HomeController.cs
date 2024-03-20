using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BooksSpring2024_sec02.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private BooksDBContext _dbContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BooksDBContext booksDBContext) //dependency injection after the comma here
        {
            _logger = logger;

            _dbContext = booksDBContext;
        }

        public IActionResult Index()
        {
            var listOfBooks = _dbContext.Books.Include(c => c.Category);

            return View(listOfBooks.ToList()); //you can delay the tolist to this part
        }

        public IActionResult Details(int id)
        {
            Book book = _dbContext.Books.Find(id);


            _dbContext.Books.Entry(book).Reference(b => b.Category).Load(); // loads the category

            //to do: Create cart object

            return View(book);


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
