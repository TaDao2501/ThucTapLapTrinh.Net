using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18203100031_TaThiDao
{
    //Họ Tên : Tạ Thị Đào
    //Ngày sinh : 25/01/2000
    //MSV: 18203100031
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TaThiDao_qlcbDataSet.canbo' table. You can move, or remove it, as needed.
            this.canboTableAdapter.Fill(this.TaThiDao_qlcbDataSet.canbo);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
