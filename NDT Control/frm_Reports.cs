using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using ClosedXML.Excel;
using MetroFramework.Forms;
using System.Threading;
using MetroFramework;

namespace NDT_Control
{
    public partial class frm_Reports : MetroForm
    {
        useSQL.useSQL dbCon;
        public static string conStr;
        frmLoading newload = new frmLoading();
        frm_menu mainMenu;

        public frm_Reports(frm_menu mm)
        {
            InitializeComponent();
            conStr = File.ReadAllText(@"..\ndtCon.cfg");
            mainMenu = mm;
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {

        }

        private void btn_Export_Click(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                if(cmbNdt.SelectedItem.ToString().Equals("DWR-WELDER"))
                {
                    checkingWelders();
                }
                else
                {
                    Utilities.CheckFiles(cmbNdt.SelectedItem.ToString(), mainMenu);            
                }
            }
            catch (Exception)
            {
                 MetroMessageBox.Show(mainMenu, "PLEASE RESTART NDT CONTROL APPLICATION", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
        }

        public void checkingWelders()
        {
            this.ofd_fileOpen = new OpenFileDialog();

            if (ofd_fileOpen.ShowDialog(this) == DialogResult.OK)
            {
                txt_filePath.Text = ofd_fileOpen.FileName;
            }

            DataTable newDWRData = new DataTable();

            DWRCheck(extractData(txt_filePath.Text, System.IO.Path.GetFileName(txt_filePath.Text)));
            txt_filePath.Visible = true;
            label2.Visible = true;
        }

        public DataTable extractData(string path, string fileName)
        {
            string fullpath = @"" + path.Replace(@"\", "/") + "/" + fileName;

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range firstCell = xlWorkSheet.get_Range("A13", "X24");
            Excel.Range lastCell = xlWorkSheet.Range[xlWorkSheet.PageSetup.PrintArea];
            Excel.Range worksheetCells = xlWorkSheet.get_Range(firstCell, lastCell);

            DataTable dtdwrData = new DataTable();
            dtdwrData.Columns.Add("ind");
            dtdwrData.Columns.Add("unit");
            dtdwrData.Columns.Add("service");
            dtdwrData.Columns.Add("line");
            dtdwrData.Columns.Add("train");
            dtdwrData.Columns.Add("joint");
            dtdwrData.Columns.Add("welder1");
            dtdwrData.Columns.Add("welder2");
            string[] strResult = null;

            for (int i = 13; i < worksheetCells.Rows.Count + 1; i++)
            {
                Excel.Range dwrData = xlWorkSheet.get_Range("A" + i, "X" + i);

                if (dwrData.Value2[1, 2] != null)
                {
                    if (IsDigitsOnly(dwrData.Value2[1, 2].ToString()) )
                    {
                        strResult = new string[] {  Convert.ToString(dwrData.Value2[1, 1]),
                                                    Convert.ToString(dwrData.Value2[1, 2]), 
                                                    Convert.ToString(dwrData.Value2[1, 3])
                                                   ,Convert.ToString(dwrData.Value2[1, 4]) + Convert.ToString(dwrData.Value2[1, 5])
                                                   ,Convert.ToString(dwrData.Value2[1, 6])
                                                   ,Convert.ToString(dwrData.Value2[1, 12])
                                                   ,Convert.ToString(dwrData.Value2[1, 23]) 
                                                   ,Convert.ToString(dwrData.Value2[1, 24])
                                                  };
                        dtdwrData.NewRow();
                        dtdwrData.Rows.Add(strResult);
                    }
                }
            }

            return dtdwrData;
        }

        public void DWRCheck(DataTable dwrData)
        {
            DataTable dtresult = new DataTable();
            dtresult.Columns.Add("S/N");
            dtresult.Columns.Add("unit");
            dtresult.Columns.Add("service");
            dtresult.Columns.Add("line");
            dtresult.Columns.Add("train");
            dtresult.Columns.Add("joint");
            dtresult.Columns.Add("welder1 - SUBCON");
            dtresult.Columns.Add("welder2 - SUBCON");
            dtresult.Columns.Add("welder1 - PCA");
            dtresult.Columns.Add("welder2 - PCA");
            dtresult.Columns.Add("WELDER COMMENT");


            DataTable dtjoints = new DataTable();
            string[] rowData = new string[] { };

            for (int i = 0; i < dwrData.Rows.Count; i++)
            {
                using (dbCon = new useSQL.useSQL(conStr))
                {
                    dtjoints = dbCon.PerformQuery("select Unit, [Service], Line, Train, Spool, JointNumber,"
                                                            + "    welder1, welder2 "
                                                        + " from joints WITH (NOLOCK) where Unit ='" + dwrData.Rows[i][1]
                                                        + "' and [Service] ='" + dwrData.Rows[i][2]
                                                        + "' and Line ='" + dwrData.Rows[i][3]
                                                        + "' and Train='" + dwrData.Rows[i][4]
                                                        + "' and Jointnumber='" + dwrData.Rows[i][5] + "'");
                }


                if(dtjoints.Rows.Count > 0)
                {
                    rowData = new string[] { dwrData.Rows[i][0].ToString(), dwrData.Rows[i][1].ToString(), dwrData.Rows[i][2].ToString()
                                        ,dwrData.Rows[i][3].ToString(), dwrData.Rows[i][4].ToString()
                                        ,dwrData.Rows[i][5].ToString(), dwrData.Rows[i][6].ToString()
                                        ,dwrData.Rows[i][7].ToString()
                                        ,dtjoints.Rows[0]["welder1"].ToString()
                                        ,dtjoints.Rows[0]["welder2"].ToString()
                                        ,( dwrData.Rows[i][6].ToString() == dtjoints.Rows[0]["welder1"].ToString().Trim() ) && 
                                          (dwrData.Rows[i][7].ToString() == dtjoints.Rows[0]["welder2"].ToString().Trim() ) ? "MATCH" : "NOT MATCH"
                                       };
                }
                else
                {
                    rowData = new string[] { dwrData.Rows[i][0].ToString(), dwrData.Rows[i][1].ToString(), dwrData.Rows[i][2].ToString()
                                        ,dwrData.Rows[i][3].ToString(), dwrData.Rows[i][4].ToString()
                                        ,dwrData.Rows[i][5].ToString(), dwrData.Rows[i][6].ToString()
                                        ,dwrData.Rows[i][7].ToString()
                                        ,""
                                        ,""
                                        ,"ISO NOT EXISTING IN PCA"
                                       };
                }

                dtresult.NewRow();
                dtresult.Rows.Add(rowData);

            }

            string filePath = System.IO.Path.GetDirectoryName(txt_filePath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(txt_filePath.Text) + " - DWR WELDER COMMENTS.xlsx";

            Utilities.ExportExcel(dtresult, filePath);
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

        public void LoadingForm()
        {
            if (newload != null)
            {
                newload = new frmLoading(this);
                Application.Run(newload);
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

        public void changeLabel(string message)
        {
            mainMenu.ChangeUpperLabel(message);
        }
    }
}
