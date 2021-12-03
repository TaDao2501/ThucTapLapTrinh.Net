using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                //Bước 1:Chuỗi kết nối
                string ketnoi = @"Data Source=DESKTOP-D27IIBQ\SQLEXPRESS;Initial Catalog=QLThuvien;Integrated Security=True";
                //string ketnoi = "Data Source=(local);Initial Catalog=qlbanhang;Integrated Security=True";
                //string ketnoi = "server=(local);database=quanlybanhang;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(ketnoi);
                //Bước 2: Mở kết nối
                sqlcon.Open();
                //Bước 3: Câu lệnh truy vấn
                string sql;
                sql = "select * from NHANVIEN";
                //Bước 4: Tạo cầu nối dữ liệu
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                //Bước 5: Tạo dataset
                DataSet ds = new DataSet();
                //Bước 6: Điền dữ liệu
                sqlda.Fill(ds);
                //Bước 7: Hiển thị dữ liệu ra lưới
                dgv1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được cở sở dữ liệu, Bạn hãy kiểm tra", "Thông báo");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Bước 1:Chuỗi kết nối
                //string ketnoi = "Data Source=(local);Initial Catalog=qlbanhang;Integrated Security=True";
                string ketnoi = @"Data Source=DESKTOP-D27IIBQ\SQLEXPRESS;Initial Catalog=QLThuvien;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(ketnoi);
                //Bước 2: Mở kết nối
                sqlcon.Open();
                //Bước 3: Câu lệnh truy vấn
                string sql;
                sql = "insert into NHANVIEN values('" + txtHoten.Text + "',N'" + date.Text + "',N'" + txtDT.Text + "',N'" + txtDC.Text + "')";
                //Bước 4: Thực thi sql
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                int kq = sqlcom.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Bạn đã thêm thành công Khách hàng vào CSDL", "Thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có mã khách hàng này rồi, Bạn hãy kiểm tra lại", "Thông báo");
                MessageBox.Show("Thông báo lỗi:" + ex.Message);
            }
        }
    }
}
