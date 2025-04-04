﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls;
using Telerik.Data;
using Taxi_AppMain.Classes;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Docking;
using UI;

namespace Taxi_AppMain
{
    public partial class frmDriverPaymentCollectionHistory : UI.SetupBase
    {
        DriverCommissionCollectionHistoryBO objDriverCommissionCollectionHistory;
        public frmDriverPaymentCollectionHistory()
        {
            InitializeComponent();
            FormatGrid();
            grdLister.AllowEditRow = true;
            grdLister.ShowGroupPanel = false;
            grdLister.EnableHotTracking = false;
            grdLister.EnableFiltering = true;
            objDriverCommissionCollectionHistory = new DriverCommissionCollectionHistoryBO();
            this.SetProperties((INavigation)objDriverCommissionCollectionHistory);

            this.Load += new EventHandler(frmPaymentCollection_Load);
            this.grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            this.btnExit1.Click += new EventHandler(btnExit1_Click);

            this.btnExportExcel.Click += new EventHandler(btnExportExcel_Click);
            this.grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            grdLister.AllowAddNewRow = false;
            this.grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            this.btnShow.Click += new EventHandler(btnShow_Click);
            this.btnDeleteAll.Click += new EventHandler(btnDeleteAll_Click);
        }

        void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteDriverPayment();
        }

        void btnShow_Click(object sender, EventArgs e)
        {
            PopulateData();
        }
        private void DeleteDriverPayment()
        {
            try
            {

                string Error = string.Empty;
                if (grdLister.Rows.Count() > 0 && grdLister.Rows.Count(c => c.Cells["Check"].Value.ToBool() == true) == 0)
                {
                    Error = "Please select record to delete";
                }
              
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }
                //long TranId = row.Cells[COLS.TranId].Value.ToLong();
                int Id = 0;
                int TransId = 0;
                long TranId = 0;
                if (grdLister.Rows.Count(c => c.Cells["Check"].Value.ToBool() == true) > 0)
                {
                    if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete Driver Payment", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    {
                        foreach (var item in grdLister.Rows.Where(c => c.Cells["Check"].Value.ToBool() == true))
                        {
                            //long TranId = row.Cells["TranId"].Value.ToLong();
                            Id = item.Cells["Id"].Value.ToInt();
                            TransId = item.Cells["TranId"].Value.ToInt();
                            TranId = item.Cells["TranId"].Value.ToLong();

                            if (TranId > 0)
                            {
                                try
                                {
                                    using (TaxiDataContext db = new TaxiDataContext())
                                    {


                                        if (db.GetTable<Fleet_DriverCommissionCollectionHistory_Detail>().Count(c => c.TransId == TransId) == 1)
                                        {

                                            Fleet_DriverCommissionCollectionHistory objHistory = db.GetTable<Fleet_DriverCommissionCollectionHistory>().FirstOrDefault(c =>
                                                          (c.Id == TranId));


                                            if (objHistory != null)
                                            {

                                                db.Fleet_DriverCommissionCollectionHistories.DeleteOnSubmit(objHistory);
                                                db.SubmitChanges();
                                            }

                                        }
                                        else
                                        {

                                            Fleet_DriverCommissionCollectionHistory_Detail objDetail = db.Fleet_DriverCommissionCollectionHistory_Details.FirstOrDefault(c => c.Id == Id);


                                            if (objDetail != null)
                                            {

                                                db.Fleet_DriverCommissionCollectionHistory_Details.DeleteOnSubmit(objDetail);
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
                        }
                        PopulateData();
                    }
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

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

            if (e.CellElement.RowInfo is GridViewSummaryRowInfo)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor = Color.Gainsboro;
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
                e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
            }
        }






        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name == "btnDelete")
            {

                GridViewRowInfo row = gridCell.RowInfo;

                if (row is GridViewDataRowInfo)
                {
                    long TranId = row.Cells[COLS.TranId].Value.ToLong();


                    if (TranId > 0)
                    {


                        try
                        {

                            int Id= row.Cells[COLS.Id].Value.ToInt();
                             int TransId= row.Cells[COLS.TranId].Value.ToInt();

                            using (TaxiDataContext db = new TaxiDataContext())
                            {


                                if (db.GetTable<Fleet_DriverCommissionCollectionHistory_Detail>().Count(c => c.TransId==TransId) == 1)
                              {

                                      Fleet_DriverCommissionCollectionHistory objHistory=db.GetTable<Fleet_DriverCommissionCollectionHistory>().FirstOrDefault(c =>
                                                    (c.Id==TranId));


                                            if (objHistory != null)
                                            {

                                                db.Fleet_DriverCommissionCollectionHistories.DeleteOnSubmit(objHistory);
                                                db.SubmitChanges();
                                            }

                                }
                                else

                                {

                                    Fleet_DriverCommissionCollectionHistory_Detail objDetail = db.Fleet_DriverCommissionCollectionHistory_Details.FirstOrDefault(c => c.Id == Id);


                                     if(objDetail!=null)
                                     {

                                         db.Fleet_DriverCommissionCollectionHistory_Details.DeleteOnSubmit(objDetail);
                                         db.SubmitChanges();

                                     }
                                }

                            }                           


                            PopulateData();
                            
                        }
                        catch (Exception ex)
                        {

                            ENUtils.ShowMessage(ex.Message);

                        }
                    }
                }
            }

        }

        void btnExportExcel_Click(object sender, EventArgs e)
        {

            if (grdLister.Rows.Count == 0)
                return;

            try
            {


                saveFileDialog1.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";

                saveFileDialog1.Title = "Save File";
                saveFileDialog1.FileName = "Driver Collection History";


                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    grdLister.Columns["IsPaid"].IsVisible = false;
                    grdLister.Columns["Paid"].IsVisible = true;
                    //grdLister.Columns["btnUpdate"].IsVisible = false;

                    grdLister.Columns[COLS.Active].HeaderText = "Active";
                    grdLister.Columns[COLS.Active].Width = 30;
                    grdLister.Columns[COLS.Rent].Width = 60;
                    grdLister.Columns[COLS.DriverNo].Width = 35;
                    grdLister.Columns[COLS.PreviousBalance].Width = 85;
                    grdLister.Columns[COLS.Adjustment].Width = 60;
                    grdLister.Columns[COLS.Collection].Width = 50;
                    grdLister.Columns[COLS.OldCollection].Width = 70;

                    grdLister.Columns[COLS.AgentCommission].Width = 60;
                    grdLister.Columns[COLS.OldAgentBalance].Width = 90;

                    grdLister.Columns[COLS.Total].Width = 45;
                    grdLister.Columns[COLS.Paid].Width = 35;




                    var row = grdLister.Rows.OrderByDescending(c => c.Cells["ToDate"].Value.ToDate()).FirstOrDefault();

                    DateTime? dtCurrent = row.Cells["FromDate"].Value.ToDate();
                    DateTime dtEnd = row.Cells["ToDate"].Value.ToDate();



                    Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[1];
                    string heading = string.Empty;
                    heading = "Driver Collection History - " + string.Format("from {0:dd/MM/yyyy}", dtCurrent) + " until " + string.Format("{0:dd/MM/yyyy}", dtEnd);

                    ClsExportGridView obj = new ClsExportGridView(grdLister, saveFileDialog1.FileName);
                    obj.ApplyCellFormatting = true;
                    obj.ConditionalFormattingObject = new StyleDataRowConditionalFormattingObject();
                    obj.ConditionalFormattingObject.ConditionFormattingColumnName = "Paid";
                    obj.ConditionalFormattingObject.RowBackColor = Color.LightGreen;
                    obj.ConditionalFormattingObject.RowForeColor = Color.Black;
                    obj.ConditionalFormattingObject.TValue = "Paid";


                    obj.Heading = heading;
                    if (obj.ExportExcel())
                    {
                        RadDesktopAlert alert = new RadDesktopAlert();
                        alert.CaptionText = "Export";
                        alert.ContentText = "<html> <b><span style=font-size:medium><color=Blue>Export Successfully</span></b></html>";
                        alert.Show();

                    }

                    //grdLister.Columns["IsPaid"].IsVisible = true;
                    //grdLister.Columns["Paid"].IsVisible = false;
                    grdLister.Columns["IsPaid"].IsVisible = false;
                    grdLister.Columns["Paid"].IsVisible = true;
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
            finally
            {

                SetDefaultColumnSettings();

            }


            //rptfrmDriverPaymentCollection frm = new rptfrmDriverPaymentCollection();
            //frm.LoadReport();
            //frm.ExportReportToExcel("excel");
        }


        private void SetDefaultColumnSettings()
        {
            grdLister.Columns["IsPaid"].IsVisible = false;
            grdLister.Columns["Paid"].IsVisible = true;

            grdLister.Columns[COLS.Active].HeaderText = "Active/Off";
            grdLister.Columns[COLS.Active].Width = 110;
            grdLister.Columns[COLS.Rent].Width = 100;
            grdLister.Columns[COLS.DriverNo].Width = 100;
            grdLister.Columns[COLS.PreviousBalance].Width = 160;
            grdLister.Columns[COLS.Adjustment].Width = 100;
            grdLister.Columns[COLS.Collection].Width = 120;
            grdLister.Columns[COLS.AgentCommission].Width = 140;
            grdLister.Columns[COLS.OldAgentBalance].Width = 170;

            grdLister.Columns[COLS.Total].Width = 100;
            grdLister.Columns[COLS.Paid].Width = 100;

        }



        void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
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


        void frmPaymentCollection_Load(object sender, EventArgs e)
        {
            FillCombo();

        }
        private void FillCombo()
        {
            ComboFunctions.FillDriverCommissionCollectionHistoryCombo(ddlDateRange);
            //ComboFunctions.FillDriverNoCombo(ddlDriver);
            ComboFunctions.FillDriverNoCombo(ddlDriver, c => c.DriverTypeId == 2);
        }


        public struct COLS
        {
            public static string Paid = "Paid";
            public static string FromDate = "FromDate";
            public static string ToDate = "ToDate";
            public static string IsPaid = "IsPaid";
            public static string Id = "Id";
            public static string TranId = "TranId";
            public static string Active = "Active";
            public static string DriverNo = "DriverNo";
            public static string DriverName = "DriverName";

            public static string Rent = "Rent";
            public static string PaidRent = "PaidRent";

            public static string Collection = "Collection";
            public static string PaidCollection = "PaidCollection";

            public static string OldCollection = "OldCollection";
            public static string OldPaidCollection = "OldPaidCollection";

            public static string Adjustment = "Adjustment";
            public static string PaidAdjustment = "PaidAdjustment";

            public static string OldAdjustment = "OldAdjustment";
            public static string OldPaidAdjustment = "OldPaidAdjustment";

            public static string AgentCommission = "AgentCommission";
            public static string PaidAgentCommission = "PaidAgentCommission";



            public static string OldAgentBalance = "OldAgentBalance";
            public static string PaidOldAgentBalance = "PaidOldAgentBalance";


            public static string PreviousBalance = "PreviousBalance";
            public static string PaidPreviousBalance = "PaidPreviousBalance";

            public static string Total = "Total";
            public static string PaidTotal = "PaidTotal";


        }
        private void FormatGrid()
        {

            GridViewCheckBoxColumn cb = new GridViewCheckBoxColumn();
            cb.Name = "Check";
            cb.Width = 80;
            cb.ReadOnly = false;
            grdLister.Columns.Add(cb);

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.Id;
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.TranId;
            col.IsVisible = false;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS.Active;
            col.HeaderText = "Active/Off";
            col.Width = 110;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverNo;
            col.HeaderText = "Driver";
            col.Width = 100;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverName;
            col.IsVisible = false;
            grdLister.Columns.Add(col);

            // Rent/Comm Column

            GridViewDecimalColumn dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.Rent;
            dcol.HeaderText = "Rent/Comm";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidRent;
            dcol.HeaderText = "Paid Rent/Comm";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);





            // Prev Rent/Comm Column

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PreviousBalance;
            dcol.HeaderText = "Prev Rent/Comm";
            dcol.Width = 160;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidPreviousBalance;
            dcol.HeaderText = "Paid Prev Rent/Comm";
            dcol.Width = 160;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);





            // Collection Column

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.Collection;
            dcol.HeaderText = COLS.Collection;
            dcol.Width = 100;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            grdLister.Columns.Add(dcol);



            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidCollection;
            dcol.HeaderText = COLS.PaidCollection;
            dcol.Width = 120;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);






            // Old Collection Column

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.OldCollection;
            dcol.HeaderText = "Prev Collection";
            dcol.Width = 120;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            grdLister.Columns.Add(dcol);



            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.OldPaidCollection;
            dcol.HeaderText = COLS.OldPaidCollection;
            dcol.Width = 120;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);





            // Agent Commission Column


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.AgentCommission;
            dcol.HeaderText = "Agent Comm";
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.Width = 110;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            grdLister.Columns.Add(dcol);



            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidAgentCommission;
            dcol.HeaderText = "Paid Agent Comm";
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.Width = 140;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);









            // Previous Agent Commission Column

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.OldAgentBalance;
            dcol.HeaderText = "Prev Agent Comm";
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.Width = 150;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            grdLister.Columns.Add(dcol);


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidOldAgentBalance;
            dcol.HeaderText = "Paid Prev Agent Comm";
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            dcol.Width = 170;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);










            // Adjustments Column

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.Adjustment;
            dcol.HeaderText = "Adjustment";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = false;
            grdLister.Columns.Add(dcol);


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidAdjustment;
            dcol.HeaderText = "Paid Adjustment";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = false;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);



            // old adjustments column
            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.OldAdjustment;
            dcol.HeaderText = "Prev Adj.";
            dcol.Width = 70;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = false;
            grdLister.Columns.Add(dcol);


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.OldPaidAdjustment;
            dcol.HeaderText = "Prev Paid Adjustment";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = false;
            dcol.IsVisible = false;
            grdLister.Columns.Add(dcol);



            // Total COlumn

            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.Total;
            dcol.HeaderText = "Total";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);


            dcol = new GridViewDecimalColumn();
            dcol.Name = COLS.PaidTotal;
            dcol.HeaderText = "Paid Total";
            dcol.Width = 100;
            dcol.DecimalPlaces = 2;
            dcol.ReadOnly = true;
            dcol.IsVisible = false;
            dcol.ExcelExportType = DisplayFormatType.Text;
            dcol.ExcelExportFormatString = "{0:d}";
            grdLister.Columns.Add(dcol);








            GridViewCheckBoxColumn cbcol = new GridViewCheckBoxColumn();
            cbcol.Name = COLS.IsPaid;
            cbcol.HeaderText = "Paid";
            cbcol.Width = 100;
            grdLister.Columns.Add(cbcol);


            col = new GridViewTextBoxColumn();
            col.Name = COLS.Paid;
            col.HeaderText = COLS.Paid;
            col.Width = 100;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            GridViewDateTimeColumn dtCol = new GridViewDateTimeColumn();
            dtCol.Name = COLS.FromDate;
            dtCol.HeaderText = COLS.FromDate;
            dtCol.Width = 120;
            dtCol.ReadOnly = true;
            dtCol.IsVisible = false;
            grdLister.Columns.Add(dtCol);


            dtCol = new GridViewDateTimeColumn();
            dtCol.Name = COLS.ToDate;
            dtCol.HeaderText = COLS.ToDate;
            dtCol.Width = 120;
            dtCol.ReadOnly = true;
            dtCol.IsVisible = false;
            grdLister.Columns.Add(dtCol);

           

            GridViewCommandColumn cmdcol = new GridViewCommandColumn();
            cmdcol.Width = 80;
            cmdcol.Name = "btnDelete";
            cmdcol.UseDefaultText = true;
            cmdcol.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            cmdcol.DefaultText = "Delete";
            cmdcol.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            grdLister.Columns.Add(cmdcol);



            ConditionalFormattingObject obj = new ConditionalFormattingObject();
            obj.RowBackColor = Color.LightGreen;
            obj.TValue1 = "Paid";
            obj.ConditionType = ConditionTypes.Equal;
            obj.TValue2 = string.Empty;
            obj.RowForeColor = Color.Black;
            obj.ApplyToRow = true;

            grdLister.Columns[COLS.Paid].ConditionalFormattingObjectList.Add(obj);


            ConditionalFormattingObject obj2 = new ConditionalFormattingObject();
            obj2.TValue1 = "(C)";
            obj2.ConditionType = ConditionTypes.EndsWith;
            obj2.TValue2 = string.Empty;
            obj2.CellForeColor = Color.White;
            obj2.CellBackColor = Color.Red;
            obj2.ApplyToRow = false;
            grdLister.Columns[COLS.DriverNo].ConditionalFormattingObjectList.Add(obj2);

        }
        public override void PopulateData()
        {
            try
            {
                int RangeId = ddlDateRange.SelectedValue.ToInt();
                int DriverId = ddlDriver.SelectedValue.ToInt();
                string Error = string.Empty;
                if (RangeId == 0)
                {
                    Error = "Required: Date Range";
                }

                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }
                int idx = 0;
                int val = 0;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    //var list = (from a in db.stp_PaymentCollection()
                    //            select new
                    //            {
                    //                Id = a.Id,
                    //                Active = a.Active,
                    //                DriverNo = a.DriverNo,
                    //                DriverName = a.DriverName,
                    //                Rent = a.Rent,
                    //                Collection = a.PDA,
                    //                AgentCommission = a.AgentCommission,
                    //                OldAgentBalance = a.OldAgentBalance,
                    //                PerviousBalance = a.BalanceDue,
                    //                Adjustments=a.Adjustments,
                    //                Total = a.Total,
                    //                IsPaid = a.IsPaid,
                    //                TranId=a.TransId,
                    //                FromDate=  a.FromDate,
                    //               ToDate= a.ToDate,
                    //                Paid=a.IsPaid!=null && a.IsPaid==true ? "Paid" : ""
                    //            }).ToList();

                    //var list =(from a in db.stp_GetDriverCommissionCollectionHistory(RangeId, DriverId)
                    //               select new
                    //               {
                    //                   Id = a.Id,
                    //                   Active = a.Active,
                    //                   DriverNo = a.DriverNo,
                    //                   //DriverName = a.DriverName,
                    //                   Rent = a.RentComm,
                    //                   Collection = a.DriverCollection,
                    //                   AgentCommission = a.AgentCommission,
                    //                   OldAgentBalance = a.PreviousAgentCommission,
                    //                   PerviousBalance = a.PrevRentComm,
                    //                   Adjustments = a.Adjustment,
                    //                   Total = a.Total,
                    //                   IsPaid = a.IsPaid,
                    //                   TranId = a.TransId,
                    //                   FromDate = a.FromDate,
                    //                   ToDate = a.TillDate,
                    //                   Paid = a.IsPaid != null && a.IsPaid == true ? "Paid" : ""
                    //               }).ToList();
                    var list = (db.stp_GetDriverCommissionCollectionHistory(RangeId, DriverId)).ToList();

                    if (list.Count == 0)
                    {
                        grdLister.RowCount = 0;
                        return;
                    }
                    var list2 = (from a in list.AsEnumerable().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>())
                                 select new
                                 {
                                     Id = a.Id,
                                     Paid = a.IsPaid != null && a.IsPaid == true ? "Paid" : "",
                                     IsPaid = a.IsPaid,
                                     PreviousAgentCommission = a.PreviousAgentCommission,
                                     PrevRentComm = a.PrevRentComm,
                                     RentComm = a.RentComm,
                                     TillDate = a.TillDate,
                                     Total = a.Total,
                                     TransId = a.TransId,
                                     FromDate = a.FromDate,
                                     DriverNo = a.DriverNo,
                                     DriverCollection = a.DriverCollection,
                                     PrevDriverCollection=a.PrevDriverCollection,

                                     AgentCommission = a.AgentCommission,
                                     Adjustment = a.Adjustment,
                                     PrevAdjustment= a.PrevAdjustment,
                                     Active = a.Active,
                                 }).ToList();

                    idx = grdLister.CurrentRow != null ? grdLister.CurrentRow.Cells[COLS.Id].Value.ToInt() : -1;
                    val = grdLister.TableElement.VScrollBar.Value;



                    grdLister.BeginUpdate();
                    grdLister.RowCount = list2.Count;
                    for (int i = 0; i < list2.Count; i++)
                    {
                        grdLister.Rows[i].Cells[COLS.Id].Value = list2[i].Id;
                        grdLister.Rows[i].Cells[COLS.Active].Value = list2[i].Active;
                        grdLister.Rows[i].Cells[COLS.DriverNo].Value = list2[i].DriverNo;
                        //grdLister.Rows[i].Cells[COLS.DriverName].Value = list2[i].DriverName;


                        grdLister.Rows[i].Cells[COLS.Rent].Value = list2[i].RentComm;
                        grdLister.Rows[i].Cells[COLS.PaidRent].Value = list2[i].IsPaid.ToBool() && list2[i].RentComm.ToDecimal() > 0 ? list2[i].RentComm.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.Collection].Value = list2[i].DriverCollection;
                        grdLister.Rows[i].Cells[COLS.PaidCollection].Value = list2[i].IsPaid.ToBool() ? list2[i].DriverCollection.ToDecimal() : 0.00m;



                        grdLister.Rows[i].Cells[COLS.OldCollection].Value = list2[i].PrevDriverCollection.ToDecimal();
                        grdLister.Rows[i].Cells[COLS.OldPaidCollection].Value = list2[i].IsPaid.ToBool() ? list2[i].PrevDriverCollection.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.AgentCommission].Value = list2[i].AgentCommission;
                        grdLister.Rows[i].Cells[COLS.PaidAgentCommission].Value = list2[i].IsPaid.ToBool() ? list2[i].AgentCommission.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.OldAgentBalance].Value = list2[i].PreviousAgentCommission.ToDecimal();
                        grdLister.Rows[i].Cells[COLS.PaidOldAgentBalance].Value = list2[i].IsPaid.ToBool() ? list2[i].PreviousAgentCommission.ToDecimal() : 0.00m;



                        grdLister.Rows[i].Cells[COLS.PreviousBalance].Value = list2[i].PrevRentComm;
                        grdLister.Rows[i].Cells[COLS.PaidPreviousBalance].Value = list2[i].IsPaid.ToBool() && list2[i].PrevRentComm.ToDecimal() > 0 ? list2[i].PrevRentComm.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.Adjustment].Value = list2[i].Adjustment.ToDecimal();
                        grdLister.Rows[i].Cells[COLS.PaidAdjustment].Value = list2[i].IsPaid.ToBool() ? list2[i].Adjustment.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.OldAdjustment].Value = list2[i].PrevAdjustment.ToDecimal();
                        grdLister.Rows[i].Cells[COLS.OldPaidAdjustment].Value = list2[i].IsPaid.ToBool() ? list2[i].PrevAdjustment.ToDecimal() : 0.00m;


                        grdLister.Rows[i].Cells[COLS.Total].Value = list2[i].Total;
                        grdLister.Rows[i].Cells[COLS.PaidTotal].Value = list2[i].IsPaid.ToBool() ? list2[i].Total.ToDecimal() : 0.00m;



                        grdLister.Rows[i].Cells[COLS.IsPaid].Value = list2[i].IsPaid;
                        grdLister.Rows[i].Cells[COLS.TranId].Value = list2[i].TransId;

                        grdLister.Rows[i].Cells[COLS.Paid].Value = list2[i].Paid;
                        grdLister.Rows[i].Cells[COLS.FromDate].Value = list2[i].FromDate;
                        grdLister.Rows[i].Cells[COLS.ToDate].Value = list2[i].TillDate;
                        grdLister.Rows[i].Cells["Check"].Value = false;
                    }


                    grdLister.EndUpdate();

                }

                grdLister.Columns["FromDate"].IsVisible = false;
                grdLister.Columns["ToDate"].IsVisible = false;
                grdLister.Columns["IsPaid"].IsVisible = false;


                AddSummaries();
                UpdatePeriod();

                if (idx > 0)
                    grdLister.CurrentRow = grdLister.Rows.FirstOrDefault(c => c.Cells[COLS.Id].Value.ToInt() == idx);


                if (grdLister.TableElement.VScrollBar.Maximum >= val)
                    grdLister.TableElement.VScrollBar.Value = val;
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void UpdatePeriod()
        {
            try
            {

                var row = grdLister.Rows.OrderByDescending(c => c.Cells["ToDate"].Value.ToDate()).FirstOrDefault();

                DateTime? dtCurrent = row.Cells["FromDate"].Value.ToDate();
                DateTime dtEnd = row.Cells["ToDate"].Value.ToDate();
                this.FormTitle = "Drivers Collection History - " + string.Format("from {0:dd/MM/yyyy}", dtCurrent) + " until " + string.Format("{0:dd/MM/yyyy}", dtEnd);



            }
            catch
            {



            }
        }


        private void AddSummaries()
        {


            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();

            GridViewSummaryItem c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.None;
            c.Name = "DriverNo";
            c.AggregateExpression = "SUM(Rent)";
            c.FormatString = "Total";
            item2.Add(c);

            //  item2.Add(new GridViewSummaryItem("DriverNo", "Total", GridAggregateFunction.None));
            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidRent + ")";
            c.Name = COLS.Rent;
            c.FormatString = "{0}";
            item2.Add(c);

            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidPreviousBalance + ")";
            c.Name = COLS.PreviousBalance;
            c.FormatString = "{0}";
            item2.Add(c);



            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidCollection + ")";
            c.Name = COLS.Collection;
            c.FormatString = "{0}";
            item2.Add(c);


       

            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.OldPaidCollection + ")";
            c.Name = COLS.OldCollection;
            c.FormatString = "{0}";
            item2.Add(c);

            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidAgentCommission + ")";
            c.Name = COLS.AgentCommission;
            c.FormatString = "{0}";
            item2.Add(c);


            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidOldAgentBalance + ")";
            c.Name = COLS.OldAgentBalance;
            c.FormatString = "{0}";
            item2.Add(c);


            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidAdjustment + ")";
            c.Name = COLS.Adjustment;
            c.FormatString = "{0}";
            item2.Add(c);


            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.OldPaidAdjustment + ")";
            c.Name = COLS.OldAdjustment;
            c.FormatString = "{0}";
            item2.Add(c);


            c = new GridViewSummaryItem();
            c.Aggregate = GridAggregateFunction.Sum;
            c.AggregateExpression = "SUM(" + COLS.PaidTotal + ")";
            c.Name = COLS.Total;
            c.FormatString = "{0}";
            item2.Add(c);
            //item2.Add(new GridViewSummaryItem("Rent", "{0}", GridAggregateFunction.Sum));


            //item2.Add(new GridViewSummaryItem("Collection", "{0}", GridAggregateFunction.Sum));

            //item2.Add(new GridViewSummaryItem("AgentCommission", "{0}", GridAggregateFunction.Sum));

            //item2.Add(new GridViewSummaryItem("OldAgentBalance", "{0}", GridAggregateFunction.Sum));

            //   item2.Add(new GridViewSummaryItem(COLS.Adjustment, "{0}", GridAggregateFunction.Sum));
            ////   item2.Add(new GridViewSummaryItem(COLS.PreviousBalance, "{0}", GridAggregateFunction.Sum));


            //   item2.Add(new GridViewSummaryItem("Total", "{0}", GridAggregateFunction.Sum));

            this.grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            this.grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
        }







        private void cbAllCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllCompany.Checked == true)
            {
                if (grdLister.Rows.Count > 0)
                {
                    for (int i = 0; i < grdLister.Rows.Count; i++)
                    {
                        grdLister.Rows[i].Cells["Check"].Value = true;//..CurrentCell.Value;
                    }
                }
            }
            else if (cbAllCompany.Checked == false)
            {
                if (grdLister.Rows.Count > 0)
                {
                    for (int i = 0; i < grdLister.Rows.Count; i++)
                    {
                        grdLister.Rows[i].Cells["Check"].Value = false;//..CurrentCell.Value;

                    }
                }
            }
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            try
            {
                int RangeId = ddlDateRange.SelectedValue.ToInt();


                if (RangeId == 0)
                {

                    ENUtils.ShowMessage("Please select a DateRange History");
                    return;
                }

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    Fleet_DriverCommissionCollectionHistory objHistory = db.GetTable<Fleet_DriverCommissionCollectionHistory>().FirstOrDefault(c =>
                                  (c.Id == RangeId));


                    if (objHistory != null)
                    {

                        db.Fleet_DriverCommissionCollectionHistories.DeleteOnSubmit(objHistory);
                        db.SubmitChanges();
                    }


                }


                ComboFunctions.FillDriverCommissionCollectionHistoryCombo(ddlDateRange);
                grdLister.Rows.Clear();
               

            }
            catch(Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }
       



    }
}
