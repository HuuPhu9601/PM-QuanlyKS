using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.DataProviders;
using Project_DATN.Services.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class LoaiPhongController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<LoaiPhongRequest> lstlau = new List<LoaiPhongRequest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28656/api/loaiphong"))
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    lstlau = JsonConvert.DeserializeObject<List<LoaiPhongRequest>>(apiresult);
                }
            }
            return View(lstlau);
        }

        [HttpGet]
        public IActionResult CreateLoaiPhong()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateQRcode(int id)
        {
            LoaiPhongRequest request = new LoaiPhongRequest();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var res = await httpClients.GetAsync("http://localhost:28656/api/loaiphong/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        request = JsonConvert.DeserializeObject<LoaiPhongRequest>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }

                return View(request);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateQRcode(LoaiPhongRequest mod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode("http://localhost:5000/loaiPhong/ShowQRDetail/" + mod.Id,QRCodeGenerator.ECCLevel.Q);
                QRCode qR = new QRCode(qRCodeData);
                using (Bitmap bm = qR.GetGraphic(20))
                {
                    bm.Save(ms, ImageFormat.Png);
                    ViewBag.QRcode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

                var uplp =await DataProvider.Ins.DB.LoaiPhongs.FindAsync(mod.Id);
                if (uplp == null)
                {
                    return View();
                }
                uplp.fields1 = mod.fields1;
                DataProvider.Ins.DB.LoaiPhongs.Update(uplp);
                await DataProvider.Ins.DB.SaveChangesAsync();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowQRDetail(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("CreateQRcode");
            }
            var qrDeatail =await DataProvider.Ins.DB.LoaiPhongs.FindAsync(id);
            if (qrDeatail == null)
            {
                return RedirectToAction("CreateQRcode");
            }

            ViewBag.QRDetail = qrDeatail.fields1;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLoaiPhong(LoaiPhongRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateLoaiPhong", mod);
            }

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PostAsync("http://localhost:28656/api/loaiphong", content))
                {

                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLoaiPhong(int id)
        {
            LoaiPhongRequest request = new LoaiPhongRequest();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var res = await httpClients.GetAsync("http://localhost:28656/api/loaiphong/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        request = JsonConvert.DeserializeObject<LoaiPhongRequest>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }

                return View(request);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLoaiPhong(LoaiPhongRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateLoaiPhong", mod);
            }
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PutAsync("http://localhost:28656/api/loaiphong/" + mod.Id, content))
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeleteLoaiPhong(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:28656/api/loaiphong/" + id))
                {
                    //string apiResult = await response.Content.ReadAsStringAsync();
                    //lstStu = JsonConvert.DeserializeObject<student>(apiResult);
                }

            }
            return RedirectToAction("Index");
        }
    }
}
