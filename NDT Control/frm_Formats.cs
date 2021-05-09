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
using System.Diagnostics;
using System.IO;

namespace NDT_Control
{
    public partial class frm_Formats : MetroForm
    {
        public frm_Formats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {            
            Process.Start(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\ndt loader sample data(3).jpg");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\NDT Loader Format.xlsx", sfd.FileName);
                Process.Start(sfd.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\lot loader sample data.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\Lot Loader Format.xlsx", sfd.FileName);
                Process.Start(sfd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\NDT File Check Loader Format.xlsx", sfd.FileName);
                Process.Start(sfd.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Excel Formats\\ndt lfile check sample data.jpg");
        }
    }
}
