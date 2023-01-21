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
    public class PhieubanhangController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PhieubanhangController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Phieunhapkho
        public async Task<IActionResult> Index()
        {
            var phieunhapkho = _context.Phieubanhang.Where(p=>p.Active==1).Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation);

            return View(await phieunhapkho.ToListAsync());
        }

        // GET: Phieunhapkho/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var phieubanhang = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == id);
            ViewBag.Idpbh = phieubanhang.Idpbh;


            TempData["Noidungphieubanhang"]  = await _context.Noidungpbh
                .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpbh == phieubanhang.Idpbh)
                .ToListAsync();


            return View();
        }

        // GET: Phieunhapkho/Create
        public IActionResult Create()
        {
            ViewData["Nhanvienidnv"] = new SelectList(_context.Nhanvien, "Idnv", "Idnv");
            return View();
        }

        // POST: Phieunhapkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieubanhang phieubanhang)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();
                
                if (nhanvien == null)
                {
                    phieubanhang.Idnv = 2;
                }
                else
                {
                    phieubanhang.Idnv = nhanvien.Idnv;
                }
                DateTime dateNow = DateTime.Now;
                phieubanhang.Ngaylap = dateNow;
                phieubanhang.Active = 1;

                _context.Add(phieubanhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Nhanvienidnv"] = new SelectList(_context.Nhanvien, "Idnv", "Idnv", phieubanhang.Idnv);
            return RedirectToAction(nameof(Index));


        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieubanhang = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == id);
            if (phieubanhang == null)
            {
                return NotFound();
            }

            return View(phieubanhang);
        }
        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phieubanhang phieubanhang)
        {
            if (id != phieubanhang.Idpbh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string employeeEmail = Request.Cookies["HienCaCookie"];
                    Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();
                   
                    if (nhanvien == null)
                    {
                        phieubanhang.Idnv = 2;
                    }
                    else
                    {
                        phieubanhang.Idnv = nhanvien.Idnv;
                    }
                    _context.Update(phieubanhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieubanhangExists(phieubanhang.Idpbh))
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
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var pbh = _context.Phieubanhang.Where(m => m.Idpbh == id).FirstOrDefault();

                _context.Phieubanhang.Remove(pbh);
                _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }



        }
        // GET: Phieunhapkho/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{



        //    Phieubanhang phieubanhang = _context.Phieubanhang.Where(pn => pn.Idpbh == id).FirstOrDefault();
        //    ViewData["sophieu"] = phieubanhang.Sophieu;
        //    ViewData["idpnk"] = phieubanhang.Idpbh;
        //    List<Noidungpbh> noidungphieubanhang = await _context.Noidungpbh
        //        .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
        //        .Include(n => n.IdvlNavigation)
        //        .Where(pbh=> pbh.Idpbh == phieubanhang.Idpbh)
        //        .ToListAsync();


        //    return View(noidungphieubanhang);
        //}

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieubanhang = await _context.Phieubanhang.FindAsync(id);
            phieubanhang.Active = 0;
            _context.Phieubanhang.Update(phieubanhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        private bool PhieubanhangExists(int id)
        {
            return _context.Phieubanhang.Any(e => e.Idpbh == id);
        }
    }
}
