using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace KNCSDL
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-D27IIBQ\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True");


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

                        string sql = "SELECT * FROM login WHERE username = '" + user + "' AND password = '" + pass + "'";
                        SqlCommand cmd = new SqlCommand(sql, sqlcon);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read.Read() == true)
                        {
                            MessageBox.Show("Bạn đăng nhập thành công!", "Đăng nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            Form1 f = new Form1();
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassWord.Text = "";
            txtUserName.Clear();
            txtUserName.Focus();
        }
    }
}
