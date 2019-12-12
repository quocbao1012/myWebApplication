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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]

        public IList<KhachHang> KhachHang { get; set; }
        public PaginatedList<KhachHang> khachhangs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string filter { get; set; }
        public string filter1 { get; set; }

        public async Task OnGetAsync(string filter, 
                                     string filter1,
                                     string searchString,
                                     string searchString1,
                                     int? pageIndex)
        {
            //IQueryable<KhachHang> khachhang = from s in _context.KhachHang
                                           //   select s;

            ViewData["searchString"] = searchString;
            ViewData["searchString1"] = searchString1;


            filter = searchString;
            filter1 = searchString1;
            IQueryable<KhachHang> kh = from m in _context.KhachHang
                                              select m;
            if (!string.IsNullOrEmpty(filter) && !String.IsNullOrEmpty(filter1))
            {
                kh = kh.Where(s => s.KhachHangId.Contains(filter))
                                    .Where(m => m.TenKhachHang.Contains(filter1));
            }
            else if (!string.IsNullOrEmpty(filter))
            {
                kh = kh.Where(m => m.KhachHangId.Contains(filter));
            }
            else if (!String.IsNullOrEmpty(filter1))
            {
                kh = kh.Where(m => m.TenKhachHang.Contains(filter1));
            }

            int pageSize = 4;
            khachhangs = await PaginatedList<KhachHang>.CreateAsync(
               kh.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
