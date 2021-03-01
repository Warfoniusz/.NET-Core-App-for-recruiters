using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastebudsGalore.Models
{
    public class CartItem
    {

        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal getTotalPrice()
        {
            return Item.Price * Quantity;
        }
    }
}
