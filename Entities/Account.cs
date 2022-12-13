using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Account
    {
        public Account()
        {
            Khachhang = new HashSet<Khachhang>();
            Nhanvien = new HashSet<Nhanvien>();
        }

        public int Idaccount { get; set; }
        public string Tk { get; set; }
        public string Mk { get; set; }
        public int? Active { get; set; }
        public int Vaitroidvt { get; set; }

        public virtual Vaitro VaitroidvtNavigation { get; set; }
        public virtual ICollection<Khachhang> Khachhang { get; set; }
        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
    }
}
