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
    public partial class frm_modifyNDT : MetroForm 
    {
        public static string conStr;
        private BindingSource bindingSource = new BindingSource();

        public frm_modifyNDT()
        {
            InitializeComponent();
            conStr = File.ReadAllText(@"..\ndtCon.cfg");
        }

        private void rd_Loader_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Loader.Checked)
            {
                pnl_loader.Visible = true;
                pnl_bgloader.Visible = true;
            }
            else
            {
                pnl_loader.Visible = false;
                pnl_bgloader.Visible = false;
            }
        }

        private void rd_joint_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_joint.Checked)
            {
                pnl_joint.Visible = true;
                pnl_jointbg.Visible = true;
            }
            else
            {
                pnl_joint.Visible = false;
                pnl_jointbg.Visible = false;
            }
        }

        private void rd_report_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_report.Checked)
            {
                pnl_report.Visible = true;
                pnl_repbg.Visible = true;
            }
            else
            {
                pnl_report.Visible = false;
                pnl_repbg.Visible = false;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            DataTable dbData =  new DataTable();
            dgData.DataSource = null;
            
            if (rd_joint.Checked)
            {
                string ndtType = "";

                if (cmb_ndt.SelectedItem.ToString() == "PWHT")
                {
                    ndtType = "PWHT1, PWHTDATE1, PWHT2, PWHTDATE2, PWHT3, PWHTDATE3, PWHT4, PWHTDATE4, PWHTACCEPTED";
                }
                else if (cmb_ndt.SelectedItem.ToString() == "HTA")
                {
                    ndtType = "HT1,HTDATE1, HT2, HTDATE2, HT3, HTDATE3, HTAACCEPTED";
                }
                else if (cmb_ndt.SelectedItem.ToString() == "HTB")
                {
                    ndtType = "HTB,HTBDATE, HTB2, HTB2DATE, HTB3, HTB3DATE, HTBACCEPTED";
                }
                else if (cmb_ndt.SelectedItem.ToString() == "PMI")
                {
                    ndtType = "PMINUMBER, PMIDATE, PMI AS [PMI ACCEPTED]";
                }
                else if (cmb_ndt.SelectedItem.ToString() == "PT")
                {
                    ndtType = "PTNUMBER, PTDATE, PT AS [PT ACCEPTED]";
                }
                else if (cmb_ndt.SelectedItem.ToString() == "FT")
                {
                    ndtType = "FERRIT, FERRITDATE, FERRIT2, FERRIT2DATE, FERRIT3, FERRIT3DATE, FERRITACCEPTED";
                }

                dbData = Utilities.GetDBData("select UNIT,SERVICE, LINE,TRAIN, JOINTNUMBER,"
                                                + ndtType
                                                + " from joints WITH (NOLOCK) where Unit ='" + txt_Unit.Text
                                                + "' and [Service] ='" + txt_service.Text
                                                + "' and Line ='" + txt_line.Text
                                                + "' and Train='" + txt_train.Text
                                                + "' and JointNumber='" + txt_joint.Text + "'");
            }
            else if(rd_report.Checked)
            {
                string ndtType = "", sqlQuery="";

                if (cmb_ndttype_report.SelectedItem.ToString() == "PWHT")
                {
                    ndtType = "PWHT1, PWHTDATE1, PWHT2, PWHTDATE2, PWHT3, PWHTDATE3, PWHT4, PWHTDATE4, PWHTACCEPTED";
                    sqlQuery = "PWHT1='"+ txt_report.Text +"' or PWHT2 = '"+ txt_report.Text +"' or PWHT3='" + txt_report.Text +"' or PWHT4='"+txt_report.Text +"'";
                }
                else if (cmb_ndttype_report.SelectedItem.ToString() == "HTA")
                {
                    ndtType = "HT1,HTDATE1, HT2, HTDATE2, HT3, HTDATE3, HTAACCEPTED";
                    sqlQuery = "HT1='" + txt_report.Text + "' or HT2 = '" + txt_report.Text + "' or HT3='" + txt_report.Text + "'";
                }
                else if (cmb_ndttype_report.SelectedItem.ToString() == "HTB")
                {
                    ndtType = "HTB,HTBDATE, HTB2, HTB2DATE, HTB3, HTB3DATE, HTBACCEPTED";
                    sqlQuery = "HTb1='" + txt_report.Text + "' or HTb2 = '" + txt_report.Text + "' or HTb3='" + txt_report.Text + "'";
                }
                else if (cmb_ndttype_report.SelectedItem.ToString() == "PMI")
                {
                    ndtType = "PMINUMBER, PMIDATE, PMI AS [PMI ACCEPTED]";
                    sqlQuery = "PMInumber ='" + txt_report.Text +"'";
                }
                else if (cmb_ndttype_report.SelectedItem.ToString() == "PT")
                {
                    ndtType = "PTNUMBER, PTDATE, PT AS [PT ACCEPTED]";
                    sqlQuery = "PTnumber ='" + txt_report.Text + "'";
                }
                else if (cmb_ndttype_report.SelectedItem.ToString() == "FT")
                {
                    ndtType = "FERRIT, FERRITDATE, FERRIT2, FERRIT2DATE, FERRIT3, FERRIT3DATE, FERRITACCEPTED";
                    sqlQuery = "FERRIT='" + txt_report.Text + "' or FERRIT2 = '" + txt_report.Text + "' or FERRIT3='" + txt_report.Text + "'";
                }

                dbData = Utilities.GetDBData("select UNIT,SERVICE, LINE,TRAIN, JOINTNUMBER,"
                                                + ndtType
                                                + " from joints WITH (NOLOCK) where " + sqlQuery.ToString());
            }
            else if(rd_Loader.Checked)
            {
                DataTable excelData = new DataTable();
                excelData = Utilities.ImportExcelData(txtfilepath.Text);
                dbData = Utilities.GetNDTOnlyData(excelData);
            }
            Utilities.DTtoDG(dbData, this.dgData);

            for (int i = 0; i < 5; i++)
            {
                dgData.Columns[i].ReadOnly = true;
                dgData.Columns[i].Frozen = true;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.UploadData(dgData);
                MessageBox.Show("CHANGES SAVED!");
                dgData.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AN ERROR OCCURED:" + ex.ToString());
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pnl_joint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_joint.Clear();
            txt_line.Clear();
            txt_service.Clear();
            txt_train.Clear();
            txt_Unit.Clear();
            cmb_ndt.SelectedIndex = -1;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtfilepath.Text = openFileDialog1.FileName;
            }
        }
    }
}
