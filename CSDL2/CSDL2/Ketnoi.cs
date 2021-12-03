using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL2
{
    class Ketnoi
    {
        private static string DiaChi = @"Data Source=DESKTOP-D27IIBQ\SQLEXPRESS;Initial Catalog=QLHH;Integrated Security=True";
        public static SqlConnection TaoDuongOng()
        {
            return new SqlConnection(DiaChi);
        }

        public static DataTable LayBang(string sql)
        {
            SqlConnection Conn = TaoDuongOng();
            Conn.Open();
            DataTable Da = new DataTable();
            SqlDataAdapter Rs = new SqlDataAdapter(sql, Conn);
            Rs.Fill(Da);
            Rs.Dispose();
            Conn.Dispose();
            return Da;
        }
        public static void ThemSuaXoa(string sql)
        {
            SqlConnection Conn = TaoDuongOng();
            Conn.Open();
            SqlCommand Lenh = new SqlCommand(sql, Conn);
            Lenh.ExecuteNonQuery();
            Lenh.Dispose();
            Conn.Dispose();
        }
    }
}
