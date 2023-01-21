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
        
    
        [Required]

        public float Soluong { get; set; }
     
        [Required]

        public string Donvitinh { get; set; }
        [Required]

        public float Dongia { get; set; }
        [Required]
       
        public string Solo { get; set; }
        [Required]

        public DateTime? Ngaysx { get; set; }
        [Required]

        public DateTime? Hansd { get; set; }
        [Required]

        public int Idpnk { get; set; }
        [Required]

        public int Idvl { get; set; }

        public virtual Phieunhapkho IdpnkNavigation { get; set; }
        public virtual Vatlieu IdvlNavigation { get; set; }
    }
}
