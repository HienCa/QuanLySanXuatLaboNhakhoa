using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Ctgiaidoansxhhtp
    {
        public int Idctgdsxhhtp { get; set; }
        public string Ghichu { get; set; }
        public int Idgdsx { get; set; }
        public int Idhhtp { get; set; }

        public virtual Giaidoansx IdgdsxNavigation { get; set; }
        public virtual Hanghoathanhpham IdhhtpNavigation { get; set; }
    }
}
