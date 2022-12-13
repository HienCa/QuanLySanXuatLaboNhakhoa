using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieusanxuatbandau
    {
        public int Idvlsxbd { get; set; }
        public string Soluong { get; set; }
        public string Donvitinh { get; set; }
        public string Dongiadm { get; set; }
        public int Vatlieuidvl { get; set; }
        public int Bangdinhmucidbdm { get; set; }

        public virtual Bangdinhmuc BangdinhmucidbdmNavigation { get; set; }
        public virtual Vatlieu VatlieuidvlNavigation { get; set; }
    }
}
