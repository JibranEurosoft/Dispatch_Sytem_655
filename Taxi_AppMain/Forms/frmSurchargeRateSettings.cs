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
    public partial class frmSurchargeRateSettings : UI.SetupBase
    {
        SysPolicyBO objMaster;
        public frmSurchargeRateSettings()
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
            this.Load += FrmSurchargeRateSettings_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnExit1.Click += BtnExit1_Click;
        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            if (args.ToggleState == ToggleState.On)
            {
                dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
                dtpTillDate.CustomFormat = "dd/MM/yyyy HH:mm";

                dtpFromDate.ShowUpDown = false;
                dtpTillDate.ShowUpDown = false;

                ddlFromDay.Visible = false;
                ddlTillDay.Visible = false;
            }

        }

        private void optDateWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                dtpFromDate.CustomFormat = "dd/MM/yyyy";
                dtpTillDate.CustomFormat = "dd/MM/yyyy";
                dtpFromDate.ShowUpDown = false;
                dtpTillDate.ShowUpDown = false;
                ddlFromDay.Visible = false;
                ddlTillDay.Visible = false;
            }
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

        private void FrmSurchargeRateSettings_Load(object sender, EventArgs e)
        {
         //   FormatSurchargeRateGrid();
            FormatSurchargeRateOnPlotsGrid();
            DisplaySurchargeRates();
          //  tabControl1.TabPages[1].Visible = false;
          //  tabControl1.TabPages.Remove(tabPage1);
        }

        public override void Save()
        {
            try
            {

                if (objMaster.Current != null)
                {

                   
                        //if (dtpFromDate.Value == null)
                        //{
                        //    ENUtils.ShowMessage("Required : From Date/Time");
                        //  //  return rtn;

                        //}

                        //if (dtpTillDate.Value == null)
                        //{
                        //    ENUtils.ShowMessage("Required : Till Date/Time");
                        //   // return rtn;

                        //}


                        //if (dtpFromDate.Value.ToDate() > dtpTillDate.Value.ToDate())
                        //{
                        //    ENUtils.ShowMessage("Required : From Date must be less than Till Date");
                        //  //  return rtn;

                        //}


                        int criteriaBy = 0 ;
                        
                        if (optDateTimeWise.ToggleState == ToggleState.On)
                            criteriaBy = 1;
                        else if (optDateWise.ToggleState == ToggleState.On)
                            criteriaBy = 2;
                        else if (optDayTimeWise.ToggleState == ToggleState.On)
                            criteriaBy = 3;




                        int fromDay = GetDayId(ddlFromDay.Text);
                        int toDay = GetDayId(ddlTillDay.Text);


                        string[] skipProperties = new string[] { "Gen_SysPolicy", "Fleet_VehicleType" };
                    //List<Gen_SysPolicy_SurchargeRate> listRates = (from a in grdSurchargeRates.Rows
                    //                                               select new Gen_SysPolicy_SurchargeRate
                    //                                               {
                    //                                                   Id = a.Cells[COL_SURCHARGERATES.ID].Value.ToLong(),
                    //                                                   SysPolicyId = objMaster.Current.Id,
                    //                                                   PostCode = a.Cells[COL_SURCHARGERATES.POSTCODE].Value.ToStr().Trim().ToUpper(),
                    //                                                  // Percentage = a.Cells[COL_SURCHARGERATES.PERCENTAGE].Value.ToDecimal(),
                    //                                                   IsAmountWise =true,
                    //                                                   Amount = a.Cells[COL_SURCHARGERATES.AMOUNT].Value.ToDecimal(),
                    //                                                 //  Parking = a.Cells[COL_SURCHARGERATES.PARKING].Value.ToDecimal(),
                    //                                                //   Waiting = a.Cells[COL_SURCHARGERATES.WAITING].Value.ToDecimal(),
                    //                                                   ApplicableFromDateTime = dtpFromDate.Value,
                    //                                                   CriteriaBy = criteriaBy,
                    //                                                   EnableSurcharge = chkEnableIncrement.Checked,
                    //                                                   ApplicableToDateTime = dtpTillDate.Value,
                    //                                                   ApplicableFromDay = fromDay,
                    //                                                   ApplicableToDay = toDay


                    //                                               }).ToList();

                  //  IList<Gen_SysPolicy_SurchargeRate> savedListRates = objMaster.Current.Gen_SysPolicy_SurchargeRates;
                 //   Utils.General.SyncChildCollection(ref savedListRates, ref listRates, "Id", skipProperties);

                    

                    List<Gen_SysPolicy_SurchargeRate> listRatesZone = (from a in grdSurchargeRateonPlots.Rows
                                                                       select new Gen_SysPolicy_SurchargeRate
                                                                       {
                                                                           Id = a.Cells[COL_SURCHARGERATES.ID].Value.ToLong(),
                                                                           SysPolicyId = objMaster.Current.Id,
                                                                           
                                                                           zoneid = a.Cells[COL_SURCHARGERATES.PlotId].Value.ToIntorNull(),
                                                                           Percentage = a.Cells[COL_SURCHARGERATES.PERCENTAGE].Value.ToDecimal(),
                                                                           IsAmountWise = a.Cells[COL_SURCHARGERATES.AMOUNTWISE].Value.ToBool(),
                                                                           ApplyOutofTown = a.Cells[COL_SURCHARGERATES.TOWNWISE].Value.ToBool(),
                                                                           Amount = a.Cells[COL_SURCHARGERATES.AMOUNT].Value.ToDecimal(),
                                                                           Parking = a.Cells[COL_SURCHARGERATES.PARKING].Value.ToDecimal(),
                                                                           Waiting = a.Cells[COL_SURCHARGERATES.WAITING].Value.ToDecimal(),
                                                                           ApplicableFromDateTime = dtpFromDate.DateTimePickerElement.Value,
                                                                           CriteriaBy = criteriaBy,
                                                                           EnableSurcharge = chkEnableIncrement.Checked,
                                                                           ApplicableToDateTime = dtpTillDate.DateTimePickerElement.Value,
                                                                           ApplicableFromDay = fromDay,
                                                                           ApplicableToDay = toDay,
                                                                           Holidays= a.Cells[COL_SURCHARGERATES.OPERATOR].Value.ToStr()
                                                                       }).ToList();

                    IList<Gen_SysPolicy_SurchargeRate> savedListRatesZone = objMaster.Current.Gen_SysPolicy_SurchargeRates;

                    //foreach (var item in listRates)
                    //{
                    //    listRatesZone.Add(new Gen_SysPolicy_SurchargeRate
                    //    {
                    //        Id = item.Id,
                    //        SysPolicyId = item.SysPolicyId,
                    //        PostCode = item.PostCode,
                    //        Percentage = item.Percentage,
                    //        Amount = item.Amount,
                    //        IsAmountWise = item.IsAmountWise,
                    //        Parking = item.Parking,
                    //        Waiting = item.Waiting,

                    //        ApplicableFromDateTime = dtpFromDate.Value,
                    //        CriteriaBy = criteriaBy,
                    //        EnableSurcharge = chkEnableIncrement.Checked,
                    //        ApplicableToDateTime = dtpTillDate.Value,
                    //        ApplicableFromDay = fromDay,
                    //        ApplicableToDay = toDay,


                    //    }
                    //    );
                    //}
                    Utils.General.SyncChildCollection(ref savedListRatesZone, ref listRatesZone, "Id", skipProperties);


                    //}
                    objMaster.Save();
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
                    e.Row.Cells[COL_SURCHARGERATES.PERCENTAGE].Value = 0;
                }
                else
                {
                    e.Row.Cells[COL_SURCHARGERATES.AMOUNT].Value = 0;
                }


            }
        }
        private void DisplaySurchargeRates()
        {
         //   grdSurchargeRates.Rows.Clear();
            grdSurchargeRateonPlots.Rows.Clear();

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

           // int cntP = 0;
            //grdSurchargeRates.RowCount = postcodeList.Count;
            //// foreach (var item in objMaster.Current.Gen_SysPolicy_SurchargeRates)
            //foreach (var item in postcodeList)
            //{
            //    GridViewRowInfo row = grdSurchargeRates.Rows[cntP];
            //    row.Cells[COL_SURCHARGERATES.ID].Value = item.Id;
            //    row.Cells[COL_SURCHARGERATES.POLICYID].Value = item.SysPolicyId;
            //    row.Cells[COL_SURCHARGERATES.POSTCODE].Value = item.PostCode;
            //    row.Cells[COL_SURCHARGERATES.PERCENTAGE].Value = item.Percentage;

            //    row.Cells[COL_SURCHARGERATES.AMOUNTWISE].Value = item.IsAmountWise.ToBool();
            //    row.Cells[COL_SURCHARGERATES.AMOUNT].Value = item.Amount.ToDecimal();

            //    row.Cells[COL_SURCHARGERATES.WAITING].Value = item.Waiting.ToDecimal();
            //    row.Cells[COL_SURCHARGERATES.PARKING].Value = item.Parking.ToDecimal();

            //    cntP++;
            //}
            

            var list3 = list2.Where(x => x.zoneid != null).ToList();
            grdSurchargeRateonPlots.RowCount = list3.Count;
            int cnt = 0;
            foreach (var item in list3)
            {
                GridViewRowInfo row = grdSurchargeRateonPlots.Rows[cnt];
                row.Cells[COL_SURCHARGERATES.ID].Value = item.Id;
                row.Cells[COL_SURCHARGERATES.POLICYID].Value = item.SysPolicyId;
                row.Cells[COL_SURCHARGERATES.PlotId].Value = item.zoneid.ToInt();
                row.Cells[COL_SURCHARGERATES.PERCENTAGE].Value = item.Percentage;

                row.Cells[COL_SURCHARGERATES.AMOUNTWISE].Value = item.IsAmountWise.ToBool();
                row.Cells[COL_SURCHARGERATES.TOWNWISE].Value = item.ApplyOutofTown.ToBool();
                row.Cells[COL_SURCHARGERATES.AMOUNT].Value = item.Amount.ToDecimal();

                row.Cells[COL_SURCHARGERATES.WAITING].Value = item.Waiting.ToDecimal();
                row.Cells[COL_SURCHARGERATES.PARKING].Value = item.Parking.ToDecimal();

                row.Cells[COL_SURCHARGERATES.OPERATOR].Value = item.Holidays.ToStr();

                cnt++;
            }

            if(grdSurchargeRateonPlots.Rows.Count>0)
            {
                var item = list2.Where(x => x.zoneid != null ).FirstOrDefault();
                if(item!=null)
                {
                    if(item.CriteriaBy.ToInt()==1)
                    {
                        optDateTimeWise.ToggleState = ToggleState.On;
                    }
                   else if (item.CriteriaBy.ToInt() == 2)
                    {
                        optDateWise.ToggleState = ToggleState.On;
                    }
                   else if (item.CriteriaBy.ToInt() == 3)
                    {
                        optDayTimeWise.ToggleState = ToggleState.On;

                        if (item.ApplicableFromDay.ToInt() == 1)
                            ddlFromDay.Text = "Monday";
                        else if (item.ApplicableFromDay.ToInt() == 2)
                            ddlFromDay.Text = "Tuesday";
                        else if (item.ApplicableFromDay.ToInt() == 3)
                            ddlFromDay.Text = "Wednesday";
                        else if (item.ApplicableFromDay.ToInt() == 4)
                            ddlFromDay.Text = "Thursday";

                        else if (item.ApplicableFromDay.ToInt() == 5)
                            ddlFromDay.Text = "Friday";

                        else if (item.ApplicableFromDay.ToInt() == 6)
                            ddlFromDay.Text = "Saturday";
                        else if (item.ApplicableFromDay.ToInt() == 0)
                            ddlFromDay.Text = "Sunday";



                        if (item.ApplicableToDay.ToInt() == 1)
                            ddlTillDay.Text = "Monday";
                        else if (item.ApplicableToDay.ToInt() == 2)
                            ddlTillDay.Text = "Tuesday";
                        else if (item.ApplicableToDay.ToInt() == 3)
                            ddlTillDay.Text = "Wednesday";
                        else if (item.ApplicableToDay.ToInt() == 4)
                            ddlTillDay.Text = "Thursday";

                        else if (item.ApplicableToDay.ToInt() == 5)
                            ddlTillDay.Text = "Friday";

                        else if (item.ApplicableToDay.ToInt() == 6)
                            ddlTillDay.Text = "Saturday";
                        else if (item.ApplicableToDay.ToInt() == 0)
                            ddlTillDay.Text = "Sunday";

                    }

                    chkEnableIncrement.Checked = item.EnableSurcharge.ToBool();
                    dtpFromDate.Value = item.ApplicableFromDateTime;
                    dtpTillDate.Value = item.ApplicableToDateTime;


                    //if(item.ApplicableFromDay.ToInt()>0 && item.ApplicableToDay.ToInt()>0)
                    //{
                      

                 //   }


                }


            }

            tabPage2.Text = "Plot wise Surcharge(" + grdSurchargeRateonPlots.Rows.Count + ")";

           // UI.GridFunctions.SetFilter(grdSurchargeRates);
           //  grdSurchargeRates.AllowEditRow = true;
           //var list2 = list.Where(x => x.zoneid != null).ToList();
           //grdSurchargeRateonPlots.RowCount = list2.Count();
           //for (int i = 0; i < list2.Count(); i++)
           //{
           //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.ID].Value = list2[i].Id;
           //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.POLICYID].Value = list2[i].SysPolicyId;
           //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.PlotId].Value = list2[i].zoneid.ToInt();

            //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.PERCENTAGE].Value = list2[i].Percentage;

            //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.AMOUNTWISE].Value = list2[i].IsAmountWise.ToBool();
            //    grdSurchargeRateonPlots.Rows[i].Cells[COL_SURCHARGERATES.AMOUNT].Value = list2[i].Amount.ToDecimal();
            //}
        }
        //private void FormatSurchargeRateGrid()
        //{

        //    grdSurchargeRates.ShowGroupPanel = false;
        //    GridViewTextBoxColumn col = new GridViewTextBoxColumn();
        //    col.IsVisible = false;
        //    col.Name = COL_SURCHARGERATES.ID;
        //    grdSurchargeRates.Columns.Add(col);

        //    col = new GridViewTextBoxColumn();
        //    col.IsVisible = false;
        //    col.Name = COL_SURCHARGERATES.POLICYID;
        //    grdSurchargeRates.Columns.Add(col);

        //    col = new GridViewTextBoxColumn();
        //    col.HeaderText = COL_SURCHARGERATES.POSTCODE;
        //    col.Width = 100;
        //    col.Name = COL_SURCHARGERATES.POSTCODE;
        //    col.ColumnCharacterCasing = CharacterCasing.Upper;
        //    grdSurchargeRates.Columns.Add(col);

        //    GridViewCheckBoxColumn colChk = new GridViewCheckBoxColumn();
        //    colChk.HeaderText = "Amount Wise";
        //    colChk.Width = 85;
        //    colChk.Name = COL_SURCHARGERATES.AMOUNTWISE;
        //    colChk.IsVisible = false;
        //    grdSurchargeRates.Columns.Add(colChk);


        //    GridViewDecimalColumn col2 = new GridViewDecimalColumn();
        //    col2.HeaderText = "Percentage (%)";
        //    col2.Width = 102;
        //    col2.Maximum = 100;
        //    col2.Name = COL_SURCHARGERATES.PERCENTAGE;
        //    col2.IsVisible = false;
        //    grdSurchargeRates.Columns.Add(col2);


        //    col2 = new GridViewDecimalColumn();
        //    col2.HeaderText = "Amount (£)";
        //    col2.Width = 75;
        //    col2.Maximum = 100000;
        //    col2.Name = COL_SURCHARGERATES.AMOUNT;
        //    col2.ReadOnly = false;
        //    col2.DecimalPlaces = 2;
        //    grdSurchargeRates.Columns.Add(col2);

        //    col2 = new GridViewDecimalColumn();
        //    col2.HeaderText = "Parking (£)";
        //    col2.Width = 75;
        //    col2.Maximum = 100000;
        //    col2.Name = COL_SURCHARGERATES.PARKING;
        //    col2.IsVisible = false;
        //    grdSurchargeRates.Columns.Add(col2);

        //    col2 = new GridViewDecimalColumn();
        //    col2.HeaderText = "Waiting (£)";
        //    col2.Width = 75;
        //    col2.Maximum = 100000;
        //    col2.IsVisible = false;
        //    col2.Name = COL_SURCHARGERATES.WAITING;
        //    grdSurchargeRates.Columns.Add(col2);



        //    UI.GridFunctions.AddDeleteColumn(grdSurchargeRates);

        //    grdSurchargeRates.ShowGroupPanel = false;
        //    grdSurchargeRates.AddNewRowPosition = SystemRowPosition.Bottom;
            
        //    tabPage2.Hide();
        // //   grdSurchargeRates.CellBeginEdit += new GridViewCellCancelEventHandler(grdSurchargeRates_CellBeginEdit);
        // //   grdSurchargeRates.CellEndEdit += GrdSurchargeRates_CellEndEdit;
          
        //}

        private void GrdSurchargeRates_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null)
            {
                bool IsAmountWise = e.Row.Cells[COL_FARES.AMOUNTWISE].Value.ToBool();

               
                if (IsAmountWise)
                {
                    e.Row.Cells[COL_SURCHARGERATES.PERCENTAGE].Value = 0;
                }
                else
                {
                    e.Row.Cells[COL_SURCHARGERATES.AMOUNT].Value = 0;
                }


            }
        }

        private void FormatSurchargeRateOnPlotsGrid()
        {

            grdSurchargeRateonPlots.ShowGroupPanel = false;
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_SURCHARGERATES.ID;
            grdSurchargeRateonPlots.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_SURCHARGERATES.POLICYID;
            grdSurchargeRateonPlots.Columns.Add(col);

           
            GridViewComboBoxColumn colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 160;
            colCombo.Name = COL_SURCHARGERATES.PlotId;
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

            grdSurchargeRateonPlots.Columns.Add(colCombo);




            GridViewCheckBoxColumn colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Amount Wise";
            colChk.Width = 85;
            colChk.Name = COL_SURCHARGERATES.AMOUNTWISE;
            grdSurchargeRateonPlots.Columns.Add(colChk);


           

            GridViewDecimalColumn col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Percentage (%)";
            col2.Width = 102;
            col2.Maximum = 100;
            col2.Name = COL_SURCHARGERATES.PERCENTAGE;
            grdSurchargeRateonPlots.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Amount (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_SURCHARGERATES.AMOUNT;
            grdSurchargeRateonPlots.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Parking (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_SURCHARGERATES.PARKING;
            grdSurchargeRateonPlots.Columns.Add(col2);


            col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Extra (£)";
            col2.Width = 75;
            col2.Maximum = 100000;
            col2.Name = COL_SURCHARGERATES.WAITING;
            grdSurchargeRateonPlots.Columns.Add(col2);

            colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Apply Out of Town";
            colChk.Width = 120;
            colChk.Name = COL_SURCHARGERATES.TOWNWISE;
            grdSurchargeRateonPlots.Columns.Add(colChk);


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
            comboCol.Name = COL_SURCHARGERATES.OPERATOR;
            grdSurchargeRateonPlots.Columns.Add(comboCol);


            UI.GridFunctions.AddDeleteColumn(grdSurchargeRateonPlots);

            grdSurchargeRateonPlots.ShowGroupPanel = false;
            grdSurchargeRateonPlots.AddNewRowPosition = SystemRowPosition.Bottom;
     

            grdSurchargeRateonPlots.CellBeginEdit += new GridViewCellCancelEventHandler(grdSurchargeRates_CellBeginEdit);
            grdSurchargeRateonPlots.CellEndEdit += GrdSurchargeRates_CellEndEdit;


        }
        public struct COL_SURCHARGERATES
        {
            public static string ID = "Id";
            public static string POLICYID = "POLICYID";
            public static string POSTCODE = "Post Code";


            public static string PERCENTAGE = "PERCENTAGE";
            public static string AMOUNT = "AMOUNT";

            public static string AMOUNTWISE = "AMOUNTWISE";
            public static string TOWNWISE = "TOWNWISE";

            public static string PlotName = "PlotName";

            public static string PlotId = "PlotId";

            public static string PARKING = "PARKING";
            public static string WAITING = "WAITING";

            public static string OPERATOR = "OPERATOR";

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