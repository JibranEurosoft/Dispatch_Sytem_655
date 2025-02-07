using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Taxi_BLL;
using Utils;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using System.Collections;

namespace Taxi_AppMain
{
    public partial class rptfrmJobsList : UI.SetupBase
    {
        public rptfrmJobsList()
        {
            InitializeComponent();

            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;



            this.grdPaymentTypes.CellBeginEdit += new GridViewCellCancelEventHandler(grdPaymentTypes_CellBeginEdit);
            this.pnlCriteria.Click += new EventHandler(pnlCriteria_Click);
            this.grdLister.Click += new EventHandler(pnlCriteria_Click);
            optSortDesc.CheckedChanged += new EventHandler(optSortDesc_CheckedChanged);
            grdLister.ContextMenuOpening += new ContextMenuOpeningEventHandler(grdLister_ContextMenuOpening);
            this.chkAllVehicle.ToggleStateChanged += new StateChangedEventHandler(chkAllVehicle_ToggleStateChanged);
            ddlSubCompany.Enter += DdlSubCompany_Enter;
            ddlTransferredSubCompanyId.Enter += DdlTransferredSubCompanyId_Enter;

            this.FormClosing += RptfrmJobsList_FormClosing;
            grdLister.KeyDown += GrdLister_KeyDown;
         
        }
        Forms.frmCustomScreenTip frmTip = null;

        private void GrdLister_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.I)
                {

                    if (grdLister.CurrentRow is GridViewDataRowInfo && grdLister.IsInEditMode == false)
                    {

                        long id = grdLister.CurrentRow.Cells["Id"].Value.ToLong();


                        frmTip = new Forms.frmCustomScreenTip(id);
                        frmTip.StartPosition = FormStartPosition.CenterParent;
                        frmTip.ShowInTaskbar = false;
                        frmTip.ShowDialog();
                        KeyEventArgs key = frmTip.LastSendEventArgs;

                        frmTip.Dispose();
                        frmTip = null;



                        if (key.KeyCode == Keys.Up || key.KeyCode == Keys.Down)
                        {
                            GrdLister_KeyDown(null, key);
                         
                        }
                       
                    }

                }
                else if(e.KeyCode== Keys.Up)
                {
                    //int index = grdLister.ChildRows.FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == grdLister.CurrentRow.Cells["Id"].Value.ToLong()).Index;
                    //grdLister.CurrentRow = grdLister.row[(index - 1)];


                    int  index = this.grdLister.Rows.ToList().FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == grdLister.CurrentRow.Cells["Id"].Value.ToLong()).Index;

                    if (index - 1 >= 0)
                        grdLister.CurrentRow = grdLister.Rows.ToList().FirstOrDefault(c => c.Index == (index - 1));
                }
                else if(e.KeyCode== Keys.Down)
                {
                    int index = this.grdLister.Rows.ToList().FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == grdLister.CurrentRow.Cells["Id"].Value.ToLong()).Index;

                    if (index + 1 < grdLister.Rows.Count)
                        grdLister.CurrentRow = grdLister.Rows.ToList().FirstOrDefault(c => c.Index == (index + 1));

                }
                
            }
            catch
            {

            }
        }

        private void RptfrmJobsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
            GC.Collect();
        }

        private void DdlTransferredSubCompanyId_Enter(object sender, EventArgs e)
        {
            if(ddlTransferredSubCompanyId.DataSource==null)
            {
                ComboFunctions.FillSubCompanyCombo(ddlTransferredSubCompanyId,false);
            }
        }

        private void DdlSubCompany_Enter(object sender, EventArgs e)
        {
            if (ddlSubCompany.DataSource == null)
            {
                ComboFunctions.FillSubCompanyCombo(ddlSubCompany,false);
            }
        }

        void chkAllVehicle_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                ddlCompanyVehicle.SelectedValue = null;
                ddlCompanyVehicle.Enabled = false;
                //ddlAllDriver.SelectedValue = 0;
            }
            else
            {
                if (ddlCompanyVehicle.DataSource == null)
                {
                    ComboFunctions.FillVehicleCombo(ddlCompanyVehicle);
                }
                ddlCompanyVehicle.Enabled = true;
            }
        }

        RadDropDownMenu objMenu = null;

        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {


            if (objMenu == null)
            {
                objMenu = new RadDropDownMenu();


                RadMenuItem item = new RadMenuItem("View Booking");  // 11 index
                item.ForeColor = Color.Black;
                item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.Click += new EventHandler(ViewBooking_Click);
                objMenu.Items.Add(item);

                item = new RadMenuItem("Copy Booking");  // 11 index
                item.ForeColor = Color.Black;
                item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.Click += new EventHandler(CopyBooking_Click);
                objMenu.Items.Add(item);


                item = new RadMenuItem("Copy Text");  // 11 index
                item.ForeColor = Color.Black;
                item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.Click += new EventHandler(CopyText_Click);
                objMenu.Items.Add(item);


            }
            e.ContextMenu = objMenu;



        }

        void ViewBooking_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDetailForm();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        void CopyText_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {

                    Clipboard.Clear();
                    Clipboard.SetText(grdLister.CurrentCell.Value.ToStr());


                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


        void CopyBooking_Click(object sender, EventArgs e)
        {
            try
            {
                long jobId = 0;


                jobId = grdLister.CurrentRow.Cells["Id"].Value.ToLong();
                CopyBooking(jobId);

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void CopyBooking(long jobId)
        {

            if (jobId > 0)
            {

                AppVars.objCopyBooking = General.GetObject<Booking>(c => c.Id == jobId);


            }

        }

        void optSortDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (optSortAsc.Tag != null)
                return;
            ViewReport();
        }


        void pnlCriteria_Click(object sender, EventArgs e)
        {
            grdPaymentTypes.Visible = false;
            btnSelectPaymentType.ToggleState = ToggleState.Off;
        }


        void grdPaymentTypes_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            //if (grdPaymentTypes.CurrentRow is GridViewRowInfo && grdPaymentTypes.CurrentRow != null)
            //{


            if (e.Column != null && e.Column.Name == COLSP.PaymentType)
                e.Cancel = true;

            try
            {


                string Payment = string.Join(",", grdPaymentTypes.Rows.Where(c => c.Cells[COLSP.Check].Value.ToBool()).Select(c => c.Cells[COLSP.PaymentType].Value.ToStr()).ToArray<string>());
                txtPaymentTypes.Text = Payment;
            }
            catch (Exception ex)
            {


            }

        }


        string PaymentType = string.Empty;



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
            try
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

                //else if (e.CellElement is GridDataCellElement)
                //{



                //    e.CellElement.ToolTipText = e.CellElement.Text;
                //    e.CellElement.BorderColor = Color.DarkSlateBlue;
                //    e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                //    e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                //    e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                //    e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                //    e.CellElement.ForeColor = Color.Black;

                //    e.CellElement.Font = oldFont;

                //}


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


                    if (e.Row.Cells[COLS.IsProcessed].Value != null)
                    {

                        e.CellElement.RowElement.BackColor = Color.YellowGreen;
                        e.CellElement.RowElement.NumberOfColors = 1;
                        e.CellElement.RowElement.DrawFill = true;
                    }
                    else
                    {
                        //  e.CellElement.RowElement.BackColor = Color.White;
                        //   e.CellElement.RowElement.NumberOfColors = 1;
                        e.CellElement.RowElement.DrawFill = false;
                    }
                }

                if (e.CellElement.RowInfo is GridViewSummaryRowInfo)
                {
                    e.CellElement.DrawFill = true;
                    e.CellElement.GradientStyle = GradientStyles.Solid;
                    e.CellElement.BackColor = Color.Gainsboro;
                    e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
                    e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
                    e.CellElement.ForeColor = Color.Red;
                }
            }
            catch
            {


            }

        }


      


        private void ShowUpdateAgentCommButton(bool show)
        {

            lblAgent.Visible = show;
            numAgentComm.Visible = show;
            btnUpdateAll.Visible = show;
        }

        private void rptfrmJobsList_Load(object sender, EventArgs e)
        {
            try
            {
                //  dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date;

                var dt = DateTime.Now.AddDays(-7);

                dtpFromDate.Value = new DateTime(dt.Year, dt.Month, dt.Day).Date;


                dtpFromTime.Value = dtpFromDate.Value.Value.Date + TimeSpan.Zero;

                TimeSpan tillTime = TimeSpan.Zero;

                TimeSpan.TryParse("23:59:59", out tillTime);

                dt = DateTime.Now.AddDays(1);

                dtpToDate.Value = new DateTime(dt.Year, dt.Month, dt.Day).Date;



                dtptilltime.Value = dtpToDate.Value.Value.Date + tillTime;
            }
            catch(Exception ex)
            {
                dtpFromDate.Value = DateTime.Now.GetStartOfCurrentWeek().ToDate();
                TimeSpan tillTime = TimeSpan.Zero;

                TimeSpan.TryParse("23:59:59", out tillTime);
                dtpFromTime.Value = dtpFromDate.Value.Value.Date + TimeSpan.Zero;
                dtpToDate.Value = DateTime.Now.AddDays(1).ToDate();
                dtptilltime.Value = dtpToDate.Value.Value.Date + tillTime;
            }



            ddluser.Enter += Ddluser_Enter;

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "ID";
            col.Name = "Id";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Ref #";
            col.Name = COLS.RefNumber;
            col.Width = 40;
            grdLister.Columns.Add(col);

            //GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
            //colDt.Name = COLS.BookingDate;
            //colDt.ReadOnly = true;
            //colDt.HeaderText = "Booking Date";
            //grdLister.Columns.Add(colDt);

            GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
            colDt.Name = COLS.PickupDate;
            colDt.ReadOnly = true;
            colDt.Width = 70;
            colDt.HeaderText = "Pickup Date-Time";
            grdLister.Columns.Add(colDt);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = false;
            col.HeaderText = "Passenger";
            col.Name = COLS.Passenger;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
             col.IsVisible = true;
            col.ReadOnly = true;
            col.HeaderText = "Mobile No";
            col.Name = "MobileNo";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = true;
            col.HeaderText = "Tel No";
            col.Name ="TelNo";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.ReadOnly = true;
            col.Name = COLS.OldPickupPoint;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = false;
            col.HeaderText = "Pickup Point";
            col.Name = COLS.PickupPoint;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Via";
            col.Name = COLS.Via;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = true;
            col.Width = 40;

            col.HeaderText = "Notes";
            col.Name = COLS.Notes;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.ReadOnly = false;
            col.Width = 50;
            col.HeaderText = "Payment Ref";
            col.Name = COLS.PaymentRef;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.ReadOnly = true;
            col.VisibleInColumnChooser = false;
            col.Name = COLS.OldDestination;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            //     col.IsVisible = false;
            col.ReadOnly = false;
            col.HeaderText = "Destination";
            col.Name = COLS.Destination;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = false;
            col.HeaderText = "Journey";
            col.Width = 40;
            col.Name = COLS.Journey;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = false;
            col.HeaderText = "Special Req.";
            col.Width = 60;
            col.Name = COLS.SpecialReq;
            grdLister.Columns.Add(col);



            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = COLS.Fare;
            colD.Name = COLS.Fare;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "Extra Charges";
            colD.IsVisible = false;
            colD.Name = COLS.Extra;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "Drv Parking";
            colD.Name = COLS.DrvParking;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);



            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces =0;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "W/T";
            colD.Name = COLS.WaitingTime;
            colD.Maximum = 9999999;
        //    colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "Drv Waiting";
            colD.Name = COLS.DrvWaiting;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);






            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "A/C Price";
            colD.Name = COLS.AccFare;
            //   colD.Width = 70;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "A/C Parking";
            colD.Name = COLS.AccParking;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);



            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "A/C Waiting";
            colD.Name = COLS.AccWaiting;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.IsVisible = false;
            grdLister.Columns.Add(colD);



            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Agent Comm.";
            colD.Name = COLS.AgentComm;
            // colD.Width = 70;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Cust. Price";
            colD.Name = COLS.CustFare;
            colD.VisibleInColumnChooser = false;
            // colD.Width = 70;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);




            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = false;
            colD.HeaderText = "Booking Fee";
            colD.Name = COLS.BookingFee;
            colD.VisibleInColumnChooser = true;

            colD.IsVisible = AppVars.objPolicyConfiguration.PickCommissionDeductionFromJobsTotal.ToBool();

            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(colD);


            //col = new GridViewTextBoxColumn();

            //col.ReadOnly = true;
            //col.Name = COLS.Account;
            //col.HeaderText = COLS.Account;
            //grdLister.Columns.Add(col);

            GridViewComboBoxColumn colCombo = new GridViewComboBoxColumn();
            colCombo.Name = COLS.Account;
            colCombo.HeaderText = COLS.Account;
            colCombo.DataSource = General.GetQueryable<Gen_Company>(c=>c.IsClosed==false).Select(args => new
            {
                args.CompanyName,
                args.Id
            }

                                                        ).OrderBy(c => c.CompanyName).ToList();
            colCombo.DisplayMember = "CompanyName";
            colCombo.ValueMember = "Id";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;

            grdLister.Columns.Add(colCombo);



            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = true;
            col.HeaderText = "Order No";
            col.Name = "OrderNo";
            grdLister.Columns.Add(col);



            GridViewDecimalColumn dec = new GridViewDecimalColumn();
            dec.DecimalPlaces = 2;
            dec.VisibleInColumnChooser = true;
            dec.Name = "Mileage";
            dec.HeaderText = "Mileage";
            dec.IsVisible = false;
            dec.ReadOnly = true;
            grdLister.Columns.Add(dec);


            GridViewComboBoxColumn paymentTypeCombo = new GridViewComboBoxColumn();
            paymentTypeCombo.Name = COLS.PaymentType;
            paymentTypeCombo.HeaderText = COLS.PaymentType;

            paymentTypeCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            paymentTypeCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            paymentTypeCombo.ReadOnly = false;
            grdLister.Columns.Add(paymentTypeCombo);



            col = new GridViewTextBoxColumn();
            col.IsVisible = false;

            col.Name = COLS.OldPaymentType;
            grdLister.Columns.Add(col);




            col = new GridViewTextBoxColumn();
            //  col.IsVisible = false;
            col.ReadOnly = true;
            col.Name = COLS.Driver;
            col.HeaderText = COLS.Driver;
            col.Width = 40;
            grdLister.Columns.Add(col);






            colCombo = new GridViewComboBoxColumn();
            colCombo.Name = COLS.Vehicle;
            colCombo.HeaderText = COLS.Vehicle;
            colCombo.DataSource = General.GetQueryable<Fleet_VehicleType>(null).Select(args => new
            {
                args.VehicleType,
                args.Id
            }
            ).ToList();

            colCombo.DisplayMember = "VehicleType";
            colCombo.ValueMember = "Id";
            colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colCombo.ReadOnly = false;
            grdLister.Columns.Add(colCombo);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.EscortNo;
            col.Name = COLS.EscortNo;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.EscortPrice;
            col.Name = COLS.EscortPrice;
            col.ReadOnly = true;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            grdLister.Columns.Add(col);


            //col = new GridViewTextBoxColumn();
            //// col.IsVisible = false;
            //col.HeaderText = COLS.Vehicle;
            //col.Name = COLS.Vehicle;
            //col.ReadOnly = true;
            //grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.HeaderText = COLS.Status;
            col.Name = COLS.Status;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Operator";
            col.Name = "Operator";
            col.ReadOnly = false;
            col.VisibleInColumnChooser = true;
            grdLister.Columns.Add(col);

            //col = new GridViewTextBoxColumn();
            //col.HeaderText = COLS.EscortName;
            //col.Name = COLS.EscortName;
            //col.ReadOnly = true;
            //col.IsVisible = false;
            //grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.HeaderText = "Booked By";
            col.Name = COLS.BookedBy;
            col.ReadOnly = false;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.HeaderText = "Invoice #";
            col.Name = COLS.InvoiceNo;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.HeaderText = "Despatch By";
            col.Name = COLS.DespatchBy;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            GridViewTextBoxColumn cbcol = new GridViewTextBoxColumn();
            cbcol.Name = COLS.IsProcessed;
            cbcol.IsVisible = false;
            grdLister.Columns.Add(cbcol);


            grdLister.Columns[COLS.RefNumber].HeaderText = "Ref #";

            grdLister.Columns[COLS.Fare].HeaderText = "Fare £";
            grdLister.Columns[COLS.PickupPoint].HeaderText = "Pickup Point";

            grdLister.Columns[COLS.Destination].HeaderText = "Destination";


            //  grdLister.Columns[COLS.BookingDate].HeaderText = "Booking Date";

            //   (grdLister.Columns[COLS.BookingDate] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
            //  (grdLister.Columns[COLS.BookingDate] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


            (grdLister.Columns[COLS.PickupDate] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
            (grdLister.Columns[COLS.PickupDate] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


            grdLister.Columns[COLS.PickupDate].HeaderText = "Pickup Date-Time";
            grdLister.Columns[COLS.Account].HeaderText = "A/C";

            grdLister.Columns[COLS.DespatchBy].HeaderText = "Despatched By";


          
            grdLister.CellEndEdit += new GridViewCellEventHandler(grdLister_CellEndEdit2);

            UM_Form_Template objTemplate = General.GetObject<UM_Form_Template>(c => c.UM_Form.FormName == this.Name && c.IsDefault == true);

            if (objTemplate != null)
            {
                templateNo = objTemplate.TemplateName;


                if(AppVars.objPolicyConfiguration.DefaultClientId.ToStr()== "AscOt.C@rs")
                {
                    templateNo = "Template7";

                }

                if (objTemplate.ApplyDriverReduction.ToBool())
                {

                    grdLister.CellEndEdit += new GridViewCellEventHandler(grdLister_CellEndEdit);


                }


                if (objTemplate.ShowSpecialColumns.ToBool())
                    grdLister.Tag = 1;


            }


            if (templateNo.ToLower() == "template1")
            {
                grdLister.Columns[COLS.Notes].IsVisible = false;
                grdLister.Columns[COLS.BookedBy].IsVisible = false;
                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.AccFare].IsVisible = false;
                grdLister.Columns[COLS.CustFare].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = false;
            }

            else if (templateNo.ToLower() == "template2")
            {
                grdLister.Columns[COLS.Notes].IsVisible = false;
                grdLister.Columns[COLS.DespatchBy].IsVisible = false;
                grdLister.Columns[COLS.Status].IsVisible = false;
                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.AccFare].IsVisible = false;
                grdLister.Columns[COLS.CustFare].IsVisible = false;
            }
            else if (templateNo.ToLower() == "template3")
            {
                grdLister.Columns[COLS.Notes].IsVisible = false;
                grdLister.Columns[COLS.BookedBy].IsVisible = false;

                grdLister.Columns[COLS.AccFare].IsVisible = false;
                grdLister.Columns[COLS.CustFare].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = false;

            }
            else if (templateNo.ToLower() == "template4")
            {
                grdLister.Columns[COLS.Notes].IsVisible = false;
                grdLister.Columns[COLS.BookedBy].IsVisible = false;
                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.DespatchBy].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = false;

            }

            else if (templateNo.ToLower() == "template5")
            {
                grdLister.Columns[COLS.PaymentRef].IsVisible = true;
                grdLister.Columns[COLS.Notes].IsVisible = false;

                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.DespatchBy].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = true;
                grdLister.Columns[COLS.CustFare].IsVisible = false;


                grdLister.Columns[COLS.Fare].ReadOnly = false;
                grdLister.Columns[COLS.AccFare].ReadOnly = false;
                grdLister.Columns[COLS.AgentComm].IsVisible = true;
                grdLister.Columns[COLS.AgentComm].ReadOnly = false;
                grdLister.AllowEditRow = true;



                grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
                grdLister.CellBeginEdit += new GridViewCellCancelEventHandler(grdLister_CellBeginEdit);

            }
            else if (templateNo.ToLower() == "template6")
            {
                grdLister.Columns[COLS.PaymentRef].IsVisible = true;
                grdLister.Columns[COLS.Notes].IsVisible = false;
                // grdLister.Columns[COLS.BookedBy].IsVisible = false;
                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.DespatchBy].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = true;
                grdLister.Columns[COLS.CustFare].IsVisible = false;


                grdLister.Columns[COLS.Fare].ReadOnly = false;
                grdLister.Columns[COLS.AccFare].ReadOnly = false;
                grdLister.Columns[COLS.AgentComm].IsVisible = false;
                grdLister.AllowEditRow = true;



                grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
                grdLister.CellBeginEdit += new GridViewCellCancelEventHandler(grdLister_CellBeginEdit);

            }
            else if (templateNo.ToLower() == "template7")
            {
                grdLister.Columns[COLS.PaymentRef].IsVisible = true;
                grdLister.Columns[COLS.Notes].IsVisible = false;
              
                grdLister.Columns[COLS.InvoiceNo].IsVisible = false;
                grdLister.Columns[COLS.DespatchBy].IsVisible = false;
                grdLister.Columns[COLS.Via].IsVisible = true;
                grdLister.Columns[COLS.CustFare].IsVisible = false;


                grdLister.Columns[COLS.Fare].ReadOnly = false;
                grdLister.Columns[COLS.AccFare].ReadOnly = false;
                grdLister.Columns[COLS.AgentComm].IsVisible = false;
                grdLister.AllowEditRow = true;

                grdLister.Columns[COLS.PickupPoint].ReadOnly = true;
                grdLister.Columns[COLS.Destination].ReadOnly = true;
                grdLister.Columns[COLS.Vehicle].ReadOnly = true;
                grdLister.Columns[COLS.Passenger].ReadOnly = true;
                grdLister.Columns[COLS.Via].ReadOnly = true;
                grdLister.Columns[COLS.SpecialReq].ReadOnly = true;

                grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
                grdLister.CellBeginEdit += new GridViewCellCancelEventHandler(grdLister_CellBeginEdit);
                optSortAsc.Tag = 1;
                optSortAsc.Checked = true;
                optSortAsc.Tag = null;
            }

            AddUpdateColumn(grdLister);


            this.btnSelectPaymentType.ToggleStateChanged += new StateChangedEventHandler(btnSelectPaymentType_ToggleStateChanged);
            FillCombo();
            FormatPaymentTypeGrid();
            LoadPaymentTypes();


            if (listofPaymentTypes != null)
            {

                paymentTypeCombo.DataSource = listofPaymentTypes;
                paymentTypeCombo.DisplayMember = "PaymentType";
                paymentTypeCombo.ValueMember = "Id";

            }


            ddlPaymentType.Visible = false;
            grdLister.EnableFiltering = true;
            grdLister.ShowFilteringRow = true;


            SetColumns();





            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();


            GridViewSummaryItem cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.Fare;
            item2.Add(cc);


            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.DrvParking;
            item2.Add(cc);


            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.DrvWaiting;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.Extra;
            item2.Add(cc);


            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.AccFare;
            item2.Add(cc);


            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.AccParking;
            item2.Add(cc);


            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.AccWaiting;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.BookingFee;
            item2.Add(cc);








            this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;


            if (AppVars.listUserRights.Count(c => c.functionId == "DISABLE EXPORT LIST") > 0)
            {

                btnExportToExcel2.Visible = false;
                btnExportPDF.Visible = false;
            }



            if (AppVars.AppTheme != "ControlDefault")
            {
                grdLister.ForeColor = Color.White;
            }
            else
            {
                grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
             

                grdLister.EnableAlternatingRowColor = true;
                grdLister.TableElement.AlternatingRowColor = Color.AliceBlue;


            }


            try
            {
                hiddenColumnsList = General.GetQueryable<UM_Form_UserDefinedSetting>(c => c.UM_Form.FormName == this.Name && (c.IsVisible == true || c.GridColMoveTo != null)).ToList();

                for (int i = 0; i < hiddenColumnsList.Count; i++)
                {

                    if (grdLister.Columns[hiddenColumnsList[i].GridColumnName] != null)
                    {

                        grdLister.Columns[hiddenColumnsList[i].GridColumnName].IsVisible = hiddenColumnsList[i].IsVisible.ToBool();
                        if (hiddenColumnsList[i].GridColMoveTo != null && hiddenColumnsList[i].IsVisible.ToBool())
                        {
                            grdLister.Columns.Move(grdLister.Columns[hiddenColumnsList[i].GridColumnName].Index, hiddenColumnsList[i].GridColMoveTo.ToInt());
                        }
                        grdLister.Columns[hiddenColumnsList[i].GridColumnName].Width = hiddenColumnsList[i].GridColWidth.ToInt();

                    }
                }
            }
            catch
            {

            }


        }

        private void Ddluser_Enter(object sender, EventArgs e)
        {
            if (ddluser.DataSource == null)
                ComboFunctions.FillUsersCombo(ddluser,c=>c.IsActive==true);
        }

        private void SetColumns()
        {
            try
            {
                if (AppVars.listUserRights.Count(c => c.functionId == "SHOW PARKING") > 0)
                {
                    grdLister.Columns[COLS.AccParking].IsVisible = true;
                    grdLister.Columns[COLS.DrvParking].IsVisible = true;

                }
                if (AppVars.listUserRights.Count(c => c.functionId == "SHOW WAITING") > 0)
                {
                    grdLister.Columns[COLS.AccWaiting].IsVisible = true;
                    grdLister.Columns[COLS.DrvWaiting].IsVisible = true;

                }
                if (AppVars.listUserRights.Count(c => c.functionId == "SHOW EXTRA CHARGES") > 0)
                {
                    grdLister.Columns[COLS.Extra].IsVisible = true;


                }
            }
            catch
            {

            }

        }



       



        void grdLister_CellEndEdit2(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {




                    if (grdLister.CurrentColumn != null && (grdLister.CurrentColumn.Name == COLS.Fare || grdLister.CurrentColumn.Name == COLS.AccFare || grdLister.CurrentColumn is GridViewDecimalColumn) && grdLister.IsInEditMode == false)
                    {

                        if (grdLister.Tag.ToStr() == "1" && e.Row.Cells[COLS.Account].Value.ToInt()>0)
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                var CompanyPricePercent = db.Gen_Companies.Where(c => c.Id == e.Row.Cells[COLS.Account].Value.ToInt()).Select(c=>c.CompanyPricePercent).FirstOrDefault().ToInt();

                                
                                    e.Row.Cells[COLS.AccFare].Value = Math.Round(e.Value.ToDecimal() + ((e.Value.ToDecimal() * CompanyPricePercent.ToDecimal()) / 100), 2);


                               
                            }
                        }




                        UpdateBooking(grdLister.CurrentRow);

                    }
                }
            }
            catch (Exception ex)
            {

                try
                {
                    File.AppendAllText(Application.StartupPath + "\\exception_updatefromjoblist.txt", DateTime.Now + " " + ex.Message + Environment.NewLine);

                }
                catch(Exception ex2)
                {

                }

            }



        }




        void btnSelectPaymentType_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (btnSelectPaymentType.ToggleState == ToggleState.On)
            {
                grdPaymentTypes.Visible = true;
                grdPaymentTypes.BringToFront();
            }
            else
            {
                grdPaymentTypes.Visible = false; ;
            }
        }

        IList listofPaymentTypes = null;
        private void LoadPaymentTypes()
        {
            try
            {
                var list = (from a in General.GetQueryable<Gen_PaymentType>(c => c.IsVisible == true)
                            select new
                            {
                                PaymentType = a.PaymentType,
                                Id = a.Id
                               
                            }).ToList();
                grdPaymentTypes.RowCount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {

                    grdPaymentTypes.Rows[i].Cells[COLSP.Id].Value = list[i].Id;
                    grdPaymentTypes.Rows[i].Cells[COLSP.PaymentType].Value = list[i].PaymentType;

                }


                grdPaymentTypes.ShowColumnHeaders = false;

                listofPaymentTypes = list;

            }
            catch (Exception ex)
            {

            }
        }
        void grdLister_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Row != null && e.Row is GridViewDataRowInfo)
            {
                if (e.Column != null
                    && (e.Column.Name == COLS.AccFare || e.Column.Name == COLS.AgentComm || e.Column.Name == COLS.AccParking || e.Column.Name == COLS.AccWaiting)

                    && e.Row.Cells[COLS.Account].Value.ToStr().Trim() == string.Empty)
                {
                    e.Cancel = true;


                }
                //else
                //{

                //    if (e.Column != null)
                //    {

                //        if (e.Row.Cells[COLS.Account].Value.ToInt() > 0 && e.Column.Name == COLS.PaymentType && e.Column is GridViewComboBoxColumn)
                //        {
                //           var list=   General.GetQueryable<Gen_Company_PaymentType>(null).Where(c=>c.CompanyId==e.Row.Cells[COLS.Account].Value.ToInt()).ToList();

                //            foreach (var item in listofPaymentTypes)
                //            {


                //            }

                //            (e.Column as GridViewComboBoxColumn).DataSource
                //        }
                //        else
                //        {
                //            (e.Column as GridViewComboBoxColumn).DataSource=listofPaymentTypes;


                //        }


                //    }

                //}


            }
        }

        void grdLister_CellEndEdit(object sender, GridViewCellEventArgs e)
        {


            //try
            //{
            //    if (e.Row.Cells[COLS.Account].Value.ToStr().Trim().Length > 0)
            //    {


            //        decimal Company = e.Row.Cells[COLS.AccFare].Value.ToDecimal();
            //        decimal Driver = e.Row.Cells[COLS.Fare].Value.ToDecimal();
            //        decimal Agent = e.Row.Cells[COLS.AgentComm].Value.ToDecimal();




            //        if (e.Column.Name == COLS.AccFare)
            //        {
            //            Company = e.Value.ToDecimal();
            //            Agent = Company - Driver;
            //            e.Row.Cells[COLS.AgentComm].Value = Agent;

            //            e.Row.Cells[COLS.Fare].Value = Company - Agent;

            //        }
            //        else if (e.Column.Name == COLS.AgentComm)
            //        {

            //            Agent = e.Value.ToDecimal();
            //            Driver = Company - Agent;
            //            e.Row.Cells[COLS.Fare].Value = Driver;
            //            e.Row.Cells[COLS.AccFare].Value = Driver + Agent;



            //        }
            //        else if (e.Column.Name == COLS.Fare)
            //        {
            //            Driver = e.Value.ToDecimal();
            //            Agent = Company - Driver;
            //            e.Row.Cells[COLS.AgentComm].Value = Agent;



            //            e.Row.Cells[COLS.AccFare].Value = Driver + Agent;

            //        }
            //    }


            //    //if(Company<0 || Driver<0)
            //    //e.Row.Cells[COLS_AirportCommission.CompanyPrice].Value=(Driver+Agent);
            //    //e.Row.Cells[COLS_AirportCommission.DriverPrice].Value=(Company-Agent);
            //    //e.Row.Cells[COLS_AirportCommission.CustomerPrice].Value=(Company-Driver);
            //}
            //catch (Exception ex)
            //{

            //}
            try
            {

                if (e.Column != null && e.Column.Name == COLS.AccFare && e.Row.Cells[COLS.Account].Value.ToStr().Trim().Length > 0)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        var objAcc = db.Gen_Companies.FirstOrDefault(c => c.Id == e.Row.Cells[COLS.Account].Value.ToInt());

                        if (objAcc != null)
                        {
                            if (objAcc.DriverFareReductionType.ToStr().ToLower() == "percent")
                            {
                                e.Row.Cells[COLS.Fare].Value = Math.Round(e.Value.ToDecimal() - ((e.Value.ToDecimal() * objAcc.DriverFareReductionValue.ToDecimal()) / 100), 2);

                            }
                            else
                            {

                                e.Row.Cells[COLS.Fare].Value = e.Value.ToDecimal() - objAcc.DriverFareReductionValue.ToDecimal();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }






        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name == "btnUpdate")
                {


                    UpdateBooking(gridCell.RowInfo);



                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);


            }
        }


        private void UpdateBooking(GridViewRowInfo row)
        {

            if (row == null)
                return;

            // GridViewRowInfo row = gridCell.RowInfo;

            if (row is GridViewDataRowInfo)
            {
                string bookingNo = string.Empty;
                long id = row.Cells[COLS.ID].Value.ToLong();
                bool driverRentCommExist = false;
                bool accountinvoiceExist = false;
                string error = string.Empty;
                bool allowUpdateTransaction = false;
                try
                {
                   
                    if (AppVars.listUserRights.Count(c => c.formName == "frmBooking" && (c.functionId == "LOCK BOOKING AFTER TRANSACTION")) > 0)
                    {
                        int reasonCnt = 0;

                        using (TaxiDataContext db = new TaxiDataContext())
                        {

                            if (db.Invoice_Charges.Count(c => c.BookingId == id) > 0)
                            {
                              
                                reasonCnt++;
                                error = reasonCnt + ". Account Invoice Exist" + Environment.NewLine;


                                accountinvoiceExist = true;
                            }

                            if (db.DriverRent_Charges.Count(c => c.BookingId == id) > 0)
                            {
                                driverRentCommExist = true;
                                reasonCnt++;
                                error += reasonCnt + ". Driver Rent Statement Exist" + Environment.NewLine;
                             
                            }

                            if (db.Fleet_DriverCommision_Charges.Count(c => c.BookingId == id) > 0)
                            {
                                driverRentCommExist = true;
                                reasonCnt++;
                                error += reasonCnt + ". Driver Commission Statement Exist" + Environment.NewLine;
                           
                            }


                           
                        }

                        if (driverRentCommExist == true && error.Length > 0)
                        {
                            if (accountinvoiceExist == true)
                            {
                                ENUtils.ShowMessage("You cannot edit this booking" + Environment.NewLine + Environment.NewLine + "Reasons:-" + Environment.NewLine + error);
                                return;
                            }
                        }
                        

                    }
                    else
                        allowUpdateTransaction = true;
                }
                catch
                {


                }


                string custName = row.Cells[COLS.Passenger].Value.ToStr().Trim();

                decimal fare = row.Cells[COLS.Fare].Value.ToDecimal();
                decimal ACCFare = row.Cells[COLS.AccFare].Value.ToDecimal();
                decimal AgentComm = row.Cells[COLS.AgentComm].Value.ToDecimal();
                decimal extra = row.Cells[COLS.Extra].Value.ToDecimal();

                decimal drvParking = row.Cells[COLS.DrvParking].Value.ToDecimal();
                decimal drvWaiting = row.Cells[COLS.DrvWaiting].Value.ToDecimal();

                decimal accParking = row.Cells[COLS.AccParking].Value.ToDecimal();
                decimal accWaiting = row.Cells[COLS.AccWaiting].Value.ToDecimal();

                decimal bookingFee = row.Cells[COLS.BookingFee].Value.ToDecimal();


                bool ShowDrvParking = grdLister.Columns[COLS.DrvParking].IsVisible;
                bool ShowDrvWaiting = grdLister.Columns[COLS.DrvWaiting].IsVisible;
                bool ShowAccParking = grdLister.Columns[COLS.AccParking].IsVisible;
                bool ShowAccWaiting = grdLister.Columns[COLS.AccWaiting].IsVisible;


               
                int? accountId = row.Cells[COLS.Account].Value.ToIntorNull();
                int? paymentTypeId = row.Cells[COLS.PaymentType].Value.ToIntorNull();


                if(paymentTypeId==null)
                {
                    ENUtils.ShowMessage("Required : Payment Type");
                    return;
                }

                int? oldPaymentTypeId = row.Cells[COLS.OldPaymentType].Value.ToIntorNull();
                int? vehicleTypeId = row.Cells[COLS.Vehicle].Value.ToIntorNull();

                string bookedBy = row.Cells[COLS.BookedBy].Value.ToStr().Trim();
                string paymentcomments = row.Cells[COLS.PaymentRef].Value.ToStr().Trim();
                string specialreq = row.Cells[COLS.SpecialReq].Value.ToStr().Trim();

                string pickup = row.Cells[COLS.PickupPoint].Value.ToStr().ToUpper().Trim();
                string destination = row.Cells[COLS.Destination].Value.ToStr().ToUpper().Trim();


                string oldPickup = row.Cells[COLS.OldPickupPoint].Value.ToStr().ToUpper().Trim();
                string oldDestination = row.Cells[COLS.OldDestination].Value.ToStr().ToUpper().Trim();


                int? waitingtime = null;

                if (grdLister.Columns[COLS.WaitingTime].IsVisible)
                    waitingtime = row.Cells[COLS.WaitingTime].Value.ToInt();

                if (string.IsNullOrEmpty(pickup))
                {
                    ENUtils.ShowMessage("Pickup Point cannot be empty");
                    return;
                }

                if (string.IsNullOrEmpty(destination))
                {
                    ENUtils.ShowMessage("Destination cannot be empty");
                    return;
                }

                if (accountId != null && paymentTypeId != null)
                {

                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.DeferredLoadingEnabled = false;
                        if (db.Gen_Company_PaymentTypes.Where(c => c.CompanyId == accountId).Count()>0 &&
                            db.Gen_Company_PaymentTypes.Where(c => c.CompanyId == accountId && c.PaymentTypeId == paymentTypeId).Count() == 0)
                        {
                            ENUtils.ShowMessage("This PaymentType is not available for this Account");
                            return;
                        }

                    }
                        
                }


                BookingBO objMaster = new BookingBO();
                objMaster.GetByPrimaryKey(id);

                if (objMaster.Current != null)
                {


                    //if ((error.Length > 0 && driverRentCommExist == false &&
                    //    (fare == objMaster.Current.FareRate.ToDecimal()
                    //     && drvParking == objMaster.Current.CongtionCharges.ToDecimal()
                    //     && drvWaiting == objMaster.Current.MeetAndGreetCharges.ToDecimal()))
                    //    )
                    //{
                    //    ENUtils.ShowMessage("You cannot edit this booking" + Environment.NewLine + Environment.NewLine + "Reasons:-" + Environment.NewLine + error);
                    //    return;
                    //}

                    if (paymentTypeId == null || paymentTypeId.ToInt() == 0)
                    {
                        ENUtils.ShowMessage("Required : Payment Type");
                        return;

                    }


                    if (driverRentCommExist || accountinvoiceExist)
                    {
                        if (objMaster.Current.CompanyId != null)
                        {
                            if (accountId == null || accountId.ToInt() == 0)
                            {
                                ENUtils.ShowMessage("Required : Account");
                                return;

                            }
                        }

                    }


                    if (driverRentCommExist )
                    {

                        if ((fare != objMaster.Current.FareRate.ToDecimal()
                         || drvParking != objMaster.Current.CongtionCharges.ToDecimal()
                         || drvWaiting != objMaster.Current.MeetAndGreetCharges.ToDecimal()))
                        {


                            ENUtils.ShowMessage("You cannot edit this booking" + Environment.NewLine + Environment.NewLine + "Reasons:-" + Environment.NewLine + error);


                            if(fare!=objMaster.Current.FareRate.ToDecimal())
                            {
                                row.Cells[COLS.Fare].Value = objMaster.Current.FareRate.ToDecimal();

                            }

                            if (drvParking != objMaster.Current.CongtionCharges.ToDecimal())
                            {
                                row.Cells[COLS.DrvParking].Value = objMaster.Current.CongtionCharges.ToDecimal();

                            }

                            if (drvWaiting != objMaster.Current.MeetAndGreetCharges.ToDecimal())
                            {
                                row.Cells[COLS.DrvWaiting].Value = objMaster.Current.MeetAndGreetCharges.ToDecimal();

                            }

                            return;


                        }                      

                    }






                    //audit

                    string beforechangeLog = string.Empty;
                    string afterchangeLog = string.Empty;




                    if (fare != objMaster.Current.FareRate.ToDecimal())
                    {
                        beforechangeLog = "Old Fare : " + objMaster.Current.FareRate.ToDecimal() + Environment.NewLine;
                        afterchangeLog = "New Fare : " + fare + Environment.NewLine;

                    }




                    if (drvParking != objMaster.Current.CongtionCharges.ToDecimal())
                    {
                        beforechangeLog += "Old Parking : " + objMaster.Current.CongtionCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Parking : " + drvParking + Environment.NewLine;
                    }

                    if (drvWaiting != objMaster.Current.MeetAndGreetCharges.ToDecimal())
                    {
                        beforechangeLog += "Old Waiting : " + objMaster.Current.MeetAndGreetCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Waiting : " + drvWaiting + Environment.NewLine;
                    }



                    if (ACCFare != objMaster.Current.CompanyPrice.ToDecimal())
                    {
                        beforechangeLog = "Old Acc Fare : " + objMaster.Current.CompanyPrice.ToDecimal() + Environment.NewLine;
                        afterchangeLog = "New Acc Fare : " + ACCFare + Environment.NewLine;

                    }

                    if (accParking != objMaster.Current.ParkingCharges.ToDecimal())
                    {
                        beforechangeLog += "Old AccParking : " + objMaster.Current.ParkingCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Acc Parking : " + accParking + Environment.NewLine;
                    }

                    if (accWaiting != objMaster.Current.WaitingCharges.ToDecimal())
                    {
                        beforechangeLog += "Old Acc Waiting : " + objMaster.Current.WaitingCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Acc Waiting : " + accWaiting + Environment.NewLine;
                    }


                    if (extra != objMaster.Current.ExtraDropCharges.ToDecimal())
                    {
                        beforechangeLog += "Old Extra : " + objMaster.Current.ExtraDropCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Extra : " + extra + Environment.NewLine;
                    }

                  

                    if (AgentComm != objMaster.Current.AgentCommission.ToDecimal())
                    {
                        beforechangeLog += "Old Agent Fee : " + objMaster.Current.AgentCommission.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Agent Fee : " + AgentComm + Environment.NewLine;
                    }

                    if (bookingFee != objMaster.Current.CashRate.ToDecimal())
                    {
                        beforechangeLog += "Old Booking Fee : " + objMaster.Current.ServiceCharges.ToDecimal() + Environment.NewLine;
                        afterchangeLog += "New Booking Fee : " + bookingFee + Environment.NewLine;
                    }



                    if (oldPickup != pickup)
                    {
                        beforechangeLog += "Old Pickup : " + oldPickup.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Pickup : " + pickup.ToStr() + Environment.NewLine;

                    }


                    if (oldDestination != destination)
                    {
                        beforechangeLog += "Old Destination : " + oldDestination.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Destination : " + destination.ToStr() + Environment.NewLine;

                    }


                    if (oldPaymentTypeId.ToInt() != paymentTypeId.ToInt())
                    {

                        string oldPaymentTypeName = "";
                        string newPaymentTypeName = "";

                        if (oldPaymentTypeId == Enums.PAYMENT_TYPES.CASH)
                            oldPaymentTypeName = "Cash";
                        else if (oldPaymentTypeId == Enums.PAYMENT_TYPES.BANK_ACCOUNT)
                            oldPaymentTypeName = "Account";
                        if (oldPaymentTypeId == Enums.PAYMENT_TYPES.CREDIT_CARD)
                            oldPaymentTypeName = "Credit Card";
                        if (oldPaymentTypeId == Enums.PAYMENT_TYPES.CREDIT_CARD_PAID)
                            oldPaymentTypeName = "Credit Card(PAID)";



                        if (paymentTypeId == Enums.PAYMENT_TYPES.CASH)
                            newPaymentTypeName = "Cash";
                        else if (paymentTypeId == Enums.PAYMENT_TYPES.BANK_ACCOUNT)
                            newPaymentTypeName = "Account";
                        if (paymentTypeId == Enums.PAYMENT_TYPES.CREDIT_CARD)
                            newPaymentTypeName = "Credit Card";
                        if (paymentTypeId == Enums.PAYMENT_TYPES.CREDIT_CARD_PAID)
                            newPaymentTypeName = "Credit Card(PAID)";


                        beforechangeLog += "Old Payment Type : " + oldPaymentTypeName.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Payment Type : " + newPaymentTypeName.ToStr() + Environment.NewLine;

                    }


                    if (accountId.ToInt() != objMaster.Current.CompanyId.ToInt())
                    {
                        try
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                db.DeferredLoadingEnabled = false;


                                string oldAccName = string.Empty;
                                if (objMaster.Current.CompanyId != null)
                                    oldAccName = db.Gen_Companies.Where(c => c.Id == objMaster.Current.CompanyId).Select(c => c.CompanyName).FirstOrDefault();


                                string AccName = string.Empty;

                                if (accountId.ToInt() > 0)
                                    AccName = db.Gen_Companies.Where(c => c.Id == accountId).Select(c => c.CompanyName).FirstOrDefault();


                                beforechangeLog += "Old Account : " + oldAccName + Environment.NewLine;
                                afterchangeLog += "New Account  : " + AccName + Environment.NewLine;

                            }
                        }
                        catch
                        {

                        }
                    }

                    if (vehicleTypeId.ToInt() != objMaster.Current.VehicleTypeId.ToInt())
                    {
                        try
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                db.DeferredLoadingEnabled = false;


                                string oldVehName = string.Empty;
                                if (objMaster.Current.VehicleTypeId != null)
                                    oldVehName = db.Fleet_VehicleTypes.Where(c => c.Id == objMaster.Current.VehicleTypeId).Select(c => c.VehicleType).FirstOrDefault();


                                string VehName = string.Empty;

                                if (vehicleTypeId.ToInt() > 0)
                                    VehName = db.Fleet_VehicleTypes.Where(c => c.Id == vehicleTypeId).Select(c => c.VehicleType).FirstOrDefault();


                                beforechangeLog += "Old Vehicle : " + oldVehName + Environment.NewLine;
                                afterchangeLog += "New Vehicle  : " + VehName + Environment.NewLine;

                            }
                        }
                        catch
                        {

                        }
                    }


                    if (bookedBy != objMaster.Current.BookedBy.ToStr())
                    {
                        beforechangeLog += "Old Booked By : " + objMaster.Current.BookedBy.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Booked By : " + bookedBy + Environment.NewLine;

                    }

                    if (paymentcomments != objMaster.Current.PaymentComments.ToStr())
                    {
                        beforechangeLog += "Old Payment Ref : " + objMaster.Current.PaymentComments.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Payment Ref : " + paymentcomments + Environment.NewLine;

                    }


                    if (specialreq != objMaster.Current.SpecialRequirements.ToStr())
                    {
                        beforechangeLog += "Old Special Req : " + objMaster.Current.SpecialRequirements.ToStr() + Environment.NewLine;
                        afterchangeLog += "New Special Req : " + specialreq + Environment.NewLine;

                    }


                    //




                    bookingNo = objMaster.Current.BookingNo.ToStr().Trim();

                    objMaster.Current.FareRate = fare;
                    objMaster.Current.ExtraDropCharges = extra;
                    objMaster.Current.CustomerPrice = fare;
                    objMaster.Current.CompanyPrice = ACCFare;
                    objMaster.Current.AgentCommission = AgentComm;
                    objMaster.Current.CompanyId = accountId;
                    objMaster.Current.BookedBy = bookedBy.ToStr();
                    objMaster.Current.PaymentComments = paymentcomments.ToStr();
                    objMaster.Current.SpecialRequirements = specialreq.ToStr();

                    objMaster.Current.IsProcessed = true;

                    objMaster.Current.VehicleTypeId = vehicleTypeId;

                    if (ShowDrvParking)
                        objMaster.Current.CongtionCharges = drvParking;

                    if (ShowDrvWaiting)
                    {
                        objMaster.Current.MeetAndGreetCharges = drvWaiting;
                    }

                    if (ShowAccParking)
                    {
                        objMaster.Current.ParkingCharges = accParking;
                    }

                    if (ShowAccWaiting)
                    {
                        objMaster.Current.WaitingCharges = accWaiting;
                    }



                    if (grdLister.Columns[COLS.BookingFee].IsVisible)
                    {
                        objMaster.Current.ServiceCharges = bookingFee;
                    }




                    if (oldPickup != pickup)
                    {

                        objMaster.Current.FromAddress = pickup;
                        objMaster.Current.FromPostCode = General.GetPostCodeMatch(objMaster.Current.FromAddress);

                        if (objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.POSTCODE)
                        {
                            if (objMaster.Current.FromPostCode.ToStr().Length > 0)
                                objMaster.Current.FromStreet = objMaster.Current.FromAddress.Replace("-" + objMaster.Current.FromPostCode, "").Trim();


                        }
                        else if (objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.AIRPORT)
                        {
                            string[] pickupArr = pickup.Split(new char[] { '-' });


                            if (pickupArr.Count() == 2)
                            {
                                string airportName = pickupArr[1].ToLower().Replace(",", "").Trim();

                                if (airportName.Length > 0)
                                {
                                    var objLocation = General.GetObject<Gen_Location>(c => ((c.LocationName + " " + c.PostCode).ToLower().Replace(",", "").Trim()) == airportName);

                                    if (objLocation != null && objLocation.LocationTypeId != null)
                                    {
                                        objMaster.Current.FromLocId = objLocation.Id;
                                        objMaster.Current.FromLocTypeId = Enums.LOCATION_TYPES.AIRPORT;
                                        objMaster.Current.FromStreet = pickupArr[0].ToStr().Trim();
                                    }
                                    else
                                    {

                                        objMaster.Current.FromLocTypeId = Enums.LOCATION_TYPES.ADDRESS;

                                    }
                                }
                            }

                        }
                        else if (objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.CLUBBAR
                            || objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.UNDERGROUNDSTATION
                            || objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.HOTELS
                            || objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.HOSPITAL
                            || objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.SCHOOLS
                             || objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.STORE)
                        {




                            pickup = pickup.ToLower().Replace(",", "").Trim();

                            if (pickup.Length > 0)
                            {
                                var objLocation = General.GetObject<Gen_Location>(c => ((c.LocationName + " " + c.PostCode).ToLower().Replace(",", "").Trim()) == pickup);

                                if (objLocation != null && objLocation.LocationTypeId != null)
                                {

                                    objMaster.Current.FromLocId = objLocation.Id;
                                    objMaster.Current.FromLocTypeId = objLocation.LocationTypeId;


                                }
                                else
                                {

                                    objMaster.Current.FromLocTypeId = Enums.LOCATION_TYPES.ADDRESS;

                                }
                            }

                        }

                    }


                    if (oldDestination != destination)
                    {

                        objMaster.Current.ToAddress = destination;
                        objMaster.Current.ToPostCode = General.GetPostCodeMatch(objMaster.Current.ToAddress);

                        if (objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.POSTCODE)
                        {
                            if (objMaster.Current.ToPostCode.ToStr().Length > 0)
                                objMaster.Current.ToStreet = objMaster.Current.ToAddress.Replace("-" + objMaster.Current.ToPostCode, "").Trim();

                        }
                        else if (objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.AIRPORT)
                        {
                            string[] Arr = destination.Split(new char[] { '-' });


                            if (Arr.Count() == 2)
                            {
                                string airportName = Arr[1].ToLower().Replace(",", "").Trim();

                                if (airportName.Length > 0)
                                {
                                    var objLocation = General.GetObject<Gen_Location>(c => ((c.LocationName + " " + c.PostCode).ToLower().Replace(",", "").Trim()) == airportName);

                                    if (objLocation != null && objMaster.Current.ToLocTypeId != null)
                                    {
                                        objMaster.Current.ToLocId = objLocation.Id;
                                        objMaster.Current.ToLocTypeId = Enums.LOCATION_TYPES.AIRPORT;
                                        objMaster.Current.ToStreet = Arr[0].ToStr().Trim();
                                    }
                                    else
                                    {

                                        objMaster.Current.ToLocTypeId = Enums.LOCATION_TYPES.ADDRESS;

                                    }
                                }
                            }

                        }
                        else if (objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.CLUBBAR
                           || objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.UNDERGROUNDSTATION
                           || objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.HOTELS
                           || objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.HOSPITAL
                           || objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.SCHOOLS
                            || objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.STORE)
                        {




                            destination = destination.ToLower().Replace(",", "").Trim();

                            if (destination.Length > 0)
                            {
                                var objLocation = General.GetObject<Gen_Location>(c => ((c.LocationName + " " + c.PostCode).ToLower().Replace(",", "").Trim()) == destination);

                                if (objLocation != null && objLocation.LocationTypeId != null)
                                {

                                    objMaster.Current.ToLocId = objLocation.Id;
                                    objMaster.Current.ToLocTypeId = objLocation.LocationTypeId;


                                }
                                else
                                {

                                    objMaster.Current.FromLocTypeId = Enums.LOCATION_TYPES.ADDRESS;

                                }
                            }

                        }
                    }


                    if (paymentTypeId != null && oldPaymentTypeId != paymentTypeId)
                    {
                        objMaster.Current.PaymentTypeId = paymentTypeId;
                        row.Cells[COLS.OldPaymentType].Value = paymentTypeId;

                    }
                    if (objMaster.Current.CompanyId != null)
                    {

                        objMaster.Current.TotalCharges = objMaster.Current.CompanyPrice + objMaster.Current.ParkingCharges.ToDecimal() + objMaster.Current.WaitingCharges.ToDecimal()+objMaster.Current.ExtraDropCharges.ToDecimal();
                    }
                    else
                    {

                        objMaster.Current.TotalCharges = objMaster.Current.FareRate + objMaster.Current.MeetAndGreetCharges.ToDecimal() + objMaster.Current.CongtionCharges.ToDecimal()+objMaster.Current.ExtraDropCharges.ToDecimal();

                    }



                    if (objMaster.Current.CompanyId != null)
                        objMaster.Current.IsCompanyWise = true;
                    else
                        objMaster.Current.IsCompanyWise = false;


                    objMaster.Current.CustomerName = custName;


                    if (waitingtime != null)
                        objMaster.Current.DriverWaitingMins = waitingtime;


                    objMaster.CheckCustomerValidation = false;
                    objMaster.CheckDataValidation = false;
                    objMaster.DisableUpdateReturnJob = true;
                    objMaster.AllowUpdateTransaction = allowUpdateTransaction;

                    if (beforechangeLog.ToStr().Trim().Length > 0)
                    {


                        objMaster.Current.Booking_Logs.Add(new Booking_Log { BeforeUpdate = beforechangeLog, AfterUpdate = afterchangeLog, BookingId = objMaster.Current.Id, UpdateDate = DateTime.Now, User = AppVars.LoginObj.UserName.ToStr() });
                    }


                    objMaster.Save();


                    UpdateTotalEarning();
                    //  UpdateDriverCommission(id);

                    //  UpdateCompanyInvoice(id);

                    
           

                    row.Cells[COLS.IsProcessed].Value = 1;

                    General.AddUserLog("Update Booking (" + bookingNo + ") from Job List Report",3);

                }
            }

        }


        private void UpdateDriverCommission(long jobId)
        {

            try
            {

                long? updateCommissionId = null;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    updateCommissionId = db.Fleet_DriverCommision_Charges.FirstOrDefault(c => c.BookingId == jobId).DefaultIfEmpty().TransId;


                    if (updateCommissionId.ToLong() > 0)
                    {
                        Fleet_DriverCommision objCommission = db.Fleet_DriverCommisions.FirstOrDefault(c => c.Id == updateCommissionId);


                        if (objCommission != null)
                        {

                            decimal Credit = 0.00m;
                            decimal Debit = 0.00m;
                            decimal totalCredit = 0.00m;
                            decimal totalDebit = 0.00m;
                            decimal owedBalance = 0.00m;
                            decimal Currentbalance = 0.00m;


                            decimal pdaRent = objCommission.PDARent.ToDecimal();
                            decimal collectionAndDelivery = objCommission.CollectionDeliveryCharges.ToDecimal();


                            decimal accountJobsTotal = objCommission.Fleet_DriverCommision_Charges.Where(c => c.Booking.PaymentTypeId != Enums.PAYMENT_TYPES.CASH).Sum(c => (c.Booking.FareRate + c.Booking.MeetAndGreetCharges)).ToDecimal();
                            decimal jobsFareTotal = objCommission.Fleet_DriverCommision_Charges.Sum(c => (c.Booking.FareRate + c.Booking.MeetAndGreetCharges)).ToDecimal();

                            decimal agentTotal = objCommission.Fleet_DriverCommision_Charges.Where(c => c.Booking.PaymentTypeId == Enums.PAYMENT_TYPES.CASH).Sum(c => c.Booking.AgentCommission).ToDecimal();

                            decimal commissionTotal = objCommission.Fleet_DriverCommision_Charges.Sum(c => ((c.Booking.FareRate + c.Booking.MeetAndGreetCharges) * objCommission.DriverCommision) / 100).ToDecimal();

                            decimal owed = Math.Round((pdaRent + agentTotal + commissionTotal) - accountJobsTotal, 2);

                            if (objCommission.Fleet_DriverCommissionExpenses.Count > 0)
                            {
                                Debit = objCommission.Fleet_DriverCommissionExpenses.Sum(c => c.Debit).ToDecimal();
                                Credit = objCommission.Fleet_DriverCommissionExpenses.Sum(c => c.Credit).ToDecimal();
                            }


                            totalCredit = (commissionTotal + Credit);
                            totalDebit = (accountJobsTotal + Debit);

                            owedBalance = (totalCredit - totalDebit);
                            Currentbalance = owedBalance + objCommission.OldBalance.ToDecimal();

                            objCommission.CommissionTotal = commissionTotal;
                            objCommission.AccJobsTotal = accountJobsTotal;
                            objCommission.Balance = Currentbalance;
                            objCommission.AgentFeesTotal = agentTotal;

                            objCommission.JobsTotal = jobsFareTotal;
                            objCommission.DriverOwed = owed;

                            db.SubmitChanges();
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }

        }

        private void UpdateCompanyInvoice(long jobId)
        {

            try
            {

                long? InvoiceId = null;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    InvoiceId = db.Invoice_Charges.FirstOrDefault(c => c.BookingId == jobId).DefaultIfEmpty().InvoiceId;

                    if (InvoiceId.ToLong() > 0)
                    {
                        Invoice objInvoice = db.Invoices.FirstOrDefault(c => c.Id == InvoiceId);


                        if (objInvoice != null)
                        {

                            objInvoice.InvoiceTotal = objInvoice.Invoice_Charges.Where(c => c.Booking.PaymentTypeId != 6)
                                 .Sum(c => c.Booking.CompanyPrice).ToDecimal();


                            db.SubmitChanges();


                        }

                    }

                }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

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


        string templateNo = "Template1";

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Print();
        }


        private List<stp_GetBookingBaseResultEx> GetDataSourceBySP(int reportType, int companyId, DateTime? fromDate, DateTime? toDate, int DriverId, int PaymentTypeId, string BookedBy, int CompanyGroupId, long FleetMasterId)
        {
        

          

            if (fromDate != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                fromDate = (fromDate.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



            if (toDate != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                toDate = (toDate.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();

            
            //if (fromDate.Value.TimeOfDay != TimeSpan.Zero)
            //    fullfromdateCriteria = true;





            //if (toDate.Value.TimeOfDay != TimeSpan.Zero)
            //    fulltodateCriteria = true;





            string orderNo = ddlOrderNo.Text.Trim();

            int subCompanyId = ddlSubCompany.SelectedValue.ToInt();

            int transferredSubCompanyId = ddlTransferredSubCompanyId.SelectedValue.ToInt();


            List<int?> listofPaymentTypes = new List<int?>();

            if (grdPaymentTypes.Rows.Count(c => c.Cells[COLSP.Check].Value.ToBool()) == 0)
                PaymentTypeId = 0;

            else
            {
                listofPaymentTypes = grdPaymentTypes.Rows.Where(c => c.Cells[COLSP.Check].Value.ToBool()).Select(a => a.Cells[COLSP.Id].Value.ToIntorNull()).ToList<int?>();
                PaymentTypeId = 1;
            }

            string PaymentTypes = string.Empty;
            

            PaymentType = string.Join(",", (from a in listofPaymentTypes

                                            select a.Value).ToArray<int>());

           
            //var drivers = string.Join(",", from item in listofPaymentTypes select  item).ToArray<string>());
           // PaymentType =String.Join(',', (listofPaymentTypes)).ToArray<string>();


            using (TaxiDataContext db = new TaxiDataContext())
            {



                //var list = db.stp_GetBookingBase(fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList(); ;

                var list = db.ExecuteQuery<stp_GetBookingBaseResultEx>("exec stp_getbookingbase {0},{1],{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList();



                if (ddlCompanyGroup.SelectedValue.ToInt() > 0)
                {
                    var groupRecords = db.Gen_Companies.Where(c => c.GroupId == ddlCompanyGroup.SelectedValue.ToInt()).Select(c => c.Id).ToList();

                    list = list.Where(a => groupRecords.Count(c => c == a.CompanyId) > 0).ToList();

                }


              


                if (optSortAsc.Checked)
                {
                    list = list.OrderBy(c => c.PickupDateTime)
                                     .ToList();
                }
                else
                {
                    list=list.OrderByDescending(c => c.PickupDateTime)
                                  .ToList();
                }


                if (ddluser.SelectedValue.ToInt() > 0)
                {

                    var listX2 = db.ExecuteQuery<stp_GetBookingBaseResultEx>("exec stp_getbookingbase {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList(); ;


                    int operatorId = ddluser.SelectedValue.ToInt();
                    var Ids= listX2.Where(a => a.OperatorId == operatorId).Select(c => c.Id).ToList();


                    list=list.Where(c => Ids.Contains(c.Id)).ToList();

                }



              

                return list;
            }


        }



        private List<stp_GetBookingBaseResultEx> GetDataSourceBySPExjobListReport(int reportType, int companyId, DateTime? fromDate, DateTime? toDate, int DriverId, int PaymentTypeId, string BookedBy,int OperatorId, int CompanyGroupId, long FleetMasterId)
        {



            if (fromDate != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                fromDate = (fromDate.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



            if (toDate != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                toDate = (toDate.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();









            string orderNo = ddlOrderNo.Text.Trim();

            int subCompanyId = ddlSubCompany.SelectedValue.ToInt();

            int transferredSubCompanyId = ddlTransferredSubCompanyId.SelectedValue.ToInt();

            int operatorId = ddluser.SelectedValue.ToInt();

            List<int?> listofPaymentTypes = new List<int?>();

            if (grdPaymentTypes.Rows.Count(c => c.Cells[COLSP.Check].Value.ToBool()) == 0)
                PaymentTypeId = 0;

            else
            {
                listofPaymentTypes = grdPaymentTypes.Rows.Where(c => c.Cells[COLSP.Check].Value.ToBool()).Select(a => a.Cells[COLSP.Id].Value.ToIntorNull()).ToList<int?>();
                PaymentTypeId = 1;
            }

            string PaymentTypes = string.Empty;


            PaymentType = string.Join(",", (from a in listofPaymentTypes

                                            select a.Value).ToArray<int>());


            //var drivers = string.Join(",", from item in listofPaymentTypes select  item).ToArray<string>());
            // PaymentType =String.Join(',', (listofPaymentTypes)).ToArray<string>();


            using (TaxiDataContext db = new TaxiDataContext())
            {



                //    var list = db.stp_GetBookingBase(fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList(); ;

                var list = db.ExecuteQuery<stp_GetBookingBaseResultEx>("exec stp_getbookingbase {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy,OperatorId, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList();

                if (ddlCompanyGroup.SelectedValue.ToInt() > 0)
                {
                    var groupRecords = db.Gen_Companies.Where(c => c.GroupId == ddlCompanyGroup.SelectedValue.ToInt()).Select(c => c.Id).ToList();

                    list = list.Where(a => groupRecords.Count(c => c == a.CompanyId) > 0).ToList();

                }


                //if (operatorId > 0)
                //{
                //    list = list.Where(a => a.OperatorId == operatorId).ToList();

                //}


                if (optSortAsc.Checked)
                {
                    list = list.OrderBy(c => c.PickupDateTime)
                                     .ToList();
                }
                else
                {
                    list = list.OrderByDescending(c => c.PickupDateTime)
                                  .ToList();
                }


                return list;
            }


        }

        private List<stp_GetBookingBaseResultEx> GetDataSourceBySPEx(int reportType, int companyId, DateTime? fromDate, DateTime? toDate, int DriverId, int PaymentTypeId, string BookedBy, int CompanyGroupId, long FleetMasterId)
        {



            if (fromDate != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                fromDate = (fromDate.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



            if (toDate != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                toDate = (toDate.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();




         




            string orderNo = ddlOrderNo.Text.Trim();

            int subCompanyId = ddlSubCompany.SelectedValue.ToInt();

            int transferredSubCompanyId = ddlTransferredSubCompanyId.SelectedValue.ToInt();

            int operatorId = ddluser.SelectedValue.ToInt();

            List<int?> listofPaymentTypes = new List<int?>();

            if (grdPaymentTypes.Rows.Count(c => c.Cells[COLSP.Check].Value.ToBool()) == 0)
                PaymentTypeId = 0;

            else
            {
                listofPaymentTypes = grdPaymentTypes.Rows.Where(c => c.Cells[COLSP.Check].Value.ToBool()).Select(a => a.Cells[COLSP.Id].Value.ToIntorNull()).ToList<int?>();
                PaymentTypeId = 1;
            }

            string PaymentTypes = string.Empty;


            PaymentType = string.Join(",", (from a in listofPaymentTypes

                                            select a.Value).ToArray<int>());


            //var drivers = string.Join(",", from item in listofPaymentTypes select  item).ToArray<string>());
            // PaymentType =String.Join(',', (listofPaymentTypes)).ToArray<string>();


            using (TaxiDataContext db = new TaxiDataContext())
            {



                //    var list = db.stp_GetBookingBase(fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList(); ;

                var list = db.ExecuteQuery<stp_GetBookingBaseResultEx>("exec stp_getbookingbase {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy,0, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList();

                if (ddlCompanyGroup.SelectedValue.ToInt() > 0)
                {
                    var groupRecords = db.Gen_Companies.Where(c => c.GroupId == ddlCompanyGroup.SelectedValue.ToInt()).Select(c => c.Id).ToList();

                    list = list.Where(a => groupRecords.Count(c => c == a.CompanyId) > 0).ToList();

                }


                if(operatorId>0)
                {
                    list = list.Where(a =>a.OperatorId==operatorId).ToList();

                }


                if (optSortAsc.Checked)
                {
                    list = list.OrderBy(c => c.PickupDateTime)
                                     .ToList();
                }
                else
                {
                    list = list.OrderByDescending(c => c.PickupDateTime)
                                  .ToList();
                }


                return list;
            }


        }



        public override void Print()
        {
            try
            {

                DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
                DateTime? toDate = dtpToDate.Value.ToDateorNull();


                rptfrmJobListViewer frm = new rptfrmJobListViewer();

                frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);
//                frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                frm.DataSourceBySP = GetDataSourceBySPEx(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                frm.TemplateValue = templateNo + "_rptJobsList.rdlc";
                frm.GenerateReport();

                DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("rptfrmJobListViewer1");

                if (doc != null)
                {
                    doc.Close();
                }
                UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }

        }


        private void btnViewReport_Click_1(object sender, EventArgs e)
        {
            ViewReport();

        }

        public struct COLSP
        {
            public static string Id = "Id";
            public static string PaymentType = "PaymentType";
            public static string Check = "Check";
        }
        private void FormatPaymentTypeGrid()
        {
            grdPaymentTypes.AllowEditRow = true;
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLSP.Id;
            col.IsVisible = false;
            grdPaymentTypes.Columns.Add(col);
            col = new GridViewTextBoxColumn();
            col.Name = COLSP.PaymentType;
            col.HeaderText = "Payment Type";
            col.Width = 100;
            col.ReadOnly = true;

            grdPaymentTypes.Columns.Add(col);
            GridViewCheckBoxColumn cbcol = new GridViewCheckBoxColumn();
            cbcol.Name = COLSP.Check;
            col.ReadOnly = false;
            cbcol.Width = 40;
            grdPaymentTypes.Columns.Add(cbcol);
        }

        public struct COLS
        {



            public static string ID = "ID";
            public static string BookingDate = "BookingDate";

            public static string PickupDate = "PickupDate";
            public static string RefNumber = "RefNumber";
            public static string Passenger = "Passenger";

            public static string Account = "Account";
            public static string PaymentType = "PaymentType";
            public static string OldPaymentType = "OldPaymentType";

            public static string OldPickupPoint = "OldPickupPoint";
            public static string PickupPoint = "PickupPoint";
            public static string Via = "Via";
            public static string Notes = "Notes";
            public static string PaymentRef = "PaymentRef";
            public static string OldDestination = "OldDestination";
            public static string Destination = "Destination";
            public static string Driver = "Driver";
            public static string Vehicle = "Vehicle";
            public static string Fare = "Fare";
            public static string Extra = "Extra";
            public static string DrvParking = "DrvParking";
            public static string DrvWaiting = "DrvWaiting";
            public static string WaitingTime = "WaitingTime";

            public static string AccFare = "AccFare";
            public static string AccParking = "AccParking";
            public static string AccWaiting = "AccWaiting";
            public static string AgentComm = "AgentComm";

            public static string BookingFee = "BookingFee";

            public static string CustFare = "CustFare";

            public static string Status = "Status";
            public static string BookedBy = "BookedBy";
            public static string InvoiceNo = "InvoiceNo";
            public static string DespatchBy = "DespatchBy";
            public static string Journey = "Journey";
            public static string SpecialReq = "SpecialReq";
            public static string IsProcessed = "IsProcessed";
            //public static string EscortName = "EscortName";
            public static string EscortPrice = "EscortPrice";
            public static string EscortNo = "EscortNo";
        }

        public struct eReportType
        {
            public static int COMPLETED_JOBS = 1;
            public static int INCOMPLETE_JOBS = 2;
            public static int NOTACCEPTED_JOBS = 3;
            public static int REJECTED_JOBS = 4;
            public static int CANCELLED_JOBS = 5;
            public static int ALL_JOBS = 6;



        }


        private int GetReportType()
        {

            int reportType = eReportType.COMPLETED_JOBS;
            if (optInCompleteJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = eReportType.INCOMPLETE_JOBS;
            }
            else if (optNotAccepedJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = eReportType.NOTACCEPTED_JOBS;
            }
            else if (optRejectedJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = eReportType.REJECTED_JOBS;
            }
            else if (optCancelledJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = eReportType.CANCELLED_JOBS;
            }
            else if (optAllJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = eReportType.ALL_JOBS;
            }

            return reportType;

        }

        private int GetBookingStatus()
        {

            int reportType = Enums.BOOKINGSTATUS.COMPLETED.ToInt();
            if (optCompletedJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = Enums.BOOKINGSTATUS.DISPATCHED.ToInt();
            }
            else if (optNotAccepedJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = Enums.BOOKINGSTATUS.NOTACCEPTED.ToInt();
            }
            else if (optInCompleteJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = -1;
            }
            else if (optRejectedJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = Enums.BOOKINGSTATUS.REJECTED.ToInt();
            }
            else if (optCancelledJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType =Enums.BOOKINGSTATUS.CANCELLED.ToInt();
            }
            else if (optAllJobs.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                reportType = 0;
            }

            return reportType;

        }

        private void ViewReport()
        {

            try
            {
                string BookedBy = ddlBookedBy.Text.Trim();
                int OperatorId = 0;
                //var listold = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), dtpFromDate.Value.ToDateorNull(), dtpToDate.Value.ToDateorNull(), ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), BookedBy, ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                if (ddluser.SelectedValue != null)
                {
                    OperatorId = int.Parse(ddluser.SelectedValue.ToString());
                }

                var list = GetDataSourceBySPExjobListReport(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), dtpFromDate.Value.ToDateorNull(), dtpToDate.Value.ToDateorNull(), ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), BookedBy, OperatorId, ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());


                lblTotalJobs.Text = "Total Job(s) : " + list.Count.ToStr();


                // grdLister.DataSource = list;
                grdLister.RowCount = list.Count;


                grdLister.MasterTemplate.BeginUpdate();

                GridViewRowInfo row = null;
                for (int i = 0; i < list.Count; i++)
                {

                    row = grdLister.Rows[i];

                    row.Cells[COLS.ID].Value = list[i].Id;
                    //  row.Cells[COLS.BookingDate].Value = list[i].BookingDate.ToDateTime().ToStr();
                    row.Cells[COLS.PickupDate].Value = list[i].PickupDateTime;


                    row.Cells[COLS.RefNumber].Value = list[i].BookingNo.ToStr();
                    row.Cells[COLS.Passenger].Value = list[i].CustomerName.ToStr();

                    row.Cells[COLS.Vehicle].Value = list[i].VehicleTypeId.ToStr();
                    row.Cells[COLS.Account].Value = list[i].CompanyId;
                    row.Cells[COLS.PaymentType].Value = list[i].PaymentTypeId;
                    row.Cells[COLS.OldPaymentType].Value = list[i].PaymentTypeId;

                    row.Cells[COLS.PickupPoint].Value = list[i].FromAddress.ToStr();
                    row.Cells[COLS.OldPickupPoint].Value = list[i].FromAddress.ToStr();



                    row.Cells[COLS.Via].Value = list[i].Via1.ToStr();



                    row.Cells[COLS.Notes].Value = list[i].NotesString.ToStr();
                    row.Cells[COLS.PaymentRef].Value = list[i].PaymentComments.ToStr();
                    row.Cells[COLS.Journey].Value = list[i].JourneyType.ToStr();

                    row.Cells[COLS.Destination].Value = list[i].ToAddress.ToStr();
                    row.Cells[COLS.OldDestination].Value = list[i].ToAddress.ToStr();



                    row.Cells[COLS.Fare].Value = list[i].FareRate.ToDecimal();
                    row.Cells[COLS.DrvParking].Value = list[i].CongtionCharges.ToDecimal();
                    row.Cells[COLS.DrvWaiting].Value = list[i].MeetAndGreetCharges.ToDecimal();
                    row.Cells[COLS.Extra].Value = list[i].ExtraDropCharges.ToDecimal();


                    if (list[i].CompanyId != null)
                    {
                        row.Cells[COLS.AccFare].Value = list[i].CompanyPrice.ToDecimal();
                        row.Cells[COLS.AccParking].Value = list[i].ParkingCharges.ToDecimal();
                        row.Cells[COLS.AccWaiting].Value = list[i].WaitingCharges.ToDecimal();

                    }
                    else
                    {

                        row.Cells[COLS.AccFare].Value = 0.00m;
                        row.Cells[COLS.AccParking].Value = 0.00m;
                        row.Cells[COLS.AccWaiting].Value = 0.00m;



                    }
                   

                    row.Cells[COLS.AgentComm].Value = list[i].AgentCommission.ToDecimal();
                    row.Cells[COLS.CustFare].Value = list[i].CustomerPrice.ToDecimal();
                    row.Cells[COLS.BookingFee].Value = list[i].ServiceCharges.ToDecimal();

                    row.Cells[COLS.Driver].Value = list[i].DriverNo.ToStr();
                    row.Cells[COLS.Status].Value = list[i].StatusName.ToStr();
                    row.Cells[COLS.BookedBy].Value = list[i].BookedBy.ToStr();

                    row.Cells[COLS.InvoiceNo].Value = list[i].InvoiceNo.ToStr();

                    row.Cells[COLS.SpecialReq].Value = list[i].SpecialRequirements.ToStr();


                    row.Cells[COLS.IsProcessed].Value = list[i].CostCenterId;

                    row.Cells[COLS.EscortNo].Value = list[i].EscortNo.ToStr();
                    row.Cells[COLS.EscortPrice].Value = list[i].EscortPrice.ToStr();

                    row.Cells["Mileage"].Value = list[i].TotalTravelledMiles;
                    row.Cells[COLS.WaitingTime].Value = list[i].DriverWaitingMins.ToInt();

                    row.Cells["OrderNo"].Value = list[i].OrderNo.ToStr();
                    row.Cells["MobileNo"].Value = list[i].CustomerMobileNo.ToStr();
                    row.Cells["TelNo"].Value = list[i].CustomerPhoneNo.ToStr();

                    row.Cells["Operator"].Value = list[i].Operator.ToStr();
                    //row.Cells[COLS.EscortName].Value = list[i].EscortName.ToStr();

                }


                grdLister.MasterTemplate.EndUpdate();



                lblTotalJobs.Text = "Total Jobs : " + grdLister.Rows.Count.ToStr();

                UpdateTotalEarning();

            }
            catch(Exception ex)
            {
                lblTotalEarning.Visible = false;

            }
        }

        private void UpdateTotalEarning()
        {
            try
            {


                //decimal cashBookingFee = 0.00m;
                //decimal AccBookingFee = 0.00m;

                //cashBookingFee = grdLister.Rows.Where(c => c.Cells[COLS.Account].Value == null).Sum(c => c.Cells[COLS.BookingFee].Value.ToDecimal()).ToDecimal();

                //AccBookingFee = grdLister.Rows.Where(c => c.Cells[COLS.Account].Value != null).Sum(c => c.Cells[COLS.BookingFee].Value.ToDecimal()).ToDecimal();


                //lblTotalEarning.Text = "Total Earning : " + Math.Round(
                //    (grdLister.Rows.Where(c => c.Cells[COLS.Account].Value == null)
                //    .Sum(c => c.Cells[COLS.Fare].Value.ToDecimal() + c.Cells[COLS.DrvParking].Value.ToDecimal() + c.Cells[COLS.DrvWaiting].Value.ToDecimal()+c.Cells[COLS.BookingFee].Value.ToDecimal())
                //                                                 + grdLister.Rows.Where(c => c.Cells[COLS.Account].Value != null)
                //                                                 .Sum(c => c.Cells[COLS.AccFare].Value.ToDecimal() + c.Cells[COLS.AccParking].Value.ToDecimal() + c.Cells[COLS.AccWaiting].Value.ToDecimal()  + c.Cells[COLS.BookingFee].Value.ToDecimal())), 2);


                //lblTotalEarning.Text+=" | Fares Total : "+Math.Round((grdLister.Rows.Sum(c => c.Cells[COLS.Fare].Value.ToDecimal() + c.Cells[COLS.DrvParking].Value.ToDecimal() + c.Cells[COLS.DrvWaiting].Value.ToDecimal())+ cashBookingFee),2);
                //lblTotalEarning.Text += " | Accounts Total : " + Math.Round((grdLister.Rows.Sum(c => c.Cells[COLS.AccFare].Value.ToDecimal() + c.Cells[COLS.AccParking].Value.ToDecimal() + c.Cells[COLS.AccWaiting].Value.ToDecimal())+AccBookingFee),2);


                //decimal cashBookingFee = 0.00m;
                //decimal AccBookingFee = 0.00m;

                //cashBookingFee = grdLister.Rows.Where(c => c.Cells[COLS.Account].Value == null).Sum(c => c.Cells[COLS.BookingFee].Value.ToDecimal()).ToDecimal();

                //AccBookingFee = grdLister.Rows.Where(c => c.Cells[COLS.Account].Value != null).Sum(c => c.Cells[COLS.BookingFee].Value.ToDecimal()).ToDecimal();


                lblTotalEarning.Text = "Total Earning : " + Math.Round(
                    (grdLister.Rows.Where(c => c.Cells[COLS.Account].Value == null)
                    .Sum(c => c.Cells[COLS.Fare].Value.ToDecimal() + c.Cells[COLS.DrvParking].Value.ToDecimal() + c.Cells[COLS.DrvWaiting].Value.ToDecimal() )
                                                                 + grdLister.Rows.Where(c => c.Cells[COLS.Account].Value != null)
                                                                 .Sum(c => c.Cells[COLS.AccFare].Value.ToDecimal() + c.Cells[COLS.AccParking].Value.ToDecimal() + c.Cells[COLS.AccWaiting].Value.ToDecimal() )), 2);


                lblTotalEarning.Text += " | Fares Total : " + Math.Round((grdLister.Rows.Sum(c => c.Cells[COLS.Fare].Value.ToDecimal() + c.Cells[COLS.DrvParking].Value.ToDecimal() + c.Cells[COLS.DrvWaiting].Value.ToDecimal()) ), 2);
                lblTotalEarning.Text += " | Accounts Total : " + Math.Round((grdLister.Rows.Sum(c => c.Cells[COLS.AccFare].Value.ToDecimal() + c.Cells[COLS.AccParking].Value.ToDecimal() + c.Cells[COLS.AccWaiting].Value.ToDecimal()) ), 2);



                if(grdLister.Columns[COLS.BookingFee].IsVisible)
                    lblTotalEarning.Text += " | Booking Fee : " + Math.Round((grdLister.Rows.Sum(c => c.Cells[COLS.BookingFee].Value.ToDecimal())), 2);




            }
            catch
            {


            }

        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {


            try
            {

                rptfrmJobListViewer frm = new rptfrmJobListViewer();

                DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
                DateTime? toDate = dtpToDate.Value.ToDateorNull();



                frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);
                //frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                frm.DataSourceBySP = GetDataSourceBySPEx(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                frm.TemplateValue = templateNo + "_rptJobsList.rdlc";
                frm.GenerateReport();

                frm.ExportReport();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }



        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ViewDetailForm();
        }

        private void ViewDetailForm()
        {

            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {
                ShowBookingForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
            }
        }

        private void ShowBookingForm(int id)
        {
            if(  General.ShowBookingForm(id, true, "", "", Enums.BOOKING_TYPES.LOCAL))
            {

                using (TaxiDataContext db = new TaxiDataContext())
                {
                   var obj=   db.Bookings.FirstOrDefault(c => c.Id == id);

                    grdLister.CurrentRow.Cells[COLS.Passenger].Value = obj.CustomerName.ToStr();
                    grdLister.CurrentRow.Cells[COLS.PickupDate].Value = obj.PickupDateTime;
                    grdLister.CurrentRow.Cells[COLS.PickupPoint].Value = obj.FromAddress.ToStr();
                    grdLister.CurrentRow.Cells[COLS.Destination].Value = obj.ToAddress.ToStr();


                    grdLister.CurrentRow.Cells[COLS.Vehicle].Value = obj.VehicleTypeId.ToStr();
                    grdLister.CurrentRow.Cells[COLS.Account].Value = obj.CompanyId;
                    grdLister.CurrentRow.Cells[COLS.PaymentType].Value = obj.PaymentTypeId;
                    grdLister.CurrentRow.Cells[COLS.OldPaymentType].Value = obj.PaymentTypeId;



                    grdLister.CurrentRow.Cells[COLS.Via].Value = obj.ViaString.ToStr();








                    grdLister.CurrentRow.Cells[COLS.Fare].Value = obj.FareRate.ToDecimal();
                    grdLister.CurrentRow.Cells[COLS.DrvParking].Value = obj.CongtionCharges.ToDecimal();
                    grdLister.CurrentRow.Cells[COLS.DrvWaiting].Value = obj.MeetAndGreetCharges.ToDecimal();
                    grdLister.CurrentRow.Cells[COLS.Extra].Value = obj.ExtraDropCharges.ToDecimal();


                    if (obj.CompanyId != null)
                    {
                        grdLister.CurrentRow.Cells[COLS.AccFare].Value = obj.CompanyPrice.ToDecimal();
                        grdLister.CurrentRow.Cells[COLS.AccParking].Value = obj.ParkingCharges.ToDecimal();
                        grdLister.CurrentRow.Cells[COLS.AccWaiting].Value = obj.WaitingCharges.ToDecimal();

                    }
                    else
                    {

                        grdLister.CurrentRow.Cells[COLS.AccFare].Value = 0.00m;
                        grdLister.CurrentRow.Cells[COLS.AccParking].Value = 0.00m;
                        grdLister.CurrentRow.Cells[COLS.AccWaiting].Value = 0.00m;



                    }


                    grdLister.CurrentRow.Cells[COLS.AgentComm].Value = obj.AgentCommission.ToDecimal();
          
                    grdLister.CurrentRow.Cells[COLS.BookingFee].Value = obj.ServiceCharges.ToDecimal();

                  

                    grdLister.CurrentRow.Cells[COLS.SpecialReq].Value = obj.SpecialRequirements.ToStr();


                  


                  

                }
                   
            }


            //frmBooking frm = new frmBooking();
            //frm.OnDisplayRecord(id);
            //frm.ControlBox = true;
            //frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            //frm.MaximizeBox = false;
            //frm.ShowDialog();

        }

        private void chkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {



                ddlCompany.SelectedValue = null;
                ddlCompany.Enabled = false;


            }
            else
            {
                if (ddlCompany.DataSource == null)
                {
                    ComboFunctions.FillCompanyCombo(ddlCompany);

                }

                ddlCompany.Enabled = true;

            }
        }
        private void FillCombo()
        {
            //ComboFunctions.FillPaymentTypeCombo(ddlPaymentType);
            //ComboFunctions.FillCompanyGroupCombo(ddlCompanyGroup);



        }
        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                ddlAllDriver.SelectedValue = null;
                ddlAllDriver.Enabled = false;
                //ddlAllDriver.SelectedValue = 0;
            }

            else
            {
                if (ddlAllDriver.DataSource == null)
                {
                    //ComboFunctions.FillDriverCombo(ddlAllDriver);
                    ComboFunctions.FillDriverNoCombo(ddlAllDriver);
                }
                ddlAllDriver.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {

                rptfrmJobListViewer frm = new rptfrmJobListViewer();

                DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
                DateTime? toDate = dtpToDate.Value.ToDateorNull();



                frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);

                if (templateNo.ToStr().ToLower() == "template6" )
                {
                    frm.TemplateValue = templateNo + "_excel_rptJobsList.rdlc";

                }
                else
                {
                    frm.TemplateValue = templateNo + "_rptJobsList.rdlc";

                }
                //frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());


                frm.DataSourceBySP = GetDataSourceBySPEx(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                frm.GenerateReport();

                frm.ExportReportToExcel();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void ddlCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void ddlCompany_SelectedValueChanged(object sender, EventArgs e)
        {


            try
            {

                ShowUpdateAgentCommButton(false);
                int? companyId = ddlCompany.SelectedValue.ToIntorNull();


                if (companyId == null)
                {
                    ddlOrderNo.Enabled = false;

                    ddlBookedBy.DataSource = null;
                }
                else
                {
                    Gen_Company obj = General.GetObject<Gen_Company>(c => c.Id == companyId);
                    if (obj != null)
                    {


                        if (obj.AccountTypeId == Enums.ACCOUNT_TYPE.ACCOUNT)
                        {
                            ddlPaymentType.SelectedValue = null;
                            var item = ddlPaymentType.Items.FirstOrDefault(c => c.Value.ToInt() == 9);
                            if (item != null)
                            {
                                item.Enabled = false;
                            }
                        }
                        else
                        {
                            var item = ddlPaymentType.Items.FirstOrDefault(c => c.Value.ToInt() == 9);
                            if (item != null)
                            {
                                item.Enabled = true;
                            }
                        }


                        if (obj.HasSingleOrderNo.ToBool() == false)
                        {

                            var list = General.GetQueryable<Booking>(c => c.CompanyId == obj.Id && (c.OrderNo != null && c.OrderNo != ""))
                                           .Select(args => new { Id = args.OrderNo, OrderNo = args.OrderNo }).Distinct().ToList();

                            ComboFunctions.FillCombo(list, ddlOrderNo, "OrderNo", "Id");

                            ddlOrderNo.Enabled = true;

                        }
                        else
                        {
                            ddlOrderNo.Enabled = false;

                        }


                        if (obj.CompanyName.ToLower().Contains("direct comm"))
                        {
                            ShowUpdateAgentCommButton(true);

                        }
                        else
                        {

                            ShowUpdateAgentCommButton(false);
                        }

                    }
                    if (obj.HasBookedBy.ToBool())
                    {
                        var list = General.GetQueryable<Booking>(c => c.CompanyId == obj.Id && (c.BookedBy != null && c.BookedBy != ""))
                                                                   .Select(args => new { Id = args.BookedBy, BookedBy = args.BookedBy }).Distinct().ToList();
                        ComboFunctions.FillCombo(list, ddlBookedBy, "BookedBy", "Id");

                        //   ddlBookedBy.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        string pwd = string.Empty;

        private void btnUpdateAll_Click(object sender, EventArgs e)
        {


            try
            {

                //    MessageBox.Show("Please check Account and Jobs"+Environment.NewLine+"Below Jobs will be affected on update");

                if (DialogResult.Yes == MessageBox.Show("Please check Account and Jobs" + Environment.NewLine + "Below Jobs will be affected on update" + Environment.NewLine + " Are you sure you want to update?", "", MessageBoxButtons.YesNo))
                {

                    if (pwd != "euro1234euro")
                    {

                        frmLockingPwd frmUnLock = new frmLockingPwd();
                        frmUnLock.ShowDialog();

                        if (string.IsNullOrEmpty(frmUnLock.ReturnValue1))
                            return;
                        else
                            pwd = frmUnLock.ReturnValue1;


                        frmUnLock.Dispose();
                    }

                    if (pwd.ToStr().Trim().ToLower() == "euro1234euro")
                    {

                        string Ids = string.Join(",", grdLister.Rows.Select(c => c.Cells["Id"].Value.ToStr()).ToArray<string>());


                        if (Ids.ToStr().Length > 0)
                        {
                            btnUpdateAll.Enabled = false;

                            decimal agentValue = numAgentComm.Value;

                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                db.stp_RunProcedure("update booking set AgentCommission=" + agentValue + " where Id in (" + Ids + ")");

                            }

                            foreach (var item in Ids)
                            {
                                UpdateDriverCommission(item);
                            }


                            ViewReport();

                            btnUpdateAll.Enabled = true;
                        }
                        pwd = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
                btnUpdateAll.Enabled = true;
            }

        }

        private void btnColumnChooser_Click(object sender, EventArgs e)
        {
            grdLister.ShowColumnChooser();
        }


        private void InitializeExportGrid2()
        {
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();

            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();


            this.radGridView2.Location = new System.Drawing.Point(405, 60);
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.Size = new System.Drawing.Size(240, 150);
            this.radGridView2.TabIndex = 18;
            this.radGridView2.Text = "radGridView2";
            this.radGridView2.Visible = false;

            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();

            //this.radPanel1.Controls.Add(this.radGridView1);
        }


        private Telerik.WinControls.UI.RadGridView radGridView2;
      

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {

                if (radGridView2 == null)
                    InitializeExportGrid2();

                radGridView2.Columns.Clear();

                foreach (var item in grdLister.Columns.Where(c => c.IsVisible).ToList())
                {

                    //if(item is GridViewDateTimeColumn)
                    //{
                    //    radGridView2.Columns.Add(new GridViewDateTimeColumn { CustomFormat= "dd:MM:yyyy HH:mm", FormatString= "{0:dd:MM:yyyy HH:mm}", Name = item.Name, HeaderText = item.HeaderText, Width = item.Width });

                    //}
                    //else
                    radGridView2.Columns.Add(new GridViewTextBoxColumn { Name = item.Name, HeaderText = item.HeaderText, Width = item.Width });
                }

                radGridView2.RowCount = grdLister.Rows.Count;

                for (int i = 0; i < grdLister.Rows.Count; i++)
                {
                    foreach (var col in grdLister.Columns.Where(c => c.IsVisible == true).ToList())
                    {

                        if (col is GridViewComboBoxColumn)
                        {



                            try
                            {
                                int cellvalue = grdLister.Rows[i].Cells[col.Name].Value.ToInt();
                                var datasource = (object)(grdLister.Columns[col.Name] as GridViewComboBoxColumn).DataSource;
                                IList collection = (IList)datasource;
                                var objData = collection.AsQueryable().OfType<object>().FirstOrDefault(c => c.ToStr().Contains(", Id = " + cellvalue + " }"));

                                if (objData == null)
                                    radGridView2.Rows[i].Cells[col.Name].Value = " ";
                                else
                                {
                                    string item = objData.ToStr().Split(new string[] { ", Id" }, StringSplitOptions.None)[0].Split(new string[] { " = " }, StringSplitOptions.None)[1];
                                    radGridView2.Rows[i].Cells[col.Name].Value = item.ToStr().Trim();


                                }


                            }
                            catch
                            {

                            }

                            //var text=datasource.FirstOrDefault(c => c.ToStr().Contains(", Id = " + cellvalue + " }"));
                            //if(datasource[0])
                            //            radGridView2.Rows[i].Cells[col.Name].Value = grdLister.Rows[i].Cells[col.Name] as GridViewComboBoxColumn).HeaderText;
                        }
                        //else if (col is GridViewDateTimeColumn)
                        //{
                        //    radGridView2.Rows[i].Cells[col.Name].Value =string.Format("{0:dd-MMM-yy  HH:mm}",grdLister.Rows[i].Cells[col.Name].Value)+" ";
                        //}
                        else
                            radGridView2.Rows[i].Cells[col.Name].Value = grdLister.Rows[i].Cells[col.Name].Value;
                    }
                }

                if (radGridView2.Rows.Count > 0)
                {

                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "JobList.csv";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            //try
                            //{
                            int columnCount = (radGridView2.Columns.Count);
                            string columnNames = "";
                            string[] outputCsv = new string[radGridView2.Rows.Count + 1];

                            for (int i = radGridView2.Columns[0].Index; i < grdLister.Columns.Where(c => c.IsVisible == true).Count() - 1; i++)
                            //for (int i = radGridView2.Columns[0].Index; i < radGridView2.Columns.Count; i++)
                            {
                                if (radGridView2.Columns[i].IsVisible && radGridView2.Columns[i].HeaderText!=null)
                                {
                                    columnNames += radGridView2.Columns[i].HeaderText.ToStr() + ",";
                                }
                            }
                            outputCsv[0] += columnNames;
                            for (int i = 1; (i - 1) < radGridView2.Rows.Count; i++)
                            {
                                for (int j = radGridView2.Columns[0].Index; j < columnCount; j++)
                                {
                                    if (radGridView2.Columns[j].IsVisible)
                                    {
                                        if (radGridView2.Rows[i - 1].Cells[j].Value != null)
                                        {
                                            //outputCsv[i] += radGridView2.Rows[i - 1].Cells[j].Value.ToString() + ",";   
                                            outputCsv[i] += "\"" + radGridView2.Rows[i - 1].Cells[j].Value.ToStr() + "\"" + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += "\"" + " " + "\"" + ",";
                                        }
                                    }
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            if (File.Exists(sfd.FileName))
                            {

                                MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Try Again !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }
        List<UM_Form_UserDefinedSetting> hiddenColumnsList = null;

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {


                string query = string.Empty;
                int order = 0;
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    int FormId = db.ExecuteQuery<int>("select Id from UM_Forms where FormName  = 'rptfrmJobsList' ").FirstOrDefault();

                    db.ExecuteQuery<int>("Delete from UM_Form_UserDefinedSettings where FormId = " + FormId);
                    foreach (var item in grdLister.Columns.ToList())
                    {


                        if (item.IsVisible == true)
                        {
                            order = order + 1;
                            query = " insert into UM_Form_UserDefinedSettings(FormId,GridColumnName,IsVisible, GridColWidth,GridColMoveTo)values(" + FormId + ",'" + item.Name + "',1," + item.Width + "," + order + ")";
                        }
                        else
                        {
                            query = " insert into UM_Form_UserDefinedSettings(FormId,GridColumnName,IsVisible,GridColWidth,GridColMoveTo)values(" + FormId + ",'" + item.Name + "',0," + item.Width + "," + 0 + ")";

                        }

                        db.ExecuteQuery<int>(query);

                    }
                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void chkAllPaymentType_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(args.ToggleState== ToggleState.On)
            {
                grdPaymentTypes.Rows.ToList().ForEach(c => c.Cells[COLSP.Check].Value = true);
            }
            else
            {
                grdPaymentTypes.Rows.ToList().ForEach(c => c.Cells[COLSP.Check].Value = false);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            grdPaymentTypes.Rows.ToList().ForEach(c => c.Cells[COLSP.Check].Value = false);
        }

        private void ddlCompanyGroup_Enter(object sender, EventArgs e)
        {
            if (ddlCompanyGroup.DataSource == null)
                ComboFunctions.FillCompanyGroupCombo(ddlCompanyGroup);
        }
    }
}
