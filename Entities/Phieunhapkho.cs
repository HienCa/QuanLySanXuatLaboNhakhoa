using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieunhapkho
    {
        public Phieunhapkho()
        {
            Noidungphieunhap = new HashSet<Noidungphieunhap>();
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idpnk { get; set; }
        [Display(Name ="Số phiếu")]
        [Required]

        [StringLength(255, ErrorMessage = "Thông tin nhập quá dài!", MinimumLength = 1)]
        public string Sophieu { get; set; }
        [Required]
        [Display(Name = "Ngày nhập")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Ngaynhap { get; set; }
        [Display(Name = "Số hóa đơn")]

        public string Sohd { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày hóa đơn")]

        public string Ngayhd { get; set; }
        [Display(Name = "Ghi chú")]
        [StringLength(255, ErrorMessage = "Thông tin nhập quá dài!", MinimumLength = 0)]
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Nhanvienidnv { get; set; }

        public virtual Nhanvien NhanvienidnvNavigation { get; set; }
        public virtual ICollection<Noidungphieunhap> Noidungphieunhap { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
