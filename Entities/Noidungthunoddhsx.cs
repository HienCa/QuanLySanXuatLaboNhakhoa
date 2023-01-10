using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungthunoddhsx
    {
        public int Idndtndhsx { get; set; }
        [Required]

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngaythuno { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0.01, 100000, ErrorMessage = "Vui lòng nhập số tiền hợp lệ")]
        [DataType(DataType.Currency)]
        public float Sotien { get; set; }
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]
        [Required]

        public string Ghichu { get; set; }
        [Required]

        public int Idptnkh { get; set; }
        [Required]

        public int Iddhsx { get; set; }

        public virtual Dondathangsx IddhsxNavigation { get; set; }
        public virtual Phieuthunokh IdptnkhNavigation { get; set; }
    }
}
