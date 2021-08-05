using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class LoaiDichVuController : Controller
    {
        private readonly ILoaiDichVuService _loaidichVuService;
        private readonly DB_Context _Context;
        public LoaiDichVuController(ILoaiDichVuService LoaidichVuService, DB_Context context)
        {
            _loaidichVuService = LoaidichVuService;
            _Context = context;
        }
        // GET: LoaiDichVuController
        public ActionResult Index()
        {
            return View(_loaidichVuService.GetAllLoaiDichVu());
        }

        // GET: LoaiDichVuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoaiDichVuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiDichVuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiDichVu ldv)
        {
            _loaidichVuService.AddLoaiDichVu(ldv);

            return RedirectToAction(nameof(Index));

        }

        // GET: LoaiDichVuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_loaidichVuService.GetLoaiDichVu(id));
        }

        // POST: LoaiDichVuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoaiDichVu loaidichVu)
        {
            _loaidichVuService.EditLoaiDichVu(loaidichVu);
            return RedirectToAction("Index");
        }

        // GET: LoaiDichVuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoaiDichVuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _loaidichVuService.DeleteLoaiDichVu(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("LoaiDichVu");
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Tên loại dịch vụ"),
                                        new DataColumn("Mô tả"),
                                        new DataColumn("Trạng thái"),});

            var customers = from customer in this._Context.LoaiDichVus.Take(10)
                            select customer;

            foreach (var loaiDichVu in customers)
            {
                dt.Rows.Add(loaiDichVu.tenLoaiDichVu, loaiDichVu.moTa, loaiDichVu.trangThai);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Loại dịch vụ.xlsx");
                }
            }
        }
    }
}