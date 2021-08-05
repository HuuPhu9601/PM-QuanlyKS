using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OfficeOpenXml;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Project_DATN.Controllers
{
    public class DichVuController : Controller
    {

        private readonly IDichVuService _dichVuService;
        private readonly DB_Context _Context;
        public DichVuController(IDichVuService dichVuService, DB_Context context)
        {
            _dichVuService = dichVuService;
            _Context = context;
        }
        public IActionResult Index()
        {
            return View(_dichVuService.GetAllDichVu());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiDichVu = new SelectList(_Context.LoaiDichVus, "ID", "tenLoaiDichVu");
            return View();
        }
        public async Task<IActionResult> Create(DichVu dichVu)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(dichVu), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:5000/api/dichvu", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            ViewBag.LoaiDichVu = new SelectList(_Context.LoaiDichVus, "ID", "tenLoaiDichVu");
            return View(_dichVuService.GetDichVu(id));
        }
        public async Task<IActionResult> Edit(int id, DichVu dichVu)
        {
            DichVu dv = new DichVu();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(dichVu), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:5000/api/dichvu/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        dv = JsonConvert.DeserializeObject<DichVu>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            DichVu st = new DichVu();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:5000/api/dichvu/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<DichVu>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Hoadon");
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Tên dịch vụ"),
                                        new DataColumn("Đơn vị tính"),
                                        new DataColumn("Đơn giá"),
                                        new DataColumn("Đơn vị tiền"),
                                        new DataColumn("Mô tả"),
                                        new DataColumn("Trạng thái"),});

            var customers = from customer in this._Context.DichVus.Take(10)
                            select customer;

            foreach (var dichVu in customers)
            {
                dt.Rows.Add(dichVu.tenDichVu, dichVu.donViTinh, dichVu.donGia, dichVu.donViTien, dichVu.moTa, dichVu.trangThai);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dịch Vụ.xlsx");
                }
            }
        }
    }
}