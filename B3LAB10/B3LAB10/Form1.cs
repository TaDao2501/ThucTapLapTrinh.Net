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


namespace B3LAB10
{
    public partial class Form1 : Form
    {
        Nhanvien nv = new Nhanvien();


        void HienthiNhanvien()
        {
            DataTable dt = nv.LayDSNhanvien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv1.Columns[0].HeaderText = "MÃ NV";
                dgv1.Columns[1].HeaderText = "HỌ TÊN";
                dgv1.Columns[2].HeaderText = "NGÀY SINH";
                dgv1.Columns[3].HeaderText = "ĐỊA CHỈ";
                dgv1.Columns[4].HeaderText = "ĐIỆN THOẠI";
                dgv1.Columns[5].HeaderText = "MÃ BẰNG CẤP";
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienthiNhanvien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
