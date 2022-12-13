using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;
using Windows.Web.Http;

namespace QuanLySanXuat.Controllers
{
    public class PersonalInformationManamentController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PersonalInformationManamentController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }
        ProductionManagementSoftwareContext context = new ProductionManagementSoftwareContext();
        // GET: PersonalInformationManament
        public IActionResult Index()
        {
            string customerEmail = Request.Cookies["HienCaCookie"];
            Khachhang KH = context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
            return View(KH);
        }

        //Quản lý thông tin tài khoản ngân hàng của khách hàng
        public IActionResult PersonalBankManament()
        {
            string customerEmail = Request.Cookies["HienCaCookie"];
            Khachhang KH = context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
            //join 3 bảng
            var BankDetails = _context.Chitietnganhangkh.Where(idkh=>idkh.Khachhangidkh==KH.Idkh)
                .Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);
            ViewData["Fullname"] = KH.Tenkh;

            
            
            return View(BankDetails);
        }
        public IActionResult PersonalOrderManament()
        {
            string customerEmail = Request.Cookies["HienCaCookie"];
            Khachhang KH = context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
            //join 3 bảng
            //var BankDetails = _context.Chitietnganhangkh.Where(idkh => idkh.Khachhangidkh == KH.Idkh)
            //    .Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);
            ViewData["Fullname"] = KH.Tenkh;



            return View();
        }
        public IActionResult RateOfProgress()
        {
            string customerEmail = Request.Cookies["HienCaCookie"];
            Khachhang KH = context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
            //join 3 bảng
            //var BankDetails = _context.Chitietnganhangkh.Where(idkh => idkh.Khachhangidkh == KH.Idkh)
            //    .Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);
            ViewData["Fullname"] = KH.Tenkh;



            return View();
        }






        // GET: PersonalInformationManament/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .Include(k => k.AccountidaccountNavigation)
                .FirstOrDefaultAsync(m => m.Idkh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: PersonalInformationManament/Create
        public IActionResult Create()
        {
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount");
            return View();
        }

        // POST: PersonalInformationManament/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkh,Makh,Tenkh,Diachi,Sdt,Email,Gioitinh,Masothue,Ghichu,Nvidsale,Active,Accountidaccount")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", khachhang.Accountidaccount);
            return View(khachhang);
        }

        // GET: PersonalInformationManament/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", khachhang.Accountidaccount);
            return View(khachhang);
        }

        // POST: PersonalInformationManament/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Idkh,Makh,Tenkh,Diachi,Sdt,Email,Gioitinh,Masothue,Ghichu,Nvidsale,Active,Accountidaccount")] Khachhang khachhang)
        {
            Khachhang kh = context.Khachhang.Where(kh => kh.Idkh == khachhang.Idkh).FirstOrDefault();

            if (ModelState.IsValid)
            {
                try
                {
                    khachhang.Nvidsale = kh.Nvidsale;
                    khachhang.Accountidaccount = kh.Accountidaccount;
                    khachhang.Active = kh.Active;
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();


                    // cập nhật lại thông tin ngân hàng của khách hàng
                    var getBank = await _context.Nganhang.FirstOrDefaultAsync(email => email.Email.Equals(kh.Email));

                    getBank.Masothue = khachhang.Masothue;
                    getBank.Email = khachhang.Email;
                    getBank.Diachi = khachhang.Diachi;

                    _context.Update(getBank);
                    await _context.SaveChangesAsync();


                    ViewData["Message"] = "Thông tin đã được cập nhật thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.Idkh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "PersonalInformationManament");
            }
            ViewData["Accountidaccount"] = new SelectList(_context.Account, "Idaccount", "Idaccount", khachhang.Accountidaccount);
            return RedirectToAction("Index", "PersonalInformationManament");

        }

        // GET: PersonalInformationManament/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .Include(k => k.AccountidaccountNavigation)
                .FirstOrDefaultAsync(m => m.Idkh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: PersonalInformationManament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhang.FindAsync(id);
            _context.Khachhang.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhang.Any(e => e.Idkh == id);
        }
    }
}
