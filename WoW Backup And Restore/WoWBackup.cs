using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoW_Backup_And_Restore {
    public static class WoWBackup {
        private delegate void Local_Bw_BackupError(Exception ex);
        private delegate void Local_Bw_BackupComplete();
        private delegate void Local_Bw_RetoreStarted();
        private static RestoreWindow RestWindow { get; set; }
        public static StatusWindow statWindow { get; set; }
        public static void StartAutoBackup() {
            DirectoryInfo di = new DirectoryInfo(SettingsWorker.Settings.BackupFolder);
            DateTime newestFile = new DateTime(1970, 1, 1);
            List<FileInfo> Files = di.GetFiles().ToList();
            if (Files.Count > 0) {
                foreach (FileInfo fi in Files) {
                    DateTime biCd = BackupInfoWorker.GetBackupCreation(fi);
                    if (biCd > newestFile) {
                        newestFile = biCd;
                    }
                }
                if (SettingsWorker.Settings.DaysBetweenBackups < 1) {
                    SettingsWorker.Settings.DaysBetweenBackups = 1;
                }
                newestFile = newestFile.AddDays(SettingsWorker.Settings.DaysBetweenBackups);
                if (newestFile <= DateTime.Now) {
                    StartBackup();
                } else {
                    SettingsWorker.mainForm.Hide();
                    AutoStartAndQuit();
                }
            } else {
                StartBackup();
            }
        }
        public static void StartBackupWithFileName(FileInfo restoreFile, FileInfo backupFile, RestoreWindow rw, bool BackupFirst) {
            RestWindow = rw;
            statWindow = new StatusWindow();
            statWindow.StatusLabel.Text = "Backing Up";
            BackupWorker bw = new BackupWorker(SettingsWorker.Settings, true, restoreFile, backupFile);
            bw.BackupComplete += Bw_BackupComplete;
            bw.BackupError += Bw_BackupError;
            bw.RestoreStarted += Bw_RestoreStarted;
            bw.BackupBeforeRestore = BackupFirst;
            Thread th = new Thread(bw.StartRestore);
            th.SetApartmentState(ApartmentState.MTA);
            th.Start();
            statWindow.ShowDialog();
        }

        private static void Bw_RestoreStarted() {
            if (statWindow.InvokeRequired) {
                Local_Bw_RetoreStarted lbr = new Local_Bw_RetoreStarted(Bw_RestoreStarted);
                statWindow.Invoke(lbr);
            } else {
                statWindow.StatusLabel.Text = "Restoring Backup";
            }
        }

        public static void StartBackup() {
            statWindow = new StatusWindow();
            statWindow.StatusLabel.Text = "Backing Up";
            BackupWorker bw = new BackupWorker(SettingsWorker.Settings,false);
            bw.BackupComplete += Bw_BackupComplete;
            bw.BackupError += Bw_BackupError;
            Thread th = new Thread(bw.Start);
            th.SetApartmentState(ApartmentState.MTA);
            th.Start();
            statWindow.ShowDialog();
        }
        private static void Bw_BackupError(Exception ex) {
            if (statWindow.InvokeRequired) {
                Local_Bw_BackupError be = new Local_Bw_BackupError(Bw_BackupError);
                statWindow.Invoke(be, new object[] { ex });
            } else {
                MessageBox.Show("Error Backing Up: " + ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private static void Bw_BackupComplete() {
            if (statWindow.InvokeRequired) {
                Local_Bw_BackupComplete bc = new Local_Bw_BackupComplete(Bw_BackupComplete);
                statWindow.Invoke(bc);
            } else {
                BackupComplete();
            }
        }

        private static void AutoStartAndQuit() {
            if (SettingsWorker.Settings.AutoStartWoW) {
                DirectoryInfo di = new DirectoryInfo(SettingsWorker.Settings.WoWFolder);
                DirectoryInfo dip = di.Parent;
                DirectoryInfo bNetFold = new DirectoryInfo(Path.Combine(dip.FullName, "Battle.net"));
                if (bNetFold.Exists) {
                    FileInfo fi = new FileInfo(Path.Combine(bNetFold.FullName, "Battle.net Launcher.exe"));
                    if (fi.Exists) {
                        Process.Start(fi.FullName);
                        if (SettingsWorker.Settings.AutoQuitApp) {
                            Application.Exit();
                        } else {
                            SettingsWorker.mainForm.Show();
                        }
                    }
                }
            }
        }

        private static void BackupComplete() {
            statWindow.Close();
            statWindow.Dispose();
            statWindow = null;
            if (RestWindow != null) {
                RestWindow.BackupComplete();
                RestWindow = null;
            }
        }
    }
}
