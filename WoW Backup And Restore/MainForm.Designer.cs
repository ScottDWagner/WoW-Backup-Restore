
namespace WoW_Backup_And_Restore {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.WoWFolderBox = new System.Windows.Forms.TextBox();
            this.WoWFolderLabel = new System.Windows.Forms.Label();
            this.Choose_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BackupFolderLabel = new System.Windows.Forms.Label();
            this.BackupFolderBox = new System.Windows.Forms.TextBox();
            this.NumberOfBackupsBox = new System.Windows.Forms.NumericUpDown();
            this.NumBackupsLabel = new System.Windows.Forms.Label();
            this.BackupNowButton = new System.Windows.Forms.Button();
            this.AutoStartWowCheckBox = new System.Windows.Forms.CheckBox();
            this.QuitWhenCompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.RestoreBackupButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NumDaysBetweenBackups = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBackupsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumDaysBetweenBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WoWFolderBox
            // 
            this.WoWFolderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WoWFolderBox.Location = new System.Drawing.Point(10, 25);
            this.WoWFolderBox.Name = "WoWFolderBox";
            this.WoWFolderBox.Size = new System.Drawing.Size(458, 21);
            this.WoWFolderBox.TabIndex = 2;
            // 
            // WoWFolderLabel
            // 
            this.WoWFolderLabel.AutoSize = true;
            this.WoWFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WoWFolderLabel.ForeColor = System.Drawing.Color.White;
            this.WoWFolderLabel.Location = new System.Drawing.Point(11, 6);
            this.WoWFolderLabel.Name = "WoWFolderLabel";
            this.WoWFolderLabel.Size = new System.Drawing.Size(84, 15);
            this.WoWFolderLabel.TabIndex = 3;
            this.WoWFolderLabel.Text = "WoW Folder";
            // 
            // Choose_Button
            // 
            this.Choose_Button.Location = new System.Drawing.Point(417, 49);
            this.Choose_Button.Name = "Choose_Button";
            this.Choose_Button.Size = new System.Drawing.Size(51, 20);
            this.Choose_Button.TabIndex = 4;
            this.Choose_Button.Text = "Choose";
            this.Choose_Button.UseVisualStyleBackColor = true;
            this.Choose_Button.Click += new System.EventHandler(this.Choose_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BackupFolderLabel
            // 
            this.BackupFolderLabel.AutoSize = true;
            this.BackupFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupFolderLabel.ForeColor = System.Drawing.Color.White;
            this.BackupFolderLabel.Location = new System.Drawing.Point(11, 67);
            this.BackupFolderLabel.Name = "BackupFolderLabel";
            this.BackupFolderLabel.Size = new System.Drawing.Size(99, 15);
            this.BackupFolderLabel.TabIndex = 6;
            this.BackupFolderLabel.Text = "Backup Folder";
            // 
            // BackupFolderBox
            // 
            this.BackupFolderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupFolderBox.Location = new System.Drawing.Point(10, 86);
            this.BackupFolderBox.Name = "BackupFolderBox";
            this.BackupFolderBox.Size = new System.Drawing.Size(458, 21);
            this.BackupFolderBox.TabIndex = 5;
            // 
            // NumberOfBackupsBox
            // 
            this.NumberOfBackupsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfBackupsBox.Location = new System.Drawing.Point(147, 134);
            this.NumberOfBackupsBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumberOfBackupsBox.Name = "NumberOfBackupsBox";
            this.NumberOfBackupsBox.Size = new System.Drawing.Size(72, 21);
            this.NumberOfBackupsBox.TabIndex = 8;
            this.NumberOfBackupsBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NumBackupsLabel
            // 
            this.NumBackupsLabel.AutoSize = true;
            this.NumBackupsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumBackupsLabel.ForeColor = System.Drawing.Color.White;
            this.NumBackupsLabel.Location = new System.Drawing.Point(10, 136);
            this.NumBackupsLabel.Name = "NumBackupsLabel";
            this.NumBackupsLabel.Size = new System.Drawing.Size(136, 15);
            this.NumBackupsLabel.TabIndex = 9;
            this.NumBackupsLabel.Text = "Number of Backups:";
            // 
            // BackupNowButton
            // 
            this.BackupNowButton.Location = new System.Drawing.Point(371, 145);
            this.BackupNowButton.Name = "BackupNowButton";
            this.BackupNowButton.Size = new System.Drawing.Size(97, 20);
            this.BackupNowButton.TabIndex = 10;
            this.BackupNowButton.Text = "Backup Now";
            this.BackupNowButton.UseVisualStyleBackColor = true;
            this.BackupNowButton.Click += new System.EventHandler(this.BackupNowButton_Click);
            // 
            // AutoStartWowCheckBox
            // 
            this.AutoStartWowCheckBox.AutoSize = true;
            this.AutoStartWowCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoStartWowCheckBox.ForeColor = System.Drawing.Color.White;
            this.AutoStartWowCheckBox.Location = new System.Drawing.Point(27, 196);
            this.AutoStartWowCheckBox.Name = "AutoStartWowCheckBox";
            this.AutoStartWowCheckBox.Size = new System.Drawing.Size(124, 19);
            this.AutoStartWowCheckBox.TabIndex = 11;
            this.AutoStartWowCheckBox.Text = "Auto Start WoW";
            this.AutoStartWowCheckBox.UseVisualStyleBackColor = true;
            // 
            // QuitWhenCompleteCheckBox
            // 
            this.QuitWhenCompleteCheckBox.AutoSize = true;
            this.QuitWhenCompleteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitWhenCompleteCheckBox.ForeColor = System.Drawing.Color.White;
            this.QuitWhenCompleteCheckBox.Location = new System.Drawing.Point(27, 220);
            this.QuitWhenCompleteCheckBox.Name = "QuitWhenCompleteCheckBox";
            this.QuitWhenCompleteCheckBox.Size = new System.Drawing.Size(159, 19);
            this.QuitWhenCompleteCheckBox.TabIndex = 12;
            this.QuitWhenCompleteCheckBox.Text = "Auto Quit Application";
            this.QuitWhenCompleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // RestoreBackupButton
            // 
            this.RestoreBackupButton.Location = new System.Drawing.Point(371, 171);
            this.RestoreBackupButton.Name = "RestoreBackupButton";
            this.RestoreBackupButton.Size = new System.Drawing.Size(97, 20);
            this.RestoreBackupButton.TabIndex = 13;
            this.RestoreBackupButton.Text = "Restore Backup";
            this.RestoreBackupButton.UseVisualStyleBackColor = true;
            this.RestoreBackupButton.Click += new System.EventHandler(this.RestoreBackupButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Day(s) Between Backups:";
            // 
            // NumDaysBetweenBackups
            // 
            this.NumDaysBetweenBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDaysBetweenBackups.Location = new System.Drawing.Point(181, 169);
            this.NumDaysBetweenBackups.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumDaysBetweenBackups.Name = "NumDaysBetweenBackups";
            this.NumDaysBetweenBackups.Size = new System.Drawing.Size(36, 21);
            this.NumDaysBetweenBackups.TabIndex = 14;
            this.NumDaysBetweenBackups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 311);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumDaysBetweenBackups);
            this.Controls.Add(this.RestoreBackupButton);
            this.Controls.Add(this.QuitWhenCompleteCheckBox);
            this.Controls.Add(this.AutoStartWowCheckBox);
            this.Controls.Add(this.BackupNowButton);
            this.Controls.Add(this.NumBackupsLabel);
            this.Controls.Add(this.NumberOfBackupsBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackupFolderLabel);
            this.Controls.Add(this.BackupFolderBox);
            this.Controls.Add(this.Choose_Button);
            this.Controls.Add(this.WoWFolderLabel);
            this.Controls.Add(this.WoWFolderBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW Backup Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBackupsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumDaysBetweenBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WoWFolderBox;
        private System.Windows.Forms.Label WoWFolderLabel;
        private System.Windows.Forms.Button Choose_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label BackupFolderLabel;
        private System.Windows.Forms.TextBox BackupFolderBox;
        private System.Windows.Forms.NumericUpDown NumberOfBackupsBox;
        private System.Windows.Forms.Label NumBackupsLabel;
        private System.Windows.Forms.Button BackupNowButton;
        private System.Windows.Forms.CheckBox AutoStartWowCheckBox;
        private System.Windows.Forms.CheckBox QuitWhenCompleteCheckBox;
        private System.Windows.Forms.Button RestoreBackupButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumDaysBetweenBackups;
    }
}

