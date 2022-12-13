using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLySanXuat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.Controllers
{
    //[Authorize]
    public class QuanLyTonKhoController : Controller
    {
        ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QuanLyNhapKho()
        {
            List<Phieunhapkho> phieunhapkho = context.Phieunhapkho.Where(active => active.Active == 1).ToList();
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
