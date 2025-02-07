﻿using System;
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

namespace Taxi_AppMain
{
    public partial class frmPreCustomerInvoiceList  : UI.SetupBase
    {
        InvoiceBO objMaster = null;
        public frmPreCustomerInvoiceList()
        {
            InitializeComponent();
        //    this.Load +=new EventHandler(frmCompanyInvoiceList_Load);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new InvoiceBO();

            this.SetProperties((INavigation)objMaster);
            //   grdLister.CellFormatting+=new CellFormattingEventHandler(grdLister_CellFormatting);

            grdLister.ShowRowHeaderColumn = false;
            this.Shown += new EventHandler(frmCompanyInvoiceList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            //    grdLister.EnableFastScrolling = true;

        }

        void frmCompanyInvoiceList_Shown(object sender, EventArgs e)
        {

            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

         

            this.InitializeForm("frmPreCustomerInvoice");
            LoadInvoiceList();

            grdLister.AddEditColumn();

            if (this.CanDelete)
            {
                grdLister.AddDeleteColumn();
                grdLister.Columns["btnDelete"].Width = 70;
            }


            grdLister.Columns["Id"].IsVisible = false;

            grdLister.Columns["InvoiceNo"].HeaderText = "Invoice No";
            grdLister.Columns["InvoiceNo"].Width = 80;

            grdLister.Columns["InvoiceDate"].HeaderText = "Invoice Date";
            grdLister.Columns["InvoiceDate"].Width = 100;

            (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy";
            (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy}";

            grdLister.Columns["Customer"].Width = 150;
            grdLister.Columns["Address"].Width = 250;


            grdLister.Columns["Telephone"].Width = 100;
            grdLister.Columns["Telephone"].HeaderText = "Telephone No";

            grdLister.Columns["MobileNo"].Width = 100;
            grdLister.Columns["MobileNo"].HeaderText = "Mobile No";

            grdLister.Columns["InvoiceTotal"].Width = 100;
            grdLister.Columns["InvoiceTotal"].HeaderText = "Invoice Total";

            grdLister.Columns["btnEdit"].Width = 70;
       

            


            UI.GridFunctions.SetFilter(grdLister);
                


        }

        private void LoadInvoiceList()
        {

            var query = from a in General.GetQueryable<Invoice>(c=>c.InvoiceTypeId==Enums.INVOICE_TYPE.PRE_INVOICE_CUSTOMER)
                   
                        select new
                        {
                            Id = a.Id,
                            InvoiceNo = a.InvoiceNo,
                            InvoiceDate =a.InvoiceDate,
                            Customer = a.Customer.Name,
                            Address = a.Customer.Address1,
                            Telephone=a.Customer.TelephoneNo,
                            MobileNo=a.Customer.MobileNo,
                            InvoiceTotal=a.InvoiceTotal
                        };


            grdLister.DataSource = query.OrderByDescending(c => c.InvoiceDate).ToList();
        
        }

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Invoice ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {


                    RadGridView grid = gridCell.GridControl;
                    grid.CurrentRow.Delete();
                }
            }
            else if (gridCell.ColumnInfo.Name.ToLower() == "btnedit")
            {
                ViewDetailForm();


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

            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {
                General.ShowPreCustomerInvoiceForm(grdLister.CurrentRow.Cells["Id"].Value.ToLong());
            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
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
                    objMaster.Delete(objMaster.Current);


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

            LoadInvoiceList();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
          //  txtSearch.Text = string.Empty;
            LoadInvoiceList();
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




    }
}

