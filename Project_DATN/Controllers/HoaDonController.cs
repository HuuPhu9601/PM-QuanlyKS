using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonService _hoaDonService;
        public readonly DB_Context _context;
        public readonly IBookingServices _bookingServices;
        public HoaDonController(IHoaDonService hoaDonService,DB_Context context, IBookingServices bookingServices)
        {
            _context = context;
            _hoaDonService = hoaDonService;
            _bookingServices = bookingServices;
        }
        private byte[] ObjectToByteArray(HoaDon hoa)
        {
            if (hoa == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, hoa);

            return ms.ToArray();
        }
        [NonAction]
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
       
        public IActionResult Index(int page = 1)
        {
            var model = _hoaDonService.Paging(page);
            ViewBag.Pages = model.pages;
            ViewBag.Page = model.page;
           return View(model.hoaDons);
        }
        [HttpGet]
        public IActionResult SearchByDate(DateTime to, DateTime from, int page = 1)
        {
            var model = _hoaDonService.Paging(page);
            ViewBag.Pages = model.pages;
            ViewBag.Page = model.page;
            return View("Index",_hoaDonService.getHoaDonByDate(to,from));
        }
        [HttpGet]
        public IActionResult QrCode(int id)
        {
            ViewBag.KhachHang = new SelectList(_context.KhachHangs, "ID", "CCCD");
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.GiaoDich = new SelectList(_context.GiaoDichs, "ID", "loaiHinhThucThanhToan");
            ViewBag.LoaiPhong = new SelectList(_context.LoaiPhongs, "ID", "tenLoaiPhong");
            ViewBag.Phong = new SelectList(_context.Phongs, "ID", "tenPhong");
            ViewBag.GiaoCa = new SelectList(_context.GiaoCas, "ID", "caLam");
            return View(_hoaDonService.GetHoaDon(id));
        }
        [HttpPost]
        public IActionResult QrCode(HoaDon hoa)
        {
            
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(hoa.ToString(), QRCodeGenerator.ECCLevel.Q);
            
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytesCode(qrCodeImage));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.KhachHang = new SelectList(_context.KhachHangs, "ID", "CCCD");
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.GiaoDich = new SelectList(_context.GiaoDichs, "ID", "loaiHinhThucThanhToan");
            ViewBag.LoaiPhong = new SelectList(_context.LoaiPhongs, "ID", "tenLoaiPhong");
            ViewBag.Phong = new SelectList(_context.Phongs, "ID", "tenPhong");
            ViewBag.GiaoCa = new SelectList(_context.GiaoCas, "ID", "caLam");
            return View();
        }
        public async Task<IActionResult> Create(HoaDon hoaDon)
        {
            using (var httpClients = new HttpClient())
            {
                StringContent comtent = new StringContent(JsonConvert.SerializeObject(hoaDon), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PostAsync("http://localhost:28656/api/hoadons", comtent))
                {

                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.KhachHang = new SelectList(_context.KhachHangs, "ID", "CCCD");
            ViewBag.TaiKhoan = new SelectList(_context.TaiKhoans, "ID", "tenTaiKhoan");
            ViewBag.GiaoDich = new SelectList(_context.GiaoDichs, "ID", "loaiHinhThucThanhToan");
            ViewBag.LoaiPhong = new SelectList(_context.LoaiPhongs, "ID", "tenLoaiPhong");
            ViewBag.Phong = new SelectList(_context.Phongs, "ID", "tenPhong");
            ViewBag.GiaoCa = new SelectList(_context.GiaoCas, "ID", "caLam");
            return View(_hoaDonService.GetHoaDon(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,HoaDon hoaDon)
        {
            HoaDon st = new HoaDon();
            using (var httpClients = new HttpClient())
            {
                StringContent comparer = new StringContent(JsonConvert.SerializeObject(hoaDon), Encoding.UTF8, "application/json");
                using (var res = await httpClients.PutAsync("http://localhost:28656/api/hoadons/" + id, comparer))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<HoaDon>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HoaDon st = new HoaDon();
            using (var httpClients = new HttpClient())
            {
                using (var res = await httpClients.DeleteAsync("http://localhost:28656/api/hoadons/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReult = await res.Content.ReadAsStringAsync();
                        st = JsonConvert.DeserializeObject<HoaDon>(apiReult);
                    }
                    else
                    {
                        ViewBag.StatusCode = res.StatusCode;
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Hoadon");
            dt.Columns.AddRange(new DataColumn[20] { new DataColumn("Mã hóa đơn"),
                                        new DataColumn("Họ tên khách"),
                                        new DataColumn("Người lập"),
                                        new DataColumn("Hình Thức Thanh Toán"),
                                        new DataColumn("Phòng"),
                                        new DataColumn("Ca làm"),
                                        new DataColumn("Loại phòng"),
                                        new DataColumn("Ngày lập hợp đồng"),
                                        new DataColumn("Nhận phòng"),
                                        new DataColumn("Trả phòng"),
                                        new DataColumn("Thời gian ở"),
                                        new DataColumn("Tiền khách trả"),
                                        new DataColumn("Trả lại"),
                                        new DataColumn("Giảm trừ"),
                                        new DataColumn("Cọc tiền"),
                                        new DataColumn("Phụ thu"),
                                        new DataColumn("VAT"),
                                        new DataColumn("Chiết khẩu"),
                                        new DataColumn("Giảm giá"),
                                        new DataColumn("Trạng thái"),});

            var customers = from customer in this._context.HoaDons.Take(10)
                            select customer;

            foreach (var Hoadon in customers)
            {
                dt.Rows.Add(Hoadon.maHoaDon, Hoadon.KhachHang,Hoadon.TaiKhoan,Hoadon.GiaoDich, Hoadon.Phong,Hoadon.GiaoCa, Hoadon.LoaiPhong,Hoadon.ngayGioLap, Hoadon.ngayGioNhanPhong, Hoadon.ngayGioTraPhong, Hoadon.thoiGianThue, Hoadon.tienKhachDua, Hoadon.tienTraLai, Hoadon.giamTru, Hoadon.cocTien, Hoadon.phuThu, Hoadon.thueVAT, Hoadon.chietKhau, Hoadon.giamGia, Hoadon.trangThai);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Hóa Đơn.xlsx");
                }
            }
        }
    }

}

    