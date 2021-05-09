using ClosedXML.Excel;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Linq;

namespace NDT_Control
{
    public class Utilities
    {
        frmLoading newload = new frmLoading();
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        #region Excel Files Transactions
        
        public static void ExportExcel(DataGridView dgv)
        {
            Missing mv = Missing.Value;
            Microsoft.Office.Interop.Excel.Application NewExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook wkb = NewExcelApp.Workbooks.Add(mv);
            Excel.Worksheet wks = wkb.Sheets[1];

            for (int y = 0; y <= dgv.Columns.Count - 1; y++)
            {
                ((Excel.Range)wks.Cells[1, y + 1]).Value = dgv.Columns[y].ToString();
            }

            for (int x = 1; x <= dgv.Rows.Count; x++)
            {
                for (int y = 0; y <= dgv.Columns.Count - 1; y++)
                {
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).NumberFormat = "@";
                }
            }

            wks = null;
            wkb = null;
            NewExcelApp.Quit();
            MessageBox.Show("Done");
        }

        public static bool ExportExcel(DataTable dt, string filepath)
        {
            try
            {
                if (dt.Rows.Count > 100000)
                {
                    Missing mv = Missing.Value;
                    Microsoft.Office.Interop.Excel.Application NewExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Excel.Workbook wkb = NewExcelApp.Workbooks.Add(mv);
                    Excel.Worksheet wks = wkb.Sheets[1];
                    XLWorkbook wb = new XLWorkbook();

                    DataTable[] splittedtables = dt.AsEnumerable()
                                            .Select((row, index) => new { row, index })
                                            .GroupBy(x => x.index / 100000)  // integer division, the fractional part is truncated
                                            .Select(g => g.Select(x => x.row).CopyToDataTable())
                                            .ToArray();

                    for (int i = 0; i <= splittedtables.Count() - 1; i++)
                    {
                        wb.Worksheets.Add(splittedtables[i], "Page " + i);
                    }

                    filepath = filepath + ".xlsx";
                    wb.SaveAs(filepath);
                }
                else
                {
                    XLWorkbook wb = new XLWorkbook();
                    wb.Worksheets.Add(dt, "Sheet1");
                    wb.SaveAs(filepath);

                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }

        //USED EXCLUSIVELY FOR FILE CHECKING...
        public static void ExportExcel(DataTable dt1, DataTable dt2, string filename)
        {
            XLWorkbook wb = new XLWorkbook();
            
            wb.Worksheets.Add(dt1, "NDT REPORTS - MAIN FOLDER");
            wb.Worksheets.Add(dt2, "NDT REPORTS - PCA");

            filename = filename + ".xlsx";
            wb.SaveAs(filename);            
        }
        //USED EXCLUSIVELY FOR FILE CHECKING...

        public static bool ExportExcel(List<DataTable> dt1, string filename)
        {
            try 
	        {
                    XLWorkbook wb = new XLWorkbook();

                    foreach (DataTable n in dt1)
                    {
                        wb.Worksheets.Add(n,n.TableName);
                    }
                    
                    wb.SaveAs(filename);
                    return true;
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.ToString());
		        return false;
	        }
        }

        public static DataTable ImportExcelData(string excelfilepath)
       {
           Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
           Excel.Workbook xlWorkBook = null;
           Excel.Worksheet xlWorkSheet = null;
           
            try
           {
                var dt = new DataTable();

                string fullpath = @"" + excelfilepath.Replace(@"\", "/") + "/" + System.IO.Path.GetFileName(excelfilepath);
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(excelfilepath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Columns.ClearFormats();
                xlWorkSheet.Rows.ClearFormats();

                Excel.Range worksheetCells = xlWorkSheet.UsedRange;

                var data = worksheetCells.Value2;

                //ADD COLUMNS
                for (int i = 1; i < worksheetCells.Columns.Count + 1; i++)
                {
                    DataColumn newCol = new DataColumn();
                    string cellValue = String.Empty;
                    newCol.DataType = System.Type.GetType("System.String");

                    try
                    {
                        cellValue = (string)(data[1, i]);
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                    {
                        var ConvertVal = (double)(data[1, i]);
                        cellValue = ConvertVal.ToString();
                    }
                    newCol.ColumnName = cellValue;
                    dt.Columns.Add(newCol);
                }

                //ADD ROWS
                for (int rwcnt = 2; rwcnt <= worksheetCells.Rows.Count; rwcnt++)
                {
                    List<string> exceldata = new List<string>();
                    for (int i = 1, y = 0; i < worksheetCells.Columns.Count + 1; i++, y++)
                    {
                        string cellValue = String.Empty;
                        try
                        {
                            cellValue = (string)(data[rwcnt, i]);
                        }
                        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                        {
                            var ConvertVal = (double)(data[rwcnt, i]);
                            cellValue = ConvertVal.ToString();
                        }
                        exceldata.Add(cellValue);
                    }

                    var newRow = exceldata.ToArray();
                    dt.Rows.Add(newRow);
                }

                return dt;
           }
           finally
           {
               xlWorkBook.Close(0);
               xlApp.Quit();
               System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
               System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
               System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
           }
        }

        #endregion 

        #region Database Transactions

        public static DataTable GetNDTJointCollData(NDT_Control.Data_Classes.NDTCollection rawData)
        {
            DataTable retData = new DataTable();

            foreach (NDT_Control.Data_Classes.NDT dta in rawData)
            {
                using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_uploadData.conStr))
                {
                    retData = dbCon.PerformQuery("select *"
                                                    + " from joints WITH (NOLOCK) where Unit ='" + dta._unit
                                                    + "' and [Service] ='" + dta._service
                                                    + "' and Line ='" + dta._line
                                                    + "' and Train='" + dta._train
                                                    + "' and Jointnumber='" + dta._joint + "'");
                }
            }
            return retData;
        }

        public static DataTable GetNDTJointData(NDT_Control.Data_Classes.NDT rawData)
        {
            DataTable retData = new DataTable();
            
            using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_uploadData.conStr))
            {
                retData = dbCon.PerformQuery("select *"
                                                + " from joints WITH (NOLOCK) where Unit ='" + rawData._unit
                                                + "' and [Service] ='" + rawData._service
                                                + "' and Line ='" + rawData._line
                                                + "' and Train='" + rawData._train
                                                + "' and Jointnumber='" + rawData._joint + "'");
            }
            return retData; 
        }

        public static DataTable GetNDTOnlyData(DataTable dtData)
        {
            DataTable retData = new DataTable();

            for (int i = 1; i < dtData.Rows.Count; i++)
            {
                DataTable result = new DataTable();
                using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_menu.conStr))
                {
                    result = dbCon.PerformQuery("SELECT UNIT,SERVICE, LINE,TRAIN, JOINTNUMBER, RTNUMBER1, RTDATE1, RTNUMBER2, RTDATE2, RTNUMBER3, RTDATE3,"
                                                    + "RESHOOT, RESHOOTDATE, RESHOOT2, RESHOOTDATE2,RTACCEPTED,"
                                                    + "PWHT1, PWHTDATE1, PWHT2, PWHTDATE2, PWHT3, PWHTDATE3, PWHTACCEPTED,"
                                                    + "HT1, HTDATE1, HT2, HTDATE2, HT3, HTDATE3, HTAACCEPTED,"
                                                    + "HTB, HTBDATE, HTB2, HTB2DATE, HTB3, HTB3DATE, HTBACCEPTED,"
                                                    + "PMINUMBER, PMIDATE, PMI,"
                                                    + "PTNUMBER, PTDATE, PT,"
                                                    + "FERRIT, FERRITDATE, FERRIT2, FERRIT2DATE, FERRIT3, FERRIT3DATE, FERRITACCEPTED"
                                                    + " from joints WITH (NOLOCK) where Unit ='" + dtData.Rows[i][1].ToString()
                                                    + "' and [Service] ='" + dtData.Rows[i][0].ToString()
                                                    + "' and Line ='" + dtData.Rows[i][2].ToString()
                                                    + "' and Train='" + dtData.Rows[i][3].ToString()
                                                    + "' and Jointnumber='" + dtData.Rows[i][4].ToString() + "'");
                }

                if (retData.Columns.Count == 0)
                {
                    retData = result.Clone();
                }
                retData.ImportRow(result.Rows[0]);
            }
            return retData; 
        }

        public static DataTable GetDBData(string sqlQuery)
        {
            DataTable returnData = new DataTable();
            
            using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_menu.conStr))
            {
                returnData = dbCon.PerformQuery(sqlQuery);
            }
            return returnData;
        }

        public static void PerformSQLQuery(string sqlQuery)
        {
            using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_menu.conStr))
            {
                dbCon.PerformQuery(sqlQuery);
            }
        }

        public static void UploadData(DataGridView dgData)
        {
            for (int i = 1; i < dgData.Rows.Count; i++)
            {
                using (useSQL.useSQL dbCon = new useSQL.useSQL(frm_menu.conStr))
                {

                } 
            }
        }

        #endregion

        #region Check PDF Files

        public static DataTable CheckFiles(DataTable worksheetCells)
        {
            var reports = new List<string[]>();

            string ndtfilelocation;

            DataSet ds = new DataSet();

            DataTable dt = new DataTable("ReportTable");
            dt.Columns.Add(new DataColumn("reportNo", typeof(string)));
            dt.Columns.Add(new DataColumn("comment", typeof(string)));

            for (int i = 1; i < worksheetCells.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                string ndtType = "";

                if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("PWHT"))
                {
                    ndtType = "PWHT";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("RT"))
                {
                    ndtType = "RT";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("HTA"))
                {
                    ndtType = "HTA";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("HTB"))
                {
                    ndtType = "HTB";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("PT"))
                {
                    ndtType = "PT";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("FT"))
                {
                    ndtType = "FERRIT";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("PMI"))
                {
                    ndtType = "PMI";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("TML"))
                {
                    ndtType = "TML";
                }
                else if (worksheetCells.Rows[i][1].ToString().ToUpper().Equals("BORESCOPE"))
                {
                    ndtType = "BORESCOPE";
                }


                ndtfilelocation = "Z:/04 - Construction/04-Site Progress Report/ISOMETRICS/ABOVEGROUND/NDT/" + ndtType + "/" + worksheetCells.Rows[i][0] + ".pdf";
                string ndtmainLocation = @"" + ndtfilelocation.Replace(@"\", "/");


                if (File.Exists(ndtmainLocation))
                {
                    dr["reportNo"] = worksheetCells.Rows[i][0];
                    dr["comment"] = "REPORT EXISTING";
                }
                else
                {
                    dr["reportNo"] = worksheetCells.Rows[i][0];
                    dr["comment"] = "REPORT NOT EXIST";
                }

                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            return dt;
        }

        public static DataTable CheckFilesFromLoader(DataTable worksheetCells)
        {
            useSQL.useSQL dbCon;
            string conStr = File.ReadAllText(@"..\ndtCon.cfg");
            DataTable dtresult2 = new DataTable();

            dtresult2.Columns.Add("UNIT");
            dtresult2.Columns.Add("SERVICE");
            dtresult2.Columns.Add("LINE");
            dtresult2.Columns.Add("TRAIN");
            dtresult2.Columns.Add("JOINTNUMBER");
            dtresult2.Columns.Add("ReportNumber");
            dtresult2.Columns.Add("Result");

            foreach(DataRow dr in worksheetCells.Rows)
            {

            DataTable dtDBReport = new DataTable();
            using (dbCon = new useSQL.useSQL(conStr))
            {
                if (dr[1].Equals("RT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(rtnumber1) as [reportnum],unit,service,line, train, JointNumber from Joints WITH(NOLOCK) WHERE RTNUMBER1 = '" + dr[0].ToString() + "' or "
                    + " RTNumber2 = '" + dr[0].ToString() + "' OR RTNumber3 = '" + dr[0].ToString() + "' or reshoot = '" + dr[0].ToString() + "' or reshoot2 = '" + dr[0].ToString() + "' ");
                }
                else if (dr[1].Equals("PWHT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PWHT1) as [reportnum],unit,service,line, train, JointNumber from Joints WITH(NOLOCK) WHERE PWHT1 = '" + dr[0].ToString() + "' or PWHT2 ='" + dr[0].ToString() + "' OR PWHT3 = '" + dr[0].ToString() + "' ");
                }
                else if (dr[1].Equals("HTA"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(HT1),unit,service,line, train, JointNumber as [reportnum] from Joints WITH(NOLOCK) WHERE HT1 = '" + dr[0].ToString() + "' or HT2 = '" + dr[0].ToString() + "' OR HT3 = '" + dr[0].ToString() + "'");
                }
                else if (dr[1].Equals("HTB"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(HTB) as [reportnum],unit,service,line, train, JointNumber from Joints WITH(NOLOCK) WHERE HTB ='" + dr[0].ToString() + "' OR htb2 = '" + dr[0].ToString() + "' OR htb3 = '" + dr[0].ToString() + "'");
                }
                else if (dr[1].Equals("PMI"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PMINUMBER) as [reportnum],unit,service,line, train, JointNumber as [reportnum] from Joints WITH(NOLOCK) WHERE PMINUMBER ='" + dr[0].ToString() + "'");
                }
                else if (dr[1].Equals("PT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PTNUMBER) as [reportnum],unit,service,line, train, JointNumber as [reportnum] from Joints WITH(NOLOCK) WHERE PTNUMBER ='"+ dr[0].ToString() +"'");

                }
                else if (dr[1].Equals("FT") || dr[1].Equals("FERRIT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(FERRIT) as [reportnum],unit,service,line, train, JointNumber from Joints WITH(NOLOCK) WHERE FERRIT = '" + dr[0].ToString() + "' OR ferrit2 = '" + dr[0].ToString() + "' or ferrit3 = '" + dr[0].ToString() + "'");
                }
            }

            string[] strResult2 = null;

            if (dtDBReport.Rows.Count > 0)
            {
                strResult2 = new string[] { dtDBReport.Rows[0][1].ToString(), dtDBReport.Rows[0][2].ToString(), dtDBReport.Rows[0][3].ToString(), dtDBReport.Rows[0][4].ToString(), dtDBReport.Rows[0][5].ToString(), dtDBReport.Rows[0][0].ToString(), "REPORT UPDATED" };
            }
            else
            {
                strResult2 = new string[] { dtDBReport.Rows[0][1].ToString(), dtDBReport.Rows[0][2].ToString(), dtDBReport.Rows[0][3].ToString(), dtDBReport.Rows[0][4].ToString(), dtDBReport.Rows[0][5].ToString(), dtDBReport.Rows[0][0].ToString(), "REPORT NOT FOUND IN DATABASE" };
            }
            dtresult2.NewRow();
            dtresult2.Rows.Add(strResult2);

            }

            return dtresult2;

       }

        public static void CheckFiles(string ndtType, frm_menu updateLoading)
        {
            HashSet<string> dtpdf = new HashSet<string>();
            useSQL.useSQL dbCon;
            string conStr = File.ReadAllText(@"..\ndtCon.cfg");
            DirectoryInfo d = null;

            if (ndtType.Equals("RT"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\RT");
            }
            else if (ndtType.Equals("PWHT"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\PWHT");
            }
            else if (ndtType.Equals("HTA"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\HTA");
            }
            else if (ndtType.Equals("HTB"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\HTB");
            }
            else if (ndtType.Equals("PMI"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\PMI");
            }
            else if (ndtType.Equals("PT"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\PT");
            }
            else if (ndtType.Equals("FT") || ndtType.Equals("FERRIT"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\NDT\Ferrit");
            }
            else if (ndtType.Equals("DWR"))
            {
                d = new DirectoryInfo(@"Z:\04 - Construction\04-Site Progress Report\ISOMETRICS\ABOVEGROUND\WeldReport");
            }

            FileInfo[] Files = d.GetFiles("*.pdf");

            int filectr= 0;
            foreach (FileInfo file in Files)
            {
                filectr++;
                dtpdf.Add(Path.GetFileNameWithoutExtension(file.Name));
                updateLoading.ChangeUpperLabel("TOTAL PDF FILES:" + filectr);
            }

            DataTable dtDBReport = new DataTable();
            using (dbCon = new useSQL.useSQL(conStr))
            {
                if (ndtType.Equals("RT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(rtnumber1) as [reportnum],unit,service,line, train, JointNumber, rtdate1,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE] "
                                +" from Joints WITH(NOLOCK) WHERE RTNUMBER1 <> '' union select distinct RTRIM(RTnumber2) "
                                + ",unit,service,line, train, JointNumber, rtdate2,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE RTNUMBER2 <> '' "
                                + " union select distinct RTRIM(RTnumber3),unit,service,line, train, JointNumber,rtdate3,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WHERE RTNUMBER3 <> '' union select distinct RTRIM(reshoot) "
                                + ",unit,service,line, train, JointNumber,reshootdate,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE RESHOOT <> '' union "
                                + "select distinct RTRIM(reshoot2),unit,service,line, train, JointNumber,reshootdate2,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  "
                                + "from Joints WITH(NOLOCK) WHERE RESHOOT2 <> ''");
                }
                else if (ndtType.Equals("PWHT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PWHT1) as [reportnum],unit,service,line, train, JointNumber,pwhtdate1,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE PWHT1 <> '' union select distinct RTRIM(PWHT2)"
                                + ",unit,service,line, train, JointNumber,pwhtdate2,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE PWHT2 <> '' union select distinct RTRIM(PWHT3)"
                                + ",unit,service,line, train, JointNumber,pwhtdate3,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE PWHT3 <>''");
                }
                else if (ndtType.Equals("HTA"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(HT1)  as [reportnum],unit,service,line, train, JointNumber,htdate1,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE] from Joints WITH(NOLOCK) WHERE HT1 <> '' union select distinct RTRIM(HT2)"
                                + ",unit,service,line, train, JointNumber,htdate2,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE HT2 <> '' union select distinct RTRIM(HT3),unit,service,line, train, JointNumber,htdate3,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE] "
                                + " from Joints WITH(NOLOCK) WHERE HT3 <>''");
                }
                else if (ndtType.Equals("HTB"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(HTB) as [reportnum],unit,service,line, train, JointNumber,htbdate,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE HTB <> '' union select distinct RTRIM(HTB2)"
                                    + ",unit,service,line, train, JointNumber,htb2date,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE HTB2 <> '' union select distinct RTRIM(HTB3),unit,service,line, train, JointNumber,htb3date,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE] "
                                    + " from Joints WITH(NOLOCK) WHERE HTB3 <>''");
                }
                else if (ndtType.Equals("PMI"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PMINUMBER) as [reportnum],unit,service,line, train, JointNumber, pmidate,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]   from Joints WITH(NOLOCK) WHERE PMINUMBER <> ''");
                }
                else if (ndtType.Equals("PT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(PTNUMBER) as [reportnum],unit,service,line, train, JointNumber,ptdate,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE PTNUMBER <> ''");
                }
                else if (ndtType.Equals("FT") || ndtType.Equals("FERRIT"))
                {
                    dtDBReport = dbCon.PerformQuery("select distinct RTRIM(FERRIT) as [reportnum],unit,service,line, train, JointNumber,ferritdate,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE FERRIT <> '' union select distinct RTRIM(FERRIT2)"
                                                    + ",unit,service,line, train, JointNumber,ferrit2date,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]  from Joints WITH(NOLOCK) WHERE FERRIT2 <> '' union select distinct RTRIM(FERRIT3),unit,service,line, train, JointNumber,ferrit3date,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE]"
                                                    + " from Joints WITH(NOLOCK) WHERE FERRIT3 <> ''");
                }
                else if (ndtType.Equals("DWR"))
                {
                    dtDBReport = dbCon.PerformQuery("SELECT DISTINCT WeldingReportNumber AS [reportnum],UNIT,SERVICE,LINE,TRAIN, JOINTNUMBER, dateofweld,case when active = 1 then 'ACTIVE' else 'CANCELED' end as [ACTIVE] FROM JOINTS"
                                                     +"   WHERE"
                                                     +"   WeldingReportNumber <> ''"
                                                     +"   AND "
                                                     +"   Active =1"
                                                     +"   AND JointType NOT IN ('FJ','TH')");
                }
            }

            var hashSet = new HashSet<string[]>(DTtoList(dtDBReport));
            var pcaReports = new HashSet<string>(dtDBReport.AsEnumerable().Select(x => x.Field<string>("reportnum")));

            DataTable dtresult1 = new DataTable();
            dtresult1.Columns.Add("ReportNumber");
            dtresult1.Columns.Add("Result");
            string[] strResult1 = null;
            var hashReports = hashSet.First();
            int pdfreportCount = 0;

            if (!ndtType.Equals("DWR"))
            {
                foreach (string c in dtpdf)
                {
                    updateLoading.ChangeLowerLabel(pdfreportCount++, dtpdf.Count(), "PDF FILE CHECKING:  ");                    
                    if(pcaReports.Contains(c))
                    {
                        strResult1 = new string[] { c, "REPORT UPDATED IN PCA" };
                    }
                    else
                    {
                        strResult1 = new string[] { c, "NOT UPDATED" };
                    }

                    dtresult1.NewRow();
                    dtresult1.Rows.Add(strResult1);
                }
            }

            DataTable dtresult2 = new DataTable();
            
            dtresult2.Columns.Add("UNIT");
            dtresult2.Columns.Add("SERVICE");
            dtresult2.Columns.Add("LINE");
            dtresult2.Columns.Add("TRAIN");
            dtresult2.Columns.Add("JOINTNUMBER");
            dtresult2.Columns.Add("ReportNumber");
            dtresult2.Columns.Add("ReportDate");
            dtresult2.Columns.Add("Joint Active");
            dtresult2.Columns.Add("Result");

            string[] strResult2 = null;
            int dbReportCount = 0;
            int totalrepcount = hashSet.Count();

            foreach (string[] c in hashSet)
            {
                dbReportCount++;
                //updateLoading.ChangeLowerLabel(dbReportCount, totalrepcount, "PCA JOINT REPORTS CHECKING:  ");
                //updateLoading.ChangeUpperLabel("PAKPAKPAK LABAN LNG BES:" + dbReportCount);
                    if (Regex.IsMatch(c[0], @"\s"))
                    {
                        if (dtpdf.Contains(c[0].Trim()))
                        {
                            if (!ndtType.Equals("DWR"))
                            {
                                strResult2 = new string[] { c[1], c[2], c[3], c[4], c[5], c[0], c[6], c[7], "REPORT EXISTING IN MAIN FOLDER BUT UPDATED WITH SPACES" };
                            }
                        }
                        else
                        {
                            strResult2 = new string[] { c[1], c[2], c[3], c[4], c[5], c[0], c[6], c[7], "REPORT MISSING IN MAIN FOLDER" };
                        }
                    }
                    else
                    {
                            if (dtpdf.Contains(c[0]))
                            {
                                if (!ndtType.Equals("DWR"))
                                {
                                    strResult2 = new string[] { c[1], c[2], c[3], c[4], c[5], c[0], c[6], c[7], "REPORT EXISTING IN MAIN FOLDER" };
                                }
                            }
                            else
                            {
                                strResult2 = new string[] { c[1], c[2], c[3], c[4], c[5], c[0], c[6], c[7], "REPORT MISSING IN MAIN FOLDER" };
                            }    
                    }

                if (strResult2 != null)
                {
                    dtresult2.NewRow();
                    dtresult2.Rows.Add(strResult2);
                }
            }

            string fn = null;

            if (ndtType.Equals("RT"))
            {
                fn = " RT CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("PWHT"))
            {
                fn = " PWHT CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("HTA"))
            {
                fn = " HTA CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("HTB"))
            {
                fn = " HTB CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("PMI"))
            {
                fn = " PMI CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("PT"))
            {
                fn = " PT CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("FT") || ndtType.Equals("FERRIT"))
            {
                fn = " FT CHECK FILE RESULT.xlsx";
            }
            else if (ndtType.Equals("DWR"))
            {
                fn = " DWR CHECK FILE RESULT.csv";
            }

            if (!ndtType.Equals("DWR"))
            {
                try
                {
                   ExportExcel(dtresult1, dtresult2, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + fn);
                    MetroMessageBox.Show(updateLoading, "", "RESULT SUCCESSFULLY IMPORTED! FILE LOCATED IN YOUR DESKTOP.", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(updateLoading, "IMPORT FAILED", "There is something wrong. " + ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
                }
            }
            else
            {
                ExportExcel(dtresult2, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + fn);
            }
        }

        #endregion

        #region DataTable to Other Objects
        public static void DTtoLV(DataTable dtData, ListView lvData)
        {
            for (int i = 0; i < dtData.Columns.Count; i++)
            {
                lvData.Columns.Add(dtData.Columns[i].ToString());
            }
       
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                List<string> lsData = new List<string>();
                for (int y = 0; y < dtData.Columns.Count; y++)
                {                    
                    lsData.Add(dtData.Rows[i][y].ToString());
                }

                var additem = new ListViewItem(lsData.ToArray());
                lvData.Items.Add(additem);   
            }

            lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static void DTtoDG(DataTable dtData, DataGridView dgData)
        {
            if (dgData.DataSource != null)
            {
                dgData.DataSource = null;
            }

            dgData.DataSource = dtData;
        }

        public static void DTtoCmb(DataTable dtData, ComboBox cmb)
        {
            cmb.DataSource = dtData;
            cmb.DisplayMember = dtData.Columns[0].ColumnName;
            cmb.ValueMember = dtData.Columns[0].ColumnName;
        }

        public static DataTable DGtoDT(DataGridView dgData)
        {
            DataTable dtData = new DataTable();

            foreach (DataGridViewColumn col in dgData.Columns)
            {
                dtData.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgData.Rows)
            {
                DataRow dRow = dtData.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dtData.Rows.Add(dRow);
            }
            return dtData;
        }

        public static List<string[]> DTtoList(DataTable dtData)
        {
            List<string[]> newList = new List<string[]>();
            foreach (DataRow dr in dtData.Rows)
            {
                newList.Add(new string[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString() });
            }
            return newList;
        }

        #endregion

        #region NDT Transactions
        public static void NDTClassesTESTING()
        {
            var rt1report = new ReportDetails("RT1 PAAAAK LAVERN", "2019/07/20");
            var rt2report = new ReportDetails("RT2", "2019/07/20");
            var rt3report = new ReportDetails("RT3", "2019/07/20");
            
            RTReport jointRT = new RTReport(rt1report, rt2report, rt3report);            
        }
        #endregion

        #region LogXml

        public static void LogUpdateNDT(List<string> ndtData)
        {

            if (File.Exists(@"..\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + " NDT Log.xml"))
            {
                XmlDocument logs = new XmlDocument();
                logs.Load(@"..\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + " NDT Log.xml");

                XmlNode newNode = logs.CreateNode(XmlNodeType.Element, "NDTLogData",null);

                XmlNode unit = logs.CreateElement("UNIT");
                unit.InnerText = ndtData[0].ToString();

                XmlNode service = logs.CreateElement("SERVICE");
                service.InnerText = ndtData[1].ToString();

                XmlNode line = logs.CreateElement("LINE");
                line.InnerText = ndtData[2].ToString();

                XmlNode train = logs.CreateElement("TRAIN");
                train.InnerText = ndtData[3].ToString();

                XmlNode joint = logs.CreateElement("JOINT");
                joint.InnerText = ndtData[4].ToString();

                XmlNode reportnum = logs.CreateElement("REPORTNUMBER");
                reportnum.InnerText = ndtData[5].ToString();

                XmlNode loaderfile = logs.CreateElement("LOADERFILE");
                loaderfile.InnerText = ndtData[6].ToString();

                XmlNode dateupload = logs.CreateElement("DATEUPLOAD");
                dateupload.InnerText = ndtData[7].ToString();

                XmlNode uploadedby = logs.CreateElement("UPDATEDBY");
                uploadedby.InnerText = ndtData[8].ToString();

                newNode.AppendChild(unit);
                newNode.AppendChild(service);
                newNode.AppendChild(line);
                newNode.AppendChild(train);
                newNode.AppendChild(joint);
                newNode.AppendChild(reportnum);
                newNode.AppendChild(loaderfile);
                newNode.AppendChild(dateupload);
                newNode.AppendChild(uploadedby);

                logs.DocumentElement.AppendChild(newNode);

                logs.Save(@"..\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + " NDT Log.xml");
            }
            else
            {
                //CREATE NEW XML
                XmlDocument logs = new XmlDocument();

                XmlNode ndtlogs = logs.CreateElement("DATA_LOGS");
                logs.AppendChild(ndtlogs);

                XmlNode ndtDataLog = logs.CreateElement("NDTLogData");
                ndtlogs.AppendChild(ndtDataLog);

                XmlNode unitNode = logs.CreateElement("UNIT");
                unitNode.AppendChild(logs.CreateTextNode(ndtData[0].ToString()));
                ndtDataLog.AppendChild(unitNode);

                XmlNode serviceNode = logs.CreateElement("SERVICE");
                serviceNode.AppendChild(logs.CreateTextNode(ndtData[1].ToString()));
                ndtDataLog.AppendChild(serviceNode);

                XmlNode lineNode = logs.CreateElement("LINE");
                lineNode.AppendChild(logs.CreateTextNode(ndtData[2].ToString()));
                ndtDataLog.AppendChild(lineNode);

                XmlNode trainNode = logs.CreateElement("TRAIN");
                trainNode.AppendChild(logs.CreateTextNode(ndtData[3].ToString()));
                ndtDataLog.AppendChild(trainNode);

                XmlNode jointNode = logs.CreateElement("JOINT");
                jointNode.AppendChild(logs.CreateTextNode(ndtData[4].ToString()));
                ndtDataLog.AppendChild(jointNode);

                XmlNode reportNumNode = logs.CreateElement("REPORTNUMBER");
                reportNumNode.AppendChild(logs.CreateTextNode(ndtData[5].ToString()));
                ndtDataLog.AppendChild(reportNumNode);

                XmlNode loaderFileNode = logs.CreateElement("LOADERFILE");
                loaderFileNode.AppendChild(logs.CreateTextNode(ndtData[6].ToString()));
                ndtDataLog.AppendChild(loaderFileNode);

                XmlNode dateUploadNode = logs.CreateElement("DATEUPLOAD");
                dateUploadNode.AppendChild(logs.CreateTextNode(ndtData[7].ToString()));
                ndtDataLog.AppendChild(dateUploadNode);

                XmlNode updatedByNode = logs.CreateElement("UPDATEDBY");
                updatedByNode.AppendChild(logs.CreateTextNode(ndtData[8].ToString()));
                ndtDataLog.AppendChild(updatedByNode);

                logs.Save(@"..\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + " NDT Log.xml");
            }
        }

        public static DataTable XmlToDT()
        {
            DataSet dsLogs = new DataSet();
            DataTable xmllogs = new DataTable();
            var d = new DirectoryInfo(@"..\Logs\");
            FileInfo[] Files = d.GetFiles("*.xml");

            foreach (FileInfo n in Files)
            {
                dsLogs.ReadXml(@"..\Logs\" + n.ToString());
            }

            xmllogs = dsLogs.Tables[0];

            return xmllogs;
        }
        #endregion
    }
}
