using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_DATN.Services.DataProviders;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class LauController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<LauRequest> lstlau = new List<LauRequest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28656/api/lau"))
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    lstlau = JsonConvert.DeserializeObject<List<LauRequest>>(apiresult);
                }
            }
            return View(lstlau);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLau()
        {
            ViewBag.lstCoso = new SelectList(await DataProvider.Ins.DB.CoSos.ToListAsync(), "ID", "tenCoSo");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLau(LauRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateLau", mod);
            }

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PostAsync("http://localhost:28656/api/lau", content))
                {

                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLau(int id)
        {
            LauRequest request = new LauRequest();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var res = await httpClients.GetAsync("http://localhost:28656/api/lau/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        request = JsonConvert.DeserializeObject<LauRequest>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
                ViewBag.lstCoso = new SelectList(await DataProvider.Ins.DB.CoSos.ToListAsync(), "ID", "tenCoSo");
                return View(request);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLau(LauRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateLau",mod);
            }
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PutAsync("http://localhost:28656/api/lau/" + mod.Id, content))
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeleteLau(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:28656/api/lau/" + id))
                {
                }

            }
            return RedirectToAction("Index");
        }
    }
}
