using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Giaidoansanxuat
    {
        public Giaidoansanxuat()
        {
            Chitietgiaidoansanxuathoanghoathanhpham = new HashSet<Chitietgiaidoansanxuathoanghoathanhpham>();
            Tosanxuat = new HashSet<Tosanxuat>();
        }

        public int Idgdsx { get; set; }
        public string Magdsx { get; set; }
        public string Tengdsx { get; set; }
        public string Donvingaycong { get; set; }
        public string Trinhtusanxuat { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Chitietgiaidoansanxuathoanghoathanhpham> Chitietgiaidoansanxuathoanghoathanhpham { get; set; }
        public virtual ICollection<Tosanxuat> Tosanxuat { get; set; }
    }
}
