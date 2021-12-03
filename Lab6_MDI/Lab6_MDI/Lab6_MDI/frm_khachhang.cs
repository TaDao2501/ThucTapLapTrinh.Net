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

namespace Lab6_MDI
{
    public partial class frm_khachhang : Form
    {
        public frm_khachhang()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_khachhang_Load(object sender, EventArgs e)
        {
            try
            {
                //Bước 1:Chuỗi kết nối
                string ketnoi = @"Data Source=desktop-d27iibq\sqlexpress;Initial Catalog=quanlybanhang;Integrated Security=True";
                //string ketnoi = "Data Source=(local);Initial Catalog=qlbanhang;Integrated Security=True";
                //string ketnoi = "server=(local);database=quanlybanhang;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(ketnoi);
                //Bước 2: Mở kết nối
                sqlcon.Open();
                //Bước 3: Câu lệnh truy vấn
                string sql;
                sql = "select * from tblKhachHang";
                //Bước 4: Tạo cầu nối dữ liệu
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                //Bước 5: Tạo dataset
                DataSet ds = new DataSet();
                //Bước 6: Điền dữ liệu
                sqlda.Fill(ds);
                //Bước 7: Hiển thị dữ liệu ra lưới
                dataGridView1.DataSource = ds.Tables[0];
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được cở sở dữ liệu, Bạn hãy kiểm tra","Thông báo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtht.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbogt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                //Bước 1:Chuỗi kết nối
                //string ketnoi = "Data Source=(local);Initial Catalog=qlbanhang;Integrated Security=True";
                string ketnoi = @"Data Source=desktop-d27iibq\sqlexpress;Initial Catalog=quanlybanhang;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(ketnoi);
                //Bước 2: Mở kết nối
                sqlcon.Open();
                //Bước 3: Câu lệnh truy vấn
                string sql;
                sql = "insert into tblKhachHang values('"+txtmakh.Text+"',N'"+txtht.Text+"',N'"+cbogt.Text+"',N'"+txtdc.Text+"',N'"+txtdt.Text+"')";
                //Bước 4: Thực thi sql
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                int kq=sqlcom.ExecuteNonQuery();
                if (kq>0)
                {
                    MessageBox.Show("Bạn đã thêm thành công Khách hàng vào CSDL","Thêm dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frm_khachhang_Load(sender, e);
                }
       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có mã khách hàng này rồi, Bạn hãy kiểm tra lại", "Thông báo");
                MessageBox.Show("Thông báo lỗi:" + ex.Message);
            }
        }
        private static string hopnhap(string tb, string tieude, ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 100);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = tieude;

            //  System.Windows.Forms.TextBox textBox = new TextBox();
            System.Windows.Forms.Label lblnd = new Label();
            lblnd.Size = new System.Drawing.Size(size.Width - 20, 23);
            lblnd.Location = new System.Drawing.Point(5, 5);
            lblnd.Text = tb;
            inputBox.Controls.Add(lblnd);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 50, 43);
            textBox.Location = new System.Drawing.Point(25, 35);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);


            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&Ok";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 120, 59);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 100, 59);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            //  return result;
            return input;
        }
        private void btntk_Click(object sender, EventArgs e)
        {
            try
            {
                //Bước 1:Chuỗi kết nối
                //string ketnoi = "Data Source=(local);Initial Catalog=qlbanhang;Integrated Security=True";
                string ketnoi = @"Data Source=desktop-d27iibq\sqlexpress;Initial Catalog=quanlybanhang;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(ketnoi);
                //Bước 2: Mở kết nối
                sqlcon.Open();
                //Bước 3: Câu lệnh truy vấn và điều kiện
                string sql;
                string input = "";
                string thongbao;
                thongbao = "Bạn hãy nhập giá trị tìm kiếm";
                //  MessageBox.Show("Kết quả:" + hopnhap(thongbao, "Nhập liệu", ref input));
                input = hopnhap(thongbao, "Nhập liệu", ref input);
                sql = "select * from tblKhachHang where makh='"+input+"'";
                //Bước 4: Tạo cầu nối dữ liệu
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                //Bước 5: Tạo dataset
                DataSet ds = new DataSet();
                //Bước 6: Điền dữ liệu
                sqlda.Fill(ds);
                //Bước 7: Hiển thị dữ liệu ra lưới
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được cở sở dữ liệu, Bạn hãy kiểm tra", "Thông báo");
            }

        }
    }
}
