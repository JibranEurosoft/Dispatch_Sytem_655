using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Taxi_AppMain.Report_Classes;
using Telerik.WinControls.UI.Docking;
using Utils;
using Telerik.WinControls.Enumerations;

namespace Taxi_AppMain
{
    public partial class rptfrmdriverPaymentReport : UI.SetupBase
    {
        Taxi_Model.TaxiDataContext db = new Taxi_Model.TaxiDataContext();
        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);

        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);


        private Color _HeaderRowBackColor = Color.SteelBlue;

        public Color HeaderRowBackColor
        {
            get { return _HeaderRowBackColor; }
            set { _HeaderRowBackColor = value; }
        }


        private Color _HeaderRowBorderColor = Color.DarkSlateBlue;

        public Color HeaderRowBorderColor
        {
            get { return _HeaderRowBorderColor; }
            set { _HeaderRowBorderColor = value; }
        }

        public struct COLS_
        {

            public static string ID = "ID";
            public static string DriverNo = "DriverNo";
            public static string Date = "Date";
            public static string Driver = "Driver";
            public static string Credit = "Credit";
            public static string Debit = "Debit";
            public static string Type = "Type";
            public static string TransNo = "TransNo";
            public static string Description = "Description";
            public static string UpdateBy = "UpdateBy";
            public static string Balance = "Balance";

        }


        public rptfrmdriverPaymentReport()
        {
            InitializeComponent();
            this.Load += RptfrmdriverPaymentReport_Load;
         
            FormatGrid();
        }

   
        private void FormatGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS_.DriverNo;
            col.HeaderText = "Driver";
            col.ReadOnly = true;
            col.Width = 70;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.TransNo;
            col.HeaderText = "Statement No";
            col.ReadOnly = true;
            col.Width = 100;
            grdLister.Columns.Add(col);

            GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
            colDt.Name = COLS_.Date;
            colDt.ReadOnly = true;
            colDt.Width = 120;
            colDt.HeaderText = "Payment Date";
            grdLister.Columns.Add(colDt);

            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.ReadOnly = true;
            colD.Width = 90;
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Credit";
            colD.Name = COLS_.Credit;
            colD.VisibleInColumnChooser = false;
            // colD.Width = 70;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.ReadOnly = true;
            colD.Width = 90;
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Debit";
            colD.Name = COLS_.Debit;
            colD.VisibleInColumnChooser = false;
            // colD.Width = 70;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);




           

            //col = new GridViewTextBoxColumn();
            //// col.IsVisible = false;
            //col.ReadOnly = true;
            //col.Name = COLS_.Type;
            //col.HeaderText = "Type";
            //col.Width = 70;
            //grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Description";
            col.Name = COLS_.Description;
            col.Width = 170;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Update By";
            col.Name = COLS_.UpdateBy;
            col.Width = 80;
            grdLister.Columns.Add(col);

            UI.GridFunctions.SetFilter(grdLister);


            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();
            
            GridViewSummaryItem cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.Credit;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.Debit;
            item2.Add(cc);

            this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }


        private void RptfrmdriverPaymentReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddDays(-7).Date;
            dtpToDate.Value = DateTime.Now.AddDays(1);
            dtpFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtptilltime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }
        public struct COLS
        {

            public static string Amount = "Paid Amount";
        
        }
     
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = (dtpFromDate.Value.Value.Date + dtpFromTime.Value.Value.TimeOfDay);
            DateTime? toDate = (dtpToDate.Value.Value.Date +dtptilltime.Value.Value.TimeOfDay);
            var list = db.sp_DriverCommissionExpenses(fromDate, toDate).OrderBy(c=>c.Driverno).ToList();




            string driverno = string.Empty;


            if(ddlAllDriver.SelectedValue!=null)
            {

               driverno = ddlAllDriver.Text.Remove(ddlAllDriver.Text.IndexOf("-") - 1).Trim();
                list.Where(c => c.Driverno == driverno).ToList();
            }

      

            grdLister.Rows.Clear();

            grdLister.RowCount = list.Count;


            grdLister.MasterTemplate.BeginUpdate();

            GridViewRowInfo row = null;
            for (int i = 0; i < list.Count; i++)
            {

                row = grdLister.Rows[i];

                row.Cells[COLS_.DriverNo].Value = list[i].Driverno;
               
                row.Cells[COLS_.Date].Value = list[i].Date;
                
                row.Cells[COLS_.Description].Value = list[i].Description.ToString();

                if (list[i].Type == "Credit")
                {
                    row.Cells[COLS_.Credit].Value = list[i].PaidAmount;
                }
                else
                {
                    row.Cells[COLS_.Debit].Value = list[i].PaidAmount;
                }

                row.Cells[COLS_.TransNo].Value = list[i].TransNo.ToString();

                // row.Cells[COLS_.Type].Value = list[i].Type;
                row.Cells[COLS_.UpdateBy].Value = list[i].UpdateBy;

               // row.Cells[COLS_.Balance].Value = list[i].Balance.ToDecimal();
            }


            grdLister.MasterTemplate.EndUpdate();






            //this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            //GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();


            //GridViewSummaryItem cc = new GridViewSummaryItem();
            //cc.Aggregate = GridAggregateFunction.Sum;
            //cc.Name = COLS.Amount;
            //item2.Add(cc);

            //this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);

            //this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;


            //UI.GridFunctions.SetFilter(grdLister);

            //grdLister.Columns["Driverno"].Width = 100;
            //grdLister.Columns["PaidAmount"].Width = 100;
            //grdLister.Columns["UpdateBy"].Width = 120;
            //grdLister.Columns["Date"].Width = 140;
            //grdLister.Columns["Description"].Width = 160;
            //grdLister.Columns["Type"].Width = 100;

            //grdLister.Columns["Driverno"].HeaderText = "Driver";
            //grdLister.Columns["PaidAmount"].HeaderText = "Paid Amount";
            //grdLister.Columns["UpdateBy"].HeaderText = "Update By";
            //grdLister.Columns["Driver"].IsVisible = false;


        }

     
        public override void Print()
        {
            try
            {

                DateTime? fromDate = dtpFromDate.Value.Value;
                DateTime? toDate = dtpToDate.Value.Value;

                rptdriverpaymentreport frm = new rptdriverpaymentreport();
                //rptfrmJobListViewer frm = new rptfrmJobListViewer();

                //frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);
                //                frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                frm.FromDate = string.Format("{0:dd/MM/yyyy}", fromDate);
                frm.ToDate = string.Format("{0:dd/MM/yyyy}", toDate);



                frm.DriverNo = getdriverno();


                frm.GenerateReport();

                DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("rptdriverpaymentreport");

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

        private string getdriverno()
        {
            string driverno = string.Empty;


            if (ddlAllDriver.SelectedValue != null)
            {

                driverno = ddlAllDriver.Text.Remove(ddlAllDriver.Text.IndexOf("-") - 1).Trim();
                
            }

            return driverno;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {

                rptdriverpaymentreport frm = new rptdriverpaymentreport();

                DateTime? fromDate = dtpFromDate.Value.Value;
                DateTime? toDate = dtpToDate.Value.Value;

                frm.FromDate = string.Format("{0:dd/MM/yyyy}", fromDate);
                frm.ToDate = string.Format("{0:dd/MM/yyyy}", toDate);

                frm.DriverNo = getdriverno();

                frm.GenerateReport();

                frm.ExportReport();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {

                rptfrmJobListViewer frm = new rptfrmJobListViewer();

                DateTime? fromDate = dtpFromDate.Value.Value;
                DateTime? toDate = dtpToDate.Value.Value;
                frm.DriverNo = getdriverno();

                frm.GenerateReport();

                frm.ExportReportToExcel();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                ddlAllDriver.SelectedValue = null;
                ddlAllDriver.Enabled = false;
            }
            else
            {
                ddlAllDriver.Enabled = true;
            }
        }

        private void ddlAllDriver_Enter(object sender, EventArgs e)
        {
            if(ddlAllDriver.DataSource==null)
            {

                ComboFunctions.FillDriverNoComboSorted(ddlAllDriver);

            }
        }
    }
}
