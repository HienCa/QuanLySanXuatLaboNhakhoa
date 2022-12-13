using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Bangdinhmuc
    {
        public Bangdinhmuc()
        {
            Hanghoathanhpham = new HashSet<Hanghoathanhpham>();
            Vatlieusanxuatbandau = new HashSet<Vatlieusanxuatbandau>();
        }

        public int Idbdm { get; set; }
        public string Mabdm { get; set; }
        public string Tenbdm { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Hanghoathanhpham> Hanghoathanhpham { get; set; }
        public virtual ICollection<Vatlieusanxuatbandau> Vatlieusanxuatbandau { get; set; }
    }
}
