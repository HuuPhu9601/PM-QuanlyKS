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
    public class AutoRenderController : Controller
    {
        [HttpGet("/AutoRender/AutoRenderRoom/{id}")]
        public async Task<IActionResult> AutoRenderRoom(int id)
        {
            ViewBag.ListLoaiPhong = new SelectList(await DataProvider.Ins.DB.LoaiPhongs.ToListAsync(), "ID", "tenLoaiPhong");

            //var getIdcoso = DataProvider.Ins.DB.CoSos.Where(x => x.tenCoSo == tenCoSo).Single().ID;
            var getListTang = DataProvider.Ins.DB.Laus.Where(x => x.ID_CoSo == id).ToList();

            CosoRequest request = new CosoRequest()
            {
                solau = getListTang.Count,
                Id = id,
            };
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> AutoRenderRoom(CosoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("AutoRenderRoom", request);
            }

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var resource = await client.PostAsync("http://localhost:28656/api/autorenderroom", content);

                if (resource.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiReult = await resource.Content.ReadAsStringAsync();
                    request = JsonConvert.DeserializeObject<CosoRequest>(apiReult);
                }
                else
                {
                    ViewBag.StatusCode = resource.StatusCode;
                }

            }
            return RedirectToAction("Index", "Phong");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCoso()
        {
            ViewBag.ListTinh = new SelectList(await DataProvider.Ins.DB.TinhThanhPhos.ToListAsync(), "ID", "tenTinh");
            ViewBag.ListQuanHuyen = new SelectList(await DataProvider.Ins.DB.QuanHuyens.ToListAsync(), "ID", "tenQuan_Huyen");
            ViewBag.ListTKNH = new SelectList(await DataProvider.Ins.DB.TaiKhoanNganHangs.ToListAsync(), "ID", "soTaiKhoan");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoso(CosoRequest req)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCoso", req);
            }

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("http://localhost:28656/api/coso", content))
                {
                    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    string apiReult = await response.Content.ReadAsStringAsync();
                    //    req = JsonConvert.DeserializeObject<CosoRequest>(apiReult);
                    //}
                    //else
                    //{
                    //    ViewBag.StatusCode = response.StatusCode;
                    //}
                }
            }
            var getIdcoso = await DataProvider.Ins.DB.CoSos.Where(x => x.tenCoSo == req.tenCoSo).SingleAsync();
            return RedirectToAction("AutoRenderRoom", "AutoRender", new { id = getIdcoso.ID });
        }
    }
}
