using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Nuocsx
    {
        public Nuocsx()
        {
            Vatlieu = new HashSet<Vatlieu>();
        }

        public int Idnsx { get; set; }
        public string Mansx { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Tennsx { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Vatlieu> Vatlieu { get; set; }
    }
}
