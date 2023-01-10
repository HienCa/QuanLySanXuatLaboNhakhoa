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
    public class NuocsxController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NuocsxController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Nhomvatlieu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nuocsx.Where(n=>n.Active==1).ToListAsync());
        }

        // GET: Nhomvatlieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nsx = await _context.Nuocsx
                .FirstOrDefaultAsync(m => m.Idnsx == id);
            if (nsx == null)
            {
                return NotFound();
            }

            return View(nsx);
        }

        // GET: Nhomvatlieu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhomvatlieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnsx,Mansx,Tennsx,Active")] Nuocsx nuocsx)
        {
            if (ModelState.IsValid)
            {
                nuocsx.Active = 1;
                _context.Add(nuocsx);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nuocsx);
        }
        public IActionResult CreateOfVL()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOfVL([Bind("Idnsx,Mansx,Tennsx,Active")] Nuocsx nuocsx)
        {
            if (ModelState.IsValid)
            {
                nuocsx.Active = 1;
                _context.Add(nuocsx);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Vatlieu");


            }
            return RedirectToAction("Create", "Vatlieu");

        }

        // GET: Nhomvatlieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuocsx = await _context.Nuocsx.FindAsync(id);
            if (nuocsx == null)
            {
                return NotFound();
            }
            return View(nuocsx);
        }

        // POST: Nhomvatlieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnsx,Mansx,Tennsx,Active")] Nuocsx nuocsx)
        {
            if (id != nuocsx.Idnsx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nuocsx.Active = 1;

                    _context.Update(nuocsx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomvatlieuExists(nuocsx.Idnsx))
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
            return View(nuocsx);
        }

        // GET: Nhomvatlieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuocsx = await _context.Nuocsx
                .FirstOrDefaultAsync(m => m.Idnsx == id);
            if (nuocsx == null)
            {
                return NotFound();
            }

            return View(nuocsx);
        }

        // POST: Nhomvatlieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuocsx = await _context.Nuocsx.FindAsync(id);
            nuocsx.Active = 0;
            _context.Nuocsx.Update(nuocsx);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        private bool NhomvatlieuExists(int id)
        {
            return _context.Nuocsx.Any(e => e.Idnsx == id);
        }
    }
}
