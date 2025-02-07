using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using DAL;
using Telerik.WinControls.UI;
using Taxi_Model;
using UI;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmFareMeterSetting : UI.SetupBase
    {
        SysPolicyBO objMaster;
        decimal MeterRoundedValue = 0;
        int FareMeterType = 0;
        public frmFareMeterSetting()
        {
            InitializeComponent();
            objMaster = new SysPolicyBO();
            this.SetProperties((INavigation)objMaster);
            MeterTypes();
            FormatGrid();
            FormatGridBookingFeeRange();
            this.Load += new EventHandler(frmFareMeterSetting_Load);
            this.ddlFareMeterType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlFareMeterType_SelectedIndexChanged);
        }

        void ddlFareMeterType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //string MeterType = ddlFareMeterType.Text.ToStr().Trim();
            //if (MeterType.StartsWith("Fare Meter 1"))
            //{
            //    MeterRoundedValue = 0;
            //    spnMeterRoundedValue.Visible = false;
            //    lblFareValue.Visible = false;
            //}
            //else if (MeterType.StartsWith("Fare Meter 2"))
            //{
            //    spnMeterRoundedValue.Visible = true;
            //    lblFareValue.Visible = true;
            //}
        }

        void frmFareMeterSetting_Load(object sender, EventArgs e)
        {
            try
            {
                       
                           
                if(AppVars.listUserRights.Count(c=>c.functionId=="SHOW METER OTHER DETAIL")>0)
                {
                    pnlMeterDetails.Visible = true;

                }


                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.DeferredLoadingEnabled = true;

                    var list = (from a in db.Fleet_VehicleTypes
                                orderby a.OrderNo
                                select new
                                {
                                    VehicleTypeId = a.Id,
                                    VehicleType = a.VehicleType
                                }).ToList();


                    grdFareMeterSetting.RowCount = list.Count;

                    for (int i = 0; i < list.Count; i++)
                    {

                        grdFareMeterSetting.Rows[i].Cells[COLS.VehicleTypeId].Value = list[i].VehicleTypeId.ToInt();
                        grdFareMeterSetting.Rows[i].Cells[COLS.VehicleType].Value = list[i].VehicleType.ToString();
                        grdFareMeterSetting.Rows[i].Cells[COLS.HasMeter].Value = false;
                    }


                    Gen_SysPolicy obj =db.Gen_SysPolicies.FirstOrDefault();
                    if (obj != null)
                    {
                        objMaster.GetByPrimaryKey(obj.Id);
                        DisplayRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }            
        }
        public void MeterTypes()
        {
            RadListDataItem item=new RadListDataItem();
            item.Text="Fare Meter 1 (BASIC)";
            item.Value=1;
            item.Enabled = false;

            ddlFareMeterType.Items.Add(item);

            item = new RadListDataItem();
            item.Text = "ONLINE";
            item.Value = 2;
            ddlFareMeterType.Items.Add(item);



            item = new RadListDataItem();
            item.Text = "OFFLINE";
            item.Value = 3;
            ddlFareMeterType.Items.Add(item);
        }

        
        public override void DisplayRecord()
        {


            if (objMaster.Current == null) return;


            try
            {

                if (objMaster.Current.Gen_SysPolicy_Configurations.Count == 1)
                {

                    int PolicyId = objMaster.Current.Gen_SysPolicy_Configurations[0].FareMeterType.ToInt();
                    ddlFareMeterType.SelectedValue = PolicyId;

                    string BookingFee = objMaster.Current.Gen_SysPolicy_Configurations[0].PDANewWeekMessageByDay;

                    if (BookingFee != string.Empty && BookingFee != null  && BookingFee.ToStr().StartsWith("{")==true)

                    {
                        MeterTariff objIVR = Newtonsoft.Json.JsonConvert.DeserializeObject<MeterTariff>(BookingFee);

                        if (objIVR.ChangePlotOnAsDirected == "1")
                        {
                            chkChangePlotOnAsDirected.Checked = true;
                        }
                        else
                        {
                            chkChangePlotOnAsDirected.Checked = false;
                        }

                        if (objIVR.RemoveExtraCharges == "1")
                        {
                            chkRemoveExtraCharges.Checked = true;
                        }
                        else
                        {
                            chkRemoveExtraCharges.Checked = false;
                        }

                        if (objIVR.ShowBookingFees == "1")
                        {
                            chkShowBookingFee.Checked = true;
                        }
                        else
                        {
                            chkShowBookingFee.Checked = false;
                        }

                        if (objIVR.ShowExtraCharges == "1")
                        {
                            chkShowExtraCharges.Checked = true;
                        }
                        else
                        {
                            chkShowExtraCharges.Checked = false;
                        }

                        if (objIVR.ShowParkingCharges == "1")
                        {
                            chkShowParkingCharges.Checked = true;
                        }
                        else
                        {
                            chkShowParkingCharges.Checked = false;
                        }
                  
                       
                        spnExtraChargesPerQty.Value = objIVR.ExtraChargesPerQty.ToDecimal();

                        grdBookingFeeRange.RowCount= objIVR.BookingFeesRange.Count(); ;

                        for (int i = 0; i < objIVR.BookingFeesRange.Count; i++)
                        {
                            grdBookingFeeRange.Rows[i].Cells[COLS_BOOKINGFEE.From].Value = objIVR.BookingFeesRange[i].From.ToDecimal();
                            grdBookingFeeRange.Rows[i].Cells[COLS_BOOKINGFEE.To].Value = objIVR.BookingFeesRange[i].To.ToDecimal();
                            grdBookingFeeRange.Rows[i].Cells[COLS_BOOKINGFEE.Charges].Value = objIVR.BookingFeesRange[i].Charges.ToDecimal();
                        }

                    }

                                       


                    chkEnablePeakOffPeakWiseFares.Checked = objMaster.Current.Gen_SysPolicy_Configurations[0].EnablePeakOffPeakFares.ToBool();
               


                    spnMeterRoundedValue.Value = objMaster.Current.Gen_SysPolicy_Configurations[0].FareMeterRoundedCalc.ToDecimal();

                    var list = (from a in General.GetQueryable<Gen_SysPolicy_FareMeterSetting>(c => c.SysPolicyId != null)
                                select new
                                {
                                    Id = a.Id,
                                    SysPolicyId = a.SysPolicyId,
                                    VehicleTypeId = a.VehicleTypeId,
                                    HasMeter = a.HasMeter,
                                    AutoStartWaiting=a.AutoStartWaiting,
                                    a.AutoStartWaitingBelowSpeed,
                                    a.AutoStartWaitingMinDist,
                                    a.AutoStartWaitingBelowSpeedSeconds,
                                    AutoStopWaitingSpeed=a.AutoStopWaitingOnSpeed,
                                    DrvWaitingCharges=a.DrvWaitingChargesPerMin,
                                    WaitingTime=a.AccWaitingChargesPerMin
                                }).ToList();


                    GridViewRowInfo row = null;
                    foreach (var item in list)
                    {
                        row = grdFareMeterSetting.Rows.FirstOrDefault(c => c.Cells[COLS.VehicleTypeId].Value.ToIntorNull() == item.VehicleTypeId);

                        if (row != null)
                        {
                            row.Cells[COLS.VehicleTypeId].Value = item.VehicleTypeId.ToInt();
                            row.Cells[COLS.Id].Value = item.Id.ToInt();
                            row.Cells[COLS.HasMeter].Value = item.HasMeter.ToBool();
                            row.Cells[COLS.SysPolicyId].Value = item.SysPolicyId.ToIntorNull();

                            row.Cells[COLS.AutoStartWaiting].Value = item.AutoStartWaiting.ToBool();
                            row.Cells[COLS.AutoStartWaitingSpeedLimit].Value = item.AutoStartWaitingBelowSpeed.ToDecimal();
                            row.Cells[COLS.AutoStartWaitingMinDist].Value = item.AutoStartWaitingMinDist.ToDecimal();

                            row.Cells[COLS.AutoStartWaitingSecondsLimit].Value = item.AutoStartWaitingBelowSpeedSeconds.ToInt();


                            row.Cells[COLS.AutoStopWaitingOnSpeed].Value = item.AutoStopWaitingSpeed.ToDecimal();
                            row.Cells[COLS.DrvWaitingCharges].Value = item.DrvWaitingCharges.ToDecimal();
                            row.Cells[COLS.WaitingTime].Value = item.WaitingTime.ToDecimal();


                        }
                    }


                   

                }

            }
            catch (Exception ex)
            {


            }
        }

        public struct COLS_BOOKINGFEE
        {
            public static string From = "From";
            public static string To = "To";
            public static string Charges = "Charges";
        }

        public struct COLS
        {
            public static string Id = "Id";
            public static string SysPolicyId = "SysPolicyId";
            public static string VehicleTypeId = "VehicleTypeId";
            public static string VehicleType = "VehicleType";
            public static string HasMeter = "HasMeter";
            public static string AutoStartWaiting = "AutoStartWaiting";
            public static string AutoStartWaitingMinDist = "AutoStartWaitingMinDist";
            public static string AutoStartWaitingSpeedLimit = "AutoStartWaitingSpeedLimit";
            public static string AutoStartWaitingSecondsLimit = "AutoStartWaitingSecondsLimit";

            public static string AutoStopWaitingOnSpeed = "AutoStopWaitingOnSpeed";
            public static string DrvWaitingCharges = "DrvWaitingCharges";
            public static string AccountWaitingCharges = "AccountWaitingCharges";
            public static string WaitingTime = "WaitingTime";
        }

        public void FormatGridBookingFeeRange()
        {

            GridViewDecimalColumn col = new GridViewDecimalColumn();
            col.Name = COLS_BOOKINGFEE.From;
            col.HeaderText = "From";
            col.Width = 110;
            grdBookingFeeRange.Columns.Add(col);

            col = new GridViewDecimalColumn();
            col.Name = COLS_BOOKINGFEE.To;
            col.HeaderText = "To";
            col.Width = 110;
            grdBookingFeeRange.Columns.Add(col);

            col = new GridViewDecimalColumn();
            col.Name = COLS_BOOKINGFEE.Charges;
            col.HeaderText = "Charges";
            col.Width = 110;
            grdBookingFeeRange.Columns.Add(col);

            grdBookingFeeRange.AllowAddNewRow = true;


        }

        public void FormatGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.Id;
            col.IsVisible = false;
            grdFareMeterSetting.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.SysPolicyId;
            col.IsVisible = false;
            grdFareMeterSetting.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.VehicleTypeId;
            col.IsVisible = false;
            grdFareMeterSetting.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.VehicleType;
            col.HeaderText = "Vehicle Type";
            col.ReadOnly = true;
            col.Width = 130;
            col.IsPinned = true;
            grdFareMeterSetting.Columns.Add(col);


            GridViewCheckBoxColumn ckcol = new GridViewCheckBoxColumn();
            ckcol.Name = COLS.HasMeter;
            ckcol.HeaderText = "Has Meter";
            ckcol.Width = 80;
            grdFareMeterSetting.Columns.Add(ckcol);


            ckcol = new GridViewCheckBoxColumn();
            ckcol.Name = COLS.AutoStartWaiting;
            ckcol.HeaderText = "AutoStart Waiting";
            ckcol.Width = 110;            
            grdFareMeterSetting.Columns.Add(ckcol);


            GridViewDecimalColumn colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Maximum = 50;
            colD.HeaderText = "AutoStart Waiting on Speed Limit(mph)";
            colD.Name = COLS.AutoStartWaitingSpeedLimit;
            colD.Minimum = 0;
            colD.Width = 210;
            grdFareMeterSetting.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Maximum = 600;
            colD.HeaderText = "AutoStart Waiting Seconds";
            colD.Name = COLS.AutoStartWaitingSecondsLimit;
            colD.Minimum = 0;
            colD.Width = 150;
            grdFareMeterSetting.Columns.Add(colD);


            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Maximum = 50;
            colD.HeaderText = "AutoStart Waiting Min. Dist";
            colD.Name = COLS.AutoStartWaitingMinDist;
            colD.Minimum = 0;
            colD.Width = 150;
            colD.IsVisible = AppVars.listUserRights.Count(c => c.functionId == "SHOW AUTOSTART MIN DISTANCE") > 0;
            colD.VisibleInColumnChooser = colD.IsVisible;
            grdFareMeterSetting.Columns.Add(colD);



            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 2;
            colD.Maximum = 50;
            colD.HeaderText = "AutoStop Waiting On Speed(mph)";
            colD.Name = COLS.AutoStopWaitingOnSpeed;
            colD.Minimum = 0;
            colD.Width = 180;
            grdFareMeterSetting.Columns.Add(colD);

            colD = new GridViewDecimalColumn();
            colD.DecimalPlaces = 3;
            colD.Maximum = 500;
            colD.HeaderText = "Waiting Charges";
            colD.Name = COLS.DrvWaitingCharges;
            colD.Minimum = 0;
            colD.Width = 100;
            grdFareMeterSetting.Columns.Add(colD);


            colD = new  GridViewDecimalColumn();
            colD.DecimalPlaces = 0;
      //      colD.DataEditFormatString = "{0:F0}";
            colD.FormatString = "{0:F0}";
            colD.Maximum = 500;
            colD.HeaderText = "Waiting Time(secs)";
            colD.Name = COLS.WaitingTime;
            colD.Minimum = 0;
            colD.Width = 110;
            grdFareMeterSetting.Columns.Add(colD);


            //colD = new GridViewDecimalColumn();
            //colD.DecimalPlaces = 2;
            //colD.Maximum = 140;
            //colD.HeaderText = "A/C Waiting Charges/mins)";
            //colD.Name = COLS.AccountWaitingCharges;
            //colD.Minimum = 0;
            //colD.Width = 200;
            //grdFareMeterSetting.Columns.Add(colD);


            GridViewCommandColumn cmdCol = new GridViewCommandColumn();
            cmdCol.UseDefaultText = true;
            cmdCol.DefaultText = "Meter Settings";
            cmdCol.Width = 100;
            cmdCol.Name = "btnmeter";
            cmdCol.IsVisible = false;
            grdFareMeterSetting.Columns.Add(cmdCol);


            grdFareMeterSetting.CommandCellClick += new CommandCellClickEventHandler(grdFareMeterSetting_CommandCellClick);
           

        }

        void grdFareMeterSetting_CommandCellClick(object sender, EventArgs e)
        {


            try
            {
                if (grdFareMeterSetting.CurrentColumn != null)
                {
                    if (grdFareMeterSetting.CurrentColumn.Name == "btnmeter")
                    {

                        int vehicleTypeId = grdFareMeterSetting.CurrentRow.Cells[COLS.VehicleTypeId].Value.ToInt();

                      //  General.GetObject<Fare>(c => c.VehicleTypeId == vehicleTypeId);

                        AppVars.objPolicyConfiguration.EnablePeakOffPeakFares = chkEnablePeakOffPeakWiseFares.Checked;



                        if (AppVars.objPolicyConfiguration.FareMeterType.ToInt() == 2)
                        {
                            using (frmSpecialDayFares frm = new frmSpecialDayFares())
                            {
                                frm.ShowDialog();
                            }

                        }
                        else
                        {

                            using (frmPDAMeterFares frm = new frmPDAMeterFares(vehicleTypeId))
                            {
                                frm.ShowDialog();
                            }
                        }

                        GC.Collect();

                    }


                }

            }
            catch
            {


            }

        }

       


        public override void Save()
        {

            try
            {


                int MeterType = ddlFareMeterType.SelectedValue.ToInt();
                if (MeterType==-1)
                {
                    ENUtils.ShowMessage("Required : Fare Meter Type");
                    return;
                }
                if (MeterType ==2)
                {
                    MeterRoundedValue = spnMeterRoundedValue.Value.ToDecimal();
                    FareMeterType = 2;
                }
                if (MeterType == 3)
                {
                    MeterRoundedValue = spnMeterRoundedValue.Value.ToDecimal();
                    FareMeterType = 3;
                }
                else
                {
                    FareMeterType = 2;
                    MeterRoundedValue = 0;
                }

               

                Gen_SysPolicy obj = General.GetQueryable<Gen_SysPolicy>(null).FirstOrDefault();
                if (obj != null)
                {
                    objMaster.GetByPrimaryKey(obj.Id);
                    objMaster.Edit();
                }


                objMaster.Current.Gen_SysPolicy_Configurations[0].FareMeterType = ddlFareMeterType.SelectedValue.ToInt();
                objMaster.Current.Gen_SysPolicy_Configurations[0].FareMeterRoundedCalc = MeterRoundedValue.ToDecimal();

                //"Gen_SysPolicy",
                string[] skipProperties = new string[] { "Gen_SysPolicy","Fleet_VehicleType" };
                List<Gen_SysPolicy_FareMeterSetting> listofFares = (from a in grdFareMeterSetting.Rows
                                                                select new Gen_SysPolicy_FareMeterSetting
                                                                {
                                                                    Id = a.Cells[COLS.Id].Value.ToInt(),
                                                                    SysPolicyId = objMaster.Current.Id,
                                                                    VehicleTypeId = a.Cells[COLS.VehicleTypeId].Value.ToIntorNull(),
                                                                    HasMeter = a.Cells[COLS.HasMeter].Value.ToBool(),
                                                                    AutoStartWaiting = a.Cells[COLS.AutoStartWaiting].Value.ToBool(),
                                                                     AutoStartWaitingBelowSpeed=a.Cells[COLS.AutoStartWaitingSpeedLimit].Value.ToDecimal(),
                                                                      AutoStartWaitingBelowSpeedSeconds=a.Cells[COLS.AutoStartWaitingSecondsLimit].Value.ToInt(),
                                                                       AutoStartWaitingMinDist=a.Cells[COLS.AutoStartWaitingMinDist].Value.ToDecimal(),
                                                                     AutoStopWaitingOnSpeed=a.Cells[COLS.AutoStopWaitingOnSpeed].Value.ToDecimal(),
                                                                      DrvWaitingChargesPerMin=a.Cells[COLS.DrvWaitingCharges].Value.ToDecimal(),
                                                                      AccWaitingChargesPerMin=a.Cells[COLS.WaitingTime].Value.ToDecimal()
                                                                }).ToList();


                


                IList<Gen_SysPolicy_FareMeterSetting> savedListFares = objMaster.Current.Gen_SysPolicy_FareMeterSettings;
                Utils.General.SyncChildCollection(ref savedListFares, ref listofFares, "Id", skipProperties);

                bool IsUpdated = false;

                if (objMaster.Current.Gen_SysPolicy_Configurations[0].EnablePeakOffPeakFares.ToBool() != chkEnablePeakOffPeakWiseFares.Checked
                    || objMaster.Current.Gen_SysPolicy_Configurations[0].FareMeterType.ToInt() != ddlFareMeterType.SelectedValue.ToInt())
                {



                    objMaster.Current.Gen_SysPolicy_Configurations[0].EnablePeakOffPeakFares = chkEnablePeakOffPeakWiseFares.Checked;

                    IsUpdated = true;

                   
                }
                objMaster.Current.Gen_SysPolicy_Configurations[0].PDANewWeekMessageByDay = GetSerialize().ToStr();

                objMaster.Save();


                if (IsUpdated)
                {
                    General.LoadConfiguration(); 

                }


                bool rtn = General.SendMessageToPDA("request refreshzones").Result.ToBool();



                Close();
            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                {
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                }
                else
                {
                    ENUtils.ShowMessage(ex.Message);
                }
            }
        }


        private void UpdateMeterSettings()
        {



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetSerialize()
        {
            try
            {

                List<BookingFeeRange> list = (from r in grdBookingFeeRange.Rows
                                    select new BookingFeeRange
                                    {
                                        From =  Convert.ToSingle(r.Cells[COLS_BOOKINGFEE.From].Value),
                                        To = Convert.ToSingle(r.Cells[COLS_BOOKINGFEE.To].Value),
                                        Charges = Convert.ToSingle(r.Cells[COLS_BOOKINGFEE.Charges].Value)
                                    }).ToList();

                MeterTariff obje = new MeterTariff();
                obje.RemoveExtraCharges = chkRemoveExtraCharges.Checked ? "1" : "0";
                obje.ShowExtraCharges = chkShowExtraCharges.Checked ? "1" : "0";
                obje.ExtraChargesPerQty = spnExtraChargesPerQty.Value.ToStr();
                obje.ShowBookingFees = chkShowBookingFee.Checked ? "1" : "0";
                obje.BookingFeesRange = list;
                obje.ShowParkingCharges = chkShowParkingCharges.Checked ? "1" : "0";
                obje.ChangePlotOnAsDirected = chkChangePlotOnAsDirected.Checked ? "1" : "0";

                string jsonParameterValue = Newtonsoft.Json.JsonConvert.SerializeObject(obje);
                return jsonParameterValue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void grdFareMeterSetting_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

public class BookingFeeRange
{
    public float From;
    public float To;
    public float Charges;

}

public class MeterTariff
{
    public string RemoveExtraCharges;
    public string ExtraChargesPerQty;
    public string ShowExtraCharges;
    public string ShowBookingFees;
    public List<BookingFeeRange> BookingFeesRange;
    public string ShowParkingCharges;
    public string ChangePlotOnAsDirected;
}