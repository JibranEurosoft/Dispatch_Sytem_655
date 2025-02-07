using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;
using System.Collections;
using Utils;

using System.Data.Linq;
using Telerik.WinControls.Data;
using System.Linq.Expressions;

namespace UI
{
   

    public partial class SetupBase : Form,INavigator
    {
        public int skip = 0;
        private bool _ShowSaveButton = false;

        public bool ShowSaveButton
        {
            get
            {

                return this._ShowSaveButton;

            }
            set
            {
                this._ShowSaveButton = value;
                btnSaveOn.Visible = this._ShowSaveButton;
              
            }
        }


     

        public Color HeaderColor
        {
            get { return pnlHeaderTitle.BackColor; }
            set { pnlHeaderTitle.BackColor = value; }
        }


        public Color HeaderForeColor
        {
            get { return pnlHeaderTitle.ForeColor; }
            set { pnlHeaderTitle.ForeColor = value; }
        }




        private bool _ShowAddNewButton = false;

        public bool ShowAddNewButton
        {
            get
            {

                return this._ShowAddNewButton;

            }
            set
            {
                this._ShowAddNewButton = value;
                btnOnNew.Visible = this._ShowAddNewButton;

            }
        }



        private bool _ShowExitButton = false;

        public bool ShowExitButton
        {
            get
            {

                return this._ShowExitButton;

            }
            set
            {
                this._ShowExitButton = value;
               btnExit.Visible = this._ShowExitButton;

            }
        }


        private bool _ShowSaveAndCloseButton = false;

        public bool ShowSaveAndCloseButton
        {
            get
            {

                return this._ShowSaveAndCloseButton;

            }
            set
            {
                this._ShowSaveAndCloseButton = value;
                btnSaveAndClose.Visible = this._ShowSaveAndCloseButton;

            }
        }


        private bool _ShowSaveAndNewButton = false;

        public bool ShowSaveAndNewButton
        {
            get
            {

                return this._ShowSaveAndNewButton;

            }
            set
            {
                this._ShowSaveAndNewButton = value;
                btnSaveAndNew.Visible = this._ShowSaveAndNewButton;

            }
        }

      

        private string _formTitle;

        public string FormTitle
        {
            get { return _formTitle; }
            set {
                   _formTitle = value;
                   this.pnlHeaderTitle.Text = _formTitle;
            
                }
        }


        private bool _showHeader=false;

        public bool ShowHeader
        {
            get { return _showHeader; }
            set { _showHeader = value;

            this.pnlHeaderTitle.Visible = _showHeader;
               }
        }


        private DAL.LoginUser _LoginUser;

        public DAL.LoginUser LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }



        private bool _CanEdit;

        protected internal bool CanEdit
        {
            get { return _CanEdit; }
            set { _CanEdit = value; }
        }
        private bool _CanDelete;

        protected internal bool CanDelete
        {
            get { return _CanDelete; }
            set { _CanDelete = value; }
        }
        private bool _CanSave;

        protected internal bool CanAdd
        {
            get { return _CanSave; }
            set { _CanSave = value; }
        }
        private bool _CanPrint;

        protected internal bool CanPrint
        {
            get { return _CanPrint; }
            set { _CanPrint = value; }
        }

        protected internal int _CurrentFormId;

        public int CurrentFormId
        {
            get { return _CurrentFormId; }
            set { _CurrentFormId = value; }
        }


       

        private INavigation objBLL;

        protected internal INavigation ObjBLL
        {
            get { return objBLL; }
            set { objBLL = value; }
        }


       public  INavigator objChild;
     


      private bool _FixedExitButtonOnTopRight = false;

      public bool FixedExitButtonOnTopRight
      {
          get { return _FixedExitButtonOnTopRight; }
          set { 
              
              
              _FixedExitButtonOnTopRight = value;

              if (value)
              {
                  SetExitButtonOnTopRight();
              }
             }
      }

      private void SetExitButtonOnTopRight()
      {
          int right = this.Bounds.Right;
           int top=this.Bounds.Top;

           btnExit.Size = new Size(77, 38);
           btnExit.TextImageRelation = TextImageRelation.TextBeforeImage;
           btnExit.Location = new Point(this.Size.Width-80,0);
           
      }

        public SetupBase()
        {
            InitializeComponent();
        }

       

        public void SetProperties(INavigation objNavigation)
        {
            this.ObjBLL = objNavigation;
            this.ObjBLL.SetLogin(AppVars.objLogin);
            SetLogin();

            UserRights objRights=AppVars.listUserRights.FirstOrDefault(c => c.formName == this.Name);

            if(objRights!=null)
            {

                this.CurrentFormId = objRights.formId.ToInt();
                this.InitializeForm();
            }

        }

        protected void SetLogin()
        {
            this.LoginUser = AppVars.objLogin;
        }





   
     

       protected virtual bool OnDisposeForm()
       {
           return false;

       }     


      
        public virtual void PopulateData()
        {
          
    
        }




        #region INavigator Members




        public virtual void Save()
        {
            
          
        }

        public virtual bool OnDeleteFailed()
        {
            return true;
        }

        public virtual void Delete()
        {
          
        }

        public virtual void AddNew()
        {
           // throw new NotImplementedException();
        }

        public virtual void OnNew()
        {



        }

        public virtual void Print()
        {
          
        }


        public virtual void OnDisplayRecord()
        {
            DisplayRecord();
            ShowLog();


        }



        public virtual void OnDisplayRecord(object id)
        {
            this.objBLL.GetByPrimaryKey(id);
            DisplayRecord();
            ShowLog();


        }

        public void ShowLog()
        {
        //    MainMenuForm.MainMenuFrm.lblCheckInOutDetails.Text = objBLL.GetLogDetails();
        }

        public virtual void DisplayRecord()
        {

        }

   

        public virtual void RefreshData()
        {
            PopulateData();

        }

        #endregion

            


        protected internal void InitializeForm()
        {
            if (AppVars.listUserRights.FindAll(f => f.formId == this.CurrentFormId && f.functionId == "ADD").Count()  >0)
            {
                this.CanAdd = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formId == this.CurrentFormId && f.functionId == "EDIT").Count() >0)
            {
                this.CanEdit = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formId == this.CurrentFormId && f.functionId == "PRINT").Count() >0)
            {
                this.CanPrint = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formId == this.CurrentFormId && f.functionId == "DELETE").Count() > 0)
            {
                this.CanDelete = true;
            }


          
        }



        protected internal void InitializeForm(string formName)
        {
            this.CurrentFormId = AppVars.listUserRights.FirstOrDefault(c => c.formName == formName).DefaultIfEmpty().formId.ToInt();


            if (AppVars.listUserRights.FindAll(f => f.formName ==formName && f.functionId == "ADD").Count() > 0)
            {
                this.CanAdd = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formName == formName && f.functionId == "EDIT").Count() > 0)
            {
                this.CanEdit = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formName == formName && f.functionId == "PRINT").Count() > 0)
            {
                this.CanPrint = true;
            }

            if (AppVars.listUserRights.FindAll(f => f.formName == formName && f.functionId == "DELETE").Count() > 0)
            {
                this.CanDelete = true;
            }
            else
                this.CanDelete = false;


         

            SetLogin();
        //    this.CurrentFormId = AppVars.listUserRights.FirstOrDefault(c => c.formName == this.Name).formId.ToInt();


        }


       


      

        private void btnSaveOn_Click(object sender, EventArgs e)
        {
            MainMenuForm.MainMenuFrm.objSetupBase = this;
            MainMenuForm.MainMenuFrm.OnSave();

            if (this.objBLL.ActionStatus == eActionStatus.Success)
            {
                this.ObjBLL.ClearFilter();
                this.ObjBLL.New();
            }
        }

        private void btnOnNew_Click(object sender, EventArgs e)
        {
            MainMenuForm.MainMenuFrm.objSetupBase = this;

            MainMenuForm.MainMenuFrm.OnNew();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew();
        }


        protected void SaveAndNew()
        {
            MainMenuForm.MainMenuFrm.objSetupBase = this;
            MainMenuForm.MainMenuFrm.OnSave();

            if (this.objBLL.ActionStatus == eActionStatus.Success)
            {
                this.ObjBLL.ClearFilter();
                this.ObjBLL.New();
                
                ClearAllTextBoxes(this);


                this.OnNew();


            }

        }

        private void ClearAllTextBoxes(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox)
                    c.Text = string.Empty;

                if (c.Controls.Count > 0)
                    ClearAllTextBoxes(c);
            }

          
        }
      


        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }


        protected void SaveAndClose()
        {
            MainMenuForm.MainMenuFrm.objSetupBase = this;
            MainMenuForm.MainMenuFrm.OnSave();

            if (this.objBLL.ActionStatus == eActionStatus.Success)
            {
                this.Close();
            }

        }
    }
}
