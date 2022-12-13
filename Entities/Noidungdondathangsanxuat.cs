using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungdondathangsanxuat
    {
        public int Idndddhsx { get; set; }
        public string Soluong { get; set; }
        public string Dongia { get; set; }
        public int Donhangsanxuatiddhsx { get; set; }
        public int Hanghoathanhphamidhhtp { get; set; }

        public virtual Donhangsanxuat DonhangsanxuatiddhsxNavigation { get; set; }
        public virtual Hanghoathanhpham HanghoathanhphamidhhtpNavigation { get; set; }
    }
}
