using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vaitro
    {
        public Vaitro()
        {
            Account = new HashSet<Account>();
        }

        public int Idvt { get; set; }
        public string Mavt { get; set; }
        public string Tenvt { get; set; }
        public string Ghichu { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
