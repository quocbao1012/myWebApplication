using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.khachhang
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DetailsModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public KhachHang KhachHang { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KhachHang = await _context.KhachHang.FirstOrDefaultAsync(m => m.KhachHangId == id);

            if (KhachHang == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
