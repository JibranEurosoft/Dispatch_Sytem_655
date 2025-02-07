using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using DAL;
using Taxi_Model;
using UI;
using Telerik.WinControls.UI;
using Utils;
using Telerik.WinControls;
using Taxi_AppMain.Classes;
using Telerik.WinControls.Enumerations;

namespace Taxi_AppMain
{
    public partial class frmSubCompany : UI.SetupBase
    {



        SubCompanyBO objMaster;
        public frmSubCompany()
        {
            InitializeComponent();

            objMaster = new SubCompanyBO();
            this.SetProperties((INavigation)objMaster);
            this.Shown += new EventHandler(frmCompany_Shown);

            this.Load += new EventHandler(frmSubCompany_Load);

            this.grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            this.grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            this.grdLister.RowsChanging += new GridViewCollectionChangingEventHandler(grdLister_RowsChanging);
            this.grdLister.RowsChanged += new GridViewCollectionChangedEventHandler(grdLister_RowsChanged);
            this.chkAmount.ToggleStateChanged += ChkAmount_ToggleStateChanged;
            chkUseInvoiceEmail.ToggleStateChanged += new StateChangedEventHandler(chkUseInvoiceEmail_ToggleStateChanged);

            this.Shown += new EventHandler(frmSubCompany_Shown);


            FillMapIconCombo();

            OnNew();

            if (AppVars.AppTheme != "ControlDefault")
            {
                grdLister.AutoCellFormatting = false;



            }

        }

        private void ChkAmount_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                numBookingFees.Maximum = 10000;
            }
            else
            {
                numBookingFees.Maximum = 100;
            }
        }

        void chkUseInvoiceEmail_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {

                lblInvoiceHost.Visible = true;
                lblInvoicePort.Visible = true;
                lblInvoiceEmail.Visible = true;
                lblInvoicePassword.Visible = true;
                smtpInvoiceEmail.Visible = true;
                smtpInvoicePassword.Visible = true;
                smtpInvoicePort.Visible = true;
                smtpInvoiceHost.Visible = true;
                smtpInvoiceSSL.Visible = true;

            }
            else
            {

                smtpInvoiceEmail.Text = string.Empty;
                smtpInvoicePassword.Text = string.Empty;
                smtpInvoicePort.Text = string.Empty;
                smtpInvoiceHost.Text = string.Empty;

                lblInvoiceHost.Visible = false;
                lblInvoicePort.Visible = false;
                lblInvoiceEmail.Visible = false;
                lblInvoicePassword.Visible = false;
                smtpInvoiceEmail.Visible = false;
                smtpInvoicePassword.Visible = false;
                smtpInvoicePort.Visible = false;
                smtpInvoiceHost.Visible = false;
                smtpInvoiceSSL.Visible = false;


            }
        }

        void grdLister_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {

                PopulateData();
            }
        }


        private void FillMapIconCombo()
        {
            try
            {


                string path = System.Windows.Forms.Application.StartupPath + "\\VehicleImages\\";
                RadListDataItem radItem = null;
                foreach (var item in General.GetQueryable<Gen_MapIcon>(null).ToList())
                {
                    radItem = new RadListDataItem();
                    radItem.Font = new Font("Tahoma", 12, FontStyle.Bold);
                    radItem.Text = item.MapIconName;
                    radItem.Value = item.MapIconName + "_";

                    if (System.IO.File.Exists(path + item.MapIconName + ".png"))
                    {
                        radItem.Image = Image.FromFile(path + item.MapIconName + ".png");
                    }
                    //    radItem.Height = 40;
                    ddlMapIcon.Items.Add(radItem);
                }

                ddlMapIcon.DropDownListElement.ItemHeight = 30;
                ddlMapIcon.Items[0].Height = 30;
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }


        }

        void frmSubCompany_Shown(object sender, EventArgs e)
        {
            FocusOnCompanyName();
        }

        private void FocusOnCompanyName()
        {

            txtCompanyName.Focus();
        }

        void grdLister_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {


                objMaster = new SubCompanyBO();

                try
                {

                    objMaster.GetByPrimaryKey((e.NewItems[0] as GridViewRowInfo).Cells["Id"].Value.ToInt());
                    objMaster.Delete(objMaster.Current);



                }
                catch (Exception ex)
                {
                    if (objMaster.Errors.Count > 0)
                        ENUtils.ShowMessage(objMaster.ShowErrors());
                    else
                    {
                        ENUtils.ShowMessage(ex.Message);

                    }
                    e.Cancel = true;

                }


            }
        }

        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                RadGridView grid = gridCell.GridControl;
                if (gridCell.ColumnInfo.Name == "btnDelete")
                {

                    if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Sub Company ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    {
                        gridCell.RowInfo.Delete();

                    }
                }
                else if (gridCell.ColumnInfo.Name == "ColEdit" && grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
                    DisplayRecord();

                }
            }
            catch (Exception ex)
            {

                //ENUtils.ShowMessage(ex.Message);
            }
        }

        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

            if (e.Row != null && e.Row is GridViewDataRowInfo)
            {

                objMaster.GetByPrimaryKey(e.Row.Cells["Id"].Value.ToInt());
                DisplayRecord();
            }
        }

        void frmSubCompany_Load(object sender, EventArgs e)
        {
            if (AppVars.listUserRights.Count(c => c.functionId == "DISABLE MULTIPLE") > 0)
            {
                label1.Visible = false;
                grdLister.Visible = false;

                TaxiDataContext dt = new TaxiDataContext();

                var Subcompanylist = (from a in dt.Gen_SubCompanies
                                      select a).Take(1);



                objMaster.GetByPrimaryKey(Subcompanylist.FirstOrDefault().Id);
                DisplayRecord();

                btnOnNew.Visible = false;

                btnSaveAndNew.Visible = false;


            }
            else
            {

                btnOnNew.Visible = true;
                btnSaveAndNew.Visible = true;

                PopulateData();
                grdLister.AddEditColumn();
                grdLister.AddDeleteColumn();
            }


            if(AppVars.objPolicyConfiguration.EnableZoneWiseFares.ToBool() && AppVars.objPolicyConfiguration.DeadMileageType.ToInt()==1)
            pnlRoundRobin.Visible = true;
     
        }



        void frmCompany_Shown(object sender, EventArgs e)
        {
            txtCompanyName.Focus();
        }




        public override void PopulateData()
        {
            try
            {

                var query = from a in General.GetQueryable<Gen_SubCompany>(null)

                            select new
                            {
                                Id = a.Id,
                                Name = a.CompanyName,
                                Email = a.EmailAddress,
                                TelephoneNo = a.TelephoneNo,
                                Address = a.Address,
                                Fax = a.Fax,
                                IsSysGen = a.IsSysGen
                            };


                grdLister.DataSource = query.ToList();

                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdLister.AllowAutoSizeColumns = true;

                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["IsSysGen"].IsVisible = false;
                grdLister.Columns["TelephoneNo"].HeaderText = "Telephone No";


            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }
        }




        #region Overridden Methods


        public override void DisplayRecord()
        {
            if (objMaster.Current == null) return;




            txtCompanyName.Text = objMaster.Current.CompanyName.ToStr();
            txtCompanyEmail.Text = objMaster.Current.EmailAddress.ToStr();
            txtCompanyFax.Text = objMaster.Current.Fax.ToStr();
            txtTelNo.Text = objMaster.Current.TelephoneNo.ToStr();
            txtCompanyEmergencyNo.Text = objMaster.Current.EmergencyNo.ToStr();
            txtCompanyWebsite.Text = objMaster.Current.WebsiteUrl.ToStr();
            txtAddress.Text = objMaster.Current.Address.ToStr();
            txtEmailCC.Text = objMaster.Current.EmailCC.ToStr().Trim();

            if (objMaster.Current.CompanyLogo != null)
                pb_logo.SetImage(objMaster.Current.CompanyLogo.ToArray());
            else
                pb_logo.Clear();

            txtSortCode.Text = objMaster.Current.SortCode.ToStr().Trim();
            txtAccountNo.Text = objMaster.Current.AccountNo.ToStr().Trim();
            txtAccountTitle.Text = objMaster.Current.AccountTitle.ToStr().Trim();
            txtBank.Text = objMaster.Current.BankName.ToStr().Trim();
            txtCompanyNumber.Text = objMaster.Current.CompanyNumber.ToStr().Trim();
            txtVATNumber.Text = objMaster.Current.CompanyVatNumber.ToStr().Trim();
            txtBLC.Text = objMaster.Current.BlcNumber.ToStr().Trim();
            txtIBAN.Text = objMaster.Current.IbanNumber.ToStr().Trim();

            if (objMaster.Current.BackgroundColor != 0)
            {
                Color clr = Color.FromArgb(objMaster.Current.BackgroundColor.ToInt());
                txtBgColor.BackColor = clr;
                txtBgColor.Tag = clr.ToArgb();
            }



            ddlMapIcon.SelectedValue = objMaster.Current.MapIcon.ToStr().Trim();


            smtpchkIsSecureConn.Checked = objMaster.Current.SmtpHasSSL.ToBool();
            SmtpHost.Text = objMaster.Current.SmtpHost.ToStr().Trim();
            smtpPassword.Text = objMaster.Current.SmtpPassword.ToStr().Trim();
            smtpPort.Text = objMaster.Current.SmtpPort.ToStr().Trim();
            smtpUserName.Text = objMaster.Current.SmtpUserName.ToStr().Trim();
            chkDisableAcceptEmail.Checked = objMaster.Current.DisableAcceptEmail.ToBool();
            chkDisableDeclineEmail.Checked = objMaster.Current.DisableDeclineEmail.ToBool();

            chkUseInvoiceEmail.Checked = objMaster.Current.UseDifferentEmailForInvoices.ToBool();
            smtpInvoiceEmail.Text = objMaster.Current.SmtpInvoiceUserName.ToStr().Trim();
            smtpInvoicePassword.Text = objMaster.Current.SmtpInvoicePassword.ToStr().Trim();

            smtpInvoiceHost.Text = objMaster.Current.SmtpInvoiceHost.ToStr().Trim();
            smtpInvoicePort.Text = objMaster.Current.SmtpInvoicePort.ToStr().Trim();
            smtpInvoiceSSL.Checked = objMaster.Current.SmtpInvoiceSSL.ToBool();
            txtCLINumbers.Text = objMaster.Current.ConnectionString.ToStr().Trim();

            using (TaxiDataContext db = new TaxiDataContext())
            {
             //   var query =db.ExecuteQuery<Gen_ServiceChargeEx>("select * from gen_servicecharges where subcompanyid="+ objMaster.Current.Id).FirstOrDefault();

                var query = db.Gen_ServiceCharges.FirstOrDefault(c => c.SubCompanyId == objMaster.Current.Id);
                if (query != null)
                {

                 

                    chkAmount.Checked = query.AmountWise.ToBool();
                    if (query.AmountWise.ToBool())
                    {
                        numBookingFees.Value = query.ServiceChargeAmount.ToDecimal();
                    }
                    else
                    {
                        numBookingFees.Value = query.ServiceChargePercent.ToDecimal();
                    }

                    chkAirportBookingFee.Checked = query.DifferentAirportBookingFee.ToBool();
                    numAirportJobsBookingFee.Value = query.AirportBookingFee.ToDecimal();
                }
                else
                {
                    chkAirportBookingFee.Checked = false;
                    chkAmount.Checked = false;
                    numBookingFees.Value = 0;
                }

            }

            numdeadMileage.Value = objMaster.Current.DeadMileage.ToDecimal();
            numdeadmileagepercent.Value = objMaster.Current.DeadMileagePercent.ToDecimal();


            chkFromBoundary.Checked = objMaster.Current.ApplyDeadMileageFromBoundary.ToBool();

            int deadMileageType = objMaster.Current.DeadMileageType.ToInt();

            if (deadMileageType == 1)
                ddlDeadMileageType.Items[0].Selected = true;
            else if (deadMileageType == 2)
                ddlDeadMileageType.Items[1].Selected = true;
            else if (deadMileageType == 3)
                ddlDeadMileageType.Items[2].Selected = true;
            else if (deadMileageType == 4)
                ddlDeadMileageType.Items[3].Selected = true;
            else if (deadMileageType == 5)
            {
                ddlDeadMileageType.Items[4].Selected = true;
                numdeadmileagepercent.Visible = true;
                numdeadmileagepercentlabel.Visible = true;

            }
            txtdeadmileageTownPostcode.Text = objMaster.Current.DefaultCounty.ToStr().Trim();

        }




        public override void AddNew()
        {
            OnNew();
        }

        public override void OnNew()
        {
            txtAccountNo.Text = string.Empty;
            txtAccountTitle.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtBgColor.Text = string.Empty;
            txtCompanyEmail.Text = string.Empty;
            txtCompanyEmergencyNo.Text = string.Empty;
            txtCompanyFax.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCompanyNumber.Text = string.Empty;
            txtCompanyWebsite.Text = string.Empty;
            txtEmailCC.Text = string.Empty;
            txtCLINumbers.Text = string.Empty;

            txtSortCode.Text = string.Empty;
            txtTelNo.Text = string.Empty;
            txtVATNumber.Text = string.Empty;
            smtpUserName.Text = string.Empty;
            smtpPort.Text = string.Empty;
            smtpPassword.Text = string.Empty;
            SmtpHost.Text = string.Empty;
            smtpInvoiceEmail.Text = string.Empty;
            smtpInvoicePassword.Text = string.Empty;

            smtpchkIsSecureConn.Checked = false;


            chkUseInvoiceEmail.Checked = false;
            chkDisableDeclineEmail.Checked = false;
            chkDisableAcceptEmail.Checked = false;
            numBookingFees.Value = 0;
            chkAmount.Checked = false;
            numBookingFees.Maximum = 10000;

            pb_logo.Clear();
            FocusOnCompanyName();


            if (ddlMapIcon.Items.Count > 0)
            {
                ddlMapIcon.SelectedItem = ddlMapIcon.Items[0];
                //  pb_mapicon.Image = ddlMapIcon.Items[0].Image;

            }


            objMaster.Clear();
        }


        public override void Save()
        {
            OnSave();

        }


        public bool OnSave()
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


                objMaster.Current.CompanyName = txtCompanyName.Text.Trim();
                objMaster.Current.EmailAddress = txtCompanyEmail.Text.Trim();
                objMaster.Current.Address = txtAddress.Text.Trim();
                objMaster.Current.TelephoneNo = txtTelNo.Text.Trim();
                objMaster.Current.EmergencyNo = txtCompanyEmergencyNo.Text.Trim();
                objMaster.Current.WebsiteUrl = txtCompanyWebsite.Text.Trim();
                objMaster.Current.Fax = txtCompanyFax.Text.Trim();

                objMaster.Current.EmailCC = txtEmailCC.Text.Trim();
                objMaster.Current.IsSysGen = false;


                if (pb_logo.GetImage() != null)
                {
                    objMaster.Current.CompanyLogo = pb_logo.GetByteArrayOfImage();
                }
                else
                {
                    objMaster.Current.CompanyLogo = null;

                }

                objMaster.Current.BankName = txtBank.Text.Trim();
                objMaster.Current.AccountNo = txtAccountNo.Text.Trim();
                objMaster.Current.AccountTitle = txtAccountTitle.Text.Trim();
                objMaster.Current.CompanyNumber = txtCompanyNumber.Text.Trim();
                objMaster.Current.CompanyVatNumber = txtVATNumber.Text.Trim();
                objMaster.Current.SortCode = txtSortCode.Text.Trim();
                objMaster.Current.IbanNumber = txtIBAN.Text.Trim();
                objMaster.Current.BlcNumber = txtBLC.Text.Trim();

                objMaster.Current.BackgroundColor = txtBgColor.Tag.ToInt();

                string mapIcon = ddlMapIcon.SelectedValue.ToStr().Trim();
                if (string.IsNullOrEmpty(mapIcon))
                    mapIcon = ddlMapIcon.Items[0].Value.ToStr();


                objMaster.Current.MapIcon = mapIcon;


                objMaster.Current.SmtpHasSSL = smtpchkIsSecureConn.Checked;
                objMaster.Current.SmtpHost = SmtpHost.Text.Trim();
                objMaster.Current.SmtpPassword = smtpPassword.Text.Trim();
                objMaster.Current.SmtpPort = smtpPort.Text.Trim();
                objMaster.Current.SmtpUserName = smtpUserName.Text.Trim();

                objMaster.Current.UseDifferentEmailForInvoices = chkUseInvoiceEmail.Checked;
                objMaster.Current.SmtpInvoiceUserName = smtpInvoiceEmail.Text.ToStr().Trim();
                objMaster.Current.SmtpInvoicePassword = smtpInvoicePassword.Text.ToStr().Trim();
                objMaster.Current.SmtpInvoiceHost = smtpInvoiceHost.Text.ToStr().Trim();
                objMaster.Current.SmtpInvoicePort = smtpInvoicePort.Text.Trim();
                objMaster.Current.SmtpInvoiceSSL = smtpInvoiceSSL.Checked;

                objMaster.Current.DisableAcceptEmail = chkDisableAcceptEmail.Checked;
                objMaster.Current.DisableDeclineEmail = chkDisableDeclineEmail.Checked;

                objMaster.Current.ConnectionString = txtCLINumbers.Text.Trim();
                objMaster.Current.DefaultCounty = txtdeadmileageTownPostcode.Text.Trim();
                objMaster.Current.DeadMileage = numdeadMileage.Value.ToDecimal();

                objMaster.Current.DeadMileagePercent = numdeadmileagepercent.Value;
                objMaster.Current.ApplyDeadMileageFromBoundary = chkFromBoundary.Checked;

                string deadMileageType = ddlDeadMileageType.Text.Trim().ToLower();

                if (deadMileageType.Contains("1"))
                    objMaster.Current.DeadMileageType = 1;
                else if (deadMileageType.Contains("2"))
                    objMaster.Current.DeadMileageType = 2;
                else if (deadMileageType.Contains("3"))
                    objMaster.Current.DeadMileageType = 3;
                else if (deadMileageType.Contains("4"))
                    objMaster.Current.DeadMileageType = 4;
                else if (deadMileageType.Contains("5"))
                    objMaster.Current.DeadMileageType = 5;
                else
                {
                    objMaster.Current.DeadMileageType = 0;

                }
                objMaster.Save();

                //

                chkAmount.Checked = true;

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    if (db.Gen_ServiceCharges.Where(c => c.SubCompanyId == objMaster.Current.Id).Count() == 0)
                    {
                        Gen_ServiceCharge objServiceCharge = new Gen_ServiceCharge();
                        objServiceCharge.SubCompanyId = objMaster.Current.Id;
                        objServiceCharge.AmountWise = chkAmount.Checked;
                        if (chkAmount.Checked)
                        {
                            objServiceCharge.ServiceChargePercent = 0;
                            objServiceCharge.ServiceChargeAmount = numBookingFees.Value.ToDecimal();
                        }
                        else
                        {
                            objServiceCharge.ServiceChargeAmount = 0;
                            objServiceCharge.ServiceChargePercent = numBookingFees.Value.ToDecimal();
                        }
                        objServiceCharge.DifferentAirportBookingFee = chkAirportBookingFee.Checked;
                        objServiceCharge.AirportBookingFee = numAirportJobsBookingFee.Value.ToDecimal();
                        db.Gen_ServiceCharges.InsertOnSubmit(objServiceCharge);
                        db.SubmitChanges();
                    }
                    else
                    {
                        // int Id = db.Gen_ServiceCharges.Where(c => c.SubCompanyId == objMaster.Current.Id).FirstOrDefault().Id;
                        var query = db.Gen_ServiceCharges.FirstOrDefault(c => c.SubCompanyId == objMaster.Current.Id);
                        query.AmountWise = chkAmount.Checked;
                        if (chkAmount.Checked)
                        {
                            query.ServiceChargePercent = 0;
                            query.ServiceChargeAmount = numBookingFees.Value.ToDecimal();
                        }
                        else
                        {
                            query.ServiceChargeAmount = 0;
                            query.ServiceChargePercent = numBookingFees.Value.ToDecimal();
                        }


                        query.DifferentAirportBookingFee = chkAirportBookingFee.Checked;
                        query.AirportBookingFee = numAirportJobsBookingFee.Value.ToDecimal();
                        db.SubmitChanges();
                    }


                }
                //


                OnNew();

                PopulateData();


                UpdateEmailSettings();

                return true;

            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
                return false;
            }


        }


        private void UpdateEmailSettings()
        {

            try
            {
                if (grdLister.Rows.Count == 1)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        Gen_SysPolicy_Configuration objPolicy = db.Gen_SysPolicy_Configurations.FirstOrDefault();

                        if (objPolicy != null)
                        {
                            objPolicy.SmtpHost = objMaster.Current.SmtpHost.ToStr();
                            objPolicy.UserName = objMaster.Current.SmtpUserName.ToStr();
                            objPolicy.Password = objMaster.Current.SmtpPassword.ToStr();
                            objPolicy.Port = objMaster.Current.SmtpPort.ToStr();
                            objPolicy.EnableSSL = objMaster.Current.SmtpHasSSL.ToBool();


                            db.SubmitChanges();
                        }
                    }



                }

            }
            catch
            {


            }

        }






        #endregion

        private void frmCompany_FormClosed(object sender, FormClosedEventArgs e)
        {

        }






        private void btnPickBgColor_Click(object sender, EventArgs e)
        {
            SetColor(txtBgColor);
        }

        private void btnClearBgColor_Click(object sender, EventArgs e)
        {
            ClearColor(txtBgColor);
        }



        // Adil 28/5/13
        private void SetColor(TextBox txt)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {

                txt.BackColor = colorDialog1.Color;
                txt.Tag = colorDialog1.Color.ToArgb();
            }

        }
        private void ClearColor(TextBox txt)
        {

            txt.BackColor = Color.White;
            txt.Tag = null;


        }

        private void frmCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

            }
        }

        private void ddlMapIcon_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlMapIcon.SelectedItem != null)
            {
                pb_mapicon.Image = ddlMapIcon.SelectedItem.Image;
            }
            else
            {

                pb_mapicon.Image = null;
            }
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void radLabel7_Click(object sender, EventArgs e)
        {

        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radGroupBox11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnShowDeadMileageFormula_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowRoundRobinFormula();
        }

        private void ddlDeadMileageType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ShowRoundRobinFormula();
        }

        private void lbldeadmileagetownpostcode_Click(object sender, EventArgs e)
        {
          
        }

        private void ShowRoundRobinFormula()
        {

            if (btnShowDeadMileageFormula.ToggleState == ToggleState.On)
            {
                txtRoundRobinFormula.Visible = true;

                numdeadmileagepercent.Visible = false;
                numdeadmileagepercentlabel.Visible = false;

                if (ddlDeadMileageType.Items[0].Selected)
                {

                    txtRoundRobinFormula.Text = "A= (TOWN To Pickup)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "B= (Journey Mileage)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "C= (Destination To TOWN)" + Environment.NewLine + Environment.NewLine;
                    txtRoundRobinFormula.Text += "Mileage = (A + B + C) /2";


                }

                else if (ddlDeadMileageType.Items[1].Selected)
                {

                    txtRoundRobinFormula.Text = "A= (TOWN To Pickup)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "B= (Journey Mileage)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "C= (Destination To TOWN)" + Environment.NewLine + Environment.NewLine;
                    txtRoundRobinFormula.Text += "Mileage = A/2 + B + C/2";


                }

                else if (ddlDeadMileageType.Items[2].Selected)
                {

                    txtRoundRobinFormula.Text = "A= (TOWN To Pickup)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "B= (Journey Mileage)" + Environment.NewLine + Environment.NewLine;
                    //   txtRoundRobinFormula.Text = "C= (Destination To BASE)" + Environment.NewLine + Environment.NewLine;
                    txtRoundRobinFormula.Text += "Mileage = (A + B) ";


                }
                else if (ddlDeadMileageType.Items[3].Selected)
                {

                    txtRoundRobinFormula.Text = "A= (TOWN To Pickup)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "B= (Journey Mileage)" + Environment.NewLine + Environment.NewLine;
                    //   txtRoundRobinFormula.Text = "C= (Destination To BASE)" + Environment.NewLine + Environment.NewLine;
                    txtRoundRobinFormula.Text += "Mileage = A/2 + B ";


                }
                else if (ddlDeadMileageType.Items[4].Selected)
                {
                    numdeadmileagepercent.Visible = true;
                    numdeadmileagepercentlabel.Visible = true;
                    txtRoundRobinFormula.Text = "A= (TOWN To Pickup)" + Environment.NewLine;
                    txtRoundRobinFormula.Text += "B= (Journey Mileage)" + Environment.NewLine + Environment.NewLine;
                    //   txtRoundRobinFormula.Text = "C= (Destination To BASE)" + Environment.NewLine + Environment.NewLine;
                    txtRoundRobinFormula.Text += "Mileage = B + (LowestDeadMileage*DeadMileage%) ";


                }
                else
                {
                    txtRoundRobinFormula.Text = "";
                }

            }
            else
            {

                txtRoundRobinFormula.Visible = false;
                txtRoundRobinFormula.Text = "";
                numdeadmileagepercent.Visible = false;
                numdeadmileagepercentlabel.Visible = false;
            }
        }

        private void chkAirportBookingFee_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
           

                numAirportJobsBookingFee.Enabled = args.ToggleState == ToggleState.On? true:false;

            if (numAirportJobsBookingFee.Enabled == false)
                numAirportJobsBookingFee.Value = 0.00m;

        }
    }



}
