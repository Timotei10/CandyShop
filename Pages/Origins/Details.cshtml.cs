using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;

namespace CandyShop.Pages.Origins
{
    public class DetailsModel : PageModel
    {
        private readonly CandyShop.Data.CandyShopContext _context;

        public DetailsModel(CandyShop.Data.CandyShopContext context)
        {
            _context = context;
        }

      public Origin Origin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Origin == null)
            {
                return NotFound();
            }

            var origin = await _context.Origin.FirstOrDefaultAsync(m => m.ID == id);
            if (origin == null)
            {
                return NotFound();
            }
            else 
            {
                Origin = origin;
            }
            return Page();
        }
    }
}
