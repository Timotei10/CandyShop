using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyShop.Data;
using CandyShop.Models;

namespace CandyShop.Pages.Origins
{
    public class CreateModel : PageModel
    {
        private readonly CandyShop.Data.CandyShopContext _context;

        public CreateModel(CandyShop.Data.CandyShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Origin Origin { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Origin.Add(Origin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
