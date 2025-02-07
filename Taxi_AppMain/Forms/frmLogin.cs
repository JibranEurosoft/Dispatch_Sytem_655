using System;
using System.Collections.Generic;

using System.Linq;

using System.Windows.Forms;

using Utils;
using Taxi_Model;
using Telerik.WinControls;


using Taxi_AppMain.Forms;
using System.Configuration;


namespace Taxi_AppMain
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            string environment = ConfigurationManager.AppSettings["Environment"];
            if (environment == "Development")
            {
                txtUserName.Text = "eurosoft";
                txtPassword.Text = "14331101";
            }
            SetShown();
           }

        private void SetShown()
        {
            this.Shown += FrmLogin_Shown;
        }

      
        private bool IsAutoLogin = false;

        private void FrmLogin_Shown(object sender, System.EventArgs e)
        {
            txtUserName.Focus();
        }

        public frmLogin(string[] args)
        {
            InitializeComponent();
            AppVars.LoginObj = new LoginUser();
            AppVars.listUserRights = new List<UI.UserRights>();

            if (args != null && args.Count() > 2)
            {
                txtUserName.Text = args[1].Replace("*", " ").Trim();
                txtPassword.Text = args[2].ToStr().Trim();
                IsAutoLogin = true;
                Login();

            }


        }




        private void btnLogin_Click(object sender, EventArgs e)
        {
          //  Application.Exit();
       
           Login();
        }

        



        delegate void DisplayProgressBar();
        private void Login()
        {

            try
            {
                TaxiDataContext db = new TaxiDataContext();

                UM_User obj = db.UM_Users.FirstOrDefault(c =>(c.IsActive==true) &&  (c.UserName.ToLower() == txtUserName.Text.Trim().ToLower() && c.Passwrd.ToLower() == txtPassword.Text.Trim().ToLower()));


                if (obj == null)
                {
                    RadMessageBox.Show("Invalid UserName or Password.", "EuroSoftTech", MessageBoxButtons.OK, RadMessageIcon.Error);
                    txtUserName.Focus();
                    db.Dispose();
                    return;
                }
                else
                {

                    AppVars.objSubCompany =db.Gen_SubCompanies.FirstOrDefault(c => c.Id == obj.SubcompanyId);

                    if (AppVars.objSubCompany == null)
                    {
                        db.Dispose();

                        ENUtils.ShowMessage("This user is not created properly"+Environment.NewLine
                                      +"Define Subcompany for that user in Users Menu.");
                        return;

                    }


                     AppVars.DefaultSubCompanyId = AppVars.objSubCompany.Id;


                }

                if (this.InvokeRequired)
                {
                    DisplayProgressBar d = new DisplayProgressBar(ShowLoadingImage);
                    this.BeginInvoke(d);
                }
                else
                {
                    ShowLoadingImage();

                }
                      

                frmMainMenu frm = new frmMainMenu();


                if (IsAutoLogin)
                    frm.showWarning = false;

                frm.ObjLoginUser = new DAL.LoginUser();
                frm.ObjLoginUser.SysGen = obj.UM_SecurityGroup.SysGen.ToBool();          

                frm.ObjLoginUser.LgroupId = obj.SecurityGroupId.ToInt();
                frm.ObjLoginUser.LoginName = obj.UserName;
                frm.ObjLoginUser.LuserId = obj.Id;
                frm.ObjLoginUser.UserName = obj.UserName;
                frm.ObjLoginUser.Email = obj.Email;
                frm.ObjLoginUser.Password = obj.Passwrd;

                frm.ObjLoginUser.LsessionId =db.stp_ControlerLogins(frm.ObjLoginUser.LuserId.ToInt(), null,null,Environment.MachineName).FirstOrDefault().Id.ToInt();
              
      

                frm.ObjLoginUser.IsAdmin=obj.ConfirmPasswrd.ToStr()=="1"?true:false;
                AppVars.LoginObj = frm.ObjLoginUser;


                //if (System.Diagnostics.Debugger.IsAttached)
                //    obj.ThemeName = "HighContrastBlack";


                AppVars.AppTheme = obj.ThemeName;
                frm.CurrentTheme = obj.ThemeName;
                frm.ShowAllBookings = obj.ShowAllBookings.ToBool();

                frm.ShowAllDrivers = obj.ShowAllDrivers.ToBool();

                frm.ShowDriverFilter = obj.ShowDriverFilter.ToBool();
                frm.ShowBookingFilter = obj.ShowBookingFilter.ToBool();
                AppVars.ShowAllBookings = obj.ShowAllBookings.ToBool();
                AppVars.CanTransferJob = obj.TransferBooking.ToBool();

                AppVars.IsTelephonist = obj.Fax.ToStr() == "1" ? true : false;

                frm.Show();




                this.ShowInTaskbar = false;

                this.Hide();

                frmLoading.Close();

                db.Dispose();




               // Close();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }


       
        frmLoadingScreen frmLoading = null;
        private void ShowLoadingImage()
        {

            frmLoading = new frmLoadingScreen();
            frmLoading.ShowInTaskbar = false;


            frmLoading.Show();
        }

      

        private void frmLogin_Load(object sender, EventArgs e)
        {



            try
            {
             



                if (Program.onrestartArgs != null && Program.onrestartArgs.Count() > 0)
                {




                    try
                    {

                        System.IO.File.AppendAllText(Application.StartupPath + "\\autorestart.TXT", DateTime.Now + Environment.NewLine);
                    }
                    catch
                    {


                    }
                }
            }
            catch
            {

            }





        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                Login();

            }
        }


    

  
    }


  



}
