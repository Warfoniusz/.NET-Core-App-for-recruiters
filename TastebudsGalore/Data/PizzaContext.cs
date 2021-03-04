using Microsoft.EntityFrameworkCore;
using TastebudsGalore.Models;

namespace TastebudsGalore.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Product>(
                p =>
                {
                    p.HasKey(w => w.Id);
                    p.OwnsOne<Item>(w => w.Item, i =>
                    {
                        i.WithOwner(it => it.Product)
                        .HasForeignKey(it => it.Id);
                        i.Property(w => w.Price).HasColumnType("Money");
                        i.HasKey(w => w.Id);
                        i.HasData(
                            new Item
                            {
                                Id = 1,
                                Price = 20.0M
                            },
                            new Item
                            {
                                Id = 2,
                                Price = 22.0M
                            },
                            new Item
                            {
                                Id = 3,
                                Price = 24.0M
                            },
                            new Item
                            {
                                Id = 4,
                                Price = 22.0M
                            });
                    });
                }
                );
                    

            modelbuilder.Entity<Product>().HasData(
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
                    Description = "Tomato sauce, mozarella, pineapple, ham.",


                });


        }
    }
}