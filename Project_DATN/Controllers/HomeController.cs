using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project_DATN.Services.IServices.PhuIServices;

namespace Project_DATN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhongService _phongService;
        public HomeController(ILogger<HomeController> logger , IPhongService phongService)
        {
            _logger = logger;
            _phongService = phongService;
        }

        public IActionResult Index()
        {
            //var lstEmptyRooms = _phongService.GetAll().Result.FirstOrDefault(x=>x.trangThai == "Trống");
            // return View(lstEmptyRooms);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
