using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Tosanxuathanghoathanhpham
    {
        public int Idtsxhhtp { get; set; }
        public int Tosanxuatidtsx { get; set; }
        public int Hanghoathanhphamidhhtp { get; set; }
        public DateTime? Ngaybd { get; set; }
        public DateTime? Ngaykt { get; set; }
        public string Ghichu { get; set; }

        public virtual Hanghoathanhpham HanghoathanhphamidhhtpNavigation { get; set; }
        public virtual Tosanxuat TosanxuatidtsxNavigation { get; set; }
    }
}
