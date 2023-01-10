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
    public class NhacungcapsController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NhacungcapsController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Nhacungcaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhacungcapvl.Where(n=>n.Active==1).ToListAsync());
        }

        // GET: Nhacungcaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcapvl
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhacungcaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Nhacungcapvl nhacungcap)
        {
            if (ModelState.IsValid)
            {
                nhacungcap.Active = 1;
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");

            }
            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcapvl.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Nhacungcaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Nhacungcapvl nhacungcap)
        {
            if (id != nhacungcap.Idncc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nhacungcap.Active = 1;

                    _context.Update(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhacungcapExists(nhacungcap.Idncc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

            }
            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcapvl
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: Nhacungcaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhacungcap = await _context.Nhacungcapvl.FindAsync(id);
            nhacungcap.Active = 0;
            _context.Nhacungcapvl.Update(nhacungcap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        private bool NhacungcapExists(int id)
        {
            return _context.Nhacungcapvl.Any(e => e.Idncc == id);
        }
    }
}
