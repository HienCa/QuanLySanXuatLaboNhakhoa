using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Vatlieu
    {
        public Vatlieu()
        {
            Noidungphieunhap = new HashSet<Noidungphieunhap>();
            Vatlieusanxuatbandau = new HashSet<Vatlieusanxuatbandau>();
            Vatlieusanxuatthuc = new HashSet<Vatlieusanxuatthuc>();
        }

        public int Idvl { get; set; }
        [Required]
        [Display(Name = "Mã vật liệu")]
        [StringLength(255, ErrorMessage = "Thông tin bạn cung cấp quá dài!", MinimumLength = 1)]
        public string Mavl { get; set; }
        [Required]
        [Display(Name = "Tên vật liệu")]
        [StringLength(255, ErrorMessage = "Thông tin bạn cung cấp quá dài!", MinimumLength = 1)]
        public string Tenvl { get; set; }
        [Required]
        [Display(Name = "Đơn vị tính")]
        [StringLength(255, ErrorMessage = "Thông tin bạn cung cấp quá dài!", MinimumLength = 1)]
        public string Donvitinh { get; set; }
        [Required]
        [Display(Name = "Quy cách")]
        [StringLength(255, ErrorMessage = "Thông tin bạn cung cấp quá dài!", MinimumLength = 1)]
        public string Quycach { get; set; }
        //[Required]
        [Display(Name = "Giá")]
        //[StringLength(255, ErrorMessage = "Thông tin bạn cung cấp quá dài!", MinimumLength = 1)]
        public string Giaban { get; set; }
        public int? Active { get; set; }
        public int Nhomvatlieuidnvl { get; set; }
        public int Hangsanxuatidhsx { get; set; }
        public int Nhacungcapidncc { get; set; }

        public virtual Hangsanxuat HangsanxuatidhsxNavigation { get; set; }
        public virtual Nhacungcap NhacungcapidnccNavigation { get; set; }
        public virtual Nhomvatlieu NhomvatlieuidnvlNavigation { get; set; }
        public virtual ICollection<Noidungphieunhap> Noidungphieunhap { get; set; }
        public virtual ICollection<Vatlieusanxuatbandau> Vatlieusanxuatbandau { get; set; }
        public virtual ICollection<Vatlieusanxuatthuc> Vatlieusanxuatthuc { get; set; }
    }
}
