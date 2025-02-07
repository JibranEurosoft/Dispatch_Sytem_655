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
using Microsoft.Reporting.WinForms;
using Taxi_AppMain.Classes;


namespace Taxi_AppMain
{
    public partial class rptfrmCommissionReconciliation : UI.SetupBase
    {
        bool IsReportLoaded = false;
        bool IsLoaded = false;
        public rptfrmCommissionReconciliation()
        {
            InitializeComponent();
            this.chkAllDriver.CheckedChanged += new EventHandler(chkAllDriver_CheckedChanged);
            this.chkAllSubCompany.CheckedChanged += new EventHandler(chkAllSubCompany_CheckedChanged);
            this.ddlSubCompany.SelectedValueChanged += new EventHandler(ddlSubCompany_SelectedValueChanged);
            this.btnExit1.Click += new EventHandler(btnExit1_Click);
        }

        void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ddlSubCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                int Id = ddlSubCompany.SelectedValue.ToInt();
                if (Id > 0)
                {
                    var list = (from a in General.GetQueryable<Fleet_Driver>(c => (c.SubcompanyId == Id) && (c.DriverTypeId == Enums.DRIVERTYPES.COMMISSION) && (c.IsActive == true))
                                orderby a.DriverNo
                                select new
                                {
                                    Id = a.Id,
                                    DriverName = a.DriverNo + " - " + a.DriverName

                                }).ToList();
                    ComboFunctions.FillCombo(list, ddl_Driver, "DriverName", "Id");
                }

            }
        }

        void chkAllSubCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSubCompany.Checked)
            {
                ddlSubCompany.SelectedValue = null;
                ddlSubCompany.Enabled = false;
            }
            else
            {
                ddlSubCompany.Enabled = true;
            }
        }

        void chkAllDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDriver.Checked)
            {
                ddl_Driver.SelectedValue = null;
                ddl_Driver.Enabled = false;
            }
            else
            {
                ddl_Driver.Enabled = true;
            }
        }

        private List<ClsCommissionReconciliationReport> GetDataSource(int? driverId, DateTime? fromDate, DateTime? tillDate)
        {
            // decimal rent = AppVars.objPolicyConfiguration.DriverMonthlyRent.ToDecimal();

            decimal commission = AppVars.objPolicyConfiguration.DriverCommissionPerBooking.ToDecimal();

            var query = General.GetQueryable<Booking>(c => c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED);

            var list = query.Where(a => a.DriverId != null && a.Fleet_Driver.DriverTypeId == 2 &&
                            (driverId == null || a.DriverId == driverId) && a.CompanyId != null
                            && (a.PickupDateTime.Value.Date >= fromDate && a.PickupDateTime.Value.Date <= tillDate))
                           .GroupBy(args => new
                           {
                               args.Gen_Company.CompanyCode,
                               //    args.Gen_Company.CompanyName,
                               args.Fleet_Driver.DriverNo,
                               args.DriverId,
                               args.Fleet_Driver.DriverMonthlyRent
                           })
                           .Select(args => new
                           {
                               DriverId = args.Key.DriverId,
                               DriverNo = args.Key.DriverNo,
                               CompanyCode = args.Key.CompanyCode,
                               //   CompanyName = args.Key.CompanyName,
                               //  TotalJobs = args.Count(),
                               TotalAmount = args.Sum(c => c.TotalCharges),
                               Commission = args.Sum(c => (c.DriverCommissionType == "Commission" ? (c.TotalCharges * commission) / 100 : c.DriverCommission))
                               // Balance = rent - args.Sum(c => c.TotalCharges).ToDecimal()
                           }).OrderBy(c => c.DriverNo).ToList();


            List<ClsCommissionReconciliationReport> resultList = new List<ClsCommissionReconciliationReport>();

            ClsCommissionReconciliationReport obj = null;
            int cnt = 0;
            int? oldDriverId = null;


            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i].DriverId != oldDriverId)
            //    {


            //        obj = new ClsCommissionReconciliationReport();
            //        obj.CompanyCode = list[i].CompanyCode;
            //        cnt = 1;

            //        resultList.Add(obj);

            //    }
            //    else
            //    {
            //        obj = resultList.FirstOrDefault(c => c.DriverId == oldDriverId);
            //        cnt++;
            //        if (cnt <= 10)
            //        {
            //            obj.GetType().GetProperty("CompanyCode" + cnt).SetValue(obj, list[i].CompanyCode, null);
            //        }

            //    }
            //    oldDriverId = list[i].DriverId;
            //    obj.DriverId = list[i].DriverId;
            //    obj.DriverNo = list[i].DriverNo;
            //    obj.DriverRent = list[i].Commission.ToDecimal();

            //    obj.TotalAmount = obj.TotalAmount.ToDecimal() + list[i].TotalAmount.ToDecimal();


            //    if ((list.Count - 1 > i + 1 && list[i + 1].DriverId != list[i].DriverId) || list.Count == i + 1)
            //    {
            //        //  obj.Balance = obj.TotalAmount - rent;
            //        obj.Balance = obj.TotalAmount - obj.DriverRent.ToDecimal();
            //    }


            //}


            return resultList;

        

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GenerateReport();

        }

        private void GenerateReport()
        {
            try
            {

                int driverid = ddl_Driver.SelectedValue.ToInt();

                int SubCompanyId = ddlSubCompany.SelectedValue.ToInt();

                string Error = string.Empty;

                if (SubCompanyId == 0 && !chkAllSubCompany.Checked)
                {
                    Error = "Required : SubCompany";

                }
                if (driverid == 0 && !chkAllDriver.Checked)
                {
                    if (string.IsNullOrEmpty(Error))
                    {
                        Error = "Required : Driver";
                    }
                    else
                    {
                        Error += Environment.NewLine + "Required : Driver";
                    }
                }


                if(chkAllDate.Checked==false)
                {
                    if(dtpFromDate.Value==null)
                        Error += Environment.NewLine + "Required : Starting Date";

                }

                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

                using (TaxiDataContext db = new TaxiDataContext())
                {

                var list = db.stp_GetDriverCommissionReconciliation(SubCompanyId, driverid).ToList();

                    if (dtpFromDate.Value!=null)
                    {
                        try
                        {
                            list = list.Where(c => c.TransDate >= dtpFromDate.Value).ToList();
                        }
                        catch
                        {

                        }

                    }

                        list = (list.AsEnumerable().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>())).ToList();

                
                  

                    ClsCommissionReconciliationReportBindingSource.DataSource = list;
                }

                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[3];

                string address = AppVars.objSubCompany.Address;
                string telNo = "Tel No. " + AppVars.objSubCompany.TelephoneNo;

                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CompanyHeader", AppVars.objSubCompany.CompanyName.ToStr());

                param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Telephone", telNo);
                param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Address", address);
                //Report_Parameter_AverageJobsPerDay
                //string heading = string.Empty;
                //if (fromDate != null && tillDate != null)
                //{
                //    heading =  string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", tillDate);
                //}
                //param[3] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Criteria", heading);
                //param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AverageJobsPerDay", s.ToStr());
                //param[5] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AverageWorkingPerDay", sWorking);


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

        private void rptfrmDriverLoginHistory_Load(object sender, EventArgs e)
        {
            try
            {

                // ComboFunctions.FillDriverNoCombo(ddl_Driver, c => c.DriverTypeId == Enums.DRIVERTYPES.RENT);
                ComboFunctions.FillSubCompanyCombo(ddlSubCompany);
                IsLoaded = true;
                if (AppVars.listUserRights.Count(c => c.formName == "frmBookingsList" && c.functionId == "DISABLE EXPORT LIST") > 0)
                {
                   
                    btnExportPDF.Visible = false;
                    reportViewer1.ShowExportButton = false;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (IsReportLoaded)
            {
                ExportReport();
            }
            else
            {
                GenerateReport();
                ExportReport();
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
            saveFileDlg.FileName = "Rent Reconciliation Report";

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

        private void chkAllDate_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAllDate.Checked)
            {
                label1.Enabled = true;
                dtpFromDate.Value = null;
                dtpFromDate.Enabled = false;

            }
            else
            {
                label1.Enabled = true;
                dtpFromDate.Enabled = true;
            }
        }
    }
}
