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
    public class LoainhanvienController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public LoainhanvienController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Hangsanxuat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loainhanvien.Where(n => n.Active == 1).ToListAsync());
        }

        // GET: Hangsanxuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var loainhanvien = await _context.Loainhanvien
                .FirstOrDefaultAsync(m => m.Idlnv == id);
            if (loainhanvien == null)
            {
                return NotFound();
            }

            return View(loainhanvien);
        }

        // GET: Hangsanxuat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hangsanxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlnv,Malnv,Tenlnv,Ghichu,Active")] Loainhanvien loainhanvien)
        {
            if (ModelState.IsValid)
            {
                loainhanvien.Active = 1;
                _context.Add(loainhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Nhanvien");

            }
            return View(loainhanvien);
        }

        // GET: Hangsanxuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loainhanvien = await _context.Loainhanvien
                .FirstOrDefaultAsync(m => m.Idlnv == id);
            //var hangsanxuat = await _context.Hangsanxuat.FindAsync(id);
            if (loainhanvien == null)
            {
                return NotFound();
            }
            return View(loainhanvien);
        }

        // POST: Hangsanxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlnv,Malnv,Tenlnv,Ghichu,Active")] Loainhanvien loainhanvien)
        {
            if (id != loainhanvien.Idlnv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    loainhanvien.Active = 1;
                    _context.Update(loainhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoainhanvienExists(loainhanvien.Idlnv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Create", "Nhanvien");

            }
            return View(loainhanvien);
        }

        // GET: Hangsanxuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loainhanvien = await _context.Loainhanvien
                .FirstOrDefaultAsync(m => m.Idlnv == id);
            if (loainhanvien == null)
            {
                return NotFound();
            }

            return View(loainhanvien);
        }

        // POST: Hangsanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loainhanvien = await _context.Loainhanvien.FindAsync(id);
            loainhanvien.Active = 0;
            _context.Loainhanvien.Update(loainhanvien);
            await _context.SaveChangesAsync();
              return RedirectToAction("Create", "Nhanvien");

        }

        private bool LoainhanvienExists(int id)
        {
            return _context.Loainhanvien.Any(e => e.Idlnv == id);
        }
    }
}
