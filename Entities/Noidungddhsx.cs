using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungddhsx
    {
        public int Idhhtp { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
        public int Iddhsx { get; set; }
        public int Idndddhsx { get; set; }

        public virtual Dondathangsx IddhsxNavigation { get; set; }
        public virtual Hanghoathanhpham IdhhtpNavigation { get; set; }
    }
}
