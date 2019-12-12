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

namespace WebApplication1.Pages.vemaybay
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public EditModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public VeMayBay VeMayBay { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VeMayBay = await _context.VeMayBay
                .Include(v => v.ChuyenBay)
                .Include(v => v.PhieuDatVe).FirstOrDefaultAsync(m => m.VeMayBayId == id);

            if (VeMayBay == null)
            {
                return NotFound();
            }
           ViewData["ChuyenBayId"] = new SelectList(_context.ChuyenBay, "ChuyenBayId", "ChuyenBayId");
           ViewData["PhieuDatVeId"] = new SelectList(_context.PhieuDatVe, "PhieuDatVeId", "PhieuDatVeId");
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

            _context.Attach(VeMayBay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeMayBayExists(VeMayBay.VeMayBayId))
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

        private bool VeMayBayExists(string id)
        {
            return _context.VeMayBay.Any(e => e.VeMayBayId == id);
        }
    }
}
