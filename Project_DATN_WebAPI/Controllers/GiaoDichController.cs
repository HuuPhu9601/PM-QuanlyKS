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
    public class GiaoDichController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly IGiaoDichService _giaoDich;
        private readonly DB_Context _Context;
        // GET: api/<HoaDonsController>
        public GiaoDichController(IGiaoDichService giaoDich, DB_Context context)
        {
            _Context = context;
            _giaoDich = giaoDich;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GiaoDich>> GetGiaoDichs()
        {
            return _giaoDich.GetAllGiaoDich();
        }

        // GET api/<HoaDonsController>/5
        [HttpGet("{id}")]
        public ActionResult<GiaoDich> GetGiaoDich(int id)
        {
            return _giaoDich.GetGiaoDich(id);
        }

        // POST api/<HoaDonsController>
        [HttpPost]
        public ActionResult<KhachHang> Post(GiaoDich giaoDich)
        {
            _giaoDich.AddGiaoDich(giaoDich);
            return CreatedAtAction("GetGiaoDichs", giaoDich);
        }

        // PUT api/<HoaDonsController>/5
        [HttpPut("{id}")]
        public ActionResult<GiaoDich> Put(int id, GiaoDich giaoDich)
        {
            _giaoDich.EditGiaoDich(giaoDich);
            return RedirectToAction("GetGiaoDichs");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GiaoDich> Delete(int id)
        {
            _giaoDich.DeleteGiaoDich(id);
            return RedirectToAction("GetKhachHang");
        }
    }
}
