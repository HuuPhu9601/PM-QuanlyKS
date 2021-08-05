using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLPhongController : ControllerBase
    {
        private readonly IPhongService _phongService;
        public QLPhongController(IPhongService phongService)
        {
            _phongService = phongService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _phongService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _phongService.GetPhongById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhongRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Phong p = new Phong()
            {
                ID_LoaiPhong = request.ID_LoaiPhong,
                ID_CoSo = request.ID_CoSo,
                ID_Lau = request.ID_Lau,
                tenPhong = request.tenPhong,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai
            };

            var result = await _phongService.CraetePhong(p);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PhongRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Phong p = new Phong()
            {
                ID_LoaiPhong = request.ID_LoaiPhong,
                ID_CoSo = request.ID_CoSo,
                ID_Lau = request.ID_Lau,
                tenPhong = request.tenPhong,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai
            };

            var result = await _phongService.UpdatePhong(id, p);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _phongService.RemovePhong(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
