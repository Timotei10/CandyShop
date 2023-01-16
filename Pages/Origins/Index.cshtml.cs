using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models;
using System.Security.Policy;
using CandyShop.Migrations;
using CandyShop.Models.ViewModels;

namespace CandyShop.Pages.Origins
{
    public class IndexModel : PageModel
    {
        private readonly CandyShop.Data.CandyShopContext _context;

        public IndexModel(CandyShop.Data.CandyShopContext context)
        {
            _context = context;
        }

        public IList<Origin> Origin { get; set; } = default!;

        public OriginIndexData OriginData { get; set; }
        public int OriginID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? productID)
        {
            OriginData = new OriginIndexData();
            OriginData.Origins = await _context.Origin
            .Include(i => i.Products)
            .ThenInclude(c => c.Producer)
            .OrderBy(i => i.OriginName)
            .ToListAsync();
            if (id != null)
            {
                OriginID = id.Value;
                Origin origin = OriginData.Origins
                .Where(i => i.ID == id.Value).Single();
                OriginData.Products = origin.Products;
            }

        }
    }
}
