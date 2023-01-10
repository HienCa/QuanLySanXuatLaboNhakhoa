using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungthunokh
    {
        public int Idndptnkh { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngaythuno { get; set; }
        public float Sotien { get; set; }
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]

        public string Ghichu { get; set; }
        [Required]

        public int Idptnkh { get; set; }
        [Required]

        public int Idpbh { get; set; }

        public virtual Phieubanhang IdpbhNavigation { get; set; }
        public virtual Phieuthunokh IdptnkhNavigation { get; set; }
    }
}
