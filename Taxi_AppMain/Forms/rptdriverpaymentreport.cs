using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_AppMain.Classes;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Taxi_AppMain.Report_Classes
{
    public partial class rptdriverpaymentreport : UI.SetupBase
    {
        Taxi_Model.TaxiDataContext db = new Taxi_Model.TaxiDataContext();
        public rptdriverpaymentreport()
        {
            InitializeComponent();
        }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string DriverNo { get; set; }
        public void GenerateReport()
        {
                        
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptfrmdriverPaymentReport.rdlc";



            Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[5];

            string address = AppVars.objSubCompany.Address;
            string telNo = "Tel No. " + AppVars.objSubCompany.TelephoneNo;
            
            param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FromDate", FromDate);
            param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ToDate", ToDate);          

            List<ClsLogo> objLogo = new List<ClsLogo>();
            objLogo.Add(new ClsLogo { ImageInBytes = AppVars.objSubCompany.CompanyLogo != null ? AppVars.objSubCompany.CompanyLogo.ToArray() : null });
            ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
            this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);

            string path = @"File:";
            
            var lst = db.sp_DriverCommissionExpenses(Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate)).OrderBy(c=>c.Driverno).ToList();


            try
            {
                if (DriverNo != null && DriverNo.Trim().Length > 0)
                {
                    lst = lst.Where(c => c.Driverno == DriverNo).ToList();
                }
            }
            catch
            {

            }

            decimal TotalCredit = lst.Where(c=>c.Type == "Credit").Sum(c => c.PaidAmount).Value;
            decimal TotalDebit = lst.Where(c => c.Type == "Debit").Sum(c => c.PaidAmount).Value;

            param[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter_TotalDebit", TotalDebit.ToString());
            param[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter_TotalCredit", TotalCredit.ToString());
            param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Path", path);

            reportViewer1.LocalReport.SetParameters(param);

            this.sp_DriverCommissionExpensesResultBindingSource.DataSource = lst;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.RefreshReport();
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
            saveFileDlg.FileName = "DriverPayment";

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



        public void ExportReportToExcel()
        {

            Microsoft.Reporting.WinForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render(
             "Excel", null, out mimeType, out encoding,
              out extension,
             out streamids, out warnings);


            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "Excel File (*.xls)|*.xls";
            saveFileDlg.Title = "Save File";
            saveFileDlg.FileName = "DriverPayment";

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

        private void rptdriverpaymentreport_Load(object sender, EventArgs e)
        {
          
        }
    }
}
