using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieuthunokh
    {
        public Phieuthunokh()
        {
            Noidungthunodondathangkh = new HashSet<Noidungthunodondathangkh>();
            Noidungthunokh = new HashSet<Noidungthunokh>();
        }

        public int Idptnkh { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Hinhthucthanhtoanidhttt { get; set; }
        public int Nhanvienidnv { get; set; }

        public virtual Hinhthucthanhtoan HinhthucthanhtoanidhtttNavigation { get; set; }
        public virtual Nhanvien NhanvienidnvNavigation { get; set; }
        public virtual ICollection<Noidungthunodondathangkh> Noidungthunodondathangkh { get; set; }
        public virtual ICollection<Noidungthunokh> Noidungthunokh { get; set; }
    }
}
