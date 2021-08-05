using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.ManhIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class BookingRoomController : Controller
    {
        public readonly DB_Context _context;
        public readonly IHoaDonService _hoaDonService;
        public readonly ICheckInCheckOutService _checkInCheckOutService;
        public readonly IBookingServices _bookingServices;
        public BookingRoomController(DB_Context context, IHoaDonService hoaDonService,
            ICheckInCheckOutService checkInCheckOutService,IBookingServices bookingServices)
        {
            _context = context;
            _hoaDonService = hoaDonService;
            _bookingServices = bookingServices;
            _checkInCheckOutService = checkInCheckOutService;
        }
        [HttpGet]
        public IActionResult Index(int idPhong)
        {
            ViewBag.HoaDon = _context.HoaDons.Where(x => x.ID_Phong == idPhong).Select(x => x.ID);
            ViewBag.Phong = _context.Phongs.Include(x => x.Lau).Include(y => y.CoSo).Include(x => x.LoaiPhong).ToList();
            ViewBag.Tang = _context.Laus.Include(x=>x.CoSo).ToList();
            ViewBag.CoSo = _context.CoSos.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult CheckIn(int idPhong)
        {
            var tenPhong = _context.Phongs.Where(x => x.ID == idPhong).SingleOrDefault().tenPhong;
            var loaiPhong = _context.Phongs.Where(x => x.ID == idPhong).FirstOrDefault().ID_LoaiPhong;
            var giaPhong = _context.LoaiPhongs.Where(x => x.ID == loaiPhong).FirstOrDefault();
            HoaDon hd = new HoaDon() { ID_Phong = idPhong };
            Phong phong = (from n in _context.Phongs where n.ID == idPhong select n).FirstOrDefault();
            ViewBag.IdPhong = hd.ID_Phong;
            ViewBag.TenPhong = tenPhong;
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.GiaoDich = new SelectList(_context.GiaoDichs, "ID", "loaiHinhThucThanhToan");
            ViewBag.LoaiPhong = new SelectList(_context.LoaiPhongs, "ID", "tenLoaiPhong");
            ViewBag.GiaoCa = new SelectList(_context.GiaoCas, "ID", "caLam");
            ViewBag.GiaPhong = giaPhong;
           
            return View(hd);
        }
        [HttpPost]
        public IActionResult CheckIn(HoaDon hd)
        {
            //_checkInCheckOutService.CheckIn(hd, hd.ID_Phong);
            _bookingServices.nhanPhong(hd,hd.ID_Phong);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CheckOut(int id, int idPhong)
        {
            var updateThoiGianThue = (from n in _context.HoaDons where n.ID_Phong == idPhong&&n.trangThai=="Chưa Thanh Toán"  && n.Phong.trangThai == "Có Người" select n).FirstOrDefault();
            //_checkInCheckOutService.UpdateThoiGianTraPhong(updeteThoiGianThue);
            _bookingServices.traPhong(updateThoiGianThue);
            var hd = (from n in _context.HoaDons where n.ID_Phong == idPhong&& n.trangThai=="Chưa Thanh Toán" && n.Phong.trangThai == "Có Người" select n).FirstOrDefault();
            return View(hd);
        }
        public IActionResult CheckOut(HoaDon hoaDon)
        {
            //_checkInCheckOutService.CheckOut(hoaDon);
            _bookingServices.thanhToanHoaDon(hoaDon);
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddDichVu(int idPhong)
        {
            var CTHD = _context.ChiTietHoaDons.ToList();
            ViewBag.DichVu = new SelectList(_context.DichVus, "ID", "tenDichVu");
            var idHoaDon = (from n in _context.HoaDons where n.ID_Phong == idPhong && n.trangThai == "Chưa Thanh Toán" && n.Phong.trangThai == "Có Người" select n.ID).FirstOrDefault();
            ChiTiet_HoaDon cthd = new ChiTiet_HoaDon() { ID_HoaDon = idHoaDon };
            var dichVu = (from n in _context.ChiTietHoaDons where n.ID_HoaDon == idHoaDon select n).FirstOrDefault();
            return View(cthd);
        }
        public IActionResult AddDichVu(ChiTiet_HoaDon cthd)
        {
            _checkInCheckOutService.AddDichVu(cthd);
                return RedirectToAction("Index");
        }

        //[HttpGet("BookingRoom/ThuePhong/{idPhong}")]
        //public IActionResult ThuePhong([FromRoute] int idPhong)
        //{
        //    var tenPhong = _context.Phongs.Where(x => x.ID == idPhong).SingleOrDefault().tenPhong;
        //    ViewBag.TenPhong = tenPhong;
        //    return View();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="khach"></param>
        ///// <param name="idPhong"></param>
        ///// <returns></returns>
        //[HttpPost("BookingRoom/ThuePhong/{idPhong}")]
        //public IActionResult ThuePhong(KhachHang khach, int idPhong)
        //{
        //    _checkInCheckOutService.ThuePhong(khach,idPhong);
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult ChuyenPhong(int idPhong)
        {
            List<Phong> phong = _context.Phongs.Where(x=>x.trangThai=="Trống").ToList();
            ViewBag.ListPhong = phong;
             ViewBag.Tang = _context.Laus.Include(x=>x.CoSo).ToList();
            var getPhong = (from n in _context.HoaDons where n.ID_Phong == idPhong && n.trangThai == "Chưa Thanh Toán" select n).FirstOrDefault();
            return View(getPhong);
        }
        //[HttpPost("BookingRoom/ChuyenPhong/{idPhong}")]
        public IActionResult ChuyenPhong(HoaDon hoa,int idPhong)
        {
            _bookingServices.ChuyenPhong(hoa, idPhong);
            return RedirectToAction("Index");
        }
    }
}
