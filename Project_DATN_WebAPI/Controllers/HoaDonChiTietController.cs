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
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IHoaDonChiTietService _hoaDon;
        private readonly DB_Context _Context;
        // GET: api/<HoaDonsController>
        public HoaDonChiTietController(IHoaDonChiTietService hoaDon, DB_Context context)
        {
            _Context = context;
            _hoaDon = hoaDon;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ChiTiet_HoaDon>> GetHoaDonChiTiets()
        {
            return _Context.ChiTietHoaDons.ToList();
        }

        // GET api/<HoaDonsController>/5
        [HttpGet("{id}")]
        public ActionResult<ChiTiet_HoaDon> GetHoaDonChiTiet(int id)
        {
            return _hoaDon.GetChiTietHoaDon(id);
        }

        // POST api/<HoaDonsController>
        [HttpPost]
        public ActionResult<ChiTiet_HoaDon> Post(ChiTiet_HoaDon hoaDon)
        {
            _hoaDon.AddChiTietHoaDon(hoaDon);
            return CreatedAtAction("GetHoaDonChiTiets", hoaDon);
        }

        // PUT api/<HoaDonsController>/5
        [HttpPut("{id}")]
        public ActionResult<ChiTiet_HoaDon> Put(int id, ChiTiet_HoaDon hoaDon)
        {
            _hoaDon.EditChiTietHoaDon(hoaDon);
            return RedirectToAction("GetHoaDonChiTiets");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<ChiTiet_HoaDon> Delete(int id)
        {
            _hoaDon.DeleteChiTietHoaDon(id);
            return RedirectToAction("GetHoaDonChiTiets");
        }
    }
}
