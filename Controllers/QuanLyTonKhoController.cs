﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.Controllers
{
    [Authorize]
    public class QuanLyTonKhoController : Controller
    {
        ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
        public async Task<IActionResult> Index()
        {
          var phieunhap= context.Phieunhapkho.Where(pn=>pn.Active==1).Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation); 
            TempData["phieunhapkho"] = context.Phieunhapkho.Where(pn => pn.Active == 1).Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation).ToList();
            //TempData["phieuxuatkho"] = context.Phieubanhang.Where(px => px.Active == 1).Include(p => p.NhanvienidnvNavigation).ToList();
     //có thể do null nên báo lỗi, kiểm tra null trước
            return View(await phieunhap.ToListAsync());
        }
        public IActionResult QuanLyNhapKho()
        {
            List<Phieunhapkho> phieunhapkho = context.Phieunhapkho.Where(active => active.Active == 1).Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation).ToList();
            return View(phieunhapkho);
        }

        public IActionResult QuanLyXuatKho()
        {
            return View();
        }

        public IActionResult BangDinhMuc()
        {
            return View();
        }

        public IActionResult BangNhap()
        {
            return View();
        }
    }
}
