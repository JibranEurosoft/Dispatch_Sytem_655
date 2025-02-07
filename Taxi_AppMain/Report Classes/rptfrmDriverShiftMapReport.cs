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
using GMap.NET;
using Taxi_AppMain.Classes;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Taxi_AppMain
{
    public partial class rptfrmDriverShiftMapReport : UI.SetupBase
    {


        BookingBO objMaster;
        public rptfrmDriverShiftMapReport()
        {
            InitializeComponent();


            grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            grdLister.CommandCellClick += GrdLister_CommandCellClick;
            grdLister.EnableAlternatingRowColor = true;
            grdLister.TableElement.AlternatingRowColor = Color.AliceBlue;

            this.FormClosing += RptfrmJobsList_FormClosing;
            objMaster = new BookingBO();
            if (ddlAllDriver.DataSource == null)
            {
                //ComboFunctions.FillDriverCombo(ddlAllDriver);
                ComboFunctions.FillDriverNoCombo(ddlAllDriver);
            }
            ddlAllDriver.Enabled = true;
        }

        private void GrdLister_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;

           
            if (gridCell.ColumnInfo.Name.ToString() == "btnViewMap")
            {
                try
                {
                    int Id = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
                    string driverno = ddlAllDriver.SelectedValue.ToString();
                    // grdLister.CurrentRow.Cells["DriverNo"].Value.ToStr();
                    driverno = driverno.TrimStart('0');



                    DateTime? fromDate = Convert.ToDateTime(grdLister.CurrentRow.Cells["ShiftStart"].Value);
                    DateTime? tillDate = null;

                    if(grdLister.CurrentRow.Cells["ShiftEnd"].Value.ToStr().Trim().Length==0)
                    {
                        tillDate = DateTime.Now;
                    }
                    else
                    {
                        tillDate = Convert.ToDateTime(grdLister.CurrentRow.Cells["ShiftEnd"].Value);

                    }

                    //recent code
                    string datefrom = grdLister.CurrentRow.Cells["ShiftStart"].Value.ToStr();
                    string[] datepartfrom = datefrom.Split(' ');
                    string dateto = tillDate.ToStr();
                    string[] datepartto = dateto.Split(' ');
                    //end recent code

                    string[] paramfrom = datefrom.Split('/');
                    string[] paramto = dateto.Split('/');

                    string dayfrom = paramfrom[0].ToStr();
                    string monthfrom = paramfrom[1].ToStr();
                    string[] yearparam = paramfrom[2].Split(' ');
                    string year = yearparam[0].ToStr();


                    string dayto = paramto[0].ToStr();
                    string monthto = paramto[1].ToStr();


                    monthfrom = monthfrom.TrimStart('0');
                    monthto = monthto.TrimStart('0');


                    dayfrom = dayfrom.TrimStart('0');
                    dayto = dayto.TrimStart('0');
                    string timefrom1 = (dtpFromDate.Value.Value.TimeOfDay).ToString();

                    string filepathfrom = "C:\\Projects\\AlphaCarsLtd\\Logs\\" + year + "\\" + monthfrom + "\\" + dayfrom + "\\" + driverno + ".txt";
                    string filepathTo = "C:\\Projects\\AlphaCarsLtd\\Logs\\" + year + "\\" + monthto + "\\" + dayto + "\\" + driverno + ".txt";

                    string patternfrom = datefrom.ToStr();
                    string patternto = dateto.ToStr(); 
                    string startdate = datepartfrom[0].ToStr();
                    string enddate = datepartto[0].ToStr();
                 
                    LatLngDateFrmAndTo listlatlng = new LatLngDateFrmAndTo();
                    LatLngDateFrmAndTo objc = new LatLngDateFrmAndTo();
                    List<PointLatLng> latlngpoint = new List<PointLatLng>();
                    List<CoordinatesWithUpdatedDate> lstdateandpoints = new List<CoordinatesWithUpdatedDate>();
                    List<PointLatLng> obj = new List<PointLatLng>();

                    if (startdate.Equals(enddate))
                    {
                        //if (File.Exists(@filepathfrom))
                        //{
                            var lines = General.GetDriverTrackingHistory(filepathfrom.Replace("\\","\\\\"));
                           // var lines = File.ReadAllText(@filepathfrom);
                            //   var allLines = File.ReadAllLines(@filepathfrom);

                            //    var alllines = General.GetDriverTrackingHistory(filepathfrom);

                      
                        string resX = string.Empty;
                            foreach (string result in lines.Split(new string[] { "\\r\\n" },StringSplitOptions.RemoveEmptyEntries  ))
                            {

                            resX = string.Empty;

                            if (result.StartsWith("\""))
                            {
                                resX = result.Substring(1).Trim();
                            }
                            else
                                resX = result;


                            if (resX.ToStr().Trim().Length == 0)
                                continue;

                            PointLatLng coordinates = new PointLatLng();
                                DateTime dtobj = new DateTime();
                                CoordinatesWithUpdatedDate cltln = new CoordinatesWithUpdatedDate();
                                LatLngDateFrmAndTo objnew = new LatLngDateFrmAndTo();


                            try
                            {
                                DateTime dt = resX.Split('|')[0].Replace("\\", "").ToDateTime();

                                if (dt >= fromDate && dt <= tillDate)
                                {

                                    string[] readline = resX.Split(',');
                                    string[] res = readline[0].Split('|');
                                    string[] res1 = readline[1].Split('|');


                                    DateTime dtm = readline[0].Split('|')[0].ToDateTime();

                                    int? driverid = readline[0].Split('|')[1].ToInt();

                                    double? lat = Convert.ToDouble(readline[0].Split('|')[3]);
                                    double? lng = Convert.ToDouble(readline[1].Split('|')[0]);

                                    string speedtext = res1[1].ToStr();
                                    decimal dData = 0;
                                    decimal speed = 0;
                                    if (speedtext.Contains("E") || speedtext.Contains("e"))
                                    {
                                        speedtext = speedtext.Substring(0, speedtext.Length - 1).Trim();
                                        dData = Convert.ToDecimal(Decimal.Parse(speedtext.ToString(), System.Globalization.NumberStyles.Float));
                                        speed = Math.Round(dData, 2);
                                    }
                                    else
                                    {
                                        dData = Convert.ToDecimal(speedtext);
                                        speed = Math.Round(dData, 0);
                                    }


                                    string zoneid = res1[2].ToStr();
                                    string bookingid = res[2] + ",";

                                    coordinates.Lat = (double)lat;
                                    coordinates.Lng = (double)lng;
                                    dtobj = dtm;
                                    cltln.Lat = (double)lat;
                                    cltln.Lng = (double)lng;
                                    cltln.UpdateDate = dtm;
                                    cltln.Speed = speed;
                                    cltln.ZoneId = zoneid;
                                    cltln.driverid = driverid;
                                    cltln.JobId = Convert.ToInt64(res[2].ToStr());
                                    listlatlng.BookId.Append(bookingid);
                                    listlatlng.ListOfUpdatedDate.Add(dtobj);
                                    listlatlng.latlnglist.Add(coordinates);


                                    lstdateandpoints.Add(cltln);

                                }
                            }
                            catch(Exception ex)
                            {

                            }


                            }


                        //}

                        //else
                        //{
                        //    ENUtils.ShowMessage("Record not found!");
                        //    return;

                        //}


                    }
                    else
                    {
                        
                            //  var lines = General.GetDriverTrackingHistory(@filepathfrom);
                            var lines = General.GetDriverTrackingHistory(filepathfrom.Replace("\\", "\\\\"));
                            string resX = string.Empty;

                            foreach (string result in lines.Split(new string[] { "\\r\\n" }, StringSplitOptions.RemoveEmptyEntries))
                            {



                                resX = string.Empty;

                                if (result.StartsWith("\""))
                                {
                                    resX = result.Substring(1).Trim();
                                }
                                else
                                    resX = result;


                                if (resX.ToStr().Trim().Length == 0)
                                    continue;


                                PointLatLng coordinates = new PointLatLng();
                                DateTime dtobj = new DateTime();
                                CoordinatesWithUpdatedDate cltln = new CoordinatesWithUpdatedDate();
                                DateTime dt = resX.Split('|')[0].ToDateTime();
                                
                             
                                if (dt >= fromDate && dt <= tillDate)
                                {

                                    string[] readline = resX.Split(',');
                                    string[] res = readline[0].Split('|');
                                    string[] res1 = readline[1].Split('|');

                                    DateTime dtm = readline[0].Split('|')[0].ToDateTime();

                                    int? driverid = readline[0].Split('|')[1].ToInt();

                                    double? lat = Convert.ToDouble(readline[0].Split('|')[3]);
                                    double? lng = Convert.ToDouble(readline[1].Split('|')[0]);
                                    
                                    string speedtext = res1[1].ToStr();
                                    decimal dData = 0;
                                    decimal speed = 0;


                                    if (speedtext.Contains("E") || speedtext.Contains("e"))
                                    {
                                        speedtext = speedtext.Substring(0, speedtext.Length - 1).Trim();
                                        dData = Convert.ToDecimal(Decimal.Parse(speedtext.ToString(), System.Globalization.NumberStyles.Float));
                                        speed = Math.Round(dData, 0);
                                    }
                                    else
                                    {
                                        dData = Convert.ToDecimal(speedtext);
                                        speed = Math.Round(dData, 2);
                                    }

                                    string zoneid = res1[2].ToStr();
                                    string bookingid = res[2] + ",";
                                    coordinates.Lat = (double)lat;
                                    coordinates.Lng = (double)lng;
                                    dtobj = dtm;
                                    cltln.Lat = (double)lat;
                                    cltln.Lng = (double)lng;
                                    cltln.UpdateDate = dtm;
                                    cltln.Speed = speed;
                                    cltln.ZoneId = zoneid;
                                    cltln.driverid = driverid;
                                    cltln.JobId = Convert.ToInt64(res[2].ToStr());
                                    listlatlng.BookId.Append(bookingid);
                                    listlatlng.ListOfUpdatedDate.Add(dtobj);
                                    listlatlng.latlnglist.Add(coordinates);


                                    lstdateandpoints.Add(cltln);





                                }


                            }

                            //if (File.Exists(@filepathTo))
                            //{
                                //  var allLinespathTo1 = File.ReadAllLines(@filepathTo);
                                //   var lines2 = File.ReadAllText(filepathTo);
                           
                                var lines2 = General.GetDriverTrackingHistory(filepathTo.Replace("\\", "\\\\"));
                                 resX = string.Empty;


                                foreach (var result in lines2.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                                {

                                    resX = string.Empty;

                                    if (result.StartsWith("\""))
                                    {
                                        resX = result.Substring(1).Trim();
                                    }
                                    else
                                        resX = result;


                                    if (resX.ToStr().Trim().Length == 0)
                                        continue;

                                    PointLatLng coordinates = new PointLatLng();
                                    DateTime dtobj = new DateTime();
                                    CoordinatesWithUpdatedDate cltln = new CoordinatesWithUpdatedDate();
                                    DateTime dt = resX.Split('|')[0].ToDateTime();

                                    if (dt >= fromDate && dt <= tillDate)
                                    {

                                        string[] readline = resX.Split(',');
                                        string[] res = readline[0].Split('|');
                                        string[] res1 = readline[1].Split('|');

                                        DateTime dtm = readline[0].Split('|')[0].ToDateTime();

                                        int? driverid = readline[0].Split('|')[1].ToInt();

                                        double? lat = Convert.ToDouble(readline[0].Split('|')[3]);
                                        double? lng = Convert.ToDouble(readline[1].Split('|')[0]);
                                       string speedtext = res1[1].ToStr();
                                        decimal dData = 0;
                                        decimal speed = 0;
                                        if (speedtext.Contains("E") || speedtext.Contains("e"))
                                        {
                                            speedtext = speedtext.Substring(0, speedtext.Length - 1).Trim();
                                            dData = Convert.ToDecimal(Decimal.Parse(speedtext.ToString(), System.Globalization.NumberStyles.Float));
                                            speed = Math.Round(dData, 0);
                                        }
                                        else
                                        {
                                            dData = Convert.ToDecimal(speedtext);
                                            speed = Math.Round(dData, 2);
                                        }

                                        string zoneid = res1[2].ToStr();
                                        string bookingid = res[2] + ",";
                                        coordinates.Lat = (double)lat;
                                        coordinates.Lng = (double)lng;
                                        dtobj = dtm;
                                        cltln.Lat = (double)lat;
                                        cltln.Lng = (double)lng;
                                        cltln.UpdateDate = dtm;
                                        cltln.Speed = speed;
                                        cltln.ZoneId = zoneid;
                                        cltln.driverid = driverid;
                                        cltln.JobId = Convert.ToInt64(res[2].ToStr());
                                        listlatlng.BookId.Append(bookingid);
                                        listlatlng.ListOfUpdatedDate.Add(dtobj);
                                        listlatlng.latlnglist.Add(coordinates);


                                        lstdateandpoints.Add(cltln);



                                    }

                                }
                            //}


                            
                        

                    }


                    
                    



                    if (listlatlng.latlnglist.Count>0)
                    {
                        MapReport(listlatlng, lstdateandpoints);

                    }
                    else
                    {
                       
                        ENUtils.ShowMessage("Map Route Details not found!");
                        return;

                    }



                }
                catch (Exception ex)
                {
                    ENUtils.ShowMessage(ex.Message);
                }


            }
        }




        
        private void MapReport(LatLngDateFrmAndTo listlatlng,List<CoordinatesWithUpdatedDate> lst)
        {
            try
            {
                                    
                        frmrptJobRouthPathGoogle rptRoute = new frmrptJobRouthPathGoogle(listlatlng,lst);
                        rptRoute.StartPosition = FormStartPosition.CenterScreen;
                        rptRoute.ShowDialog();
                        //rptRoute.Dispose();
                    
                
            }
            catch (Exception ex)
            {

            }

        }
        private void RptfrmJobsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
            GC.Collect();
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


        private bool ApplyDrvFareReduction;

        private void rptfrmJobsList_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);



          
            dtpToDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);


     
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "ID";
            col.Name = "Id";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "DriverNo";
            col.Name = COLS.DriverNo;
            col.Width = 40;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverName;
            col.ReadOnly = true;
            col.Width = 70;
            col.HeaderText = "Name";
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "VehicleNo";
            col.Name = COLS.VehicleNo;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = true;
            col.HeaderText = "Shift Start";
            col.Name = COLS.ShiftStart;
            grdLister.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            // col.IsVisible = false;
            col.ReadOnly = true;
            col.HeaderText = "Shift End";
            col.Name = COLS.ShiftEnd;
            grdLister.Columns.Add(col);

            AddColumn(grdLister);

            grdLister.EnableFiltering = true;
            grdLister.ShowFilteringRow = true;


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


        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Print();
        }


        //private List<stp_GetBookingBaseResult> GetDataSourceBySP(int reportType, int companyId, DateTime? fromDate, DateTime? toDate, int DriverId, int PaymentTypeId, string BookedBy, int CompanyGroupId, long FleetMasterId)
        //{



        //    if (fromDate != null && dtpFromTime.Value != null && dtpFromTime.Value.Value != null)
        //        fromDate = (fromDate.Value.ToDate() + dtpFromTime.Value.Value.TimeOfDay).ToDateTime();



        //    if (toDate != null && dtptilltime.Value != null && dtptilltime.Value.Value != null)
        //        toDate = (toDate.Value.ToDate() + dtptilltime.Value.Value.TimeOfDay).ToDateTime();


        //    bool fullfromdateCriteria = false;

        //    bool fulltodateCriteria = false;


        //    if (fromDate.Value.TimeOfDay != TimeSpan.Zero)
        //        fullfromdateCriteria = true;


        //    if (toDate.Value.TimeOfDay != TimeSpan.Zero)
        //        fulltodateCriteria = true;


        //    string PaymentTypes = string.Empty;


        //    PaymentType = string.Join(",", (from a in listofPaymentTypes

        //                                    select a.Value).ToArray<int>());


        //    //var drivers = string.Join(",", from item in listofPaymentTypes select  item).ToArray<string>());
        //   // PaymentType =String.Join(',', (listofPaymentTypes)).ToArray<string>();


        //   using (TaxiDataContext db = new TaxiDataContext())
        //  {

        //  var list = db.stp_GetDriversLoginLogoutDetails](fromDate, toDate, companyId, DriverId, PaymentTypeId, PaymentType, GetBookingStatus(), BookedBy, transferredSubCompanyId, FleetMasterId, subCompanyId, orderNo).ToList(); ;

        //        //if (optSortAsc.Checked)
        //        //{
        //        //    list = list.OrderBy(c => c.PickupDateTime)
        //        //                     .ToList();
        //        //}
        //        //else
        //        //{
        //        //    list=list.OrderByDescending(c => c.PickupDateTime)
        //        //                  .ToList();
        //        //}


        //            return list;
        // }


        //}

        private void AddColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();
            col.Width = 50;

            col.Name = "btnViewMap";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "View Map";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }


        public override void Print()
        {
            try
            {

                DateTime? fromDate = dtpFromDate.Value.ToDateTimeorNull();
                DateTime? toDate = dtpToDate.Value.ToDateTimeorNull();

                // TimeSpan tillTime = TimeSpan.Zero;

                // TimeSpan.TryParse("23:59:59", out toDate);

                int driverId = ddlAllDriver.SelectedValue.ToInt();


                //rptfrmJobListViewer frm = new rptfrmJobListViewer();

                //frm.ReportHeading = "Date Range : " + string.Format("{0:dd/MM/yyyy}", fromDate) + " to " + string.Format("{0:dd/MM/yyyy}", toDate);
                //                frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                List<ClsDriverShitMap> list = new TaxiDataContext().ExecuteQuery<ClsDriverShitMap>("exec stp_GetDriversLoginLogoutDetails {0},{1},{2},{3}", driverId, fromDate, toDate, 0).ToList();



                grdLister.RowCount = list.Count;

                
                for (int i = 0; i < list.Count; i++)
                {

                    grdLister.Rows[i].Cells[COLS.ID].Value = list[i].LoginID;
                    //  row.Cells[COLS.BookingDate].Value = list[i].BookingDate.ToDateTime().ToStr();
                    grdLister.Rows[i].Cells[COLS.DriverNo].Value = list[i].DriverNo;

                    grdLister.Rows[i].Cells[COLS.DriverName].Value = list[i].DriverName.ToStr();
                    grdLister.Rows[i].Cells[COLS.VehicleNo].Value = list[i].VehicleNo.ToStr();

                    grdLister.Rows[i].Cells[COLS.ShiftStart].Value = list[i].LoginDateTime.ToStr();
                    grdLister.Rows[i].Cells[COLS.ShiftEnd].Value = list[i].LogoutDateTime.ToStr();


                }


                grdLister.MasterTemplate.EndUpdate();

                //frm.DataSourceBySP = GetDataSourceBySP(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());
                //frm.TemplateValue = templateNo + "_rptJobsList.rdlc";
                //frm.GenerateReport();

                DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("rptfrmJobListViewer1");


            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }

        }


        private void btnViewReport_Click_1(object sender, EventArgs e)
        {
            Print();

        }

        public struct COLSP
        {
            public static string Id = "Id";
            public static string PaymentType = "PaymentType";
            public static string Check = "Check";
        }


        public struct COLS
        {



            public static string ID = "ID";
            public static string DriverNo = "DriverNo";

            public static string DriverName = "DriverName";
            public static string VehicleNo = "VehicleNo";
            public static string ShiftStart = "ShiftStart";

            public static string ShiftEnd = "ShiftEnd";

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



        private void ViewReport()
        {

            //try
            //{
            //    string BookedBy = ddlBookedBy.Text.Trim();
            //    //var listold = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), dtpFromDate.Value.ToDateorNull(), dtpToDate.Value.ToDateorNull(), ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), BookedBy, ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());


            //    var list = GetDataSourceBySP(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), dtpFromDate.Value.ToDateorNull(), dtpToDate.Value.ToDateorNull(), ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), BookedBy, ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());


            //    lblTotalJobs.Text = "Total Job(s) : " + list.Count.ToStr();


            //    // grdLister.DataSource = list;
            //    grdLister.RowCount = list.Count;


            //    grdLister.MasterTemplate.BeginUpdate();

            //    GridViewRowInfo row = null;
            //    for (int i = 0; i < list.Count; i++)
            //    {

            //        row = grdLister.Rows[i];

            //        row.Cells[COLS.ID].Value = list[i].Id;
            //        //  row.Cells[COLS.BookingDate].Value = list[i].BookingDate.ToDateTime().ToStr();
            //        row.Cells[COLS.PickupDate].Value = list[i].PickupDateTime;


            //        row.Cells[COLS.RefNumber].Value = list[i].BookingNo.ToStr();
            //        row.Cells[COLS.Passenger].Value = list[i].CustomerName.ToStr();

            //        row.Cells[COLS.Vehicle].Value = list[i].VehicleTypeId.ToStr();
            //        row.Cells[COLS.Account].Value = list[i].CompanyId;
            //        row.Cells[COLS.PaymentType].Value = list[i].PaymentTypeId;
            //        row.Cells[COLS.OldPaymentType].Value = list[i].PaymentTypeId;

            //        row.Cells[COLS.PickupPoint].Value = list[i].FromAddress.ToStr();
            //        row.Cells[COLS.OldPickupPoint].Value = list[i].FromAddress.ToStr();



            //        row.Cells[COLS.Via].Value = list[i].Via1.ToStr();



            //        row.Cells[COLS.Notes].Value = list[i].NotesString.ToStr();
            //        row.Cells[COLS.PaymentRef].Value = list[i].PaymentComments.ToStr();
            //        row.Cells[COLS.Journey].Value = list[i].JourneyType.ToStr();

            //        row.Cells[COLS.Destination].Value = list[i].ToAddress.ToStr();
            //        row.Cells[COLS.OldDestination].Value = list[i].ToAddress.ToStr();



            //        row.Cells[COLS.Fare].Value = list[i].FareRate.ToDecimal();
            //        row.Cells[COLS.DrvParking].Value = list[i].CongtionCharges.ToDecimal();
            //        row.Cells[COLS.DrvWaiting].Value = list[i].MeetAndGreetCharges.ToDecimal();
            //        row.Cells[COLS.Extra].Value = list[i].ExtraDropCharges.ToDecimal();
            //        row.Cells[COLS.AccFare].Value = list[i].CompanyPrice.ToDecimal();
            //        row.Cells[COLS.AccParking].Value = list[i].ParkingCharges.ToDecimal();
            //        row.Cells[COLS.AccWaiting].Value = list[i].WaitingCharges.ToDecimal();

            //        row.Cells[COLS.AgentComm].Value = list[i].AgentCommission.ToDecimal();
            //        row.Cells[COLS.CustFare].Value = list[i].CustomerPrice.ToDecimal();


            //        row.Cells[COLS.Driver].Value = list[i].DriverNo.ToStr();
            //        row.Cells[COLS.Status].Value = list[i].StatusName.ToStr();
            //        row.Cells[COLS.BookedBy].Value = list[i].BookedBy.ToStr();

            //        row.Cells[COLS.InvoiceNo].Value = list[i].InvoiceNo.ToStr();

            //        row.Cells[COLS.SpecialReq].Value = list[i].SpecialRequirements.ToStr();


            //        row.Cells[COLS.IsProcessed].Value = list[i].CostCenterId;


            //        row.Cells["Mileage"].Value = list[i].TotalTravelledMiles;

            //    }


            //    grdLister.MasterTemplate.EndUpdate();



            //    lblTotalJobs.Text = "Total Jobs : " + grdLister.Rows.Count.ToStr();

            //    UpdateTotalEarning();

            //}
            //catch
            //{
            //    lblTotalEarning.Visible = false;

            //}
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
                //frm.DataSourceBySP = GetDataSourceBySP( ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlTransferredSubCompanyId.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                //frm.TemplateValue = templateNo + "_rptJobsList.rdlc";
                //frm.GenerateReport();

                //frm.ExportReport();
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
            General.ShowBookingForm(id, true, "", "", Enums.BOOKING_TYPES.LOCAL);


            //frmBooking frm = new frmBooking();
            //frm.OnDisplayRecord(id);
            //frm.ControlBox = true;
            //frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            //frm.MaximizeBox = false;
            //frm.ShowDialog();

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

                //frm.DataSource = GetDataSource(GetReportType(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                //frm.DataSourceBySP = GetDataSourceBySP(GetBookingStatus(), ddlCompany.SelectedValue.ToInt(), fromDate, toDate, ddlAllDriver.SelectedValue.ToInt(), ddlPaymentType.SelectedValue.ToInt(), ddlBookedBy.Text.Trim(), ddlCompanyGroup.SelectedValue.ToInt(), ddlCompanyVehicle.SelectedValue.ToLong());

                //frm.GenerateReport();

                //frm.ExportReportToExcel();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void ddlCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

    }

    public class ClsDriverShitMap
    {
        public long LoginID;
        public int? DriverId;
        public string DriverNo;
        public string DriverName;
        public int? DriverTypeId;
        //public int? FleetMasterId;
        public int VehicleTypeId;

        public string VehicleNo;
        public string VehicleType;
        public DateTime? LoginDateTime;
        public DateTime? LogoutDateTime;
        public int? JobsDone;
        public decimal? Earned;
        public bool? HasPDA;
    }

}


