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
    public class NganhangController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public NganhangController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Nganhang
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nganhang.Where(n=>n.Active==1).ToListAsync());
        }

        // GET: Nganhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nsx = await _context.Nganhang
                .FirstOrDefaultAsync(m => m.Idnh == id);
            if (nsx == null)
            {
                return NotFound();
            }

            return View(nsx);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Nganhang nh, string action)
        {
            try
            {
                nh.Idhttt = 1;
                if (action.Equals("addItem"))
                {
                    
                    nh.Idnh = 0;
                    _context.Add(nh);

                }
                if (action.Equals("editItem"))
                {
                    nh.Active = 1;
                    _context.Update(nh);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


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
        public async Task<IActionResult> Create(Nganhang nganhang)
        {
            if (ModelState.IsValid)
            {
                nganhang.Idhttt = 1;
                nganhang.Active = 1;
                _context.Add(nganhang);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nganhang);
        }
        public IActionResult CreateOfVL()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOfVL( Nganhang nganhang)
        {
            if (ModelState.IsValid)
            {
                nganhang.Active = 1;
                nganhang.Idhttt = 1;

                _context.Add(nganhang);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Nganhang");


            }
            return RedirectToAction("Index", "Nganhang");

        }

        // GET: Nganhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang.FindAsync(id);
            if (nganhang == null)
            {
                return NotFound();
            }
            return View(nganhang);
        }

        // POST: Nganhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Nganhang nganhang)
        {
            if (id != nganhang.Idnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nganhang.Active = 1;
                    nganhang.Idhttt = 1;

                    _context.Update(nganhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhangExists(nganhang.Idnh))
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
            return View(nganhang);
        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var nh = _context.Nganhang.Where(m => m.Idnh == id).FirstOrDefault();
                nh.Active = 0;
                _context.Nganhang.Update(nh);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }



        }
        // GET: Nganhang/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var nganhang = await _context.Nganhang
        //        .FirstOrDefaultAsync(m => m.Idnh == id);
        //    if (nganhang == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(nganhang);
        //}

        // POST: Nganhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nganhang = await _context.Nganhang.FindAsync(id);
            nganhang.Active = 0;
            _context.Nganhang.Update(nganhang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        private bool NganhangExists(int id)
        {
            return _context.Nganhang.Any(e => e.Idnh == id);
        }
    }
}
