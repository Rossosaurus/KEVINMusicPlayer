﻿namespace KEVIN
{
    partial class frmTesting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTesting));
            this.lblT = new System.Windows.Forms.Label();
            this.lblTV = new System.Windows.Forms.Label();
            this.lblSL = new System.Windows.Forms.Label();
            this.lblMQ = new System.Windows.Forms.Label();
            this.lblQN = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblMQV = new System.Windows.Forms.Label();
            this.lblPV = new System.Windows.Forms.Label();
            this.lblSLV = new System.Windows.Forms.Label();
            this.lblQNV = new System.Windows.Forms.Label();
            this.bwDebug = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(12, 9);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(33, 13);
            this.lblT.TabIndex = 0;
            this.lblT.Text = "Timer";
            // 
            // lblTV
            // 
            this.lblTV.AutoSize = true;
            this.lblTV.Location = new System.Drawing.Point(118, 9);
            this.lblTV.Name = "lblTV";
            this.lblTV.Size = new System.Drawing.Size(16, 13);
            this.lblTV.TabIndex = 1;
            this.lblTV.Text = "---";
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(12, 22);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(65, 13);
            this.lblSL.TabIndex = 2;
            this.lblSL.Text = "SongLength";
            // 
            // lblMQ
            // 
            this.lblMQ.AutoSize = true;
            this.lblMQ.Location = new System.Drawing.Point(12, 35);
            this.lblMQ.Name = "lblMQ";
            this.lblMQ.Size = new System.Drawing.Size(62, 13);
            this.lblMQ.TabIndex = 3;
            this.lblMQ.Text = "Queue Size";
            // 
            // lblQN
            // 
            this.lblQN.AutoSize = true;
            this.lblQN.Location = new System.Drawing.Point(12, 48);
            this.lblQN.Name = "lblQN";
            this.lblQN.Size = new System.Drawing.Size(87, 13);
            this.lblQN.TabIndex = 4;
            this.lblQN.Text = "Current QueueID";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(12, 61);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(41, 13);
            this.lblP.TabIndex = 5;
            this.lblP.Text = "Playing";
            // 
            // lblMQV
            // 
            this.lblMQV.AutoSize = true;
            this.lblMQV.Location = new System.Drawing.Point(118, 35);
            this.lblMQV.Name = "lblMQV";
            this.lblMQV.Size = new System.Drawing.Size(16, 13);
            this.lblMQV.TabIndex = 7;
            this.lblMQV.Text = "---";
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Location = new System.Drawing.Point(118, 61);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(16, 13);
            this.lblPV.TabIndex = 8;
            this.lblPV.Text = "---";
            // 
            // lblSLV
            // 
            this.lblSLV.AutoSize = true;
            this.lblSLV.Location = new System.Drawing.Point(118, 22);
            this.lblSLV.Name = "lblSLV";
            this.lblSLV.Size = new System.Drawing.Size(16, 13);
            this.lblSLV.TabIndex = 9;
            this.lblSLV.Text = "---";
            // 
            // lblQNV
            // 
            this.lblQNV.AutoSize = true;
            this.lblQNV.Location = new System.Drawing.Point(118, 48);
            this.lblQNV.Name = "lblQNV";
            this.lblQNV.Size = new System.Drawing.Size(16, 13);
            this.lblQNV.TabIndex = 10;
            this.lblQNV.Text = "---";
            // 
            // bwDebug
            // 
            this.bwDebug.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDebug_DoWork);
            // 
            // frmTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 79);
            this.Controls.Add(this.lblQNV);
            this.Controls.Add(this.lblSLV);
            this.Controls.Add(this.lblPV);
            this.Controls.Add(this.lblMQV);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblQN);
            this.Controls.Add(this.lblMQ);
            this.Controls.Add(this.lblSL);
            this.Controls.Add(this.lblTV);
            this.Controls.Add(this.lblT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmTesting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblTV;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label lblMQ;
        private System.Windows.Forms.Label lblQN;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblMQV;
        private System.Windows.Forms.Label lblPV;
        private System.Windows.Forms.Label lblSLV;
        private System.Windows.Forms.Label lblQNV;
        private System.ComponentModel.BackgroundWorker bwDebug;
    }
}