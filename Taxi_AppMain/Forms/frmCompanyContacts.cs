using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls.UI;

namespace Taxi_AppMain
{
    public partial class frmCompanyContacts  : UI.SetupBase
    {
        CompanyContactBO objMaster = null;
        private int _CompanyId;

        public int CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }
        public frmCompanyContacts(int companyId)
        {
            InitializeComponent();
            ComboFunctions.FillCompanyCombo(ddlCompany);
            this.Shown += new EventHandler(frmCompanyDepartments_Shown);
            objMaster = new CompanyContactBO();
            this.SetProperties((INavigation)objMaster);
            ddlCompany.SelectedValue = companyId;
            this.CompanyId = companyId;

            ComboFunctions.FillVehicleTypeCombo(ddlVehicleType);

        }

       

        private bool saved = false;

        public bool Saved
        {
            get { return saved; }
            set { saved = value; }
        }
        void frmCompanyDepartments_Shown(object sender, EventArgs e)
        {
            OnNew();
        }




       

        public override void Save()
        {
            try
            {
                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                }
                else
                {
                    objMaster.Edit();
                }

                objMaster.Current.ContactName = txtContactName.Text.ToStr().Trim();

                objMaster.Current.Email = txtEmail.Text.ToStr().Trim();
                objMaster.Current.TelephoneNo = txtTelNo.Text.ToStr().Trim();
                objMaster.Current.MobileNo = txtMobNo.Text.ToStr().Trim();                
                objMaster.Current.CompanyId = ddlCompany.SelectedValue.ToInt();
                
                objMaster.Current.AccPassword = txtPwd.Text.ToStr().Trim();
                objMaster.Current.UserName = txtUserName.Text.ToStr().Trim();
                objMaster.Current.JobTitles = txtJobTitle.Text.ToStr().Trim();
                objMaster.Current.OrderNo = txtRefNo.Text.ToStr().Trim();
                objMaster.Current.Address = txtAddress.Text.ToStr().Trim();
                objMaster.Current.SpecialNotes = txtSpecialRequirements.Text.ToStr().Trim();
                objMaster.Current.Attributes = btnAttributes.Tag.ToStr().Trim();
                objMaster.Current.DefaultVehicleId = ddlVehicleType.SelectedValue.ToInt();

                objMaster.Current.IsDefault = false;

              //  objMaster.Current. = txtPwd.Text.Trim();

                objMaster.Save();


                using (TaxiDataContext db = new TaxiDataContext())
                {

                    int bookedBy = 0;
                    int webAccount = 0;
                    if (chkBookedBy.Checked)
                    {
                        bookedBy = 1;
                    }
                    if (chkWebLogin.Checked)
                    {
                        webAccount = 1;
                    }

                    if (bookedBy == 1)
                    {
                        db.ExecuteQuery<int>("exec stp_AddAccountContactDetails {0},{1},{2} ", objMaster.Current.Id , bookedBy , webAccount );
                    }
                    else
                    {
                        db.ExecuteQuery<int>("exec stp_DeleteAccountContactDetails {0},{1},{2} ", + objMaster.Current.Id , bookedBy , webAccount );
                    }

                    if (webAccount == 1)
                    {
                        db.ExecuteQuery<int>("exec stp_AddAccountContactDetails {0},{1},{2} " , objMaster.Current.Id , bookedBy , webAccount );
                    }
                    else
                    {
                        db.ExecuteQuery<int>("exec stp_DeleteAccountContactDetails {0},{1},{2} ",  objMaster.Current.Id , bookedBy , webAccount );
                    }

                }



                this.saved = true;
            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
            }
        }

        private void ShowAttributes()
        {
            try
            {

                frmBookingAttributesList frm = new frmBookingAttributesList(btnAttributes.Tag.ToStr());
                frm.ShowDialog();
                btnAttributes.Text = "Attri&butes" + Environment.NewLine + frm.input_values;

                if (frm.input_values.ToStr().Trim().Length > 0)
                {

                    btnAttributes.Tag = "," + frm.input_values + ",";
                }
                else
                    btnAttributes.Tag = "";



                frm.Dispose();

                //FocusOnCustomer();

            }
            catch
            {


            }
        }

        public override void DisplayRecord()
        {
            if (objMaster.Current == null) return;

            txtContactName.Text = objMaster.Current.ContactName.ToStr();
            txtEmail.Text = objMaster.Current.Email.ToStr();

            txtTelNo.Text = objMaster.Current.TelephoneNo.ToStr();
            txtMobNo.Text = objMaster.Current.MobileNo.ToStr();

            ddlCompany.SelectedValue = objMaster.Current.CompanyId;
            
            txtPwd.Text = objMaster.Current.AccPassword;
            txtUserName.Text = objMaster.Current.UserName;
            txtJobTitle.Text = objMaster.Current.JobTitles;
            txtRefNo.Text = objMaster.Current.OrderNo;
            txtAddress.Text = objMaster.Current.Address;
            txtSpecialRequirements.Text = objMaster.Current.SpecialNotes ;
            btnAttributes.Text += objMaster.Current.Attributes.ToStr().Trim().Length > 0 ? Environment.NewLine + objMaster.Current.Attributes.ToStr().Trim().TrimStart(new char[] { ',' }).TrimEnd(new char[] { ',' }) : "";
            btnAttributes.Tag= objMaster.Current.Attributes ;
            ddlVehicleType.SelectedValue = objMaster.Current.DefaultVehicleId;


            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var BookedBy = db.ExecuteQuery<int>("select ContactId from Gen_Company_BookedBy where ContactId=" + objMaster.Current.Id).ToList();
                    var WebAccount = db.ExecuteQuery<int>("select ContactId from Gen_Company_WebAccounts where ContactId=" + objMaster.Current.Id).ToList();

                    if (BookedBy.Count > 0)                   
                        chkBookedBy.Checked = true;                   
                    else                   
                        chkBookedBy.Checked = false;

                    if (WebAccount.Count > 0)
                        chkWebLogin.Checked = true;
                    else
                        chkWebLogin.Checked = false;

                }
            }
            catch
            {

            }

            //  txtPwd.Text = objMaster.Current.Passwrd;

        }

        public override void AddNew()
        {
          
        }

        public override void OnNew()
        {
            txtContactName.Focus();
        }

        private void btnAttributes_Click(object sender, EventArgs e)
        {
            ShowAttributes();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

