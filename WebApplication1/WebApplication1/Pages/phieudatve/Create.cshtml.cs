using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.phieudatve
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public CreateModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ChuyenBayId"] = new SelectList(_context.ChuyenBay, "ChuyenBayId", "ChuyenBayId");
        ViewData["KhachHangId"] = new SelectList(_context.KhachHang, "KhachHangId", "KhachHangId");
        ViewData["LoTrinhId"] = new SelectList(_context.LoTrinh, "LoTrinhId", "LoTrinhId");
            return Page();
        }

        [BindProperty]
        public PhieuDatVe PhieuDatVe { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PhieuDatVe.Add(PhieuDatVe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
