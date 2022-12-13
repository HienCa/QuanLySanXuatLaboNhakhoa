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
    public class HangsanxuatController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public HangsanxuatController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Hangsanxuat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hangsanxuat.Where(n => n.Active==1).ToListAsync());
        }

        // GET: Hangsanxuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var hangsanxuat = await _context.Hangsanxuat
                .FirstOrDefaultAsync(m => m.Idhsx == id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }

            return View(hangsanxuat);
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
        public async Task<IActionResult> Create([Bind("Idhsx,Mahsx,Tenhsx,Active")] Hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                hangsanxuat.Active = 1;
                _context.Add(hangsanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddInterface","Vatlieu");

            }
            return View(hangsanxuat);
        }

        // GET: Hangsanxuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hangsanxuat = await _context.Hangsanxuat
                .FirstOrDefaultAsync(m => m.Idhsx == id);
            //var hangsanxuat = await _context.Hangsanxuat.FindAsync(id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Hangsanxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idhsx,Mahsx,Tenhsx,Active")] Hangsanxuat hangsanxuat)
        {
            if (id != hangsanxuat.Idhsx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangsanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangsanxuatExists(hangsanxuat.Idhsx))
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
            return View(hangsanxuat);
        }

        // GET: Hangsanxuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangsanxuat = await _context.Hangsanxuat
                .FirstOrDefaultAsync(m => m.Idhsx == id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }

            return View(hangsanxuat);
        }

        // POST: Hangsanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangsanxuat = await _context.Hangsanxuat.FindAsync(id);
            hangsanxuat.Active = 0;
            _context.Hangsanxuat.Update(hangsanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangsanxuatExists(int id)
        {
            return _context.Hangsanxuat.Any(e => e.Idhsx == id);
        }
    }
}
