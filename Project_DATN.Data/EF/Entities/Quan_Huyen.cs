﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class Quan_Huyen
    {
        public int ID { get; set; }

        public string tenQuan_Huyen { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<CoSo> ICCoSo { get; set; }
    }
}
