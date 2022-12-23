using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Dondathangsx
    {
        public Dondathangsx()
        {
            Noidungddhsx = new HashSet<Noidungddhsx>();
            Noidungthunoddhsx = new HashSet<Noidungthunoddhsx>();
        }

        public int Iddhsx { get; set; }
        public string Madhsx { get; set; }
        public DateTime Ngaydat { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public string Trangthai { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idkh { get; set; }

        public virtual Khachhang IdkhNavigation { get; set; }
        public virtual ICollection<Noidungddhsx> Noidungddhsx { get; set; }
        public virtual ICollection<Noidungthunoddhsx> Noidungthunoddhsx { get; set; }
    }
}
