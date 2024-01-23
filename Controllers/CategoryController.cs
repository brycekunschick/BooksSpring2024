using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
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

        [HttpGet]
        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(Category categoryObj) 
        {
            if (ModelState.IsValid) 
            {
                _dbContext.Categories.Add(categoryObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Category");
            }

            return View(categoryObj);
        }



        public IActionResult Edit(int id)
        {
            Category category = _dbContext.Categories.Find(id);

            return View(category);
        }

        [HttpPost]

        public IActionResult Edit(int id, [Bind("CategoryID, Name, Description")] Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(categoryObj);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Category");
            }

            return View(categoryObj);
        }

    }
}
