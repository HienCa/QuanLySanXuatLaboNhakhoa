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
    public class NhomvatlieuController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NhomvatlieuController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Nhomvatlieu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhomvl.Where(n=>n.Active==1).ToListAsync());
        }

        // GET: Nhomvatlieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomvatlieu = await _context.Nhomvl
                .FirstOrDefaultAsync(m => m.Idnvl == id);
            if (nhomvatlieu == null)
            {
                return NotFound();
            }

            return View(nhomvatlieu);
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
        public async Task<IActionResult> Create([Bind("Idnvl,Manvl,Tennvl,Loainvl,Active")] Nhomvl nhomvatlieu)
        {
            if (ModelState.IsValid)
            {
                nhomvatlieu.Active = 1;
                _context.Add(nhomvatlieu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nhomvatlieu);
        }
        public IActionResult CreateOfVL()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOfVL([Bind("Idnvl,Manvl,Tennvl,Loainvl,Active")] Nhomvl nhomvatlieu)
        {
            if (ModelState.IsValid)
            {
                nhomvatlieu.Active = 1;
                _context.Add(nhomvatlieu);
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

            var nhomvatlieu = await _context.Nhomvl.FindAsync(id);
            if (nhomvatlieu == null)
            {
                return NotFound();
            }
            return View(nhomvatlieu);
        }

        // POST: Nhomvatlieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnvl,Manvl,Tennvl,Loainvl,Active")] Nhomvl nhomvatlieu)
        {
            if (id != nhomvatlieu.Idnvl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nhomvatlieu.Active = 1;

                    _context.Update(nhomvatlieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomvatlieuExists(nhomvatlieu.Idnvl))
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
            return View(nhomvatlieu);
        }

        // GET: Nhomvatlieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomvatlieu = await _context.Nhomvl
                .FirstOrDefaultAsync(m => m.Idnvl == id);
            if (nhomvatlieu == null)
            {
                return NotFound();
            }

            return View(nhomvatlieu);
        }

        // POST: Nhomvatlieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhomvatlieu = await _context.Nhomvl.FindAsync(id);
            nhomvatlieu.Active = 0;
            _context.Nhomvl.Update(nhomvatlieu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        private bool NhomvatlieuExists(int id)
        {
            return _context.Nhomvl.Any(e => e.Idnvl == id);
        }
    }
}
