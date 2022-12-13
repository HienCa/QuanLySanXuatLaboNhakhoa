using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieusanxuatthuc
    {
        public int Idvlt { get; set; }
        public string Soluong { get; set; }
        public string Donvitinh { get; set; }
        public int Vatlieuidvl { get; set; }
        public int Hanghoathanhphamidhhtp { get; set; }

        public virtual Hanghoathanhpham HanghoathanhphamidhhtpNavigation { get; set; }
        public virtual Vatlieu VatlieuidvlNavigation { get; set; }
    }
}
