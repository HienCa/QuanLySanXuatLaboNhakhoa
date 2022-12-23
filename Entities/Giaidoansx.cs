using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Giaidoansx
    {
        public Giaidoansx()
        {
            Ctgiaidoansxhhtp = new HashSet<Ctgiaidoansxhhtp>();
            Tosanxuat = new HashSet<Tosanxuat>();
        }

        public int Idgdsx { get; set; }
        public string Magdsx { get; set; }
        public string Tengdsx { get; set; }
        public float Donvingaycong { get; set; }
        public int Trinhtusx { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Ctgiaidoansxhhtp> Ctgiaidoansxhhtp { get; set; }
        public virtual ICollection<Tosanxuat> Tosanxuat { get; set; }
    }
}
