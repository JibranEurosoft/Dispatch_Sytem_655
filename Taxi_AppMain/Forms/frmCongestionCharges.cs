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
    public partial class frmCongestionCharges : UI.SetupBase
    {
        SysPolicyBO objMaster;
        public frmCongestionCharges()
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

     

        public override void Save()
        {
            try
            {

                if (objMaster.Current != null)
                {
                   

                   string[] skipProperties = new string[] { "Gen_SysPolicy", "Fleet_VehicleType" };
                    
                    DateTime NullDate = new DateTime(1900, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToDate();

                    DateTime NullDate2 = new DateTime(2040, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToDate();

                    IList<Gen_SysPolicy_CongestionCharge> savedListRatesZone = objMaster.Current.Gen_SysPolicy_CongestionCharges;
                    List<Gen_SysPolicy_CongestionCharge> listRatesZone = (from a in grdCongestionCharges.Rows
                                                                       select new Gen_SysPolicy_CongestionCharge
                                                                       {
                                                                           Id = a.Cells[COL_CONGESTIONCHARGES.ID].Value.ToInt(),
                                                                           SysPolicyId = objMaster.Current.Id,
                                                                           
                                                                           ZoneId = a.Cells[COL_CONGESTIONCHARGES.PlotId].Value.ToIntorNull(),
                                                                          
                                                                           IsDayWise = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool(),
                                                                           Amount = a.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value.ToDecimal(),
                                                                           FromDay = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool() == true ? a.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value.ToString() : null,
                                                                           TillDay = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool() == true ? a.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value.ToString() : null,

                                                                           FromDateTime = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool() != true ?
                                                                                          (a.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value.ToDateorNull() != null ?
                                                                                          (string.Format("{0:dd/MM/yyyy HH:mm}", a.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value.ToDateorNull() + Convert.ToDateTime(a.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value).TimeOfDay).ToDateTime())
                                                                                                                                                : NullDate + Convert.ToDateTime(a.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value).TimeOfDay).ToDateTime() : (string.Format("{0:dd/MM/yyyy HH:mm}", (NullDate + a.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value.ToDateTime().TimeOfDay).ToDateTime())).ToDateTime(),
                                                                         

                                                                           TillDateTime = a.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool() != true ?
                                                                                          (a.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value.ToDateorNull() != null ?
                                                                                          (string.Format("{0:dd/MM/yyyy HH:mm}", a.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value.ToDateorNull() + Convert.ToDateTime(a.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value).TimeOfDay).ToDateTime())
                                                                                                                                                : NullDate2 + Convert.ToDateTime(a.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value).TimeOfDay).ToDateTime() : (string.Format("{0:dd/MM/yyyy HH:mm}", (NullDate + a.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value.ToDateTime().TimeOfDay).ToDateTime())).ToDateTime(),

                                                                       }).ToList();

                    Utils.General.SyncChildCollection(ref savedListRatesZone, ref listRatesZone, "Id", skipProperties);

                  
                    objMaster.Save();



                    try
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.ExecuteQuery<int>("delete from Gen_SysPolicy_CongestionCharges where SysPolicyId is null");
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
           // grdSurchargeRates.Rows.Clear();
            grdCongestionCharges.Rows.Clear();

            var list = objMaster.Current.Gen_SysPolicy_CongestionCharges.ToList();

            var list2 = (from a in list
                         join b in new TaxiDataContext().Gen_Zones on a.ZoneId equals b.Id
                         where a.SysPolicyId != null
                         orderby b.ZoneName
                         select new
                         {
                             a.Id,
                             a.SysPolicyId,                           
                             a.IsDayWise,
                             a.Amount,                            
                             a.ZoneId,                           
                             a.FromDateTime,
                             a.TillDateTime,
                             a.FromDay,
                             a.TillDay,
                      
                         }).ToList();


            var postcodeList = list.Where(x => x.ZoneId == null).ToList();

            int cntP = 0;
            grdCongestionCharges.RowCount = postcodeList.Count;
            // foreach (var item in objMaster.Current.Gen_SysPolicy_SurchargeRates)
            foreach (var item in postcodeList)
            {
                GridViewRowInfo row = grdCongestionCharges.Rows[cntP];
                row.Cells[COL_CONGESTIONCHARGES.ID].Value = item.Id;
                row.Cells[COL_CONGESTIONCHARGES.POLICYID].Value = item.SysPolicyId;

                row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value = item.IsDayWise.ToBool();
                row.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value = item.Amount.ToDecimal();
                if (item.FromDay != null)
                {
                    row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = item.FromDay.ToString();
                    row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = item.TillDay.ToString();
                }
                if (item.FromDateTime.ToDateTime() !=null)
                {
                    row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = item.FromDateTime.ToDateTime();
                    row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = item.TillDateTime.ToDateTime();

                    row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = item.FromDateTime.ToDateTime();
                    row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = item.TillDateTime.ToDateTime();
                }
                

                cntP++;
            }
            

            var list3 = list2.Where(x => x.ZoneId != null).ToList();
            grdCongestionCharges.RowCount = list3.Count;
            int cnt = 0;
            foreach (var item in list3)
            {
                GridViewRowInfo row = grdCongestionCharges.Rows[cnt];
                row.Cells[COL_CONGESTIONCHARGES.ID].Value = item.Id;
                row.Cells[COL_CONGESTIONCHARGES.POLICYID].Value = item.SysPolicyId;
                row.Cells[COL_CONGESTIONCHARGES.PlotId].Value = item.ZoneId.ToInt();
              
                row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value = item.IsDayWise.ToBool();
               
                row.Cells[COL_CONGESTIONCHARGES.AMOUNT].Value = item.Amount.ToDecimal();
                if (item.FromDay !=null)
                {
                    row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = item.FromDay.ToString();
                    row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = item.TillDay.ToString();
                }


                if (item.FromDateTime.ToDateTime() != null && item.FromDateTime.ToDateTime().ToLongDateString() != "01/01/1900")
                {
                    row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = item.FromDateTime.ToDateTime();
                    row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = item.TillDateTime.ToDateTime();

                    row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = item.FromDateTime.ToDateTime();
                    row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = item.TillDateTime.ToDateTime();
                }
                else
                {
                    row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = null;
                    row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = null;

                    row.Cells[COL_CONGESTIONCHARGES.FROMTIME].Value = item.FromDateTime.ToDateTime();
                    row.Cells[COL_CONGESTIONCHARGES.TILLTIME].Value = item.TillDateTime.ToDateTime();
                }

                cnt++;
            }

            
        }
        private void FormatSurchargeRateGrid()
        {

            
          
        }

        private void grdSurchargeRates_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column != null)
            {

                bool IsDayWise = e.Row.Cells[COL_CONGESTIONCHARGES.DAYWISE].Value.ToBool();

                if (IsDayWise && (e.Column.Name == COL_CONGESTIONCHARGES.FROMDATE || e.Column.Name == COL_CONGESTIONCHARGES.TILLDATE ))
                {
                    e.Cancel = true;

                }

                if (IsDayWise == false && ( e.Column.Name == COL_CONGESTIONCHARGES.FROMDAY || e.Column.Name == COL_CONGESTIONCHARGES.TILLDAY))
                {
                    e.Cancel = true;

                }

               
                    

            }
        }

        private void GrdSurchargeRates_CellEndEdit(object sender, GridViewCellEventArgs e)
        {


            if (e.Column.Name==COL_CONGESTIONCHARGES.DAYWISE  )
            {



                if (e.Value.ToBool() == true)
                {
                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].ReadOnly = false;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].Value = null;

                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].ReadOnly = true;


                }
                else
                {
                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDATE].ReadOnly = false;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDATE].ReadOnly = false;


                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].ReadOnly = true;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].ReadOnly = true;


                    e.Row.Cells[COL_CONGESTIONCHARGES.FROMDAY].Value = null;
                    e.Row.Cells[COL_CONGESTIONCHARGES.TILLDAY].Value = null;

                }


            }
            else
            {             


               
            }
        }

        private void FormatSurchargeRateOnPlotsGrid()
        {

            grdCongestionCharges.ShowGroupPanel = false;
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_CONGESTIONCHARGES.ID;
            grdCongestionCharges.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_CONGESTIONCHARGES.POLICYID;
            grdCongestionCharges.Columns.Add(col);

           
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

            grdCongestionCharges.Columns.Add(colCombo);

        


            GridViewCheckBoxColumn colChk = new GridViewCheckBoxColumn();
            colChk.HeaderText = "Day Wise";
            colChk.Width = 70;
            colChk.Name = COL_CONGESTIONCHARGES.DAYWISE;
            grdCongestionCharges.Columns.Add(colChk);


            colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 80;
            colCombo.Name = COL_CONGESTIONCHARGES.FROMDAY;
            colCombo.HeaderText = "From Day";
            // colCombo.DataSource = Program.dtCombos.Tables[2].Copy();
            colCombo.DataSource = General.GetWeekDays();
            colCombo.DisplayMember = "Name";
            colCombo.ValueMember = "Name";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdCongestionCharges.Columns.Add(colCombo);


            colCombo = new GridViewComboBoxColumn();
            colCombo.Width = 80;
            colCombo.Name = COL_CONGESTIONCHARGES.TILLDAY;
            colCombo.HeaderText = "Till Day";
            // colCombo.DataSource = Program.dtCombos.Tables[2].Copy();
            colCombo.DataSource = General.GetWeekDays();
            colCombo.DisplayMember = "Name";
            colCombo.ValueMember = "Name";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdCongestionCharges.Columns.Add(colCombo);

            GridViewDateTimeColumn dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.FROMDATE;
            dtcol.HeaderText = "From Date";
            dtcol.CustomFormat = "dd/MM/yyyy";
            dtcol.FormatString = "{0:dd/MM/yyyy}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 90;
            grdCongestionCharges.Columns.Add(dtcol);


            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.FROMTIME;
            dtcol.HeaderText = "From Time";
            dtcol.CustomFormat = "HH:mm";
            dtcol.FormatString = "{0:HH:mm}";
            dtcol.Width = 85;
            dtcol.Format = DateTimePickerFormat.Custom;
            grdCongestionCharges.Columns.Add(dtcol);

            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.TILLDATE;
            dtcol.HeaderText = "Till Date";
            dtcol.CustomFormat = "dd/MM/yyyy";
            dtcol.FormatString = "{0:dd/MM/yyyy}";
            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 90;
            grdCongestionCharges.Columns.Add(dtcol);


            dtcol = new GridViewDateTimeColumn();
            dtcol.Name = COL_CONGESTIONCHARGES.TILLTIME;
           
            dtcol.HeaderText = "Till Time";
            dtcol.FormatString = "{0:HH:mm}";
            dtcol.CustomFormat = "HH:mm";

            dtcol.Format = DateTimePickerFormat.Custom;
            dtcol.Width = 85;
            grdCongestionCharges.Columns.Add(dtcol);


            GridViewDecimalColumn col2 = new GridViewDecimalColumn();
            col2.HeaderText = "Amount";
            col2.Width = 70;
            col2.Maximum = 60;
            col2.Name = COL_CONGESTIONCHARGES.AMOUNT;

            grdCongestionCharges.Columns.Add(col2);


            GridViewCommandColumn cmd = new GridViewCommandColumn();
            cmd.Width = 70;
            cmd.Name = "btnDelete";
            cmd.UseDefaultText = true;
            cmd.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            cmd.DefaultText = "Delete";
            cmd.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdCongestionCharges.Columns.Add(cmd);

            grdCongestionCharges.ShowGroupPanel = false;
            grdCongestionCharges.AddNewRowPosition = SystemRowPosition.Bottom;


            grdCongestionCharges.CellBeginEdit += new GridViewCellCancelEventHandler(grdSurchargeRates_CellBeginEdit);
            grdCongestionCharges.CellEndEdit += GrdSurchargeRates_CellEndEdit;
            grdCongestionCharges.CommandCellClick += GrdCongestionCharges_CommandCellClick;


        }

        private void GrdCongestionCharges_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
                {
                    
                        //int Id = grdCongestionCharges.CurrentRow.Cells[COL_CONGESTIONCHARGES.ID].Value.ToInt();
                        //if (Id > 0)
                        //{
                        //    using (TaxiDataContext db = new TaxiDataContext())
                        //    {
                        //        var query = db.Gen_SysPolicy_CongestionCharges.FirstOrDefault(c => c.Id == Id);
                        //        db.Gen_SysPolicy_CongestionCharges.DeleteOnSubmit(query);
                        //        db.SubmitChanges();
                        //    }
                        //}
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