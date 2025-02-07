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
    public partial class rptfrmDriverInvoicePayment : UI.SetupBase
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
        public rptfrmDriverInvoicePayment()
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



            ComboFunctions.FillDriverNoComboSorted(ddldriver,null);

            this.ddlSubCompany.SelectedValueChanged += new System.EventHandler(this.ddlSubCompany_SelectedValueChanged);
            this.ddldriver.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCompany_SelectedIndexChanged);
            ddlSubCompany.SelectedValue = AppVars.objSubCompany.Id;

            ddlInvoiceType.SelectedIndex = 0;
            FormatGrid();
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

            if (ddldriver.SelectedValue == null)
            {
                companyId = 0;
            }
            else
            {
                companyId = ddldriver.SelectedValue.ToInt();
            }



            IsExcelReport = false;
            this.ClsInvoicePaymentBindingSource.DataSource = GetData(ddlSubCompany.SelectedValue.ToInt(), companyId);
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


        private List<ClsInvoicePayment> GetData(int SubCompanyId, int companyId)
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
            //reportViewer1.Tag = "invoice";

            //string email = string.Empty;


            //if (ddldriver.SelectedValue.ToInt() > 0)
            //{
            //    int companyId = ddldriver.SelectedValue.ToInt();
            //    using (TaxiDataContext db = new TaxiDataContext())
            //    {
            //        email = db.Gen_Companies.Where(c => c.Id == companyId).Select(c => c.Email).FirstOrDefault();

            //    }
            //}


            //General.ShowEmailForm(reportViewer1, "Invoice Statement Report", email, AppVars.objSubCompany, false);
        }

        public void ExportReport()
        {

            //Microsoft.Reporting.WinForms.Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string extension;

            //byte[] bytes = reportViewer1.LocalReport.Render(
            // "Pdf", null, out mimeType, out encoding,
            //  out extension,
            // out streamids, out warnings);


            //SaveFileDialog saveFileDlg = new SaveFileDialog();
            //saveFileDlg.Filter = "PDF File (*.pdf)|*.pdf";
            //saveFileDlg.Title = "Save File";

            //saveFileDlg.FileName = "Invoice Statement Report";

            ////   saveFileDlg.RestoreDirectory = false;
            //if (saveFileDlg.ShowDialog() == DialogResult.OK)
            //{

            //    try
            //    {
            //        FileStream fs = new FileStream(saveFileDlg.FileName, FileMode.Create);
            //        fs.Write(bytes, 0, bytes.Length);
            //        fs.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

        }
        public void ExportReportToExcel(string exportTo)
        {
            //Microsoft.Reporting.WinForms.Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string extension;

            //byte[] bytes = reportViewer1.LocalReport.Render(
            // "Pdf", null, out mimeType, out encoding,
            //  out extension,
            // out streamids, out warnings);


            //SaveFileDialog saveFileDlg = new SaveFileDialog();
            //saveFileDlg.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";
            //saveFileDlg.Title = "Save File";

            //saveFileDlg.FileName = "Invoice Statement Report";

            ////   saveFileDlg.RestoreDirectory = false;
            //if (saveFileDlg.ShowDialog() == DialogResult.OK)
            //{

            //    try
            //    {
            //        FileStream fs = new FileStream(saveFileDlg.FileName, FileMode.Create);
            //        fs.Write(bytes, 0, bytes.Length);
            //        fs.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
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


        private void FormatGrid()
        {

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = "Id";
           // col.HeaderText = "Driver";
            col.IsVisible = false;
            col.Width = 70;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = "TransId";
            // col.HeaderText = "Driver";
            col.IsVisible = false;
            col.Width = 70;
            grdLister.Columns.Add(col);

            GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
            colDt.Name = "Date";
            colDt.ReadOnly = true;
            colDt.Width = 150;
            colDt.HeaderText = "Date";
            grdLister.Columns.Add(colDt);

                      


            col = new GridViewTextBoxColumn();
            col.Name = "StatementNo";
            col.HeaderText = "Ref No";
            col.ReadOnly = true;
            col.Width = 120;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.Name = "Driver";
            col.HeaderText = "Driver";
            col.ReadOnly = true;
            col.Width = 150;
            grdLister.Columns.Add(col);




            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.ReadOnly = true;
            colD.Width = 120;
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Total";
            colD.Name = "InvoiceTotal";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.ReadOnly = true;
            colD.Width = 120;
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Payment";
            colD.Name = "Payment";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.ReadOnly = true;
            colD.Width = 120;
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Balance";
            colD.Name = "Balance";
            grdLister.Columns.Add(colD);


            UI.GridFunctions.SetFilter(grdLister);


            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();

            GridViewSummaryItem cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = "InvoiceTotal";
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = "Payment";
            item2.Add(cc);



            //cc = new GridViewSummaryItem();
            //cc.Aggregate = GridAggregateFunction.Sum;
            //cc.Name = "Balance";
            //item2.Add(cc);

            this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
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

                if (dtpFromDate.Value == null || dtpToDate.Value == null)
                    error += "Required : Date";



                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;

                }

                if (ddldriver.SelectedValue == null)
                {
                    companyId = 0;
                }
                else
                {
                    companyId = ddldriver.SelectedValue.ToInt();
                }



              
                DateTime? fromDate = (dtpFromDate.Value.Value.Date + dtpFromDate.Value.Value.TimeOfDay);
                DateTime? toDate = (dtpToDate.Value.Value.Date + dtpToDate.Value.Value.TimeOfDay);



                

                    using (TaxiDataContext db = new TaxiDataContext())
                {

                    var list =db.ExecuteQuery<ClsDriverInvoiceStatement>("exec stp_DriverInvoiceStatement {0},{1},{2},{3}",ddlSubCompany.SelectedValue.ToInt(),ddldriver.SelectedValue.ToInt(),fromDate,toDate).OrderBy(c => c.DriverNo).ToList();




                   

                    grdLister.Rows.Clear();
                    


                    grdLister.MasterTemplate.BeginUpdate();


                    int cnt = 0;
                    foreach (var item in list)
                    {

                        if (grdLister.Rows.Count(c => c.Cells["TransId"].Value.ToLong() == item.Id) > 0)
                            continue;

                        var row = grdLister.Rows.AddNew();
                        row.Cells["Id"].Value = item.Id;
                        row.Cells["Driver"].Value = item.Driver;
                        row.Cells["Date"].Value = item.TransDate;
                        row.Cells["StatementNo"].Value = item.TransNo;
                        row.Cells["InvoiceTotal"].Value = item.InvoiceTotal.ToDecimal();
                        row.Cells["Balance"].Value = item.InvoiceTotal.ToDecimal();

                        int cnt2 = 0;




                        decimal lastBalance = row.Cells["InvoiceTotal"].Value.ToDecimal();
                        foreach (var item2 in list.Where(c => c.TransId==item.Id))
                        {
                            var row2 = grdLister.Rows.AddNew();

                          
                            row2.Cells["Id"].Value = item.Id;
                            row2.Cells["Driver"].Value = item.Driver;
                            row2.Cells["Date"].Value = item.TransDate;

                            if(item2.Debit.ToDecimal()>0)
                              row2.Cells["StatementNo"].Value ="D"+ item2.PaymentId.ToStr();
                            else
                                row2.Cells["StatementNo"].Value = "C" + item2.PaymentId.ToStr();

                            row2.Cells["TransId"].Value = item2.TransId;

                            row2.Cells["Payment"].Value = item2.Payment.ToDecimal();

                            if(item2.Debit.ToDecimal()>0)
                            row2.Cells["Balance"].Value = lastBalance + item2.Payment.ToDecimal();
                            else
                                row2.Cells["Balance"].Value = lastBalance - item2.Payment.ToDecimal();


                            lastBalance = row2.Cells["Balance"].Value.ToDecimal();
                            cnt2++;
                        }

                        cnt++;

                    }

                    //GridViewRowInfo row = null;



                    //for (int i = 0; i < list.Count; i++)
                    //{

                    //    row = grdLister.Rows[i];
                    //    row.Cells["Id"].Value = list[i].Id;
                    //   row.Cells["Driver"].Value = list[i].Driver;

                    //    row.Cells["Date"].Value = list[i].TransDate;

                    //    row.Cells["StatementNo"].Value = list[i].TransNo;

                    //    row.Cells["InvoiceTotal"].Value = list[i].InvoiceTotal.ToDecimal();
                       
                    //    row.Cells["Payment"].Value = list[i].Payment.ToDecimal();
                    //    row.Cells["Balance"].Value = list[i].Balance.ToDecimal();

                      
                    //    //if (list[i].Type == "Credit")
                    //    //{
                    //    //    row.Cells[COLS_.Credit].Value = list[i].PaidAmount;
                    //    //}
                    //    //else
                    //    //{
                    //    //    row.Cells[COLS_.Debit].Value = list[i].PaidAmount;
                    //    //}

                    //    //row.Cells[COLS_.TransNo].Value = list[i].TransNo.ToString();

                    //    //// row.Cells[COLS_.Type].Value = list[i].Type;
                    //    //row.Cells[COLS_.UpdateBy].Value = list[i].UpdateBy;

                    //    //row.Cells[COLS_.Balance].Value = list[i].Balance.ToDecimal();
                    //}


                    grdLister.MasterTemplate.EndUpdate();

                }
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

            ddldriver.Tag = "1";
            ComboFunctions.FillDriverNoComboSorted(ddldriver,c=>c.SubcompanyId== ddlSubCompany.SelectedValue.ToInt() );

            ddldriver.Tag = "0";
        }

        private void ddlCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (ddldriver.SelectedValue == null || ddldriver.Tag.ToStr() == "1")
                return;
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.DeferredLoadingEnabled = false;
                    int subCompanyId = db.Gen_Companies.FirstOrDefault(c => c.Id == ddldriver.SelectedValue.ToInt()).DefaultIfEmpty().SubCompanyId.ToInt(); ;

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
                ddldriver.Enabled = false;
                ddldriver.SelectedIndex = -1;
            }
            else
            {
                ddldriver.Enabled = true;
                ddldriver.SelectedIndex = 0;
            }
        }
    }
}
