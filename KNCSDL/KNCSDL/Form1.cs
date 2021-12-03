using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNCSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongtinKH frm = new ThongtinKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongtinMH frm = new ThongtinMH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chiTiếtBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietBanHang frm = new ChiTietBanHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemKH frm = new TimKiemKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tìmKiếmMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemMH frm = new TimKiemMH();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
