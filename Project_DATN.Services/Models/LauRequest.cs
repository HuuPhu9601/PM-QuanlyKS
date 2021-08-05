using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Models
{
    public class LauRequest
    {
        public int Id { get; set; }
        public int ID_CoSo { get; set; }
        public string tenLau { get; set; }
        public int SoLuongPhong { get; set; }
        public int soLuongLau { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string tencoso { get; set; }
    }
}
