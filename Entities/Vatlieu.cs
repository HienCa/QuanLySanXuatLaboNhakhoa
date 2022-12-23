using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieu
    {
        public Vatlieu()
        {
            Noidungpbh = new HashSet<Noidungpbh>();
            Noidungpnk = new HashSet<Noidungpnk>();
            Vatlieusxbd = new HashSet<Vatlieusxbd>();
            Vatlieusxtt = new HashSet<Vatlieusxtt>();
        }

        public int Idvl { get; set; }
        public string Mavl { get; set; }
        public string Tenvl { get; set; }
        public string Quycach { get; set; }
        public float Giaban { get; set; }
        public int Active { get; set; }
        public int Idnvl { get; set; }
        public int Idhsx { get; set; }
        public int Idnsx { get; set; }

        public virtual Hangsx IdhsxNavigation { get; set; }
        public virtual Nuocsx IdnsxNavigation { get; set; }
        public virtual Nhomvl IdnvlNavigation { get; set; }
        public virtual ICollection<Noidungpbh> Noidungpbh { get; set; }
        public virtual ICollection<Noidungpnk> Noidungpnk { get; set; }
        public virtual ICollection<Vatlieusxbd> Vatlieusxbd { get; set; }
        public virtual ICollection<Vatlieusxtt> Vatlieusxtt { get; set; }
    }
}
