using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class TaiKhoanNganHangController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            List<TaiKhoanNganHangRequest> lstTikhoan = new List<TaiKhoanNganHangRequest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28656/api/taikhoannganhang"))
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    lstTikhoan = JsonConvert.DeserializeObject<List<TaiKhoanNganHangRequest>>(apiresult);
                }
            }
            return View(lstTikhoan);
        }

        [HttpGet]
        public IActionResult CreateTKNH()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTKNH(TaiKhoanNganHangRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTKNH",mod);
            }

            TaiKhoanNganHangRequest request = new TaiKhoanNganHangRequest()
            {
                diaChiCN = mod.diaChiCN,ghiChu = mod.ghiChu,hoTenChuTKNH = mod.hoTenChuTKNH,
                soTaiKhoan = mod.soTaiKhoan, tenChiNhanh = mod.tenChiNhanh,tenNganHang = mod.tenNganHang,trangThai = mod.trangThai
            };

            using (var client =new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                     "application/json");
                using (var response = await client.PostAsync("http://localhost:28656/api/taikhoannganhang", content))
                {

                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTKNH(int id)
        {
            TaiKhoanNganHangRequest request = new TaiKhoanNganHangRequest();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var res = await httpClients.GetAsync("http://localhost:28656/api/taikhoannganhang/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        request = JsonConvert.DeserializeObject<TaiKhoanNganHangRequest>(apiReult);
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
        public async Task<IActionResult> UpdateTKNH(TaiKhoanNganHangRequest mod)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateTKNH", mod);
            }
            TaiKhoanNganHangRequest request = new TaiKhoanNganHangRequest()
            {
                diaChiCN = mod.diaChiCN,
                ghiChu = mod.ghiChu,
                hoTenChuTKNH = mod.hoTenChuTKNH,
                soTaiKhoan = mod.soTaiKhoan,
                tenChiNhanh = mod.tenChiNhanh,
                tenNganHang = mod.tenNganHang,
                trangThai = mod.trangThai
            };
            using (var client  = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                     "application/json");
                using (var response =await client.PutAsync("http://localhost:28656/api/taikhoannganhang/" + mod.Id,content))
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeleteTKNH(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:28656/api/taikhoannganhang/" + id))
                {
                    
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}
