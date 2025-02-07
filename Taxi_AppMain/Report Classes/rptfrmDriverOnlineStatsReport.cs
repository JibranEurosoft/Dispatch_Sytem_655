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
    public partial class rptfrmDriverOnlineStatsReport : UI.SetupBase
    {
        private List<ClsDriverOnlineStats> _DataSource;

        public List<ClsDriverOnlineStats> DataSource
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
        public rptfrmDriverOnlineStatsReport()
        {
            InitializeComponent();
            this.btnPrint.Click += new EventHandler(btnPrint_Click);
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        public void LoadReport()
        {
            try
            {
                //DateTime? dtFrom = dtpFromDate.Value.ToDateorNull();
                //DateTime? dtTill = dtpToDate.Value.ToDateorNull();


                //if (dtFrom != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                //    dtFrom = (dtFrom.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



                //if (dtTill != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                //    dtTill = (dtTill.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();
                string Error = string.Empty;
                //if (dtFrom == null)
                //{
                //    Error = "Required: From Date";
                //}
                //if (dtTill == null)
                //{
                //    if (string.IsNullOrEmpty(Error))
                //    {
                //        Error = "Required: To Date";
                //    }
                //    else
                //    {
                //        Error += Environment.NewLine + "Required: To Date";
                //    }
                //}
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

                this.reportViewer1.LocalReport.EnableExternalImages = true;
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    List<ClsDriverOnlineStats> list = db.ExecuteQuery<ClsDriverOnlineStats>("exec stp_GetDriverOnlineStats").ToList();
                    ClsDriverOnlineStatsBindingSource.DataSource = list;
                            

                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[1];
                string heading = string.Empty;
                //heading = "Date Range: " + string.Format("{0:yyyy-MM-dd HH:mm}", dtFrom) + " to " + string.Format("{0:yyyy-MM-dd HH:mm}", dtTill);
                //    heading = "From: " + string.Format("{0:dd/MM/yyyy}", dtFrom) + " To: " + string.Format("{0:dd/MM/yyyy}", dtTill);
                //    string EndDate = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                //    string To = string.Format("{0:dd/MM/yyyy}", dtTill);
                    string Earning = "Total Drivers - "+ list.Count().ToStr()+" found";
                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDrivers", Earning);
                //param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDrivers", Earning);
                
                //List<ClsLogo> objLogo = new List<ClsLogo>();
                //objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
                //ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
                //this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);
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

            saveFileDlg.FileName = "Driver Online Stats Report";

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
            General.ShowEmailForm(reportViewer1, "Driver Online Stats Report");
        }
        public void ExportReportToExcel(string exportTo)
        {



            SaveFileDialog saveFileDlg = new SaveFileDialog();

            //if (exportTo.ToLower() == "pdf")
            //    saveFileDlg.Filter = "PDF File (*.pdf)|*.pdf";
            //else
            saveFileDlg.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";

            saveFileDlg.Title = "Save File";
            saveFileDlg.FileName = "Driver Online Stats Report";


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
            LoadReport();

        }

       


        private void btnExportPDF_Click(object sender, EventArgs e)
        {


            try
            {

              
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

      

       





    }
}
