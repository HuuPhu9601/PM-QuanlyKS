using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System.Collections.Generic;
using System.Linq;
namespace Project_DATN_WebAPI.Controllers
{
    [Route("api/[controller]")]//đã có 
    [ApiController]
    public class QuanHuyenController : ControllerBase
    {
        private readonly IQuanhuyenService _quanhuyen;
        private readonly DB_Context _Context;
        public QuanHuyenController(IQuanhuyenService QuanHuyen, DB_Context context)
        {
            _Context = context;
            _quanhuyen = QuanHuyen;
        }
        public ActionResult<IEnumerable<Quan_Huyen>> GetQuanHuyen()
        {
            return Ok(_Context.QuanHuyens.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<Quan_Huyen> GetQuanHuyen(int id)
        {
            return Ok( _quanhuyen.GetQuanHuyen(id));
        }
        [HttpPost]
        public ActionResult<Quan_Huyen> Post(Quan_Huyen Qh)
        {
            _quanhuyen.AddQuanHuyen(Qh);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult<Quan_Huyen> Put(int id, Quan_Huyen Qh)
        {
            _quanhuyen.EditQuanHuyen(Qh);
            return Ok();
        }

    }
}