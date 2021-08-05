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
    public class LoaiDichVuController : Controller
    {
        private readonly ILoaiDichVuService _loaiDichVu;
        private readonly DB_Context _Context;
        public LoaiDichVuController(ILoaiDichVuService loaiDichVu, DB_Context context)
        {
            _Context = context;
            _loaiDichVu = loaiDichVu;
        }
        public ActionResult<IEnumerable<LoaiDichVu>> GetloaiDichVu()
        {
            return _Context.LoaiDichVus.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<LoaiDichVu> GetloaiDichVu(int id)
        {
            return _loaiDichVu.GetLoaiDichVu(id);
        }
        [HttpPost]
        public ActionResult<LoaiDichVu> Post(LoaiDichVu ldv)
        {
            _loaiDichVu.AddLoaiDichVu(ldv);
            return CreatedAtAction("GetLoaiDichVu", ldv);
        }
        [HttpPut("{id}")]
        public ActionResult<LoaiDichVu> Put(int id, LoaiDichVu dichVu)
        {
            _loaiDichVu.EditLoaiDichVu(dichVu);
            return RedirectToAction("GetLoaiDichVu");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<LoaiDichVu> Delete(int id)
        {
            _loaiDichVu.DeleteLoaiDichVu(id);
            return RedirectToAction("GetDichVu");
        }
    }
}
