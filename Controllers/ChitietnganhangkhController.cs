using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;

namespace QuanLySanXuat.Controllers
{
    [Authorize]
    public class ChitietnganhangkhController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public ChitietnganhangkhController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Chitietnganhangkh
        public IActionResult Index()
        {
            //var productionManagementSoftwareContext = _context.Chitietnganhangkh.Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);


            string customerEmail = Request.Cookies["HienCaCookie"];
            Khachhang KH = _context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
            //join 3 bảng
            TempData["Banks"] = _context.Ctnganhangkh.Where(idkh => idkh.Idkh == KH.Idkh).Where(active=>active.IdnhNavigation.Active==1)
                .Include(c => c.IdkhNavigation).Include(c => c.IdnhNavigation).ToList();
            ViewData["Fullname"] = KH.Tenkh;

            TempData["lockedBanks"] = _context.Ctnganhangkh.Where(idkh => idkh.Idkh == KH.Idkh).Where(active => active.IdnhNavigation.Active == 0)
                .Include(c => c.IdkhNavigation).Include(c => c.IdnhNavigation).ToList();

            //return View(BankDetails);

            return View();
        }

        // GET: Chitietnganhangkh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnganhangkh = await _context.Ctnganhangkh
                .Include(c => c.IdkhNavigation)
                .Include(c => c.IdnhNavigation)
                .FirstOrDefaultAsync(m => m.Idctnhkh == id);
            if (chitietnganhangkh == null)
            {
                return NotFound();
            }

            return View(chitietnganhangkh);
        }

        // GET: Chitietnganhangkh/Create
        public IActionResult Create()
        {
            ViewData["Khachhangidkh"] = new SelectList(_context.Khachhang, "Idkh", "Diachi");
            ViewData["Nganhangidnh"] = new SelectList(_context.Nganhang, "Idnh", "Idnh");
            return View();
        }

        // POST: Chitietnganhangkh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Ctnganhangkh chitietnganhangkh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietnganhangkh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(chitietnganhangkh);
        }

        // GET: Chitietnganhangkh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var chitietnganhangkh = await _context.Chitietnganhangkh.FindAsync(id);
            var chitietnganhangkh = await _context.Ctnganhangkh
                .Include(c => c.IdkhNavigation)
                .Include(c => c.IdnhNavigation)
                .FirstOrDefaultAsync(m => m.Idctnhkh == id);
            string action = HttpContext.Request.Query["action"].ToString();
            //ViewData["unlock"] = "";
            //ViewData["lock"] = "";
            //if (action.Equals("lock"))
            //{
            //    ViewData["unlock"] = "hidden";
            //}
            //else
            //{
            //    ViewData["lock"] = "hidden";

            //}
            if (chitietnganhangkh == null)
            {
                return NotFound();
            }
            //ViewData["Khachhangidkh"] = new SelectList(_context.Khachhang, "Idkh", "Diachi", chitietnganhangkh.Khachhangidkh);
            //ViewData["Nganhangidnh"] = new SelectList(_context.Nganhang, "Idnh", "Idnh", chitietnganhangkh.Nganhangidnh);


            //return View(chitietnganhangkh);
            return View(chitietnganhangkh);



        }

        // POST: Chitietnganhangkh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string action, string tenng,string Ghichu,  Ctnganhangkh chitietnganhangkh)
        {
            if (id != chitietnganhangkh.Idctnhkh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //string customerEmail = Request.Cookies["HienCaCookie"];
                    //Khachhang KH = _context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
                    Nganhang nganhang = _context.Nganhang.Where(idng => idng.Idnh == chitietnganhangkh.Idnh).FirstOrDefault();
                    nganhang.Tennh = tenng;
                    nganhang.Ghichu = Ghichu;
                    if (action.Equals("lock"))
                    {
                        nganhang.Active = 0;
                    }
                    else
                    {
                        nganhang.Active = 1;
                    }
                    
                    //    var BankDetails = _context.Chitietnganhangkh.Where(idkh => idkh.Khachhangidkh == KH.Idkh)
                    //.Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);



                    _context.Update(chitietnganhangkh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietnganhangkhExists(chitietnganhangkh.Idctnhkh))
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
            //ViewData["Khachhangidkh"] = new SelectList(_context.Khachhang, "Idkh", "Diachi", chitietnganhangkh.Khachhangidkh);
            //ViewData["Nganhangidnh"] = new SelectList(_context.Nganhang, "Idnh", "Idnh", chitietnganhangkh.Nganhangidnh);
            return View(chitietnganhangkh);
        }


        //public async Task<IActionResult> Unlcok(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    //var chitietnganhangkh = await _context.Chitietnganhangkh.FindAsync(id);
        //    var chitietnganhangkh = await _context.Chitietnganhangkh
        //        .Include(c => c.KhachhangidkhNavigation)
        //        .Include(c => c.NganhangidnhNavigation)
        //        .FirstOrDefaultAsync(m => m.Idctnhkh == id);

        //    if (chitietnganhangkh == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Khachhangidkh"] = new SelectList(_context.Khachhang, "Idkh", "Diachi", chitietnganhangkh.Khachhangidkh);
        //    ViewData["Nganhangidnh"] = new SelectList(_context.Nganhang, "Idnh", "Idnh", chitietnganhangkh.Nganhangidnh);


        //    //return View(chitietnganhangkh);
        //    return View(chitietnganhangkh);



        //}

        //// POST: Chitietnganhangkh/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Unlock(int id, string tenng, [Bind("Idctnhkh,Stk,Nganhangidnh,Khachhangidkh")] Chitietnganhangkh chitietnganhangkh)
        //{
        //    if (id != chitietnganhangkh.Idctnhkh)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //string customerEmail = Request.Cookies["HienCaCookie"];
        //            //Khachhang KH = _context.Khachhang.Where(kh => kh.Email.Equals(customerEmail)).FirstOrDefault();
        //            Nganhang nganhang = _context.Nganhang.Where(idng => idng.Idnh == chitietnganhangkh.Nganhangidnh).FirstOrDefault();
        //            nganhang.Active = 1;
        //            //    var BankDetails = _context.Chitietnganhangkh.Where(idkh => idkh.Khachhangidkh == KH.Idkh)
        //            //.Include(c => c.KhachhangidkhNavigation).Include(c => c.NganhangidnhNavigation);



        //            _context.Update(chitietnganhangkh);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ChitietnganhangkhExists(chitietnganhangkh.Idctnhkh))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Khachhangidkh"] = new SelectList(_context.Khachhang, "Idkh", "Diachi", chitietnganhangkh.Khachhangidkh);
        //    ViewData["Nganhangidnh"] = new SelectList(_context.Nganhang, "Idnh", "Idnh", chitietnganhangkh.Nganhangidnh);
        //    return View(chitietnganhangkh);
        //}

        // GET: Chitietnganhangkh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnganhangkh = await _context.Ctnganhangkh
                .Include(c => c.IdkhNavigation)
                .Include(c => c.IdnhNavigation)
                .FirstOrDefaultAsync(m => m.Idctnhkh == id);
            if (chitietnganhangkh == null)
            {
                return NotFound();
            }

            return View(chitietnganhangkh);
        }

        // POST: Chitietnganhangkh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitietnganhangkh = await _context.Ctnganhangkh.FindAsync(id);
            _context.Ctnganhangkh.Remove(chitietnganhangkh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietnganhangkhExists(int id)
        {
            return _context.Ctnganhangkh.Any(e => e.Idctnhkh == id);
        }
    }
}
