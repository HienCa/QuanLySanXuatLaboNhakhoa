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
    public class VatlieuController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public VatlieuController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Vatlieu
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Vatlieu.Include(v => v.IdhsxNavigation).Include(v => v.IdnvlNavigation).Include(v => v.IdnsxNavigation);
            return View(await productionManagementSoftwareContext.Where(vl=>vl.Active==1).ToListAsync());
        }

        public IActionResult AddInterface()
        {
            //TempData["nhomvatlieu"] = _context.Nhomvatlieu.Where(n=>n.Active== 1).ToList();
            //TempData["nhacungcap"] = _context.Nhacungcap.Where(n => n.Active == 1).ToList();
            //TempData["hangsanxuat"] = _context.Hangsanxuat.Where(n => n.Active == 1).ToList();
            return View();
        }

        // GET: Vatlieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatlieu = await _context.Vatlieu
                .Include(v => v.IdhsxNavigation)
                .Include(v => v.IdnvlNavigation)
                .Include(v => v.IdnsxNavigation)
                .FirstOrDefaultAsync(m => m.Idvl == id);
            if (vatlieu == null)
            {
                return NotFound();
            }

            return View(vatlieu);
        }

        // GET: Vatlieu/Create
        public IActionResult Create()
        {
        


            return View();
        }

        ////POST: Vatlieu/Create
        ////To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Vatlieu vatlieu)
        {
            if (ModelState.IsValid)
            {
                if(vatlieu.Tenvl != null || vatlieu.Quycach != null || vatlieu.Giaban <= 0 || vatlieu.Idhsx <= 0 || vatlieu.Idnsx <= 0 || vatlieu.Idnvl <= 0)
                {
                    _context.Vatlieu.Add(vatlieu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }

            return View("AddInterface", "Vatlieu");
        }

        //public async Task<IActionResult> Createe(int nhomvl, int nuosx, int hangsx, Vatlieu vatlieu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        vatlieu.Idnvl = nhomvl;
        //        vatlieu.Idhsx = hangsx;
        //        vatlieu.Idnsx = nuosx;
        //        vatlieu.Active = 1;
        //        _context.Vatlieu.Add(vatlieu);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View("AddInterface", "Vatlieu");
        //}

        // GET: Vatlieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatlieu = await _context.Vatlieu.FindAsync(id);
            if (vatlieu == null)
            {
                return NotFound();
            }
           

            return View(vatlieu);
        }

        // POST: Vatlieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvl,Mavl,Tenvl,Quycach,Giaban,Active,Idnvl,Idhsx")] Vatlieu vatlieu)
        {
            if (id != vatlieu.Idvl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vatlieu.Active = 1;
                    _context.Update(vatlieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VatlieuExists(vatlieu.Idvl))
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

            return View("Edit", "Vatlieu");
        }

        // GET: Vatlieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatlieu = await _context.Vatlieu
                .Include(v => v.IdhsxNavigation)
                .Include(v => v.IdnvlNavigation)
                .Include(v => v.IdnsxNavigation)

                .FirstOrDefaultAsync(m => m.Idvl == id);
            if (vatlieu == null)
            {
                return NotFound();
            }

            return View(vatlieu);
        }

        // POST: Vatlieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vatlieu = await _context.Vatlieu.FindAsync(id);
            vatlieu.Active = 0;
            _context.Vatlieu.Update(vatlieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VatlieuExists(int id)
        {
            return _context.Vatlieu.Any(e => e.Idvl == id);
        }
    }
}
