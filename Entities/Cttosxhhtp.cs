using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Cttosxhhtp
    {
        public int Idcttsxhhtp { get; set; }
        public DateTime Ngaybd { get; set; }
        public DateTime Ngaykt { get; set; }
        public string Ghichu { get; set; }
        public int Idtsx { get; set; }
        public int Idhhtp { get; set; }

        public virtual Hanghoathanhpham IdhhtpNavigation { get; set; }
        public virtual Tosanxuat IdtsxNavigation { get; set; }
    }
}
