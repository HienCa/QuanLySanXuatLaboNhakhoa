using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Noidungthunokh
    {
        public int Idndtnkh { get; set; }
        public string Sotien { get; set; }
        public string Ghichu { get; set; }
        public int Phieuthunokhidptnkh { get; set; }
        public int Phieubanhangidpbh { get; set; }
        public DateTime Ngaythuno { get; set; }

        public virtual Phieubanhang PhieubanhangidpbhNavigation { get; set; }
        public virtual Phieuthunokh PhieuthunokhidptnkhNavigation { get; set; }
    }
}
