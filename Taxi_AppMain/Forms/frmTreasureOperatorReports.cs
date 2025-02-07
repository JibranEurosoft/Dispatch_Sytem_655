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
    public partial class frmTreasureOperatorReports : UI.SetupBase
    {
       // RadGridViewExcelExporter exporter = null;
        //RadGridViewExcelExporter exporter2 = null;
        
        public frmTreasureOperatorReports()
        {
            InitializeComponent();
            grdOperatorPrivateHireDriverRecord.ReadOnly = true;
            grdOperatorPrivateHireDriverRecord.ShowGroupPanel = false;
            grdOperatorPrivateHireDriverRecord.EnableHotTracking = false;
            grdOperatorPrivateHireDriverRecord.EnableFiltering = true;
            this.btnShowOperator.Click += new EventHandler(btnShowOperator_Click);
           
            DefaultDate();
            FillCombo();
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.btnShowVehicle.Click += new EventHandler(btnShowVehicle_Click);
            this.btnExport2.Click += new EventHandler(btnExport2_Click);
           
            this.Load += new EventHandler(frmTreasureOperatorReports_Load);
            this.radProgressBar1.Visible = false;
            this.radProgressBar2.Visible = false;
        }



        void frmTreasureOperatorReports_Load(object sender, EventArgs e)
        {
            LoadOperatorPrivateHireDriverRecord();
            OperatorVehicleRecod();
           // BookingReport();
        }

      

        void btnExport2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
              
                if (radGridView2 == null)
                    InitializeExportGrid2();

                radGridView2.Columns.Clear();
                
                radGridView2.Columns.Add(new GridViewTextBoxColumn("MonthCommencing", "MonthCommencing"));
                radGridView2.Columns.Add(new GridViewTextBoxColumn("OperatorLicenceNumber", "OperatorLicenceNumber"));
                radGridView2.Columns.Add(new GridViewTextBoxColumn("OperatorName", "OperatorName"));
                radGridView2.Columns.Add(new GridViewTextBoxColumn("VehicleRegistrationMark", "VehicleRegistrationMark"));
                radGridView2.Columns.Add(new GridViewTextBoxColumn("VehicleMake", "VehicleMake"));
                radGridView2.Columns.Add(new GridViewTextBoxColumn("PHCVehicle", "PHCVehicle"));

                List<string> lst = new List<string>();
                var list = (from a in grdOperatorVehicleRecord.Rows
                            select new
                            {
                                MonthCommencing = a.Cells["MonthCommencing"].Value,
                                OperatorLicenceNumber = a.Cells["OperatorLicenceNumber"].Value,
                                OperatorName = a.Cells["OperatorName"].Value,
                                VehicleRegistrationMark = a.Cells["VehicleRegistrationMark"].Value,
                                VehicleMake = a.Cells["VehicleMake"].Value,
                                PHCVehicle = a.Cells["PHCVehicle"].Value,
                            }).ToList();
                lst.Add(list[0].VehicleRegistrationMark.ToString());
                lst.Add(list[0].VehicleMake.ToString());
                lst.Add(list[0].PHCVehicle.ToString());



                radGridView2.RowCount = list.Count;
                for (int i = 0; i < radGridView2.RowCount; i++)
                {
                    radGridView2.Rows[i].Cells["MonthCommencing"].Value = " " + list[i].MonthCommencing + " ";
                    radGridView2.Rows[i].Cells["OperatorLicenceNumber"].Value = list[i].OperatorLicenceNumber;
                    radGridView2.Rows[i].Cells["OperatorName"].Value = list[i].OperatorName;
                    radGridView2.Rows[i].Cells["VehicleRegistrationMark"].Value = " " + list[i].VehicleRegistrationMark + " ";
                    radGridView2.Rows[i].Cells["VehicleMake"].Value = list[i].VehicleMake;
                    radGridView2.Rows[i].Cells["PHCVehicle"].Value = list[i].PHCVehicle;
                }



                // grdOperatorVehicleRecord.Columns["VehicleOwner"].IsVisible = false;
                radGridView2.Columns["MonthCommencing"].IsVisible = false;
                radGridView2.Columns["OperatorName"].IsVisible = false;
                radGridView2.Columns["OperatorLicenceNumber"].IsVisible = false;


                radGridView2.Columns["MonthCommencing"].HeaderText = "Month Commencing";
                radGridView2.Columns["OperatorLicenceNumber"].HeaderText = "Operator Licence Number";
                radGridView2.Columns["OperatorName"].HeaderText = "Operator Name";
                radGridView2.Columns["VehicleRegistrationMark"].HeaderText = "VRM";
                radGridView2.Columns["VehicleMake"].HeaderText = "Vehicle Make";
                radGridView2.Columns["PHCVehicle"].HeaderText = "Vehicle Licence Number";


                if (radGridView2.Rows.Count > 0)
                {

                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "Output.csv";
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
                            for (int i = radGridView2.Columns["VehicleRegistrationMark"].Index; i < radGridView2.Columns.Count; i++)
                            {
                                if (radGridView2.Columns[i].IsVisible)
                                {
                                    columnNames += radGridView2.Columns[i].HeaderText.ToString() + ",";
                                }
                            }
                            outputCsv[0] += columnNames;
                            for (int i = 1; (i - 1) < radGridView2.Rows.Count; i++)
                            {
                                for (int j = radGridView2.Columns["VehicleRegistrationMark"].Index; j < columnCount; j++)
                                {
                                    if (radGridView2.Columns[j].IsVisible)
                                    {
                                        if (radGridView2.Rows[i - 1].Cells[j].Value != null)
                                            outputCsv[i] += radGridView2.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Error :" + ex.Message);
                            //}

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

            /*
            try
            {
                saveFileDialog2.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx"; //"CSV|*.csv|All file|*.*";
                saveFileDialog2.FilterIndex = 1;
                if (DialogResult.OK == saveFileDialog2.ShowDialog())
                {

                    this.btnExport2.Enabled = false;
                   

                    ClsExportGridView obj = new ClsExportGridView(grdOperatorVehicleRecord, saveFileDialog2.FileName);
                    obj.ApplyCellFormatting = false;
                    obj.ApplyCustomCellFormatting = true;
                   
                    obj.ExportExcelAsync();

                    this.btnExport2.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
             */
        }

        void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnExport2.Enabled = true;
            this.radProgressBar2.Value1 = 0;

            MessageBox.Show("Export successfully.");
        }

        void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.IsDisposed)
            {
                e.Cancel = true;
                return;
            }
          //  exporter2.Export(this.radGridView2, (String)e.Argument, "Vehicle Record");
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.IsDisposed)
            {
                e.Cancel = true;
                return;
            }
         //   exporter.Export(this.radGridView1, (String)e.Argument, "Booking Report");


        }

        //Update the progress bar with the export progress    
        
       
        private void exportProgress2(object sender, ProgressEventArgs e)
        {

            if (this.IsDisposed)
                return;
            // Call InvokeRequired to check if thread needs marshalling, to access properly the UI thread.
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(
                delegate
                {
                    if (e.ProgressValue <= 100)
                    {
                        radProgressBar2.Value1 = e.ProgressValue;
                    }
                    else
                    {
                        radProgressBar2.Value1 = 100;
                    }
                }));
            }
            else
            {
                if (e.ProgressValue <= 100)
                {
                    radProgressBar2.Value1 = e.ProgressValue;
                }
                else
                {
                    radProgressBar2.Value1 = 100;
                }
            }
        }
        // when the worker finishes the export, we can do some post processing   
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {



            this.btnExport.Enabled = true;
            this.radProgressBar1.Value1 = 0;

            MessageBox.Show("Export successfully.");

        }

        void exporter_CSVCellFormatting(object sender, Telerik.WinControls.UI.Export.CSV.CSVCellFormattingEventArgs e)
        {
            if (e.GridColumnIndex == 11 && e.GridRowInfoType == typeof(GridViewDataRowInfo))
            {
                e.CSVCellElement.Value = ".1671370201";
            }
         
        }

        void btnShowVehicle_Click(object sender, EventArgs e)
        {
            OperatorVehicleRecod();
        }
        void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (radGridView1 == null)
                    InitializeExportGrid();


                radGridView1.Columns.Clear();
                radGridView1.Columns.Add(new GridViewTextBoxColumn("MonthCommencing", "MonthCommencing"));
                radGridView1.Columns.Add(new GridViewTextBoxColumn("OperatorLicenceNumber", "OperatorLicenceNumber"));

                radGridView1.Columns.Add(new GridViewTextBoxColumn("OperatorName", "OperatorName"));

                radGridView1.Columns.Add(new GridViewTextBoxColumn("PrivateHireLicenceNumber", "PrivateHireLicenceNumber"));
                radGridView1.Columns.Add(new GridViewTextBoxColumn("FirstName", "FirstName"));
                radGridView1.Columns.Add(new GridViewTextBoxColumn("Surname", "Surname"));
                radGridView1.Columns.Add(new GridViewTextBoxColumn("Surname2", "Surname2"));




                var list = (from a in grdOperatorPrivateHireDriverRecord.Rows
                            select new
                            {
                                MonthCommencing = a.Cells["MonthCommencing"].Value,
                                OperatorLicenceNumber = a.Cells["OperatorLicenceNumber"].Value,
                                OperatorName = a.Cells["OperatorName"].Value,
                                PrivateHireLicenceNumber = a.Cells["PrivateHireLicenceNumber"].Value,//
                                FirstName = a.Cells["FirstName"].Value,//
                                Surname = a.Cells["Surname"].Value,//
                                Surname2 = a.Cells["Surname2"].Value,

                            }).ToList();
                radGridView1.RowCount = list.Count;
                for (int i = 0; i < radGridView1.RowCount; i++)
                {
                    radGridView1.Rows[i].Cells["MonthCommencing"].Value = list[i].MonthCommencing;
                    radGridView1.Rows[i].Cells["OperatorLicenceNumber"].Value = list[i].OperatorLicenceNumber;
                    radGridView1.Rows[i].Cells["OperatorName"].Value = list[i].OperatorName;
                    radGridView1.Rows[i].Cells["PrivateHireLicenceNumber"].Value = list[i].PrivateHireLicenceNumber;
                    radGridView1.Rows[i].Cells["FirstName"].Value = list[i].FirstName;
                    radGridView1.Rows[i].Cells["Surname"].Value = list[i].Surname;
                    radGridView1.Rows[i].Cells["Surname2"].Value = list[i].Surname2;
                   
                }
                radGridView1.Columns["MonthCommencing"].HeaderText = "Month Commencing";
                radGridView1.Columns["OperatorLicenceNumber"].HeaderText = "Operator Licence Number";
                radGridView1.Columns["OperatorName"].HeaderText = "Operator Name";
                radGridView1.Columns["PrivateHireLicenceNumber"].HeaderText = "Private Hire Driver Licence Number";
                radGridView1.Columns["FirstName"].HeaderText = "Forename";
                radGridView1.Columns["Surname"].HeaderText = "Surname";
                radGridView1.Columns["Surname2"].HeaderText = "";


                


                if (radGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "Output.csv";
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
                            int columnCount = (radGridView1.Columns.Count - 1);
                            string columnNames = "";
                            string[] outputCsv = new string[radGridView1.Rows.Count + 1];
                            for (int i = radGridView1.Columns["PrivateHireLicenceNumber"].Index; i < radGridView1.Columns.Count; i++)
                            {
                                if (radGridView1.Columns[i].IsVisible)
                                {
                                    columnNames += radGridView1.Columns[i].HeaderText.ToString() + ",";
                                }
                            }
                            outputCsv[0] += columnNames;
                            for (int i = 1; (i - 1) < radGridView1.Rows.Count; i++)
                            {
                                for (int j = radGridView1.Columns["PrivateHireLicenceNumber"].Index; j < columnCount; j++)
                                {
                                    if (radGridView1.Columns[j].IsVisible)
                                    {
                                        if (radGridView1.Rows[i - 1].Cells[j].Value != null)
                                            outputCsv[i] += radGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                    }
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            if (File.Exists(sfd.FileName))
                            {
                                MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Try Again !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Error :" + ex.Message);
                            //}
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //grdOperatorPrivateHireDriverRecord.Columns["FirstName"].Width = 150;
                //grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].Width = 180;
                //grdOperatorPrivateHireDriverRecord.Columns["Surname"].Width = 140;



                //ExportToCSV exporter = new ExportToCSV(this.grdOperatorPrivateHireDriverRecord);

                //exporter.SummariesExportOption = SummariesOption.DoNotExport;

                //exporter.RunExport(saveFileDialog1.FileName);

                this.btnExport.Enabled = true;
                // }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

            /*
            try
            {
                saveFileDialog1.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx"; //"CSV|*.csv|All file|*.*"; //

                saveFileDialog1.FilterIndex = 1;

                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    
                    this.btnExport.Enabled = false;

                    grdOperatorPrivateHireDriverRecord.Columns["FirstName"].Width = 180;
                    grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].Width = 230;
                    grdOperatorPrivateHireDriverRecord.Columns["Surname"].Width = 180;


                    btnExport.Enabled = false;
                    ClsExportGridView obj = new ClsExportGridView(grdOperatorPrivateHireDriverRecord, saveFileDialog1.FileName);
                    obj.ApplyCellFormatting = false;
                    obj.ApplyCustomCellFormatting = true;
                    //  obj.Heading = heading;

                   obj.ExportExcelAsync();

                    btnExport.Enabled = true;

                   
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
               
            //ExportOperatorPrivateHireDriverRecord();
            //this.btnExport.Enabled = true;
            //grdOperatorPrivateHireDriverRecord.Columns["OperatorLicenceNumber"].Width = 160;
            //grdOperatorPrivateHireDriverRecord.Columns["MonthCommencing"].Width = 160;
            //grdOperatorPrivateHireDriverRecord.Columns["OperatorName"].Width = 170;
            //grdOperatorPrivateHireDriverRecord.Columns["FirstName"].Width = 150;
            //grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].Width = 180;
            //grdOperatorPrivateHireDriverRecord.Columns["Surname"].Width = 110;
    */
        }

   
        
        private void InitializeExportGrid()
        {
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();

            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();


            this.radGridView1.Location = new System.Drawing.Point(405, 60);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(240, 150);
            this.radGridView1.TabIndex = 18;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.Visible = false;

            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();

            //this.radPanel1.Controls.Add(this.radGridView1);
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


        private void ExportOperatorPrivateHireDriverRecord()
        {
            try
            {
                saveFileDialog1.Filter = "CSV|*.csv|All file|*.*";
                saveFileDialog1.FilterIndex = 1;
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    this.btnExport.Enabled = false;
                    grdOperatorPrivateHireDriverRecord.Columns["OperatorLicenceNumber"].Width = 140;
                    grdOperatorPrivateHireDriverRecord.Columns["MonthCommencing"].Width = 130;
                    grdOperatorPrivateHireDriverRecord.Columns["OperatorName"].Width = 150;
                    grdOperatorPrivateHireDriverRecord.Columns["FirstName"].Width = 140;
                    grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].Width = 140;
                    grdOperatorPrivateHireDriverRecord.Columns["Surname"].Width = 110;
                    ClsExportGridView objClsExportGridView = new ClsExportGridView(this.grdOperatorPrivateHireDriverRecord, saveFileDialog1.FileName);
                    objClsExportGridView.ApplyCellFormatting = true;
                    string headerText = "Date Range : " + string.Format("{0:dd-MMM-yy}", dtpFromDate.Value) + " to " + string.Format("{0:dd-MMM-yy}", dtpToDate.Value);
                    objClsExportGridView.Heading = headerText;
                    objClsExportGridView.TitleFontSize = 18;
                    objClsExportGridView.TitleBackColor = Color.Red;
                    objClsExportGridView.TitleForeColor = Color.White;
                    objClsExportGridView.HeaderBackColor = Color.Black;
                    objClsExportGridView.HeaderForeColor = Color.White;
                    objClsExportGridView.ExportExcelAsync(radProgressBar1);
                    objClsExportGridView = null;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);

            }
        }

        private void DefaultDate()
        {
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
            dtpFromDate2.Value = DateTime.Now.AddMonths(-1);
            dtpToDate2.Value = DateTime.Now;
            
        }
        private void FillCombo()
        {
            using (TaxiDataContext db = new TaxiDataContext())
            {
                var list = (from a in db.Gen_SubCompanies
                            select new
                            {
                                Id = a.Id,
                                CompanyName = a.CompanyName
                            }).ToList();
                ddlSubCompany.DataSource = list;
                ddlSubCompany.DisplayMember = "CompanyName";
                ddlSubCompany.ValueMember = "Id";
                ddlSubCompany2.DataSource = list;
                ddlSubCompany2.DisplayMember = "CompanyName";
                ddlSubCompany2.ValueMember = "Id";
             
               

            }
        }
        void btnShowOperator_Click(object sender, EventArgs e)
        {
            LoadOperatorPrivateHireDriverRecord();
        }
        private void LoadOperatorPrivateHireDriverRecord()
        {
            try
            {
                string Message = string.Empty;
                DateTime? dtFrom = dtpFromDate.Value.ToDateorNull();
                DateTime? dtTill = dtpToDate.Value.ToDateorNull();
                int BookingStatusId = 0;
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
                MonthCommencing = string.Format("{0:dd/MM/yyyy}", dtFrom.Value) + "-" + string.Format("{0:dd/MM/yyyy}", dtTill.Value);
                if (rdoAll.IsChecked)
                {
                    BookingStatusId = 0;
                }
                if (rdoCompleted.IsChecked)
                {
                    BookingStatusId = 2;
                }
                if (rdoCanceled.IsChecked)
                {
                    BookingStatusId = 3;
                }
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list = db.stp_OperatorPrivateHireDriverRecord(ddlSubCompany.SelectedValue.ToInt(), dtFrom.Value, dtTill.Value + TimeSpan.Parse("23:59:59"), BookingStatusId, MonthCommencing).Where(c=>c.FirstName.ToLower()!="test").ToList();
                    
                    //var list2=NaturalSortComparer(list.OrderBy(c=>c.DriverNo)).
                    var list2 = (list.AsEnumerable().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>())).ToList();

                    grdOperatorPrivateHireDriverRecord.DataSource = list2;

                }
                grdOperatorPrivateHireDriverRecord.Columns["Id"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["BookingNo"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["DriverId"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["Surname2"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["DriverNo"].IsVisible = false;

                grdOperatorPrivateHireDriverRecord.Columns["MonthCommencing"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["OperatorLicenceNumber"].IsVisible = false;
                grdOperatorPrivateHireDriverRecord.Columns["OperatorName"].IsVisible = false;

                grdOperatorPrivateHireDriverRecord.Columns["MonthCommencing"].HeaderText = "Month Commencing";
                grdOperatorPrivateHireDriverRecord.Columns["OperatorLicenceNumber"].HeaderText = "Operator Licence Number";
                grdOperatorPrivateHireDriverRecord.Columns["OperatorLicenceNumber"].Width = 160;
                grdOperatorPrivateHireDriverRecord.Columns["MonthCommencing"].Width = 160;
                grdOperatorPrivateHireDriverRecord.Columns["OperatorName"].HeaderText = "Operator Name";
                grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].HeaderText = "Private hire Driver Licence Number";
                grdOperatorPrivateHireDriverRecord.Columns["FirstName"].HeaderText = "Forename";
                grdOperatorPrivateHireDriverRecord.Columns["OperatorName"].Width = 170;
                grdOperatorPrivateHireDriverRecord.Columns["FirstName"].Width = 150;
                grdOperatorPrivateHireDriverRecord.Columns["PrivateHireLicenceNumber"].Width = 280;
                grdOperatorPrivateHireDriverRecord.Columns["Surname"].Width = 140;



            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }
        //Operator Vehicle recod

        private void OperatorVehicleRecod()
        {
            try
            {
                string Message = string.Empty;
                DateTime? dtFrom = dtpFromDate2.Value.ToDateorNull();
                DateTime? dtTill = dtpToDate2.Value.ToDateorNull();
                int BookingStatusId = 0;
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
                MonthCommencing = string.Format("{0:dd/MM/yyyy}", dtFrom.Value) + "-" + string.Format("{0:dd/MM/yyyy}", dtTill.Value);
                if (rdoAll2.IsChecked)
                {
                    BookingStatusId = 0;
                }
                if (rdoCompleted2.IsChecked)
                {
                    BookingStatusId = 2;
                }
                if (rdoCanceled2.IsChecked)
                {
                    BookingStatusId = 3;
                }
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list = db.stp_OperatorVehicleRecord(ddlSubCompany2.SelectedValue.ToInt(), dtFrom.Value, dtTill.Value + TimeSpan.Parse("23:59:59"), BookingStatusId, MonthCommencing).ToList();
                    list = list.Where(c => c.VehicleRegistrationMark != "").ToList();
                    var list2 = (list.AsEnumerable().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>())).ToList();

                    grdOperatorVehicleRecord.DataSource = list2;

                    //grdOperatorVehicleRecord.RowCount = list2.Count;
                    //for (int i = 0; i < list2.Count; i++)
                    //{
                    //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.VehicleRegistrationMark].Value =" "+ list2[i].VehicleRegistrationMark+" ";
                    //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.VehicleModel].Value = " " + list2[i].VehicleModel + " ";
                    //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.PHCVehicle].Value = " " + list2[i].PHCVehicle.ToString() + " ";
                    //}

                }
                grdOperatorVehicleRecord.Columns["Id"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["BookingNo"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["DriverId"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["DriverNo"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["DriverName"].IsVisible = false;
               // grdOperatorVehicleRecord.Columns["VehicleOwner"].IsVisible = false;

                grdOperatorVehicleRecord.Columns["MonthCommencing"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["OperatorLicenceNumber"].IsVisible = false;
                grdOperatorVehicleRecord.Columns["OperatorName"].IsVisible = false;
                //grdOperatorVehicleRecord.Columns["VehicleColor"].IsVisible = false;
               // grdOperatorVehicleRecord.Columns["VehicleType"].IsVisible = false;
             //   grdOperatorVehicleRecord.Columns["VehicleModel"].IsVisible = false;

                grdOperatorVehicleRecord.Columns["MonthCommencing"].HeaderText = "Month Commencing";
                grdOperatorVehicleRecord.Columns["OperatorLicenceNumber"].HeaderText = "Operator Licence Number";
                grdOperatorVehicleRecord.Columns["OperatorLicenceNumber"].Width = 170;
                grdOperatorVehicleRecord.Columns["MonthCommencing"].Width = 150;
                grdOperatorVehicleRecord.Columns["OperatorName"].HeaderText = "Operator Name";
                grdOperatorVehicleRecord.Columns["VehicleRegistrationMark"].HeaderText = "VRM";
                grdOperatorVehicleRecord.Columns["PHCVehicle"].HeaderText = "Vehicle licence number";
                grdOperatorVehicleRecord.Columns["VehicleMake"].HeaderText = "Vehicle make";

                grdOperatorVehicleRecord.Columns["VehicleMake"].Width = 140;
                grdOperatorVehicleRecord.Columns["OperatorName"].Width = 140;
                grdOperatorVehicleRecord.Columns["PHCVehicle"].Width = 140;
                grdOperatorVehicleRecord.Columns["VehicleRegistrationMark"].Width = 170;

                //

              //  grdOperatorVehicleRecord.Columns["VehicleColor"].Width = 110;

             //   grdOperatorVehicleRecord.Columns["VehicleModel"].Width = 110;
              //  grdOperatorVehicleRecord.Columns["VehicleType"].Width = 110;

              //  grdOperatorVehicleRecord.Columns["VehicleType"].HeaderText = "Vehicle Type";
             //   grdOperatorVehicleRecord.Columns["VehicleModel"].HeaderText = "Vehicle Model";
              //  grdOperatorVehicleRecord.Columns["VehicleColor"].HeaderText = "Vehicle Color";
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        //private void BookingReport()
        //{
        //    try
        //    {
        //        string Message = string.Empty;
        //        DateTime? dtFrom = dtpFromDate2.Value.ToDateorNull();
        //        DateTime? dtTill = dtpToDate2.Value.ToDateorNull();
        //        int BookingStatusId = 0;
        //        int BookingTypeId = 0;
        //        int driverId = 0;
        //        string VehicleReg = string.Empty;
        //        string MobileNo = string.Empty;
        //        string MonthCommencing = string.Empty;
        //        if (dtFrom.Value == null)
        //        {
        //            Message = "Required : From Date";
        //        }
        //        if (dtTill.Value == null)
        //        {
        //            if (!string.IsNullOrEmpty(Message))
        //            {
        //                Message = "Required : To Date";
        //            }
        //            else
        //            {
        //                Message += Environment.NewLine;// "Required : To Date";
        //                Message += "Required : To Date";
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(Message))
        //        {
        //            RadMessageBox.Show(Message);
        //            return;
        //        }

        //        if (txtVehicleReg.Text != string.Empty)
        //        {
        //            VehicleReg = txtVehicleReg.Text;
        //        }

        //        if (txtMobileNo.Text != string.Empty)
        //        {
        //            MobileNo = txtMobileNo.Text;
        //        }

        //        MonthCommencing = string.Format("{0:dd/MM/yyyy}", dtFrom.Value) + "-" + string.Format("{0:dd/MM/yyyy}", dtTill.Value);
        //        if (rdoAll3.IsChecked)
        //        {
        //            BookingStatusId = 0;
        //        }
        //        if (rdoCompleted3.IsChecked)
        //        {
        //            BookingStatusId = 2;
        //        }
        //        if (rdoCancelled3.IsChecked)
        //        {
        //            BookingStatusId = 3;
        //        }

        //        if (ddlDriver.SelectedValue.ToInt() > 0)
        //        {
        //            driverId = ddlDriver.SelectedValue.ToInt();
        //        }

        //        if (ddlBookingType.SelectedValue.ToInt() > 0)
        //        {
        //            BookingTypeId = ddlBookingType.SelectedValue.ToInt();
        //        }

        //        using (TaxiDataContext db = new TaxiDataContext())
        //        {
        //            var list = db.stp_BookingReport(ddlSubCompany2.SelectedValue.ToInt(), (dtFrom3.Value.ToDate() + dtpFromTime.Value.TimeOfDay).ToDateTime(), (dtTo3.Value.ToDate() + dtpTillTime.Value.TimeOfDay).ToDateTime(), BookingStatusId, BookingTypeId, driverId, VehicleReg, MobileNo).ToList();
        //            list = list.Where(c => c.VehicleRegistration != "").ToList();
        //            var list2 = (list.AsEnumerable().OrderByDescending(item => item.PickupdateTime)).ToList();

        //            grdOperatorBookingReport.DataSource = list2;

        //            lblCount.Text = "Total Records : " + list2.Count.ToStr();
        //            //for (int i = 0; i < list2.Count; i++)
        //            //{
        //            //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.VehicleRegistrationMark].Value =" "+ list2[i].VehicleRegistrationMark+" ";
        //            //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.VehicleModel].Value = " " + list2[i].VehicleModel + " ";
        //            //    grdOperatorVehicleRecord.Rows[i].Cells[COLS.PHCVehicle].Value = " " + list2[i].PHCVehicle.ToString() + " ";
        //            //}

        //        }
        //        grdOperatorBookingReport.Columns["Id"].IsVisible = false;
        //        grdOperatorBookingReport.Columns["DriverId"].IsVisible = false;
        //        grdOperatorBookingReport.Columns["DriverNo"].IsVisible = true;
        //        grdOperatorBookingReport.Columns["VehicleMake"].IsVisible = false;
        //        grdOperatorBookingReport.Columns["OperatorLicenceNumber"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["DriverName"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["VehicleOwner"].IsVisible = false;

        //        //grdOperatorVehicleRecord.Columns["MonthCommencing"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["OperatorLicenceNumber"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["OperatorName"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["VehicleColor"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["VehicleType"].IsVisible = false;
        //        //grdOperatorVehicleRecord.Columns["VehicleModel"].IsVisible = false;

        //        grdOperatorBookingReport.Columns["BookingNo"].HeaderText = "Ref No";
        //        grdOperatorBookingReport.Columns["OperatorLicenceNumber"].HeaderText = "Operator Licence Number";
        //        grdOperatorBookingReport.Columns["PickupdateTime"].HeaderText = "Pickup Date/Time";
        //        grdOperatorBookingReport.Columns["CustomerName"].HeaderText = "Customer Name";
        //        grdOperatorBookingReport.Columns["CustomerMobileNo"].HeaderText = "Mobile No";
        //        grdOperatorBookingReport.Columns["FromAddress"].HeaderText = "Pickup";
        //        grdOperatorBookingReport.Columns["ViaString"].HeaderText = "Via";
        //        grdOperatorBookingReport.Columns["ToAddress"].HeaderText = "Destination";
        //        grdOperatorBookingReport.Columns["FareRate"].HeaderText = "Total Fare";
        //        grdOperatorBookingReport.Columns["DriverName"].HeaderText = "Driver";
        //        grdOperatorBookingReport.Columns["DriverNo"].HeaderText = "Driver No";
        //        grdOperatorBookingReport.Columns["VehicleRegistration"].HeaderText = "Vehicle Reg";
        //        grdOperatorBookingReport.Columns["PHCVehicle"].HeaderText = "PHC Vehicle";
        //        grdOperatorBookingReport.Columns["VehicleType"].HeaderText = "Vehicle";
        //        grdOperatorBookingReport.Columns["PaymentType"].HeaderText = "Payment";
        //        grdOperatorBookingReport.Columns["CompanyName"].HeaderText = "Account";
        //        grdOperatorBookingReport.Columns["PHCDriver"].HeaderText = "PHC Driver";
        //        grdOperatorBookingReport.Columns["OperatorName"].HeaderText = "Sub Company";
        //        grdOperatorBookingReport.Columns["StatusName"].HeaderText = "Status";
                
        //        grdOperatorBookingReport.Columns["OperatorLicenceNumber"].Width = 170;
        //        grdOperatorBookingReport.Columns["CustomerMobileNo"].Width = 80;
        //        grdOperatorBookingReport.Columns["BookingNo"].Width = 80;
        //        grdOperatorBookingReport.Columns["PickupdateTime"].Width = 120;
        //        grdOperatorBookingReport.Columns["CustomerName"].Width = 120;
        //        grdOperatorBookingReport.Columns["FromAddress"].Width = 190;
        //        grdOperatorBookingReport.Columns["ViaString"].Width = 150;
        //        grdOperatorBookingReport.Columns["ToAddress"].Width = 190;
        //        grdOperatorBookingReport.Columns["VehicleRegistration"].Width = 100;
        //        grdOperatorBookingReport.Columns["CompanyName"].Width = 100;
        //        grdOperatorBookingReport.Columns["PaymentType"].Width = 80;
        //        grdOperatorBookingReport.Columns["VehicleType"].Width = 80;
        //        grdOperatorBookingReport.Columns["PHCVehicle"].Width = 100;
        //        grdOperatorBookingReport.Columns["PHCDriver"].Width = 100;
        //        grdOperatorBookingReport.Columns["OperatorName"].Width = 120;
        //        grdOperatorBookingReport.Columns["StatusName"].Width = 100;
        //        grdOperatorBookingReport.Columns["DriverNo"].Width = 100;
        //        grdOperatorBookingReport.Columns["DriverName"].Width = 80;
        //        grdOperatorBookingReport.Columns["FareRate"].Width = 70;
              
        //    }
        //    catch (Exception ex)
        //    {
        //        RadMessageBox.Show(ex.Message);
        //    }
        //}


        private void mnuRunCommand_Click(object sender, EventArgs e)
        {
            //frmRunCommand frm = new frmRunCommand();
            //frm.ShowDialog();
            //frm.Dispose();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
