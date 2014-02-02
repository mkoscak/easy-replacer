namespace Replacer
{
    partial class FrmMain
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubs = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.labelOne = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubstitutions = new System.Windows.Forms.ComboBox();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(157, 68);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(125, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "&Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(10, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Substitutions:";
            // 
            // txtSubs
            // 
            this.txtSubs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubs.Location = new System.Drawing.Point(12, 122);
            this.txtSubs.Multiline = true;
            this.txtSubs.Name = "txtSubs";
            this.txtSubs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSubs.Size = new System.Drawing.Size(408, 312);
            this.txtSubs.TabIndex = 2;
            this.txtSubs.WordWrap = false;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelOne});
            this.statusBar.Location = new System.Drawing.Point(0, 437);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(432, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // labelOne
            // 
            this.labelOne.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(92, 17);
            this.labelOne.Text = "Program started";
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemplateName.AutoEllipsis = true;
            this.lblTemplateName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTemplateName.Location = new System.Drawing.Point(86, 106);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(332, 13);
            this.lblTemplateName.TabIndex = 4;
            this.lblTemplateName.Text = "<no_name>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(32, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subs file:";
            // 
            // cbSubstitutions
            // 
            this.cbSubstitutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubstitutions.FormattingEnabled = true;
            this.cbSubstitutions.Location = new System.Drawing.Point(89, 14);
            this.cbSubstitutions.Name = "cbSubstitutions";
            this.cbSubstitutions.Size = new System.Drawing.Size(193, 21);
            this.cbSubstitutions.TabIndex = 6;
            this.cbSubstitutions.SelectedIndexChanged += new System.EventHandler(this.cbSubstitutions_SelectedIndexChanged);
            // 
            // cbTemplate
            // 
            this.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(89, 41);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(193, 21);
            this.cbTemplate.TabIndex = 8;
            this.cbTemplate.SelectedIndexChanged += new System.EventHandler(this.cbTemplate_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Template set:";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogo.Location = new System.Drawing.Point(288, 14);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(132, 89);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 9;
            this.picLogo.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 459);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cbTemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSubstitutions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTemplateName);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.txtSubs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcess);
            this.MinimumSize = new System.Drawing.Size(448, 498);
            this.Name = "FrmMain";
            this.Text = "Easy Replacer v0.2";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubs;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel labelOne;
        private System.Windows.Forms.Label lblTemplateName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubstitutions;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

