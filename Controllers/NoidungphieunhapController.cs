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
    public class NoidungphieunhapController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NoidungphieunhapController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Noidungphieunhap
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Noidungphieunhap.Include(n => n.PhieunhapkhoidpnkNavigation).Include(n => n.VatlieuidvlNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }

        // GET: Noidungphieunhap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Phieunhapkho phieunhap = _context.Phieunhapkho.Where(pn => pn.Idpnk == id).FirstOrDefault();
            List<Noidungphieunhap> nd = await _context.Noidungphieunhap
                .Include(n => n.PhieunhapkhoidpnkNavigation)
                .Include(n => n.VatlieuidvlNavigation)
                .Where(pn => pn.Phieunhapkhoidpnk == phieunhap.Idpnk)
                .ToListAsync();
            //if (noidungphieunhap == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: Noidungphieunhap/Create
        public IActionResult Create()
        {
            ViewData["Phieunhapkhoidpnk"] = new SelectList(_context.Phieunhapkho, "Idpnk", "Idpnk");
            ViewData["Vatlieuidvl"] = new SelectList(_context.Vatlieu, "Idvl", "Idvl");
            return View();
        }

        // POST: Noidungphieunhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Idpn, int Idvl, [Bind("Idpnk,Soluong,Dongia,Vatlieuidvl,Phieunhapkhoidpnk")] Noidungphieunhap noidungphieunhap, Phieunhapkho phieunhapkho)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(email => email.Email.Equals(employeeEmail)).FirstOrDefault();

                noidungphieunhap.Vatlieuidvl = Idvl;
                Phieunhapkho pnk = _context.Phieunhapkho.Where(pn => pn.Idpnk == Idpn).FirstOrDefault();
                pnk.Sohd = phieunhapkho.Sohd;
                pnk.Ghichu = phieunhapkho.Ghichu;
                pnk.Ngayhd = phieunhapkho.Ngayhd;

                noidungphieunhap.Phieunhapkhoidpnk = pnk.Idpnk;


                _context.Add(noidungphieunhap);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditPN",pnk.Idpnk);
            }
            ViewData["Phieunhapkhoidpnk"] = new SelectList(_context.Phieunhapkho, "Idpnk", "Idpnk", noidungphieunhap.Phieunhapkhoidpnk);
            ViewData["Vatlieuidvl"] = new SelectList(_context.Vatlieu, "Idvl", "Idvl", noidungphieunhap.Vatlieuidvl);
            return View(noidungphieunhap);
        }

        // GET: Noidungphieunhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungphieunhap = await _context.Noidungphieunhap.FindAsync(id);
            if (noidungphieunhap == null)
            {
                return NotFound();
            }
            ViewData["Phieunhapkhoidpnk"] = new SelectList(_context.Phieunhapkho, "Idpnk", "Idpnk", noidungphieunhap.Phieunhapkhoidpnk);
            ViewData["Vatlieuidvl"] = new SelectList(_context.Vatlieu, "Idvl", "Idvl", noidungphieunhap.Vatlieuidvl);
            return View(noidungphieunhap);
        }

        // POST: Noidungphieunhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpnk,Soluong,Dongia,Vatlieuidvl,Phieunhapkhoidpnk")] Noidungphieunhap noidungphieunhap)
        {
            if (id != noidungphieunhap.Idpnk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noidungphieunhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungphieunhapExists(noidungphieunhap.Idpnk))
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
            ViewData["Phieunhapkhoidpnk"] = new SelectList(_context.Phieunhapkho, "Idpnk", "Idpnk", noidungphieunhap.Phieunhapkhoidpnk);
            ViewData["Vatlieuidvl"] = new SelectList(_context.Vatlieu, "Idvl", "Idvl", noidungphieunhap.Vatlieuidvl);
            return View(noidungphieunhap);
        }

        // GET: Noidungphieunhap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungphieunhap = await _context.Noidungphieunhap
                .Include(n => n.PhieunhapkhoidpnkNavigation)
                .Include(n => n.VatlieuidvlNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (noidungphieunhap == null)
            {
                return NotFound();
            }

            return View(noidungphieunhap);
        }

        // POST: Noidungphieunhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noidungphieunhap = await _context.Noidungphieunhap.FindAsync(id);
            _context.Noidungphieunhap.Remove(noidungphieunhap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoidungphieunhapExists(int id)
        {
            return _context.Noidungphieunhap.Any(e => e.Idpnk == id);
        }
    }
}
