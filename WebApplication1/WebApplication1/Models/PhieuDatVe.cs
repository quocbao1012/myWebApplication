using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PhieuDatVe
    {
        public PhieuDatVe()
        {
            VeMayBay = new HashSet<VeMayBay>();
        }

        public string PhieuDatVeId { get; set; }
        public DateTime NgayDat { get; set; }
        public string KhachHangId { get; set; }
        public string ChuyenBayId { get; set; }
        public string LoTrinhId { get; set; }

        public virtual ChuyenBay ChuyenBay { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual LoTrinh LoTrinh { get; set; }
        public virtual ICollection<VeMayBay> VeMayBay { get; set; }
    }
}
