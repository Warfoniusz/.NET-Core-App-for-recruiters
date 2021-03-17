using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TastebudsGalore.Data;
using TastebudsGalore.Models;

namespace TastebudsGalore.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly PizzaContext _Context;

        public IndexModel(PizzaContext context)
        {
            _Context = context;
        }
        public IEnumerable<Product> PizzaTypes { get; set; }
        public void OnGet()
        {
            PizzaTypes = _Context.Products.ToList();
        }
    }
}

