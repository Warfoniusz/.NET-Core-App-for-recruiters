using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TastebudsGalore.Models;

namespace TastebudsGalore.Data
{
    public static class Pizza
    {

        public static List<Product> PizzaTypes = new List<Product>() {
            new Product
            {
                Id = 1,
                ItemId = 1,
                Name = "Margharita",
                Description = "Tomato sauce, mozarella, basil."
            },
            new Product
            {
                Id = 2,
                ItemId = 2,
                Name = "Capriciosa",
                Description = "Tomato sauce, mozarella, ham, mushrooms."
            },
            new Product
            {
                Id = 3,
                ItemId = 3,
                Name = "Diavola",
                Description = "Tomato sauce, mozarella, spicy salami, red onion."
            },
            new Product
            {
                Id = 4,
                ItemId = 4,
                Name = "Hawaiian",
                Description = "Tomato sauce, mozarella, pineapple, ham."
            }};
    
    }
}
