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
    public class CosoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CosoRequest> lstcoso = new List<CosoRequest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28656/api/coso/"))
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    lstcoso = JsonConvert.DeserializeObject<List<CosoRequest>>(apiresult);
                }
            }
            return View(lstcoso);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCoso()
        {
            var selectQuanHuyen = await DataProvider.Ins.DB.QuanHuyens.ToListAsync();
            var selectTinhTP = await DataProvider.Ins.DB.TinhThanhPhos.ToListAsync();

            List<TaiKhoanNganHangRequest> lstcs = new List<TaiKhoanNganHangRequest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28656/api/taikhoannganhang"))
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    lstcs = JsonConvert.DeserializeObject<List<TaiKhoanNganHangRequest>>(apiresult);
                }
            }

            var selects = new SelectList(lstcs, "Id", "soTaiKhoan");
            var selectsQH = new SelectList(selectQuanHuyen, "ID", "tenQuan_Huyen");
            var selectsTinh = new SelectList(selectTinhTP, "ID", "tenTinh");
            ViewBag.ListTKNH = selects;
            ViewBag.ListQH = selectsQH;
            ViewBag.ListTinh = selectsTinh;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoso(CosoRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCoso",mod);
            }

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PostAsync("http://localhost:28656/api/coso", content))
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
        public async Task<IActionResult> UpdateCoso(int id)
        {
            CosoRequest st = new CosoRequest();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.GetAsync("http://localhost:28656/api/coso/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<CosoRequest>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return View(st);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoso(CosoRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCoso",mod);
            }
            CosoRequest request = new CosoRequest()
            {
                email = mod.email,
                hoTenNguoiDaiDien = mod.hoTenNguoiDaiDien,
                ID_Quan_Huyen = mod.ID_Quan_Huyen,
                ID_Tinh_TP = mod.ID_Tinh_TP,
                ID_TK_NH = mod.ID_TK_NH,
                ghiChu = mod.ghiChu,
                solau = mod.solau,
                tenCoSo = mod.tenCoSo,
                maSoThue = mod.maSoThue,
                soDienThoai = mod.soDienThoai,
                trangThai = mod.trangThai
            };

            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PutAsync("http://localhost:28656/api/coso/" + mod.Id, content))
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeleteCoso(int id)
        {
            CosoRequest st = new CosoRequest();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/coso/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<CosoRequest>(apiReult);
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
