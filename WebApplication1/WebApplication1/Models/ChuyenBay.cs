using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ChuyenBay
    {
        public ChuyenBay()
        {
            PhieuDatVe = new HashSet<PhieuDatVe>();
            VeMayBay = new HashSet<VeMayBay>();
        }

        public string ChuyenBayId { get; set; }
        public string LoaiMayBay { get; set; }
        public DateTime NgayCatCanh { get; set; }
        public TimeSpan GioCatCanh { get; set; }

        public virtual ICollection<PhieuDatVe> PhieuDatVe { get; set; }
        public virtual ICollection<VeMayBay> VeMayBay { get; set; }
    }
}
