namespace KEVIN
{
    partial class frmKEVINSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKEVINSettings));
            this.tlpSettingsTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblSettings = new System.Windows.Forms.Label();
            this.pcbxSettings = new System.Windows.Forms.PictureBox();
            this.tlpNavigationBar = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tlpSettingsTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSettings)).BeginInit();
            this.tlpNavigationBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSettingsTitle
            // 
            this.tlpSettingsTitle.ColumnCount = 2;
            this.tlpSettingsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.56962F));
            this.tlpSettingsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.43038F));
            this.tlpSettingsTitle.Controls.Add(this.lblSettings, 0, 0);
            this.tlpSettingsTitle.Controls.Add(this.pcbxSettings, 1, 0);
            this.tlpSettingsTitle.Location = new System.Drawing.Point(-1, -1);
            this.tlpSettingsTitle.Name = "tlpSettingsTitle";
            this.tlpSettingsTitle.RowCount = 1;
            this.tlpSettingsTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsTitle.Size = new System.Drawing.Size(395, 50);
            this.tlpSettingsTitle.TabIndex = 0;
            this.tlpSettingsTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpSettingsTitle_Paint);
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Trebuchet MS", 27F);
            this.lblSettings.Location = new System.Drawing.Point(6, 3);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(148, 44);
            this.lblSettings.TabIndex = 2;
            this.lblSettings.Text = "Settings";
            // 
            // pcbxSettings
            // 
            this.pcbxSettings.BackgroundImage = global::KEVIN.Properties.Resources.Settings_Logo_Coloured_fw;
            this.pcbxSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbxSettings.Location = new System.Drawing.Point(340, 3);
            this.pcbxSettings.Name = "pcbxSettings";
            this.pcbxSettings.Size = new System.Drawing.Size(52, 44);
            this.pcbxSettings.TabIndex = 3;
            this.pcbxSettings.TabStop = false;
            // 
            // tlpNavigationBar
            // 
            this.tlpNavigationBar.ColumnCount = 1;
            this.tlpNavigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNavigationBar.Controls.Add(this.button1, 0, 0);
            this.tlpNavigationBar.Controls.Add(this.button2, 0, 1);
            this.tlpNavigationBar.Controls.Add(this.button3, 0, 2);
            this.tlpNavigationBar.Location = new System.Drawing.Point(-1, 49);
            this.tlpNavigationBar.Name = "tlpNavigationBar";
            this.tlpNavigationBar.RowCount = 3;
            this.tlpNavigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpNavigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpNavigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNavigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNavigationBar.Size = new System.Drawing.Size(39, 610);
            this.tlpNavigationBar.TabIndex = 1;
            this.tlpNavigationBar.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpNavigationBar_Paint);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::KEVIN.Properties.Resources.General_Button_fw;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 112);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::KEVIN.Properties.Resources.Skins_Button_Not_Selected__fw;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 197);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 64);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::KEVIN.Properties.Resources.Player_Button_Not_Selected__fw;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 112);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 85);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmKEVINSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 656);
            this.Controls.Add(this.tlpNavigationBar);
            this.Controls.Add(this.tlpSettingsTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmKEVINSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmKEVINSettings_Load);
            this.tlpSettingsTitle.ResumeLayout(false);
            this.tlpSettingsTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxSettings)).EndInit();
            this.tlpNavigationBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSettingsTitle;
        private System.Windows.Forms.TableLayoutPanel tlpNavigationBar;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pcbxSettings;
    }
}