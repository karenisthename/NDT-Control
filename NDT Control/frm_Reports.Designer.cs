namespace NDT_Control
{
    partial class frm_Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_filePath = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNdt = new System.Windows.Forms.ComboBox();
            this.ofd_fileOpen = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_filePath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbNdt);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 73);
            this.panel2.TabIndex = 4;
            // 
            // txt_filePath
            // 
            // 
            // 
            // 
            this.txt_filePath.CustomButton.Image = null;
            this.txt_filePath.CustomButton.Location = new System.Drawing.Point(178, 1);
            this.txt_filePath.CustomButton.Name = "";
            this.txt_filePath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_filePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_filePath.CustomButton.TabIndex = 1;
            this.txt_filePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_filePath.CustomButton.UseSelectable = true;
            this.txt_filePath.CustomButton.Visible = false;
            this.txt_filePath.Enabled = false;
            this.txt_filePath.Lines = new string[0];
            this.txt_filePath.Location = new System.Drawing.Point(75, 35);
            this.txt_filePath.MaxLength = 32767;
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.PasswordChar = '\0';
            this.txt_filePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_filePath.SelectedText = "";
            this.txt_filePath.SelectionLength = 0;
            this.txt_filePath.SelectionStart = 0;
            this.txt_filePath.ShortcutsEnabled = true;
            this.txt_filePath.Size = new System.Drawing.Size(200, 23);
            this.txt_filePath.TabIndex = 9;
            this.txt_filePath.UseSelectable = true;
            this.txt_filePath.Visible = false;
            this.txt_filePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_filePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "File Path:";
            this.label2.Visible = false;
            // 
            // btnVerify
            // 
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.BackColor = System.Drawing.Color.White;
            this.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnVerify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnVerify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerify.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerify.Location = new System.Drawing.Point(311, 4);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(176, 24);
            this.btnVerify.TabIndex = 7;
            this.btnVerify.Text = "CHECK FILES AND IMPORT";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "NDT:";
            // 
            // cmbNdt
            // 
            this.cmbNdt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNdt.FormattingEnabled = true;
            this.cmbNdt.Items.AddRange(new object[] {
            "RT",
            "PWHT",
            "HTA",
            "HTB",
            "PMI",
            "PT",
            "FERRIT"});
            this.cmbNdt.Location = new System.Drawing.Point(75, 7);
            this.cmbNdt.Name = "cmbNdt";
            this.cmbNdt.Size = new System.Drawing.Size(200, 22);
            this.cmbNdt.TabIndex = 2;
            // 
            // ofd_fileOpen
            // 
            this.ofd_fileOpen.FileName = "ofd_fileOpen";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frm_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(516, 108);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Reports";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Report";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNdt;
        private MetroFramework.Controls.MetroTextBox txt_filePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofd_fileOpen;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}