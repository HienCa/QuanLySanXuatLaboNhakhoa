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
            Cttosxhhtp = new HashSet<Cttosxhhtp>();
        }

        public int Idtsx { get; set; }
        public string Matsx { get; set; }
        public string Tentsx { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idgdsx { get; set; }

        public virtual Giaidoansx IdgdsxNavigation { get; set; }
        public virtual ICollection<Cttosxhhtp> Cttosxhhtp { get; set; }
    }
}
