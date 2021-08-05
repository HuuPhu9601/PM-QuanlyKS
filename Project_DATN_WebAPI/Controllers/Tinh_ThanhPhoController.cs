using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN_WebAPI.Controllers
{
    public class Tinh_ThanhPhoController : ControllerBase
    {
        private readonly ITinhThanhPhoService _tinhThanhPho;
        private readonly DB_Context _Context;
        public Tinh_ThanhPhoController(ITinhThanhPhoService TinhThanhPho, DB_Context context)
        {
            _Context = context;
            _tinhThanhPho = TinhThanhPho;
        }
        public ActionResult<IEnumerable<Tinh_ThanhPho>> GetTinhThanhPho()
        {
            return _Context.TinhThanhPhos.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Tinh_ThanhPho> GetTinhThanhPho(int id)
        {
            return _tinhThanhPho.GetTinhThanhPho(id);
        }
        [HttpPost]
        public ActionResult<Tinh_ThanhPho> Post(Tinh_ThanhPho Tp)
        {
            _tinhThanhPho.AddTinhThanhPho(Tp);
            return CreatedAtAction("GetTinhThanhPho", Tp);
        }
        [HttpPut("{id}")]
        public ActionResult<Tinh_ThanhPho> Put(int id, Tinh_ThanhPho Tp)
        {
            _tinhThanhPho.EditTinhThanhPho(Tp);
            return RedirectToAction("GetTinhThanhPho");
        }

    }
}
