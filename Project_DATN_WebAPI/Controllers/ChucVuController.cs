using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly DB_Context _dbContext;

        public ChucVuController(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/ChucVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project_DATN.Data.EF.Entities.ChucVu>>> GetAllChucVu()
        {
            var chucVu = await _dbContext.ChucVus.Select(x => new ChucVu()
            {
                ID = x.ID,
                TaiKhoan = x.TaiKhoan,
                PhongBan = x.PhongBan,
                tenChucVu = x.tenChucVu,
                ngayBatDauApDung = x.ngayBatDauApDung,
                denNgay = x.denNgay,
                ghiChu = x.ghiChu,
                trangThai = x.trangThai,
            }).ToListAsync();
            return chucVu;
        }

        // GET: api/ChucVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project_DATN.Data.EF.Entities.ChucVu>> GetChucVu(int id)
        {
            var chucVu = await _dbContext.ChucVus.Where(x=>x.ID==id).Select(x=>new ChucVu()
            {
                TaiKhoan = x.TaiKhoan,
                PhongBan = x.PhongBan,
                tenChucVu = x.tenChucVu,
                ngayBatDauApDung = x.ngayBatDauApDung,
                denNgay = x.denNgay,
                ghiChu = x.ghiChu,
                trangThai = x.trangThai
            }).SingleAsync();

            if (chucVu == null)
            {
                return NotFound();
            }

            return chucVu;
        }

        // PUT: api/ChucVu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucVu(int id, Project_DATN.Data.EF.Entities.ChucVu chucVu)
        {
            if (id != chucVu.ID)
            {
                return BadRequest();
            }

            _dbContext.Entry(chucVu).State = EntityState.Modified;

            try
            {
                _dbContext.ChucVus.Update(chucVu);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Project_DATN.Data.EF.Entities.ChucVu>> PostChucVu(Project_DATN.Data.EF.Entities.ChucVu chucVu)
        {
            _dbContext.ChucVus.Add(chucVu);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetChucVu", new { id = chucVu.ID }, chucVu);
        }

        // DELETE: api/ChucVu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project_DATN.Data.EF.Entities.ChucVu>> DeleteChucVu(int id)
        {
            var chucVu = await _dbContext.ChucVus.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            _dbContext.ChucVus.Remove(chucVu);
            await _dbContext.SaveChangesAsync();

            return chucVu;
        }

        private bool ChucVuExists(int id)
        {
            return _dbContext.ChucVus.Any(e => e.ID == id);
        }
    }
}
