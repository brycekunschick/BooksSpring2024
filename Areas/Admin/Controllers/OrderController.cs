using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksSpring2024_sec02.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private BooksDBContext _dbContext;

        public OrderController(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> listOfOrders = _dbContext.Orders.Include(o => o.ApplicationUser);


            return View(listOfOrders);
        }
    }
}
