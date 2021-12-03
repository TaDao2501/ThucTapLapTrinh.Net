using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_DKMoRong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtso1.Text = "";
            txtso2.Clear();
            txtkq.Clear();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string soa = txtso1.Text; 
            string sob = txtso2.Text; 
            if (soa.Length == 0 || sob.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đủ cả 2 ô số nguyên A và B để có thể thực hiện phép tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float a = float.Parse(soa);
                float b = float.Parse(sob);
                float result = a + b; 
                txtkq.Text = result.ToString();
               
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
