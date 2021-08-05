using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class GiaoCaController : Controller
    {
        private readonly IGiaoCaService _IgiaoCaService;
        private readonly DB_Context _DBContext;

        public GiaoCaController(IGiaoCaService giaoCaService , DB_Context dB_Context)
        {
            _IgiaoCaService = giaoCaService;
            _DBContext = dB_Context;
        }
        public IActionResult ListHoaDon()
        {
            
            var lst = _IgiaoCaService.GetListHoaDon();
            return View(lst.ToList());
        }
      
        public IActionResult LichSuGiaoCa()
        {
            var nv = _DBContext.GiaoCas.Include(x => x.TaiKhoan).ToList();
            var lst = _IgiaoCaService.GetListGiaoCa();
            return View(lst.ToList());
        }
        [HttpGet]
        public IActionResult TaoCaLam()
        {
            var time = DateTime.Now.ToString(); 
            ViewBag.Time = time;

            ViewBag.TaiKhoan = new SelectList(_DBContext.TaiKhoans, "ID", "tenTaiKhoan");

            var DSTK = new SelectList(_DBContext.TaiKhoans.Select(c => c.ID).ToList(), "DSTK");
            ViewBag.Id = DSTK;
            return View();
        }
        [HttpPost]
        public IActionResult TaoCaLam(GiaoCa giaoCa)
        {
            _IgiaoCaService.AddGiaoCa(giaoCa);
            return RedirectToAction("LichSuGiaoCa");
        }

        [HttpGet]
        public IActionResult UpdateGC(int id)
        {
            var time = DateTime.Now.ToString();
            ViewBag.Time = time;

            ViewBag.TaiKhoan = new SelectList(_DBContext.TaiKhoans, "ID", "tenTaiKhoan");

            var DSTK = new SelectList(_DBContext.TaiKhoans.Select(c => c.ID).ToList(), "DSTK");
            ViewBag.Id = DSTK;
            return View("UpdateGC", _DBContext.GiaoCas.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateGC(int id ,GiaoCa giaoCa)
        {
            _IgiaoCaService.UpdateGiaoCa(giaoCa);
            return RedirectToAction("LichSuGiaoCa");
        }

        public ActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");



            //Response.Clear();

            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.Headers.Add("content-disposition", "attachment: filename" + "ExeclReport.xlxs");
            //Response.Body.WriteAsync(pck.GetAsByteArray());


            using (var excel = new ExcelPackage())
            {


                var workSheet = excel.Workbook.Worksheets.Add("Worksheet Name");
                workSheet.Cells["A1"].Value = "Lịch sử giao ca ";
                workSheet.Cells["A2"].Value = "Thời gian";
                workSheet.Cells["B2"].Value = string.Format("{0:dd MMM yyyy} at{0:H: mm tt}", DateTimeOffset.Now);
                workSheet.Cells[4, 1].LoadFromCollection(_IgiaoCaService.GetListGiaoCa(), PrintHeaders: true, TableStyle: OfficeOpenXml.Table.TableStyles.Medium6);
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports.xlsx");
            }

            

        }

        public IActionResult Export( int id)
        {
            var data = _DBContext.GiaoCas.Select(x => x.ID).Equals(id);
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var packege = new ExcelPackage(stream))
            {
                var sheet = packege.Workbook.Worksheets.Add("Loai");

                sheet.Cells[1, 1].Value = "Ca Làm";
                sheet.Cells[1, 2].Value = "Số tiền đầu ca";
                sheet.Cells[1, 3].Value = "Số tiền thu cuối ca";
                sheet.Cells[1, 4].Value = "Số lượng hóa đơn trong ca";
                sheet.Cells[1, 5].Value = "Ghi chú";
                sheet.Cells[1, 6].Value = "Trạng thái";
                sheet.Cells[1, 7].Value = "Tổng tiền thu được trong ca";

                


                packege.Save();
            }
            stream.Position = 0;

            var filename = $"Loai_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",filename);
        }


       
    }
}
