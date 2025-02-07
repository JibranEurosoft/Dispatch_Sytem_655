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
using Utils;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using System.Collections;
using Taxi_AppMain.Classes;
using Microsoft.Reporting.WinForms;

namespace Taxi_AppMain
{
    public partial class rptfrmDriverSummaryReport : UI.SetupBase
    {
        private List<ClsDriverSummaryReportcs> _DataSource;

        public List<ClsDriverSummaryReportcs> DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private DateTime _fromdate;

        public DateTime fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }

        private DateTime _todate;

        public DateTime todate
        {
            get { return _todate; }
            set { _todate = value; }
        }

        private DateTime _fromtime;

        public DateTime fromtime
        {
            get { return _fromtime; }
            set { _fromtime = value; }
        }

        private DateTime _totime;

        public DateTime totime
        {
            get { return _totime; }
            set { _totime = value; }
        }

        bool IsReportLoaded = false;
        public rptfrmDriverSummaryReport()
        {
            InitializeComponent();
            this.btnPrint.Click += new EventHandler(btnPrint_Click);

                FormatPaymentTypeGrid();
            LoadPaymentTypes();

        }

        private void LoadPaymentTypes()
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list = (from a in db.Gen_PaymentTypes.Where(c => c.IsVisible == true)
                                select new { Id = a.Id, PaymentType = a.PaymentType }).ToList();


                    string val = "";

                    try
                    {
                        val = db.ExecuteQuery<string>("select setval from appsettings where setkey='EnableAllPaymentTypesOnDriverSummaryReport'").FirstOrDefault();
                    }
                    catch
                    {

                    }

                    if(val=="" || val=="false")
                    list = list.Where(x => x.PaymentType.ToUpper() != "CASH").OrderBy(C => C.PaymentType).ToList();


                    grdPaymentTypes.RowCount = list.Count;
                    for (int i = 0; i < list.Count; i++)
                    {
                        grdPaymentTypes.Rows[i].Cells[COLSP.Id].Value = list[i].Id;
                        grdPaymentTypes.Rows[i].Cells[COLSP.PaymentType].Value = list[i].PaymentType;
                        grdPaymentTypes.Rows[i].Cells[COLSP.Check].Value = true;
                    }
                    grdPaymentTypes.ShowColumnHeaders = false;
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void FormatPaymentTypeGrid()
        {
            grdPaymentTypes.AllowEditRow = true;
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLSP.Id;
            col.IsVisible = false;
            grdPaymentTypes.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLSP.PaymentType;
            col.HeaderText = "Payment Type";
            col.Width = 100;
            col.ReadOnly = true;

            grdPaymentTypes.Columns.Add(col);
            GridViewCheckBoxColumn cbcol = new GridViewCheckBoxColumn();
            cbcol.Name = COLSP.Check;
            col.ReadOnly = false;
            cbcol.Width = 40;
            grdPaymentTypes.Columns.Add(cbcol);
        }

    



        public struct COLSP
        {
            public static string Id = "Id";
            public static string PaymentType = "PaymentType";
            public static string Check = "Check";
        }


        void btnPrint_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        List<ClsDriverSummaryReportcs> list = null;

        DateTime? dtFrom = null;
        DateTime? dtTill = null;
        DateTime? dtFromtime = null;
        DateTime? dtTilltime = null;
        public void LoadReport()
        {
            string paymentType = string.Join(",", grdPaymentTypes.Rows.Where(c => c.Cells[COLSP.Check].Value.ToBool()).Select(c => c.Cells[COLSP.Id].Value.ToStr()).ToArray<string>());
           // txtPaymentTypes.Text = Payment;

            try
            {    //load on print
                 dtFrom = dtpFromDate.Value.ToDateorNull();
                 dtTill = dtpToDate.Value.ToDateorNull();
                

                if (dtFrom != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                    dtFrom = (dtFrom.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



                if (dtTill != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                    dtTill = (dtTill.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();
                string Error = string.Empty;
                if (dtFrom == null)
                {
                    Error = "Required: From Date";
                }
                if (dtTill == null)
                {
                    if (string.IsNullOrEmpty(Error))
                    {
                        Error = "Required: To Date";
                    }
                    else
                    {
                        Error += Environment.NewLine + "Required: To Date";
                    }
                }
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

                this.reportViewer1.LocalReport.EnableExternalImages = true;
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    list = db.ExecuteQuery<ClsDriverSummaryReportcs>("exec stp_GetDriverSummaryReport {0},{1},{2}", dtFrom, dtTill, ddlAllDriver.SelectedValue.ToInt())
                        .OrderBy(item => item.DriverNo, new NaturalSortComparer<string>()).ToList();

                    list = list.Where(c => paymentType.Split(',').Count(x => x == c.PaymentTypeId.ToString()) > 0).ToList();


                    if(ddlDriverType.SelectedValue.ToInt()>0)
                    {

                        var driverIds=db.Fleet_Drivers.Where(c => c.DriverTypeId == ddlDriverType.SelectedValue.ToInt()).Select(c => c.Id).ToList();


                        list = list.Where(a => driverIds.Count(c => c == a.DriverId) > 0).ToList();

                    }

                    ClsDriverSummaryReportcsBindingSource.DataSource = list;
                    this.DataSource = list;

                    Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[7];
                    string heading = string.Empty;
                    heading = "Date Range: " + string.Format("{0:yyyy-MM-dd HH:mm}", dtFrom) + " to " + string.Format("{0:yyyy-MM-dd HH:mm}", dtTill);
                    heading = "From: " + string.Format("{0:dd/MM/yyyy}", dtFrom) + " To: " + string.Format("{0:dd/MM/yyyy}", dtTill);
                    string EndDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    string To = string.Format("{0:dd/MM/yyyy}", dtTill);
                    string Earning = "Total Drivers - " + list.Count().ToStr() + " found";
                    string Total_Jobs =  list.Count().ToStr();

                    
                    string address = AppVars.objSubCompany.Address;
                    
                    string telNo = "Tel No. " + AppVars.objSubCompany.TelephoneNo;

                    int driverId = ddlAllDriver.SelectedValue.ToInt();

                    param[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterPeriod", heading);
                    param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDrivers", Earning);
                    param[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalJobs", Total_Jobs);
                    param[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterAddress", address);
                    param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_TotalEarning", list.Where(c=>driverId==0 || c.DriverId==driverId).Sum(c=> c.CongtionCharges.ToDecimal()+c.ParkingCharges.ToDecimal()+c.WaitingCharges.ToDecimal()+c.ExtraDropCharges.ToDecimal()).ToStr());

                    param[5] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_TotalJobs", list.Where(c => driverId == 0 || c.DriverId == driverId).Count().ToStr());
                    param[6] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_TotalFares", list.Where(c => driverId == 0 || c.DriverId == driverId).Sum(c => c.CongtionCharges.ToDecimal() ).ToStr());


                    List<ClsLogo> objLogo = new List<ClsLogo>();
                    objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
                    ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
                    this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);
                    
                 //   reportViewer1.LocalReport.ReportPath = @reportpath;
                    
                    reportViewer1.Refresh();
                    reportViewer1.LocalReport.SetParameters(param);
                    this.reportViewer1.ZoomPercent = 100;
                    this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
                    this.reportViewer1.RefreshReport();
                    IsReportLoaded = true;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        
        public void LoadReport(string DriverNo)
        {
            try
            {
                    //load on sent ema
                    dtFrom = fromdate.ToDateTime();
                    dtTill = todate.ToDateTime();
                   dtFromtime = fromtime.ToDateTime();
                   dtTilltime = totime.ToDateTime();

                if (dtFrom != null && dtFromtime != null && dtFromtime.Value != null)
                    dtFrom = (dtFrom.Value.ToDate() + dtFromtime.Value.TimeOfDay).ToDateTime();



                if (dtTill != null && dtTilltime != null && dtTilltime.Value != null)
                    dtTill = (dtTill.Value.ToDate() + dtTilltime.Value.TimeOfDay).ToDateTime();

                string Error = string.Empty;
                if (dtFrom == null)
                {
                    Error = "Required: From Date";
                }
                if (dtTill == null)
                {
                    if (string.IsNullOrEmpty(Error))
                    {
                        Error = "Required: To Date";
                    }
                    else
                    {
                        Error += Environment.NewLine + "Required: To Date";
                    }
                }
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

                
                reportViewer1.LocalReport.DataSources.Clear();
                
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                //this.reportViewer1.Dispose();
                this.reportViewer1.Clear();
                using (TaxiDataContext db = new TaxiDataContext())
                {


                    
                    list = this.DataSource.Where(c => c.DriverNo == DriverNo).ToList();
                    this.DataSource = null;
                    ClsDriverSummaryReportcsBindingSource.DataSource = list;
                    this.DataSource = list;

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    
                    Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[4];
                    string heading = string.Empty;
                    heading = "Date Range: " + string.Format("{0:yyyy-MM-dd HH:mm}", dtFrom) + " to " + string.Format("{0:yyyy-MM-dd HH:mm}", dtTill);
                    heading = "From: " + string.Format("{0:dd/MM/yyyy}", dtFrom) + " To: " + string.Format("{0:dd/MM/yyyy}", dtTill);
                    string EndDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    string To = string.Format("{0:dd/MM/yyyy}", dtTill);
                    string Earning = "Total Drivers - "+ list.Count().ToStr()+" found";
                    string Total_Jobs = "Total Jobs - " + list.Count().ToStr() + " found";
                    string address = AppVars.objSubCompany.Address;
                    
                    //param[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterPeriod", heading);
                    //param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDrivers", Earning);

                    


                    //param[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterPeriod", heading);
                    //param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDrivers", Earning);
                    //param[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalJobs", Total_Jobs);
                    //param[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterAddress", address);
                    
                    paramList.Add(new ReportParameter("ReportParameterPeriod", heading, true));
                    paramList.Add(new ReportParameter("ReportParameterTotalDrivers", Earning, true));
                    paramList.Add(new ReportParameter("ReportParameterTotalJobs", Total_Jobs, true));
                    paramList.Add(new ReportParameter("ReportParameterAddress", address, true));
                    this.reportViewer1.LocalReport.SetParameters(paramList);




                    ReportDataSource rptDataSource = new ReportDataSource("ClsDriverSummaryReport", DataSource);
                    reportViewer1.LocalReport.DataSources.Add(rptDataSource);


                    List<ClsLogo> objLogo = new List<ClsLogo>();
                    objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
                    ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
                    this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);



                  reportViewer1.LocalReport.Refresh();
                 //reportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;

                    //reportViewer1.LocalReport.SetParameters(param);
                  this.reportViewer1.ZoomPercent = 100;
                  this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                  this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
                  //this.reportViewer1.RefreshReport();
                  IsReportLoaded = true;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        private decimal AvgJob(decimal Total, decimal Commission, int JobsDone)
        { 
            decimal Avg=0.00m;

            if (JobsDone == 0)
                JobsDone = 1;


          
                Avg = ((Total - Commission) / JobsDone);
            
            return Avg;
        }
        public void ExportReport()
        {

            Microsoft.Reporting.WinForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render(
             "Pdf", null, out mimeType, out encoding,
              out extension,
             out streamids, out warnings);


            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "PDF File (*.pdf)|*.pdf";
            saveFileDlg.Title = "Save File";

            saveFileDlg.FileName = "Driver Earning Report";

            //   saveFileDlg.RestoreDirectory = false;
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(saveFileDlg.FileName, FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public void SendEmail()
        {
            try
            {
                DateTime? fromDate = dtpFromDate.Value.ToDate();
                DateTime? tillDate = dtpToDate.Value.ToDate();
                reportViewer1.Tag = "invoice";



                if (chkIndividualDriver.Checked == true)
                {

                    //frmEmailIndividualDriver frm = new frmEmailIndividualDriver(reportViewer1, "Driver Summary Report");

                    ////frm.DriverSummaryListObject = list.ToList();

                    //List<ClsDriverSummaryReportcs> listdst = list.GroupBy(x => x.DriverNo).Select(g => g.First()).ToList();

                    //frm.DriverSummaryListObject = listdst;
                    //frm.check = "summaryreport";


                    //frm.FormateGrid();
                    //frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.DriverSummaryDataSource = DataSource;
                    //frm.FROMDATE = fromDate.ToDateTime();
                    //frm.TODATE = tillDate.ToDateTime();
                    //frm.Show();


                }

                else
                {


                    if (ddlAllDriver.SelectedValue.ToInt()>0)
                    {
                        string email = string.Empty;
                        string driverNo = list[0].DriverNo.ToStr();

                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            email = db.Fleet_Drivers.Where(c => c.DriverNo == driverNo.ToStr()).Select(c => c.Email).FirstOrDefault().ToString();

                            General.ShowEmailForm(reportViewer1, "Driver Summary Report", email, AppVars.objSubCompany, false);

                        }
                    }
                    else
                    {
                        General.ShowEmailForm(reportViewer1, "Driver Summary Report", "", AppVars.objSubCompany, false);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }
        public void ExportReportToExcel(string exportTo)
        {



            SaveFileDialog saveFileDlg = new SaveFileDialog();

            //if (exportTo.ToLower() == "pdf")
            //    saveFileDlg.Filter = "PDF File (*.pdf)|*.pdf";
            //else
            saveFileDlg.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";

            saveFileDlg.Title = "Save File";
            saveFileDlg.FileName = "Driver Earning Report";


            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {


                try
                {
                    FileStream fs = new FileStream(saveFileDlg.FileName, FileMode.Create);

                    Microsoft.Reporting.WinForms.Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = reportViewer1.LocalReport.Render(
                     exportTo.ToLower(), null, out mimeType, out encoding,
                      out extension,
                     out streamids, out warnings);

                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      

    


     

       

       

       

        private void rptfrmJobsList_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date;



            TimeSpan tillTime = TimeSpan.Zero;

            TimeSpan.TryParse("23:59:59", out tillTime);

            dtpToDate.Value = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.LastDayOfMonthValue()).Date);



            dtptilltime.Value = dtpToDate.Value.Value.Date + tillTime;

         //   FillCombo();
        }

       


        private void btnExportPDF_Click(object sender, EventArgs e)
        {


            try
            {

                //rptfrmJobListViewer frm = new rptfrmJobListViewer();

                //DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
                //DateTime? toDate = dtpToDate.Value.ToDateorNull();



                //frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);

                if (IsReportLoaded)
                {
                    ExportReport();
                }
                else
                {
                    LoadReport();
                    ExportReport();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }



        private void FillCombo()
        {
            ComboFunctions.FillDriverNoComboSorted(ddlAllDriver);

        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsReportLoaded)
                {
                    ExportReportToExcel("Excel");
                }
                else
                {
                    LoadReport();
                    ExportReportToExcel("Excel");
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

      

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = dtpFromDate.Value.ToDate();
            DateTime? tillDate = dtpToDate.Value.ToDate();

            string error = string.Empty;


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

            //ReportHeading = "Company Cash Report for Date Range :" + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", tillDate);
           // DataSource = GetData(fromDate, tillDate);

            LoadReport();

            SendEmail();
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

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void ddlDriverType_Enter(object sender, EventArgs e)
        {
            if(ddlDriverType.DataSource==null)
            ComboFunctions.FillDriverTypeCombo(ddlDriverType);
        }

        private void ddlDriverType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ddlAllDriver.Enabled)
                {

                    if (ddlDriverType.SelectedIndex == -1)
                        FillCombo();
                    else
                        ComboFunctions.FillDriverNoComboSorted(ddlAllDriver, c => c.DriverTypeId == ddlDriverType.SelectedValue.ToInt());

                }
            }
            catch
            {

            }
        }
        private void FilLDriverCombo()
        {

            if (ddlDriverType.SelectedIndex == -1)
                FillCombo();
            else
                ComboFunctions.FillDriverNoComboSorted(ddlAllDriver, c => c.DriverTypeId == ddlDriverType.SelectedValue.ToInt());

        }

        private void ddlAllDriver_Enter(object sender, EventArgs e)
        {
            if(ddlAllDriver.DataSource==null)
            {
                FilLDriverCombo();

            }
           
        }
    }
}

