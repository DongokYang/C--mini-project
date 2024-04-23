namespace WindowsApp.Dongok.Yang
{
    partial class AboutForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linklblCopyright = new System.Windows.Forms.LinkLabel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsApp.Dongok.Yang.Properties.Resources.new_car__1_;
            this.pictureBox1.Location = new System.Drawing.Point(200, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // linklblCopyright
            // 
            this.linklblCopyright.AllowDrop = true;
            this.linklblCopyright.AutoEllipsis = true;
            this.linklblCopyright.AutoSize = true;
            this.linklblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.linklblCopyright.Location = new System.Drawing.Point(235, 234);
            this.linklblCopyright.Name = "linklblCopyright";
            this.linklblCopyright.Size = new System.Drawing.Size(93, 20);
            this.linklblCopyright.TabIndex = 1;
            this.linklblCopyright.TabStop = true;
            this.linklblCopyright.Text = "Logo credit";
            this.linklblCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblCopyright_LinkClicked);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblAppName.Location = new System.Drawing.Point(116, 5);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(301, 26);
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = "Vehicle Quote - Dongok Yang";
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.Location = new System.Drawing.Point(12, 324);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(73, 16);
            this.lblAppVersion.TabIndex = 3;
            this.lblAppVersion.Text = "Version 1.0";
            this.lblAppVersion.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(335, 324);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 16);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright © 2024 - Dongok Yang";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(238, 274);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 32);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(571, 348);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblAppVersion);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.linklblCopyright);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Vehicle Quote - Dongok Yang ";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linklblCopyright;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnOk;
    }
}