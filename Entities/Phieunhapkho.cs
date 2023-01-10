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
            Noidungpnk = new HashSet<Noidungpnk>();
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idpnk { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Sophieu { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngaylap { get; set; }
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]

        public string Sohd { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ngayhd { get; set; }
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]

        public string Ghichu { get; set; }
        public int Active { get; set; }
        [Required]

        public int Idncc { get; set; }
        [Required]

        public int Idnv { get; set; }

        public virtual Nhacungcapvl IdnccNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungpnk> Noidungpnk { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
