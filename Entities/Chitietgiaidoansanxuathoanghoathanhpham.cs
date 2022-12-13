using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Chitietgiaidoansanxuathoanghoathanhpham
    {
        public int Idctdgsxhhtp { get; set; }
        public string Ghichu { get; set; }
        public int Giaidoansanxuatidgdsx { get; set; }
        public int Hanghoathanhphamidhhtp { get; set; }

        public virtual Giaidoansanxuat GiaidoansanxuatidgdsxNavigation { get; set; }
        public virtual Hanghoathanhpham HanghoathanhphamidhhtpNavigation { get; set; }
    }
}
