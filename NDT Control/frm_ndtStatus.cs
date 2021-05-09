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
using System.IO;


namespace NDT_Control
{
    public partial class frm_ndtStatus : MetroForm
    {
        DataTable rtJoints = new DataTable();
        DataTable pwhtJoints = new DataTable();
        DataTable pmiJoints = new DataTable();
        DataTable htbJoints = new DataTable();
        DataTable htaJoints = new DataTable();
        DataTable ftJoints = new DataTable();
        DataTable ptJoints = new DataTable();

        frm_menu mainMenu;
        bool rtloaded, pwhtloaded, htaloaded, htbloaded, ptloaded, ftloaded, pmiloaded;

        public frm_ndtStatus(frm_menu mm)
        {
            InitializeComponent();
            dgv_RT.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_pwht.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_pmi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_htb.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_hta.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_pt.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_ft.SelectionMode = DataGridViewSelectionMode.CellSelect;
            mainMenu = mm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                loadingWorker.RunWorkerAsync();

                RTLoader.RunWorkerAsync();
                PWHTLoader.RunWorkerAsync();
                PMILoader.RunWorkerAsync();
                HTBLoader.RunWorkerAsync();
                HTALoader.RunWorkerAsync();
                PTLoader.RunWorkerAsync();
                FTLoader.RunWorkerAsync();

                LoadNDTStatus();
                adjustColumns();
            }
            catch (Exception excp)
            {
                MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }

        }

        #region COMMON FUNCTIONS

        private void button2_Click(object sender, EventArgs e)
        {
            loadingWorker.RunWorkerAsync();
            Utilities.ExportExcel(Utilities.DGtoDT(dgv_jointDetails), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + txt_tblLoaded.Text + " JOINTS.xlsx");
        }

        public void LoadNDTStatus()
        {
            pic_ft.Visible = false;
            pic_hta.Visible = false;
            pic_htb.Visible = false;
            pic_pmi.Visible = false;
            pic_pt.Visible = false;
            pic_pwht.Visible = false;
            pic_rt.Visible = false;

            DataTable rt = new DataTable("RT");
            DataTable pwht = new DataTable("PWHT");
            DataTable pmi = new DataTable("PMI");
            DataTable htb = new DataTable("HTB");
            DataTable hta = new DataTable("HTA");
            DataTable pt = new DataTable("PT");
            DataTable ft = new DataTable("FT");

            mainMenu.ChangeUpperLabel("RT STATUS LOADING...");
            string rtQuery = File.ReadAllText(@"..\NDT Status\Status\RT.sql");
            rt = Utilities.GetDBData(rtQuery);
            Utilities.DTtoDG(CalculateStatus(rt), dgv_RT);

            mainMenu.ChangeUpperLabel("PWHT STATUS LOADING...");
            string pwhtQuery = File.ReadAllText(@"..\NDT Status\Status\PWHT.sql");
            pwht = Utilities.GetDBData(pwhtQuery);

            Utilities.DTtoDG(CalculateStatus(pwht), dgv_pwht);

            mainMenu.ChangeUpperLabel("PMI STATUS LOADING...");
            string pmiQuery = File.ReadAllText(@"..\NDT Status\Status\PMI.sql");
            pmi = Utilities.GetDBData(pmiQuery);

            Utilities.DTtoDG(CalculateStatus(pmi), dgv_pmi);

            mainMenu.ChangeUpperLabel("HTB STATUS LOADING...");
            string htbQuery = File.ReadAllText(@"..\NDT Status\Status\HTB.sql");
            htb = Utilities.GetDBData(htbQuery);

            Utilities.DTtoDG(CalculateStatus(htb), dgv_htb);

            mainMenu.ChangeUpperLabel("HTA STATUS LOADING...");
            string htaQuery = File.ReadAllText(@"..\NDT Status\Status\HTA.sql");
            hta = Utilities.GetDBData(htaQuery);

            Utilities.DTtoDG(CalculateStatus(hta), dgv_hta);

            mainMenu.ChangeUpperLabel("PT STATUS LOADING...");
            string ptQuery = File.ReadAllText(@"..\NDT Status\Status\PT.sql");
            pt = Utilities.GetDBData(ptQuery);

            Utilities.DTtoDG(CalculateStatus(pt), dgv_pt);

            mainMenu.ChangeUpperLabel("FT STATUS LOADING...");
            string ftQuery = File.ReadAllText(@"..\NDT Status\Status\FT.sql");
            ft = Utilities.GetDBData(ftQuery);

            Utilities.DTtoDG(CalculateStatus(ft), dgv_ft);
        }

        private void DisplayJointDetails(string[] selectedData, string ndt)
        {
            DataTable searchtable = new DataTable();
             if(ndt.Equals("RT"))
             {
                 searchtable = rtJoints;
             }
             else if(ndt.Equals("PWHT"))
             {
                searchtable = pwhtJoints;
             }
             else if (ndt.Equals("PMI"))
             {
                 searchtable = pmiJoints;
             }
             else if (ndt.Equals("HTB"))
             {
                 searchtable = htbJoints;
             }
             else if (ndt.Equals("HTA"))
             {
                 searchtable = htaJoints;
             }
             else if (ndt.Equals("FT"))
             {
                 searchtable = ftJoints;
             }
             else if (ndt.Equals("PT"))
             {
                 searchtable = ptJoints;
             }
            
            DataTable linqResult = new DataTable();

            try
            {
                if (selectedData.Length > 1)
                {
                    if (selectedData[3].Equals("LB/SB") || selectedData[3].Equals("LB/SB"))
                    {
                        var results = from jointdetails in searchtable.AsEnumerable()
                                      where jointdetails.Field<string>("Subcontractor") == selectedData[0] &&
                                            jointdetails.Field<string>("InspN") == selectedData[1] &&
                                            jointdetails.Field<string>("%") == selectedData[2]
                                      select jointdetails;

                        linqResult = results.CopyToDataTable();
                    }
                    else
                    {
                        var results = from jointdetails in searchtable.AsEnumerable()
                                      where jointdetails.Field<string>("Subcontractor") == selectedData[0] &&
                                            jointdetails.Field<string>("InspN") == selectedData[1] &&
                                            jointdetails.Field<string>("%") == selectedData[2] &&
                                            jointdetails.Field<string>("Bore") == selectedData[3]
                                      select jointdetails;
                        linqResult = results.CopyToDataTable();
                    }
                }
                else
                {
                    var results = from jointdetails in searchtable.AsEnumerable()
                                  where jointdetails.Field<string>("Subcontractor") == selectedData[0]
                                  select jointdetails;
                    linqResult = results.CopyToDataTable();
                }
                txt_tblLoaded.Text = ndt +" "+ string.Join(" ", selectedData);
                Utilities.DTtoDG(linqResult, dgv_jointDetails);
            }
            catch (Exception)
            {
            }
        }

        private DataTable CalculateStatus(DataTable data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SUBCONTRACTOR");
            dt.Columns.Add("TOTAL SCOPE");
            dt.Columns.Add("FORECAST NDT");
            dt.Columns.Add("PENDING NDT");
            dt.Columns.Add("PREVIOUS WEEK");
            dt.Columns.Add("ACTUAL WEEK");
            dt.Columns.Add("ACCUMULATED");
            dt.Columns.Add("ACTUALLY WELDED");
            dt.Columns.Add("REQUIRED NDT");
            dt.Columns.Add("BACKLOG NDT");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                dt.Rows.Add();
            }

            for (int i = 0; i < data.Rows.Count-1; i++)
            {
                dt.Rows[i]["SUBCONTRACTOR"] = data.Rows[i]["Subcontractor"];
                dt.Rows[i]["TOTAL SCOPE"] = data.Rows[i]["TotalScope"];
                dt.Rows[i]["ACCUMULATED"] = data.Rows[i]["Accumulated"];
                dt.Rows[i]["ACTUALLY WELDED"] = data.Rows[i]["ActuallyWelded"];
                dt.Rows[i]["REQUIRED NDT"] = data.Rows[i]["RequiredNDT"];
                dt.Rows[i]["FORECAST NDT"] = data.Rows[i]["ForecastNDT"];
            }

            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                dt.Rows[i]["PENDING NDT"] = Convert.ToInt32(dt.Rows[i]["FORECAST NDT"]) - Convert.ToInt32(dt.Rows[i]["ACCUMULATED"]);
                dt.Rows[i]["BACKLOG NDT"] = Convert.ToInt32(dt.Rows[i]["REQUIRED NDT"]) - Convert.ToInt32(dt.Rows[i]["ACCUMULATED"]);
            }


            return dt;
        }

        private void loadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            mainMenu.StartLoading();
        }

        private void loadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainMenu.CloseLoading();
        }

        public void adjustColumns()
        {
            Adjustgridheight(dgv_RT);
            Adjustgridheight(dgv_pwht);
            Adjustgridheight(dgv_pmi);
            Adjustgridheight(dgv_hta);
            Adjustgridheight(dgv_htb);
            Adjustgridheight(dgv_pt);
            Adjustgridheight(dgv_ft);

            dgv_RT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_pwht.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_pmi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_hta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_htb.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_pt.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_ft.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        
        private void ChangeLabel(string mesg, Label lbl)
        {
            lbl.Text = mesg;
        }

        public void Adjustgridheight(DataGridView dgv)
        {
            int overallheight = dgv.ColumnHeadersHeight;

            foreach (DataGridViewRow n in dgv.Rows)
            {
                overallheight += n.Height;
            }
            dgv.Height = overallheight;
        }
        
        #endregion

        #region RT Joint Transactions

        private void RTLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("RT JOINTS:", lbl_RTStatus);
            }));
            pic_rt.Visible = true;
            rtloaded = true;
        }

        private void dgv_RT_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.ColumnIndex == 1)
            {
                if (rtloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_RT.SelectedCells;
                    string[] selected = dgv_RT.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "RT");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "RT JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
           
        }

        private void RTLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("RT JOINTS: LOADING...", lbl_RTStatus);
            }));

            rtloaded = false;
            string rtQuery = File.ReadAllText(@"..\NDT Status\Joint Details\RT.sql");
            rtJoints = Utilities.GetDBData(rtQuery);
        }
                
        #endregion

        #region PWHT Joint Transactions
        private void PWHTLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("PWHT JOINTS: LOADING...", lbl_PWHTStatus);
            }));

            pwhtloaded = false;
            string pwhtQuery = File.ReadAllText(@"..\NDT Status\Joint Details\PWHT.sql");
            pwhtJoints = Utilities.GetDBData(pwhtQuery);
        }

        private void PWHTLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("PWHT JOINTS:", lbl_PWHTStatus);
            }));
            pic_pwht.Visible = true;
            pwhtloaded = true;
        }

        private void dgv_pwht_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (pwhtloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_pwht.SelectedCells;
                    string[] selected = dgv_pwht.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected,"PWHT");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "PWHT JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
          
        }
        #endregion 

        #region PMI Joint Transactions

        private void PMILoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("PWHT JOINTS: LOADING...", lbl_PWHTStatus);
            }));

            pmiloaded = false;
            string pmiQuery = File.ReadAllText(@"..\NDT Status\Joint Details\PMI.sql");
            pmiJoints = Utilities.GetDBData(pmiQuery);
        }

        private void PMILoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("PMI JOINTS:", lbl_PMIStatus);
            }));
            pic_pmi.Visible = true;
            pmiloaded = true;
        }
 
        private void dgv_pmi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (pmiloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_pmi.SelectedCells;
                    string[] selected = dgv_pmi.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "PMI");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "PMI JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }       

        #endregion


        #region HTB Joint Transactions

        private void HTBLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("HTB JOINTS: LOADING...", lbl_HTBStatus);
            }));

            htbloaded = false;
            string htbQuery = File.ReadAllText(@"..\NDT Status\Joint Details\HTB.sql");
            htbJoints = Utilities.GetDBData(htbQuery);
        }        
        
        private void HTBLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("HTB JOINTS:", lbl_HTBStatus);
            }));
            pic_htb.Visible = true;
            htbloaded = true;
        }

        private void dgv_htb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (htbloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_htb.SelectedCells;
                    string[] selected = dgv_htb.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "HTB");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "HTB JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }        

        #endregion

        #region HTA Joints Transaction 

        private void HTALoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("HTA JOINTS: LOADING...", lbl_HTAStatus);
            }));

            htaloaded = false;
            string htaQuery = File.ReadAllText(@"..\NDT Status\Joint Details\HTA.sql");
            htaJoints = Utilities.GetDBData(htaQuery);
        }

        private void HTALoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("HTA JOINTS:", lbl_HTAStatus);
            }));
            pic_hta.Visible = true;
            htaloaded = true;
        }

        private void dgv_hta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (htaloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_hta.SelectedCells;
                    string[] selected = dgv_hta.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "HTA");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "HTA JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }
        
        #endregion

        #region PT Joint Transaction

        private void PTLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {

                this.ChangeLabel("PT JOINTS: LOADING...", lbl_PTStatus);
            }));

            ptloaded = false;
            string ptQuery = File.ReadAllText(@"..\NDT Status\Joint Details\PT.sql");
            ptJoints = Utilities.GetDBData(ptQuery);
        }

        private void PTLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("PT JOINTS:", lbl_PTStatus);
            }));
            pic_pt.Visible = true;
            ptloaded = true;
        }

        private void dgv_pt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (ptloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_pt.SelectedCells;
                    string[] selected = dgv_pt.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "PT");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "PT JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }

        #endregion

        #region FT

        private void FTLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("FT JOINTS: LOADING...", lbl_FTStatus);
            }));

            ftloaded = false;
            string ftQuery = File.ReadAllText(@"..\NDT Status\Joint Details\FT.sql");
            ftJoints = Utilities.GetDBData(ftQuery);
        }

        private void FTLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ChangeLabel("FT JOINTS:", lbl_FTStatus);
            }));
            pic_ft.Visible = true;
            ftloaded = true;
        }

        private void dgv_ft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (ftloaded)
                {
                    dgv_jointDetails.DataSource = null;
                    dgv_jointDetails.Rows.Clear();

                    var v = dgv_ft.SelectedCells;
                    string[] selected = dgv_ft.Rows[v[0].RowIndex].Cells[0].Value.ToString().Trim().Split(' ');
                    //INSERT CHECKING OF SUBCON
                    DisplayJointDetails(selected, "FT");
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "FT JOINTS STILL LOADING.", "PLEASE WAIT...", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }

        #endregion

    }
}
