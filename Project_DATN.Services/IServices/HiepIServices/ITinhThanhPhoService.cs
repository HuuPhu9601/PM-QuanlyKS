using Microsoft.AspNetCore.Mvc;
using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices.HiepIServices
{
    public interface ITinhThanhPhoService
    {
        public Tinh_ThanhPho GetTinhThanhPho(int IdTinhThanhPho);
        public List<Tinh_ThanhPho> GetAllTinhThanhPho();
        public bool AddTinhThanhPho(Tinh_ThanhPho tp);
        public bool EditTinhThanhPho(Tinh_ThanhPho tp);
     
    }
}
