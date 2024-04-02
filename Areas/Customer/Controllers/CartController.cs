﻿using BooksSpring2024_sec02.Data;
using BooksSpring2024_sec02.Models;
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

                Order = new Order()

            };

            foreach(var cartItem in shoppingCartVM.CartItems)
            {
                cartItem.SubTotal = cartItem.Book.Price * cartItem.Quantity; //subtotal for individual cart item

                shoppingCartVM.Order.OrderTotal += cartItem.SubTotal;
            }


            return View(shoppingCartVM);
        }

        public IActionResult IncrementByOne(int id)
        {
            Cart cart = _dbContext.Carts.Find(id);

            cart.Quantity++;

            _dbContext.Update(cart);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult DecrementByOne(int id)
        {
            Cart cart = _dbContext.Carts.Find(id);

            if(cart.Quantity <= 1)
            {
                //remove the item
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
            }
            else
            {
                cart.Quantity--;

                _dbContext.Update(cart);
                _dbContext.SaveChanges();
            }


            return RedirectToAction("Index");

        }

        public IActionResult RemoveFromCart(int id)
        {
            Cart cart = _dbContext.Carts.Find(id);

            _dbContext.Carts.Remove(cart);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult ReviewOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//fetches the user ID

            var cartItemsList = _dbContext.Carts.Where(c => c.UserId == userId).Include(c => c.Book);

            ShoppingCartVM shoppingCartVM = new ShoppingCartVM
            {
                CartItems = cartItemsList,

                Order = new Order()


            };

            foreach (var cartItem in shoppingCartVM.CartItems)
            {
                cartItem.SubTotal = cartItem.Book.Price * cartItem.Quantity; //subtotal for individual cart item

                shoppingCartVM.Order.OrderTotal += cartItem.SubTotal;
            }


            shoppingCartVM.Order.ApplicationUser = _dbContext.ApplicationUsers.Find(userId);

            shoppingCartVM.Order.CustomerName = shoppingCartVM.Order.ApplicationUser.Name;

            shoppingCartVM.Order.StreetAddress = shoppingCartVM.Order.ApplicationUser.StreetAddress;

            shoppingCartVM.Order.City = shoppingCartVM.Order.ApplicationUser.City;

            shoppingCartVM.Order.State = shoppingCartVM.Order.ApplicationUser.State;

            shoppingCartVM.Order.PostalCode = shoppingCartVM.Order.ApplicationUser.PostalCode;

            shoppingCartVM.Order.Phone = shoppingCartVM.Order.ApplicationUser.PhoneNumber;


            return View(shoppingCartVM);
        }




    }
}
