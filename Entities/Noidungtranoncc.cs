using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungtranoncc
    {
        public int Idndtnncc { get; set; }
        public string Sotien { get; set; }
        public string Ngaytrano { get; set; }
        public string Ghichu { get; set; }
        public int Phieunhapkhoidpnk { get; set; }
        public int Phieutranonccidptnncc { get; set; }

        public virtual Phieunhapkho PhieunhapkhoidpnkNavigation { get; set; }
        public virtual Phieutranoncc PhieutranonccidptnnccNavigation { get; set; }
    }
}
