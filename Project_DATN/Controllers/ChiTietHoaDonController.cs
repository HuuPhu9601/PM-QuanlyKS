using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Project_DATN.Data.EF.DBContext;
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
    public class ChiTietHoaDonController : Controller
    {
        private readonly IHoaDonChiTietService _hoaDonChiTietService;
        private readonly DB_Context _Context;
        public ChiTietHoaDonController(IHoaDonChiTietService hoaDonChiTietService, DB_Context context)
        {
            _hoaDonChiTietService = hoaDonChiTietService;
            _Context = context;
        }
        public IActionResult Index()
        {
            return View(_hoaDonChiTietService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HoaDon = new SelectList(_Context.HoaDons, "ID", "maHoaDon");
            ViewBag.DichVu = new SelectList(_Context.DichVus, "ID", "tenDichVu");
            return View();
        }
        public async Task<IActionResult> Create(ChiTiet_HoaDon chiTietHoaDon)
        {
            
                using (var httpClients = new HttpClient())
                {
                    StringContent comtent = new StringContent(JsonConvert.SerializeObject(chiTietHoaDon), Encoding.UTF8, "application/json");
                    using (var res = await httpClients.PostAsync("http://localhost:28656/api/khachhang", comtent))
                    {

                    }
                }

                return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.HoaDon = new SelectList(_Context.HoaDons, "ID", "maHoaDon");
            ViewBag.DichVu = new SelectList(_Context.DichVus, "ID", "tenDichVu");
            return View(_hoaDonChiTietService.GetChiTietHoaDon(id));
        }
        public async Task<IActionResult> Edit(int id,ChiTiet_HoaDon chiTietHoaDon)
        {
            ChiTiet_HoaDon st = new ChiTiet_HoaDon();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(chiTietHoaDon), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:28656/api/khachhang/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<ChiTiet_HoaDon>(apiReult);
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
            ChiTiet_HoaDon st = new ChiTiet_HoaDon();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/hoadonchitiet/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<ChiTiet_HoaDon>(apiReult);
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
