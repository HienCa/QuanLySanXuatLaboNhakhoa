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
            return View(await _context.Nhacungcap.Where(n=>n.Active==1).ToListAsync());
        }

        // GET: Nhacungcaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
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
        public async Task<IActionResult> Create([Bind("Idncc,Mancc,Tenncc,Diachi,Sdt,Email,Masothue,Ghichu,Active")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                nhacungcap.Active = 1;
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("AddInterface", "Vatlieu");

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

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Idncc,Mancc,Tenncc,Diachi,Sdt,Email,Masothue,Ghichu,Active")] Nhacungcap nhacungcap)
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
                return RedirectToAction("AddInterface", "VatLieu");
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

            var nhacungcap = await _context.Nhacungcap
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
            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            nhacungcap.Active = 0;
            _context.Nhacungcap.Update(nhacungcap);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddInterface","Vatlieu");
        }

        private bool NhacungcapExists(int id)
        {
            return _context.Nhacungcap.Any(e => e.Idncc == id);
        }
    }
}
