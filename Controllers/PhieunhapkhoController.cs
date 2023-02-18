using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;
using OfficeOpenXml;



namespace QuanLySanXuat.Controllers
{
    [Authorize]
    public class PhieunhapkhoController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public PhieunhapkhoController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }

        // GET: Phieunhapkho
        public async Task<IActionResult> Index()
        {
            var phieunhapkho = _context.Phieunhapkho.Where(p => p.Active == 1).Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation);

            return View(await phieunhapkho.ToListAsync());
        }

        public async Task<IActionResult> ShowReport(DateTime? from, DateTime? to, string action, int? Idvl)
        {
            List<Noidungpnk> Listndpnk;

            if (from != null && to != null)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            if (from != null && to != null && Idvl > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to).Where(d => d.Idvl==Idvl).Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            if (from == null && to == null && Idvl > 0)
            {
                Listndpnk = await _context.Noidungpnk.Where(d => d.Idvl == Idvl).Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
            }
            else
            {
                Listndpnk = await _context.Noidungpnk.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation).Include(p => p.IdpnkNavigation.IdnccNavigation).ToListAsync();
                

            }
            if (action.Equals("export") && from == null && to == null || action.Equals("export"))
            {

                using (var workbook = new XLWorkbook())
                {
                    //tên sheet
                    var worksheet = workbook.Worksheets.Add("Phieunhapkho");

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
                        worksheet.Cell(currentRow, 4).Value = "BẢNG KÊ PHIẾU NHẬP KHO TỪ " + fromString + " ĐẾN " + toString;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 4).Value = "BẢNG KÊ PHIẾU NHẬP KHO TỪ " + from + " ĐẾN " + to;

                    }

                    //danh sách phiếu
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Mã NCC";
                    worksheet.Cell(currentRow, 2).Value = "Tên nhà cung cấp";
                    worksheet.Cell(currentRow, 3).Value = "Ngày nhập";
                    worksheet.Cell(currentRow, 4).Value = "Số phiếu";
                    worksheet.Cell(currentRow, 5).Value = "Số lô";
                    worksheet.Cell(currentRow, 6).Value = "Mã hàng hóa";
                    worksheet.Cell(currentRow, 7).Value = "Tên hàng hóa";
                    worksheet.Cell(currentRow, 8).Value = "Đơn vị tính";
                    worksheet.Cell(currentRow, 9).Value = "Số lượng";
                    worksheet.Cell(currentRow, 10).Value = "Đơn giá nhập(đ)";
                    worksheet.Cell(currentRow, 11).Value = "Thành tiền(đ)";

                    float tongSoLuong = 0;
                    float tongGiaNhap = 0;
                    float tongThanhTien = 0;

                    foreach (var pnk in Listndpnk)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = pnk.IdpnkNavigation.IdnccNavigation.Mancc;
                        worksheet.Cell(currentRow, 2).Value = pnk.IdpnkNavigation.IdnccNavigation.Tenncc;
                        DateTime Ngaylap = (DateTime)pnk.IdpnkNavigation.Ngaylap;
                        worksheet.Cell(currentRow, 3).Value = Ngaylap.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        worksheet.Cell(currentRow, 4).Value = pnk.IdpnkNavigation.Sophieu;
                        worksheet.Cell(currentRow, 5).Value = pnk.Solo;
                        worksheet.Cell(currentRow, 6).Value = pnk.IdvlNavigation.Mavl;
                        worksheet.Cell(currentRow, 7).Value = pnk.IdvlNavigation.Tenvl;
                        worksheet.Cell(currentRow, 8).Value = pnk.Donvitinh;
                        worksheet.Cell(currentRow, 9).Value = pnk.Soluong;
                        worksheet.Cell(currentRow, 10).Value = pnk.Dongia;

                        var Thanhtien = String.Format("{0:0,0}", (pnk.Soluong * pnk.Dongia));
                        worksheet.Cell(currentRow, 11).Value = Thanhtien;

                        tongSoLuong += pnk.Soluong;
                        tongGiaNhap += pnk.Dongia;
                        tongThanhTien += (pnk.Soluong * pnk.Dongia);

                    }
                    currentRow++;
                    worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                    worksheet.Cell(currentRow, 9).Value = tongSoLuong;
                    worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", tongGiaNhap);
                    worksheet.Cell(currentRow, 11).Value = String.Format("{0:0,0}", tongThanhTien);

                    //tiêu đề
                    DateTime now = DateTime.Now;
                    currentRow += 2;
                    worksheet.Cell(currentRow, 8).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "Người mua";
                    worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                    worksheet.Cell(currentRow, 9).Value = "Người phê duyệt";

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 9).Value = "(Ký, họ tên, đóng dấu)";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "phieunhapkho" + fromString +"-"+ toString + ".xlsx");
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
                builder.AppendLine("Mã nhà cung cấp, Tên nhà cung cấp, Ngày nhập, Số phiếu, Số lô, Mã hàng hóa, Tên hàng hóa, Đơn vị tính, Số lượng, Đon giá, Thành tiền");
                foreach (var p in Listndpnk)
                {
                    builder.AppendLine($"{p.IdpnkNavigation.IdnccNavigation.Mancc}, {p.IdpnkNavigation.IdnccNavigation.Tenncc}, {p.IdpnkNavigation.Ngaylap}, {p.IdpnkNavigation.Sophieu}, {p.Solo}, {p.IdvlNavigation.Mavl}, {p.IdvlNavigation.Tenvl}, {p.Donvitinh}, {p.Soluong}, {p.Dongia}, {p.Soluong * p.Dongia}");
                }

                return File(new UTF8Encoding().GetBytes(builder.ToString()), "text/csv", "phieunhapkho" + fromString + "-" + toString + ".csv");
            }

                return View(Listndpnk);
        }
       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Phieunhapkho pnk, string action)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                if (nhanvien == null)
                {
                    pnk.Idnv = 2;
                }
                else
                {
                    pnk.Idnv = nhanvien.Idnv;
                }
                if (action.Equals("addItem"))
                {
                    pnk.Ngaylap = DateTime.Now;
                    pnk.Idpnk = 0;
                    _context.Add(pnk);

                }
                if (action.Equals("editItem"))
                {
                    pnk.Active = 1;
                    _context.Update(pnk);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            TempData["phieunhapkho"] = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            ViewBag.Idpnk = id;


            TempData["noidungphieunhap"] = await _context.Noidungpnkshow
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == id)
                .ToListAsync();

            TempData["noidungphieutranoncc"] = await _context.Noidungtranoncc
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdptnnccNavigation)
                .Where(pn => pn.Idpnk == id)
                .ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actions(Noidungpnk noidungphieunhap, string action, int phieunhap)
        {
            //add and edit phieu nhap va phieu tam;
            try
            {

                Noidungpnkshow ndpnkshow = new Noidungpnkshow();
                ndpnkshow.Solo = noidungphieunhap.Solo;
                ndpnkshow.Soluong = noidungphieunhap.Soluong;
                ndpnkshow.Slc = noidungphieunhap.Soluong;
                ndpnkshow.Dongia = noidungphieunhap.Dongia;
                ndpnkshow.Donvitinh = noidungphieunhap.Donvitinh;
                ndpnkshow.Ngaysx = noidungphieunhap.Ngaysx;
                ndpnkshow.Hansd = noidungphieunhap.Hansd;
                ndpnkshow.Idpnk = noidungphieunhap.Idpnk;
                ndpnkshow.Idvl = noidungphieunhap.Idvl;
                if (action.Equals("addItem"))
                {
                    noidungphieunhap.Idndpnk = 0;
                    _context.Noidungpnk.Add(noidungphieunhap);

                    ndpnkshow.Idndpnk = 0;
                    _context.Noidungpnkshow.Add(ndpnkshow);
                    await _context.SaveChangesAsync();
                }
                if (action.Equals("editItem"))
                {
                    noidungphieunhap.Idndpnk = phieunhap;
                    ndpnkshow.Idndpnk = phieunhap;

                    _context.Noidungpnk.Update(noidungphieunhap);
                    _context.Noidungpnkshow.Update(ndpnkshow);

                    await _context.SaveChangesAsync();
                }
                if (action.Equals("TaoPhieu"))
                {
                    Phieutranoncc phieutranoncc = new Phieutranoncc();
                    phieutranoncc.Sophieu = noidungphieunhap.IdpnkNavigation.Sophieu;
                    phieutranoncc.Ngaylap = DateTime.Now;
                    phieutranoncc.Idhttt = 1;
                    _context.Phieutranoncc.Add(phieutranoncc);
                    await _context.SaveChangesAsync();
                }
                //phieunhapkho.Active = 1;
                //phieunhapkho.Ngaylap = DateTime.Now;
                //_context.Add(phieunhapkho);
                //await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Phieunhapkho", new { id = noidungphieunhap.Idpnk });

            }
            catch (Exception e)
            {

            }
            TempData["phieunhapkho"] = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == noidungphieunhap.Idpnk);
            ViewBag.Idpnk = noidungphieunhap.Idpnk;



            TempData["noidungphieunhap"] = await _context.Noidungpnk
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdvlNavigation)
                .Where(pn => pn.Idpnk == noidungphieunhap.Idpnk)
                .ToListAsync();
            TempData["noidungphieutranoncc"] = await _context.Noidungtranoncc
                .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
                .Include(n => n.IdptnnccNavigation)
                .Where(pn => pn.Idpnk == noidungphieunhap.Idpnk)
                .ToListAsync();

            return View();


        }
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
        public async Task<IActionResult> Create(Phieunhapkho phieunhapkho)
        {
            if (ModelState.IsValid)
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Nhanvien nhanvien = _context.Nhanvien.Where(nv => nv.Email == employeeEmail).FirstOrDefault();

                if (nhanvien == null)
                {
                    phieunhapkho.Idnv = 2;
                }
                else
                {
                    phieunhapkho.Idnv = nhanvien.Idnv;
                }
                phieunhapkho.Active = 1;
                phieunhapkho.Ngaylap = DateTime.Now;
                _context.Add(phieunhapkho);

                Phieutranoncc phieutranoncc = new Phieutranoncc();
                phieutranoncc.Idnv = phieunhapkho.Idnv;
                phieutranoncc.Ngaylap = DateTime.Now;
                phieutranoncc.Sophieu = phieunhapkho.Sophieu;
                phieutranoncc.Idhttt = 1;
                phieutranoncc.Active = 1;


                _context.Phieutranoncc.Add(phieutranoncc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Phieunhapkho");
            }

            return View(phieunhapkho);


        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieunhapkho = await _context.Phieunhapkho
                .Include(p => p.IdnvNavigation).Include(p => p.IdnccNavigation)
                .FirstOrDefaultAsync(m => m.Idpnk == id);
            if (phieunhapkho == null)
            {
                return NotFound();
            }

            return View(phieunhapkho);
        }
        // POST: Phieunhapkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phieunhapkho phieunhapkho)
        {
            if (id != phieunhapkho.Idpnk)
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
                        phieunhapkho.Idnv = 2;
                    }
                    else
                    {
                        phieunhapkho.Idnv = nhanvien.Idnv;
                    }
                    _context.Update(phieunhapkho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieunhapkhoExists(phieunhapkho.Idpnk))
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
            return View(phieunhapkho);



        }

        // GET: Phieunhapkho/Delete/5
        public IActionResult Delete(int? id)
        {

            try
            {
                var phieunhapkho = _context.Phieunhapkho.Where(m => m.Idpnk == id).FirstOrDefault();
                phieunhapkho.Active = 0;
                _context.Phieunhapkho.Update(phieunhapkho);
                _context.SaveChangesAsync();
                return new JsonResult(new { code = 200, msg = "Xóa thành công!" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { code = 500, msg = e });
            }



        }
        //public async Task<IActionResult> Delete(int? id)
        //{


        //    Phieunhapkho phieunhap = _context.Phieunhapkho.Where(pn => pn.Idpnk == id).FirstOrDefault();
        //    ViewData["sophieu"] = phieunhap.Sophieu;
        //    ViewData["idpnk"] = phieunhap.Idpnk;
        //    List<Noidungpnk> noidungphieunhap = await _context.Noidungpnk
        //        .Include(n => n.IdpnkNavigation).Include(n => n.IdpnkNavigation.IdnvNavigation)
        //        .Include(n => n.IdvlNavigation)
        //        .Where(pn => pn.Idpnk == phieunhap.Idpnk)
        //        .ToListAsync();


        //    return View(noidungphieunhap);
        //}

        // POST: Phieunhapkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieunhapkho = await _context.Phieunhapkho.FindAsync(id);
            phieunhapkho.Active = 0;
            _context.Phieunhapkho.Update(phieunhapkho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        private bool PhieunhapkhoExists(int id)
        {
            return _context.Phieunhapkho.Any(e => e.Idpnk == id);
        }
    }
}
