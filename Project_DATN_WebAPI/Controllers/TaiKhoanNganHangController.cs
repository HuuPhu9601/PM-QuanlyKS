using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanNganHangController : ControllerBase
    {
        private readonly TaiKhoanNganHangIService _TknhService;
        public TaiKhoanNganHangController(TaiKhoanNganHangIService TknhService)
        {
            _TknhService = TknhService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _TknhService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTKNHByID([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _TknhService.GetTKById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaiKhoanNganHangRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            TaiKhoan_NganHang tknh = new TaiKhoan_NganHang()
            {
                hoTenChuTKNH = request.hoTenChuTKNH,
                soTaiKhoan = request.soTaiKhoan,
                tenNganHang = request.tenNganHang,
                tenChiNhanh = request.tenChiNhanh,
                diaChiCN = request.diaChiCN,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai
            };

            var result = await _TknhService.CraeteTKNH(tknh);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TaiKhoanNganHangRequest request)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest();
            }
            TaiKhoan_NganHang tknh = new TaiKhoan_NganHang()
            {
                hoTenChuTKNH = request.hoTenChuTKNH,
                soTaiKhoan = request.soTaiKhoan,
                tenNganHang = request.tenNganHang,
                tenChiNhanh = request.tenChiNhanh,
                diaChiCN = request.diaChiCN,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai
            };

            var result = await _TknhService.UpdateTKNH(id, tknh);
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
            var result = await _TknhService.RemoveTKNH(id);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok();
        }
    }
}
