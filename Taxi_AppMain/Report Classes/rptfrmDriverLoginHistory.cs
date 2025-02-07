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


namespace Taxi_AppMain
{
    public partial class rptfrmDriverLoginHistory :UI.SetupBase
    {
        public rptfrmDriverLoginHistory()
        {
            InitializeComponent();
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GenerateReport();
        
        }

        string templateName = null;

        private void GenerateReport()
        {
            try
            {

                int? driverid=ddl_Driver.SelectedValue.ToIntorNull();


                if (driverid == null)
                {
                    ENUtils.ShowMessage("Required :  Driver");
                    return;
                }


                if (dtpFromDate.Value != null && dtpFromDate.Value.Value.Year == 1753)
                    dtpFromDate.Value = null;

                if (dtpTillDate.Value != null && dtpTillDate.Value.Value.Year == 1753)
                    dtpTillDate.Value = null;

                DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
                DateTime? tillDate = dtpTillDate.Value.ToDateorNull();


                if (tillDate != null)
                    tillDate = tillDate + TimeSpan.Parse("23:59:59");



                if (templateName == null)
                    templateName = General.GetObject<UM_Form_Template>(c => c.UM_Form.FormName == this.Name && c.IsDefault == true).DefaultIfEmpty().TemplateName.ToStr();
                


                if (templateName.ToStr().ToLower().Trim() == "template2")
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.template2_rptDriverLoginHistory.rdlc";

                    List<vu_DriverLoginHistory> list = (from a in General.GetQueryable<vu_DriverLoginHistory>(c => c.driverid == driverid
                                                                      && (
                                                                         (fromDate == null || c.logindatetime >= fromDate) &&
                                                                         (tillDate == null || c.logindatetime <= tillDate)
                                                                         ))
                                                        select new vu_DriverLoginHistory
                                                        {

                                                            logoutdatetime = a.logoutdatetime,
                                                            VehicleNo = a.VehicleNo,
                                                            driverid = a.driverid,
                                                            driverno = a.driverno,
                                                            drivername = a.drivername,
                                                            //   LoginHour = a.l,
                                                            //    TotalDays = a.,
                                                            //  TotalHrs = a.TotalHrs,
                                                            BreakTime = a.logoutdatetime != null ? Math.Round((a.logoutdatetime.Value.Subtract(a.logindatetime.Value).TotalHours), 1) : 0,
                                                            Total = a.Total,

                                                            JobsDone = a.JobsDone,


                                                            Earning = (a.Account - a.Commission),
                                                            Earned = (a.Account - a.Commission),
                                                            Account = a.Account,
                                                            Cash = a.Cash,
                                                            Commission = a.Commission,
                                                            AvgJob = a.PDARent,
                                                            Avghour = a.Parking + a.ExtraDropCharges,
                                                            Avgday = ((a.Account - a.Commission) + (a.Parking + a.ExtraDropCharges)) - a.PDARent,
                                                            logindatetime = a.logindatetime,
                                                            PDARent = a.PDARent,
                                                            Parking = a.Parking,
                                                            Waiting = a.Waiting,
                                                            ExtraDropCharges = a.ExtraDropCharges,
                                                            DriverCommissionPerBooking = a.DriverCommissionPerBooking,
                                                            Cash1 = a.Cash1,
                                                            Account1 = a.Account1,
                                                            BookingFee = a.BookingFee,
                                                            DriverMonthlyRent = a.DriverMonthlyRent,
                                                            drivertypeid = a.drivertypeid,
                                                            Expenses = a.Expenses,
                                                            vehicletype = a.vehicletype
                                                        })
                                                                        .OrderByDescending(c => c.logindatetime).ToList();




                    vu_DriverLoginHistoryBindingSource.DataSource = list;
                }
               else
                {

                    List<vu_DriverLoginHistory> list = (from a in General.GetQueryable<vu_DriverLoginHistory>(c => c.driverid == driverid
                                                                      && (
                                                                         (fromDate == null || c.logindatetime >= fromDate) &&
                                                                         (tillDate == null || c.logindatetime <= tillDate)
                                                                         ))
                                                        select new vu_DriverLoginHistory
                                                        {

                                                            logoutdatetime = a.logoutdatetime,
                                                            VehicleNo = a.VehicleNo,
                                                            driverid = a.driverid,
                                                            driverno = a.driverno,
                                                            drivername = a.drivername,
                                                            //   LoginHour = a.l,
                                                            //    TotalDays = a.,
                                                            //  TotalHrs = a.TotalHrs,
                                                            
                                                           

                                                            JobsDone = a.JobsDone,


                                                            
                                                            logindatetime = a.logindatetime,
                                                         
                                                            vehicletype = a.vehicletype
                                                        })
                                                                        .OrderByDescending(c => c.logindatetime).ToList();


                    vu_DriverLoginHistoryBindingSource.DataSource = list;


                }


                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[4];

                string address = AppVars.objSubCompany.Address;
                string telNo = "Tel No. " + AppVars.objSubCompany.TelephoneNo;

                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Header", AppVars.objSubCompany.CompanyName.ToStr());
                param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Address", address);
                param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Telephone", telNo);

                string heading = string.Empty;
                if (fromDate != null && tillDate != null)
                {
                    heading =  string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", tillDate);
                }
                param[3] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Criteria", heading);
              

                reportViewer1.LocalReport.SetParameters(param);



                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {




            }
        }

        private void rptfrmDriverLoginHistory_Load(object sender, EventArgs e)
        {
            try
            {

                ComboFunctions.FillDriverNoCombo(ddl_Driver);

                dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpTillDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.LastDayOfMonthValue());
            }
            catch (Exception ex)
            {


            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            GenerateReport();
            ExportReport();
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
            saveFileDlg.FileName = "DriverLoginHistory";

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

    }
}
