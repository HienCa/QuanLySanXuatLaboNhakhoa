using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieu
    {
        public Vatlieu()
        {
            Noidungpbh = new HashSet<Noidungpbh>();
            Noidungpnk = new HashSet<Noidungpnk>();
            Vatlieusxbd = new HashSet<Vatlieusxbd>();
            Vatlieusxtt = new HashSet<Vatlieusxtt>();
        }

        public int Idvl { get; set; }
        public string Mavl { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tenvl { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Quycach { get; set; }

        public float Giaban { get; set; }

        public int Active { get; set; }
        [Required]

        public int Idnvl { get; set; }
        [Required]

        public int Idhsx { get; set; }
        [Required]

        public int Idnsx { get; set; }

        public virtual Hangsx IdhsxNavigation { get; set; }
        public virtual Nuocsx IdnsxNavigation { get; set; }
        public virtual Nhomvl IdnvlNavigation { get; set; }
        public virtual ICollection<Noidungpbh> Noidungpbh { get; set; }
        public virtual ICollection<Noidungpnk> Noidungpnk { get; set; }
        public virtual ICollection<Vatlieusxbd> Vatlieusxbd { get; set; }
        public virtual ICollection<Vatlieusxtt> Vatlieusxtt { get; set; }
    }
}
