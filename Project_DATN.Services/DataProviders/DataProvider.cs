using Project_DATN.Data.EF.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.DataProviders
{
    public class DataProvider
    {
        public static DataProvider _ins;

        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }

        public DB_Context DB { get; set; }

        public DataProvider()
        {
            DB = new DB_Context();
        }
    }
}
