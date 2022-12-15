using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using QuanLySanXuat.Entities;
using QuanLySanXuat.Models;
using QuanLySanXuat.Service;

namespace QuanLySanXuat.Controllers
{
    public class NhanvienController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public NhanvienController(ProductionManagementSoftwareContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Nhanvien.Where(nv=>nv.Active==1).Include(k => k.AccountidaccountNavigation).Include(k => k.LoainhanvienidlnvNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(k => k.AccountidaccountNavigation)
                .Include(k => k.LoainhanvienidlnvNavigation)
                .FirstOrDefaultAsync(m => m.Idnv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }


        private string UploadedFile(NhanvienViewModel model)
        {
            string uniqueFileName = null;

            if (model.Hinhanh != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Hinhanh.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Hinhanh.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            //ImageModel imageModel = new ImageModel();
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount");
            //return View(imageModel);
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnv,Manv,Tennv,Diachi,Sdt,Email,Gioitinh,Masothue,Ghichu,Active,Loainhanvienidlnv,Accountidaccount,NgaySinh,Hinhanh")] NhanvienViewModel nhanvien)
        {
            string uniqueFileName = UploadedFile(nhanvien);

            if (ModelState.IsValid)
            {
              
                Account accountEmployee = new Account();
                accountEmployee.Tk = nhanvien.Email;
                accountEmployee.Mk = "NV12345";
                accountEmployee.Vaitroidvt = 5;//nhân viên thường
                _context.Add(accountEmployee);
                await _context.SaveChangesAsync();
                Account a = _context.Account.Where(n => n.Tk.Equals(accountEmployee.Tk)).FirstOrDefault();

                //copy lại nhanvien vì NhanvienViewModel không được gán bằng Nhanvien
                Nhanvien nv = new Nhanvien();
                //lấy hình ảnh
                nv.Hinhanh = uniqueFileName;
                nv.Idnv = nhanvien.Idnv;
                nv.Manv = nhanvien.Manv;
                nv.Tennv = nhanvien.Tennv;
                nv.Diachi = nhanvien.Diachi;
                nv.Sdt = nhanvien.Sdt;
                nv.Gioitinh = nhanvien.Gioitinh;
                nv.Masothue = nhanvien.Masothue;
                nv.Ghichu = nhanvien.Ghichu;
                nv.Loainhanvienidlnv = nhanvien.Loainhanvienidlnv;
                nv.Accountidaccount = nhanvien.Accountidaccount;
                nv.NgaySinh = nhanvien.NgaySinh;

                nv.Accountidaccount = a.Idaccount;
                nv.Active = 1;
                _context.Add(nv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", nhanvien.Accountidaccount);
            return View(nhanvien);
        }


        //public IActionResult CreateCustomerAccount()
        //{
        //    //ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount");
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateCustomerAccount([Bind("Idnv,Manv,Tenkh,Diachi,Sdt,Email,Gioitinh,Masothue,Ghichu,Active,Accountidaccount,NgaySinh,Hinhanh")] Nhanvien nhanvien)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //create account customer
        //        Account account = new Account();
        //        account.Tk = nhanvien.Email;
        //        account.Mk = "KH12345";// default password 
        //        account.Vaitroidvt = 2;//id =2 is customer
        //        _context.Account.Add(account);
        //        await _context.SaveChangesAsync();

        //        var accountOfCustomer = await _context.Account.FirstOrDefaultAsync(email => email.Tk.Equals(nhanvien.Email));

        //        //create customer 
        //        nhanvien.Accountidaccount = accountOfCustomer.Idaccount;
        //        _context.Add(nhanvien);
        //        await _context.SaveChangesAsync();



        //        var getCustomer = await _context.Nhanvien.FirstOrDefaultAsync(email => email.Email.Equals(nhanvien.Email));

        //        //Khởi tạo trước ngân hàng và chi tiết ngân hàng của khách hàng để thuận tiện cho khách hàng khai báo stk ngân hàng sau này
        //        Nganhang nganhang = new Nganhang();
        //        nganhang.Masothue = nhanvien.Masothue;
        //        nganhang.Email = nhanvien.Email;
        //        nganhang.Diachi = nhanvien.Diachi;
        //        //nganhang.Ghichu = khachhang.Ghichu;
        //        nganhang.Hinhthucthanhtoanidhttt = 1;
        //        _context.Nganhang.Add(nganhang);
        //        await _context.SaveChangesAsync();



        //        //Vấn đề cần giải quyết: khi 1 khách hàng sử dụng nhiều email khác nhau để đăng ký tài khoản ngân hàng
        //        // Giiari pháp dưới đây chỉ giải quyết cho khách hàng sử dụng 1 email cho nhiều tài khoản ngân hàng
        //        var getBank = await _context.Nganhang.FirstOrDefaultAsync(email => email.Email.Equals(nhanvien.Email));

        //        Chitietnganhangkh chitietnganhangkh = new Chitietnganhangkh();
        //        chitietnganhangkh.Khachhangidkh = getCustomer.Idnv;
        //        chitietnganhangkh.Nganhangidnh = getBank.Idnh;
        //        _context.Chitietnganhangkh.Add(chitietnganhangkh);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("DangNhap", "Home");
        //    }
        //    ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", khachhang.Accountidaccount);
        //    return RedirectToAction("CreateCustomerAccount", "Khachhang");
        //}

        public IActionResult ForgotPassword([Bind("Idaccount,Tk,Mk,Active,Vaitroidvt")] Account account)
        {
            ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
            //HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;

            var newPassword = "KH12345";
            string email = account.Tk;
            string errorMessage = "Email không chính xác. Vui lòng kiểm tra lại email!";
            try
            {

                Nhanvien kh = context.Nhanvien.Where(tk => tk.Email.Equals(email)).FirstOrDefault();
                if (kh != null)
                {
                    var address = email;

                    var subject = "Reset your password";
                    var message = "Xin Chào " + kh.Tennv + "\n Mật khẩu mới của bạn là " + newPassword;
                    //sendmail(từ mail, đến mail, tiêu đề, nội dung, mail gửi, mật khẩu ứng dụng)




                    var mailContent = new MailContent();
                    mailContent.To = "dtny050601@gmail.com";
                    mailContent.Subject = subject;
                    mailContent.Body = "<h1>FORM HIENCA</h1>" + message;

                    //IConfiguration _configuration = null;

                    //_configuration.GetSection("MailSettings");

                    ////khai báo lấy cấu hình trong appsetting.json ra
                    //IOptions<MailSettings> mailSettings = mailSettings.;
                    //SendMailService c = new SendMailService(mailSettings);
                    SendMailService c = new SendMailService();


                    c.SendMail(mailContent);



                    Account a = context.Account.Where(tk => tk.Tk.Equals(email)).FirstOrDefault();
                    a.Mk = newPassword;
                    context.SaveChanges();

                    TempData["Message"] = "Chúng tôi đã gửi mail xác nhận đến cho bạn. Vui lòng kiểm tra mail!";

                    return RedirectToAction("DangNhap", "Home");

                }
                else
                {
                    TempData["errorMessage"] = errorMessage;


                }
         



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            TempData["Message"] = errorMessage;

            return RedirectToAction("QuenMatKhau", "Home");
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Nhanvien = await _context.Nhanvien.FindAsync(id);
            if (Nhanvien == null)
            {
                return NotFound();
            }
            ViewData["Accountidaccount"] = Nhanvien.Accountidaccount;

            return View(Nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnv,Manv,Tennv,Diachi,Sdt,Email,Gioitinh,Masothue,Ghichu,Active,Loainhanvienidlnv,Accountidaccount,NgaySinh,Hinhanh")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Idnv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nhanvien nv = nhanvien;
                    nhanvien.Active = 1;
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Idnv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", nhanvien.Accountidaccount);
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(k => k.AccountidaccountNavigation)
                .FirstOrDefaultAsync(m => m.Idnv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            nhanvien.Active = 0;
            _context.Nhanvien.Update(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Nhanvien");
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanvien.Any(e => e.Idnv == id);
        }
    }
}

