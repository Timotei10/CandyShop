using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyShop.Data;
using CandyShop.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly CandyShop.Data.CandyShopContext _context;

        public CreateModel(CandyShop.Data.CandyShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OriginID"] = new SelectList(_context.Set<Origin>(), "ID","OriginName");

            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            Product.ProductCategories = newProduct.ProductCategories;
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        /*PopulateAssignedCategoryData(_context, newProduct);

            return Page();*/
        /* PopulateAssignedCategoryData(_context, newProduct);
  return Page();*/
    }
}
