using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Authorize]
    public class KhachhangController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public KhachhangController(ProductionManagementSoftwareContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;

        }

        // GET: Khachhang
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Khachhang.Where(kh => kh.Active == 1);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }

        // GET: Khachhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                //.Include(k => k.AccountidaccountNavigation)
                .FirstOrDefaultAsync(m => m.Idkh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Khachhang kh, string action)
        {
            try
            {
                if (action.Equals("addItem"))
                {
                    kh.Idkh = 0;
                    _context.Add(kh);

                }
                if (action.Equals("editItem"))
                {
                    kh.Active = 1;
                    _context.Update(kh);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }


        // GET: Khachhang/Create
        public IActionResult Create()
        {
            return View();
        }
        private string UploadedFile(KhachhangViewModel model)
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
        // POST: Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KhachhangViewModel khachhang)
        {
            string uniqueFileName = UploadedFile(khachhang);

            try
            {
                //Chức năng giành cho khách hàng không đăng ký tài khoản
                Khachhang kh = new Khachhang();
                //lấy hình ảnh
                kh.Hinhanh = uniqueFileName;
                kh.Idkh = khachhang.Idkh;
                kh.Makh = khachhang.Makh;
                kh.Tenkh = khachhang.Tenkh;
                kh.Diachi = khachhang.Diachi;
                kh.Cccd = khachhang.Cccd;
                kh.Sdt = khachhang.Sdt;
                kh.Email = khachhang.Email;
                kh.Gioitinh = khachhang.Gioitinh;
                kh.Masothue = khachhang.Masothue;
                kh.Ghichu = khachhang.Ghichu;
                kh.Facebook = khachhang.Facebook;
                kh.Zalo = khachhang.Zalo;
                kh.Ngaysinh = khachhang.Ngaysinh;
                kh.Active = 1;

                    kh.Matkhau = "KH12345";
                
                _context.Khachhang.Add(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(khachhang);

            }
        }


        public IActionResult CreateCustomerAccount()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomerAccount(Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                //create account customer
                //Account account = new Account();
                //account.Tk = khachhang.Email;
                //account.Mk = "KH12345";// default password 
                //account.Vaitroidvt = 2;//id =2 is customer
                //_context.Account.Add(account);
                //await _context.SaveChangesAsync();

                //var accountOfCustomer = await _context.Account.FirstOrDefaultAsync(email => email.Tk.Equals(khachhang.Email));

                //create customer 
                //khachhang.Accountidaccount = accountOfCustomer.Idaccount;
                khachhang.Matkhau = "KH12345";
                _context.Add(khachhang);
                await _context.SaveChangesAsync();



                var getCustomer = await _context.Khachhang.FirstOrDefaultAsync(email => email.Email.Equals(khachhang.Email));

                //Khởi tạo trước ngân hàng và chi tiết ngân hàng của khách hàng để thuận tiện cho khách hàng khai báo stk ngân hàng sau này
                Nganhang nganhang = new Nganhang();
                nganhang.Masothue = khachhang.Masothue;
                nganhang.Email = khachhang.Email;
                nganhang.Diachi = khachhang.Diachi;
                //nganhang.Ghichu = khachhang.Ghichu;
                nganhang.Idhttt = 1;
                _context.Nganhang.Add(nganhang);
                await _context.SaveChangesAsync();



                //Vấn đề cần giải quyết: khi 1 khách hàng sử dụng nhiều email khác nhau để đăng ký tài khoản ngân hàng
                // Giiari pháp dưới đây chỉ giải quyết cho khách hàng sử dụng 1 email cho nhiều tài khoản ngân hàng
                var getBank = await _context.Nganhang.FirstOrDefaultAsync(email => email.Email.Equals(khachhang.Email));

                Ctnganhangkh chitietnganhangkh = new Ctnganhangkh();
                chitietnganhangkh.Idkh = getCustomer.Idkh;
                chitietnganhangkh.Idnh = getBank.Idnh;
                _context.Ctnganhangkh.Add(chitietnganhangkh);
                await _context.SaveChangesAsync();

                return RedirectToAction("DangNhap", "Home");
            }
            return RedirectToAction("CreateCustomerAccount", "Khachhang");
        }

        public IActionResult ForgotPassword([Bind("Idaccount,Tk,Mk,Active,Vaitroidvt")] Account account)
        {
            ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
            //HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;

            var newPassword = "KH12345";
            string email = account.Email;
            string errorMessage = "Email không chính xác. Vui lòng kiểm tra lại email!";
            try
            {

                Khachhang kh = context.Khachhang.Where(tk => tk.Email.Equals(email)).FirstOrDefault();
                if (kh != null)
                {
                    var address = email;

                    var subject = "Reset your password";
                    var message = "Xin Chào " + kh.Tenkh + "\n Mật khẩu mới của bạn là " + newPassword;
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



                    Khachhang a = context.Khachhang.Where(tk => tk.Email.Equals(email)).FirstOrDefault();
                    a.Matkhau = newPassword;
                    context.SaveChanges();

                    TempData["Message"] = "Chúng tôi đã gửi mail xác nhận đến cho bạn. Vui lòng kiểm tra mail!";

                    return RedirectToAction("DangNhap", "Home");

                }
                else
                {
                    TempData["errorMessage"] = errorMessage;


                }
                //var kh = context.Khachhang.FirstOrDefaultAsync(email => email.Email.Equals(email));



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            TempData["Message"] = errorMessage;

            return RedirectToAction("QuenMatKhau", "Home");
        }

        // GET: Khachhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);


            KhachhangViewModel kh = new KhachhangViewModel();
            kh.ExistingImage = khachhang.Hinhanh;

            kh.Idkh = khachhang.Idkh;
            kh.Makh = khachhang.Makh;
            kh.Tenkh = khachhang.Tenkh;
            kh.Diachi = khachhang.Diachi;
            kh.Sdt = khachhang.Sdt;
            kh.Cccd = khachhang.Cccd;
            kh.Email = khachhang.Email;
            kh.Ngaysinh = khachhang.Ngaysinh;

            kh.Gioitinh = khachhang.Gioitinh;
            kh.Masothue = khachhang.Masothue;
            kh.Ghichu = khachhang.Ghichu;
            kh.Nvidsale = khachhang.Nvidsale;
            kh.Facebook = khachhang.Facebook;
            kh.Zalo = khachhang.Zalo;
            kh.ExistingImage = khachhang.Hinhanh;

            //kh.Accountidaccount = khachhang.Accountidaccount;
            //kh.NgaySinh = khachhang.NgaySinh;
            kh.Active = 1;
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(kh);
        }

        // POST: Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KhachhangViewModel khachhang)
        {
            string uniqueFileName = UploadedFile(khachhang);


            try
            {
                Khachhang kh = new Khachhang();
                //lấy hình ảnh
                kh.Hinhanh = uniqueFileName;
                kh.Idkh = khachhang.Idkh;
                kh.Makh = khachhang.Makh;
                kh.Tenkh = khachhang.Tenkh;
                kh.Diachi = khachhang.Diachi;
                kh.Sdt = khachhang.Sdt;

                kh.Email = khachhang.Email;
                kh.Gioitinh = khachhang.Gioitinh;
                kh.Masothue = khachhang.Masothue;
                kh.Ghichu = khachhang.Ghichu;
                kh.Facebook = khachhang.Facebook;
                kh.Zalo = khachhang.Zalo;
                //kh.Accountidaccount = khachhang.Accountidaccount;
                kh.Ngaysinh = khachhang.Ngaysinh;

                if (khachhang.Hinhanh != null)
                {
                    if (khachhang.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", khachhang.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    kh.Hinhanh = UploadedFile(khachhang);
                }
                kh.Active = 1;
                _context.Khachhang.Update(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(khachhang);
            }



        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var kh = _context.Khachhang.Where(m => m.Idkh == id).FirstOrDefault();

                kh.Active = 0;
                _context.Khachhang.Update(kh);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }



        }
        // GET: Khachhang/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var khachhang = await _context.Khachhang

        //        .FirstOrDefaultAsync(m => m.Idkh == id);
        //    if (khachhang == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(khachhang);
        //}

        // POST: Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhang.FindAsync(id);
            khachhang.Active = 0;
            _context.Khachhang.Update(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhang.Any(e => e.Idkh == id);
        }
    }
}
