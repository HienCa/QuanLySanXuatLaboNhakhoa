﻿using Microsoft.AspNetCore.Http;
using QuanLySanXuat.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class KhachhangViewModel : EditImageViewModel
    {
        public KhachhangViewModel()
        {
            Chitietnganhangkh = new HashSet<Chitietnganhangkh>();
            Donhangsanxuat = new HashSet<Donhangsanxuat>();
            Phieubanhang = new HashSet<Phieubanhang>();
        }

        public int Idkh { get; set; }
        public string Makh { get; set; }
        public string Tenkh { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Gioitinh { get; set; }
        public string Masothue { get; set; }
        public string Ghichu { get; set; }
        public int? Nvidsale { get; set; }
        public int? Active { get; set; }
        public int Accountidaccount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }
        //public IFormFile Hinhanh { get; set; }


        public virtual Account AccountidaccountNavigation { get; set; }
        public virtual ICollection<Chitietnganhangkh> Chitietnganhangkh { get; set; }
        public virtual ICollection<Donhangsanxuat> Donhangsanxuat { get; set; }
        public virtual ICollection<Phieubanhang> Phieubanhang { get; set; }
    }
}