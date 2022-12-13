using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Tosanxuat
    {
        public Tosanxuat()
        {
            Tosanxuathanghoathanhpham = new HashSet<Tosanxuathanghoathanhpham>();
        }

        public int Idtsx { get; set; }
        public string Matsx { get; set; }
        public string Tentsx { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Giaidoansanxuatidgdsx { get; set; }

        public virtual Giaidoansanxuat GiaidoansanxuatidgdsxNavigation { get; set; }
        public virtual ICollection<Tosanxuathanghoathanhpham> Tosanxuathanghoathanhpham { get; set; }
    }
}
