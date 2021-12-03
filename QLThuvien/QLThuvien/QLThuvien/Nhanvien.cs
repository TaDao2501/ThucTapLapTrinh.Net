using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLThuvien
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
            string strSQL = "Select Manv, Hotennv, Ngaysinh,Diachi,Dienthoai, Tenbangcap From Nhanvien N, BANGCAP B Where N.Mabangcap=B.Mabangcap";
        DataTable dt = db.Execute(strSQL); //Goi phuongthuc truy xuat du lieu
        return dt;
        }
        public DataTable LayBangcap()
        {
            string strSQL = "Select * from BANGCAP"; DataTable dt =db.Execute(strSQL); return dt;
        }
        public void XoaNhanVien(string index_nv)
        {
            string sql = "Delete from NHANVIEN where Manv = " + index_nv;db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void ThemNhanVien(string ten, string ngaysinh,string diachi, string dienthoai, string index_bc)
        {
            string sql = string.Format("Insert Into NHANVIEN Values(N'{0}', '{1}', N'{2}', '{3}',{4})", ten, ngaysinh, diachi, dienthoai, index_bc); 
            db.ExecuteNonQuery(sql);
        }
        //Cập nhật nhân viên
        public void CapNhatNhanVien(string index_nv, string hoten,string ngaysinh, string diachi, string dienthoai, string index_bc)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update NHANVIEN set Hotennv = N'{0}', Ngaysinh = '{1}', Diachi =N'{2}', Dienthoai = '{3}', Mabangcap = { 4} whereManv = { 5 }", hoten, ngaysinh, diachi,dienthoai,index_bc, index_nv);
            db.ExecuteNonQuery(str);
        }


    }
}
