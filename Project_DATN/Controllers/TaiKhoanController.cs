using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanService _iTaiKhoanService;
        private DB_Context _context;
        private IWebHostEnvironment _hostEnvironment;

        public TaiKhoanController(ITaiKhoanService iTaiKhoanService, DB_Context context, IWebHostEnvironment hostEnvironment)
        {
            _iTaiKhoanService = iTaiKhoanService;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            try
            {
                var lstTk = _iTaiKhoanService.GetAllTaiKhoan();
                return View(lstTk);
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
            ViewBag.ID_CoSo = new SelectList(_context.CoSos, "ID", "tenCoSo");
            ViewBag.ID_PhongBan = new SelectList(_context.PhongBans, "ID", "tenPhongBan");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaiKhoan taiKhoan)
        {
            ViewBag.ID_CoSo = new SelectList(_context.CoSos, "ID", "tenCoSo");
            ViewBag.ID_PhongBan = new SelectList(_context.PhongBans, "ID", "tenPhongBan");
            if (ModelState.IsValid)
            {
                if (_iTaiKhoanService.GetAllTaiKhoan().Any(x => x.email == taiKhoan.email))
                {
                    TempData["Error"] = "<script>alert('Email đã được sử dụng. vui lòng chọn Email khác')</script>";
        
                    return View(taiKhoan);
                }
                if (_iTaiKhoanService.GetAllTaiKhoan().Any(x => x.email == taiKhoan.email))
                {
                    TempData["Error"] = "<script>alert('Tên tài khoản đã được sử dụng. Vui lòng chọn tên tài khoản khác')</script>";
                 return View(taiKhoan);
                }
                if (taiKhoan.AvatarFile != null)
                {
                   taiKhoan.anhDaiDien = await SaveImage(taiKhoan);
                    await _iTaiKhoanService.Add(taiKhoan);
                    return RedirectToAction(nameof(Index));
                }
                taiKhoan.anhDaiDien = null;
                await _iTaiKhoanService.Add(taiKhoan);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ID_CoSo = new SelectList(_context.CoSos, "ID", "tenCoSo");
            ViewBag.ID_PhongBan = new SelectList(_context.PhongBans, "ID", "tenPhongBan");
            return View(taiKhoan);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ID_CoSo = new SelectList(_context.CoSos, "ID", "tenCoSo");
            ViewBag.ID_PhongBan = new SelectList(_context.PhongBans, "ID", "tenPhongBan");
            var tk = _iTaiKhoanService.FindById(id);
            return View(tk);
        }
        //Action edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                if (taiKhoan.AvatarFile != null)
                {
                   taiKhoan.anhDaiDien = await SaveImage(taiKhoan);
                    await _iTaiKhoanService.Edit(taiKhoan);
                    return RedirectToAction(nameof(Index));
                }
                var avt =_iTaiKhoanService.GetAllTaiKhoan().FirstOrDefault(x => x.ID == taiKhoan.ID)?.anhDaiDien;
                taiKhoan.anhDaiDien = avt;
               await _iTaiKhoanService.Edit(taiKhoan);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ID_CoSo = new SelectList(_context.CoSos, "ID", "tenCoSo");
            ViewBag.ID_PhongBan = new SelectList(_context.PhongBans, "ID", "tenPhongBan");
            return View(taiKhoan);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tk = _iTaiKhoanService.FindById(id);
            return View(tk);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTk(int id)
        {
            var tk = _iTaiKhoanService.GetAllTaiKhoan().Find(x => x.ID == id);
            var imgPath = Path.Combine(_hostEnvironment.WebRootPath, "images", tk.anhDaiDien);
            if (System.IO.File.Exists(imgPath))
                System.IO.File.Delete(imgPath);
            await _iTaiKhoanService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<string> SaveImage(TaiKhoan taiKhoan)
        {
            var wwwRootPath = _hostEnvironment.WebRootPath;
            var fileName = taiKhoan.tenTaiKhoan;
            var extension = Path.GetExtension(taiKhoan.AvatarFile.FileName);
            fileName += extension;
            var path = Path.Combine(wwwRootPath + "/images", fileName);
            taiKhoan.anhDaiDien = fileName;
            await using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            await taiKhoan.AvatarFile.CopyToAsync(fileStream);
            return fileName;
        }
    }
}
