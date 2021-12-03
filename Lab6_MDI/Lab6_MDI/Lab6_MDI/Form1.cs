using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Lab6_MDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn vừa kích vào save!"); 
        }

        private void bảnQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string ma =Microsoft.VisualBasic.Interaction.InputBox("Nhập mã khách hàng cần tìm kiếm", "Tìm kiếm");
            string input = "";
            string thongbao;
            thongbao = "Bạn hãy nhập giá trị tìm kiếm";
            MessageBox.Show("Kết quả:"+hopnhap(thongbao,"Nhập liệu",ref input));

        }
        //  private static DialogResult ShowInputDialog(ref string input)
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

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_khachhang frm = new frm_khachhang();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
