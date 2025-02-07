using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Taxi_Model;
using Taxi_BLL;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.IO;
using Taxi_AppMain.Classes;
using Microsoft.Reporting.WinForms;
using Telerik.WinControls.UI.Docking;

namespace Taxi_AppMain
{
    public partial class frmJobStatisticsReport : UI.SetupBase
    {
        public frmJobStatisticsReport()
        {
            InitializeComponent();
            this.Load += new EventHandler(rptfrmJobStatisticsReport_Load);
        }

        void rptfrmJobStatisticsReport_Load(object sender, EventArgs e)
        {
            FormatGrid();
            DefaultDate();
            FillCombo();
            ShowSearchType();
            

        }
        public struct COLS
        {
            public static string BookingNo = "Booking No";
            public static string PickupDateTime = "PickupDateTime";
            public static string VehicleType = "VehicleType";
            public static string FromAddress = "FromAddress";
            public static string ToAddress = "ToAddress";
            public static string DriverName = "DriverName";
            public static string StatusName = "StatusName";
        }
        public void FormatGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.BookingNo;
            col.HeaderText = "Booking No";
            col.Width = 150;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.PickupDateTime;
            col.HeaderText = "Pickup Date Time";
            col.Width = 145;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.VehicleType;
            col.HeaderText = "Vehicle Type";
            col.Width = 130;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.FromAddress;
            col.HeaderText = "From Address";
            col.Width = 280;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.ToAddress;
            col.HeaderText = "To Address";
            col.Width = 280;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverName;
            col.HeaderText = "Driver Name";
            col.Width = 130;
            grdJobsStatistics.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLS.StatusName;
            col.HeaderText = "Status";
            col.Width = 130;
            grdJobsStatistics.Columns.Add(col);
        }
        public override void PopulateData()
        {
            try
            {
                string FromPostCode = string.Empty;
                string ToPostCode = string.Empty;
                string locationName = string.Empty;
                int FromLocId = 0;
                int ToLocId = 0;
                int FromZoneId = 0;
                int ToZoneId = 0;
                string customerName = string.Empty;
             
                int AccountId = 0;


                if (rbtnPostCode.IsChecked == true)
                {
                    string PostCode = txtPostCode.Text.Trim();
                    if (string.IsNullOrEmpty(PostCode))
                    {
                        ENUtils.ShowMessage("Requierd : Post Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromPostCode = PostCode;
                    }
                    else if(rbtnDestination.IsChecked==true)
                    {
                        ToPostCode = PostCode;
                    }
                    else
                    {
                        FromPostCode = PostCode;
                        ToPostCode = PostCode;
                    }
                }
                else if (rbtnLocation.IsChecked == true)
                {
                    int LocationId = 0;

                    if (ddlLocationType.Text == "Default")
                    {
                        LocationId = ddlLocation.SelectedValue.ToInt();
                        locationName = ddlLocation.Text;
                       
                    }
                    else
                    {
                        LocationId = ddlNewLocations.SelectedValue.ToInt();
                        locationName = ddlNewLocations.Text;
                    }
                    

                    if (LocationId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Loaction Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromLocId = LocationId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToLocId = LocationId;
                    }
                    else
                    {
                        ToLocId = LocationId;
                        FromLocId = LocationId;
                    }
                }              
                else
                {
                    int ZoneId = ddlArea.SelectedValue.ToInt();
                    if (ZoneId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Area Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromZoneId = ZoneId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToZoneId = ZoneId;
                    }
                    else
                    {
                        FromZoneId = ZoneId;
                        ToZoneId = ZoneId;
                    }
                }


                if (rbtCustomer.IsChecked == true)
                {

                    customerName = txtCustomerName.Text;
                  
                }
                else if (rbtAccount.IsChecked == true)
                {

                    AccountId = ddlAccount.SelectedValue.ToInt();
                    if (AccountId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Account");
                        return;
                    }

                }

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    //var list =    db.stp_JobStatistics(FromPostCode,ToPostCode,FromLocId,ToLocId,FromZoneId,ToZoneId,fromDate.Value.ToDate(),tillDate.Value.ToDate()).ToList();
                    var list = db.ExecuteQuery<Stp_JobStatistics>("exec stp_JobStatistics1 {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", FromPostCode, ToPostCode, FromLocId, ToLocId, FromZoneId, ToZoneId, fromDate.Value.ToDate(), tillDate.Value.ToDateTime(), customerName,  AccountId, locationName).ToList();
                    
                    //db.ExecuteQuery<int>("exec stp_UpdateJobEnd {0},{1},{2},{3},{4},{5},{6}", _JobId, _DriverId, JobStatusId.ToIntorNull(), DriverStatusId.ToIntorNull(), -1, "", "-1");
                    if (list.Count() > 0)
                    {
                        grdJobsStatistics.Columns.Clear();
                        grdJobsStatistics.DataSource = list;
                        grdJobsStatistics.Columns["BookingNo"].Width = 150;
                        grdJobsStatistics.Columns["PickupDateTime"].Width = 145;
                        grdJobsStatistics.Columns["VehicleType"].Width = 130;
                        grdJobsStatistics.Columns["FromAddress"].Width = 280;
                        grdJobsStatistics.Columns["ToAddress"].Width = 280;
                        grdJobsStatistics.Columns["DriverName"].Width = 130;
                        grdJobsStatistics.Columns["StatusName"].Width = 130;
                        grdJobsStatistics.Columns["BookingNo"].HeaderText = "Booking No";
                        grdJobsStatistics.Columns["PickupDateTime"].HeaderText = "Pickup Date Time";
                        grdJobsStatistics.Columns["VehicleType"].HeaderText = "Vehicle Type";
                        grdJobsStatistics.Columns["FromAddress"].HeaderText = "From Address";
                        grdJobsStatistics.Columns["ToAddress"].HeaderText = "To Address";
                        grdJobsStatistics.Columns["DriverName"].HeaderText = "Driver Name";
                        grdJobsStatistics.Columns["StatusName"].HeaderText = "Status";

                    }
                    else
                    {
                        grdJobsStatistics.Columns.Clear();
                        grdJobsStatistics.Rows.Clear();
                        FormatGrid();
                    }
                    lblTotalJobs.Text = "Total Jobs : " + grdJobsStatistics.Rows.Count();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        private void DefaultDate()
        {
            fromDate.Value = DateTime.Now.ToDate().AddDays(-7); ;
            tillDate.Value = DateTime.Now.ToDate() + new TimeSpan(23, 59, 59);
        }
        private void FillCombo()
        {
            ComboFunctions.FillFullLocationsCombo(ddlLocation);
            ComboFunctions.FillZonesCombo(ddlArea);
            ComboFunctions.FillCompanyCombo(ddlAccount);
            ComboFunctions.FillNewLocationCombo(ddlNewLocations);
          
        }

     
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnLocation_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowSearchType();
        }

        private void rbtnArea_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowSearchType();
        }

        private void rbtnPostCode_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowSearchType();   
        }
        private void ShowSearchType()
        {
            if (rbtnPostCode.IsChecked == true)
            {
                lblSearchType.Text = "Post Code";
                txtPostCode.BringToFront();
                ddlLocationType.Visible = false;
            }
            else if (rbtnLocation.IsChecked == true)
            {
                lblSearchType.Text = "Location";
                ddlLocation.BringToFront();
                ddlLocationType.Visible = true;
                ddlLocationType.Text = "Default";
            }
            else
            {
                lblSearchType.Text = "Area";
                ddlArea.BringToFront();
                ddlLocationType.Visible = false;
            }

            if (rbtCustomer.IsChecked == true)
            {
                lblCustomer.Text = "Customer";
                txtCustomerName.Visible = true;
                txtCustomerName.BringToFront();
            }
            else if (rbtAccount.IsChecked == true)
            {
                lblCustomer.Text = "Account";
                ddlAccount.BringToFront();
                txtCustomerName.Visible = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string FromPostCode = string.Empty;
                string ToPostCode = string.Empty;
                string locationName = string.Empty;
                
                int FromLocId = 0;
                int ToLocId = 0;
                int FromZoneId = 0;
                int ToZoneId = 0;
                string customerName = string.Empty;
                int AccountId = 0;

                if (rbtnPostCode.IsChecked == true)
                {
                    string PostCode = txtPostCode.Text.Trim();
                    if (string.IsNullOrEmpty(PostCode))
                    {
                        ENUtils.ShowMessage("Requierd : Post Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromPostCode = PostCode;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToPostCode = PostCode;
                    }
                    else
                    {
                        FromPostCode = PostCode;
                        ToPostCode = PostCode;
                    }
                }
                else if (rbtnLocation.IsChecked == true)
                {
                    int LocationId = 0;

                    if (ddlLocationType.Text == "Default")
                    {
                        LocationId = ddlLocation.SelectedValue.ToInt();
                        locationName = ddlLocation.Text;
                        
                    }
                    else
                    {
                        LocationId = ddlNewLocations.SelectedValue.ToInt();
                        locationName = ddlNewLocations.Text;
                    }
                    if (LocationId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Loaction Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromLocId = LocationId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToLocId = LocationId;
                    }
                    else
                    {
                        ToLocId = LocationId;
                        FromLocId = LocationId;
                    }
                }
                
                else if (rbtnLocation.IsChecked == true)
                {
                    lblSearchType.Text = "Location";
                    ddlLocation.BringToFront();
                    
                }
                else
                {
                    int ZoneId = ddlArea.SelectedValue.ToInt();
                    if (ZoneId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Area Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromZoneId = ZoneId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToZoneId = ZoneId;
                    }
                    else
                    {
                        FromZoneId = ZoneId;
                        ToZoneId = ZoneId;
                    }
                }

                if (rbtCustomer.IsChecked == true)
                {

                    customerName = txtCustomerName.Text;

                }
                else if (rbtAccount.IsChecked == true)
                {

                    AccountId = ddlAccount.SelectedValue.ToInt();
                    if (AccountId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Account");
                        return;
                    }

                }

                rptfrmJobStatisticsReport frm = new rptfrmJobStatisticsReport(FromPostCode, ToPostCode, FromLocId, ToLocId, FromZoneId, ToZoneId, fromDate.Value.ToDate(), tillDate.Value.ToDateTime(), customerName, AccountId, locationName);
                frm.LoadReport();
                frm.ExportReport();
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string FromPostCode = string.Empty;
                string ToPostCode = string.Empty;
                string LocationName = string.Empty;
                int FromLocId = 0;
                int ToLocId = 0;
                int FromZoneId = 0;
                int ToZoneId = 0;
                string customerName = string.Empty;
                
                int AccountId = 0;

                if (rbtnPostCode.IsChecked == true)
                {
                    string PostCode = txtPostCode.Text.Trim();
                    if (string.IsNullOrEmpty(PostCode))
                    {
                        ENUtils.ShowMessage("Requierd : Post Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromPostCode = PostCode;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToPostCode = PostCode;
                    }
                    else
                    {
                        FromPostCode = PostCode;
                        ToPostCode = PostCode;
                    }
                }
                else if (rbtnLocation.IsChecked == true)
                {
                    int LocationId = 0;

                    if (ddlLocationType.Text == "Default")
                    {
                        LocationId = ddlLocation.SelectedValue.ToInt();
                        LocationName = ddlLocation.Text;

                    }
                    else
                    {
                        LocationId = ddlNewLocations.SelectedValue.ToInt();
                        LocationName = ddlNewLocations.Text;
                    }
                    if (LocationId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Loaction Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromLocId = LocationId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToLocId = LocationId;
                    }
                    else
                    {
                        ToLocId = LocationId;
                        FromLocId = LocationId;
                    }
                }
                else
                {
                    int ZoneId = ddlArea.SelectedValue.ToInt();
                    if (ZoneId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Area Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromZoneId = ZoneId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToZoneId = ZoneId;
                    }
                    else
                    {
                        FromZoneId = ZoneId;
                        ToZoneId = ZoneId;
                    }
                }

                if (rbtCustomer.IsChecked == true)
                {

                    customerName = txtCustomerName.Text;
                    
                }
                else if (rbtAccount.IsChecked == true)
                {

                    AccountId = ddlAccount.SelectedValue.ToInt();
                    
                    if (AccountId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Account");
                        return;
                    }

                }

                rptfrmJobStatisticsReport frm = new rptfrmJobStatisticsReport(FromPostCode,ToPostCode,FromLocId,ToLocId,FromZoneId,ToZoneId,fromDate.Value.ToDate(),tillDate.Value.ToDateTime(),customerName, AccountId, LocationName);
               // frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);
              //  frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt());

                //frm.GenerateReport();

                DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("rptfrmJobStatisticsReport1");

                if (doc != null)
                {
                    doc.Close();
                }
                UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string FromPostCode = string.Empty;
                string ToPostCode = string.Empty;
                string LocationName = string.Empty;
                
                int FromLocId = 0;
                int ToLocId = 0;
                int FromZoneId = 0;
                int ToZoneId = 0;
                string customerName = string.Empty;
                int AccountId = 0;

                if (rbtnPostCode.IsChecked == true)
                {
                    string PostCode = txtPostCode.Text.Trim();
                    if (string.IsNullOrEmpty(PostCode))
                    {
                        ENUtils.ShowMessage("Requierd : Post Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromPostCode = PostCode;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToPostCode = PostCode;
                    }
                    else
                    {
                        FromPostCode = PostCode;
                        ToPostCode = PostCode;
                    }
                }
                else if (rbtnLocation.IsChecked == true)
                {
                    int LocationId = 0;

                    if (ddlLocationType.Text == "Default")
                    {
                        LocationId = ddlLocation.SelectedValue.ToInt();
                        LocationName = ddlLocation.Text;

                    }
                    else
                    {
                        LocationId = ddlNewLocations.SelectedValue.ToInt();
                        LocationName = ddlNewLocations.Text;
                    }
                    if (LocationId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Loaction Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromLocId = LocationId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToLocId = LocationId;
                    }
                    else
                    {
                        ToLocId = LocationId;
                        FromLocId = LocationId;
                    }
                }              
                else
                {
                    int ZoneId = ddlArea.SelectedValue.ToInt();
                    if (ZoneId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Area Code");
                        return;
                    }
                    if (rbtnPickup.IsChecked == true)
                    {
                        FromZoneId = ZoneId;
                    }
                    else if (rbtnDestination.IsChecked == true)
                    {
                        ToZoneId = ZoneId;
                    }
                    else
                    {
                        FromZoneId = ZoneId;
                        ToZoneId = ZoneId;
                    }
                }


                if (rbtCustomer.IsChecked == true)
                {

                    customerName = txtCustomerName.Text;
                }
                else if (rbtAccount.IsChecked == true)
                {

                    AccountId = ddlAccount.SelectedValue.ToInt();
                    if (AccountId == 0)
                    {
                        ENUtils.ShowMessage("Requierd : Account");
                        return;
                    }

                }

                rptfrmJobStatisticsReport frm = new rptfrmJobStatisticsReport(FromPostCode, ToPostCode, FromLocId, ToLocId, FromZoneId, ToZoneId, fromDate.Value.ToDate(), tillDate.Value.ToDateTime(), customerName, AccountId, LocationName);
                frm.EmailSending();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        
        private void rbtCustomer_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowSearchType();
        }


        private void rbtAccount_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ShowSearchType();
        }

        private void ddlLocationType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ddlLocationType.Text == "Default")
                {
                    ddlLocation.BringToFront();
                }
                else
                {
                    ddlNewLocations.BringToFront();                    
                }
            }
            catch (Exception ex)
            {

                
            }
            
        }
    }
}

public class Gen_NewLocations
{
    public int Id;
    public string FullLocationName;
}


