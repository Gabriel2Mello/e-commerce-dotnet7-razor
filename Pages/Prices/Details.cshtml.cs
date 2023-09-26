using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Pages_Prices
{
    public class DetailsModel : PageModel
    {
        private readonly e_commerce.Data.ApplicationDbContext _context;

        public DetailsModel(e_commerce.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Price Price { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }
            else 
            {
                Price = price;
            }
            return Page();
        }
    }
}
