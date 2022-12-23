//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using QuanLySanXuat.Entities;

//namespace QuanLySanXuat.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly ProductionManagementSoftwareContext _context;

//        public AccountController(ProductionManagementSoftwareContext context)
//        {
//            _context = context;
//        }

//        // GET: Account
//        public async Task<IActionResult> Index()
//        {
//            var productionManagementSoftwareContext = _context.Account.Include(a => a.VaitroidvtNavigation);
//            return View(await productionManagementSoftwareContext.ToListAsync());
//        }

//        // GET: Account/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Account
//                .Include(a => a.VaitroidvtNavigation)
//                .FirstOrDefaultAsync(m => m.Idaccount == id);
//            if (account == null)
//            {
//                return NotFound();
//            }

//            return View(account);
//        }

//        // GET: Account/Create
//        public IActionResult Create()
//        {
//            ViewData["Vaitroidvt"] = new SelectList(_context.Vaitro, "Idvt", "Idvt");
//            return View();
//        }

//        // POST: Account/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Idaccount,Tk,Mk,Active,Vaitroidvt")] Account account)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(account);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Vaitroidvt"] = new SelectList(_context.Vaitro, "Idvt", "Idvt", account.Vaitroidvt);
//            return View(account);
//        }

//        // GET: Account/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Account.FindAsync(id);
//            if (account == null)
//            {
//                return NotFound();
//            }
//            ViewData["Vaitroidvt"] = new SelectList(_context.Vaitro, "Idvt", "Idvt", account.Vaitroidvt);
//            return View(account);
//        }

//        // POST: Account/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Idaccount,Tk,Mk,Active,Vaitroidvt")] Account account)
//        {
//            if (id != account.Idaccount)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(account);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AccountExists(account.Idaccount))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Vaitroidvt"] = new SelectList(_context.Vaitro, "Idvt", "Idvt", account.Vaitroidvt);
//            return View(account);
//        }

//        // GET: Account/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var account = await _context.Account
//                .Include(a => a.VaitroidvtNavigation)
//                .FirstOrDefaultAsync(m => m.Idaccount == id);
//            if (account == null)
//            {
//                return NotFound();
//            }

//            return View(account);
//        }

//        // POST: Account/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var account = await _context.Account.FindAsync(id);
//            _context.Account.Remove(account);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AccountExists(int id)
//        {
//            return _context.Account.Any(e => e.Idaccount == id);
//        }
//    }
//}
