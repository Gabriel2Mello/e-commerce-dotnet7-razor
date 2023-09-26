using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_commerce.Data;
using e_commerce.Models;

namespace e_commerce.Pages_Prices
{
    public class EditModel : PageModel
    {
        private readonly e_commerce.Data.ApplicationDbContext _context;

        public EditModel(e_commerce.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Price Price { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price =  await _context.Prices.FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }
            Price = price;
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(Price.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PriceExists(int id)
        {
          return (_context.Prices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
