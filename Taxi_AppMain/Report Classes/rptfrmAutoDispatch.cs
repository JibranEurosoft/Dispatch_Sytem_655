﻿using System;
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

namespace Taxi_AppMain
{
    public partial class rptfrmAutoDispatch : UI.SetupBase
    {
        bool IsReportLoaded = false;
        private List<stp_AutodispatchResult> _DataSource;

        public List<stp_AutodispatchResult> DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        public rptfrmAutoDispatch()
        {
            InitializeComponent();
        }

        private void rptfrmAutoDispatch_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        public void LoadUsers()
        {
            ComboFunctions.FillUsers(ddlUsers);
            dtpFromDate.Value = DateTime.Now.GetStartOfCurrentWeek();
            dtpTillDate.Value = DateTime.Now.ToDate();
        }
        public void LoadReport()
        {
            try
            {
                int DespatchStats = 1;
                if (rdoStatsOnly.Checked == true)
                {
                    DespatchStats = 1;
                }
                else
                {
                    DespatchStats = 2;
                }
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                string ControllerName=string.Empty;

                ControllerName = ddlUsers.Text;
                TimeSpan tillTime = TimeSpan.Zero;
                TimeSpan.TryParse("23:59:59", out tillTime);
                DateTime dtFrom = dtpFromDate.Value.ToDate();
                DateTime dtTill = dtpTillDate.Value.ToDate()+tillTime;

                var list2 = (from a in new TaxiDataContext().stp_ManualDespatchJobs(dtFrom, dtTill, ControllerName)
                             select new stp_ManualDespatchJobsResult
                             {
                                 User = a.User,
                                 ManualDespatch = a.ManualDespatch
                             }).ToList();
                this.stp_ManualDespatchJobsResultBindingSource.DataSource = list2;

                var list = (from a in new TaxiDataContext().stp_Autodispatch(dtFrom, dtTill, ControllerName)
                            select new stp_AutodispatchResult
                            {
                                User = a.User,
                                AddBy = a.AddBy,
                                AfterUpdate = a.AfterUpdate,
                                BookingId = a.BookingId,
                                BookingNo = a.BookingNo,
                                DriverNo = a.DriverNo,
                                FromAddress = a.FromAddress,
                                ToAddress = a.ToAddress,
                                PickupDateTime = a.PickupDateTime
                            }).ToList();
                this.stp_AutodispatchResultBindingSource.DataSource = list;
                int Totalobs = list.Count;
                int AutoDespathJobs = list.Where(c => c.AfterUpdate.StartsWith("Job Auto Despatched")).Count();
                int ManualDespathJobs = list.Where(c => c.AfterUpdate.StartsWith("Job Despatched")).Count();


                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[5];
                string heading = string.Empty;
                
                heading = string.Format("{0:dd/MM/yy}", dtFrom) + " to " + string.Format("{0:dd/MM/yy}", dtTill);

                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Period", heading);
                param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_TotalJobs", Totalobs.ToStr());
                param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AutoDespatch", AutoDespathJobs.ToStr());
                param[3] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_ManualDespatch", ManualDespathJobs.ToStr());
                param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Stats", DespatchStats.ToStr());

                List<ClsLogo> objLogo = new List<ClsLogo>();
                objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
                ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);

                this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);
                reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                this.reportViewer1.RefreshReport();
                IsReportLoaded = true;
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
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

            saveFileDlg.FileName = "Auto Dispatch Report";

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

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (IsReportLoaded == true)
            {
                ExportReport();
            }
            else
            {
                LoadReport();
                ExportReport();
            }
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<stp_AutodispatchResult> GetData(DateTime? fromDate, DateTime? tillDate, string name)
        {
            return (from a in new Taxi_Model.TaxiDataContext().stp_Autodispatch(fromDate, tillDate, name)
                    select new stp_AutodispatchResult
                    {
                        User = a.User,
                        AddBy = a.AddBy,
                        AfterUpdate = a.AfterUpdate,
                        BookingId = a.BookingId,
                        BookingNo = a.BookingNo,
                        DriverNo = a.DriverNo,
                        FromAddress = a.FromAddress,
                        ToAddress = a.ToAddress,
                        PickupDateTime = a.PickupDateTime

                    }).ToList();
        }
        public void SendEmail()
        {
            General.ShowEmailForm(reportViewer1, "Auto Despatch Booking Report");
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.ddlUsers.Text.ToStr();
                TimeSpan tillTime = TimeSpan.Zero;
                TimeSpan.TryParse("23:59:59", out tillTime);
               
                DateTime? fromDate = dtpFromDate.Value.ToDate();
                DateTime? tillDate = dtpTillDate.Value.ToDate()+tillTime;

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

                //ReportHeading = "Controller Activity Report for Date Range :" + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", tillDate);
                

                DataSource = GetData(fromDate, tillDate, name);
                LoadReport();
                SendEmail();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
    }
}
