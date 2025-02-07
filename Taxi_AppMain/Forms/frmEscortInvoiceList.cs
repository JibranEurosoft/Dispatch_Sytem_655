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

namespace Taxi_AppMain
{
    public partial class frmEscortInvoiceList : UI.SetupBase
    {
        InvoiceBO objMaster = null;
        RadDropDownMenu Items = null;
        public frmEscortInvoiceList()
        {
            InitializeComponent();
            grdLister.ContextMenuOpening += GrdLister_ContextMenuOpening;
            Items = new RadDropDownMenu();
            Items.BackColor = Color.Orange;

            RadMenuItem Items1 = new RadMenuItem("Pay Invoice");
            Items1.ForeColor = Color.Blue;
            Items1.BackColor = Color.Blue;
            Items1.Font = new Font("Tahoma", 10, FontStyle.Bold);
            Items1.Click += Items1_Click;
            Items.Items.Add(Items1);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new InvoiceBO();

            this.SetProperties((INavigation)objMaster);

            grdLister.ShowRowHeaderColumn = false;
            this.Shown += new EventHandler(frmCompanyInvoiceList_Shown);
            
            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);

        }

        private void GrdLister_RowFormatting(object sender, RowFormattingEventArgs e)
        {
        
        }

        private void GrdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {
                GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                if (cell == null)
                    return;

                else if (cell.GridControl.Name == "grdLister")
                {
                    e.ContextMenu = Items;
                    return;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void Items1_Click(object sender, EventArgs e)
        {
            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewRowInfo)
            {
                PaymetForm(grdLister.CurrentRow);
            }
        }

        public void PaymetForm(GridViewRowInfo row)
        {

            try
            {

                //frmInvoicePayment frm = new frmInvoicePayment(id, InvoiceNo, Total);
                frmPaymentEscort frm = new frmPaymentEscort(row.Cells["EscortId"].Value.ToLong(), row.Cells["Id"].Value.ToInt());
                frm.MaximizeBox = false;
                frm.ShowDialog();
                frm.Dispose();

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



                this.InitializeForm("frmEscortInvoice");
                LoadInvoiceList();

                //grdLister.AddEditColumn();

                //if (this.CanDelete)
                //{
                //    grdLister.AddDeleteColumn();
                //    grdLister.Columns["btnDelete"].Width = 70;
                //}


                AddEditColumn(grdLister);

                if (this.CanDelete)
                {
                    AddDeleteColumn(grdLister);
                    grdLister.Columns["btnDelete"].Width = 70;
                }


                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["EscortId"].IsVisible = false;
                grdLister.Columns["InvoicePaymentTypeId"].IsVisible = false;
                grdLister.Columns["InvoiceNo"].HeaderText = "Invoice No";
                grdLister.Columns["InvoiceNo"].Width = 80;

                grdLister.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                grdLister.Columns["InvoiceDate"].Width = 100;

                (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy";
                (grdLister.Columns["InvoiceDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy}";

                grdLister.Columns["Escort"].Width = 150;
                grdLister.Columns["Address"].Width = 240;


                grdLister.Columns["Telephone"].Width = 100;

                grdLister.Columns["Email"].Width = 110;


                grdLister.Columns["InvoiceTotal"].Width = 100;
                grdLister.Columns["InvoiceTotal"].HeaderText = "Invoice Total";

                grdLister.Columns["btnEdit"].Width = 70;


                UI.GridFunctions.SetFilter(grdLister);

            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }

        public static void AddEditColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();

            col.Name = "btnEdit";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Edit";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);


        }

        private void AddDeleteColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();

            col.Name = "btnDelete";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Delete";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }
        int invoicePaymentType = 0;
        private void LoadInvoiceList()
        {
            if (chkAll.Checked == true)
                invoicePaymentType = 0;
            else if (rdPaid.Checked == true)
                invoicePaymentType = Enums.INVOICE_PAYMENTTYPES.FULLPAID;
            else
                invoicePaymentType = Enums.INVOICE_PAYMENTTYPES.UNPAID;

            var query = from a in General.GetQueryable<Invoice>(c => c.InvoiceTypeId == Enums.INVOICE_TYPE.ESCORT_INVOICE)
                        where    (invoicePaymentType == 0 || a.InvoicePaymentTypeID == invoicePaymentType)
                            //&& (InvoicePaymentTypeId == 0 || b.InvoicePaymentTypeID == InvoicePaymentTypeId.ToInt())
                        select new
                        {
                            Id = a.Id,
                            InvoiceNo = a.InvoiceNo,
                            InvoiceDate =a.InvoiceDate,
                            EscortId = a.EscortId,
                            Escort = a.Gen_Escort.EscortName,
                            Address = a.Gen_Escort.AddressLine1,
                            Telephone = a.Gen_Escort.TelephoneNo,
                            Email=a.Gen_Escort.EmailAddress,
                            InvoiceTotal=a.InvoiceTotal,
                            InvoicePaymentTypeId = a.InvoicePaymentTypeID
                        };


            grdLister.DataSource = query.AsEnumerable().OrderBy(item => item.InvoiceNo, new NaturalSortComparer<string>()).ToList();

            ConditionalFormattingObject objPaymentType = new ConditionalFormattingObject();
            objPaymentType.ApplyToRow = true;
            objPaymentType.RowBackColor = Color.YellowGreen;
            objPaymentType.ConditionType = ConditionTypes.Greater;
            objPaymentType.TValue1 = "2";
            grdLister.Columns["InvoicePaymentTypeId"].ConditionalFormattingObjectList.Add(objPaymentType);

            grdLister.ViewCellFormatting += GrdLister_ViewCellFormatting;
            //grdLister.DataSource = query.OrderBy(c=>c.InvoiceNo).ToList();


        }

        private void GrdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            {
                try
                {
                    if (e.CellElement is GridHeaderCellElement)
                    {
                        //e.CellElement
                        e.CellElement.BorderColor = _HeaderRowBorderColor;
                        e.CellElement.BorderColor2 = _HeaderRowBorderColor;
                        e.CellElement.BorderColor3 = _HeaderRowBorderColor;
                        e.CellElement.BorderColor4 = _HeaderRowBorderColor;


                        //e.CellElement.DrawBorder = false;
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




                        //if (e.CellElement.RowElement.IsSelected == true)
                        //{

                        //    e.CellElement.RowElement.NumberOfColors = 1;
                        //    e.CellElement.RowElement.BackColor = Color.DeepSkyBlue;

                        //    e.CellElement.NumberOfColors = 1;
                        //    e.CellElement.BackColor = Color.DeepSkyBlue;
                        //    e.CellElement.ForeColor = Color.White;
                        //    e.CellElement.Font = newFont;


                        //}


                        //else
                        //{
                        //    e.CellElement.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.TwoWayBindingLocal);

                        //}

                        e.CellElement.DrawFill = false;









                    }
                }
                catch { }
            }
        }

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
        RadButtonElement button = null;
        string cellValue = string.Empty;

        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);
        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);


     

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Invoice ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    int InvoiceId = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
                    //invoice_Payment obj = General.GetObject<invoice_Payment>(c => c.invoiceId == InvoiceId);
                  //  if (obj == null)
                  //  {
                        RadGridView grid = gridCell.GridControl;
                        grid.CurrentRow.Delete();
                   // }
                    //else
                    //{
                    //    ENUtils.ShowMessage("You Cannot Delete a Record Payment Exits..");
                    //}
                    
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
            try
            {


                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    long id=grdLister.CurrentRow.Cells["Id"].Value.ToLong();

                    General.ShowEscortInvoiceForm(id);
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

                   // int InvoiceId = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
                  //  invoice_Payment obj = General.GetObject<invoice_Payment>(c => c.invoiceId == InvoiceId);
                    //if (obj == null)
                    //{
                        objMaster.Delete(objMaster.Current);
                    //}
                    //else
                    //{
                    //    ENUtils.ShowMessage("You Can not delete a record..");
                    //    return;
                    //}
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

        public void RefreshColor()
        {
            
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                invoicePaymentType = 0;
                PopulateData();

            }
        }

        private void rdPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPaid.Checked == true)
            {
                invoicePaymentType = Enums.INVOICE_PAYMENTTYPES.FULLPAID;
                PopulateData();
            }
        }

        private void rdUnPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdUnPaid.Checked == true)
            {
                invoicePaymentType = Enums.INVOICE_PAYMENTTYPES.UNPAID;
                PopulateData();
            }
        }
    }
}

