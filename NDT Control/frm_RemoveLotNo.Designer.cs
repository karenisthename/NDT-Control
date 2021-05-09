namespace NDT_Control
{
    partial class frm_RemoveLotNo
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
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_subc = new MetroFramework.Controls.MetroComboBox();
            this.btn_lotnum_upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "SELECT SUBCON:";
            // 
            // cmb_subc
            // 
            this.cmb_subc.FormattingEnabled = true;
            this.cmb_subc.ItemHeight = 23;
            this.cmb_subc.Items.AddRange(new object[] {
            "ABJ",
            "NSH",
            "ELECO",
            "SINOPEC"});
            this.cmb_subc.Location = new System.Drawing.Point(122, 29);
            this.cmb_subc.Name = "cmb_subc";
            this.cmb_subc.Size = new System.Drawing.Size(280, 29);
            this.cmb_subc.Style = MetroFramework.MetroColorStyle.Lime;
            this.cmb_subc.TabIndex = 16;
            this.cmb_subc.UseSelectable = true;
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
            this.btn_lotnum_upload.Location = new System.Drawing.Point(122, 65);
            this.btn_lotnum_upload.Name = "btn_lotnum_upload";
            this.btn_lotnum_upload.Size = new System.Drawing.Size(280, 24);
            this.btn_lotnum_upload.TabIndex = 17;
            this.btn_lotnum_upload.Text = "REMOVE ALL LOT NUMBERS";
            this.btn_lotnum_upload.UseVisualStyleBackColor = false;
            this.btn_lotnum_upload.Click += new System.EventHandler(this.btn_lotnum_upload_Click);
            // 
            // frm_RemoveLotNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 112);
            this.Controls.Add(this.btn_lotnum_upload);
            this.Controls.Add(this.cmb_subc);
            this.Controls.Add(this.label13);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_RemoveLotNo";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private MetroFramework.Controls.MetroComboBox cmb_subc;
        private System.Windows.Forms.Button btn_lotnum_upload;

    }
}