using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;

namespace QuanLySanXuat.Controllers
{
    [Authorize]
    public class PhieubanhangController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PhieubanhangController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Phieunhapkho
        public async Task<IActionResult> Index()
        {
            var phieunhapkho = _context.Phieubanhang.Where(p => p.Active == 1).Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation);

            return View(await phieunhapkho.ToListAsync());
        }
        public async Task<IActionResult> ShowReport(DateTime? from, DateTime? to, string action, int? Idvl)
        {
            List<Noidungpbh> Listndpbh;

            if (from != null && to != null)
            {
                Listndpbh = await _context.Noidungpbh.Where(d => d.IdpbhNavigation.Ngaylap >= from && d.IdpbhNavigation.Ngaylap <= to).Include(p => p.IdpbhNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpbhNavigation.IdkhNavigation).ToListAsync();
            }
            if (from != null && to != null && Idvl > 0)
            {
                Listndpbh = await _context.Noidungpbh.Where(d => d.IdpbhNavigation.Ngaylap >= from && d.IdpbhNavigation.Ngaylap <= to).Include(p => p.IdpbhNavigation).Where(d => d.Idvl == Idvl).Include(p => p.IdvlNavigation).Include(p => p.IdpbhNavigation.IdkhNavigation).ToListAsync();
            }
            if (from == null && to == null && Idvl > 0)
            {
                Listndpbh = await _context.Noidungpbh.Include(p => p.IdpbhNavigation).Where(d => d.Idvl == Idvl).Include(p => p.IdvlNavigation).Include(p => p.IdpbhNavigation.IdkhNavigation).ToListAsync();
            }
            else
            {
                Listndpbh = await _context.Noidungpbh.Include(p => p.IdpbhNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpbhNavigation.IdkhNavigation).ToListAsync();

            }
            if (action.Equals("export") && from == null && to == null || action.Equals("export"))
            {

                using (var workbook = new XLWorkbook())
                {
                    //tên sheet
                    var worksheet = workbook.Worksheets.Add("Phieubanhang");

                    //tiêu đề
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "CÔNG TY SẢN XUẤT HIENCA";
                    currentRow += 2;
                    string fromString="";
                    string toString="";
                    if (from != null && to != null)
                    {
                        DateTime From = (DateTime)from;
                        DateTime To = (DateTime)to;
                        fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 3).Value = "BẢNG KÊ PHIẾU BÁN HÀNG TỪ " + fromString + " ĐẾN " + toString;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 3).Value = "BẢNG KÊ PHIẾU BÁN HÀNG TỪ " + from + " ĐẾN " + to;

                    }

                    //danh sách phiếu
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Mã KH";
                    worksheet.Cell(currentRow, 2).Value = "Tên khách hàng";
                    worksheet.Cell(currentRow, 3).Value = "Ngày lập";
                    worksheet.Cell(currentRow, 4).Value = "Số phiếu";
                    worksheet.Cell(currentRow, 5).Value = "Tên hàng hóa";
                    worksheet.Cell(currentRow, 6).Value = "Số lượng";
                    worksheet.Cell(currentRow, 7).Value = "Đơn giá nhập(đ)";
                    worksheet.Cell(currentRow, 8).Value = "Thành tiền(đ)";

                    float tongSoLuong = 0;
                    float tongGiaNhap = 0;
                    float tongThanhTien = 0;

                    foreach (var pnk in Listndpbh)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = pnk.IdpbhNavigation.IdkhNavigation.Makh;
                        worksheet.Cell(currentRow, 2).Value = pnk.IdpbhNavigation.IdkhNavigation.Tenkh;
                        DateTime Ngaylap = (DateTime)pnk.IdpbhNavigation.Ngaylap;
                        worksheet.Cell(currentRow, 3).Value = Ngaylap.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 4).Value = pnk.IdpbhNavigation.Sophieu;
                        worksheet.Cell(currentRow, 5).Value = pnk.IdvlNavigation.Tenvl;
                        worksheet.Cell(currentRow, 6).Value = pnk.Soluong;
                        worksheet.Cell(currentRow, 7).Value = pnk.Dongia;

                        var Thanhtien = String.Format("{0:0,0}", (pnk.Soluong * pnk.Dongia));
                        worksheet.Cell(currentRow, 8).Value = Thanhtien;

                        tongSoLuong += pnk.Soluong;
                        tongGiaNhap += pnk.Dongia;
                        tongThanhTien += (pnk.Soluong * pnk.Dongia);

                    }
                    currentRow++;
                    worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                    worksheet.Cell(currentRow, 6).Value = tongSoLuong;
                    worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tongGiaNhap);
                    worksheet.Cell(currentRow, 8).Value = String.Format("{0:0,0}", tongThanhTien);

                    //tiêu đề
                    DateTime now = DateTime.Now;
                    currentRow += 2;
                    worksheet.Cell(currentRow, 7).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "Người mua";
                    worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                    worksheet.Cell(currentRow, 8).Value = "Người phê duyệt";

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 8).Value = "(Ký, họ tên, đóng dấu)";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "phieubanhang" + fromString + "-" + toString + ".xlsx");
                    }
                }
            }
            if (action.Equals("csv") && from == null && to == null || action.Equals("csv"))
            {
                string fromString = "";
                string toString = "";
                if (from != null && to != null)
                {

                    DateTime From = (DateTime)from;
                    DateTime To = (DateTime)to;
                    fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                }

                var builder = new StringBuilder();
                builder.AppendLine("Mã khách hàng, Tên khách hàng, Ngày lập, Số phiếu, Tên hàng hóa, Số lượng, Đon giá, Thành tiền");
                foreach (var p in Listndpbh)
                {
                    builder.AppendLine($"{p.IdpbhNavigation.IdkhNavigation.Makh}, {p.IdpbhNavigation.IdkhNavigation.Tenkh}, {p.IdpbhNavigation.Ngaylap}, {p.IdpbhNavigation.Sophieu}, {p.IdvlNavigation.Tenvl}, {p.Soluong}, {p.Dongia}, {p.Soluong * p.Dongia}");
                }

                return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "phieubanhang" + fromString + "-" + toString + ".csv");
            }
            return View(Listndpbh);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Phieubanhang pbh, string action)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                if (nhanvien == null)
                {
                    pbh.Idnv = 2;
                }
                else
                {
                    pbh.Idnv = nhanvien.Idnv;
                }
                if (action.Equals("addItem"))
                {
                    pbh.Ngaylap = DateTime.Now;
                    pbh.Idpbh = 0;
                    _context.Add(pbh);

                }
                if (action.Equals("editItem"))
                {
                    pbh.Active = 1;
                    _context.Update(pbh);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchProduct(int? IdpbhSearch, string searchString, int searchIdvl, string action, Noidungpbh nd, int? idpbhDelete)
        {

            TempData["phieubanhang"] = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == IdpbhSearch);
            ViewBag.Idpbh = IdpbhSearch;

            TempData["noidungphieubanhang"] = await _context.Noidungpbh
                .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpbh == IdpbhSearch)
                .ToListAsync();


            //Noidungthunokh ndptn = await _context.Noidungthunokh
            //   .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
            //   .Include(n => n.IdptnkhNavigation)
            //   .Where(pn => pn.Idpbh == IdpbhSearch)
            //   .FirstOrDefaultAsync();

            TempData["noidungphieuthunokh"] = await _context.Noidungthunokh
               .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
               .Include(n => n.IdptnkhNavigation)
               .Where(pn => pn.Idpbh == IdpbhSearch)
               .ToListAsync();
            //TempData["SophieuTNKH"] = ndptn.IdptnkhNavigation.Sophieu;
            //TempData["Idptnkh"] = ndptn.Idptnkh;

            TempData["VatlieuSearch"] = await _context.Noidungpnkshow
            .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(nd => nd.Soluong > 0)
                .Where(pn => pn.IdpnkNavigation.Active == 1)
                .Where(pn => pn.IdvlNavigation.Mavl.Equals(searchString))
                .ToListAsync();


            //string sessionIdvl = HttpContext.Session.GetString("Idvl");
            //int Idvl = Convert.ToInt32(sessionIdvl);
            Vatlieu selectedGoods = _context.Vatlieu.Where(active => active.Active == 1).Where(Id => Id.Idvl == searchIdvl).FirstOrDefault();
            TempData["selectedGoods"] = selectedGoods;
            if (action.Equals("AddNDPBH"))
            {
                try
                {
                    float count = nd.Soluong;
                    List<Noidungpnkshow> ListNDPN = await _context.Noidungpnkshow.Where(n => n.Idvl == nd.Idvl).OrderBy(a => a.Hansd).ToListAsync();
                    foreach (Noidungpnkshow ndpn in ListNDPN)
                    {
                        float countAvailable = ndpn.Slc;
                        if (ndpn.Slc > 0 && ndpn.Slc <= count)
                        {
                            ndpn.Slc -= ndpn.Slc;
                            count -= ndpn.Slc;

                        }
                        if (ndpn.Slc > count)
                        {
                            ndpn.Slc -= count;
                        }

                        if (count == 0)
                        {
                            //chưa vào đây để xóa khi sl=0

                            break;
                        }
                        _context.Noidungpnkshow.Update(ndpn);

                    }
                    foreach (Noidungpnkshow ndpndel in ListNDPN)
                    {
                        if (ndpndel.Slc == 0)
                        {
                            _context.Noidungpnkshow.Remove(ndpndel);
                            await _context.SaveChangesAsync();

                        }
                    }
                    _context.Noidungpbh.Add(nd);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {

                }
            }
            else if (action.Equals("deleteNDBH"))
            {
                //Chưa xử lý khi xóa hoàn sl
                try
                {
                    var ndbh = _context.Noidungpbh.Where(m => m.Idndpbh == idpbhDelete).FirstOrDefault();

                    _context.Noidungpbh.Remove(ndbh);
                    await _context.SaveChangesAsync();
                    return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

                }
                catch (Exception e)
                {
                    return new JsonResult(new { code = 500, msg = e });
                }

            }
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {

            TempData["phieubanhang"] = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == id);
            ViewBag.Idpbh = id;

            TempData["noidungphieubanhang"] = await _context.Noidungpbh
                .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpbh == id)
                .ToListAsync();

            //Noidungthunokh ndptn = await _context.Noidungthunokh
            //    .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
            //    .Include(n => n.IdptnkhNavigation)
            //    .Where(pn => pn.Idpbh == id)
            //    .FirstOrDefaultAsync();

            TempData["noidungphieuthunokh"] = await _context.Noidungthunokh
                .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                .Include(n => n.IdptnkhNavigation)
                .Where(pn => pn.Idpbh == id)
                .ToListAsync();




            //TempData["SophieuTNKH"] = ndptn.IdptnkhNavigation.Sophieu;
            //TempData["Idptnkh"] = ndptn.Idptnkh;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungpbh noidungpbh, string action, int phieubanhang, string searchString = "")
        {

            try
            {


                if (action.Equals("addItem"))
                {
                    _context.Noidungpbh.Add(noidungpbh);
                    await _context.SaveChangesAsync();
                }
                if (action.Equals("editItem"))
                {
                    noidungpbh.Idndpbh = phieubanhang;


                    _context.Noidungpbh.Update(noidungpbh);

                    await _context.SaveChangesAsync();
                }
                if (action.Equals("TaoPhieu"))
                {
                    Phieutranoncc phieutranoncc = new Phieutranoncc();
                    phieutranoncc.Sophieu = noidungpbh.IdpbhNavigation.Sophieu;
                    phieutranoncc.Ngaylap = DateTime.Now;
                    phieutranoncc.Idhttt = 1;
                    _context.Phieutranoncc.Add(phieutranoncc);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Details", "Phieubanhang", new { id = noidungpbh.Idpbh });

            }
            catch (Exception e)
            {

            }
            TempData["phieubanhang"] = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == noidungpbh.Idpbh);
            ViewBag.Idpbh = noidungpbh.Idpbh;


            TempData["noidungphieubanhang"] = await _context.Noidungpbh
                 .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                 .Include(n => n.IdvlNavigation)
                 .Where(pn => pn.Idpbh == noidungpbh.Idpbh)
                 .ToListAsync();

            if (!searchString.Equals(""))
            {
                TempData["VatlieuSearch"] = await _context.Noidungpnk
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.IdvlNavigation.Mavl.Equals(searchString))
                .ToListAsync();
            }

            TempData["noidungphieuthunokh"] = await _context.Noidungthunokh
                .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
                .Include(n => n.IdptnkhNavigation)
                .Where(pn => pn.Idpbh == noidungpbh.Idpbh)
                .ToListAsync();

            return View();


        }
        // GET: Phieunhapkho/Details/5

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }


        //    var phieubanhang = await _context.Phieubanhang
        //        .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
        //        .FirstOrDefaultAsync(m => m.Idpbh == id);
        //    ViewBag.Idpbh = phieubanhang.Idpbh;


        //    TempData["Noidungphieubanhang"]  = await _context.Noidungpbh
        //        .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
        //        .Include(n => n.IdvlNavigation)
        //        .Where(pn => pn.Idpbh == phieubanhang.Idpbh)
        //        .ToListAsync();


        //    return View();
        //}

        // GET: Phieunhapkho/Create
        public IActionResult Create()
        {
            ViewData["Nhanvienidnv"] = new SelectList(_context.Nhanvien, "Idnv", "Idnv");
            return View();
        }

        // POST: Phieunhapkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Phieubanhang phieubanhang)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                if (nhanvien == null)
                {
                    phieubanhang.Idnv = 2;
                }
                else
                {
                    phieubanhang.Idnv = nhanvien.Idnv;
                }
                DateTime dateNow = DateTime.Now;
                phieubanhang.Ngaylap = dateNow;
                phieubanhang.Active = 1;

                _context.Add(phieubanhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Nhanvienidnv"] = new SelectList(_context.Nhanvien, "Idnv", "Idnv", phieubanhang.Idnv);
            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieubanhang = await _context.Phieubanhang
                .Include(p => p.IdnvNavigation).Include(p => p.IdkhNavigation)
                .FirstOrDefaultAsync(m => m.Idpbh == id);
            if (phieubanhang == null)
            {
                return NotFound();
            }

            return View(phieubanhang);
        }
        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phieubanhang phieubanhang)
        {
            if (id != phieubanhang.Idpbh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string employeeEmail = Request.Cookies["HienCaCookie"];
                    Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                    if (nhanvien == null)
                    {
                        phieubanhang.Idnv = 2;
                    }
                    else
                    {
                        phieubanhang.Idnv = nhanvien.Idnv;
                    }
                    _context.Update(phieubanhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieubanhangExists(phieubanhang.Idpbh))
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
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete(int? id)
        {

            try
            {
                var pbh = _context.Phieubanhang.Where(m => m.Idpbh == id).FirstOrDefault();
                pbh.Active = 0;
                _context.Phieubanhang.Update(pbh);
                _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }



        }
        // GET: Phieunhapkho/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{



        //    Phieubanhang phieubanhang = _context.Phieubanhang.Where(pn => pn.Idpbh == id).FirstOrDefault();
        //    ViewData["sophieu"] = phieubanhang.Sophieu;
        //    ViewData["idpnk"] = phieubanhang.Idpbh;
        //    List<Noidungpbh> noidungphieubanhang = await _context.Noidungpbh
        //        .Include(n => n.IdpbhNavigation).Include(n => n.IdpbhNavigation.IdnvNavigation)
        //        .Include(n => n.IdvlNavigation)
        //        .Where(pbh=> pbh.Idpbh == phieubanhang.Idpbh)
        //        .ToListAsync();


        //    return View(noidungphieubanhang);
        //}

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieubanhang = await _context.Phieubanhang.FindAsync(id);
            phieubanhang.Active = 0;
            _context.Phieubanhang.Update(phieubanhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        private bool PhieubanhangExists(int id)
        {
            return _context.Phieubanhang.Any(e => e.Idpbh == id);
        }
    }
}
