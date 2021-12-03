using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuvien
{
    public partial class frmNhanVien : Form
    {

        Nhanvien nv = new Nhanvien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        void HienthiNhanvien()
        {


            //int i = 0;

            //foreach (DataRow row in dt.Rows)

            //{
            //    lsvNhanVien.FullRowSelect = true;
            //    lsvNhanVien.Items.Add(row["HoTenNhanVien"].ToString());

            //    lsvNhanVien.Items[i].SubItems.Add(row["NgaySinh"].ToString());

            //    lsvNhanVien.Items[i].SubItems.Add(row["DiaChi"].ToString());
            //    lsvNhanVien.Items[i].SubItems.Add(row["DienThoai"].ToString());
            //    i++;

            //}
            lsvNhanVien.GridLines = true;

            lsvNhanVien.FullRowSelect = true;
            lsvNhanVien.Items.Clear();
            DataTable dt = nv.LayDSNhanvien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsvNhanVien.FullRowSelect = true;
                ListViewItem lvi= lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
              

                  
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
            // lsvNhanVien.View = View.Details;

            //lsvNhanVien.Columns.Add("HoTenNhanVien");

            //lsvNhanVien.Columns.Add("NgaySinh");

            //lsvNhanVien.Columns.Add("DiaChi");
            //lsvNhanVien.Columns.Add("DienThoai");
        }
        void setNull()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        void setButton(bool val)
        {
            
             btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnThoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }
        void HienthiBangcap()
        {
            DataTable dt = nv.LayBangcap();
            cboBangCap.DataSource = dt;
            cboBangCap.DisplayMember = "TenBangcap";
            cboBangCap.ValueMember = "MaBangcap";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

            setNull();
            setButton(true);
            HienthiNhanvien();
            HienthiBangcap();


            //SqlConnection con = new SqlConnection("server =.; database = QlTHUVIEN; integrated security = true;");

            //SqlDataAdapter da = new SqlDataAdapter("select HoTenNhanVien ,NgaySinh , DiaChi ,DienThoai from NHANVIEN", con);

            //DataTable tb = new DataTable();

            //da.Fill(tb);



            //lsvNhanVien.Items.Clear();





            //lsvNhanVien.View = View.Details;

            //lsvNhanVien.Columns.Add("HoTenNhanVien");

            //lsvNhanVien.Columns.Add("NgaySinh");

            //lsvNhanVien.Columns.Add("DiaChi");
            //lsvNhanVien.Columns.Add("DienThoai");

            //lsvNhanVien.GridLines = true;

            //lsvNhanVien.FullRowSelect = true;





            //int i = 0;

            //foreach (DataRow row in tb.Rows)

            //{
            //    lsvNhanVien.FullRowSelect = true;
            //   lsvNhanVien.Items.Add(row["HoTenNhanVien"].ToString());

            //    lsvNhanVien.Items[i].SubItems.Add(row["NgaySinh"].ToString());

            //    lsvNhanVien.Items[i].SubItems.Add(row["DiaChi"].ToString());
            //    lsvNhanVien.Items[i].SubItems.Add(row["DienThoai"].ToString());
            //    i++;

            //}



        }





        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool themmoi = false;
        private void button1_Click(object sender, EventArgs e)
        {

            themmoi = true;
            setButton(false);
            txtHoTen.Focus();
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
                // sql = "insert into NHANVIEN values('" + txtHoTen.Text + "',N'" + dtpNgaySinh.Text + "',N'" + txtDiaChi.Text + txtDienThoai.Text + "')";
                //Bước 4: Thực thi sql
                sql = "INSERT INTO NHANVIEN(Hotennv,Ngaysinh,Diachi,Dienthoai) VALUES('" + txtHoTen.Text + "','" + dtpNgaySinh.Value.ToString("MM/dd/yy") + "','" + txtDiaChi.Text + "','" + txtDienThoai.Text + "')";

                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                int kq = sqlcom.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Bạn đã thêm thành công Khách hàng vào CSDL", "Thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmNhanVien_Load(sender, e);
                }

            }
            catch (Exception ex)
            {

            }


        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                //Chuyen sang kieu dateTime
                dtpNgaySinh.Value =
                DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[2].Text);
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                //Tìm vị trí của Tên bằng cấp trong Combobox
                cboBangCap.SelectedIndex =cboBangCap.FindString(lsvNhanVien.SelectedItems[0].SubItems[5].Text);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóakhông ? ", "Xóa bằng cấp", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(
                    lsvNhanVien.SelectedItems[0].SubItems[0].Text);
                    lsvNhanVien.Items.RemoveAt(
                    lsvNhanVien.SelectedIndices[0]);
       
                setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");

            //if (lsvNhanVien.SelectedItems.Count > 0)
            //{
            //    lsvNhanVien.Items.Remove(lsvNhanVien.SelectedItems[0]);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lsvNhanVien.SelectedItems[0].SubItems[0].Text = txtHoTen.Text;
            //lsvNhanVien.SelectedItems[0].SubItems[1].Text = dtpNgaySinh.Value.ToShortDateString();
            //lsvNhanVien.SelectedItems[0].SubItems[2].Text = txtDiaChi.Text; 
            //lsvNhanVien.SelectedItems[0].SubItems[3].Text = txtDienThoai.Text;
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cậpnhật","Sửa mẫu tin");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}",dtpNgaySinh.Value);
            //Định dạng ngày tương ứng với trong CSDL SQLserver
            if (themmoi)
            {
                nv.ThemNhanVien(txtHoTen.Text, ngay, txtDiaChi.Text,txtDienThoai.Text, cboBangCap.SelectedValue.ToString());
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                nv.CapNhatNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text, txtHoTen.Text, ngay, txtDiaChi.Text,
                txtDienThoai.Text, cboBangCap.SelectedValue.ToString());
                MessageBox.Show("Cập nhật thành công");
            }
            HienthiNhanvien();
            setNull();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }
    }
}
        
     

    
