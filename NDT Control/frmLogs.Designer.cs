namespace NDT_Control
{
    partial class frmLogs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_ISO = new System.Windows.Forms.Panel();
            this.txt_line = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txt_unit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txt_service = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txt_train = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txt_joint = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txt_reportnum = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txt_uploadedBy = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dt_uploaded = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmb_category = new MetroFramework.Controls.MetroComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_logs = new MetroFramework.Controls.MetroGrid();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btn_clearIso = new MetroFramework.Controls.MetroButton();
            this.btn_clearDate = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            this.pnl_ISO.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_clearDate);
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.pnl_ISO);
            this.groupBox1.Controls.Add(this.txt_reportnum);
            this.groupBox1.Controls.Add(this.metroLabel9);
            this.groupBox1.Controls.Add(this.txt_uploadedBy);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.dt_uploaded);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.cmb_category);
            this.groupBox1.Location = new System.Drawing.Point(22, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnl_ISO
            // 
            this.pnl_ISO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_ISO.Controls.Add(this.btn_clearIso);
            this.pnl_ISO.Controls.Add(this.txt_line);
            this.pnl_ISO.Controls.Add(this.metroLabel4);
            this.pnl_ISO.Controls.Add(this.txt_unit);
            this.pnl_ISO.Controls.Add(this.metroLabel8);
            this.pnl_ISO.Controls.Add(this.txt_service);
            this.pnl_ISO.Controls.Add(this.metroLabel7);
            this.pnl_ISO.Controls.Add(this.txt_train);
            this.pnl_ISO.Controls.Add(this.metroLabel6);
            this.pnl_ISO.Controls.Add(this.txt_joint);
            this.pnl_ISO.Controls.Add(this.metroLabel5);
            this.pnl_ISO.Enabled = false;
            this.pnl_ISO.Location = new System.Drawing.Point(42, 82);
            this.pnl_ISO.Name = "pnl_ISO";
            this.pnl_ISO.Size = new System.Drawing.Size(407, 28);
            this.pnl_ISO.TabIndex = 18;
            // 
            // txt_line
            // 
            // 
            // 
            // 
            this.txt_line.CustomButton.Image = null;
            this.txt_line.CustomButton.Location = new System.Drawing.Point(44, 1);
            this.txt_line.CustomButton.Name = "";
            this.txt_line.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_line.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_line.CustomButton.TabIndex = 1;
            this.txt_line.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_line.CustomButton.UseSelectable = true;
            this.txt_line.CustomButton.Visible = false;
            this.txt_line.Lines = new string[0];
            this.txt_line.Location = new System.Drawing.Point(194, 3);
            this.txt_line.MaxLength = 32767;
            this.txt_line.Name = "txt_line";
            this.txt_line.PasswordChar = '\0';
            this.txt_line.PromptText = "LINE";
            this.txt_line.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_line.SelectedText = "";
            this.txt_line.SelectionLength = 0;
            this.txt_line.SelectionStart = 0;
            this.txt_line.ShortcutsEnabled = true;
            this.txt_line.Size = new System.Drawing.Size(66, 23);
            this.txt_line.TabIndex = 9;
            this.txt_line.UseSelectable = true;
            this.txt_line.WaterMark = "LINE";
            this.txt_line.WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_line.WaterMarkFont = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(7, 4);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(65, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Isometric:";
            // 
            // txt_unit
            // 
            // 
            // 
            // 
            this.txt_unit.CustomButton.Image = null;
            this.txt_unit.CustomButton.Location = new System.Drawing.Point(13, 1);
            this.txt_unit.CustomButton.Name = "";
            this.txt_unit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_unit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_unit.CustomButton.TabIndex = 1;
            this.txt_unit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_unit.CustomButton.UseSelectable = true;
            this.txt_unit.CustomButton.Visible = false;
            this.txt_unit.Lines = new string[0];
            this.txt_unit.Location = new System.Drawing.Point(74, 3);
            this.txt_unit.MaxLength = 32767;
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.PasswordChar = '\0';
            this.txt_unit.PromptText = "UNIT";
            this.txt_unit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_unit.SelectedText = "";
            this.txt_unit.SelectionLength = 0;
            this.txt_unit.SelectionStart = 0;
            this.txt_unit.ShortcutsEnabled = true;
            this.txt_unit.Size = new System.Drawing.Size(35, 23);
            this.txt_unit.TabIndex = 7;
            this.txt_unit.UseSelectable = true;
            this.txt_unit.WaterMark = "UNIT";
            this.txt_unit.WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_unit.WaterMarkFont = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Enabled = false;
            this.metroLabel8.Location = new System.Drawing.Point(320, 3);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(15, 19);
            this.metroLabel8.TabIndex = 15;
            this.metroLabel8.Text = "-";
            // 
            // txt_service
            // 
            this.txt_service.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txt_service.CustomButton.Image = null;
            this.txt_service.CustomButton.Location = new System.Drawing.Point(32, 1);
            this.txt_service.CustomButton.Name = "";
            this.txt_service.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_service.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_service.CustomButton.TabIndex = 1;
            this.txt_service.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_service.CustomButton.UseSelectable = true;
            this.txt_service.CustomButton.Visible = false;
            this.txt_service.Lines = new string[0];
            this.txt_service.Location = new System.Drawing.Point(122, 3);
            this.txt_service.MaxLength = 32767;
            this.txt_service.Name = "txt_service";
            this.txt_service.PasswordChar = '\0';
            this.txt_service.PromptText = "SERVICE";
            this.txt_service.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_service.SelectedText = "";
            this.txt_service.SelectionLength = 0;
            this.txt_service.SelectionStart = 0;
            this.txt_service.ShortcutsEnabled = true;
            this.txt_service.Size = new System.Drawing.Size(54, 23);
            this.txt_service.TabIndex = 8;
            this.txt_service.UseSelectable = true;
            this.txt_service.WaterMark = "SERVICE";
            this.txt_service.WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_service.WaterMarkFont = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Enabled = false;
            this.metroLabel7.Location = new System.Drawing.Point(259, 5);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(15, 19);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "-";
            // 
            // txt_train
            // 
            // 
            // 
            // 
            this.txt_train.CustomButton.Image = null;
            this.txt_train.CustomButton.Location = new System.Drawing.Point(20, 1);
            this.txt_train.CustomButton.Name = "";
            this.txt_train.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_train.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_train.CustomButton.TabIndex = 1;
            this.txt_train.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_train.CustomButton.UseSelectable = true;
            this.txt_train.CustomButton.Visible = false;
            this.txt_train.Lines = new string[0];
            this.txt_train.Location = new System.Drawing.Point(277, 3);
            this.txt_train.MaxLength = 32767;
            this.txt_train.Name = "txt_train";
            this.txt_train.PasswordChar = '\0';
            this.txt_train.PromptText = "TRAIN";
            this.txt_train.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_train.SelectedText = "";
            this.txt_train.SelectionLength = 0;
            this.txt_train.SelectionStart = 0;
            this.txt_train.ShortcutsEnabled = true;
            this.txt_train.Size = new System.Drawing.Size(42, 23);
            this.txt_train.TabIndex = 10;
            this.txt_train.UseSelectable = true;
            this.txt_train.WaterMark = "TRAIN";
            this.txt_train.WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_train.WaterMarkFont = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Enabled = false;
            this.metroLabel6.Location = new System.Drawing.Point(106, 5);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(15, 19);
            this.metroLabel6.TabIndex = 13;
            this.metroLabel6.Text = "-";
            // 
            // txt_joint
            // 
            // 
            // 
            // 
            this.txt_joint.CustomButton.Image = null;
            this.txt_joint.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.txt_joint.CustomButton.Name = "";
            this.txt_joint.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_joint.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_joint.CustomButton.TabIndex = 1;
            this.txt_joint.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_joint.CustomButton.UseSelectable = true;
            this.txt_joint.CustomButton.Visible = false;
            this.txt_joint.Lines = new string[0];
            this.txt_joint.Location = new System.Drawing.Point(338, 3);
            this.txt_joint.MaxLength = 32767;
            this.txt_joint.Name = "txt_joint";
            this.txt_joint.PasswordChar = '\0';
            this.txt_joint.PromptText = "JOINT";
            this.txt_joint.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_joint.SelectedText = "";
            this.txt_joint.SelectionLength = 0;
            this.txt_joint.SelectionStart = 0;
            this.txt_joint.ShortcutsEnabled = true;
            this.txt_joint.Size = new System.Drawing.Size(45, 23);
            this.txt_joint.TabIndex = 11;
            this.txt_joint.UseSelectable = true;
            this.txt_joint.WaterMark = "JOINT";
            this.txt_joint.WaterMarkColor = System.Drawing.Color.Gray;
            this.txt_joint.WaterMarkFont = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Enabled = false;
            this.metroLabel5.Location = new System.Drawing.Point(177, 5);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(15, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "-";
            // 
            // txt_reportnum
            // 
            this.txt_reportnum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txt_reportnum.CustomButton.Image = null;
            this.txt_reportnum.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txt_reportnum.CustomButton.Name = "";
            this.txt_reportnum.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_reportnum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_reportnum.CustomButton.TabIndex = 1;
            this.txt_reportnum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_reportnum.CustomButton.UseSelectable = true;
            this.txt_reportnum.CustomButton.Visible = false;
            this.txt_reportnum.Enabled = false;
            this.txt_reportnum.Lines = new string[0];
            this.txt_reportnum.Location = new System.Drawing.Point(116, 54);
            this.txt_reportnum.MaxLength = 32767;
            this.txt_reportnum.Name = "txt_reportnum";
            this.txt_reportnum.PasswordChar = '\0';
            this.txt_reportnum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_reportnum.SelectedText = "";
            this.txt_reportnum.SelectionLength = 0;
            this.txt_reportnum.SelectionStart = 0;
            this.txt_reportnum.ShortcutsEnabled = true;
            this.txt_reportnum.Size = new System.Drawing.Size(222, 23);
            this.txt_reportnum.TabIndex = 17;
            this.txt_reportnum.UseSelectable = true;
            this.txt_reportnum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_reportnum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txt_reportnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.metroTextBox7_KeyPress);
            // 
            // metroLabel9
            // 
            this.metroLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(12, 54);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(105, 19);
            this.metroLabel9.TabIndex = 16;
            this.metroLabel9.Text = "Report Number:";
            // 
            // txt_uploadedBy
            // 
            this.txt_uploadedBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txt_uploadedBy.CustomButton.Image = null;
            this.txt_uploadedBy.CustomButton.Location = new System.Drawing.Point(184, 1);
            this.txt_uploadedBy.CustomButton.Name = "";
            this.txt_uploadedBy.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_uploadedBy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_uploadedBy.CustomButton.TabIndex = 1;
            this.txt_uploadedBy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_uploadedBy.CustomButton.UseSelectable = true;
            this.txt_uploadedBy.CustomButton.Visible = false;
            this.txt_uploadedBy.Enabled = false;
            this.txt_uploadedBy.Lines = new string[0];
            this.txt_uploadedBy.Location = new System.Drawing.Point(545, 86);
            this.txt_uploadedBy.MaxLength = 32767;
            this.txt_uploadedBy.Name = "txt_uploadedBy";
            this.txt_uploadedBy.PasswordChar = '\0';
            this.txt_uploadedBy.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_uploadedBy.SelectedText = "";
            this.txt_uploadedBy.SelectionLength = 0;
            this.txt_uploadedBy.SelectionStart = 0;
            this.txt_uploadedBy.ShortcutsEnabled = true;
            this.txt_uploadedBy.Size = new System.Drawing.Size(206, 23);
            this.txt_uploadedBy.TabIndex = 5;
            this.txt_uploadedBy.UseSelectable = true;
            this.txt_uploadedBy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_uploadedBy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(455, 89);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(88, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Uploaded By:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(441, 54);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Date Uploaded:";
            // 
            // dt_uploaded
            // 
            this.dt_uploaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_uploaded.Enabled = false;
            this.dt_uploaded.Location = new System.Drawing.Point(545, 51);
            this.dt_uploaded.MinimumSize = new System.Drawing.Size(0, 29);
            this.dt_uploaded.Name = "dt_uploaded";
            this.dt_uploaded.Size = new System.Drawing.Size(206, 29);
            this.dt_uploaded.TabIndex = 2;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(47, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Category:";
            // 
            // cmb_category
            // 
            this.cmb_category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.ItemHeight = 23;
            this.cmb_category.Items.AddRange(new object[] {
            "DATE UPLOADED",
            "UPLOADED BY",
            "ISOMETRIC",
            "REPORT NUMBER"});
            this.cmb_category.Location = new System.Drawing.Point(116, 19);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(635, 29);
            this.cmb_category.TabIndex = 0;
            this.cmb_category.UseSelectable = true;
            this.cmb_category.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_logs);
            this.panel1.Location = new System.Drawing.Point(22, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 518);
            this.panel1.TabIndex = 1;
            // 
            // dgv_logs
            // 
            this.dgv_logs.AllowUserToAddRows = false;
            this.dgv_logs.AllowUserToDeleteRows = false;
            this.dgv_logs.AllowUserToResizeRows = false;
            this.dgv_logs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_logs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_logs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_logs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_logs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_logs.EnableHeadersVisualStyles = false;
            this.dgv_logs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv_logs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_logs.Location = new System.Drawing.Point(0, 0);
            this.dgv_logs.Name = "dgv_logs";
            this.dgv_logs.ReadOnly = true;
            this.dgv_logs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_logs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_logs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_logs.Size = new System.Drawing.Size(984, 518);
            this.dgv_logs.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(897, 19);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 89);
            this.metroButton1.TabIndex = 19;
            this.metroButton1.Text = "SEARCH";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btn_clearIso
            // 
            this.btn_clearIso.Location = new System.Drawing.Point(389, 3);
            this.btn_clearIso.Name = "btn_clearIso";
            this.btn_clearIso.Size = new System.Drawing.Size(14, 23);
            this.btn_clearIso.TabIndex = 20;
            this.btn_clearIso.Text = "C";
            this.btn_clearIso.UseSelectable = true;
            this.btn_clearIso.Click += new System.EventHandler(this.btn_clearIso_Click);
            // 
            // btn_clearDate
            // 
            this.btn_clearDate.Location = new System.Drawing.Point(753, 55);
            this.btn_clearDate.Name = "btn_clearDate";
            this.btn_clearDate.Size = new System.Drawing.Size(14, 23);
            this.btn_clearDate.TabIndex = 21;
            this.btn_clearDate.Text = "C";
            this.btn_clearDate.UseSelectable = true;
            this.btn_clearDate.Click += new System.EventHandler(this.btn_clearDate_Click);
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLogs";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "6";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_ISO.ResumeLayout(false);
            this.pnl_ISO.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroGrid dgv_logs;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txt_joint;
        private MetroFramework.Controls.MetroTextBox txt_train;
        private MetroFramework.Controls.MetroTextBox txt_line;
        private MetroFramework.Controls.MetroTextBox txt_service;
        private MetroFramework.Controls.MetroTextBox txt_unit;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txt_uploadedBy;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dt_uploaded;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmb_category;
        private MetroFramework.Controls.MetroTextBox txt_reportnum;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.Panel pnl_ISO;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btn_clearIso;
        private MetroFramework.Controls.MetroButton btn_clearDate;
    }
}