using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Xml;
using System.IO;
using Telerik.WinControls.UI.Docking;
using System.Reflection;
using Utils;

namespace UI
{

    public partial class MainMenu : Form
    {

     
        private StatusStrip _StatusBarElement;

        public StatusStrip StatusBarElement
        {
            get { return statusStrip1; }
            set { _StatusBarElement = statusStrip1; }
        }

        private bool _ShowHeaderMenu = true;

        public bool ShowHeaderMenu
        {
            get { return _ShowHeaderMenu; }
            set { _ShowHeaderMenu = value;
            this.radPanel1.Visible = value;
                }
        }



      

        public  SetupBase objSetupBase;
        private List<UserRights> listofUserRights;

     
        private DAL.LoginUser _objLoginUser;

        public DAL.LoginUser ObjLoginUser
        {
            get { return _objLoginUser; }
            set { _objLoginUser = value; }
        }

        public  List<UserRights> ListofUserRights
        {
            get { return listofUserRights; }
            set { listofUserRights = value; }
        }
       

        public static Form newForm;
       

        bool ShowInDialog = false;

      
       

        public static INavigator ichildForm;
        private Icon _Ico;

        public Icon Ico
        {
            get { return _Ico; }
            set { _Ico = value; }
        }

     


      

        private string _LoginFormName;

        public string LoginFormName
        {
            get { return _LoginFormName; }
            set { _LoginFormName = value; }
        }


        private string _BackupFormName;

        public string BackupFormName
        {
            get { return _BackupFormName; }
            set { _BackupFormName = value; }
        }



        private string _AppTitle;

        public string AppTitle
        {
            get { return _AppTitle; }
            set { 
                    _AppTitle = value;
                    this.Text = _AppTitle;
            
                }
        }
        private Image _AppImage;

        public Image AppImage
        {
            get { return _AppImage; }
            set {
                    _AppImage = value;
                    this.documentContainer1.BackgroundImage = _AppImage;
                 }
        }

     


       
        private string _CurrentTheme;

        public string CurrentTheme
        {
            get { return _CurrentTheme; }
            set { _CurrentTheme = value; }
        }

        


        //public bool ShowCustomToolbar
        //{

        //    get
        //    {
        //        return toolbar_Custom.Visibility == ElementVisibility.Visible ? true : false;


        //    }

        //    set
        //    {
             

        //        toolbar_Custom.Visibility = value == true ? ElementVisibility.Visible : ElementVisibility.Collapsed;

        //    }

        //}





     


  //      bool isLoaded=false;
      

      

     

        public MainMenu()
        {
            InitializeComponent();

            
        }

       

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

            if (this.DesignMode) return;

       
            AppVars.MenuMDIForm = this;

            objSetupBase = new SetupBase();
    
            if(this.listofUserRights==null)
              this.listofUserRights = new List<UserRights>();
       
            if(this.ObjLoginUser==null)
               this.ObjLoginUser = new DAL.LoginUser();
      
            OnLoadFormWithRights();
             AppVars.listUserRights = this.listofUserRights;

         

         

         
         //   isLoaded = true;
            this.Icon = Ico;
           

            AppVars.objLogin = this.ObjLoginUser;
            MainMenuForm.MainMenuFrm = this;


            if (this.listofUserRights == null)
                this.listofUserRights = new List<UserRights>();

        

               assemblyName = System.Reflection.Assembly.GetEntryAssembly();
                  asmTypes = assemblyName.GetTypes();
        }

       

       

        void ReportMenuBar_PageCollapsing(object sender, RadPageViewCancelEventArgs e)
        {
            e.Cancel = true;
        }


        public virtual void OnLoadFormWithRights()
        {


        }


        private void LoadThemesCombo()
        {


            //ThemeList themeList = ThemeResolutionService.GetAvailableThemes();
            //if (themeList.Count() > 0)
            //{
            //    radComboThemes.DisplayMember = "ThemeName";
            //    radComboThemes.ValueMember = "ThemeName";
            //    radComboThemes.DataSource = themeList.Distinct().Where(t=>!t.ThemeName.EndsWith("*") && t.ThemeName!="BreezeExtended").ToList();
            //}

            //radComboThemes.SelectedIndex = -1;


            //if(!this.ShowThemesCombo)
            //{
            //    radComboThemes.Visibility= ElementVisibility.Collapsed;
            //    lblThemeName.Visibility= ElementVisibility.Collapsed;

            //}

            //    if (!string.IsNullOrEmpty(this.CurrentTheme))
            //    {
            //        radComboThemes.SelectedValue=this.CurrentTheme;
            //        LoadTheme();
            //    }
            //}

        }
        private void LoadTheme()
        {
            //if (radComboThemes.SelectedIndex >= 0)
            //    ThemeResolutionService.ApplicationThemeName = radComboThemes.Text;

        }


        private void radComboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(!isLoaded)return;

            //if(radComboThemes.SelectedIndex>=0)
            //    ThemeResolutionService.ApplicationThemeName=radComboThemes.SelectedText;
        }


  


         
      


        protected virtual void OnClickMenuItem(string key)
        {
            ShowForm(key.ToStr());
        }

        public void ShowForm(string key)
        {
            try
            {
                Telerik.WinControls.UI.Docking.DockWindow dockable = GetDockByName(key + "1");
                if (dockable != null)
                {
                    OpenedForm(dockable,null);
                    // radDock1.ActiveWindow = dockable;

                }
                else
                {
                    Assembly assemblyName = System.Reflection.Assembly.GetEntryAssembly();
                    Type[] asmTypes = assemblyName.GetTypes();
                    string concatKey = assemblyName.GetName().Name + "." + key;
                    Type t = asmTypes.FirstOrDefault(r => r.FullName == concatKey);
                    newForm = (Form)Activator.CreateInstance(t);


                    //if (tNode != null)
                    //{
                    //    newForm.Tag = tNode != null ? tNode.ToolTipText : "";
                    //    //  newForm.Text = tNode != null ? tNode.Text : "";

                    //}

                    BeforeOpenForm(ref newForm);

                    //newForm.MdiParent = this;
                    //ichildForm = (INavigator)newForm;
                    //newForm.Show();



                    //objSetupBase = (SetupBase)newForm;
                    //objSetupBase.objChild = ichildForm;


                    //FillSearchCombo();

                }
            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }


         Assembly assemblyName =null; 
        Type[] asmTypes = null;
        public void ShowFormInDialog(string key,bool showDialog)
        {
            try
            {

               
                string concatKey = assemblyName.GetName().Name + "." + key;
                Type t = asmTypes.FirstOrDefault(r => r.FullName == concatKey);
                newForm = (Form)Activator.CreateInstance(t);



                ichildForm = (INavigator)newForm;
                objSetupBase = (SetupBase)newForm;
                objSetupBase.objChild = ichildForm;

                objSetupBase.ControlBox = true;
                objSetupBase.FormBorderStyle = FormBorderStyle.Fixed3D;
                objSetupBase.MaximizeBox = false;
                objSetupBase.StartPosition = FormStartPosition.CenterScreen;
                if (showDialog)
                    objSetupBase.ShowDialog();
                else
                    objSetupBase.Show();


            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }

        public void ShowSimpleFormInDialog(string key, bool showDialog)
        {
            try
            {


                string concatKey = assemblyName.GetName().Name + "." + key;
                Type t = asmTypes.FirstOrDefault(r => r.FullName == concatKey);
                newForm = (Form)Activator.CreateInstance(t);




                newForm.ControlBox = true;
                newForm.FormBorderStyle = FormBorderStyle.Fixed3D;
                newForm.MaximizeBox = false;
                newForm.StartPosition = FormStartPosition.CenterScreen;
                if (showDialog)
                    newForm.ShowDialog();
                else
                    newForm.Show();


            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }




        public virtual void OpenedForm(Telerik.WinControls.UI.Docking.DockWindow dock,RadTreeNode node)
        {

            radDock1.ActiveWindow = dock;
        }


        public virtual void BeforeOpenForm(ref Form newForm)
        {


            ichildForm = (INavigator)newForm;
            objSetupBase = (SetupBase)newForm;
            objSetupBase.objChild = ichildForm;

            if (this.ShowInDialog == true)
            {
                objSetupBase.ControlBox = true;
                objSetupBase.FormBorderStyle = FormBorderStyle.Fixed3D;
                objSetupBase.MaximizeBox = false;
                objSetupBase.StartPosition = FormStartPosition.CenterScreen;
                objSetupBase.ShowDialog();

            }
            else
            {
                newForm.MdiParent = this;
              
                newForm.Show();
             
            }



        }


        public void OnNew()
        {
            if (ichildForm == null) return;

            if (objSetupBase.ObjBLL == null) return;

            if (!objSetupBase.CanAdd)
            {
                RadMessageBox.Show("Add Mode -- Permission Denied", this.AppTitle);

                return;
            }




            this.objSetupBase.ObjBLL.New();
            ichildForm.AddNew();

        }
    


        public void ViewForm(Form form)
        {
            try
            {

                form.FormClosing += new FormClosingEventHandler(form_FormClosing);

                form.MdiParent = this;
                ichildForm = (INavigator)newForm;
                form.Show();
              //  this.radToolStrip1.Enabled = false;
                  

                

              
            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  this.radToolStrip1.Enabled = true;
        }

     
        public void ShowForm(Form frm)
        {
            try
            {
                Telerik.WinControls.UI.Docking.DockWindow dockable = GetDockByName(frm.Name + "1");
                if (dockable != null)
                    radDock1.ActiveWindow = dockable;
                else
                {
                   // Assembly assemblyName = System.Reflection.Assembly.GetEntryAssembly();
                   // Type[] asmTypes = assemblyName.GetTypes();
                   // string concatKey = assemblyName.GetName().Name + "." + key;
                    //Type t = asmTypes.FirstOrDefault(r => r.FullName == concatKey);
                 //   newForm = (Form)Activator.CreateInstance(t);
                    newForm = frm;
                    newForm.MdiParent = this;
                    ichildForm = (INavigator)newForm;

                    objSetupBase = (SetupBase)newForm;
                    objSetupBase.objChild = ichildForm;

                  

                    newForm.Show();
                    newForm.Focus();
                    string windowName=newForm.Name+"1";
                    Telerik.WinControls.UI.Docking.DockWindow window = this.radDock1.DockWindows.FirstOrDefault(c => c.Name == windowName);
                    if (window != null)
                    {
                        window.Focus();
                        window.Select();
                    }
  
                }
            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }


        public void ShowFormSeparately(Form frm)
        {
            try
            {
              
                    newForm = frm;
                    newForm.MdiParent = this;
                    ichildForm = (INavigator)newForm;

                    objSetupBase = (SetupBase)newForm;
                    objSetupBase.objChild = ichildForm;

                  //  FillSearchCombo();

                    newForm.Show();
                    newForm.Focus();
                    string windowName = newForm.Name + "1";

                    Telerik.WinControls.UI.Docking.DockWindow window = this.radDock1.DockWindows.FirstOrDefault(c => c.Name == windowName);
                    if (window != null)
                    {
                        window.Focus();
                        window.Select();
                    }

             }
        
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }


        public void ShowFormWithDisplay(SetupBase frm)
        {
            try
            {
                Telerik.WinControls.UI.Docking.DockWindow dockable = GetDockByName(frm.Name + "1");
                if (dockable != null)
                {
                    radDock1.ActiveWindow = dockable;

                    frm.DisplayRecord();
                }
                else
                {
                    // Assembly assemblyName = System.Reflection.Assembly.GetEntryAssembly();
                    // Type[] asmTypes = assemblyName.GetTypes();
                    // string concatKey = assemblyName.GetName().Name + "." + key;
                    //Type t = asmTypes.FirstOrDefault(r => r.FullName == concatKey);
                    //   newForm = (Form)Activator.CreateInstance(t);
                    newForm = frm;
                    newForm.MdiParent = this;
                    ichildForm = (INavigator)newForm;

                    objSetupBase = (SetupBase)newForm;
                    objSetupBase.objChild = ichildForm;

                 //   FillSearchCombo();

                    newForm.Show();
                    newForm.Focus();
                    string windowName = newForm.Name + "1";
                    Telerik.WinControls.UI.Docking.DockWindow window = this.radDock1.DockWindows.FirstOrDefault(c => c.Name == windowName);
                    if (window != null)
                    {
                        window.Focus();
                        window.Select();
                    }

                }
            }
            catch
            {
                Telerik.WinControls.RadMessageBox.Show("Option not available");

            }
        }




        public Telerik.WinControls.UI.Docking.DockWindow GetDockByName(string name)
        {
            foreach (Telerik.WinControls.UI.Docking.DockWindow dockable in radDock1.DockWindows)
            {
           
                if (dockable.Name==name)
                    return dockable;
            }

            return null;
        }


      

       

        public void PerformGroupOnClick(RadPageViewPage page)
        {
            //if (page != null && page.Tag != null)
            //{
            //    this.ShowForm(page.Tag.ToStr());
            //}

        }

       

        private void radDock1_DockStateChanging(object sender, DockStateChangingEventArgs e)
        {
            if (e.NewWindow.Name.ToLower() == "toolwindowleft" && e.NewDockState == Telerik.WinControls.UI.Docking.DockState.Floating)
            {
                e.NewWindow.DockState = Telerik.WinControls.UI.Docking.DockState.Docked;
                e.Cancel = true;
                return;
            }
        }

        private void radBtnLogout_Click(object sender, EventArgs e)
        {

            if (OnLogout())
            {
            

            }
        }


        protected virtual bool OnLogout()
        {

            bool isLogoout= LogOut();
            if (isLogoout)
            {
            
            }
            return isLogoout;
        }

        private bool LogOut()
        {
            bool isLogout = false;
            
             if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to Logout ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
            {
     
                isLogout = true;
               
            }
            
             return isLogout;
        }




      

        private void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            if (e.DockWindow != null && this.radDock1.ActiveWindow != null && this.radDock1.ActiveWindow.ActiveControl != null && !this.radDock1.ActiveWindow.Name.Equals("toolWindowLeft") && !this.radDock1.ActiveWindow.Name.Equals("toolWindowDashBoard"))
            {
                if (radDock1.ActiveWindow.ActiveControl is Form)
                {

                    newForm = (Form)this.radDock1.ActiveWindow.ActiveControl;

                    if (newForm.GetType().GetInterface("INavigator") != null)
                    {

                        ichildForm = (INavigator)newForm;

                        objSetupBase = (SetupBase)newForm;
                        objSetupBase.objChild = ichildForm;

                       


                     
                    }
                }
            }
        }


     

     
        public void Register(INavigator frmToRegister)
        {

        }

        private void radDock1_DockWindowAdded(object sender, DockWindowEventArgs e)
        {

          //  if (e.DockWindow != null && e.DockWindow.Text != "toolWindow1")
          //     ichildForm = (INavigator)e.DockWindow.FindForm(); 
        }

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void AutoHideAppMenu()
        {
         //   this.toolWindowLeft.AutoHide();

        }

        public void ShowFullScreen(bool IsFullScreen)
        {


            this.radPanel1.Visible = !IsFullScreen;
            this.pnl_StatusBar.Visible = !IsFullScreen;
   

        }

     


    

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();         
      
        }

        public void OnSave()
        {

            if (ichildForm == null || objSetupBase.ObjBLL == null) return;

            if (!CanAddRecord())
            {
                return;
            }
            else if (!CanEditRecord())
            {
                return;

            }
           
           
             objSetupBase.Save();           
          
             

        }


        private bool CanAddRecord()
        {
            bool valid = true;
            if (objSetupBase.ObjBLL.IsAddMode())
            {
                if (!objSetupBase.CanAdd)
                {
                    RadMessageBox.Show("Add Mode -- Permission Denied", this.AppTitle);
                    valid = false;
                }

            }

            return valid;

        }


        private bool CanEditRecord()
        {
            bool valid = true;
            if (objSetupBase.ObjBLL.IsEditMode())
            {
                if (!objSetupBase.CanEdit)
                {
                    RadMessageBox.Show("Edit Mode -- Permission Denied", this.AppTitle);
                    valid = false;
                }

            }

            return valid;
        }


        private bool CanDeleteRecord()
        {
            bool valid = true;
            if (objSetupBase.ObjBLL.IsEditMode())
            {
                if (!objSetupBase.CanDelete)
                {
                    RadMessageBox.Show("Delete Mode -- Permission Denied", this.AppTitle);
                    valid = false;
                }

            }

            return valid;
        }

     

      

       

     

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            OnLogout();
        }

     

      

        private void btnRefresh_Click(object sender,EventArgs e)
        {
            if (ichildForm == null) return;

            ichildForm.RefreshData();

        }



       

      
       
        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            pnl_StatusBar.Visible = pnl_StatusBar.Visible == true ? false : true;
        }
           






     
    }
}

