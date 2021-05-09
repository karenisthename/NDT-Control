namespace NDT_Control
{
    partial class frm_uploadData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl_lotno = new System.Windows.Forms.Panel();
            this.btn_lotnoExport = new System.Windows.Forms.Button();
            this.lbl_lotno_total = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl_lotno_updated = new System.Windows.Forms.Label();
            this.lbl_lotno_verified = new System.Windows.Forms.Label();
            this.lbl_lotno_error = new System.Windows.Forms.Label();
            this.rd_lotno_errors = new System.Windows.Forms.RadioButton();
            this.rd_lotno_all = new System.Windows.Forms.RadioButton();
            this.rd_lotno_verified = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.rd_lotno_updated = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_lotnum_upload = new System.Windows.Forms.Button();
            this.lv_lotnumbers = new System.Windows.Forms.ListView();
            this.pnl_NDT_Loader = new System.Windows.Forms.Panel();
            this.rd_loaderError = new System.Windows.Forms.RadioButton();
            this.rd_Updated = new System.Windows.Forms.RadioButton();
            this.lbl_alreadyUpdated = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rd_Error = new System.Windows.Forms.RadioButton();
            this.rd_verified = new System.Windows.Forms.RadioButton();
            this.rd_all = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_totaljoint = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_loaderErrors = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_errorjoints = new System.Windows.Forms.Label();
            this.lbl_verifiedJoints = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lst_removedJoints = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.rd_lotno_remove = new MetroFramework.Controls.MetroRadioButton();
            this.rd_lotno_upload = new MetroFramework.Controls.MetroRadioButton();
            this.btnVerify = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.ofd_fileOpen = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_lotno.SuspendLayout();
            this.pnl_NDT_Loader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 501);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pnl_lotno);
            this.panel3.Controls.Add(this.pnl_NDT_Loader);
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1012, 431);
            this.panel3.TabIndex = 4;
            // 
            // pnl_lotno
            // 
            this.pnl_lotno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_lotno.Controls.Add(this.btn_lotnoExport);
            this.pnl_lotno.Controls.Add(this.lbl_lotno_total);
            this.pnl_lotno.Controls.Add(this.label18);
            this.pnl_lotno.Controls.Add(this.lbl_lotno_updated);
            this.pnl_lotno.Controls.Add(this.lbl_lotno_verified);
            this.pnl_lotno.Controls.Add(this.lbl_lotno_error);
            this.pnl_lotno.Controls.Add(this.rd_lotno_errors);
            this.pnl_lotno.Controls.Add(this.rd_lotno_all);
            this.pnl_lotno.Controls.Add(this.rd_lotno_verified);
            this.pnl_lotno.Controls.Add(this.label13);
            this.pnl_lotno.Controls.Add(this.rd_lotno_updated);
            this.pnl_lotno.Controls.Add(this.label12);
            this.pnl_lotno.Controls.Add(this.label11);
            this.pnl_lotno.Controls.Add(this.label10);
            this.pnl_lotno.Controls.Add(this.btn_lotnum_upload);
            this.pnl_lotno.Controls.Add(this.lv_lotnumbers);
            this.pnl_lotno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_lotno.Location = new System.Drawing.Point(0, 0);
            this.pnl_lotno.Name = "pnl_lotno";
            this.pnl_lotno.Size = new System.Drawing.Size(1010, 429);
            this.pnl_lotno.TabIndex = 23;
            this.pnl_lotno.Visible = false;
            // 
            // btn_lotnoExport
            // 
            this.btn_lotnoExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_lotnoExport.BackColor = System.Drawing.Color.White;
            this.btn_lotnoExport.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_lotnoExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_lotnoExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_lotnoExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lotnoExport.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lotnoExport.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_lotnoExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_lotnoExport.Location = new System.Drawing.Point(6, 399);
            this.btn_lotnoExport.Name = "btn_lotnoExport";
            this.btn_lotnoExport.Size = new System.Drawing.Size(176, 24);
            this.btn_lotnoExport.TabIndex = 24;
            this.btn_lotnoExport.Text = "EXPORT LIST TO EXCEL";
            this.btn_lotnoExport.UseVisualStyleBackColor = false;
            this.btn_lotnoExport.Click += new System.EventHandler(this.btn_lotnoExport_Click);
            // 
            // lbl_lotno_total
            // 
            this.lbl_lotno_total.AutoSize = true;
            this.lbl_lotno_total.Location = new System.Drawing.Point(838, 16);
            this.lbl_lotno_total.Name = "lbl_lotno_total";
            this.lbl_lotno_total.Size = new System.Drawing.Size(10, 13);
            this.lbl_lotno_total.TabIndex = 23;
            this.lbl_lotno_total.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(683, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(153, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "TOTAL LOADER JOINTS:";
            // 
            // lbl_lotno_updated
            // 
            this.lbl_lotno_updated.AutoSize = true;
            this.lbl_lotno_updated.Location = new System.Drawing.Point(642, 27);
            this.lbl_lotno_updated.Name = "lbl_lotno_updated";
            this.lbl_lotno_updated.Size = new System.Drawing.Size(10, 13);
            this.lbl_lotno_updated.TabIndex = 21;
            this.lbl_lotno_updated.Text = "-";
            // 
            // lbl_lotno_verified
            // 
            this.lbl_lotno_verified.AutoSize = true;
            this.lbl_lotno_verified.Location = new System.Drawing.Point(642, 6);
            this.lbl_lotno_verified.Name = "lbl_lotno_verified";
            this.lbl_lotno_verified.Size = new System.Drawing.Size(10, 13);
            this.lbl_lotno_verified.TabIndex = 20;
            this.lbl_lotno_verified.Text = "-";
            // 
            // lbl_lotno_error
            // 
            this.lbl_lotno_error.AutoSize = true;
            this.lbl_lotno_error.Location = new System.Drawing.Point(473, 5);
            this.lbl_lotno_error.Name = "lbl_lotno_error";
            this.lbl_lotno_error.Size = new System.Drawing.Size(10, 13);
            this.lbl_lotno_error.TabIndex = 19;
            this.lbl_lotno_error.Text = "-";
            // 
            // rd_lotno_errors
            // 
            this.rd_lotno_errors.AutoSize = true;
            this.rd_lotno_errors.Location = new System.Drawing.Point(164, 24);
            this.rd_lotno_errors.Name = "rd_lotno_errors";
            this.rd_lotno_errors.Size = new System.Drawing.Size(52, 17);
            this.rd_lotno_errors.TabIndex = 17;
            this.rd_lotno_errors.TabStop = true;
            this.rd_lotno_errors.Text = "Errors";
            this.rd_lotno_errors.UseVisualStyleBackColor = true;
            this.rd_lotno_errors.CheckedChanged += new System.EventHandler(this.rd_lotno_errors_CheckedChanged);
            // 
            // rd_lotno_all
            // 
            this.rd_lotno_all.AutoSize = true;
            this.rd_lotno_all.Location = new System.Drawing.Point(71, 3);
            this.rd_lotno_all.Name = "rd_lotno_all";
            this.rd_lotno_all.Size = new System.Drawing.Size(36, 17);
            this.rd_lotno_all.TabIndex = 16;
            this.rd_lotno_all.TabStop = true;
            this.rd_lotno_all.Text = "All";
            this.rd_lotno_all.UseVisualStyleBackColor = true;
            this.rd_lotno_all.CheckedChanged += new System.EventHandler(this.rd_lotno_all_CheckedChanged);
            // 
            // rd_lotno_verified
            // 
            this.rd_lotno_verified.AutoSize = true;
            this.rd_lotno_verified.Location = new System.Drawing.Point(71, 21);
            this.rd_lotno_verified.Name = "rd_lotno_verified";
            this.rd_lotno_verified.Size = new System.Drawing.Size(60, 17);
            this.rd_lotno_verified.TabIndex = 15;
            this.rd_lotno_verified.TabStop = true;
            this.rd_lotno_verified.Text = "Verified";
            this.rd_lotno_verified.UseVisualStyleBackColor = true;
            this.rd_lotno_verified.CheckedChanged += new System.EventHandler(this.rd_lotno_verified_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "FILTERS:";
            // 
            // rd_lotno_updated
            // 
            this.rd_lotno_updated.AutoSize = true;
            this.rd_lotno_updated.Location = new System.Drawing.Point(164, 3);
            this.rd_lotno_updated.Name = "rd_lotno_updated";
            this.rd_lotno_updated.Size = new System.Drawing.Size(104, 17);
            this.rd_lotno_updated.TabIndex = 13;
            this.rd_lotno_updated.TabStop = true;
            this.rd_lotno_updated.Text = "Already Updated";
            this.rd_lotno_updated.UseVisualStyleBackColor = true;
            this.rd_lotno_updated.CheckedChanged += new System.EventHandler(this.rd_lotno_updated_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(405, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Error Joints:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(591, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Verified:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(549, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Already updated:";
            // 
            // btn_lotnum_upload
            // 
            this.btn_lotnum_upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lotnum_upload.BackColor = System.Drawing.Color.White;
            this.btn_lotnum_upload.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btn_lotnum_upload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btn_lotnum_upload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_lotnum_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lotnum_upload.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lotnum_upload.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_lotnum_upload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_lotnum_upload.Location = new System.Drawing.Point(831, 399);
            this.btn_lotnum_upload.Name = "btn_lotnum_upload";
            this.btn_lotnum_upload.Size = new System.Drawing.Size(176, 24);
            this.btn_lotnum_upload.TabIndex = 8;
            this.btn_lotnum_upload.Text = "UPLOAD";
            this.btn_lotnum_upload.UseVisualStyleBackColor = false;
            this.btn_lotnum_upload.Click += new System.EventHandler(this.btn_lotnum_upload_Click);
            // 
            // lv_lotnumbers
            // 
            this.lv_lotnumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_lotnumbers.BackColor = System.Drawing.SystemColors.Window;
            this.lv_lotnumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_lotnumbers.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_lotnumbers.FullRowSelect = true;
            this.lv_lotnumbers.GridLines = true;
            this.lv_lotnumbers.HideSelection = false;
            this.lv_lotnumbers.Location = new System.Drawing.Point(3, 47);
            this.lv_lotnumbers.Name = "lv_lotnumbers";
            this.lv_lotnumbers.Size = new System.Drawing.Size(1003, 346);
            this.lv_lotnumbers.TabIndex = 1;
            this.lv_lotnumbers.UseCompatibleStateImageBehavior = false;
            this.lv_lotnumbers.View = System.Windows.Forms.View.Details;
            // 
            // pnl_NDT_Loader
            // 
            this.pnl_NDT_Loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_NDT_Loader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_NDT_Loader.Controls.Add(this.rd_loaderError);
            this.pnl_NDT_Loader.Controls.Add(this.rd_Updated);
            this.pnl_NDT_Loader.Controls.Add(this.lbl_alreadyUpdated);
            this.pnl_NDT_Loader.Controls.Add(this.label9);
            this.pnl_NDT_Loader.Controls.Add(this.rd_Error);
            this.pnl_NDT_Loader.Controls.Add(this.rd_verified);
            this.pnl_NDT_Loader.Controls.Add(this.rd_all);
            this.pnl_NDT_Loader.Controls.Add(this.label5);
            this.pnl_NDT_Loader.Controls.Add(this.lbl_totaljoint);
            this.pnl_NDT_Loader.Controls.Add(this.label7);
            this.pnl_NDT_Loader.Controls.Add(this.lbl_loaderErrors);
            this.pnl_NDT_Loader.Controls.Add(this.label6);
            this.pnl_NDT_Loader.Controls.Add(this.lbl_errorjoints);
            this.pnl_NDT_Loader.Controls.Add(this.lbl_verifiedJoints);
            this.pnl_NDT_Loader.Controls.Add(this.label4);
            this.pnl_NDT_Loader.Controls.Add(this.label3);
            this.pnl_NDT_Loader.Controls.Add(this.btnUpload);
            this.pnl_NDT_Loader.Controls.Add(this.btnExport);
            this.pnl_NDT_Loader.Controls.Add(this.lst_removedJoints);
            this.pnl_NDT_Loader.Location = new System.Drawing.Point(3, 3);
            this.pnl_NDT_Loader.Name = "pnl_NDT_Loader";
            this.pnl_NDT_Loader.Size = new System.Drawing.Size(1004, 423);
            this.pnl_NDT_Loader.TabIndex = 0;
            this.pnl_NDT_Loader.Visible = false;
            this.pnl_NDT_Loader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_NDT_Loader_Paint);
            // 
            // rd_loaderError
            // 
            this.rd_loaderError.AutoSize = true;
            this.rd_loaderError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_loaderError.Location = new System.Drawing.Point(251, 20);
            this.rd_loaderError.Name = "rd_loaderError";
            this.rd_loaderError.Size = new System.Drawing.Size(88, 17);
            this.rd_loaderError.TabIndex = 22;
            this.rd_loaderError.Text = "Loader Errors";
            this.rd_loaderError.UseVisualStyleBackColor = true;
            this.rd_loaderError.CheckedChanged += new System.EventHandler(this.rd_loaderError_CheckedChanged);
            // 
            // rd_Updated
            // 
            this.rd_Updated.AutoSize = true;
            this.rd_Updated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Updated.Location = new System.Drawing.Point(141, 21);
            this.rd_Updated.Name = "rd_Updated";
            this.rd_Updated.Size = new System.Drawing.Size(104, 17);
            this.rd_Updated.TabIndex = 21;
            this.rd_Updated.Text = "Already Updated";
            this.rd_Updated.UseVisualStyleBackColor = true;
            this.rd_Updated.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lbl_alreadyUpdated
            // 
            this.lbl_alreadyUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_alreadyUpdated.AutoSize = true;
            this.lbl_alreadyUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_alreadyUpdated.Location = new System.Drawing.Point(602, 5);
            this.lbl_alreadyUpdated.Name = "lbl_alreadyUpdated";
            this.lbl_alreadyUpdated.Size = new System.Drawing.Size(13, 13);
            this.lbl_alreadyUpdated.TabIndex = 20;
            this.lbl_alreadyUpdated.Text = "--";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(485, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ALREADY UPDATED:";
            // 
            // rd_Error
            // 
            this.rd_Error.AutoSize = true;
            this.rd_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Error.Location = new System.Drawing.Point(141, 4);
            this.rd_Error.Name = "rd_Error";
            this.rd_Error.Size = new System.Drawing.Size(124, 17);
            this.rd_Error.TabIndex = 18;
            this.rd_Error.Text = "Error/Not Exist Joints";
            this.rd_Error.UseVisualStyleBackColor = true;
            this.rd_Error.CheckedChanged += new System.EventHandler(this.rd_Error_CheckedChanged);
            // 
            // rd_verified
            // 
            this.rd_verified.AutoSize = true;
            this.rd_verified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_verified.Location = new System.Drawing.Point(41, 20);
            this.rd_verified.Name = "rd_verified";
            this.rd_verified.Size = new System.Drawing.Size(90, 17);
            this.rd_verified.TabIndex = 17;
            this.rd_verified.Text = "Verified Joints";
            this.rd_verified.UseVisualStyleBackColor = true;
            this.rd_verified.CheckedChanged += new System.EventHandler(this.rd_verified_CheckedChanged);
            // 
            // rd_all
            // 
            this.rd_all.AutoSize = true;
            this.rd_all.Checked = true;
            this.rd_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_all.Location = new System.Drawing.Point(41, 3);
            this.rd_all.Name = "rd_all";
            this.rd_all.Size = new System.Drawing.Size(98, 17);
            this.rd_all.TabIndex = 16;
            this.rd_all.TabStop = true;
            this.rd_all.Text = "All loader Joints";
            this.rd_all.UseVisualStyleBackColor = true;
            this.rd_all.CheckedChanged += new System.EventHandler(this.rd_all_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Filter:";
            // 
            // lbl_totaljoint
            // 
            this.lbl_totaljoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_totaljoint.AutoSize = true;
            this.lbl_totaljoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totaljoint.Location = new System.Drawing.Point(966, 15);
            this.lbl_totaljoint.Name = "lbl_totaljoint";
            this.lbl_totaljoint.Size = new System.Drawing.Size(15, 13);
            this.lbl_totaljoint.TabIndex = 14;
            this.lbl_totaljoint.Text = "--";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(807, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "TOTAL LOADER JOINTS:";
            // 
            // lbl_loaderErrors
            // 
            this.lbl_loaderErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_loaderErrors.AutoSize = true;
            this.lbl_loaderErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loaderErrors.Location = new System.Drawing.Point(779, 5);
            this.lbl_loaderErrors.Name = "lbl_loaderErrors";
            this.lbl_loaderErrors.Size = new System.Drawing.Size(13, 13);
            this.lbl_loaderErrors.TabIndex = 12;
            this.lbl_loaderErrors.Text = "--";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(683, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "LOADER ERROR:";
            // 
            // lbl_errorjoints
            // 
            this.lbl_errorjoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_errorjoints.AutoSize = true;
            this.lbl_errorjoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_errorjoints.Location = new System.Drawing.Point(779, 22);
            this.lbl_errorjoints.Name = "lbl_errorjoints";
            this.lbl_errorjoints.Size = new System.Drawing.Size(13, 13);
            this.lbl_errorjoints.TabIndex = 10;
            this.lbl_errorjoints.Text = "--";
            // 
            // lbl_verifiedJoints
            // 
            this.lbl_verifiedJoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_verifiedJoints.AutoSize = true;
            this.lbl_verifiedJoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_verifiedJoints.Location = new System.Drawing.Point(602, 22);
            this.lbl_verifiedJoints.Name = "lbl_verifiedJoints";
            this.lbl_verifiedJoints.Size = new System.Drawing.Size(13, 13);
            this.lbl_verifiedJoints.TabIndex = 9;
            this.lbl_verifiedJoints.Text = "--";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(628, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ERROR/NOT EXIST JOINTS:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(500, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "VERIFIED JOINTS:";
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.White;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpload.Location = new System.Drawing.Point(823, 393);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(176, 24);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "UPLOAD VERIFIED JOINTS";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
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
            this.btnExport.Location = new System.Drawing.Point(4, 393);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(176, 24);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "EXPORT LIST TO EXCEL";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lst_removedJoints
            // 
            this.lst_removedJoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_removedJoints.BackColor = System.Drawing.SystemColors.Window;
            this.lst_removedJoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lst_removedJoints.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_removedJoints.FullRowSelect = true;
            this.lst_removedJoints.GridLines = true;
            this.lst_removedJoints.HideSelection = false;
            this.lst_removedJoints.Location = new System.Drawing.Point(4, 39);
            this.lst_removedJoints.Name = "lst_removedJoints";
            this.lst_removedJoints.Size = new System.Drawing.Size(995, 349);
            this.lst_removedJoints.TabIndex = 0;
            this.lst_removedJoints.UseCompatibleStateImageBehavior = false;
            this.lst_removedJoints.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "UNIT";
            this.columnHeader1.Width = 38;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SERVICE";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LINE";
            this.columnHeader3.Width = 49;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TRAIN";
            this.columnHeader4.Width = 46;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "JOINT";
            this.columnHeader5.Width = 42;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "REPORT";
            this.columnHeader6.Width = 185;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "REPORT DATE";
            this.columnHeader7.Width = 83;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "RESULT";
            this.columnHeader8.Width = 51;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "REMARKS";
            this.columnHeader9.Width = 220;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "NDT TYPE";
            this.columnHeader10.Width = 63;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "JOINT STATE";
            this.columnHeader11.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rd_lotno_remove);
            this.panel2.Controls.Add(this.rd_lotno_upload);
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_browse);
            this.panel2.Controls.Add(this.txtFilePath);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbMode);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 58);
            this.panel2.TabIndex = 3;
            // 
            // rd_lotno_remove
            // 
            this.rd_lotno_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_lotno_remove.AutoSize = true;
            this.rd_lotno_remove.Location = new System.Drawing.Point(727, 33);
            this.rd_lotno_remove.Name = "rd_lotno_remove";
            this.rd_lotno_remove.Size = new System.Drawing.Size(69, 15);
            this.rd_lotno_remove.Style = MetroFramework.MetroColorStyle.Lime;
            this.rd_lotno_remove.TabIndex = 9;
            this.rd_lotno_remove.Text = "REMOVE";
            this.rd_lotno_remove.UseSelectable = true;
            this.rd_lotno_remove.Visible = false;
            this.rd_lotno_remove.CheckedChanged += new System.EventHandler(this.rd_lotno_remove_CheckedChanged);
            // 
            // rd_lotno_upload
            // 
            this.rd_lotno_upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd_lotno_upload.AutoSize = true;
            this.rd_lotno_upload.Location = new System.Drawing.Point(727, 14);
            this.rd_lotno_upload.Name = "rd_lotno_upload";
            this.rd_lotno_upload.Size = new System.Drawing.Size(69, 15);
            this.rd_lotno_upload.Style = MetroFramework.MetroColorStyle.Lime;
            this.rd_lotno_upload.TabIndex = 8;
            this.rd_lotno_upload.Text = "UPLOAD";
            this.rd_lotno_upload.UseSelectable = true;
            this.rd_lotno_upload.Visible = false;
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
            this.btnVerify.Location = new System.Drawing.Point(831, 31);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(176, 24);
            this.btnVerify.TabIndex = 7;
            this.btnVerify.Text = "VERIFY LOADER";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "FILE:";
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
            this.btn_browse.Location = new System.Drawing.Point(831, 2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(176, 26);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "BROWSE";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(60, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(640, 22);
            this.txtFilePath.TabIndex = 0;
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
            // cmbMode
            // 
            this.cmbMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "NDT Loader",
            "Lot Loader",
            "NDT File Check"});
            this.cmbMode.Location = new System.Drawing.Point(60, 7);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(640, 22);
            this.cmbMode.TabIndex = 2;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frm_uploadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 535);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_uploadData";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Load += new System.EventHandler(this.frm_uploadData_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnl_lotno.ResumeLayout(false);
            this.pnl_lotno.PerformLayout();
            this.pnl_NDT_Loader.ResumeLayout(false);
            this.pnl_NDT_Loader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog ofd_fileOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroRadioButton rd_lotno_upload;
        private MetroFramework.Controls.MetroRadioButton rd_lotno_remove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnl_lotno;
        private System.Windows.Forms.Button btn_lotnum_upload;
        private System.Windows.Forms.ListView lv_lotnumbers;
        private System.Windows.Forms.Panel pnl_NDT_Loader;
        private System.Windows.Forms.RadioButton rd_loaderError;
        private System.Windows.Forms.RadioButton rd_Updated;
        private System.Windows.Forms.Label lbl_alreadyUpdated;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rd_Error;
        private System.Windows.Forms.RadioButton rd_verified;
        private System.Windows.Forms.RadioButton rd_all;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_totaljoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_loaderErrors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_errorjoints;
        private System.Windows.Forms.Label lbl_verifiedJoints;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListView lst_removedJoints;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_lotno_total;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl_lotno_updated;
        private System.Windows.Forms.Label lbl_lotno_verified;
        private System.Windows.Forms.Label lbl_lotno_error;
        private System.Windows.Forms.RadioButton rd_lotno_errors;
        private System.Windows.Forms.RadioButton rd_lotno_all;
        private System.Windows.Forms.RadioButton rd_lotno_verified;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rd_lotno_updated;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_lotnoExport;
    }
}