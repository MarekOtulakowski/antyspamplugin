namespace AntySpamPlugin
{
    partial class FormSettings
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
            this.TC_tabs = new System.Windows.Forms.TabControl();
            this.T_servers = new System.Windows.Forms.TabPage();
            this.GB_signingSpam = new System.Windows.Forms.GroupBox();
            this.L_questionSignedSpam = new System.Windows.Forms.Label();
            this.TB_sign = new System.Windows.Forms.TextBox();
            this.CB_modifySubjectMail = new System.Windows.Forms.CheckBox();
            this.GB_spamDestination = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RB_junkFolder = new System.Windows.Forms.RadioButton();
            this.L_choosedFolder = new System.Windows.Forms.Label();
            this.RB_chooseFolder = new System.Windows.Forms.RadioButton();
            this.B_chooseFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_addServer = new System.Windows.Forms.TextBox();
            this.B_removeServer = new System.Windows.Forms.Button();
            this.B_addServer = new System.Windows.Forms.Button();
            this.CLB_listServer = new System.Windows.Forms.CheckedListBox();
            this.T_whiteList = new System.Windows.Forms.TabPage();
            this.B_removeAllFromWhiteList = new System.Windows.Forms.Button();
            this.B_importFromFile = new System.Windows.Forms.Button();
            this.B_exportToFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.L_whiteList = new System.Windows.Forms.Label();
            this.TB_addToWhiteList = new System.Windows.Forms.TextBox();
            this.LB_whiteList = new System.Windows.Forms.ListBox();
            this.B_removeFromWhiteList = new System.Windows.Forms.Button();
            this.B_editSelectedWhiteRecord = new System.Windows.Forms.Button();
            this.B_addToWhiteList = new System.Windows.Forms.Button();
            this.T_other = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.B_destinationFile = new System.Windows.Forms.Button();
            this.TB_pathToErrorLog = new System.Windows.Forms.TextBox();
            this.CB_saveError = new System.Windows.Forms.CheckBox();
            this.B_saveSettings = new System.Windows.Forms.Button();
            this.B_dontSaveAndExit = new System.Windows.Forms.Button();
            this.TC_tabs.SuspendLayout();
            this.T_servers.SuspendLayout();
            this.GB_signingSpam.SuspendLayout();
            this.GB_spamDestination.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.T_whiteList.SuspendLayout();
            this.T_other.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TC_tabs
            // 
            this.TC_tabs.Controls.Add(this.T_servers);
            this.TC_tabs.Controls.Add(this.T_whiteList);
            this.TC_tabs.Controls.Add(this.T_other);
            this.TC_tabs.Location = new System.Drawing.Point(3, 3);
            this.TC_tabs.Name = "TC_tabs";
            this.TC_tabs.SelectedIndex = 0;
            this.TC_tabs.Size = new System.Drawing.Size(316, 443);
            this.TC_tabs.TabIndex = 0;
            // 
            // T_servers
            // 
            this.T_servers.Controls.Add(this.GB_signingSpam);
            this.T_servers.Controls.Add(this.GB_spamDestination);
            this.T_servers.Controls.Add(this.groupBox1);
            this.T_servers.Location = new System.Drawing.Point(4, 22);
            this.T_servers.Name = "T_servers";
            this.T_servers.Padding = new System.Windows.Forms.Padding(3);
            this.T_servers.Size = new System.Drawing.Size(308, 417);
            this.T_servers.TabIndex = 0;
            this.T_servers.Text = "Servers";
            this.T_servers.UseVisualStyleBackColor = true;
            // 
            // GB_signingSpam
            // 
            this.GB_signingSpam.Controls.Add(this.L_questionSignedSpam);
            this.GB_signingSpam.Controls.Add(this.TB_sign);
            this.GB_signingSpam.Controls.Add(this.CB_modifySubjectMail);
            this.GB_signingSpam.Location = new System.Drawing.Point(10, 368);
            this.GB_signingSpam.Name = "GB_signingSpam";
            this.GB_signingSpam.Size = new System.Drawing.Size(273, 43);
            this.GB_signingSpam.TabIndex = 17;
            this.GB_signingSpam.TabStop = false;
            this.GB_signingSpam.Text = "Signed spam";
            // 
            // L_questionSignedSpam
            // 
            this.L_questionSignedSpam.AutoSize = true;
            this.L_questionSignedSpam.Location = new System.Drawing.Point(220, 21);
            this.L_questionSignedSpam.Name = "L_questionSignedSpam";
            this.L_questionSignedSpam.Size = new System.Drawing.Size(33, 13);
            this.L_questionSignedSpam.TabIndex = 2;
            this.L_questionSignedSpam.Text = "word)";
            // 
            // TB_sign
            // 
            this.TB_sign.Enabled = false;
            this.TB_sign.Location = new System.Drawing.Point(167, 17);
            this.TB_sign.Name = "TB_sign";
            this.TB_sign.Size = new System.Drawing.Size(53, 20);
            this.TB_sign.TabIndex = 1;
            this.TB_sign.Text = "[SPAM]";
            // 
            // CB_modifySubjectMail
            // 
            this.CB_modifySubjectMail.AutoSize = true;
            this.CB_modifySubjectMail.Location = new System.Drawing.Point(9, 20);
            this.CB_modifySubjectMail.Name = "CB_modifySubjectMail";
            this.CB_modifySubjectMail.Size = new System.Drawing.Size(159, 17);
            this.CB_modifySubjectMail.TabIndex = 0;
            this.CB_modifySubjectMail.Text = "Modify subject mail? (adding";
            this.CB_modifySubjectMail.UseVisualStyleBackColor = true;
            this.CB_modifySubjectMail.CheckedChanged += new System.EventHandler(this.CB_modifySubjectMail_CheckedChanged);
            // 
            // GB_spamDestination
            // 
            this.GB_spamDestination.Controls.Add(this.label2);
            this.GB_spamDestination.Controls.Add(this.label1);
            this.GB_spamDestination.Controls.Add(this.RB_junkFolder);
            this.GB_spamDestination.Controls.Add(this.L_choosedFolder);
            this.GB_spamDestination.Controls.Add(this.RB_chooseFolder);
            this.GB_spamDestination.Controls.Add(this.B_chooseFolder);
            this.GB_spamDestination.Location = new System.Drawing.Point(10, 249);
            this.GB_spamDestination.Name = "GB_spamDestination";
            this.GB_spamDestination.Size = new System.Drawing.Size(273, 114);
            this.GB_spamDestination.TabIndex = 16;
            this.GB_spamDestination.TabStop = false;
            this.GB_spamDestination.Text = "Move spam to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "(list above) then this mail move to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "If mail server sender there are listed on black list";
            // 
            // RB_junkFolder
            // 
            this.RB_junkFolder.AutoSize = true;
            this.RB_junkFolder.Checked = true;
            this.RB_junkFolder.Location = new System.Drawing.Point(9, 56);
            this.RB_junkFolder.Name = "RB_junkFolder";
            this.RB_junkFolder.Size = new System.Drawing.Size(77, 17);
            this.RB_junkFolder.TabIndex = 12;
            this.RB_junkFolder.TabStop = true;
            this.RB_junkFolder.Text = "JunkFolder";
            this.RB_junkFolder.UseVisualStyleBackColor = true;
            this.RB_junkFolder.CheckedChanged += new System.EventHandler(this.RB_junkFolder_CheckedChanged);
            // 
            // L_choosedFolder
            // 
            this.L_choosedFolder.AutoSize = true;
            this.L_choosedFolder.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.L_choosedFolder.Location = new System.Drawing.Point(25, 97);
            this.L_choosedFolder.Name = "L_choosedFolder";
            this.L_choosedFolder.Size = new System.Drawing.Size(23, 13);
            this.L_choosedFolder.TabIndex = 15;
            this.L_choosedFolder.Text = "null";
            // 
            // RB_chooseFolder
            // 
            this.RB_chooseFolder.AutoSize = true;
            this.RB_chooseFolder.Location = new System.Drawing.Point(9, 77);
            this.RB_chooseFolder.Name = "RB_chooseFolder";
            this.RB_chooseFolder.Size = new System.Drawing.Size(95, 17);
            this.RB_chooseFolder.TabIndex = 13;
            this.RB_chooseFolder.Text = "choosed folder";
            this.RB_chooseFolder.UseVisualStyleBackColor = true;
            this.RB_chooseFolder.CheckedChanged += new System.EventHandler(this.RB_chooseFolder_CheckedChanged);
            // 
            // B_chooseFolder
            // 
            this.B_chooseFolder.Enabled = false;
            this.B_chooseFolder.Location = new System.Drawing.Point(188, 71);
            this.B_chooseFolder.Name = "B_chooseFolder";
            this.B_chooseFolder.Size = new System.Drawing.Size(75, 23);
            this.B_chooseFolder.TabIndex = 14;
            this.B_chooseFolder.Text = "Choose";
            this.B_chooseFolder.UseVisualStyleBackColor = true;
            this.B_chooseFolder.Click += new System.EventHandler(this.B_chooseFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_addServer);
            this.groupBox1.Controls.Add(this.B_removeServer);
            this.groupBox1.Controls.Add(this.B_addServer);
            this.groupBox1.Controls.Add(this.CLB_listServer);
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 238);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check spam on servers";
            // 
            // TB_addServer
            // 
            this.TB_addServer.Location = new System.Drawing.Point(88, 182);
            this.TB_addServer.Name = "TB_addServer";
            this.TB_addServer.Size = new System.Drawing.Size(177, 20);
            this.TB_addServer.TabIndex = 2;
            // 
            // B_removeServer
            // 
            this.B_removeServer.Location = new System.Drawing.Point(7, 209);
            this.B_removeServer.Name = "B_removeServer";
            this.B_removeServer.Size = new System.Drawing.Size(102, 23);
            this.B_removeServer.TabIndex = 3;
            this.B_removeServer.Text = "Remove server(s)";
            this.B_removeServer.UseVisualStyleBackColor = true;
            this.B_removeServer.Click += new System.EventHandler(this.B_removeServer_Click);
            // 
            // B_addServer
            // 
            this.B_addServer.Location = new System.Drawing.Point(7, 180);
            this.B_addServer.Name = "B_addServer";
            this.B_addServer.Size = new System.Drawing.Size(75, 23);
            this.B_addServer.TabIndex = 1;
            this.B_addServer.Text = "Add server";
            this.B_addServer.UseVisualStyleBackColor = true;
            this.B_addServer.Click += new System.EventHandler(this.B_addServer_Click);
            // 
            // CLB_listServer
            // 
            this.CLB_listServer.FormattingEnabled = true;
            this.CLB_listServer.Location = new System.Drawing.Point(8, 25);
            this.CLB_listServer.Name = "CLB_listServer";
            this.CLB_listServer.Size = new System.Drawing.Size(258, 154);
            this.CLB_listServer.TabIndex = 0;
            // 
            // T_whiteList
            // 
            this.T_whiteList.Controls.Add(this.B_removeAllFromWhiteList);
            this.T_whiteList.Controls.Add(this.B_importFromFile);
            this.T_whiteList.Controls.Add(this.B_exportToFile);
            this.T_whiteList.Controls.Add(this.label3);
            this.T_whiteList.Controls.Add(this.L_whiteList);
            this.T_whiteList.Controls.Add(this.TB_addToWhiteList);
            this.T_whiteList.Controls.Add(this.LB_whiteList);
            this.T_whiteList.Controls.Add(this.B_removeFromWhiteList);
            this.T_whiteList.Controls.Add(this.B_editSelectedWhiteRecord);
            this.T_whiteList.Controls.Add(this.B_addToWhiteList);
            this.T_whiteList.Location = new System.Drawing.Point(4, 22);
            this.T_whiteList.Name = "T_whiteList";
            this.T_whiteList.Padding = new System.Windows.Forms.Padding(3);
            this.T_whiteList.Size = new System.Drawing.Size(308, 417);
            this.T_whiteList.TabIndex = 1;
            this.T_whiteList.Text = "White List Senders";
            this.T_whiteList.UseVisualStyleBackColor = true;
            // 
            // B_removeAllFromWhiteList
            // 
            this.B_removeAllFromWhiteList.Location = new System.Drawing.Point(211, 132);
            this.B_removeAllFromWhiteList.Name = "B_removeAllFromWhiteList";
            this.B_removeAllFromWhiteList.Size = new System.Drawing.Size(91, 23);
            this.B_removeAllFromWhiteList.TabIndex = 11;
            this.B_removeAllFromWhiteList.Text = "Remove All";
            this.B_removeAllFromWhiteList.UseVisualStyleBackColor = true;
            this.B_removeAllFromWhiteList.Click += new System.EventHandler(this.B_removeAllFromWhiteList_Click);
            // 
            // B_importFromFile
            // 
            this.B_importFromFile.Location = new System.Drawing.Point(210, 350);
            this.B_importFromFile.Name = "B_importFromFile";
            this.B_importFromFile.Size = new System.Drawing.Size(91, 23);
            this.B_importFromFile.TabIndex = 10;
            this.B_importFromFile.Text = "Import from file";
            this.B_importFromFile.UseVisualStyleBackColor = true;
            this.B_importFromFile.Click += new System.EventHandler(this.B_importFromFile_Click);
            // 
            // B_exportToFile
            // 
            this.B_exportToFile.Location = new System.Drawing.Point(210, 379);
            this.B_exportToFile.Name = "B_exportToFile";
            this.B_exportToFile.Size = new System.Drawing.Size(91, 23);
            this.B_exportToFile.TabIndex = 9;
            this.B_exportToFile.Text = "Export to file";
            this.B_exportToFile.UseVisualStyleBackColor = true;
            this.B_exportToFile.Click += new System.EventHandler(this.B_exportToFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "example: \"smith@dom.com\" or \"@dom.com\"";
            // 
            // L_whiteList
            // 
            this.L_whiteList.AutoSize = true;
            this.L_whiteList.Location = new System.Drawing.Point(7, 7);
            this.L_whiteList.Name = "L_whiteList";
            this.L_whiteList.Size = new System.Drawing.Size(187, 13);
            this.L_whiteList.TabIndex = 5;
            this.L_whiteList.Text = "Add or remove safe list senders bellow";
            // 
            // TB_addToWhiteList
            // 
            this.TB_addToWhiteList.Location = new System.Drawing.Point(6, 43);
            this.TB_addToWhiteList.Name = "TB_addToWhiteList";
            this.TB_addToWhiteList.Size = new System.Drawing.Size(197, 20);
            this.TB_addToWhiteList.TabIndex = 0;
            this.TB_addToWhiteList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_addToWhiteList_KeyPress);
            // 
            // LB_whiteList
            // 
            this.LB_whiteList.FormattingEnabled = true;
            this.LB_whiteList.Location = new System.Drawing.Point(6, 73);
            this.LB_whiteList.Name = "LB_whiteList";
            this.LB_whiteList.Size = new System.Drawing.Size(197, 329);
            this.LB_whiteList.TabIndex = 2;
            // 
            // B_removeFromWhiteList
            // 
            this.B_removeFromWhiteList.Location = new System.Drawing.Point(210, 103);
            this.B_removeFromWhiteList.Name = "B_removeFromWhiteList";
            this.B_removeFromWhiteList.Size = new System.Drawing.Size(91, 23);
            this.B_removeFromWhiteList.TabIndex = 4;
            this.B_removeFromWhiteList.Text = "Remove";
            this.B_removeFromWhiteList.UseVisualStyleBackColor = true;
            this.B_removeFromWhiteList.Click += new System.EventHandler(this.B_removeFromWhiteList_Click);
            // 
            // B_editSelectedWhiteRecord
            // 
            this.B_editSelectedWhiteRecord.Location = new System.Drawing.Point(210, 73);
            this.B_editSelectedWhiteRecord.Name = "B_editSelectedWhiteRecord";
            this.B_editSelectedWhiteRecord.Size = new System.Drawing.Size(91, 23);
            this.B_editSelectedWhiteRecord.TabIndex = 3;
            this.B_editSelectedWhiteRecord.Text = "Edit";
            this.B_editSelectedWhiteRecord.UseVisualStyleBackColor = true;
            this.B_editSelectedWhiteRecord.Click += new System.EventHandler(this.B_editSelectedWhiteRecord_Click);
            // 
            // B_addToWhiteList
            // 
            this.B_addToWhiteList.Location = new System.Drawing.Point(210, 41);
            this.B_addToWhiteList.Name = "B_addToWhiteList";
            this.B_addToWhiteList.Size = new System.Drawing.Size(91, 23);
            this.B_addToWhiteList.TabIndex = 1;
            this.B_addToWhiteList.Text = "Add";
            this.B_addToWhiteList.UseVisualStyleBackColor = true;
            this.B_addToWhiteList.Click += new System.EventHandler(this.B_addToWhiteList_Click);
            // 
            // T_other
            // 
            this.T_other.Controls.Add(this.groupBox2);
            this.T_other.Location = new System.Drawing.Point(4, 22);
            this.T_other.Name = "T_other";
            this.T_other.Padding = new System.Windows.Forms.Padding(3);
            this.T_other.Size = new System.Drawing.Size(308, 417);
            this.T_other.TabIndex = 2;
            this.T_other.Text = "Other";
            this.T_other.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.B_destinationFile);
            this.groupBox2.Controls.Add(this.TB_pathToErrorLog);
            this.groupBox2.Controls.Add(this.CB_saveError);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 80);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Path to error log";
            // 
            // B_destinationFile
            // 
            this.B_destinationFile.Location = new System.Drawing.Point(199, 44);
            this.B_destinationFile.Name = "B_destinationFile";
            this.B_destinationFile.Size = new System.Drawing.Size(75, 23);
            this.B_destinationFile.TabIndex = 2;
            this.B_destinationFile.Text = "Choose";
            this.B_destinationFile.UseVisualStyleBackColor = true;
            this.B_destinationFile.Click += new System.EventHandler(this.B_destinationFile_Click);
            // 
            // TB_pathToErrorLog
            // 
            this.TB_pathToErrorLog.Location = new System.Drawing.Point(7, 46);
            this.TB_pathToErrorLog.Name = "TB_pathToErrorLog";
            this.TB_pathToErrorLog.Size = new System.Drawing.Size(185, 20);
            this.TB_pathToErrorLog.TabIndex = 1;
            // 
            // CB_saveError
            // 
            this.CB_saveError.AutoSize = true;
            this.CB_saveError.Location = new System.Drawing.Point(8, 21);
            this.CB_saveError.Name = "CB_saveError";
            this.CB_saveError.Size = new System.Drawing.Size(86, 17);
            this.CB_saveError.TabIndex = 0;
            this.CB_saveError.Text = "Write errors?";
            this.CB_saveError.UseVisualStyleBackColor = true;
            this.CB_saveError.CheckedChanged += new System.EventHandler(this.CB_saveError_CheckedChanged);
            // 
            // B_saveSettings
            // 
            this.B_saveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_saveSettings.Location = new System.Drawing.Point(13, 452);
            this.B_saveSettings.Name = "B_saveSettings";
            this.B_saveSettings.Size = new System.Drawing.Size(123, 23);
            this.B_saveSettings.TabIndex = 1;
            this.B_saveSettings.Text = "Save settings";
            this.B_saveSettings.UseVisualStyleBackColor = true;
            this.B_saveSettings.Click += new System.EventHandler(this.B_saveSettings_Click);
            // 
            // B_dontSaveAndExit
            // 
            this.B_dontSaveAndExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_dontSaveAndExit.Location = new System.Drawing.Point(185, 452);
            this.B_dontSaveAndExit.Name = "B_dontSaveAndExit";
            this.B_dontSaveAndExit.Size = new System.Drawing.Size(123, 23);
            this.B_dontSaveAndExit.TabIndex = 2;
            this.B_dontSaveAndExit.Text = "Don\'t save and cancel";
            this.B_dontSaveAndExit.UseVisualStyleBackColor = true;
            this.B_dontSaveAndExit.Click += new System.EventHandler(this.B_dontSaveAndExit_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 481);
            this.Controls.Add(this.B_dontSaveAndExit);
            this.Controls.Add(this.B_saveSettings);
            this.Controls.Add(this.TC_tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings AntySpam Plugin";
            this.TC_tabs.ResumeLayout(false);
            this.T_servers.ResumeLayout(false);
            this.GB_signingSpam.ResumeLayout(false);
            this.GB_signingSpam.PerformLayout();
            this.GB_spamDestination.ResumeLayout(false);
            this.GB_spamDestination.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.T_whiteList.ResumeLayout(false);
            this.T_whiteList.PerformLayout();
            this.T_other.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TC_tabs;
        private System.Windows.Forms.TabPage T_servers;
        private System.Windows.Forms.TabPage T_whiteList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_addServer;
        private System.Windows.Forms.Button B_removeServer;
        private System.Windows.Forms.Button B_addServer;
        private System.Windows.Forms.CheckedListBox CLB_listServer;
        private System.Windows.Forms.TextBox TB_addToWhiteList;
        private System.Windows.Forms.ListBox LB_whiteList;
        private System.Windows.Forms.Button B_removeFromWhiteList;
        private System.Windows.Forms.Button B_editSelectedWhiteRecord;
        private System.Windows.Forms.Button B_addToWhiteList;
        private System.Windows.Forms.Button B_saveSettings;
        private System.Windows.Forms.Button B_dontSaveAndExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_whiteList;
        private System.Windows.Forms.GroupBox GB_signingSpam;
        private System.Windows.Forms.Label L_questionSignedSpam;
        private System.Windows.Forms.TextBox TB_sign;
        private System.Windows.Forms.CheckBox CB_modifySubjectMail;
        private System.Windows.Forms.GroupBox GB_spamDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RB_junkFolder;
        private System.Windows.Forms.Label L_choosedFolder;
        private System.Windows.Forms.RadioButton RB_chooseFolder;
        private System.Windows.Forms.Button B_chooseFolder;
        private System.Windows.Forms.TabPage T_other;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button B_destinationFile;
        private System.Windows.Forms.TextBox TB_pathToErrorLog;
        private System.Windows.Forms.CheckBox CB_saveError;
        private System.Windows.Forms.Button B_importFromFile;
        private System.Windows.Forms.Button B_exportToFile;
        private System.Windows.Forms.Button B_removeAllFromWhiteList;
    }
}