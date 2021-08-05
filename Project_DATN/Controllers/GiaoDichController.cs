using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class GiaoDichController : Controller
    {
        private readonly IGiaoDichService _giaoDichService;
        public GiaoDichController(IGiaoDichService giaoDichService)
        {
            _giaoDichService = giaoDichService;
        }
        public IActionResult Index()
        {
            return View(_giaoDichService.GetAllGiaoDich());
        }
        [HttpGet]
        public IActionResult AddGiaoDich()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGiaoDich(GiaoDich gd)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(gd), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:28656/api/giaodich", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditGiaoDich(int id)
        {
            return View(_giaoDichService.GetGiaoDich(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditGiaoDich(int id,GiaoDich giaoDich)
        {
            GiaoDich st = new GiaoDich();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(giaoDich), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:28656/api/giaodich/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<GiaoDich>(apiReult);
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
            GiaoDich st = new GiaoDich();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/giaodich/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<GiaoDich>(apiReult);
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
