using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosoController : ControllerBase
    {
        private readonly ICosoService _cocoService;
        private readonly IAutoRenderRoomService _autoService;
        public CosoController(ICosoService cocoService, IAutoRenderRoomService autoService)
        {
            _cocoService = cocoService;
            _autoService = autoService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cocoService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCosoById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _cocoService.GetCosoById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CosoRequest request)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CoSo cs = new CoSo()
            {
                tenCoSo = request.tenCoSo,
                hoTenNguoiDaiDien = request.hoTenNguoiDaiDien,
                maSoThue = request.maSoThue,
                soDienThoai = request.soDienThoai,
                email = request.email,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai,
                ID_Quan_Huyen = request.ID_Quan_Huyen,
                ID_Tinh_TP = request.ID_Tinh_TP,
                ID_TK_NH = request.ID_TK_NH,
            };

            var result = await _autoService.CreateCoso(cs, request.solau);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CosoRequest request)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest();
            }

            CoSo cs = new CoSo()
            {
                tenCoSo = request.tenCoSo,
                hoTenNguoiDaiDien = request.hoTenNguoiDaiDien,
                maSoThue = request.maSoThue,
                soDienThoai = request.soDienThoai,
                email = request.email,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai,
            };

            var result = await _cocoService.UpdateCoso(id, cs);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = await _cocoService.RemoveCoso(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
