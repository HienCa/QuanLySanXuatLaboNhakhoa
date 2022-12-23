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
            Noidungthunoddhsx = new HashSet<Noidungthunoddhsx>();
            Noidungthunokh = new HashSet<Noidungthunokh>();
        }

        public int Idptnkh { get; set; }
        public string Sophieu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idhttt { get; set; }
        public int Idnv { get; set; }

        public virtual Hinhthucthanhtoan IdhtttNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungthunoddhsx> Noidungthunoddhsx { get; set; }
        public virtual ICollection<Noidungthunokh> Noidungthunokh { get; set; }
    }
}
