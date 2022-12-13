using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Hanghoathanhpham
    {
        public Hanghoathanhpham()
        {
            Chitietgiaidoansanxuathoanghoathanhpham = new HashSet<Chitietgiaidoansanxuathoanghoathanhpham>();
            Noidungdondathangsanxuat = new HashSet<Noidungdondathangsanxuat>();
            Tosanxuathanghoathanhpham = new HashSet<Tosanxuathanghoathanhpham>();
            Vatlieusanxuatthuc = new HashSet<Vatlieusanxuatthuc>();
        }

        public int Idhhtp { get; set; }
        public string Mahhtp { get; set; }
        public string Tenhhtp { get; set; }
        public string Mota { get; set; }
        public string Hinhanh { get; set; }
        public int? Active { get; set; }
        public int Bangdinhmucidbdm { get; set; }

        public virtual Bangdinhmuc BangdinhmucidbdmNavigation { get; set; }
        public virtual ICollection<Chitietgiaidoansanxuathoanghoathanhpham> Chitietgiaidoansanxuathoanghoathanhpham { get; set; }
        public virtual ICollection<Noidungdondathangsanxuat> Noidungdondathangsanxuat { get; set; }
        public virtual ICollection<Tosanxuathanghoathanhpham> Tosanxuathanghoathanhpham { get; set; }
        public virtual ICollection<Vatlieusanxuatthuc> Vatlieusanxuatthuc { get; set; }
    }
}
