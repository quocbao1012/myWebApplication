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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context; 
        }
        [BindProperty(SupportsGet = true)]
        public string ChuyenBayLoaiMayBay { get; set; }
        public SelectList LoaiMayBay { get; set; }
        public IList<ChuyenBay> ChuyenBay { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<KhachHang> KhachHang { get; set; }
        public PaginatedList<ChuyenBay> chuyenbays {get;set;}
        [BindProperty(SupportsGet = true)]
        public string filter { get; set; }
        public async Task OnGetAsync(string filter,string searchString, int? pageIndex)
        {

            KhachHang = (from s in _context.KhachHang
                         select s).ToList<KhachHang>();


            ViewData["searchString"] = searchString;


            filter = searchString;

            IQueryable<ChuyenBay> chuyenbay = from m in _context.ChuyenBay
                         select m;
            if (!string.IsNullOrEmpty(filter)&& !String.IsNullOrEmpty(ChuyenBayLoaiMayBay))
            {
                chuyenbay = chuyenbay.Where(m => m.ChuyenBayId.Contains(filter))
                                    .Where(m => m.LoaiMayBay == ChuyenBayLoaiMayBay);
            }
             else if (!string.IsNullOrEmpty(ChuyenBayLoaiMayBay))
            {
                chuyenbay= chuyenbay.Where(m => m.LoaiMayBay == ChuyenBayLoaiMayBay);
            }
            else if (!String.IsNullOrEmpty(filter))
            {
                chuyenbay = chuyenbay.Where(m => m.ChuyenBayId.Contains(filter));               
            }


            int pageSize = 4;
            IEnumerable<string> selectList = (from t in _context.ChuyenBay

                                              select t.LoaiMayBay).Distinct().ToList();
            LoaiMayBay = new SelectList(selectList); 

            chuyenbays = await PaginatedList<ChuyenBay>.CreateAsync(
               chuyenbay.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
