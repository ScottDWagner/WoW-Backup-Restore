using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoW_Backup_And_Restore {
    public partial class RestoreWindow : Form {
        private delegate void Local_Bw_BackupError(Exception ex);
        private delegate void Local_Bw_BackupComplete();
        private bool HasBackupError { get; set; }
        private FileInfo BackupFile { get; set; }
        public RestoreWindow() {
            InitializeComponent();
        }

        private void RestoreWindow_Load(object sender, EventArgs e) {
            FileNameLabel.Text = "";
            BackupDateTimeLabel.Text = "";
        }

        private void ChooseBackupFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WoW Backups|*.wowb";
            ofd.InitialDirectory = SettingsWorker.Settings.BackupFolder;
            if (ofd.ShowDialog() == DialogResult.OK) {
                BackupFile = new FileInfo(ofd.FileName);
                if (BackupFile.Exists) {
                    DateTime dt = BackupInfoWorker.GetBackupCreation(BackupFile);
                    FileNameLabel.Text = BackupFile.Name;
                    BackupDateTimeLabel.Text = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                    RestoreButton.Enabled = true;
                }
            }
        }

        private void BackupCurrent() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WoW Backups|*.wowb";
            if (sfd.ShowDialog() == DialogResult.OK) {
                FileInfo fi = new FileInfo(sfd.FileName);
                WoWBackup.StartBackupWithFileName(BackupFile, fi, this, BackupFirstCheckBox.Checked);
            }
        }
        public void BackupComplete() {
            MessageBox.Show("Restore Complete");
        }
        private void RestoreButton_Click(object sender, EventArgs e) {
            if (BackupFirstCheckBox.Checked) {
                BackupCurrent();
            } else {
                WoWBackup.StartBackupWithFileName(BackupFile, null, this, BackupFirstCheckBox.Checked);
            }
        }
    }
}
