#region UsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
#endregion

namespace AntySpamPlugin
{
    public partial class AntySpamMSOutlook
    {
        #region Variables
        private Office.CommandBar menuBar;
        private Office.CommandBarPopup newMenuBar;
        private Office.CommandBarButton buttonOne;
        private Office.CommandBarButton buttonOneAbout;
        private string menuTag = "menuAntySpam";
        List<string> listBLS;
        List<string> listDisableBLS;
        List<string> listSafeSenders;
        bool IsSaveErrorLog = true;
        string pathToErrorLog = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\errorLogAntySpamPlugin.txt";
        string pathToSettings = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\settingsAntySpamOutlookPlugin.xml";
        string entryIDSpamFolder = string.Empty;
        string entryIDStoreSpamFolder = string.Empty;
        string spamSignWord = string.Empty;
        string nameSpamChoosedFolder = string.Empty;
        string currentProfileName = string.Empty;
        #endregion

        /// <summary>
        /// Read XML file settings
        /// </summary>
        /// <returns>true if read ok</returns>
        private bool ReadXML()
        {
            try
            {
                pathToSettings = GetPathToSettingForOutlookProfile(Application.Session.CurrentProfileName);

                if (!File.Exists(pathToSettings))
                {
                    WriteDefaultSettings();
                    return true;
                }

                XmlTextReader reader = new XmlTextReader(pathToSettings);
                while (reader.Read())
                {
                    XmlNodeType nType = reader.NodeType;
                    if (nType == XmlNodeType.Element)
                    {
                        if (reader.Name == "EnableServers")
                        {
                            string eServers = reader.NamespaceURI;
                            string[] tabEservers = eServers.Split(';');
                            foreach (string oDserver in tabEservers)
                            {
                                listBLS.Add(oDserver);
                            }
                        }
                        if (reader.Name == "DisableServers")
                        {
                            string dServers = reader.NamespaceURI;
                            string[] tabDservers = dServers.Split(';');
                            foreach (string oEserver in tabDservers)
                            {
                                listDisableBLS.Add(oEserver);
                            }
                        }
                        if (reader.Name == "SafeSenders")
                        {
                            string sSenders = reader.NamespaceURI;
                            string[] tabSsenders = sSenders.Split(';');
                            foreach (string oSsenders in tabSsenders)
                            {
                                listSafeSenders.Add(oSsenders);
                            }
                        }
                        if (reader.Name == "PathToErrorLog")
                        {
                            pathToErrorLog = reader.NamespaceURI;
                        }
                        if (reader.Name == "IsSaveErrorLog")
                        {
                            IsSaveErrorLog = bool.Parse(reader.NamespaceURI);
                        }
                        if (reader.Name == "EntryIDSpamFolder")
                        {
                            entryIDSpamFolder = reader.NamespaceURI;
                        }
                        if (reader.Name == "EntryIDStoreSpamFolder")
                        {
                            entryIDStoreSpamFolder = reader.NamespaceURI;
                        }
                        if (reader.Name == "NameChoosedSpamFolder")
                        {
                            nameSpamChoosedFolder = reader.NamespaceURI;   
                        }
                        if (reader.Name == "SpamSignWord")
                        {
                            spamSignWord = reader.NamespaceURI;
                        }
                        if (reader.Name == "CurrentProfileName")
                        {
                            currentProfileName = reader.NamespaceURI;
                        }
                    }
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                SaveToLog("Error read xml settings file:\n\r" + ex.Message, pathToErrorLog);
                return false;
            }
        }

        /// <summary>
        /// Get path to setting antyspam for outlook profile
        /// </summary>
        /// <param name="inputProfileName">current profile outlook name</param>
        /// <returns>path to setting for outlook profile</returns>
        private string GetPathToSettingForOutlookProfile(string inputProfileName)
        {
            string outputProfileName = inputProfileName;
            outputProfileName = outputProfileName.Replace("\\", "");
            outputProfileName = outputProfileName.Replace("/", "");
            outputProfileName = outputProfileName.Replace(":", "");
            outputProfileName = outputProfileName.Replace("*", "");
            outputProfileName = outputProfileName.Replace("?", "");
            outputProfileName = outputProfileName.Replace("\"", "");
            outputProfileName = outputProfileName.Replace("<", "");
            outputProfileName = outputProfileName.Replace(">", "");
            outputProfileName = outputProfileName.Replace("|", "");
            outputProfileName = outputProfileName.Trim();
            outputProfileName = outputProfileName.Replace(" ", "");

            string newPathToSetting = pathToSettings;
            newPathToSetting = pathToSettings.Substring(0, pathToSettings.LastIndexOf(".")) +
                               outputProfileName + ".xml";
            return newPathToSetting;
        }

        /// <summary>
        /// Save XML settings file
        /// </summary>
        private void SaveXML()
        {
            try
            {
                if (File.Exists(pathToSettings))
                {
                    File.Delete(pathToSettings);
                }

                string enableBLS = string.Empty;
                string disableBLS = string.Empty;
                string safeSenders = string.Empty;

                foreach (string oSafeSenders in listSafeSenders)
                {
                    if (safeSenders != string.Empty)
                    {
                        safeSenders += ";" + oSafeSenders;
                    }
                    else
                    {
                        safeSenders = oSafeSenders;
                    }
                }
                foreach (string oServerEBLS in listBLS)
                {
                    if (enableBLS != string.Empty)
                    {
                        enableBLS += ";" + oServerEBLS;
                    }
                    else
                    {
                        enableBLS = oServerEBLS;
                    }
                }
                foreach (string oServerDBLS in listDisableBLS)
                {
                    if (disableBLS != string.Empty)
                    {
                        disableBLS += ";" + oServerDBLS;
                    }
                    else
                    {
                        disableBLS = oServerDBLS;
                    }
                }

                XmlTextWriter textWriter = new XmlTextWriter(pathToSettings, null);
                textWriter.WriteStartDocument();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteComment("AntySpam plugin for Outlook2010 - file settings");
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteStartElement("CPluginSettings");
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("EnableServers", enableBLS);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("DisableServers", disableBLS);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("PathToErrorLog", pathToErrorLog);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("IsSaveErrorLog", IsSaveErrorLog.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("SafeSenders", safeSenders);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("EntryIDSpamFolder", entryIDSpamFolder);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("EntryIDStoreSpamFolder", entryIDStoreSpamFolder);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("NameChoosedSpamFolder", nameSpamChoosedFolder);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("SpamSignWord", spamSignWord);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteWhitespace("   ");
                textWriter.WriteStartElement("CurrentProfileName", currentProfileName);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteEndElement();
                textWriter.WriteWhitespace(Environment.NewLine);
                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                SaveToLog("Error write xml settings file:\n\r" + ex.Message, pathToErrorLog);
            }
        }

        /// <summary>
        /// Add menu bar plugin
        /// </summary>
        private void AddMenuBar()
        {
            try
            {
                //Define the existent Menu Bar
                menuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;
                //Define the new Menu Bar into the old menu bar
                newMenuBar = (Office.CommandBarPopup)menuBar.Controls.Add(
                    Office.MsoControlType.msoControlPopup, missing,
                    missing, missing, false);

                //If I dont find the newMenuBar, I add it
                if (newMenuBar != null)
                {
                    newMenuBar.Caption = "AntySpam";
                    newMenuBar.Tag = menuTag;

                    //about
                    buttonOneAbout = (Office.CommandBarButton)newMenuBar.Controls.
                    Add(Office.MsoControlType.msoControlButton, missing,
                        missing, 1, true);
                    buttonOneAbout.Style = Office.MsoButtonStyle.msoButtonCaption;
                    buttonOneAbout.Caption = "About plugin";
                    buttonOneAbout.FaceId = 611;
                    buttonOneAbout.Tag = "c124";
                    buttonOneAbout.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(buttonOneAbout_Click);

                    //setting
                    buttonOne = (Office.CommandBarButton)newMenuBar.Controls.
                    Add(Office.MsoControlType.msoControlButton, missing,
                        missing, 1, true);
                    buttonOne.Style = Office.MsoButtonStyle.
                        msoButtonIconAndCaption;
                    buttonOne.Caption = "AntySpam Settings";
                    //This is the Icon near the Text
                    buttonOne.FaceId = 610;
                    buttonOne.Tag = "c123";
                    //Insert Here the Button1.Click event    
                    buttonOne.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(buttonOne_Click);
                    newMenuBar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                SaveToLog("Error adding menu plugin bar:\n\r" + ex.Message, pathToErrorLog);
            }
        }

        /// <summary>
        /// Event button click About plugin
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        private void buttonOneAbout_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            AboutBoxDialog aboutBoxDialog = new AboutBoxDialog();
            aboutBoxDialog.ShowDialog();
        }

        /// <summary>
        /// Write default settings
        /// </summary>
        /// <remarks>
        /// If file doen't exist then sets default settings
        /// </remarks>
        private void WriteDefaultSettings()
        {
            listBLS.Clear();
            listDisableBLS.Clear();

            //enable default
            listBLS.Add("sbl-xbl.spamhaus.org");
            listBLS.Add("bl.spamcop.net");

            //disable default
            listDisableBLS.Add("access.redhawk.org");
            listDisableBLS.Add("accredit.habeas.com");
            listDisableBLS.Add("bl.deadbeef.com");
            listDisableBLS.Add("bl.spamcannibal.org");
            listDisableBLS.Add("blackholes.uceb.org");
            listDisableBLS.Add("blacklist.spambag.org");
            listDisableBLS.Add("cbl.abuseat.org");
            listDisableBLS.Add("cbl.ni.bg");
            listDisableBLS.Add("cblless.anti-spam.org.cn");
            listDisableBLS.Add("combined.njabl.org");
            listDisableBLS.Add("combined.rbl.msrbl.net");
            listDisableBLS.Add("dnsbl.ahbl.org");
            listDisableBLS.Add("dnsbl.burnt-tech.com");
            listDisableBLS.Add("dnsbl.delink.net");
            listDisableBLS.Add("dnsbl.njabl.org");
            listDisableBLS.Add("dnsbl.sorbs.net");
            listDisableBLS.Add("dnsbl.tqmcube.com");
            listDisableBLS.Add("dnsbl-1.uceprotect.net");
            listDisableBLS.Add("dnsbl-2.uceprotect.net");
            listDisableBLS.Add("dnsbl-3.uceprotect.net");
            listDisableBLS.Add("dul.dnsbl.sorbs.net");
            listDisableBLS.Add("http.dnsbl.sorbs.net");
            listDisableBLS.Add("ko.tqmcube.com");
            listDisableBLS.Add("list.dsbl.org");
            listDisableBLS.Add("misc.dnsbl.sorbs.net");
            listDisableBLS.Add("multihop.dsbl.org");
            listDisableBLS.Add("no-more-funn.moensted.dk");
            listDisableBLS.Add("prc.tqmcube.com");
            listDisableBLS.Add("psbl.surriel.com");
            listDisableBLS.Add("rbl.spamlab.com");
            listDisableBLS.Add("smtp.dnsbl.sorbs.net");
            listDisableBLS.Add("socks.dnsbl.sorbs.net");
            listDisableBLS.Add("spam.tqmcube.com");
            listDisableBLS.Add("ubl.unsubscore.com");
            listDisableBLS.Add("unconfirmed.dsbl.org");
            listDisableBLS.Add("zen.spamhaus.org");

            pathToErrorLog = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\errorLogAntySpamPlugin.txt";
            IsSaveErrorLog = true;

            entryIDSpamFolder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk).EntryID;
            entryIDStoreSpamFolder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk).StoreID;
            nameSpamChoosedFolder = string.Empty;
            listSafeSenders.Clear();
            spamSignWord = string.Empty;
            
            currentProfileName = Application.Session.CurrentProfileName;
        }

        /// <summary>
        /// Events when user click button in menu bar plugin
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        private void buttonOne_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            if (currentProfileName != Application.Session.CurrentProfileName)
            {
                WriteDefaultSettings();
            }

            FormSettings formSettings = new FormSettings(listBLS,
                                                         listDisableBLS,
                                                         listSafeSenders,
                                                         IsSaveErrorLog,
                                                         pathToErrorLog,
                                                         entryIDSpamFolder,
                                                         entryIDStoreSpamFolder,
                                                         spamSignWord,
                                                         nameSpamChoosedFolder);
            formSettings.OutlookApplication = Application;
            DialogResult dr = formSettings.ShowDialog();

            if (dr == DialogResult.OK)
            {
                listBLS = formSettings.EnableBLS;
                listDisableBLS = formSettings.DisableBLS;
                listSafeSenders = formSettings.SafeSenders;
                IsSaveErrorLog = formSettings.IsSaveLog;
                pathToErrorLog = formSettings.PathToErrorLog;
                entryIDSpamFolder = formSettings.EntryIDSpamFolder;
                entryIDStoreSpamFolder = formSettings.EntryIDStoreSpamFolder;
                spamSignWord = formSettings.SpamSignWord;
                nameSpamChoosedFolder = formSettings.NameSpamChoosedFolder;
                currentProfileName = Application.Session.CurrentProfileName;
                SaveXML();
            }

            SaveToLog(formSettings.ErrorLog, pathToErrorLog);
        }

        /// <summary>
        /// Remove menu bar plugin
        /// </summary>
        private void RemoveMenubar()
        {
            // If the menu already exists, remove it.
            try
            {
                Office.CommandBarPopup foundMenu = (Office.CommandBarPopup)
                    this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.
                    FindControl(Office.MsoControlType.msoControlPopup,
                    missing, menuTag, true, true);
                if (foundMenu != null)
                {
                    foundMenu.Delete(true);
                }
            }
            catch (Exception ex)
            {
                SaveToLog("Error remove menu bar plugin:\n\r" + ex.Message, pathToErrorLog);
            }
        }

        /// <summary>
        /// SaveToLog
        /// </summary>
        /// <remarks>
        /// function write messages to log
        /// </remarks>
        /// <param name="message">message to write</param>
        /// <param name="path">path to log file</param>
        private void SaveToLog(string message, string path)
        {
            if (IsSaveErrorLog)
            {
                // Create a writer and open the file:
                StreamWriter log;

                if (!File.Exists(path))
                {
                    log = new StreamWriter(path);
                }
                else
                {
                    log = File.AppendText(path);
                }

                try
                {
                    // Write to the file:
                    log.WriteLine(message);
                }
                catch { }

                // Close the stream:
                log.Close();
            }
        }

        /// <summary>
        /// On load plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            listBLS = new List<string>();
            listDisableBLS = new List<string>();
            listSafeSenders = new List<string>();

            if (!ReadXML())
            {
                WriteDefaultSettings();
            }

            SplashScreen spScreen = new SplashScreen(DateTime.Now);
            spScreen.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            spScreen.Show();
            this.Application.NewMailEx += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_NewMailExEventHandler(Application_NewMailEx);

            //Outlook.Rules rules = Application.Session.DefaultStore.GetRules() as Outlook.Rules;
            //Application.Session.DefaultStore.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk).

            RemoveMenubar();
            AddMenuBar();
        }

        string previousProcessMail = string.Empty;
        string previousMoveProecessMail = string.Empty;

        /// <summary>
        /// Event if receive new mail
        /// </summary>
        /// <param name="EntryIDItem">Entry ID mail</param>
        private void Application_NewMailEx(string EntryIDItem)
        {
            try
            {
                //for other location inbox folder (eg. IMAP) -> Type.Missing (diffent store, pst file)
                Outlook.MailItem mail = Application.Session.GetItemFromID(EntryIDItem, Type.Missing) as Outlook.MailItem;

                if (previousProcessMail == mail.EntryID) return;
                if (previousMoveProecessMail == mail.EntryID) return;

                previousProcessMail = mail.EntryID;

                //older location inbox folder (default) work only POP3 and Exchange
                //Outlook.MailItem mail = Application.Session.GetItemFromID(EntryIDItem, Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox).StoreID) as Outlook.MailItem;

                //if receive not mail exit function (eg. read raport etc)
                if (mail == null) return;

                Outlook.PropertyAccessor pAccess = mail.PropertyAccessor;
                string mailHeader = pAccess.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E").ToString();

                bool IsSpam = false;

                try
                {
                    //new algoritm (>2.0.6)
                    string fsIpStep1 = mailHeader.Substring(0, mailHeader.IndexOf(")"));
                    string ipToVerify = fsIpStep1.Substring(fsIpStep1.IndexOf("(") + 1, fsIpStep1.Length - fsIpStep1.IndexOf("(") - 1);

                    if (!IsAddressValid(ipToVerify))
                    {
                        fsIpStep1 = mailHeader.Substring(mailHeader.IndexOf("Received: from"), mailHeader.Length - mailHeader.IndexOf("Received: from"));
                        string fsIpStep2 = fsIpStep1.Substring(0, fsIpStep1.IndexOf("]"));
                        ipToVerify = fsIpStep2.Substring(fsIpStep2.IndexOf("[") + 1, fsIpStep2.Length - fsIpStep2.IndexOf("[") - 1);
                    }

                    //old algoritm (<=2.0.5.2)
                    //string fsIpStep1 = mailHeader.Substring(mailHeader.IndexOf("Received: from"), mailHeader.Length - mailHeader.IndexOf("Received: from"));
                    //string fsIpStep2 = fsIpStep1.Substring(0, fsIpStep1.IndexOf("]"));
                    //string ipToVerify = fsIpStep2.Substring(fsIpStep2.IndexOf("[") + 1, fsIpStep2.Length - fsIpStep2.IndexOf("[") - 1);

                    //string[] BLS = new string[] { "sbl-xbl.spamhaus.org", "bl.spamcop.net" };
                    string[] BLS = new string[listBLS.Count];
                    int i = 0;
                    foreach (string oServer in listBLS)
                    {
                        BLS[i] = oServer;
                        i++;
                    }

                    VerifyIP IP = new VerifyIP(ipToVerify, BLS);

                    if (IP.BlackList.IsListed)  //Is the IP address listed?
                    {
                        IsSpam = true;
                    }

                    //bellow line only test (all message this spam) remove after publish
                    //IsSpam = true;
                }
                catch (Exception ex)
                {
                    SaveToLog("Error reading message header:\n\r" + mailHeader + "\n\r" + ex.Message,
                              pathToErrorLog);
                }

                if (IsSpam)
                {
                    //check if mail sender is a white list
                    if (!IsSenderSafe(mail.SenderEmailAddress))
                    {
                        //bellow variable to idetyfity error
                        bool bDefaultJunkFolder = false;
                        try
                        {
                            //if spam folder user choosed
                            if (!string.IsNullOrEmpty(entryIDSpamFolder) &&
                                !string.IsNullOrEmpty(entryIDStoreSpamFolder))
                            {
                                bDefaultJunkFolder = false;

                                mail.Move(Application.Session.GetFolderFromID(entryIDSpamFolder, entryIDStoreSpamFolder) as Outlook.Folder);

                                Outlook.Folder spamFol = Application.Session.GetFolderFromID(entryIDSpamFolder, entryIDStoreSpamFolder) as Outlook.Folder;

                                foreach (Outlook.MailItem item in spamFol.Items)
                                {
                                    if (item.ReceivedTime == mail.ReceivedTime)
                                    {
                                        ChangeEmailSubject(item);
                                        previousMoveProecessMail = item.EntryID;
                                        break;
                                    }
                                }

                                //free COM object
                                Marshal.ReleaseComObject(spamFol);
                                GC.SuppressFinalize(spamFol);
                                spamFol = null;
                            }

                            //if isn't, default "JunkFolder"
                            else
                            {
                                bDefaultJunkFolder = true;
                                mail.Move(Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk));

                                Outlook.Folder spamFol = Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk) as Outlook.Folder;

                                foreach (Outlook.MailItem item in spamFol.Items)
                                {
                                    if (item.ReceivedTime == mail.ReceivedTime)
                                    {
                                        ChangeEmailSubject(item);
                                        previousMoveProecessMail = item.EntryID;
                                        break;
                                    }
                                }

                                //free COM object
                                Marshal.ReleaseComObject(spamFol);
                                GC.SuppressFinalize(spamFol);
                                spamFol = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            SaveToLog("Error moving mail to spam folder:\n\r" + 
                                      ex.Message +
                                      "\n\r" + "Default JunkFolder = " + bDefaultJunkFolder,
                                      pathToErrorLog);
                        }
                    }
                }

                //free COM object
                Marshal.ReleaseComObject(pAccess);
                GC.SuppressFinalize(pAccess);
                pAccess = null;

                Marshal.ReleaseComObject(mail);
                GC.SuppressFinalize(mail);
                mail = null;

            }
            catch (Exception ex)
            {
                SaveToLog("Error plugin:\n\r" + ex.Message,
                          pathToErrorLog);
            }
        }

        /// <summary>
        /// Change Email Subject (adding eg. [SPAM] word)
        /// </summary>
        /// <param name="mail"></param>
        private void ChangeEmailSubject(Outlook.MailItem mail)
        {
            try
            {
                //modify spam subject (user choosed)
                if (!string.IsNullOrEmpty(spamSignWord))
                {
                    string prevSubject = mail.Subject;
                    mail.Subject = spamSignWord +
                                   " " +
                                   prevSubject;
                    mail.Save();
                }
            }
            catch (Exception ex)
            {
                SaveToLog("Error modify subject mail:\n\r" + ex.Message, pathToErrorLog);
            }
        }

        /// <summary>
        /// Validate IP Address
        /// </summary>
        /// <param name="addrString">IP Address as String</param>
        /// <returns>true if IP Address is correctly</returns>
        private bool IsAddressValid(string addrString)
        {
            System.Net.IPAddress address;
            return System.Net.IPAddress.TryParse(addrString, out address);
        }

        /// <summary>
        /// Check if sender email is safe sender
        /// </summary>
        /// <param name="senderMail"></param>
        /// <returns>true if sender email is safe</returns>
        private bool IsSenderSafe(string senderMail)
        {
            bool result = false;

            foreach (string oSenderEmail in listSafeSenders)
            {
                //if safe is email "smith@dom.com"
                if (senderMail == oSenderEmail)
                {
                    return true;
                }

                //if safe is domain "@dom.com"
                else if (senderMail.Contains(oSenderEmail) && (oSenderEmail.Length > 0))
                {
                    return true;
                }
            }

            return result;
        }

        /// <summary>
        /// Event shutdown plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            this.Application.NewMailEx -= new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_NewMailExEventHandler(Application_NewMailEx);
            buttonOne.Click -= new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(buttonOne_Click);
            buttonOneAbout.Click -= new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(buttonOneAbout_Click);
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

