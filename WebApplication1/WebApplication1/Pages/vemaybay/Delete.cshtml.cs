using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.vemaybay
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Data.WebApplication1Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VeMayBay = await _context.VeMayBay.FindAsync(id);

            if (VeMayBay != null)
            {
                _context.VeMayBay.Remove(VeMayBay);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
