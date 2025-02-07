using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Telerik.WinControls.UI;
using Taxi_BLL;
using Taxi_Model;
using Telerik.WinControls.UI.Docking;
using Utils;
using Telerik.WinControls;
using Taxi_AppMain.Forms;

namespace Taxi_AppMain
{
    public partial class frmCompanyInvoiceList : UI.SetupBase
    {
        InvoiceBO objMaster = null;
        int CompanyId = 0;
        public frmCompanyInvoiceList()
        {
            InitializeComponent();
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new InvoiceBO();

            this.SetProperties((INavigation)objMaster);

            grdLister.ShowRowHeaderColumn = false;
            grdLister.AllowEditRow = false;
            this.Shown += new EventHandler(frmCompanyInvoiceList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            this.btnPrintSelected.Click += new EventHandler(btnPrintSelected_Click);
        
            



        }


        public frmCompanyInvoiceList(int Id)
        {
            InitializeComponent();
            CompanyId = Id;
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new InvoiceBO();

            this.SetProperties((INavigation)objMaster);

            grdLister.ShowRowHeaderColumn = false;
            grdLister.AllowEditRow = false;
            this.Shown += new EventHandler(frmCompanyInvoiceList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            this.btnPrintSelected.Click += new EventHandler(btnPrintSelected_Click);
            




        }
     
        string TemplateName = "0";
     


   

        void btnPrintSelected_Click(object sender, EventArgs e)
        {
            PrintInvoices();
        }

        private string GetTemplate()
        {
            string temp = string.Empty;
            using (TaxiDataContext db = new TaxiDataContext())
            {
                temp = db.UM_Form_Templates.Where(c => c.UM_Form.FormName == "frmInvoiceReport" && c.IsDefault == true).Select(c => c.TemplateName).FirstOrDefault().ToStr();

            }

            return temp;
        }

        private void PrintInvoices()
        {
            try
            {
                string temp = GetTemplate();
            



                bool uselandscape = true; ;
                if (AppVars.objPolicyConfiguration.DefaultClientId.ToStr() == "!ndex_@ut0_$erv!ce$_Ltd")
                {
                    uselandscape = false;

                }
                else
                    if (temp == "Template48")
                {

                    uselandscape = false;
                }


                frmInvoiceReport frm=null;
                if (grdLister.Rows.Count(c => c.Cells["Check"].Value.ToBool()) > 0)
                {
                    foreach (var item in grdLister.Rows)
                    {
                        if (item.Cells["Check"].Value.ToBool() == true)
                        {

                            long Id = item.Cells["Id"].Value.ToLong();
                            if (Id > 0)
                            {
                                objMaster.GetByPrimaryKey(Id);

                                if (uselandscape)
                                {
                                    ReportPrintDocument_Landscape rpt = null;

                                    frm = new frmInvoiceReport();
                                    frm.ObjInvoice = objMaster.Current;
                                    frm.HasSplitByField = "None";
                                    var list = General.GetQueryable<vu_Invoice>(a => a.Id == Id).OrderBy(c => c.PickupDate).ToList();
                                    int count = list.Count;

                                    frm.DataSource = list;
                                    frm.GenerateReport();
                                    rpt = new ReportPrintDocument_Landscape(frm.reportViewer1.LocalReport);
                                    rpt.Print();
                                    rpt.Dispose();
                                }
                                else
                                {
                                    ReportPrintDocument rpt = null;

                                    frm = new frmInvoiceReport();
                                    frm.ObjInvoice = objMaster.Current;
                                    frm.HasSplitByField = "None";
                                    var list = General.GetQueryable<vu_Invoice>(a => a.Id == Id).OrderBy(c => c.PickupDate).ToList();
                                    int count = list.Count;

                                    frm.DataSource = list;
                                    frm.GenerateReport();
                                    rpt = new ReportPrintDocument(frm.reportViewer1.LocalReport);
                                    rpt.Print();
                                    rpt.Dispose();
                                }
                            }
                        }
                    }
                }
                else
                {
                    ENUtils.ShowMessage("Please select invoice to print");
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        void frmCompanyInvoiceList_Shown(object sender, EventArgs e)
        {
            try
            {

                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;



                this.InitializeForm("frmInvoice");

                TemplateName=  GetTemplate();
                LoadInvoiceList(0);


                GridViewCommandColumn cmdcol = new GridViewCommandColumn();
                cmdcol.Width = 80;
                cmdcol.Name = "btnEmail";
                cmdcol.UseDefaultText = true;
                cmdcol.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                cmdcol.DefaultText = "Email";
                cmdcol.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                grdLister.Columns.Add(cmdcol);

                cmdcol = new GridViewCommandColumn();
                cmdcol.Width = 80;
                cmdcol.Name = "btnInfo";
                cmdcol.UseDefaultText = true;
                cmdcol.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                cmdcol.DefaultText = "Info";
                cmdcol.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                grdLister.Columns.Add(cmdcol);

                grdLister.AddEditColumn();

                if (this.CanDelete)
                {
                    grdLister.AddDeleteColumn();
                    grdLister.Columns["btnDelete"].Width = 70;
                }


                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["CompanyId"].IsVisible = false;
                grdLister.Columns["Email"].IsVisible = false;


                grdLister.Columns["InvoiceNo"].HeaderText = "Invoice No";
                grdLister.Columns["InvoiceNo"].Width = 80;

                grdLister.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                grdLister.Columns["InvoiceDate"].Width = 100;

                (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy";
                (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy}";

                grdLister.Columns["Company"].HeaderText = "Account";
                grdLister.Columns["Company"].Width = 150;
                grdLister.Columns["Address"].Width = 240;


                grdLister.Columns["Telephone"].Width = 100;

                grdLister.Columns["InvoiceTotal"].Width = 100;
                grdLister.Columns["InvoiceTotal"].HeaderText = "Invoice Total";

                grdLister.Columns["btnEdit"].Width = 70;


                UI.GridFunctions.SetFilter(grdLister);


                btnVatCalculator.Visible = AppVars.listUserRights.Count(c => c.functionId == "SHOW VAT CALCULATOR") > 0;
                grdLister.Columns["ExtraTotal"].VisibleInColumnChooser = false;
                grdLister.Columns["ExtraTotal"].IsVisible = false;


                if (grdLister.Columns.Contains("Check"))
                {
                    (grdLister.Columns["Check"] as GridViewCheckBoxColumn).ReadOnly = false;

                    grdLister.Columns["Check"].Width = 20;
                }
                grdLister.AllowEditRow = true;


                grdLister.EnableHotTracking = false;

                

            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }

        private void LoadInvoiceList(int order)
        {



            if (AppVars.listUserRights.Count(c => c.formName == "frmCompanyInvoiceList" && c.functionId == "PRINT INVOICE LIST") > 0)
            {
                if (grdLister.Columns.Contains("Check") == false)
                {
                    GridViewCheckBoxColumn col = new GridViewCheckBoxColumn();
                    col.Width = 20;
                    col.AutoSizeMode = BestFitColumnMode.None;
                    col.HeaderText = "";
                    col.Name = "Check";
                    //col.IsPinned = true;
                    grdLister.Columns.Add(col);
                }
                btnPrintSelected.Visible = true;

                chkAll.Visible = true;
                btnEmail.Visible = true;
            }
            else
            {
                btnPrintSelected.Visible = false;
            }

            int accTypeId = ddlAccountType.SelectedValue.ToInt();

            if (order == 0)
            {



                using (TaxiDataContext db = new TaxiDataContext())
                {


                    var query =( from a in db.Invoices
                                join b in db.Gen_Companies on a.CompanyId equals b.Id
                                where (a.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT) && (a.CompanyId == CompanyId || CompanyId == 0)
                                && (accTypeId==0 || b.AccountTypeId==accTypeId)

                                //  var query = from a in General.GetQueryable<Invoice>(c => (c.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT) && (c.CompanyId==CompanyId || CompanyId==0) )

                                orderby a.InvoiceDate descending

                                select new
                                {
                                    Id = a.Id,
                                    InvoiceNo = a.InvoiceNo,
                                    InvoiceDate = a.InvoiceDate,
                                    a.CompanyId,
                                    Code=b.CompanyCode,
                                    Company = b.CompanyName,
                                    Address = b.Address.Replace("\n"," "),
                                    Telephone =b.TelephoneNo,
                                    BookedBy = a.AddLog,
                                    NetTotal=a.InvoiceTotal,
                                    InvoiceTotal = GetTotal(a, b),
                                    ExtraTotal=a.TotalInvoiceAmount,
                                    b.Email
                                }).ToList();


                    if(dtpFromDate.Value.Year>2000 && dtpToDate.Value.Year>2000)
                    {
                        query = query.Where(c => c.InvoiceDate >= dtpFromDate.Value && c.InvoiceDate <= dtpToDate.Value).ToList();

                    }

                    grdLister.DataSource = query.ToList();
                }
            }
            else if (order == 1)
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var query = (from a in db.Invoices
                                join b in db.Gen_Companies on a.CompanyId equals b.Id
                                where a.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT
                                  && (accTypeId == 0 || b.AccountTypeId == accTypeId)
                                 //  var query = (from a in General.GetQueryable<Invoice>(c => (c.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT) && (c.CompanyId == CompanyId || CompanyId == 0))

                                 select new
                                {
                                    Id = a.Id,
                                    InvoiceNo = a.InvoiceNo,
                                    InvoiceDate = a.InvoiceDate,
                                    a.CompanyId,
                                    Code = b.CompanyCode,
                                    Company = b.CompanyName,
                                    Address = b.Address.Replace("\n", " "),
                                    Telephone = b.TelephoneNo,
                                    BookedBy = a.AddLog,
                                    NetTotal = a.InvoiceTotal,
                                    InvoiceTotal = GetTotal(a, b),
                                    ExtraTotal = a.TotalInvoiceAmount,
                                    b.Email
                                }).AsEnumerable().OrderBy(item => item.InvoiceNo, new NaturalSortComparer<string>()).ToList();
                    if (dtpFromDate.Value.Year > 2000 && dtpToDate.Value.Year > 2000)
                    {
                        query = query.Where(c => c.InvoiceDate >= dtpFromDate.Value && c.InvoiceDate <= dtpToDate.Value).ToList();

                    }

                    grdLister.DataSource = query.ToList();
                }

            }
            else if (order == 2)
            {

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var query = (from a in db.Invoices
                                 join b in db.Gen_Companies on a.CompanyId equals b.Id
                                 where a.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT
                                   && (accTypeId == 0 || b.AccountTypeId == accTypeId)
                                 // var query = (from a in General.GetQueryable<Invoice>(c => (c.InvoiceTypeId == Enums.INVOICE_TYPE.ACCOUNT) && (c.CompanyId == CompanyId || CompanyId == 0))


                                 select new
                                 {
                                     Id = a.Id,
                                     InvoiceNo = a.InvoiceNo,
                                     InvoiceDate = a.InvoiceDate,
                                     a.CompanyId,
                                     Code = b.CompanyCode,
                                     Company = b.CompanyName,
                                     Address = b.Address.Replace("\n", " "),
                                     Telephone =b.TelephoneNo,
                                     BookedBy = a.AddLog,
                                     NetTotal = a.InvoiceTotal,
                                     InvoiceTotal = GetTotal(a, b),
                                     ExtraTotal = a.TotalInvoiceAmount,
                                     b.Email
                                 }).AsEnumerable().OrderByDescending(item => item.InvoiceNo, new NaturalSortComparer<string>()).ToList();
                    if (dtpFromDate.Value.Year > 2000 && dtpToDate.Value.Year > 2000)
                    {
                        query = query.Where(c => c.InvoiceDate >= dtpFromDate.Value && c.InvoiceDate <= dtpToDate.Value).ToList();

                    }

                    grdLister.DataSource = query.ToList();
                }
            }
            
           

         
            grdLister.Columns["BookedBy"].HeaderText = "Booked by";

            grdLister.Columns["NetTotal"].IsVisible = false;

            grdLister.Columns["Email"].IsVisible = false;


        }


        private decimal? GetTotal(Invoice i, Gen_Company objCompany)
        {
            decimal? invoiceGrandTotal = i.InvoiceTotal;
            try
            {
              
                decimal discountAmount = 0.00m;
                decimal DiscountPercent = 0.00m;
                decimal valueAddedTax = 0.0m;
                decimal AdminFeesPercent = 0.00m;
                decimal AdminFees = 0.00m;
                decimal extraTotal = 0.00m;
                string CompanyAccountNo = string.Empty;


                if (objCompany != null)
                {
                    //  Gen_Company objCompany = General.GetObject<Gen_Company>(c => c.Id == companyId);
                    if(TemplateName.ToStr().ToLower()=="template10")
                    extraTotal = i.TotalInvoiceAmount.ToDecimal();

                    invoiceGrandTotal = invoiceGrandTotal - extraTotal;
                    if (objCompany != null)
                    {


                        if (objCompany.DiscountPercentage.ToDecimal() > 0)
                        {
                            discountAmount = (invoiceGrandTotal.ToDecimal() * objCompany.DiscountPercentage.ToDecimal()) / 100;
                            DiscountPercent = objCompany.DiscountPercentage.ToDecimal();
                            //     HasDiscount = "1";
                        }

                        decimal GrandAmount = (invoiceGrandTotal.ToDecimal()-discountAmount);
                        if (objCompany.AdminFees > 0)
                        {
                      
                            AdminFees = Math.Round(((invoiceGrandTotal.ToDecimal() * objCompany.AdminFees.ToDecimal()) / 100).ToDecimal(), 2);
                            AdminFeesPercent = objCompany.AdminFees.ToDecimal();


                            if (objCompany.AdminFeeType.ToStr().ToLower() == "amount")
                                AdminFees = objCompany.AdminFees.ToDecimal();


                            AdminFees = Math.Round(AdminFees, 2);

                        }

                        if (objCompany.HasVat.ToBool())
                        {


                            valueAddedTax = (GrandAmount.ToDecimal() * 20) / 100;
                           
                            if (objCompany.VatOnlyOnAdminFees.ToBool())
                            {
                                valueAddedTax = (AdminFees * 20) / 100;
                              

                            }
                            else
                            {
                                valueAddedTax = ((GrandAmount.ToDecimal() + AdminFees) * 20) / 100;

                            }

                            valueAddedTax = Math.Round(valueAddedTax, 2);

                        }

                    }

                }



               

                invoiceGrandTotal =Math.Round ( ( ((invoiceGrandTotal + valueAddedTax) - discountAmount) + AdminFees+extraTotal).ToDecimal(), 2);

               




            }
            catch
            {

            }
            return Math.Round(invoiceGrandTotal.ToDecimal(), 2);



        }



        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Invoice ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    int InvoiceId = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
                    invoice_Payment obj = General.GetObject<invoice_Payment>(c => c.invoiceId == InvoiceId);
                    if (obj == null)
                    {
                        RadGridView grid = gridCell.GridControl;
                        grid.CurrentRow.Delete();
                    }
                    else
                    {
                        ENUtils.ShowMessage("You Cannot Delete a Record Payment Exits..");
                    }
                    
                }
            }
            else if (gridCell.ColumnInfo.Name.ToLower() == "btnedit")
            {
                ViewDetailForm();


            }

            else if (gridCell.ColumnInfo.Name.ToLower() == "btninfo")
            {
                ViewInfo();


            }
            else if (gridCell.ColumnInfo.Name.ToLower() == "btnemail")
            {
                SendEmail();
            }
        }
        private void EmailInvoices()
        {
            try
            {
               // string subject = txtSubject.Text.Trim();

               

                var rows = grdLister.Rows.Where(c => c.Cells["Check"].Value.ToBool()).ToList();



                List<long> invoiceIds = rows.Select(c => c.Cells["Id"].Value.ToLong()).ToList<long>();


                List<GridViewRowInfo> rowsDept = new List<GridViewRowInfo>();
               

                if (invoiceIds.Count > 0)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        frmInvoiceReport frm = new frmInvoiceReport();
                        frm.HasSplitByDept = false;

                        frm.ObjInvoice = objMaster.Current;

                        var list =db.vu_Invoices.Where(a => invoiceIds.Contains(a.Id)).ToList();

                        frmEmail frmEmail = new frmEmail(null, "", "");

                        foreach (var item in rows)
                        {

                            string inv = item.Cells["Id"].Value.ToStr().Trim();




                            if (inv.ToStr().Trim().Length > 0 && inv.ToStr().Trim().IsNumeric())
                            {

                                frm.DataSource = list.Where(c => c.Id == inv.ToLong()).OrderBy(c => c.PickupDate).ToList();


                                frm.GenerateReport();

                               
                                string invoiceNo = list.FirstOrDefault(c => c.Id == inv.ToLong()).DefaultIfEmpty().InvoiceNo.ToStr().Trim();



                                frm.reportViewer1.Tag = "invoice";
                                frm.SendEmailInternally(frmEmail, frm.DataSource[0].CompanyName + " - INVOICE "+ invoiceNo, invoiceNo, item.Cells["Email"].Value.ToStr().Trim());
                            }


                        }


                    }
                    ENUtils.ShowMessage("Email has been sent successfully");

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }





        }


        private void SendEmail()
        {


            // if (objMaster.Current == null || objMaster.Current.Id == 0) return;


            GridViewRowInfo row = grdLister.CurrentRow;

            if (row != null && row is GridViewDataRowInfo)
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {






                    int Id = row.Cells["Id"].Value.ToInt();                  
                    int companyId = row.Cells["CompanyId"].Value.ToInt();
                    string invoiceNo = row.Cells["InvoiceNo"].Value.ToStr();

                 
                    frmInvoiceReport frm = new frmInvoiceReport();

                    frm.HasSplitByField = "";// ddlSplitBy.Text;
                    frm.ObjInvoice =db.Invoices.FirstOrDefault(c=>c.Id== Id);                  
                 
                   
                    frm.DataSource =db.vu_Invoices.Where(a => a.Id == Id).OrderBy(c => c.PickupDate).ToList(); 
                    frm.GenerateReport();


                    if (companyId != 0)
                    {
                        string email = db.Gen_Companies.Where(c => c.Id == companyId).Select(c => c.Email).FirstOrDefault();

                        frm.SendEmail(invoiceNo, email);

                    }
                }
            }

        }




        private void ViewInfo()
        {
            try
            {


                GridViewRowInfo row = grdLister.CurrentRow;

                if (row != null && row is GridViewDataRowInfo)
                {

                    int Id = row.Cells["Id"].Value.ToInt();
                    int companyId = row.Cells["CompanyId"].Value.ToInt();                    
                    decimal netAmount = row.Cells["NetTotal"].Value.ToDecimal();

                    decimal extras = row.Cells["ExtraTotal"].Value.ToDecimal();

                    if (TemplateName.ToStr().ToLower() != "template10")
                        extras = 0.00m;

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        decimal invoiceGrandTotal = netAmount;
                        decimal discountAmount = 0.00m;
                        decimal DiscountPercent = 0.00m;
                        decimal valueAddedTax = 0.0m;
                        decimal AdminFeesPercent = 0.00m;
                        decimal AdminFees = 0.00m;
                        string HasAdminFees = string.Empty;
                        string HasDiscount = "0";
                      

                        if (companyId != 0)
                        {
                            var objCompany = db.Gen_Companies.Where(c => c.Id == companyId).Select(args => new { args.Address, args.HasVat, args.AdminFees, args.AdminFeeType, args.DiscountPercentage, args.VatOnlyOnAdminFees })
                                .FirstOrDefault();
                            if (objCompany != null)
                            {

                             //   extras= db.ExecuteQuery<decimal>("select (isnull( parkingcharges,0.00)+isnull(extradropcharges,0.00)) from invoice_charges inner join booking  (no lock) on booking.id=invoice_charges.bookingId where invoiceid=" + Id).FirstOrDefault();

                                netAmount = netAmount-extras ;

                                if (objCompany.DiscountPercentage.ToDecimal() > 0)
                                {
                                    discountAmount = (netAmount * objCompany.DiscountPercentage.ToDecimal()) / 100;
                                    DiscountPercent = objCompany.DiscountPercentage.ToDecimal();
                                    HasDiscount = "1";
                                }

                                decimal grandTotal = netAmount - discountAmount;

                                if (objCompany.AdminFees > 0)
                                {

                                    AdminFeesPercent = objCompany.AdminFees.ToDecimal();
                                    HasAdminFees = "1";

                                    if (objCompany.AdminFeeType.ToStr().ToLower() == "percent")
                                    {
                                        AdminFees = (grandTotal * objCompany.AdminFees.ToDecimal()) / 100;

                                    }
                                    else
                                        AdminFees = objCompany.AdminFees.ToDecimal();

                                    AdminFees = Math.Round(AdminFees, 2);
                                }

                                if (objCompany.HasVat.ToBool())
                                {




                                    if (objCompany.VatOnlyOnAdminFees.ToBool())
                                    {
                                        valueAddedTax = (AdminFees * 20) / 100;


                                    }
                                    else
                                    {
                                        valueAddedTax = ( (grandTotal+ AdminFees) * 20) / 100;
                                    }

                                    valueAddedTax = Math.Round(valueAddedTax, 2);

                                }

                              
                                

                            }

                            invoiceGrandTotal =Math.Round ( ( (netAmount + valueAddedTax + AdminFees+extras) - discountAmount).ToDecimal(),2);


                            string newLine = Environment.NewLine;

                            StringBuilder text = new StringBuilder();

                            text.Append("<html>");


                            text.Append("<b>" + "Invoice # : " + row.Cells["InvoiceNo"].Value.ToStr() + " @ <color=Red>" + string.Format("{0:dd-MMM-yyyy}", row.Cells["InvoiceDate"].Value) + "</b>");
                            text.Append("<br><br>");
                            text.Append(newLine + newLine);
                            text.Append("<br><b><color=Black>Company : " + row.Cells["Company"].Value.ToStr() + "</b>");
                            text.Append(newLine + newLine);
                            text.Append("<br><b>Address : " + objCompany.Address.ToStr() + " </b> ");

                            text.Append("<br><br>");
                            text.Append(newLine + newLine);

                            text.Append("<br><b>Net Total :        </b>" + Math.Round(netAmount.ToDecimal(), 2));

                            text.Append(newLine);


                            if (HasDiscount.ToStr() == "1")
                            {
                                text.Append("<b>Discount       " + string.Format("{0:##0.##}", DiscountPercent) + "%" + " : " + Math.Round(discountAmount, 2));
                                text.Append(newLine);
                            }


                            if (valueAddedTax.ToDecimal() > 0)
                            {
                                text.Append("<br><b><color=Red>VAT :                  </b>" + Math.Round(valueAddedTax.ToDecimal(), 2));
                                text.Append(newLine);
                            }


                            if (AdminFees.ToDecimal() > 0)
                            {
                                text.Append("<br><b><color=Red>Admin Fees :    </b>" + Math.Round(AdminFees.ToDecimal(), 2));
                                text.Append(newLine);
                            }

                            if (extras.ToDecimal() > 0)
                            {
                                text.Append("<br><b><color=Red>Total Parking/Extra :    </b>" + Math.Round(extras.ToDecimal(), 2));
                                text.Append(newLine);
                            }



                            invoiceGrandTotal = (netAmount + valueAddedTax + AdminFees+extras) - discountAmount;
                            text.Append("<br><b><color=Red>Invoice Total : </b>" + Math.Round(invoiceGrandTotal, 2));
                            text.Append("<br><br>");
                            text.Append(newLine);

                            frmCustomScreenInvoiceTip frmTip = new frmCustomScreenInvoiceTip(text.ToString());
                            frmTip.StartPosition = FormStartPosition.CenterParent;
                            frmTip.ShowInTaskbar = false;
                            frmTip.ShowDialog();
                            KeyEventArgs key = frmTip.LastSendEventArgs;

                            frmTip.Dispose();


                        }


                    }

                }
            }
            catch (Exception ex)
            {


            }
        }

        void frmLocationList_Load(object sender, EventArgs e)
        {
        }

        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ViewDetailForm();
        }

        private void ViewDetailForm()
        {
            try
            {

              

                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    long id=grdLister.CurrentRow.Cells["Id"].Value.ToLong();
                 //   Cursor.Position = new Point(Cursor.Position.X, 100);
                  //  System.Threading.Thread.Sleep(100);

               //     grdLister.ShowItemToolTips = false;
                  // 
                       General.ShowCompanyInvoiceForm(id);

                      

                       //if (screenTip != null)
                       //{

                         
                       //    screenTip.DisposeChildren();
                       //    screenTip.Dispose();
                       //    screenTip = null;
                       //  //  screenTip.Enabled = false;
                       //}
                }
                else
                {
                    ENUtils.ShowMessage("Please select a record");
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        void Grid_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {

                objMaster = new InvoiceBO();

                try
                {

                    objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());

                    int InvoiceId = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
                    invoice_Payment obj = General.GetObject<invoice_Payment>(c => c.invoiceId == InvoiceId);
                    if (obj == null)
                    {
                        objMaster.Delete(objMaster.Current);
                    }
                    else
                    {
                        ENUtils.ShowMessage("You Can not delete a record..");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (objMaster.Errors.Count > 0)
                        ENUtils.ShowMessage(objMaster.ShowErrors());
                    else
                    {
                        ENUtils.ShowMessage(ex.Message);

                    }
                    e.Cancel = true;

                }
            }
        }







        public override void RefreshData()
        {
            PopulateData();
        }



        public override void PopulateData()
        {
            int orderNo = 0;

            if (OPTASC.Checked)
                orderNo = 1;
            else if (OPTDESC.Checked)
                orderNo = 2;

            LoadInvoiceList(orderNo);

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            int orderNo = 0;

            if (OPTASC.Checked)
                orderNo = 1;
            else if (OPTDESC.Checked)
                orderNo = 2;
            //  txtSearch.Text = string.Empty;
            LoadInvoiceList(orderNo);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateData();

            }
        }

        private void btnSageExport_Click(object sender, EventArgs e)
        {
            frmSageExport frm = new frmSageExport();
            frm.ShowDialog();


        }

        private void OPTDESC_CheckedChanged(object sender, EventArgs e)
        {

         
            if ((sender as RadioButton).Checked)
            {
                int val = -1;
                if ((sender as RadioButton).Name == "optDefault")
                    val = (sender as RadioButton).Tag.ToInt();
                else if ((sender as RadioButton).Name == "OPTASC")
                    val = (sender as RadioButton).Tag.ToInt();
                else if ((sender as RadioButton).Name == "OPTDESC")
                    val = (sender as RadioButton).Tag.ToInt();


                if (val != -1)
                    LoadInvoiceList(val);
            }
        }

        private void btnVatCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                frmVatCalculator frm = new frmVatCalculator();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                frm.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            dtpFromDate.Text = "";
            dtpFromDate.DateTimePickerElement.Value = null;
            dtpToDate.DateTimePickerElement.Value = null;
            ddlAccountType.SelectedValue = null;
            PopulateData();
        }

        private void chkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(args.ToggleState== Telerik.WinControls.Enumerations.ToggleState.On)
            {
                grdLister.Rows.ToList().ForEach(c => c.Cells["Check"].Value = true);
            }else
            {
                grdLister.Rows.ToList().ForEach(c => c.Cells["Check"].Value = false);
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            EmailInvoices();
        }

        private void ddlAccountType_Enter(object sender, EventArgs e)
        {
           if(ddlAccountType.DataSource==null)
            {
                ComboFunctions.FillAccountTypeCombo(ddlAccountType);
            }
        }
    }
}

