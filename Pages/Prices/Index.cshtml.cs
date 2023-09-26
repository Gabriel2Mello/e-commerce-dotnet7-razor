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
    public class IndexModel : PageModel
    {
        private readonly e_commerce.Data.ApplicationDbContext _context;

        public IndexModel(e_commerce.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Price> Price { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prices != null)
            {
                Price = await _context.Prices
                .Include(p => p.Product).ToListAsync();
            }
        }
    }
}
