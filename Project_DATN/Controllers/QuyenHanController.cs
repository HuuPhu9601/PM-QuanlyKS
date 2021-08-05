using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN.Controllers
{
    public class QuyenHanController : Controller
    {
        private IQuyenHanService _iQuyenHanService;
        public QuyenHanController(IQuyenHanService iQuyenHanService)
        {
            _iQuyenHanService = iQuyenHanService;
        }
        public IActionResult Index()
        {
            try
            {
                var listqh = _iQuyenHanService.GetAllQuyenHan();
                return View(listqh);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuyenHan qh)
        {
            if (!ModelState.IsValid)
            {
                return View(qh);
            }

            if (qh.ID == 0)
            {
                _iQuyenHanService.Add(qh);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var qh = _iQuyenHanService.FindById(id);
            return View(qh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuyenHan qh)
        {
            if (!ModelState.IsValid)
            {
                return View(qh);
            }

            _iQuyenHanService.Edit(qh);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var qh = _iQuyenHanService.FindById(id);
            return View(qh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQh(int id)
        {
            _iQuyenHanService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
