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

namespace WebApplication1.Pages.phieudatve
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public EditModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public PhieuDatVe PhieuDatVe { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhieuDatVe = await _context.PhieuDatVe
                .Include(p => p.ChuyenBay)
                .Include(p => p.KhachHang)
                .Include(p => p.LoTrinh).FirstOrDefaultAsync(m => m.PhieuDatVeId == id);

            if (PhieuDatVe == null)
            {
                return NotFound();
            }
           ViewData["ChuyenBayId"] = new SelectList(_context.ChuyenBay, "ChuyenBayId", "ChuyenBayId");
           ViewData["KhachHangId"] = new SelectList(_context.KhachHang, "KhachHangId", "KhachHangId");
           ViewData["LoTrinhId"] = new SelectList(_context.LoTrinh, "LoTrinhId", "LoTrinhId");
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

            _context.Attach(PhieuDatVe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuDatVeExists(PhieuDatVe.PhieuDatVeId))
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

        private bool PhieuDatVeExists(string id)
        {
            return _context.PhieuDatVe.Any(e => e.PhieuDatVeId == id);
        }
    }
}
