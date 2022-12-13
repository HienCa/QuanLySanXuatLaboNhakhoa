using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungthunodondathangkh
    {
        public int Idndtnddhkh { get; set; }
        public string Sotien { get; set; }
        public DateTime? Ngaythuno { get; set; }
        public string Ghichu { get; set; }
        public int Phieuthunokhidptnkh { get; set; }
        public int Donhangsanxuatiddhsx { get; set; }

        public virtual Donhangsanxuat DonhangsanxuatiddhsxNavigation { get; set; }
        public virtual Phieuthunokh PhieuthunokhidptnkhNavigation { get; set; }
    }
}
