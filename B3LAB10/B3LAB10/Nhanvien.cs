using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace B3LAB10
{
    class Nhanvien
    {
        Database db;
        public Nhanvien()
        {
            db = new Database();
        }
        public DataTable LayDSNhanvien()
        {
            string strSQL = "Select Manv, Hotennv, Ngaysinh,Diachi,Dienthoai, Mabangcap From NHANVIEN N, BANGCAP B Where N.Mabangcap=B.Mabangcap";
            DataTable dt = db.Execute(strSQL); //Goi phuong thuc truy xuat du lieu
            return dt;
        }
        public DataTable LayBangcap()
        {
            string strSQL = "Select * from BANGCAP"; DataTable dt = db.Execute(strSQL); return dt;
        }
    }
}
