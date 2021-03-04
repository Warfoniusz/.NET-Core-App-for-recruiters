using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastebudsGalore.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        //Navigational properties
        public Product Product { get; set; }

    }/*                    ZRÓB ROLLBACK DO OSTATNIEGO COMMITA I PODMIEŃ PIZZA NA PIZZACONTEXT, ZOSTAW CALA RESZTE AKTUALNĄ                              */
}
