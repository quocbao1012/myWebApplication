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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public IList<VeMayBay> VeMayBay { get;set; }
        public PaginatedList<VeMayBay> vemaybays { get; set; }
        public List<ChuyenBay> chuyenbays { get; set; }
        public List<PhieuDatVe> phieudatves { get; set; }
        [BindProperty(SupportsGet = true)]
        public string filter { get; set; }

        public async Task OnGetAsync(string filter,
                                     int? pageIndex,
                                     string searchString)
        {
            VeMayBay = await _context.VeMayBay
                .Include(v => v.ChuyenBay)
                .Include(v => v.PhieuDatVe).ToListAsync();

            chuyenbays = (from s in _context.ChuyenBay
                         select s).ToList<ChuyenBay>();
            phieudatves = (from s in _context.PhieuDatVe
                         select s).ToList<PhieuDatVe>();


            IQueryable<VeMayBay> vmb = from s in _context.VeMayBay
                                         select s;
            ViewData["searchString"] = searchString;
            filter = searchString;



            if (!string.IsNullOrEmpty(filter))
            {
                vmb = vmb.Where(s => s.VeMayBayId.Contains(filter));
            }



            int pageSize = 4;
            vemaybays = await PaginatedList<VeMayBay>.CreateAsync(
               vmb.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
