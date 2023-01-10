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
    public class PhieunhapkhoController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PhieunhapkhoController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Phieunhapkho
        public async Task<IActionResult> Index()
        {
            var phieunhapkho = _context.Phieunhapkho.Where(p=>p.Active==1).Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation);

            return View(await phieunhapkho.ToListAsync());
        }

        // GET: Phieunhapkho/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var phieunhap = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            ViewBag.Idpnk = phieunhap.Idpnk;


            TempData["noidungphieunhap"]  = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == phieunhap.Idpnk)
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
        public async Task<IActionResult> Create( Phieunhapkho phieunhapkho)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();
                
                if (nhanvien == null)
                {
                    phieunhapkho.Idnv = 2;
                }
                else
                {
                    phieunhapkho.Idnv = nhanvien.Idnv;
                }
                phieunhapkho.Active = 1;

                _context.Add(phieunhapkho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Phieunhapkho");
            }
            ViewData["Nhanvienidnv"] = new SelectList(_context.Nhanvien, "Idnv", "Idnv", phieunhapkho.Idnv);
            return RedirectToAction("Index", "Phieunhapkho");

        }

        public async Task<IActionResult> EditPN(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }

            return View(phieunhapkho);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }

            return View(phieunhapkho);
        }
        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phieunhapkho phieunhapkho)
        {
            if (id != phieunhapkho.Idpnk)
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
                        phieunhapkho.Idnv = 2;
                    }
                    else
                    {
                        phieunhapkho.Idnv = nhanvien.Idnv;
                    }
                    _context.Update(phieunhapkho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieunhapkhoExists(phieunhapkho.Idpnk))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Phieunhapkho");

            }
            return RedirectToAction("Index", "Phieunhapkho");

        }

        // GET: Phieunhapkho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var phieunhapkho = await _context.Phieunhapkho
            //    .Include(p => p.NhanvienidnvNavigation)
            //    .FirstOrDefaultAsync(m => m.Idpnk == id);

            Phieunhapkho phieunhap = _context.Phieunhapkho.Where(pn => pn.Idpnk == id).FirstOrDefault();
            ViewData["sophieu"] = phieunhap.Sophieu;
            ViewData["idpnk"] = phieunhap.Idpnk;
            List<Noidungpnk> noidungphieunhap = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == phieunhap.Idpnk)
                .ToListAsync();
            //if (phieunhapkho == null)
            //{
            //    return NotFound();
            //}

            return View(noidungphieunhap);
        }

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieunhapkho = await _context.Phieunhapkho.FindAsync(id);
            phieunhapkho.Active = 0;
            _context.Phieunhapkho.Update(phieunhapkho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Phieunhapkho");

        }

        private bool PhieunhapkhoExists(int id)
        {
            return _context.Phieunhapkho.Any(e => e.Idpnk == id);
        }
    }
}
