using Microsoft.AspNetCore.Http;
using QuanLySanXuat.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class NhanvienViewModel : EditImageViewModel
    {
        public NhanvienViewModel()
        {
            Phieubanhang = new HashSet<Phieubanhang>();
            Phieunhapkho = new HashSet<Phieunhapkho>();
            Phieuthunokh = new HashSet<Phieuthunokh>();
            Phieutranoncc = new HashSet<Phieutranoncc>();
        }

        public int Idnv { get; set; }
        public string Manv { get; set; }
        public string Tennv { get; set; }
        public string Gioitinh { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public int? Tosxid { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Loainhanvienidlnv { get; set; }
        public int Accountidaccount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime? NgaySinh { get; set; }

        //public IFormFile Hinhanh { get; set; }
        public string Masothue { get; set; }


        public virtual Account AccountidaccountNavigation { get; set; }
        public virtual Loainhanvien LoainhanvienidlnvNavigation { get; set; }
        public virtual ICollection<Phieubanhang> Phieubanhang { get; set; }
        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual ICollection<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual ICollection<Phieutranoncc> Phieutranoncc { get; set; }
    }
}
