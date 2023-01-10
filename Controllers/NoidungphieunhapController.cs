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
            var productionManagementSoftwareContext = _context.Noidungpnk.Include(n => n.IdpnkNavigation).Include(n => n.IdvlNavigation);
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
            List<Noidungpnk> nd = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == phieunhap.Idpnk)
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
        public async Task<IActionResult> Create(Noidungpnk noidungphieunhap)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(email => email.Email.Equals(employeeEmail)).FirstOrDefault();
           
 
                _context.Add(noidungphieunhap);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Phieunhapkho", new { @id = noidungphieunhap.Idpnk });
            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = noidungphieunhap.Idpnk });
        }

        // GET: Noidungphieunhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var noidungphieunhap = await _context.Noidungpnk
                .FirstOrDefaultAsync(m => m.Idndpnk == id);


            if (noidungphieunhap == null)
            {
                return NotFound();
            }
           
            return View(noidungphieunhap);
        }

        // POST: Noidungphieunhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Noidungpnk noidungphieunhap)
        {
            if (id != noidungphieunhap.Idndpnk)
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
                    if (!NoidungphieunhapExists(noidungphieunhap.Idndpnk))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Phieunhapkho", new { @id = noidungphieunhap.Idpnk });

            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = noidungphieunhap.Idpnk });

        }

        // GET: Noidungphieunhap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungphieunhap = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation)
                .Include(n => n.IdvlNavigation)
                .FirstOrDefaultAsync(m => m.Idndpnk == id);
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
            var noidungphieunhap = await _context.Noidungpnk.FindAsync(id);
            _context.Noidungpnk.Remove(noidungphieunhap);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Phieunhapkho", new { @id = noidungphieunhap.Idpnk });

        }

        private bool NoidungphieunhapExists(int id)
        {
            return _context.Noidungpnk.Any(e => e.Idndpnk == id);
        }
    }
}
