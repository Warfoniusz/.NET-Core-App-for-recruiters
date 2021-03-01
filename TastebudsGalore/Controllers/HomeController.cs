using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TastebudsGalore.Data;
using TastebudsGalore.Models;

namespace TastebudsGalore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Cart _Cart = new Cart();


        public void CartItemCount()
        {
            var total = _Cart.CartItems.Sum(c => c.Quantity);
            ViewData["Shopping Cart Quantity"] = total;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CartItemCount();
            return View(Pizza.PizzaTypes);
        }

        public IActionResult Details(int id)
        {
            CartItemCount();
            var item = Pizza.PizzaTypes.SingleOrDefault(i => i.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult ShowCart()
        {
            var cartVM = new CartViewModel();
            cartVM.CartItems = _Cart.CartItems;
            cartVM.= _Cart.CartItems.Sum(c => c.getTotalPrice());
            CartItemCount();
            return View("Cart", cartVM);
        }

        public IActionResult AddToCart(int itemId)
        {
            var item = Pizza.PizzaTypes.SingleOrDefault(i => i.ItemId == itemId);

            if (item != null)
            {
                var cartItem = new CartItem
                {
                    Item = item.item,
                    Quantity = 1
                };
                _Cart.addItem(cartItem);
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult RemoveFromCart(int itemId)
        {
            _Cart.removeItem(itemId);
            return RedirectToAction("Index");
        }
        
        public IActionResult Privacy()
        {
            CartItemCount();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
