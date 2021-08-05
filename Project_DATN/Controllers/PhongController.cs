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
    public class PhongController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PhongRequest> prequest = new List<PhongRequest>();
            using (var client = new HttpClient())
            {
                using (var response =await client.GetAsync("http://localhost:28656/api/qlphong"))
                {
                    var apiresult =await response.Content.ReadAsStringAsync();
                    prequest = JsonConvert.DeserializeObject<List<PhongRequest>>(apiresult);
                }
            }
            return View(prequest);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePhong()
        {
            ViewBag.lstloaiphong =new SelectList(await DataProvider.Ins.DB.LoaiPhongs.ToListAsync(), "ID", "tenLoaiPhong");

            ViewBag.lsttang = new SelectList(await DataProvider.Ins.DB.Laus.ToListAsync(), "ID", "tenLau");
            ViewBag.lstCoso = new SelectList(await DataProvider.Ins.DB.CoSos.ToListAsync(), "ID", "tenCoSo");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhong(PhongRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePhong", request);
            }
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var response =await client.PostAsync("http://localhost:28656/api/qlphong",content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.StatusCode = response.StatusCode;
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
        public async Task<IActionResult> UpdatePhong(int id)
        {
            PhongRequest phong = new PhongRequest();
            using (var client =new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:28656/api/qlphong/"+id))
                {
                    var apiresult =await response.Content.ReadAsStringAsync();
                    phong = JsonConvert.DeserializeObject<PhongRequest>(apiresult);
                }
            }

            ViewBag.lstloaiphong = new SelectList(await DataProvider.Ins.DB.LoaiPhongs.ToListAsync(), "ID", "tenLoaiPhong");

            ViewBag.lsttang = new SelectList(await DataProvider.Ins.DB.Laus.ToListAsync(), "ID", "tenLau");
            ViewBag.lstCoso = new SelectList(await DataProvider.Ins.DB.CoSos.ToListAsync(), "ID", "tenCoSo");

            return View(phong);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhong(PhongRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdatePhong",request);
            }
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PutAsync("http://localhost:28656/api/qlphong/" + request.Id, content))
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeletePhong(int id)
        {
            PhongRequest st = new PhongRequest();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/qlphong/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {

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
