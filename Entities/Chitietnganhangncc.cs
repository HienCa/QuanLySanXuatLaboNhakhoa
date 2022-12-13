using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Chitietnganhangncc
    {
        public int Idctnhncc { get; set; }
        public int Nhacungcapidncc { get; set; }
        public int Nganhangidnh { get; set; }
        public string Stk { get; set; }

        public virtual Nganhang NganhangidnhNavigation { get; set; }
        public virtual Nhacungcap NhacungcapidnccNavigation { get; set; }
    }
}
