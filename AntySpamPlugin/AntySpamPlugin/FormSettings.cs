#region UsingDirective
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.IO;
#endregion

namespace AntySpamPlugin
{
    public partial class FormSettings : Form
    {
        #region Variables
        public List<string> EnableBLS = new List<string>();
        public List<string> DisableBLS = new List<string>();
        public List<string> SafeSenders = new List<string>();
        public bool IsSaveLog = true;
        public string PathToErrorLog = string.Empty;
        public Outlook._Application OutlookApplication;
        public string EntryIDSpamFolder = string.Empty;
        public string EntryIDStoreSpamFolder = string.Empty;
        public string SpamSignWord = string.Empty;
        public string NameSpamChoosedFolder = string.Empty;
        public string ErrorLog = string.Empty;
        #endregion

        /// <summary>
        /// Constructor settings form
        /// </summary>
        /// <param name="enableBLS">list enable black server</param>
        /// <param name="disableBLS">list disable black server</param>
        /// <param name="safeSenders">list safe senders</param>
        /// <param name="iSsaveLog">is save error log</param>
        /// <param name="pathToErrorLog">path to error log</param>
        /// <param name="entryIDSpamFolder">entryID choosed spam folder</param>
        /// <param name="entryIDStoreSpamFolder">entryID store choosed spam folder</param>
        /// <param name="spamSignWord">spam sign word</param>
        /// <param name="nameSpamChoosedFolder">name spam choosed folder</param>
        public FormSettings(List<string> enableBLS,
                            List<string> disableBLS,
                            List<string> safeSenders,
                            bool iSsaveLog,
                            string pathToErrorLog,
                            string entryIDSpamFolder,
                            string entryIDStoreSpamFolder,
                            string spamSignWord,
                            string nameSpamChoosedFolder)
        {
            InitializeComponent();
            EnableBLS = enableBLS;
            DisableBLS = disableBLS;
            SafeSenders = safeSenders;
            IsSaveLog = iSsaveLog;
            PathToErrorLog = pathToErrorLog;
            EntryIDSpamFolder = entryIDSpamFolder;
            EntryIDStoreSpamFolder = entryIDStoreSpamFolder;
            SpamSignWord = spamSignWord;
            NameSpamChoosedFolder = nameSpamChoosedFolder;
            FillCLB();
        }

        /// <summary>
        /// Fill read settings in constructor
        /// </summary>
        private void FillCLB()
        {
            //path to log
            if (IsSaveLog)
            {
                CB_saveError.Checked = true;
                TB_pathToErrorLog.Text = PathToErrorLog;
                TB_pathToErrorLog.Enabled = true;
                B_destinationFile.Enabled = true;
            }
            else
            {
                TB_pathToErrorLog.Enabled = false;
                B_destinationFile.Enabled = false;
            }

            //servers list
            int i = 0;
            if (EnableBLS.Count > 0)
            {
                foreach (string oServer in EnableBLS)
                {
                    CLB_listServer.Items.Add(oServer);
                    CLB_listServer.SetItemChecked(i, true);
                    i++;
                }
            }
            if (DisableBLS.Count > 0)
            {
                foreach (string oServer in DisableBLS)
                {
                    CLB_listServer.Items.Add(oServer);
                    CLB_listServer.SetItemChecked(i, false);
                    i++;
                }
            }
            if (SafeSenders.Count > 0)
            {
                foreach (string oSender in SafeSenders)
                {
                    LB_whiteList.Items.Add(oSender);
                }
            }

            //choosed spam folder and signed
            if (!string.IsNullOrEmpty(NameSpamChoosedFolder))
            {
                RB_chooseFolder.Checked = true;
                RB_junkFolder.Checked = false;
                B_chooseFolder.Enabled = true;
                L_choosedFolder.Text = NameSpamChoosedFolder;
            }
            if (!string.IsNullOrEmpty(SpamSignWord))
            {
                CB_modifySubjectMail.Checked = true;
                TB_sign.Enabled = true;
                TB_sign.Text = SpamSignWord;
            }
        }

        /// <summary>
        /// Add server to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_addServer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_addServer.Text))
            {
                CLB_listServer.Items.Add(TB_addServer.Text);
                TB_addServer.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Addres server is empty, please enter address", "Error adding server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Save settings (DialogResult = OK)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_saveSettings_Click(object sender, EventArgs e)
        {
            EnableBLS.Clear();
            DisableBLS.Clear();
            SafeSenders.Clear();

            for (int i = 0; i < CLB_listServer.Items.Count; i++)
            {
                if (CLB_listServer.GetItemChecked(i))
                {
                    EnableBLS.Add(CLB_listServer.Items[i].ToString());
                }
                else
                {
                    DisableBLS.Add(CLB_listServer.Items[i].ToString());
                }
            }
            for (int j = 0; j < LB_whiteList.Items.Count; j++)
            {
                SafeSenders.Add(LB_whiteList.Items[j].ToString());
            }

            //save spam sign word
            if (CB_modifySubjectMail.Checked &&
                TB_sign.Text != string.Empty)
            {
                SpamSignWord = TB_sign.Text;
            }
            else
            {
                SpamSignWord = string.Empty;
            }

            //save choosed spam folder
            if (RB_chooseFolder.Checked == false)
            {
                EntryIDSpamFolder = string.Empty;
                EntryIDStoreSpamFolder = string.Empty;
                NameSpamChoosedFolder = string.Empty;
            }

            this.Close();
        }

        /// <summary>
        /// Remove server(s) from above list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_removeServer_Click(object sender, EventArgs e)
        {
            if (CLB_listServer.Items.Count > 0 &&
                CLB_listServer.CheckedItems.Count > 0)
            {
                List<int> listServerToRemove = new List<int>();
                foreach (string oServer in CLB_listServer.CheckedItems)
                {
                    int no = CLB_listServer.CheckedItems.IndexOf(oServer);
                    listServerToRemove.Add(no);
                }
                while (listServerToRemove.Count > 0)
                {
                    CLB_listServer.Items.Remove(CLB_listServer.CheckedItems[0].ToString());
                    listServerToRemove.Remove(listServerToRemove[0]);
                    CLB_listServer.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Doesn't choose server to remove", "Error removing server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Changed checked (WriteErrorLog)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_saveError_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_saveError.Checked)
            {
                IsSaveLog = true;
                TB_pathToErrorLog.Enabled = true;
                B_destinationFile.Enabled = true;
            }
            else
            {
                IsSaveLog = false;
                TB_pathToErrorLog.Enabled = false;
                B_destinationFile.Enabled = false;
            }
        }

        /// <summary>
        /// Choose destination file output to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_destinationFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            sfd.Filter = "Text Files (*.txt)|*.txt";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                TB_pathToErrorLog.Text = sfd.FileName;
            }
        }

        /// <summary>
        /// Don't save settings and close window    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_dontSaveAndExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Add new item to white list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_addToWhiteList_Click(object sender, EventArgs e)
        {
            AddToWhiteList();
        }

        /// <summary>
        /// Function adding to white list
        /// </summary>
        private void AddToWhiteList()
        {
            if (!string.IsNullOrEmpty(TB_addToWhiteList.Text))
            {
                if (ValidateSender(TB_addToWhiteList.Text))
                {
                    bool bSafeSenderExist = false;
                    for (int i = 0; i < LB_whiteList.Items.Count; i++)
                    {
                        if (LB_whiteList.Items[i].ToString() == TB_addToWhiteList.Text)
                        {
                            bSafeSenderExist = true;
                            break;
                        }
                    }

                    if (!bSafeSenderExist)
                    {
                        LB_whiteList.Items.Add(TB_addToWhiteList.Text);
                        TB_addToWhiteList.Text = string.Empty;
                    }                    
                }
                else
                {
                    MessageBox.Show("Mail address isn't correctly format, please enter correct address\nExample: \"smith@dom.com\" or \"@dom.com\"", "Error adding sender", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                TB_addToWhiteList.Focus();
            }
            else
            {
                MessageBox.Show("Mail address is empthy, please enter address", "Error adding sender", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Very simple validate correct sender address
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>true if corrent address</returns>
        private bool ValidateSender(string sender)
        {
            bool result = false;

            if (sender.Contains("@") && sender.Contains("."))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Edit selected item from white list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_editSelectedWhiteRecord_Click(object sender, EventArgs e)
        {
            if (LB_whiteList.SelectedItems.Count > 0)
            {
                TB_addToWhiteList.Text = LB_whiteList.SelectedItem.ToString();
                LB_whiteList.Items.Remove(LB_whiteList.SelectedItem);
                LB_whiteList.Refresh();
            }
        }

        /// <summary>
        /// Remove selected item from white list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_removeFromWhiteList_Click(object sender, EventArgs e)
        {
            if (LB_whiteList.SelectedItems.Count > 0)
            {
                LB_whiteList.Items.Remove(LB_whiteList.SelectedItem);
                LB_whiteList.Refresh();
            }
        }

        /// <summary>
        /// Changed choose spam destination folder, originally JunkFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RB_junkFolder_CheckedChanged(object sender, EventArgs e)
        {
            B_chooseFolder.Enabled = false;
        }

        /// <summary>
        /// Changed choose spam destination folder, user choosed folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RB_chooseFolder_CheckedChanged(object sender, EventArgs e)
        {
            B_chooseFolder.Enabled = true;
        }

        /// <summary>
        /// Choosed destination Spam folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_chooseFolder_Click(object sender, EventArgs e)
        {
            //http://msdn.microsoft.com/en-us/library/ff184616.aspx
            Outlook.Folder folder = OutlookApplication.Session.PickFolder() as Outlook.Folder;
            if (folder != null)
            {
                EntryIDSpamFolder = folder.EntryID;
                EntryIDStoreSpamFolder = folder.StoreID;
                NameSpamChoosedFolder = folder.Name;

                //display name in window
                L_choosedFolder.Text = folder.Name;

                //free com object
                Marshal.ReleaseComObject(folder);
                GC.SuppressFinalize(folder);
                folder = null;
            }
            else
            {
                EntryIDSpamFolder = string.Empty;
                EntryIDStoreSpamFolder = string.Empty;
                NameSpamChoosedFolder = string.Empty;
            }
        }

        /// <summary>
        /// Choosed word to sign subject mail (user choosed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_modifySubjectMail_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_modifySubjectMail.Checked)
            {
                TB_sign.Enabled = true;
            }
            else
            {
                TB_sign.Enabled = false;
            }
        }

        /// <summary>
        /// Import safe sender list form file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_importFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "txt files (*.txt)|*.txt";

            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                List<string> importeSenderList = ReadFromFile(ofd.FileName);

                if (importeSenderList.Count > 0)
                {
                    if (LB_whiteList.Items.Count > 0)
                    {
                        if (LB_whiteList.Items[0].ToString() == string.Empty)
                        {
                            LB_whiteList.Items.RemoveAt(0);
                        }
                    }

                    List<string> existList = new List<string>();
                    bool bSafeSenderExist = false;
                    foreach (string oneSafeSender in importeSenderList)
                    {
                        existList.Clear();
                        for (int i = 0; i < LB_whiteList.Items.Count; i++)
                        {
                            if (LB_whiteList.Items[i].ToString() == oneSafeSender)
                            {
                                bSafeSenderExist = true;
                                break;
                            }
                        }

                        if (!bSafeSenderExist)
                        {
                            LB_whiteList.Items.Add(oneSafeSender);
                        }
                        bSafeSenderExist = false;
                    }                    
                }
            }
        }

        /// <summary>
        /// Export safe sender list from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_exportToFile_Click(object sender, EventArgs e)
        {
            List<string> SafeSenderToExport = new List<string>();
            for (int i = 0; i < LB_whiteList.Items.Count; i++)
            {
                SafeSenderToExport.Add(LB_whiteList.Items[i].ToString());
            }

            if (SafeSenderToExport.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                sfd.Filter = "txt files (*.txt)|*.txt";

                DialogResult dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    SaveToFile(SafeSenderToExport, sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Safe list senders is empty, please add first to list before press export button!",
                                "Error export",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Safe list string to file
        /// </summary>
        /// <param name="listToSave">list senders to save</param>
        /// <param name="path">path to file</param>
        /// <returns>true if success</returns>
        private bool SaveToFile(List<string> listToSave, string path)
        {
            bool result = false;

            try
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    foreach (string line in listToSave)
                    {
                        file.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog += "Error writing safe list sender to file:\n\r" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Read list senders from file
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>read list senders</returns>
        private List<string> ReadFromFile(string path)
        {
            List<string> readList = new List<string>();

            if (File.Exists(path))
            {
                StreamReader file = null;
                string line;
                try
                {
                    file = new StreamReader(path);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Trim() != string.Empty)
                        {
                            if (line.Contains('@') && line.Contains('.'))
                            {
                                if (line.IndexOf('@') != line.LastIndexOf('@'))
                                {
                                    //break becouse correctly mail not contains 2 or more "@"
                                    break;
                                }
                                readList.Add(line.Trim());
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog += "Error reading safe list sender from file:\n\r" + ex.Message;
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }

            return readList;
        }

        /// <summary>
        /// Remove all records from white list senders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_removeAllFromWhiteList_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, remove all senders from whitelist?",
                                              "Remove all confirm",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                LB_whiteList.Items.Clear();
            }
        }

        /// <summary>
        /// Enter press at textbox adding to whitelist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_addToWhiteList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(TB_addToWhiteList.Text))
                {
                    AddToWhiteList();
                }
            }
        }
    }
}
