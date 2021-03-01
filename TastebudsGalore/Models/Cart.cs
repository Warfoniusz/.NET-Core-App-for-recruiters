using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastebudsGalore.Models
{
    public class Cart
    {
        public int orderId { get; set; }
        public List<CartItem> CartItems { get; set; }


        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public void addItem(CartItem Item)
        {
            if(CartItems.Exists(i => i.Item.Id == Item.Item.Id))
                {
                CartItems.Find(I => I.Item.Id == Item.Item.Id)
                    .Quantity += 1;
                }
            else
            {
                CartItems.Add(Item);
            }
        }

        public void removeItem(int itemId)
        {
            var item = CartItems
                .SingleOrDefault(c => c.Item.Id == itemId);

            if (item?.Quantity <= 1)
            {
                CartItems.Remove(item);
            }
            else if (item != null)
            {
                item.Quantity -= 1;
            }

        }
    }
}
