using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void clean()
        {
            txtma.Text = "";
            txtten.Text = "";
            txttk.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            dgvLop.DataSource = Ketnoi.LayBang(
                "select * from tblLop");
            dgvLop.Columns[0].HeaderText = "Mã SV";
            dgvLop.Columns[1].HeaderText = "Họ Tên";

            dgvLop.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgvLop.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLop.CurrentRow != null)
            {
                txtma.Text = dgvLop.CurrentRow.Cells[0].Value.ToString();
                txtten.Text = dgvLop.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuly.Them(txtma.Text, txtten.Text);
            string sql = "insert into tblLop values(N'" +
                txtma + "', N'" +
                txtten + "')";
            Ketnoi.ThemSuaXoa(sql);
            dgvLop.DataSource = Ketnoi.LayBang("select * from tblLop");
            clean();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tblLop SET Ten = N'" +
               txtten.Text + "' where Ma =N'" +
               txtma.Text + "' ";
            Ketnoi.ThemSuaXoa(sql);
            dgvLop.DataSource = Ketnoi.LayBang(
               "select * from tblLop");
            clean();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from tblLop where Ma =N'" +
                txtma.Text + "'";
            Ketnoi.ThemSuaXoa(sql);
            dgvLop.DataSource = Ketnoi.LayBang(
             "select * from tblLop");
            MessageBox.Show("Đã xóa!", "Thống báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            clean();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txttk.Text.Trim() == "")
                sql = "select * from tblLop";
            else
                sql = "select * from tblLop where Ma like N'" +
                   txttk.Text + "%'";

            dgvLop.DataSource = Ketnoi.LayBang(sql);
            clean();
        }
    }
}
