#region UsingDirective
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
#endregion

namespace AntySpamPlugin
{
    public partial class SplashScreen : Form
    {
        #region Variables
        DateTime time = DateTime.Now;
        DateTime newTime = DateTime.Now;
        Timer timer = new Timer(); 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="time"></param>
        public SplashScreen(DateTime time)
        {
            InitializeComponent();
            time = this.time;
            timer.Interval = 2000;
            newTime = time.AddSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Start();
        }

        /// <summary>
        /// Timer display window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {            
            if (DateTime.Now > newTime)
            {
                timer.Stop();
                this.Close();
            }
        }

        /// <summary>
        /// Event close window, free resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Tick -= new EventHandler(timer_Tick);
        }
    }
}
