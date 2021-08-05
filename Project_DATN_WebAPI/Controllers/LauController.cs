using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LauController : ControllerBase
    {
        private readonly ILauService _lauService;
        public LauController(ILauService lauService)
        {
            _lauService = lauService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _lauService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLauByID([FromRoute]int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _lauService.GetLauById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LauRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Lau lau = new Lau()
            {
                tenLau = request.tenLau,
                soLuongLau = request.SoLuongPhong,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai,
                ID_CoSo = request.ID_CoSo
            };
            var result = await _lauService.CraeteLau(lau);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] LauRequest request)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest();
            }

            Lau lau = new Lau()
            {
                tenLau = request.tenLau,
                soLuongLau = request.soLuongLau,
                ghiChu = request.ghiChu,
                trangThai = request.trangThai,
                ID_CoSo = request.ID_CoSo
            };
            var result = await _lauService.UpdateLau(id,lau);
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
            var result = await _lauService.RemoveLau(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
