using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BooksSpring2024_sec02.Areas.Customer.Controllers
{

    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private BooksDBContext _dbContext;

        public CartController(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//fetches the user ID

            var cartItemsList = _dbContext.Carts.Where(c => c.UserId == userId).Include(c => c.Book);

            ShoppingCartVM shoppingCartVM = new ShoppingCartVM
            {
                CartItems = cartItemsList,

                OrderTotal = 0,

            };


            return View(shoppingCartVM);
        }
    }
}
