using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungphieunhap
    {
        public int Idpnk { get; set; }
        public string Soluong { get; set; }
        public string Dongia { get; set; }
        public int Vatlieuidvl { get; set; }
        public int Phieunhapkhoidpnk { get; set; }

        public virtual Phieunhapkho PhieunhapkhoidpnkNavigation { get; set; }
        public virtual Vatlieu VatlieuidvlNavigation { get; set; }
    }
}
