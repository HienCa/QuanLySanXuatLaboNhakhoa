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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Phieunhapkho pnk, string action)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                if (nhanvien == null)
                {
                    pnk.Idnv = 2;
                }
                else
                {
                    pnk.Idnv = nhanvien.Idnv;
                }
                if (action.Equals("addItem"))
                {
                    pnk.Ngaylap = DateTime.Now;
                    pnk.Idpnk = 0;
                    _context.Add(pnk);

                }
                if (action.Equals("editItem"))
                {
                    pnk.Active = 1;
                    _context.Update(pnk);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            TempData["phieunhapkho"] = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            ViewBag.Idpnk = id;


            TempData["noidungphieunhap"] = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == id)
                .ToListAsync();

            TempData["noidungphieutranoncc"] = await _context.Noidungtranoncc
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdptnnccNavigation)
                .Where(pn => pn.Idpnk == id)
                .ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions( Noidungpnk noidungphieunhap, string action, int phieunhap)
        {
            
            try {
                
                
                if (action.Equals("addItem"))
                {
                    _context.Noidungpnk.Add(noidungphieunhap);
                    await _context.SaveChangesAsync();
                }
                if (action.Equals("editItem"))
                {
                    noidungphieunhap.Idndpnk = phieunhap;
                   
                  
                    _context.Noidungpnk.Update(noidungphieunhap);

                    await _context.SaveChangesAsync();
                }
                if (action.Equals("TaoPhieu"))
                {
                    Phieutranoncc phieutranoncc = new Phieutranoncc();
                    phieutranoncc.Sophieu = noidungphieunhap.IdpnkNavigation.Sophieu;
                    phieutranoncc.Ngaylap = DateTime.Now;
                    phieutranoncc.Idhttt = 1;
                    _context.Phieutranoncc.Add(phieutranoncc);
                    await _context.SaveChangesAsync();
                }
                //phieunhapkho.Active = 1;
                //phieunhapkho.Ngaylap = DateTime.Now;
                //_context.Add(phieunhapkho);
                //await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieunhapkho", new { id = noidungphieunhap.Idpnk });

            }
            catch(Exception e) {
                
            }
            TempData["phieunhapkho"] = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == noidungphieunhap.Idpnk);
                ViewBag.Idpnk = noidungphieunhap.Idpnk;



                TempData["noidungphieunhap"] = await _context.Noidungpnk
                    .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                    .Include(n => n.IdvlNavigation)
                    .Where(pn => pn.Idpnk == noidungphieunhap.Idpnk)
                    .ToListAsync();
            TempData["noidungphieutranoncc"] = await _context.Noidungtranoncc
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdptnnccNavigation)
                .Where(pn => pn.Idpnk == noidungphieunhap.Idpnk)
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
                phieunhapkho.Ngaylap = DateTime.Now;
                _context.Add(phieunhapkho);

                Phieutranoncc phieutranoncc = new Phieutranoncc();
                phieutranoncc.Idnv = phieunhapkho.Idnv;
                phieutranoncc.Ngaylap = DateTime.Now;
                phieutranoncc.Sophieu = phieunhapkho.Sophieu;
                phieutranoncc.Idhttt = 1;
                phieutranoncc.Active = 1;
                _context.Phieutranoncc.Add(phieutranoncc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Phieunhapkho");
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
                return RedirectToAction(nameof(Index));


            }
            return View(phieunhapkho);



        }

        // GET: Phieunhapkho/Delete/5
        public IActionResult Delete(int? id)
        {

            try
            {
                var phieunhapkho = _context.Phieunhapkho.Where(m => m.Idpnk == id).FirstOrDefault();
                phieunhapkho.Active = 0;
                _context.Phieunhapkho.Update(phieunhapkho);
                _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }



        }
        //public async Task<IActionResult> Delete(int? id)
        //{


        //    Phieunhapkho phieunhap = _context.Phieunhapkho.Where(pn => pn.Idpnk == id).FirstOrDefault();
        //    ViewData["sophieu"] = phieunhap.Sophieu;
        //    ViewData["idpnk"] = phieunhap.Idpnk;
        //    List<Noidungpnk> noidungphieunhap = await _context.Noidungpnk
        //        .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
        //        .Include(n => n.IdvlNavigation)
        //        .Where(pn => pn.Idpnk == phieunhap.Idpnk)
        //        .ToListAsync();


        //    return View(noidungphieunhap);
        //}

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieunhapkho = await _context.Phieunhapkho.FindAsync(id);
            phieunhapkho.Active = 0;
            _context.Phieunhapkho.Update(phieunhapkho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        private bool PhieunhapkhoExists(int id)
        {
            return _context.Phieunhapkho.Any(e => e.Idpnk == id);
        }
    }
}
