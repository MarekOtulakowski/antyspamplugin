#region UsingDirective
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms; 
#endregion

namespace AntySpamPlugin
{
    partial class AboutBoxDialog : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AboutBoxDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open project website in default internet browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MarekOtulakowski/antyspamplugin");

        }
    }
}
