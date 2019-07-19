namespace KAZ_Root_Cert_Detector
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lvCerts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemoveCerts = new System.Windows.Forms.Button();
            this.picUS = new System.Windows.Forms.PictureBox();
            this.picRU = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRU)).BeginInit();
            this.SuspendLayout();
            // 
            // lvCerts
            // 
            this.lvCerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCerts.Location = new System.Drawing.Point(1, 12);
            this.lvCerts.Name = "lvCerts";
            this.lvCerts.Size = new System.Drawing.Size(1134, 394);
            this.lvCerts.TabIndex = 0;
            this.lvCerts.UseCompatibleStateImageBehavior = false;
            this.lvCerts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FriendlyName";
            this.columnHeader1.Width = 213;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Issuer";
            this.columnHeader2.Width = 187;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ExpirationDate";
            this.columnHeader3.Width = 161;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ThumbPrint";
            this.columnHeader4.Width = 282;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SerialNumber";
            this.columnHeader5.Width = 173;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "StoreLocation";
            this.columnHeader6.Width = 120;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1050, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemoveCerts
            // 
            this.btnRemoveCerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveCerts.Enabled = false;
            this.btnRemoveCerts.Location = new System.Drawing.Point(13, 414);
            this.btnRemoveCerts.Name = "btnRemoveCerts";
            this.btnRemoveCerts.Size = new System.Drawing.Size(235, 23);
            this.btnRemoveCerts.TabIndex = 2;
            this.btnRemoveCerts.Text = "Remove KAZ Certificates";
            this.btnRemoveCerts.UseVisualStyleBackColor = true;
            this.btnRemoveCerts.Click += new System.EventHandler(this.btnRemoveCerts_Click);
            // 
            // picUS
            // 
            this.picUS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picUS.Image = global::KAZ_Root_Cert_Detector.Properties.Resources.United_Kingdom;
            this.picUS.Location = new System.Drawing.Point(495, 412);
            this.picUS.Name = "picUS";
            this.picUS.Size = new System.Drawing.Size(51, 33);
            this.picUS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUS.TabIndex = 6;
            this.picUS.TabStop = false;
            this.picUS.Click += new System.EventHandler(this.picUS_Click);
            // 
            // picRU
            // 
            this.picRU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRU.Image = global::KAZ_Root_Cert_Detector.Properties.Resources.Russia;
            this.picRU.Location = new System.Drawing.Point(438, 412);
            this.picRU.Name = "picRU";
            this.picRU.Size = new System.Drawing.Size(51, 33);
            this.picRU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRU.TabIndex = 5;
            this.picRU.TabStop = false;
            this.picRU.Click += new System.EventHandler(this.picRU_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 450);
            this.Controls.Add(this.picUS);
            this.Controls.Add(this.picRU);
            this.Controls.Add(this.btnRemoveCerts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvCerts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Kazakhstan Root Cert Detection";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCerts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemoveCerts;
        private System.Windows.Forms.PictureBox picRU;
        private System.Windows.Forms.PictureBox picUS;
    }
}

