using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly DB_Context _context;
        private ITaiKhoanService _iTaiKhoanService;
        public TaiKhoanController(DB_Context context, ITaiKhoanService iTaiKhoanService)
        {
            _context = context;
            _iTaiKhoanService = iTaiKhoanService;
        }
        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoan()
        {
            return _iTaiKhoanService.GetAllTaiKhoan();
        }

        // GET: api/TaiKhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(int id)
        {
            var taiKhoan = _iTaiKhoanService.FindById(id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            return taiKhoan;
        }

        // PUT: api/TaiKhoans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(int id, TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.ID)
            {
                return BadRequest();
            }

            try
            {
                taiKhoan.ID = id;
                await _iTaiKhoanService.Edit(taiKhoan);
                return RedirectToAction("GetTaiKhoan", id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaiKhoans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> PostTaiKhoan(TaiKhoan taiKhoan)
        {
            await _iTaiKhoanService.Add(taiKhoan);

            return CreatedAtAction("GetTaiKhoan", new { id = taiKhoan.ID }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaiKhoan>> DeleteTaiKhoan(int id)
        {
            var taiKhoan =_iTaiKhoanService.FindById(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            await _iTaiKhoanService.Delete(id);

            return taiKhoan;
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoans.Any(e => e.ID == id);
        }
    }
}
