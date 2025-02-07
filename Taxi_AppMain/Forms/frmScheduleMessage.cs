using System;
using System.Linq;
using System.Windows.Forms;
using Utils;
using Taxi_Model;
using Telerik.WinControls.UI;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using System.Threading;

namespace Taxi_AppMain
{
    public partial class frmScheduleMessage : UI.SetupBase
    {
        public struct COLS
        {
            public static string Id = "Id";
            public static string FromDateTime = "FromDateTime";
            public static string TillDateTime = "TillDateTime";
            public static string Interval = "Interval";
            public static string ScheduleFor = "ScheduleFor";
            public static string Message = "Message";
        }

        public frmScheduleMessage()
        {
            InitializeComponent();
            FormatGrid();
            ClearForm();

           // this.ThemeName = "Desert";
            this.Load += new EventHandler(frmBookingTypes_Load);
            this.FormClosed += new FormClosedEventHandler(frmBookingTypes_FormClosed);
        }

        public void ClearForm()
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            dtpFromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0); //DateTime.Now;//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtptilltime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); //DateTime.Now;//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            rbALD.Checked = true;
            txtMessage.Text = "";
            txtID.Text = "";
           
        }

        void frmBookingTypes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        void frmBookingTypes_Load(object sender, EventArgs e)
        {
            PopulateData();
        }
        public void FormatGrid()
        {

            grdMain.AllowColumnReorder = false;
            grdMain.AllowColumnResize = false;
            grdMain.AllowRowResize = false;
            grdMain.EnableSorting = false;
            grdMain.AllowEditRow = false;

            grdMain.AllowAutoSizeColumns = true;
            grdMain.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            grdMain.ShowGroupPanel = false;


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = "Id";
            grdMain.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.FromDateTime;
            col.ReadOnly = true;
            col.Width = 130;
            col.HeaderText = "From Date Time";
            grdMain.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.TillDateTime;
            col.ReadOnly = true;
            col.Width = 130;
            col.HeaderText = "Till Date Time";
            grdMain.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.Interval;
            col.ReadOnly = true;
            col.Width = 50;
            col.HeaderText = "Interval";
            grdMain.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.ScheduleFor;
            col.ReadOnly = true;
            col.Width = 150;
            col.HeaderText = "Schedule For";
            grdMain.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.Message;
            col.ReadOnly = true;
            col.Width = 150;
            col.HeaderText = "Message";
            grdMain.Columns.Add(col);

            GridViewCommandColumn colDelete = new GridViewCommandColumn();
            colDelete.Width = 60;

            colDelete.Name = "btnDelete";
            colDelete.UseDefaultText = true;
            colDelete.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            colDelete.DefaultText = "Delete";
            colDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grdMain.Columns.Add(colDelete);
            grdMain.CommandCellClick += GrdMain_CommandCellClick;

        }

        private void GrdMain_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                string name = gridCell.ColumnInfo.Name.ToLower();

                if (name == "btndelete")
                {


                    GridViewRowInfo row = gridCell.GridControl.CurrentRow;

                    if (row is GridViewDataRowInfo)
                    {
                        int Id = row.Cells["Id"].Value.ToInt();

                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.ExecuteQuery<int>("delete from ScheduleMessages where id=" + Id);


                        }
                        row.Delete();
                        RefreshSchdule();

                    }
                }
            }
            catch
            {

            }
        }

        public override void PopulateData()
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var data1 = db.ExecuteQuery<ScheduleMessage>("SELECT Id,FromDateTime,TillDateTime,Interval,ScheduleFor,Message FROM [ScheduleMessages]").ToList();

                    grdMain.RowCount = data1.Count;
                    for (int i = 0; i < data1.Count; i++)
                    {

                        grdMain.Rows[i].Cells[COLS.Id].Value = data1[i].Id;
                        grdMain.Rows[i].Cells[COLS.FromDateTime].Value = data1[i].FromDateTime;
                        grdMain.Rows[i].Cells[COLS.TillDateTime].Value = data1[i].TillDateTime;
                        grdMain.Rows[i].Cells[COLS.Interval].Value = data1[i].Interval;
                        grdMain.Rows[i].Cells[COLS.ScheduleFor].Value = data1[i].ScheduleFor == 1 ? "All Logged In Drivers" : "All Logged In Available Drivers"; ;
                        grdMain.Rows[i].Cells[COLS.Message].Value = data1[i].Message;
                    }
                }
            }
            catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
        }

        private void grdMain_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (grdMain.CurrentRow == null) return;

            txtID.Text = grdMain.CurrentRow.Cells[COLS.Id].Value.ToString();
            int Id = txtID.Text.ToInt();
         

            dtpFromDate.Value = grdMain.CurrentRow.Cells[COLS.FromDateTime].Value.ToDateTime();
            dtpFromTime.Value = grdMain.CurrentRow.Cells[COLS.FromDateTime].Value.ToDateTime();
            dtpToDate.Value = grdMain.CurrentRow.Cells[COLS.TillDateTime].Value.ToDateTime();
            dtptilltime.Value = grdMain.CurrentRow.Cells[COLS.TillDateTime].Value.ToDateTime();

            txtInterval.Value = grdMain.CurrentRow.Cells[COLS.Interval].Value.ToInt();
            if (grdMain.CurrentRow.Cells[COLS.ScheduleFor].Value.ToString() == "All Logged In Drivers") { rbALD.Checked = true; } else { rbALAD.Checked = true; }
            txtMessage.Text = grdMain.CurrentRow.Cells[COLS.Message].Value.ToString();
        }


        private void btnSaveClose_Click(object sender, EventArgs e)

        {
            if (txtID.Text.Trim() == "")
            {
                try
                {
                    DateTime? fromDate = (dtpFromDate.Value.Value.Date + dtpFromTime.Value.Value.TimeOfDay);
                    DateTime? toDate = (dtpToDate.Value.Value.Date + dtptilltime.Value.Value.TimeOfDay);
                    int interval = txtInterval.Value.ToInt();
                    int ScheduleFor = rbALD.Checked == true ? 1 : 2;
                    string Message = txtMessage.Text;

                    string Qry = @"INSERT INTO  ScheduleMessages (FromDateTime,TillDateTime,Interval,ScheduleFor,Message)" +
                                 "VALUES('" +
                                 DateTime.Parse(fromDate.ToString()).ToString("yyyy-MM-dd HH:mm") + "','" +
                                 DateTime.Parse(toDate.ToString()).ToString("yyyy-MM-dd HH:mm") + "'," +
                                 interval + "," + ScheduleFor + ",'" + Message + "')";

                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.ExecuteQuery<string>(Qry);
                    }
                }
                catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
            }
            else
            {
                try
                {
                    DateTime? fromDate = (dtpFromDate.Value.Value.Date + dtpFromTime.Value.Value.TimeOfDay);
                    DateTime? toDate = (dtpToDate.Value.Value.Date + dtptilltime.Value.Value.TimeOfDay);
                    int interval = txtInterval.Value.ToInt();
                    int ScheduleFor = rbALD.Checked == true ? 1 : 2;
                    string Message = txtMessage.Text;

                    string Qry = @"UPDATE ScheduleMessages SET 
                                    FromDateTime='" + DateTime.Parse(fromDate.ToString()).ToString("yyyy-MM-dd HH:mm") + "'," +
                                    "TillDateTime='" + DateTime.Parse(toDate.ToString()).ToString("yyyy-MM-dd HH:mm") + "'," +
                                    "Interval=" + interval + "," +
                                    "ScheduleFor=" + ScheduleFor + "," +
                                    "Message ='" + Message + "' WHERE Id =" + txtID.Text;

                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.ExecuteQuery<string>(Qry);
                    }
                }
                catch (Exception ex) { ENUtils.ShowMessage(ex.Message); }
            }


            ClearForm();
            PopulateData();
            RefreshSchdule();
        }


        private void RefreshSchdule()
        {
           

           

            try
            {
                frmMainMenu ObjfrmMainMenu = ((frmMainMenu)(Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmMainMenu")));
                HubConnection Connection = ObjfrmMainMenu.Connection;
                IHubProxy HubProxy = ObjfrmMainMenu.HubProxy;

                if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    Connection.Start();

                    Thread.Sleep(5000);
                }
                else if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting
                            || Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting)
                {
                    Thread.Sleep(5000);
                    
                }
                HubProxy.Invoke("RefreshScheduledMessage", "restart");
               
            }
            catch (Exception ex)
            {
                        
            }
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
