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
using System.Threading;
using MetroFramework;
using System.Diagnostics;

namespace NDT_Control
{
    public partial class frm_Queries : MetroForm
    {
        frmLoading newload = new frmLoading();
        frm_menu mainMenu;

        public frm_Queries(frm_menu mm)
        {
            InitializeComponent();
            mainMenu = mm;
            FillComboBx();
            dtp_from.Format = DateTimePickerFormat.Custom;
            dtp_to.Format = DateTimePickerFormat.Custom;

            dtp_from.CustomFormat = "yyyy/MM/dd";
            dtp_to.CustomFormat = "yyyy/MM/dd";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
        }

        private void FillComboBx()
        {
            DirectoryInfo d = new DirectoryInfo(@"..\Queries\"); ;
            FileInfo[] Files = d.GetFiles("*.sql");

            foreach (FileInfo file in Files)
            {
                comboBox1.Items.Add(file.Name.Replace(".sql",""));
            }

            string[] subdirs = Directory.GetDirectories(@"..\Queries\").Select(Path.GetFileName).ToArray();
            foreach (string file in subdirs)
            {
                comboBox1.Items.Add(file.ToString());
            }
            
            Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT RTRIM(UNIT) as [unit] FROM HTP WHERE ACTIVE = 1 UNION SELECT 'ALL' ORDER BY UNIT"), cmb_tp_unit);
        }

        private void NDTPerformanceExport()
        {
            DataTable pwht = new DataTable("PWHT");
            DataTable pmi = new DataTable("PMI");
            DataTable hta = new DataTable("HTA");
            DataTable pt = new DataTable("PT");
            DataTable ft = new DataTable("FT");

            string addUnits = GetCheckedUnits();

            //mainMenu.ChangeUpperLabel("EXTRACTING PWHT");
            string pwhtQuery = File.ReadAllText(@"..\Queries\NDT PERFORMANCE\NDT PERFORMANCE (PWHT).sql");
            pwhtQuery += addUnits;
            pwht = Utilities.GetDBData(pwhtQuery);
            pwht.TableName = "PWHT";

            mainMenu.ChangeUpperLabel("EXTRACTING PMI");
            string pmiQuery = File.ReadAllText(@"..\Queries\NDT PERFORMANCE\NDT PERFORMANCE (PMI).sql");
            pmiQuery += addUnits;
            pmi = Utilities.GetDBData(pmiQuery);
            pmi.TableName = "PMI";

            mainMenu.ChangeUpperLabel("EXTRACTING HTA");
            string htaQuery = File.ReadAllText(@"..\Queries\NDT PERFORMANCE\NDT PERFORMANCE (HTA).sql");
            htaQuery += addUnits; 
            hta = Utilities.GetDBData(htaQuery);
            hta.TableName = "HTA";

            mainMenu.ChangeUpperLabel("EXTRACTING PT");
            string ptQuery = File.ReadAllText(@"..\Queries\NDT PERFORMANCE\NDT PERFORMANCE (PT).sql");
            ptQuery += addUnits;
            pt = Utilities.GetDBData(ptQuery);
            pt.TableName = "PT";
            mainMenu.ChangeUpperLabel("EXTRACTING FT");
            string ftQuery = File.ReadAllText(@"..\Queries\NDT PERFORMANCE\NDT PERFORMANCE (FT).sql");
            ftQuery += addUnits;
            ft = Utilities.GetDBData(ftQuery);
            ft.TableName = "FT";

            mainMenu.ChangeUpperLabel("EXPORTING TO EXCEL...");

            List<DataTable> NDTPerformances = new List<DataTable>();
            NDTPerformances.Add(pwht);
            NDTPerformances.Add(pmi);
            NDTPerformances.Add(hta);
            NDTPerformances.Add(pt);
            NDTPerformances.Add(ft);

            if(Utilities.ExportExcel(NDTPerformances, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " NDT PERFORMANCE.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "NDT PERFORMANCE EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "NDT PERFORMANCE EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            if (lstbx_filters.Items.Count == 0)
            {
                if (MetroMessageBox.Show(mainMenu, "DO YOU WANT PROCEED WITHOUT FILTERS?", "FILTERS", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 150) == DialogResult.Yes)
                {
                    if (comboBox1.SelectedItem == null)
                    {
                        MetroMessageBox.Show(mainMenu, "", "PLEASE SELECT A QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex.Equals(0))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            AllNDTCumulative();
                        }
                        else if (comboBox1.SelectedIndex.Equals(1)) //DWR AFTER TESTED DATE 
                        {
                            backgroundWorker1.RunWorkerAsync();
                            DWRafterTP();
                        }
                        else if (comboBox1.SelectedIndex.Equals(2))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            DWRNDTPerDay();
                        }
                        else if (comboBox1.SelectedIndex.Equals(3))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            NDTBeforeWeld();
                        }
                        else if (comboBox1.SelectedIndex.Equals(4))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            JointNDTStatus();
                        }
                        else if (comboBox1.SelectedIndex.Equals(5))
                        {
                            backgroundWorker1.RunWorkerAsync();
                            NDTAfterTest();
                        }
                        else if (comboBox1.SelectedIndex.Equals(6)) //NDT PERFORMANCE 
                        {
                            backgroundWorker1.RunWorkerAsync();
                            NDTPerformanceExport();
                        }
                    }
                }
            }
            else
            {
                if (comboBox1.SelectedItem == null)
                {
                    MetroMessageBox.Show(mainMenu, "", "PLEASE SELECT A QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
                else
                {
                    if (comboBox1.SelectedIndex.Equals(0))
                    {
                        backgroundWorker1.RunWorkerAsync();
                        AllNDTCumulative();
                    }
                    else if (comboBox1.SelectedIndex.Equals(1)) //DWR AFTER TESTED DATE 
                    {
                        backgroundWorker1.RunWorkerAsync();
                        DWRafterTP();
                    }
                    else if (comboBox1.SelectedIndex.Equals(2))
                    {
                        backgroundWorker1.RunWorkerAsync();
                        DWRNDTPerDay();
                    }
                    else if (comboBox1.SelectedIndex.Equals(3))
                    {
                        backgroundWorker1.RunWorkerAsync();
                        NDTBeforeWeld();
                    }
                    else if (comboBox1.SelectedIndex.Equals(4))
                    {
                        backgroundWorker1.RunWorkerAsync();
                        JointNDTStatus();
                    }
                    else if (comboBox1.SelectedIndex.Equals(5))
                    {
                        backgroundWorker1.RunWorkerAsync();
                        NDTAfterTest();
                    }
                    else if (comboBox1.SelectedIndex.Equals(6)) //NDT PERFORMANCE 
                    {
                        backgroundWorker1.RunWorkerAsync();
                        NDTPerformanceExport();
                    }
                }
            }
        }

        private string getFilterString()
        {
            string filters = "";
            string units = "";

            //units = GetCheckedUnits(); //enable if performing normal NDT Performance

            //INSERT STRING MANIPULATION FOR QUERY HERE....
            List<string> listbxUnits = new List<string>();
            List<string[]> listbxTP = new List<string[]>();
            List<string> listbxDates = new List<string>();
            List<string> listbxNDT = new List<string>();

            foreach (string n in lstbx_filters.Items)
            {
                if (!n.Equals("ALL TEST PACK AND ALL UNITS"))
                { 
                    if (n.Contains("UNIT") && !(n.Contains("TEST PACK")))
                    {
                        if (!n.Equals(""))
                        { 
                            listbxUnits.Add(n);
                        }
                    }
                    else if (n.Contains("TEST PACK") || n.Contains("TESTPACK"))
                    {
                            if (n.Contains("UNIT"))
                            {
                                listbxTP.Add(new string[] { n, "TP1" });
                            }
                            else
                            {
                                listbxTP.Add(new string[] { n, "TP2" });
                            }
                    }
                    else if (n.Contains("DATE"))
                    {
                        listbxDates.Add(n);
                    }
                    else if(n.Contains("NDT TYPE"))
                    {
                        listbxNDT.Add(n);
                    }                
                }
            }

            if (listbxUnits.Count > 0)
            {
                filters += GetCheckedUnits2(listbxUnits);
            }

            if (filters != "")
            {
                if (listbxTP.Count > 0)
                { 
                    filters += " AND " + GetTPCheck(listbxTP);
                }
               
            }
            else
            {
                if (listbxTP.Count > 0)
                { 
                    filters += GetTPCheck(listbxTP);
                }
            }

            //if (cmb_htp.SelectedValue != null)
            //{
            //    if (units != "")
            //    {
            //        filters += " AND htp.htp='" + cmb_htp.SelectedValue.ToString() +"'";
            //    }
            //}
            return units+ " " + filters;        
        }

        #region ListBox Filtered

        private string GetCheckedUnits2(List<string> un)
        {
            var checkedUnits = grpbx_units.Controls.OfType<CheckBox>().Count(x => x.Checked);
            string units = checkedUnits > 1 ? " AND ( jts.unit in (" : " AND ( jts.unit =";

            if(!chk_allUnits.Checked)
            {
                    if (checkedUnits > 1)
                    {
                        List<string> unitsList = new List<string>();
                        List<string> otherUnit = new List<string>();

                        foreach (Control c in grpbx_units.Controls)
                        {
                            if ((c is CheckBox) && ((CheckBox)c).Checked)
                            {
                                if (c.Text.Equals("34 - A1") || c.Text.Equals("34 - A2"))
                                {
                                    otherUnit.Add(c.Text);
                                }
                                else
                                {
                                    unitsList.Add(c.Text);
                                }
                            }
                        }

                        int ctr = 0;
                        foreach (string n in unitsList)
                        {
                            ctr++;
                            units += n;
                            if (ctr != unitsList.Count())
                            {
                                units += ",";
                            }
                            else
                            {
                                if (otherUnit.Count > 0)
                                {
                                    units += ")";
                                }
                                else
                                {
                                    units += "))";
                                }
                            }
                        }

                        if (otherUnit.Count > 0)
                        {
                            if (otherUnit.Contains("34 - A1") && otherUnit.Contains("34 - A2"))
                            {
                                units += " or jts.unit = 34";
                            }
                            else if (otherUnit.Contains("34 - A1") && !otherUnit.Contains("34 - A2"))
                            {
                                units += " OR (jts.unit= 34 and (htp.HTP like '30-34-01-%' or htp.HTP like '30-34-03-%')))";
                            }
                            else if (otherUnit.Contains("34 - A2") && !otherUnit.Contains("34 - A1"))
                            {
                                units += " OR (jts.unit= 34 and (htp.HTP like '30-34-02-%')))";
                            }
                        }
                    }
                    else
                    {
                        foreach (Control c in grpbx_units.Controls)
                        {
                            if ((c is CheckBox) && ((CheckBox)c).Checked)
                            {
                                units += c.Text;
                            }
                        }
                    }

                    if (checkedUnits > 0)
                    {
                        return units;
                    }
                    else
                    {
                        return "";
                    }
            }
            else
            {
                return "";
            }
        }

        private string GetCheckedUnits()
        {
            var checkedUnits = grpbx_units.Controls.OfType<CheckBox>().Count(x => x.Checked);
            string units = checkedUnits > 1 ? " AND ( joints.unit in (" : " AND ( joints.unit =";
            //string units = checkedUnits > 1 ? " ( joints.unit in (" : " ( joints.unit =";

            if (checkedUnits > 1)
            {
                List<string> unitsList = new List<string>();
                List<string> otherUnit = new List<string>();

                foreach (Control c in grpbx_units.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        if (c.Text.Equals("34 - A1") || c.Text.Equals("34 - A2"))
                        {
                            otherUnit.Add(c.Text);
                        }
                        else
                        {
                            unitsList.Add(c.Text);
                        }
                    }
                }

                int ctr = 0;
                foreach (string n in unitsList)
                {
                    ctr++;
                    units += n;
                    if(ctr != unitsList.Count())
                    {
                        units += ",";
                    }
                    else
                    {
                        if (otherUnit.Count > 0)
                        {
                            units += ")";
                        }
                        else
                        {
                            units += "))";
                        }
                    }
                }

                if (otherUnit.Count > 0)
                {
                    if (otherUnit.Contains("34 - A1") && otherUnit.Contains("34 - A2"))
                    {
                        units += " or joints.unit = 34";
                    }
                    else if (otherUnit.Contains("34 - A1") && !otherUnit.Contains("34 - A2"))
                    {
                        units += " OR (joints.unit= 34 and (htp.HTP like '30-34-01-%' or htp.HTP like '30-34-03-%')))";
                    }
                    else if (otherUnit.Contains("34 - A2") && !otherUnit.Contains("34 - A1"))
                    {
                         units += " OR (joints.unit= 34 and (htp.HTP like '30-34-02-%')))";
                    }
                }
            }
            else
            {
                foreach (Control c in grpbx_units.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        units += c.Text ;
                    }
                }
            }

            return units;
        }

        private string GetTPCheck(List<string[]> tps)
        {
            string filter = " AND ";

            var tp1 = from u in tps where u.Contains("TP1") select u;
            var tp2 = from u in tps where u.Contains("TP2") select u;

            string tp1filter = "";

            tp1filter += "HTP.UNIT in (";
            int countertp1 = 0;

            foreach (string[] d in tp1)
            {
                countertp1++;
                if (countertp1 != tp1.Count())
                {
                    tp1filter += "'" + d[0].ToString().Substring(d[0].Length - 2) + "', ";
                }
                else
                {
                    tp1filter += "'" + d[0].ToString().Substring(d[0].Length - 2) + "') ";
                }
            }

            string tp2filter = "";

            tp2filter += "HTP.HTP in (";
            int countertp2 = 0;

            foreach (string[] d in tp2)
            {
                countertp2++;
                if (countertp2 != tp1.Count())
                {
                    tp2filter += "'" + d[0].ToString().Replace("TEST PACK: ","") + "', ";
                }
                else
                {
                    tp2filter += "'" + d[0].ToString().Replace("TEST PACK: ", "") + "') ";
                }
            }

            if (tp1.Count() > 0 && tp2.Count() > 0)
            {
                filter += "((" + tp1filter + ") OR (" + tp2filter  +"))";
            }
            else if (tp1.Count() > 0 && tp2.Count() == 0)
            {
                filter += tp1filter;
            }
            else if (tp1.Count() == 0 && tp2.Count() > 0)
            {
                filter += tp2filter;
            }
            return filter;
        }

        #endregion

        #region Queries

        private void AllNDTCumulative()
        {
            DataTable dt_allNDT = new DataTable("AllNDT");

            string script = File.ReadAllText(@"..\Queries\ALL NDT - Current Month -Cumulative.sql");
            script += getFilterString();
            StringBuilder sb = new StringBuilder(script);
            sb.Replace("@DateStart", dtp_from.Text);
            sb.Replace("@DateEnd", dtp_to.Text);
            dt_allNDT = Utilities.GetDBData(sb.ToString());
            dt_allNDT.TableName = "DWRNDT";

            if (Utilities.ExportExcel(dt_allNDT, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " ALL NDT - Monthly Cumulative.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void DWRNDTPerDay()
        {
            DataTable dt_dwrndt = new DataTable("DWRNDT");

            string script = File.ReadAllText(@"..\Queries\DWR-NDT PER DAY.sql");
            script += getFilterString();
            StringBuilder sb = new StringBuilder(script);
            sb.Replace("@startdate", dtp_from.Text);
            sb.Replace("@enddate", dtp_to.Text);
            dt_dwrndt = Utilities.GetDBData(sb.ToString());
            dt_dwrndt.TableName = "DWRNDT";

            if (Utilities.ExportExcel(dt_dwrndt, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " DWR-NDT PER DATE.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void DWRafterTP()
        {
            DataTable dt_dwr = new DataTable("DWR");

            string dwrQuery = File.ReadAllText(@"..\Queries\DWR AFTER TESTED DATE.sql");
            dwrQuery += getFilterString();
            dt_dwr = Utilities.GetDBData(dwrQuery);
            dt_dwr.TableName = "DWR";

            if (Utilities.ExportExcel(dt_dwr, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " DWR AFTER TESTED DATE.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "NDT PERFORMANCE EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "NDT PERFORMANCE EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void NDTBeforeWeld()
        {
            DataTable dt_dwr = new DataTable("DWR");

            string dwrQuery = File.ReadAllText(@"..\Queries\NDT BEFORE DATE OF WELD.sql");
            dwrQuery += getFilterString();
            dt_dwr = Utilities.GetDBData(dwrQuery);
            dt_dwr.TableName = "DWR";

            if (Utilities.ExportExcel(dt_dwr, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " NDT BEFORE DATE OF WELD.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "NDT PERFORMANCE EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "NDT PERFORMANCE EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void JointNDTStatus()
        {
            string script = "";
            StringBuilder sb;

            #region Overall
            DataTable dt_oPwht = new DataTable("PWHT");
            DataTable dt_oPmi = new DataTable("PMI");
            DataTable dt_oHta = new DataTable("HTA");
            DataTable dt_oHtb = new DataTable("HTB");
            DataTable dt_oPt = new DataTable("PT");
            DataTable dt_oFt = new DataTable("FT");

            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - PWHT.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@EndDate", dtp_to.Text);
            dt_oPwht = Utilities.GetDBData(sb.ToString());
            dt_oPwht.TableName = "PWHT";

            script = "";
            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - PMI.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@DateEnd", dtp_to.Text);
            dt_oPmi = Utilities.GetDBData(sb.ToString());
            dt_oPmi.TableName = "PMI";

            script = "";
            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - HTA.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@EndDate", dtp_to.Text);
            dt_oHta = Utilities.GetDBData(sb.ToString());
            dt_oHta.TableName = "HTA";

            script = "";
            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - HTB.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@EndDate", dtp_to.Text);
            dt_oHtb = Utilities.GetDBData(sb.ToString());
            dt_oHtb.TableName = "HTB";


            script = "";
            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - PT.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@EndDate", dtp_to.Text);
            dt_oPt = Utilities.GetDBData(sb.ToString());
            dt_oPt.TableName = "PT";

            script = "";
            script = File.ReadAllText(@"..\Queries\NDT JOINT STATUS PER DATE\OVERALL - FT.sql");
            sb = new StringBuilder(script);
            sb.Replace("@StartDate", dtp_from.Text);
            sb.Replace("@EndDate", dtp_to.Text);
            dt_oFt = Utilities.GetDBData(sb.ToString());
            dt_oFt.TableName = "FT";
            #endregion

            List<DataTable> ndttbls = new List<DataTable>();
            ndttbls.Add(dt_oFt);
            ndttbls.Add(dt_oHta);
            ndttbls.Add(dt_oHtb);
            ndttbls.Add(dt_oPmi);
            ndttbls.Add(dt_oPt);
            ndttbls.Add(dt_oPwht);

            if (Utilities.ExportExcel(ndttbls, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " NDT JOINT STATUS PER DATE.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void NDTAfterTest()
        {
            DataTable rt = new DataTable("RT");
            DataTable pwht = new DataTable("PWHT");
            DataTable pmi = new DataTable("PMI");
            DataTable hta = new DataTable("HTA");
            DataTable htb = new DataTable("HTA");
            DataTable pt = new DataTable("PT");
            DataTable ft = new DataTable("FT");

            string rtQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\RT.sql");
            rt = Utilities.GetDBData(rtQuery);
            rt.TableName = "RT";

            mainMenu.ChangeUpperLabel("EXTRACTING PWHT");
            string pwhtQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\PWHT.sql");
            pwht = Utilities.GetDBData(pwhtQuery);
            pwht.TableName = "PWHT";

            mainMenu.ChangeUpperLabel("EXTRACTING PMI");
            string pmiQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\PMI.sql");
            pmi = Utilities.GetDBData(pmiQuery);
            pmi.TableName = "PMI";

            mainMenu.ChangeUpperLabel("EXTRACTING HTA");
            string htaQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\HTA.sql");
            hta = Utilities.GetDBData(htaQuery);
            hta.TableName = "HTA";

            mainMenu.ChangeUpperLabel("EXTRACTING HTB");
            string htbQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\HTB.sql");
            htb = Utilities.GetDBData(htbQuery);
            htb.TableName = "HTB";

            mainMenu.ChangeUpperLabel("EXTRACTING PT");
            string ptQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\PT.sql");
            pt = Utilities.GetDBData(ptQuery);
            pt.TableName = "PT";

            mainMenu.ChangeUpperLabel("EXTRACTING FT");
            string ftQuery = File.ReadAllText(@"..\Queries\NDT AFTER TESTED DATE\FT.sql");
            ft = Utilities.GetDBData(ftQuery);
            ft.TableName = "FT";

            mainMenu.ChangeUpperLabel("EXPORTING TO EXCEL...");

            List<DataTable> NDTPerformances = new List<DataTable>();
            NDTPerformances.Add(rt);
            NDTPerformances.Add(pwht);
            NDTPerformances.Add(pmi);
            NDTPerformances.Add(hta);
            NDTPerformances.Add(htb);
            NDTPerformances.Add(pt);
            NDTPerformances.Add(ft);

            if (Utilities.ExportExcel(NDTPerformances, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + " NDT AFTER TESTED DATE.xlsx"))
            {
                MetroMessageBox.Show(mainMenu, "FILE LOCATED ON YOUR DESKTOP", "NDT PERFORMANCE EXPORT SUCCESSFUL!", MessageBoxButtons.OK, MessageBoxIcon.Question, 150);
            }
            else
            {
                MetroMessageBox.Show(mainMenu, "", "NDT PERFORMANCE EXPORT FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        private void NDTStatusPerDate()
        { 
        
        }

        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mainMenu.StartLoading();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainMenu.CloseLoading();
        }

        private void frm_Queries_Load(object sender, EventArgs e)
        {
         
        }

        private void chk_allUnits_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allUnits.Checked)
            {
                chk_01.Enabled = false;
                chk_02.Enabled = false;
                chk_03.Enabled = false;
                chk_04.Enabled = false;
                chk_05.Enabled = false;
                chk_06.Enabled = false;
                chk_11.Enabled = false;
                chk_12.Enabled = false;
                chk_13.Enabled = false;
                chk_14.Enabled = false;
                chk_21.Enabled = false;
                chk_22.Enabled = false;
                chk_23.Enabled = false;
                chk_25.Enabled = false;
                chk_34_1.Enabled = false;
                chk_34_2.Enabled = false;
                chk_74.Enabled = false;

                chk_01.Checked = true;
                chk_02.Checked = true;
                chk_03.Checked = true;
                chk_04.Checked = true;
                chk_05.Checked = true;
                chk_06.Checked = true;
                chk_11.Checked = true;
                chk_12.Checked = true;
                chk_13.Checked = true;
                chk_14.Checked = true;
                chk_21.Checked = true;
                chk_22.Checked = true;
                chk_23.Checked = true;
                chk_25.Checked = true;
                chk_34_1.Checked = true;
                chk_34_2.Checked = true;
                chk_74.Checked = true;
                //rtxtbx_filters.Text += "UNITS: ALL";
            }
            else
            {
                chk_01.Enabled = true;
                chk_02.Enabled = true;
                chk_03.Enabled = true;
                chk_04.Enabled = true;
                chk_05.Enabled = true;
                chk_06.Enabled = true;
                chk_11.Enabled = true;
                chk_12.Enabled = true;
                chk_13.Enabled = true;
                chk_14.Enabled = true;
                chk_21.Enabled = true;
                chk_22.Enabled = true;
                chk_23.Enabled = true;
                chk_25.Enabled = true;
                chk_34_1.Enabled = true;
                chk_34_2.Enabled = true;
                chk_74.Enabled = true;

                chk_01.Checked = false;
                chk_02.Checked = false;
                chk_03.Checked = false;
                chk_04.Checked = false;
                chk_05.Checked = false;
                chk_06.Checked = false;
                chk_11.Checked = false;
                chk_12.Checked = false;
                chk_13.Checked = false;
                chk_14.Checked = false;
                chk_21.Checked = false;
                chk_22.Checked = false;
                chk_23.Checked = false;
                chk_25.Checked = false;
                chk_34_1.Checked = false;
                chk_34_2.Checked = false;
                chk_74.Checked = false;
                //rtxtbx_filters.Text += "";
            }
        }

        private void AddUnitFilters()
        {
            string checkedUnits = "UNITS: ";

            List<string> unitsList = new List<string>();

            if (!chk_allUnits.Checked)
            {
                foreach (Control c in grpbx_units.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        unitsList.Add(c.Text);
                    }
                }

                if (unitsList.Count > 0)
                {
                    foreach (string n in unitsList)
                    {
                        checkedUnits += n;
                        if (!(unitsList.Last() == n))
                        {
                            checkedUnits += ",";
                        }
                    }
                    lstbx_filters.Items.Add(checkedUnits);
                }
                else
                {
                    MetroMessageBox.Show(mainMenu, "PLEASE SELECT ATLEAST ONE UNIT", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
                }
            }
            else
            {
                lstbx_filters.Items.Add( checkedUnits +=  " ALL ISO UNITS");
            }
 
        }

        private void chk_01_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_02_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chk_21_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chk_34_1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chk_11_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chk_12_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_22_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chk_34_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_03_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_06_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chk_23_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chk_74_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void chk_04_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chk_13_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chk_25_CheckedChanged(object sender, EventArgs e)
        {
          
        }
         
        private void chk_05_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chk_14_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUnitFilters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            this.lstbx_filters.Items.Remove(lstbx_filters.SelectedItem);
        }

        private void lstbx_filters_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTP();
        }

        private void AddTP()
        {
            if (rd_allTP.Checked)
            {
                lstbx_filters.Items.Add("ALL TEST PACK AND ALL UNITS");
            }
            else
            {
                if (chk_TPAll.Checked)
                {
                    lstbx_filters.Items.Add("TEST PACK: ALL UNIT - " + cmb_tp_unit.SelectedValue.ToString());
                }
                else
                {
                    lstbx_filters.Items.Add("TEST PACK: " + cmb_htp.SelectedValue.ToString());
                }
            }        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstbx_filters.Items.Add("DATE RANGE: " + dtp_from.Text + " - " + dtp_to.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {                
                rchtxtbx_desc.Clear();
                if (lstbx_filters.Items.Count > 0)
                {
                    lstbx_filters.Items.Clear();
                }

                try
                {
                    rchtxtbx_desc.Text = File.ReadAllText(@"..\Queries Description\" + comboBox1.SelectedItem + ".txt"); 
                }
                catch (Exception)
                {
                    
                }

                try
                {
                    if (comboBox1.SelectedIndex.Equals(0))
                    {
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = true;
                        grpbx_HTP.Enabled = false;
                        grpbx_units.Enabled = false;
                    }
                    else if (comboBox1.SelectedIndex.Equals(1)) //DWR AFTER TESTED DATE
                    {
                        grpbx_units.Enabled = true;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = false;
                        grpbx_HTP.Enabled = true;
                    }
                    else if (comboBox1.SelectedIndex.Equals(2))
                    {
                        grpbx_units.Enabled = true;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = true;
                        grpbx_HTP.Enabled = false;
                    }
                    else if (comboBox1.SelectedIndex.Equals(3))
                    {
                        grpbx_units.Enabled = false;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = false;
                        grpbx_HTP.Enabled = false;
                    }
                    else if (comboBox1.SelectedIndex.Equals(4))
                    {
                        grpbx_units.Enabled = false;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = true;
                        grpbx_HTP.Enabled = false;
                    }
                    else if (comboBox1.SelectedIndex.Equals(5))
                    {
                        grpbx_units.Enabled = false;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = false;
                        grpbx_HTP.Enabled = false;
                    }
                    else if (comboBox1.SelectedIndex.Equals(6)) //NDT PERFORMANCE
                    {
                        grpbx_units.Enabled = true;
                        grpbx_NDTtype.Enabled = false;
                        grpbx_Dates.Enabled = false;
                        grpbx_HTP.Enabled = false;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btn_addFilter_Click(object sender, EventArgs e)
        {
            AddUnitFilters();
        }

        private void LoadColumns(string selection)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddTP();
        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_tpOthers.Checked)
            {
                grpbx_others.Enabled = true;

            }
            else
            {
                grpbx_others.Enabled = false;
            }
        }

        private void rdbtn_tp_CheckedChanged(object sender, EventArgs e)
        {
            if (!cmb_tp_unit.SelectedValue.Equals("ALL"))
            {
                Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT HTP FROM HTP WHERE ACTIVE = 1 and UNIT =" + cmb_tp_unit.SelectedValue + " union select 'ALL' order by HTP"), cmb_htp);
                cmb_htp.Refresh();
            }
            else
            {
                Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT HTP FROM HTP WHERE ACTIVE = 1 union select 'ALL' order by HTP"), cmb_htp);
                cmb_htp.Refresh();
            }

        }

        private void rd_btnSS_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cmb_tp_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chk_TPAll.Checked)
            { 
                if (cmb_tp_unit.SelectedValue.Equals("ALL"))
                {
                    cmb_htp.Enabled = false;
                    //Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT HTP FROM HTP WHERE ACTIVE = 1 order by HTP"), cmb_htp);
                    //cmb_htp.Refresh();
                }
                else 
                {
                    if (cmb_tp_unit.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        cmb_htp.Enabled = true;
                        Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT HTP FROM HTP WHERE ACTIVE = 1 and unit= "+ cmb_tp_unit.SelectedValue +" union select 'ALL' order by HTP"), cmb_htp);
                        cmb_htp.Refresh();                
                    }
                }            
            }
        }

        private void btn_datesAddFilter_Click(object sender, EventArgs e)
        {
            lstbx_filters.Items.Add(cmb_DateType.Text + " DATE : FROM " + dtp_from.Text + " TO " + dtp_to.Text);
        }

        private void btn_ndtTypeFilter_Click(object sender, EventArgs e)
        {
            lstbx_filters.Items.Add("NDT TYPE: " + cmb_NDTType.Text);
        }

        private void chk_TPAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_TPAll.Checked)
            {
                cmb_htp.Enabled = false;
            }
            else
            {
                cmb_htp.Enabled = true;
            }
        }

        private void btn_sampleResult_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            { 
                try
                {
                    if (comboBox1.SelectedIndex.Equals(0)) //Cumulative
                    {
                        Process.Start(@"..\Queries Results\ALL NDT - Monthly Cumulative.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(1)) //DWR AFTER TESTED DATE
                    {
                        Process.Start(@"..\Queries Results\DWR AFTER TESTED DATE.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(2)) //DWR- NDT per day
                    {
                        Process.Start(@"..\Queries Results\DWR-NDT PER DATE.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(3)) //NDT BEFORE DATE OF WELD
                    {
                        Process.Start(@"..\Queries Results\NDT BEFORE DATE OF WELD.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(4)) //NDT REPORT JOINT COUNT
                    {
                        Process.Start(@"..\Queries Results\NDT JOINT STATUS PER DATE.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(5)) //NDT AFTER TESTED DATE
                    {
                        Process.Start(@"..\Queries Results\NDT AFTER TESTED DATE.xlsx");
                    }
                    else if (comboBox1.SelectedIndex.Equals(6)) //NDT PERFORMANCE
                    {
                        Process.Start(@"..\Queries Results\NDT PERFORMANCE.xlsx");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
