using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Hanghoathanhpham
    {
        public Hanghoathanhpham()
        {
            Ctgiaidoansxhhtp = new HashSet<Ctgiaidoansxhhtp>();
            Cttosxhhtp = new HashSet<Cttosxhhtp>();
            Noidungddhsx = new HashSet<Noidungddhsx>();
            Vatlieusxtt = new HashSet<Vatlieusxtt>();
        }

        public int Idhhtp { get; set; }
        public string Mahhtp { get; set; }
        public string Tenhhtp { get; set; }
        public float? Dongiachung { get; set; }
        public string Mota { get; set; }
        public string Hinhanh { get; set; }
        public int Active { get; set; }
        public int Idbdm { get; set; }

        public virtual Bangdinhmuc IdbdmNavigation { get; set; }
        public virtual ICollection<Ctgiaidoansxhhtp> Ctgiaidoansxhhtp { get; set; }
        public virtual ICollection<Cttosxhhtp> Cttosxhhtp { get; set; }
        public virtual ICollection<Noidungddhsx> Noidungddhsx { get; set; }
        public virtual ICollection<Vatlieusxtt> Vatlieusxtt { get; set; }
    }
}
