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
            var productionManagementSoftwareContext = _context.Vatlieu.Include(v => v.HangsanxuatidhsxNavigation).Include(v => v.NhomvatlieuidnvlNavigation);
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
                .Include(v => v.HangsanxuatidhsxNavigation)
                .Include(v => v.NhomvatlieuidnvlNavigation)
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
            ViewData["Hangsanxuatidhsx"] = new SelectList(_context.Hangsanxuat, "Idhsx", "Idhsx");
            ViewData["Nhomvatlieuidnvl"] = new SelectList(_context.Nhomvatlieu, "Idnvl", "Idnvl");
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhomvatlieu, "Idncc", "Idncc");


            return View();
        }

        // POST: Vatlieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvl,Mavl,Tenvl,Donvitinh,Quycach,Giaban,Active,Nhomvatlieuidnvl,Hangsanxuatidhsx,Nhacungcapidncc")] Vatlieu vatlieu)
        {
            if (ModelState.IsValid)
            {
                vatlieu.Active = 1;
                _context.Add(vatlieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hangsanxuatidhsx"] = new SelectList(_context.Hangsanxuat, "Idhsx", "Idhsx", vatlieu.Hangsanxuatidhsx);
            ViewData["Nhomvatlieuidnvl"] = new SelectList(_context.Nhomvatlieu, "Idnvl", "Idnvl", vatlieu.Nhomvatlieuidnvl);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhomvatlieu, "Idncc", "Idncc", vatlieu.Nhacungcapidncc);

            return View(vatlieu);
        }

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
            ViewData["Hangsanxuatidhsx"] = new SelectList(_context.Hangsanxuat, "Idhsx", "Idhsx", vatlieu.Hangsanxuatidhsx);
            ViewData["Nhomvatlieuidnvl"] = new SelectList(_context.Nhomvatlieu, "Idnvl", "Idnvl", vatlieu.Nhomvatlieuidnvl);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhomvatlieu, "Idncc", "Idncc", vatlieu.Nhacungcapidncc);

            return View(vatlieu);
        }

        // POST: Vatlieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvl,Mavl,Tenvl,Donvitinh,Quycach,Giaban,Active,Nhomvatlieuidnvl,Hangsanxuatidhsx,Nhacungcapidncc")] Vatlieu vatlieu)
        {
            if (id != vatlieu.Idvl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["Hangsanxuatidhsx"] = new SelectList(_context.Hangsanxuat, "Idhsx", "Idhsx", vatlieu.Hangsanxuatidhsx);
            ViewData["Nhomvatlieuidnvl"] = new SelectList(_context.Nhomvatlieu, "Idnvl", "Idnvl", vatlieu.Nhomvatlieuidnvl);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhomvatlieu, "Idncc", "Idncc", vatlieu.Nhacungcapidncc);
            return View(vatlieu);
        }

        // GET: Vatlieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatlieu = await _context.Vatlieu
                .Include(v => v.HangsanxuatidhsxNavigation)
                .Include(v => v.NhomvatlieuidnvlNavigation)
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
