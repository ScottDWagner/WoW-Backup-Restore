
namespace WoW_Backup_And_Restore {
    partial class RestoreWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreWindow));
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.ChooseBackupFileButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.BackupDateTimeLabel = new System.Windows.Forms.Label();
            this.BackupFirstCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FileNameLabel.ForeColor = System.Drawing.Color.White;
            this.FileNameLabel.Location = new System.Drawing.Point(11, 11);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(65, 19);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "FileName";
            // 
            // ChooseBackupFileButton
            // 
            this.ChooseBackupFileButton.Location = new System.Drawing.Point(9, 67);
            this.ChooseBackupFileButton.Name = "ChooseBackupFileButton";
            this.ChooseBackupFileButton.Size = new System.Drawing.Size(86, 20);
            this.ChooseBackupFileButton.TabIndex = 1;
            this.ChooseBackupFileButton.Text = "Choose File";
            this.ChooseBackupFileButton.UseVisualStyleBackColor = true;
            this.ChooseBackupFileButton.Click += new System.EventHandler(this.ChooseBackupFileButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Enabled = false;
            this.RestoreButton.Location = new System.Drawing.Point(208, 66);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(86, 20);
            this.RestoreButton.TabIndex = 2;
            this.RestoreButton.Text = "Restore Backup";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // BackupDateTimeLabel
            // 
            this.BackupDateTimeLabel.AutoSize = true;
            this.BackupDateTimeLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackupDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.BackupDateTimeLabel.Location = new System.Drawing.Point(11, 35);
            this.BackupDateTimeLabel.Name = "BackupDateTimeLabel";
            this.BackupDateTimeLabel.Size = new System.Drawing.Size(111, 19);
            this.BackupDateTimeLabel.TabIndex = 3;
            this.BackupDateTimeLabel.Text = "BackupDateTime";
            // 
            // BackupFirstCheckBox
            // 
            this.BackupFirstCheckBox.AutoSize = true;
            this.BackupFirstCheckBox.ForeColor = System.Drawing.Color.White;
            this.BackupFirstCheckBox.Location = new System.Drawing.Point(111, 69);
            this.BackupFirstCheckBox.Name = "BackupFirstCheckBox";
            this.BackupFirstCheckBox.Size = new System.Drawing.Size(85, 17);
            this.BackupFirstCheckBox.TabIndex = 4;
            this.BackupFirstCheckBox.Text = "Backup First";
            this.BackupFirstCheckBox.UseVisualStyleBackColor = true;
            // 
            // RestoreWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(306, 99);
            this.Controls.Add(this.BackupFirstCheckBox);
            this.Controls.Add(this.BackupDateTimeLabel);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.ChooseBackupFileButton);
            this.Controls.Add(this.FileNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore Backup";
            this.Load += new System.EventHandler(this.RestoreWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Button ChooseBackupFileButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Label BackupDateTimeLabel;
        private System.Windows.Forms.CheckBox BackupFirstCheckBox;
    }
}