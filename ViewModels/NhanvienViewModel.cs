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
        //mới thêm tổ
        public NhanvienViewModel()
        {
            Phieubanhang = new HashSet<Phieubanhang>();
            Phieunhapkho = new HashSet<Phieunhapkho>();
            Phieuthunokh = new HashSet<Phieuthunokh>();
            Phieutranoncc = new HashSet<Phieutranoncc>();
        }

        public int Idnv { get; set; }
        public string Manv { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tennv { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Cccd { get; set; }
        [Required]
        public DateTime Ngaysinh { get; set; }

        [Required]
        public string Gioitinh { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Diachi { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Sdt { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Email { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Matkhau { get; set; }
   
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Masothue { get; set; }

        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Facebook { get; set; }
   
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Zalo { get; set; }
        public int? Tosxid { get; set; }

        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Ghichu { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Phieubanhang> Phieubanhang { get; set; }
        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual ICollection<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual ICollection<Phieutranoncc> Phieutranoncc { get; set; }
    }
}
