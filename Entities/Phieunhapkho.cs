using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieunhapkho
    {
        public Phieunhapkho()
        {
            Noidungphieunhap = new HashSet<Noidungphieunhap>();
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idpnk { get; set; }
        public string Sophieu { get; set; }
        public string Ngaynhap { get; set; }
        public string Sohd { get; set; }
        public string Ngayhd { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Nhanvienidnv { get; set; }

        public virtual Nhanvien NhanvienidnvNavigation { get; set; }
        public virtual ICollection<Noidungphieunhap> Noidungphieunhap { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
