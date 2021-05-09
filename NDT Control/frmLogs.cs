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
using MetroFramework;

namespace NDT_Control
{
    public partial class frmLogs : MetroForm
    {
        DataTable dtlogs;

        public frmLogs()
        {
            InitializeComponent();
            dtlogs = Utilities.XmlToDT();
            Utilities.DTtoDG(Utilities.XmlToDT(), dgv_logs);           
        }

        private void metroTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dtlogs.DefaultView;

                dv.RowFilter = string.Format("REPORTNUMBER like '%{0}%'", txt_reportnum.Text);
                dgv_logs.DataSource = dv.ToTable();
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_category.SelectedItem.ToString() == "REPORT NUMBER")
            {
                txt_reportnum.Enabled = true;
                pnl_ISO.Enabled = false;
                txt_uploadedBy.Enabled = false;
                dt_uploaded.Enabled = false;
            }
            else if (cmb_category.SelectedItem.ToString() == "DATE UPLOADED")
            {
                txt_reportnum.Enabled = false;
                pnl_ISO.Enabled = false;
                txt_uploadedBy.Enabled = false;
                dt_uploaded.Enabled = true;
            }
            else if (cmb_category.SelectedItem.ToString() == "UPLOADED BY")
            {
                txt_reportnum.Enabled = false;
                pnl_ISO.Enabled = false;
                txt_uploadedBy.Enabled = true;
                dt_uploaded.Enabled = false;
            }
            else if (cmb_category.SelectedItem.ToString() == "ISOMETRIC")
            {
                txt_reportnum.Enabled = false;
                pnl_ISO.Enabled = true;
                txt_uploadedBy.Enabled = false;
                dt_uploaded.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_category.SelectedItem.ToString() == "REPORT NUMBER")
                {
                    DataView dv = dtlogs.DefaultView;

                    dv.RowFilter = string.Format("REPORTNUMBER like '%{0}%'", txt_reportnum.Text);

                    dgv_logs.DataSource = dv.ToTable();
                }
                else if (cmb_category.SelectedItem.ToString() == "DATE UPLOADED")
                {
                    DataView dv = dtlogs.DefaultView;

                    dv.RowFilter = string.Format("DATEUPLOAD like '%{0}%'", dt_uploaded.Value.ToString("yyyy/MM/dd"));

                    dgv_logs.DataSource = dv.ToTable();
                }
                else if (cmb_category.SelectedItem.ToString() == "UPLOADED BY")
                {
                    DataView dv = dtlogs.DefaultView;

                    dv.RowFilter = string.Format("UPDATEDBY like '%{0}%'", txt_uploadedBy.Text);

                    dgv_logs.DataSource = dv.ToTable();
                }
                else if (cmb_category.SelectedItem.ToString() == "ISOMETRIC")
                {
                    DataView dv = dtlogs.DefaultView;

                    dv.RowFilter = string.Format("UNIT='{0}' AND SERVICE ='{1}' AND LINE ='{2}' AND TRAIN ='{3}' AND JOINT ='{4}'"
                                                , txt_unit.Text, txt_service.Text, txt_line.Text, txt_train.Text, txt_joint.Text);


                    dgv_logs.DataSource = dv.ToTable();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_clearIso_Click(object sender, EventArgs e)
        {
            txt_unit.Text = "";
            txt_service.Text = "";
            txt_line.Text = "";
            txt_train.Text = "";
            txt_joint.Text = "";

            DataView dv = dtlogs.DefaultView;
            dv.RowFilter = string.Empty;
            dgv_logs.DataSource = dv.ToTable();
        }

        private void btn_clearDate_Click(object sender, EventArgs e)
        {
            DataView dv = dtlogs.DefaultView;
            dv.RowFilter = string.Empty;
            dgv_logs.DataSource = dv.ToTable();
        }
    }
}
