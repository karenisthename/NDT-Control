using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.IO;
using MetroFramework;
using MetroFramework.Forms;
using System.Threading;



namespace NDT_Control
{
    public partial class frm_uploadData : MetroForm
    {
        useSQL.useSQL dbCon;
        public static string conStr;
        public NDT_Control.Data_Classes.NDTCollection newNDTColl;
        public static NDT_Control.Data_Classes.NDTCollection CleanNDT;
        NDT_Control.Data_Classes.NDTCollection allJoints = new Data_Classes.NDTCollection();
        NDT_Control.Data_Classes.NDTCollection verifiedJoints = new Data_Classes.NDTCollection();
        NDT_Control.Data_Classes.NDTCollection updatedJoints = new Data_Classes.NDTCollection();
        NDT_Control.Data_Classes.NDTCollection errorJoints = new Data_Classes.NDTCollection();
        NDT_Control.Data_Classes.NDTCollection loaderErrors = new Data_Classes.NDTCollection();
        DataTable lotno_verified = new DataTable();
        DataTable lotno_updated = new DataTable();
        DataTable lotno_errors = new DataTable();
        DataTable lotremarks = new DataTable();
        string ExcelPath = "";
        frmLoading newload = new frmLoading();
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\LOG.txt"; //@"..\RELEASE\LOG.txt";
        frm_menu mainMenu;

        public frm_uploadData(frm_menu mm)
        {
            InitializeComponent();
            //conStr = @"Server=KJD00093\SQL2012;Database=TRPCAKNPC;Trusted_Connection=True;";
            conStr = File.ReadAllText(@"..\ndtCon.cfg");
            mainMenu = mm;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            if(newNDTColl != null)
            {
              newNDTColl.Clear();
              CleanNDT.Clear();
            }

            this.ofd_fileOpen = new OpenFileDialog();

            if (ofd_fileOpen.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = ofd_fileOpen.FileName;                
            }

            pnl_NDT_Loader.Visible = false;
            
        }

        public void CheckFiles(string filepath)
        {
            ExcelPath = filepath;

            string fullpath = @"" + filepath.Replace(@"\", "/") + "/" + System.IO.Path.GetFileName(filepath);

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range firstCell = null;
            firstCell = xlWorkSheet.get_Range("A2", "B2");
            Excel.Range lastCell = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Excel.Range worksheetCells = xlWorkSheet.get_Range(firstCell, lastCell);

            var reports = new List<string[]>();

            string ndtfilelocation;

            DataSet ds = new DataSet();

            DataTable dt = new DataTable("ReportTable");
            dt.Columns.Add(new DataColumn("reportNo", typeof(string)));
            dt.Columns.Add(new DataColumn("comment", typeof(string)));

            for (int i = 1; i < worksheetCells.Rows.Count + 1; i++)
            {
                DataRow dr = dt.NewRow();
                string ndtType = "";

                if (worksheetCells.Value2[1, 2] == "PWHT")
                { 
                    ndtType = "PWHT";
                }
                else if (worksheetCells.Value2[1, 2] == "RT")
                {
                    ndtType = "RT";
                }
                else if (worksheetCells.Value2[1, 2] == "HTA")
                {
                    ndtType = "HTA";
                }
                else if (worksheetCells.Value2[1, 2] == "HTB")
                {
                    ndtType = "HTB";
                }
                else if (worksheetCells.Value2[1, 2] == "PT")
                {
                    ndtType = "PT";
                }
                else if (worksheetCells.Value2[1, 2] == "FT")
                {
                    ndtType = "FERRIT";
                }
                else if (worksheetCells.Value2[1, 2] == "PMI")
                {
                    ndtType = "PMI";
                }
                else if (worksheetCells.Value2[1, 2] == "TML")
                {
                    ndtType = "TML";
                }
                else if (worksheetCells.Value2[1, 2] == "BORESCOPE")
                {
                    ndtType = "BORESCOPE";
                }


                ndtfilelocation = "Z:/04 - Construction/04-Site Progress Report/ISOMETRICS/ABOVEGROUND/NDT/"+ ndtType +"/" + worksheetCells.Value2[i, 1] + ".pdf";
                string ndtmainLocation = @"" + ndtfilelocation.Replace(@"\", "/");


                if (File.Exists(ndtmainLocation))
                {
                    dr["reportNo"] = worksheetCells.Value2[i, 1];
                    dr["comment"] = "REPORT EXISTING";
                }
                else
                {
                    dr["reportNo"] = worksheetCells.Value2[i, 1];
                    dr["comment"] = "REPORT NOT EXIST";
                }

                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            xlWorkBook.Close(0);
            xlApp.Quit();

            ExporttoExcel(dt);
        }

        public NDT_Control.Data_Classes.NDTCollection ExtractExcelData(string filepath)
        {            
                ExcelPath = filepath;

                string fullpath = @"" + filepath.Replace(@"\", "/") + "/" + System.IO.Path.GetFileName(filepath);

                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Excel.Range firstCell = null;

                if (cmbMode.SelectedItem.ToString().Equals("Lot Loader") || cmbMode.SelectedItem.ToString().Equals("RT Remarks(FOR TP)")) 
                {
                    firstCell = xlWorkSheet.get_Range("A2", "F2");
                }
                else if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
                {
                    firstCell = xlWorkSheet.get_Range("A2", "I2");
                }
                else if (cmbMode.SelectedItem.ToString().Equals("R1/R2"))
                {
                    firstCell = xlWorkSheet.get_Range("A2", "I2");
                }

                Excel.Range lastCell = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range worksheetCells = xlWorkSheet.get_Range(firstCell, lastCell);

                newNDTColl = NDTData(worksheetCells);
                xlWorkBook.Close(0);
                xlApp.Quit();
                
                return DataChecking(newNDTColl);
        }

        public NDT_Control.Data_Classes.NDTCollection NDTData(Excel.Range xcelData)
        {
            NDT_Control.Data_Classes.NDTCollection NDTdataCollection = new Data_Classes.NDTCollection();
            Excel.Range NDT_data = null;

            for (int i = 1; i < xcelData.Rows.Count + 1; i++)
            {
                if (cmbMode.SelectedItem.ToString().Equals("Lot Loader") || cmbMode.SelectedItem.ToString().Equals("RT Remarks(FOR TP)"))
                {
                    NDT_data = xcelData.get_Range("A" + i, "F" + i);
                }
                else if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
                {
                    NDT_data = xcelData.get_Range("A" + i, "I" + i);
                }
                else if (cmbMode.SelectedItem.ToString().Equals("R1/R2"))
                {
                    NDT_data = xcelData.get_Range("A" + i, "I" + i);
                }

                if (NDT_data.Value2[1, 1] != null)
                {
                    NDT_Control.Data_Classes.NDT newNDT = new Data_Classes.NDT();

                    if (cmbMode.SelectedItem.ToString().Equals("Lot Loader") || cmbMode.SelectedItem.ToString().Equals("RT Remarks(FOR TP)"))
                    {
                        newNDT = new Data_Classes.NDT(Convert.ToString(NDT_data.Value2[1, 2]),
                                                                           Convert.ToString(NDT_data.Value2[1, 1]),
                                                                           Convert.ToString(NDT_data.Value2[1, 3]),
                                                                           Convert.ToString(NDT_data.Value2[1, 4]),
                                                                           Convert.ToString(NDT_data.Value2[1, 5]),
                                                                           Convert.ToString(NDT_data.Value2[1, 6])
                                                                           );
                    }
                    else if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
                    {
                        newNDT = new Data_Classes.NDT(Convert.ToString(NDT_data.Value2[1, 2]),
                                                                            Convert.ToString(NDT_data.Value2[1, 1]),
                                                                            Convert.ToString(NDT_data.Value2[1, 3]),
                                                                            Convert.ToString(NDT_data.Value2[1, 4]),
                                                                            Convert.ToString(NDT_data.Value2[1, 5]),
                                                                            Convert.ToString(NDT_data.Value2[1, 6]),
                                                                            Convert.ToString(NDT_data.Value2[1, 7]),
                                                                            Convert.ToString(NDT_data.Value2[1, 8]),
                                                                            Convert.ToString(NDT_data.Value2[1, 9])
                                                                            );
                    }
                    else if (cmbMode.SelectedItem.ToString().Equals("R1/R2"))
                    {
                        newNDT = new Data_Classes.NDT(Convert.ToString(NDT_data.Value2[1, 2]),
                                                    Convert.ToString(NDT_data.Value2[1, 1]),
                                                    Convert.ToString(NDT_data.Value2[1, 3]),
                                                    Convert.ToString(NDT_data.Value2[1, 4]),
                                                    Convert.ToString(NDT_data.Value2[1, 5]),
                                                    Convert.ToString(NDT_data.Value2[1, 6]),
                                                    Convert.ToString(NDT_data.Value2[1, 8]),
                                                    Convert.ToString(NDT_data.Value2[1, 7]),
                                                    Convert.ToString(NDT_data.Value2[1, 9]),
                                                    0
                                                    );

                    }

                    NDTdataCollection.Add(newNDT);
                }
            }

            return NDTdataCollection;
        }

        private void btn_NDTMain_Click(object sender, EventArgs e)
        {
            
        }

        private NDT_Control.Data_Classes.NDTCollection DataChecking(NDT_Control.Data_Classes.NDTCollection rawNDTData)
        {
            NDT_Control.Data_Classes.NDTCollection jointsRemove = new Data_Classes.NDTCollection();
            NDT_Control.Data_Classes.NDT dtNDT = new Data_Classes.NDT();

            DateTime dt;
            int cntNotExist = 0 ;
            #region Data Format Checking
            lbl_totaljoint.Text = rawNDTData.Count().ToString();

            foreach (NDT_Control.Data_Classes.NDT dta in rawNDTData)
            {
                int ctr = 0;
                if (cmbMode.SelectedItem.ToString().Equals("Lot Loader") || cmbMode.SelectedItem.ToString().Equals("RT Remarks(FOR TP)"))
                {
                    if ((!IsDigitsOnly(dta._unit)) || dta._unit.Length != 2)
                    {
                        dta.result = "INCORRECT FORMAT: UNIT";
                    }

                    if ((!IsDigitsOnly(dta._line)) || dta._line.Length != 6)
                    {
                        dta.result += "**INCORRECT FORMAT: LINE";
                    }

                    if (dta._joint.Length < 2) 
                    {
                        dta.result += "**INCORRECT FORMAT: Joint";
                    }

                    DataTable jointData = new DataTable();

                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        jointData = dbCon.PerformQuery("select *"
                                                        + " from joints WITH (NOLOCK) where Unit ='" + dta._unit
                                                        + "' and [Service] ='" + dta._service
                                                        + "' and Line ='" + dta._line
                                                        + "' and Train='" + dta._train
                                                        + "' and Jointnumber='" + dta._joint + "'");
                    }

                    if (jointData.Rows.Count == 0)
                    {
                        dta.result += "**Joint is not existing";
                    }

                    if (dta._remarks != "" && dta._remarks != null)
                    {
                        jointsRemove.Add(dta);
                    }
                }
                else if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
                {
                    if ((!IsDigitsOnly(dta._unit)) || dta._unit.Length != 2)
                    {
                        dta._remarks = "INCORRECT FORMAT: UNIT";
                    }

                    if ((!IsDigitsOnly(dta._line)) || dta._line.Length != 6)
                    {
                        dta._remarks += "**INCORRECT FORMAT: LINE";
                    }

                    if (!DateTime.TryParseExact(dta.date, new string[] { "yyyy/MM/dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        dta._remarks += "**INCORRECT FORMAT: Report Date";
                    }

                    DataTable jointData = new DataTable();
                    
                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        jointData = dbCon.PerformQuery("select *"
                                                        + " from joints WITH (NOLOCK) where Unit ='" + dta._unit
                                                        + "' and [Service] ='" + dta._service
                                                        + "' and Line ='" + dta._line
                                                        + "' and Train='" + dta._train
                                                        + "' and Jointnumber='" + dta._joint + "'");
                    }

                    if (jointData.Rows.Count == 0)
                    {
                        dta._remarks += "**Joint is not existing";
                        errorJoints.Add(dta);
                        allJoints.Add(dta);
                        ctr += 1;
                    }

                    if (!dta.report.Contains(dta.ndt_type))
                    {
                        dta._remarks += "**INCORRECT NDT TYPE";
                        errorJoints.Add(dta);
                        allJoints.Add(dta);
                        ctr += 1;
                    }

                    if (ctr > 0)
                    {
                        cntNotExist += 1;
                    }

                    if (dta._remarks != "" && dta._remarks != null)
                    {
                        jointsRemove.Add(dta);
                    }

                }
                else if (cmbMode.SelectedItem.ToString().Equals("R1/R2"))
                {
                    if ((!IsDigitsOnly(dta._unit)) || dta._unit.Length != 2)
                    {
                        dta.result = "INCORRECT FORMAT: UNIT";
                    }

                    if ((!IsDigitsOnly(dta._line)) || dta._line.Length != 6)
                    {
                        dta.result += "- INCORRECT FORMAT: LINE";
                    }

                    if ((!IsDigitsOnly(dta._train)) || dta._train.Length != 2)
                    {
                        dta.result += "- INCORRECT FORMAT: Train";
                    }

                    if (dta._joint.Length < 2)
                    {
                        dta.result += "- INCORRECT FORMAT: Joint";
                    }

                    DataTable jointData = new DataTable();

                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        jointData = dbCon.PerformQuery("select *"
                                                        + " from joints WITH (NOLOCK) where Unit ='" + dta._unit
                                                        + "' and [Service] ='" + dta._service
                                                        + "' and Line ='" + dta._line
                                                        + "' and Train='" + dta._train
                                                        + "' and Jointnumber='" + dta._joint + "'");
                    }

                    if (jointData.Rows.Count == 0)
                    {
                        dta.result += "- Joint is not existing";
                    }

                    if (dta.result != null)
                    {
                        jointsRemove.Add(dta);
                    }
                }

                lbl_loaderErrors.Text = cntNotExist.ToString();            
            }
            #endregion

            //Clean RawData
            foreach(NDT_Control.Data_Classes.NDT removeJoints in jointsRemove )
            {
                rawNDTData.Remove(removeJoints);

                string[] row = { removeJoints._unit, removeJoints._service, removeJoints._line, removeJoints._train, removeJoints._joint,
                                 removeJoints.report, removeJoints.date,removeJoints.result, removeJoints._remarks, removeJoints.ndt_type
                               };                
            }

            jointsRemove.Clear();

            if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
            {                 
                #region PCA Checking

                int cntError = 0, cntUpdated = 0;
                jointsRemove.Clear();

            foreach (NDT_Control.Data_Classes.NDT dta in rawNDTData)
            {
                DataTable jointData = new DataTable();

                using (dbCon = new useSQL.useSQL(conStr))
                {
                    jointData = dbCon.PerformQuery("select *,htp.htp as [testpacknum], htp.pt as [testeddate] FROM"
		                                            +"                (SELECT Size.EqSize AS Dia, j.* "
		                                            +"               FROM Joints j,Size WITH (NOLOCK) "
		                                            +"                WHERE j.JointSize=size.Jointsize) AS jts "
	                                                +"           LEFT JOIN"
		                                            +"                (SELECT * "
		                                            +"               FROM Spool with (NOLOCK) "
		                                            +"                WHERE Active=1) as sp"
		                                            +"               ON jts.service=sp.service" 
		                                            +"                AND jts.unit=sp.unit "
		                                            +"               AND jts.line=sp.line "
		                                            +"               AND jts.train=sp.train" 
		                                            +"                AND jts.spool=sp.spool"
	                                                +"            LEFT JOIN HTP ON HTP.HTP = SP.HTP"
                                                    +" where JTS.Unit ='" + dta._unit
                                                    + "' and JTS.[Service] ='" + dta._service
                                                    + "' and JTS.Line ='" + dta._line
                                                    + "' and JTS.Train='" + dta._train
                                                    + "' and JTS.Jointnumber='" + dta._joint + "'");
                }

                if (jointData.Rows.Count > 0)
                {
                    int ctr = 0;

                    if (jointData.Rows[0]["dateofweld"].ToString().Trim() == "")
                    {
                        dta._remarks += "**Missing DWR";
                        ctr += 1;
                    }

                    else if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["dateofweld"].ToString()))
                    {
                        dta._remarks += "**Report Date before DWR";
                        ctr += 1;
                    }

                    //RT RESHOOT
                    if (jointData.Rows[0]["RTAccepted"].ToString() == "False" && jointData.Rows[0]["RTNumber1"].ToString().Trim() != ""
                        &&
                        jointData.Rows[0]["RT1rej"].ToString() == "False"
                        )
                    {
                        dta._remarks += "**RT RESHOOT. CHECK RT REPORTS";
                        ctr += 1;
                    }

                    //RT REPAIR CHECKING 
                    if (jointData.Rows[0]["RT1rej"].ToString() == "True")
                    {
                        //FOR REJECTED RT
                        string rejecteddate = jointData.Rows[0]["RT3rej"].ToString() == "False" && jointData.Rows[0]["RT2rej"].ToString() == "True" ? jointData.Rows[0]["RTDate2"].ToString() : jointData.Rows[0]["RTDate1"].ToString();
                        if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(rejecteddate))
                        {
                            dta._remarks += "**RT REJECTED. REPORT DATE BEFORE RT REJECTED";
                            ctr += 1;
                        }

                        //FOR DWR
                        if (jointData.Rows[0]["ivisual2"].ToString().Trim() == "" && (jointData.Rows[0]["rtrejreason"].ToString().Contains("C/O") || jointData.Rows[0]["RTRemarks"].ToString().Contains("C/O")))
                        {
                            dta._remarks += "**JOINT IS CUT OUT";
                            ctr += 1;
                        }
                        else if (jointData.Rows[0]["ivisual2"].ToString().Trim() == "" && (!(jointData.Rows[0]["rtrejreason"].ToString().Contains("C/O")) || !(jointData.Rows[0]["RTRemarks"].ToString().Contains("C/O"))))
                        {
                            if ((jointData.Rows[0]["Active"].ToString() == "True"))
                            {
                                dta._remarks += "**PENDING REPAIR DWR(2nd)";
                            }
                            ctr += 1;
                        }
                        else
                        {
                            if ((jointData.Rows[0]["RT2rej"].ToString() == "False") && (Convert.ToDateTime(jointData.Rows[0]["ReparationDate"].ToString()) > Convert.ToDateTime(dta.date)))
                            {
                                dta._remarks += "**NDT TAKEN BEFORE THE REPAIR DWR(2nd)";
                                ctr += 1;
                            }
                            else
                            {
                                if (jointData.Rows[0]["RT2rej"].ToString() == "True" && jointData.Rows[0]["ivisual3"].ToString() == "")
                                {
                                    dta._remarks += "**PENDING REPAIR DWR(3rd)";
                                    ctr += 1;
                                    
                                }
                                else if (jointData.Rows[0]["RT2rej"].ToString() == "True" && jointData.Rows[0]["ivisual3"].ToString() != "")
                                {
                                    if (jointData.Rows[0]["Reparationdate2"].ToString().Trim() != "")
                                    {
                                        if (Convert.ToDateTime(jointData.Rows[0]["Reparationdate2"].ToString()) > Convert.ToDateTime(dta.date))
                                        {
                                            dta._remarks += "**NDT TAKEN BEFORE THE REPAIR DWR(3rd)";
                                            ctr += 1;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (dta._remarks != "" && dta._remarks != null )
                    {
                        cntError += 1;
                        errorJoints.Add(dta);
                    }
                  
                }

                if (jointData.Rows.Count > 0)
                {
                    int ctr = 0;
                    //REPORTCHECKING
                    if (dta.ndt_type == "PMI")
                    {
                        if(jointData.Rows[0]["PMINumber"].ToString().Trim() != "")
                        {
                            if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PMIDate"].ToString()))
                            {
                                dta._remarks += "**Existing report has latest date";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if(jointData.Rows[0]["PMInumber"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["PMIDate"].ToString() ))
                            {
                                dta._remarks += "**Already updated on PMI";
                                ctr +=1;
                                updatedJoints.Add(dta);
                            }
                         }
                    }

                    if (dta.ndt_type == "PT")
                    {
                        if(jointData.Rows[0]["PTNUMBER"].ToString().Trim() != "")
                        {
                            if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PTDATE"].ToString()))
                            {
                                dta._remarks += "**Existing report has latest date";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if(jointData.Rows[0]["PTNUMBER"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["PTDATE"].ToString()))
                            {
                                dta._remarks += "**Already updated on PT";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                        }
                    }

                    if (dta.ndt_type == "PWHT")
                    {
                        if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                        {
                            if (dta.date == jointData.Rows[0]["PWHTDate1"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT1"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on PWHT1";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["PWHTDate2"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT2"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on PWHT 2";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["PWHTDate3"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT3"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on PWHT 3";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                        }

                        if (jointData.Rows[0]["testeddate"].ToString().Trim() != "")
                        {
                            if (Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["testeddate"].ToString()))
                            {
                                dta._remarks += "**PWHT after Pressure Test: " + jointData.Rows[0]["testpacknum"].ToString() + " tested on " + jointData.Rows[0]["testeddate"].ToString();
                               
                                cntError += 1;
                                errorJoints.Add(dta);
                            }
                        }
                    }


                    if (dta.ndt_type == "HTA")
                    {
                        if (jointData.Rows[0]["HTDate1"].ToString().Trim() != "")
                        {
                            if (dta.date == jointData.Rows[0]["HTDate1"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT1"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HT 1";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["HTDate2"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT2"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HT 2";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["HTDate3"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT3"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HT 3";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                        }
                    }

                    if (dta.ndt_type == "HTB")
                    {
                        if (jointData.Rows[0]["HTBDATE"].ToString().Trim() != "")
                        {
                            if (dta.date == jointData.Rows[0]["HTBDate"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HTB 1";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["HTb2Date"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb2"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HTB 2";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                            else if (dta.date == jointData.Rows[0]["HTb3Date"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb3"].ToString().Trim()))
                            {
                                dta._remarks += "**Already uploaded on HTB 3";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                        }
                    }

                    if (dta.ndt_type == "FT")
                    {
                        if (jointData.Rows[0]["ferrit"].ToString().Trim() != "")
                        {
                            if (dta.date == jointData.Rows[0]["ferritdate"].ToString().Trim())
                            {
                                dta._remarks += "**Already uploaded on FT";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }   
                            else if(jointData.Rows[0]["ferrit"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["ferritdate"].ToString()))
                            {
                                dta._remarks += "**Already updated on FT";
                                ctr += 1;
                                updatedJoints.Add(dta);
                            }
                        }
                    }

                    if (ctr > 0)
                    { 
                        cntUpdated += 1;
                    }                
                }
                lbl_alreadyUpdated.Text = cntUpdated.ToString();

                if (dta._remarks != null)
                {
                    jointsRemove.Add(dta);
                }
                allJoints.Add(dta);
                lbl_errorjoints.Text = cntError.ToString();
            }
            #endregion            

                //Clean RawData FOR PCA CHECKING
                foreach (NDT_Control.Data_Classes.NDT removeJoints in jointsRemove)
                {
                    rawNDTData.Remove(removeJoints);
                }
            }


            foreach (NDT_Control.Data_Classes.NDT vjoints in rawNDTData)
            {
                verifiedJoints.Add(vjoints);
            }

            foreach (NDT_Control.Data_Classes.NDT dta in allJoints)
            {
                string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type
                                   };
                var additem = new ListViewItem(row);
                lst_removedJoints.Items.Add(additem);
            }

            return rawNDTData;
        }

        public bool IsDigitsOnly(string str)
        {
            if (str != null)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                allJoints.Clear();
                verifiedJoints.Clear();
                updatedJoints.Clear();
                errorJoints.Clear();
                loaderErrors.Clear();
                rd_all.Checked = true;

                if (cmbMode.SelectedItem == null)
                {
                   MetroMessageBox.Show(mainMenu, "PLEASE CHOOSE MODE.", "UPLOAD DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
                else if(txtFilePath.Text == "")
                {
                    MetroMessageBox.Show(mainMenu, "PLEASE SELECT EXCEL FILE.", "UPLOAD DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
                else
                {
                        if(cmbMode.SelectedItem.ToString().Equals("NDT File Check"))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            DataTable checkfilesdata = new DataTable();
                            checkfilesdata = Utilities.CheckFilesFromLoader(Utilities.ImportExcelData(txtFilePath.Text));
                            Utilities.ExportExcel(checkfilesdata, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "NDT FILE CHECKING" +".xlsx");

                            MetroMessageBox.Show(mainMenu, "LOADER VERIFIED!", "LOADER VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                        }
                        else if (cmbMode.SelectedItem.ToString().Equals("Remove NDT"))
                        {
                        
                        }
                        else if (cmbMode.SelectedItem.ToString().Equals("Lot Loader"))
                        {
                            
                            pnl_lotno.Visible = true;
                            pnl_NDT_Loader.Visible = false;
                            DataTable lotNum = new DataTable();
                            lotNum = Utilities.ImportExcelData(txtFilePath.Text);
                            if (!rd_lotno_upload.Checked && !rd_lotno_remove.Checked)
                            {
                                MessageBox.Show("REMOVE OR UPLOAD LOT NUMBERS? PLEASE CHOOSE REMOVE OR UPLOAD","LOT NUMBER REMOVE OR UPLOAD",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                            else if(rd_lotno_upload.Checked)
                            {
                                VerifyLotLoader(lotNum, 0);
                                MetroMessageBox.Show(mainMenu, "LOADER VERIFIED!", "LOADER VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                           
                            }
                            else 
                            {
                                VerifyLotLoader(lotNum, 1);
                                MetroMessageBox.Show(mainMenu, "LOADER VERIFIED!", "LOADER VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                           
                            };
                        }
                        else
                        {
                            backgroundWorker1.RunWorkerAsync();
                            pnl_lotno.Visible = false;
                            lst_removedJoints.Items.Clear();

                            //CHANGES
                            GetExcelData(txtFilePath.Text);
                            VerifyLoader(allJoints);

                            pnl_NDT_Loader.Visible = true;
                            MetroMessageBox.Show(mainMenu, "LOADER VERIFIED!", "LOADER VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                        }
                }
            }
            catch (Exception excp)
            {
                MetroMessageBox.Show(mainMenu, "CANNOT PROCEED. ERROR MESSAGE:" + excp.ToString(), "OOPS! SOMETHING WRONG", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
            }
        } 

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                ExporttoExcel(lst_removedJoints);
            }
            catch (Exception)
            {
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }

        }

        public void ExporttoExcel(ListView lstData)
        {
            Missing mv = Missing.Value;
            Microsoft.Office.Interop.Excel.Application NewExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook wkb = NewExcelApp.Workbooks.Add(mv);
            Excel.Worksheet wks = wkb.Sheets[1];

            for (int y = 0; y <= lstData.Columns.Count - 1; y++)
            {
                ((Excel.Range)wks.Cells[1, y + 1]).Value = lstData.Columns[y].Text;          
            }

            for (int x = 1; x <= lstData.Items.Count; x++)
            {
                for (int y = 0; y <= lstData.Columns.Count - 1; y++)
                {
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).NumberFormat = "@";
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).Value = lstData.Items[x - 1].SubItems[y].Text;  
                }
            }

            string filePath = System.IO.Path.GetDirectoryName(txtFilePath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(txtFilePath.Text) + " - Loader Correction.xlsx";

            wkb.SaveAs(filePath);
            wks = null;

            //System.Runtime.InteropServices.Marshal.ReleaseComObject(wkb);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(wks);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(NewExcelApp);
            NewExcelApp.Quit();

            MessageBox.Show("COMMENTS SUCCESSFULLY EXPORTED!", "LOADER COMMENTS");
        }

        public void ExporttoExcel(DataTable dt)
        {
            backgroundWorker1.RunWorkerAsync();
            Missing mv = Missing.Value;
            Microsoft.Office.Interop.Excel.Application NewExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook wkb = NewExcelApp.Workbooks.Add(mv);
            Excel.Worksheet wks = wkb.Sheets[1];

            for (int y = 0; y <= dt.Columns.Count - 1; y++)
            {
                ((Excel.Range)wks.Cells[1, y + 1]).Value = dt.Columns[y].ToString();
            }

            for (int x = 1; x <= dt.Rows.Count-1; x++)
            {
                for (int y = 0; y <= dt.Columns.Count - 1; y++)
                {
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).NumberFormat = "@";
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).Value = dt.Rows[x][y].ToString();
                }
            }

            string filePath = System.IO.Path.GetDirectoryName(txtFilePath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(txtFilePath.Text) + " - " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            wkb.SaveAs(filePath);
            wks = null;
            wkb = null;
            NewExcelApp.Quit();
            MessageBox.Show("COMMENTS SUCCESSFULLY EXPORTED!", "LOADER COMMENTS");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            try
            {
                UploadCleanNDT(verifiedJoints);
                MetroMessageBox.Show(mainMenu, "", "LOADER SUCCESSFULLY UPLOADED!" + " TOTAL UPDATED JOINTS: " + lbl_verifiedJoints.Text, MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            catch (Exception excpt)
            {
                MetroMessageBox.Show(mainMenu, "UPLOAD NOT SUCCESSFUL", "There's something wrong." + excpt.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

        public bool UploadCleanNDT(NDT_Control.Data_Classes.NDTCollection dataUpload)
        {
            string sqlUpdate = "";
            int reportCount = 0;
 
            foreach(NDT_Control.Data_Classes.NDT newData in dataUpload)
            {
                reportCount++;
                DataTable jointData = Utilities.GetNDTJointData(newData);

                if (cmbMode.SelectedItem.ToString().Equals("Lot Loader"))
                {
                        sqlUpdate = @"Update Joints set batchnum ='" + newData._remarks 
                                                     + "' where unit=" + newData._unit
                                                     + " and [Service]='" + newData._service
                                                     + "' and line='" + newData._line
                                                     + "' and train='" + newData._train
                                                     + "' and batchnum <>'" + newData._remarks 
                                                     + "'and JointNumber ='" + newData._joint + "'";
                }
                else if(cmbMode.SelectedItem.ToString().Equals("RT Remarks(FOR TP)"))
                {
                    sqlUpdate = @"Update Joints set RTRemarks ='" + newData._remarks
                                                    + "' where unit=" + newData._unit
                                                    + " and [Service]='" + newData._service
                                                    + "' and line='" + newData._line
                                                    + "' and train='" + newData._train
                                                    + "' and batchnum <>'" + newData._remarks
                                                    + "'and JointNumber ='" + newData._joint + "'";
                }
                else if (cmbMode.SelectedItem.ToString().Equals("NDT Loader"))
                {
                    #region NDTUpload

                    if (dataUpload.Count > 5)
                    { 
                        mainMenu.ChangeLowerLabel(reportCount, dataUpload.Count(), "UPLOADING NDT : ");
                    }

                    string res = newData.result == "ACC" ? "1" : "0";

                    if (newData.ndt_type == "PMI")
                    {
                        if (jointData.Rows[0]["PMINumber"].ToString().Trim() != newData.report.ToString() || (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["PMIDate"].ToString())))
                        {
                            sqlUpdate = @"Update Joints set PMInumber ='" + newData.report.Trim() + "', PMIDate  ='" + newData.date.Trim() + "', PMI=" + res
                                                         + " where unit='" + newData._unit
                                                         + "' and [Service]='" + newData._service
                                                         + "' and line='" + newData._line
                                                         + "' and train='" + newData._train
                                                         + "'and JointNumber ='" + newData._joint + "'";
                        }
                    }
                    else if (newData.ndt_type == "PT")
                    {
                        if (jointData.Rows[0]["PTNumber"].ToString().Trim() != newData.report.ToString() || (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["PTdate"].ToString())))
                        {
                            sqlUpdate = @"Update Joints set PTnumber ='" + newData.report.Trim() + "', PTDate  ='" + newData.date.Trim() + "', PT=" + res
                                                                      + " where unit='" + newData._unit
                                                                      + "' and [Service]='" + newData._service
                                                                      + "' and line='" + newData._line
                                                                      + "' and train='" + newData._train
                                                                      + "'and JointNumber ='" + newData._joint + "'";
                        }
                    }
                    else if (newData.ndt_type == "PWHT")
                    {
                        #region PWHT

                        if (jointData.Rows[0]["PWHT1"].ToString().Trim() == "")
                        {
                            sqlUpdate = @"Update Joints set PWHT1 ='" + newData.report + "', PWHTDATE1  ='" + newData.date + "', PWHTAccepted=" + res
                                + " where unit='" + newData._unit
                                + "' and [Service]='" + newData._service
                                + "' and line='" + newData._line
                                + "' and train='" + newData._train
                                + "'and JointNumber ='" + newData._joint + "'";
                        }
                        else if (jointData.Rows[0]["PWHT1"].ToString().Trim() != newData.report || jointData.Rows[0]["PWHTDATE1"].ToString().Trim() != newData.date)
                        {
                            if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "" && (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString())))
                            {
                                if (jointData.Rows[0]["PWHT2"].ToString().Trim() == "")
                                {
                                    sqlUpdate = @"Update Joints set PWHT1 ='" + newData.report + "', PWHTDATE1  ='" + newData.date + "', PWHTAccepted=" + res
                                                  + ",PWHT2 ='" + jointData.Rows[0]["PWHT1"].ToString() + "', PWHTDATE2  ='" + jointData.Rows[0]["PWHTdate1"].ToString()
                                                  + "' where unit='" + newData._unit
                                                  + "' and [Service]='" + newData._service
                                                  + "' and line='" + newData._line
                                                  + "' and train='" + newData._train
                                                  + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    if (jointData.Rows[0]["PWHT3"].ToString().Trim() == "")
                                    {
                                        sqlUpdate = @"Update Joints set PWHT1 ='" + newData.report + "', PWHTDATE1  ='" + newData.date + "', PWHTAccepted=" + res
                                                      + ",PWHT2 ='" + jointData.Rows[0]["PWHT1"].ToString() + "', PWHTDATE2  ='" + jointData.Rows[0]["PWHTdate1"].ToString()
                                                      + "' ,PWHT3 ='" + jointData.Rows[0]["PWHT2"].ToString() + "', PWHTDATE3  ='" + jointData.Rows[0]["PWHTdate2"].ToString()
                                                      + "' where unit='" + newData._unit
                                                      + "' and [Service]='" + newData._service
                                                      + "' and line='" + newData._line
                                                      + "' and train='" + newData._train
                                                      + "'and JointNumber ='" + newData._joint + "'";
                                    }
                                    else
                                    {
                                        sqlUpdate = @"Update Joints set PWHT1 ='" + newData.report + "', PWHTDATE1  ='" + newData.date + "', PWHTAccepted=" + res
                                                          + ",PWHT2 ='" + jointData.Rows[0]["PWHT1"].ToString() + "', PWHTDATE2  ='" + jointData.Rows[0]["PWHTdate1"].ToString()
                                                          + "',PWHT3 ='" + jointData.Rows[0]["PWHT2"].ToString() + "', PWHTDATE3  ='" + jointData.Rows[0]["PWHTdate2"].ToString()
                                                          + "',PWHT4 ='" + jointData.Rows[0]["PWHT3"].ToString() + "', PWHTDATE4  ='" + jointData.Rows[0]["PWHTdate3"].ToString()
                                                          + "' where unit='" + newData._unit
                                                          + "' and [Service]='" + newData._service
                                                          + "' and line='" + newData._line
                                                          + "' and train='" + newData._train
                                                          + "'and JointNumber ='" + newData._joint + "'";
                                    }
                                }
                            }
                            else if (jointData.Rows[0]["PWHT2"].ToString().Trim() != newData.report || jointData.Rows[0]["PWHTdate2"].ToString().Trim() != newData.date)
                            {

                                if ((jointData.Rows[0]["PWHTDate2"].ToString().Trim() == "") || (jointData.Rows[0]["PWHTDate2"].ToString().Trim() != "" && (Convert.ToDateTime(newData.date) < Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString()))))
                                {
                                    if (jointData.Rows[0]["PWHT3"].ToString().Trim() == "")
                                    {
                                        sqlUpdate = @"Update Joints set PWHT2 ='" + newData.report + "', PWHTDATE2  ='" + newData.date + "', PWHTAccepted=" + res
                                                             + ",PWHT3 ='" + jointData.Rows[0]["PWHT2"].ToString() + "', PWHTDATE3  ='" + jointData.Rows[0]["PWHTdate2"].ToString()
                                                             + "' where unit='" + newData._unit
                                                             + "' and [Service]='" + newData._service
                                                             + "' and line='" + newData._line
                                                             + "' and train='" + newData._train
                                                             + "'and JointNumber ='" + newData._joint + "'";
                                    }
                                    else
                                    {
                                        sqlUpdate = @"Update Joints set PWHT2 ='" + newData.report + "', PWHTDATE2  ='" + newData.date
                                                          + "',PWHT3 ='" + jointData.Rows[0]["PWHT2"].ToString() + "', PWHTDATE3  ='" + jointData.Rows[0]["PWHTdate2"].ToString()
                                                          + "',PWHT4 ='" + jointData.Rows[0]["PWHT3"].ToString() + "', PWHTDATE4  ='" + jointData.Rows[0]["PWHTdate3"].ToString()
                                                          + "' where unit='" + newData._unit
                                                          + "' and [Service]='" + newData._service
                                                          + "' and line='" + newData._line
                                                          + "' and train='" + newData._train
                                                          + "'and JointNumber ='" + newData._joint + "'";
                                    }
                                }
                            }
                            else if (jointData.Rows[0]["PWHT3"].ToString().Trim() != newData.report || jointData.Rows[0]["PWHTdate3"].ToString().Trim() != newData.date)
                            {
                                if ((jointData.Rows[0]["PWHTDate3"].ToString().Trim() == "") || (jointData.Rows[0]["PWHTDate3"].ToString().Trim() != "" && (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["PWHTDate3"].ToString()))))
                                {
                                    sqlUpdate = @"Update Joints set PWHT3 ='" + newData.report + "', PWHTDATE3  ='" + newData.date + "', PWHTAccepted=" + res
                                                        + "',PWHT4 ='" + jointData.Rows[0]["PWHT3"].ToString() + "', PWHTDATE4  ='" + jointData.Rows[0]["PWHTdate3"].ToString()
                                                        + "' where unit='" + newData._unit
                                                        + "' and [Service]='" + newData._service
                                                        + "' and line='" + newData._line
                                                        + "' and train='" + newData._train
                                                        + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set PWHT4 ='" + jointData.Rows[0]["PWHT3"].ToString() + "', PWHTDATE4  ='" + jointData.Rows[0]["PWHTdate3"].ToString()
                                                    + "', PWHTAccepted=" + res
                                                    + " where unit='" + newData._unit
                                                    + "' and [Service]='" + newData._service
                                                    + "' and line='" + newData._line
                                                    + "' and train='" + newData._train
                                                    + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                        }

                        #endregion
                    }
                    else if (newData.ndt_type == "HTA")
                    {
                        #region HTA
                        if (jointData.Rows[0]["HT1"].ToString().Trim() == "")
                        {
                            sqlUpdate = @"Update Joints set HT1 ='" + newData.report.Trim() + "', HTDate1  ='" + newData.date.Trim() + "', HTAAccepted=" + res
                                + " where unit='" + newData._unit
                                + "' and [Service]='" + newData._service
                                + "' and line='" + newData._line
                                + "' and train='" + newData._train
                                + "'and JointNumber ='" + newData._joint + "'";
                        }
                        else if (jointData.Rows[0]["HT1"].ToString().Trim() != newData.report.Trim() || jointData.Rows[0]["HTDate1"].ToString().Trim() != newData.date.Trim())
                        {
                            if (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["HTDate1"].ToString()))
                            {
                                if (jointData.Rows[0]["HT2"].ToString().Trim() == "")
                                {
                                    sqlUpdate = @"Update Joints set HT1 ='" + newData.report.Trim() + "', HTDate1  ='" + newData.date.Trim() + "', HTAAccepted=" + res
                                                  + ",HT2 ='" + jointData.Rows[0]["HT1"].ToString().Trim() + "', HTDate2  ='" + jointData.Rows[0]["HTDate1"].ToString().Trim()
                                                  + "' where unit='" + newData._unit
                                                  + "' and [Service]='" + newData._service
                                                  + "' and line='" + newData._line
                                                  + "' and train='" + newData._train
                                                  + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set HT1 ='" + newData.report.Trim() + "', HTDate1  ='" + newData.date.Trim() + "', HTAAccepted=" + res
                                                          + ",HT2 ='" + jointData.Rows[0]["HT1"].ToString() + "', HTDate2  ='" + jointData.Rows[0]["HTDate1"].ToString()
                                                          + "',HT3 ='" + jointData.Rows[0]["HT2"].ToString() + "', HTDate3  ='" + jointData.Rows[0]["HTDate2"].ToString()
                                                          + "' where unit='" + newData._unit
                                                          + "' and [Service]='" + newData._service
                                                          + "' and line='" + newData._line
                                                          + "' and train='" + newData._train
                                                          + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                            else if (jointData.Rows[0]["HT2"].ToString().Trim() != newData.report.Trim() || jointData.Rows[0]["HTDate2"].ToString().Trim() != newData.date.Trim())
                            {

                                if ((jointData.Rows[0]["HTDate2"].ToString().Trim() == "") || (jointData.Rows[0]["HTDate2"].ToString().Trim() != "" && (Convert.ToDateTime(newData.date) < Convert.ToDateTime(jointData.Rows[0]["HTDate1"].ToString()))))
                                {
                                    sqlUpdate = @"Update Joints set HT2 ='" + newData.report.Trim() + "', HTDate2  ='" + newData.date.Trim()
                                                      + "',HT3 ='" + jointData.Rows[0]["HT2"].ToString() + "', HTDate3  ='" + jointData.Rows[0]["HTDate2"].ToString()
                                                      + "' where unit='" + newData._unit
                                                      + "' and [Service]='" + newData._service
                                                      + "' and line='" + newData._line
                                                      + "' and train='" + newData._train
                                                      + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set HT3 ='" + newData.report.Trim() + "', HTDate3  ='" + newData.date.Trim() + "', HTAAccepted=" + res
                                                      + " where unit='" + newData._unit
                                                      + "' and [Service]='" + newData._service
                                                      + "' and line='" + newData._line
                                                      + "' and train='" + newData._train
                                                      + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                        }

                        #endregion
                    }
                    else if (newData.ndt_type == "HTB")
                    {
                        #region HTB
                        if (jointData.Rows[0]["HTB"].ToString().Trim() == "")
                        {
                            sqlUpdate = @"Update Joints set HTB ='" + newData.report.Trim() + "', HTBDate  ='" + newData.date.Trim() + "', HTBAccepted=" + res
                                + " where unit='" + newData._unit
                                + "' and [Service]='" + newData._service
                                + "' and line='" + newData._line
                                + "' and train='" + newData._train
                                + "'and JointNumber ='" + newData._joint + "'";
                        }
                        else if (jointData.Rows[0]["HTB"].ToString().Trim() != newData.report.Trim() || jointData.Rows[0]["HTBDate"].ToString().Trim() != newData.date)
                        {
                            if (Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["HTBDate"].ToString()))
                            {
                                if (jointData.Rows[0]["HTB2"].ToString().Trim() == "")
                                {
                                    sqlUpdate = @"Update Joints set HTB ='" + newData.report.Trim() + "', HTBDate  ='" + newData.date.Trim() + "', HTBAccepted=" + res
                                                  + ",HTB2 ='" + jointData.Rows[0]["HTB"].ToString() + "', HTB2Date  ='" + jointData.Rows[0]["HTBDate"].ToString()
                                                  + "' where unit='" + newData._unit
                                                  + "' and [Service]='" + newData._service
                                                  + "' and line='" + newData._line
                                                  + "' and train='" + newData._train
                                                  + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set HTB ='" + newData.report.Trim() + "', HTBDate  ='" + newData.date.Trim() + "', HTBAccepted=" + res
                                                          + ",HTB2 ='" + jointData.Rows[0]["HTB"].ToString() + "', HTB2Date  ='" + jointData.Rows[0]["HTBDate"].ToString()
                                                          + "',HTB3 ='" + jointData.Rows[0]["HTB2"].ToString() + "', HTB3Date  ='" + jointData.Rows[0]["HTB2Date"].ToString()
                                                          + "' where unit='" + newData._unit
                                                          + "' and [Service]='" + newData._service
                                                          + "' and line='" + newData._line
                                                          + "' and train='" + newData._train
                                                          + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                            else if (jointData.Rows[0]["HTB2"].ToString().Trim() != newData.report.Trim() || jointData.Rows[0]["HTB2Date"].ToString().Trim() != newData.date)
                            {
                                if ((jointData.Rows[0]["HTB2Date"].ToString().Trim() != "") || (jointData.Rows[0]["HTB2Date"].ToString().Trim() == "" && (Convert.ToDateTime(newData.date) < Convert.ToDateTime(jointData.Rows[0]["HTBDate"].ToString()))))
                                {
                                    sqlUpdate = @"Update Joints set HTB2 ='" + newData.report.Trim() + "', HTB2Date  ='" + newData.date.Trim()
                                                      + "',HTB3 ='" + jointData.Rows[0]["HTB2"].ToString() + "', HTB3Date  ='" + jointData.Rows[0]["HTB2Date"].ToString()
                                                      + "' where unit='" + newData._unit
                                                      + "' and [Service]='" + newData._service
                                                      + "' and line='" + newData._line
                                                      + "' and train='" + newData._train
                                                      + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set HTB3 ='" + newData.report.Trim() + "', HTB3Date  ='" + newData.date.Trim() + "', HTBAccepted=" + res
                                                         + "' where unit='" + newData._unit
                                                         + "' and [Service]='" + newData._service
                                                         + "' and line='" + newData._line
                                                         + "' and train='" + newData._train
                                                         + "'and JointNumber ='" + newData._joint + "'";

                                }
                            }

                        }

                        #endregion
                    }
                    else if (newData.ndt_type == "FT")
                    {
                        #region FT
                        if (jointData.Rows[0]["ferrit"].ToString().Trim() == "")
                        {
                            sqlUpdate = @"Update Joints set ferrit ='" + newData.report + "', ferritDate  ='" + newData.date + "', FerritAccepted=" + res
                                + " where unit='" + newData._unit
                                + "' and [Service]='" + newData._service
                                + "' and line='" + newData._line
                                + "' and train='" + newData._train
                                + "'and JointNumber ='" + newData._joint + "'";
                        }
                        else if (jointData.Rows[0]["ferrit"].ToString().Trim() != newData.report || jointData.Rows[0]["ferritDate"].ToString().Trim() != newData.date)
                        {
                            if (jointData.Rows[0]["ferritDate"].ToString().Trim() != "" && Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["ferritDate"].ToString()))
                            {
                                if (jointData.Rows[0]["ferrit2"].ToString().Trim() == "")
                                {
                                    sqlUpdate = @"Update Joints set ferrit ='" + newData.report + "', ferritDate  ='" + newData.date + "', FerritAccepted=" + res
                                                  + ",ferrit2 ='" + jointData.Rows[0]["ferrit"].ToString() + "', ferrit2Date  ='" + jointData.Rows[0]["ferritDate"].ToString()
                                                  + "' where unit='" + newData._unit
                                                  + "' and [Service]='" + newData._service
                                                  + "' and line='" + newData._line
                                                  + "' and train='" + newData._train
                                                  + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                    sqlUpdate = @"Update Joints set ferrit ='" + newData.report + "', ferritDate  ='" + newData.date + "', FerritAccepted=" + res
                                                          + ",ferrit2 ='" + jointData.Rows[0]["ferrit"].ToString() + "', ferrit2Date  ='" + jointData.Rows[0]["ferritDate"].ToString()
                                                          + "',ferrit3 ='" + jointData.Rows[0]["ferrit2"].ToString() + "', ferrit3Date  ='" + jointData.Rows[0]["ferrit2Date"].ToString()
                                                          + "' where unit='" + newData._unit
                                                          + "' and [Service]='" + newData._service
                                                          + "' and line='" + newData._line
                                                          + "' and train='" + newData._train
                                                          + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                            else if (jointData.Rows[0]["ferrit2"].ToString().Trim() != newData.report || jointData.Rows[0]["ferrit2Date"].ToString().Trim() != newData.date)
                            {
                                if (jointData.Rows[0]["ferrit2Date"].ToString().Trim() != "" && Convert.ToDateTime(newData.date) > Convert.ToDateTime(jointData.Rows[0]["ferrit2Date"].ToString()))
                                {
                                    sqlUpdate = @"Update Joints set ferrit2 ='" + newData.report + "', ferrit2Date  ='" + newData.date
                                                      + "',ferrit3 ='" + jointData.Rows[0]["ferrit2"].ToString() + "', ferrit3Date  ='" + jointData.Rows[0]["ferrit2Date"].ToString()
                                                      + "' where unit='" + newData._unit
                                                      + "' and [Service]='" + newData._service
                                                      + "' and line='" + newData._line
                                                      + "' and train='" + newData._train
                                                      + "'and JointNumber ='" + newData._joint + "'";
                                }
                                else
                                {
                                        sqlUpdate = @"Update Joints set ferrit3 ='" + newData.report + "', ferrit3Date  ='" + newData.date + "', FerritAccepted=" + res
                                                            + " where unit='" + newData._unit
                                                            + "' and [Service]='" + newData._service
                                                            + "' and line='" + newData._line
                                                            + "' and train='" + newData._train
                                                            + "'and JointNumber ='" + newData._joint + "'";
                                }
                            }
                        }

                        #endregion
                    }

                    List<string> logdata = new List<string>();
                    logdata.Add(newData._unit);
                    logdata.Add(newData._service);
                    logdata.Add(newData._line);
                    logdata.Add(newData._train);
                    logdata.Add(newData._joint);
                    logdata.Add(newData.report);
                    logdata.Add(System.IO.Path.GetFileName(txtFilePath.Text));
                    logdata.Add(DateTime.Now.ToString("yyyy/MM/dd"));
                    logdata.Add(Environment.UserName);

                    //Utilities.CheckLogExist();
                    Utilities.LogUpdateNDT(logdata);

                    #endregion
                }
                else if (cmbMode.SelectedItem.ToString().Equals("R1/R2"))
                {
                    DataTable dtWelders = new DataTable();
                    string script;
                    
                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        if (newData._remarks == "R1")
                        {
                             script = File.ReadAllText(@"..\QUERIES\R1.sql");
                        } 
                        else
                        {
                             script = File.ReadAllText(@"..\QUERIES\R2.sql");
                        }
                        
                        StringBuilder sb = new StringBuilder(script);
                        sb.Replace("@RepDate", newData.date);
                        sb.Replace("@Report", newData.report);
                        sb.Replace("@welder", newData._welder);
                        sb.Replace("@Unit", newData._unit);
                        sb.Replace("@Service", newData._service);
                        sb.Replace("@Line", newData._line);
                        sb.Replace("@Train", newData._train);
                        sb.Replace("@Joint", newData._joint);
                        
                        dtWelders = dbCon.PerformQuery(sb.ToString());
                    }
                }

                if (sqlUpdate != "")
                {
                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        dbCon.PerformQuery(sqlUpdate);
                    }
                }
            }

            return true;
        }

        private void frm_uploadData_Load(object sender, EventArgs e)
        {

        }

        private void pnl_NDT_Loader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rd_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_all.Checked)
            {
                lst_removedJoints.Items.Clear();

                foreach(NDT_Control.Data_Classes.NDT dta in allJoints)
                {
                    string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                    var additem = new ListViewItem(row);
                    lst_removedJoints.Items.Add(additem);
                }
            }
        }

        private void rd_verified_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_verified.Checked)
            {
                lst_removedJoints.Items.Clear();

                foreach(NDT_Control.Data_Classes.NDT dta in verifiedJoints)
                {
                    string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                    var additem = new ListViewItem(row);
                    lst_removedJoints.Items.Add(additem);
                }

            }
        }

        private void rd_Error_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Error.Checked)
            {
                lst_removedJoints.Items.Clear();
                foreach (NDT_Control.Data_Classes.NDT dta in errorJoints)
                {
                    string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                    var additem = new ListViewItem(row);
                    lst_removedJoints.Items.Add(additem);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Updated.Checked)
            {
                lst_removedJoints.Items.Clear();

                foreach (NDT_Control.Data_Classes.NDT dta in updatedJoints)
                {
                    string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                    var additem = new ListViewItem(row);
                    lst_removedJoints.Items.Add(additem);
                }
            }
        }
    
        //NEW METHODS
        private void GetExcelData(string excelPath)
        {
            DataTable exceldt = new DataTable();
            exceldt = Utilities.ImportExcelData(excelPath);

            for (int i = 0; i < exceldt.Rows.Count; i++)
            {
                int reportstatenum = i + 1;
                mainMenu.ChangeUpperLabel("TOTAL REPORTS:" + reportstatenum);
                if (exceldt.Rows[i][0].ToString() != "")
                { 
                     NDT_Control.Data_Classes.NDT ndtJoint = new Data_Classes.NDT();
                    ndtJoint._unit = exceldt.Rows[i][1].ToString().Trim();
                    ndtJoint._service = exceldt.Rows[i][0].ToString().Trim();
                    ndtJoint._line = exceldt.Rows[i][2].ToString().Trim();
                    ndtJoint._train = exceldt.Rows[i][3].ToString().Trim();
                    ndtJoint._joint = exceldt.Rows[i][4].ToString().Trim();
                    ndtJoint.report = exceldt.Rows[i][5].ToString().Trim();
                    ndtJoint.date = exceldt.Rows[i][6].ToString().Trim();
                    ndtJoint.result = exceldt.Rows[i][7].ToString().Trim();
                    ndtJoint.ndt_type = exceldt.Rows[i][8].ToString().Trim();

                    var jointData = Utilities.GetDBData("select *"
                                                         + " from joints WITH (NOLOCK) where Unit ='" + ndtJoint._unit
                                                         + "' and [Service] ='" + ndtJoint._service
                                                         + "' and Line ='" + ndtJoint._line
                                                         + "' and Train='" + ndtJoint._train
                                                         + "' and Jointnumber='" + ndtJoint._joint + "'");

                    if (jointData.Rows.Count > 0)
                    {
                        ndtJoint._active = jointData.Rows[0]["Active"].ToString() == "0" ? "CANCELED - " + jointData.Rows[0]["jointstate"].ToString().Trim() : "ACTIVE - " + jointData.Rows[0]["jointstate"].ToString().Trim();
                    }
                    else
                    {
                        ndtJoint._active = "";
                    }
                    allJoints.Add(ndtJoint);
                }
            }
        }

        private void VerifyLoader(NDT_Control.Data_Classes.NDTCollection loaderjoints)
        {
            var jointsCategorize = new Data_Classes.NDTCollection();
            jointsCategorize = loaderjoints;
            DateTime dt;
            int loadererrorCount = 0, errorJointsCount = 0, updatedreports = 0, verifiedjointscount = 0;

            //--FIRST CHECKING--//
            #region FormatChecking
            int a = 1;
            foreach (NDT_Control.Data_Classes.NDT dta in allJoints)
            {
                mainMenu.ChangeLowerLabel(a++, allJoints.Count(), "FIRST VERIFICATION:");
                if (dta._remarks == null)
                {
                    if ((!IsDigitsOnly(dta._unit)) || dta._unit.Length != 2)
                    {
                        dta._remarks = "**INCORRECT FORMAT: UNIT";
                    }

                    if ((!IsDigitsOnly(dta._line)) || dta._line.Length != 6)
                    {
                        dta._remarks += "**INCORRECT FORMAT: LINE";
                    }

                    if ((!DateTime.TryParseExact(dta.date, new string[] { "yyyy/MM/dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) || (Convert.ToDateTime(dta.date) > DateTime.Now))
                    {
                        dta._remarks += "**INCORRECT REPORT DATE.";
                    }

                    if (!dta.report.Contains(dta.ndt_type))
                    {
                        dta._remarks += "**INCORRECT NDT TYPE";
                    }

                    if (dta._remarks != null)
                    {
                        loaderErrors.Add(dta);
                        loadererrorCount++;
                    }
                }
            }

            #endregion

            //--SECOND Checking--//
            #region Joint Exist/Not Exist
            int b = 1;
            var jointData = new DataTable();
            foreach (NDT_Control.Data_Classes.NDT dta in allJoints)
            {
                mainMenu.ChangeLowerLabel(b++, allJoints.Count(), "SECOND VERIFICATION:");
                if (dta._remarks == null)
                { 
                     jointData = Utilities.GetDBData("select *"
                                                        + " from joints WITH (NOLOCK) where Unit ='" + dta._unit
                                                        + "' and [Service] ='" + dta._service
                                                        + "' and Line ='" + dta._line
                                                        + "' and Train='" + dta._train
                                                        + "' and Jointnumber='" + dta._joint + "'");


                     if (jointData.Rows.Count == 0)
                     {
                         dta._remarks += "**JOINT IS NOT EXISTING";
                     }
                     else
                     {
                         //=============================================DWR checking=============================================//
                         jointData = Utilities.GetDBData("select *,htp.htp as [testpacknum], htp.pt as [testeddate] , case when htp.targettest <> '' then 'QC TESTED DATE' else 'CONSTRUCTION TESTED DATE' end as [QCCONS] FROM"
                                                    + "                (SELECT Size.EqSize AS Dia, j.* "
                                                    + "               FROM Joints j,Size WITH (NOLOCK) "
                                                    + "                WHERE j.JointSize=size.Jointsize) AS jts "
                                                    + "           LEFT JOIN"
                                                    + "                (SELECT * "
                                                    + "               FROM Spool with (NOLOCK) "
                                                    + "                WHERE Active=1) as sp"
                                                    + "               ON jts.service=sp.service"
                                                    + "                AND jts.unit=sp.unit "
                                                    + "               AND jts.line=sp.line "
                                                    + "               AND jts.train=sp.train"
                                                    + "                AND jts.spool=sp.spool"
                                                    + "            LEFT JOIN HTP ON HTP.HTP = SP.HTP"
                                                    + " where JTS.Unit ='" + dta._unit
                                                    + "' and JTS.[Service] ='" + dta._service
                                                    + "' and JTS.Line ='" + dta._line
                                                    + "' and JTS.Train='" + dta._train
                                                    + "' and JTS.Jointnumber='" + dta._joint + "'");

                         if (jointData.Rows[0]["dateofweld"].ToString().Trim() == "")
                         {
                             dta._remarks += "**Missing DWR";
                         }
                         else if ((Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["dateofweld"].ToString())) && jointData.Rows[0]["rt1rej"].ToString().Equals("False"))
                         {
                             if (
                                 //PWHT
                                     (dta.ndt_type == "PWHT" && string.IsNullOrEmpty(jointData.Rows[0]["PWHT1"].ToString().Trim()) && jointData.Rows[0]["PWHT2"].ToString() == "" &&
                                         jointData.Rows[0]["PWHT3"].ToString() == ""
                                     )
                                     ||
                                 //HTA
                                      (dta.ndt_type == "HTA" && jointData.Rows[0]["HT1"].ToString() == "" && jointData.Rows[0]["HT2"].ToString() == "" &&
                                         jointData.Rows[0]["HT3"].ToString() == ""
                                      )
                                       ||
                                 //HTB
                                      (dta.ndt_type == "HTB" && jointData.Rows[0]["HTB"].ToString() == "" && jointData.Rows[0]["HTB2"].ToString() == "" &&
                                         jointData.Rows[0]["HTB3"].ToString() == ""
                                      )
                                      ||
                                 //PMI
                                      (dta.ndt_type == "PMI" && jointData.Rows[0]["PMINUMBER"].ToString() == ""
                                      )
                                      ||
                                 //PT
                                      (dta.ndt_type == "PT" && jointData.Rows[0]["PTNUMBER"].ToString() == ""
                                      )
                                       ||
                                 //FERRIT
                                      (dta.ndt_type == "FT" && jointData.Rows[0]["FERRIT"].ToString() == "" && jointData.Rows[0]["FERRIT2"].ToString() == "" &&
                                         jointData.Rows[0]["FERRIT3"].ToString() == ""
                                      )
                                 )
                             {
                                 dta._remarks += "**Report Date before DWR";
                             }
                         }

                         //=============================================RT Rejected ,PWHT after TP AND other NDT conditions checking=============================================//

                         if (jointData.Rows[0]["RTAccepted"].ToString() == "False" && jointData.Rows[0]["RTNumber1"].ToString().Trim() != "" && jointData.Rows[0]["RT1rej"].ToString() == "False")
                         {
                             dta._remarks += "**RT RESHOOT. CHECK RT REPORTS";
                         }

                         if (jointData.Rows[0]["ivisual2"].ToString().Trim() == "" && (jointData.Rows[0]["rtrejreason"].ToString().Contains("C/O") || jointData.Rows[0]["RTRemarks"].ToString().Contains("C/O")))
                         {
                             dta._remarks += "**JOINT IS CUT OUT";
                         }
                         else
                         {
                             if (jointData.Rows[0]["RT1rej"].ToString() == "True")
                             {
                                 string rejecteddate = GetRejectedDate(jointData);

                                 if (rejecteddate.Contains("PENDING"))
                                 {
                                     dta._remarks += rejecteddate;
                                 }
                                 else
                                 {
                                     if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(rejecteddate))
                                     {
                                         dta._remarks += "**REPORT DATE BEFORE REPAIR DWR";
                                     }
                                 }
                             }

                             //NDT RESTRICTIONS CHECKING
                             if(dta.ndt_type.Contains("PWHT"))
                             {
                                 if (jointData.Rows[0]["HTDate1"].ToString().Trim() != "")
                                 { 
                                        if((Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["HTDate1"].ToString().Trim())) && jointData.Rows[0]["HTaAccepted"].ToString().Equals("True"))
                                        {
                                            dta._remarks += "**REMOVE/UNCHECK HTA ACCEPTED. PENDING TO TAKE ANOTHER HTA. CHECK JOINT NDT.";
                                        }
                                 }

                                 if (jointData.Rows[0]["PTDate"].ToString().Trim() != "")
                                 {
                                     if ((Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["PTDate"].ToString().Trim())) && jointData.Rows[0]["pt"].ToString().Equals("True"))
                                        {
                                            dta._remarks += "**REMOVE/UNCHECK PT ACCEPTED. PENDING TO TAKE ANOTHER PT. CHECK JOINT NDT.";
                                        }
                                 }

                                 if (jointData.Rows[0]["htbdate"].ToString().Trim() != "")
                                 {
                                     if ((Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["htbdate"].ToString().Trim())) && jointData.Rows[0]["htbaccepted"].ToString().Equals("True"))
                                    {
                                        dta._remarks += "**REMOVE/UNCHECK HTB ACCEPTED. PENDING TO TAKE ANOTHER HTB. CHECK JOINT NDT.";
                                    }

                                 }

                                 if (jointData.Rows[0]["ferritdate"].ToString().Trim() != "")
                                 {
                                     if ((Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["ferritdate"].ToString().Trim())) && jointData.Rows[0]["ferritaccepted"].ToString().Equals("True"))
                                     {
                                         dta._remarks += "**REMOVE/UNCHECK FT ACCEPTED. PENDING TO TAKE ANOTHER FT. CHECK JOINT NDT.";
                                     }
                                 }


                                if (jointData.Rows[0]["testeddate"].ToString().Trim() != "")
                                {
                                    if (Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["testeddate"].ToString()))
                                    {
                                        dta._remarks += "**PWHT after Pressure Test: " + jointData.Rows[0]["testpacknum"].ToString() + " tested on " + jointData.Rows[0]["testeddate"].ToString().Trim() + "(" + jointData.Rows[0]["QCCONS"].ToString() + ")";
                                    }
                                }
                             }
                             else if (dta.ndt_type.Contains("HTA"))
                             {
                                 if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                                 {
                                     if(Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString().Trim()))
                                     {
                                         dta._remarks += "**REPORT DATE BEFORE PWHT DATE. CHECK JOINT AND NDT.";
                                     }
                                 }
                             }
                             else if(dta.ndt_type.Contains("HTB"))
                             {
                                 if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                                 {
                                     if(Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString().Trim()))
                                     {
                                        dta._remarks += "**REPORT DATE AFTER PWHT DATE. CHECK JOINT AND NDT.";
                                     }
                                 }
                             }
                             else if(dta.ndt_type.Contains("PT"))
                             {
                                 if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                                 {
                                     if(Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString().Trim()))
                                     {
                                        dta._remarks += "**REPORT DATE BEFORE PWHT DATE. CHECK JOINT AND NDT.";
                                     }
                                 }
                             }
                             else if(dta.ndt_type.Contains("FT"))
                             {
                                 if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                                 {
                                     if(Convert.ToDateTime(dta.date) > Convert.ToDateTime(jointData.Rows[0]["PWHTDate1"].ToString().Trim()))
                                     {
                                        dta._remarks += "**REPORT DATE AFTER PWHT DATE. CHECK JOINT AND NDT.";
                                     }
                                 }
                             }
                         }
                     }

                    if (dta._remarks != null)
                    {
                        errorJoints.Add(dta);
                        errorJointsCount++;
                    }               
                }
            }
           
            #endregion            

            //--THIRD Checking 
            #region Existing Report
            int c = 0;
            foreach (NDT_Control.Data_Classes.NDT dta in allJoints)
            {
                if (!((!DateTime.TryParseExact(dta.date, new string[] { "yyyy/MM/dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) || (Convert.ToDateTime(dta.date) > DateTime.Now)))
                {
                    mainMenu.ChangeLowerLabel(c++, allJoints.Count(), "THIRD VERIFICATION:");
                    jointData = Utilities.GetDBData("select *,htp.htp as [testpacknum], htp.pt as [testeddate] FROM"
                                                   + "                (SELECT Size.EqSize AS Dia, j.* "
                                                   + "               FROM Joints j,Size WITH (NOLOCK) "
                                                   + "                WHERE j.JointSize=size.Jointsize) AS jts "
                                                   + "           LEFT JOIN"
                                                   + "                (SELECT * "
                                                   + "               FROM Spool with (NOLOCK) "
                                                   + "                WHERE Active=1) as sp"
                                                   + "               ON jts.service=sp.service"
                                                   + "                AND jts.unit=sp.unit "
                                                   + "               AND jts.line=sp.line "
                                                   + "               AND jts.train=sp.train"
                                                   + "                AND jts.spool=sp.spool"
                                                   + "            LEFT JOIN HTP ON HTP.HTP = SP.HTP"
                                                   + " where JTS.Unit ='" + dta._unit
                                                   + "' and JTS.[Service] ='" + dta._service
                                                   + "' and JTS.Line ='" + dta._line
                                                   + "' and JTS.Train='" + dta._train
                                                   + "' and JTS.Jointnumber='" + dta._joint + "'");

                    if (jointData.Rows.Count > 0)
                    {
                        if (dta.ndt_type == "PMI")
                        {
                            if (jointData.Rows[0]["PMINumber"].ToString().Trim() != "")
                            {
                                if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PMIDate"].ToString()))
                                {
                                    dta._remarks += "**Existing report has latest date";
                                }
                                else if (jointData.Rows[0]["PMInumber"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["PMIDate"].ToString()))
                                {
                                    dta._remarks += "**Already updated on PMI";
                                }
                            }
                        }

                        if (dta.ndt_type == "PT")
                        {
                            if (jointData.Rows[0]["PTNUMBER"].ToString().Trim() != "")
                            {
                                if (Convert.ToDateTime(dta.date) < Convert.ToDateTime(jointData.Rows[0]["PTDATE"].ToString()))
                                {
                                    dta._remarks += "**Existing report has latest date";
                                }
                                else if (jointData.Rows[0]["PTNUMBER"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["PTDATE"].ToString()))
                                {
                                    dta._remarks += "**Already updated on PT";
                                }
                            }
                        }

                        if (dta.ndt_type == "PWHT")
                        {
                            if (jointData.Rows[0]["PWHTDate1"].ToString().Trim() != "")
                            {
                                if (dta.date == jointData.Rows[0]["PWHTDate1"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT1"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on PWHT1";
                                }
                                else if (dta.date == jointData.Rows[0]["PWHTDate1"].ToString().Trim() && (dta.report.Trim() != jointData.Rows[0]["PWHT1"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 1 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                                else if (dta.date != jointData.Rows[0]["PWHTDate1"].ToString().Trim() && (dta.report.Trim()== jointData.Rows[0]["PWHT1"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 1 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                                else if (dta.date == jointData.Rows[0]["PWHTDate2"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT2"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on PWHT 2";
                                }
                                else if (dta.date == jointData.Rows[0]["PWHTDate2"].ToString().Trim() && (dta.report.Trim() != jointData.Rows[0]["PWHT2"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 2 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                                else if (dta.date != jointData.Rows[0]["PWHTDate2"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT2"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 2 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                                else if (dta.date == jointData.Rows[0]["PWHTDate3"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT3"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on PWHT 3";
                                }
                                else if (dta.date == jointData.Rows[0]["PWHTDate3"].ToString().Trim() && (dta.report.Trim() != jointData.Rows[0]["PWHT3"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 3 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                                else if (dta.date != jointData.Rows[0]["PWHTDate3"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["PWHT3"].ToString().Trim()))
                                {
                                    dta._remarks += "**EXISTING PWHT 3 REPORT ERROR. CHECK PWHT REPORT.";
                                }
                            }
                        }


                        if (dta.ndt_type == "HTA")
                        {
                            if (jointData.Rows[0]["HTDate1"].ToString().Trim() != "")
                            {
                                if (dta.date == jointData.Rows[0]["HTDate1"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT1"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HT 1";
                                }
                                else if (dta.date == jointData.Rows[0]["HTDate2"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT2"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HT 2";
                                }
                                else if (dta.date == jointData.Rows[0]["HTDate3"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["HT3"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HT 3";
                                }
                            }
                        }

                        if (dta.ndt_type == "HTB")
                        {
                            if (jointData.Rows[0]["HTBDATE"].ToString().Trim() != "")
                            {
                                if (dta.date == jointData.Rows[0]["HTBDate"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HTB 1";
                                }
                                else if (dta.date == jointData.Rows[0]["HTb2Date"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb2"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HTB 2";
                                }
                                else if (dta.date == jointData.Rows[0]["HTb3Date"].ToString().Trim() && (dta.report.Trim() == jointData.Rows[0]["htb3"].ToString().Trim()))
                                {
                                    dta._remarks += "**Already uploaded on HTB 3";
                                }
                            }
                        }

                        if (dta.ndt_type == "FT")
                        {
                            if (jointData.Rows[0]["ferrit"].ToString().Trim() != "")
                            {
                                if (dta.date == jointData.Rows[0]["ferritdate"].ToString().Trim())
                                {
                                    dta._remarks += "**Already uploaded on FT";
                                }
                                else if (jointData.Rows[0]["ferrit"].ToString() == dta.report && Convert.ToDateTime(dta.date) == Convert.ToDateTime(jointData.Rows[0]["ferritdate"].ToString()))
                                {
                                    dta._remarks += "**Already updated on FT";
                                }
                            }
                        }
                    }

                    if (dta._remarks != null && (dta._remarks.Contains("Already") || dta._remarks.Contains("latest date")))
                    {
                        updatedJoints.Add(dta);
                        updatedreports++;
                    }
                }
            }
            #endregion

            foreach (NDT_Control.Data_Classes.NDT dta in allJoints)
            { 
                if(dta._remarks == null)
                {
                    verifiedJoints.Add(dta);
                    verifiedjointscount++;
                }
            }

            foreach(NDT_Control.Data_Classes.NDT dta in allJoints)
            {
                string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                var additem = new ListViewItem(row);
                lst_removedJoints.Items.Add(additem);
            }

            lbl_alreadyUpdated.Text = updatedreports.ToString();
            lbl_errorjoints.Text = errorJointsCount.ToString();
            lbl_loaderErrors.Text = loadererrorCount.ToString();
            lbl_verifiedJoints.Text = verifiedjointscount.ToString();
            lbl_totaljoint.Text = allJoints.Count().ToString();
        }

        private void VerifyLotLoader(DataTable lotloaderdata, int mode)
        {
            lv_lotnumbers.Clear();
            LotNumbersClearItems();
            DataTable jointData = new DataTable();
            int verified = 0, updated = 0, errors = 0;

            if (mode.Equals(0)) //UPLOAD
            {
                #region UPLOAD
                if (!lotloaderdata.Columns[0].ToString().ToUpper().Equals("SERVICE") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("UNIT") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("LINE") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("TRAIN") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("JOINT") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("LOT NUMBER")
                   )
                {
                    MetroMessageBox.Show(mainMenu, "INCORRECT LOADER FORMAT. CHECK THE CORRECT FORMAT IN FORMAT MODULE.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
                }
                else
                {
                    foreach (DataRow dr in lotloaderdata.Rows)
                    {
                        DataRow remarksDr = lotremarks.NewRow();

                        if ((!IsDigitsOnly(dr[1].ToString().Trim())) || dr[1].ToString().Trim().Length != 2)
                        {
                            remarksDr[0] = dr[1].ToString();
                            remarksDr[1] = dr[0].ToString();
                            remarksDr[2] = dr[2].ToString();
                            remarksDr[3] = dr[3].ToString();
                            remarksDr[4] = dr[4].ToString();
                            remarksDr[5] = dr[5].ToString().Trim();
                            remarksDr[6] = "";

                            remarksDr[7] = "**INCORRECT FORMAT: UNIT";
                            errors++;
                            lotno_errors.Rows.Add(remarksDr.ItemArray);
                        }
                        else if ((!IsDigitsOnly(dr[2].ToString().Trim())) || dr[2].ToString().Trim().Length != 6)
                        {
                            remarksDr[0] = dr[1].ToString();
                            remarksDr[1] = dr[0].ToString();
                            remarksDr[2] = dr[2].ToString();
                            remarksDr[3] = dr[3].ToString();
                            remarksDr[4] = dr[4].ToString();
                            remarksDr[5] = dr[5].ToString().Trim();
                            remarksDr[6] = "";
                            remarksDr[7] = "**INCORRECT FORMAT: LINE";
                            errors++;
                            lotno_errors.Rows.Add(remarksDr.ItemArray);
                        }
                        else
                        {
                            jointData = Utilities.GetDBData("select UNIT,SERVICE,LINE,TRAIN, JOINTNUMBER, BATCHNUM"
                                      + " from joints WITH (NOLOCK) where Unit ='" + dr[1].ToString().Trim()
                                      + "' and [Service] ='" + dr[0].ToString().Trim()
                                      + "' and Line ='" + dr[2].ToString().Trim()
                                      + "' and Train='" + dr[3].ToString().Trim()
                                      + "' and Jointnumber='" + dr[4].ToString().Trim() + "'");

                            remarksDr[0] = jointData.Rows[0]["UNIT"].ToString().Trim();
                            remarksDr[1] = jointData.Rows[0]["SERVICE"].ToString().Trim();
                            remarksDr[2] = jointData.Rows[0]["LINE"].ToString().Trim();
                            remarksDr[3] = jointData.Rows[0]["TRAIN"].ToString().Trim();
                            remarksDr[4] = jointData.Rows[0]["JOINTNUMBER"].ToString().Trim();
                            remarksDr[5] = dr[5].ToString().Trim();
                            remarksDr[6] = jointData.Rows[0]["BATCHNUM"].ToString().Trim();

                            if (jointData.Rows.Count == 0)
                            {
                                remarksDr[7] = "**JOINT IS NOT EXISTING";
                                errors++;
                                lotno_errors.Rows.Add(remarksDr.ItemArray);
                            }
                            else if ((jointData.Rows[0]["batchnum"].ToString().Trim() != dr[5].ToString()) && (jointData.Rows[0]["batchnum"].ToString().Trim() != ""))
                            {
                                remarksDr[7] = "**DIFFERENT OLD LOTNUMBER - OVERWRITE OLD";
                                verified++;
                                lotno_verified.Rows.Add(remarksDr.ItemArray);
                            }
                            else if (jointData.Rows[0]["batchnum"].ToString().Trim() == dr[5].ToString())
                            {
                                remarksDr[7] = "**SAME OLD LOTNUMBER";
                                updated++;
                                lotno_updated.Rows.Add(remarksDr.ItemArray);
                            }
                            else
                            {
                                remarksDr[7] = "";
                                verified++;
                                lotno_verified.Rows.Add(remarksDr.ItemArray);
                            }
                        }

                        lotremarks.Rows.Add(remarksDr);
                    }
                }
                #endregion
            }
            else
            {
                #region REMOVE
                if (!lotloaderdata.Columns[0].ToString().ToUpper().Equals("SERVICE") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("UNIT") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("LINE") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("TRAIN") &&
                    !lotloaderdata.Columns[0].ToString().ToUpper().Equals("JOINT")
                   )
                {
                    MessageBox.Show("INCORRECT LOADER FORMAT. CHECK THE CORRECT FORMAT IN FORMAT MODULE.");
                }
                else
                {
                    foreach (DataRow dr in lotloaderdata.Rows)
                    {
                        DataRow remarksDr = lotremarks.NewRow();

                        if ((!IsDigitsOnly(dr[1].ToString().Trim())) || dr[1].ToString().Trim().Length != 2)
                        {
                            remarksDr[0] = dr[1].ToString();
                            remarksDr[1] = dr[0].ToString();
                            remarksDr[2] = dr[2].ToString();
                            remarksDr[3] = dr[3].ToString();
                            remarksDr[4] = dr[4].ToString();
                            remarksDr[5] = "";
                            remarksDr[6] = "";

                            remarksDr[7] = "**INCORRECT FORMAT: UNIT";
                            errors++;
                            lotno_errors.Rows.Add(remarksDr.ItemArray);
                        }
                        else if ((!IsDigitsOnly(dr[2].ToString().Trim())) || dr[2].ToString().Trim().Length != 6)
                        {
                            remarksDr[0] = dr[1].ToString();
                            remarksDr[1] = dr[0].ToString();
                            remarksDr[2] = dr[2].ToString();
                            remarksDr[3] = dr[3].ToString();
                            remarksDr[4] = dr[4].ToString();
                            remarksDr[5] = "";
                            remarksDr[6] = "";
                            remarksDr[7] = "**INCORRECT FORMAT: LINE";
                            errors++;
                            lotno_errors.Rows.Add(remarksDr.ItemArray);
                        }
                        else
                        {
                            jointData = Utilities.GetDBData("select UNIT,SERVICE,LINE,TRAIN, JOINTNUMBER, BATCHNUM"
                                      + " from joints WITH (NOLOCK) where Unit ='" + dr[1].ToString().Trim()
                                      + "' and [Service] ='" + dr[0].ToString().Trim()
                                      + "' and Line ='" + dr[2].ToString().Trim()
                                      + "' and Train='" + dr[3].ToString().Trim()
                                      + "' and Jointnumber='" + dr[4].ToString().Trim() + "'");

                            remarksDr[0] = jointData.Rows[0]["UNIT"].ToString().Trim();
                            remarksDr[1] = jointData.Rows[0]["SERVICE"].ToString().Trim();
                            remarksDr[2] = jointData.Rows[0]["LINE"].ToString().Trim();
                            remarksDr[3] = jointData.Rows[0]["TRAIN"].ToString().Trim();
                            remarksDr[4] = jointData.Rows[0]["JOINTNUMBER"].ToString().Trim();
                            remarksDr[5] = "";
                            remarksDr[6] = jointData.Rows[0]["BATCHNUM"].ToString().Trim();

                            if (jointData.Rows.Count == 0)
                            {
                                remarksDr[7] = "**JOINT IS NOT EXISTING";
                                errors++;
                                lotno_errors.Rows.Add(remarksDr.ItemArray);
                            }
                            else if (jointData.Rows[0]["batchnum"].ToString().Trim() != "")
                            {
                                remarksDr[7] = "**REMOVE OLD LOT NUMBER";
                                verified++;
                                lotno_verified.Rows.Add(remarksDr.ItemArray);
                            }
                            else
                            {
                                remarksDr[7] = "";
                                verified++;
                                lotno_verified.Rows.Add(remarksDr.ItemArray);
                            }
                        }
                        lotremarks.Rows.Add(remarksDr);
                    }
                }
                #endregion
            }

            lbl_lotno_error.Text = errors.ToString();
            lbl_lotno_total.Text = lotloaderdata.Rows.Count.ToString();
            lbl_lotno_updated.Text = updated.ToString();
            lbl_lotno_verified.Text = verified.ToString();
            Utilities.DTtoLV(lotremarks,lv_lotnumbers);
        }

        private void rd_loaderError_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_loaderError.Checked)
            {
                lst_removedJoints.Items.Clear();
                foreach (NDT_Control.Data_Classes.NDT dta in loaderErrors)
                {
                    string[] row = { dta._unit, dta._service, dta._line, dta._train, dta._joint,
                                     dta.report, dta.date,dta.result, dta._remarks, dta.ndt_type, dta._active
                                   };
                    var additem = new ListViewItem(row);
                    lst_removedJoints.Items.Add(additem);
                }
            }
        }

        private string GetRejectedDate(DataTable jointData)
        {
            string returnDate = jointData.Rows[0]["RTdate1"].ToString();


            if (jointData.Rows[0]["ivisual2"].ToString().Trim() == "")
            {
                 returnDate = "**PENDING DWR REPAIR REPORT(1st)";
            }
            else if (jointData.Rows[0]["RT2Rej"].ToString().Trim() == "True" && jointData.Rows[0]["ivisual3"].ToString() == "")
            {
                 returnDate = "**PENDING DWR REPAIR REPORT(2nd)";
            }
            else
            {
                if (jointData.Rows[0]["ivisual3"].ToString().Trim() != "")
                {
                    returnDate = jointData.Rows[0]["reparationDate2"].ToString().Trim();
                }
                else if (jointData.Rows[0]["ivisual2"].ToString().Trim() != "" && jointData.Rows[0]["ivisual3"].ToString().Trim() == "")
                {
                    returnDate = jointData.Rows[0]["reparationDate"].ToString();
                }
            }

            return returnDate;
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedItem.ToString().Equals("Lot Loader"))
            {
                rd_lotno_remove.Visible = true;
                rd_lotno_upload.Visible = true;
                InitializeLotNumbersColumns();
            }
            else
            {
                rd_lotno_remove.Visible = false;
                rd_lotno_upload.Visible = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mainMenu.StartLoading();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainMenu.CloseLoading();
        }

        private void rd_lotno_verified_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_lotno_verified.Checked)
            {
                lv_lotnumbers.Items.Clear();
                foreach (DataRow dta in lotno_verified.Rows)
                {
                    string[] row = { dta[0].ToString(),dta[1].ToString(),dta[2].ToString(),dta[3].ToString(),
                                       dta[4].ToString(),dta[5].ToString(),dta[6].ToString(),
                                       dta[7].ToString()
                                   };
                    var additem = new ListViewItem(row);
                    lv_lotnumbers.Items.Add(additem);
                }
            }
        }

        private void rd_lotno_updated_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_lotno_updated.Checked)
            {
                lv_lotnumbers.Items.Clear();
                foreach (DataRow dta in lotno_updated.Rows)
                {
                    string[] row = { dta[0].ToString(),dta[1].ToString(),dta[2].ToString(),dta[3].ToString(),
                                       dta[4].ToString(),dta[5].ToString(),dta[6].ToString(),
                                       dta[7].ToString()
                                   };
                    var additem = new ListViewItem(row);
                    lv_lotnumbers.Items.Add(additem);
                }
            }
        }

        private void rd_lotno_errors_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_lotno_errors.Checked)
            {
                lv_lotnumbers.Items.Clear();
                foreach (DataRow dta in lotno_errors.Rows)
                {
                    string[] row = { dta[0].ToString(),dta[1].ToString(),dta[2].ToString(),dta[3].ToString(),
                                       dta[4].ToString(),dta[5].ToString(),dta[6].ToString(),
                                       dta[7].ToString()
                                   };
                    var additem = new ListViewItem(row);
                    lv_lotnumbers.Items.Add(additem);
                }
            }
        }

        private void rd_lotno_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_all.Checked)
            {
                lv_lotnumbers.Items.Clear();
                foreach (DataRow dta in lotremarks.Rows)
                {
                    string[] row = { dta[0].ToString(),dta[1].ToString(),dta[2].ToString(),dta[3].ToString(),
                                       dta[4].ToString(),dta[5].ToString(),dta[6].ToString(),
                                       dta[7].ToString()
                                   };
                    var additem = new ListViewItem(row);
                    lv_lotnumbers.Items.Add(additem);
                }
            }
        }

        private void LotNumbersClearItems()
        {
            lotno_errors.Clear();
            lotno_updated.Clear();
            lotno_verified.Clear();
            lotremarks.Clear();
        }

        private void InitializeLotNumbersColumns()
        {
            
            lotno_errors.Columns.Add("UNIT");
            lotno_errors.Columns.Add("SERVICE");
            lotno_errors.Columns.Add("LINE");
            lotno_errors.Columns.Add("TRAIN");
            lotno_errors.Columns.Add("JOINT");
            lotno_errors.Columns.Add("NEWLOT");
            lotno_errors.Columns.Add("OLDLOT");
            lotno_errors.Columns.Add("REMARKS");
            lotno_errors.AcceptChanges();
                        
            lotno_updated.Columns.Add("UNIT");
            lotno_updated.Columns.Add("SERVICE");
            lotno_updated.Columns.Add("LINE");
            lotno_updated.Columns.Add("TRAIN");
            lotno_updated.Columns.Add("JOINT");
            lotno_updated.Columns.Add("NEWLOT");
            lotno_updated.Columns.Add("OLDLOT");
            lotno_updated.Columns.Add("REMARKS");
            lotno_updated.AcceptChanges();
            
            lotno_verified.Columns.Add("UNIT");
            lotno_verified.Columns.Add("SERVICE");
            lotno_verified.Columns.Add("LINE");
            lotno_verified.Columns.Add("TRAIN");
            lotno_verified.Columns.Add("JOINT");
            lotno_verified.Columns.Add("NEWLOT");
            lotno_verified.Columns.Add("OLDLOT");
            lotno_verified.Columns.Add("REMARKS");
            lotno_verified.AcceptChanges();
            
            lotremarks.Columns.Add("UNIT");
            lotremarks.Columns.Add("SERVICE");
            lotremarks.Columns.Add("LINE");
            lotremarks.Columns.Add("TRAIN");
            lotremarks.Columns.Add("JOINT");
            lotremarks.Columns.Add("NEWLOT");
            lotremarks.Columns.Add("OLDLOT");
            lotremarks.Columns.Add("REMARKS");
            lotremarks.AcceptChanges();
        }

        private void btn_lotnum_upload_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlUpdate = "";
                int rowCount = 0;
                if (lotno_verified.Rows.Count > 0)
                {
                    foreach (DataRow dr in lotno_verified.Rows)
                    {
                        sqlUpdate = @"Update Joints set batchnum ='" + dr[5].ToString()
                                                          + "' where unit=" + dr[0].ToString()
                                                          + " and [Service]='" + dr[1].ToString()
                                                          + "' and line='" + dr[2].ToString()
                                                          + "' and train='" + dr[3].ToString()
                                                          + "'and JointNumber ='" + dr[4].ToString() + "'";
                        if (sqlUpdate != "")
                        {
                            using (dbCon = new useSQL.useSQL(conStr))
                            {
                                dbCon.PerformQuery(sqlUpdate);
                            } 
                        } 
                    } 
                    MessageBox.Show("LOT LOADER SUCCESSFULLY UPLOADED!" + " TOTAL UPDATED JOINTS: " + lbl_lotno_verified.Text, "LOT LOADER UPLOAD");

                }
                else
                {
                    MessageBox.Show("NO VERIFIED LOTNUMBERS." + " TOTAL UPDATED JOINTS: 0", "LOT LOADER UPLOAD");
                }
            }
            catch (Exception)
            {
                
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }

        }

        private void rd_lotno_remove_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_lotno_remove.Checked)
            {
                if (MetroMessageBox.Show(mainMenu, "DO YOU WANT TO REMOVE BY SUBCONTRACTORS?", "REMOVE LOT NUMBERS BY SUBCON OR LOADER", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 150) == DialogResult.Yes)
                {
                    frm_RemoveLotNo newremove = new frm_RemoveLotNo();
                    newremove.ShowDialog();
                }
            }
        }

        private void btn_lotnoExport_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                ExporttoExcel(lv_lotnumbers);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

    }
}
