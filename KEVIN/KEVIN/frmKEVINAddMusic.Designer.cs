namespace KEVIN
{
    partial class frmKEVINAddMusic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINAddMusic));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAddMusic = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblAddMusic);
            this.pnlHeader.Location = new System.Drawing.Point(-4, -4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(753, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAddMusic
            // 
            this.lblAddMusic.AutoSize = true;
            this.lblAddMusic.Font = new System.Drawing.Font("Trebuchet MS", 27F);
            this.lblAddMusic.Location = new System.Drawing.Point(9, 10);
            this.lblAddMusic.Name = "lblAddMusic";
            this.lblAddMusic.Size = new System.Drawing.Size(181, 44);
            this.lblAddMusic.TabIndex = 0;
            this.lblAddMusic.Text = "Add Music";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnSubmit);
            this.pnlFooter.Location = new System.Drawing.Point(-4, 359);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(753, 60);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(651, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 35);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // frmKEVINAddMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 416);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmKEVINAddMusic";
            this.Text = "Add Music";
            this.Load += new System.EventHandler(this.frmKEVINAddMusic_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAddMusic;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSubmit;
    }
}