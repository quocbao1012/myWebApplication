using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            PhieuDatVe = new HashSet<PhieuDatVe>();
        }

        public string KhachHangId { get; set; }
        public string TenKhachHang { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<PhieuDatVe> PhieuDatVe { get; set; }
    }
}
