using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenHanController : ControllerBase
    {

        private IQuyenHanService _iQuyenHanService;
        private DB_Context _context;

        public QuyenHanController(IQuyenHanService iQuyenHanService, DB_Context context)
        {
            _iQuyenHanService = iQuyenHanService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuyenHan>> GetAllQuyenHan()
        {
            return _iQuyenHanService.GetAllQuyenHan();
        }

        [HttpGet("{id}")]
        public ActionResult<QuyenHan> GetQuyenHan(int id)
        {
            return _iQuyenHanService.FindById(id);
        }

        [HttpPost]
        public ActionResult<QuyenHan> Post([FromBody]QuyenHan qh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _iQuyenHanService.Add(qh);
            return CreatedAtAction("GetQuyenHan", qh);
        }
        // PUT api/<TaiKhoanController>/5
        [HttpPut("{id}")]
        public ActionResult<TaiKhoan> Put(int id, QuyenHan qh)
        {
            _iQuyenHanService.Edit(qh);
            return RedirectToAction("GetQuyenHan", id);
        }

        [HttpDelete("{id}")]
        public ActionResult<TaiKhoan> ApiDelete(int id)
        {
            _iQuyenHanService.Delete(id);
            return RedirectToAction("GetQuyenHan");
        }
    }
}
    

