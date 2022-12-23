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
    public class TosanxuatController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public TosanxuatController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Tosanxuat
        public async Task<IActionResult> Index()
        {
            var productionManagementSoftwareContext = _context.Tosanxuat.Include(t => t.IdgdsxNavigation);
            return View(await productionManagementSoftwareContext.ToListAsync());
        }

        // GET: Tosanxuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tosanxuat = await _context.Tosanxuat
                .Include(t => t.IdgdsxNavigation)
                .FirstOrDefaultAsync(m => m.Idtsx == id);
            if (tosanxuat == null)
            {
                return NotFound();
            }

            return View(tosanxuat);
        }

        // GET: Tosanxuat/Create
        public IActionResult Create()
        {
            ViewData["Giaidoansanxuatidgdsx"] = new SelectList(_context.Giaidoansx, "Idgdsx", "Idgdsx");
            return View();
        }

        // POST: Tosanxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtsx,Matsx,Tentsx,Ghichu,Active,Giaidoansanxuatidgdsx")] Tosanxuat tosanxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tosanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Giaidoansanxuatidgdsx"] = new SelectList(_context.Giaidoansx, "Idgdsx", "Idgdsx", tosanxuat.Giaidoansx);
            return View(tosanxuat);
        }

        // GET: Tosanxuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tosanxuat = await _context.Tosanxuat.FindAsync(id);
            if (tosanxuat == null)
            {
                return NotFound();
            }
            //ViewData["Giaidoansanxuatidgdsx"] = new SelectList(_context.Giaidoansanxuat, "Idgdsx", "Idgdsx", tosanxuat.Giaidoansanxuatidgdsx);
            return View(tosanxuat);
        }

        // POST: Tosanxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtsx,Matsx,Tentsx,Ghichu,Active,Giaidoansanxuatidgdsx")] Tosanxuat tosanxuat)
        {
            if (id != tosanxuat.Idtsx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tosanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TosanxuatExists(tosanxuat.Idtsx))
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
            //ViewData["Giaidoansanxuatidgdsx"] = new SelectList(_context.Giaidoansanxuat, "Idgdsx", "Idgdsx", tosanxuat.Giaidoansanxuatidgdsx);
            return View(tosanxuat);
        }

        // GET: Tosanxuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tosanxuat = await _context.Tosanxuat
                .Include(t => t.IdgdsxNavigation)
                .FirstOrDefaultAsync(m => m.Idtsx == id);
            if (tosanxuat == null)
            {
                return NotFound();
            }

            return View(tosanxuat);
        }

        // POST: Tosanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tosanxuat = await _context.Tosanxuat.FindAsync(id);
            _context.Tosanxuat.Remove(tosanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TosanxuatExists(int id)
        {
            return _context.Tosanxuat.Any(e => e.Idtsx == id);
        }
    }
}
