using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoW_Backup_And_Restore {
    public partial class StartupForm : Form {
        private delegate void Local_CheckThread_CheckForCTRLKey();
        private delegate void Local_CheckThread_ThreadComplete();
        private bool CtrlKeyPressed { get; set; }
        private CheckCTRLThread CheckThread { get; set; }
        public StartupForm() {
            InitializeComponent();
            this.KeyDown += StartupForm_KeyDown;
        }

        private void StartupForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control) {
                CtrlKeyPressed = true;
            }
        }
        private void StartupForm_Load(object sender, EventArgs e) {
            CheckThread = new CheckCTRLThread();
            CheckThread.CheckForCTRLKey += CheckThread_CheckForCTRLKey;
            CheckThread.ThreadComplete += CheckThread_ThreadComplete;
            Thread th = new Thread(CheckThread.Start);
            th.SetApartmentState(ApartmentState.MTA);
            th.Start();
        }
        private void CheckThread_ThreadComplete() {
            if (this.InvokeRequired) {
                Local_CheckThread_ThreadComplete lct = new Local_CheckThread_ThreadComplete(CheckThread_ThreadComplete);
                this.Invoke(lct);
            } else {
                CheckForCtrlKey();
            }
        }
        private void CheckThread_CheckForCTRLKey() {
            if (this.InvokeRequired) {
                Local_CheckThread_CheckForCTRLKey lcc = new Local_CheckThread_CheckForCTRLKey(CheckThread_CheckForCTRLKey);
                this.Invoke(lcc);
            } else {
                CheckThread.StopThread = CtrlKeyPressed;
            }
        }
        private void CheckForCtrlKey() {
            if (CtrlKeyPressed) {
                SettingsWorker.mainForm.Show();
                this.Close();
            } else {
                if (SettingsWorker.Settings.AutoStartWoW && !CtrlKeyPressed) {
                    WoWBackup.StartAutoBackup();
                    this.Close();
                } else {
                    SettingsWorker.mainForm.Show();
                    this.Close();
                }
            }
        }
    }

    public class CheckCTRLThread {
        public delegate void CheckForCTRLKeyDelegate();
        public event CheckForCTRLKeyDelegate CheckForCTRLKey;
        public delegate void ThreadCompleteDelegate();
        public event ThreadCompleteDelegate ThreadComplete;
        public int StopCheckCount { get; set; }
        public bool StopThread { get; set; }
        public CheckCTRLThread() {
            StopCheckCount = 0;
        }
        public void Start() {
            CheckForStop();
        }
        public void CheckForStop() {
            if (StopCheckCount < 5 && !StopThread) {
                CheckForCTRLKey();
                StopCheckCount++;
                Thread.Sleep(1000);
                CheckForStop();
            } else {
                ThreadComplete();
            }
        }
    }
}
