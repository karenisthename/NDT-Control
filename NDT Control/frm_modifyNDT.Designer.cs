namespace NDT_Control
{
    partial class frm_modifyNDT
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
            this.gb_loaderbg = new System.Windows.Forms.GroupBox();
            this.pnl_report = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_ndttype_report = new System.Windows.Forms.ComboBox();
            this.txt_report = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_joint = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_ndt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_joint = new MetroFramework.Controls.MetroTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_train = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_line = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_service = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Unit = new MetroFramework.Controls.MetroTextBox();
            this.pnl_loader = new System.Windows.Forms.Panel();
            this.txtfilepath = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.pnl_bgloader = new System.Windows.Forms.Panel();
            this.pnl_repbg = new System.Windows.Forms.Panel();
            this.pnl_jointbg = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_Loader = new System.Windows.Forms.RadioButton();
            this.rd_joint = new System.Windows.Forms.RadioButton();
            this.rd_report = new System.Windows.Forms.RadioButton();
            this.btnVerify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.btn_update = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.gb_loaderbg.SuspendLayout();
            this.pnl_report.SuspendLayout();
            this.pnl_joint.SuspendLayout();
            this.pnl_loader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gb_loaderbg);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(14, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(893, 283);
            this.panel2.TabIndex = 4;
            // 
            // gb_loaderbg
            // 
            this.gb_loaderbg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_loaderbg.Controls.Add(this.pnl_report);
            this.gb_loaderbg.Controls.Add(this.pnl_joint);
            this.gb_loaderbg.Controls.Add(this.pnl_loader);
            this.gb_loaderbg.Controls.Add(this.pnl_bgloader);
            this.gb_loaderbg.Controls.Add(this.pnl_repbg);
            this.gb_loaderbg.Controls.Add(this.pnl_jointbg);
            this.gb_loaderbg.Location = new System.Drawing.Point(63, 39);
            this.gb_loaderbg.Name = "gb_loaderbg";
            this.gb_loaderbg.Size = new System.Drawing.Size(815, 203);
            this.gb_loaderbg.TabIndex = 15;
            this.gb_loaderbg.TabStop = false;
            // 
            // pnl_report
            // 
            this.pnl_report.BackColor = System.Drawing.Color.Honeydew;
            this.pnl_report.Controls.Add(this.label10);
            this.pnl_report.Controls.Add(this.cmb_ndttype_report);
            this.pnl_report.Controls.Add(this.txt_report);
            this.pnl_report.Controls.Add(this.label6);
            this.pnl_report.Location = new System.Drawing.Point(286, 20);
            this.pnl_report.Name = "pnl_report";
            this.pnl_report.Size = new System.Drawing.Size(279, 122);
            this.pnl_report.TabIndex = 12;
            this.pnl_report.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "NDT TYPE:";
            // 
            // cmb_ndttype_report
            // 
            this.cmb_ndttype_report.FormattingEnabled = true;
            this.cmb_ndttype_report.Items.AddRange(new object[] {
            "PWHT",
            "HTA",
            "HTB",
            "PMI",
            "PT",
            "FT"});
            this.cmb_ndttype_report.Location = new System.Drawing.Point(5, 26);
            this.cmb_ndttype_report.Name = "cmb_ndttype_report";
            this.cmb_ndttype_report.Size = new System.Drawing.Size(69, 22);
            this.cmb_ndttype_report.TabIndex = 19;
            // 
            // txt_report
            // 
            this.txt_report.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_report.CustomButton.Image = null;
            this.txt_report.CustomButton.Location = new System.Drawing.Point(251, 1);
            this.txt_report.CustomButton.Name = "";
            this.txt_report.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_report.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_report.CustomButton.TabIndex = 1;
            this.txt_report.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_report.CustomButton.UseSelectable = true;
            this.txt_report.CustomButton.Visible = false;
            this.txt_report.Lines = new string[0];
            this.txt_report.Location = new System.Drawing.Point(3, 68);
            this.txt_report.MaxLength = 32767;
            this.txt_report.Name = "txt_report";
            this.txt_report.PasswordChar = '\0';
            this.txt_report.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_report.SelectedText = "";
            this.txt_report.SelectionLength = 0;
            this.txt_report.SelectionStart = 0;
            this.txt_report.ShortcutsEnabled = true;
            this.txt_report.Size = new System.Drawing.Size(273, 23);
            this.txt_report.TabIndex = 8;
            this.txt_report.UseSelectable = true;
            this.txt_report.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_report.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8F);
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "REPORT NUMBER:";
            // 
            // pnl_joint
            // 
            this.pnl_joint.BackColor = System.Drawing.Color.Honeydew;
            this.pnl_joint.Controls.Add(this.button1);
            this.pnl_joint.Controls.Add(this.label9);
            this.pnl_joint.Controls.Add(this.cmb_ndt);
            this.pnl_joint.Controls.Add(this.label7);
            this.pnl_joint.Controls.Add(this.txt_joint);
            this.pnl_joint.Controls.Add(this.label8);
            this.pnl_joint.Controls.Add(this.txt_train);
            this.pnl_joint.Controls.Add(this.label5);
            this.pnl_joint.Controls.Add(this.txt_line);
            this.pnl_joint.Controls.Add(this.label4);
            this.pnl_joint.Controls.Add(this.txt_service);
            this.pnl_joint.Controls.Add(this.label3);
            this.pnl_joint.Controls.Add(this.txt_Unit);
            this.pnl_joint.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_joint.Location = new System.Drawing.Point(587, 16);
            this.pnl_joint.Name = "pnl_joint";
            this.pnl_joint.Size = new System.Drawing.Size(215, 177);
            this.pnl_joint.TabIndex = 12;
            this.pnl_joint.Visible = false;
            this.pnl_joint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_joint_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SeaGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(8, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 28);
            this.button1.TabIndex = 19;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(51, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "NDT TYPE:";
            // 
            // cmb_ndt
            // 
            this.cmb_ndt.FormattingEnabled = true;
            this.cmb_ndt.Items.AddRange(new object[] {
            "PWHT",
            "HTA",
            "HTB",
            "PMI",
            "PT",
            "FT"});
            this.cmb_ndt.Location = new System.Drawing.Point(109, 108);
            this.cmb_ndt.Name = "cmb_ndt";
            this.cmb_ndt.Size = new System.Drawing.Size(68, 21);
            this.cmb_ndt.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "JOINT NO.:";
            // 
            // txt_joint
            // 
            this.txt_joint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_joint.CustomButton.Image = null;
            this.txt_joint.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txt_joint.CustomButton.Name = "";
            this.txt_joint.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_joint.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_joint.CustomButton.TabIndex = 1;
            this.txt_joint.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_joint.CustomButton.UseSelectable = true;
            this.txt_joint.CustomButton.Visible = false;
            this.txt_joint.Lines = new string[0];
            this.txt_joint.Location = new System.Drawing.Point(160, 57);
            this.txt_joint.MaxLength = 32767;
            this.txt_joint.Name = "txt_joint";
            this.txt_joint.PasswordChar = '\0';
            this.txt_joint.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_joint.SelectedText = "";
            this.txt_joint.SelectionLength = 0;
            this.txt_joint.SelectionStart = 0;
            this.txt_joint.ShortcutsEnabled = true;
            this.txt_joint.Size = new System.Drawing.Size(48, 23);
            this.txt_joint.TabIndex = 15;
            this.txt_joint.UseSelectable = true;
            this.txt_joint.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_joint.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "TRAIN:";
            // 
            // txt_train
            // 
            this.txt_train.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_train.CustomButton.Image = null;
            this.txt_train.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txt_train.CustomButton.Name = "";
            this.txt_train.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_train.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_train.CustomButton.TabIndex = 1;
            this.txt_train.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_train.CustomButton.UseSelectable = true;
            this.txt_train.CustomButton.Visible = false;
            this.txt_train.Lines = new string[0];
            this.txt_train.Location = new System.Drawing.Point(160, 24);
            this.txt_train.MaxLength = 32767;
            this.txt_train.Name = "txt_train";
            this.txt_train.PasswordChar = '\0';
            this.txt_train.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_train.SelectedText = "";
            this.txt_train.SelectionLength = 0;
            this.txt_train.SelectionStart = 0;
            this.txt_train.ShortcutsEnabled = true;
            this.txt_train.Size = new System.Drawing.Size(48, 23);
            this.txt_train.TabIndex = 13;
            this.txt_train.UseSelectable = true;
            this.txt_train.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_train.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "LINE:";
            // 
            // txt_line
            // 
            this.txt_line.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_line.CustomButton.Image = null;
            this.txt_line.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txt_line.CustomButton.Name = "";
            this.txt_line.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_line.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_line.CustomButton.TabIndex = 1;
            this.txt_line.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_line.CustomButton.UseSelectable = true;
            this.txt_line.CustomButton.Visible = false;
            this.txt_line.Lines = new string[0];
            this.txt_line.Location = new System.Drawing.Point(54, 68);
            this.txt_line.MaxLength = 32767;
            this.txt_line.Name = "txt_line";
            this.txt_line.PasswordChar = '\0';
            this.txt_line.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_line.SelectedText = "";
            this.txt_line.SelectionLength = 0;
            this.txt_line.SelectionStart = 0;
            this.txt_line.ShortcutsEnabled = true;
            this.txt_line.Size = new System.Drawing.Size(48, 23);
            this.txt_line.TabIndex = 11;
            this.txt_line.UseSelectable = true;
            this.txt_line.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_line.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SERVICE:";
            // 
            // txt_service
            // 
            this.txt_service.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_service.CustomButton.Image = null;
            this.txt_service.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txt_service.CustomButton.Name = "";
            this.txt_service.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_service.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_service.CustomButton.TabIndex = 1;
            this.txt_service.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_service.CustomButton.UseSelectable = true;
            this.txt_service.CustomButton.Visible = false;
            this.txt_service.Lines = new string[0];
            this.txt_service.Location = new System.Drawing.Point(54, 39);
            this.txt_service.MaxLength = 32767;
            this.txt_service.Name = "txt_service";
            this.txt_service.PasswordChar = '\0';
            this.txt_service.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_service.SelectedText = "";
            this.txt_service.SelectionLength = 0;
            this.txt_service.SelectionStart = 0;
            this.txt_service.ShortcutsEnabled = true;
            this.txt_service.Size = new System.Drawing.Size(48, 23);
            this.txt_service.TabIndex = 9;
            this.txt_service.UseSelectable = true;
            this.txt_service.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_service.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "UNIT:";
            // 
            // txt_Unit
            // 
            this.txt_Unit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txt_Unit.CustomButton.Image = null;
            this.txt_Unit.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txt_Unit.CustomButton.Name = "";
            this.txt_Unit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_Unit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_Unit.CustomButton.TabIndex = 1;
            this.txt_Unit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_Unit.CustomButton.UseSelectable = true;
            this.txt_Unit.CustomButton.Visible = false;
            this.txt_Unit.Lines = new string[0];
            this.txt_Unit.Location = new System.Drawing.Point(54, 10);
            this.txt_Unit.MaxLength = 32767;
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.PasswordChar = '\0';
            this.txt_Unit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Unit.SelectedText = "";
            this.txt_Unit.SelectionLength = 0;
            this.txt_Unit.SelectionStart = 0;
            this.txt_Unit.ShortcutsEnabled = true;
            this.txt_Unit.Size = new System.Drawing.Size(48, 23);
            this.txt_Unit.TabIndex = 7;
            this.txt_Unit.UseSelectable = true;
            this.txt_Unit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_Unit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pnl_loader
            // 
            this.pnl_loader.BackColor = System.Drawing.Color.Honeydew;
            this.pnl_loader.Controls.Add(this.txtfilepath);
            this.pnl_loader.Controls.Add(this.label2);
            this.pnl_loader.Controls.Add(this.btn_browse);
            this.pnl_loader.Location = new System.Drawing.Point(9, 18);
            this.pnl_loader.Name = "pnl_loader";
            this.pnl_loader.Size = new System.Drawing.Size(258, 122);
            this.pnl_loader.TabIndex = 14;
            this.pnl_loader.Visible = false;
            // 
            // txtfilepath
            // 
            this.txtfilepath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.txtfilepath.CustomButton.Image = null;
            this.txtfilepath.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.txtfilepath.CustomButton.Name = "";
            this.txtfilepath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtfilepath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtfilepath.CustomButton.TabIndex = 1;
            this.txtfilepath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtfilepath.CustomButton.UseSelectable = true;
            this.txtfilepath.CustomButton.Visible = false;
            this.txtfilepath.Lines = new string[0];
            this.txtfilepath.Location = new System.Drawing.Point(63, 5);
            this.txtfilepath.MaxLength = 32767;
            this.txtfilepath.Name = "txtfilepath";
            this.txtfilepath.PasswordChar = '\0';
            this.txtfilepath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtfilepath.SelectedText = "";
            this.txtfilepath.SelectionLength = 0;
            this.txtfilepath.SelectionStart = 0;
            this.txtfilepath.ShortcutsEnabled = true;
            this.txtfilepath.Size = new System.Drawing.Size(189, 23);
            this.txtfilepath.TabIndex = 8;
            this.txtfilepath.UseSelectable = true;
            this.txtfilepath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtfilepath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "FILE PATH:";
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browse.BackColor = System.Drawing.Color.White;
            this.btn_browse.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_browse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_browse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browse.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_browse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_browse.Location = new System.Drawing.Point(10, 34);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(242, 26);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "BROWSE FILE";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // pnl_bgloader
            // 
            this.pnl_bgloader.BackColor = System.Drawing.Color.SeaGreen;
            this.pnl_bgloader.Location = new System.Drawing.Point(13, 23);
            this.pnl_bgloader.Name = "pnl_bgloader";
            this.pnl_bgloader.Size = new System.Drawing.Size(258, 122);
            this.pnl_bgloader.TabIndex = 15;
            this.pnl_bgloader.Visible = false;
            // 
            // pnl_repbg
            // 
            this.pnl_repbg.BackColor = System.Drawing.Color.SeaGreen;
            this.pnl_repbg.Location = new System.Drawing.Point(291, 25);
            this.pnl_repbg.Name = "pnl_repbg";
            this.pnl_repbg.Size = new System.Drawing.Size(279, 122);
            this.pnl_repbg.TabIndex = 13;
            this.pnl_repbg.Visible = false;
            // 
            // pnl_jointbg
            // 
            this.pnl_jointbg.BackColor = System.Drawing.Color.SeaGreen;
            this.pnl_jointbg.Location = new System.Drawing.Point(592, 21);
            this.pnl_jointbg.Name = "pnl_jointbg";
            this.pnl_jointbg.Size = new System.Drawing.Size(215, 177);
            this.pnl_jointbg.TabIndex = 19;
            this.pnl_jointbg.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rd_Loader);
            this.groupBox1.Controls.Add(this.rd_joint);
            this.groupBox1.Controls.Add(this.rd_report);
            this.groupBox1.Location = new System.Drawing.Point(63, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 36);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rd_Loader
            // 
            this.rd_Loader.AutoSize = true;
            this.rd_Loader.Location = new System.Drawing.Point(103, 12);
            this.rd_Loader.Name = "rd_Loader";
            this.rd_Loader.Size = new System.Drawing.Size(62, 18);
            this.rd_Loader.TabIndex = 8;
            this.rd_Loader.Text = "Loader";
            this.rd_Loader.UseVisualStyleBackColor = true;
            this.rd_Loader.CheckedChanged += new System.EventHandler(this.rd_Loader_CheckedChanged);
            // 
            // rd_joint
            // 
            this.rd_joint.AutoSize = true;
            this.rd_joint.Location = new System.Drawing.Point(615, 12);
            this.rd_joint.Name = "rd_joint";
            this.rd_joint.Size = new System.Drawing.Size(94, 18);
            this.rd_joint.TabIndex = 9;
            this.rd_joint.Text = "Specific Joint";
            this.rd_joint.UseVisualStyleBackColor = true;
            this.rd_joint.CheckedChanged += new System.EventHandler(this.rd_joint_CheckedChanged);
            // 
            // rd_report
            // 
            this.rd_report.AutoSize = true;
            this.rd_report.Location = new System.Drawing.Point(355, 12);
            this.rd_report.Name = "rd_report";
            this.rd_report.Size = new System.Drawing.Size(104, 18);
            this.rd_report.TabIndex = 10;
            this.rd_report.Text = "Specific Report";
            this.rd_report.UseVisualStyleBackColor = true;
            this.rd_report.CheckedChanged += new System.EventHandler(this.rd_report_CheckedChanged);
            // 
            // btnVerify
            // 
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.BackColor = System.Drawing.Color.White;
            this.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnVerify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnVerify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVerify.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerify.Location = new System.Drawing.Point(63, 247);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(814, 24);
            this.btnVerify.TabIndex = 7;
            this.btnVerify.Text = "SEARCH";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "MODE:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgData);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Location = new System.Drawing.Point(14, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 116);
            this.panel1.TabIndex = 5;
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Location = new System.Drawing.Point(2, 3);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(886, 79);
            this.dgData.TabIndex = 9;
            // 
            // btn_update
            // 
            this.btn_update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_update.BackColor = System.Drawing.Color.White;
            this.btn_update.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_update.Location = new System.Drawing.Point(2, 88);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(886, 24);
            this.btn_update.TabIndex = 8;
            this.btn_update.Text = "SAVE CHANGES";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_modifyNDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm_modifyNDT";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gb_loaderbg.ResumeLayout(false);
            this.pnl_report.ResumeLayout(false);
            this.pnl_report.PerformLayout();
            this.pnl_joint.ResumeLayout(false);
            this.pnl_joint.PerformLayout();
            this.pnl_loader.ResumeLayout(false);
            this.pnl_loader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd_joint;
        private System.Windows.Forms.RadioButton rd_Loader;
        private System.Windows.Forms.RadioButton rd_report;
        private System.Windows.Forms.Panel pnl_joint;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txt_Unit;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroTextBox txt_joint;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroTextBox txt_train;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox txt_line;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txt_service;
        private System.Windows.Forms.Panel pnl_report;
        private MetroFramework.Controls.MetroTextBox txt_report;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_ndt;
        private System.Windows.Forms.GroupBox gb_loaderbg;
        private System.Windows.Forms.Panel pnl_loader;
        private MetroFramework.Controls.MetroTextBox txtfilepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnl_bgloader;
        private System.Windows.Forms.Panel pnl_repbg;
        private System.Windows.Forms.Panel pnl_jointbg;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_ndttype_report;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}