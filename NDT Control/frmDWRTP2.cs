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
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using MetroFramework;

namespace NDT_Control
{
    public partial class frmDWRTP2 : MetroForm
    {
        public static string conStr;
        DataTable csJoints = new DataTable();
        string DWRNumbers = AppDomain.CurrentDomain.BaseDirectory + "\\DWRcontrolNum.txt";
        string DWRLog = AppDomain.CurrentDomain.BaseDirectory + "\\DWRLog.txt";
        string DWRCSReportNum;
        DataTable dt_iso = new DataTable();
        frm_menu mainMenu;

        public frmDWRTP2(frm_menu mm)
        {
            InitializeComponent();
            conStr = File.ReadAllText(@"..\ndtCon.cfg");
            mainMenu = mm;
        }

        private void frmDWRTP2_Load(object sender, EventArgs e)
        {
            DataTable dt_tp = new DataTable();

            dt_tp = Utilities.GetDBData("select distinct htp from HTP");

            cmb_tp.DataSource = dt_tp.DefaultView;
            cmb_tp.DisplayMember = "htp";
            cmb_tp.BindingContext = this.BindingContext;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                btn_exportexcel.Visible = false;
                if (cmb_tp.Text == "" || cmb_dwrMode.Text == "" || cmbSubcon.Text == "")
                {
                    MessageBox.Show("Please select TP # and DWR.");
                }
                else
                {
                    dt_iso = Utilities.GetDBData("select DISTINCT RTRIM(iso.Unit)+'-'+RTRIM(iso.[Service])+'-'+RTRIM(iso.Line)+'-'+RTRIM(iso.Train) as ISO"
                                                   + "         FROM (	SELECT Size.EQSize AS MainDia,i.* "
                                                   + "                 FROM Isometric i WITH (NOLOCK),Size WITH (NOLOCK) "
                                                   + "                 WHERE i.LatestRevision LIKE '%Latest%' "
                                                   + "                 AND i.Dia=Size.Jointsize "
                                                   + "                 AND i.active=1) AS iso "
                                                   + "         LEFT JOIN"
                                                   + "             (SELECT * "
                                                   + "             FROM Spool with (NOLOCK) "
                                                   + "             WHERE Active=1) as sp"
                                                   + "             ON iso.service=sp.service "
                                                   + "             AND iso.unit=sp.unit "
                                                   + "             AND iso.line=sp.line "
                                                   + "             AND iso.train=sp.train where sp.HTP = '" + cmb_tp.Text + "'");
                    dgv_joints.DataSource = null;
                    dgv_details.Rows.Clear();
                    Utilities.DTtoDG(dt_iso, this.dgv_iso);
                }
            }
            catch (Exception)
            {
                
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

        private void dgv_iso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmb_dwrMode.Text == "NEW REPORT")
            {
                dgv_details.Columns["olddwr"].ReadOnly = false;
                dgv_details.Columns["olddateofweld"].ReadOnly = false;
            }
            else
            {
                dgv_details.Columns["olddwr"].ReadOnly = true;
                dgv_details.Columns["olddateofweld"].ReadOnly = true;
            }

            if (e.ColumnIndex == 1)
            {
                if (dgv_iso.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (dgv_iso.Rows[e.RowIndex].Cells[0].Value.Equals(true))
                    {
                        lbl_iso.Text = dgv_iso.SelectedCells[0].Value.ToString();
                        DataTable dt_joint = new DataTable();
                        string[] iso = dgv_iso.SelectedCells[0].Value.ToString().Split('-');

                        dt_joint = Utilities.GetDBData("SELECT DISTINCT jts.JointNumber as [JOINT] FROM"
                                                        + "                    (	SELECT Size.EQSize AS MainDia,i.*"
                                                        + "                         FROM Isometric i WITH (NOLOCK),Size WITH (NOLOCK) "
                                                        + "                         WHERE i.LatestRevision LIKE '%Latest%' "
                                                        + "                         AND i.Dia=Size.Jointsize "
                                                        + "                         AND i.active=1) AS iso"
                                                        + "                 LEFT JOIN"
                                                        + "                     (SELECT Size.EqSize AS Dia, j.* "
                                                        + "                     FROM JointsSubc j,Size WITH (NOLOCK) "
                                                        + "                     WHERE j.JointSize=size.Jointsize) AS jts"
                                                        + "                     ON iso.[service]=jts.[service] "
                                                        + "                     AND iso.unit=jts.unit "
                                                        + "                     AND iso.line=jts.line "
                                                        + "                     AND iso.train=jts.train "
                                                        + "           where"
                                                        + "             iso.unit =" + iso[0].ToString()
                                                        + "             and "
                                                        + "             iso.Service = '" + iso[1].ToString()
                                                        + "'             and "
                                                        + "             iso.line = '" + iso[2].ToString()
                                                        + "'            and "
                                                        + "             iso.Train ='" + iso[3].ToString() + "'");
                        Utilities.DTtoDG(dt_joint, this.dgv_joints);
                    }
                }
               
                
            }
        }

        private void dgv_joints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dgv_joints.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (dgv_joints.Rows[e.RowIndex].Cells[0].Value.Equals(true))
                    {
                        DataTable dt_jointdetails = new DataTable();
                        string[] iso = dgv_iso.SelectedCells[0].Value.ToString().Split('-');

                        dt_jointdetails = Utilities.GetDBData("SELECT DISTINCT "
                                                        + "iso.unit, iso.Service, iso.Line, iso.Train, jts.MaterialClass, iso.RevisionNumber, jts.Spool,"
                                                        + "jts.JointType, jts.location, jts.JointNumber, jts.Dia, jts.Sch,"
                                                        + "mb.Description as [item 1], jts.materialgrade1, jts.HN1 as [Heat 1],"
                                                        + "mb.Item as [item 2], jts.materialgrade2, jts.HN2 as [Heat 2],"
                                                        + "'' as [Fit up Report], jts.FitUpDate, jts.welder1, jts.welder2,"
                                                        + "jts.WPS, jts.Rod, jts.HeatRod, jts.Electr, jts.HeatE,"
                                                        + "'ACC' as [ACC], '' as [REJ], jts.WeldingReportNumber as [Remarks], jts.DateofWeld as [Date]"

                                                        + " FROM"
                                                        + "    (	SELECT Size.EQSize AS MainDia,i.*"
                                                        + "        FROM Isometric i WITH (NOLOCK),Size WITH (NOLOCK) "
                                                        + "        WHERE i.LatestRevision LIKE '%Latest%' "
                                                        + "        AND i.Dia=Size.Jointsize "
                                                        + "        AND i.active=1) AS iso "
                                                        + "LEFT JOIN"
                                                        + "    (SELECT Size.EqSize AS Dia, j.* "
                                                        + "    FROM JointsSubc j,Size WITH (NOLOCK) "
                                                        + "    WHERE j.JointSize=size.Jointsize) AS jts"
                                                        + "    ON iso.[service]=jts.[service] "
                                                        + "    AND iso.unit=jts.unit "
                                                        + "    AND iso.line=jts.line "
                                                        + "    AND iso.train=jts.train "
                                                        + "    LEFT JOIN MatBase mb WITH (NOLOCK)"
                                                       + " ON jts.itemcode=mb.ItemCode where"
                                                        + "             iso.unit =" + iso[0].ToString()
                                                        + "             and "
                                                        + "             iso.Service = '" + iso[1].ToString()
                                                        + "'             and "
                                                        + "             iso.line = '" + iso[2].ToString()
                                                        + "'            and "
                                                        + "             iso.Train ='" + iso[3].ToString()
                                                        +"'             and jts.jointnumber='" + dgv_joints.SelectedCells[0].Value.ToString() + "'");

                        Utilities.DTtoDG(dt_jointdetails, dgv_details);


                    }
                }
            }
        }

        public void addtoDG(DataTable dtadd)
        { 
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] iso = dgv_iso.SelectedCells[0].Value.ToString().Split('-');

            if (CheckJoint(iso[0].ToString(), iso[1].ToString(), iso[2].ToString(), iso[3].ToString(), dgv_joints.SelectedCells[0].Value.ToString()))
            {
                MetroMessageBox.Show(mainMenu, "", "JOINT ALREADY ADDED.", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
            else
            {
                DataTable dt_jointdetails = new DataTable();

                dt_jointdetails = Utilities.GetDBData("SELECT DISTINCT "
                                                + "	rtrim(iso.unit) as unit, rtrim(iso.Service) as service, rtrim(iso.Line) as line, rtrim(iso.Train) as train, "
                                                + "    jts.JointNumber as joint,rtrim(jts.MaterialClass) as lineclass, rtrim(iso.RevisionNumber) as revision,rtrim(jts.location) as location, rtrim(jts.Spool) as spool,"
                                                + "    rtrim(jts.Jointtype) as jointtype, jts.dia, rtrim(jts.sch) as sch,"
                                                + "    mb.Description as [item 1], jts.materialgrade1, jts.HN1 as [Heat 1],"
                                                + "    mb.Item as [item 2], jts.materialgrade2, jts.HN2 as [Heat 2],"
                                                + "    jts.FitUpDate, jts.welder1, jts.welder2,"
                                                + "    jts.WPS, jts.Rod, jts.HeatRod, jts.Electr, jts.HeatE,iso.inspN,"
                                                + "    jts.WeldingReportNumber, jts.DateofWeld "
                                                + "FROM"
                                                + "    (	SELECT Size.EQSize AS MainDia,i.*"
                                                + "        FROM Isometric i WITH (NOLOCK),Size WITH (NOLOCK) "
                                                + "        WHERE i.LatestRevision LIKE '%Latest%' "
                                                + "        AND i.Dia=Size.Jointsize "
                                                + "        AND i.active=1) AS iso "
                                                + "LEFT JOIN"
                                                + "    (SELECT Size.EqSize AS Dia, j.* "
                                                + "    FROM JointsSubc j,Size WITH (NOLOCK) "
                                                + "    WHERE j.JointSize=size.Jointsize) AS jts"
                                                + "    ON iso.[service]=jts.[service] "
                                                + "    AND iso.unit=jts.unit "
                                                + "    AND iso.line=jts.line "
                                                + "    AND iso.train=jts.train "
                                                + "    LEFT JOIN MatBase mb WITH (NOLOCK)"
                                               + " ON jts.itemcode=mb.ItemCode where"
                                                + "             iso.unit =" + iso[0].ToString()
                                                + "             and "
                                                + "             iso.Service = '" + iso[1].ToString()
                                                + "'             and "
                                                + "             iso.line = '" + iso[2].ToString()
                                                + "'            and "
                                                + "             iso.Train ='" + iso[3].ToString()
                                                + "'             and jts.jointnumber='" + dgv_joints.SelectedCells[0].Value.ToString() + "'");
                
                DataTable dtJointtype = Utilities.GetDBData("SELECT rtrim(JOINTTYPE) as [jointtype] FROM JointType");
                DataTable dtMatClass = Utilities.GetDBData("SELECT DISTINCT RTRIM(MaterialClass) as [materialclass] FROM MaterialClass");
                DataTable dtDia = Utilities.GetDBData("SELECT DISTINCT rtrim(eqsize) AS [jointsize] FROM size");
                DataTable dtSch = Utilities.GetDBData("SELECT DISTINCT RTRIM(sch) as sch FROM schedulemm");
                DataTable dtWelder = Utilities.GetDBData("SELECT DISTINCT RTRIM(Stamp) as [welder] FROM WelderList");
                DataTable dtWPS = Utilities.GetDBData("SELECT DISTINCT RTRIM(wps) as wps FROM WPS");

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_details);

                for (int i = 0; i < 30; i++)
                {
                    if (i != 29) //COLUMN INDEX
                    {
                        if (i == 5)
                        {
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtMatClass;
                            ContactCombo.DisplayMember = "materialclass";
                            ContactCombo.ValueMember = "materialclass";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        else if (i == 9)
                        { 
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtJointtype;
                            ContactCombo.DisplayMember = "jointtype";
                            ContactCombo.ValueMember = "jointtype";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        else if(i == 10)
                        {
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtDia;
                            ContactCombo.DisplayMember = "jointsize";
                            ContactCombo.ValueMember = "jointsize";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        else if(i == 11)
                        {
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtSch;
                            ContactCombo.DisplayMember = "Sch";
                            ContactCombo.ValueMember = "Sch";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        else if(i == 19 || i == 20)
                        {
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtWelder;
                            ContactCombo.DisplayMember = "welder"; //i == 19 ? "Welder1" : "Welder2" ;
                            ContactCombo.ValueMember = "welder";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        else if(i == 21)
                        {
                            DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[i]);

                            ContactCombo.DataSource = dtWPS;
                            ContactCombo.DisplayMember = "wps";
                            ContactCombo.ValueMember = "wps";
                            row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                        }
                        
                        row.Cells[i].Value = dt_jointdetails.Rows[0][i].ToString();
                    }
                    else
                    {
                        row.Cells[29].Value = cmb_tp.Text;
                    }
                }
                dgv_details.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_details.SelectedRows)
            {
                dgv_details.Rows.Remove(row);
            }
        }

        private void dgv_details_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                string dwrreport = LogDWR();

                DataTable dwrData = new DataTable();
                dwrData = Utilities.DGtoDT(dgv_details);
                this.reportViewer1.LocalReport.DataSources.Clear();
                DataSet ds = new DataSet();
                ds.Tables.Add(dwrData);

                reportViewer1.LocalReport.ReportPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\CS_DWR.rdlc";
                ReportDataSource rdsWM = new ReportDataSource("CS_DWR", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Add(rdsWM);

                ReportParameter parameter = new ReportParameter("DWRNumber", dwrreport);
                this.reportViewer1.LocalReport.SetParameters(parameter);

                ReportParameter parameterSubCon = new ReportParameter("SubCon", cmbSubcon.Text);
                this.reportViewer1.LocalReport.SetParameters(parameterSubCon);

                System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                ps.Landscape = true;
                ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
                ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                reportViewer1.SetPageSettings(ps);

                var setup = reportViewer1.GetPageSettings();
                setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                reportViewer1.SetPageSettings(setup);

                this.reportViewer1.RefreshReport();
                this.Enabled = true;
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                btn_exportexcel.Visible = true;
                MetroMessageBox.Show(mainMenu, "", "DWR GENERATED", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            catch (Exception ex)
            {
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION: " + ex.Message, "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

        private string LogDWR()
        {
            string dwrnum = cmb_dwrMode.Text == "NEW REPORT" ? "DWR-" + cmbSubcon.Text + "-T-" : "DWR-" + cmbSubcon.Text + "-CS-";
            
            string s = File.ReadLines(DWRNumbers).Last();

            int newDWRnumber = Int32.Parse(s.ToString()) + 1;
            File.AppendAllText(DWRNumbers, Environment.NewLine + newDWRnumber.ToString());

            using (var tw = new StreamWriter(DWRLog, true))
            {
                tw.WriteLine("DWR:" + dwrnum + newDWRnumber + "**Generated by:" + Environment.UserName + "**Date:" + DateTime.Now.ToString());
                tw.Close();
            }

            DWRCSReportNum = dwrnum + newDWRnumber;
            return dwrnum + newDWRnumber;
        }

        private void dgv_iso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public bool CheckJoint(string unit, string service, string line, string train, string joint)
        {
            bool exist = false;
            foreach (DataGridViewRow row in dgv_details.Rows)
            {
                if (unit == row.Cells[0].Value.ToString() &&
                   service == row.Cells[1].Value.ToString() &&
                    line == row.Cells[2].Value.ToString() &&
                    train == row.Cells[3].Value.ToString() &&
                    joint == row.Cells[4].Value.ToString()
                    )
                {
                    return exist = true;
                }
            }

            return exist;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                string fname = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DWRCSReportNum;
                DataTable rawData = new DataTable();
                rawData = Utilities.DGtoDT(dgv_details);

                for (int i = 0; i < rawData.Columns.Count; i++)
                {
                    if (rawData.Columns[i].ToString() == "dia" )
                    {
                        rawData.Columns[i].ColumnName = "jointsize";
                    }
                    else if(rawData.Columns[i].ToString() == "heat1" )
                    {
                        rawData.Columns[i].ColumnName = "HN1";
                    }
                    else if(rawData.Columns[i].ToString() == "heat2" )
                    {
                        rawData.Columns[i].ColumnName = "HN2";
                    }
                    else if(rawData.Columns[i].ToString() == "electrode" )
                    {
                        rawData.Columns[i].ColumnName = "electr";
                    }
                    else if (rawData.Columns[i].ToString() == "heatelectrode")
                    {
                        rawData.Columns[i].ColumnName = "heate";
                    }
                    else if (rawData.Columns[i].ToString() == "olddwr")
                    {
                        rawData.Columns[i].ColumnName = "ivisual";
                    }
                }

                rawData.Columns.Remove("lineclass");
                rawData.Columns.Remove("revision");
                rawData.Columns.Remove("itemdesc1");
                rawData.Columns.Remove("itemdesc2");
                rawData.Columns.Remove("fitupdate");
                rawData.Columns.Remove("cc");
                rawData.Columns.Remove("olddateofweld");
                rawData.Columns.Remove("tpnum");

                System.Data.DataColumn newColumn = new System.Data.DataColumn("Dateofweld", typeof(System.String));
                newColumn.DefaultValue = DateTime.Now.ToString("yyyy/MM/dd");
                rawData.Columns.Add(newColumn);

                System.Data.DataColumn csweldingrep = new System.Data.DataColumn("WeldingReportNumber", typeof(System.String));
                csweldingrep.DefaultValue = DWRCSReportNum;
                rawData.Columns.Add(csweldingrep);

                try
                {
                    Utilities.ExportExcel(rawData, fname + ".xlsx");
                    MetroMessageBox.Show(mainMenu, "EXPORT SUCCESSFUL", "FILE IS LOCATED ON YOUR DESKTOP", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(mainMenu, "EXPORT FAILED!", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
                }
            }
            catch (Exception)
            {
                
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

        private void dgv_details_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_clearISO_Click(object sender, EventArgs e)
        {
        }

        private void txt_svc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mainMenu.StartLoading();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainMenu.CloseLoading();
        }
    }
}
