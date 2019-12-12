using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.phieudatve
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;
        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public IList<PhieuDatVe> PhieuDatVe { get;set; }
        public PaginatedList<PhieuDatVe> phieudatves { get; set; }
        [BindProperty(SupportsGet = true)]
        public string filter { get; set; }


        public async Task OnGetAsync(string searchString, string filter, int? pageIndex)
        {
            PhieuDatVe = await _context.PhieuDatVe
                .Include(p => p.ChuyenBay)
                .Include(p => p.KhachHang)
                .Include(p => p.LoTrinh).ToListAsync();

            IQueryable<PhieuDatVe> pdv = from s in _context.PhieuDatVe
                                         select s;
            ViewData["searchString"] = searchString;
            filter = searchString;

           
            if (!string.IsNullOrEmpty(filter))
            {
                pdv = pdv.Where(s => s.PhieuDatVeId.Contains(filter))
                                    .Where(m => m.PhieuDatVeId.Contains(filter));
            }
            int pageSize = 4;
            phieudatves = await PaginatedList<PhieuDatVe>.CreateAsync(
               pdv.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
