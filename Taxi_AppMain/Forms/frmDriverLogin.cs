﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Utils;
using Taxi_Model;
using Taxi_BLL;

namespace Taxi_AppMain
{
    public partial class frmDriverLogin : Form
    {
        //  DriverBO objMaster;
        public frmDriverLogin()
        {
            InitializeComponent();

            this.Shown += new EventHandler(frmDriverLogin_Shown);


        }


        private void ShowDrivers(bool loggedIn)
        {

            try
            {


                using (TaxiDataContext db = new TaxiDataContext())
                {

                    if (loggedIn)
                    {

                        var list = (from a in db.Fleet_DriverQueueLists
                                    join b in db.Fleet_Drivers on a.DriverId equals b.Id
                                    where a.Status == true
                                    orderby b.DriverNo
                                    select new
                                    {
                                        Id = b.Id,
                                        DriverName = b.DriverNo + " - " + b.DriverName,
                                        DriverNo = b.DriverNo,
                                        a.FleetMasterId
                                    }).ToList();

                        grdDrivers.RowCount = list.Count;

                        for (int i = 0; i < list.Count; i++)
                        {

                            grdDrivers.Rows[i].Cells["colId"].Value = list[i].Id;
                            grdDrivers.Rows[i].Cells["colDrv"].Value = list[i].DriverName;
                            grdDrivers.Rows[i].Cells["DriverNo"].Value = list[i].DriverNo;
                            grdDrivers.Rows[i].Cells["FleetMasterId"].Value = list[i].FleetMasterId.ToLong();


                        }


                    }
                    else
                    {

                        var list = (from a in db.Fleet_Drivers
                                    where a.IsActive == true
                                    orderby a.DriverNo
                                    select new
                                    {
                                        Id = a.Id,
                                        DriverName = a.DriverNo + " - " + a.DriverName,
                                        DriverNo = a.DriverNo,
                                        FleetMasterId = default(int?)
                                    }).ToList();  // General.GetQueryable<Fleet_Driver>(null)

                        grdDrivers.RowCount = list.Count;

                        for (int i = 0; i < list.Count; i++)
                        {

                            grdDrivers.Rows[i].Cells["colId"].Value = list[i].Id;
                            grdDrivers.Rows[i].Cells["colDrv"].Value = list[i].DriverName;
                            grdDrivers.Rows[i].Cells["DriverNo"].Value = list[i].DriverNo;

                            grdDrivers.Rows[i].Cells["FleetMasterId"].Value = null;
                        }

                    }

                }


                grdDrivers.Columns["FleetMasterId"].IsVisible = false;
            }
            catch
            {

            }
        }


        void frmDriverLogin_Shown(object sender, EventArgs e)
        {
            try
            {

                grdDrivers.CellBeginEdit += GrdDrivers_CellBeginEdit;

                ShowDrivers(false);






            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }



        private void GrdDrivers_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Column is GridViewComboBoxColumn)
                {


                    int? driverId = e.Row.Cells["colId"].Value.ToIntorNull();



                    var list = General.GetQueryable<Fleet_Driver_CompanyVehicle>(c => c.DriverId == driverId && c.FleetMasterId != null).Select(args => new
                    {

                        Id = args.FleetMasterId,
                        No = args.Fleet_Master.VehicleNo
                    }).ToList();

                    (e.Column as GridViewComboBoxColumn).DataSource = list;


                    if (list.Count == 0)
                    {
                        var list2 = General.GetQueryable<Fleet_Master>(null).Select(args => new
                        {

                            Id = args.Id,
                            No = args.VehicleNo
                        }).ToList();

                        (e.Column as GridViewComboBoxColumn).DataSource = list2;

                    }



                (e.Column as GridViewComboBoxColumn).DisplayMember = "No";
                    (e.Column as GridViewComboBoxColumn).ValueMember = "Id";
                    //colCombo.NullValue = "select";
                    (e.Column as GridViewComboBoxColumn).DropDownStyle = RadDropDownStyle.DropDown;



                    if (e.Row.Cells["FleetMasterId"].Value.ToInt() > 0)
                    {
                        e.Row.Cells[e.ColumnIndex].Value = e.Row.Cells["FleetMasterId"].Value;


                    }


                }
            }

            catch
            {


            }
        }

        private void GrdDrivers_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            try
            {

                int? driverId = e.Row.Cells["colId"].Value.ToIntorNull();

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var list = db.Fleet_Driver_CompanyVehicles.Where(c => c.DriverId == driverId && c.FleetMasterId != null).Select(args => new
                    {

                        Id = args.FleetMasterId,
                        No = args.Fleet_Master.VehicleNo
                    }).ToList();

                    (e.Column as GridViewComboBoxColumn).DataSource = list;


                    if (list.Count == 0)
                    {
                        var list2 = db.Fleet_Masters.Select(args => new
                        {

                            Id = args.Id,
                            No = args.VehicleNo
                        }).ToList();

                        (e.Column as GridViewComboBoxColumn).DataSource = list2;
                    }

                (e.Column as GridViewComboBoxColumn).DisplayMember = "No";
                    (e.Column as GridViewComboBoxColumn).ValueMember = "Id";
                    //colCombo.NullValue = "select";
                    (e.Column as GridViewComboBoxColumn).DropDownStyle = RadDropDownStyle.DropDown;

                }
            }

            catch
            {


            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDriver();
        }

        int? totalFleets = null;
        private void LoginDriver()
        {


            try
            {
                bool IsValidate = false;

                List<int?> ids = grdDrivers.Rows.Where(c => c.Cells["colChk"].Value.ToBool()).Select(c => c.Cells["colId"].Value.ToIntorNull()).ToList();

                if (ids.Count == 0)
                {
                    IsValidate = true;
                    ENUtils.ShowMessage("Please select a Driver");
                    return;
                }

                //  List<int?> ids = lstDriver.SelectedItems.Select(c => c.Value.ToIntorNull()).ToList();




                //if (db.Fleet_DriverQueueLists.Count(c => ids.Contains(c.DriverId) && c.Status == true) > 0)
                //{

                //    ENUtils.ShowMessage("Some Selected Driver(s)  already in the Login List..");
                //    IsValidate = true;
                //    grdDrivers.Focus();
                //    // lstDriver.Focus();
                //    return;
                //}


                //if (totalFleets> 0 &&  grdDrivers.Rows.Where(c=>c.Cells["colChk"].Value.ToBool().Any(c => c.Cells["colVeh"].Value.ToIntorNull()==null))
                //{
                //    ENUtils.ShowMessage("Required Vehicle");
                //    return;


                //}




                DriverQueueBO objMaster = null;
                int? driverId = null;
                string driverNos = "";

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    foreach (GridViewRowInfo row in grdDrivers.Rows.Where(c => c.Cells["colChk"].Value.ToBool()))
                    {

                        objMaster = new DriverQueueBO();
                        driverId = row.Cells["colId"].Value.ToIntorNull();

                        if (db.Fleet_DriverQueueLists.Count(c => c.DriverId == driverId && c.Status == true) > 0)
                        {
                            objMaster.GetByPrimaryKey(db.Fleet_DriverQueueLists.Where(c => c.DriverId == driverId && c.Status == true).Select(args => args.Id).FirstOrDefault());
                            //objMaster.Edit();
                        }
                        else
                        {
                          


                            objMaster.New();


                            objMaster.Current.IsManualLogin = true;
                            objMaster.Current.DriverId = driverId;
                            objMaster.Current.Status = true;
                            objMaster.Current.LoginDateTime = DateTime.Now;
                            objMaster.Current.QueueDateTime = DateTime.Now;
                            objMaster.Current.WaitSinceOn = DateTime.Now;
                        }




                        objMaster.Current.FleetMasterId = row.Cells["colVeh"].Value.ToIntorNull();





                        if (objMaster.Current.FleetMasterId == null)
                        {

                            int cnt = db.Fleet_Driver_PDASettings.Where(c => c.DriverId == objMaster.Current.DriverId && (c.HasCompanyCars != null && c.HasCompanyCars == true)).Count();


                            if (cnt > 0)
                            {
                                    IsValidate = true;
                                ENUtils.ShowMessage("Required Vehicle");
                                break;


                            }


                        }
                        else
                        {

                            int cnt = db.Fleet_DriverQueueLists.Where(c => c.Status == true && c.FleetMasterId == objMaster.Current.FleetMasterId && c.DriverId != driverId).Count();


                            if (cnt > 0)
                            {
                                   IsValidate = true;
                                ENUtils.ShowMessage("Other Driver is already loggedIn with this Vehicle");
                                break;


                            }


                        }


                 


                        DateTime nowDate = DateTime.Now.ToDate();
                        TimeSpan TimeNow = DateTime.Now.TimeOfDay;
                        int? LoginID = AppVars.LoginObj.LgroupId.ToInt();

                        bool manualuntickHasPda = true;
                        //     bool manualuntickHasPda = AppVars.listUserRights.Count(c => c.functionId == "DISABLE HASPDA ON MANUAL LOGIN DRIVER") > 0;


                        if (objMaster.Current.Id == 0)
                        {

                            var data1 = General.GetQueryable<Fleet_Driver>(c => c.Id == driverId).AsEnumerable();
                            var data2 = General.GetQueryable<Fleet_Driver_Shift>(c => c.DriverId == driverId);
                            var query = (from a in data1
                                         join b in data2 on a.Id equals b.DriverId
                                         select new
                                         {
                                             DriverNo = a.DriverNo,
                                             ShiftName = b.Driver_Shift.ShiftName,
                                             FTime = b.FromTime.Value.TimeOfDay,
                                             TTime = b.ToTime.Value.TimeOfDay,


                                         }).AsQueryable();
                            DataTable dt = query.ToDataTable();
                            string ShiftN = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                ShiftN += dt.Rows[i]["ShiftName"].ToStr() + " " + dt.Rows[i]["FTime"].ToStr().Substring(0, 5) + " to " + dt.Rows[i]["TTime"].ToStr().Substring(0, 5) + " ";
                            }



                            Fleet_Driver obj = General.GetObject<Fleet_Driver>(c => c.Id == driverId);
                            string DriverNo = obj.DriverNo.ToStr();

                            if (General.GetQueryable<Fleet_Driver_Shift>(c => c.DriverId == driverId && c.Driver_Shift_ID == 7).Count() > 0)
                            {
                                if (General.GetQueryable<Fleet_Driver>(c => c.Id == driverId && c.MOTExpiryDate < nowDate || c.MOTExpiryDate == null && c.MOT2ExpiryDate < nowDate || c.MOT2ExpiryDate == null && c.DrivingLicenseExpiryDate < nowDate || c.DrivingLicenseExpiryDate == null && c.PCODriverExpiryDate < nowDate || c.PCODriverExpiryDate == null && c.PCOVehicleExpiryDate < nowDate || c.PCOVehicleExpiryDate == null).Count(c => ids.Contains(c.Id)) > 0)
                                {
                                    if (LoginID == 2)
                                    {
                                        //       IsValidate = true;
                                        ENUtils.ShowMessage("Driver License Is Expire Driver Not Login..");
                                        return;
                                    }
                                }
                                driverNos += "," + row.Cells["DriverNo"].Value.ToStr();


                                objMaster.IsManualLoggedInUnTickHasPDA = manualuntickHasPda;

                                objMaster.Save();
                            }
                            else
                            {
                                if (General.GetQueryable<Fleet_Driver_Shift>(c => c.DriverId == driverId && c.FromTime.Value.TimeOfDay < TimeNow && c.ToTime.Value.TimeOfDay > TimeNow).Count() > 0)
                                {
                                    if (General.GetQueryable<Fleet_Driver>(c => c.Id == driverId && c.MOTExpiryDate < nowDate || c.MOTExpiryDate == null && c.MOT2ExpiryDate < nowDate || c.MOT2ExpiryDate == null && c.DrivingLicenseExpiryDate < nowDate || c.DrivingLicenseExpiryDate == null && c.PCODriverExpiryDate < nowDate || c.PCODriverExpiryDate == null && c.PCOVehicleExpiryDate < nowDate || c.PCOVehicleExpiryDate == null).Count(c => ids.Contains(c.Id)) > 0)
                                    {
                                        if (LoginID == 2)
                                        {
                                                   IsValidate = true;
                                            ENUtils.ShowMessage("Driver License Is Expire Driver Not Login..");
                                            return;
                                        }
                                    }
                                    driverNos += "," + row.Cells["DriverNo"].Value.ToStr();

                                    objMaster.IsManualLoggedInUnTickHasPDA = manualuntickHasPda;
                                    objMaster.Save();
                                }
                                else
                                {
                                        IsValidate = true;
                                    ENUtils.ShowMessage("Driver " + DriverNo + " not available \n Driver Shift: " + ShiftN);

                                }
                            }



                        }
                        else
                        {
                            objMaster.Save();
                        }



                        if (objMaster.Current.FleetMasterId != null)
                        {
                            try
                            {
                                db.ExecuteQuery<int>("exec stp_updatedrivervehicledetails {0},{1}", driverId, objMaster.Current.FleetMasterId);
                            }
                            catch
                            {

                            }

                        }
                    }


                    if (IsValidate == false)
                    {

                        General.RefreshListWithoutSelected<frmDriverLoginList>("frmDriverLoginList1");

                        General.BroadCastRefreshWaitingDrivers();

                        if (objMaster.Current.Id == 0)
                        {

                            try
                            {


                                if (driverNos.ToStr().StartsWith(","))
                                    driverNos = driverNos.Remove(0, 1);

                                if (driverNos.ToStr().EndsWith(","))
                                    driverNos = driverNos.Remove(driverNos.Length - 1);

                                //GridViewComboBoxColumn comboBoxColumn = this.radGridView1.Columns["column"] as GridViewComboBoxColumn;
                                //object value = this.radGridView1.Rows[0].Cells["SupplierColumn"].Value;
                                //string text = (string)comboBoxColumn.GetLookupValue(value);
                            }
                            catch
                            {


                            }

                            General.AddUserLog("Driver(s) (" + driverNos + ") Manually Login Controller", 3);







                        }




                        this.Close();


                    }


                }
            }



            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }

        }

        private void grdDrivers_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.Column != null && e.Column.Name == "colDrv")
                    e.Cancel=true;
            }
            catch (Exception ex)
            {

            }
        }

        private void chkShowLoggedIn_CheckedChanged(object sender, EventArgs e)
        {
            ShowDrivers(true);
        }
    }
}
