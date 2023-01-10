using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungpnk
    {
        public int Idndpnk { get; set; }
        
        [Range(1, 10000000, ErrorMessage ="Số lượng không hợp lệ")]
        [Required]

        public float Soluong { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        //[Range(0,100000000, ErrorMessage = "Vui lòng nhập số tiền hợp lệ")]

        [DataType(DataType.Currency)]
        public float Dongia { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Solo { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ngaysx { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Hansd { get; set; }
        [Required]

        public int Idpnk { get; set; }
        [Required]

        public int Idvl { get; set; }

        public virtual Phieunhapkho IdpnkNavigation { get; set; }
        public virtual Vatlieu IdvlNavigation { get; set; }
    }
}
