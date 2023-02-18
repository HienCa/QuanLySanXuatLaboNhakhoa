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
    public class NoidungtranonccController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NoidungtranonccController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Noidungtranoncc.Include(n => n.IdpnkNavigation).Include(n => n.IdptnnccNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Noidungtranoncc Noidungtranoncc = _context.Noidungtranoncc.Where(pn => pn.Idpnk == id).FirstOrDefault();
            List<Noidungtranoncc> nd = await _context.Noidungtranoncc
                .Include(n => n.IdpnkNavigation)
                .Include(n => n.IdptnnccNavigation)
                .Where(pn => pn.Idpnk == id)
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
        public async Task<IActionResult> Create(Noidungtranoncc Noidungtranoncc, string action, int Idpnk, Phieutranoncc ptn, string SoPhieuNK)
        {
            try
            {
                Noidungtranoncc.Ngaytrano = DateTime.Now;
                if (action.Equals("addItem"))
                {
                    _context.Add(Noidungtranoncc);

                }
                if (action.Equals("editItem"))
                {
                    _context.Update(Noidungtranoncc);

                }
                if (action.Equals("createPTNNCC"))
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
                    ptn.Sophieu = SoPhieuNK + Idpnk;
                    ptn.Idnv = Idnv;
                    ptn.Ngaylap = DateTime.Now;
                    ptn.Active = 1;
                    _context.Phieutranoncc.Add(ptn);


                    await _context.SaveChangesAsync();
                    Phieutranoncc ptnncc = _context.Phieutranoncc.Where(nv => nv.Sophieu == ptn.Sophieu).FirstOrDefault();
                    TempData["Idptnncc"] = ptnncc.Idptnncc;
                    TempData["SophieuTNNCC"] = ptnncc.Sophieu;
                    return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });

                }
                if (action.Equals("finish"))
                {
                    Phieunhapkho pnk = _context.Phieunhapkho.Where(id => id.Idpnk == Noidungtranoncc.Idpnk).FirstOrDefault();
                    pnk.Active = 0;
                    _context.Phieunhapkho.Update(pnk);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Phieunhapkho");

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });
            }

            catch {
                return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });

            }

        }

        // GET: Noidungphieunhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var Noidungtranoncc = await _context.Noidungtranoncc
                .FirstOrDefaultAsync(m => m.Idndptnncc == id);


            if (Noidungtranoncc == null)
            {
                return NotFound();
            }
           
            return View(Noidungtranoncc);
        }

        // POST: Noidungphieunhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Noidungtranoncc Noidungtranoncc)
        {
            if (id != Noidungtranoncc.Idndptnncc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Noidungtranoncc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungtranonccExists(Noidungtranoncc.Idndptnncc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });

            }

            return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });

        }

        public IActionResult Delete(int? id)
        {
           
            try
            {
                var Noidungtranoncc = _context.Noidungtranoncc.Where(m => m.Idndptnncc == id).FirstOrDefault();
               
                _context.Noidungtranoncc.Remove(Noidungtranoncc);
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
            var Noidungtranoncc = await _context.Noidungtranoncc
               .FirstOrDefaultAsync(m => m.Idndptnncc == id);
            _context.Noidungtranoncc.Remove(Noidungtranoncc);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Phieunhapkho", new { @id = Noidungtranoncc.Idpnk });

        }

        private bool NoidungtranonccExists(int id)
        {
            return _context.Noidungtranoncc.Any(e => e.Idndptnncc == id);
        }
    }
}
