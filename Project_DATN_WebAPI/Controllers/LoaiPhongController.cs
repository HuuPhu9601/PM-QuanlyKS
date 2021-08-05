using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly ILoaiPhongService _loaiphongService;
        public LoaiPhongController(ILoaiPhongService loaiphongService)
        {
            _loaiphongService = loaiphongService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _loaiphongService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoaiPhongRequest loaiPhong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LoaiPhong lp = new LoaiPhong()
            {
                donGiaQuaDem = loaiPhong.donGiaQuaDem,
                donGiaTheoGio = loaiPhong.donGiaTheoGio,
                donGiaTheoNgay = loaiPhong.donGiaTheoNgay,
                ghiChu = loaiPhong.ghiChu,
                tenLoaiPhong = loaiPhong.tenLoaiPhong,
                soNguoi = loaiPhong.soNguoi,
                trangThai = loaiPhong.trangThai,
            };
            var result = await _loaiphongService.CraeteLoaiPhong(lp);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiPhongByID([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest(id);
            }
            var result = await _loaiphongService.GetLoaiPhongById(id);
            return Ok(result);
        }

        [HttpPut("{loaiphongid}")]
        public async Task<IActionResult> Update([FromRoute] int loaiphongid, [FromBody] LoaiPhongRequest request)
        {

            if (!ModelState.IsValid || loaiphongid == 0)
            {
                return BadRequest();
            }
            LoaiPhong lp = new LoaiPhong()
            {
                donGiaQuaDem = request.donGiaQuaDem,
                donGiaTheoGio = request.donGiaTheoGio,
                donGiaTheoNgay = request.donGiaTheoNgay,
                ghiChu = request.ghiChu,
                tenLoaiPhong = request.tenLoaiPhong,
                soNguoi = request.soNguoi,
                trangThai = request.trangThai,
            };

            var result = await _loaiphongService.UpdateLoaiPhong(loaiphongid, lp);
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
            var result = await _loaiphongService.RemoveLoaiPhong(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddQRcode([FromRoute] int id,[FromBody] LoaiPhongRequest req)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest();
            }
            LoaiPhong lp = new LoaiPhong()
            {
                fields1 = req.fields1,
                ID = id
            };
            var result = await _loaiphongService.AddQRcode(lp);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
