using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.ChuyenBay> ChuyenBay { get; set; }

        public DbSet<WebApplication1.Models.KhachHang> KhachHang { get; set; }

        public DbSet<WebApplication1.Models.LoTrinh> LoTrinh { get; set; }

        public DbSet<WebApplication1.Models.PhieuDatVe> PhieuDatVe { get; set; }

        public DbSet<WebApplication1.Models.VeMayBay> VeMayBay { get; set; }
    }
}
