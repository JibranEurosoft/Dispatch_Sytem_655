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
    public partial class frmDriverRentDebitCredit3 : UI.SetupBase
    {

        DriverRentBO objMaster = null;
        //decimal PDARent = 0.00m;
        //decimal CarRent = 0.00m;
        //decimal CarInsuranceRent = 0.00m;
        //decimal PrimeCompanyRent = 0.00m;
        public struct COLS
        {
            public static string ID = "ID";
            public static string TransId = "TransId";
            public static string BookingId = "BookingId";
            public static string AccountTypeId = "AccountTypeId";
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
            public static string AgentFees = "AgentFees";
            public static string Charges = "Charges";

            public static string Parking = "Parking";
            public static string Waiting = "Waiting";
            public static string ExtraDrop = "ExtraDrop";
            public static string MeetAndGreet = "MeetAndGreet";
            public static string CongtionCharge = "CongtionCharge";
            public static string RemovalDescription = "RemovalDescription";
            public static string Total = "Total";
            public static string Payment_ID = "Payment_ID";
            public static string PaymentType = "PaymentType";

            public static string BookingFees = "BookingFee";

            public static string Fares = "Fares";
            public static string Account = "Account";
            public static string CompanyId = "CompanyId";
            public static string PaymentTypeId = "PaymentTypeId";
            public static string IsCommissionWise = "IsCommissionWise";
            public static string DriverCommissionType = "DriverCommissionType";
            public static string DriverCommission = "DriverCommission";

        }
        public frmDriverRentDebitCredit3()
        {
            InitializeComponent();
            InitializeConstructor();


        }
        public frmDriverRentDebitCredit3(int Id)
        {
            InitializeComponent();
            InitializeConstructor();
            ddlDriver.SelectedValue = Id;

        }

        public frmDriverRentDebitCredit3(long Id, bool IsHide)
        {
            InitializeComponent();
            InitializeConstructor();
            ddlDriver.SelectedValue = Id;
           
            OnDisplayRecord(Id);

            this.btnPrint2.Visible = !IsHide;
            this.btnSaveInvoice.Visible = !IsHide;
            // DisplayRecord();
        }

        public struct EXPCOLS
        {
            public static string Id = "Id";
            public static string User = "User";
            public static string RentId = "RentId";
            public static string Debit = "Debit";
            public static string Credit = "Credit";
            public static string Amount = "Amount";
            public static string Description = "Description";
            public static string Date = "Date";
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
            col.Name = EXPCOLS.RentId;
            col.IsVisible = false;
            grdDriverExpenses.Columns.Add(col);
            GridViewDecimalColumn dcol = new GridViewDecimalColumn();

            dcol.Name = EXPCOLS.Credit;
            dcol.ReadOnly = true;
            dcol.Width = 80;
            dcol.HeaderText = EXPCOLS.Credit;
            dcol.Maximum = 10000;
            dcol.Minimum = -10000;
            grdDriverExpenses.Columns.Add(dcol);

            dcol = new GridViewDecimalColumn();
            dcol.Name = EXPCOLS.Debit;
            dcol.HeaderText = EXPCOLS.Debit;
            dcol.ReadOnly = true;
            dcol.Maximum = 10000;
            dcol.Minimum = -10000;
            dcol.Width = 80;
            grdDriverExpenses.Columns.Add(dcol);

            dcol = new GridViewDecimalColumn();
            dcol.Name = EXPCOLS.Amount;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdDriverExpenses.Columns.Add(dcol);


            col = new GridViewTextBoxColumn();
            col.Name = EXPCOLS.Description;
            col.HeaderText = EXPCOLS.Description;
            col.Width = 150;
            col.ReadOnly = true;
            grdDriverExpenses.Columns.Add(col);


            GridViewDateTimeColumn dtcol = new GridViewDateTimeColumn();
            dtcol.Name = EXPCOLS.Date;
            dtcol.IsVisible = false;
            grdDriverExpenses.Columns.Add(dtcol);


            GridViewCommandColumn cmd = new GridViewCommandColumn();
            cmd.Width = 60;
            cmd.Name = "Delete";
            cmd.UseDefaultText = true;
            cmd.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            cmd.DefaultText = "Delete";
            cmd.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdDriverExpenses.Columns.Add(cmd);
        }

        private void ClearExpanseFields()
        {
            txtRemarks.Text = "";
            spnAmount.Value = 0;
            spnAmount.Focus();
        }
        private void frmDriverRent_Load(object sender, EventArgs e)
        {

        }
        private void frmDriverRent_Shown(object sender, EventArgs e)
        {
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }


        private void FillDriverCombo()
        {

            ComboFunctions.FillDriverNoCombo(ddlDriver, c => c.DriverTypeId == 1 && c.IsActive==true);

            ddlDriver.SelectedIndex = -1;
        }

        private void InitializeConstructor()
        {
           
            objMaster = new DriverRentBO();
            FillDriverCombo();
          //  ComboFunctions.FillRentPayReasonCombo(ddlReason);

            txtOldBalance.ReadOnly = AppVars.listUserRights.Count(c => c.formName == this.Name && c.functionId == "SPECIAL") == 0;



            dtpTransactionDate.Value = DateTime.Now.ToDateTime();
            FormatChargesGrid();
         //   txtDriverRent.Text = string.Empty;
            grdLister.ShowGroupPanel = false;
            grdLister.AutoCellFormatting = true;
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdLister.ShowRowHeaderColumn = false;

            
            this.SetProperties((INavigation)objMaster);

            grdLister.AllowAddNewRow = false;


            dtpFromDate.Value = DateTime.Now.ToDate().AddDays(-6);
            dtpTillDate.Value = DateTime.Now.ToDate();

      
            dtpFromDate.DateTimePickerElement.ValueChanging += new ValueChangingEventHandler(DateTimePickerElement_ValueChanging);
            dtpTillDate.DateTimePickerElement.ValueChanging += new ValueChangingEventHandler(DateTimePickerElement_ValueChanging);



       //     grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            FormatExpenseGrid();
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.grdDriverExpenses.CommandCellClick += new CommandCellClickEventHandler(grdDriverExpenses_CommandCellClick);


            chkHoliday.CheckedChanged += new EventHandler(chkHoliday_CheckedChanged);

            this.btnAddNew.Click += new EventHandler(btnAddNew_Click);

            numpdaRent.Validated += new EventHandler(numRentValue_Validated);
            numDrvRent.Validated += new EventHandler(numRentValue_Validated);
            numCarRent.Validated += new EventHandler(numRentValue_Validated);
            numCarInsuranceRent.Validated += new EventHandler(numRentValue_Validated);
            numPrimeCompanyRent.Validated += new EventHandler(numRentValue_Validated);
            txtRemarks.ListBoxElement.Width = 279;
            txtRemarks.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtRemarks.ListBoxElement.Height = 36;
            this.txtRemarks.TextChanged += new EventHandler(txtRemarks_TextChanged);

            chkCarryForwardBalance.Visible = AppVars.listUserRights.Count(c => c.functionId == "DISABLE C/F OLD BALANCE") > 0;
            chkCarryForwardBalance.Tag = AppVars.listUserRights.Count(c => c.functionId == "DISABLE C/F OLD BALANCE") > 0;

            this.ddlDriver.SelectedValueChanged += new System.EventHandler(this.ddlDriver_SelectedValueChanged);

        }

        void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            TextSelect();
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

                        res = con.Fleet_DriverRentExpenses.Take(0).Select(w => w.Description).ToArray();
                    }
                    else
                        // res = con.Fleet_DriverTemplets.Where(w => w.Templets.StartsWith(txtRemarks.Text)).Select(w => w.Templets).ToArray();
                        res = con.Fleet_DriverRentExpenses.Where(w => w.Description.StartsWith(txtRemarks.Text)).Select(w => w.Description).ToArray();
                }
                txtRemarks.ListBoxElement.Items.AddRange(res);
                //279, 36
                if (res.Count() > 0)
                {
                    txtRemarks.ShowListBox();

                    txtRemarks.ListBoxElement.BringToFront();
                    txtRemarks.ListBoxElement.ScrollAlwaysVisible = true;
                    txtRemarks.ListBoxElement.Height = 90;
                    txtRemarks.ListBoxElement.Width = 279;
                }
                else
                {
                    txtRemarks.ListBoxElement.Hide();
                    txtRemarks.ListBoxElement.Items.RemoveAt(0);
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

        private void numRentValue_Validated(object sender, EventArgs e)
        {
            CalculateTotal();
        }


        void btnAddNew_Click(object sender, EventArgs e)
        {
            OnNew();
        }

        private bool IsDisplayingRecord=false;

        void chkHoliday_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDisplayingRecord == false)
            {

                if (chkHoliday.Checked)
                {
                    numCarRent.Value = 0.00m;
                    numpdaRent.Value = 0.00m;

                }
                else
                {
                    Fleet_Driver obj = General.GetObject<Fleet_Driver>(c => c.Id == ddlDriver.SelectedValue.ToInt());
                    if (obj != null)
                    {
                        numpdaRent.Value = obj.PDARent.ToDecimal();

                        if (obj.UseCompanyVehicle.ToBool())
                        {
                            numCarRent.Visible = true;                            
                            numCarRent.Value = obj.CarRent.ToDecimal();


                        }
                        else
                        {
                       
                            numCarRent.Value = 0.00m;

                        }


                    }
                }

                CalculateTotal();
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

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlDriver.SelectedValue == null)
            {
                ENUtils.ShowMessage("Please select a driver");
                ddlDriver.Focus();
                return;
            }
            AddDriverExpenses();
       //     CalculateBalance();
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
                       
                        string fromAddress = row.Cells[COLS.PickupPoint].Value.ToStr().Trim();

                        string toAddress = row.Cells[COLS.Destination].Value.ToStr().Trim();



                        if (string.IsNullOrEmpty(fromAddress))
                        {
                            ENUtils.ShowMessage("Pickup Address cannot be empty");
                            return;
                        }


                        if (string.IsNullOrEmpty(toAddress))
                        {
                            ENUtils.ShowMessage("Destination Address cannot be empty");
                            return;

                        }


                        long id = row.Cells[COLS.BookingId].Value.ToLong();
                        decimal fare = row.Cells[COLS.Fares].Value.ToDecimal();
                        decimal parking = row.Cells[COLS.Parking].Value.ToDecimal();
                        decimal waiting = row.Cells[COLS.Waiting].Value.ToDecimal();
                        decimal extraDrop = row.Cells[COLS.ExtraDrop].Value.ToDecimal();
                        decimal bookingFee = row.Cells[COLS.BookingFees].Value.ToDecimal();
                        //decimal meetAndGreet = row.Cells[COLS.MeetAndGreet].Value.ToDecimal();
                        //decimal CongtionCharge = row.Cells[COLS.CongtionCharge].Value.ToDecimal();


                        BookingBO objBookngBo = new BookingBO();
                        try
                        {


                            objBookngBo.GetByPrimaryKey(id);

                            if (objBookngBo.Current != null)
                            {
                                objBookngBo.Current.FareRate = fare;
                                objBookngBo.Current.CongtionCharges = parking;
                                objBookngBo.Current.MeetAndGreetCharges = waiting;
                                objBookngBo.Current.ExtraDropCharges = extraDrop;

                                objBookngBo.Current.ServiceCharges = bookingFee;
                               

                                if (objBookngBo.Current.CompanyId == null)
                                {
                                    objBookngBo.Current.TotalCharges = objBookngBo.Current.FareRate.ToDecimal()
                                                 + objBookngBo.Current.ExtraDropCharges.ToDecimal() + objBookngBo.Current.MeetAndGreetCharges.ToDecimal() + objBookngBo.Current.CongtionCharges.ToDecimal() + objBookngBo.Current.ServiceCharges.ToDecimal();
                                }
                                else
                                {
                                    objBookngBo.Current.TotalCharges = objBookngBo.Current.CompanyPrice.ToDecimal() + objBookngBo.Current.ParkingCharges.ToDecimal() + objBookngBo.Current.WaitingCharges.ToDecimal() + objBookngBo.Current.ExtraDropCharges.ToDecimal() + objBookngBo.Current.ServiceCharges.ToDecimal();

                                }

                               

                                objBookngBo.Save();

                                CalculateTotal();


                                long index = grdLister.CurrentRow != null ? grdLister.CurrentRow.Cells["Id"].Value.ToLong() : -1;
                                int val = grdLister.TableElement.VScrollBar.Value;


                                Save();


                                if (index > 0)
                                    grdLister.CurrentRow = grdLister.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == index);

                                grdLister.TableElement.VScrollBar.Value = val;



                                //          CalculateBalance();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (objMaster.Errors.Count > 0)
                                ENUtils.ShowMessage(objMaster.ShowErrors());
                            else
                                ENUtils.ShowMessage(ex.Message);

                        }
                    }
                }
                else if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
                {
                    if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    {
                        RadGridView grid = gridCell.GridControl;
                        grid.CurrentRow.Delete();
                        CalculateTotal();
                    }
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void FormatChargesGrid()
        {

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();

            col.IsVisible = false;
            col.Name = "Id";
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.IsCommissionWise;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.BookingId;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name =COLS.DriverCommissionType;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.DriverCommission;
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
            col = new GridViewTextBoxColumn();
            col.Name = COLS.PaymentTypeId;
            col.IsVisible = false;
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
            col.HeaderText = "Payment Type";
            col.IsVisible = true;
            col.Width = 70;
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


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.AccountTypeId;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Pickup Point";
            col.Name = "PickupPoint";
          //  col.ReadOnly = true;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.HeaderText = "Destination";
            col.Name = "Destination";
          //  col.ReadOnly = true;
            grdLister.Columns.Add(col);




            GridViewDecimalColumn colD = new GridViewDecimalColumn();
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
            colD.HeaderText = "Waiting";
            colD.Name = "Waiting";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = true;
            colD.ReadOnly = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Parking";
            colD.Name = "Parking";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = true;
            colD.ReadOnly = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Extra";
            colD.Name = COLS.ExtraDrop;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = true;
            colD.ReadOnly = false;
            grdLister.Columns.Add(colD);




            //colD = new GridViewDecimalColumn();
            //colD.DecimalPlaces = 2;
            //colD.Minimum = 0;
            //colD.HeaderText = "Meet and Greet";
            //colD.Name = "MeetAndGreet";
            //colD.Maximum = 9999999;
            //colD.FormatString = "{0:#,###0.00}";
            //colD.IsVisible = false;
            //grdLister.Columns.Add(colD);


            //colD = new GridViewDecimalColumn();
            //colD.DecimalPlaces = 2;
            //colD.Minimum = 0;
            //colD.HeaderText = "Congestion";
            //colD.Name = "CongtionCharge";
            //colD.Maximum = 9999999;
            //colD.FormatString = "{0:#,###0.00}";
            //colD.IsVisible = false;
            //grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.HeaderText = "Agent Fee";
            colD.Name = "AgentFees";
            colD.Maximum = 9999999;
            colD.ReadOnly = true;
            colD.FormatString = "{0:#,###0.00}";
            colD.ReadOnly = true;
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
            colD.HeaderText = "Total";
            colD.Name = "Total";
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.Expression = "Fares+Waiting";
        //    colD.Expression = "Fares";
            grdLister.Columns.Add(colD);


          


            (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
            (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


            grdLister.Columns["PickUpDate"].Width = 60;

            grdLister.Columns["Account"].Width = 75;

            grdLister.Columns[COLS.BookingId].IsVisible = false;


            grdLister.Columns["RefNumber"].Width = 40;
            grdLister.Columns["Vehicle"].Width = 60;
            grdLister.Columns[COLS.Passenger].Width = 60;
            grdLister.Columns["PickUpPoint"].Width = 80;
            grdLister.Columns["Destination"].Width = 80;

           // grdLister.Columns["Charges"].Width = 50;
            grdLister.Columns["Parking"].Width = 45;
            grdLister.Columns["Waiting"].Width = 50;
          
            grdLister.Columns["Total"].Width = 45;
            grdLister.Columns["OrderNo"].Width = 55;

            grdLister.Columns["PickUpDate"].HeaderText = "Pickup Date-Time";
            grdLister.Columns["RefNumber"].HeaderText = "Ref #";
            grdLister.Columns["PickUpPoint"].HeaderText = "Pickup Point";
      
           // grdLister.Columns["Payment_ID"].Width = 70;





            GridViewCommandColumn colCmd = new GridViewCommandColumn();
            colCmd.Width = 50;
            colCmd.Name = "btnUpdate";
            colCmd.UseDefaultText = true;
            colCmd.IsVisible = true;
            colCmd.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            colCmd.DefaultText = "Update";
            colCmd.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdLister.Columns.Add(colCmd);
          
         //   grdLister.AddDeleteColumn();


           grdLister.CommandCellClick+=new CommandCellClickEventHandler(grdLister_CommandCellClick);
            grdLister.ViewCellFormatting += GrdLister_ViewCellFormatting;
            grdLister.AllowDeleteRow = false;
            //
        }

       

        protected override void OnClosed(EventArgs e)
        {

            General.RefreshListWithoutSelected<frmDriverRentList3>("frmDriverRentList31");

        }


        public override void Save()
        {
            OnSave();
        }
        private void OnSave()
        {
            try
            {

                if (grdLister.Rows.Count == 0)
                    CalculateTotal();

                int DriverId = ddlDriver.SelectedValue.ToInt();

                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                }
                else
                {
                    var query = General.GetQueryable<DriverRent>(c => c.DriverId == DriverId).OrderByDescending(c => c.Id).FirstOrDefault();

                    if (query != null)
                    {
                        string Transno = query.TransNo.ToStr();

                        if (Transno == txtTransNo.Text)
                        {
                            objMaster.Edit();
                        }
                        else
                        {
                            ENUtils.ShowMessage("Can not Save Record. Another Record Exits..");
                        }
                    }
                    else
                    {
                        objMaster.Edit();
                    }
                }
               // decimal Fuel = txtFuel.Text == "" ? 0 : txtFuel.Text.ToDecimal();
             ///   decimal Extra = txtExtra.Text == "" ? 0 : txtExtra.Text.ToDecimal();



                objMaster.Current.TransDate = dtpTransactionDate.Value.ToDateTime();
                objMaster.Current.DriverId = ddlDriver.SelectedValue.ToIntorNull();
                objMaster.Current.DriverRent1 = numDrvRent.Value.ToDecimal();
                
                objMaster.Current.Balance = txtBlance.Value.ToDecimal();
                objMaster.Current.OldBalance = txtOldBalance.Text.ToDecimal();

                objMaster.Current.PDARent = numpdaRent.Value.ToDecimal();
                objMaster.Current.VAT = numVAT.Value.ToDecimal();

                objMaster.Current.FromDate = dtpFromDate.Value.ToDate();
                objMaster.Current.ToDate = dtpTillDate.Value.ToDate();
                objMaster.Current.TransFor = ddlDayWise.SelectedText.ToStr();
                // Driver Vehicle Rent
                objMaster.Current.CarRent = numCarRent.Value.ToDecimal();
                objMaster.Current.CarInsuranceRent = numCarInsuranceRent.Value.ToDecimal();
                objMaster.Current.PrimeCompanyRent = numPrimeCompanyRent.Value.ToDecimal();
                //

                objMaster.Current.IsHoliday = chkHoliday.Checked;

                objMaster.Current.AccountJobsTotal = txtAccountTotal.Value;
                objMaster.Current.CashJobsTotal = numCashJobsTotal.Value;


                objMaster.Current.JobsTotal = objMaster.Current.AccountJobsTotal.ToDecimal() + objMaster.Current.CashJobsTotal.ToDecimal();

                objMaster.Current.TotalJobs = grdLister.Rows.Count;

             
                objMaster.Current.AccountExpenses = numAccountExpenses.Value.ToDecimal();

                objMaster.Current.AgentTotal = numAgentTotal.Value.ToDecimal() ;
                objMaster.Current.OldAgentCommission = numaccountbookingfeetotal.Value.ToDecimal();

                objMaster.Current.Extra = numExtraTotal.Value.ToDecimal();
                objMaster.Current.Fuel = numParkingTotal.Value.ToDecimal();

                string[] skipProperties = { "DriverRent", "Booking" };
                IList<DriverRent_Charge> savedList = objMaster.Current.DriverRent_Charges;
                List<DriverRent_Charge> listofDetail = (from r in grdLister.Rows

                                                        select new DriverRent_Charge
                                                            {
                                                                Id = r.Cells[COLS.ID].Value.ToLong(),
                                                                TransId = r.Cells[COLS.TransId].Value.ToLong(),
                                                                BookingId = r.Cells[COLS.BookingId].Value.ToLongorNull(),

                                                            }).ToList();


                Utils.General.SyncChildCollection(ref savedList, ref listofDetail, "Id", skipProperties);

                string[] skipExpensesProperties = { "DriverRent"};
                IList<Fleet_DriverRentExpense> savedlistExpenses = objMaster.Current.Fleet_DriverRentExpenses;
                List<Fleet_DriverRentExpense> listofDetailExpenses = (from a in grdDriverExpenses.Rows
                                                                    select new Fleet_DriverRentExpense
                                                                    {
                                                                        Id=a.Cells[EXPCOLS.Id].Value.ToLong(),
                                                                        RentId=a.Cells[EXPCOLS.RentId].Value.ToLongorNull(),
                                                                        Credit=a.Cells[EXPCOLS.Credit].Value.ToDecimal(),
                                                                        Debit=a.Cells[EXPCOLS.Debit].Value.ToDecimal(),
                                                                        Date=a.Cells[EXPCOLS.Date].Value.ToDateorNull(),
                                                                        Amount=a.Cells[EXPCOLS.Amount].Value.ToDecimal(),
                                                                        Description=a.Cells[EXPCOLS.Description].Value.ToStr(),
                                                                         AddBy=a.Cells[EXPCOLS.User].Value.ToStr()
                                                                         
                                                                    }).ToList();
                Utils.General.SyncChildCollection(ref savedlistExpenses, ref listofDetailExpenses, "Id", skipExpensesProperties);


                objMaster.CheckDataValidation = true;

                objMaster.Current.TransactionType = Enums.TRANSACTIONTYPE.DRIVER_RENT_EXPENSE3;
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


            try
            {
                IsDisplayingRecord = true;

                ddlDriver.Enabled = false;

             //   btnPaymentHistory.Visible = true;
          
         
                lblRent.Visible = true;
         

                lblRentPound.Visible = true;
           


                radButton1.Enabled = false;


                btnExportPDF.Enabled = true;
                btnPrint2.Enabled = true;
                btnSendEmail.Enabled = true;
                pnlPaid.Visible = true;

                txtTransNo.Text = objMaster.Current.TransNo.ToStr();
                dtpTransactionDate.Value = objMaster.Current.TransDate.ToDate();
                ddlDriver.SelectedValue = objMaster.Current.DriverId;

                dtpFromDate.Value = objMaster.Current.FromDate.ToDate();
                dtpTillDate.Value = objMaster.Current.ToDate.ToDate();


                ddlDayWise.SelectedText = "";
                ddlDayWise.SelectedText = objMaster.Current.TransFor.ToStr();
                numAccountExpenses.Value = objMaster.Current.AccountExpenses.ToDecimal();


                chkHoliday.Checked = objMaster.Current.IsHoliday.ToBool();

                if (chkHoliday.Checked)
                {

                    chkHoliday.Visible = true;
                }

                int cnt = objMaster.Current.DriverRent_Charges.Count;
                var list = objMaster.Current.DriverRent_Charges;
                grdLister.RowCount = cnt;
                Booking objBooking = null;
                for (int i = 0; i < cnt; i++)
                {
                    grdLister.Rows[i].Cells[COLS.ID].Value = list[i].Id;
                    grdLister.Rows[i].Cells[COLS.TransId].Value = list[i].TransId;
                    grdLister.Rows[i].Cells[COLS.BookingId].Value = list[i].BookingId;

                    objBooking = list[i].Booking;

                    if (objBooking != null)
                    {

                        try
                        {

                            grdLister.Rows[i].Cells[COLS.Account].Value = objBooking.CompanyId != null ? objBooking.Gen_Company.CompanyName : "";
                            grdLister.Rows[i].Cells[COLS.CompanyId].Value = objBooking.CompanyId.ToStr();

                            grdLister.Rows[i].Cells[COLS.AccountTypeId].Value = objBooking.CompanyId != null ? objBooking.Gen_Company.AccountTypeId.ToStr().Trim() : null;

                            grdLister.Rows[i].Cells[COLS.PickupDate].Value = objBooking.PickupDateTime;
                            grdLister.Rows[i].Cells[COLS.OrderNo].Value = objBooking.OrderNo;
                            grdLister.Rows[i].Cells[COLS.PupilNo].Value = objBooking.PupilNo;

                            grdLister.Rows[i].Cells[COLS.BookedBy].Value = objBooking.Gen_Company_Department.DefaultIfEmpty().DepartmentName.ToStr();

                            grdLister.Rows[i].Cells[COLS.Vehicle].Value = objBooking.Fleet_VehicleType.VehicleType;

                            grdLister.Rows[i].Cells[COLS.VehicleID].Value = objBooking.VehicleTypeId;
                            grdLister.Rows[i].Cells[COLS.RefNumber].Value = objBooking.BookingNo;




                            grdLister.Rows[i].Cells[COLS.PickupPoint].Value = !string.IsNullOrEmpty(objBooking.FromDoorNo) ? objBooking.FromDoorNo + " - " + objBooking.FromAddress.ToStr() : objBooking.FromAddress.ToStr();
                            grdLister.Rows[i].Cells[COLS.Destination].Value = !string.IsNullOrEmpty(objBooking.ToDoorNo) ? objBooking.ToDoorNo + " - " + objBooking.ToAddress.ToStr() : objBooking.ToAddress.ToStr();

                            grdLister.Rows[i].Cells[COLS.Parking].Value = objBooking.CongtionCharges.ToDecimal();
                            grdLister.Rows[i].Cells[COLS.Waiting].Value = objBooking.MeetAndGreetCharges.ToDecimal();
                            grdLister.Rows[i].Cells[COLS.AgentFees].Value = objBooking.AgentCommission.ToDecimal();
                               grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = objBooking.ExtraDropCharges.ToDecimal();
                            //     grdLister.Rows[i].Cells[COLS.MeetAndGreet].Value = objBooking.MeetAndGreetCharges.ToDecimal();
                            //     grdLister.Rows[i].Cells[COLS.CongtionCharge].Value = objBooking.CongtionCharges.ToDecimal();

                            grdLister.Rows[i].Cells[COLS.Fares].Value = objBooking.FareRate.ToDecimal();
                            grdLister.Rows[i].Cells[COLS.Total].Value = objBooking.FareRate.ToDecimal() + objBooking.MeetAndGreetCharges.ToDecimal();


                            grdLister.Rows[i].Cells[COLS.Passenger].Value = objBooking.CustomerName.ToStr().Trim();

                            //    grdLister.Rows[i].Cells[COLS.Payment_ID].Value = objBooking.InvoicePaymentTypeId.ToInt();

                            grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value = objBooking.PaymentTypeId.ToInt();

                            grdLister.Rows[i].Cells[COLS.PaymentType].Value = objBooking.Gen_PaymentType.PaymentType.ToStr();

                            grdLister.Rows[i].Cells[COLS.BookingFees].Value = objBooking.ServiceCharges.ToDecimal();

                            grdLister.Rows[i].Cells[COLS.IsCommissionWise].Value = objBooking.IsCommissionWise.ToBool();
                            grdLister.Rows[i].Cells[COLS.DriverCommissionType].Value = objBooking.DriverCommissionType.ToStr().Trim();
                            grdLister.Rows[i].Cells[COLS.DriverCommission].Value = objBooking.DriverCommission.ToDecimal();
                           
                        }
                        catch
                        {


                        }
                    }

                }

                grdLister.CurrentRow = null;
                //NC
                grdDriverExpenses.Rows.Clear();
                foreach (var item in objMaster.Current.Fleet_DriverRentExpenses)
                {
                    GridViewRowInfo row;
                    row = grdDriverExpenses.Rows.AddNew();
                    row.Cells[EXPCOLS.Id].Value = item.Id;
                    row.Cells[EXPCOLS.RentId].Value = item.RentId;
                    row.Cells[EXPCOLS.Credit].Value = item.Credit;
                    row.Cells[EXPCOLS.Debit].Value = item.Debit;
                    row.Cells[EXPCOLS.Date].Value = item.Date;
                    row.Cells[EXPCOLS.Amount].Value = item.Amount;
                    row.Cells[EXPCOLS.Description].Value = item.Description;
                    row.Cells[EXPCOLS.User].Value = item.AddBy.ToStr();
                }



                numDrvRent.Value = objMaster.Current.DriverRent1.ToDecimal();
                numCarRent.Value = objMaster.Current.CarRent.ToDecimal();
                numCarInsuranceRent.Value = objMaster.Current.CarInsuranceRent.ToDecimal();
                numPrimeCompanyRent.Value = objMaster.Current.PrimeCompanyRent.ToDecimal();
                numpdaRent.Value = objMaster.Current.PDARent.ToDecimal();
              
                txtAccountTotal.Value = objMaster.Current.AccountJobsTotal.ToDecimal();
                numAgentTotal.Value = objMaster.Current.AgentTotal.ToDecimal();
                numaccountbookingfeetotal.Value = objMaster.Current.OldAgentCommission.ToDecimal();

                numParkingTotal.Value = objMaster.Current.Fuel.ToDecimal();
                numExtraTotal.Value = objMaster.Current.Extra.ToDecimal();
                txtOldBalance.Value = objMaster.Current.OldBalance.ToDecimal();
                txtBlance.Value = objMaster.Current.Balance.ToDecimal();
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



                ddlSubCompany.Enabled = true;
                if (ddlSubCompany.DataSource == null)
                {
                    ComboFunctions.FillSubCompanyCombo(ddlSubCompany);

                    if (ddlSubCompany.Items.Count > 1)
                        ddlSubCompany.SelectedIndex = 1;
                    else
                        ddlSubCompany.SelectedIndex = 0;


                }

                ddlSubCompany.SelectedValue = objMaster.Current.Fleet_Driver.DefaultIfEmpty().SubcompanyId;

                IsDisplayingRecord = false;



                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var query =db.DriverRents.Where(c => c.DriverId == objMaster.Current.DriverId).Select(c=>c.Id).OrderByDescending(c => c).FirstOrDefault().DefaultIfEmpty();


                    if ((query != 0 && query != objMaster.Current.Id && query > objMaster.Current.Id))
                    {

                        btnSaveInvoice.Enabled = false;
                        //   btnPick.Enabled = false;


                    }
                }

                chkCarryForwardBalance.Enabled = false;
            }
            catch (Exception ex)
            {



            }

        }


        private void btnPickBooking_Click(object sender, EventArgs e)
        {
            try
            {
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



                bool RentForProcessedJobs = AppVars.objPolicyConfiguration.RentForProcessedJobs.ToBool();

                string[] hiddenColumns = null;


                hiddenColumns = new string[] {  "Id", "Parking","Destination","Waiting","ExtraDrop","MeetAndGreet","Congtion",
                                                "Total","OrderNo","PupilNo","BookingDate","Description","Charges","AccountType","CompanyId",   "IsCommissionWise","DriverCommissionType","DriverCommission","PaymentTypeId","DropOffCharge","PickupCharge","AgentCommission","BookingStatusId"};



                Func<Booking, bool> _conditionDate = null;
                //if (ddlPickType.SelectedIndex == 0)
                    _conditionDate = b => b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate;
                //else
                //    _conditionDate = b => b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate;


                Expression<Func<Booking, bool>> _exp=null;

                if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2)
                {
                    _exp = c => c.DriverId == DriverId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP) )
                                             &&   (c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate);

                }
               else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 4)
                {
                    _exp = c => c.DriverId == DriverId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && (c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || c.BookingStatusId==Enums.BOOKINGSTATUS.CANCELLED)))
                                            && (c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate);
                }
                else
                {
                    _exp = c => c.DriverId == DriverId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED)
                     && (c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate);


                }

                List<object[]> list = General.ShowDriverRentTransactionExpensesWithWaitingBookingMultiLister(_exp, hiddenColumns, _conditionDate);
                GridViewRowInfo row;



                int cnt = list.Count;


             //   var existBookingId = grdLister.Rows.Select(c => c.Cells[COLS.BookingId].Value.ToLong()).ToList<long>();

             //   list.RemoveAll(c => existBookingId.Contains(c[0].ToLong()));

                cnt = list.Count;
                decimal a1 = 0;
                decimal a2 = 0;


                grdLister.RowCount = cnt;

                for (int i = 0; i < cnt; i++)
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

                    grdLister.Rows[i].Cells[COLS.CompanyId].Value = list[i][11].ToStr();
                    grdLister.Rows[i].Cells[COLS.AccountTypeId].Value = list[i][22].ToStr();

                    //  grdLister.Rows[i].Cells[COLS.Charges].Value = list[i][10].ToDecimal();

                    grdLister.Rows[i].Cells[COLS.Parking].Value = list[i][13].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.Waiting].Value = list[i][14].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = list[i][30].ToDecimal();


                   
                    grdLister.Rows[i].Cells[COLS.Total].Value = list[i][19].ToDecimal()+ list[i][14].ToDecimal();

                    grdLister.Rows[i].Cells[COLS.RemovalDescription].Value = list[i][18].ToStr();

                    grdLister.Rows[i].Cells[COLS.BookedBy].Value = list[i][20].ToStr();
                    grdLister.Rows[i].Cells[COLS.Fares].Value = list[i][21].ToDecimal();


                    grdLister.Rows[i].Cells[COLS.IsCommissionWise].Value = list[i][23].ToStr().Trim();
                    grdLister.Rows[i].Cells[COLS.DriverCommissionType].Value = list[i][24].ToStr().Trim();
                    grdLister.Rows[i].Cells[COLS.DriverCommission].Value = list[i][25].ToDecimal();
                    grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value = list[i][29].ToInt();

                  

                    grdLister.Rows[i].Cells[COLS.AgentFees].Value = list[i][26].ToInt();

                    grdLister.Rows[i].Cells[COLS.BookingFees].Value = list[i][31].ToDecimal();


                    grdLister.Rows[i].Cells[COLS.PaymentType].Value = list[i][34].ToStr();
                }
                numAccountExpenses.Value = (a1 + a2);
                CalculateTotal();
        
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }


        private void SetWeekDates(int? driverId)
        {
            if (driverId == null)
                return;

            try
            {
                if (objMaster.PrimaryKeyValue == null)
                {

                    var query1 = General.GetQueryable<DriverRent>(c => c.DriverId == driverId)
                                          .OrderByDescending(c => c.Id).FirstOrDefault();
                    if (query1 != null)
                    {
                        DateTime? dtTill = query1.ToDate.ToDateorNull();
                        dtpFromDate.Value = dtTill.Value.AddDays(1);
                        dtpTillDate.Value = dtTill.Value.AddDays(7);

                    }
                }

            }
            catch
            {


            }
        }

        private bool IsNewRecord = false;

        private void ddlDriver_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsNewRecord)
                return;

            try
            {
                int? DriverId = ddlDriver.SelectedValue.ToInt();

                SetWeekDates(DriverId);

                Fleet_Driver obj = General.GetObject<Fleet_Driver>(c => c.Id == DriverId);
                if (obj != null)
                {
                    
                    numDrvRent.Value = (obj.DriverMonthlyRent.ToDecimal()).ToDecimal();
                 //   txtRent.Text = (obj.DriverMonthlyRent.ToDecimal()).ToStr();
                    numpdaRent.Value = obj.PDARent.ToDecimal();

                    if (obj.UseCompanyVehicle.ToBool())
                    {
                        lblCarRent.Visible = true;
                        lblCarInsurance.Visible = true;
                        numCarRent.Visible = true;

                        numCarRent.Value = obj.CarRent.ToDecimal();

                        numCarInsuranceRent.Visible = true;
                        numCarInsuranceRent.Value = obj.CarInsuranceRent.ToDecimal();
                    }
                    else
                    {
                        numCarRent.Value = 0.00m;
                        numCarRent.Visible = false;
                        numCarInsuranceRent.Value = 0.00m;
                        numCarInsuranceRent.Visible = false;
                        lblCarRent.Visible = false;
                        lblCarInsurance.Visible = false;
                    }

                    if (obj.IsPrimeCompanyDriver.ToBool())
                    {
                        lblPrimeRent.Visible = true;
                        numPrimeCompanyRent.Visible = true;
                        numPrimeCompanyRent.Value = obj.PrimeCompanyRent.ToDecimal();
                    }
                    else
                    {
                        numPrimeCompanyRent.Value = 0.00m;
                        numPrimeCompanyRent.Visible = false;
                        lblPrimeRent.Visible = false;

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

                    //PDARent = obj.PDARent.ToDecimal();
                    //CarRent = obj.CarRent.ToDecimal();
                    //CarInsuranceRent = obj.CarInsuranceRent.ToDecimal();
                    //PrimeCompanyRent = obj.PrimeCompanyRent.ToDecimal();
                  
                    CalculateTotal();

                    ddlSubCompany.SelectedValue = obj.SubcompanyId;
             
                
                
                }


                if (obj.DriverRents.Count == 0)
                {

                    decimal driverBalance =obj.InitialBalance.ToDecimal();
                    txtOldBalance.Value = (driverBalance).ToDecimal();

                }
                else
                {

                    SetOldBalance(DriverId);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void SetOldBalance(int? DriverId)
        {
            if (DriverId == null)
                return;
            try
            {

                if ( (chkCarryForwardBalance.Visible == false && chkCarryForwardBalance.Tag.ToBool()==false) || chkCarryForwardBalance.Checked)
                {

                    var query = General.GetQueryable<DriverRent>(c => c.DriverId == DriverId).OrderByDescending(c => c.Id).FirstOrDefault();

                    if (query != null)
                    {

                        txtOldBalance.Value = query.Balance.ToDecimal();
                    }
                    else
                    {
                        txtOldBalance.Value = 0.00m;
                    }
                }
                else
                {
                    txtOldBalance.Value = 0.00m;
                }
            }
            catch
            {

            }
        }


        private void CalculateTotal()
        {

            try
            {
                // NC
                decimal Credit = 0.00m;
                decimal Debit = 0.00m;
                decimal totalCredit = 0.00m;
                decimal totalDebit = 0.00m;

                decimal owedBalance = 0.00m;
                decimal Currentbalance = 0.00m;
                double totalWeeks = (dtpTillDate.Value.ToDate().Subtract(dtpFromDate.Value.ToDate()).TotalDays) / 7;

                if (totalWeeks <= 0)
                    totalWeeks = 1;



                numCashJobsTotal.Value = grdLister.Rows
                                            .Where(c=>c.Cells[COLS.PaymentTypeId].Value.ToInt()==Enums.PAYMENT_TYPES.CASH)
                                            .Sum(c=>c.Cells[COLS.Total].Value.ToDecimal().ToDecimal());



                txtAccountTotal.Value = grdLister.Rows
                                            .Where(c=>c.Cells[COLS.PaymentTypeId].Value.ToInt()!=Enums.PAYMENT_TYPES.CASH)
                                            .Sum(c=>c.Cells[COLS.Total].Value.ToDecimal().ToDecimal());



                decimal parkingTotal = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH)
                                                          .Sum(c => c.Cells[COLS.Parking].Value.ToDecimal());
           

                numParkingTotal.Value = parkingTotal;


                decimal extraTotal = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH)
                                                       .Sum(c => c.Cells[COLS.ExtraDrop].Value.ToDecimal());


                numExtraTotal.Value = extraTotal;



              



                decimal AccountjobTotal = txtAccountTotal.Value.ToDecimal();

                     
                        decimal OldBalance =  txtOldBalance.Text.ToDecimal();
                        decimal DriverRent = numDrvRent.Text.ToDecimal();


                        decimal TotalpdaRent = (numpdaRent.Value );
                        decimal TotalCarRent = (numCarRent.Value);
                        decimal TotalCarInsuranceRent = (numCarInsuranceRent.Value);
                        decimal TotalPrimeCompanyRent = (numPrimeCompanyRent.Value );
                      
                        //decimal TotalpdaRent = (PDARent * totalWeeks.ToInt());
                        //decimal TotalCarRent = (CarRent * totalWeeks.ToInt());
                        //decimal TotalCarInsuranceRent = (CarInsuranceRent * totalWeeks.ToInt());
                        //decimal TotalPrimeCompanyRent = (PrimeCompanyRent * totalWeeks.ToInt());

                        numpdaRent.Value = TotalpdaRent;
                        numCarRent.Value = TotalCarRent;
                        numCarInsuranceRent.Value = TotalCarInsuranceRent;
                        numPrimeCompanyRent.Value = TotalPrimeCompanyRent;                    
                 
                        if (grdDriverExpenses.RowCount > 0)
                        {
                            Debit = grdDriverExpenses.Rows.Sum(c => c.Cells[EXPCOLS.Debit].Value.ToDecimal());
                            Credit = grdDriverExpenses.Rows.Sum(c => c.Cells[EXPCOLS.Credit].Value.ToDecimal());
                        }

                         numAgentTotal.Value = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.CASH)
                                        .Sum(c => (c.Cells[COLS.AgentFees].Value.ToDecimal()).ToDecimal());

                numAgentTotal.Value = numAgentTotal.Value + grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() == Enums.PAYMENT_TYPES.CASH).Sum(c => (c.Cells[COLS.BookingFees].Value.ToDecimal()).ToDecimal());

                decimal agentFeesTotal =numAgentTotal.Value;


                     numaccountbookingfeetotal.Value = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != Enums.PAYMENT_TYPES.CASH).Sum(c => (c.Cells[COLS.BookingFees].Value.ToDecimal()).ToDecimal());




                totalCredit = (AccountjobTotal + Credit.ToDecimal() + parkingTotal+ extraTotal+(numAccountExpenses.Value.ToDecimal()));
                        totalDebit=Debit +(DriverRent + agentFeesTotal+ TotalpdaRent + TotalCarRent + TotalCarInsuranceRent + TotalPrimeCompanyRent);
 
                     
                        owedBalance = (totalDebit-totalCredit );
                      
                        Currentbalance = owedBalance + OldBalance;                
                        txtBlance.Value = Currentbalance.ToDecimal();
            }
            catch (Exception ex)
            {
            }
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


          
            
            frmDriverTransactionExpensesReport3 frm = new frmDriverTransactionExpensesReport3(1);
            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "summary_";

            }
            var list = General.GetQueryable<vu_DriverRentExpense>(a => a.Id == id).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverRentExpense>(a => a.RentId == id).ToList();
            frm.DataSource2 = list2;
            frm.CompanyHeader = ddlSubCompany.Text.Trim();
            frm.ObjSubCompany = General.GetObject<Gen_SubCompany>(c => c.Id == ddlSubCompany.SelectedValue.ToInt());
            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }
            frm.GenerateReport();

            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverTransactionExpensesReport31");
            if (doc != null)
            {
                doc.Close();
            }

            UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
        }




        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;

            //frmDriverTransactionReport frm = new frmDriverTransactionReport(1);


            //var list = General.GetQueryable<vu_DriverRent>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            //int count = list.Count;

            //frm.DataSource = list;
            //frm.CompanyHeader = ddlSubCompany.Text.Trim();

            //frm.GenerateReport();
            frmDriverTransactionExpensesReport3 frm = new frmDriverTransactionExpensesReport3(1);
            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "summary_";

            }
            var list = General.GetQueryable<vu_DriverRentExpense>(a => a.Id == id).OrderBy(c=>c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverRentExpense>(a => a.RentId == id).ToList();
            frm.DataSource2 = list2;
            frm.CompanyHeader = ddlSubCompany.Text.Trim();
            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }
            frm.GenerateReport();


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverTransactionExpensesReport31");


            frm.ExportReport(objMaster.Current.TransNo);
        }


        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            OnSave();

        }
        public override void OnNew()
        {
            txtTransNo.Text = string.Empty;
            IsNewRecord = true;
            FillDriverCombo();
        //    ComboFunctions.FillRentPayReasonCombo(ddlReason);
            grdLister.Rows.Clear();

            txtAccountTotal.Text = string.Empty;
         //   ddlReason.SelectedIndex = 0;
            grdDriverExpenses.Rows.Clear();
            numAccountExpenses.Value = 0;
            numParkingTotal.Value = 0.00m;
            numExtraTotal.Value = 0.00m;

            spnAmount.Value = 0;
            txtRemarks.Text = "";

            IsDisplayingRecord = true;
            chkHoliday.Checked = false;
            chkHoliday.Visible = true;
            IsDisplayingRecord = false;

            numCarInsuranceRent.Value = 0.00m;
            numCarRent.Value = 0.00m;
            numPrimeCompanyRent.Value = 0.00m;
            numDrvRent.Value = 0.00m;
            numpdaRent.Value = 0.00m;

            txtAccountTotal.Value = 0.00m;
            txtOldBalance.Value = 0.00m;
            txtBlance.Value = 0.00m;


            btnPaymentHistory.Visible = false;
            radButton1.Enabled = true;
            btnPrint2.Enabled = false;
            btnExportPDF.Enabled = false;
            btnSendEmail.Enabled = false;

            lblVAT.Visible = false;
            numVAT.Value=0.00m;
            numVAT.Visible = false;

            objMaster.Clear();
            IsNewRecord = false;

            ddlDriver.Focus();
            ddlDriver.Enabled = true;

            chkCarryForwardBalance.Enabled = true;

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


                       radButton1.Enabled = true;
                    CalculateTotal();
                    // CalculateBalance();

                }
                else
                {
                    e.Cancel = true;
               

                }


            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;

            //frmDriverTransactionReport frm = new frmDriverTransactionReport(1);


            //var list = General.GetQueryable<vu_DriverRent>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            //int count = list.Count;

            //frm.DataSource = list;
            //frm.CompanyHeader = ddlSubCompany.Text.Trim();

            //frm.GenerateReport();

            frmDriverTransactionExpensesReport3 frm = new frmDriverTransactionExpensesReport3(1);
            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                frm.DisplayCriteriaType = "summary_";

            }
            var list = General.GetQueryable<vu_DriverRentExpense>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverRentExpense>(a => a.RentId == id).ToList();
            frm.DataSource2 = list2;
            frm.CompanyHeader = ddlSubCompany.Text.Trim();

            if (numVAT.Visible && numVAT.Value > 0)
            {
                frm.VAT = numVAT.Value.ToDecimal();
            }
            frm.GenerateReport();



           // DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverTransactionExpensesReport31");
            frm.SendEmail(objMaster.Current.TransNo, objMaster.Current.Fleet_Driver.DefaultIfEmpty().Email.ToStr().Trim());
            //   frm.SendEmail(objMaster.Current.TransNo);
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
         //   CalculateBalance();
        }
    
        private void ddlDayWise_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
            }

        }

        private void btnBookingReport_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;


            frmDriverTransactionExpensesReport3 frm = new frmDriverTransactionExpensesReport3(2);

            var list = General.GetQueryable<vu_DriverRentExpense>(a => a.Id == id).ToList();
            int count = list.Count;

            frm.DataSource = list;
            var list2 = General.GetQueryable<vu_FleetDriverRentExpense>(a => a.RentId == id).ToList();
            frm.DataSource2 = list2;

            frm.GenerateReport();


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverTransactionExpensesReport31");

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

        private void txtOldBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ( e.KeyChar!='-' && (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))))
                e.Handled = true;

            if (grdLister.Rows.Count > 0)
                e.Handled = true;

            if (txtOldBalance.Text.Length > 0 && e.KeyChar == '-')
                e.Handled = true;
       
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
               
                if(objMaster.Current!=null && objMaster.PrimaryKeyValue!=null)
                {

                    frmSearchDriverRentPaymentHistory frm = new frmSearchDriverRentPaymentHistory("",objMaster.Current.DriverRent_PaymentHistories.OrderBy(c => c.PaymentDate).ToList());

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
