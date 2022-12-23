using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public AdminController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View( );
        }
        public IActionResult DonHang()
        {
            return View();
        }

        

        public IActionResult QuanLyNhanVien()
        {
            return View();
        }
        public IActionResult ThemNhanVien()
        {
            return View();
        }



        public async Task<IActionResult> QuanLySanPham()
        {
            List<Vatlieu> VatLieu = _context.Vatlieu.ToList();
            //List<Hangsanxuat> hangsx = _context.Hangsanxuat.ToList();
            //List<Nhomvatlieu> nhomvl = _context.Nhomvatlieu.ToList();

            TempData["NCC"] = _context.Nhacungcapvl.ToList();
            TempData["HangSX"] = _context.Hangsx.ToList();
            TempData["NhomVL"] = _context.Nhomvl.ToList();

            return View(await _context.Vatlieu.ToListAsync());
        }
        public IActionResult ThemSanPham()
        {
            return View();
        }
        public IActionResult QuanLyKhachHang()
        {
            return View();
        }
        public IActionResult ThemKhachHang()
        {
            return View();
        }

        public IActionResult QuanLyDonHang()
        {
            return View();
        }
        public IActionResult ThemDonHang()
        {
            return View();
        }
        public IActionResult QuanLyDoiNhom()
        {
            return View();
        }
        public IActionResult ThemDoiNhom()
        {
            return View();
        }
        public IActionResult QuanLyBaoCaoDoanhThu()
        {
            return View();
        }

        
    }
}
