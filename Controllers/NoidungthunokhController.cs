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
    public class NoidungthunokhController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NoidungthunokhController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Noidungthunokh.Include(n => n.IdpbhNavigation).Include(n => n.IdptnkhNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Noidungthunokh Noidungthunokh = _context.Noidungthunokh.Where(pn => pn.Idpbh == id).FirstOrDefault();
            List<Noidungthunokh> nd = await _context.Noidungthunokh
                .Include(n => n.IdpbhNavigation)
                .Include(n => n.IdptnkhNavigation)
                .Where(pn => pn.Idpbh == id)
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
        public async Task<IActionResult> CreateOrEdit(Noidungthunokh Noidungthunokh, string action, int Idpbh, Phieuthunokh ptn, string SoPhieuBH)
        {
            try
            {
               
                
                Noidungthunokh.Ngaythuno = DateTime.Now;
                if (action.Equals("addItem"))
                {
                    _context.Add(Noidungthunokh);

                }
                if (action.Equals("editItem"))
                {
                    _context.Update(Noidungthunokh);

                }
                if (action.Equals("createPTNKH"))
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
                    ptn.Sophieu = SoPhieuBH + Idpbh;
                    ptn.Idnv = Idnv;
                    ptn.Ngaylap = DateTime.Now;
                    ptn.Active = 1;
                    _context.Phieuthunokh.Add(ptn);
                   
                    
                    await _context.SaveChangesAsync();
                    Phieuthunokh ptnkh = _context.Phieuthunokh.Where(nv => nv.Sophieu == ptn.Sophieu).FirstOrDefault();
                    TempData["Idptnkh"] = ptnkh.Idptnkh;
                    TempData["SophieuTNKH"] = ptn.Sophieu;
                    return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });
            }


            catch {
                return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });

            }

        }

        // GET: Noidungphieunhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var Noidungthunokh = await _context.Noidungthunokh
                .FirstOrDefaultAsync(m => m.Idndptnkh == id);


            if (Noidungthunokh == null)
            {
                return NotFound();
            }
           
            return View(Noidungthunokh);
        }

       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Noidungthunokh Noidungthunokh)
        {
            if (id != Noidungthunokh.Idndptnkh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Noidungthunokh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungthunokhExists(Noidungthunokh.Idndptnkh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });

            }

            return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });

        }

        public IActionResult Delete(int? id)
        {
           
            try
            {
                var Noidungthunokh = _context.Noidungthunokh.Where(m => m.Idndptnkh == id).FirstOrDefault();
               
                _context.Noidungthunokh.Remove(Noidungthunokh);
                 _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }
            


        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var Noidungthunokh = await _context.Noidungthunokh
               .FirstOrDefaultAsync(m => m.Idndptnkh == id);
            _context.Noidungthunokh.Remove(Noidungthunokh);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Phieubanhang", new { @id = Noidungthunokh.Idpbh });

        }

        private bool NoidungthunokhExists(int id)
        {
            return _context.Noidungthunokh.Any(e => e.Idndptnkh == id);
        }
    }
}
