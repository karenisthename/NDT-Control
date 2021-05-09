namespace NDT_Control
{
    partial class frm_Queries
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rchtxtbx_desc = new System.Windows.Forms.RichTextBox();
            this.btn_sampleResult = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpbx_NDTtype = new System.Windows.Forms.GroupBox();
            this.btn_ndtTypeFilter = new System.Windows.Forms.Button();
            this.cmb_NDTType = new System.Windows.Forms.ComboBox();
            this.grpbx_Dates = new System.Windows.Forms.GroupBox();
            this.btn_datesAddFilter = new System.Windows.Forms.Button();
            this.cmb_DateType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpbx_HTP = new System.Windows.Forms.GroupBox();
            this.grpbx_others = new System.Windows.Forms.GroupBox();
            this.chk_TPAll = new System.Windows.Forms.CheckBox();
            this.cmb_tp_unit = new System.Windows.Forms.ComboBox();
            this.cmb_htp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbtn_tpOthers = new MetroFramework.Controls.MetroRadioButton();
            this.rd_allTP = new MetroFramework.Controls.MetroRadioButton();
            this.btn_TPAddFilter = new System.Windows.Forms.Button();
            this.grpbx_units = new System.Windows.Forms.GroupBox();
            this.btn_addFilter = new System.Windows.Forms.Button();
            this.chk_01 = new System.Windows.Forms.CheckBox();
            this.chk_05 = new System.Windows.Forms.CheckBox();
            this.chk_12 = new System.Windows.Forms.CheckBox();
            this.chk_22 = new System.Windows.Forms.CheckBox();
            this.chk_02 = new System.Windows.Forms.CheckBox();
            this.chk_06 = new System.Windows.Forms.CheckBox();
            this.chk_13 = new System.Windows.Forms.CheckBox();
            this.chk_allUnits = new System.Windows.Forms.CheckBox();
            this.chk_34_2 = new System.Windows.Forms.CheckBox();
            this.chk_21 = new System.Windows.Forms.CheckBox();
            this.chk_34_1 = new System.Windows.Forms.CheckBox();
            this.chk_04 = new System.Windows.Forms.CheckBox();
            this.chk_14 = new System.Windows.Forms.CheckBox();
            this.chk_25 = new System.Windows.Forms.CheckBox();
            this.chk_11 = new System.Windows.Forms.CheckBox();
            this.chk_23 = new System.Windows.Forms.CheckBox();
            this.chk_74 = new System.Windows.Forms.CheckBox();
            this.chk_03 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstbx_filters = new System.Windows.Forms.ListBox();
            this.btn_removeFilter = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpbx_NDTtype.SuspendLayout();
            this.grpbx_Dates.SuspendLayout();
            this.grpbx_HTP.SuspendLayout();
            this.grpbx_others.SuspendLayout();
            this.grpbx_units.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(10, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 766);
            this.panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rchtxtbx_desc);
            this.groupBox3.Controls.Add(this.btn_sampleResult);
            this.groupBox3.Location = new System.Drawing.Point(7, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(508, 209);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QUERY DESCRIPTION";
            // 
            // rchtxtbx_desc
            // 
            this.rchtxtbx_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchtxtbx_desc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rchtxtbx_desc.Location = new System.Drawing.Point(7, 19);
            this.rchtxtbx_desc.Name = "rchtxtbx_desc";
            this.rchtxtbx_desc.ReadOnly = true;
            this.rchtxtbx_desc.Size = new System.Drawing.Size(490, 147);
            this.rchtxtbx_desc.TabIndex = 9;
            this.rchtxtbx_desc.Text = "";
            // 
            // btn_sampleResult
            // 
            this.btn_sampleResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_sampleResult.BackColor = System.Drawing.Color.White;
            this.btn_sampleResult.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_sampleResult.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_sampleResult.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_sampleResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sampleResult.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sampleResult.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_sampleResult.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_sampleResult.Location = new System.Drawing.Point(6, 175);
            this.btn_sampleResult.Name = "btn_sampleResult";
            this.btn_sampleResult.Size = new System.Drawing.Size(491, 25);
            this.btn_sampleResult.TabIndex = 11;
            this.btn_sampleResult.Text = "SAMPLE RESULT";
            this.btn_sampleResult.UseVisualStyleBackColor = false;
            this.btn_sampleResult.Click += new System.EventHandler(this.btn_sampleResult_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 9F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(508, 22);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpbx_NDTtype);
            this.groupBox2.Controls.Add(this.grpbx_Dates);
            this.groupBox2.Controls.Add(this.grpbx_HTP);
            this.groupBox2.Controls.Add(this.grpbx_units);
            this.groupBox2.Location = new System.Drawing.Point(7, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 453);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AVAILABLE FILTERS:";
            // 
            // grpbx_NDTtype
            // 
            this.grpbx_NDTtype.Controls.Add(this.btn_ndtTypeFilter);
            this.grpbx_NDTtype.Controls.Add(this.cmb_NDTType);
            this.grpbx_NDTtype.Enabled = false;
            this.grpbx_NDTtype.Location = new System.Drawing.Point(3, 388);
            this.grpbx_NDTtype.Name = "grpbx_NDTtype";
            this.grpbx_NDTtype.Size = new System.Drawing.Size(240, 49);
            this.grpbx_NDTtype.TabIndex = 31;
            this.grpbx_NDTtype.TabStop = false;
            this.grpbx_NDTtype.Text = "NDT TYPE";
            this.grpbx_NDTtype.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // btn_ndtTypeFilter
            // 
            this.btn_ndtTypeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ndtTypeFilter.BackColor = System.Drawing.Color.White;
            this.btn_ndtTypeFilter.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_ndtTypeFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_ndtTypeFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ndtTypeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ndtTypeFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ndtTypeFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_ndtTypeFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ndtTypeFilter.Location = new System.Drawing.Point(216, 15);
            this.btn_ndtTypeFilter.Name = "btn_ndtTypeFilter";
            this.btn_ndtTypeFilter.Size = new System.Drawing.Size(18, 26);
            this.btn_ndtTypeFilter.TabIndex = 32;
            this.btn_ndtTypeFilter.Text = ">";
            this.btn_ndtTypeFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ndtTypeFilter.UseVisualStyleBackColor = false;
            this.btn_ndtTypeFilter.Click += new System.EventHandler(this.btn_ndtTypeFilter_Click);
            // 
            // cmb_NDTType
            // 
            this.cmb_NDTType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_NDTType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_NDTType.FormattingEnabled = true;
            this.cmb_NDTType.Items.AddRange(new object[] {
            "RT",
            "PWHT",
            "HTA",
            "HTB",
            "PMI",
            "PT",
            "PMI",
            "FT"});
            this.cmb_NDTType.Location = new System.Drawing.Point(6, 17);
            this.cmb_NDTType.Name = "cmb_NDTType";
            this.cmb_NDTType.Size = new System.Drawing.Size(206, 21);
            this.cmb_NDTType.TabIndex = 2;
            // 
            // grpbx_Dates
            // 
            this.grpbx_Dates.Controls.Add(this.btn_datesAddFilter);
            this.grpbx_Dates.Controls.Add(this.cmb_DateType);
            this.grpbx_Dates.Controls.Add(this.label4);
            this.grpbx_Dates.Controls.Add(this.dtp_from);
            this.grpbx_Dates.Controls.Add(this.dtp_to);
            this.grpbx_Dates.Controls.Add(this.label5);
            this.grpbx_Dates.Controls.Add(this.label7);
            this.grpbx_Dates.Enabled = false;
            this.grpbx_Dates.Location = new System.Drawing.Point(6, 279);
            this.grpbx_Dates.Name = "grpbx_Dates";
            this.grpbx_Dates.Size = new System.Drawing.Size(237, 104);
            this.grpbx_Dates.TabIndex = 31;
            this.grpbx_Dates.TabStop = false;
            this.grpbx_Dates.Text = "DATES";
            // 
            // btn_datesAddFilter
            // 
            this.btn_datesAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_datesAddFilter.BackColor = System.Drawing.Color.White;
            this.btn_datesAddFilter.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_datesAddFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_datesAddFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_datesAddFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_datesAddFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_datesAddFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_datesAddFilter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_datesAddFilter.Location = new System.Drawing.Point(213, 21);
            this.btn_datesAddFilter.Name = "btn_datesAddFilter";
            this.btn_datesAddFilter.Size = new System.Drawing.Size(18, 74);
            this.btn_datesAddFilter.TabIndex = 30;
            this.btn_datesAddFilter.Text = ">";
            this.btn_datesAddFilter.UseVisualStyleBackColor = false;
            this.btn_datesAddFilter.Click += new System.EventHandler(this.btn_datesAddFilter_Click);
            // 
            // cmb_DateType
            // 
            this.cmb_DateType.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_DateType.FormattingEnabled = true;
            this.cmb_DateType.Items.AddRange(new object[] {
            "TEST PACK TESTED",
            "RT",
            "PWHT",
            "HTA",
            "HTB",
            "PMI",
            "PT",
            "FT",
            "DWR"});
            this.cmb_DateType.Location = new System.Drawing.Point(40, 20);
            this.cmb_DateType.Name = "cmb_DateType";
            this.cmb_DateType.Size = new System.Drawing.Size(169, 21);
            this.cmb_DateType.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "FROM:";
            // 
            // dtp_from
            // 
            this.dtp_from.CalendarFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.CustomFormat = "";
            this.dtp_from.Location = new System.Drawing.Point(40, 47);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(168, 20);
            this.dtp_from.TabIndex = 2;
            // 
            // dtp_to
            // 
            this.dtp_to.CalendarFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Location = new System.Drawing.Point(40, 73);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(168, 20);
            this.dtp_to.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "TO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "TYPE:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // grpbx_HTP
            // 
            this.grpbx_HTP.Controls.Add(this.grpbx_others);
            this.grpbx_HTP.Controls.Add(this.rdbtn_tpOthers);
            this.grpbx_HTP.Controls.Add(this.rd_allTP);
            this.grpbx_HTP.Controls.Add(this.btn_TPAddFilter);
            this.grpbx_HTP.Enabled = false;
            this.grpbx_HTP.Location = new System.Drawing.Point(6, 152);
            this.grpbx_HTP.Name = "grpbx_HTP";
            this.grpbx_HTP.Size = new System.Drawing.Size(237, 124);
            this.grpbx_HTP.TabIndex = 30;
            this.grpbx_HTP.TabStop = false;
            this.grpbx_HTP.Text = "PRESSURE TEST";
            // 
            // grpbx_others
            // 
            this.grpbx_others.Controls.Add(this.chk_TPAll);
            this.grpbx_others.Controls.Add(this.cmb_tp_unit);
            this.grpbx_others.Controls.Add(this.cmb_htp);
            this.grpbx_others.Controls.Add(this.label2);
            this.grpbx_others.Enabled = false;
            this.grpbx_others.Location = new System.Drawing.Point(5, 38);
            this.grpbx_others.Name = "grpbx_others";
            this.grpbx_others.Size = new System.Drawing.Size(230, 65);
            this.grpbx_others.TabIndex = 37;
            this.grpbx_others.TabStop = false;
            this.grpbx_others.Text = "OTHERS";
            // 
            // chk_TPAll
            // 
            this.chk_TPAll.AutoSize = true;
            this.chk_TPAll.Location = new System.Drawing.Point(160, 13);
            this.chk_TPAll.Name = "chk_TPAll";
            this.chk_TPAll.Size = new System.Drawing.Size(45, 17);
            this.chk_TPAll.TabIndex = 29;
            this.chk_TPAll.Text = "ALL";
            this.chk_TPAll.UseVisualStyleBackColor = true;
            this.chk_TPAll.CheckedChanged += new System.EventHandler(this.chk_TPAll_CheckedChanged);
            // 
            // cmb_tp_unit
            // 
            this.cmb_tp_unit.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_tp_unit.FormattingEnabled = true;
            this.cmb_tp_unit.Location = new System.Drawing.Point(108, 11);
            this.cmb_tp_unit.Name = "cmb_tp_unit";
            this.cmb_tp_unit.Size = new System.Drawing.Size(43, 21);
            this.cmb_tp_unit.TabIndex = 33;
            this.cmb_tp_unit.SelectedIndexChanged += new System.EventHandler(this.cmb_tp_unit_SelectedIndexChanged);
            // 
            // cmb_htp
            // 
            this.cmb_htp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_htp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_htp.FormattingEnabled = true;
            this.cmb_htp.Location = new System.Drawing.Point(11, 36);
            this.cmb_htp.Name = "cmb_htp";
            this.cmb_htp.Size = new System.Drawing.Size(201, 21);
            this.cmb_htp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "TP UNIT(Optional):";
            // 
            // rdbtn_tpOthers
            // 
            this.rdbtn_tpOthers.AutoSize = true;
            this.rdbtn_tpOthers.Location = new System.Drawing.Point(126, 19);
            this.rdbtn_tpOthers.Name = "rdbtn_tpOthers";
            this.rdbtn_tpOthers.Size = new System.Drawing.Size(67, 15);
            this.rdbtn_tpOthers.Style = MetroFramework.MetroColorStyle.Lime;
            this.rdbtn_tpOthers.TabIndex = 36;
            this.rdbtn_tpOthers.Text = "OTHERS";
            this.rdbtn_tpOthers.UseSelectable = true;
            this.rdbtn_tpOthers.CheckedChanged += new System.EventHandler(this.metroRadioButton5_CheckedChanged);
            // 
            // rd_allTP
            // 
            this.rd_allTP.AutoSize = true;
            this.rd_allTP.Checked = true;
            this.rd_allTP.Location = new System.Drawing.Point(12, 19);
            this.rd_allTP.Name = "rd_allTP";
            this.rd_allTP.Size = new System.Drawing.Size(105, 15);
            this.rd_allTP.Style = MetroFramework.MetroColorStyle.Lime;
            this.rd_allTP.TabIndex = 35;
            this.rd_allTP.TabStop = true;
            this.rd_allTP.Text = "ALL TEST PACK";
            this.rd_allTP.UseSelectable = true;
            // 
            // btn_TPAddFilter
            // 
            this.btn_TPAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_TPAddFilter.BackColor = System.Drawing.Color.White;
            this.btn_TPAddFilter.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_TPAddFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_TPAddFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TPAddFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TPAddFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TPAddFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_TPAddFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TPAddFilter.Location = new System.Drawing.Point(213, 12);
            this.btn_TPAddFilter.Name = "btn_TPAddFilter";
            this.btn_TPAddFilter.Size = new System.Drawing.Size(18, 26);
            this.btn_TPAddFilter.TabIndex = 30;
            this.btn_TPAddFilter.Text = ">";
            this.btn_TPAddFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_TPAddFilter.UseVisualStyleBackColor = false;
            this.btn_TPAddFilter.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // grpbx_units
            // 
            this.grpbx_units.Controls.Add(this.btn_addFilter);
            this.grpbx_units.Controls.Add(this.chk_01);
            this.grpbx_units.Controls.Add(this.chk_05);
            this.grpbx_units.Controls.Add(this.chk_12);
            this.grpbx_units.Controls.Add(this.chk_22);
            this.grpbx_units.Controls.Add(this.chk_02);
            this.grpbx_units.Controls.Add(this.chk_06);
            this.grpbx_units.Controls.Add(this.chk_13);
            this.grpbx_units.Controls.Add(this.chk_allUnits);
            this.grpbx_units.Controls.Add(this.chk_34_2);
            this.grpbx_units.Controls.Add(this.chk_21);
            this.grpbx_units.Controls.Add(this.chk_34_1);
            this.grpbx_units.Controls.Add(this.chk_04);
            this.grpbx_units.Controls.Add(this.chk_14);
            this.grpbx_units.Controls.Add(this.chk_25);
            this.grpbx_units.Controls.Add(this.chk_11);
            this.grpbx_units.Controls.Add(this.chk_23);
            this.grpbx_units.Controls.Add(this.chk_74);
            this.grpbx_units.Controls.Add(this.chk_03);
            this.grpbx_units.Location = new System.Drawing.Point(6, 18);
            this.grpbx_units.Name = "grpbx_units";
            this.grpbx_units.Size = new System.Drawing.Size(235, 133);
            this.grpbx_units.TabIndex = 29;
            this.grpbx_units.TabStop = false;
            this.grpbx_units.Text = "UNITS";
            // 
            // btn_addFilter
            // 
            this.btn_addFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_addFilter.BackColor = System.Drawing.Color.White;
            this.btn_addFilter.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_addFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_addFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_addFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_addFilter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_addFilter.Location = new System.Drawing.Point(211, 100);
            this.btn_addFilter.Name = "btn_addFilter";
            this.btn_addFilter.Size = new System.Drawing.Size(18, 26);
            this.btn_addFilter.TabIndex = 28;
            this.btn_addFilter.Text = ">";
            this.btn_addFilter.UseVisualStyleBackColor = false;
            this.btn_addFilter.Click += new System.EventHandler(this.btn_addFilter_Click);
            // 
            // chk_01
            // 
            this.chk_01.AutoSize = true;
            this.chk_01.Location = new System.Drawing.Point(6, 19);
            this.chk_01.Name = "chk_01";
            this.chk_01.Size = new System.Drawing.Size(38, 17);
            this.chk_01.TabIndex = 0;
            this.chk_01.Text = "01";
            this.chk_01.UseVisualStyleBackColor = true;
            this.chk_01.CheckedChanged += new System.EventHandler(this.chk_01_CheckedChanged);
            // 
            // chk_05
            // 
            this.chk_05.AutoSize = true;
            this.chk_05.Location = new System.Drawing.Point(6, 111);
            this.chk_05.Name = "chk_05";
            this.chk_05.Size = new System.Drawing.Size(38, 17);
            this.chk_05.TabIndex = 20;
            this.chk_05.Text = "05";
            this.chk_05.UseVisualStyleBackColor = true;
            this.chk_05.CheckedChanged += new System.EventHandler(this.chk_05_CheckedChanged);
            // 
            // chk_12
            // 
            this.chk_12.AutoSize = true;
            this.chk_12.Location = new System.Drawing.Point(51, 42);
            this.chk_12.Name = "chk_12";
            this.chk_12.Size = new System.Drawing.Size(38, 17);
            this.chk_12.TabIndex = 8;
            this.chk_12.Text = "12";
            this.chk_12.UseVisualStyleBackColor = true;
            this.chk_12.CheckedChanged += new System.EventHandler(this.chk_12_CheckedChanged);
            // 
            // chk_22
            // 
            this.chk_22.AutoSize = true;
            this.chk_22.Location = new System.Drawing.Point(99, 42);
            this.chk_22.Name = "chk_22";
            this.chk_22.Size = new System.Drawing.Size(38, 17);
            this.chk_22.TabIndex = 9;
            this.chk_22.Text = "22";
            this.chk_22.UseVisualStyleBackColor = true;
            this.chk_22.CheckedChanged += new System.EventHandler(this.chk_22_CheckedChanged);
            // 
            // chk_02
            // 
            this.chk_02.AutoSize = true;
            this.chk_02.Location = new System.Drawing.Point(51, 19);
            this.chk_02.Name = "chk_02";
            this.chk_02.Size = new System.Drawing.Size(38, 17);
            this.chk_02.TabIndex = 1;
            this.chk_02.Text = "02";
            this.chk_02.UseVisualStyleBackColor = true;
            this.chk_02.CheckedChanged += new System.EventHandler(this.chk_02_CheckedChanged);
            // 
            // chk_06
            // 
            this.chk_06.AutoSize = true;
            this.chk_06.Location = new System.Drawing.Point(51, 65);
            this.chk_06.Name = "chk_06";
            this.chk_06.Size = new System.Drawing.Size(38, 17);
            this.chk_06.TabIndex = 21;
            this.chk_06.Text = "06";
            this.chk_06.UseVisualStyleBackColor = true;
            this.chk_06.CheckedChanged += new System.EventHandler(this.chk_06_CheckedChanged);
            // 
            // chk_13
            // 
            this.chk_13.AutoSize = true;
            this.chk_13.Location = new System.Drawing.Point(51, 88);
            this.chk_13.Name = "chk_13";
            this.chk_13.Size = new System.Drawing.Size(38, 17);
            this.chk_13.TabIndex = 22;
            this.chk_13.Text = "13";
            this.chk_13.UseVisualStyleBackColor = true;
            this.chk_13.CheckedChanged += new System.EventHandler(this.chk_13_CheckedChanged);
            // 
            // chk_allUnits
            // 
            this.chk_allUnits.AutoSize = true;
            this.chk_allUnits.Location = new System.Drawing.Point(143, 63);
            this.chk_allUnits.Name = "chk_allUnits";
            this.chk_allUnits.Size = new System.Drawing.Size(81, 17);
            this.chk_allUnits.TabIndex = 23;
            this.chk_allUnits.Text = "ALL UNITS";
            this.chk_allUnits.UseVisualStyleBackColor = true;
            this.chk_allUnits.CheckedChanged += new System.EventHandler(this.chk_allUnits_CheckedChanged);
            // 
            // chk_34_2
            // 
            this.chk_34_2.AutoSize = true;
            this.chk_34_2.Location = new System.Drawing.Point(143, 19);
            this.chk_34_2.Name = "chk_34_2";
            this.chk_34_2.Size = new System.Drawing.Size(60, 17);
            this.chk_34_2.TabIndex = 15;
            this.chk_34_2.Text = "34 - A2";
            this.chk_34_2.UseVisualStyleBackColor = true;
            this.chk_34_2.CheckedChanged += new System.EventHandler(this.chk_34_2_CheckedChanged);
            // 
            // chk_21
            // 
            this.chk_21.AutoSize = true;
            this.chk_21.Location = new System.Drawing.Point(99, 19);
            this.chk_21.Name = "chk_21";
            this.chk_21.Size = new System.Drawing.Size(38, 17);
            this.chk_21.TabIndex = 7;
            this.chk_21.Text = "21";
            this.chk_21.UseVisualStyleBackColor = true;
            this.chk_21.CheckedChanged += new System.EventHandler(this.chk_21_CheckedChanged);
            // 
            // chk_34_1
            // 
            this.chk_34_1.AutoSize = true;
            this.chk_34_1.Location = new System.Drawing.Point(100, 109);
            this.chk_34_1.Name = "chk_34_1";
            this.chk_34_1.Size = new System.Drawing.Size(60, 17);
            this.chk_34_1.TabIndex = 14;
            this.chk_34_1.Text = "34 - A1";
            this.chk_34_1.UseVisualStyleBackColor = true;
            this.chk_34_1.CheckedChanged += new System.EventHandler(this.chk_34_1_CheckedChanged);
            // 
            // chk_04
            // 
            this.chk_04.AutoSize = true;
            this.chk_04.Location = new System.Drawing.Point(6, 88);
            this.chk_04.Name = "chk_04";
            this.chk_04.Size = new System.Drawing.Size(38, 17);
            this.chk_04.TabIndex = 19;
            this.chk_04.Text = "04";
            this.chk_04.UseVisualStyleBackColor = true;
            this.chk_04.CheckedChanged += new System.EventHandler(this.chk_04_CheckedChanged);
            // 
            // chk_14
            // 
            this.chk_14.AutoSize = true;
            this.chk_14.Location = new System.Drawing.Point(51, 111);
            this.chk_14.Name = "chk_14";
            this.chk_14.Size = new System.Drawing.Size(38, 17);
            this.chk_14.TabIndex = 10;
            this.chk_14.Text = "14";
            this.chk_14.UseVisualStyleBackColor = true;
            this.chk_14.CheckedChanged += new System.EventHandler(this.chk_14_CheckedChanged);
            // 
            // chk_25
            // 
            this.chk_25.AutoSize = true;
            this.chk_25.Location = new System.Drawing.Point(99, 88);
            this.chk_25.Name = "chk_25";
            this.chk_25.Size = new System.Drawing.Size(38, 17);
            this.chk_25.TabIndex = 13;
            this.chk_25.Text = "25";
            this.chk_25.UseVisualStyleBackColor = true;
            this.chk_25.CheckedChanged += new System.EventHandler(this.chk_25_CheckedChanged);
            // 
            // chk_11
            // 
            this.chk_11.AutoSize = true;
            this.chk_11.Location = new System.Drawing.Point(6, 42);
            this.chk_11.Name = "chk_11";
            this.chk_11.Size = new System.Drawing.Size(38, 17);
            this.chk_11.TabIndex = 6;
            this.chk_11.Text = "11";
            this.chk_11.UseVisualStyleBackColor = true;
            this.chk_11.CheckedChanged += new System.EventHandler(this.chk_11_CheckedChanged);
            // 
            // chk_23
            // 
            this.chk_23.AutoSize = true;
            this.chk_23.Location = new System.Drawing.Point(99, 65);
            this.chk_23.Name = "chk_23";
            this.chk_23.Size = new System.Drawing.Size(38, 17);
            this.chk_23.TabIndex = 12;
            this.chk_23.Text = "23";
            this.chk_23.UseVisualStyleBackColor = true;
            this.chk_23.CheckedChanged += new System.EventHandler(this.chk_23_CheckedChanged);
            // 
            // chk_74
            // 
            this.chk_74.AutoSize = true;
            this.chk_74.Location = new System.Drawing.Point(143, 41);
            this.chk_74.Name = "chk_74";
            this.chk_74.Size = new System.Drawing.Size(38, 17);
            this.chk_74.TabIndex = 11;
            this.chk_74.Text = "74";
            this.chk_74.UseVisualStyleBackColor = true;
            this.chk_74.CheckedChanged += new System.EventHandler(this.chk_74_CheckedChanged);
            // 
            // chk_03
            // 
            this.chk_03.AutoSize = true;
            this.chk_03.Location = new System.Drawing.Point(6, 65);
            this.chk_03.Name = "chk_03";
            this.chk_03.Size = new System.Drawing.Size(38, 17);
            this.chk_03.TabIndex = 18;
            this.chk_03.Text = "03";
            this.chk_03.UseVisualStyleBackColor = true;
            this.chk_03.CheckedChanged += new System.EventHandler(this.chk_03_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstbx_filters);
            this.groupBox1.Controls.Add(this.btn_removeFilter);
            this.groupBox1.Location = new System.Drawing.Point(263, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 425);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECTED FILTERS:";
            // 
            // lstbx_filters
            // 
            this.lstbx_filters.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_filters.FormattingEnabled = true;
            this.lstbx_filters.Location = new System.Drawing.Point(6, 18);
            this.lstbx_filters.Name = "lstbx_filters";
            this.lstbx_filters.Size = new System.Drawing.Size(238, 368);
            this.lstbx_filters.TabIndex = 0;
            this.lstbx_filters.SelectedIndexChanged += new System.EventHandler(this.lstbx_filters_SelectedIndexChanged);
            // 
            // btn_removeFilter
            // 
            this.btn_removeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_removeFilter.BackColor = System.Drawing.Color.White;
            this.btn_removeFilter.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_removeFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_removeFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_removeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removeFilter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_removeFilter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_removeFilter.Location = new System.Drawing.Point(135, 393);
            this.btn_removeFilter.Name = "btn_removeFilter";
            this.btn_removeFilter.Size = new System.Drawing.Size(109, 24);
            this.btn_removeFilter.TabIndex = 27;
            this.btn_removeFilter.Text = "REMOVE FILTER";
            this.btn_removeFilter.UseVisualStyleBackColor = false;
            this.btn_removeFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(10, 735);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(505, 24);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "EXTRACT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHOOSE QUERY:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frm_Queries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(542, 802);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Queries";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Load += new System.EventHandler(this.frm_Queries_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpbx_NDTtype.ResumeLayout(false);
            this.grpbx_Dates.ResumeLayout(false);
            this.grpbx_Dates.PerformLayout();
            this.grpbx_HTP.ResumeLayout(false);
            this.grpbx_HTP.PerformLayout();
            this.grpbx_others.ResumeLayout(false);
            this.grpbx_others.PerformLayout();
            this.grpbx_units.ResumeLayout(false);
            this.grpbx_units.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chk_01;
        private System.Windows.Forms.CheckBox chk_03;
        private System.Windows.Forms.CheckBox chk_11;
        private System.Windows.Forms.CheckBox chk_04;
        private System.Windows.Forms.CheckBox chk_21;
        private System.Windows.Forms.CheckBox chk_13;
        private System.Windows.Forms.CheckBox chk_02;
        private System.Windows.Forms.CheckBox chk_12;
        private System.Windows.Forms.CheckBox chk_05;
        private System.Windows.Forms.CheckBox chk_22;
        private System.Windows.Forms.CheckBox chk_06;
        private System.Windows.Forms.CheckBox chk_34_2;
        private System.Windows.Forms.CheckBox chk_34_1;
        private System.Windows.Forms.CheckBox chk_25;
        private System.Windows.Forms.CheckBox chk_23;
        private System.Windows.Forms.CheckBox chk_74;
        private System.Windows.Forms.CheckBox chk_14;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchtxtbx_desc;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_sampleResult;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_allUnits;
        private System.Windows.Forms.ComboBox cmb_htp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstbx_filters;
        private System.Windows.Forms.Button btn_removeFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_DateType;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpbx_HTP;
        private System.Windows.Forms.GroupBox grpbx_units;
        private System.Windows.Forms.GroupBox grpbx_NDTtype;
        private System.Windows.Forms.ComboBox cmb_NDTType;
        private System.Windows.Forms.GroupBox grpbx_Dates;
        private System.Windows.Forms.Button btn_addFilter;
        private System.Windows.Forms.Button btn_datesAddFilter;
        private System.Windows.Forms.Button btn_TPAddFilter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_ndtTypeFilter;
        private System.Windows.Forms.ComboBox cmb_tp_unit;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroRadioButton rdbtn_tpOthers;
        private MetroFramework.Controls.MetroRadioButton rd_allTP;
        private System.Windows.Forms.GroupBox grpbx_others;
        private System.Windows.Forms.CheckBox chk_TPAll;

    }
}