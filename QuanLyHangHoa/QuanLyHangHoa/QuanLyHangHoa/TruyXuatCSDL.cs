using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// nhớ thêm 2 thứ viện sau
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHangHoa
{
   static class TruyXuatCSDL
    {
        private static string DiaChi =
            @"Data Source=DESKTOP-HAOQEME\SQLEXPRESS;Initial Catalog=dbQLHH;Integrated Security=True";
        private static SqlConnection TaoDuongOng()
        {
            return new SqlConnection(DiaChi);
        }

        // lấy ra một bảng dữ liệu (table)
        public static DataTable LayBang(string sql)
        {
            SqlConnection OngHut = TaoDuongOng();
            OngHut.Open();
            SqlDataAdapter MayBom = new SqlDataAdapter(sql, OngHut);
            DataTable ThungChua = new DataTable();
            MayBom.Fill(ThungChua);
            MayBom.Dispose();
            OngHut.Dispose();
            return ThungChua;
        }
        // phương thức thêm sửa xóa
        public static void ThemSuaXoa(string sql)
        {
            SqlConnection OngHut = TaoDuongOng();
            OngHut.Open();
            SqlCommand Lenh = new SqlCommand(sql, OngHut);
            Lenh.ExecuteNonQuery();
            Lenh.Dispose();
            OngHut.Dispose();
        }

    }
}
