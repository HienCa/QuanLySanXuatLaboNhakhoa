using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Phieutranoncc
    {
        public Phieutranoncc()
        {
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idptnncc { get; set; }

        public string Sophieu { get; set; }
        [Required]
        public DateTime Ngaylap { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        [Required]

        public int Idhttt { get; set; }
        [Required]

        public int Idnv { get; set; }

        public virtual Hinhthucthanhtoan IdhtttNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
