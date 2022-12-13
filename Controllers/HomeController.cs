using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuanLySanXuat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanXuat.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace QuanLySanXuat.Controllers
{
    public class HomeController : Controller
    {
        ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(Khachhang kh)
        {
            //if (ModelState.IsValid)
            //{
            //    var HOTEN = HttpContext.Request.Query["Tenkh"].ToString();
            //    var SDT = HttpContext.Request.Query["Sdt"].ToString();
            //    var EMAIL = HttpContext.Request.Query["Email"].ToString();
            //    var DIACHI = HttpContext.Request.Query["Diachi"].ToString();
            //    var GIOITINH = HttpContext.Request.Query["GioiTinh"].ToString();
            //    var MASOTHUE = HttpContext.Request.Query["Masothue"].ToString();
            //    var GHICHU = HttpContext.Request.Query["Ghichu"].ToString();
            //    var MAKH = HttpContext.Request.Query["Makh"].ToString();
            //    //var ACTIVE = 1;
               
            //    kh.Active = 1;
            //    kh.Accountidaccount = 2;
            //    context.Khachhang.Add(kh);


            //    Account account = new Account();
            //    account.Active = 1;
            //    account.Tk = EMAIL;
            //    account.Mk = "KH12345";
            //    context.Account.Add(account);
            //    context.SaveChanges();

            //    //context.Database.ExecuteSqlRaw($"CREATECUSTOMER {MAKH},{HOTEN},{DIACHI},{SDT},{EMAIL},{GIOITINH},{MASOTHUE},{GHICHU},{ACTIVE}");
            //    //context.Database.ExecuteSqlRaw($"CREATECUSTOMERACCOUNT {EMAIL}");
            //    return RedirectToAction("DangNhap", "Home");
            //}
            
            return View();
        }
        //public IActionResult DangNhap()
        //{
        //    return View();
        //}
        public IActionResult DangNhap(Account a)
        {

            

            //if (Request.Form.Count > 0)
            //{
            //String TK = Request.Form["TK"];
            //String MK = Request.Form["MK"];

            Account account = context.Account.Where(n => n.Tk == a.Tk && n.Mk == a.Mk).FirstOrDefault();
            if (account != null)
            {
                Nhanvien nhanvien = context.Nhanvien.Where(n => n.Accountidaccount == account.Idaccount).FirstOrDefault();
                Khachhang khachhang = context.Khachhang.Where(n => n.Accountidaccount == account.Idaccount).FirstOrDefault();


                //var claims = new List<Claim> { new Claim(ClaimTypes.Name, a.Tk) };
                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);
                //var props = new AuthenticationProperties();
                //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                //if (nhanvien.Email != null || khachhang.Email !=null)
                //{
                    
                    if (account.Vaitroidvt == 1)
                    {
                    Response.Cookies.Append("HienCaCookie", nhanvien.Email);
                    return RedirectToAction("Index", "VatLieu");
                    }
                    else if (account.Vaitroidvt == 2)
                    {
                    Response.Cookies.Append("HienCaCookie", khachhang.Email);
                    return RedirectToAction("Index", "PersonalInformationManament");
                    }

                    else if (account.Vaitroidvt == 3)
                    {
                    //quản lý
                    Response.Cookies.Append("HienCaCookie", nhanvien.Email);
                    return RedirectToAction("Index", "PersonalInformationManament");
                    }
                    else if (account.Vaitroidvt == 4)
                    {
                        return RedirectToAction("Index", "PersonalInformationManament");
                    }
                //}
                //else
                //{
                //    return RedirectToAction("DangNhap", "Home");
                //}
            }

            //}

            return View();

        }


        public IActionResult DangXuat()
        {
            Response.Cookies.Delete("HienCaCookie");
            return RedirectToAction("DangNhap");
        }
        

        public IActionResult QuenMatKhau()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //Scaffold-DbContext “Data Source =.; Initial Catalog = ProductionManagementSoftware; Persist Security Info=True;User ID = sa; Password=sa”  Microsoft.EntityFrameworkCore.SQLServer -f –Output Entities
    }
}
