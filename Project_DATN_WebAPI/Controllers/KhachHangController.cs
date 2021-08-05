using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        // GET: api/<KhachHangController>
        private readonly IKhachHangService _khachHang;
        private readonly DB_Context _Context;
        // GET: api/<HoaDonsController>
        public KhachHangController(IKhachHangService khachHang, DB_Context context)
        {
            _Context = context;
            _khachHang = khachHang;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KhachHang>> GetKhachHangs()
        {
            return _khachHang.GetAllKhachHang();
        }

        // GET api/<HoaDonsController>/5
        [HttpGet("{id}")]
        public ActionResult<KhachHang> GetKhachHang(int id)
        {
            return _khachHang.GetKhachHang(id);
        }

        // POST api/<HoaDonsController>
        [HttpPost]
        public ActionResult<KhachHang> Post(KhachHang khach)
        {
            _khachHang.AddKhachHang(khach);
            return CreatedAtAction("GetKhachHang", khach);
        }

        // PUT api/<HoaDonsController>/5
        [HttpPut("{id}")]
        public ActionResult<KhachHang> Put(int id, KhachHang khachHang)
        {
            _khachHang.EditKhachHang(khachHang);
            return RedirectToAction("GetKhachHangs");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<ChiTiet_HoaDon> Delete(int id)
        {
            _khachHang.DeleteKhachHang(id);
            return RedirectToAction("GetKhachHang");
        }
    }
}
