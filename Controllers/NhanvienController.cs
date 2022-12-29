using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
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
            var productionManagementSoftwareContext = _context.Nhanvien.Where(nv => nv.Active == 1);
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
                //.Include(k => k.AccountidaccountNavigation)
                //.Include(k => k.LoainhanvienidlnvNavigation)
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
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( NhanvienViewModel nhanvien)
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
                //Account a = _context.Account.Where(n => n.Tk.Equals(accountEmployee.Tk)).FirstOrDefault();

                //copy lại nhanvien vì NhanvienViewModel không được gán bằng Nhanvien
                Nhanvien nv = new Nhanvien();
                //lấy hình ảnh
                nv.Hinhanh = uniqueFileName;
                nv.Idnv = nhanvien.Idnv;
                nv.Manv = nhanvien.Manv;
                nv.Cccd = nhanvien.Cccd;
                nv.Tennv = nhanvien.Tennv;
                nv.Diachi = nhanvien.Diachi;
                nv.Sdt = nhanvien.Sdt;
                nv.Email = nhanvien.Email;
                nv.Gioitinh = nhanvien.Gioitinh;
                nv.Masothue = nhanvien.Masothue;
                nv.Ghichu = nhanvien.Ghichu;
                //nv.Loainhanvienidlnv = nhanvien.Loainhanvienidlnv;
                //nv.Accountidaccount = nhanvien.Accountidaccount;
                nv.Ngaysinh = nhanvien.Ngaysinh;

                //nv.Accountidaccount = a.Idaccount;
                nv.Active = 1;
                _context.Add(nv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }


        public IActionResult ForgotPassword([Bind("Idaccount,Tk,Mk,Active,Vaitroidvt")] Account account)
        {
            ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
            //HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;

            var newPassword = "KH12345";
            string email = account.Tk;
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



                    //Account a = context.Account.Where(tk => tk.Tk.Equals(email)).FirstOrDefault();
                    kh.Matkhau = newPassword;
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

            var nhanvien = await _context.Nhanvien.FindAsync(id);

            NhanvienViewModel nv = new NhanvienViewModel();
            nv.Idnv = nhanvien.Idnv;
            nv.Manv = nhanvien.Manv;
            nv.Tennv = nhanvien.Tennv;
            nv.Cccd = nhanvien.Cccd;
            nv.Diachi = nhanvien.Diachi;
            nv.Sdt = nhanvien.Sdt;
            nv.Gioitinh = nhanvien.Gioitinh;
            nv.Masothue = nhanvien.Masothue;
            nv.Ghichu = nhanvien.Ghichu;
            //nv.Loainhanvienidlnv = nhanvien.Loainhanvienidlnv;
            //nv.Accountidaccount = nhanvien.Accountidaccount;
            nv.Ngaysinh = nhanvien.Ngaysinh;
            nv.Active = nhanvien.Active;
            nv.ExistingImage = nhanvien.Hinhanh;

            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nv);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NhanvienViewModel nhanvien)
        {

            if (id != nhanvien.Idnv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    Nhanvien nv = new Nhanvien();

                    //lấy hình ảnh
                    //nv.Hinhanh = uniqueFileName;
                    nv.Idnv = nhanvien.Idnv;
                    nv.Manv = nhanvien.Manv;
                    nv.Tennv = nhanvien.Tennv;
                    nv.Diachi = nhanvien.Diachi;
                    nv.Sdt = nhanvien.Sdt;
                    nv.Gioitinh = nhanvien.Gioitinh;
                    nv.Masothue = nhanvien.Masothue;
                    nv.Ghichu = nhanvien.Ghichu;
                    nv.Cccd = nhanvien.Cccd;
                    //nv.Loainhanvienidlnv = nhanvien.Loainhanvienidlnv;
                    //nv.Accountidaccount = nhanvien.Accountidaccount;
                    nv.Ngaysinh = nhanvien.Ngaysinh;


                    nv.Active = nhanvien.Active;

                    if (nhanvien.Hinhanh != null)
                    {
                        if (nhanvien.ExistingImage != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", nhanvien.ExistingImage);
                            System.IO.File.Delete(filePath);
                        }

                        nv.Hinhanh = UploadedFile(nhanvien);
                    }


                    _context.Update(nv);
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
                //.Include(k => k.AccountidaccountNavigation)
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
            return RedirectToAction("Index", "Nhanvien");
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanvien.Any(e => e.Idnv == id);
        }


        public IActionResult ExportToCSV()
        {

            List<Nhanvien> nhanvien = _context.Nhanvien.Where(nv => nv.Active == 1).ToList();

            var builder = new StringBuilder();
            builder.AppendLine("Mã nhân viên, Họ và tên, CCCD, Số điện thoại, Email, Địa chỉ, Ngày sinh, Giới tính, Mã số thuế");
            foreach (var nv in nhanvien)
            {
                builder.AppendLine($"{nv.Manv}, {nv.Tennv}, {nv.Cccd}, {nv.Sdt}, {nv.Email}, {nv.Diachi}, {nv.Ngaysinh}, {nv.Gioitinh}, {nv.Masothue}");
            }

            return File(new System.Text.UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "employees.csv");


        }
       
        public IActionResult ExportToExcel()
        {

            List<Nhanvien> all = _context.Nhanvien.Where(nv => nv.Active == 1).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Students");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Mã nhân viên";
                worksheet.Cell(currentRow, 2).Value = "Họ và tên";
                worksheet.Cell(currentRow, 3).Value = "CCCD";
                worksheet.Cell(currentRow, 4).Value = "Số điện thoại";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Địa chỉ";
                worksheet.Cell(currentRow, 7).Value = "Ngày Sinh";
                worksheet.Cell(currentRow, 8).Value = "Giới Tính";
                worksheet.Cell(currentRow, 9).Value = "Mã số thuế";

                foreach (var nv in all)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = nv.Manv;
                    worksheet.Cell(currentRow, 2).Value = nv.Tennv;
                    worksheet.Cell(currentRow, 3).Value = nv.Cccd;
                    worksheet.Cell(currentRow, 4).Value = nv.Sdt;
                    worksheet.Cell(currentRow, 5).Value = nv.Email;
                    worksheet.Cell(currentRow, 6).Value = nv.Diachi;
                    worksheet.Cell(currentRow, 7).Value = nv.Ngaysinh;
                    worksheet.Cell(currentRow, 8).Value = nv.Gioitinh;
                    worksheet.Cell(currentRow, 9).Value = nv.Masothue;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employyes.xlsx");
                }
            }



        }

        //chưa xử lý được ngày sinh
        public async Task Import(IFormFile file)
        {
           
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var pakage = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = pakage.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {

                        Nhanvien nhanvien = new Nhanvien();

                        nhanvien.Manv = worksheet.Cells[row, 1].Value.ToString().Trim();
                        nhanvien.Tennv = worksheet.Cells[row, 2].Value.ToString().Trim();
                        nhanvien.Cccd = worksheet.Cells[row, 3].Value.ToString().Trim();
                        nhanvien.Sdt = worksheet.Cells[row, 4].Value.ToString().Trim();
                        nhanvien.Email = worksheet.Cells[row, 5].Value.ToString().Trim();
                        nhanvien.Diachi = worksheet.Cells[row, 6].Value.ToString().Trim();
                        //string dateString = worksheet.Cells[row, 6].Value.ToString().Trim();

                        nhanvien.Gioitinh = worksheet.Cells[row, 8].Value.ToString().Trim();
                        nhanvien.Masothue = worksheet.Cells[row, 9].Value.ToString().Trim();
                        //nhanvien.Loainhanvienidlnv = 1;
                        //nhanvien.Accountidaccount = 1;





                        //nhanvien.NgaySinh = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);


                        _context.Nhanvien.Add(nhanvien);
                        await _context.SaveChangesAsync();

                    }
                }
            }

        }

       

    }
}

