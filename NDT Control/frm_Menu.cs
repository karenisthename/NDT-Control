using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MetroFramework.Forms;
using System.IO;
using MetroFramework;

namespace NDT_Control
{
    public partial class frm_menu : MetroForm
    {
        public static string conStr;
        frmLoading newload = new frmLoading();

        public frm_menu()
        {
            InitializeComponent();
            conStr = File.ReadAllText(@"..\ndtConTest.cfg");
            txtUserName.Text = Environment.UserName;
        }

        private void btn_NDTMain_Click(object sender, EventArgs e)
        {
        }

        private void btn_SpoolRelease_Click(object sender, EventArgs e)
        {            
            MetroMessageBox.Show(this, "This feature has been disabled", "FEATURE NOT AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.None, 150);
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {            
            frm_uploadData uploadData = new frm_uploadData(this);
            uploadData.TopLevel = false;
            pnl_Forms.Controls.Add(uploadData);
            uploadData.Dock = DockStyle.Fill;
            uploadData.Show();
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frm_Reports reports = new frm_Reports(this);
            reports.TopLevel = false;
            pnl_Forms.Controls.Add(reports);
            reports.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_about newabout = new frm_about();
            newabout.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDWRTP2 reportTP = new frmDWRTP2(this);
            reportTP.TopLevel = false;
            pnl_Forms.Controls.Add(reportTP);
            reportTP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_queries_Click(object sender, EventArgs e)
        {
            frm_Queries queryForm = new frm_Queries(this);
            queryForm.TopLevel = false;
            pnl_Forms.Controls.Add(queryForm);
            queryForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_Formats formatsForm = new frm_Formats();
            formatsForm.TopLevel = false;
            pnl_Forms.Controls.Add(formatsForm);
            formatsForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        public void StartLoading()
        {
            if (!newload.IsHandleCreated)
            {
                Thread t = new Thread(new ThreadStart(LoadingForm));
                t.IsBackground = true;
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    newload.ShowDialog();
                });
            }
        }

        public void CloseLoading()
        {
            if (this.newload != null)
            {
                this.Invoke(new Action(() => this.newload.Close()));
            }
        }

        public void ChangeUpperLabel(string strDisp)
        {
            try
            {
                newload.BeginInvoke((MethodInvoker)delegate() { newload.excelloading(strDisp); });
            }
            catch (Exception)
            {
            }
        }

        public void ChangeLowerLabel(int n1, int n2, string strDisp)
        {
            try
            {
                newload.BeginInvoke((MethodInvoker)delegate() { newload.changeNumber(n1, n2, strDisp); });
            }
            catch (Exception)
            {
                
            }
        }

        public void LoadingForm()
        {
            if (newload != null)
            {
                newload = new frmLoading(this);
                newload.ShowDialog();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void pnl_loading_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Environment.UserName != "woliveira")
            {
              MetroMessageBox.Show(this, "SORRY YOU ARE NOT AUTHORISED TO VIEW THE NDT LOGS", "There's something wrong.", MessageBoxButtons.OK, MessageBoxIcon.Hand, 150);
            }
            else
            { 
                frmLogs queryForm = new frmLogs();
                queryForm.TopLevel = false;
                pnl_Forms.Controls.Add(queryForm);
                queryForm.Show();            
            }
        }

        private void btn_ndtStatus_Click(object sender, EventArgs e)
        {
            frm_ndtStatus queryForm = new frm_ndtStatus(this);
            queryForm.TopLevel = false;
            pnl_Forms.Controls.Add(queryForm);
            queryForm.Dock = DockStyle.Fill;
            queryForm.Show();         
        }
    }
}
