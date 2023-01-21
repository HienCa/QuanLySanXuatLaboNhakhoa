using Microsoft.AspNetCore.Http;
using QuanLySanXuat.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class KhachhangViewModel : EditImageViewModel
    {
        public KhachhangViewModel()
        {
            Ctnganhangkh = new HashSet<Ctnganhangkh>();
            Dondathangsx = new HashSet<Dondathangsx>();
            Phieubanhang = new HashSet<Phieubanhang>();
        }

        public int Idkh { get; set; }

        public string Makh { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tenkh { get; set; }
     
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Cccd { get; set; }
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

        [Required]
        public string Gioitinh { get; set; }

        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Masothue { get; set; }
      
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Ghichu { get; set; }
    
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Facebook { get; set; }
  
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Zalo { get; set; }
        public int? Nvidsale { get; set; }
        
        public DateTime? Ngaysinh { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Ctnganhangkh> Ctnganhangkh { get; set; }
        public virtual ICollection<Dondathangsx> Dondathangsx { get; set; }
        public virtual ICollection<Phieubanhang> Phieubanhang { get; set; }
    }
}
