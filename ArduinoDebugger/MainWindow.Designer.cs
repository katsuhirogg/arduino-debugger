
namespace ArduinoDebugger
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.aimbotEnabled = new System.Windows.Forms.CheckBox();
            this.recoilEnabled = new System.Windows.Forms.CheckBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnExportList = new System.Windows.Forms.Button();
            this.dataTreeView = new System.Windows.Forms.TreeView();
            this.btnShowIde = new System.Windows.Forms.Button();
            this.MLeftBtn = new System.Windows.Forms.Panel();
            this.MScrollBtn = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.MRightBtn = new System.Windows.Forms.Panel();
            this.MBase = new System.Windows.Forms.Panel();
            this.MX2Btn = new System.Windows.Forms.Panel();
            this.MX1Btn = new System.Windows.Forms.Panel();
            this.lblLastBufferCommand = new System.Windows.Forms.Label();
            this.lblAthenaStatus = new System.Windows.Forms.Label();
            this.lblAthenaCmd = new System.Windows.Forms.Label();
            this.MScrollBtn.SuspendLayout();
            this.MBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 56);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 42);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(11, 27);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(121, 23);
            this.comboPorts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(11, 104);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(121, 42);
            this.btnRefreshList.TabIndex = 3;
            this.btnRefreshList.Text = "Refresh";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 149);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: ";
            // 
            // aimbotEnabled
            // 
            this.aimbotEnabled.AutoSize = true;
            this.aimbotEnabled.Location = new System.Drawing.Point(11, 203);
            this.aimbotEnabled.Name = "aimbotEnabled";
            this.aimbotEnabled.Size = new System.Drawing.Size(193, 19);
            this.aimbotEnabled.TabIndex = 6;
            this.aimbotEnabled.Text = "Enable Send Aimbot Command";
            this.aimbotEnabled.UseVisualStyleBackColor = true;
            // 
            // recoilEnabled
            // 
            this.recoilEnabled.AutoSize = true;
            this.recoilEnabled.Location = new System.Drawing.Point(11, 227);
            this.recoilEnabled.Name = "recoilEnabled";
            this.recoilEnabled.Size = new System.Drawing.Size(185, 19);
            this.recoilEnabled.TabIndex = 7;
            this.recoilEnabled.Text = "Enable Send Recoil Command";
            this.recoilEnabled.UseVisualStyleBackColor = true;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(138, 56);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(120, 42);
            this.btnClearList.TabIndex = 8;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnExportList
            // 
            this.btnExportList.Location = new System.Drawing.Point(138, 104);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.Size = new System.Drawing.Size(120, 42);
            this.btnExportList.TabIndex = 9;
            this.btnExportList.Text = "Export List";
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportList_Click);
            // 
            // dataTreeView
            // 
            this.dataTreeView.Location = new System.Drawing.Point(264, 12);
            this.dataTreeView.Name = "dataTreeView";
            this.dataTreeView.Size = new System.Drawing.Size(213, 134);
            this.dataTreeView.TabIndex = 10;
            // 
            // btnShowIde
            // 
            this.btnShowIde.Location = new System.Drawing.Point(13, 393);
            this.btnShowIde.Name = "btnShowIde";
            this.btnShowIde.Size = new System.Drawing.Size(119, 42);
            this.btnShowIde.TabIndex = 11;
            this.btnShowIde.Text = "Show IDE";
            this.btnShowIde.UseVisualStyleBackColor = true;
            // 
            // MLeftBtn
            // 
            this.MLeftBtn.BackColor = System.Drawing.Color.IndianRed;
            this.MLeftBtn.Location = new System.Drawing.Point(3, 3);
            this.MLeftBtn.Name = "MLeftBtn";
            this.MLeftBtn.Size = new System.Drawing.Size(56, 76);
            this.MLeftBtn.TabIndex = 12;
            // 
            // MScrollBtn
            // 
            this.MScrollBtn.BackColor = System.Drawing.Color.IndianRed;
            this.MScrollBtn.Controls.Add(this.panel8);
            this.MScrollBtn.Controls.Add(this.panel7);
            this.MScrollBtn.Location = new System.Drawing.Point(62, 3);
            this.MScrollBtn.Name = "MScrollBtn";
            this.MScrollBtn.Size = new System.Drawing.Size(53, 76);
            this.MScrollBtn.TabIndex = 13;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(3, 50);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(47, 23);
            this.panel8.TabIndex = 17;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(47, 23);
            this.panel7.TabIndex = 16;
            // 
            // MRightBtn
            // 
            this.MRightBtn.BackColor = System.Drawing.Color.IndianRed;
            this.MRightBtn.Location = new System.Drawing.Point(118, 3);
            this.MRightBtn.Name = "MRightBtn";
            this.MRightBtn.Size = new System.Drawing.Size(53, 76);
            this.MRightBtn.TabIndex = 13;
            // 
            // MBase
            // 
            this.MBase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MBase.Controls.Add(this.MX2Btn);
            this.MBase.Controls.Add(this.MX1Btn);
            this.MBase.Controls.Add(this.lblLastBufferCommand);
            this.MBase.Controls.Add(this.MLeftBtn);
            this.MBase.Controls.Add(this.MRightBtn);
            this.MBase.Controls.Add(this.MScrollBtn);
            this.MBase.Location = new System.Drawing.Point(304, 170);
            this.MBase.Name = "MBase";
            this.MBase.Size = new System.Drawing.Size(174, 265);
            this.MBase.TabIndex = 14;
            // 
            // MX2Btn
            // 
            this.MX2Btn.BackColor = System.Drawing.Color.IndianRed;
            this.MX2Btn.Location = new System.Drawing.Point(3, 81);
            this.MX2Btn.Name = "MX2Btn";
            this.MX2Btn.Size = new System.Drawing.Size(30, 49);
            this.MX2Btn.TabIndex = 16;
            // 
            // MX1Btn
            // 
            this.MX1Btn.BackColor = System.Drawing.Color.IndianRed;
            this.MX1Btn.Location = new System.Drawing.Point(3, 132);
            this.MX1Btn.Name = "MX1Btn";
            this.MX1Btn.Size = new System.Drawing.Size(30, 49);
            this.MX1Btn.TabIndex = 15;
            // 
            // lblLastBufferCommand
            // 
            this.lblLastBufferCommand.AutoSize = true;
            this.lblLastBufferCommand.Location = new System.Drawing.Point(3, 232);
            this.lblLastBufferCommand.Name = "lblLastBufferCommand";
            this.lblLastBufferCommand.Size = new System.Drawing.Size(70, 30);
            this.lblLastBufferCommand.TabIndex = 14;
            this.lblLastBufferCommand.Text = "\r\nCommand: ";
            // 
            // lblAthenaStatus
            // 
            this.lblAthenaStatus.AutoSize = true;
            this.lblAthenaStatus.Location = new System.Drawing.Point(12, 164);
            this.lblAthenaStatus.Name = "lblAthenaStatus";
            this.lblAthenaStatus.Size = new System.Drawing.Size(36, 15);
            this.lblAthenaStatus.TabIndex = 15;
            this.lblAthenaStatus.Text = "Pipe: ";
            // 
            // lblAthenaCmd
            // 
            this.lblAthenaCmd.AutoSize = true;
            this.lblAthenaCmd.Location = new System.Drawing.Point(11, 179);
            this.lblAthenaCmd.Name = "lblAthenaCmd";
            this.lblAthenaCmd.Size = new System.Drawing.Size(70, 15);
            this.lblAthenaCmd.TabIndex = 17;
            this.lblAthenaCmd.Text = "Command: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 447);
            this.Controls.Add(this.lblAthenaCmd);
            this.Controls.Add(this.lblAthenaStatus);
            this.Controls.Add(this.MBase);
            this.Controls.Add(this.btnShowIde);
            this.Controls.Add(this.dataTreeView);
            this.Controls.Add(this.btnExportList);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.recoilEnabled);
            this.Controls.Add(this.aimbotEnabled);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPorts);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainForm";
            this.Text = "Arduino Debugger";
            this.Load += new System.EventHandler(this.FormLoad);
            this.MScrollBtn.ResumeLayout(false);
            this.MBase.ResumeLayout(false);
            this.MBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox aimbotEnabled;
        private System.Windows.Forms.CheckBox recoilEnabled;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnExportList;
        private System.Windows.Forms.TreeView dataTreeView;
        private System.Windows.Forms.Button btnShowIde;
        private System.Windows.Forms.Panel MLeftBtn;
        private System.Windows.Forms.Panel MScrollBtn;
        private System.Windows.Forms.Panel MRightBtn;
        private System.Windows.Forms.Panel MBase;
        private System.Windows.Forms.Label lblLastBufferCommand;
        private System.Windows.Forms.Panel MX2Btn;
        private System.Windows.Forms.Panel MX1Btn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblAthenaStatus;
        private System.Windows.Forms.Label lblAthenaCmd;
    }
}

