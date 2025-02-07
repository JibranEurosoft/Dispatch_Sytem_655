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
using System.Collections;
using Telerik.WinControls.Enumerations;

namespace Taxi_AppMain
{
    public partial class rptfrmInvoicePayment : UI.SetupBase
    {
        bool IsReportLoaded = false;

        string PaymentType = string.Empty;



        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);

        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);



        private List<ClsInvoicePayment> _DataSource;

        public List<ClsInvoicePayment> DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        public bool IsExcelReport = false;
        public rptfrmInvoicePayment()
        {
            InitializeComponent();

            this.btnPrint.Click += new EventHandler(btnPrint_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
            this.btnEmail.Click += new EventHandler(btnEmail_Click);
            this.btnExit1.Click += new EventHandler(btnExit1_Click);
            this.btnExportToExcel.Click += new EventHandler(btnExportToExcel_Click);
            this.Load += RptfrmInvoicePayment_Load;





        }

        private void RptfrmInvoicePayment_Load(object sender, EventArgs e)
        {
            ComboFunctions.FillSubCompanyCombo(ddlSubCompany);



            ComboFunctions.FillCompanyCombo(ddlCompany, ddlSubCompany.SelectedValue.ToInt());

            ComboFunctions.FillCompanyGroupCombo(ddlCompanyGroup);

            this.ddlSubCompany.SelectedValueChanged += new System.EventHandler(this.ddlSubCompany_SelectedValueChanged);
            this.ddlCompany.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCompany_SelectedIndexChanged);
            ddlSubCompany.SelectedValue = AppVars.objSubCompany.Id;

            ddlInvoiceType.SelectedIndex = 0;
        }


        void btnExportToExcel_Click(object sender, EventArgs e)
        {

            if (IsReportLoaded == true && IsExcelReport == false)
            {
                ExportReportToExcel("Excel");
            }
            else if (IsReportLoaded == true && IsExcelReport == true)
            {
                IsExcelReport = false;
                LoadReport();
                ExportReportToExcel("Excel");
            }
            else
            {
                IsExcelReport = false;
                LoadReport();
                ExportReportToExcel("Excel");
            }

            //IsExcelReport = true;
            //         //            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptDriverAccountBookings.rdlc";
            //         LoadReport();
            //         ExportReportToExcel("Excel");
        }

        void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnEmail_Click(object sender, EventArgs e)
        {

            string error = string.Empty;

            if (ddlSubCompany.SelectedValue == null)
            {
                error += "Required : Sub Company";
            }

            if (!string.IsNullOrEmpty(error))
            {
                ENUtils.ShowMessage(error);
                return;

            }

            int companyId;

            if (ddlCompany.SelectedValue == null)
            {
                companyId = 0;
            }
            else
            {
                companyId = ddlCompany.SelectedValue.ToInt();
            }



            IsExcelReport = false;
            this.ClsInvoicePaymentBindingSource.DataSource = GetData(ddlSubCompany.SelectedValue.ToInt(), companyId,ddlCompanyGroup.SelectedValue.ToInt());
            LoadReport();
            SendEmail();
        }

        void btnExport_Click(object sender, EventArgs e)
        {

            if (IsReportLoaded == true && IsExcelReport == false)
            {
                ExportReport();
            }
            else if (IsReportLoaded == true && IsExcelReport == true)
            {
                IsExcelReport = false;
                LoadReport();
                ExportReport();
            }
            else
            {
                IsExcelReport = false;
                LoadReport();
                ExportReport();
            }

        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            IsExcelReport = false;
            LoadReport();
        }


        private List<ClsInvoicePayment> GetData(int SubCompanyId, int companyId,int groupId)
        {

            using (TaxiDataContext db = new TaxiDataContext())
            {
                //var list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment {0},{1}", SubCompanyId, companyId).ToList();

                var list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment {0},{1}", SubCompanyId, companyId).ToList();

                //var list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment").ToList();
                //if (chkAllDriver.Checked == true)
                //{
                //    list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment").ToList();                    
                //}
                //else
                //{
                //    list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment {0},{1}", SubCompanyId, companyId).ToList();
                //}


                if(groupId>0)
                {

                   var groupRecords=  db.Gen_Companies.Where(c => c.GroupId == groupId).Select(c => c.CompanyName).ToList();

                    list= list.Where(a => groupRecords.Count(c => c == a.CompanyName) > 0).ToList();

                }

                var result = (from a in list

                              select new ClsInvoicePayment
                              {
                                   Id=a.Id,
                                  Balance = a.Balance,
                                  CompanyName = a.CompanyName,
                                  InvoiceDate = a.InvoiceDate,
                                  InvoiceNo = a.InvoiceNo,
                                  InvoicePayment = a.InvoicePayment,
                                  InvoiceTotal = a.InvoiceTotal,
                                  PaymentDate = a.PaymentDate,
                                  TotalBalance = a.TotalBalance,
                                  CreditNoteNo = a.CreditNoteNo,
                                  CreditNoteTotal = a.CreditNoteTotal,
                                  CreditNoteDate = a.CreditNoteDate,
                                  Address = a.Address


                              }).AsEnumerable().OrderBy(item => item.InvoiceNo, new NaturalSortComparer<string>()).ToList();

                //    var list = db.ExecuteQuery<ClsInvoicePayment>("exec stp_InvoicePayment {0},{1}", SubCompanyId, companyId).ToList();

                //var result = (from a in list

                //              select new ClsInvoicePayment
                //              {

                //                 Balance = a.Balance,
                //                 CompanyName = a.CompanyName,
                //                 InvoiceDate = a.InvoiceDate,
                //                 InvoiceNo = a.InvoiceNo,
                //                 InvoicePayment = a.InvoicePayment,
                //                 InvoiceTotal = a.InvoiceTotal,
                //                 PaymentDate = a.PaymentDate,
                //                 TotalBalance = a.TotalBalance,
                //                 CreditNoteNo = a.CreditNoteNo,
                //                 CreditNoteTotal = a.CreditNoteTotal,
                //                 CreditNoteDate = a.CreditNoteDate,
                //                 Address=a.Address


                //              }).AsEnumerable().OrderBy(item => item.InvoiceNo, new NaturalSortComparer<string>()).ToList();





                if (dtpFromDate.Value != null && dtpToDate.Value != null)
                {
                    result = result.Where(c => (c.InvoiceDate >= dtpFromDate.Value && c.InvoiceDate <= dtpToDate.Value)).ToList();




                }
                else if (dtpFromDate.Value != null && dtpToDate.Value == null)
                {
                    result = result.Where(c => (c.InvoiceDate >= dtpFromDate.Value)).ToList();




                }
                else if (dtpFromDate.Value == null && dtpToDate.Value != null)
                {
                    result = result.Where(c => (c.InvoiceDate <= dtpToDate.Value)).ToList();


                }


                if (ddlInvoiceType.SelectedIndex == 1)
                    result = result.Where(c => c.Id == 3).ToList();



                if (ddlInvoiceType.SelectedIndex == 2)
                    result = result.Where(c => c.Id == 1 || c.Id == 2 || c.Id == 4).ToList();


                this.DataSource = result;
                return result;
            }
        }





        public void SendEmail()
        {
            reportViewer1.Tag = "invoice";

            string email = string.Empty;


            if (ddlCompany.SelectedValue.ToInt() > 0)
            {
                int companyId = ddlCompany.SelectedValue.ToInt();
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    email = db.Gen_Companies.Where(c => c.Id == companyId).Select(c => c.Email).FirstOrDefault();

                }
            }


            General.ShowEmailForm(reportViewer1, "Invoice Statement Report", email, AppVars.objSubCompany, false);
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

            saveFileDlg.FileName = "Invoice Statement Report";

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
        public void ExportReportToExcel(string exportTo)
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
            saveFileDlg.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";
            saveFileDlg.Title = "Save File";

            saveFileDlg.FileName = "Invoice Statement Report";

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
            //////////////////////////////////////////////////////////////

            //SaveFileDialog saveFileDlg = new SaveFileDialog();

            //         //if (exportTo.ToLower() == "pdf")
            //         //    saveFileDlg.Filter = "PDF File (*.pdf)|*.pdf";
            //         //else
            //         saveFileDlg.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";

            //         saveFileDlg.Title = "Save File";
            //         saveFileDlg.FileName = "Invoice Statement Report";


            //         if (saveFileDlg.ShowDialog() == DialogResult.OK)
            //         {


            //             try
            //             {
            //                 FileStream fs = new FileStream(saveFileDlg.FileName, FileMode.Create);

            //                 Microsoft.Reporting.WinForms.Warning[] warnings;
            //                 string[] streamids;
            //                 string mimeType;
            //                 string encoding;
            //                 string extension;

            //                 byte[] bytes = reportViewer1.LocalReport.Render(
            //                  exportTo.ToLower(), null, out mimeType, out encoding,
            //                   out extension,
            //                  out streamids, out warnings);

            //                 fs.Write(bytes, 0, bytes.Length);
            //                 fs.Close();


            //             }
            //             catch (Exception ex)
            //             {
            //                 MessageBox.Show(ex.Message);
            //             }
            //         }
        }
        private void LoadReport()
        {
            try
            {
                string error = string.Empty;

                int companyId;

                if (ddlSubCompany.SelectedValue == null)
                {
                    error += "Required : Sub Company";
                }

                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;

                }

                if (ddlCompany.SelectedValue == null)
                {
                    companyId = 0;
                }
                else
                {
                    companyId = ddlCompany.SelectedValue.ToInt();
                }


                this.reportViewer1.LocalReport.EnableExternalImages = true;

                this.ClsInvoicePaymentBindingSource.DataSource = GetData(ddlSubCompany.SelectedValue.ToInt(), companyId, ddlCompanyGroup.SelectedValue.ToInt());


                decimal invoiceTotal = this.DataSource.Where(c => c.TotalBalance != null).Select(args => new { args.InvoiceTotal, args.InvoiceNo }).Distinct().Sum(c => c.InvoiceTotal.ToDecimal());
                decimal invoicePayment = this.DataSource.Where(c => c.TotalBalance != null).Sum(c => c.InvoicePayment.ToDecimal());
                decimal invoiceCredit = this.DataSource.Where(c => c.TotalBalance != null).Sum(c => c.CreditNoteTotal.ToDecimal());


                decimal? TotalBalance = invoiceTotal - invoiceCredit - invoicePayment;

                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[3];

                string heading = string.Empty;
                //heading = "From: "+string.Format("{0:dd/MM/yyyy}", dtFrom) + " To: " + string.Format("{0:dd/MM/yyyy}", dtTill);

                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CompanyName", AppVars.objSubCompany.CompanyName);

                param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_ReportDate", string.Format("{0:dd MMMM yyyy}", DateTime.Now));

                param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_TotalBalance", TotalBalance.ToString());

                List<ClsLogo> objLogo = new List<ClsLogo>();
                objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
                ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
                this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);

                reportViewer1.LocalReport.SetParameters(param);

                if (IsExcelReport)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptInvoicePayment.rdlc";
                }
                else
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptInvoicePayment.rdlc";
                }


                this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
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





        private void ddlSubCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddlSubCompany.Tag.ToStr() == "1")
                return;

            ddlCompany.Tag = "1";
            ComboFunctions.FillCompanyCombo(ddlCompany, ddlSubCompany.SelectedValue.ToInt());

            ddlCompany.Tag = "0";
        }

        private void ddlCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (ddlCompany.SelectedValue == null || ddlCompany.Tag.ToStr() == "1")
                return;
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.DeferredLoadingEnabled = false;
                    int subCompanyId = db.Gen_Companies.FirstOrDefault(c => c.Id == ddlCompany.SelectedValue.ToInt()).DefaultIfEmpty().SubCompanyId.ToInt(); ;

                    if (subCompanyId != 0)
                    {

                        ddlSubCompany.Tag = "1";
                        ddlSubCompany.SelectedValue = subCompanyId;
                        ddlSubCompany.Tag = "0";

                    }
                }
            }
            catch
            {


            }
        }

        private void rptfrmInvoicePayment_Load_1(object sender, EventArgs e)
        {

        }

        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAllDriver.Checked)
            {
                ddlCompany.Enabled = false;
                ddlCompany.SelectedIndex = -1;
            }
            else
            {
                ddlCompany.Enabled = true;
                ddlCompany.SelectedIndex = 0;
            }
        }
    }
}
