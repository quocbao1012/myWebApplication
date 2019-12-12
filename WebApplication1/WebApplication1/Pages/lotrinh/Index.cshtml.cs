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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet =true)]

        public IList<LoTrinh> LoTrinh { get;set; }
        public PaginatedList<LoTrinh> lotrinhs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string filter { get; set; }
        public string filter1 { get; set; }
        public async Task OnGetAsync(string filter,string filter1, string searchString, string searchString1, int? pageIndex)
        {

            ViewData["searchString"] = searchString;
            ViewData["searchString1"] = searchString1;


            filter = searchString;
            filter1 = searchString1;
            IQueryable<LoTrinh> lt = from m in _context.LoTrinh
                                       select m;
            if (!string.IsNullOrEmpty(filter) && !String.IsNullOrEmpty(filter1))
            {
                lt = lt.Where(s => s.SanBayDi.Contains(filter))
                                    .Where(m => m.SanBayDen.Contains(filter1));
            }
            else if (!string.IsNullOrEmpty(filter))
            {
                lt = lt.Where(m => m.SanBayDi.Contains(filter));
            }
            else if (!String.IsNullOrEmpty(filter1))
            {
                lt = lt.Where(m => m.SanBayDen.Contains(filter1));
            }
            int pageSize = 4;
            lotrinhs = await PaginatedList<LoTrinh>.CreateAsync(
               lt.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
