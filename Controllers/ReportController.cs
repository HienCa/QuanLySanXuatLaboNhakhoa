using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLySanXuat.Entities;
using System.IO;
using ClosedXML.Excel;

namespace QuanLySanXuat.Controllers
{
    public class ReportController : Controller
    {
        private readonly ProductionManagementSoftwareContext _context;

        public ReportController(ProductionManagementSoftwareContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Report(DateTime? from, DateTime? to, string action)
        {


            if (from != null && to != null && action == "report")
            {

                var ListndpnkNew = await _context.Noidungpnkshow.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation)
                                                                .Include(p => p.IdpnkNavigation.IdnccNavigation)
                                                                .Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to)
                                                                .GroupBy(g => g.IdvlNavigation.Tenvl)
                                                                .Select(g => new
                                                                {
                                                                    Tenvl = g.Key,
                                                                    //Donvitinh = g.Select(d => d.Donvitinh),
                                                                    //Mavl = g.Select(d => d.IdvlNavigation.Mavl),
                                                                    //Giaban = g.Select(d => d.IdvlNavigation.Giaban),
                                                                    //Gianhap = g.Select(d => d.Dongia),
                                                                    Soluong = g.Sum(t => t.Soluong),
                                                                    Soluongcon = g.Sum(t => t.Slc),
                                                                    Soluongxuat = g.Sum(t => t.Soluong) - g.Sum(t => t.Slc),
                                                                    Thanhtien = g.Sum(t => t.Soluong) * g.Sum(t => t.Dongia),
                                                                    Thanhtienton = g.Sum(t => t.Slc) * g.Sum(t => t.Dongia),
                                                                    Thanhtienxuat = (g.Sum(t => t.Soluong) - g.Sum(t => t.Slc)) * g.Sum(t => t.Dongia),
                                                                }).ToListAsync();



                var ListndpnkOld = await _context.Noidungpnkshow.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation)
                                                               .Include(p => p.IdpnkNavigation.IdnccNavigation)
                                                               .Where(d => d.IdpnkNavigation.Ngaylap < from)
                                                               .GroupBy(g => g.IdvlNavigation.Tenvl)
                                                                .Select(g => new
                                                                {
                                                                    Tenvl = g.Key,
                                                                    //Donvitinh = g.Select(d => d.Donvitinh),
                                                                    //Mavl = g.Select(d => d.IdvlNavigation.Mavl),
                                                                    //Giaban = g.Select(d => d.IdvlNavigation.Giaban),
                                                                    //Gianhap = g.Select(d => d.Dongia),
                                                                    Soluong = g.Sum(t => t.Soluong),
                                                                    Soluongcon = g.Sum(t => t.Slc),
                                                                    Soluongxuat = g.Sum(t => t.Soluong) - g.Sum(t => t.Slc),
                                                                    Thanhtien = g.Sum(t => t.Soluong) * g.Sum(t => t.Dongia),
                                                                    Thanhtienton = g.Sum(t => t.Slc) * g.Sum(t => t.Dongia),
                                                                    Thanhtienxuat = (g.Sum(t => t.Soluong) - g.Sum(t => t.Slc)) * g.Sum(t => t.Dongia),
                                                                }).ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    //tên sheet
                    var worksheet = workbook.Worksheets.Add("Báo cáo Nhập-Xuất-Tồn");

                    //tiêu đề
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "CÔNG TY SẢN XUẤT HIENCA";
                    currentRow += 2;
                    DateTime From = (DateTime)from;
                    DateTime To = (DateTime)to;
                    string fromString = From.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string toString = To.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    worksheet.Cell(currentRow, 4).Value = "BÁO CÁO NHẬP-XUẤT-TỒN";
                    currentRow++;
                    worksheet.Cell(currentRow, 4).Value = "TỪ " + fromString + " ĐẾN " + toString;
                    currentRow += 2;
                    worksheet.Cell(currentRow, 4).Value = "Tồn kho đầu kỳ";
                    worksheet.Cell(currentRow, 6).Value = "Nhập trong kỳ";
                    worksheet.Cell(currentRow, 8).Value = "Xuất trong kỳ";
                    worksheet.Cell(currentRow, 11).Value = "Tồn kho cuối kỳ";
                    //danh sách
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Mã hàng hóa";
                    worksheet.Cell(currentRow, 2).Value = "Tên hàng hóa";
                    worksheet.Cell(currentRow, 3).Value = "Đơn vị tính";
                    worksheet.Cell(currentRow, 4).Value = "Số lượng";
                    worksheet.Cell(currentRow, 5).Value = "Thành tiền(đ)";

                    worksheet.Cell(currentRow, 6).Value = "Số lượng";
                    worksheet.Cell(currentRow, 7).Value = "Thành tiền(đ)";

                    worksheet.Cell(currentRow, 8).Value = "Số lượng";
                    worksheet.Cell(currentRow, 9).Value = "Đơn giá xuất kho(đ)";
                    worksheet.Cell(currentRow, 10).Value = "Thành tiền(đ)";

                    worksheet.Cell(currentRow, 11).Value = "Số lượng";
                    worksheet.Cell(currentRow, 12).Value = "Thành tiền(đ)";

                    float tongSoLuong = 0;
                    float tongSoLuongXuat = 0;
                    float tongSoLuongTon = 0;
                    float GiaNhap = 0;
                    float GiaXuat = 0;
                    float tongThanhTien = 0;
                    float tongThanhTienTon = 0;
                    float tongThanhTienXuat = 0;

                    foreach (var pnk in ListndpnkNew)
                    {
                        currentRow++;
                        //worksheet.Cell(vitri1, 1).Value = pnk.IdvlNavigation.Mavl;
                        worksheet.Cell(currentRow, 2).Value = pnk.Tenvl;
                        //worksheet.Cell(vitri1, 3).Value = pnk.Donvitinh;

                        worksheet.Cell(currentRow, 6).Value = pnk.Soluong;
                        worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", pnk.Thanhtien);


                        //worksheet.Cell(vitri1, 8).Value = pnk.Soluongxuat;
                        worksheet.Cell(currentRow, 8).Value = pnk.Soluongxuat;
                        worksheet.Cell(currentRow, 9).Value = 0;//giá xuất
                        worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", pnk.Thanhtienxuat);

                        worksheet.Cell(currentRow, 11).Value = pnk.Soluongcon;
                        worksheet.Cell(currentRow, 12).Value = String.Format("{0:0,0}", pnk.Thanhtienton);

                        tongSoLuong += pnk.Soluong;
                        tongSoLuongXuat += pnk.Soluongxuat;
                        tongSoLuongTon += pnk.Soluongcon;
                        //GiaNhap = pnk.Giaban;
                        tongThanhTien += pnk.Thanhtien;
                        tongThanhTienXuat += pnk.Thanhtienxuat;
                        tongThanhTienTon += pnk.Thanhtienton;
                    }
                    //var vitri2 = vitri1;
                    //foreach (var pnk in ListndpnkNew)
                    //{
                    //    vitri2++;


                    //    worksheet.Cell(vitri2, 4).Value = pnk.Soluong;
                    //    worksheet.Cell(vitri2, 5).Value = pnk.Thanhtien;

                    //    //worksheet.Cell(vitri2, 6).Value = pnk.IdvlNavigation.Mavl;
                    //    //worksheet.Cell(vitri2, 7).Value = pnk.IdvlNavigation.Tenvl;
                    //    //worksheet.Cell(vitri2, 8).Value = pnk.Donvitinh;
                    //    worksheet.Cell(vitri2, 9).Value = pnk.Soluongcon;
                    //    //worksheet.Cell(vitri2, 10).Value = pnk.Dongia;
                    //    //tongSoLuong += pnk.Soluong;
                    //    //tongSoLuongCon += pnk.Slc;
                    //    //tongGiaNhap += pnk.Dongia;
                    //    //tongThanhTien += (pnk.Soluong * pnk.Dongia);
                    //}


                    //var Thanhtien = String.Format("{0:0,0}", (pnk.Soluong * pnk.Dongia));
                    //worksheet.Cell(currentRow, 11).Value = Thanhtien;

                    currentRow++;
                    worksheet.Cell(currentRow, 3).Value = "TỔNG CỘNG";
                    worksheet.Cell(currentRow, 6).Value = tongSoLuong;
                    worksheet.Cell(currentRow, 7).Value = String.Format("{0:0,0}", tongThanhTien);
                    worksheet.Cell(currentRow, 8).Value = tongSoLuongXuat;
                    worksheet.Cell(currentRow, 9).Value = 0;
                    worksheet.Cell(currentRow, 10).Value = String.Format("{0:0,0}", tongThanhTienXuat);
                    worksheet.Cell(currentRow, 11).Value = tongSoLuongTon;
                    worksheet.Cell(currentRow, 12).Value = String.Format("{0:0,0}", tongThanhTienTon);

                    //tiêu đề
                    DateTime now = DateTime.Now;
                    currentRow += 3;
                    worksheet.Cell(currentRow, 10).Value = "TP. Hồ Chí Minh, Ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "Người mua";
                    worksheet.Cell(currentRow, 5).Value = "Kế toán trưởng";
                    worksheet.Cell(currentRow, 11).Value = "Người phê duyệt";

                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 5).Value = "(Ký, họ tên)";
                    worksheet.Cell(currentRow, 11).Value = "(Ký, họ tên, đóng dấu)";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "baocaonhapxuatton" + fromString + "-" + toString + ".xlsx");
                    }
                }
            }
            if (from != null && to != null && action == "search")
            {

                var ListndpnkNew1 = await _context.Noidungpnkshow.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation)
                                                                .Include(p => p.IdpnkNavigation.IdnccNavigation)
                                                                .Where(d => d.IdpnkNavigation.Ngaylap >= from && d.IdpnkNavigation.Ngaylap <= to)
                                                                .GroupBy(g => g.IdvlNavigation.Tenvl)
                                                                .Select(g => new
                                                                {
                                                                    Tenvl = g.Key,
                                                                    //Donvitinh = g.Select(d => d.Donvitinh),
                                                                    //Mavl = g.Select(d => d.IdvlNavigation.Mavl),
                                                                    //Giaban = g.Select(d => d.IdvlNavigation.Giaban),
                                                                    //Gianhap = g.Select(d => d.Dongia),
                                                                    SLnhaptrongky = g.Sum(t => t.Soluong),
                                                                    SLtoncuoiky = g.Sum(t => t.Slc),
                                                                    SLxuattrongky = g.Sum(t => t.Soluong) - g.Sum(t => t.Slc),
                                                                    Tongtiennhaptrongky = g.Sum(t => t.Soluong) * g.Sum(t => t.Dongia),
                                                                    Tongtientoncuoiky = g.Sum(t => t.Slc) * g.Sum(t => t.Dongia),
                                                                    Tongtienxuattrongky = (g.Sum(t => t.Soluong) - g.Sum(t => t.Slc)) * g.Sum(t => t.Dongia),
                                                                }).ToListAsync();



                //var ListndpnkOld = await _context.Noidungpnkshow.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation)
                //                                               .Include(p => p.IdpnkNavigation.IdnccNavigation)
                //                                               .Where(d => d.IdpnkNavigation.Ngaylap < from)
                //                                               .GroupBy(g => g.IdvlNavigation.Tenvl)
                //                                                .Select(g => new
                //                                                {
                //                                                    Tenvl = g.Key,
                //                                                    //Donvitinh = g.Select(d => d.Donvitinh),
                //                                                    //Mavl = g.Select(d => d.IdvlNavigation.Mavl),
                //                                                    //Giaban = g.Select(d => d.IdvlNavigation.Giaban),
                //                                                    //Gianhap = g.Select(d => d.Dongia),
                //                                                    SLnhaptrongky = g.Sum(t => t.Soluong),
                //                                                    SLtoncuoiky = g.Sum(t => t.Slc),
                //                                                    SLxuattrongky = g.Sum(t => t.Soluong) - g.Sum(t => t.Slc),
                //                                                    Tongtiennhaptrongky = g.Sum(t => t.Soluong) * g.Sum(t => t.Dongia),
                //                                                    Tongtientoncuoiky = g.Sum(t => t.Slc) * g.Sum(t => t.Dongia),
                //                                                    Tongtienxuattrongky = (g.Sum(t => t.Soluong) - g.Sum(t => t.Slc)) * g.Sum(t => t.Dongia),
                //                                                }).ToListAsync();



                List<Report> Listreport = new List<Report>();

                foreach (var item in ListndpnkNew1)
                {
                    Report report = new Report();
                    report.Tenvl = item.Tenvl;
                    report.SLnhaptrongky = item.SLnhaptrongky;
                    report.Tongtiennhaptrongky = item.Tongtiennhaptrongky;
                    report.SLxuattrongky = item.SLxuattrongky;
                    report.Tongtienxuattrongky = item.Tongtienxuattrongky;
                    report.SLtoncuoiky = item.SLtoncuoiky;
                    report.Tongtientoncuoiky = item.Tongtientoncuoiky;
                    Listreport.Add(report);

                }

                TempData["Listreport"] = Listreport;

            }

            if (from == null && to == null)
            {
                var ListndpnkNew = await _context.Noidungpnkshow.Include(p => p.IdpnkNavigation).Include(p => p.IdvlNavigation)
                                                                .Include(p => p.IdpnkNavigation.IdnccNavigation)
                                                                .GroupBy(g => g.IdvlNavigation.Tenvl)
                                                                .Select(g => new
                                                                {
                                                                    Tenvl = g.Key,
                                                                    //Donvitinh = g.Select(d => d.Donvitinh),
                                                                    //Mavl = g.Select(d => d.IdvlNavigation.Mavl),
                                                                    //Giaban = g.Select(d => d.IdvlNavigation.Giaban),
                                                                    //Gianhap = g.Select(d => d.Dongia),
                                                                    SLnhaptrongky = g.Sum(t => t.Soluong),
                                                                    SLtoncuoiky = g.Sum(t => t.Slc),
                                                                    SLxuattrongky = g.Sum(t => t.Soluong) - g.Sum(t => t.Slc),
                                                                    Tongtiennhaptrongky = g.Sum(t => t.Soluong) * g.Sum(t => t.Dongia),
                                                                    Tongtientoncuoiky = g.Sum(t => t.Slc) * g.Sum(t => t.Dongia),
                                                                    Tongtienxuattrongky = (g.Sum(t => t.Soluong) - g.Sum(t => t.Slc)) * g.Sum(t => t.Dongia),
                                                                }).ToListAsync();

                List<Report> Listreport = new List<Report>();
                foreach (var item in ListndpnkNew)
                {
                    Report report = new Report();
                    report.Tenvl = item.Tenvl;
                    report.SLnhaptrongky = item.SLnhaptrongky;
                    report.Tongtiennhaptrongky = item.Tongtiennhaptrongky;
                    report.SLxuattrongky = item.SLxuattrongky;
                    report.Tongtienxuattrongky = item.Tongtienxuattrongky;
                    report.SLtoncuoiky = item.SLtoncuoiky;
                    report.Tongtientoncuoiky = item.Tongtientoncuoiky;

                    Listreport.Add(report);
                }

                TempData["Listreport"] = Listreport;
            }

            return View();
        }
    }
}
