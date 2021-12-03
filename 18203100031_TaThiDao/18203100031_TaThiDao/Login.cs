using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _18203100031_TaThiDao
{
    public partial class Login : Form
        //Họ Tên : Tạ Thị Đào
        //Ngày sinh : 25/01/2000
        //MSV: 18203100031
    {
        public Login()
        {
            InitializeComponent();
        }
        public SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-D27IIBQ\SQLEXPRESS;Initial Catalog=TaThiDao_qlcb;Integrated Security=True");

        private void chkhienan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhienan.Checked == true)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassWord.Text;
            if (user == "")
            {
                MessageBox.Show("Bạn phải nhập username vào!", "Đăng nhập");
                txtUserName.Focus();
            }
            else
                if (pass == "")
                {
                    MessageBox.Show("Bạn phải nhập Password vào!", "Đăng nhập");
                    txtPassWord.Focus();
                }
                else
                {
                    try
                    {
                        sqlcon.Open();

                        string sql = "SELECT * FROM dangnhap WHERE username = '" + user + "' AND password = '" + pass + "'";
                        SqlCommand cmd = new SqlCommand(sql, sqlcon);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read.Read() == true)
                        {
                            MessageBox.Show("Bạn đăng nhập thành công!", "Đăng nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            Canbo f = new Canbo();
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản chưa có, hoặc bạn nhập sai Username hoặc Password", "Đăng nhập");
                            txtUserName.Text = "";
                            txtPassWord.Text = "";
                            txtUserName.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassWord.Text = "";
            txtUserName.Clear();
            txtUserName.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
