using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Nhacungcapvl
    {
        public Nhacungcapvl()
        {
            Ctnganhangncc = new HashSet<Ctnganhangncc>();
            Phieunhapkho = new HashSet<Phieunhapkho>();
        }

        public int Idncc { get; set; }
        public string Mancc { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tenncc { get; set; }
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
        public string Masothue { get; set; }
    
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Ghichu { get; set; }

        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Facebook { get; set; }

        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Zalo { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Ctnganhangncc> Ctnganhangncc { get; set; }
        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
    }
}
