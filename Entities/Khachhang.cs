using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Chitietnganhangkh = new HashSet<Chitietnganhangkh>();
            Donhangsanxuat = new HashSet<Donhangsanxuat>();
            Phieubanhang = new HashSet<Phieubanhang>();
        }
        
        public int Idkh { get; set; }
        [Display(Name = "Tên gọi tắt")]
        [StringLength(255, ErrorMessage = "Tên quá dài, vui lòng chọn tên khác!", MinimumLength = 0)]

        public string Makh { get; set; }
        [Display(Name = "Họ và tên")]
        [Required]
        [StringLength(255, ErrorMessage = "Vui lòng nhập đầy đủ họ tên!", MinimumLength = 5)]

        public string Tenkh { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Vui lòng nhập đầy đủ địa chỉ!", MinimumLength = 5)]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Vui lòng kiểm tra lại số điện thoại!", MinimumLength = 9)]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "Vui lòng nhập email hợp lệ!", MinimumLength = 5)]
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }
        [Display(Name = "Giới Tính")]
        public string Gioitinh { get; set; }
        [StringLength(255, ErrorMessage = "Vui lòng cung cấp dữ liệu hợp lệ!", MinimumLength = 0)]
        [Display(Name = "Mã số thuế")]
        public string Masothue { get; set; }
        [StringLength(255, ErrorMessage = "Dữ liệu bạn cung cấp quá dài!", MinimumLength = 0)]
        [Display(Name = "Ghi chú")]
        public string Ghichu { get; set; }
        public int? Nvidsale { get; set; }
        public int? Active { get; set; }
        public int Accountidaccount { get; set; }

        public virtual Account AccountidaccountNavigation { get; set; }
        public virtual ICollection<Chitietnganhangkh> Chitietnganhangkh { get; set; }
        public virtual ICollection<Donhangsanxuat> Donhangsanxuat { get; set; }
        public virtual ICollection<Phieubanhang> Phieubanhang { get; set; }
    }
}
