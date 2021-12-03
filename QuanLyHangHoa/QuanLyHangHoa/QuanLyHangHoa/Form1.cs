using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHangHoa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = 
                TruyXuatCSDL.LayBang("select * from tbHangHoa");
            dgv1.Columns[0].HeaderText = "Mã Hàng";
            dgv1.Columns[1].HeaderText = "Tên Hàng";
            dgv1.Columns[2].HeaderText = "Đơn Vị";
            dgv1.Columns[3].HeaderText = "Đơn Giá";
            dgv1.Columns[4].HeaderText = "Số Lượng";
            // thiết kập đông rộng cột
            dgv1.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv1.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv1.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv1.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv1.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

       
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbHangHoa values(N'"+
                txtMaHang.Text+"', N'"+
                txtTenHang.Text+"', N'"+
                txtDonVi.Text +"', "+
                txtDonGia.Text+", "+
                txtSoLuong.Text+")";

            TruyXuatCSDL.ThemSuaXoa(sql);

            dgv1.DataSource =
                TruyXuatCSDL.LayBang("select * from tbHangHoa");

            MessageBox.Show("Đã thêm bản ghi!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.CurrentRow!=null)
            {
                txtMaHang.Text =
                    dgv1.CurrentRow.Cells[0].Value.ToString();
                txtTenHang.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                txtDonVi.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txtDonGia.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
                txtSoLuong.Text = dgv1.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update tbHangHoa set TenHang =N'"+
               txtTenHang.Text+"', DonVi = N'"+
               txtDonVi.Text+"', DonGia="+
               txtDonGia.Text+", SoLuong = "+
               txtSoLuong.Text+" where MaHang=N'"+
               txtMaHang.Text+"'";
            MessageBox.Show(sql);

            TruyXuatCSDL.ThemSuaXoa(sql);

            dgv1.DataSource =
                TruyXuatCSDL.LayBang("select * from tbHangHoa");

            MessageBox.Show("Đã sửa bản ghi!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from tbHangHoa where MaHang =N'"+
                txtMaHang.Text+"'";

            TruyXuatCSDL.ThemSuaXoa(sql);

            dgv1.DataSource =
                TruyXuatCSDL.LayBang("select * from tbHangHoa");

            MessageBox.Show("Đã xóa bản ghi!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát PM?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq==DialogResult.Yes)
            Application.Exit();
        }
    }
}
