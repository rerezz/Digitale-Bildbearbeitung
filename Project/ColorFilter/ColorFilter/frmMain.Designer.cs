namespace ColorFilter
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
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.lblLoadImage = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpenFileDlg = new System.Windows.Forms.Button();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblTurn = new System.Windows.Forms.Label();
            this.txtTurnX = new System.Windows.Forms.TextBox();
            this.txtTurnY = new System.Windows.Forms.TextBox();
            this.lblSlash = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblRadius = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnTurn = new System.Windows.Forms.Button();
            this.cbxCorrection = new System.Windows.Forms.CheckBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxImage
            // 
            this.pbxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxImage.Image")));
            this.pbxImage.InitialImage = null;
            this.pbxImage.Location = new System.Drawing.Point(9, 127);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(607, 595);
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            this.pbxImage.MouseLeave += new System.EventHandler(this.pbxImage_MouseLeave);
            this.pbxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxImage_MouseClick);
            this.pbxImage.MouseEnter += new System.EventHandler(this.pbxImage_MouseEnter);
            // 
            // lblLoadImage
            // 
            this.lblLoadImage.AutoSize = true;
            this.lblLoadImage.Location = new System.Drawing.Point(9, 15);
            this.lblLoadImage.Name = "lblLoadImage";
            this.lblLoadImage.Size = new System.Drawing.Size(66, 13);
            this.lblLoadImage.TabIndex = 1;
            this.lblLoadImage.Text = "Load Image:";
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(81, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(475, 20);
            this.txtPath.TabIndex = 2;
            // 
            // btnOpenFileDlg
            // 
            this.btnOpenFileDlg.Location = new System.Drawing.Point(562, 10);
            this.btnOpenFileDlg.Name = "btnOpenFileDlg";
            this.btnOpenFileDlg.Size = new System.Drawing.Size(51, 23);
            this.btnOpenFileDlg.TabIndex = 3;
            this.btnOpenFileDlg.Text = "...";
            this.btnOpenFileDlg.UseVisualStyleBackColor = true;
            this.btnOpenFileDlg.Click += new System.EventHandler(this.btnOpenFileDlg_Click);
            // 
            // cbxFilter
            // 
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "Gray",
            "Red",
            "Green",
            "Blue"});
            this.cbxFilter.Location = new System.Drawing.Point(81, 38);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(475, 21);
            this.cbxFilter.TabIndex = 4;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(9, 41);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Filter:";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(562, 36);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(51, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Go";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(9, 70);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(32, 13);
            this.lblTurn.TabIndex = 7;
            this.lblTurn.Text = "Turn:";
            // 
            // txtTurnX
            // 
            this.txtTurnX.Enabled = false;
            this.txtTurnX.Location = new System.Drawing.Point(81, 67);
            this.txtTurnX.Name = "txtTurnX";
            this.txtTurnX.Size = new System.Drawing.Size(30, 20);
            this.txtTurnX.TabIndex = 8;
            this.txtTurnX.Text = "100";
            // 
            // txtTurnY
            // 
            this.txtTurnY.Enabled = false;
            this.txtTurnY.Location = new System.Drawing.Point(135, 67);
            this.txtTurnY.Name = "txtTurnY";
            this.txtTurnY.Size = new System.Drawing.Size(30, 20);
            this.txtTurnY.TabIndex = 9;
            this.txtTurnY.Text = "100";
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(117, 70);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 10;
            this.lblSlash.Text = "/";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(256, 67);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(30, 20);
            this.txtAngle.TabIndex = 11;
            this.txtAngle.Text = "45";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(171, 70);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(79, 13);
            this.lblAngle.TabIndex = 12;
            this.lblAngle.Text = "Angle (degree):";
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(296, 70);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(89, 13);
            this.lblRadius.TabIndex = 13;
            this.lblRadius.Text = "Rectangle (pixel):";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(391, 67);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(30, 20);
            this.txtHeight.TabIndex = 11;
            this.txtHeight.Text = "50";
            // 
            // btnTurn
            // 
            this.btnTurn.Location = new System.Drawing.Point(562, 65);
            this.btnTurn.Name = "btnTurn";
            this.btnTurn.Size = new System.Drawing.Size(51, 23);
            this.btnTurn.TabIndex = 3;
            this.btnTurn.Text = "Turn";
            this.btnTurn.UseVisualStyleBackColor = true;
            this.btnTurn.Click += new System.EventHandler(this.btnTurn_Click);
            // 
            // cbxCorrection
            // 
            this.cbxCorrection.AutoSize = true;
            this.cbxCorrection.Location = new System.Drawing.Point(483, 69);
            this.cbxCorrection.Name = "cbxCorrection";
            this.cbxCorrection.Size = new System.Drawing.Size(73, 17);
            this.cbxCorrection.TabIndex = 14;
            this.cbxCorrection.Text = "correction";
            this.cbxCorrection.UseVisualStyleBackColor = true;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(447, 67);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(30, 20);
            this.txtWidth.TabIndex = 11;
            this.txtWidth.Text = "100";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(427, 70);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 10;
            this.lblX.Text = "X";
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(562, 94);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(51, 23);
            this.btnDetect.TabIndex = 15;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(6, 99);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(69, 13);
            this.lblObjectName.TabIndex = 16;
            this.lblObjectName.Text = "Object Name";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(81, 96);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(475, 20);
            this.txtObjectName.TabIndex = 17;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 734);
            this.Controls.Add(this.txtObjectName);
            this.Controls.Add(this.lblObjectName);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.cbxCorrection);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.lblAngle);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.txtTurnY);
            this.Controls.Add(this.txtTurnX);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.btnTurn);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnOpenFileDlg);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblLoadImage);
            this.Controls.Add(this.pbxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label lblLoadImage;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpenFileDlg;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.TextBox txtTurnX;
        private System.Windows.Forms.TextBox txtTurnY;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnTurn;
        private System.Windows.Forms.CheckBox cbxCorrection;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label lblObjectName;
        private System.Windows.Forms.TextBox txtObjectName;
    }
}

