using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Taxi_AppMain
{
    public partial class frmJobDueAlert : Form
    {
        string filePath = System.Windows.Forms.Application.StartupPath + "\\sound\\Startup.wav";

        System.Media.SoundPlayer sp = null;

        private bool preExpired = false;

        public frmJobDueAlert(bool preBookingExpired)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmWebBookingAlert_FormClosing);
            this.preExpired = preBookingExpired;
          

            if(preBookingExpired)
            {
                if(File.Exists( System.Windows.Forms.Application.StartupPath + "\\sound\\PreBookAlert.wav"))
                {
                    filePath = System.Windows.Forms.Application.StartupPath + "\\sound\\PreBookAlert.wav";
                }

            }

            sp = new System.Media.SoundPlayer(filePath);


            this.Load += new EventHandler(frmWebBookingAlert_Load);
        }

        void frmWebBookingAlert_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 222,25);



            PlaySound();


           
       
        }

       

        void frmWebBookingAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Stop();
          


            this.Dispose();
        }

      

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

       
        private void frmLicenseAlert_MouseHover(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void frmLicenseAlert_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (btnmute.Text == "MUTE" && preExpired==false)
            {

                PlaySound();
            }
        }

        private void PlaySound()
        {
            if (File.Exists(filePath))
            {
                sp.Play();
            }
        }

        private void btnmute_Click(object sender, EventArgs e)
        {
            btnmute.Text = btnmute.Text == "MUTE" ? "UN-MUTE" : "MUTE";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AppVars.JobDueAlertLastStopped = DateTime.Now.AddMinutes(1);
            this.Close();
        }

        
    }
}
