﻿using System;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Tosanxuat tsx, string action)
        {
            try
            {
                
                if (action.Equals("addItem"))
                {

                    tsx.Idtsx = 0;
                    _context.Add(tsx);

                }
                if (action.Equals("editItem"))
                {
                    tsx.Active = 1;
                    _context.Update(tsx);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }
        // GET: Tosanxuat/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Tosanxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tosanxuat tosanxuat)
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
        public async Task<IActionResult> Edit(int id,  Tosanxuat tosanxuat)
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
 
            return View(tosanxuat);
        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var tsx = _context.Tosanxuat.Where(m => m.Idtsx == id).FirstOrDefault();
                tsx.Active = 0;
                _context.Tosanxuat.Update(tsx);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }



        }
        // GET: Tosanxuat/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tosanxuat = await _context.Tosanxuat
        //        .Include(t => t.IdgdsxNavigation)
        //        .FirstOrDefaultAsync(m => m.Idtsx == id);
        //    if (tosanxuat == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tosanxuat);
        //}

        // POST: Tosanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tosanxuat = await _context.Tosanxuat.FindAsync(id);
            tosanxuat.Active = 0;
            _context.Tosanxuat.Update(tosanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TosanxuatExists(int id)
        {
            return _context.Tosanxuat.Any(e => e.Idtsx == id);
        }
    }
}
