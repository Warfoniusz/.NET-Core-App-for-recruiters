using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TastebudsGalore.Data;
using TastebudsGalore.Models;

namespace TastebudsGalore.Pages.Admin
{
    public class AddPageModel : PageModel
    {
        private PizzaContext _Context;
        public AddPageModel(PizzaContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public AddItemModel AIM { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var item = new Item
            {
                Price = AIM.Price,
            };

            var product = new Product
            {
                Name = AIM.Name,
                Description = AIM.Description,
                Item = item
            };

            _Context.Products.Add(product);
            _Context.SaveChanges();
            product.ItemId = product.Id;
            _Context.SaveChanges();

            //This is very rough as it assumes you upload a JPG, should detect what kind of picture you upload
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + ".jpg"
                );

            if(AIM.Picture?.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AIM.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
