using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Nganhang
    {
        public Nganhang()
        {
            Ctnganhangkh = new HashSet<Ctnganhangkh>();
            Ctnganhangncc = new HashSet<Ctnganhangncc>();
        }

        public int Idnh { get; set; }
        public string Tennh { get; set; }
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        [Required]
        public string Diachi { get; set; }
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        [Required]
        public string Email { get; set; }
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        [Required]
        public string Masothue { get; set; }
      

        public string Ghichu { get; set; }
        public int Active { get; set; }
        [Required]

        public int Idhttt { get; set; }

        public virtual Hinhthucthanhtoan IdhtttNavigation { get; set; }
        public virtual ICollection<Ctnganhangkh> Ctnganhangkh { get; set; }
        public virtual ICollection<Ctnganhangncc> Ctnganhangncc { get; set; }
    }
}
