using BooksSpring2024_sec02.Data;
using Microsoft.AspNetCore.Mvc;

namespace BooksSpring2024_sec02.Controllers
{
    public class CategoryController : Controller
    {
        private BooksDBContext _dbContext;

        public CategoryController(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()//list or fetch all objects (categories)
        {
            var listOfCategories = _dbContext.Categories.ToList();

            return View(listOfCategories);
        }
    }
}
