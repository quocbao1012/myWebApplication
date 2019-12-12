using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class LoTrinh
    {
        public LoTrinh()
        {
            PhieuDatVe = new HashSet<PhieuDatVe>();
        }

        public string LoTrinhId { get; set; }
        public string SanBayDi { get; set; }
        public string SanBayDen { get; set; }

        public virtual ICollection<PhieuDatVe> PhieuDatVe { get; set; }
    }
}
