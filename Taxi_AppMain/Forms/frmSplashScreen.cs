using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Taxi_Model;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmSplashScreen : Form
    {
        public string clientName = string.Empty;
        public bool? IsVerified = null;
        System.Windows.Forms.Timer t = null;

        public frmSplashScreen()
        {

            InitializeComponent();


            this.Shown += new EventHandler(frmLoading_Shown);
            this.FormClosed += FrmSplashScreen_FormClosed;
            
        }

        private void FrmSplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (t != null)
                {

                    t.Stop();
                    t.Dispose();
                    t = null;

                }
            }
            catch
            {


            }
        }

        delegate void DisplayProgressBar();
        void frmLoading_Shown(object sender, EventArgs e)
        {

          
           
               


            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Enabled = true;
            t.Start();
            new Thread(delegate ()
            {

                try
                {
                    IsVerified = VerifyLicense();

                
                }
                catch
                {

                }
            }).Start();

          
            try
            {

                File.WriteAllText(Application.StartupPath + "\\startup.dat", DateTime.Now.ToStr());
            }
            catch
            {

            }
          
          
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (IsVerified != null)
                Close();
        }

     

        private  bool VerifyLicense()
        {

            bool verify = false;
          
            try
            {
                this.Tag = string.Empty;


               
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    clientName = db.Gen_SysPolicy_Configurations.Select(c => c.DefaultClientId).FirstOrDefault();
                }

                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\SysData.dll")
                    && Cryptography.Decrypt(File.ReadAllText(System.Windows.Forms.Application.StartupPath + "\\SysData.dll"), (clientName + "!@#"), true).Equals((clientName)))
                {


                    verify = true;
                    AppVars.LicenseChecked = true;
                    Program.objLic.AppServiceUrl = "https://www.treasureonlineapi.co.uk/CabTreasureWebApi/Home/";
                }

                else
                {


               

                    try
                    {

                        if (clientName.ToStr().Trim().Length == 0)
                        {
                            this.Tag = "Authentication Failed...";

                        }
                        else
                        {


                            verify = General.VerifyLicense(clientName);

                            if (verify == false)
                            {
                                if (Program.objLic.Reason.ToStr().Trim().ToLower().Contains("could not be resolved"))
                                {
                                    this.Tag = "Authentication Failed...";
                                }
                                else
                                {
                                    this.Tag = Program.objLic.Reason.ToStr();
                                }
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        this.Tag = ex.Message.ToStr();

                    }

                }
            }
            catch (Exception ex)
            {
                this.Tag = ex.Message.ToStr();


            }


           
            return verify;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



       

   

       



    }
}
