using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Tosanxuat
    {
        public Tosanxuat()
        {
            Cttosxhhtp = new HashSet<Cttosxhhtp>();
        }

        public int Idtsx { get; set; }
        public string Matsx { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tentsx { get; set; }
        [StringLength(4000, ErrorMessage = "Thông tin cung cấp quá dài!")]

        public string Ghichu { get; set; }
        public int Active { get; set; }
        [Required]

        public int Idgdsx { get; set; }

        public virtual Giaidoansx IdgdsxNavigation { get; set; }
        public virtual ICollection<Cttosxhhtp> Cttosxhhtp { get; set; }
    }
}
