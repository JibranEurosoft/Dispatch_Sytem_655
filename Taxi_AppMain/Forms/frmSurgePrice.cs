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
using Telerik.WinControls.Enumerations;
using System.Data.Linq;

namespace Taxi_AppMain
{
    public partial class frmSurgePrice : UI.SetupBase
    {

        public frmSurgePrice()
        {
            InitializeComponent();
            InitializeConstructor();
            
            FormatDays();
            LoadZoneGrid();
            LoadGrid();
            DisplayDays();
            ddlSearchType.SelectedIndexChanged += DdlSearchType_SelectedIndexChanged;
            grdSurgeIncreament.CommandCellClick += GrdSurgeIncreament_CommandCellClick;
            grdSurgeIncreament.DoubleClick += GrdSurgeIncreament_DoubleClick;
        }

        private void GrdSurgeIncreament_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdSurgeIncreament.CurrentRow != null && grdSurgeIncreament.CurrentRow is GridViewDataRowInfo)
                {
                    GridViewRowInfo row = grdSurgeIncreament.CurrentRow;

                    if (row.Cells[COLS_.Id].Value.ToInt() > 0)
                    {
                        globalId = row.Cells[COLS_.Id].Value.ToInt();

                        dtpFromDate.Value = row.Cells[COLS_.SurgeFromDateTime].Value.ToDateTime();
                        dtpTillDate.Value = row.Cells[COLS_.SurgeTillDateTime].Value.ToDateTime();
                        numIncrementRate.Value = row.Cells[COLS_.SurgeValue].Value.ToDecimal();
                        ddlSearchType.Text = row.Cells[COLS_.SurgeText].Value.ToStr();
                        string[] SurgePlot = row.Cells[COLS_.ExcludedPlots].Value.ToStr().Trim().Split(',');
                        string[] SurgeDays = row.Cells[COLS_.SurgeDays].Value.ToStr().Trim().Split(',');

                        foreach (var item in SurgePlot)
                        {
                            var attrRow = grdPlot.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToString() == item.ToString());

                            if (attrRow != null)
                            {
                                attrRow.Cells["Check"].Value = true;
                            }
                        }

                       
                        if (row.Cells[COLS_.SurgeCriteriaBy].Value.ToInt() == 4)
                        {
                            grdDayWise.Visible = true;
                            optDayWise.IsChecked = true;

                            foreach (var item in SurgeDays)
                            {
                                var attrRow = grdDayWise.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToString() == item.ToString());

                                if (attrRow != null)
                                {
                                    attrRow.Cells["Check"].Value = true;
                                }
                            }
                        }
                        else if (row.Cells[COLS_.SurgeCriteriaBy].Value.ToInt() == 3)
                        {
                            grdDayWise.Visible = false;
                            optTimeWise.IsChecked = true;

                            chkEnableSurcharge.Checked = true;

                        }
                        else if (row.Cells[COLS_.SurgeCriteriaBy].Value.ToInt() == 2)
                        {
                            grdDayWise.Visible = false;
                            optDateWise.IsChecked = true;
                        }
                        else if (row.Cells[COLS_.SurgeCriteriaBy].Value.ToInt() == 1)
                        {
                            grdDayWise.Visible = false;
                            optDateTimeWise.IsChecked = true;
                        }

                    }



                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GrdSurgeIncreament_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;

                if (gridCell.ColumnInfo.Name == "delete")
                {
                    int id = gridCell.RowInfo.Cells["Id"].Value.ToInt();

                    if (id > 0)
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            
                            var del = db.ExecuteQuery<int>("delete from gen_surgepricing where Id = " + id + "");
                           
                           
                        }
                        
                    }
                    gridCell.RowInfo.Delete();
                    Clear();

                }
               

            }
            catch
            {

            }
        }

        private void GetEnableSurgeData()
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list1 = db.ExecuteQuery<SurgePricing>("select * from Gen_SurgePricing where SurgeText = 'ASAP'").ToList().FirstOrDefault();

                    if (list1 != null)
                    {
                        globalId = list1.Id.ToInt();

                        dtpFromDate.Value = list1.SurgeFromDateTime.Value.ToDateTime();
                        dtpTillDate.Value = list1.SurgeTillDateTime.Value.ToDateTime();
                        numIncrementRate.Value = list1.SurgeValue.Value.ToDecimal();
                        ddlSearchType.Text = list1.SurgeText.ToStr();
                        string[] SurgePlot = list1.ExcludedPlots.ToStr().Trim().Split(',');

                        chkEnableSurcharge.Checked = list1.EnableSurge.ToBool();


                        //foreach (var item in SurgePlot)
                        //{
                        //    var attrRow = grdPlot.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToString() == item.ToString());

                        //    if (attrRow != null)
                        //    {
                        //        attrRow.Cells["Check"].Value = true;
                        //    }


                        //}

                        
                        string[] SurgePlots = list1.ExcludedPlots.ToStr().Trim().Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);

                        int cnt = 0;
                        foreach (var item in SurgePlots)
                        {
                            var Zonelist = General.GetQueryable<Gen_Zone>(c => c.Id == item.ToInt()).ToList().FirstOrDefault();
                            var attrRow = grdPlot.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToString() == item.ToString());
                            string ZoneName = Zonelist.OrderNo + ". " + Zonelist.ZoneName + "[" + Zonelist.ShortName + "]";

                            this.grdPlot.Rows.Remove(attrRow);

                            var row2 = grdPlot.Rows.NewRow();
                            row2.Cells["Id"].Value = item.ToInt();
                            row2.Cells["Check"].Value = true;
                            row2.Cells["ZoneName"].Value = ZoneName;
                            grdPlot.Rows.Insert(cnt, row2);
                            
                            cnt++;
                        }





                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Display()
        {
            try
            {
                optTimeWise.Enabled = true;
                optTimeWise.IsChecked = true;
                optDateTimeWise.Enabled = false;
                optDateWise.Enabled = false;
                optDayWise.Enabled = false;

                chkEnableSurcharge.Visible = true;
                grdDayWise.Visible = false;

                globalId = 0;
                GetEnableSurgeData();

            }
            catch (Exception)
            {

                throw;
            }   
           
        }

        public struct COLS_
        {
            public static string Id = "Id";
            public static string EnableSurge = "EnableSurge";
            public static string SurgeValue = "SurgeValue";
            public static string SurgeFromDateTime = "SurgeFromDateTime";
            public static string SurgeTillDateTime = "SurgeTillDateTime";
            public static string SurgeDays = "SurgeDays";
            public static string ExcludedPlots = "ExcludedPlots";
            public static string SurgeCriteriaBy = "SurgeCriteriaBy";
            public static string SurgeText = "SurgeText";


        }

        public void LoadZoneGrid()       
        {


            GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
            col1.Name = "Check";
            col1.HeaderText = "";
            col1.Width = 40;
            grdPlot.Columns.Add(col1);

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.HeaderText = "Id";
            col.Name = "Id";
            col.IsVisible = false;
            grdPlot.Columns.Add(col);
            
            col = new GridViewTextBoxColumn();
            col.HeaderText = "Plots";
            col.Name = "ZoneName";
            col.IsVisible = true;
            col.Width = 200;
            grdPlot.Columns.Add(col);

            //UI.GridFunctions.SetFilter(grdPlot);
            //grdPlot.MasterTemplate.ShowRowHeaderColumn = false;

            grdPlot.EnableFiltering = true;
            grdPlot.AllowAddNewRow = false;
            grdPlot.ShowGroupPanel = false;


            using (TaxiDataContext db = new TaxiDataContext())
            {
                //var list1 = db.ExecuteQuery<SurgePricing>("select * from Gen_SurgePricing where SurgeText = 'ASAP'").ToList().FirstOrDefault();
                //string[] SurgePlot = row.Cells[COLS_.ExcludedPlots].Value.ToStr().Trim().Split(',');


                var listZone = (from a in General.GetQueryable<Gen_Zone>(c => c.MaxLatitude != null)
                                orderby a.OrderNo
                                select new
                                {
                                    Id = a.Id,
                                    ZoneName = a.OrderNo + ". " + a.ZoneName + "[" + a.ShortName + "]"
                                }).ToList();

                //listZone = listZone.Where(c=> c.listZone.Contains(list1.ExcludedPlots);
                //var sdaf = listZone.Where(c=> list1.Contains(  list1.ExcludedPlots);

                for (int i = 0; i < listZone.Count; i++)
                {
                    grdPlot.Rows.AddNew();
                    grdPlot.Rows[i].Cells["Check"].Value = false;
                    grdPlot.Rows[i].Cells["Id"].Value = listZone[i].Id;
                    grdPlot.Rows[i].Cells["ZoneName"].Value = listZone[i].ZoneName;

                }
            }
               
            
            //grdPlot.AllowEditRow = true;
        }

        private void FormatDays()
        {

            grdDayWise.AllowAddNewRow = false;
            //  grdDayWise.AllowEditRow = false;
            //grdDayWise.AutoCellFormatting = true;
            grdDayWise.ShowGroupPanel = false;

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = "Id";
            col.IsVisible = false;
            grdDayWise.Columns.Add(col);

            GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
            col1.Name = "Check";
            col1.HeaderText = "";
            col1.Width = 40;
            grdDayWise.Columns.Add(col1);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Days";
            col.Name = "Days";
            col.IsVisible = true;
            col.Width = 100;
            grdDayWise.Columns.Add(col);

            grdDayWise.MasterTemplate.ShowRowHeaderColumn = false;

            grdDayWise.AllowEditRow = true;

        }

        public void LoadGrid()
        {
            try
            {

                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.Name = COLS_.Id;
                col.ReadOnly = true;
                col.IsVisible = false;
                grdSurgeIncreament.Columns.Add(col);

                GridViewDateTimeColumn dt = new GridViewDateTimeColumn();
                dt.Name = COLS_.SurgeFromDateTime;
                dt.ReadOnly = true;
                dt.FormatString = "{0:dd/MM/yyyy HH:mm}";
                dt.HeaderText = "From DateTime";
                dt.Width = 100;
                grdSurgeIncreament.Columns.Add(dt);


                dt = new GridViewDateTimeColumn();
                dt.Name = COLS_.SurgeTillDateTime;
                dt.ReadOnly = true;
                dt.FormatString = "{0:dd/MM/yyyy HH:mm}";
                dt.HeaderText = "Till DateTime";
                dt.Width = 100;
                grdSurgeIncreament.Columns.Add(dt);

                col = new GridViewTextBoxColumn();
                col.Name = COLS_.SurgeValue;
                col.ReadOnly = true;
                col.HeaderText = "Value";
                col.Width = 70;
                grdSurgeIncreament.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COLS_.SurgeDays;
                col.IsVisible = false;
                col.Width = 100;
                grdSurgeIncreament.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COLS_.ExcludedPlots;
                col.IsVisible = false;
                col.Width = 100;
                grdSurgeIncreament.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COLS_.SurgeCriteriaBy;
                col.IsVisible = false;
                col.Width = 100;
                grdSurgeIncreament.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COLS_.SurgeText;
                col.HeaderText = "Type";
                col.IsVisible = true;
                col.Width = 100;
                grdSurgeIncreament.Columns.Add(col);

                GridViewCommandColumn col2 = new GridViewCommandColumn();
                col2.Width = 60;
                col2.Name = "delete";
                col2.UseDefaultText = true;
                col2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                col2.DefaultText = "Delete";
                col2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                grdSurgeIncreament.Columns.Add(col2);

               

                UI.GridFunctions.SetFilter(grdSurgeIncreament);

                grdSurgeIncreament.AllowEditRow = true;
                grdSurgeIncreament.AllowAutoSizeColumns = true;
                grdSurgeIncreament.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdSurgeIncreament.ShowGroupPanel = false;
                grdSurgeIncreament.ShowFilteringRow = false;

                grdSurgeIncreament.ShowRowHeaderColumn = false;

                grdSurgeIncreament.CurrentRow = null;
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }

        private void DisplayDays()
        {
            try
            {
                grdDayWise.RowCount = 7;

                grdDayWise.Rows[0].Cells["Id"].Value = "1";
                grdDayWise.Rows[1].Cells["Id"].Value = "2";
                grdDayWise.Rows[2].Cells["Id"].Value = "3";
                grdDayWise.Rows[3].Cells["Id"].Value = "4";
                grdDayWise.Rows[4].Cells["Id"].Value = "5";
                grdDayWise.Rows[5].Cells["Id"].Value = "6";
                grdDayWise.Rows[6].Cells["Id"].Value = "7";

                grdDayWise.Rows[0].Cells["Days"].Value = "Sun";
                    grdDayWise.Rows[1].Cells["Days"].Value = "Mon";
                    grdDayWise.Rows[2].Cells["Days"].Value = "Tues";
                    grdDayWise.Rows[3].Cells["Days"].Value = "Wed";
                    grdDayWise.Rows[4].Cells["Days"].Value = "Thurs";
                    grdDayWise.Rows[5].Cells["Days"].Value = "Fri";
                    grdDayWise.Rows[6].Cells["Days"].Value = "Sat";
                

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void DdlSearchType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlSearchType.Text == "ASAP")
            {
                Display();
                
            }
            else
            {
                optDateTimeWise.Enabled = true;
                optDateWise.Enabled = true;
                optDayWise.Enabled = true;
                optTimeWise.Enabled = false;

                optDateTimeWise.IsChecked = true;

                chkEnableSurcharge.Visible = false;
                Clear();
            }
            
        }

        private void InitializeConstructor()
        {


            this.Load += new EventHandler(frmFareIncrement_Load);
            this.FormClosed += new FormClosedEventHandler(frmLocations_FormClosed);

           // this.ddlIncrementType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlIncrementType_SelectedIndexChanged);


        }

       
        private void PopulateData()
        {

            using (TaxiDataContext db = new TaxiDataContext())
            {

                //GetEnableSurgeData();

                var list = db.ExecuteQuery<SurgePricing>("select * from Gen_SurgePricing").ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    grdSurgeIncreament.Rows.AddNew();
                    grdSurgeIncreament.Rows[i].Cells[COLS_.Id].Value = list[i].Id;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeFromDateTime].Value = list[i].SurgeFromDateTime;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeTillDateTime].Value = list[i].SurgeTillDateTime;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeValue].Value = list[i].SurgeValue;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeDays].Value = list[i].SurgeDays;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeCriteriaBy].Value = list[i].SurgeCriteriaBy;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.ExcludedPlots].Value = list[i].ExcludedPlots;
                    grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeText].Value = list[i].SurgeText;
                }

            }
           
        }

       
        void frmFareIncrement_Load(object sender, EventArgs e)
        {
            Display();
            PopulateData();
            
        }

        private void DisplaySettings()
        {
            var obj = General.GetObject<Fare_IncrementSetting>(c => c.Id != 0);

            if (obj != null)
            {
                chkEnableSurcharge.Checked = obj.EnableIncrement.ToBool();
                dtpFromDate.Value = obj.FromDate;
                dtpTillDate.Value = obj.TillDate;

               //ddlIncrementType.Text = obj.IncrementType.ToStr().Trim().ToProperCase();
                numIncrementRate.Value = obj.IncrementRate.ToDecimal();

                if (obj.CriteriaBy.ToInt() == 1)
                {
                    optDateTimeWise.ToggleState = ToggleState.On;
                }
                else if (obj.CriteriaBy.ToInt() == 2)
                {
                    optDateWise.ToggleState = ToggleState.On;
                }
                else if (obj.CriteriaBy.ToInt() == 3)
                {
                    optTimeWise.ToggleState = ToggleState.On;
                }

            }

        }

        void frmLocations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
            }
        }


        void frmLocations_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {

                this.Close();
            }
        }

        private bool SaveSettings()
        {
            bool rtn = false;

            try
            {
                //if (dtpFromDate.Value == null)
                //{
                //	ENUtils.ShowMessage("Required : From Date");
                //	return rtn;

                //}

                //if (dtpTillDate.Value == null)
                //{
                //	ENUtils.ShowMessage("Required : Till Date");
                //	return rtn;

                //}


                //if (dtpFromDate.Value.ToDate() > dtpTillDate.Value.ToDate())
                //{
                //	ENUtils.ShowMessage("Required : From Date must be less than Till Date");
                //	return rtn;

                //}


                //string criteriaBy = ddlIncrementType.Text.Trim().ToLower();

                //if (optDateTimeWise.ToggleState == ToggleState.On)
                //	criteriaBy += "=1";
                //else if (optDateWise.ToggleState == ToggleState.On)
                //	criteriaBy += "=2";
                //else if (optTimeWise.ToggleState == ToggleState.On)
                //	criteriaBy += "=3";


                using (TaxiDataContext db = new TaxiDataContext())
                {
                    List<int> Ids = grdSurgeIncreament.Rows.Select(callnotification => Convert.ToInt32(callnotification.Cells["Id"].Value)).ToList();
                    string query = string.Empty;

                    //if (chkEnableSurcharge.Checked == false && ddlSearchType.Text == "ASAP")
                    //{
                    //    if (globalId > 0)
                    //    {

                    //        var del = db.ExecuteQuery<int>("delete from gen_surgepricing where Id = " + globalId + "");
                    //        grdSurgeIncreament.CurrentRow.Delete();
                    //        Clear();

                    //    }
                    //}
                    //else
                    //{

                        Add();

                        for (int i = 0; i < grdSurgeIncreament.Rows.Count; i++)
                        {

                            int id = grdSurgeIncreament.Rows[i].Cells["Id"].Value.ToInt();
                                               
                        
                            DateTime FromDateTime = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeFromDateTime].Value.ToDateTime();
                            DateTime TillDateTime = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeTillDateTime].Value.ToDateTime();
                            decimal surgeValue = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeValue].Value.ToDecimal();
                            int enableSurcharge = 0;


                            if (chkEnableSurcharge.Checked)
                            {
                                enableSurcharge = 1;
                            }
                            else
                            {
                                enableSurcharge = 0;
                            }

                        
                            string surgeDays = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeDays].Value.ToString();
                            string surgePlots = grdSurgeIncreament.Rows[i].Cells[COLS_.ExcludedPlots].Value.ToString();
                            string surgetext = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeText].Value.ToString();

                            int surgeCriteriaBy = grdSurgeIncreament.Rows[i].Cells[COLS_.SurgeCriteriaBy].Value.ToInt();
                        
                            if (id > 0)
                            {
                                query = "Update gen_surgepricing set EnableSurge = " + enableSurcharge + " ,SurgeValue =" + surgeValue + " ,SurgeText='" + surgetext + "',SurgeFromDateTime='" + FromDateTime.ToDateTime().ToString("yyyy-MM-dd HH:mm") + "'" +
                                   ",SurgeTillDateTime='" + TillDateTime.ToDateTime().ToString("yyyy-MM-dd HH:mm") + "',SurgeDays='" + surgeDays + "',ExcludedPlots='" + surgePlots + "',SurgeCriteriaBy=" + surgeCriteriaBy + " where Id = "+id+" ";
                               
                            }
                            else
                            { 
                                 query = "insert into gen_surgepricing (EnableSurge,SurgeValue,SurgeType,SurgeText,SurgeFromDateTime,SurgeTillDateTime,SurgeDays,ExcludedPlots,SurgeCriteriaBy) " +
                                    "values (" + enableSurcharge + "," + surgeValue + ",null,'" + surgetext + "','" + FromDateTime.ToDateTime().ToString("yyyy-MM-dd HH:mm") + "','" + TillDateTime.ToDateTime().ToString("yyyy-MM-dd HH:mm") + "','" + surgeDays + "','" + surgePlots + "'," + surgeCriteriaBy + ")";
                           
                            }
                            db.ExecuteCommand(query);
                            //if (objFare.Id == 0)
                            //    db.Fare_IncrementSettings.InsertOnSubmit(objFare);

                            //  db.SubmitChanges();


                        }

                    Clear();

                   // }
                }


                return true;
            }
            //db.stp_SaveFareIncrementSettings(dtpFromDate.Value, dtpTillDate.Value, criteriaBy, numIncrementRate.Value.ToDecimal(), chkEnableIncrement.Checked);

            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }


            return rtn;

        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            if (args.ToggleState == ToggleState.On)
            {
                dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
                dtpTillDate.CustomFormat = "dd/MM/yyyy HH:mm";

                dtpFromDate.ShowUpDown = false;
                dtpTillDate.ShowUpDown = false;

                for (int i = 0; i < grdDayWise.Rows.Count; i++)
                {
                    grdDayWise.Rows[i].Cells["Check"].Value = false;
                }

                grdDayWise.Visible = false;
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

                for (int i = 0; i < grdDayWise.Rows.Count; i++)
                {
                    grdDayWise.Rows[i].Cells["Check"].Value = false;
                }

                grdDayWise.Visible = false;
            }
        }

        private void optTimeWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {


                dtpFromDate.ShowUpDown = true;
                dtpTillDate.ShowUpDown = true;

                dtpFromDate.CustomFormat = "HH:mm";
                dtpTillDate.CustomFormat = "HH:mm";

                grdDayWise.Visible = false;
            }
        }

        int globalId = 0;

        private void Add()
        {
            try
            {

                if (dtpFromDate.DateTimePickerElement.Value == null)
                {
                    ENUtils.ShowMessage("Required : From Date");
                    return;

                }

                if (dtpTillDate.DateTimePickerElement.Value == null)
                {
                    ENUtils.ShowMessage("Required : Till Date");
                    return;

                }


                //if (dtpFromDate.DateTimePickerElement.Value.ToDate() > dtpTillDate.DateTimePickerElement.Value.ToDate())
                //{
                //    ENUtils.ShowMessage("Required : From Date must be less than Till Date");
                //    return;

                //}

                string dtfromTime = dtpFromDate.DateTimePickerElement.Value.ToString();
                string dtTillTime = dtpTillDate.DateTimePickerElement.Value.ToString();

                int criteriaby = 0;

                if (optDateTimeWise.ToggleState == ToggleState.On)
                {
                    criteriaby = 1;
                }
                else if (optDateWise.ToggleState == ToggleState.On)
                {
                    criteriaby = 2;
                }
                else if (optTimeWise.ToggleState == ToggleState.On)
                {
                    criteriaby = 3;
                }
                else if (optDayWise.ToggleState == ToggleState.On)
                {
                    criteriaby = 4;
                }
                //dtfromTime =  dtfromTime.ToDateTime();
                //dtTillTime =  dtTillTime.ToDateTime();



                string Days = string.Empty;
                for (int i = 0; i < grdDayWise.Rows.Count; i++)
                {
                    if (grdDayWise.Rows[i].Cells["Check"].Value.ToBool() == true)
                    {
                        Days += grdDayWise.Rows[i].Cells["Id"].Value.ToInt() + ",";
                    }
                }
                Days = Days.Trim(',');


                string Zones = string.Empty;
                for (int i = 0; i < grdPlot.Rows.Count; i++)
                {
                    if (grdPlot.Rows[i].Cells["Check"].Value.ToBool() == true)
                    {
                        Zones += grdPlot.Rows[i].Cells["Id"].Value.ToInt() + ",";
                    }
                }

                if (Zones.ToStr().Trim().Length > 0)
                    Zones = "," + Zones;
              
                GridViewRowInfo row = null;

                //if (ddlSearchType.Text == "ASAP")
                //{
                //    using (TaxiDataContext db = new TaxiDataContext())
                //    {
                //        var list = grdSurgeIncreament.Rows.Where(c => c.Cells[COLS_.SurgeText].Value.ToString() == "ASAP").ToList();   //  db.ExecuteQuery<SurgePricing>("select * from Gen_SurgePricing where EnableSurge = 1").ToList().FirstOrDefault();
                //        if (list.Count > 0)
                //        {
                //            ENUtils.ShowMessage("Time Wise Data has already inserted");
                //            return;
                //        }
                
                
                
                
                //   }
                //}


                //if (ddlSearchType.Text == "ASAP" && chkEnableSurcharge.Checked == false)
                //{
                //    ENUtils.ShowMessage("Enable Surcharge Should be selecsted");
                //    return;
                //}


                if (globalId == 0)
                {
                    row = grdSurgeIncreament.Rows.AddNew();
                    row.Cells[COLS_.Id].Value = 0;
                    row.Cells[COLS_.SurgeValue].Value = numIncrementRate.Value.ToDecimal();
                    row.Cells[COLS_.SurgeFromDateTime].Value = Convert.ToDateTime(dtfromTime);
                    row.Cells[COLS_.SurgeTillDateTime].Value = Convert.ToDateTime(dtTillTime);
                    row.Cells[COLS_.ExcludedPlots].Value = Zones;
                    row.Cells[COLS_.SurgeDays].Value = Days;
                    row.Cells[COLS_.SurgeCriteriaBy].Value = criteriaby;
                    row.Cells[COLS_.SurgeText].Value = ddlSearchType.Text;
                }
                else
                {

                    grdSurgeIncreament.CurrentRow.Cells[COLS_.Id].Value = globalId;
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeValue].Value = numIncrementRate.Value.ToDecimal();
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeFromDateTime].Value = Convert.ToDateTime(dtfromTime);
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeTillDateTime].Value = Convert.ToDateTime(dtTillTime);
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.ExcludedPlots].Value = Zones;
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeDays].Value = Days;
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeCriteriaBy].Value = criteriaby;
                    grdSurgeIncreament.CurrentRow.Cells[COLS_.SurgeText].Value = ddlSearchType.Text;
                }


                Clear();


                grdSurgeIncreament.CurrentRow = null;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Clear()
        {
            numIncrementRate.Value = 1;
            dtpFromDate.Value = null;
            dtpTillDate.Value = null;

            for (int i = 0; i < grdPlot.Rows.Count; i++)
            {
                grdPlot.Rows[i].Cells["Check"].Value = false;
            }
            for (int i = 0; i < grdDayWise.Rows.Count; i++)
            {
                grdDayWise.Rows[i].Cells["Check"].Value = false;
            }
            globalId = 0;
        }

        private void chkEnableIncrement_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            
        }

        private void optDayWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {

                dtpFromDate.ShowUpDown = true;
                dtpTillDate.ShowUpDown = true;

                grdDayWise.Visible = true;

                dtpFromDate.CustomFormat = "HH:mm";
                dtpTillDate.CustomFormat = "HH:mm";

                dtpFromDate.Value = DateTime.Now.ToDateTime();
                
               // dtpTillDate.Value =  TimeSpan.Parse("23:59").ToString() ;

            }

            
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

	public class SurgePricing
	{
    public int Id;

    public System.Nullable<bool> EnableSurge;

    public System.Nullable<decimal> SurgeValue;

    public System.Nullable<int> SurgeType;

    public string SurgeText;

    public System.Nullable<System.DateTime> SurgeFromDateTime;

    public System.Nullable<System.DateTime> SurgeTillDateTime;

    public string SurgeDays;

    public string ExcludedPlots;

    public System.Nullable<int> SurgeCriteriaBy;

}



