using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Loainhanvien
    {
        public Loainhanvien()
        {
            Nhanvien = new HashSet<Nhanvien>();
        }

        public int Idlnv { get; set; }
        public string Malnv { get; set; }
        public string Tenlnv { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
    }
}
