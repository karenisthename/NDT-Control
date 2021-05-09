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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace NDT_Control
{
    public partial class frm_DWR_TP : MetroForm
    {
        public static string conStr;
        useSQL.useSQL dbCon;

        public frm_DWR_TP()
        {
            InitializeComponent();
            conStr = File.ReadAllText(@"..\ndtCon.cfg");
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMode.SelectedItem.ToString().Equals("DWR AFTER PRESSURE TEST"))
                {
                    string script = File.ReadAllText(@"..\QUERIES\DWR after TP.sql");
                    StringBuilder sb = new StringBuilder(script);
                    sb.Replace("@testpacknum", txt_tp.Text);
                    sb.Replace("@TPDate", txt_tpDate.Text);

                    DataTable retData = new DataTable();
                    lst_joints.Items.Clear();

                    using (dbCon = new useSQL.useSQL(conStr))
                    {
                        retData = dbCon.PerformQuery(sb.ToString());
                    }

                    if (retData.Rows.Count > 0)
                    {
                        for (int n = 0; n < retData.Rows.Count; n++)
                        {
                            string[] row = { retData.Rows[n][0].ToString(), retData.Rows[n][1].ToString(),
                                           retData.Rows[n][2].ToString(),retData.Rows[n][3].ToString(),
                                           retData.Rows[n][4].ToString(),retData.Rows[n][5].ToString(),
                                           retData.Rows[n][6].ToString(),retData.Rows[n][7].ToString()};
                        
                            var jointData = new ListViewItem(row);
                            lst_joints.Items.Add(jointData);
                        }
                    }
                    pnl_NDT_Loader.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("TP number or TP Date is invalid.");
            }
         
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExporttoExcel();
        }

        public void ExporttoExcel()
        {
            Missing mv = Missing.Value;
            Microsoft.Office.Interop.Excel.Application NewExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook wkb = NewExcelApp.Workbooks.Add(mv);
            Excel.Worksheet wks = wkb.Sheets[1];

            for (int y = 0; y <= lst_joints.Columns.Count - 1; y++)
            {
                ((Excel.Range)wks.Cells[1, y + 1]).Value = lst_joints.Columns[y].Text;
            }

            for (int x = 1; x <= lst_joints.Items.Count; x++)
            {
                for (int y = 0; y <= lst_joints.Columns.Count - 1; y++)
                {
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).NumberFormat = "@";
                    ((Excel.Range)wks.Cells[x + 1, y + 1]).Value = lst_joints.Items[x - 1].SubItems[y].Text;
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            string filePath ="";

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                filePath = sfd.FileName;                
            }
            wkb.SaveAs(filePath);
            wks = null;
            wkb = null;
            NewExcelApp.Quit();
            MessageBox.Show("SUCCESSFULLY EXPORTED!", "EXPORT LIST TO EXCEL");
        }
    }
}
