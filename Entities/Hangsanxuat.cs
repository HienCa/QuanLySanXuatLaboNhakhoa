using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Hangsanxuat
    {
        public Hangsanxuat()
        {
            Vatlieu = new HashSet<Vatlieu>();
        }

        public int Idhsx { get; set; }
        public string Mahsx { get; set; }
        public string Tenhsx { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Vatlieu> Vatlieu { get; set; }
    }
}
