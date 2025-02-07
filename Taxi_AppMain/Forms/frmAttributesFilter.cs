using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using Utils;
using Taxi_Model;
using DAL;
using UI;
using System.Net;
using System.Xml.Linq;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Taxi_AppMain
{
    public partial class frmAttributesFilter : UI.SetupBase
    {
        List<DriverList> drvList = new List<DriverList>();
        public frmAttributesFilter()
        {
            InitializeComponent();
            FillCombo();
            FormatGrid();
            this.Load += new EventHandler(frmDriverAttributes_Load);
            this.ddlAttributes.SelectedValueChanged += new EventHandler(ddlAttributes_SelectedValueChanged);
            this.KeyDown += new KeyEventHandler(frmDriverAttributes_KeyDown);
            this.optAvailableDrivers.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(optAvailableDrivers_ToggleStateChanged);
            this.optLoginDrivers.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(optLoginDrivers_ToggleStateChanged);
            this.optAllDrivers.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(optAllDrivers_ToggleStateChanged);
        }

        void optAllDrivers_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                FilterDriver();
            }
        }

        void optLoginDrivers_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                FilterDriver();
            }
        }

        void optAvailableDrivers_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                FilterDriver();
            }
        }

        void frmDriverAttributes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void ddlAttributes_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterDriver();   
        }

        private void FilterDriver()
        {
            try
            {
                string Attributes = ddlAttributes.SelectedValue.ToStr();
                if (string.IsNullOrEmpty(Attributes))
                {
                    grdLister.Rows.Clear();
                    return;

                }
                drvList.Clear();
                if (optLoginDrivers.IsChecked)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        var Loginlist = db.Fleet_DriverQueueLists.Where(c => c.Status == true).Select(args => new {args.DriverId }).ToList();


                        if (ddlAttributes.SelectedItem.DataBoundItem.ToStr().Contains("VehicleAttributeType"))
                        {
                            var list = (
                                    from a in db.Fleet_Drivers

                                    join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                    join c in db.Gen_Zones on b.ZoneId equals c.Id
                                    join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                
                                    select new
                                    {
                                        Id = a.Id,
                                        DriverNo = a.DriverNo,
                                        DriverName = a.DriverName,
                                        VehicleType = d.VehicleType,
                                        Plot = c.ZoneName,
                                        VehicleTypeId = d.Id
                                    }).ToList();


                            string vehAttributes = db.Fleet_VehicleTypes.Where(c => c.Id == Attributes.ToInt()).Select(c => c.AttributeValues).FirstOrDefault().ToStr();

                            list = list.Where(c => vehAttributes.Contains("," + c.VehicleTypeId + ",")).ToList();


                            foreach (var item in Loginlist)
                            {
                                var obj = list.Where(c => c.Id == item.DriverId).FirstOrDefault();
                                if (obj != null)
                                {
                                    drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });
                                }
                            }

                        }
                        else
                        {

                            var list = (
                                    from a in db.Fleet_Drivers.Where(c => c.AttributeValues.Contains(Attributes))
                                    join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                    join c in db.Gen_Zones on b.ZoneId equals c.Id
                                    join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                    select new
                                    {
                                        Id = a.Id,
                                        DriverNo = a.DriverNo,
                                        DriverName = a.DriverName,
                                        VehicleType = d.VehicleType,
                                        Plot = c.ZoneName
                                    }).ToList();


                            foreach (var item in Loginlist)
                            {
                                var obj = list.Where(c => c.Id == item.DriverId).FirstOrDefault();
                                if (obj != null)
                                {
                                    drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });
                                }
                            }
                        }
                    }
                }
                else if (optAvailableDrivers.IsChecked)
                {


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        var Loginlist = db.Fleet_DriverQueueLists.Where(c => c.Status == true && c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.AVAILABLE)
                                .Select(args => new { args.DriverId }).ToList();

                        if (ddlAttributes.SelectedItem.DataBoundItem.ToStr().Contains("VehicleAttributeType"))
                        {

                            

                            var list = (
                                        from a in db.Fleet_Drivers
                                        join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                        join c in db.Gen_Zones on b.ZoneId equals c.Id
                                        join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                       
                                        select new
                                        {
                                            Id = a.Id,
                                            DriverNo = a.DriverNo,
                                            DriverName = a.DriverName,
                                            VehicleType = d.VehicleType,
                                            Plot = c.ZoneName,
                                            VehicleTypeId=d.Id
                                        }).ToList();


                            string vehAttributes = db.Fleet_VehicleTypes.Where(c => c.Id == Attributes.ToInt()).Select(c => c.AttributeValues).FirstOrDefault().ToStr();

                            list = list.Where(c => vehAttributes.Contains("," + c.VehicleTypeId + "," )).ToList();


                            foreach (var item in Loginlist)
                            {
                                var obj = list.Where(c => c.Id == item.DriverId).FirstOrDefault();
                                if (obj != null)
                                {
                                    drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });
                                }
                            }
                        }
                        else
                        {

                            

                            var list = (
                                        from a in db.Fleet_Drivers.Where(c => c.AttributeValues.Contains(Attributes))
                                        join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                        join c in db.Gen_Zones on b.ZoneId equals c.Id
                                        join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                        select new
                                        {
                                            Id = a.Id,
                                            DriverNo = a.DriverNo,
                                            DriverName = a.DriverName,
                                            VehicleType = d.VehicleType,
                                            Plot = c.ZoneName
                                        }).ToList();


                            foreach (var item in Loginlist)
                            {
                                var obj = list.Where(c => c.Id == item.DriverId).FirstOrDefault();
                                if (obj != null)
                                {
                                    drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });
                                }
                            }
                        }
                    }

                    
                }
                else
                {

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        if (ddlAttributes.SelectedItem.DataBoundItem.ToStr().Contains("VehicleAttributeType"))
                        {
                            var list = (
                                   from a in db.Fleet_Drivers
                                   join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                   join c in db.Gen_Zones on b.ZoneId equals c.Id
                                   join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                
                                   select new
                                   {
                                       Id = a.Id,
                                       DriverNo = a.DriverNo,
                                       DriverName = a.DriverName,
                                       VehicleType = d.VehicleType,
                                       Plot = c.ZoneName,
                                       VehicleTypeId = d.Id
                                   }).ToList();


                            string vehAttributes = db.Fleet_VehicleTypes.Where(c => c.Id == Attributes.ToInt()).Select(c => c.AttributeValues).FirstOrDefault().ToStr();

                            list = list.Where(c => vehAttributes.Contains("," + c.VehicleTypeId + ",")).ToList();


                            foreach (var obj in list)
                            {

                                drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });

                            }
                        }
                        else
                        {
                            var list = (
                                    from a in db.Fleet_Drivers.Where(c => c.AttributeValues.Contains(Attributes))
                                    join b in db.Fleet_Driver_Locations on a.Id equals b.DriverId
                                    join c in db.Gen_Zones on b.ZoneId equals c.Id
                                    join d in db.Fleet_VehicleTypes on a.VehicleTypeId equals d.Id
                                    select new
                                    {
                                        Id = a.Id,
                                        DriverNo = a.DriverNo,
                                        DriverName = a.DriverName,
                                        VehicleType = d.VehicleType,
                                        Plot = c.ZoneName
                                    }).ToList();


                            foreach (var obj in list)
                            {

                                drvList.Add(new DriverList { Id = obj.Id, DriverNo = obj.DriverNo, DriverName = obj.DriverName, VehicleType = obj.VehicleType, Plot = obj.Plot });

                            }
                        }
                    }

                   
                }

                grdLister.Rows.Clear();
                grdLister.RowCount = drvList.Count;
                for (int i = 0; i < drvList.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.DriverNo].Value = drvList[i].DriverNo;
                    grdLister.Rows[i].Cells[COLS.DriverName].Value = drvList[i].DriverName;
                    grdLister.Rows[i].Cells[COLS.VehicleType].Value = drvList[i].VehicleType;
                    grdLister.Rows[i].Cells["Plot"].Value = drvList[i].Plot;
                }
                //grdLister.DataSource = drvList;
                //grdLister.Columns["Id"].IsVisible = false;
                //grdLister.Columns["DriverNo"].Width = 170;
                //grdLister.Columns["DriverName"].Width = 200;
                //grdLister.Columns["VehicleType"].Width = 200;
                //grdLister.Columns["DriverNo"].HeaderText = "Driver No";
                //grdLister.Columns["DriverName"].HeaderText = "Driver Name";
                //grdLister.Columns["VehicleType"].HeaderText = "Vehicle Type";
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        public void FillCombo()
        {
            ComboFunctions.FillAttributeAndVehicleCombo(ddlAttributes);
        }
        void frmDriverAttributes_Load(object sender, EventArgs e)
        {

        }
        public struct COLS
        {
            public static string DriverNo = "DriverNo";
            public static string DriverName = "DriverName";
            public static string VehicleType = "VehicleType";
        }
        public void FormatGrid()
        {

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverNo;
            col.HeaderText = "Driver No";
            col.Width = 130;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.DriverName;
            col.HeaderText = "Driver Name";
            col.Width = 200;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.VehicleType;
            col.HeaderText = "Vehicle Type";
            col.Width = 130;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = "Plot";
            col.HeaderText = "Plot";
            col.Width = 100;
            grdLister.Columns.Add(col);

        }
    }
    public class DriverList
    {
        public int Id { get; set; }
        public string DriverNo { get; set; }
        public string DriverName { get; set; }
        public string VehicleType { get; set; }
             public string Plot { get; set; }
    }
    
}
