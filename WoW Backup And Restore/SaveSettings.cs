using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace WoW_Backup_And_Restore {
    public class SaveSettings {
        public string WoWFolder { get; set; }
        public string BackupFolder { get; set; }
        public int BackupCount { get; set; }
        public bool AutoStartWoW { get; set; }
        public bool AutoQuitApp { get; set; }
        public int DaysBetweenBackups { get; set; }
    }
    public static class SettingsWorker {
        public static string SettingsPath = Path.Combine(Path.GetTempPath(), "WoW Backup & Restore", "Settings.conf");
        public static string SettingsDirectoryPath = Path.Combine(Path.GetTempPath(), "WoW Backup & Restore");
        //C:\Users\scott\AppData\Local\Temp\WoW Backup & Restore\
        public static MainForm mainForm { get; set; }
        public static SaveSettings Settings { get; set; }
        public static SaveSettings LoadSavedSettings() {
            Settings = new SaveSettings();
            if (File.Exists(SettingsPath)) {
                XmlSerializer xs = new XmlSerializer(typeof(SaveSettings));
                using (TextReader tr = new StreamReader(SettingsPath)) {
                    Settings = (SaveSettings)xs.Deserialize(tr);
                }
            } else {
                Settings.AutoQuitApp = false;
                Settings.AutoStartWoW = false;
                Settings.BackupCount = 5;
            }
            return Settings;
        }
        public static void SaveSettings() {
            if (File.Exists(SettingsPath)) {
                File.Delete(SettingsPath);
            }
            if (!Directory.Exists(SettingsDirectoryPath)) {
                Directory.CreateDirectory(SettingsDirectoryPath);
            }
            XmlSerializer xs = new XmlSerializer(typeof(SaveSettings));
            using (StreamWriter sw = new StreamWriter(SettingsPath)) {
                xs.Serialize(sw, Settings);
            }
        }
    }
    public class BackupInfo {
        public DateTime CreationTime { get; set; }
    }
    public static class BackupInfoWorker {
        public static BackupInfo OpenBackupFile(StreamReader sr) {
            XmlSerializer xs = new XmlSerializer(typeof(BackupInfo));
            BackupInfo bui = (BackupInfo)xs.Deserialize(sr);
            return bui;
        }
        public static void SaveBackupInfoFile(BackupInfo bi, StreamWriter sw) {
            XmlSerializer xs = new XmlSerializer(typeof(BackupInfo));
            xs.Serialize(sw, bi);
            sw.Close();
        }
        public static DateTime GetBackupCreation(FileInfo fi) {
            DateTime ret = DateTime.Now;
            using (ZipArchive za = ZipFile.Open(fi.FullName, ZipArchiveMode.Read)) {
                foreach (ZipArchiveEntry entry in za.Entries) {
                    if (entry.Name.EndsWith("wowza")) {
                        BackupInfo bui = BackupInfoWorker.OpenBackupFile(new StreamReader(entry.Open()));
                        ret = bui.CreationTime;
                    }
                }
            }
            return ret;
        }
        public static void RemoveOldestBackup() {
            DirectoryInfo di = new DirectoryInfo(SettingsWorker.Settings.BackupFolder);
            FileInfo OldestFile = null;
            DateTime CurOldest = DateTime.Now;
            foreach (FileInfo fi in di.GetFiles()) {
                if (fi.Extension.EndsWith("wowb")) {
                    DateTime fiCT = BackupInfoWorker.GetBackupCreation(fi);
                    if (fiCT < CurOldest) {
                        OldestFile = fi;
                        CurOldest = fiCT;
                    }
                }
            }
            if (OldestFile != null) {
                OldestFile.Delete();
            }
        }
        public static FileInfo GetNextFileName() {
            DirectoryInfo di = new DirectoryInfo(SettingsWorker.Settings.BackupFolder);
            int i = 0;
            foreach (FileInfo fi in di.GetFiles()) {
                if (fi.Extension.EndsWith("wowb")) {
                    i++;
                }
            }
            if ((i + 1) > SettingsWorker.Settings.BackupCount) {
                RemoveOldestBackup();
            }
            BackupInfo bui = new BackupInfo();
            bui.CreationTime = DateTime.Now;
            FileInfo nfi = new FileInfo(Path.Combine(SettingsWorker.Settings.BackupFolder, "WoWBackup-" + bui.CreationTime.Ticks.ToString() + ".wowb"));
            return nfi;
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs) {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName)) {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files) {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }
            if (copySubDirs) {
                foreach (DirectoryInfo subdir in dirs) {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
    public class BackupWorker {
        public delegate void BackupCompleteDelegate();
        public event BackupCompleteDelegate BackupComplete;
        public delegate void BackupErrorDelegate(Exception ex);
        public event BackupErrorDelegate BackupError;
        public delegate void RestoreStartedDelegate();
        public event RestoreStartedDelegate RestoreStarted;
        private SaveSettings Settings { get; set; }
        private DirectoryInfo WoWFolder { get; set; }
        private DirectoryInfo BackupDirectory { get; set; }
        private FileInfo BackupFile { get; set; }
        private FileInfo RestoreFile { get; set; }
        public bool BackupBeforeRestore { get; set; }
        private bool RestoringBackup { get; set; }
        private bool NormalBackup { get; set; }
        public BackupWorker(SaveSettings settings, bool restoringBackup, FileInfo restorFile = null, FileInfo backupFile = null) {
            if (backupFile != null) {
                BackupFile = backupFile;
            }
            if (restorFile != null) {
                RestoreFile = restorFile;
            }
            RestoringBackup = restoringBackup;
            Settings = settings;
        }

        public void Start() {
            try {
                WoWFolder = new DirectoryInfo(Settings.WoWFolder);
                BackupDirectory = new DirectoryInfo(Settings.BackupFolder);
                if (WoWFolder.Exists) {
                    if (!BackupDirectory.Exists) {
                        BackupDirectory.Create();
                    }
                    BackupNow();
                }
            } catch(Exception ex) {
                BackupError(ex);
            }
            BackupComplete();
        }
        public void StartRestore() {
            try {
                WoWFolder = new DirectoryInfo(Settings.WoWFolder);
                BackupDirectory = new DirectoryInfo(Settings.BackupFolder);
                if (BackupBeforeRestore) {
                    if (WoWFolder.Exists) {
                        if (!BackupDirectory.Exists) {
                            BackupDirectory.Create();
                        }
                        BackupNow();
                        RestoreStarted();
                        RestoreBackup();
                    }
                } else {
                    if (WoWFolder.Exists) {
                        RestoreStarted();
                        RestoreBackup();
                    }
                }
            } catch (Exception ex) {
                BackupError(ex);
            }
            BackupComplete();
        }
        private void RestoreBackup() {
            DirectoryInfo WoWFolder = new DirectoryInfo(SettingsWorker.Settings.WoWFolder);
            DirectoryInfo RetailFolder = new DirectoryInfo(Path.Combine(WoWFolder.FullName, "_retail_"));
            DirectoryInfo WTFFolder = new DirectoryInfo(Path.Combine(RetailFolder.FullName, "WTF"));
            DirectoryInfo InterfaceFolder = new DirectoryInfo(Path.Combine(RetailFolder.FullName, "Interface"));
            DirectoryInfo TempFolder = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "WoWRestore"));
            DirectoryInfo TempWTFFolder = new DirectoryInfo(Path.Combine(TempFolder.FullName, "WTF"));
            DirectoryInfo TempInterfaceFolder = new DirectoryInfo(Path.Combine(TempFolder.FullName, "Interface"));
            if (TempFolder.Exists) {
                TempFolder.Delete(true);
            }
            if (InterfaceFolder.Exists) {
                InterfaceFolder.Delete(true);
            }
            if (WTFFolder.Exists) {
                WTFFolder.Delete(true);
            }
            ZipFile.ExtractToDirectory(RestoreFile.FullName, TempFolder.FullName);
            BackupInfoWorker.DirectoryCopy(TempWTFFolder.FullName, WTFFolder.FullName, true);
            BackupInfoWorker.DirectoryCopy(TempInterfaceFolder.FullName, InterfaceFolder.FullName, true);
            TempFolder.Delete(true);
        }
        private void BackupNow() {
            DirectoryInfo TempFolder = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "WoWBackupTempFolder"));
            DirectoryInfo WTFFolder = new DirectoryInfo(Path.Combine(WoWFolder.FullName, "_retail_", "WTF"));
            DirectoryInfo InterfaceFolder = new DirectoryInfo(Path.Combine(WoWFolder.FullName, "_retail_", "Interface"));
            if (WTFFolder.Exists && InterfaceFolder.Exists) {
                if (TempFolder.Exists) {
                    TempFolder.Delete(true);
                } else {
                    TempFolder.Create();
                }
                BackupInfoWorker.DirectoryCopy(WTFFolder.FullName, Path.Combine(TempFolder.FullName, WTFFolder.Name), true);
                BackupInfoWorker.DirectoryCopy(InterfaceFolder.FullName, Path.Combine(TempFolder.FullName, InterfaceFolder.Name), true);
                BackupInfo bi = new BackupInfo();
                bi.CreationTime = DateTime.Now;
                BackupInfoWorker.SaveBackupInfoFile(bi, new StreamWriter(Path.Combine(TempFolder.FullName, "Settings.wowza")));
                if (RestoringBackup && BackupFile != null) {
                    FileInfo NewFile = BackupInfoWorker.GetNextFileName();
                    ZipFile.CreateFromDirectory(TempFolder.FullName, BackupFile.FullName);
                } else {
                    FileInfo NewFile = BackupInfoWorker.GetNextFileName();
                    ZipFile.CreateFromDirectory(TempFolder.FullName, NewFile.FullName);
                }
                TempFolder.Delete(true);
            }
        }
    }
}