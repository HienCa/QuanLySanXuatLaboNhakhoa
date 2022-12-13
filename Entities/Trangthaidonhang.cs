using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Trangthaidonhang
    {
        public Trangthaidonhang()
        {
            Donhangsanxuat = new HashSet<Donhangsanxuat>();
        }

        public int Idttdh { get; set; }
        public string Mattdh { get; set; }
        public string Tenttdh { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Donhangsanxuat> Donhangsanxuat { get; set; }
    }
}
