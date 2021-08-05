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
    public class Tinh_ThanhPhoController : Controller
    {
        private readonly ITinhThanhPhoService _tinhThanhPhoService;
        private readonly DB_Context _Context;
        public Tinh_ThanhPhoController(ITinhThanhPhoService TinhThanhPhoService, DB_Context context)
        {
            _tinhThanhPhoService = TinhThanhPhoService;
            _Context = context;
        }
        public IActionResult Index()
        {
            return View(_tinhThanhPhoService.GetAllTinhThanhPho());
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }
        public async Task<IActionResult> Create(Tinh_ThanhPho Tp)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(Tp), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:5000/api/tinhthanhpho", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

           
            return View(_tinhThanhPhoService.GetTinhThanhPho(id));
        }
        public async Task<IActionResult> Edit(int id, Tinh_ThanhPho tp)
        {
            Tinh_ThanhPho Tp = new Tinh_ThanhPho();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(tp), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:5000/api/tinhthanhpho/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        Tp = JsonConvert.DeserializeObject<Tinh_ThanhPho>(apiReult);
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
