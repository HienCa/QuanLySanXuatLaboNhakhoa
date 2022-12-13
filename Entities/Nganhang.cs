using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Nganhang
    {
        public Nganhang()
        {
            Chitietnganhangkh = new HashSet<Chitietnganhangkh>();
            Chitietnganhangncc = new HashSet<Chitietnganhangncc>();
        }

        public int Idnh { get; set; }
        public string Tennh { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Masothue { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }
        public int Hinhthucthanhtoanidhttt { get; set; }

        public virtual Hinhthucthanhtoan HinhthucthanhtoanidhtttNavigation { get; set; }
        public virtual ICollection<Chitietnganhangkh> Chitietnganhangkh { get; set; }
        public virtual ICollection<Chitietnganhangncc> Chitietnganhangncc { get; set; }
    }
}
