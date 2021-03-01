using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastebudsGalore.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal OrderTotal { get; set; }


        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }
    }
}
