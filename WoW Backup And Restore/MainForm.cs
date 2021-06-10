using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WoW_Backup_And_Restore {
    public partial class MainForm : Form {
        private StatusWindow statWindow { get; set; }
        public MainForm() {
            InitializeComponent();
        }

        public void KillApp() {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            SettingsWorker.mainForm = this;
            if (SettingsWorker.Settings.AutoStartWoW && SettingsWorker.Settings.AutoQuitApp) {
                StartupForm sf = new StartupForm();
                sf.ShowDialog();
                this.Hide();
            } else if (SettingsWorker.Settings.BackupFolder.Length > 0 && SettingsWorker.Settings.WoWFolder.Length > 0 & SettingsWorker.Settings.DaysBetweenBackups >0) {
                WoWBackup.StartAutoBackup();
            }
            WoWFolderBox.Text = SettingsWorker.Settings.WoWFolder;
            NumDaysBetweenBackups.Value = SettingsWorker.Settings.DaysBetweenBackups;
            BackupFolderBox.Text = SettingsWorker.Settings.BackupFolder;
            NumberOfBackupsBox.Value = SettingsWorker.Settings.BackupCount;
            AutoStartWowCheckBox.Checked = SettingsWorker.Settings.AutoStartWoW;
            if (!AutoStartWowCheckBox.Checked) {
                QuitWhenCompleteCheckBox.Checked = false;
            } else {
                SettingsWorker.Settings.AutoQuitApp = QuitWhenCompleteCheckBox.Checked;
            }
            ValidateFields();
            WoWFolderBox.TextChanged += Settings_Changed;
            BackupFolderBox.TextChanged += Settings_Changed;
            NumberOfBackupsBox.ValueChanged += Settings_Changed;
            AutoStartWowCheckBox.CheckedChanged += Settings_Changed;
            QuitWhenCompleteCheckBox.CheckedChanged += Settings_Changed;
            NumDaysBetweenBackups.ValueChanged += Settings_Changed;
        }

        private void Settings_Changed(object sender, EventArgs e) {
            SettingsWorker.Settings.WoWFolder = WoWFolderBox.Text;
            SettingsWorker.Settings.DaysBetweenBackups = Convert.ToInt32(NumDaysBetweenBackups.Value);
            SettingsWorker.Settings.BackupFolder = BackupFolderBox.Text;
            SettingsWorker.Settings.BackupCount = Convert.ToInt32(NumberOfBackupsBox.Value);
            SettingsWorker.Settings.AutoStartWoW = AutoStartWowCheckBox.Checked;
            if (!AutoStartWowCheckBox.Checked) {
                QuitWhenCompleteCheckBox.Checked = false;
            } else {
                SettingsWorker.Settings.AutoQuitApp = QuitWhenCompleteCheckBox.Checked;
            }
            ValidateFields();
            SettingsWorker.SaveSettings();
        }

        private bool ValidateFields() {
            bool Validated = true;
            if (WoWFolderBox.Text.Length < 1 || !Directory.Exists(WoWFolderBox.Text)) {
                Validated = false;
                WoWFolderLabel.ForeColor = Color.Red;
                AutoStartWowCheckBox.Checked = false;
                QuitWhenCompleteCheckBox.Checked = false;
            } else {
                WoWFolderLabel.ForeColor = Color.White;
            }
            if (BackupFolderBox.Text.Length < 1 || !Directory.Exists(BackupFolderBox.Text)) {
                Validated = false;
                BackupFolderLabel.ForeColor = Color.Red;
                AutoStartWowCheckBox.Checked = false;
                QuitWhenCompleteCheckBox.Checked = false;
            } else {
                BackupFolderLabel.ForeColor = Color.White;
            }
            BackupNowButton.Enabled = Validated;
            RestoreBackupButton.Enabled = Validated;
            return Validated;
        }

        private void BackupNowButton_Click(object sender, EventArgs e) {
            if (ValidateFields()) {
                WoWBackup.StartBackup();
            }
        }

        private void RestoreBackupButton_Click(object sender, EventArgs e) {
            RestoreWindow rw = new RestoreWindow();
            rw.ShowDialog();
        }

        private void Choose_Button_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = WoWFolderBox.Text;
            if (fbd.ShowDialog() == DialogResult.OK) {
                WoWFolderBox.Text = fbd.SelectedPath;
                SettingsWorker.Settings.WoWFolder = fbd.SelectedPath;
                SettingsWorker.SaveSettings();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = BackupFolderBox.Text;
            if (fbd.ShowDialog() == DialogResult.OK) {
                BackupFolderBox.Text = fbd.SelectedPath;
                SettingsWorker.Settings.BackupFolder = fbd.SelectedPath;
                SettingsWorker.SaveSettings();
            }
        }
    }
}
