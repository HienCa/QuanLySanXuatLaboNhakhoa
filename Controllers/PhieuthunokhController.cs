using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;

namespace QuanLySanXuat.Controllers
{
    public class PhieuthunokhController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PhieuthunokhController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Phieuthunokh.Where(n => n.Active == 1).Include(ht => ht.IdhtttNavigation).ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var ptn = await _context.Phieuthunokh
                .FirstOrDefaultAsync(m => m.Idptnkh == id);
            if (ptn == null)
            {
                return NotFound();
            }

            return View(ptn);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Idpbh, Phieuthunokh ptn, string SoPhieuBH)
        {

            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();
                var Idnv = 2;
                if (nhanvien == null)
                {
                    Idnv = 2;
                }
                else
                {
                    Idnv = nhanvien.Idnv;
                }
                ptn.Sophieu = SoPhieuBH + Idpbh + Idnv;
                ptn.Idnv = Idnv;
                ptn.Ngaylap = DateTime.Now;
                ptn.Active = 1;
                _context.Add(ptn);

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieutranoncc");

            }
            catch
            {
                return RedirectToAction("Index", "Phieutranoncc");
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int Idptnncc, Phieutranoncc ptn, string action)
        {

            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();
                var Idnv = 2;
                if (nhanvien == null)
                {
                    Idnv = 2;
                }
                else
                {
                    Idnv = nhanvien.Idnv;
                }

                if (action.Equals("addItem"))
                {
                    ptn.Idptnncc = 0;
                    ptn.Idnv = Idnv;
                    ptn.Ngaylap = DateTime.Now;
                    ptn.Active = 1;
                    _context.Add(ptn);

                }
                if (action.Equals("editItem"))
                {
                    ptn.Idnv = Idnv;
                    ptn.Ngaylap = DateTime.Now;
                    ptn.Idptnncc = Idptnncc;
                    ptn.Active = 1;
                    _context.Update(ptn);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Phieutranoncc");

            }
            catch
            {
                return RedirectToAction("Index", "Phieutranoncc");
            }


        }




        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ptn = await _context.Phieutranoncc
                .FirstOrDefaultAsync(m => m.Idptnncc == id);

            if (ptn == null)
            {
                return NotFound();
            }
            return View(ptn);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phieutranoncc ptn)
        {
            if (id != ptn.Idptnncc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ptn.Active = 1;
                    _context.Update(ptn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieutranonccExists(ptn.Idptnncc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Create", "Phieutranoncc");

            }
            return View(ptn);
        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var ptn = _context.Phieutranoncc.Where(m => m.Idptnncc == id).FirstOrDefault();

                _context.Phieutranoncc.Remove(ptn);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }



        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ptn = await _context.Phieutranoncc.FindAsync(id);
            ptn.Active = 0;
            _context.Phieutranoncc.Update(ptn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Phieutranoncc");

        }

        private bool PhieutranonccExists(int id)
        {
            return _context.Phieutranoncc.Any(e => e.Idptnncc == id);
        }
    }
}
