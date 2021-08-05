using Microsoft.AspNetCore.Mvc;
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
    public class QuanhuyenController : Controller
    {
        private readonly IQuanhuyenService _QuanHuyenService;
        private readonly DB_Context _Context;
        public QuanhuyenController(IQuanhuyenService QuanHuyenService, DB_Context context)
        {
            _QuanHuyenService = QuanHuyenService;
            _Context = context;
        }
        public IActionResult Index()
        {
            return View(_QuanHuyenService.GetAllQuanHuyen());
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        public async Task<IActionResult> Create(Quan_Huyen Qh)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(Qh), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:5000/api/quanhuyen", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {


            return View(_QuanHuyenService.GetQuanHuyen(id));
        }
        public async Task<IActionResult> Edit(int id, Quan_Huyen qh)
        {
            Quan_Huyen Qh = new Quan_Huyen();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(qh), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:5000/api/quanhuyen/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        Qh = JsonConvert.DeserializeObject<Quan_Huyen>(apiReult);
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
