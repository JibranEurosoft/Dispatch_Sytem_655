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
using Taxi_Model;
using Taxi_BLL;
using Telerik.WinControls;
using System.Net;
using UI;
using System.Xml.Linq;
using Telerik.WinControls.Enumerations;
using System.Data.Linq;
using System.Xml;
using System.Threading;
using DAL;

namespace Taxi_AppMain
{
    public partial class frmSurchargeRateSettingDayWise : UI.SetupBase
    {
        SysPolicyBO objMaster;
        public frmSurchargeRateSettingDayWise()
        {
            InitializeComponent();

            objMaster = new SysPolicyBO();

            this.SetProperties((INavigation)objMaster);
          

            Gen_SysPolicy obj = General.GetQueryable<Gen_SysPolicy>(null).FirstOrDefault();
            if (obj != null)
            {
                objMaster.GetByPrimaryKey(obj.Id);
                objMaster.Edit();
            }
            this.Load += FrmCongestionCharges_Load;
        
            this.btnSave.Click += BtnSave_Click;
            this.btnExit1.Click += BtnExit1_Click;
        }

        private void FrmCongestionCharges_Load(object sender, EventArgs e)
        {
           
            FormatSurchargeRateOnPlotsGrid();
            DisplaySurchargeRates();
            //  tabControl1.TabPages[1].Visible = false;
            //  tabControl1.TabPages.Remove(tabPage1);
        }

      

        private void optTimeWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {


                dtpFromDate.ShowUpDown = true;
                dtpTillDate.ShowUpDown = true;
                ddlFromDay.Visible = true;
                ddlTillDay.Visible = true;


                dtpFromDate.CustomFormat = "HH:mm";
                dtpTillDate.CustomFormat = "HH:mm";
            }
        }

        private void BtnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private int GetDayId(string dayName)
        {
            dayName = dayName.ToStr().Trim();

            if (dayName.ToLower() == "monday")
                return 1;
            else if (dayName.ToLower() == "tuesday")
                return 2;
            else if (dayName.ToLower() == "wednesday")
                return 3;
            else if (dayName.ToLower() == "thursday")
                return 4;
            else if (dayName.ToLower() == "friday")
                return 5;
            else if (dayName.ToLower() == "saturday")
                return 6;
            else if (dayName.ToLower() == "sunday")
                return 0;
            else return 0;


        }

        //private int GetDayId(string dayName)
        //{
        //    dayName = dayName.ToStr().Trim();

        //    if (dayName.ToLower() == "mon")
        //        return 1;
        //    else if (dayName.ToLower() == "tues")
        //        return 2;
        //    else if (dayName.ToLower() == "wed")
        //        return 3;
        //    else if (dayName.ToLower() == "thurs")
        //        return 4;
        //    else if (dayName.ToLower() == "fri")
        //        return 5;
        //    else if (dayName.ToLower() == "satur")
        //        return 6;
        //    else if (dayName.ToLower() == "sun")
        //        return 0;
        //    else return 0;


        //}

        private DateTime GetFromDate(int daywise,DateTime FromDate, DateTime fromtime, DateTime NullDate)
        {
           
            if (daywise == 1)
            {
                return (string.Format("{0:dd/MM/yyyy HH:mm}" , FromDate.ToDateorNull() + fromtime.TimeOfDay).ToDateTime());
            }
            else if (daywise == 3)
            {
                return (string.Format("{0:dd/MM/yyyy HH:mm}", NullDate + fromtime.TimeOfDay).ToDateTime());
            }
            else
            {
                return FromDate.ToDate();
            }

            
        }

        private DateTime GetTillDate(int daywise, DateTime ToDate, DateTime Tilltime, DateTime NullDate)
        {

            if (daywise == 1)
            {
                return (string.Format("{0:dd/MM/yyyy HH:mm}", ToDate.ToDateorNull() + Tilltime.TimeOfDay).ToDateTime());
            }
            else if (daywise == 3)
            {
                return (string.Format("{0:dd/MM/yyyy HH:mm}", NullDate + Tilltime.TimeOfDay).ToDateTime());
            }
            else
            {
                return ToDate.ToDate();
            }


        }

        public override void Save()
        {
            try
            {

                if (objMaster.Current != null)
                {


                    DateTime NullDate = new DateTime(1900, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToDate();

                    DateTime NullDate2 = new DateTime(2040, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToDate();

                    
                    //int fromDay = GetDayId(ddlFromDay.Text);
                    //int toDay = GetDayId(ddlTillDay.Text);


                    string[] skipProperties = new string[] { "Gen_SysPolicy", "Fleet_VehicleType" };



                    List<Gen_SysPolicy_SurchargeRate> listRatesZone = (from a in grdSurchargeRateDayWise.Rows
                                                                       select new Gen_SysPolicy_SurchargeRate
                                                                       {
                                                                           Id = a.Cells[COL_CONGESTIONCHARGES.ID].Value.ToLong(),
                                                                           SysPolicyId = objMaster.Current.Id,

                                                                           zoneid = a.Cells[COL_CONGESTIONCHARGES.PlotId].Value.ToIntorNull(),
                                                                           Percentage = a.Cells[COL_CONGESTIONCHARGES.PERCENTAGE].Value.ToDecimal(),
                                                                           IsAmountWise = a.Cells[COL_CONGESTIONCHARGES.AMOUNTWISE].Value.ToBool(),
                                                                           ApplyOutofTown = a.Cells[COL_CONGESTIONCHARGES.TOWNWISE].Value.ToBool(),
                                                                           Amount = a.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value.ToDecimal(),
                                                                           Parking = a.Cells[COL_CONGESTIONCHARGES.PARKING].Value.ToDecimal(),
                                                                          Waiting = a.Cells[COL_CONGESTIONCHARGES.WAITING].Value.ToDecimal(),
                                                                           ApplicableFromDateTime = GetFromDate(a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToInt(), a.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value.ToDateTime(), a.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value.ToDateTime(),NullDate),
                                                                                         
                                                                           CriteriaBy = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToInt(),
                                                                           EnableSurcharge = a.Cells[COL_CONGESTIONCHARGES.ENABLESURCHARGE].Value.ToBool(),
                                                                           ApplicableToDateTime = GetTillDate(a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToInt(), a.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value.ToDateTime(), a.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value.ToDateTime(), NullDate2),
                                                                           ApplicableFromDay = GetDayId(a.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value.ToStr()).ToInt(),
                                                                           ApplicableToDay = GetDayId(a.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value.ToStr()).ToInt(),
                                                                           Holidays = a.Cells[COL_CONGESTIONCHARGES.OPERATOR].Value.ToStr()
                                                                       }).ToList();

                    IList<Gen_SysPolicy_SurchargeRate> savedListRatesZone = objMaster.Current.Gen_SysPolicy_SurchargeRates;


                    Utils.General.SyncChildCollection(ref savedListRatesZone, ref listRatesZone, "Id", skipProperties);
                    
                    objMaster.Save();


                    try
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.ExecuteQuery<int>("delete from Gen_SysPolicy_SurchargeRates where syspolicyid is null");
                        }
                    }
                    catch
                    {


                    }

                        this.Close();
                }

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

     
      
        private void DisplaySurchargeRates()
        {
            grdSurchargeRateDayWise.Rows.Clear();

            var list = objMaster.Current.Gen_SysPolicy_SurchargeRates.ToList();

            var list2 = (from a in list
                         join b in new TaxiDataContext().Gen_Zones on a.zoneid equals b.Id
                         where a.SysPolicyId != null
                         orderby b.ZoneName
                         select new
                         {
                             a.Id,
                             a.SysPolicyId,
                             a.PostCode,
                             a.Percentage,
                             a.IsAmountWise,
                             a.Amount,
                             a.Waiting,
                             a.Parking,
                             a.zoneid,
                             a.ApplyOutofTown,
                             a.ApplicableFromDateTime,
                             a.ApplicableFromDay,
                             a.ApplicableToDateTime,
                             a.ApplicableToDay,
                             a.CriteriaBy,
                             a.EnableSurcharge,
                             a.Holidays
                         }).ToList();


            var postcodeList = list.Where(x => x.zoneid == null).ToList();

 
            var list3 = list2.Where(x => x.zoneid != null).ToList();
            grdSurchargeRateDayWise.RowCount = list3.Count;
            int cnt = 0;
            foreach (var item in list3)
            {
                GridViewRowInfo row = grdSurchargeRateDayWise.Rows[cnt];
                row.Cells[COL_CONGESTIONCHARGES.ID].Value = item.Id;
                row.Cells[COL_CONGESTIONCHARGES.POLICYID].Value = item.SysPolicyId;
                row.Cells[COL_CONGESTIONCHARGES.PlotId].Value = item.zoneid.ToInt();
                row.Cells[COL_CONGESTIONCHARGES.PERCENTAGE].Value = item.Percentage;

                row.Cells[COL_CONGESTIONCHARGES.ENABLESURCHARGE].Value = item.EnableSurcharge.ToBool();
                row.Cells[COL_CONGESTIONCHARGES.AMOUNTWISE].Value = item.IsAmountWise.ToBool();
                row.Cells[COL_CONGESTIONCHARGES.TOWNWISE].Value = item.ApplyOutofTown.ToBool();
                row.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value = item.Amount.ToDecimal();
                
                row.Cells[COL_CONGESTIONCHARGES.WAITING].Value = item.Waiting.ToDecimal();
                row.Cells[COL_CONGESTIONCHARGES.PARKING].Value = item.Parking.ToDecimal();

                row.Cells[COL_CONGESTIONCHARGES.OPERATOR].Value = item.Holidays.ToStr();

                row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = item.ApplicableFromDateTime.ToDate();
                row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = item.ApplicableToDateTime.ToDate();
                row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = item.ApplicableFromDateTime.ToDateTime();
                row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = item.ApplicableToDateTime.ToDateTime();

                
                if (item.CriteriaBy.ToInt() == 1)
                {
                    row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value = "1";
                }
                else if (item.CriteriaBy.ToInt() == 2)
                {
                    row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value = "2";
                    row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = null;
                    row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = null;
                }
                else if (item.CriteriaBy.ToInt() == 3)
                {
                    row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value = "3";

                    if (item.ApplicableFromDay.ToInt() == 1)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Monday";
                    else if (item.ApplicableFromDay.ToInt() == 2)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Tuesday";
                    else if (item.ApplicableFromDay.ToInt() == 3)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Wednesday";
                    else if (item.ApplicableFromDay.ToInt() == 4)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Thursday";
                    else if (item.ApplicableFromDay.ToInt() == 5)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Friday";
                    else if (item.ApplicableFromDay.ToInt() == 6)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Saturday";
                    else if (item.ApplicableFromDay.ToInt() == 0)
                        row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = "Sunday";



                    if (item.ApplicableToDay.ToInt() == 1)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Monday";
                    else if (item.ApplicableToDay.ToInt() == 2)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Tuesday";
                    else if (item.ApplicableToDay.ToInt() == 3)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Wednesday";
                    else if (item.ApplicableToDay.ToInt() == 4)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Thursday";
                    else if (item.ApplicableToDay.ToInt() == 5)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Friday";
                    else if (item.ApplicableToDay.ToInt() == 6)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Saturday";
                    else if (item.ApplicableToDay.ToInt() == 0)
                        row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = "Sunday";


                    row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = null;
                    row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = null;

                }

                cnt++;
            }

            if (grdSurchargeRateDayWise.Rows.Count > 0)
            {
                var item = list2.Where(x => x.zoneid != null).FirstOrDefault();
                if (item != null)
                {
                    

                    
                    dtpFromDate.Value = item.ApplicableFromDateTime;
                    dtpTillDate.Value = item.ApplicableToDateTime;


                   


                }


            }

            tabPage2.Text = "Plot wise Surcharge(" + grdSurchargeRateDayWise.Rows.Count + ")";


        }
        private void FormatSurchargeRateGrid()
        {

            
          
        }

        private void grdSurchargeRates_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column != null)
            {

                    bool IsAmountWise = e.Row.Cells[COL_FARES.AMOUNTWISE].Value.ToBool();

                    if (IsAmountWise && e.Column.Name == COL_FARES.PERCENTAGE)
                    {
                        e.Cancel = true;

                    }

                    if (IsAmountWise == false && e.Column.Name == COL_FARES.AMOUNT)
                    {
                        e.Cancel = true;

                    }
                    if (IsAmountWise)
                    {
                        e.Row.Cells[COL_CONGESTIONCHARGES.PERCENTAGE].Value = 0;
                    }
                    else
                    {
                        e.Row.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value = 0;
                    }


                

                string IsDayWise = e.Row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToStr();

                if (IsDayWise.ToStr()== "3" && (e.Column.Name == COL_CONGESTIONCHARGES.FROMDATE || e.Column.Name == COL_CONGESTIONCHARGES.TILLDATE ))
                {
                    e.Cancel = true;

                }

                if (IsDayWise.ToStr() == "1" && ( e.Column.Name == COL_CONGESTIONCHARGES.FROMDAY || e.Column.Name == COL_CONGESTIONCHARGES.TILLDAY))
                {
                    e.Cancel = true;

                }

                if (IsDayWise.ToStr() == "2" && (e.Column.Name == COL_CONGESTIONCHARGES.FROMTIME || e.Column.Name == COL_CONGESTIONCHARGES.TILLTIME || e.Column.Name == COL_CONGESTIONCHARGES.FROMDAY || e.Column.Name == COL_CONGESTIONCHARGES.TILLDAY))
                {
                    e.Cancel = true;

                }


            }
        }

        private void GrdSurchargeRates_CellEndEdit(object sender, GridViewCellEventArgs e)
        {


            if (e.Column.Name==COL_CONGESTIONCHARGES.DAYWISE  )
            {



                if (e.Value.ToInt() == 1)
                {
                  
                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].ReadOnly = false;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].ReadOnly = true;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMTIME].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLTIME].ReadOnly = false;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = null;
                                        
                }
                else if (e.Value.ToInt() == 2)
                {
                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].ReadOnly = false;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].ReadOnly = true;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMTIME].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLTIME].ReadOnly = true;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = null;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = null;
                }
                else if (e.Value.ToInt() == 3)
                {
                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].ReadOnly = true;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = null;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].ReadOnly = false;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMTIME].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLTIME].ReadOnly = false;

                                     

                }


            }
            else
            {             


               
            }
        }

        private void FormatSurchargeRateOnPlotsGrid()
        {

            grdSurchargeRateDayWise.ShowGroupPanel = false;
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_CONGESTIONCHARGES.ID;
            grdSurchargeRateDayWise.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_CONGESTIONCHARGES.POLICYID;
            grdSurchargeRateDayWise.Columns.Add(col);

           
            GridViewComboBoxColumn colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 160;
            colCombo.Name = COL_CONGESTIONCHARGES.PlotId;
            colCombo.HeaderText = "Plot Name";
            // colCombo.DataSource = Program.dtCombos.Tables[2].Copy();
            colCombo.DataSource = General.GetQueryable<Gen_Zone>(null).OrderBy(c => c.ZoneName).Select(args => new
            {
                ZoneName =  args.ZoneName,
                args.Id
            }).ToList();
            colCombo.DisplayMember = "ZoneName";
            colCombo.ValueMember = "Id";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdSurchargeRateDayWise.Columns.Add(colCombo);

        


            


            GridViewCheckBoxColumn colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Amount Wise";
            colChk.Width = 85;
            colChk.Name = COL_CONGESTIONCHARGES.AMOUNTWISE;
            grdSurchargeRateDayWise.Columns.Add(colChk);

            

            GridViewDecimalColumn col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Percentage (%)";
            col2.Width = 102;
            col2.Maximum = 100;
            col2.Name = COL_CONGESTIONCHARGES.PERCENTAGE;
            grdSurchargeRateDayWise.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Amount (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_CONGESTIONCHARGES.AMOUNT;
            grdSurchargeRateDayWise.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Parking (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_CONGESTIONCHARGES.PARKING;
            grdSurchargeRateDayWise.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Extra (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_CONGESTIONCHARGES.WAITING;
            grdSurchargeRateDayWise.Columns.Add(col2);

            colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Apply Out of Town";
            colChk.Width = 120;
            colChk.Name = COL_CONGESTIONCHARGES.TOWNWISE;
            grdSurchargeRateDayWise.Columns.Add(colChk);

            colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Enable Surcharge";
            colChk.Width = 110;
            colChk.Name = COL_CONGESTIONCHARGES.ENABLESURCHARGE;
            grdSurchargeRateDayWise.Columns.Add(colChk);

            List<RadListDataItem> OperatorList = new List<RadListDataItem>();
            OperatorList.Add(new RadListDataItem("Plus(+)", "+"));
            OperatorList.Add(new RadListDataItem("Minus(-)", "-"));

            var list = (from a in OperatorList
                        select new
                        {
                            Name = a.Text,
                            Id = a.Value
                        }).ToList();

            GridViewComboBoxColumn comboCol = new GridViewComboBoxColumn();
            comboCol.DataSource = list;
            comboCol.DisplayMember = "Name";
            comboCol.ValueMember = "Id";
            comboCol.HeaderText = "Operator";
            comboCol.Width = 70;
            comboCol.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            comboCol.Name = COL_CONGESTIONCHARGES.OPERATOR;
            grdSurchargeRateDayWise.Columns.Add(comboCol);

            



            List<RadListDataItem> DateTimeList = new List<RadListDataItem>();
            DateTimeList.Add(new RadListDataItem("Date/Time Wise", "1"));
            DateTimeList.Add(new RadListDataItem("Date Wise", "2"));
            DateTimeList.Add(new RadListDataItem("Day/Time Wise", "3"));

            var list1 = (from a in DateTimeList
                         select new
                        {
                            Name = a.Text,
                            Id = a.Value
                        }).ToList();

            comboCol = new GridViewComboBoxColumn();
            comboCol.DataSource = list1;
            comboCol.DisplayMember = "Name";
            comboCol.ValueMember = "Id";
            comboCol.HeaderText = "Day Wise";
            comboCol.Width = 120;
            comboCol.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            comboCol.Name = COL_CONGESTIONCHARGES.DAYWISE;
            grdSurchargeRateDayWise.Columns.Add(comboCol);

            
            colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 80;
            colCombo.Name = COL_CONGESTIONCHARGES.FROMDAY;
            colCombo.HeaderText = "From Day";
            // colCombo.DataSource = Program.dtCombos.Tables[2].Copy();
            colCombo.DataSource = General.GetWeekDays2();
            colCombo.DisplayMember = "Name";
            colCombo.ValueMember = "Name";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdSurchargeRateDayWise.Columns.Add(colCombo);


            colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 80;
            colCombo.Name = COL_CONGESTIONCHARGES.TILLDAY;
            colCombo.HeaderText = "Till Day";
            // colCombo.DataSource = Program.dtCombos.Tables[2].Copy();
            colCombo.DataSource = General.GetWeekDays2();
            colCombo.DisplayMember = "Name";
            colCombo.ValueMember = "Name";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdSurchargeRateDayWise.Columns.Add(colCombo);

            GridViewDateTimeColumn dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.FROMDATE;
            dtcol.HeaderText = "From Date";
            dtcol.CustomFormat = "dd/MM/yyyy";
            dtcol.FormatString = "{0:dd/MM/yyyy}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 90;
            grdSurchargeRateDayWise.Columns.Add(dtcol);


            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.FROMTIME;
            dtcol.HeaderText = "From Time";
            dtcol.CustomFormat = "HH:mm";
            dtcol.FormatString = "{0:HH:mm}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 85;
            grdSurchargeRateDayWise.Columns.Add(dtcol);

            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.TILLDATE;
            dtcol.HeaderText = "Till Date";
            dtcol.CustomFormat = "dd/MM/yyyy";
            dtcol.FormatString = "{0:dd/MM/yyyy}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 90;
            grdSurchargeRateDayWise.Columns.Add(dtcol);


            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.TILLTIME;
            dtcol.HeaderText = "Till Time";
            dtcol.CustomFormat = "HH:mm";
            dtcol.FormatString = "{0:HH:mm}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 85;
            grdSurchargeRateDayWise.Columns.Add(dtcol);

            GridViewCommandColumn cmd = new GridViewCommandColumn();
            cmd.Width = 70;
            cmd.Name = "btnDelete";
            cmd.UseDefaultText = true;
            cmd.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            cmd.DefaultText = "Delete";
            cmd.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdSurchargeRateDayWise.Columns.Add(cmd);

            grdSurchargeRateDayWise.ShowGroupPanel = false;
            grdSurchargeRateDayWise.AddNewRowPosition = SystemRowPosition.Bottom;


            grdSurchargeRateDayWise.CellBeginEdit += new GridViewCellCancelEventHandler(grdSurchargeRates_CellBeginEdit);
            grdSurchargeRateDayWise.CellEndEdit += GrdSurchargeRates_CellEndEdit;
            grdSurchargeRateDayWise.CommandCellClick += GrdCongestionCharges_CommandCellClick;


        }

        private void GrdCongestionCharges_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
                {
                    
                        
                        RadGridView grid = gridCell.GridControl;

                        grid.CurrentRow.Delete();

                   
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        public struct COL_CONGESTIONCHARGES
        {
            public static string ID = "Id";
            public static string POLICYID = "POLICYID";
            public static string AMOUNT = "AMOUNT";
            public static string DAYWISE = "DAYWISE";

            public static string FROMDAY = "FROMDAY";
            public static string TILLDAY = "TILLDAY";
            public static string FROMDATE = "FROMDATE";
            public static string TILLDATE = "TILLDATE";
            public static string FROMTIME = "FROMTIME";
            public static string TILLTIME = "TILLTIME";
            public static string PlotName = "PlotName";
            public static string PlotId = "PlotId";

            public static string PERCENTAGE = "PERCENTAGE";
            
            public static string AMOUNTWISE = "AMOUNTWISE";
            public static string TOWNWISE = "TOWNWISE";
                        
            public static string PARKING = "PARKING";
            public static string WAITING = "WAITING";

            public static string OPERATOR = "OPERATOR";
            public static string ENABLESURCHARGE = "ENABLESURCHARGE";

        }
        public struct COL_FARES
        {
            public static string ID = "Id";
            public static string POLICYID = "POLICYID";
            public static string VEHICLETYPEID = "VEHICLETYPEID";
            public static string VEHICLETYPE = "VEHICLETYPE";
            public static string OPERATOR = "OPERATOR";

            public static string PERCENTAGE = "PERCENTAGE";
            public static string AMOUNT = "AMOUNT";

            public static string AMOUNTWISE = "AMOUNTWISE";
            public static string TOWNWISE = "TOWNWISE";
            public static string PARKING = "PARKING";
            public static string WAITING = "WAITING";
        }

    }
}