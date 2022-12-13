using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Donhangsanxuat
    {
        public Donhangsanxuat()
        {
            Noidungdondathangsanxuat = new HashSet<Noidungdondathangsanxuat>();
            Noidungthunodondathangkh = new HashSet<Noidungthunodondathangkh>();
        }

        public int Iddhsx { get; set; }
        public string Madhsx { get; set; }
        public DateTime? Ngaydat { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Khachhangidkh { get; set; }
        public int Trangthaidonhangidttdh { get; set; }

        public virtual Khachhang KhachhangidkhNavigation { get; set; }
        public virtual Trangthaidonhang TrangthaidonhangidttdhNavigation { get; set; }
        public virtual ICollection<Noidungdondathangsanxuat> Noidungdondathangsanxuat { get; set; }
        public virtual ICollection<Noidungthunodondathangkh> Noidungthunodondathangkh { get; set; }
    }
}
