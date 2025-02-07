using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using Utils;
using Taxi_Model;
using DAL;
using UI;
using Telerik.WinControls.UI;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Taxi_AppMain.Classes;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls;
using System.Collections;

namespace Taxi_AppMain
{
    public partial class frmPaymentEscort : UI.SetupBase
    {
        int InvoiceId = 0;
        bool IsCompanyLoaded = false;
        
        public frmPaymentEscort()
        {
            InitializeComponent();
         
          //  FormatePaymenttGride();
            FillCombo();

            ddlEscort.SelectedValueChanged += DdlCompany_SelectedValueChanged;
        
            this.Load += FrmPayment_Load;
        }

        private void SpinElement_TextChanging(object sender, TextChangingEventArgs e)
        {
            
        }
        long CompanyId = 0;
        public frmPaymentEscort(long CompanyId, int InvoiceId)
        {
            InitializeComponent();
         
            this.CompanyId = CompanyId;
           
            this.Load += FrmPayment_Load;
            
            this.InvoiceId = InvoiceId;
        }


        private void FrmPayment_Load(object sender, EventArgs e)
        {
            IsCompanyLoaded = true;
            FillCombo();
            if (InvoiceId > 0)  
            {
                ddlEscort.SelectedValue = this.CompanyId;
                ddlEscort.Enabled = false;
                Display();



            }
        }

        private void DdlCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsCompanyLoaded == false) return;

            Display();
        }

        private void Display()
        {
            try
            {
                int Id = ddlEscort.SelectedValue.ToInt();
            //    grdPayment.RowCount = 0;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var item = (from a in db.Invoices.Where(c =>  c.Id == InvoiceId)
                             
                                select new
                                {
                                    Id = a.Id,
                                    a.InvoiceTotal,
                                    a.TotalInvoiceAmount,
                                    a.InvoiceNo,
                                    a.EscortId,
                                    a.CurrentBalance,
                                   a.Remarks,
                                   a.InvoicePaymentTypeID
                                }).FirstOrDefault();

                    var objCreditNote=  db.InvoiceCreditNotes.Where(c => c.InvoiceId == InvoiceId).Select(c=>new { c.Id, c.CreditNoteTotal }).FirstOrDefault();


                    if (item == null)
                    {
                        lblMessage.Visible = true;
                       // grdPayment.Rows.Clear();
                        txtInvoiceno.Text = "";
                       // txtBalance.Value = 0;
                        txtInvoiceTotal.Value = 0.00m;
                        return;
                    }


                    lblMessage.Visible = false;
                    InvoiceId = item.Id.ToInt(); ;
                    txtInvoiceno.Text = item.InvoiceNo;


                    txtNotes.Text = item.Remarks;


                    txtInvoiceTotal.Value = item.InvoiceTotal.ToDecimal();


                    if (item.InvoicePaymentTypeID.ToInt() == 3)
                        btnPayment.Visible = true;
  

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        
       
        private void FillCombo()
        {
            //ComboFunctions.FillEscortCombo(ddlCompany);
            ComboFunctions.FillEscortCombo1(ddlEscort);
        }

        InvoiceBO objMaster = new InvoiceBO();
        void DisplayRecords()
        {
            
        }
        public struct COL_PAYMENT
        {
            public static string ID = "ID";
            public static string MASTERID = "MASTERID";

            public static string PAYMENT = "PAYMENT";
            public static string BALANCE = "BALANCE";
            public static string DATE = "DATE";
            public static string AddOn = "AddOn";
            public static string AddBy = "AddBy";

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }

    
  

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {
                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete Payment. ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {
                    try
                    {

                    
                    RadGridView grid = gridCell.GridControl;

                    

                        grid.CurrentRow.Delete();
                    
                    }
                    catch (Exception ex)
                    {
                        ENUtils.ShowMessage(ex.Message);
                    }
                }
            }

        }
        private void btnExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void grdPayment_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            
        }
        public override void Save()
        {
            try
            {
              

                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.ExecuteQuery<int>("exec stp_makeescortinvoicepayment {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", InvoiceId.ToInt(),txtInvoiceno.Text,AppVars.LoginObj.UserName.ToStr(),ddlEscort.Text.Trim(), ddlEscort.SelectedValue.ToInt(),txtInvoiceTotal.Value,txtInvoiceTotal.Value,0.00m,txtNotes.Text.Trim(), Enums.INVOICE_PAYMENTTYPES.FULLPAID,"insert");


                    }
          

            }
            catch (Exception ex)
            {
               
            }


        }

        
        protected override void OnClosed(EventArgs e)
        {
          
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            Save();

            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {


                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.ExecuteQuery<int>("exec stp_makeescortinvoicepayment {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", InvoiceId.ToInt(), txtInvoiceno.Text, AppVars.LoginObj.UserName.ToStr(), ddlEscort.Text.Trim(), ddlEscort.SelectedValue.ToInt(), txtInvoiceTotal.Value, txtInvoiceTotal.Value, 0.00m, txtNotes.Text.Trim(), Enums.INVOICE_PAYMENTTYPES.FULLPAID, "delete");


                }

                this.Close();

            }
            catch (Exception ex)
            {

            }

        }
    }
}
