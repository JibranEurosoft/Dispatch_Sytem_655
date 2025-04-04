﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Telerik.WinControls.UI;
using Taxi_BLL;
using Taxi_Model;
using DAL;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls;
using System.Linq.Expressions;

namespace Taxi_AppMain
{
    public partial class frmDriverCommissionDebitCredit5 : UI.SetupBase
    {
        List<Fleet_Driver_CommissionRange> listOfCommRange = null;

        DriverCommisionBO objMaster = null;
        private bool IsFareAndWaitingWiseComm;
        bool IsNotesExpenseAdded = false;
        int TotalWeeks = 0;
        //public decimal MaxCommission { get; set; }
        //  decimal Commision = 0;

        public struct COLS
        {
            public static string ID = "ID";
            public static string TransId = "TransId";
            public static string BookingId = "BookingId";

            public static string PickupDate = "PickupDate";
            public static string Vehicle = "Vehicle";
            public static string VehicleID = "VehicleID";
            public static string OrderNo = "OrderNo";
            public static string PupilNo = "PupilNo";
            public static string BookedBy = "BookedBy";

            public static string RefNumber = "RefNumber";

            public static string Passenger = "Passenger";

            public static string PickupPoint = "PickupPoint";
            public static string Destination = "Destination";

            public static string Charges = "Charges";

            public static string Parking = "Parking";
            public static string Waiting = "Waiting";
            public static string ExtraDrop = "ExtraDrop";
            public static string MeetAndGreet = "MeetAndGreet";
            public static string CongtionCharge = "CongtionCharge";
            public static string RemovalDescription = "RemovalDescription";
            public static string Total = "Total";
            public static string Commission = "Commission";
            public static string IsCommissionWise = "IsCommissionWise";
            public static string CommissionType = "CommissionType";
            public static string CommissionValue = "CommissionValue";

            public static string AgentFees = "AgentFees";

            
            public static string Payment_ID = "Payment_ID";
            public static string PaymentType = "PaymentType";


            public static string Fares = "Fares";
            public static string Account = "Account";
            public static string CompanyId = "CompanyId";
            public static string AccountTypeId = "AccountTypeId";
            public static string PaymentTypeId = "PaymentTypeId";

            public static string BookingFees = "BookingFees";

        }
        public struct EXPCOLS
        {
            public static string Id = "Id";
            public static string User = "User";
            public static string CommissionId = "CommissionId";
            public static string Debit = "Debit";
            public static string Credit = "Credit";
            public static string Amount = "Amount";
            public static string Description = "Description";
            public static string Date = "Date";
        }


       

        public void FormatExpenseGrid()
        {
            grdDriverExpenses.ShowGroupPanel = false;
            //    grdLister.AutoCellFormatting = true;
            grdDriverExpenses.ShowRowHeaderColumn = false;
            grdDriverExpenses.AllowAddNewRow = false;
            grdDriverExpenses.Font = new Font("Tahoma", 10, FontStyle.Bold);
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = EXPCOLS.Id;
            col.IsVisible = false;
            grdDriverExpenses.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = EXPCOLS.User;
            col.IsVisible = false;
            grdDriverExpenses.Columns.Add(col);


      


            col = new GridViewTextBoxColumn();
            col.Name = EXPCOLS.CommissionId;
            col.IsVisible = false;
            grdDriverExpenses.Columns.Add(col);
            GridViewDecimalColumn dcol = new GridViewDecimalColumn();
             
            dcol.Name = EXPCOLS.Credit;
            dcol.ReadOnly = true;
            dcol.Width = 75;
            dcol.HeaderText = EXPCOLS.Credit;
            grdDriverExpenses.Columns.Add(dcol);
            dcol = new GridViewDecimalColumn();
            dcol.Name = EXPCOLS.Debit;
            dcol.HeaderText = EXPCOLS.Debit;
            dcol.ReadOnly = true;
            dcol.Width = 75;
            grdDriverExpenses.Columns.Add(dcol);

            dcol = new GridViewDecimalColumn();
            dcol.Name = EXPCOLS.Amount;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdDriverExpenses.Columns.Add(dcol);
            col = new GridViewTextBoxColumn();
            col.Name = EXPCOLS.Description;
            col.HeaderText = EXPCOLS.Description;
            col.Width = 200;
            col.ReadOnly = true;
            grdDriverExpenses.Columns.Add(col);
            GridViewDateTimeColumn dtcol = new GridViewDateTimeColumn();
            dtcol.Name = EXPCOLS.Date;
            dtcol.IsVisible = false;
            grdDriverExpenses.Columns.Add(dtcol);
            GridViewCommandColumn cmdcol = new GridViewCommandColumn();
            cmdcol.Width = 80;
            cmdcol.Name = "Delete";
            cmdcol.UseDefaultText = true;
            cmdcol.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            cmdcol.DefaultText = "Delete";
            cmdcol.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grdDriverExpenses.Columns.Add(cmdcol);
        }
        public frmDriverCommissionDebitCredit5()
        {
            InitializeComponent();
            InitializeConstructor();

        }
        public frmDriverCommissionDebitCredit5(int Id)
        {
            InitializeComponent();
            InitializeConstructor();
            ddlDriver.SelectedValue = Id;

        }
        private void frmDriverRent_Load(object sender, EventArgs e)
        {

        }
        private void frmDriverRent_Shown(object sender, EventArgs e)
        {
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void InitializeConstructor()
        {
            objMaster = new DriverCommisionBO();

            ComboFunctions.FillDriverNoCombo(ddlDriver, c => c.DriverTypeId == Enums.DRIVERTYPES.COMMISSION && c.IsActive==true);

            dtpTransactionDate.Value = DateTime.Now.ToDateTime();
            FormatChargesGrid();
            FormatExpenseGrid();
            txtDriverOwed.Text = string.Empty;
            grdLister.ShowGroupPanel = false;
            //    grdLister.AutoCellFormatting = true;
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdLister.ShowRowHeaderColumn = false;

            grdLister.Font = new Font("Tahoma", 9, FontStyle.Bold);

            this.SetProperties((INavigation)objMaster);

            grdLister.AllowAddNewRow = false;

            grdLister.AllowDeleteRow = false;


            dtpFromDate.Value = DateTime.Now.ToDate().AddDays(-6);
            dtpTillDate.Value = DateTime.Now.ToDate();

            txtDriverOwed.Text = "0.00";
            txtBalance.Text = "0.00";
            txtCommisionPayment.Text = "0.00";
            txtExtra.Text = "0.00";
            numParkingTotal.Value = 0.00m;
            //   grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);


            dtpFromDate.DateTimePickerElement.ValueChanging += new ValueChangingEventHandler(DateTimePickerElement_ValueChanging);
            dtpTillDate.DateTimePickerElement.ValueChanging += new ValueChangingEventHandler(DateTimePickerElement_ValueChanging);
            this.btnSendEmail.Click += new EventHandler(btnSendEmail_Click);
            this.btnExportPDF.Click += new EventHandler(btnExportPDF_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSaveInvoice.Click += new EventHandler(btnSaveInvoice_Click);
            this.btnAddNew.Click += new EventHandler(btnAddNew_Click);
            this.btnPaymentHistory.Click += new EventHandler(btnPaymentHistory_Click);
            this.grdDriverExpenses.CommandCellClick += new CommandCellClickEventHandler(grdDriverExpenses_CommandCellClick);
            this.ddlDriver.SelectedValueChanged += new EventHandler(ddlDriver_SelectedValueChanged);
           
           
          

            if (AppVars.objPolicyConfiguration.DaysForAccJob.ToBool() == true)
            {
                ddlAccountBookingDays.Items[0].Selected = true;
                ddlAccountBookingDays.Text = "0";
            }

            if (AppVars.objPolicyConfiguration.PriceRangeWiseCommission.ToBool())
            {

                listOfCommRange = GetSystemCommissionRange();
            }
            txtRemarks.ListBoxElement.Width = 100;
            txtRemarks.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtRemarks.ListBoxElement.Height = 100;

            chkCarryForwardBalance.Visible = AppVars.listUserRights.Count(c => c.functionId == "DISABLE C/F OLD BALANCE") > 0;
            chkCarryForwardBalance.Tag = AppVars.listUserRights.Count(c => c.functionId == "DISABLE C/F OLD BALANCE") > 0;




        }


        private void SetWeekDates(int? driverId)
        {
            if (objMaster.PrimaryKeyValue == null)
            {

                var query1 = General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == driverId)
                                      .OrderByDescending(c => c.Id).FirstOrDefault();
                if (query1 != null)
                {
                    DateTime? dtTill = query1.ToDate.ToDateorNull();
                    dtpFromDate.Value = dtTill.Value.AddDays(1);
                    dtpTillDate.Value = dtTill.Value.AddDays(7);
                
                }
            }

        }

        void ddlDriver_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int DriverId = ddlDriver.SelectedValue.ToInt();

                if (DriverId == 0)
                    return;




             

                SetWeekDates(DriverId);

                if (objMaster.Current != null && objMaster.Current.Id > 0)
                    return;
                
                Fleet_Driver obj = General.GetObject<Fleet_Driver>(c => c.Id == DriverId);
                if (obj != null)
                {


              

                    //MaxCommission
                    numMaxCommission.Value = obj.MaxCommission.ToDecimal();

                    numMinCommLimit.Value = obj.NICNo.ToStr().Trim().IsNumeric() ? obj.NICNo.ToStr().Trim().ToDecimal() : 0.00m;

                    //
                    if (General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == obj.Id).Count() == 0)
                    {


                        txtOldBalance.Text = (obj.InitialBalance.ToDecimal()).ToStr();

                    }

                    else
                    {
                        SetOldBalance(DriverId);
                        //if (chkCarryForwardBalance.Visible == false || chkCarryForwardBalance.Checked)
                        //{

                        //    var query = General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == DriverId).OrderByDescending(c => c.Id).FirstOrDefault();

                        //    if (query != null)
                        //    {
                        //        decimal driverBalance = query.Balance.ToDecimal();
                        //        txtOldBalance.Text = (driverBalance).ToStr();
                        //    }
                        //    else
                        //    {
                        //        txtOldBalance.Text = "0.00";
                        //    }
                        //}
                    }
                    if (obj.VAT.ToDecimal() > 0)
                    {
                        lblVAT.Visible = true;
                        numVAT.Visible = true;
                        numVAT.Value = obj.VAT.ToDecimal();
                        numVAT.Enabled = true;
                    }
                    else
                    {
                        lblVAT.Visible = false;
                        numVAT.Visible = false;
                    }

                    AddDefeultExpenseValue();
                    numCommissionPercent.Value = obj.DriverCommissionPerBooking.ToDecimal();
                    numacccommpercent.Value = obj.PrimeCompanyRent.ToDecimal();


                    if(obj.IsPrimeCompanyDriver.ToBool())
                    {
                        numacccommpercent.Visible = true;
                        lblAccComm.Visible = true;
                        lblAccCommPercent.Visible = true;
                        numacccommpercent.Enabled = false;
                    }
                    else
                    {
                        numacccommpercent.Visible = false;
                        lblAccComm.Visible = false;
                        lblAccCommPercent.Visible = false;
                    }


                    numPDARentPerWeek.Value = obj.PDARent.ToDecimal();

                    CalculateTotal();
                //    CalculateBalance();

                    if (AppVars.objPolicyConfiguration.PriceRangeWiseCommission.ToBool())
                    {
                        if (obj.Fleet_Driver_CommissionRanges.Count > 0)
                        {
                            listOfCommRange = obj.Fleet_Driver_CommissionRanges.ToList();
                        }
                        else
                        {
                            listOfCommRange = GetSystemCommissionRange();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


        private void SetOldBalance(int? DriverId)
        {
            try
            {
                if ((chkCarryForwardBalance.Visible == false && chkCarryForwardBalance.Tag.ToBool()==false) || chkCarryForwardBalance.Checked)
                {

                    var query = General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == DriverId).OrderByDescending(c => c.Id).FirstOrDefault();

                    if (query != null)
                    {
                        decimal driverBalance = query.Balance.ToDecimal();
                        txtOldBalance.Text = (driverBalance).ToStr();
                    }
                    else
                    {
                        txtOldBalance.Text = "0.00";
                    }
                }
                else
                {
                    txtOldBalance.Text = "0.00";
                }

            }
            catch
            {
            }

        }

        void grdDriverExpenses_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name.ToLower() == "delete")
                {
                    if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete Entry? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    {
                        RadGridView grid = gridCell.GridControl;
                        grid.CurrentRow.Delete();
                        CalculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            try
            {

                if (objMaster.Current != null && objMaster.PrimaryKeyValue != null)
                {

                    frmSearchDriverCommissionPaymentHistory frm = new frmSearchDriverCommissionPaymentHistory("", objMaster.Current.DriverCommission_PaymentHistories.OrderBy(c => c.PaymentDate).ToList());

                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();


                    frm.Dispose();
                    frm = null;

                    GC.Collect();



                }
            }
            catch (Exception ex)
            {

            }
        }

        void btnAddNew_Click(object sender, EventArgs e)
        {
            OnNew();
        }

        void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {

            if (ddlDriver.SelectedValue == null)
            {
                ENUtils.ShowMessage("Please select a driver");
                ddlDriver.Focus();
                return;
            }

            AddDriverExpenses();
           
        }

        void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;


            frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);
            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "summary_";

            }
            var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(c => c.CommissionId == id).OrderBy(c => c.Date).ToList();
            frm.DataSource2 = list2;

            frm.IsFareAndWaitingWise = this.IsFareAndWaitingWiseComm;
            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }
            frm.GenerateReport();


          

            frm.ExportReport(objMaster.Current.TransNo);
        }

        void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;


            frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);

            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "summary_";

            }

            var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            int count = list.Count;

      
            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(c => c.CommissionId == id).OrderBy(c => c.Date).ToList();
            frm.DataSource2 = list2;


            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }


            frm.objSubCompany = objMaster.Current.Fleet_Driver.Gen_SubCompany;
          
            frm.GenerateReport();

            frm.SendEmail(objMaster.Current.TransNo, objMaster.Current.Fleet_Driver.DefaultIfEmpty().Email.ToStr().Trim());
        }

        void DateTimePickerElement_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (grdLister.Rows.Count > 0)
            {

                if (DialogResult.Yes == MessageBox.Show("You cannot Change Date After Selecting the Jobs! " + Environment.NewLine +
                     "To Change Date Filter , You need to Remove All the Jobs" + Environment.NewLine +
                     "Do you want to Remove All the Jobs ? ", "Warning", MessageBoxButtons.YesNo))
                {

                    grdLister.Rows.Clear();
                    numCommissionPercent.Enabled = true;
                    numMaxCommission.Enabled = true;
                    numMinCommLimit.Enabled = true;
                    btnPick.Enabled = true;
                    CalculateTotal();
               //     CalculateBalance();

                }
                else
                {
                    e.Cancel = true;
                    numCommissionPercent.Enabled = false;
                    numMaxCommission.Enabled = false;

                    numMinCommLimit.Enabled = false;

                }


            }
        }

        private List<Fleet_Driver_CommissionRange> GetSystemCommissionRange()
        {
            return (from a in General.GetQueryable<Gen_SysPolicy_CommissionPriceRange>(null).ToList()
                    select new Fleet_Driver_CommissionRange
                    {
                        DriverId = 0,
                        FromPrice = a.FromPrice,
                        ToPrice = a.ToPrice,
                        CommissionValue = a.CommissionValue


                    }).ToList();

        }

        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name == "btnUpdate")
                {

                    GridViewRowInfo row = gridCell.RowInfo;

                    if (row is GridViewDataRowInfo)
                    {

                        long id = row.Cells[COLS.BookingId].Value.ToLong();
                       
                        decimal fare = row.Cells[COLS.Fares].Value.ToDecimal();
                        decimal parking = row.Cells[COLS.Parking].Value.ToDecimal();
                        decimal waiting = row.Cells[COLS.Waiting].Value.ToDecimal();
                        decimal extra = row.Cells[COLS.ExtraDrop].Value.ToDecimal();
                        decimal bookingfee = row.Cells[COLS.BookingFees].Value.ToDecimal();
                        decimal agentfee = row.Cells[COLS.AgentFees].Value.ToDecimal();
                        //    decimal tip = row.Cells[COLS.Tip].Value.ToDecimal();


                        // decimal TotalCharges = row.Cells[COLS.Total].Value.ToDecimal();
                        //// string Destination = row.Cells[COLS.Destination].Value.ToStr();
                        // string PickupPoint = row.Cells[COLS.PickupPoint].Value.ToStr();
                        //  string Passenger = row.Cells[COLS.Passenger].Value.ToStr();

                        if (bookingfee>fare)
                        {
                            MessageBox.Show("Booking Fee cannot be greater than Fares");
                            return;
                        }

                        BookingBO objMaster = new BookingBO();
                        objMaster.GetByPrimaryKey(id);

                        if (objMaster.Current != null)
                        {
                            objMaster.Current.FareRate = fare;
                            objMaster.Current.CongtionCharges = parking;
                            objMaster.Current.MeetAndGreetCharges = waiting;
                            objMaster.Current.ServiceCharges = bookingfee;
                            objMaster.Current.ExtraDropCharges = extra;
                            // objMaster.Current.TipAmount = tip;
                            objMaster.Current.AgentCommission = agentfee;
                            // objMaster.Current.TotalCharges = TotalCharges;

                            if (objMaster.Current.CompanyId == null)
                            {
                                objMaster.Current.TotalCharges = objMaster.Current.FareRate.ToDecimal()
                                             + objMaster.Current.ExtraDropCharges.ToDecimal() + objMaster.Current.MeetAndGreetCharges.ToDecimal() + objMaster.Current.CongtionCharges.ToDecimal();
                            }
                            else
                            {
                                objMaster.Current.TotalCharges = objMaster.Current.CompanyPrice.ToDecimal() + objMaster.Current.ParkingCharges.ToDecimal() + objMaster.Current.WaitingCharges.ToDecimal() + objMaster.Current.ExtraDropCharges.ToDecimal();

                            }

                            objMaster.CheckCustomerValidation = false;
                            objMaster.CheckDataValidation = false;
                            objMaster.DisableUpdateReturnJob = true;
                            objMaster.Save();

                            row.Cells[COLS.Total].Value = (fare  + waiting + extra );

                            if (AppVars.objPolicyConfiguration.NoCommissionFromAccount.ToBool() && row.Cells[COLS.PaymentTypeId].Value.ToInt()==Enums.PAYMENT_TYPES.BANK_ACCOUNT)
                            {
                                row.Cells[COLS.Commission].Value = 0.00m;

                            }
                            else
                            {
                                row.Cells[COLS.Commission].Value = ((row.Cells[COLS.Fares].Value.ToDecimal() + row.Cells[COLS.Waiting].Value.ToDecimal() + row.Cells[COLS.ExtraDrop].Value.ToDecimal()) * numCommissionPercent.Value) / 100;

                            }



                            if (row.Cells["NoComm"].Value.ToBool() == true)
                            {
                                row.Cells[COLS.Commission].Value = 0.00m;



                            }

                            CalculateTotal();


                            long index = grdLister.CurrentRow != null ? grdLister.CurrentRow.Cells["Id"].Value.ToLong() : -1;
                            int val = grdLister.TableElement.VScrollBar.Value;


                            Save();



                            if (index > 0)
                                grdLister.CurrentRow = grdLister.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == index);

                            grdLister.TableElement.VScrollBar.Value = val;
                        }
                    }
                }
            }
            catch
            {



            }

        }

        //void grdLister_CommandCellClick(object sender, EventArgs e)
        //{
        //    GridCommandCellElement gridCell = (GridCommandCellElement)sender;
        //    if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
        //    {
        //        if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Trash Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
        //        {
        //            RadGridView grid = gridCell.GridControl;
        //            grid.CurrentRow.Delete();
        //        }
        //    }

        //}

        private void FormatChargesGrid()
        {

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();

            col.IsVisible = false;
            col.Name = "Id";
            grdLister.Columns.Add(col);





            col = new GridViewTextBoxColumn();
            col.Name = COLS.CompanyId;
            col.HeaderText = "ComapanyID";
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.TransId;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.BookingId;
            grdLister.Columns.Add(col);

            GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
            colDt.Name = "PickupDate";
            colDt.ReadOnly = true;
            colDt.HeaderText = "Pickup Date-Time";
            grdLister.Columns.Add(colDt);




            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Job #";
            col.Name = "RefNumber";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
             col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "PickupPlot";
            col.Name = "PickupPlot";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "DropoffPlot";
            col.Name = "DropoffPlot";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Order No";
            col.Name = "OrderNo";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Booked By";
            col.Name = COLS.BookedBy;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Pupil No";
            col.Name = "PupilNo";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Vehicle";
            col.Name = "Vehicle";
            grdLister.Columns.Add(col);


            GridViewComboBoxColumn colCombo = new GridViewComboBoxColumn();
            colCombo.Name = COLS.VehicleID;
            colCombo.HeaderText = "Vehicle";
            colCombo.DataSource = General.GetQueryable<Fleet_VehicleType>(null).OrderBy(c => c.OrderNo).ToList();
            colCombo.DisplayMember = "VehicleType";
            colCombo.ValueMember = "Id";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.DataType = typeof(int);
            grdLister.Columns.Add(colCombo);
            colCombo.IsVisible = false;
            colCombo.ReadOnly = false;






            col = new GridViewTextBoxColumn();
            col.Name = COLS.PaymentType;
            col.Width = 70;
            col.HeaderText = "Payment Type";
            col.IsVisible = true;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.Name = COLS.Passenger;
            col.HeaderText = "Passenger";
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Width = 900;
            col.IsVisible = false;
            col.ReadOnly = true;
            col.Name = COLS.RemovalDescription;
            col.HeaderText = "Description";
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.Name = COLS.Account;
            col.HeaderText = "Account";
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            GridViewCheckBoxColumn NoCommCol = new GridViewCheckBoxColumn();
            NoCommCol.Name = "NoComm";
            NoCommCol.HeaderText = "NO COMM.";
            NoCommCol.ReadOnly = true;
            NoCommCol.IsVisible = false;
            grdLister.Columns.Add(NoCommCol);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Pickup Point";
            col.Name = "PickupPoint";
            col.ReadOnly = true;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.HeaderText = "Destination";
            col.Name = "Destination";
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Charges";
            colD.Name = "Charges";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Fares";
            colD.Name = "Fares";
            colD.Maximum = 9999999;
            colD.ReadOnly = false;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Parking";
            colD.Name = "Parking";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            //colD.IsVisible = false;
            colD.ReadOnly = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Waiting";
            colD.Name = "Waiting";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.ReadOnly = false;
            //colD.IsVisible = false;
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Extra";
            colD.Name = "ExtraDrop";
            colD.IsVisible = true;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            //colD.IsVisible = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Meet and Greet";
            colD.Name = "MeetAndGreet";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Congestion";
            colD.Name = "CongtionCharge";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);



            string CommissionExpression = "";


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Agent Fee";
            colD.Name = "AgentFees";
            colD.Maximum = 9999999;
            colD.ReadOnly = true;
            colD.IsVisible = AppVars.objPolicyConfiguration.BookingFormType.ToInt()==2;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "BookingFee";
            colD.Name = COLS.BookingFees;
            colD.Maximum = 9999999;
            colD.ReadOnly = false;
            colD.IsVisible = true;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.IsVisible = true;
            colD.HeaderText = "Paid Promotion";
            colD.Name = "Promotion";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);



            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.IsVisible = true;
            colD.HeaderText = "Promotion";
            colD.Name = "SubtractPromotion";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.IsVisible = true;
            colD.HeaderText = "Total";
            colD.Name = "Total";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";




            //if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 1)
            //{
            //    CommissionExpression = "(Fares-AgentFees)";
            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 2)
            //{
            //    CommissionExpression = "(Fares+AgentFees)";
            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 3)
            //{
            //    CommissionExpression = "(Fares+Waiting+Parking)-AgentFees";

            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 4)
            //{
            //    CommissionExpression = "Fares";

            //}

            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 5)
            //{
            //    CommissionExpression = "(Fares+Waiting+Parking)+AgentFees";

            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 6)
            //{
            //    CommissionExpression = "(Fares+Waiting+Parking)";

            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 7)
            //{
            //    CommissionExpression = "(Fares+Waiting)";

            //    grdLister.Columns["Waiting"].IsVisible = true;

            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 8)
            //{
            //    grdLister.Columns["Waiting"].IsVisible = true;
            //    CommissionExpression = "(Fares+Waiting)-AgentFees";
            //    IsFareAndWaitingWiseComm = true;
            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 9)
            //{

            //    CommissionExpression = "(Fares-AgentFees)";

            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 10)
            //{
            //    CommissionExpression = "(Fares+Waiting+Parking+ExtraDrop)";
            //}


            //if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 10)
            //{
                CommissionExpression = "( Fares+Waiting+Parking+ExtraDrop+BookingFees)-SubtractPromotion";

            //   }
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 11)
            //{
            //    CommissionExpression = "(Fares+Waiting)";
            //}
            //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 12)
            //{
            //    CommissionExpression = "(Fares)";
            //}

            // if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 12)
            //{
            //    CommissionExpression = "( Fares+Parking+ExtraDrop+BookingFees)-SubtractPromotion";
            //}

            colD.Expression = CommissionExpression;
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = COLS.Commission;
            colD.Name = COLS.Commission;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = true;
            colD.ReadOnly = true;
            grdLister.Columns.Add(colD);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.IsCommissionWise;
            col.Name = COLS.IsCommissionWise;
            col.ReadOnly = true;
            col.IsVisible = false;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.CommissionType;
            col.Name = COLS.CommissionType;
            col.ReadOnly = true;
            col.IsVisible = false;
            grdLister.Columns.Add(col);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = COLS.CommissionValue;
            colD.Name = COLS.CommissionValue;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);






            //GridViewComboBoxColumn colPayment = new GridViewComboBoxColumn();
            //colPayment.Name = COLS.Payment_ID;
            //colPayment.HeaderText = "Status";
            //colPayment.DataSource = General.GetQueryable<Invoice_PaymentType>(null).Where(c => c.Id == 1 || c.Id == 3).OrderBy(c => c.Id).ToList();
            //colPayment.DisplayMember = "PaymentType";
            //colPayment.ValueMember = "Id";
            //colPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            //colPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //colPayment.DataType = typeof(int);
            //colPayment.IsVisible = false;
            //grdLister.Columns.Add(colPayment);
            //colPayment.ReadOnly = false;



            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.AccountTypeId;
            col.Name = COLS.AccountTypeId;
            col.ReadOnly = true;
            col.IsVisible = false;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.PaymentTypeId;
            col.Name = COLS.PaymentTypeId;
            col.ReadOnly = true;
            col.IsVisible = false;
            grdLister.Columns.Add(col);


          

            (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
            (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


            grdLister.Columns["PickUpDate"].Width = 60;

            grdLister.Columns["Account"].Width = 75;

            grdLister.Columns["RefNumber"].Width = 40;
            grdLister.Columns["Vehicle"].Width = 60;
            grdLister.Columns[COLS.Passenger].Width = 60;
            grdLister.Columns["PickUpPoint"].Width = 80;
            grdLister.Columns["Destination"].Width = 80;

            grdLister.Columns["Charges"].Width = 50;
            grdLister.Columns["Parking"].Width = 45;
            grdLister.Columns["Waiting"].Width = 45;
            grdLister.Columns["ExtraDrop"].Width = 50;
            grdLister.Columns["MeetAndGreet"].Width = 50;
            grdLister.Columns["CongtionCharge"].Width = 60;

            grdLister.Columns[COLS.Commission].Width = 60;

            grdLister.Columns["Total"].Width = 45;
            grdLister.Columns["OrderNo"].Width = 55;

            grdLister.Columns["PickUpDate"].HeaderText = "Pickup Date-Time";
            grdLister.Columns["RefNumber"].HeaderText = "Ref #";
            grdLister.Columns["PickUpPoint"].HeaderText = "Pickup Point";
            //grdLister.Columns["ExtraDrop"].HeaderText = "Extra Drop";

            grdLister.Columns["MeetAndGreet"].HeaderText = "M & G";
            grdLister.Columns["CongtionCharge"].HeaderText = "Congestion";
           // grdLister.Columns["Payment_ID"].Width = 70;



            AddUpdateColumn(grdLister);

        }

        private void AddUpdateColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 50;

            col.Name = "btnUpdate";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Update";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);
            grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            grdLister.ViewCellFormatting += GrdLister_ViewCellFormatting;
        }

        private void GrdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {


                if (e.Column.Name.ToLower() == "btnupdate")
                {


                    ((RadButtonElement)e.CellElement.Children[0]).Enabled = btnSaveInvoice.Enabled;


                }





            }
            catch (Exception ex)
            {

            }
        }


        //private void AddCommandColumn(RadGridView grid, string colName, string caption)
        //{
        //    GridViewCommandColumn col = new GridViewCommandColumn();
        //    col.Width = 60;

        //    col.Name = colName;
        //    col.UseDefaultText = true;
        //    col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
        //    col.DefaultText = caption;
        //    col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

        //    grid.Columns.Add(col);

        //}

        protected override void OnClosed(EventArgs e)
        {
            General.RefreshListWithoutSelected<frmCompanyInvoiceList>("frmCompanyInvoiceList1");

        }


        public override void Save()
        {
            OnSave();
        }
        private void OnSave()
        {
            try
            {

                int DriverId = ddlDriver.SelectedValue.ToInt();

                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                }
                else
                {

                    DateTime? LastEditDate = objMaster.Current.EditOn;

                    var query = General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == DriverId).OrderByDescending(c => c.Id).FirstOrDefault();

                    if (query != null)
                    {
                        string Transno = query.TransNo.ToStr();

                        if (Transno == txtTransNo.Text)
                        {

                            if (General.GetQueryable<DriverCommission_PaymentHistory>(c => c.CommissionId == objMaster.Current.Id).Count() > 0)
                            {
                                ENUtils.ShowMessage("Can not Save Record. Payment already Exist Against this Transaction..");
                                return;
                            }

                            objMaster.Edit();
                        }
                        else
                        {
                            ENUtils.ShowMessage("Can not Save Record. Another Record Exist..");
                            return;
                        }
                    }
                    else
                    {

                        if (General.GetQueryable<DriverCommission_PaymentHistory>(c => c.CommissionId == objMaster.Current.Id).Count() > 0)
                        {
                            ENUtils.ShowMessage("Can not Save Record. Payment already Exist Against this Transaction..");
                            return;
                        }


                        if (General.GetQueryable<DriverCommission_PaymentHistory>(c => c.CommissionId == objMaster.Current.Id).Count() > 0)
                        {
                            ENUtils.ShowMessage("Can not Save Record. Payment already Exist Against this Transaction..");
                            return;
                        }
                 
                        objMaster.Edit();
                      

                    }

                    DateTime? NewEditDate = objMaster.Current.EditOn;

                    if (NewEditDate != null)
                    {
                        if (LastEditDate == null && NewEditDate != null)
                        {
                            ENUtils.ShowMessage("This record is already updated from other side" + Environment.NewLine + "you need to close and open this record again");
                            return;
                        }
                        else
                        {

                            if (LastEditDate < NewEditDate)
                            {
                                ENUtils.ShowMessage("This record is already updated from other side" + Environment.NewLine + "you need to close and open this record again");
                                return;
                            }
                        }

                    }
                }
             //   decimal Fuel = txtFuel.Text == "" ? 0 : txtFuel.Text.ToDecimal();
                decimal Extra = txtExtra.Text == "" ? 0 : txtExtra.Text.ToDecimal();


                DateTime Datetime = dtpTransactionDate.Value.ToDateTime();
                objMaster.Current.TransDate = dtpTransactionDate.Value.ToDateTime();
                objMaster.Current.DriverId = ddlDriver.SelectedValue.ToIntorNull();
                //  objMaster.Current.DriverCommision = txtDriverOwed.Text == "" ? 0 : txtDriverOwed.Text.ToDecimal();
                objMaster.Current.DriverCommision = numCommissionPercent.Value;


                objMaster.Current.Balance = txtBalance.Text.ToDecimal();
                objMaster.Current.OldBalance = txtOldBalance.Text.ToDecimal();

                objMaster.Current.FromDate = dtpFromDate.Value.ToDate();
                objMaster.Current.ToDate = dtpTillDate.Value.ToDate();
                objMaster.Current.TransFor = ddlDayWise.SelectedText.ToStr();
                objMaster.Current.VAT = numVAT.Value.ToDecimal();

             //   objMaster.Current.CollectionDeliveryCharges


                objMaster.Current.AccountExpenses = spnAccountExpenses.Value.ToDecimal();
                objMaster.Current.JobsTotal = grdLister.Rows.Sum(c => c.Cells[COLS.Fares].Value.ToDecimal()
                + c.Cells[COLS.Waiting].Value.ToDecimal()
                + c.Cells[COLS.ExtraDrop].Value.ToDecimal());

                objMaster.Current.Remarks =numMinCommLimit.Value.ToStr();

                objMaster.Current.IsCreditOrDebit = optCredit.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On ? true : false;


                objMaster.Current.PDARent = numpdaRent.Value.ToDecimal();
                objMaster.Current.DriverOwed = txtDriverOwed.Text == "" ? 0 : txtDriverOwed.Text.ToDecimal();


                objMaster.Current.AgentFeesTotal = numAgentFeeTotal.Value;
                objMaster.Current.OldAgentCommission = NumAccountBookingFeeTotal.Value;
                objMaster.Current.Extra = numPDARentPerWeek.Value;
             //   objMaster.Current.CommissionTotal = ((objMaster.Current.JobsTotal - objMaster.Current.AgentFeesTotal) * numCommissionPercent.Value) / 100;
                objMaster.Current.CommissionTotal = txtCommsionTotal.Text.ToDecimal();
                
                //grdLister.Rows.Sum(c => c.Cells[COLS.Commission].Value.ToDecimal()).ToDecimal();


                //objMaster.Current.AccJobsTotal = grdLister.Rows.Where(c => c.Cells[COLS.CompanyId].Value != null).Sum(c => c.Cells[COLS.Fares].Value.ToDecimal()).ToDecimal();
                objMaster.Current.AccJobsTotal = txtTotalAccountBooking.Text.Replace("£","").ToDecimal();

                //  objMaster.Current.CollectionDeliveryCharges = numTotalCollectionDelivery.Value.ToDecimal();
                objMaster.Current.CollectionDeliveryCharges = numPromotion.Value;
                objMaster.Current.AccountBookingDays = ddlAccountBookingDays.Text.ToInt();
                objMaster.Current.TotalWeeks = TotalWeeks;
                objMaster.Current.Fuel = numParkingTotal.Value.ToDecimal();


                objMaster.Current.Adjustments = numExtraTotal.Value.ToDecimal();



                // objMaster.Current.Extra = Extra.ToDecimal();
                //MaxCommission
                objMaster.Current.MaxCommission = numMaxCommission.Value.ToDecimal();
                //
                objMaster.Current.WeekOff = chkHoliday.Checked;

                string[] skipProperties = { "Fleet_DriverCommision", "Booking" };
                IList<Fleet_DriverCommision_Charge> savedList = objMaster.Current.Fleet_DriverCommision_Charges;
                List<Fleet_DriverCommision_Charge> listofDetail = (from r in grdLister.Rows

                                                            select new Fleet_DriverCommision_Charge
                                                            {
                                                                Id = r.Cells[COLS.ID].Value.ToLong(),
                                                                TransId = r.Cells[COLS.TransId].Value.ToLong(),
                                                                BookingId = r.Cells[COLS.BookingId].Value.ToLongorNull(),
                                                                CommissionPerBooking = r.Cells[COLS.Commission].Value.ToDecimal()
                                                            }).ToList();


                Utils.General.SyncChildCollection(ref savedList, ref listofDetail, "Id", skipProperties);
                string[] skipExpProperties = { "Fleet_DriverCommision" };

                IList<Fleet_DriverCommissionExpense> savedlistExp = objMaster.Current.Fleet_DriverCommissionExpenses;
                List<Fleet_DriverCommissionExpense> listExpDetail = (from a in grdDriverExpenses.Rows
                                                                     select new Fleet_DriverCommissionExpense
                                                                     {
                                                                         Id = a.Cells[EXPCOLS.Id].Value.ToLong(),
                                                                         CommissionId = a.Cells[EXPCOLS.CommissionId].Value.ToLong(),
                                                                         Debit = a.Cells[EXPCOLS.Debit].Value.ToDecimal(),
                                                                         Credit = a.Cells[EXPCOLS.Credit].Value.ToDecimal(),
                                                                         Amount = a.Cells[EXPCOLS.Amount].Value.ToDecimal(),
                                                                         Description = a.Cells[EXPCOLS.Description].Value.ToStr(),
                                                                         Date = a.Cells[EXPCOLS.Date].Value.ToDateTimeorNull(),
                                                                          AddBy=a.Cells[EXPCOLS.User].Value.ToStr()
                                                                     }).ToList();
                Utils.General.SyncChildCollection(ref savedlistExp, ref listExpDetail, "Id", skipExpProperties);


                objMaster.Current.TransactionType = Enums.TRANSACTIONTYPE.DRIVER_COMMISSION_EXPENSE5;


                objMaster.Save();

                objMaster.GetByPrimaryKey(objMaster.PrimaryKeyValue);
                DisplayRecord();

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


        public override void DisplayRecord()
        {


            if (objMaster.Current == null) return;

            optSummaryDetails.Visible = true;
            optFullDetail.Visible = true;
            optAccountJobs.Visible = true;

            pnlRentPaid.Visible = true;
            lblRentPaid.Visible = true;

            btnExportPDF.Enabled = true;
            bt.Enabled = true;
            btnSendEmail.Enabled = true;
            pnlPaid.Visible = true;
            ddlDriver.Enabled = false;
            btnPick.Enabled = false;


            txtTransNo.Text = objMaster.Current.TransNo.ToStr();
            dtpTransactionDate.Value = objMaster.Current.TransDate.ToDateTime();
            ddlDriver.SelectedValue = objMaster.Current.DriverId;

            dtpFromDate.Value = objMaster.Current.FromDate.ToDate();
            dtpTillDate.Value = objMaster.Current.ToDate.ToDate();

            TotalWeeks = objMaster.Current.TotalWeeks.ToInt();
            spnAccountExpenses.Value = objMaster.Current.AccountExpenses.ToDecimal();

            if (objMaster.Current.VAT.ToDecimal() > 0)
            {
                lblVAT.Visible = true;
                numVAT.Visible = true;
                numVAT.Value = objMaster.Current.VAT.ToDecimal();
                numVAT.Enabled = false;
            }
            else
            {
                lblVAT.Visible = false;
                numVAT.Visible = false;
            }

            chkHoliday.Checked = objMaster.Current.WeekOff.ToBool();

         //   txtRemarks.Text = objMaster.Current.Remarks.ToStr();
            //MaxCommission
            numMaxCommission.Value = objMaster.Current.MaxCommission.ToDecimal();

            if (objMaster.Current.Remarks.ToStr().IsNumeric())
            {
                numMinCommLimit.Value = objMaster.Current.Remarks.ToStr().ToDecimal();
            }
            else
                numMinCommLimit.Value = 0;
            //

            if (objMaster.Current.IsCreditOrDebit.ToBool())
                optCredit.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            else
                optCredit.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;


            if (objMaster.Current.TransFor != "")
            {
                ddlDayWise.SelectedText = objMaster.Current.TransFor.ToStr();
            }

            numCommissionPercent.Value = objMaster.Current.DriverCommision.ToDecimal();
            txtCommisionPayment.Text = "0.00";
            numCommissionPercent.Enabled = false;
            numMaxCommission.Enabled = false;
            numMinCommLimit.Enabled = false;


            if (objMaster.Current.Fleet_Driver.IsPrimeCompanyDriver.ToBool())
            {
                numacccommpercent.Value = objMaster.Current.Fleet_Driver.PrimeCompanyRent.ToDecimal();
                numacccommpercent.Visible = true;
                numacccommpercent.Tag = true;
                lblAccComm.Visible = true;
                lblAccCommPercent.Visible = true;
                numacccommpercent.Enabled = false;
            }
            else
            {
                numacccommpercent.Tag = null;
                numacccommpercent.Value = 0.00m;
                numacccommpercent.Visible = false;
                lblAccComm.Visible = false;
                lblAccCommPercent.Visible = false;
            }




            int cnt = objMaster.Current.Fleet_DriverCommision_Charges.Count;
            var list = objMaster.Current.Fleet_DriverCommision_Charges;
            var DriverExpensesList = objMaster.Current.Fleet_DriverCommissionExpenses.ToList();
            grdDriverExpenses.RowCount = DriverExpensesList.Count;
         //   SetDefaultExpensesAddedValue();
            for (int i = 0; i < DriverExpensesList.Count; i++)
            {
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Id].Value = DriverExpensesList[i].Id;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.User].Value = DriverExpensesList[i].AddBy.ToStr();
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.CommissionId].Value = DriverExpensesList[i].CommissionId;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Debit].Value = DriverExpensesList[i].Debit;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Credit].Value = DriverExpensesList[i].Credit;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Amount].Value = DriverExpensesList[i].Amount;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Description].Value = DriverExpensesList[i].Description;
                grdDriverExpenses.Rows[i].Cells[EXPCOLS.Date].Value = DriverExpensesList[i].Date;
            }
           
            grdLister.RowCount = cnt;
            Booking objBooking = null;

            //using (TaxiDataContext db = new TaxiDataContext())
            //{
            //    var list2 = list.ToList();

            //    var bookingsList = (from a in list2
            //                        join b in db.Bookings on a.BookingId equals b.Id
            //                        select new
            //                        {
            //                            BookingId = b.Id,
            //                            b.CompanyId,
            //                            b.BookingStatusId,
            //                            b.PaymentTypeId,
            //                            b.DepartmentId,
            //                            b.VehicleTypeId,
            //                            b.FareRate,
            //                            b.MeetAndGreetCharges,
            //                            b.CongtionCharges,
            //                            b.ExtraDropCharges,
            //                            b.ServiceCharges,
            //                            b.TotalCharges,
            //                            b.FromAddress,
            //                            b.ToAddress,
            //                            b.BookingNo,
            //                            b.PickupDateTime,
            //                            b.OrderNo,
            //                            b.PupilNo,
            //                            b.AgentCommission,
            //                            b.CustomerName,
            //                            //   CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
            //                            //   AccountTypeId = b.CompanyId != null ? b.Gen_Company.AccountTypeId : 2,
            //                            a.CommissionPerBooking,
            //                            a.Id,
            //                            a.TransId,
            //                            BookId = a.BookingId,
            //                            b.InvoicePaymentTypeId,
            //                            b.IsCommissionWise
            //                        });
            //                        .ToList();


            //  }
            for (int i = 0; i < cnt; i++)
            {
                grdLister.Rows[i].Cells[COLS.ID].Value = list[i].Id;
                grdLister.Rows[i].Cells[COLS.TransId].Value = list[i].TransId;
                grdLister.Rows[i].Cells[COLS.BookingId].Value = list[i].BookingId;

                objBooking = list[i].Booking;

                if (objBooking != null)
                {


                    grdLister.Rows[i].Cells[COLS.Account].Value = objBooking.CompanyId != null ? objBooking.Gen_Company.CompanyName : "";
                    grdLister.Rows[i].Cells[COLS.CompanyId].Value = objBooking.CompanyId.ToIntorNull();
                    grdLister.Rows[i].Cells[COLS.AccountTypeId].Value = objBooking.CompanyId != null ? objBooking.Gen_Company.AccountTypeId.ToInt() : 2;
                    grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value = objBooking.PaymentTypeId.ToInt();

                    grdLister.Rows[i].Cells[COLS.PickupDate].Value = objBooking.PickupDateTime;
                    grdLister.Rows[i].Cells[COLS.OrderNo].Value = objBooking.OrderNo;
                    grdLister.Rows[i].Cells[COLS.PupilNo].Value = objBooking.PupilNo;

                    grdLister.Rows[i].Cells[COLS.BookedBy].Value = objBooking.Gen_Company_Department.DefaultIfEmpty().DepartmentName.ToStr();


                    grdLister.Rows[i].Cells[COLS.Vehicle].Value = objBooking.Fleet_VehicleType.VehicleType;

                    grdLister.Rows[i].Cells[COLS.VehicleID].Value = objBooking.VehicleTypeId;
                    grdLister.Rows[i].Cells[COLS.RefNumber].Value = objBooking.BookingNo;
                    //grdLister.Rows[i].Cells[COLS.Charges].Value = objBooking.FareRate.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Charges].Value = objBooking.CompanyPrice.ToDecimal();

                    grdLister.Rows[i].Cells[COLS.Fares].Value = objBooking.FareRate.ToDecimal();


                    grdLister.Rows[i].Cells[COLS.PickupPoint].Value = !string.IsNullOrEmpty(objBooking.FromDoorNo) ? objBooking.FromDoorNo + " - " + objBooking.FromAddress.ToStr() : objBooking.FromAddress.ToStr();
                    grdLister.Rows[i].Cells[COLS.Destination].Value = !string.IsNullOrEmpty(objBooking.ToDoorNo) ? objBooking.ToDoorNo + " - " + objBooking.ToAddress.ToStr() : objBooking.ToAddress.ToStr();

                    //NC
                    grdLister.Rows[i].Cells[COLS.Parking].Value = objBooking.CongtionCharges.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Waiting].Value = objBooking.MeetAndGreetCharges.ToDecimal();
             //       grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = objBooking.ExtraDropCharges.ToDecimal();
                    //grdLister.Rows[i].Cells[COLS.Parking].Value = objBooking.CongtionCharges.ToDecimal();
                    //grdLister.Rows[i].Cells[COLS.Waiting].Value = objBooking.MeetAndGreetCharges.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = objBooking.ExtraDropCharges.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.MeetAndGreet].Value = objBooking.MeetAndGreetCharges.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.CongtionCharge].Value = objBooking.CongtionCharges.ToDecimal();

                    grdLister.Rows[i].Cells[COLS.AgentFees].Value = objBooking.AgentCommission.ToDecimal()+objBooking.CashRate.ToDecimal();

                    grdLister.Rows[i].Cells[COLS.BookingFees].Value = objBooking.ServiceCharges.ToDecimal();


                    grdLister.Rows[i].Cells[COLS.Total].Value =(objBooking.FareRate.ToDecimal()  + objBooking.MeetAndGreetCharges.ToDecimal());
                       // (objBooking.FareRate.ToDecimal() + objBooking.MeetAndGreetCharges.ToDecimal() + objBooking.CongtionCharges.ToDecimal()) - objBooking.AgentCommission.ToDecimal();


                    grdLister.Rows[i].Cells[COLS.Passenger].Value = objBooking.CustomerName.ToStr().Trim();

                    grdLister.Rows[i].Cells[COLS.PaymentType].Value = objBooking.Gen_PaymentType.PaymentType.ToStr();


                    grdLister.Rows[i].Cells[COLS.IsCommissionWise].Value = objBooking.IsCommissionWise.ToBool();
                    //  grdLister.Rows[i].Cells[COLS.CommissionType].Value = objBooking.DriverCommissionType.ToStr();
                    grdLister.Rows[i].Cells[COLS.CommissionType].Value = "Percent";
                    // grdLister.Rows[i].Cells[COLS.CommissionValue].Value = objBooking.DriverCommission.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.CommissionValue].Value = list[i].CommissionPerBooking.ToDecimal();


                    // Add Commission Column
                    grdLister.Rows[i].Cells["Promotion"].Value = objBooking.TipAmount.ToDecimal()>0  ? objBooking.TipAmount.ToDecimal() : 0.00m;
                    grdLister.Rows[i].Cells["SubtractPromotion"].Value = objBooking.TipAmount.ToDecimal() < 0 ? -objBooking.TipAmount.ToDecimal() : 0.00m;

                    if (AppVars.objPolicyConfiguration.NoCommissionFromAccount.ToBool() 
                        && grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.BANK_ACCOUNT)
                    {


                        grdLister.Rows[i].Cells[COLS.Commission].Value = 0.00m;

                    }
                    else
                    {
                        
                            grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal() + grdLister.Rows[i].Cells[COLS.Waiting].Value.ToDecimal() + grdLister.Rows[i].Cells[COLS.ExtraDrop].Value.ToDecimal()) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numCommissionPercent.Value) / 100;


                        if(numacccommpercent.Tag!=null && numacccommpercent.Tag.ToBool())
                        {

                            if(objBooking.PaymentTypeId!=Enums.PAYMENT_TYPES.CASH)
                            {
                                grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal() + grdLister.Rows[i].Cells[COLS.Waiting].Value.ToDecimal() + grdLister.Rows[i].Cells[COLS.ExtraDrop].Value.ToDecimal()) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numacccommpercent.Value) / 100;


                            }
                        }


                    }


                    if (objBooking.CompanyId != null && objBooking.Gen_Company.DayAndNightWise.ToBool())
                    {

                        grdLister.Rows[i].Cells[COLS.Commission].Value = 0.00m;
                        grdLister.Rows[i].Cells["NoComm"].Value = true;
                    }

                }

            }




            grdLister.CurrentRow = null;

            txtInvoiceAmount.Text = objMaster.Current.JobsTotal.ToDecimal().ToStr();

            txtDriverOwed.Text = objMaster.Current.DriverOwed.ToDecimal().ToStr();

            txtOldBalance.Text = objMaster.Current.OldBalance.ToDecimal().ToStr();
            txtBalance.Text = objMaster.Current.Balance.ToDecimal().ToStr();


            txtRent.Text = objMaster.Current.DriverOwed.ToDecimal().ToStr();
            txtCommissionPaid.Text = objMaster.Current.DriverCommission_PaymentHistories.Sum(c => c.CommissionPay.ToDecimal()).ToStr();


            numPDARentPerWeek.Value = objMaster.Current.Extra.ToDecimal();

            numpdaRent.Value = objMaster.Current.PDARent.ToDecimal();

            if (objMaster.Current.WeekOff.ToBool())
                numCollectionDeliveryAmount.Value = 0.00m;

            //  numTotalCollectionDelivery.Value = objMaster.Current.CollectionDeliveryCharges.ToDecimal();

            numPromotion.Value = objMaster.Current.CollectionDeliveryCharges.ToDecimal();

            numParkingTotal.Value = objMaster.Current.Fuel.ToDecimal();
            numExtraTotal.Value = objMaster.Current.Adjustments.ToDecimal();
           



            CalculateTotal();


            var query = General.GetQueryable<Fleet_DriverCommision>(c => c.DriverId == objMaster.Current.DriverId).OrderByDescending(c => c.Id).FirstOrDefault();


            if ((query != null && query.Id != objMaster.Current.Id && query.Id > objMaster.Current.Id))
            {

                btnSaveInvoice.Enabled = false;
                btnPick.Enabled = false;

              
            }


            if (objMaster.Current.DriverCommission_PaymentHistories.Count > 0)
            {

                btnPaymentHistory.Visible = true;
                btnSaveInvoice.Enabled = false;
                btnPick.Enabled = false;

            }

            chkCarryForwardBalance.Enabled = false;

            UpdateTotalJobs();

        }
  

        private void CalculateTotal()
        {
            try
            {

                decimal Credit = 0.00m;
                decimal Debit = 0.00m;
                decimal totalCredit = 0.00m;
                decimal totalDebit = 0.00m;
                decimal owedBalance = 0.00m;
                decimal Currentbalance = 0.00m;
                double totalWeeks = (dtpTillDate.Value.ToDate().Subtract(dtpFromDate.Value.ToDate()).TotalDays) / 7;

                if (totalWeeks <= 0)
                    totalWeeks = 1;

                numpdaRent.Value = numPDARentPerWeek.Value * totalWeeks.ToInt();
             //   numTotalCollectionDelivery.Value = numCollectionDeliveryAmount.Value * totalWeeks.ToInt();
                TotalWeeks = totalWeeks.ToInt();
                decimal pdaRent = numpdaRent.Value;

                txtTotalCashBooking.Text = string.Format("{0:£ #.##}", grdLister.Rows
                    .Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.CASH)
                    .Sum(c => c.Cells[COLS.Fares].Value.ToDecimal() + c.Cells[COLS.Waiting].Value.ToDecimal() + c.Cells[COLS.ExtraDrop].Value.ToDecimal()));


                // change from Total to Fare Sum
                txtTotalAccountBooking.Text = string.Format("{0:£ #.##}", grdLister.Rows
                    .Where(c =>  c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH )
                    .Sum(c => c.Cells[COLS.Fares].Value.ToDecimal() + c.Cells[COLS.Waiting].Value.ToDecimal() + c.Cells[COLS.ExtraDrop].Value.ToDecimal()));



                decimal parkingTotal =grdLister.Rows.Where(c =>  c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH)
                                                            .Sum(c => c.Cells[COLS.Parking].Value.ToDecimal());

                if (AppVars.listUserRights.Count(c => c.functionId == "DEBIT CONGESTION") > 0)
                {
                    parkingTotal = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH
                                                             && (
                                                             c.Cells["PickupPlot"].Value.ToStr().Contains("CONGESTION") == false
                                                              && c.Cells["DropoffPlot"].Value.ToStr().Contains("CONGESTION") == false

                                                             )


                                                             )
                                                           .Sum(c => c.Cells[COLS.Parking].Value.ToDecimal());
                }
                

                numParkingTotal.Value = parkingTotal;



                decimal extraTotal = 0.00m;


                numExtraTotal.Value = extraTotal;


                numPromotion.Value= grdLister.Rows.Sum(c => c.Cells["Promotion"].Value.ToDecimal());



                // change: TOtal to Fares SUM
                decimal jobsFareTotal = grdLister.Rows.Sum(c => c.Cells[COLS.Fares].Value.ToDecimal() +
                c.Cells[COLS.Waiting].Value.ToDecimal() + c.Cells[COLS.ExtraDrop].Value.ToDecimal());

                txtInvoiceAmount.Text = string.Format("{0:£ #.##}", jobsFareTotal);

                if (txtInvoiceAmount.Text == "£ ")
                {
                    txtInvoiceAmount.Text = "£ 0";
                }
                if (txtTotalAccountBooking.Text == "£ ")
                {
                    txtTotalAccountBooking.Text = "£ 0";
                }
                if (txtCommsionTotal.Text == "£ ")
                {
                    txtCommsionTotal.Text = "£ 0";
                }


                numAgentFeeTotal.Value = grdLister.Rows.Where(c=>c.Cells[COLS.PaymentTypeId].Value.ToInt()==Enums.PAYMENT_TYPES.CASH)
                                .Sum(c => (c.Cells[COLS.AgentFees].Value.ToDecimal()).ToDecimal());




                // SERVICE CHARGES ONLY  / BOOKING FEES
                //if (AppVars.objPolicyConfiguration.PickCommissionDeductionFromJobsTotal.ToBool())
                //{
                    numAgentFeeTotal.Value = numAgentFeeTotal.Value + grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.CASH).Sum(c => (c.Cells[COLS.BookingFees].Value.ToDecimal()).ToDecimal());
                //   }
                //

                NumAccountBookingFeeTotal.Value = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH).Sum(c => (c.Cells[COLS.BookingFees].Value.ToDecimal()).ToDecimal());
                // 

                decimal JobTotal = txtInvoiceAmount.Text.TrimStart('£', ' ').ToDecimal();
                txtCommsionTotal.Text = "0.00";

                decimal commissionTotal = 0.00m;

              
                

                commissionTotal = GetCommissionTotal(jobsFareTotal, numAgentFeeTotal.Value, numCommissionPercent.Value);



                  

                

                //MaxCommission
                if (numMaxCommission.Value > 0 && commissionTotal > numMaxCommission.Value)
                {
                    commissionTotal = numMaxCommission.Value;
                  
                   
                }

                if (numMinCommLimit.Value > 0 && commissionTotal < numMinCommLimit.Value && grdLister.Rows.Count>0)
                {
                   
                    commissionTotal = numMinCommLimit.Value;


                }

                if (numVAT.Value > 0)
                {
                    commissionTotal = commissionTotal +  Math.Round(((commissionTotal * numVAT.Value) / 100),2);

                }

                txtCommsionTotal.Text = commissionTotal.ToStr();
              
                //

                // Owned

                // decimal Owend = ((txtCommsionTotal.Text).ToDecimal()) - (txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal() + pdaRent);
                decimal owed =Math.Round( (pdaRent +   numAgentFeeTotal.Value + commissionTotal) - txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal(),2);
                txtDriverOwed.Text = owed.ToStr();
                if (grdDriverExpenses.RowCount > 0)
                {
                    Debit = grdDriverExpenses.Rows.Sum(c => c.Cells[EXPCOLS.Debit].Value.ToDecimal());
                    Credit = grdDriverExpenses.Rows.Sum(c => c.Cells[EXPCOLS.Credit].Value.ToDecimal());
                }

         

                //totalCredit =( txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal()+Credit+(spnAccountExpenses.Value.ToDecimal()));
                //totalDebit = (numpdaRent.Value + numCollectionDeliveryAmount.Value.ToDecimal() + txtCommsionTotal.Text.ToDecimal()+Debit);

                // last
             //   totalCredit = (commissionTotal + Credit + (spnAccountExpenses.Value.ToDecimal()));
             //   totalDebit = (txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal() + Debit);

           //     totalCredit = (commissionTotal + Credit + (spnAccountExpenses.Value.ToDecimal()) + numAgentFeeTotal.Value + numTotalCollectionDelivery.Value+numpdaRent.Value);
            //    totalDebit = (txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal() + Debit);





                totalDebit = (commissionTotal + numpdaRent.Value + numCollectionDeliveryAmount.Value.ToDecimal() + numAgentFeeTotal.Value  + Debit);
                totalCredit = (txtTotalAccountBooking.Text.TrimStart('£', ' ').ToDecimal() + spnAccountExpenses.Value.ToDecimal() + parkingTotal+ extraTotal+ +numPromotion.Value+ Credit);




                owedBalance = (totalDebit - totalCredit);
                txtDriverOwed.Text = owedBalance.ToStr();

                totalDebit += txtOldBalance.Text.TrimStart('£', ' ').ToDecimal();
                Currentbalance = (totalDebit - totalCredit);
                txtBalance.Text = Currentbalance.ToStr(); 
           
                //totalCredit = (DriverCommissionTotal  + AccountExpenses + Credit);
                //totalDebit = (ACCJobsTotal + Debit);           
                                         
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private decimal GetCommissionTotal(decimal jobsFareTotal, decimal agentFeeTotal, decimal commissionPerBookingPercent)
        {
            decimal rtn = 0.00m;


            //if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 1)
            //{
            //    rtn =Math.Round( (((jobsFareTotal - agentFeeTotal) * commissionPerBookingPercent) / 100),2);

            //}



            //else
            //{

                rtn = Math.Round(grdLister.Rows.Sum(c => c.Cells[COLS.Commission].Value.ToDecimal()) , 2); 
       //     }


            //if (rtn > 0)
            //    rtn = (decimal)(Math.Ceiling(Convert.ToDouble(rtn) / 0.25) * 0.25);


            return rtn;



        }


        private void SetOrderNoColumn(bool show)
        {

            grdLister.Columns[COLS.OrderNo].IsVisible = show;


            if (show)
            {
                grdLister.Columns["OrderNo"].Width = 80;

            }
        }

        private void SetBookedByColumn(bool show)
        {

            grdLister.Columns[COLS.BookedBy].IsVisible = show;


            if (show)
            {
                grdLister.Columns[COLS.BookedBy].Width = 100;

            }
        }

        private void SetPupilNoColumn(bool show)
        {

            grdLister.Columns[COLS.PupilNo].IsVisible = show;


            if (show)
            {
                grdLister.Columns[COLS.PupilNo].Width = 80;

            }
        }



        public override void Print()
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;


            frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);


            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteria = "summary_";

            }

            var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(c => c.CommissionId == id).OrderBy(c => c.Date).ToList();
            frm.DataSource2 = list2;

            frm.IsFareAndWaitingWise = this.IsFareAndWaitingWiseComm;
            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }

            frm.objSubCompany = objMaster.Current.Fleet_Driver.Gen_SubCompany;
            frm.GenerateReport();

            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverCommisionTransactionExpensesReport51");



            if (doc != null)
            {
                doc.Close();
            }

            UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
        }






        public override void OnNew()
        {
            try
            {
                txtTransNo.Text = string.Empty;
                grdLister.Rows.Clear();
                ComboFunctions.FillDriverNoCombo(ddlDriver, c => c.DriverTypeId == Enums.DRIVERTYPES.COMMISSION && c.IsActive==true);
               

                grdDriverExpenses.Rows.Clear();

                txtDriverOwed.Text = "0.00";
                txtBalance.Text = "0.00";
                txtCommisionPayment.Text = "0.00";
                txtExtra.Text = "0.00";
            //    txtFuel.Text = "0.00";


                txtInvoiceAmount.Text = string.Empty;
                txtTotalCashBooking.Text = string.Empty;
                txtCommsionTotal.Text = string.Empty;
                txtTotalAccountBooking.Text = string.Empty;

                txtOldBalance.Text = string.Empty;

                txtRent.Text = string.Empty;
                txtCommissionPaid.Text = string.Empty;

                ddlDriver.SelectedValue = null;
                numCommissionPercent.Value = 0.00m;
                numAgentFeeTotal.Value = 0.00m;
                NumAccountBookingFeeTotal.Value = 0.00m;
                numPDARentPerWeek.Value = 0.00m;
                numpdaRent.Value = 0.00m;
                numParkingTotal.Value = 0.00m;
                numExtraTotal.Value = 0.00m;

                spnAccountExpenses.Value = 0.00m;

                numCommissionPercent.Enabled = true;
                numMaxCommission.Enabled = true;
                btnSaveInvoice.Enabled = true;


                pnlRentPaid.Visible = false;
                lblRentPaid.Visible = false;

                btnExportPDF.Enabled = false;
                bt.Enabled = false;
                btnSendEmail.Enabled = false;
                pnlPaid.Visible = true;

                ddlDriver.Enabled = true;
                btnPick.Enabled = true;
                btnPaymentHistory.Visible = false;
                numTotalCollectionDelivery.Value = 0;
                numCollectionDeliveryAmount.Value = 0;
                objMaster.Clear();
                objMaster.New();
                objMaster.PrimaryKeyValue = null;
                ddlDriver.Focus();
                lblTotalJobs.Text = "Total Job(s) : 0";

                lblVAT.Visible = false;
                numVAT.Value = 0.00m;
                numVAT.Visible = false;

                optSummaryDetails.Visible = false;
                optFullDetail.Visible = false;
                optAccountJobs.Visible = false;

                numMaxCommission.Value = 0.00m;

                ResetDefaultExpensesAddedValue();

                numMinCommLimit.Value = 0;

                numacccommpercent.Value = 0;
                lblAccComm.Visible = false;
                lblAccCommPercent.Visible = false;
                numacccommpercent.Visible = false;

                chkCarryForwardBalance.Enabled = true;

            }
            catch
            {


            }

        }
        private void ResetDefaultExpensesAddedValue()
        {
            IsNotesExpenseAdded = false;


        }

        private void SetDefaultExpensesAddedValue()
        {
            IsNotesExpenseAdded = true;

        }
        private void AddDefeultExpenseValue()
        {
            try
            {

                if (grdLister.Rows.Count > 0 && objMaster.PrimaryKeyValue==null)
                {


                    if (IsNotesExpenseAdded == false)
                    {
                        decimal defaultCongestion= grdLister.Rows
                         //   .Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.CASH)
                                            .Where(c => c.Cells["PickupPlot"].Value.ToStr().Contains("CONGESTION")
                                            || c.Cells["DropoffPlot"].Value.ToStr().Contains("CONGESTION") )
                                                            .Sum(c => c.Cells[COLS.Parking].Value.ToDecimal());

                        if (defaultCongestion > 0)
                        {
                            var row = grdDriverExpenses.Rows.AddNew();


                            row.Cells[EXPCOLS.Debit].Value = defaultCongestion;

                            row.Cells[EXPCOLS.Description].Value = "CONGESTION";
                            SetDefaultExpensesAddedValue();
                        }
                       
                    }
                }               
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
  

        private void ShowHideColumns(bool show)
        {

            grdLister.Columns[COLS.Charges].IsVisible = show;
            grdLister.Columns[COLS.Fares].IsVisible = show;
            grdLister.Columns[COLS.CongtionCharge].IsVisible = show;
            grdLister.Columns[COLS.Destination].IsVisible = show;
            grdLister.Columns[COLS.ExtraDrop].IsVisible = show;
            grdLister.Columns[COLS.MeetAndGreet].IsVisible = show;
            grdLister.Columns[COLS.Parking].IsVisible = show;
            grdLister.Columns[COLS.Passenger].IsVisible = show;
            grdLister.Columns[COLS.PickupDate].IsVisible = show;
            grdLister.Columns[COLS.PickupPoint].IsVisible = show;
            grdLister.Columns[COLS.Destination].IsVisible = show;
            grdLister.Columns[COLS.Vehicle].IsVisible = show;
            grdLister.Columns[COLS.RefNumber].IsVisible = show;
            grdLister.Columns[COLS.Waiting].IsVisible = show;
            grdLister.Columns[COLS.VehicleID].IsVisible = show;

            if (!show)
            {
                grdLister.Columns[COLS.Total].HeaderText = "Amount";
                grdLister.Columns[COLS.Total].Width = 70;

            }
            else
            {
                grdLister.Columns[COLS.Total].HeaderText = "Total";
                grdLister.Columns[COLS.Total].Width = 45;
            }
        }

        private void txtRentPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  CalculateBalance();
            }
            catch (Exception ex)
            {
            }
        }
      
        private void ddlDayWise_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string val = ddlDayWise.SelectedItem.Text.ToStr();

            if (val == "Weekly")
            {
                dtpFromDate.Value = DateTime.Now.ToDate().AddDays(-6);
                dtpTillDate.Value = DateTime.Now.ToDate();
            }
            else if (val == "Monthly")
            {
                dtpFromDate.Value = DateTime.Now.ToDate().AddDays(-30);
                dtpTillDate.Value = DateTime.Now.ToDate();
            }

        }


        private void btnSingle_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;


            frmDriverCommisionTransactionReport frm = new frmDriverCommisionTransactionReport(2);

            var list = General.GetQueryable<vu_DriverCommision>(a => a.Id == id).ToList();
            int count = list.Count;

            frm.DataSource = list;



            frm.GenerateReport();


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverCommisionTransactionReport1");

            if (doc != null)
            {
                doc.Close();
            }

            UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
        }

        private void txtFuel_TextChanged(object sender, EventArgs e)
        {
         //   CalculateBalance();
        }

        private void txtExtra_TextChanged(object sender, EventArgs e)
        {
            // New

            txtCommisionPayment.Text = "";
            CalculateTotal();
            //

         //   CalculateBalance();
        }

        private void txtFuel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

        }

        private void txtExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }



        private void optCredit_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            txtCommisionPayment.Text = "";
            CalculateTotal();
          //  CalculateBalance();
        }


        private void ClearExpanseFields()
        {
            txtRemarks.Text = "";
            spnAmount.Value = 0;
            spnAmount.Focus();
        }
        


        private void AddDriverExpenses()
        {
            try
            {
                decimal Debit = 0.00m;
                decimal Credit = 0.00m;
                decimal Amount = spnAmount.Value;
                string Error = string.Empty;
                string Description = txtRemarks.Text.ToStr().Trim();
                if (Amount == 0)
                {
                    Error = "Required : Amount";
                }
                if (string.IsNullOrEmpty(Description))
                {
                    if (!string.IsNullOrEmpty(Error))
                    {
                        Error += Environment.NewLine;
                    }
                    Error += "Required : Description";
                }
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }
                if (optCredit.IsChecked)
                {
                    Credit = Amount;
                    Debit = 0.00m;
                }
                else
                {
                    Debit = Amount;
                    Credit = 0.00m;
                }
                GridViewRowInfo row = null;
                row = grdDriverExpenses.Rows.AddNew();
                row.Cells[EXPCOLS.User].Value = AppVars.LoginObj.UserName.ToStr();
                row.Cells[EXPCOLS.Debit].Value = Debit;
                row.Cells[EXPCOLS.Credit].Value = Credit;
                row.Cells[EXPCOLS.Description].Value = Description;
                row.Cells[EXPCOLS.Date].Value = DateTime.Now;
                ClearExpanseFields();

                CalculateTotal();
                //grdDriverExpenses.Rows.a
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        
        private void btnPick_Click(object sender, EventArgs e)
        {
            try
            {
                decimal AccountExpenses = 0;
                int DriverId = ddlDriver.SelectedValue.ToInt();

                DateTime? fromDate = dtpFromDate.Value.ToDate();
                DateTime? tillDate = dtpTillDate.Value.ToDate();


                string error = string.Empty;
                if (DriverId == 0)
                {
                    error += "Required : Driver";
                }

                if (fromDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : From Date";
                }

                if (tillDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : To Date";


                }

                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;

                }

                if (fromDate > tillDate)
                {

                    ENUtils.ShowMessage("From Date must be less than To Date");
                    return;
                }


                DateTime? ACCJobsFromDate = fromDate.Value.AddDays(ddlAccountBookingDays.Text.ToInt());
                DateTime? ACCJobsTillDate = fromDate;

                if (ddlAccountBookingDays.Text.ToInt() < 0)
                {
                    ACCJobsTillDate = fromDate.Value.AddDays(-1).ToDate();

                }
                else
                {

                    ACCJobsTillDate = tillDate;
                }







                string[] hiddenColumns = null;



             


                if (!IsFareAndWaitingWiseComm)
                    hiddenColumns = new string[] {  "Id", "Parking","Destination","ExtraDrop","MeetAndGreet","Congtion",
                                                "Total","OrderNo","PupilNo","BookingDate","Description","Charges","AccountType","CompanyId","Waiting"
                                                ,"IsCommissionWise","DriverCommissionType","DriverCommission","PaymentTypeId","DropOffCharge","PickupCharge","BookingStatusId"};

                else
                    hiddenColumns = new string[] {  "Id", "Parking","Destination","ExtraDrop","MeetAndGreet","Congtion",
                                                "Total","OrderNo","PupilNo","BookingDate","Description","Charges","AccountType","CompanyId" 
                                                ,"IsCommissionWise","DriverCommissionType","DriverCommission","PaymentTypeId","DropOffCharge","PickupCharge","BookingStatusId"};




                bool RentForProcessedJobs = AppVars.objPolicyConfiguration.RentForProcessedJobs.ToBool();

                Expression<Func<Booking, bool>> _conditionDate = null;
                if (ddlPickType.SelectedIndex == 0)
                {
                    if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2)
                    {
                        _conditionDate = b => (((b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate))) && (b.DriverId == DriverId && ((b.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && b.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP) || b.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED));

                    }
                   else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 4)
                    {
                        _conditionDate = b => (((b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate))) && (b.DriverId == DriverId && ((b.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && (b.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || b.BookingStatusId==Enums.BOOKINGSTATUS.CANCELLED)) || b.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED));

                    }
                    else
                    {
                        _conditionDate = b => (((b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate) && b.PaymentTypeId == Enums.PAYMENT_TYPES.CASH) || ((b.PickupDateTime.Value.Date >= ACCJobsFromDate && b.PickupDateTime.Value.Date <= ACCJobsTillDate) && b.PaymentTypeId != Enums.PAYMENT_TYPES.CASH)) && (b.DriverId == DriverId && b.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED);
                    }
                }
                else
                {
                    if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2)
                    {
                        _conditionDate = b => (((b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate) && b.PaymentTypeId == Enums.PAYMENT_TYPES.CASH) || ((b.BookingDate.Value.Date >= ACCJobsFromDate && b.BookingDate.Value.Date <= ACCJobsTillDate) && b.PaymentTypeId != Enums.PAYMENT_TYPES.BANK_ACCOUNT)) && (b.DriverId == DriverId && (b.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || b.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED));
                    }
                    else
                    {
                        _conditionDate = b => (((b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate) && b.PaymentTypeId == Enums.PAYMENT_TYPES.CASH) || ((b.BookingDate.Value.Date >= ACCJobsFromDate && b.BookingDate.Value.Date <= ACCJobsTillDate) && b.PaymentTypeId != Enums.PAYMENT_TYPES.BANK_ACCOUNT)) && (b.DriverId == DriverId && b.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED);
                    }
                }

                //  List<object[]> list = null;
                List<object[]> list = General.ShowDriverCommTransactionExpense2BookingMultiLister(c => c.DriverId == DriverId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED), hiddenColumns, _conditionDate);


                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.CommandTimeout = 5;
                        var query = db.Fleet_Drivers.Where(c => c.Id == DriverId).Select(c => c.MaxCommission).FirstOrDefault().ToDecimal();
                        numMaxCommission.Value = query;


                        var query2 = db.Fleet_Drivers.Where(c => c.Id == DriverId).Select(c => c.NICNo).FirstOrDefault().ToDecimal();
                        numMinCommLimit.Value = query2.ToStr().Trim().IsNumeric() ? query2.ToStr().Trim().ToDecimal() : 0.00m ;

                    }


                }
                catch(Exception ex)
                {


                }
            



                int cnt = list.Count;


                var existBookingId = grdLister.Rows.ToList();

                Fleet_Driver_CommissionRange range = null;
                object[] objExisting = null;
                foreach (var item in existBookingId)
                {

                    if (list.Count(c => c[0].ToLong() == item.Cells[COLS.BookingId].Value.ToLong()) > 0)
                        continue;



                    objExisting = new object[item.Cells.Count];

                    objExisting[0] = item.Cells[COLS.BookingId].Value.ToLong();

                    objExisting[3] = item.Cells[COLS.RefNumber].Value.ToStr();
                    objExisting[2] = item.Cells[COLS.PickupDate].Value.ToDateTime();


                    objExisting[4] = item.Cells[COLS.Vehicle].Value.ToStr();



                    objExisting[5] = item.Cells[COLS.OrderNo].Value.ToStr();
                    objExisting[6] = item.Cells[COLS.PupilNo].Value.ToStr();

                    objExisting[7] = item.Cells[COLS.Passenger].Value.ToStr();

                    objExisting[8] = item.Cells[COLS.PickupPoint].Value.ToStr();
                    objExisting[9] = item.Cells[COLS.Destination].Value.ToStr();

                    objExisting[12] = item.Cells[COLS.Account].Value.ToStr();

                    objExisting[11] = item.Cells[COLS.CompanyId].Value.ToIntorNull();

                    objExisting[10] = item.Cells[COLS.Charges].Value.ToDecimal();
                    objExisting[21] = item.Cells[COLS.Fares].Value.ToDecimal();
                    objExisting[13] = item.Cells[COLS.Parking].Value.ToDecimal();
                    objExisting[14] = item.Cells[COLS.Waiting].Value.ToDecimal();
                    objExisting[15] = item.Cells[COLS.ExtraDrop].Value.ToDecimal();
                    objExisting[16] = item.Cells[COLS.MeetAndGreet].Value.ToDecimal();
                    objExisting[17] = item.Cells[COLS.CongtionCharge].Value.ToDecimal();
                    objExisting[19] = item.Cells[COLS.Total].Value.ToDecimal();

                    objExisting[18] = item.Cells[COLS.RemovalDescription].Value.ToStr();

                    objExisting[20] = item.Cells[COLS.BookedBy].Value.ToStr();

                    // Add Commission Column

                    objExisting[22] = item.Cells[COLS.AccountTypeId].Value.ToInt();



                    objExisting[23] = item.Cells[COLS.IsCommissionWise].Value.ToBool();
                    objExisting[24] = item.Cells[COLS.CommissionType].Value.ToStr();
                    objExisting[25] = item.Cells[COLS.CommissionValue].Value.ToDecimal();

                    objExisting[26] = item.Cells[COLS.AgentFees].Value.ToDecimal();

                    objExisting[29] = item.Cells[COLS.PaymentTypeId].Value.ToInt();

                    objExisting[30] = item.Cells[COLS.BookingFees].Value.ToDecimal();

                    ///

                    list.Add(objExisting);


                }



                // list.RemoveAll(c => existBookingId.Contains(c[0].ToLong()));

                cnt = list.Count;
                decimal a1 = 0;
                decimal a2 = 0;

                int totalRows = cnt;

                grdLister.RowCount = cnt;


                for (int i = 0; i < totalRows; i++)
                {
                    grdLister.Rows[i].Cells[COLS.BookingId].Value = list[i][0].ToLongorNull();
                    grdLister.Rows[i].Cells[COLS.RefNumber].Value = list[i][3].ToStr();
                    grdLister.Rows[i].Cells[COLS.PickupDate].Value = list[i][2].ToDateTime();

                    grdLister.Rows[i].Cells[COLS.Vehicle].Value = list[i][4].ToStr();

                    grdLister.Rows[i].Cells[COLS.OrderNo].Value = list[i][5].ToStr();
                    grdLister.Rows[i].Cells[COLS.PupilNo].Value = list[i][6].ToStr();

                    grdLister.Rows[i].Cells[COLS.Passenger].Value = list[i][7].ToStr();

                    grdLister.Rows[i].Cells[COLS.PickupPoint].Value = list[i][8].ToStr();
                    grdLister.Rows[i].Cells[COLS.Destination].Value = list[i][9].ToStr();

                    grdLister.Rows[i].Cells[COLS.Account].Value = list[i][12].ToStr();

                    grdLister.Rows[i].Cells[COLS.CompanyId].Value = list[i][11].ToIntorNull();

                    grdLister.Rows[i].Cells[COLS.Charges].Value = list[i][10].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Fares].Value = list[i][21].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Parking].Value = list[i][13].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Waiting].Value = list[i][14].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = list[i][15].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.MeetAndGreet].Value = list[i][16].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.CongtionCharge].Value = list[i][17].ToDecimal();

                    grdLister.Rows[i].Cells[COLS.AgentFees].Value = list[i][26].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.BookingFees].Value = list[i][31].ToDecimal();
                    //  grdLister.Rows[i].Cells[COLS.Total].Value = list[i][19].ToDecimal() - list[i][26].ToDecimal();

                    grdLister.Rows[i].Cells[COLS.Total].Value = (list[i][21].ToDecimal()+ list[i][14].ToDecimal()+ list[i][13].ToDecimal()) - list[i][26].ToDecimal();


                    grdLister.Rows[i].Cells[COLS.RemovalDescription].Value = list[i][18].ToStr();

                    grdLister.Rows[i].Cells[COLS.BookedBy].Value = list[i][20].ToStr();

                    grdLister.Rows[i].Cells["Promotion"].Value = list[i][34].ToDecimal() > 0 ? list[i][34].ToDecimal() : 0.00m;

                    grdLister.Rows[i].Cells["SubtractPromotion"].Value = list[i][34].ToDecimal() < 0 ? -list[i][34].ToDecimal() : 0.00m;

                    // commission column
                    if (AppVars.objPolicyConfiguration.NoCommissionFromAccount.ToBool() && list[i][29].ToInt() == Enums.PAYMENT_TYPES.BANK_ACCOUNT)
                    {


                        grdLister.Rows[i].Cells[COLS.Commission].Value = 0.00m;
                      
                    }
                    else
                    {
                        if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 13) // fare+extradrop
                        {
                            grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal()
                                                            
                                                                + grdLister.Rows[i].Cells[COLS.ExtraDrop].Value.ToDecimal()) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numCommissionPercent.Value) / 100;

                        }
                      else  if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 14) // fare+waiting
                        {
                            grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal()
                                                                 + grdLister.Rows[i].Cells[COLS.Waiting].Value.ToDecimal()
                                                               ) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numCommissionPercent.Value) / 100;

                        }
                        else // fare+waiting+extradrop
                        {

                            if(list[i][29].ToInt() != Enums.PAYMENT_TYPES.CASH && numacccommpercent.Visible)
                            {
                                grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal()
                                                                + grdLister.Rows[i].Cells[COLS.Waiting].Value.ToDecimal()
                                                                + grdLister.Rows[i].Cells[COLS.ExtraDrop].Value.ToDecimal()) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numacccommpercent.Value) / 100;

                            }
                            else
                            grdLister.Rows[i].Cells[COLS.Commission].Value = (((grdLister.Rows[i].Cells[COLS.Fares].Value.ToDecimal()
                                                                + grdLister.Rows[i].Cells[COLS.Waiting].Value.ToDecimal()
                                                                + grdLister.Rows[i].Cells[COLS.ExtraDrop].Value.ToDecimal()) - grdLister.Rows[i].Cells["SubtractPromotion"].Value.ToDecimal()) * numCommissionPercent.Value) / 100;
                        }
                    }

                    if (list[i][37].ToBool()) // no commission on this account
                    {
                        grdLister.Rows[i].Cells["NoComm"].Value = true;
                        grdLister.Rows[i].Cells[COLS.Commission].Value = 0.00m;


                    }

                    grdLister.Rows[i].Cells[COLS.IsCommissionWise].Value = list[i][23].ToBool();

                    grdLister.Rows[i].Cells[COLS.CommissionType].Value = list[i][24].ToStr();

                    grdLister.Rows[i].Cells[COLS.CommissionValue].Value = list[i][25].ToDecimal();


                    grdLister.Rows[i].Cells[COLS.AccountTypeId].Value = list[i][22].ToInt();
                    grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value = list[i][29].ToInt();

                    grdLister.Rows[i].Cells[COLS.PaymentType].Value = list[i][30].ToStr();


                    grdLister.Rows[i].Cells["PickupPlot"].Value = list[i][32].ToStr();
                    grdLister.Rows[i].Cells["DropoffPlot"].Value = list[i][33].ToStr();
                    

                   
                   
                    ///
                }



                AccountExpenses = (a1 + a2);
                spnAccountExpenses.Value = AccountExpenses;

                if (AppVars.listUserRights.Count(c => c.functionId == "DEBIT CONGESTION") > 0)
                {
                    AddDefeultExpenseValue();
                }
                CalculateTotal();
         


                if (grdLister.Rows.Count > 0)
                {
                    numCommissionPercent.Enabled = false;
                    numMaxCommission.Enabled = false;
                }
                else
                {
                    numCommissionPercent.Enabled = true;
                    numMaxCommission.Enabled = true;
                }


                UpdateTotalJobs();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


        private void UpdateTotalJobs()
        {
            lblTotalJobs.Text = "Total Job(s) : " + grdLister.Rows.Count;


        }

        private void btnBookingReport_Click_1(object sender, EventArgs e)
        {
            Print();
        }

        private void pnlPaid_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TextSelect()
        {

            try
            {

                if (txtRemarks.Text.Trim().Length == 0)
                {

                    txtRemarks.ListBoxElement.Items.Clear();
                    //this.Size = new Size(this.Size.Width, 388);
                    //this.Size = new Size(this.Size.Width, 388);
                    //radPanel2.Size = new Size(radPanel2.Size.Width, 56);
                    return;
                }

                txtRemarks.ListBoxElement.Items.Clear();
                string[] res = null;
                using (Taxi_Model.TaxiDataContext con = new TaxiDataContext())
                {
                    con.CommandTimeout = 4;
                    if (txtRemarks.Text == "")
                    {
                        //res = con.Fleet_DriverTemplets.Take(0).Select(w => w.Templets).ToArray(); 

                        res = con.Fleet_DriverCommissionExpenses.Take(0).Select(w => w.Description).ToArray();
                    }
                    else
                        // res = con.Fleet_DriverTemplets.Where(w => w.Templets.StartsWith(txtRemarks.Text)).Select(w => w.Templets).ToArray();
                        res = con.Fleet_DriverCommissionExpenses.Where(w => w.Description.StartsWith(txtRemarks.Text)).Select(w => w.Description).ToArray();
                }
                txtRemarks.ListBoxElement.Items.AddRange(res);

                if (res.Count() > 0)
                {
                    txtRemarks.ShowListBox();

                    txtRemarks.ListBoxElement.BringToFront();
                    txtRemarks.ListBoxElement.ScrollAlwaysVisible = true;
                    txtRemarks.ListBoxElement.Height = 100;
                    txtRemarks.ListBoxElement.Width = 184;
                    //this.Size = new Size(this.Size.Width, 490);
                    //radPanel2.Size = new Size(radPanel2.Size.Width, 160);
                    //txtRemarks.ListBoxElement.Height = 100;
                }
                else
                {
                    txtRemarks.ListBoxElement.Hide();
                    txtRemarks.ListBoxElement.Items.RemoveAt(0);
                    //184, 80
                    //this.Size = new Size(this.Size.Width, 388);
                    //this.Size = new Size(this.Size.Width, 388);
                    //radPanel2.Size = new Size(radPanel2.Size.Width, 56);
                }
                if (txtRemarks.Text != txtRemarks.FormerValue)
                {
                    txtRemarks.FormerValue = txtRemarks.Text;
                }
            }
            catch
            {
                //this.txtRemarks = new Size(184, 80);

               // this.Size = new Size(184, 80);
                //this.Size = new Size(this.Size.Width, 388);
                //radPanel2.Size = new Size(radPanel2.Size.Width, 56);
            }

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            TextSelect();
        }

        private void ddlDriver_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            try
            {
                if (ddlDriver.Items[e.Position].Value != null && grdLister.Rows.Count > 0)
                {
                    MessageBox.Show("You cannot Change Driver as Booking(s) already picked" + Environment.NewLine +
                        "if you want to change the driver you need to remove all these selected booking(s) or press Add New Record");

                    e.Cancel = true;

                }
            }
            catch
            {


            }


        }

        private void chkCarryForwardBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (objMaster.PrimaryKeyValue == null)
            {
                SetOldBalance(ddlDriver.SelectedValue.ToIntorNull());
                CalculateTotal();
            }
        }
    }
}
