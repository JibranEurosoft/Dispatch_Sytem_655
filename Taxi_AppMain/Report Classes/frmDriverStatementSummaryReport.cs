using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Taxi_Model;
using Telerik.WinControls;
using Utils;
using Telerik.WinControls.UI.Export;
using Telerik.Data;
using System.IO;
using System.Diagnostics;
using Telerik.WinControls.UI.Export.ExcelML;
using System.Threading;

namespace Taxi_AppMain
{
    public partial class frmDriverStatementSummaryReport : UI.SetupBase
    {
      
        public frmDriverStatementSummaryReport()
        {
            InitializeComponent();

            FormatGrid();
            DefaultDate();
            FillCombo();
            this.btnShow.Click += new EventHandler(btnShowVehicle_Click);
            this.btnExport2.Click += new EventHandler(btnExport2_Click);
            this.Load += FrmDriverStatementSummaryReport_Load;
        }
        private void FillCombo()
        {
            ComboFunctions.FillDriverNoComboSorted(ddlAllDriver);
            ComboFunctions.FillSubCompanyCombo(ddlSubCompany);
        }

        private void FormatGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS_.DriverNo;
            col.HeaderText = "Driver";
            col.ReadOnly = true;          
            col.Width = 70;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.DriverName;
            col.HeaderText = "Driver Name";
            col.ReadOnly = true;
            col.Width = 150;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS_.OfficeCommission;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Office Commission";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS_.AppFee;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "App Fee";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.BookingFee;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Booking Fee";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.AccountCredit;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Account Credit";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.ParkingTotal;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Parking Total";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS_.PaidPromotional;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Paid Promotions";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.Debit;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Debit";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_.Credit;
            col.ReadOnly = true;
            col.Width = 120;
            col.TextAlignment = ContentAlignment.MiddleRight;
            col.HeaderText = "Credit";
            grdLister.Columns.Add(col);


            UI.GridFunctions.SetFilter(grdLister);


            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();

            GridViewSummaryItem cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.Credit;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.Debit;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.OfficeCommission;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.AppFee;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.BookingFee;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.ParkingTotal;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.PaidPromotional;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS_.AccountCredit;
            item2.Add(cc);

            this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            this.grdLister.ViewCellFormatting += grdLister_ViewCellFormatting;
        }

       

        private void FrmDriverStatementSummaryReport_Load(object sender, EventArgs e)
        {
            PopulateData();
        }


        void btnExport2_Click(object sender, EventArgs e)
        {
            ExportDriverCommissionReport();
            
            ENUtils.ShowMessage("File has been saved successfully !");

        }
        private void ExportDriverCommissionReport()
        {
            try
            {
                if (DialogResult.OK == saveFileDialog2.ShowDialog())
                {
                    this.btnExport2.Enabled = false;
                    

                    ClsExportGridView objClsExportGridView = new ClsExportGridView(grdLister, saveFileDialog2.FileName);
                    
                    objClsExportGridView.TitleFontSize = 18;
                    objClsExportGridView.ApplyCellFormatting = true;
                    objClsExportGridView.TitleBackColor = Color.Red;
                    objClsExportGridView.TitleForeColor = Color.White;
                    objClsExportGridView.HeaderBackColor = Color.Black;
                    objClsExportGridView.HeaderForeColor = Color.White;
                    objClsExportGridView.ExportExcel();
                    objClsExportGridView = null;
                    this.btnExport2.Enabled = true;
                   
                   
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }


        void btnShowVehicle_Click(object sender, EventArgs e)
        {
            PopulateData();
        }


        private void DefaultDate()
        {

            dtpFromDate.Value=new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            dtpTillDate.Value = DateTime.Now;
        }
      

        private void PopulateData()
        {
            try
            {
                string Message = string.Empty;
                DateTime? dtFrom = dtpFromDate.Value.ToDateorNull();
                DateTime? dtTill = dtpTillDate.Value.ToDateorNull();

                if (dtTill != null)
                    dtTill = dtTill + TimeSpan.Parse("23:59:59");


                string MonthCommencing = string.Empty;
                if (dtFrom.Value == null)
                {
                    Message = "Required : From Date";
                }
                if (dtTill.Value == null)
                {
                    if (!string.IsNullOrEmpty(Message))
                    {
                        Message = "Required : To Date";
                    }
                    else
                    {
                        Message += Environment.NewLine;// "Required : To Date";
                        Message += "Required : To Date";
                    }
                }
                if (!string.IsNullOrEmpty(Message))
                {
                    RadMessageBox.Show(Message);
                    return;
                }

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list1 = new TaxiDataContext().ExecuteQuery<stp_DriverStatementSummaryReportResult>("exec stp_DriverStatementSummaryReport {0},{1},{2},{3}", dtFrom, dtTill, ddlAllDriver.SelectedValue.ToInt(), ddlSubCompany.SelectedValue.ToInt()).ToList();

                    var list = (list1.AsEnumerable().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>())).ToList();

                    // grdLister.DataSource = list;

                    grdLister.Rows.Clear();

                    grdLister.RowCount = list.Count;


                    grdLister.MasterTemplate.BeginUpdate();

                    GridViewRowInfo row = null;
                    for (int i = 0; i < list.Count; i++)
                    {

                        row = grdLister.Rows[i];

                        row.Cells[COLS_.DriverNo].Value = list[i].DriverNo;

                        row.Cells[COLS_.DriverName].Value = list[i].DriverName;

                        row.Cells[COLS_.OfficeCommission].Value = list[i].OfficeCommission;

                        row.Cells[COLS_.AppFee].Value = list[i].AppFee;

                        row.Cells[COLS_.AccountCredit].Value = list[i].AccountCredit;

                        row.Cells[COLS_.BookingFee].Value = list[i].BookingFee;

                        row.Cells[COLS_.ParkingTotal].Value = list[i].ParkingTotal;

                        row.Cells[COLS_.PaidPromotional].Value = list[i].PaidPromotional;

                        row.Cells[COLS_.Credit].Value = list[i].Credit;

                        row.Cells[COLS_.Debit].Value = list[i].Debit;

                    }


                    grdLister.MasterTemplate.EndUpdate();

                }

                

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
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


                       
                        e.CellElement.RowElement.DrawFill = false;
                    
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



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public struct COLS_
        {

            public static string DriverNo = "DriverNo";
            public static string DriverName = "DriverName";
            public static string OfficeCommission = "OfficeCommission";
            public static string AppFee = "AppFee";
            public static string BookingFee = "BookingFee";
            public static string AccountCredit = "AccountCredit";
            public static string ParkingTotal = "ParkingTotal";
            public static string PaidPromotional = "PaidPromotional";
            public static string Debit = "Debit";
            public static string Credit = "Credit";

        }

        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAllDriver.Checked == true)
            {
                ddlAllDriver.Enabled = false;
                ddlAllDriver.SelectedText = string.Empty;
            }
            else if(chkAllDriver.Checked == false)
            {
                ddlAllDriver.Enabled = true;
            }
        }
    }
}


public class stp_DriverStatementSummaryReportResult
{

    public string DriverNo;

    public string DriverName;

    public System.Nullable<decimal> OfficeCommission;

    public System.Nullable<decimal> AppFee;

    public System.Nullable<decimal> BookingFee;

    public System.Nullable<decimal> AccountCredit;

    public System.Nullable<decimal> ParkingTotal;

    public System.Nullable<decimal> PaidPromotional;

    public System.Nullable<decimal> Debit;

    public System.Nullable<decimal> Credit;
}