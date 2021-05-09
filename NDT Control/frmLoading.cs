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

namespace NDT_Control
{
    public partial class frmLoading : Form

    {
        public frmLoading(MetroForm mf)
        {
            InitializeComponent();
        }
           
        public frmLoading()
        {}

        public void changeNumber(int current, int total, string verify)
        {
            lbl_VERIFY.Visible = true;
            lbl_current.Visible = true;
            lbl_total.Visible = true;
            label4.Visible = true;
            
            lbl_current.Text = current.ToString();
            lbl_total.Text = total.ToString();
            lbl_VERIFY.Text = verify;
        }

        public void excelloading(string label)
        {
            try
            {
                lbl_excel.Visible = true;
                lbl_excel.Text = label;
            }
            catch (Exception)
            {
            }
        }

        private void Center(Form form)
        {
            form.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (form.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (form.Size.Height / 2));
        } 
    }
}
