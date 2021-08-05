using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly IDichVuService _dichVu;
        private readonly DB_Context _Context;
        public DichVuController(IDichVuService dichVu, DB_Context context)
        {
            _Context = context;
            _dichVu = dichVu;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DichVu>> GetDichVu()
        {
            return _Context.DichVus.ToList();
        }

      
        [HttpGet("{id}")]
        public ActionResult<DichVu> GetDichVu(int id)
        {
            return _dichVu.GetDichVu(id);
        }
       
        [HttpPost]
        public ActionResult<DichVu> Post(DichVu dv)
        {
            _dichVu.AddDichVu(dv);
            return CreatedAtAction("GetDichVu", dv);
        }
        [HttpPut("{id}")]
        public ActionResult<DichVu> Put(int id, DichVu dichVu)
        {
            _dichVu.EditDichVu(dichVu);
            return RedirectToAction("GetDichVu");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<DichVu> Delete(int id)
        {
            _dichVu.DeleteDichVu(id);
            return RedirectToAction("GetDichVu");
        }
    }
}

