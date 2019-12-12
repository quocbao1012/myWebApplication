using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.lotrinh
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public LoTrinh LoTrinh { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoTrinh = await _context.LoTrinh.FirstOrDefaultAsync(m => m.LoTrinhId == id);

            if (LoTrinh == null)
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

            LoTrinh = await _context.LoTrinh.FindAsync(id);

            if (LoTrinh != null)
            {
                _context.LoTrinh.Remove(LoTrinh);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
