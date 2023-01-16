using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;

namespace CandyShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly CandyShop.Data.CandyShopContext _context;

        public IndexModel(CandyShop.Data.CandyShopContext context)
        {
            _context = context;
        }

        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();

            ProductD.Products = await _context.Product
 .Include(b => b.Origin)
 .Include(b => b.ProductCategories)
 .ThenInclude(b => b.Category)
 .AsNoTracking()
 .OrderBy(b => b.Name)
 .ToListAsync();
            if(id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products
                    .Where(i => i.ID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);
            }
        }



        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
         /*  if (_context.Product != null)*/
            {
                Product=await _context.Product
                .Include(b => b.Origin)
                .ToListAsync();
            }
        }
    }
}
