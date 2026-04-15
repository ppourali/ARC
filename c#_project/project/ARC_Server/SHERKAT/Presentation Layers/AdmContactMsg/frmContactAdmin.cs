using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Net;
using Mehr.Presentation_Layers.AdmContactMsg;

namespace Mehr
{
    public partial class FrmContactAdmin : Form
    {

        MailMessage mail = new MailMessage();

        private Boolean sendPressed = false;

        private Boolean msgSent = false;
        public string darmangahName;
        string RAR_PATH = "";
        string current_time = "";
        string current_date = "";
        string destFilePath = "";
        private Boolean chk1, chk2, chk3,chkBackUpCreated;
        public FrmContactAdmin()
        {
            InitializeComponent();

            //otherwise will throw an exception when calling ReportProgress method
            backgroundWorker1.WorkerReportsProgress = true;

            //mandatory. Otherwise we would get an InvalidOperationException when trying to cancel the operation
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (InternetCS.IsConnected())
            {
                msgSent = false;
                sendPressed = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("لطفا از اتصال سیستم به شبکه اینترنت اطمینان حاصل نمایید");
            }

        }

        private bool isSizeOfAttachMentsAllowed()
        {
            long sumAttSizes=0;

            long maxAllowed;
                maxAllowed = 20000000;


            if ((chkSendBackup.Checked || chkSendLog.Checked || txtAttachedFiles.Text.Trim() != "") && System.IO.File.Exists(destFilePath))
            {
                FileInfo fi = new FileInfo(destFilePath);
                sumAttSizes += fi.Length;
            }

            if (sumAttSizes > maxAllowed)
                return false;
            else
                return true;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if ((openFileDialog1.ShowDialog()) == DialogResult.OK)
            {
                txtAttachedFiles.Text = "";
                foreach (string f in openFileDialog1.FileNames)
                {
                    txtAttachedFiles.Text += (f + ";");
                }
            }
        }

        private bool CompressionProcess(bool chkBackUpCreated)
        {
            bool compressedOrNot = false;
            string ext = "";
            try
            {


                if (System.IO.File.Exists(destFilePath + ".rar"))
                    System.IO.File.Delete((destFilePath + ".rar"));

                string cmdLine = "";
                string[] attachedFileName = txtAttachedFiles.Text.Split(';');
                foreach (string a in attachedFileName)
                {
                    if (a.Trim() != "")
                    {
                        cmdLine += (" " + "\"" + a + "\"");
                    }
                }

                if (chkSendLog.Checked)
                {
                    cmdLine = cmdLine + (" " + "\"" + (Application.StartupPath + "\\err.log") + "\"");
                }

                if (chkBackUpCreated)
                {
                    cmdLine = cmdLine + (" " + "\"" + (Application.StartupPath + "\\Backup\\" + "Adm_Contact_" + current_date + ".bak") + "\"");
                }

                if (cmdLine.Trim() != "")
                {
                    CompressToRar(cmdLine.Trim());
                    ext = ".rar";
                    compressedOrNot = true;
                }
                else
                {
                    compressedOrNot = false;
                }
            }
            catch (Exception ex)
            {
                mydataaccess.Log(ex);
                MessageBox.Show("در انجام عملیات فشرده سازی مشکلی رخ داده است");
            }


            destFilePath += ext;
            return compressedOrNot;
        }

        private void CompressToRar(string filePath)
        {

            string cmdArgs1 = string.Format("A -ep1 {0} {1}", "\"" + destFilePath + ".rar" + "\"" , filePath);

            Process process1 = new Process();
            process1.StartInfo.FileName = String.Format("\"{0}\"", RAR_PATH);
            process1.StartInfo.Arguments = cmdArgs1;
            Clipboard.SetText(cmdArgs1);
            process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process1.Start();
            process1.WaitForExit();
            process1.Close();
            process1.Dispose();
        }

        private void CompressToZip(FileInfo fi)
        {
            // Get the stream of the source file. 
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and already compressed files. 
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden)
                        != FileAttributes.Hidden)
                {
                    // Create the compressed file. 
                    using (FileStream outFile = File.Create(destFilePath + ".zip"))
                    {
                        using (GZipStream Compress = new GZipStream(outFile,
                                CompressionMode.Compress))
                        {
                            // Copy the source file into the compression stream.
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                Compress.Write(buffer, 0, numRead);
                            }
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            //cboCompressor.Enabled = false;
            

        }

        private bool winrarIsExists()
        {
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe"))
            {

                if (Key == null)
                {
                    RAR_PATH = "";
                    return false;
                }
                else
                {
                    RAR_PATH = Key.GetValue("Path").ToString() + @"\winrar.exe";
                    return true;
                }
            }
        }

        private void getDateTimeForName()
        {
            string d, m, y;
            d = DateTime.Today.Date.Day.ToString();
            m = DateTime.Today.Date.Month.ToString();
            y = DateTime.Today.Date.Year.ToString();
            current_time = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo).Trim();
            current_date = Shamsi(y + '/' + m + '/' + d).Trim();
        }

        private string Shamsi(string date)
        {
            int[] arrMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] arrStart = { 21, 20, 21, 21, 22, 22, 23, 23, 23, 23, 22, 22 };
            char[] sep = { '/' };
            string[] arrDate = date.Split(sep);
            int year = Convert.ToInt32(arrDate[0]);
            int month = Convert.ToInt32(arrDate[1]);
            int day = Convert.ToInt32(arrDate[2]);
            if (year % 4 == 0)
            {
                for (int i = 2; i < 12; i++)
                    arrStart[i]--;
                arrMonths[1]++;
                if (month == 1) arrStart[11]++;
            }
            else if (year % 4 == 1)
            {
                arrStart[0]--;
                arrStart[1]--;
                if (month == 1) arrStart[11]--;
            }
            year = month <= 3 ? year - 622 : year - 621;
            if (month == 3 && day >= arrStart[2]) year++;
            if (day < arrStart[month - 1])
            {
                int i = month == 1 ? 11 : month - 2;
                day = day - arrStart[i] + arrMonths[i] + 1;
                month -= 3;
            }
            else
            {
                day = day - arrStart[month - 1] + 1;
                month -= 2;
            }
            if (month <= 0) month += 12;
            return year + "." + Convert.ToString(month).PadLeft(2, '0') + "." +
            Convert.ToString(day).PadLeft(2, '0');

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            getDateTimeForName();

            chk1 = chk2 = chk3= chkBackUpCreated = false;

            backgroundWorker1.ReportProgress(30);
            backgroundWorker1.ReportProgress(50);
            backgroundWorker1.ReportProgress(70);
            backgroundWorker1.ReportProgress(100);
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                progressBar1.Value = e.ProgressPercentage - 15; //update progress bar
                Thread.Sleep(100);

                if (e.ProgressPercentage == 30)
                {
                    EnableOrDisableControlsForSendingMail(false);
                    lblState.Text = "در حال تهیه ی فایل پشتیبان";
                    return;
                }

                if (chk1 == false)
                {
                    if (chkSendBackup.Checked)
                    {
                        chkBackUpCreated = createBackup();
                    }

                    chk1 = true;
                    lblState.Text = "در حال فشرده سازی فایل های ضمیمه";
                    return;
                }
                if (chk2 == false)
                {
                    destFilePath = (Application.StartupPath + "\\" + "Adm_Contact_" + current_date);
                    bool compressed = CompressionProcess(chkBackUpCreated);
                    chk2 = true;
                    if (compressed)
                        lblState.Text = "در حال انجام عملیات ضمیمه سازی و ارسال پیام";
                    return;
                }

                if (chk3 == false)
                {

                    if (!isSizeOfAttachMentsAllowed())
                    {
                        MessageBox.Show("حجم فایل های ضمیمه بیشتر از حجم مجاز می باشد، لطفا بررسی نمایید");
                        lblState.Text = "خطای حجم فایل های ضمیمه";
                        EnableOrDisableControlsForSendingMail(true);
                        
                    }
                    else
                    {
                        mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Port = 587;
                       
                            SmtpServer.Host = "smtp.gmail.com";
                            mail.From = new MailAddress("emailforarc@gmail.com");
                            SmtpServer.Credentials = new System.Net.NetworkCredential("emailforarc@gmail.com", "arc12345");
                            SmtpServer.EnableSsl = true;
                       
                        mail.To.Add("parsareddevil@gmail.com");
                        mail.Subject = "Contact From ARC: " + txtSubject.Text;
                        mail.Body = txtBody.Text + "\r\n\r\n\r\n" + darmangahName;

                        if (destFilePath.EndsWith(".rar"))
                        {
                            System.Net.Mail.Attachment attachment;
                            attachment = new System.Net.Mail.Attachment(destFilePath.Trim());
                            mail.Attachments.Add(attachment);
                        }
                        else if (destFilePath.EndsWith(".zip"))
                        {
                            if (chkSendLog.Checked)
                            {
                                System.Net.Mail.Attachment attachment;
                                attachment = new System.Net.Mail.Attachment((Application.StartupPath + "\\err.log"));
                                mail.Attachments.Add(attachment);
                            }

                            if (chkBackUpCreated)
                            {
                                System.Net.Mail.Attachment attachment;
                                attachment = new System.Net.Mail.Attachment(destFilePath.Trim());
                                mail.Attachments.Add(attachment);
                            }


                            string[] attachedFileName = txtAttachedFiles.Text.Split(';');
                            foreach (string a in attachedFileName)
                            {
                                if (a.Trim() != "")
                                {
                                    System.Net.Mail.Attachment attachment;
                                    attachment = new System.Net.Mail.Attachment(a);
                                    mail.Attachments.Add(attachment);
                                }

                            }
                        }

                        SmtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                        SmtpServer.SendAsync(mail, "Sending Msg");
                        //mail.Dispose();

                        lblState.Text = "لطفا صبر نمایید، سرعت اتمام عملیات به سرعت اینترنت سیستم شما بستگی دارد.";
                    }
                    chk3 = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                mydataaccess.Log(ex);
                MessageBox.Show("ارسال پیام با مشکل مواجه شد");
                btnSend.Visible = true;
                backgroundWorker1.CancelAsync();

            }
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            

            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                lblState.Text = "ارسال پیام لغو شد";
            }
            else
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.ToString());
                }
                else
                {
                    lblState.Text = "پیام با موفقیت ارسال شد";
                    progressBar1.Value = 100;
                }
                mail.Dispose();
                msgSent = true;
                EnableOrDisableControlsForSendingMail(true);
                try
                {
                    System.IO.File.Delete(Application.StartupPath + "\\Backup\\" + "Adm_Contact_" + current_date + ".bak");
                }
                catch
                {
                }

                try
                {
                    System.IO.File.Delete(destFilePath.Trim());
                }
                catch
                {
                }

                sendPressed = false;



            }
        }

        private void EnableOrDisableControlsForSendingMail(bool p)
        {
            btnSend.Visible = p;
            txtSubject.Enabled = p;
            txtAttachedFiles.Enabled = p;
            btnBrowse.Enabled = p;
            txtBody.Enabled = p;
            chkSendBackup.Enabled = p;
            chkSendLog.Enabled = p;

            if (p)
            {
                mail.Dispose();
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Dispose();                
            }
        }

        private bool createBackup()
        {
            if (System.IO.Directory.Exists(Application.StartupPath + @"\Backup"))
            {
                string a = Application.StartupPath + "\\Backup\\" + "Adm_Contact_" + current_date + ".bak";

                try
                {

                    if (System.IO.File.Exists(a))
                        System.IO.File.Delete((a));

                    DB back = new DB();
                    back.path = a;
                    back.Backup_name = "Adm_Contact_" + current_date + "-" + DateTime.Now.ToLongTimeString().Substring(0, 8);
                    back.CreateBackup();

                    return true;

                }
                catch (Exception ex)
                {
                    mydataaccess.Log(ex);
                    MessageBox.Show("تهیه فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Backup");
                string a = Application.StartupPath + "\\Backup\\" + "Adm_Contact_" + current_date + ".bak";

                try
                {
                    if (System.IO.File.Exists(a))
                        System.IO.File.Delete((a));

                    DB back = new DB();
                    back.path = a;
                    back.Backup_name = "Adm_Contact_" + current_date + "-" + DateTime.Now.ToLongTimeString().Substring(0, 8);
                    back.CreateBackup();

                    return true;
                }
                catch (Exception ex)
                {
                    mydataaccess.Log(ex);
                    MessageBox.Show("تهیه فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblState.Text = "ارسال پیام با مشکل مواجه شد";
            }
            else if (e.Error != null)
            {
                lblState.Text = "ارسال پیام با مشکل مواجه شد";
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
            }
            sendPressed = false;


        }


        private void frmContactAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sendPressed == false)
                this.Dispose();

            if (msgSent == false && btnSend.Visible==false)
            {
                DialogResult dr;
                dr = MessageBox.Show("با بستن پنجره عملیات ارسال پیام لغو می شود، آیا اطمینان دارید؟", "بستن", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        private void EnterAction(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.FromArgb(192, 255, 255);
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.FromArgb(192, 255, 255);
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }

        }
        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            EnableOrDisableControlsForSendingMail(true);

            lblState.Text = "انصراف ارسال پیام";
            progressBar1.Value = 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Updates.ChangeAgeToB_date();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            openLink();
        }


        private void openLink()
        {
            System.Diagnostics.Process.Start("https://github.com/ppourali/Execs/blob/main/ARC/latest");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLink();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updates.normalizePayanDates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updates.fixMaaliTashkhis();
        }

        private void chkSendLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSendLog.Checked)
                if (!System.IO.File.Exists(Application.StartupPath + "\\err.log"))
                {
                    MessageBox.Show("فایل لاگ خطاها موجود نمی باشد لطفا بررسی نمایید");
                    chkSendLog.Checked = false;
                }
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmContactAdmin_Shown(object sender, EventArgs e)
        {
            if (!winrarIsExists())
            {
                DialogResult dr = MessageBox.Show("To use this component, Winrar has to be installed on this machine. Do you want to locate it?", "WinRAR not Found", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    this.Dispose();
                else
                {
                    winrarLocator.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);
                    if (winrarLocator.ShowDialog() == DialogResult.OK)
                        RAR_PATH = winrarLocator.FileName;
                    else
                        this.Close();
                }
            }
        }

    }
}