using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi_BLL;
using DotNetCoords;
using JobPoolAPICaller;
using Taxi_Model;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmPoolBookingAlert : Form
    {
        string filePath = System.Windows.Forms.Application.StartupPath + "\\sound\\alert.wav";

        System.Media.SoundPlayer sp = null;
        public bool IsMute = false;

        public int TotalJobs;
        PoolBooking objPool = null;
        public frmPoolBookingAlert(PoolBooking obj)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmWebBookingAlert_FormClosing);


           

          


          

            this.objPool = obj;
            this.Load += new EventHandler(frmWebBookingAlert_Load);
        }

        public void UpdateCounter(int count)
        {

            if(txtJobsCount.Visible)
            {
                txtJobsCount.Text = count.ToStr() + " Jobs Available in Pool";


            }

        }

       
        public void SetData(PoolBooking obj,int jobsCount)
        {


            try
            {

                objPool = obj;
                TotalJobs = jobsCount;
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 320, 30);
                PlaySound();


                if (jobsCount <= 1)
                {
                    txtJobsCount.Visible = false;
                    txtheader.Text = "New Job Available In Pool";
                    btnAccept.Visible = true;
                    btnClose.Visible = true;
                    btnclose2.Visible = false;

                    txttime.Text = "Date/Time : " + string.Format("{0:dd/MMM at HH:mm}", objPool.PickupDatetime);
                    txtPickup.Text = "PICKUP : " + objPool.PickupLocation.ToString().ToUpper();


                    stp_getCoordinatesByAddressResult objCoord = null;

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        objCoord = db.stp_getCoordinatesByAddress(objPool.PickupLocation.ToString().ToUpper(), General.GetPostCodeMatch(objPool.PickupLocation.ToString().ToUpper())).FirstOrDefault();

                        if (objCoord != null)
                        {
                            db.CommandTimeout = 6;

                            var list = db.stp_GetLoginDriverPlotsUpdated().Where(c => c.driverworkstatusid == Enums.Driver_WORKINGSTATUS.AVAILABLE).ToList();


                            var availabledrivers = (from a in list
                                                    select new
                                                    {
                                                        a.driverid,
                                                        a.driverno,
                                                        Distance = new LatLng(a.latitude, a.longitude).DistanceMiles(new LatLng(Convert.ToDouble(objCoord.Latitude), Convert.ToDouble(objCoord.Longtiude))),



                                                    }
                                                  ).OrderBy(c => c.Distance).FirstOrDefault();



                        

                            if (availabledrivers != null)
                            {
                                txtDriver.Text = "Driver " + availabledrivers.driverno.ToString() + " is " + Math.Round(availabledrivers.Distance, 1) + "mi away from Pickup";
                                txtDriver.Visible = true;

                            }

                        }

                    }


                    try
                    {

                        File.AppendAllText(Application.StartupPath + "\\jobofferalertload.txt", DateTime.Now + ", coord:" + objCoord == null ? "null" : objCoord.Latitude + Environment.NewLine);

                    }
                    catch
                    {


                    }
                }
                else
                {

                    txtJobsCount.Text = jobsCount.ToStr() + " Jobs Available in Pool";
                    txtJobsCount.Visible = true;
                    txtDriver.Text = "";
                    txtPickup.Text = "";
                    txttime.Text = "";
                    txtheader.Text = "";
                    btnAccept.Visible = false;
                    btnClose.Visible = false;
                    btnclose2.Visible = true;
                }


                //}
            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText(Application.StartupPath + "\\jobofferalertload_exception.txt", DateTime.Now + "," + ex.Message + Environment.NewLine);

                }
                catch
                {


                }


            }

        }

        void frmWebBookingAlert_Load(object sender, EventArgs e)
        {
           
        }

        public bool IsMuted()
        {

            return IsMute;

        }

        public void SetMuted(bool muteSnd)
        {
            try
            {
                IsMute = muteSnd;
              //  btnmute.Text = IsMute ? "UN-MUTE" : "MUTE";
            }
            catch (Exception ex)
            {


            }
        }

        public void SetMessage(string msg)
        {

            txttime.Text = msg;
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
          
            
        }

        private void PlaySound()
        {

            try
            {
                sp = new System.Media.SoundPlayer(filePath);
                if (IsMute == false)
                {
                    if (File.Exists(filePath))
                    {
                        sp.Play();
                    }
                }
            }
            catch
            {

            }
        }

        private void btnmute_Click(object sender, EventArgs e)
        {
          //  btnmute.Text = btnmute.Text == "MUTE" ? "UN-MUTE" : "MUTE";

            
           
          //  IsMute=btnmute.Text == "UN-MUTE" ? true:false;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            CloseForm();
        }


        public void CloseForm()
        {
            try
            {

                timer1.Stop();
                timer1 = null;
            }
            catch
            {


            }

            this.Close();

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                var result = JobPoolAPIProxy.AcceptJob(objPool.PoolJobId.ToStr(), AppVars.objPolicyConfiguration.DefaultClientId.ToStr());


                try
                {

                    File.AppendAllText(Application.StartupPath + "\\jobofferalertaccept.txt", DateTime.Now + ", result"+ result + Environment.NewLine);

                }
                catch
                {


                }

                CloseForm();

            }
            catch(Exception ex)
            {

                try
                {

                    File.AppendAllText(Application.StartupPath + "\\jobofferalertaccept_exception.txt", DateTime.Now + ", exception" + ex.Message + Environment.NewLine);

                }
                catch
                {


                }
               

            }
        }

        
    }
}
