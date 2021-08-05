using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly IKhachHangService _khachHangService;
        public readonly DB_Context _Context;
        public KhachHangController(IKhachHangService khachHangService, DB_Context context)
        {
            _khachHangService = khachHangService;
            _Context = context;

        }
        public IActionResult Index()
        {
            return View(_khachHangService.GetAllKhachHang());
        }
        public IActionResult ImportCustomer()
        {
            return View();
        }
        public async Task<List<KhachHang>> ImportCustomers(IFormFile file){
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var listCustomer = new List<KhachHang>();
            using (var stream = new MemoryStream())
            {
               await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                    var rowCount = worksheet.Dimension.Rows;
                    var colcount = worksheet.Dimension.Columns;
                    for(int row = 3; row<=rowCount; row++)
                    {
                        listCustomer.Add(new KhachHang { 
                            maKH = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            hoTenKH = worksheet.Cells[row,2].Value.ToString().Trim(),
                            email = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            gioiTinh = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            soDienThoai = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            CCCD = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            diaChi = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            quocTich = worksheet.Cells[row, 8].Value.ToString().Trim()
                        });
                    }
                }
            }
            _Context.KhachHangs.AddRange(listCustomer);
            _Context.SaveChanges();
            return listCustomer;
            RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KhachHang khachHang)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(khachHang), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:28656/api/khachhang", comtent))
                {
                    
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_khachHangService.GetKhachHang(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,KhachHang khachHang)
        {
            KhachHang st = new KhachHang();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(khachHang), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:28656/api/khachhang/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<KhachHang>(apiReult);
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
            KhachHang st = new KhachHang();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/khachhang/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<KhachHang>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
