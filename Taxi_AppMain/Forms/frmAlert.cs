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
    public partial class frmAlert : Form
    {
        //string filePath = System.Windows.Forms.Application.StartupPath + "\\sound\\alert.wav";

        //System.Media.SoundPlayer sp = null;
        //public bool IsMute = false;


        public string formCaption;
        public string formContent;

        public frmAlert(string caption,string content)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmWebBookingAlert_FormClosing);

       


            formCaption = caption;
            formContent = content;

            this.Tag = content;
            this.Load += new EventHandler(frmWebBookingAlert_Load);

            this.StartPosition = FormStartPosition.Manual;
         

            int opened = Application.OpenForms.OfType<Form>().Count(c => c.Name == "frmAlert");


            if (opened == 0)
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 150, 10);
            else
            {
                int x = Screen.PrimaryScreen.WorkingArea.Width - 150;
                int y = 25;

                int newY = opened * Height;
                y = y + newY;

                this.Location = new Point(x, y);
            }

    
         
        }

       

        void frmWebBookingAlert_Load(object sender, EventArgs e)
        {

        
            txtHeader.Text = formCaption;
            txtMsg.Text = formContent;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += Timer1_Tick;
         
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        //public bool IsMuted()
        //{

        //    return IsMute;

        //}

        //public void SetMuted(bool muteSnd)
        //{
        //    try
        //    {
        //        IsMute = muteSnd;
        //     //   btnmute.Text = IsMute ? "UN-MUTE" : "MUTE";
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}

        public void SetMessage(string msg)
        {

            txtMsg.Text = msg;
        }

        void frmWebBookingAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  sp.Stop();

            try
            {
                timer1.Stop();
                timer1.Dispose();



                this.Dispose();
            }
            catch
            {


            }
        }

       
    }
}
