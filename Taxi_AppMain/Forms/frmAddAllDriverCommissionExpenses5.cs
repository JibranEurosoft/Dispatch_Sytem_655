using System;
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
using UI;
using System.Linq.Expressions;

namespace Taxi_AppMain
{
    public partial class frmAddAllDriverCommissionExpenses5 : UI.SetupBase
    {
        DriverCommisionBO objMaster = null;
        ConditionalFormattingObject objCondition = new ConditionalFormattingObject();
        ConditionalFormattingObject objConditionGeneratedTrans = new ConditionalFormattingObject();
        public struct COLS
        {
            public static string Email = "Email";
            public static string Id = "Id";
            public static string DriverNo = "DriverNo";

            public static string DriverCommission = "DriverCommission";
            public static string DriverCommissionPerBooking = "DriverCommissionPerBooking";
            public static string DriverPDARent = "DriverPDARent";

            public static string CommissionPay = "CommissionPay";

            public static string OldBalance = "OldBalance";
            public static string InitialBalance = "InitialBalance";
            public static string SubCompanyId = "SubCompanyId";
            public static string CurrBalance = "CurrBalance";
            public static string TotalPDARent = "TotalPDARent";
            public static string BookingFees = "BookingFees";
            public static string AccountsTotal = "AccountsTotal";
            public static string AccountExpense = "AccountExpense";
            public static string Owed = "Owed";
            public static string CommissionId = "CommissionId";
            public static string CashTotal = "CashTotal";
            public static string JobsTotal = "JobsTotal";
            public static string AgentFees = "AgentFees";
            public static string DriverEmail = "DriverEmail";

            public static string PaidPromotion = "PaidPromotion";
            public static string Promotion = "Promotion";

            public static string CollectionAndDelivery = "CollectionAndDelivery";
            public static string TotalCollectionAndDelivery = "TotalCollectionAndDelivery";
            public static string Hokiday = "Hokiday";
            public static string VAT = "VAT";
        }
       
        private BackgroundWorker worker_Commission;

        private void InitializeFaresWorker()
        {
            if (worker_Commission == null)
            {
                worker_Commission = new BackgroundWorker();
                worker_Commission.DoWork += Worker_Commission_DoWork;
        
                worker_Commission.RunWorkerCompleted += Worker_Commission_RunWorkerCompleted;
                worker_Commission.ProgressChanged += Worker_Commission_ProgressChanged;
                worker_Commission.WorkerSupportsCancellation = true;
                worker_Commission.WorkerReportsProgress = true;
                Progessbar.Maximum = 100;
                Progessbar.Minimum = 0;
                Progessbar.Value1 = 0;
            }

        }
        int cnt = 0;
        private void Worker_Commission_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                cnt += 1;

               
                   

                Progessbar.Value1 = e.ProgressPercentage;
                Progessbar.Text = String.Format("In Progress...  {0} / {1}", cnt, selectedRows.Count);

                if(e.UserState!=null)
                {
                    var state =(ClsRowState) e.UserState;

                    state.row.Cells[COLS.CommissionId].Value = state.transId;


                    state.row.Cells[COLS.AccountsTotal].Value = state.accJobsTotal;
                    state.row.Cells[COLS.Owed].Value = state.rentDue;
                    state.row.Cells[COLS.CurrBalance].Value = state.currBlance;


                    state.row.Cells[COLS.SubCompanyId].Value = state.subCompanyId;


                }

                if (e.ProgressPercentage >= 100)
                {
                    Progessbar.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void Worker_Commission_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progessbar.Visible = false;
            Progessbar.Value1 = 0;
            percentage = 0;
            Progessbar.Text = string.Empty;
            dtpFromDate.Enabled = true;
            dtpTillDate.Enabled = true;
            
            btnSendEmail.Enabled = true;

            if (IsSavedTrans)
            {

                grdDriverCommission.Columns[COLS.CommissionPay].ReadOnly = true;
                btnPrintAll.Enabled = true;
                btnViewPrint.Enabled = true;
                btnDeleteGenerated.Visible = true;
                btnDeleteGenerated.Enabled = true;
               

            }

            if(e.Result.ToStr()!="Generate")
            {
                btnGenerate.Enabled = true;
                btnDisplayCommission.Enabled = true;
                btnGetBooking.Enabled = true;
                btnClear.Enabled = true;
                
            }

            grdDriverCommission.ReadOnly = false;
        }
        public int percentage = 0;
    
        private void Worker_Commission_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               
                
                string arg = e.Argument.ToStr();
                var count = 100 / selectedRows.Count();
                if (arg == "Get Booking")
                {
                    

                  


                    var CommissionList = General.GetGeneralList<Fleet_DriverCommision_Charge>(c => c.BookingId != null && c.TransId != 0);

                    int val = 0;
                    foreach (var row in selectedRows)
                    {

                        val += 1;
                        

                        int driverId = row.Cells[COLS.Id].Value.ToInt();
                        Expression<Func<Booking, bool>> _condition = null;

                        if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2)
                        {
                            _condition = c =>

                                                (c.FareRate != null)

                                              && (c.DriverId == driverId)
                                              && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP))
                                              && ((c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate)


                                              );

                        }
                        else
                        {

                            _condition = c =>

                                                (c.FareRate != null)

                                              && (c.DriverId == driverId)
                                              && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED)
                                              && ((c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate)


                                              );


                        }


                        var list2 = (from a in General.GetGeneralList<Booking>(_condition)
                                     join b in CommissionList on a.Id equals b.BookingId into table2
                                     from b in table2.DefaultIfEmpty()

                                     where (b == null)
                                     select new
                                     {
                                         Id = a.Id,

                                     }).Count();




                        row.Cells["Bookings"].Value = list2;

                        
                        int Cal = percentage += count;                                             

                        worker_Commission.ReportProgress(Cal);//100 * count / grdDriverCommission.Rows.Count);
             
                        

                    }
                }
                else if (arg == "Display Commission")
                {
                    DisplayCommission("");
                }
                else if (arg == "Generate")
                {
                    DisplayCommission(arg.ToStr());
                    Generate();
                   
                }

                e.Result = arg;
            }
            catch (Exception)
            {

              
            }
        }

        public frmAddAllDriverCommissionExpenses5()
        {

            InitializeComponent();
            InitializeFaresWorker();
            this.FormClosed += new FormClosedEventHandler(frmAddMultipleCompanyInvoice_FormClosed);
            this.KeyDown += new KeyEventHandler(frmAddAllDriverRent_KeyDown);
        }




        void frmAddAllDriverRent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



        void frmAddMultipleCompanyInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (worker_Commission != null)
                {

                    worker_Commission.Dispose();
                    worker_Commission = null;

                }

            }
            catch
            {

            }

            this.Dispose(true);
            GC.Collect();
        }

        private void frmCompanyInvoice_Load(object sender, EventArgs e)
        {
            DateTime? fromDate = AppVars.objPolicyConfiguration.RentFromDateTime.ToDateTimeorNull();
            DateTime? toDate = AppVars.objPolicyConfiguration.RentToDateTime.ToDateTimeorNull();

            try
            {

                int subtracted = 7 - (int)fromDate.Value.DayOfWeek;

                int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
                DateTime dtFrom = DateTime.Now.Subtract(TimeSpan.FromDays(DaysToSubtract));

                if (subtracted == 7)
                {
                    subtracted = 6;
                }

                fromDate = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.AddDays(-subtracted).Day, fromDate.Value.Hour, fromDate.Value.Minute, 0, 0);


                DateTime dtTo = DateTime.Now.Subtract(TimeSpan.FromDays(DaysToSubtract));
                toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dtTo.AddDays(toDate.Value.DayOfWeek.ToInt()).Day, toDate.Value.Hour, toDate.Value.Minute, 59, 999);


                dtpFromDate.Value = fromDate;
                dtpTillDate.Value = toDate;
            }
            catch
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-6).ToDate();
                dtpTillDate.Value = DateTime.Now.ToDate();

            }


            if (AppVars.objPolicyConfiguration.DaysForAccJob.ToBool() == true)
            {
                ddlAccountBookingDays.Items[0].Selected = true;
                ddlAccountBookingDays.Text = "0";
            }


           

          //  ComboFunctions.FillSubCompanyCombo(ddlSubCompany);

            ddlSubCompany.Visible = true;
            foreach (var item in General.GetQueryable<Gen_SubCompany>(null).Select(args => new { args.BackgroundColor, args.CompanyName, args.Id }).ToList())
            {
                ddlSubCompany.Items.Add(new RadCustomListDataItem { Text = item.CompanyName, Value = item.Id, Tag = item.Id });
            }

            if (ddlSubCompany.Items.Count == 1)
            {
               
                ddlSubCompany.SelectedIndex = 0;
                ddlSubCompany.Enabled = false;

            }
            else
            {
                ddlSubCompany.Items.Insert(0, new RadCustomListDataItem { Text = "All", Value = 0, Font = new Font("Tahoma", 10, FontStyle.Bold), ForeColor = Color.Black });
                ddlSubCompany.SelectedValue = AppVars.objSubCompany.Id;
                //  ddlSubCompany.DropDownStyle = RadDropDownStyle.DropDownList;
                ddlSubCompany.SelectedIndexChanged += DdlSubCompany_SelectedIndexChanged;
            }


            chkCarryForwardBalance.Visible = AppVars.listUserRights.Count(c => c.functionId == "DISABLE C/F OLD BALANCE") > 0;

            GetDrivers();
        }

        private void DdlSubCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RefreshCommissionView(ddlSubCompany.SelectedValue.ToInt());
        }

        public void GetDrivers()
        {
            try
            {
                objMaster = new DriverCommisionBO();
                //DateTime OneMonthBefore = DateTime.Now;
                //OneMonthBefore = OneMonthBefore.A(-1);




                GridViewCheckBoxColumn col = new GridViewCheckBoxColumn();
                col.Width = 40;
                col.AutoSizeMode = BestFitColumnMode.None;
                col.HeaderText = "";
                col.Name = "Check";
                grdDriverCommission.Columns.Add(col);


                GridViewTextBoxColumn tbcol = new GridViewTextBoxColumn();
                tbcol.Name = COLS.Id;
                tbcol.IsVisible = false;
                grdDriverCommission.Columns.Add(tbcol);


                tbcol = new GridViewTextBoxColumn();
                tbcol.Name = COLS.CommissionId;
                tbcol.IsVisible = false;
                grdDriverCommission.Columns.Add(tbcol);


                tbcol = new GridViewTextBoxColumn();
                tbcol.Name = COLS.SubCompanyId;
                tbcol.IsVisible = false;
                grdDriverCommission.Columns.Add(tbcol);

                tbcol = new GridViewTextBoxColumn();
                tbcol.Name = COLS.DriverNo;
                tbcol.HeaderText = "Driver";
                tbcol.Width = 160;
                tbcol.ReadOnly = true;
                grdDriverCommission.Columns.Add(tbcol);


                tbcol = new GridViewTextBoxColumn();
                tbcol.Name = COLS.DriverEmail;
                tbcol.IsVisible = false;
                grdDriverCommission.Columns.Add(tbcol);


                col = new GridViewCheckBoxColumn();
                col.Width = 60;
                col.AutoSizeMode = BestFitColumnMode.None;
                col.HeaderText = "Holiday";
                col.Name = COLS.Hokiday;
                grdDriverCommission.Columns.Add(col);



                GridViewTextBoxColumn tbcolX = new GridViewTextBoxColumn();
                tbcolX.Name = "Bookings";
                tbcolX.HeaderText = "Bookings";
                tbcolX.Width = 100;
                tbcolX.ReadOnly = true;
                grdDriverCommission.Columns.Add(tbcolX);

                GridViewDecimalColumn dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.DriverCommission;
                dcol.Width = 70;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Comm";//ission";
                dcol.FormatString = "{0:f2}";
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.DriverPDARent;
                dcol.Width = 70;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "PDA Rent";//ission";
                grdDriverCommission.Columns.Add(dcol);

               




                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.TotalPDARent;
                dcol.HeaderText = "Total PDA Rent";
                dcol.Width = 110;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.CollectionAndDelivery;
                dcol.Width = 120;
                dcol.ReadOnly = true;
                dcol.IsVisible = false;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Collection & Delivery";//ission";
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.TotalCollectionAndDelivery;
                dcol.Width = 120;
                dcol.ReadOnly = true;
                dcol.IsVisible = false;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Total Collection & Delivery";//ission";
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.BookingFees;
                dcol.HeaderText = "Booking Fees";
                dcol.Width = 110;
                dcol.ReadOnly = true;
                dcol.IsVisible = false;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.OldBalance;
                dcol.Width = 100;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Old Balance";
                dcol.ReadOnly = true;
                grdDriverCommission.Columns.Add(dcol);

                //tbcol = new GridViewTextBoxColumn();
                //GridViewDecimalColumn 

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.InitialBalance;
                dcol.HeaderText = "Initial Balance";
                dcol.DecimalPlaces = 2;
                dcol.IsVisible = false;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.DriverCommissionPerBooking;
                // dcol.HeaderText = "Initial Balance";
                dcol.DecimalPlaces = 2;
                dcol.IsVisible = false;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.PaidPromotion;
                dcol.Width = 120;
                dcol.ReadOnly = true;
                dcol.IsVisible = true;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Paid Promotion";
                grdDriverCommission.Columns.Add(dcol);



                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.Promotion;
                dcol.Width = 120;
                dcol.ReadOnly = true;
                dcol.IsVisible = true;
                dcol.DecimalPlaces = 2;
                dcol.HeaderText = "Promotion";
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.AccountsTotal;
                dcol.HeaderText = "A/C Total";
                dcol.Width = 90;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.CashTotal;
                dcol.HeaderText = "Cash Total";
                dcol.Width = 90;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.JobsTotal;
                dcol.HeaderText = "Jobs Total";
                dcol.Width = 90;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.AgentFees;
                dcol.HeaderText = "Agent Fees";
                dcol.Width = 90;
                dcol.ReadOnly = true;
                dcol.IsVisible = false;
                dcol.DecimalPlaces = 2;

                grdDriverCommission.Columns.Add(dcol);
                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.AccountExpense;
                dcol.HeaderText = "Account Expense";
                dcol.Width = 120;
                dcol.ReadOnly = true;
                dcol.IsVisible = false;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.CommissionPay;
                dcol.HeaderText = "Comm: Pay";
                dcol.Width = 90;
                dcol.DecimalPlaces = 2;
                dcol.IsVisible = false;
                dcol.ReadOnly = false;
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.Owed;
                dcol.HeaderText = "Owed";
                dcol.Width = 90;
                dcol.ReadOnly = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);



                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.CurrBalance;
                dcol.HeaderText = "Balance";
                dcol.Width = 110;
                dcol.DecimalPlaces = 2;
                dcol.ReadOnly = true;
                grdDriverCommission.Columns.Add(dcol);


                dcol = new GridViewDecimalColumn();
                dcol.Name = COLS.VAT;
                dcol.HeaderText = "VAT";
                dcol.Width = 80;
                dcol.ReadOnly = true;
                dcol.IsVisible = true;
                dcol.DecimalPlaces = 2;
                grdDriverCommission.Columns.Add(dcol);

                grdDriverCommission.ShowRowHeaderColumn = false;


                objCondition.CellForeColor = Color.Red;
                objCondition.TValue1 = "0";
                objCondition.ConditionType = ConditionTypes.Equal;
                grdDriverCommission.Columns[COLS.CurrBalance].ConditionalFormattingObjectList.Add(objCondition);

                objConditionGeneratedTrans.RowBackColor = Color.LightGreen;
                objConditionGeneratedTrans.TValue1 = "0";
                objConditionGeneratedTrans.ApplyToRow = true;
                objConditionGeneratedTrans.ConditionType = ConditionTypes.Greater;
                grdDriverCommission.Columns[COLS.CommissionId].ConditionalFormattingObjectList.Add(objConditionGeneratedTrans);


                RefreshCommissionView(ddlSubCompany.SelectedValue.ToInt());

                grdDriverCommission.EnableSorting = false;
                grdDriverCommission.CellValueChanged += new GridViewCellEventHandler(grdDriverCommission_CellValueChanged);
                grdDriverCommission.AllowDeleteRow = false;
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }

        }

        void grdDriverCommission_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column is GridViewCheckBoxColumn && e.Column.Name == COLS.Hokiday)
            {
                if (e.Value.ToBool())
                {
                    e.Row.Cells[COLS.DriverPDARent].Tag = e.Row.Cells[COLS.DriverPDARent].Value;
                    e.Row.Cells[COLS.DriverPDARent].Value = 0.00m;

                    e.Row.Cells[COLS.TotalPDARent].Tag = e.Row.Cells[COLS.TotalPDARent].Value;
                    e.Row.Cells[COLS.TotalPDARent].Value = 0.00m;

                    e.Row.Cells[COLS.CollectionAndDelivery].Tag = e.Row.Cells[COLS.CollectionAndDelivery].Value;
                    e.Row.Cells[COLS.CollectionAndDelivery].Value = 0.00m;

                    e.Row.Cells[COLS.TotalCollectionAndDelivery].Tag = e.Row.Cells[COLS.TotalCollectionAndDelivery].Value;
                    e.Row.Cells[COLS.TotalCollectionAndDelivery].Value = 0.00m;
                }
                else
                {
                    e.Row.Cells[COLS.DriverPDARent].Value = e.Row.Cells[COLS.DriverPDARent].Tag.ToDecimal();
                    e.Row.Cells[COLS.TotalPDARent].Value = e.Row.Cells[COLS.TotalPDARent].Tag.ToDecimal();

                    e.Row.Cells[COLS.CollectionAndDelivery].Value = e.Row.Cells[COLS.CollectionAndDelivery].Tag.ToDecimal();
                    e.Row.Cells[COLS.TotalCollectionAndDelivery].Value = e.Row.Cells[COLS.TotalCollectionAndDelivery].Tag.ToDecimal();


                }

            }

        }


        private void RefreshCommissionView(int subCompanyId)
        {
            try
            {

                DateTime? dtFrom = dtpFromDate.Value.ToDate();
                DateTime? dtTill = dtpTillDate.Value.ToDateTimeorNull();


                using (TaxiDataContext db = new TaxiDataContext())
                {
                     var list = db.stp_AddAllDriverCommission(dtFrom, dtTill).Where(c=>( subCompanyId==0 || c.SubcompanyId== subCompanyId)).OrderBy(item => item.Driver, new NaturalSortComparer<string>()).ToList();
                    //List<clsstp_AddAllDriverCommissionResult> list = db.ExecuteQuery<clsstp_AddAllDriverCommissionResult>("exec stp_AddAllDriverCommission {0},{1}",dtFrom, dtTill)
                    //    .Where(c => (subCompanyId == 0 || c.SubcompanyId == subCompanyId)).ToList();


                    int cnt = list.Count;
                    grdDriverCommission.RowCount = cnt;

                    for (int i = 0; i < cnt; i++)
                    {


                        grdDriverCommission.Rows[i].Cells["Check"].Value = true;
                        grdDriverCommission.Rows[i].Cells[COLS.Id].Value = list[i].Id;
                        grdDriverCommission.Rows[i].Cells[COLS.SubCompanyId].Value = list[i].SubcompanyId;
                        grdDriverCommission.Rows[i].Cells[COLS.DriverNo].Value = list[i].Driver;
                        grdDriverCommission.Rows[i].Cells[COLS.DriverEmail].Value = list[i].Email;
                        

                        // ADD PDA RENT
                        grdDriverCommission.Rows[i].Cells[COLS.DriverPDARent].Value = list[i].PDARent.ToDecimal();
                        grdDriverCommission.Rows[i].Cells[COLS.CollectionAndDelivery].Value = list[i].CollectionCharges.ToDecimal();
                        grdDriverCommission.Rows[i].Cells[COLS.VAT].Value = list[i].VAT.ToDecimal();

                        if (list[i].CommissionId == 0)
                        {
                            grdDriverCommission.Rows[i].Cells[COLS.OldBalance].Value = list[i].InitialBalance;
                        }
                        else
                        {
                            grdDriverCommission.Rows[i].Cells[COLS.OldBalance].Value = list[i].OldBalance;

                            if (chkCarryForwardBalance.Visible == true && chkCarryForwardBalance.Checked == false)
                            {

                                grdDriverCommission.Rows[i].Cells[COLS.OldBalance].Value = 0.00m;
                            }
                        }
                        grdDriverCommission.Rows[i].Cells[COLS.InitialBalance].Value = list[i].InitialBalance;
                        grdDriverCommission.Rows[i].Cells[COLS.DriverCommissionPerBooking].Value = list[i].DriverCommissionPerBooking;
                        grdDriverCommission.Rows[i].Cells[COLS.CashTotal].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.JobsTotal].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.AgentFees].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.CommissionId].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.CommissionPay].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.AccountExpense].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.Owed].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.CurrBalance].Value = (list[i].PDARent.ToDecimal() + grdDriverCommission.Rows[i].Cells[COLS.OldBalance].Value.ToDecimal());
                        grdDriverCommission.Rows[i].Cells[COLS.DriverCommission].Value = null;
                        grdDriverCommission.Rows[i].Cells[COLS.AccountsTotal].Value = null;


                   
                    }
                }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            SetFilters();
            cnt = 0;
            worker_Commission.RunWorkerAsync("Generate");
            Progessbar.Visible = true;
            DisableControl();
            
        }

        private void SetFilters()
        {

            fromDate = dtpFromDate.Value.ToDate();
            tillDate = dtpTillDate.Value.ToDate();

            selectedRows = grdDriverCommission.Rows.Where(c => c.Cells["Check"].Value.ToBool()).ToList();
            grdDriverCommission.ReadOnly = true;
        }

        List<GridViewRowInfo> selectedRows = null;

        bool IsSavedTrans = false;

        DateTime? fromDate = null;
        DateTime? tillDate = null;

        private void Generate()
        {
            try
            {
               

                var count = 100 /selectedRows.Count;
               

                
                var listofDrivers = (from a in General.GetQueryable<Fleet_Driver>(c => c.DriverTypeId == 2)
                                     select new
                                     {
                                         a.Id,
                                         a.MaxCommission,
                                         a.SubcompanyId,
                                         a.NICNo,
                                         a.IsPrimeCompanyDriver,
                                         a.PrimeCompanyRent
                                     }).ToList();



              
               
                long transId = 0;
                decimal accJobsTotal = 0;
                decimal rentDue = 0;
                decimal currBalance = 0;
                decimal MaxCommission = 0, MinCommission=0;





                // test

                //Expression<Func<Booking, bool>> _condition = null;

                List<int> listofDriversToGenerate= selectedRows.Select(c => c.Cells["Id"].Value.ToInt()).ToList<int>();

              
                string drivers=  string.Join(",", listofDriversToGenerate);
                List<stp_getDriverListForGeneratingCommResult> driverCommissionList = null;
                List<long?> BookingIds = null;
                tillDate = tillDate.ToDate();
                tillDate = tillDate + new TimeSpan(23, 59, 59);
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    driverCommissionList= db.ExecuteQuery<stp_getDriverListForGeneratingCommResult>("exec stp_getDriverListForGeneratingComm {0},{1},{2},{3}"
                        , drivers, fromDate, tillDate, AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt()).ToList();

                    BookingIds = db.Fleet_DriverCommision_Charges.Where(c=> c.BookingId != null && c.TransId != 0).Select(c=>c.BookingId).ToList();
                    
                }
                tillDate = tillDate.ToDate();

                ////

           
                ClsRowState rowState = new ClsRowState();
                int selectedDriverId = 0;
                foreach (var row in selectedRows)
                {

                    

                    transId = 0;
                    accJobsTotal = 0;
                    rentDue = 0;
                    currBalance = 0.00m;
                    selectedDriverId = row.Cells["Id"].Value.ToInt();
                    // was live
                    //  transId = objCommissionList.FirstOrDefault(c => c.DriverId == row.Cells["Id"].Value.ToInt()).DefaultIfEmpty().Id;


                    //MaxCommission
                    MaxCommission = listofDrivers.Where(c => c.Id == selectedDriverId).FirstOrDefault().MaxCommission.ToDecimal();
                    //

                    var minCom = listofDrivers.Where(c => c.Id == selectedDriverId).FirstOrDefault().NICNo.ToStr();




                    if (minCom.ToStr().Trim().IsNumeric())
                        MinCommission = minCom.ToDecimal();
                    else
                        MinCommission = 0;

                    bool differentcommforaccbooking = listofDrivers.Where(c => c.Id == selectedDriverId).FirstOrDefault().IsPrimeCompanyDriver.ToBool();


                    decimal acccommperbooking = listofDrivers.Where(c => c.Id == selectedDriverId).FirstOrDefault().PrimeCompanyRent.ToDecimal();


                    if (OnSave(selectedDriverId, row.Cells[COLS.OldBalance].Value.ToDecimal(), row.Cells[COLS.DriverCommissionPerBooking].Value.ToDecimal()
                        , row.Cells[COLS.DriverPDARent].Value.ToDecimal(), row.Cells["InitialBalance"].Value.ToDecimal(), row.Cells[COLS.CommissionPay].Value.ToDecimal()
                        , ref accJobsTotal, ref transId, ref rentDue, ref currBalance, row.Cells[COLS.Hokiday].Value.ToBool()
                        , ref MaxCommission,ref MinCommission, row.Cells[COLS.VAT].Value.ToDecimal(), BookingIds, driverCommissionList,fromDate,tillDate, differentcommforaccbooking, acccommperbooking))
                    {

                        IsSavedTrans = true;

                        if (rowState == null)
                            rowState = new ClsRowState();

                        rowState.row = row;
                        rowState.transId=transId;
                        rowState.accJobsTotal = accJobsTotal;
                        rowState.rentDue = rentDue;
                        rowState.currBlance = currBalance;
                        try
                        {
                            rowState.subCompanyId = listofDrivers.Where(c => c.Id == selectedDriverId).FirstOrDefault().SubcompanyId.ToInt();
                        }
                        catch
                        {
                            rowState.subCompanyId = 1;
                        }

                      
                    }
                    else
                        rowState = null;

                    int Cal = percentage += count;
                    
                    worker_Commission.ReportProgress(Cal,rowState);
                }
               





            }
            catch (Exception ex)
            {



            }

        }

        public class ClsRowState
        {
            public GridViewRowInfo row;
            public int subCompanyId;
            public decimal currBlance;
            public long transId;
            public decimal accJobsTotal;
            public decimal rentDue;

        }



        private void UpdateLayout(GridViewRowInfo row,int subCompanyId,decimal currBlance,long transId,decimal accJobsTotal, decimal rentDue)
        {

        }



        private void cbAllCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllDrivers.Checked == true)
            {
                if (grdDriverCommission.Rows.Count > 0)
                {
                    for (int i = 0; i < grdDriverCommission.Rows.Count; i++)
                    {
                        grdDriverCommission.Rows[i].Cells["Check"].Value = true;//..CurrentCell.Value;
                    }
                }
            }
            else if (cbAllDrivers.Checked == false)
            {
                if (grdDriverCommission.Rows.Count > 0)
                {
                    for (int i = 0; i < grdDriverCommission.Rows.Count; i++)
                    {
                        grdDriverCommission.Rows[i].Cells["Check"].Value = false;//..CurrentCell.Value;

                    }
                }
            }
        }


        List<Fleet_Driver_DebitCreditNote> listofDrvDebitCreditNotes = null;

        private bool OnSave(int DriverId, decimal oldBalance, decimal DriverCommissionPerBooking, decimal pdaCommission
            , decimal InitialBalance, decimal CommissionPayValue, ref decimal accJobs, ref long transId
            , ref decimal rentDue, ref decimal currBalance, bool IsHoliday, ref decimal MaxCommission,ref decimal minCommission, decimal VAT
            ,List<long?> bookingIds, List<stp_getDriverListForGeneratingCommResult> driverCommissionList,DateTime? fromDate,DateTime? tillDate,bool differentcommonaccbookings, decimal DriverCommissionPerAccBooking)
        {

            bool IsSaved = false;


            try
            {

               

               
                

                long savedTransId = transId;

                
                objMaster = new DriverCommisionBO();

                if (transId == 0)
                {

                    objMaster.New();

                }
                else
                {
                    objMaster.GetByPrimaryKey(transId);

                    if (objMaster.Current == null)
                        objMaster.New();

                }


                List<Fleet_DriverCommision_Charge> ListDetail = null;


               


                var list2 = (from a in driverCommissionList
                             join b in bookingIds on a.Id equals b into table2
                             from b in table2.DefaultIfEmpty()

                             where ( b == null) && a.Driverid==DriverId
                             select new
                             {
                                a.Id,
                                 a.TotalFare,
                                 a.CompanyId ,
                                 a.AccountTypeId ,

                                 a.DriverCommissionAmount ,
                                 a.DriverCommissionType ,
                                 a.IsCommissionWise ,
                                 a.AgentCommission,
                                 a.DropOffCharge,
                                 a.PickupCharge,
                                  a.Parking,
                                  a.BookingFee,
                                 a.ExtraDropCharges,
                                a.PickupPlot,
                                 a.DropOffPlot,
                                 a.PaymentTypeId,
                                 a.Waiting,
                                 a.FareRate,
                                a.Promotion,
                               
                             }).ToList();



                if(chkOperatedDrivers.Checked)
                {
                    if(list2.Count==0)
                    {

                        IsSaved = false;
                        transId = 0;
                        return IsSaved;
                    }

                }


                ListDetail = (from a in list2
                                                                 select new Fleet_DriverCommision_Charge
                                                      {
                                                          //Id = a.Id,
                                                          TransId = objMaster.Current.Id,
                                                          BookingId = a.Id,
                                                          CommissionPerBooking = (a.TotalFare * DriverCommissionPerBooking) / 100
                                                          //CommissionPerBooking=a.DriverCommissionAmount
                                                      }).ToList();

                string[] skipProperties = { "Fleet_DriverCommision", "Booking" };
                IList<Fleet_DriverCommision_Charge> savedList = objMaster.Current.Fleet_DriverCommision_Charges;

                Utils.General.SyncChildCollection(ref savedList, ref ListDetail, "Id", skipProperties);


                decimal Total = list2.Sum(c => c.TotalFare).ToDecimal();
                decimal ACCJobsTotal = list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH)
                                       .Sum(c => c.TotalFare).ToDecimal();


                decimal parkingTotal = list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH)
                                                             .Sum(c => c.Parking.ToDecimal());

                if (AppVars.listUserRights.Count(c => c.functionId == "DEBIT CONGESTION") > 0)
                {
                    parkingTotal = list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH
                          && (
                           c.PickupPlot.ToStr().ToUpper().Contains("CONGESTION")==false
                                            && c.DropOffPlot.ToStr().ToUpper().ToStr().Contains("CONGESTION")==false

                             )

                                                          ).Sum(c => c.Parking.ToDecimal());
                                                           
                }


                decimal promotionTotal = list2.Where(c => c.Promotion!=null && c.Promotion>0)
                                                          .Sum(c => c.Promotion.ToDecimal());


                decimal subtractPromotionTotal = -(list2.Where(c => c.Promotion != null && c.Promotion < 0)
                                                        .Sum(c => c.Promotion.ToDecimal()));

                double totalWeeks = (dtpTillDate.Value.ToDate().Subtract(dtpFromDate.Value.ToDate()).TotalDays) / 7;

                if (totalWeeks < 1)
                    totalWeeks = 1;




                decimal TotalPDARent = (pdaCommission * totalWeeks.ToInt());

                decimal AgentCommission = list2.Where(c => c.AccountTypeId == Enums.ACCOUNT_TYPE.CASH).Sum(c => c.AgentCommission).ToDecimal();

                // bookingfee
                //if (AppVars.objPolicyConfiguration.PickCommissionDeductionFromJobsTotal.ToBool())
                //{

                    AgentCommission = AgentCommission + list2.Where(c => c.AccountTypeId == Enums.ACCOUNT_TYPE.CASH).Sum(c => c.BookingFee).ToDecimal();
                //   }
                //
               // Total = Total;


                decimal DriverCommissionTotal = 0;

                decimal accountsBookingFeeTotal= list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH).Sum(c => c.BookingFee).ToDecimal();

                // if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 1)
                // {
                //     DriverCommissionTotal = ((Total - AgentCommission) * DriverCommissionPerBooking / 100);
                // }
                //else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 4)
                // {
                //     DriverCommissionTotal = (Total * DriverCommissionPerBooking / 100);
                // }
                // else if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 7)
                // {
                //     DriverCommissionTotal = (Total * DriverCommissionPerBooking / 100);


                // }
                // else
                // {



                if (AppVars.objPolicyConfiguration.NoCommissionFromAccount.ToBool())
                {

                    decimal CashTotal = list2.Where(c => c.PaymentTypeId != Enums.PAYMENT_TYPES.BANK_ACCOUNT).Sum(c => c.TotalFare).ToDecimal();
                    decimal AccTotal = 0;
                    DriverCommissionTotal = ((CashTotal+ AccTotal) * DriverCommissionPerBooking / 100);


                }
                else if(differentcommonaccbookings)
                {

                    decimal CashTotal = list2.Where(c => c.PaymentTypeId == Enums.PAYMENT_TYPES.CASH).Sum(c => c.TotalFare).ToDecimal();
                  
                    DriverCommissionTotal = (CashTotal  * DriverCommissionPerBooking / 100) + ((list2.Where(c => c.PaymentTypeId!= Enums.PAYMENT_TYPES.CASH).Sum(c => c.TotalFare).ToDecimal())* DriverCommissionPerAccBooking)/100;


                }
                else
                {
                    DriverCommissionTotal = ((Total-subtractPromotionTotal) * DriverCommissionPerBooking / 100);

                    if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 13) // fare+extradrop
                    {
                        Total = list2.Sum(c => c.FareRate.ToDecimal()+c.ExtraDropCharges.ToDecimal()).ToDecimal();
                        DriverCommissionTotal = ((Total - subtractPromotionTotal) * DriverCommissionPerBooking / 100);

                    }
                    else   if (AppVars.objPolicyConfiguration.DrvCommissionCalculationType.ToInt() == 14) // fare+waiting
                    {
                        Total = list2.Sum(c => c.FareRate.ToDecimal() + c.Waiting.ToDecimal()).ToDecimal();
                        DriverCommissionTotal = ((Total - subtractPromotionTotal) * DriverCommissionPerBooking / 100);

                    }


                }
                //    }

                // MaxCommission

                if (MaxCommission > 0 && DriverCommissionTotal > MaxCommission)
                {
                    DriverCommissionTotal = MaxCommission;
                }



                if (minCommission > 0 && DriverCommissionTotal < minCommission && list2.Count>0)
                {
                    DriverCommissionTotal = minCommission;
                }

                if (VAT.ToDecimal()>0)
                {
                    DriverCommissionTotal= DriverCommissionTotal+   Math.Round(((DriverCommissionTotal*VAT.ToDecimal())/100),2);

                }

                //


            


                objMaster.Current.CollectionDeliveryCharges = promotionTotal;

                objMaster.Current.MaxCommission = MaxCommission;

                objMaster.Current.Adjustments = 0.00m;

                //objMaster.Current.Adjustments = list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH)
                //                                    .Sum(c => c.ExtraDropCharges.ToDecimal());




                decimal owed = 0.00m;
                decimal AccountExpenses = 0.00m;

                decimal totalCredit = 0.00m;
                decimal totalDebit = 0.00m;



                decimal Debit = 0.00m;
                decimal Credit = 0.00m;

                if (savedTransId > 0 && objMaster.Current.Fleet_DriverCommissionExpenses.Count > 0)
                {
                    Debit = objMaster.Current.Fleet_DriverCommissionExpenses.Where(c => c.Debit.ToDecimal() > 0).Select(c => c.Debit).Sum().ToDecimal();
                    Credit = objMaster.Current.Fleet_DriverCommissionExpenses.Where(c => c.Credit.ToDecimal() > 0).Select(c => c.Credit).Sum().ToDecimal();
                }
                else

                {

                    if (AppVars.listUserRights.Count(c => c.functionId == "DEBIT CONGESTION") > 0)
                    {
                        decimal congestion = list2
                            //.Where(c => c.AccountTypeId == Enums.ACCOUNT_TYPE.CASH)
                            .Where(c => c.PickupPlot.ToStr().ToUpper().Contains("CONGESTION")
                                            || c.DropOffPlot.ToStr().ToUpper().ToStr().Contains("CONGESTION"))
                                                             .Sum(c => c.Parking.ToDecimal());
                        if (congestion > 0)
                        {
                            objMaster.Current.Fleet_DriverCommissionExpenses.Add(new Fleet_DriverCommissionExpense
                            {
                                Description = "CONGESTION",
                                Debit = congestion,

                            });
                            Debit = congestion;
                        }

                    }

                }

                totalDebit = (DriverCommissionTotal + TotalPDARent + AgentCommission  + Debit);
                totalCredit = (ACCJobsTotal + parkingTotal + AccountExpenses + objMaster.Current.Adjustments.ToDecimal()+ promotionTotal+ Credit);
                owed = (totalDebit - totalCredit);
                objMaster.Current.DriverOwed = owed;

                totalDebit += oldBalance;
                //totalCredit = (DriverCommissionTotal  + AccountExpenses + Credit);
                //totalDebit = (ACCJobsTotal + Debit);

                objMaster.Current.Balance = (totalDebit - totalCredit);

                objMaster.Current.AccountExpenses = AccountExpenses;
                objMaster.Current.OldAgentCommission = accountsBookingFeeTotal;

                objMaster.Current.AccJobsTotal = ACCJobsTotal;

                objMaster.Current.CommissionTotal = DriverCommissionTotal;
                objMaster.Current.JobsTotal = Total;
                objMaster.Current.AgentFeesTotal = AgentCommission;

                objMaster.Current.CommisionPay = CommissionPayValue.ToDecimal();
                objMaster.Current.VAT = VAT.ToDecimal();

                objMaster.Current.DriverCommision = DriverCommissionPerBooking;

                // add pda rent
                objMaster.Current.Extra = pdaCommission;

                objMaster.Current.PDARent = TotalPDARent;

                objMaster.Current.AddBy = AppVars.LoginObj.LuserId.ToInt();
                objMaster.Current.AddLog = AppVars.LoginObj.LoginName.ToStr();
                objMaster.Current.AddOn = DateTime.Now;
                objMaster.Current.TransDate = DateTime.Now; //dtpTransactionDate.Value.ToDateTime();
                objMaster.Current.DriverId = DriverId;//ddlDriver.SelectedValue.ToIntorNull();
                objMaster.Current.OldBalance = oldBalance;// (CurrentBalance - RentPay);
                objMaster.Current.FromDate = fromDate;
                objMaster.Current.ToDate = tillDate;
                objMaster.Current.TransFor = "Weekly";//ddlDayWise.SelectedText.ToStr();


                objMaster.Current.AccountBookingDays = ddlAccountBookingDays.Text.ToInt();
                objMaster.Current.TotalWeeks = totalWeeks.ToInt();

                // objMaster.Current.Fuel = 0;//Fuel.ToDecimal();
                //   objMaster.Current.Extra = 0;// Extra.ToDecimal();



                //  decimal parkingTotal = list2.Sum(c => c.Parking.ToDecimal()).ToDecimal();
                objMaster.Current.Fuel = parkingTotal;

             

                if (IsHoliday)
                {
                    objMaster.Current.Extra = 0.00m;
                    objMaster.Current.PDARent = 0.00m;
                    objMaster.Current.CollectionDeliveryCharges = 0.00m;


                }

                objMaster.Current.WeekOff = IsHoliday;

                objMaster.DisableCheckTotalBookings = true;

       
                objMaster.Current.TransactionType = Enums.TRANSACTIONTYPE.DRIVER_COMMISSION_EXPENSE5;


                objMaster.Save();

             
                currBalance = objMaster.Current.Balance.ToDecimal();
                IsSaved = true;
                transId = objMaster.Current.Id;

                //   }
            }
            catch (Exception ex)
            {
                //if (objMaster.Errors.Count > 0)
                //    ENUtils.ShowMessage(objMaster.ShowErrors());
                //else
                //{
                //    ENUtils.ShowMessage(ex.Message);

                //}
            }

            return IsSaved;

        }

        private void btnExits_Click_1(object sender, EventArgs e)
        {
            this.Close();
            //this.Hide();

        }
        public void ShowDriverCommission(int Id)
        {
            frmDriverCommissionDebitCredit5 frm = new frmDriverCommissionDebitCredit5();

            frm.OnDisplayRecord(Id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmDriverCommissionDebitCredit51");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);
        }

        //public  void ShowCompanyInvoiceForm(int id)
        //{


        //    frmDriverRent frm = new frmDriverRent(id);
        //    frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    frm.MaximizeBox = false;
        //    frm.MinimizeBox = false;
        //    frm.ControlBox = true;
        //    //frm.OnDisplayRecord(id);
        //    frm.ShowDialog();
        //    frm.Dispose();
        //}

        private void grdCompany_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (grdDriverCommission.CurrentRow != null && grdDriverCommission.CurrentRow is GridViewDataRowInfo)
            {
                int CommissionId = grdDriverCommission.CurrentRow.Cells[COLS.CommissionId].Value.ToInt();
                if (CommissionId > 0)
                {
                    ShowDriverCommission(CommissionId);
                    //  ShowCompanyInvoiceForm(id);  
                }

            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
            }
        }

        private void btnEmailInvoices_Click(object sender, EventArgs e)
        {


            EmailInvoices();

        }


        private void EmailInvoices()
        {
            //try
            //{
            //    string subject = txtSubject.Text.Trim();

            //    if (string.IsNullOrEmpty(subject))
            //    {
            //        ENUtils.ShowMessage("Required : Email Subject");
            //        return;
            //    }

            //    var rows = grdDriverCommission.Rows.Where(c => c.Cells[COLS.CommissionId].Value.ToLong() > 0).ToList();



            //    List<long> invoiceIds = rows.Select(c => c.Cells[COLS.CommissionId].Value.ToLong()).ToList<long>();

            //    if (invoiceIds.Count > 0)
            //    {

            //        frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);
            //        frm.reportViewer1.Tag = "invoice";
            //        var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => invoiceIds.Contains(a.Id)).ToList();
            //        var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(a => invoiceIds.Contains(a.Id)).ToList();


            //        List<Fleet_Driver> driversList = General.GetGeneralList<Fleet_Driver>(c => c.DriverTypeId == 2);

            //        frmEmail frmEmail = new frmEmail(null, "", "");

            //        bool issuccess = true;
            //        foreach (var item in rows.Where(c => c.Cells["Check"].Value.ToBool()))
            //        {
            //            frm.DataSource = list.Where(c => c.Id == item.Cells[COLS.CommissionId].Value.ToLong()).OrderBy(c => c.PickupDate).ToList();
            //            frm.DataSource2 = list2.Where(c => c.CommissionId == item.Cells[COLS.CommissionId].Value.ToLong()).OrderBy(c => c.Date).ToList();
            //            frm.VAT = item.Cells[COLS.VAT].Value.ToDecimal();
            //            frm.GenerateReport();

            //            //string email = driversList.FirstOrDefault(c => c.Id == item.Cells[COLS.Id].Value.ToInt()).DefaultIfEmpty().Email.ToStr().Trim();
            //            string email = item.Cells[COLS.DriverEmail].Value.ToStr();


            //            if (!string.IsNullOrEmpty(email))
            //            {


            //                if (issuccess == true)
            //                {
            //                    issuccess = frm.SendEmailInternally(frmEmail, subject, item.Cells[COLS.DriverNo].Value.ToStr().Trim(), email);
            //                }
            //             }
            //        }


            //        if (frmEmail != null && frmEmail.IsDisposed == false)
            //        {
            //            frmEmail.Close();
            //            GC.Collect();

            //        }



            //        ENUtils.ShowMessage("Email has been sent successfully");

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ENUtils.ShowMessage(ex.Message);

            //}





        }

        private void DisableControl()
        {
            dtpFromDate.Enabled = false;
            dtpTillDate.Enabled = false;
            btnGenerate.Enabled = false;
            btnDisplayCommission.Enabled = false;
            btnGetBooking.Enabled = false;
            btnClear.Enabled = false;
            btnPrintAll.Enabled = false;
            btnSendEmail.Enabled = false;
            btnDeleteGenerated.Enabled = false;

        }

        private void btnDisplayRent_Click(object sender, EventArgs e)
        {
            SetFilters();
            cnt = 0;
            worker_Commission.RunWorkerAsync("Display Commission");
            Progessbar.Visible = true;
            DisableControl();

        }


        private void DisplayCommission(string args)
        {

            try
            {
                decimal CommissionDue = 0;
                int DriverId = 0;
                decimal DriverCommissionPerBooking = 0.00m;
                decimal pdaRent = 0.00m;
                decimal collectionCharges = 0.00m;
                decimal oldBalance = 0.00m;
                decimal AgentCommission = 0;
                decimal MaxCommission = 0,MinCommission=0;

                var count = 100 /selectedRows.Count;

                var listofDrivers = (from a in General.GetQueryable<Fleet_Driver>(c => c.DriverTypeId == 2 && c.IsActive==true)
                                     select new
                                     {
                                         a.Id,
                                         a.MaxCommission,
                                         a.NICNo
                                     }).ToList();

                List<int> listofDriversToGenerate = selectedRows.Select(c => c.Cells["Id"].Value.ToInt()).ToList<int>();


                string drivers = string.Join(",", listofDriversToGenerate);
                List<stp_getDriverListForGeneratingCommResult> driverCommissionList = null;
                List<long?> BookingIds = null;
                tillDate = tillDate.ToDate();
                tillDate = tillDate + new TimeSpan(23, 59, 59);
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    driverCommissionList = db.ExecuteQuery<stp_getDriverListForGeneratingCommResult>("exec stp_getDriverListForGeneratingComm {0},{1},{2},{3}"
                        , drivers, fromDate, tillDate, AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt()).ToList();

                    BookingIds = db.Fleet_DriverCommision_Charges.Where(c => c.BookingId != null && c.TransId != 0).Select(c => c.BookingId).ToList();

                }


                // var commissionList = General.GetGeneralList<Fleet_DriverCommision_Charge>(c => c.BookingId != null && c.TransId != 0);
                double totalWeeks = (tillDate.ToDate().Subtract(fromDate.ToDate()).TotalDays) / 7;
                if (totalWeeks < 0)
                    totalWeeks = 1;
                foreach (var row in selectedRows)
                {

                   
                   

                    DriverId = row.Cells["Id"].Value.ToInt();
                    DriverCommissionPerBooking = row.Cells[COLS.DriverCommissionPerBooking].Value.ToDecimal();

                    pdaRent = row.Cells[COLS.DriverPDARent].Value.ToDecimal();

                    collectionCharges = row.Cells[COLS.CollectionAndDelivery].Value.ToDecimal();


                    decimal TotalPDARent = (pdaRent * totalWeeks.ToInt());
                    decimal TotalCollectionCharges = (collectionCharges * totalWeeks.ToInt());



                    if (row.Cells[COLS.Hokiday].Value.ToBool())
                    {
                        pdaRent = 0.00m;
                        collectionCharges = 0.00m;
                        TotalPDARent = 0.00m;
                        TotalCollectionCharges = 0.00m;
                    }

                    oldBalance = row.Cells[COLS.OldBalance].Value.ToDecimal();


                    

                        MaxCommission = listofDrivers.Where(c => c.Id == DriverId).FirstOrDefault().MaxCommission.ToDecimal();

                    var minCom = listofDrivers.Where(c => c.Id == DriverId).FirstOrDefault().NICNo.ToStr();

                    if (minCom.ToStr().Trim().IsNumeric())
                        MinCommission = minCom.ToDecimal();
                    else
                        MinCommission = 0;

                    CommissionDue = 0;

                    try
                    {


                      

                        var list2 = (from a in driverCommissionList
                                     join b in BookingIds on a.Id equals b into table2
                                     from b in table2.DefaultIfEmpty()

                                     where (b == null) && a.Driverid == DriverId
                                     select new
                                     {
                                         a.Id,
                                         a.TotalFare,
                                         a.CompanyId,
                                         a.AccountTypeId,

                                         a.DriverCommissionAmount,
                                         a.DriverCommissionType,
                                         a.IsCommissionWise,
                                         a.AgentCommission,
                                         a.DropOffCharge,
                                         a.PickupCharge,
                                         a.Parking,
                                         a.BookingFee,
                                         a.ExtraDropCharges,
                                         a.PickupPlot,
                                         a.DropOffPlot,
                                         a.PaymentTypeId,
                                         a.Promotion
                                     }).ToList();


                        //var list2 = (from a in General.GetGeneralList<Booking>(c => c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED

                        //    && (c.FareRate != null)
                                   
                        //    && (c.DriverId == DriverId)
                        //                && (c.PickupDateTime.Value.Date >= dtpFromDate.Value.Value.Date && c.PickupDateTime.Value.Date <= dtpTillDate.Value.Value.Date))
                        //             join b in commissionList on a.Id equals b.BookingId into table2
                        //             from b in table2.DefaultIfEmpty()
                                   

                        //             where (b == null)
                        //             select new
                        //             {
                        //                 Id = a.Id,
                        //                 TotalFare = a.FareRate.ToDecimal(),
                        //                 //NC
                        //                 WaitingCharges = a.MeetAndGreetCharges.ToDecimal(),
                        //                 ParkingCharges = a.CongtionCharges.ToDecimal(),
                        //                 ExtraDropCharges = a.ExtraDropCharges.ToDecimal(),
                        //                 //

                        //                 CompanyId = a.CompanyId,
                        //                 AccountTypeId = (a.PaymentTypeId == Enums.PAYMENT_TYPES.CASH) ? Enums.ACCOUNT_TYPE.CASH : Enums.ACCOUNT_TYPE.ACCOUNT, //1,//a.Gen_Company.AccountTypeId,
                        //                 DriverCommissionAmount = a.DriverCommission,
                        //                 DriverCommissionType = a.DriverCommissionType,
                        //                 IsCommissionWise = a.IsCommissionWise,
                        //                 AgentCommission = a.AgentCommission,
                        //                 DropOffCharge =0,
                        //                 PickupCharge =  0,
                        //                 a.PaymentTypeId,
                        //                 Promotion=a.TipAmount
                        //             }).ToList();



                        oldBalance = row.Cells[COLS.OldBalance].Value.ToDecimal();

                      
                      
                        decimal ACCJobsTotal = list2.Where(c => c.AccountTypeId != Enums.ACCOUNT_TYPE.CASH).Sum(c => c.TotalFare).ToDecimal();


                        decimal parkingTotal = list2.Sum(c => c.Parking.ToDecimal()).ToDecimal();

                        decimal promotionTotal = list2.Where(c=>c.Promotion.ToDecimal()>0).Sum(c => c.Promotion.ToDecimal()).ToDecimal();

                        decimal subtractPromotionTotal =  -(list2.Where(c => c.Promotion.ToDecimal() < 0).Sum(c => c.Promotion.ToDecimal()).ToDecimal());

                        decimal CashJobsTotal = list2.Where(c => c.AccountTypeId == Enums.ACCOUNT_TYPE.CASH).Sum(c =>c.TotalFare).ToDecimal();

                      
                        decimal JobsTotal = (ACCJobsTotal + CashJobsTotal);


                        decimal AccountExpenses = 0.00m;



                        if (AppVars.objPolicyConfiguration.NoCommissionFromAccount.ToBool())
                        {

                            decimal CTotal = list2.Where(c => c.PaymentTypeId != Enums.PAYMENT_TYPES.BANK_ACCOUNT).Sum(c => c.TotalFare ).ToDecimal();
                            decimal AccTotal = 0;
                            DriverCommissionPerBooking = ((CTotal + AccTotal) * DriverCommissionPerBooking / 100);


                        }
                        else
                        {
                            DriverCommissionPerBooking = ((JobsTotal- subtractPromotionTotal) * row.Cells[COLS.DriverCommissionPerBooking].Value.ToDecimal() / 100);

                        }



                        // MaxCommission
                        if (MaxCommission > 0 && DriverCommissionPerBooking > MaxCommission)
                        {
                            DriverCommissionPerBooking = MaxCommission;
                        }
                        //


                        // MinCommission
                        if (MinCommission > 0 && DriverCommissionPerBooking < MinCommission)
                        {
                            DriverCommissionPerBooking = MinCommission;
                        }
                        //




                        decimal owed = ((AgentCommission + TotalPDARent + DriverCommissionPerBooking) - ACCJobsTotal);
                        decimal PDARent = row.Cells[COLS.DriverPDARent].Value.ToDecimal();

                        CommissionDue = owed;

                        decimal totalCredit = 0.00m;
                        decimal totalDebit = 0.00m;
                        int TotalJobs = list2.Count;
                        decimal BookingFees = 0.0m;

                     
                        totalDebit = owed;
                        totalCredit = (ACCJobsTotal + AccountExpenses + parkingTotal);
                        owed = (totalDebit - totalCredit);
                       

                        row.Cells[COLS.CurrBalance].Value = (owed + oldBalance);
                        row.Cells[COLS.Owed].Value = owed;
                        row.Cells[COLS.AccountExpense].Value = AccountExpenses;
                        row.Cells[COLS.TotalPDARent].Value = TotalPDARent;
                        row.Cells[COLS.TotalCollectionAndDelivery].Value = TotalCollectionCharges;

                        if (chkApplyBookingFees.Checked)
                        {
                            row.Cells[COLS.BookingFees].Value = (TotalJobs * BookingFees);
                        }


                        row.Cells[COLS.CashTotal].Value = CashJobsTotal;
                        row.Cells[COLS.JobsTotal].Value = (JobsTotal);
                        row.Cells[COLS.AccountsTotal].Value = ACCJobsTotal;
                        row.Cells[COLS.CommissionPay].Value = 0.00m;

                        row.Cells[COLS.CommissionId].Value = null;
                        row.Cells[COLS.AgentFees].Value = AgentCommission;
                        row.Cells[COLS.DriverCommission].Value = DriverCommissionPerBooking;

                        row.Cells[COLS.PaidPromotion].Value = promotionTotal;
                        row.Cells[COLS.Promotion].Value = subtractPromotionTotal;

                        if (list2!=null)
                        row.Cells["Bookings"].Value = list2.Count;
            
                    }
                    catch (Exception ex)
                    {
                        ENUtils.ShowMessage(ex.Message);

                    }



                    if (args.ToStr().Length == 0)
                    {
                        int Cal = percentage += count;

                        worker_Commission.ReportProgress(Cal);
                    }
                    

                    //
                }


            }
            catch (Exception ex)
            {



            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbAllDrivers.Checked = true;
            dtpFromDate.Enabled = true;
            dtpTillDate.Enabled = true;


            grdDriverCommission.Columns[COLS.CommissionPay].ReadOnly = false;

            RefreshCommissionView(ddlSubCompany.SelectedValue.ToInt());
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintDocument();
        }


        private void PrintDocument()
        {

            //try
            //{
            //    try
            //    {



            //        var rows = grdDriverCommission.Rows.Where(c => c.Cells[COLS.CommissionId].Value.ToLong() > 0).ToList();



            //        List<long> invoiceIds = rows.Select(c => c.Cells[COLS.CommissionId].Value.ToLong()).ToList<long>();

            //        if (invoiceIds.Count > 0)
            //        {

            //            frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);
            //            frm.CompanyHeader = ddlSubCompany.Text.Trim();

            //            var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => invoiceIds.Contains(a.Id)).ToList();
            //            var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(a => invoiceIds.Contains(a.Id)).ToList();


            //            List<Fleet_Driver> driversList = General.GetGeneralList<Fleet_Driver>(c => c.DriverTypeId == 2);
            //            frmEmail frmEmail = new frmEmail(null, "", "");


            //            foreach (var item in rows)
            //            {
            //                frm.DataSource = list.Where(c => c.Id == item.Cells[COLS.CommissionId].Value.ToLong()).OrderBy(c => c.PickupDate).ToList();
            //                frm.DataSource2 = list2.Where(c => c.CommissionId == item.Cells[COLS.CommissionId].Value.ToLong()).OrderBy(c => c.Date).ToList();
            //                frm.VAT = item.Cells[COLS.VAT].Value.ToDecimal();
            //                frm.GenerateReport();

            //                ReportPrintDocument rpt = new ReportPrintDocument(frm.reportViewer1.LocalReport);
            //                rpt.Print();
            //                rpt.Dispose();
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ENUtils.ShowMessage(ex.Message);

            //    }




            //}
            //catch (Exception ex)
            //{


            //}


        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewPrint_Click(object sender, EventArgs e)
        {

            try
            {


                var rows = grdDriverCommission.Rows.Where(c => c.Cells[COLS.CommissionId].Value.ToLong() > 0).ToList();

                var list = (from a in grdDriverCommission.Rows.Where(c => c.Cells[COLS.CommissionId].Value.ToInt() > 0)
                            select new
                            {
                                CommissionId = a.Cells[COLS.CommissionId].Value.ToInt(),
                                DriverId = a.Cells[COLS.Id].Value.ToInt(),
                                Driver = a.Cells[COLS.DriverNo].Value.ToStr(),
                                VAT = a.Cells[COLS.VAT].Value.ToDecimal(),
                                SubCompanyId=  a.Cells[COLS.SubCompanyId].Value.ToInt()
                            }).ToList();


                //  List<long> invoiceIds = rows.Select(c => c.Cells[COLS.CommissionId].Value.ToLong()).ToList<long>();

                if (list.Count > 0)
                {
                    frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(list, dtpFromDate.Value.ToDate(), dtpTillDate.Value.ToDate());
                    frm.ShowDialog();
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }






        }

        private void btnDeleteGenerated_Click(object sender, EventArgs e)
        {
            try
            {

                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Delete All ? ", "", MessageBoxButtons.YesNo))
                {

                    string[] list = grdDriverCommission.Rows.Where(c => c.Cells[COLS.CommissionId].Value.ToLong() > 0).Select(c => c.Cells[COLS.CommissionId].Value.ToStr())
                                            .ToArray<string>();

                    if (list.Count() > 0)
                    {
                        string arr = string.Join(",", list);

                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.stp_RunProcedure("delete from fleet_drivercommision where Id in (" + arr + ")");

                        }

                        btnDeleteGenerated.Visible = false;

                        grdDriverCommission.Rows.ToList().ForEach(c => c.Cells[COLS.CommissionId].Value = 0);

                        btnGenerate.Enabled = true;
                        btnDisplayCommission.Enabled = true;
                        btnGetBooking.Enabled = true;
                        btnClear.Enabled = true;
                    }
                }


            }
            catch (Exception ex)
            {


            }

        }

        private void btnGetBooking_Click(object sender, EventArgs e)
        {
            try
            {
                SetFilters();
                cnt = 0;
                worker_Commission.RunWorkerAsync("Get Booking");
                Progessbar.Visible = true;
                DisableControl();

                //bool RentForProcessedJobs = AppVars.objPolicyConfiguration.RentForProcessedJobs.ToBool();


                //DateTime? fromDate = dtpFromDate.Value.ToDate();
                //DateTime? tillDate = dtpTillDate.Value.ToDate();

                //DateTime? ACCJobsFromDate = fromDate.Value.AddDays(ddlAccountBookingDays.Text.ToInt());
                //DateTime? ACCJobsTillDate = fromDate;

                //if (ddlAccountBookingDays.Text.ToInt() < 0)
                //{
                //    ACCJobsTillDate = fromDate.Value.AddDays(-1).ToDate();

                //}
                //else
                //{

                //    ACCJobsTillDate = tillDate;
                //}

                //var CommissionList = General.GetGeneralList<Fleet_DriverCommision_Charge>(c => c.BookingId != null && c.TransId != 0);


                //foreach (var row in grdDriverCommission.Rows)
                //{




                //    int driverId= row.Cells[COLS.Id].Value.ToInt();
                   

                     

                //    Expression<Func<Booking, bool>> _condition = null;



                //    if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2)
                //    {
                //        _condition = c =>

                //                            (c.FareRate != null)

                //                          && (c.DriverId == driverId)
                //                          && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP))
                //                          && ((c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate)


                //                          );

                //    }
                //    else
                //    {

                //        _condition = c =>

                //                            (c.FareRate != null)

                //                          && (c.DriverId == driverId)
                //                          && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED)
                //                          && ((c.PickupDateTime.Value.Date >= fromDate && c.PickupDateTime.Value.Date <= tillDate)


                //                          );
                        

                //    }


                //    var list2 = (from a in General.GetGeneralList<Booking>(_condition)
                //                 join b in CommissionList on a.Id equals b.BookingId into table2
                //                 from b in table2.DefaultIfEmpty()

                //                 where (b == null)
                //                 select new
                //                 {
                //                     Id = a.Id,

                //                 }).Count();




                //    row.Cells["Bookings"].Value = list2;

                //}



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chkCarryForwardBalance_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCommissionView(ddlSubCompany.SelectedValue.ToInt());
        }
    }
}
