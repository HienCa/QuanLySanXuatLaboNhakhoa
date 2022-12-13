using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungphieunhap
    {
        public int Idpnk { get; set; }
        [Display(Name = "Số lượng")]
        [Required]
        [StringLength(255, ErrorMessage = "Vui lòng nhập số lượng cần nhập kho!", MinimumLength = 1)]
        public string Soluong { get; set; }
        [Display(Name = "Đơn giá nhập")]
        [Required]
        [StringLength(255, ErrorMessage = "Vui lòng nhập đơn giá!", MinimumLength = 1)]
        public string Dongia { get; set; }
        [Required]
        public int Vatlieuidvl { get; set; }
        [Required]
        public int Phieunhapkhoidpnk { get; set; }

        public virtual Phieunhapkho PhieunhapkhoidpnkNavigation { get; set; }
        public virtual Vatlieu VatlieuidvlNavigation { get; set; }
    }
}
