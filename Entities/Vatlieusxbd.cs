using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieusxbd
    {
        public int Idvlsxbd { get; set; }
        public float Soluong { get; set; }
        public string Donvitinh { get; set; }
        public float Dongiadm { get; set; }
        public int Idbdm { get; set; }
        public int Idvl { get; set; }

        public virtual Bangdinhmuc IdbdmNavigation { get; set; }
        public virtual Vatlieu IdvlNavigation { get; set; }
    }
}
