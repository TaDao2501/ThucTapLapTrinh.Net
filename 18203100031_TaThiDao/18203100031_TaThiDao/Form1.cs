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
    public partial class Form1 : Form
    {
        //Họ Tên : Tạ Thị Đào
        //Ngày sinh : 25/01/2000
        //MSV: 18203100031
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cánBộToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Canbo frm = new Canbo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.MdiParent = this;
            frm.Show();
        
        }

        private void cánBộToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Canbo frm = new Canbo();
            frm.MdiParent = this;
            frm.Show();
        
        }

        private void tácGiảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tacgia frm = new Tacgia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cánBộToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BaoCao frm = new BaoCao();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
