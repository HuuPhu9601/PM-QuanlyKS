using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.duongpro99vipIService;

namespace Project_DATN.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly DB_Context _dbContext;

        public ChucVuController(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<ChucVu> lstChucVu = new List<ChucVu>();
            using (var httpClients = new HttpClient())
            {
                using (var response = await httpClients.GetAsync("http://localhost:28656/api/chucvu"))
                {
                    string apiResult = await response.Content.ReadAsStringAsync();
                    lstChucVu = JsonConvert.DeserializeObject<List<ChucVu>>(apiResult);
                }
            }
            return View(lstChucVu);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ID_TaiKhoan = new SelectList(_dbContext.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.ID_PhongBan = new SelectList(_dbContext.PhongBans, "ID", "tenPhongBan");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ChucVu chucVu)
        {
            if (!ModelState.IsValid)
            {
                return Content("Mời bạn nhập đầy đủ các trường thông tin");
            }
            using (var httpClients = new HttpClient())
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(chucVu), Encoding.UTF8, "application/json");
                using (var response = await httpClients.PostAsync("http://localhost:28656/api/chucvu", content))
                {

                }
            }
            return RedirectToAction("Index");
        }
        //Xem chi tiết
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ID_TaiKhoan = new SelectList(_dbContext.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.ID_PhongBan = new SelectList(_dbContext.PhongBans, "ID", "tenPhongBan");
            ChucVu cv = new ChucVu();
            using (var httpClients = new HttpClient())
            {
                using (var response = await httpClients.GetAsync("http://localhost:28656/api/chucvu/" + id))//Truyền ID vào URL
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();
                        cv = JsonConvert.DeserializeObject<ChucVu>(apiResult);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(cv);
        }
        public async Task<IActionResult> Delete(int id)
        {
            ChucVu cv = new ChucVu();
            using (var httpClients = new HttpClient())
            {
                using (var response = await httpClients.DeleteAsync("http://localhost:28656/api/chucvu/" + id))//Truyền ID vào URL
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();
                        cv = JsonConvert.DeserializeObject<ChucVu>(apiResult);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ID_TaiKhoan = new SelectList(_dbContext.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.ID_PhongBan = new SelectList(_dbContext.PhongBans, "ID", "tenPhongBan");
            ChucVu cv = new ChucVu();
            using (var httpClients = new HttpClient())
            {
                using (var response = await httpClients.GetAsync("http://localhost:28656/api/chucvu/" + id))//Truyền ID vào URL
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResult = await response.Content.ReadAsStringAsync();
                        cv = JsonConvert.DeserializeObject<ChucVu>(apiResult);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(cv);
        }
        public async Task<IActionResult> Edit(ChucVu chucVu)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(chucVu), Encoding.UTF8, "application/json");
                using (var response = await httpClients.PutAsync($"http://localhost:28656/api/chucvu/{chucVu.ID}", content))
                {

                }
            }
            return RedirectToAction("Index");
        }
    }
}
