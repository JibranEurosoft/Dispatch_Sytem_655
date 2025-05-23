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
using Microsoft.Reporting.WinForms;
using Taxi_AppMain.Classes;
using System.Collections;
using System.Drawing.Printing;

namespace Taxi_AppMain
{
    public partial class frmDriverCommisionTransactionExpensesReport5 : UI.SetupBase
    {

        public decimal VAT { get; set; }
        private bool _IsFareAndWaitingWise;

        public bool IsFareAndWaitingWise
        {
            get { return _IsFareAndWaitingWise; }
            set { _IsFareAndWaitingWise = value; }
        }



        //private List<vu_DriverCommision> _DataSource;

        //public List<vu_DriverCommision> DataSource
        private List<vu_DriverCommisionExpenses2> _DataSource;

        public List<vu_DriverCommisionExpenses2> DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        private List<vu_FleetDriverCommissionExpense> _DataSource2;

        public List<vu_FleetDriverCommissionExpense> DataSource2
        {
            get { return _DataSource2; }
            set { _DataSource2 = value; }
        }
        private string _CompanyHeader;

        public string CompanyHeader
        {
            get { return _CompanyHeader; }
            set { _CompanyHeader = value; }
        }

        public struct COLS
        {
            public static string ID = "ID";
            public static string PickupDate = "PickupDate";
            public static string Vehicle = "Vehicle";
            public static string OrderNo = "OrderNo";
            public static string PupilNo = "PupilNo";

            public static string RefNumber = "RefNumber";

            public static string Passenger = "Passenger";

            public static string PickupPoint = "PickupPoint";
            public static string Destination = "Destination";

            public static string Charges = "Charges";

            public static string Parking = "Parking";
            public static string Waiting = "Waiting";
            public static string ExtraDrop = "ExtraDrop";
            public static string MeetAndGreet = "MeetAndGreet";
            public static string CongtionCharge = "CongtionCharge";
            public static string Total = "Total";

        }

       public  Gen_SubCompany objSubCompany = null;


        private string _DisplayCriteria = "";

        public string DisplayCriteria
        {
            get { return _DisplayCriteria; }
            set { _DisplayCriteria = value; }
        }




        public void GenerateReport()
        {
            try
            {
             

                reportViewer1.LocalReport.EnableExternalImages = true;





                if (AppVars.objPolicyConfiguration.DefaultClientId.ToStr() == "Whittington_C@r$")
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptDriverCommisionExpenses5_template2.rdlc";



                Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[35];


              


                if(objSubCompany==null)
                {
                    objSubCompany = AppVars.objSubCompany;

                }
                int? driverId = this.DataSource.FirstOrDefault().DefaultIfEmpty().DriverId;


                Fleet_Driver obj = General.GetObject<Fleet_Driver>(c => c.Id == driverId);
                if (objSubCompany != null && obj.SubcompanyId.ToInt() != objSubCompany.Id)
                {

                    objSubCompany = obj.Gen_SubCompany;

                }

                string address = objSubCompany.Address;
                string telNo = string.Empty;

                string sortCode = objSubCompany.SortCode.ToStr();
                string accountNo = objSubCompany.AccountNo.ToStr();
                string accountTitle = objSubCompany.AccountTitle.ToStr();
                string bank = objSubCompany.BankName.ToStr();


                string hasBankDetails = "1";
                if (string.IsNullOrEmpty(sortCode) && string.IsNullOrEmpty(accountNo) && string.IsNullOrEmpty(accountTitle)
                    && string.IsNullOrEmpty(bank))
                {
                    hasBankDetails = "0";
                }

                if (!string.IsNullOrEmpty(sortCode))
                    sortCode = "Sort Code : " + sortCode;



                if (!string.IsNullOrEmpty(accountTitle))
                    accountTitle = "Account Title : " + accountTitle;



                string website = objSubCompany.WebsiteUrl.ToStr();
                if (!string.IsNullOrEmpty(website))
                {
                    website += " , ";
                }

                website += "Email:" + objSubCompany.EmailAddress.ToStr();


                string companyNumber = objSubCompany.CompanyNumber.ToStr();
                if (!string.IsNullOrEmpty(companyNumber))
                {
                    companyNumber = "Company Number: " + companyNumber;
                }

                string vatNumber= objSubCompany.CompanyVatNumber.ToStr();
                //if (!string.IsNullOrEmpty(vatNumber))
                //{
                //    vatNumber =  vatNumber;
                //}


                param[0] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Address", address);

                param[18] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Footer", objSubCompany.WebsiteUrl.ToStr());

                param[14] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_MobileNo", "Mobile: " + objSubCompany.EmergencyNo.ToStr());
                param[15] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Website", website);
                param[16] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Email", "Email: " + objSubCompany.EmailAddress.ToStr());

                param[20] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CompanyNumber", companyNumber);
                param[21] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_VATNumber", vatNumber);


                param[7] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_SortCode", sortCode);
                param[9] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AccountTitle", accountTitle);
                param[10] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Bank", bank);



                List<ClsLogo> objLogo = new List<ClsLogo>();
                objLogo.Add(new ClsLogo { ImageInBytes = objSubCompany.CompanyLogo != null ? objSubCompany.CompanyLogo.ToArray() : null });
                ReportDataSource imageDataSource = new ReportDataSource("Taxi_AppMain_Classes_ClsLogo", objLogo);
                this.reportViewer1.LocalReport.DataSources.Add(imageDataSource);

                string path = @"File:";
                param[2] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Path", path);
                param[6] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CompanyHeader", objSubCompany.CompanyName.ToStr());







               

              

                var data = this.DataSource.FirstOrDefault().DefaultIfEmpty();


                telNo = "Telephone: " + objSubCompany.TelephoneNo + ", Fax: " + objSubCompany.Fax + ", E-mail: " + objSubCompany.EmailAddress + ", Website:"+ objSubCompany.WebsiteUrl;

                if (!string.IsNullOrEmpty(accountNo))
                    accountNo = "Account No : " + accountNo;


               // string className = "Taxi_AppMain.ReportDesigns.";
                //if (IsCheck == 1)
                //{

                //    if (IsFareAndWaitingWise)
                //    {
                //        this.reportViewer1.LocalReport.ReportEmbeddedResource = className + "rptDriverCommisionTrasaction3.rdlc";

                //    }
                //    else
                //    {

                        

                //        this.reportViewer1.LocalReport.ReportEmbeddedResource = className + "rptDriverCommisionTrasaction4.rdlc";
                //    }
                //}
                //else
                //{
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = className + "rptDriverCommisionTrasaction2.rdlc";
                //}

                param[1] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Telephone", telNo);


                param[8] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AccountNo", accountNo);




                string vat = "0";
                decimal discountAmount = 0.00m;
                decimal valueAddedTax = VAT; //0.0m;
                decimal CashTotalAmount = 0.0m;
                decimal AccountTotalAmount = 0.0m;
                decimal CardTotalAmount = 0.0m;

                CashTotalAmount = this._DataSource.Where(c => c.PaymentTypeId == Enums.PAYMENT_TYPES.CASH).Sum(c=>c.FareRate + c.WaitingCharges  + c.ExtraPickUpCharges).ToDecimal();
                AccountTotalAmount = this._DataSource.Where(c => c.PaymentTypeId == Enums.PAYMENT_TYPES.BANK_ACCOUNT).Sum(c => c.FareRate + c.WaitingCharges+ c.ExtraPickUpCharges).ToDecimal();
                CardTotalAmount = this._DataSource.Where(c => (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH) && (c.PaymentTypeId != Enums.PAYMENT_TYPES.BANK_ACCOUNT)).Sum(c => c.FareRate + c.WaitingCharges + c.ExtraPickUpCharges).ToDecimal();

                string discount = string.Format("{0:c}", discountAmount);
                discount = discount.Substring(1);

                string grandTotal = "";
               
                param[17] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Discount", discount);


                param[3] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_InvoiceTotal", grandTotal);

                param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_HasVat", vat);

                param[5] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_VAT", valueAddedTax.ToStr());
                param[11] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_HasDepartment", "0");

                param[12] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Net", "0");

                param[13] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_HasCostCenter", "0");

                param[19] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_HasBankDetails", hasBankDetails);


                string AccountBooking = string.Empty; 
                  string CashBooking = string.Empty;


              


                   
                  decimal DriverCommision = obj.DriverCommissionPerBooking.ToDecimal();



               
                

                  decimal JobTotal = 0; 
                //if(this.IsFareAndWaitingWise)
                //{
                //    AccountBooking = string.Format("{0:£ #.##}", this.DataSource.Where(c => c.CompanyId != null && c.BookingTypeId.ToInt() == Enums.ACCOUNT_TYPE.ACCOUNT).Sum(c => c.FareRate.ToDecimal() + c.WaitingCharges.ToDecimal()));
                //    CashBooking = string.Format("{0:£ #.##}", this.DataSource.Where(c => c.CompanyId == null || c.BookingTypeId.ToInt()==Enums.ACCOUNT_TYPE.CASH).Sum(c => c.FareRate.ToDecimal() + c.WaitingCharges.ToDecimal()));
                //    JobTotal = this.DataSource.Sum(c => c.FareRate.Value.ToDecimal()+ c.WaitingCharges.ToDecimal());

                //}
                //else
                //{
                    AccountBooking = string.Format("{0:£ #.##}", this.DataSource.Where(c => c.CompanyId != null && c.BookingTypeId.ToInt()==Enums.ACCOUNT_TYPE.ACCOUNT).Sum(c => c.FareRate.ToDecimal() + c.ParkingCharges.ToDecimal() + c.WaitingCharges.ToDecimal() + c.ExtraPickUpCharges));
                    CashBooking = string.Format("{0:£ #.##}", this.DataSource.Where(c => c.CompanyId == null || c.BookingTypeId.ToInt() == Enums.ACCOUNT_TYPE.CASH).Sum(c => c.FareRate.ToDecimal() + c.ParkingCharges.ToDecimal() + c.WaitingCharges.ToDecimal() + c.ExtraPickUpCharges));
                     JobTotal=   this.DataSource.Sum(c => c.FareRate.ToDecimal()+c.ParkingCharges.ToDecimal()+c.WaitingCharges.ToDecimal() + c.ExtraPickUpCharges);
         //       }


                param[22] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AccountJobTotal", AccountBooking);
                param[23] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CashJobTotal", CashBooking);
                string BalanceType = string.Empty;
                int DriverId = this.DataSource.FirstOrDefault().DriverId.ToInt();
                int Id = this.DataSource.FirstOrDefault().Id.ToInt(); 

                string StatementDate = string.Empty;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.DeferredLoadingEnabled = false;

                    var query = db.Fleet_DriverCommisions.Where(c => c.DriverId == DriverId && c.Id != Id).OrderByDescending(c => c.Id).FirstOrDefault();
                  //  var query = General.GetObject<Fleet_DriverCommision>(c => c.DriverId == DriverId && c.Id < Id);

                   
                    if (query == null)
                    {
                        BalanceType = "Initial Balance";
                        StatementDate = string.Format("{0:dd/MM}", this.DataSource.FirstOrDefault().TransDate);
                    }
                    else
                    {
                        BalanceType = "Balance from statement " + query.TransNo;
                        StatementDate = string.Format("{0:dd/MM}", query.TransDate);
                    }
                }
               
                string Commision = (JobTotal * DriverCommision / 100).ToStr();
                decimal AccountTotal = (this.DataSource.Sum(c => c.AccountJobsTotal)).ToDecimal();
             //   decimal AccountCommision=(25*AccountTotal/100);
                decimal CashTotal = (this.DataSource.Sum(c => c.CashJobsTotal)).ToDecimal();
              //  decimal CashCommision=(25*CashTotal/100);
               // decimal TotalDebit = this.DataSource2.Sum(c => c.Debit).ToDecimal();
              //  decimal TotalCredit = this.DataSource2.Sum(c=>c.Credit).ToDecimal();



              //  decimal commissionTotal = this.data


             //   var objRecord=  General.GetObject<Fleet_DriverCommision>(c => c.Id == Id);


                //if (objRecord != null)
                //{

                //    commissionTotal = objRecord.CommissionTotal.ToDecimal() + objRecord.AgentFeesTotal.ToDecimal();
                //}

                if (AppVars.objPolicyConfiguration.PriceRangeWiseCommission.ToBool())
                {

                    List<Fleet_Driver_CommissionRange> listofRange = obj.Fleet_Driver_CommissionRanges.ToList();

                    if (listofRange.Count == 0)
                    {
                        listofRange = GetSystemCommissionRange();

                    }

                    Commision =Math.Round(this.DataSource
                                  .Sum(c => c.IsCommissionWise.ToBool() ? (c.DriverCommissionType == "Percent" ? ((c.TotalCharges * c.DriverCommissionOnBooking) / 100) : c.DriverCommissionOnBooking) : (((c.FareRate * listofRange.FirstOrDefault(a => c.TotalCharges >= a.FromPrice && c.FareRate <= a.ToPrice).DefaultIfEmpty().CommissionValue.ToDecimal()) / 100))).ToDecimal(),2).ToStr();


                }


                param[24] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Commision", Commision);

                string DriverGrandTotal = "";

                if (this.DataSource != null)
                {
                    DriverGrandTotal = (this.DataSource[0].DriverCommision + this.DataSource[0].Extra + this.DataSource[0].fuel + this.DataSource[0].OldBalance).ToStr();
                }

                param[25] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_GrandTotal", DriverGrandTotal);

                int cnt = this.DataSource.Count;
                decimal AccountExpenses = 0.00m;
            //    decimal DropOfCharges=this.DataSource.Sum(c=>c.ExtraDropOfCharges).ToDecimal();
             //   decimal PickUpCharges=this.DataSource.Sum(c=>c.ExtraPickUpCharges).ToDecimal();
              //  AccountExpenses=(DropOfCharges+PickUpCharges);
                param[26] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_jobCount", cnt.ToStr());
                param[27] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_BalanceType", BalanceType);
                param[28] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_AccountExpenses", AccountExpenses.ToStr());
                param[29] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_StatementDate", StatementDate);
                //Report_Parameter_StatementDate
              
                string balance=string.Empty;
                
                decimal bal=this.DataSource.FirstOrDefault().DefaultIfEmpty().Balance.ToDecimal();
                

                if(bal>=0)
                {

                    balance = "You are due to receive £" + string.Format("{0:f2}", bal);
                }
                else
                {
                    balance = "You are due to Pay £" + string.Format("{0:f2}", bal);

                    balance = balance.Replace("-", "").Trim();

                }


                param[30] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_Balance", balance);
                param[31] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter_DisplayType", DisplayCriteria);

                param[32] = new Microsoft.Reporting.WinForms.ReportParameter("CashTotalAmount", CashTotalAmount.ToStr());
                param[33] = new Microsoft.Reporting.WinForms.ReportParameter("AccountTotalAmount", AccountTotalAmount.ToStr());
                param[34] = new Microsoft.Reporting.WinForms.ReportParameter("CardTotalAmount", CardTotalAmount.ToStr());


             //   string strCommissionTotal = string.Format("{0:f2}", commissionTotal);
            //    param[31] = new Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_CommissionTotal", strCommissionTotal);

                
                
                //int minRows = 12;
                //if (cnt < minRows)
                //{
                //    for (int i = 0; i < minRows - cnt; i++)
                //    {
                //        this.DataSource.Add(new vu_DriverCommisionExpenses2 { Id = data.Id, BookingId = data.BookingId, });//, Passenger = data.Passenger, FromAddress = data.FromAddress, ToAddress = data.ToAddress });

                //    }

                //}.

                if (DisplayCriteria == "account_")
                    DisplayCriteria = "";

               // this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns." + DisplayCriteria + "rptDriverCommisionExpenses5.rdlc";


                reportViewer1.LocalReport.SetParameters(param);
                this.vu_DriverCommisionExpenses2BindingSource.DataSource = this.DataSource;
                this.vu_FleetDriverCommissionExpenseBindingSource.DataSource = this.DataSource2;

                // Create the PageSettings object
               // PageSettings pgSettings = new PageSettings
               // {
               //     PaperSize = new PaperSize("A4", 827, 1169), // A4 in hundredths of an inch
               //     Margins = new Margins(50, 50, 50, 50)       // Set margins (optional)
                
               // };

               //// Assign the PageSettings to the ReportViewer
               // reportViewer1.SetPageSettings(pgSettings);

                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }

        public bool SendEmailInternally(frmEmail frmE, string subject, string invoiceNo, string email)
        {


            frmE.ReportViewer1 = this.reportViewer1;
            frmE.FileTitle = "Commission for " + invoiceNo.ToStr();
            frmE.EmailSubject = subject;
            frmE.ToEmail = email;
            frmE.txtTo.Text = email;
            frmE.txtSubject.Text = subject;
            frmE.txtAttachment.Text = "Commission for " + invoiceNo;


           

            if (objSubCompany == null)
                frmE.SendEmail(true);
            else
                frmE.SendEmail(true, objSubCompany);

            return frmE.IsEmailSent;
            //         General.ShowEmailForm(reportViewer1, "Account Invoice # " + invoiceNo, email);

        }

      //  public static StringBuilder EmailSentQuery;

        public bool SendEmailAsynchronously(frmEmail frmE, string subject, string invoiceNo, string email)
        {


            frmE.ReportViewer1 = this.reportViewer1;
            frmE.FileTitle = "Commission for " + invoiceNo.ToStr();
            frmE.EmailSubject = subject;
            frmE.ToEmail = email;
           // frmE.txtTo.Text = email;
          //  frmE.txtSubject.Text = subject;
            frmE.AttachmentText = "Commission for " + invoiceNo;




          
                frmE.SendEmailAsync( objSubCompany);

            return frmE.IsEmailSent;
          
        }



        private List<Fleet_Driver_CommissionRange> GetSystemCommissionRange()
        {

            return (from a in General.GetQueryable<Gen_SysPolicy_CommissionPriceRange>(null).ToList()
                    select new Fleet_Driver_CommissionRange
                    {
                        DriverId = 0,
                        FromPrice = a.FromPrice,
                        ToPrice = a.ToPrice,
                        CommissionValue = a.CommissionValue


                    }).ToList();


        }



        int IsCheck = 0;
        public frmDriverCommisionTransactionExpensesReport5(int val)
        {
            InitializeComponent();

            IsCheck = val;
          //  this.Load += new EventHandler(frmInvoiceReport_Load);

            ComboFunctions.FillDriverNoCombo(ddlCompany);

            if (ddlCompany.SelectedValue == null)
                pnlCriteria.Visible = false;

            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTillDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.LastDayOfMonthValue());
        }


        public frmDriverCommisionTransactionExpensesReport5(IList LIST,DateTime from, DateTime till)
        {
            InitializeComponent();

           // IsCheck = val;
        //    this.Load += new EventHandler(frmInvoiceReport_Load);


            GridViewCheckBoxColumn col = new GridViewCheckBoxColumn();
            col.Width = 40;
            col.AutoSizeMode = BestFitColumnMode.None;
            col.HeaderText = "";
            col.Name = "Check";
            grdDriverCommission.Columns.Add(col);

            grdDriverCommission.DataSource = LIST;


            SetGridFormat();
            this.Load += FrmDriverCommisionTransactionExpensesReport5_Load;
                this.Shown += new EventHandler(frmDriverCommisionTransactionExpensesReport2_Shown);

            this.FormClosing += FrmDriverCommisionTransactionExpensesReport5_FormClosing;    
         

            lblCriteria.Text = "From : " + string.Format("{0:dd/MM/yyyy}", from) + " to " + string.Format("{0:dd/MM/yyyy}", till);

        }

        private void FrmDriverCommisionTransactionExpensesReport5_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (worker_Commission != null )
                {
                    if (worker_Commission.IsBusy)
                    {
                        if (  DialogResult.Yes == MessageBox.Show("Sending email is inProgress..." + Environment.NewLine + "Do you want to cancel this process?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            worker_Commission.CancelAsync();
                            IsCancelledWorker = true;
                            worker_Commission.Dispose();
                            worker_Commission = null;
                        }
                        else
                        {
                            e.Cancel = true;

                        }
                    }
                    else
                    {

                        IsCancelledWorker = true;
                        worker_Commission.Dispose();
                        worker_Commission = null;
                    }
                    

                }
            }
            catch
            {

            }
        }

        private void FrmDriverCommisionTransactionExpensesReport5_Load(object sender, EventArgs e)
        {
            SetGridFormat();
        }

        private void SetGridFormat()
        {

            try
            {
                if (grdDriverCommission.Rows.Count > 0)
                {



                    grdDriverCommission.Columns["CommissionId"].IsVisible = false;
                    grdDriverCommission.Columns["DriverId"].IsVisible = false;

                    grdDriverCommission.Columns["VAT"].IsVisible = false;

                    grdDriverCommission.Columns["SubCompanyId"].IsVisible = false;

                    grdDriverCommission.AllowAutoSizeColumns = true;
                    grdDriverCommission.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    grdDriverCommission.Columns["CommissionId"].IsVisible = false;
                    grdDriverCommission.Columns["DriverId"].IsVisible = false;

                    grdDriverCommission.Columns["VAT"].IsVisible = false;

                


                    grdDriverCommission.Columns["Check"].Width = 60;
                    grdDriverCommission.Columns["Driver"].Width = 260;

                }

            }
            catch
            {

            }
        }

        void frmDriverCommisionTransactionExpensesReport2_Shown(object sender, EventArgs e)
        {

            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ControlBox = true;
                if (grdDriverCommission.Rows.Count > 0)
                {



                    grdDriverCommission.Columns["CommissionId"].IsVisible = false;
                    grdDriverCommission.Columns["DriverId"].IsVisible = false;

                    grdDriverCommission.Columns["VAT"].IsVisible = false;

                    grdDriverCommission.AllowAutoSizeColumns = true;
                    grdDriverCommission.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;


                    grdDriverCommission.Columns["Check"].Width = 60;
                    grdDriverCommission.Columns["Driver"].Width = 260;


                    grdDriverCommission.Rows.ToList().ForEach(c => c.Cells["Check"].Value = true);
                    grdDriverCommission.ShowFilteringRow = true;
                    grdDriverCommission.EnableFiltering = true;

                    txtPreviewlabel.Text = "Preview " + "1" + " of " + grdDriverCommission.Rows.Count;




                    var row = grdDriverCommission.Rows.FirstOrDefault();

                    if (row != null)
                    {
                        SetDataSourceAndGenerateReport(row.Cells["CommissionId"].Value.ToInt(), row.Cells["VAT"].Value.ToDecimal());
                    }

                }
            }
            catch (Exception ex)
            {


            }



        }

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

        string cellValue = string.Empty;
        void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {

            if (e.CellElement is GridHeaderCellElement)
            {
                //    e.CellElement
                e.CellElement.BorderColor = _HeaderRowBorderColor;
                e.CellElement.BorderColor2 = _HeaderRowBorderColor;
                e.CellElement.BorderColor3 = _HeaderRowBorderColor;
                e.CellElement.BorderColor4 = _HeaderRowBorderColor;


                // e.CellElement.DrawBorder = false;
                e.CellElement.BackColor = _HeaderRowBackColor;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.Font = newFont;
                e.CellElement.ForeColor = Color.White;
                e.CellElement.DrawFill = true;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

            }

            else if (e.CellElement is GridFilterCellElement)
            {
                e.CellElement.Font = oldFont;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.White;
                e.CellElement.RowElement.BackColor = Color.White;
                e.CellElement.RowElement.NumberOfColors = 1;

                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;
            }

            else if (e.CellElement is GridDataCellElement)
            {



                e.CellElement.ToolTipText = e.CellElement.Text;
                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                e.CellElement.ForeColor = Color.Black;

                e.CellElement.Font = oldFont;


            }




        }



        public void ExportReport(string invoiceNo)
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
            saveFileDlg.FileName = "DriverCommisionTransaction-" + invoiceNo;

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
        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name == "btnUpdate")
            {

                GridViewRowInfo row = gridCell.RowInfo;
                

                if (row is GridViewDataRowInfo)
                {
                    long id = row.Cells[COLS.ID].Value.ToLong();
                    decimal fare = row.Cells[COLS.Charges].Value.ToDecimal();
                    decimal parking = row.Cells[COLS.Parking].Value.ToDecimal();
                    decimal waiting = row.Cells[COLS.Waiting].Value.ToDecimal();
                    decimal extraDrop = row.Cells[COLS.ExtraDrop].Value.ToDecimal();
                    decimal meetAndGreet = row.Cells[COLS.MeetAndGreet].Value.ToDecimal();
                    decimal CongtionCharge = row.Cells[COLS.CongtionCharge].Value.ToDecimal();
                    decimal TotalCharges = row.Cells[COLS.Total].Value.ToDecimal();


                    BookingBO objMaster = new BookingBO();
                    objMaster.GetByPrimaryKey(id);

                    if (objMaster.Current != null)
                    {
                        objMaster.Current.FareRate = fare;
                        objMaster.Current.ParkingCharges = parking;
                        objMaster.Current.WaitingCharges = waiting;
                        objMaster.Current.ExtraDropCharges = extraDrop;
                        objMaster.Current.MeetAndGreetCharges = meetAndGreet;
                        objMaster.Current.CongtionCharges = CongtionCharge;
                        objMaster.Current.TotalCharges = TotalCharges;


                        objMaster.Save();

                        ViewReport();
                    }


                }


            }

        }

      

        private void AddUpdateColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 50;

            col.Name = "btnUpdate";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Update";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }


        private void ViewReport()
        {
            int DriverId = ddlCompany.SelectedValue.ToInt();
            DateTime? fromDate = dtpFromDate.Value.ToDate();
            DateTime? tillDate = dtpTillDate.Value.ToDate();

            string error = string.Empty;
            if (DriverId == 0)
            {
                error += "Required : Company";
            }

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

            if (!string.IsNullOrEmpty(error))
            {
                ENUtils.ShowMessage(error);
                return;

            }


            if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                DisplayCriteria = "";

            }
            else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                DisplayCriteria = "account_";

            }
            else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                DisplayCriteria = "summary_";

            }

            lblCriteria.Text = "Account Invoice Report Related to '" + ddlCompany.Text.ToStr() + "', Date Range :" + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", tillDate);

            var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => a.DriverId == DriverId && a.TransDate >= fromDate && a.TransDate <= tillDate).ToList();
            int count = list.Count;

            this.DataSource = list;
            GenerateReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

            ViewReport();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        public void SendEmail(string invoiceNo,string email)
        {
            reportViewer1.Tag = "invoice";

            if (objSubCompany != null)
            {
                if (objSubCompany.UseDifferentEmailForInvoices.ToBool())
                {
                   // Gen_SubCompany objNewSubCompany = new Gen_SubCompany();
                   // objNewSubCompany = General.CopyPropertiesTo<Gen_SubCompany, Gen_SubCompany>(objSubCompany, objNewSubCompany);
                    General.ShowEmailForm(reportViewer1, "Driver Commission Transaction # " + invoiceNo, email, objSubCompany, false);
                }
                else
                {
                    General.ShowEmailForm(reportViewer1, "Driver Commission Transaction # " + invoiceNo, email, objSubCompany, false);
                }
            }
            else
            {

                if (AppVars.objSubCompany.UseDifferentEmailForInvoices.ToBool())
                {
                  //  Gen_SubCompany objNewSubCompany = new Gen_SubCompany();
                  //  objNewSubCompany = General.CopyPropertiesTo<Gen_SubCompany, Gen_SubCompany>(AppVars.objSubCompany, objNewSubCompany);
                    General.ShowEmailForm(reportViewer1, "Driver Commission Transaction # " + invoiceNo, email, AppVars.objSubCompany, false);
                }
                else
                {
                    General.ShowEmailForm(reportViewer1, "Driver Commission Transaction # " + invoiceNo, email, false);

                }


            }
        }

        //public static  TU CopyPropertiesTo<T, TU>(this T source, TU dest)
        //{
        //    var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
        //    var destProps = typeof(TU).GetProperties()
        //            .Where(x => x.CanWrite)
        //            .ToList();

        //    foreach (var sourceProp in sourceProps)
        //    {
        //        if (destProps.Any(x => x.Name == sourceProp.Name))
        //        {
        //            var p = destProps.First(x => x.Name == sourceProp.Name);
        //            if (p.CanWrite)
        //            { // check if the property can be set or no.
        //                p.SetValue(dest, sourceProp.GetValue(source, null), null);
        //            }
        //        }

        //    }

        //    return dest;

        //}

        private void grdDriverCommission_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row != null && e.Row is GridViewDataRowInfo)
            {
                 int TransId=  e.Row.Cells["CommissionId"].Value.ToInt();

                 SetDataSourceAndGenerateReport(TransId, e.Row.Cells["VAT"].Value.ToDecimal());


                 var row= grdDriverCommission.Rows.FirstOrDefault(c => c.Cells["CommissionId"].Value.ToLong() == TransId);

                 if (row != null)
                 {

                     txtPreviewlabel.Text = "Preview " + (row.Index + 1).ToInt() + " of " + grdDriverCommission.Rows.Count;
                 }
            }
        }


        private void SetDataSourceAndGenerateReport(int Id,decimal VAT)
        {
            if (Id > 0)
            {
                if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    DisplayCriteria = "";

                }
                else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    DisplayCriteria = "account_";

                }
                else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    DisplayCriteria = "summary_";

                }
                this.VAT = VAT;
                var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => a.Id == Id).OrderBy(c => c.PickupDate).ToList();
                int count = list.Count;

                this.DataSource = list;
                var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(c => c.CommissionId == Id).OrderBy(c => c.Date).ToList();
                this.DataSource2 = list2;

                //   frm.IsFareAndWaitingWise = this.IsFareAndWaitingWiseComm;

                GenerateReport();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = 0;


                if (grdDriverCommission.CurrentRow == null || (grdDriverCommission.CurrentRow is GridViewDataRowInfo) == false)
                    grdDriverCommission.CurrentRow = grdDriverCommission.Rows[rowIndex];


                if (grdDriverCommission.CurrentRow != null )
                {
                    if (grdDriverCommission.CurrentRow is GridViewDataRowInfo && (grdDriverCommission.CurrentRow.Index + 1) < grdDriverCommission.Rows.Count)
                    {
                        rowIndex = grdDriverCommission.CurrentRow.Index + 1;
                        grdDriverCommission.CurrentRow = grdDriverCommission.Rows[rowIndex];
                    }
                    else
                        rowIndex = grdDriverCommission.Rows.Count - 1;
                }


                if (rowIndex >= 0)
                {

                    var row = grdDriverCommission.Rows.FirstOrDefault(c => c.Index == rowIndex);

                    if (row != null)
                    {

                        int TransId = row.Cells["CommissionId"].Value.ToInt();

                        SetDataSourceAndGenerateReport(TransId, row.Cells["VAT"].Value.ToDecimal());
                    }


                    txtPreviewlabel.Text = "Preview " + (rowIndex + 1).ToInt() + " of " + grdDriverCommission.Rows.Count;

                }


              

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);


            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {

                int rowIndex = 0;

              


                if (grdDriverCommission.CurrentRow != null && grdDriverCommission.CurrentRow is GridViewDataRowInfo)// && (grdDriverCommission.CurrentRow.Index + 1) < grdDriverCommission.Rows.Count)
                {
                    rowIndex = grdDriverCommission.CurrentRow.Index - 1;

                    if (rowIndex == -1)
                        rowIndex = 0;


                    grdDriverCommission.CurrentRow = grdDriverCommission.Rows[rowIndex];


                }


                if (rowIndex >= 0)
                {

                    var row = grdDriverCommission.Rows.FirstOrDefault(c => c.Index == rowIndex);

                    if (row != null)
                    {

                        int TransId = row.Cells["CommissionId"].Value.ToInt();

                        SetDataSourceAndGenerateReport(TransId, row.Cells["VAT"].Value.ToDecimal());
                    }


                    txtPreviewlabel.Text = "Preview " + (rowIndex + 1).ToInt() + " of " + grdDriverCommission.Rows.Count;



                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);


            }
        }

        private void cbAllDrivers_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllDrivers.Checked == true)
            {
                if (grdDriverCommission.Rows.Count > 0)
                {
                    for (int i = 0; i < grdDriverCommission.Rows.Count; i++)
                    {
                        grdDriverCommission.Rows[i].Cells["Check"].Value = true;//..CurrentCell.Value;
                    }
                }
            }
            else if (cbAllDrivers.Checked == false)
            {
                if (grdDriverCommission.Rows.Count > 0)
                {
                    for (int i = 0; i < grdDriverCommission.Rows.Count; i++)
                    {
                        grdDriverCommission.Rows[i].Cells["Check"].Value = false;//..CurrentCell.Value;

                    }
                }
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintDocument(0);
        }


        string subject = string.Empty;
        List<GridViewRowInfo> rows = null;
        private void btnEmailAll_Click(object sender, EventArgs e)
        {

            subject= txtSubject.Text.Trim();

            if (string.IsNullOrEmpty(subject))
            {
                ENUtils.ShowMessage("Required : Email Subject");
                return;
            }


            cnt = 0;

            rows = grdDriverCommission.Rows.Where(c => c.Cells["Check"].Value.ToBool() == true).ToList();

            InitializeWorker();
            worker_Commission.RunWorkerAsync();
            StartWorker();
            //  EmailInvoices(0);
        }

        private void StartWorker()
        {
            Progessbar.Visible = true;
            dtpFromDate.Enabled = false;
            dtpTillDate.Enabled = false;
            grdDriverCommission.Enabled = false;
            btnNext.Enabled = false;
            btnPrev.Enabled = false;
            btnEmailAll.Enabled = false;
            btnEmailCurrent.Enabled = false;
            btnPrintAll.Enabled = false;
            btnPrintCurrent.Enabled = false;
            optAccountJobs.Enabled = false;
            optFullDetail.Enabled = false;
            optSummaryDetails.Enabled = false;
           

        }

        private void StopWorker()
        {
            Progessbar.Visible = false;
            Progessbar.Value1 = 0;
            percentage = 0;
            Progessbar.Text = string.Empty;
           
            dtpFromDate.Enabled = true;
            dtpTillDate.Enabled = true;
            grdDriverCommission.Enabled = true;
            btnNext.Enabled = true;
            btnPrev.Enabled = true;


            btnEmailAll.Enabled = true;
            btnEmailCurrent.Enabled = true;
            btnPrintAll.Enabled = true;
            btnPrintCurrent.Enabled = true;
            optAccountJobs.Enabled = true;
            optFullDetail.Enabled = true;
            optSummaryDetails.Enabled = true;

        }




        private bool EmailInvoices(long TransId)
        {

            bool IsSuccess = false;
            try
            {

                if (TransId > 0)
                {
                    string subjectX = txtSubject.Text.Trim();

                    if (string.IsNullOrEmpty(subjectX))
                    {
                        ENUtils.ShowMessage("Required : Email Subject");
                        return false;
                    }
                }
                    // List<GridViewRowInfo> rows = null;


                    if (TransId == 0)
                {

                    if(rows==null)
                       rows = grdDriverCommission.Rows.Where(c => c.Cells["Check"].Value.ToBool()==true ).ToList();
                }
                else
                    rows = grdDriverCommission.Rows.Where(c => c.Cells["CommissionId"].Value.ToLong() == TransId).ToList();



                //List<long> invoiceIds = rows.Select(c => c.Cells["CommissionId"].Value.ToLong()).ToList<long>();


                var count = 0;

                List<long> invoiceIds = new List<long>();

                if (TransId == 0)
                {

                    invoiceIds = rows.Select(c => c.Cells["CommissionId"].Value.ToLong()).ToList<long>();

                    count=  100 / rows.Count();
                }
                else
                {

                    invoiceIds = new List<long>();
                    invoiceIds.Add(TransId);

                }



                if (invoiceIds.Count > 0)
                {

                    frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);
                    frm.reportViewer1.Tag = "invoice";
                    if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        frm.DisplayCriteria = "";

                    }
                    else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        frm.DisplayCriteria = "account_";

                    }
                    else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        frm.DisplayCriteria = "summary_";

                    }


                    if (TransId == 0)
                    {
                        worker_Commission.ReportProgress(-1);
                    }
                    var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => invoiceIds.Contains(a.Id)).ToList();
                    var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(a => invoiceIds.Contains(a.Id)).ToList();

                    List<Fleet_Driver> driversList = General.GetQueryable<Fleet_Driver>(c => c.DriverTypeId == 2).ToList();

                    frmEmail frmEmail = new frmEmail(null, "", "");

                    Fleet_Driver objDriver = null;



                    foreach (var item in rows.Where(c => c.Cells["Check"].Value.ToBool()))
                    {
                        frm.DataSource = list.Where(c => c.Id == item.Cells["CommissionId"].Value.ToLong()).OrderBy(c => c.PickupDate).ToList();
                        frm.DataSource2 = list2.Where(c => c.CommissionId == item.Cells["CommissionId"].Value.ToLong()).OrderBy(c => c.Date).ToList();
                        frm.VAT = item.Cells["VAT"].Value.ToDecimal();
                        frm.GenerateReport();

                        objDriver = driversList.FirstOrDefault(c => c.Id == item.Cells["DriverId"].Value.ToInt());
                        //string email = driversList.FirstOrDefault(c => c.Id == item.Cells[COLS.Id].Value.ToInt()).DefaultIfEmpty().Email.ToStr().Trim();
                        string email = objDriver!=null ? objDriver.Email.ToStr().Trim(): "";

                        if (!string.IsNullOrEmpty(email))
                        {
                             IsSuccess= frm.SendEmailAsynchronously(frmEmail, subject, objDriver.DriverNo.ToStr().Trim(), email);
                        }

                        if (IsCancelledWorker)
                            break;

                        if (TransId == 0)
                        {

                            int Cal = percentage += count;

                            worker_Commission.ReportProgress(Cal);//100 * count / grdDriverCommission.Rows.Count);

                        }
                    }


                    if (frmEmail != null && frmEmail.IsDisposed == false)
                    {
                        frmEmail.Close();
                      

                    }


                    if (IsSuccess && TransId>0)
                    {

                        RadDesktopAlert alert = new RadDesktopAlert();
                        alert.ContentText = "Email has been sent successfully";
                        alert.Show();

                        try
                        {
                            GC.Collect();

                        }
                        catch
                        {

                        }
                    }
                    // ENUtils.ShowMessage("Email has been sent successfully");

                }
            }
            catch (Exception ex)
            {
              //  ENUtils.ShowMessage(ex.Message);

            }

            return IsSuccess;




        }

        private bool IsCancelledWorker = false;


        private void PrintDocument(long TransId)
        {

            try
            {
                try
                {

                    List<GridViewRowInfo> rows = null;


                    if (TransId == 0)
                    {


                        rows = grdDriverCommission.Rows.Where(c => c.Cells["Check"].Value.ToBool() == true).ToList();
                    }
                    else
                        rows= grdDriverCommission.Rows.Where(c => c.Cells["CommissionId"].Value.ToLong() ==TransId).ToList();


                    List<long> invoiceIds = new List<long>();

                    if (TransId == 0)
                    {

                        invoiceIds = rows.Select(c => c.Cells["CommissionId"].Value.ToLong()).ToList<long>();
                    }
                    else
                    {

                        invoiceIds = new List<long>();
                        invoiceIds.Add(TransId);

                    }


                    if (invoiceIds.Count > 0)
                    {

                        frmDriverCommisionTransactionExpensesReport5 frm = new frmDriverCommisionTransactionExpensesReport5(1);


                        if (objSubCompany == null)
                            objSubCompany = AppVars.objSubCompany;


                        frm.CompanyHeader = objSubCompany.CompanyName.ToStr().Trim();

                        if (optFullDetail.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                        {
                            frm.DisplayCriteria = "";

                        }
                        else if (optAccountJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                        {
                            frm.DisplayCriteria = "account_";

                        }
                        else if (optSummaryDetails.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                        {
                            frm.DisplayCriteria = "summary_";

                        }

                        var list = General.GetQueryable<vu_DriverCommisionExpenses2>(a => invoiceIds.Contains(a.Id)).ToList();
                        var list2 = General.GetQueryable<vu_FleetDriverCommissionExpense>(a => invoiceIds.Contains(a.Id)).ToList();


                        List<Fleet_Driver> driversList = General.GetGeneralList<Fleet_Driver>(c => c.DriverTypeId == 2);
                        frmEmail frmEmail = new frmEmail(null, "", "");


                        foreach (var item in rows)
                        {
                            frm.DataSource = list.Where(c => c.Id == item.Cells["CommissionId"].Value.ToLong()).OrderBy(c => c.PickupDate).ToList();
                            frm.DataSource2 = list2.Where(c => c.CommissionId == item.Cells["CommissionId"].Value.ToLong()).OrderBy(c => c.Date).ToList();
                            frm.VAT = item.Cells["VAT"].Value.ToDecimal();
                            frm.GenerateReport();

                            ReportPrintDocument rpt = new ReportPrintDocument(frm.reportViewer1.LocalReport);
                            rpt.Print();
                            rpt.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ENUtils.ShowMessage(ex.Message);

                }




            }
            catch (Exception ex)
            {


            }


        }

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {

            if(grdDriverCommission.CurrentRow!=null && grdDriverCommission.CurrentRow is GridViewDataRowInfo)
            {
                PrintDocument(grdDriverCommission.CurrentRow.Cells["CommissionId"].Value.ToLong());

            }
        }

        private void btnEmailCurrent_Click(object sender, EventArgs e)
        {
            if (grdDriverCommission.CurrentRow != null && grdDriverCommission.CurrentRow is GridViewDataRowInfo)
            {
                EmailInvoices(grdDriverCommission.CurrentRow.Cells["CommissionId"].Value.ToLong());

            }
        }

        private void optAccountJobs_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(args.ToggleState== Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int rowIndex = 0;
                if (grdDriverCommission.CurrentRow != null)
                {
                    if (grdDriverCommission.CurrentRow is GridViewDataRowInfo && (grdDriverCommission.CurrentRow.Index + 1) < grdDriverCommission.Rows.Count)
                    {
                        rowIndex = grdDriverCommission.CurrentRow.Index + 1;
                        grdDriverCommission.CurrentRow = grdDriverCommission.Rows[rowIndex];
                    }
                    else
                        rowIndex = grdDriverCommission.Rows.Count - 1;
                }


                if (rowIndex >= 0)
                {

                    var row = grdDriverCommission.Rows.FirstOrDefault(c => c.Index == rowIndex);

                    if (row != null)
                    {

                        int TransId = row.Cells["CommissionId"].Value.ToInt();

                        SetDataSourceAndGenerateReport(TransId, row.Cells["VAT"].Value.ToDecimal());
                    }


                    txtPreviewlabel.Text = "Preview " + (rowIndex + 1).ToInt() + " of " + grdDriverCommission.Rows.Count;

                }
            }
        }


        #region EmailAll

        private BackgroundWorker worker_Commission;
        int cnt = 0;
        public int percentage = 0;

        private void InitializeWorker()
        {
            if (worker_Commission == null)
            {
                worker_Commission = new BackgroundWorker();
                worker_Commission.DoWork += Worker_Commission_DoWork;

                worker_Commission.RunWorkerCompleted += Worker_Commission_RunWorkerCompleted;
                worker_Commission.ProgressChanged += Worker_Commission_ProgressChanged;
                worker_Commission.WorkerSupportsCancellation = true;
                worker_Commission.WorkerReportsProgress = true;

          
                Progessbar.Maximum = 100;
                Progessbar.Minimum = 0;
                Progessbar.Value1 = 0;
            }

        }
       
        private void Worker_Commission_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0)
            {

                cnt += 1;
                Progessbar.Value1 = e.ProgressPercentage;

            }
            else
                Progessbar.Value1 = 0;

            Progessbar.Text = String.Format("Sending Email {0} / {1}", cnt, rows.Count);
          
        }
      
        private void Worker_Commission_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IsCancelledWorker)
                    return;

                StopWorker();


                if (e.Result != null && e.Result.ToBool())
                {
                    RadDesktopAlert alert = new RadDesktopAlert();
                    alert.ContentText = "Email has been sent successfully";
                    alert.Show();
                    try
                    {
                        GC.Collect();
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

        }

        private void Worker_Commission_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


               

                bool isSuccess=  EmailInvoices(0);

                e.Result = isSuccess;


            }
            catch (Exception)
            {

               // throw;
            }
        }

        #endregion
    }
}
