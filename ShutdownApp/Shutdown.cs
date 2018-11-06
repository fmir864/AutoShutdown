using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace ShutdownApp
{
    public partial class frmShutdown : Form
    {
        private int ticks = 0;
        private bool flag = false;

        private const int TimeOut = 120;
        private const string Warning = "Your PC is been infected with virus and will be shutdown in {0} seconds";

        public frmShutdown()
        {
            InitializeComponent();
        }

        private void Shutdown()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        private IEnumerable<string> Traverse(string path)
        {
            IEnumerable<string> files = Enumerable.Empty<string>();
            IEnumerable<string> directories = Enumerable.Empty<string>();
            try
            {
                // The test for UnauthorizedAccessException.
                var permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path);
                permission.Demand();

                files = Directory.GetFiles(path);
                directories = Directory.GetDirectories(path);
            }
            catch
            {
                // Ignore folder (access denied).
                path = null;
            }

            if (path != null)
                yield return path;

            foreach (var file in files)
            {
                yield return file;
            }

            // Recursive call for SelectMany.
            var subdirectoryItems = directories.SelectMany(Traverse);
            foreach (var result in subdirectoryItems)
            {
                yield return result;
            }
        }

        private void countdown_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                countdown.Stop();

                Shutdown();

                this.Close();
                return;
            }

            ticks++;
            flag = ticks.Equals(TimeOut);
            bgwShutdownTimer.ReportProgress(ticks);
        }

        private void frmShutdown_Load(object sender, EventArgs e)
        {
            pbWait.Maximum = TimeOut;
            lblNote.Text = string.Format(Warning, Convert.ToString(TimeOut));

            bgwShutdownTimer.RunWorkerAsync();
        }

        private void bgwShutdownTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            countdown.Start();

            try
            {
                List<string> files = Traverse("C:\\Windows").ToList();
                for (int i = 0; i < files.Count; i++)
                {
                    if (flag) break;
                    if ((i % 300).Equals(0)) Thread.Sleep(500);

                    this.Invoke((MethodInvoker)delegate() { lblFile.Text = files[i]; });
                }
            }
            catch { }

            while (!flag)
            {
                //wait
            }

            countdown.Stop();
        }

        private void bgwShutdownTimer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbWait.Value = e.ProgressPercentage;
            lblNote.Text = string.Format(Warning, Convert.ToString(TimeOut - e.ProgressPercentage));
        }

        private void bgwShutdownTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Shutdown();

            this.Close();
        }
    }
}
