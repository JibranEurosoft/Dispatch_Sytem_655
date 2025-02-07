using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Utils;
using Taxi_Model;
using Taxi_BLL;
using Telerik.WinControls.Enumerations;
using System.Collections;
using Telerik.Data;

namespace Taxi_AppMain
{
    public partial class rptfrmRentReport : UI.SetupBase
    {
        //RadGridViewExcelExporter exporter = null;

        IList listofPaymentTypes = null;

        List<Gen_PaymentType> paymentTypesLst = new List<Gen_PaymentType>();


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

        public struct COLSP
        {
            public static string Id = "Id";
            public static string PaymentType = "PaymentType";
            public static string Check = "Check";
        }

        public struct COLS
        {
            //Driver Acc Total(a)    Credit Card Total(b)   Rent(c)    Total Balance(d)           

            public static string Id = "ID";
            public static string DriverName = "Driver Name";
            public static string DriverNo = "Driver";
            public static string AccTotal = "Acc Total";
            public static string CreditCard = "Credit Card Total";
            public static string Rent = "Rent";
            public static string TotalBalance = "Total Balance";
        }

        class DriverRent
        {
            public int Id { get; set; }
            public string DriverName { get; set; }
            public string DriverNo { get; set; }
            public decimal? AccTotal { get; set; }
            public decimal? CreditCard { get; set; }
            public decimal? Rent { get; set; }
            public decimal? TotalBalance { get; set; }
        }

        public rptfrmRentReport()
        {
            InitializeComponent();

              
         
            FormatPaymentTypeGrid();
            LoadPaymentTypes();

          
            grdLister.BestFitColumns();               
            grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            grdLister.EnableAlternatingRowColor = true;
            grdLister.TableElement.AlternatingRowColor = Color.AliceBlue;
     
            chkAllDriver_ToggleStateChanged(chkAllDriver, new StateChangedEventArgs(ToggleState.On));
            radCheckBox1_ToggleStateChanged(radCheckBox1, new StateChangedEventArgs(ToggleState.On));
            chkAllDriver.Checked = true;
            radCheckBox1.Checked = false;
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

       

        private void LoadPaymentTypes()
        {
            try
            {
                var list = (from a in General.GetQueryable<Gen_PaymentType>(c => c.IsVisible == true)
                            select new { Id = a.Id, PaymentType = a.PaymentType }).ToList();

                list = list.Where(x => x.PaymentType.ToUpper() != "CASH").OrderBy(c=>c.PaymentType).ToList();
                grdPaymentTypes.RowCount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    grdPaymentTypes.Rows[i].Cells[COLSP.Id].Value = list[i].Id;
                    grdPaymentTypes.Rows[i].Cells[COLSP.PaymentType].Value = list[i].PaymentType;
                    grdPaymentTypes.Rows[i].Cells[COLSP.Check].Value = true;
                }

                grdPaymentTypes.ShowColumnHeaders = false;
                listofPaymentTypes = list;
            }
            catch (Exception ex){ ex.ToString(); }
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

           else  if (e.CellElement.RowInfo is GridViewSummaryRowInfo)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = GradientStyles.Solid;
                e.CellElement.BackColor = Color.Gainsboro;
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
                e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);
                e.CellElement.ForeColor = Color.Red;
            }
            //radCheckBox1.Checked = false;
        }
     

        private void rptfrmJobsPaymentList_Load(object sender, EventArgs e)
        {
         

            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.LastDayOfMonthValue());

            //Driver Acc Total(a)    Credit Card Total(b)   Rent(c)    Total Balance(d)           

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.Id;
            col.HeaderText = "ID";
            col.Width = 30;
            grdLister.Columns.Add(col);

         

            col = new GridViewTextBoxColumn();             
            col.ReadOnly = true;
            col.HeaderText = "Driver No";
            col.Name = COLS.DriverNo;
            col.TextAlignment = ContentAlignment.MiddleCenter;
            col.Width = 30;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.Name = COLS.DriverName;
            col.HeaderText = "Name";
            col.Width = 150;
            grdLister.Columns.Add(col);

            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Acc Total"; 
            colD.Name = COLS.AccTotal;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.Width = 50;
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Credit Card Total";
            colD.Name = COLS.CreditCard;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.Width = 50;
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Rent";
            colD.Name = COLS.Rent;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.Width = 50;
            grdLister.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Minimum = 0;
            colD.ReadOnly = true;
            colD.HeaderText = "Total Balance";
            colD.Name = COLS.TotalBalance;
            colD.Maximum = 9999999;
            colD.FormatString = "{0:#,###0.00}";
            colD.Width = 50;
            grdLister.Columns.Add(colD);

            this.grdLister.MasterTemplate.SummaryRowsBottom.Clear();

            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();

            GridViewSummaryItem cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.AccTotal;
            
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.CreditCard;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.Rent;
            item2.Add(cc);

            cc = new GridViewSummaryItem();
            cc.Aggregate = GridAggregateFunction.Sum;
            cc.Name = COLS.TotalBalance;
            item2.Add(cc);

            grdLister.MasterTemplate.Columns[COLS.AccTotal].TextAlignment = ContentAlignment.MiddleRight;
            grdLister.MasterTemplate.Columns[COLS.CreditCard].TextAlignment = ContentAlignment.MiddleRight;
            grdLister.MasterTemplate.Columns[COLS.TotalBalance].TextAlignment = ContentAlignment.MiddleRight;

            grdLister.MasterTemplate.SummaryRowsBottom.Add(item2);
            grdLister.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;



            ddlDrivers.Enter += DdlDrivers_Enter;
        }

        private void DdlDrivers_Enter(object sender, EventArgs e)
        {   
            if(ddlDrivers.DataSource==null)
                ComboFunctions.FillDriverNoCombo(ddlDrivers);
        }

       
        
 
           
        private void btnViewReport_Click_1(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void ViewReport()
        {

            DateTime? fromDate = dtpFromDate.Value.ToDateorNull();
            DateTime? toDate = dtpToDate.Value.ToDateorNull();

            if (fromDate != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
                fromDate = (fromDate.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();

            if (toDate != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
                toDate = (toDate.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();

            int DriverId = ddlDrivers.SelectedValue.ToInt();
            string Rent =(tbRent.Enabled? tbRent.Text:"0");
            var payType = string.Join(",", grdPaymentTypes.Rows.Where(c => c.Cells["Check"].Value.ToBool()).Select(c => c.Cells[COLSP.PaymentType].Value.ToStr()));
            string AccTotal = payType.Contains("Account")? "Account":"";
            string CardTotal = (","+(payType + ",")).Replace(",Account","");

            CardTotal = CardTotal.Remove(0,1);
            CardTotal = (CardTotal.Length>0? CardTotal.Remove(CardTotal.Length-1,1):"");

         
            using (TaxiDataContext db = new TaxiDataContext())
            {
                    var list = db.ExecuteQuery<DriverRent>("exec sp_CalculateDriverRent {0},{1},{2},{3},{4},{5}", fromDate, toDate, Rent,DriverId, AccTotal, CardTotal).ToList();
            
                grdLister.RowCount = list.Count;

            
                for (int i = 0; i < list.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.Id].Value = list[i].Id;
                    grdLister.Rows[i].Cells[COLS.DriverName].Value = list[i].DriverName.ToStr();
                    grdLister.Rows[i].Cells[COLS.DriverNo].Value = list[i].DriverNo;

                    grdLister.Rows[i].Cells[COLS.AccTotal].Value = list[i].AccTotal.ToStr();
                    grdLister.Rows[i].Cells[COLS.CreditCard].Value = list[i].CreditCard.ToStr();

                    grdLister.Rows[i].Cells[COLS.Rent].Value = list[i].Rent.ToStr();
                    grdLister.Rows[i].Cells[COLS.TotalBalance].Value = list[i].TotalBalance.ToStr();

                   
                }

           


            }
        }

  
        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState ==  ToggleState.On)
            {
                ddlDrivers.SelectedValue = null;
                ddlDrivers.Enabled = false;
                ddlDrivers.SelectedValue = 0;                
            }
            else
            {
                if (ddlDrivers.DataSource != null)
                {             
                    ComboFunctions.FillDriverNoCombo(ddlDrivers);
                    if (ddlDrivers.Items.Count > 0)
                    {
                        ddlDrivers.SelectedValue = 2;
                    }
                }
                ddlDrivers.Enabled = true;
            }
        }

      

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                tbRent.Enabled = true;
            }
            else
            {
                tbRent.Enabled = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {



                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {

                    if (grdLister.Rows.Count == 0)
                        ViewReport();

                    //exporter = new RadGridViewExcelExporter();

                    //BackgroundWorker worker = new BackgroundWorker();
                    //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                    //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
                    //worker.RunWorkerAsync(saveFileDialog1.FileName);
                    //exporter.Progress += new ProgressHandler(exportProgress);

                    this.btnExportExcel.Enabled = false;
                    this.btnViewReport.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.IsDisposed)
            {
                e.Cancel = true;
                return;
            }

         //   exporter.Export(this.grdLister, (String)e.Argument, "Rent Report");


        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {



            this.btnExportExcel.Enabled = true;
            this.btnViewReport.Enabled = true;
            this.radProgressBar1.Value1 = 0;

            ENUtils.ShowMessage("Export successfully.");

        }

        //Update the progress bar with the export progress    
        private void exportProgress(object sender, ProgressEventArgs e)
        {

            if (this.IsDisposed)
                return;
            // Call InvokeRequired to check if thread needs marshalling, to access properly the UI thread.
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(
                    delegate
                    {
                        if (e.ProgressValue <= 100)
                        {
                            radProgressBar1.Value1 = e.ProgressValue;
                        }
                        else
                        {
                            radProgressBar1.Value1 = 100;
                        }
                    }));
                }
                else
                {
                    if (e.ProgressValue <= 100)
                    {
                        radProgressBar1.Value1 = e.ProgressValue;
                    }
                    else
                    {
                        radProgressBar1.Value1 = 100;
                    }
                }
            }
            catch
            {

            }
        }







    }
}
