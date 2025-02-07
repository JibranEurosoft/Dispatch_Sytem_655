using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Collections;
using Telerik.WinControls.UI;
using System.Linq;
using Utils;
using Telerik.WinControls.Enumerations;
using UI;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.IO;
using System.Net;


namespace Taxi_AppMain
{
    public partial class frmFlightTracking : Telerik.WinControls.UI.RadForm
    {

        private bool _IsAutoSizeRows;

        public bool IsAutoSizeRows
        {
            get { return _IsAutoSizeRows; }
            set { _IsAutoSizeRows = value; }
        }

        private object[] _RowData;

        public object[] RowData
        {
            get { return _RowData; }
            set { _RowData = value; }
        }


        private string[] _HiddenColumns;

        public string[] HiddenColumns
        {
            get { return _HiddenColumns; }
            set { _HiddenColumns = value; }
        }

        private List<object[]> _listofData;

        public List<object[]> ListofData
        {
            get { return _listofData; }
            set { _listofData = value; }
        }

        private string _pkField;

        public string PkField
        {
            get { return _pkField; }
            set { _pkField = value; }
        }


        private object _pkValue;

        public object PkValue
        {
            get { return _pkValue; }
            set { _pkValue = value; }
        }


    

        static string FlightNum = string.Empty;

        private const string COLCheckBox = "COL_ChECKBOX";

        public static void setTextboxText(string result)
        {
            FlightNum = result;
        }


        DateTime? FlightDate = null;
       

        public frmFlightTracking(string FlightNo,DateTime? flightDate)
        {
            InitializeComponent();
            this.ListofData = new List<object[]>();
            FlightNum = FlightNo;
            this.FlightDate = flightDate;
            FormateGrid();
          
        }

        public struct COL_FLIGHTS
        {
            public static string CHECK = "CHECK";
            public static string FLIGHTNO = "FLIGHTNO";
            public static string ARRIVINGFROM = "ARRIVINGFROM";
            public static string SCHEDULEDATETIME = "SCHEDULEDATETIME";
            public static string ARRIVALDATETIME = "ARRIVALDATETIME";
            public static string TERMINAL = "TERMINAL";
            public static string STATUS = "STATUS";
        }

       public  FlightData data = null;

    

        private void FormateGrid()
        {
            try
            {

                grdLister.ReadOnly = false;
                grdLister.AllowEditRow = true;
                //grdZones.AllowAutoSizeColumns = true;
                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdLister.ShowRowHeaderColumn = false;
                grdLister.AllowAddNewRow = false;
                grdLister.ShowGroupPanel = false;
                grdLister.AllowColumnReorder = false;


                GridViewCheckBoxColumn cbcol = new GridViewCheckBoxColumn();

                cbcol.IsVisible = false;
                cbcol.VisibleInColumnChooser = false;

              
                cbcol.Name = COL_FLIGHTS.CHECK;
                cbcol.HeaderText = "";
                cbcol.Width = 20;
                cbcol.ReadOnly = false;
                grdLister.Columns.Add(cbcol);


                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.FLIGHTNO;
                col.HeaderText = "Flight No";
                col.ReadOnly = true;
                col.Width = 40;
                grdLister.Columns.Add(col);


                 col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.SCHEDULEDATETIME;
                col.HeaderText = "Scheduled On";
                col.ReadOnly = true;
                col.Width = 95;
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.ARRIVALDATETIME;
                col.HeaderText = "Arrival";
                col.ReadOnly = true;
                col.Width = 95;
                grdLister.Columns.Add(col);

              
                col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.ARRIVINGFROM;
                col.HeaderText = "Arriving From";
                col.ReadOnly = true;
                col.Width = 70;
                grdLister.Columns.Add(col);
                          

                col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.TERMINAL;
                col.HeaderText = "Terminal";
                col.ReadOnly = true;
                col.Width = 40;
                grdLister.Columns.Add(col);

 
                col = new GridViewTextBoxColumn();
                col.Name = COL_FLIGHTS.STATUS;
                col.HeaderText = "Status";
                col.ReadOnly = true;
                col.Width = 40;
                grdLister.Columns.Add(col);



                col = new GridViewTextBoxColumn();
                col.Name = "Details";
                col.HeaderText = "Details";
                col.ReadOnly = true;
                col.IsVisible = false;
                col.Width = 40;
                grdLister.Columns.Add(col);



                DateTime? dt = null;

              
                if(this.FlightDate==null)
                {
                    if (this.FlightDate.ToDate() == DateTime.Now.ToDate())
                        this.FlightDate = DateTime.Now.ToDate();

                }

                var json = "";


                FlightData fdata = new FlightData();
              
                fdata.FlightNo = FlightNum;
                fdata.InputDateTime = string.Format("{0:dd/MM/yyyy}", this.FlightDate);

               json= JsonConvert.SerializeObject(fdata);


                string API = "http://116.202.117.250/WindsorCars/api/supplier/requestflightdetails" + "?mesg="+ json;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json";
                request.Method = WebRequestMethods.Http.Get;
                request.Proxy = null;

                WebResponse responsea = request.GetResponse();
               
                StreamReader sr = new StreamReader(responsea.GetResponseStream());
                json = sr.ReadToEnd();

                 data = null;
                if (json.Contains("{"))
                {




                    try
                    {


                        data = JsonConvert.DeserializeObject<FlightData>(json);
                    }
                    catch
                    {

                    }

                    if (data.ScheduleDateTime.Year < 2000)
                    {
                        MessageBox.Show("Flight details not found");
                        data = null;
                    }
                    else
                    {



                        try
                        {
                            File.AppendAllText(Application.StartupPath + "\\Logs\\FlightTracker\\" + FlightNum + ".txt", json);
                        }
                        catch
                        {


                        }
                        var row = grdLister.Rows.AddNew();
                  
                        row.Cells[COL_FLIGHTS.TERMINAL].Value = data.ArrivalTerminal.ToStr();
                        row.Cells[COL_FLIGHTS.FLIGHTNO].Value = FlightNum.ToUpper();
                        row.Cells[COL_FLIGHTS.SCHEDULEDATETIME].Value = data.ScheduleDateTime;
                        if (data.DelayedDateTime.Year >= 2020)
                            row.Cells[COL_FLIGHTS.ARRIVALDATETIME].Value = data.DelayedDateTime;

                        row.Cells[COL_FLIGHTS.ARRIVINGFROM].Value = data.ArrivingFrom.ToStr();
                        row.Cells[COL_FLIGHTS.STATUS].Value = data.Status.ToStr();

                        row.Cells["Details"].Value = data.FlightInformation.ToStr();

                    }
                }

                //UI.GridFunctions.SetFilter(grdZones);
            }
            catch (Exception ex)
            {

      
            }

        }

        public DataSet Tabulate(string json)
        {
            var jsonLinq = JObject.Parse(json);

            // Find the first array using Linq
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

          
            return JsonConvert.DeserializeObject<DataSet>(trgArray.ToString());
        }

        private void CreateCheckBoxColumn()
        {
            GridViewCheckBoxColumn col = new GridViewCheckBoxColumn();
            col.Width = 30;
            col.Name = "COLCheckBox";
            col.FieldName = "COLCheckBox";
            grdLister.Columns.Add(col);

        }


  


        private void HideColumns()
        {
            if (HiddenColumns == null) return;

            foreach (string col in this.HiddenColumns)
            {
                grdLister.Columns[col].IsVisible = false;

            }


        }



        private string[] _BestFitColumns;

        public string[] BestFitColumns
        {
            get { return _BestFitColumns; }
            set { _BestFitColumns = value; }
        }


        private void SetBestFitColumns()
        {
            if (BestFitColumns == null) return;

            foreach (string col in this.BestFitColumns)
            {
                grdLister.Columns[col].BestFit();

            }
        }




       

        private void grdLister_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                PickRecords();

            }
            catch
            {

            }

        }

        private void frmLister_Load(object sender, EventArgs e)
        {

            this.grdLister.AutoSizeRows = this.IsAutoSizeRows;

            this.grdLister.ShowGroupPanel = false;
            this.grdLister.AllowAutoSizeColumns = true;
            this.grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            HideColumns();
            this.grdLister.MasterTemplate.ShowRowHeaderColumn = false;

            SetBestFitColumns();


            this.KeyDown += FrmFlightTracking_KeyDown;
        }

        private void FrmFlightTracking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if(e.KeyCode== Keys.Enter)
                PickRecords();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {



            PickRecords();

        }

        private void PickRecords()
        {

            ListofData.Clear();
            object[] obj;
            if (grdLister.Rows.Count == 1)
            {
               
                    obj = new object[6];

                    obj[0] = grdLister.Rows[0].Cells[1].Value;
                    obj[1] = grdLister.Rows[0].Cells[2].Value;
                    obj[2] = grdLister.Rows[0].Cells[3].Value;
                    obj[3] = grdLister.Rows[0].Cells[4].Value;
                    obj[4] = grdLister.Rows[0].Cells[5].Value;
                obj[5] = grdLister.Rows[0].Cells[7].Value;


                ListofData.Add(obj);


                  

                
            }
            else
            {
                foreach (GridViewRowInfo row in grdLister.Rows.Where(c => c.Cells[0].Value.ToBool()))
                {
                    obj = new object[grdLister.Columns.Count - 1];

                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        obj[i - 1] = row.Cells[i].Value;
                    }

                    ListofData.Add(obj);

                }
            }
            

            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);

        private void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                //    e.CellElement
                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;


                // e.CellElement.DrawBorder = false;
                e.CellElement.BackColor = Color.SteelBlue;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.Font = newFont;
                e.CellElement.ForeColor = Color.White;
                e.CellElement.DrawFill = true;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

            }

            if (e.CellElement.ColumnInfo.Name == COL_FLIGHTS.SCHEDULEDATETIME || e.CellElement.ColumnInfo.Name == COL_FLIGHTS.ARRIVALDATETIME)
            {
                e.CellElement.Font = newFont;
            }

            
        

        }

        

       



        

       
    }
}
