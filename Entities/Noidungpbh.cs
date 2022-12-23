using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungpbh
    {
        public int Idndpbh { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
        public int Idpbh { get; set; }
        public int Idvl { get; set; }

        public virtual Phieubanhang IdpbhNavigation { get; set; }
        public virtual Vatlieu IdvlNavigation { get; set; }
    }
}
