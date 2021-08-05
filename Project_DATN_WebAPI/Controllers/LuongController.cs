using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_DATN.Services.IServices.HiepIServices;
namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongController : ControllerBase
    {
        private readonly ILuongService _Luong;
        private readonly DB_Context _Context;
        public LuongController(ILuongService luong, DB_Context context)
        {
            _Context = context;
            _Luong = luong;
        }
        public ActionResult<IEnumerable<Luong>> GetLuong()
        {
            return _Context.Luongs.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Luong> GetLuong(int id)
        {
            return _Luong.GetLuong(id);
        }
        [HttpPost]
        public ActionResult<Luong> Post(Luong lg)
        {
            _Luong.AddLuong(lg);
            return CreatedAtAction("GetLuong", lg);
        }
        [HttpPut("{id}")]
        public ActionResult<Luong> Put(int id, Luong luong)
        {
            _Luong.EditLuong(luong);
            return RedirectToAction("GetLuong");
        }

        // DELETE api/<HoaDonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<LoaiDichVu> Delete(int id)
        {
            _Luong.DeleteLuong(id);
            return RedirectToAction("GetLuong");
        }
    }
}
