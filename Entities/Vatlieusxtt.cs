using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieusxtt
    {
        public int Idvlsxtt { get; set; }
        public float Soluong { get; set; }
        public string Donvitinh { get; set; }
        public int Idhhtp { get; set; }
        public int Idvl { get; set; }

        public virtual Hanghoathanhpham IdhhtpNavigation { get; set; }
        public virtual Vatlieu IdvlNavigation { get; set; }
    }
}
