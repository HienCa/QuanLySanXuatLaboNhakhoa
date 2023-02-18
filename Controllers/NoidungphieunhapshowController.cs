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
    public class NoidungphieunhapshowController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NoidungphieunhapshowController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Noidungphieunhap
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Noidungpnkshow.Include(n => n.IdpnkNavigation).Include(n => n.IdvlNavigation);
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
            List<Noidungpnkshow> nd = await _context.Noidungpnkshow
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
        public async Task<IActionResult> Create(Noidungpnkshow Noidungpnkshow)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(email => email.Email.Equals(employeeEmail)).FirstOrDefault();
           
 
                _context.Add(Noidungpnkshow);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Phieunhapkho", new { @id = Noidungpnkshow.Idpnk });
            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungpnkshow.Idpnk });
        }

        // GET: Noidungphieunhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var Noidungpnkshow = await _context.Noidungpnkshow
                .FirstOrDefaultAsync(m => m.Idndpnk == id);


            if (Noidungpnkshow == null)
            {
                return NotFound();
            }
           
            return View(Noidungpnkshow);
        }

        // POST: Noidungphieunhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Noidungpnkshow Noidungpnkshow)
        {
            if (id != Noidungpnkshow.Idndpnk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Noidungpnkshow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungphieunhapExists(Noidungpnkshow.Idndpnk))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungpnkshow.Idpnk });

            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungpnkshow.Idpnk });

        }

        public IActionResult Delete(int? id)
        {
           
            try
            {
                var Noidungpnkshow = _context.Noidungpnkshow.Where(m => m.Idndpnk == id).FirstOrDefault();
               
                _context.Noidungpnkshow.Remove(Noidungpnkshow);
                 _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }
            


        }

        // POST: Noidungphieunhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var noidungphieunhap = await _context.Noidungpnkshow.FindAsync(id);
            var Noidungpnkshow = await _context.Noidungpnkshow
               .FirstOrDefaultAsync(m => m.Idndpnk == id);
            _context.Noidungpnkshow.Remove(Noidungpnkshow);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungpnkshow.Idpnk });

        }

        private bool NoidungphieunhapExists(int id)
        {
            return _context.Noidungpnkshow.Any(e => e.Idndpnk == id);
        }
    }
}
