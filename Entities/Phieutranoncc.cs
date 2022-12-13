using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieutranoncc
    {
        public Phieutranoncc()
        {
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idptnncc { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Hinhthucthanhtoanidhttt { get; set; }
        public int Nhanvienidnv { get; set; }

        public virtual Hinhthucthanhtoan HinhthucthanhtoanidhtttNavigation { get; set; }
        public virtual Nhanvien NhanvienidnvNavigation { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
