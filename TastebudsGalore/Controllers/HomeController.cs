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
        private PizzaContext _context;
        private static Cart _Cart = new Cart();

        public HomeController(PizzaContext context)
        {
            _context = context;
        }


        public void CartItemCount()
        {
            var total = _Cart.CartItems.Sum(c => c.Quantity);
            ViewData["Shopping Cart Quantity"] = total;
        }

        public IActionResult Index()
        {
            CartItemCount();
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            CartItemCount();
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            var vm = new DetailsViewModel
            {
                Product = product
            };

            if (product != null)
            {
                return View(vm);
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
            cartVM.OrderTotal= _Cart.CartItems.Sum(c => c.getTotalPrice());
            CartItemCount();
            return View("Cart", cartVM);
        }

        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.SingleOrDefault(p => p.ItemId == itemId);

            if (product != null)
            {
                var cartItem = new CartItem
                {
                    Item = product.Item,
                    Quantity = 1
                };
                _Cart.addItem(cartItem);
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult RemoveFromCart(int itemId)
        {
            
            _Cart.removeItem(itemId);
            bool isEmpty = !_Cart.CartItems.Any();
            if (!isEmpty)
            {
                return RedirectToAction("ShowCart");
            }
            else
            {
                return RedirectToAction("Index");
            }
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
