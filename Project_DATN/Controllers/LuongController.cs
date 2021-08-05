using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class LuongController : Controller
    {
        private readonly ILuongService _luongService;
        private readonly DB_Context _Context;
        public LuongController(ILuongService luongService, DB_Context context)
        {
            _luongService = luongService;
            _Context = context;
        }
        public IActionResult Index()
        {
            return View(_luongService.GetAllLuong());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ID_TaiKhoan = new SelectList(_Context.TaiKhoans, "ID", "TenTaiKhoan");
            return View();
        }
        public async Task<IActionResult> Create(Luong luong)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(luong), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:5000/api/luong", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.TaiKhoan = new SelectList(_Context.TaiKhoans, "ID", "TenTaiKhoan");
            return View(_luongService.GetLuong(id));
        }
        public async Task<IActionResult> Edit(int id, Luong luong)
        {
            Luong lg = new Luong();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(luong), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:5000/api/luong/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        lg = JsonConvert.DeserializeObject<Luong>(apiReult);
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
            Luong lg = new Luong();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:5000/api/luong/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        lg = JsonConvert.DeserializeObject<Luong>(apiReult);
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
