using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieubanhang
    {
        public Phieubanhang()
        {
            Noidungthunokh = new HashSet<Noidungthunokh>();
        }

        public int Idpbh { get; set; }
        public string Sophieu { get; set; }
        public DateTime? Ngaylap { get; set; }
        public string Sohd { get; set; }
        public string Ngayhd { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Nhanvienidnv { get; set; }
        public int Khachhangidkh { get; set; }

        public virtual Khachhang KhachhangidkhNavigation { get; set; }
        public virtual Nhanvien NhanvienidnvNavigation { get; set; }
        public virtual ICollection<Noidungthunokh> Noidungthunokh { get; set; }
    }
}
