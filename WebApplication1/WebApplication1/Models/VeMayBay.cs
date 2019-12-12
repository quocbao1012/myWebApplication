using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class VeMayBay
    {
        public string VeMayBayId { get; set; }
        public string SoGhe { get; set; }
        public string KhoangGhe { get; set; }
        public int GiaVe { get; set; }
        public string PhieuDatVeId { get; set; }
        public string ChuyenBayId { get; set; }

        public virtual ChuyenBay ChuyenBay { get; set; }
        public virtual PhieuDatVe PhieuDatVe { get; set; }
    }
}
