using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Pages_Prices
{
    public class CreateModel : PageModel
    {
        private readonly e_commerce.Data.ApplicationDbContext _context;

        public CreateModel(e_commerce.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Price Price { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Prices == null || Price == null)
            {
                return Page();
            }

            _context.Prices.Add(Price);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
