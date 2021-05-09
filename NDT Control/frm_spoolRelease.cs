using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace NDT_Control
{
    public partial class frm_spoolRelease : MetroForm
    {
        public frm_spoolRelease()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }

            txtSpoolReleaseNum.Text = System.IO.Path.GetFileName(txtFilePath.Text).Replace(".xlsx","");
        }

        private void dgv_Paint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Utilities.NDTClassesTESTING();
        }
    }
}
