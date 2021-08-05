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
    public class HoaDonsController : ControllerBase
    {
        private readonly IHoaDonService _hoaDon;
        private readonly DB_Context _Context;
        // GET: api/<HoaDonsController>
        public HoaDonsController(IHoaDonService hoaDon,DB_Context context)
        {
            _Context = context;
            _hoaDon = hoaDon;
        }
        [HttpGet]
        public ActionResult<IEnumerable<HoaDon>> GetHoaDons()
        {
            return _Context.HoaDons.ToList();
        }

        // GET api/<HoaDonsController>/5
        [HttpGet("{id}")]
        public ActionResult<HoaDon> GetHoaDon(int id)
        {
            return _hoaDon.GetHoaDon(id);
        }

        // POST api/<HoaDonsController>
        [HttpPost]
        public ActionResult<HoaDon> Post(HoaDon hoaDon,int idPhong)
        {
            _hoaDon.AddHoaDon(hoaDon,idPhong);
            return CreatedAtAction("GetHoaDons", hoaDon);
        }

        // PUT api/<HoaDonsController>/5
        [HttpPut("{id}")]
        public ActionResult<HoaDon> Put(int id, HoaDon hoaDon)
        {
            _hoaDon.EditHoaDon(hoaDon);
           return RedirectToAction("GetHoaDons");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<HoaDon> Delete(int id)
        {
            _hoaDon.DeleteHoaDon(id);
            return RedirectToAction("GetHoaDons");
        }
    }
}
