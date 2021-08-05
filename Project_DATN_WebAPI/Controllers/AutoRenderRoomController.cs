using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoRenderRoomController : ControllerBase
    {
        private readonly IAutoRenderRoomService _autoService;
        public AutoRenderRoomController(IAutoRenderRoomService autoService)
        {
            _autoService = autoService;
        }

        [HttpPost]
        public async Task<IActionResult> AutoRenderRoomApi([FromBody] CosoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CoSo cs = new CoSo()
            {
                ID = request.Id,
                tenCoSo = request.tenCoSo,
                hoTenNguoiDaiDien = request.hoTenNguoiDaiDien,
                maSoThue = request.maSoThue,
                soDienThoai = request.soDienThoai,
                email = request.email,
                ghiChu = request.ghiChu,
                trangThai = "Trống",
                ID_Quan_Huyen = request.ID_Quan_Huyen,
                ID_Tinh_TP = request.ID_Tinh_TP,
                ID_TK_NH = request.ID_TK_NH
            };

            var result = await _autoService.AutoRenderRoom(cs, request.kyhieuphong, request.solau, request.soluongphong, request.idloaiphong);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
