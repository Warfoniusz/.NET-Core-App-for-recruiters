using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TastebudsGalore.Models;

namespace TastebudsGalore.Data
{
    public static class Pizza
    {

        public static List<Product> Pizzas = new List<Product>() {
            new Product
            {
                Id = 1,
                Name = "Margharita",
                Description = "Tomato sauce, mozarella, basil."
            },
            new Product
            {
                Id = 2,
                Name = "Capriciosa",
                Description = "Tomato sauce, mozarella, ham, mushrooms."
            },
            new Product
            {
                Id = 3,
                Name = "Diavola",
                Description = "Tomato sauce, mozarella, spicy salami, red onion."
            },
            new Product
            {
                Id = 4,
                Name = "Hawaiian",
                Description = "Tomato sauce, mozarella, pineapple, ham.",


            }};

        public static List<Item> Stock = new List<Item>
        {
            new Item
            {
                Id = 1,
                Product = Pizzas[0],
                Price = 20.0M
            },
            new Item
            {
                Id = 2,
                Product = Pizzas[1],
                Price = 22.0M
            },
            new Item
            {
                Id = 3,
                Product = Pizzas[2],
                Price = 24.0M
            },
            new Item
            {
                Id = 4,
                Product = Pizzas[3],
                Price = 22.0M
            }


        };
    }
}
