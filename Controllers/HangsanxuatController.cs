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
            return View(await _context.Hangsx.Where(n => n.Active==1).ToListAsync());
        }

        // GET: Hangsanxuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var hangsanxuat = await _context.Hangsx
                .FirstOrDefaultAsync(m => m.Idhsx == id);
            if (hangsanxuat == null)
            {
                return NotFound();
            }

            return View(hangsanxuat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Hangsx hangsx, string action)
        {
            try
            {
                if (action.Equals("addItem"))
                {
                    hangsx.Idhsx = 0;
                    _context.Add(hangsx);

                }
                if (action.Equals("editItem"))
                {
                    hangsx.Active = 1;
                    _context.Update(hangsx);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id==0)
            {
                return View(new Hangsx());


            }
            else
            {
                var hangsanxuat = await _context.Hangsx.FindAsync(id);
                if (hangsanxuat == null)
                {
                    return NotFound();
                }
                return View(hangsanxuat);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id,[Bind("Idhsx,Mahsx,Tenhsx,Active")] Hangsx hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    hangsanxuat.Active = 1;
                    _context.Add(hangsanxuat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");


                }
                else
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
                    //return Json(new { isValid = true, html = "" });
                    //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit",hangsanxuat) });
                    return RedirectToAction("Index");
                }
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
        public async Task<IActionResult> Create([Bind("Idhsx,Mahsx,Tenhsx,Active")] Hangsx hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                hangsanxuat.Active = 1;
                _context.Add(hangsanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");


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
            var hangsanxuat = await _context.Hangsx
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
        public async Task<IActionResult> Edit(int id, [Bind("Idhsx,Mahsx,Tenhsx,Active")] Hangsx hangsanxuat)
        {
            if (id != hangsanxuat.Idhsx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hangsanxuat.Active=1;
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
        public IActionResult Delete(int? id)
        {

            try
            {
                var h = _context.Hangsx.Where(m => m.Idhsx == id).FirstOrDefault();
                h.Active = 0;
                _context.Hangsx.Update(h);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }



        }
        // GET: Hangsanxuat/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hangsanxuat = await _context.Hangsx
        //        .FirstOrDefaultAsync(m => m.Idhsx == id);
        //    if (hangsanxuat == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hangsanxuat);
        //}

        // POST: Hangsanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangsanxuat = await _context.Hangsx.FindAsync(id);
            hangsanxuat.Active = 0;
            _context.Hangsx.Update(hangsanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        private bool HangsanxuatExists(int id)
        {
            return _context.Hangsx.Any(e => e.Idhsx == id);
        }
    }
}
