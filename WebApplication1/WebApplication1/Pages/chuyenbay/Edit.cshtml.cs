using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.chuyenbay
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public EditModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ChuyenBay ChuyenBay { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChuyenBay = await _context.ChuyenBay.FirstOrDefaultAsync(m => m.ChuyenBayId == id);

            if (ChuyenBay == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChuyenBay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenBayExists(ChuyenBay.ChuyenBayId))
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

        private bool ChuyenBayExists(string id)
        {
            return _context.ChuyenBay.Any(e => e.ChuyenBayId == id);
        }
    }
}
