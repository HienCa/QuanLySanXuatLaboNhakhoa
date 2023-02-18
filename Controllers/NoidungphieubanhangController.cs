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
    public class NoidungphieubanhangController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NoidungphieubanhangController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Noidungphieunhap
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Noidungpbh.Include(n => n.IdpbhNavigation).Include(n => n.IdvlNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }

        // GET: Noidungphieunhap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Phieubanhang pbh = _context.Phieubanhang.Where(pn => pn.Idpbh == id).FirstOrDefault();
            List<Noidungpbh> nd = await _context.Noidungpbh
                .Include(n => n.IdpbhNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpbh == pbh.Idpbh)
                .ToListAsync();
           

            return View();
        }

      
        public IActionResult Create()
        {
           
            return View();
        }

       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Noidungpbh nd)
        {

            

            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(email => email.Email.Equals(employeeEmail)).FirstOrDefault();
           
 
                _context.Add(nd);
                await _context.SaveChangesAsync();
                return RedirectToAction("SearchProduct", "Phieubanhang", new { @id = nd.Idpbh });
            }

            return RedirectToAction("SearchProduct", "Phieubanhang", new { @id = nd.Idpbh });
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var noidungphieunhap = await _context.Noidungpbh
                .FirstOrDefaultAsync(m => m.Idndpbh == id);


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
        public async Task<IActionResult> Edit(int id, Noidungpbh nd)
        {
            if (id != nd.Idndpbh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungphieubanhangExists(nd.Idndpbh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Phieunhapkho", new { @id = nd.Idpbh });

            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = nd.Idpbh });

        }

        public IActionResult Delete(int? id)
        {
           
            try
            {
                var nd = _context.Noidungpbh.Where(m => m.Idndpbh == id).FirstOrDefault();
               
                _context.Noidungpbh.Remove(nd);
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
            //var noidungphieunhap = await _context.Noidungpnk.FindAsync(id);
            var nd = await _context.Noidungpbh
               .FirstOrDefaultAsync(m => m.Idndpbh == id);
            _context.Noidungpbh.Remove(nd);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Phieubanghang", new { @id = nd.Idpbh });

        }

        private bool NoidungphieubanhangExists(int id)
        {
            return _context.Noidungpbh.Any(e => e.Idndpbh == id);
        }
    }
}
