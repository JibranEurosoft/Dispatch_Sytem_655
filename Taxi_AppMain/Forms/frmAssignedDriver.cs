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
using Telerik.WinControls.UI;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Taxi_AppMain.Classes;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls;
using System.Collections;
using System.Threading;

namespace Taxi_AppMain
{
    public partial class frmAssignedDriver : Form
    {
        BookingGroupBO ObjMaster;
        int IsOpenFrom = 0;
        long allocatedJobId = 0;
     
        public frmAssignedDriver(long ID,int openFrom)
        {
            InitializeComponent();
            ObjMaster = new BookingGroupBO();
            ObjMaster.GetByPrimaryKey(ID);


            ComboFunctions.FillDriverNoCombo(ddl_Driver);
          //  ComboFunctions.FillDriverNoQueueCombo(ddl_Driver);
            DisplayRecord();
            this.Shown += new EventHandler(frmAllocateDriver_Shown);
            this.KeyDown += new KeyEventHandler(frmAllocateDriver_KeyDown);
            this.IsOpenFrom = openFrom;
           
          
        }

        void frmAllocateDriver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();

            }
            else if(e.KeyCode==Keys.Enter)
            {
                Save();

            }
        }

      
        void frmAllocateDriver_Shown(object sender, EventArgs e)
        {
            ddl_Driver.Focus();
            if(!string.IsNullOrEmpty(ddl_Driver.Text))
            {
                    ddl_Driver.DropDownListElement.TextBox.TextBoxItem.Select(0,2);
            }
        }

       
        private void btnExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private string allocateDrvNo;

        private void Save()
        {
            try
            {
                int defaultAllocationLimit = AppVars.objPolicyConfiguration.AllocateDrvPreExistJobLimit.ToInt();
                int? driverId = ddl_Driver.SelectedValue.ToIntorNull();
                int? oldDriverId = null;
                string oldDriverNo = string.Empty;
                long jobId = 0;
                bool cancelJob = false;
                DateTime? pickupDateAndTime=ObjMaster.Current.TripDate.ToDateTimeorNull();

                               
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    if (driverId!=null)
                    {

                    var ObjDriver = General.GetObject<Fleet_Driver>(c => c.Id == driverId);

                    if (ObjDriver != null)
                    {
                        allocateDrvNo = ObjDriver.DriverNo.ToStr().Trim();
                                                
                    }

                    try
                    {
                        if ((driverId != null && ObjMaster.Current.DriverId == null) || (driverId != null && ObjMaster.Current.DriverId != null && driverId != ObjMaster.Current.DriverId))
                        {

                            if (IsDriverDocumentExpired(driverId.ToInt(), ObjDriver))
                                return;

                        }
                    }
                    catch
                    {

                    }
                }

                
                    if (ObjMaster.Current != null)
                    {
                        if (driverId != null || (ObjMaster.Current.DriverId != null ))
                        {
                 
                            ObjMaster.CheckDataValidation = false;

                            ObjMaster.Edit();

                            ObjMaster.Current.DriverId = driverId;

                            jobId = ObjMaster.Current.Id;
                            allocatedJobId = jobId;
                           
                            ObjMaster.Save();                      

                            this.Close();

                       
                            db.ExecuteQuery<int>("Update Booking set DriverId = " + driverId + " where groupJobId = " + ObjMaster.Current.Id + "");
                        

                            string Msg = string.Empty;

                            string driverno = db.Fleet_Drivers.Where(c => c.Id == driverId).Select(c => c.DriverNo).ToStr();

                            if (driverId != null)
                            {
                                if(chkConfirmed.Checked)
                                    Msg = "Shuttle is Assigned and confirmed to Driver (" + driverno.ToStr() + ")";
                                else
                                    Msg = "Shuttle is Assigned  to Driver (" + driverno.ToStr() + ")";


                            }
                            
                            
                            if (cancelJob)
                            {

                                //For TCP Connection
                                if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                                {
                                        new Thread(delegate()
                                        {
                                             General.SendMessageToPDA("request pda=" + oldDriverId + "=" + jobId + "=Cancelled Pre Job>>" + jobId + "=2");
                                     }).Start();  
                                
                                }

                            }

                           
                          


                        }
                        else
                        {

                             ENUtils.ShowMessage("Required: Driver");
                        }
                    }


                }
             
            }
            catch (Exception ex)
            {


            }
        }

        private void RefreshTodayAndPreBookingsDashboard()
        {
            try
            {
                new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_TODAY_AND_PREBOOKING_DASHBOARD);

                // ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard")).RefreshTodayBookingData();
                // dashBoard.LoadDriverWaitingGrid();
            }
            catch (Exception ex)
            {


            }

        }
     
        public  void DisplayRecord()
        {
            try
            {
                if (ObjMaster.Current == null) return;

                ddl_Driver.SelectedValue = ObjMaster.Current.DriverId;

                if (ObjMaster.Current.DriverId != null)
                    chkConfirmed.Checked = true;
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }

        }



        private bool IsDriverDocumentExpired(int driverId,Fleet_Driver ObjDriver)
        {
            bool rtn = false;

            try
            {
               if(ObjDriver==null)
                  ObjDriver = General.GetObject<Fleet_Driver>(c => c.Id == driverId);

                if (ObjDriver != null)
                {


                    string msg = string.Empty;


                    DateTime nowDate = DateTime.Now.ToDate();
                    DateTime? pickupDateTime=ObjMaster.Current.TripDate;



                    if (ObjDriver.MOTExpiryDate != null && (ObjDriver.MOTExpiryDate.ToDate() < nowDate || ObjDriver.MOTExpiryDate.ToDate()< pickupDateTime.ToDate()))
                        {
                           
                          if (ObjDriver.MOTExpiryDate.ToDate() < nowDate)
                            {

                                msg += "Driver MOT Expired :       " + string.Format("{0:dd/MM/yyyy}", ObjDriver.MOTExpiryDate) + Environment.NewLine;
                            }
                          else
                          {
                              msg += "Driver MOT is Expiring at :       " + string.Format("{0:dd/MM/yyyy}", ObjDriver.MOTExpiryDate) + Environment.NewLine;


                          }


                        }
                    if (ObjDriver.MOT2ExpiryDate != null && ObjDriver.MOT2ExpiryDate.ToDate() < nowDate)
                        {

                           // if (ObjDriver.MOT2ExpiryDate.ToDate() < nowDate)
                              msg += "Driver MOT 2 Expired :    " + string.Format("{0:dd/MM/yyyy}", ObjDriver.MOT2ExpiryDate) + Environment.NewLine;
                            //else
                            //    msg += "Driver MOT 2 is Expiring :    " + string.Format("{0:dd/MM/yyyy}", ObjDriver.MOT2ExpiryDate) + Environment.NewLine;

                        }
                     if (ObjDriver.InsuranceExpiryDate != null && (ObjDriver.InsuranceExpiryDate < nowDate || ObjDriver.InsuranceExpiryDate<pickupDateTime))
                        {
                            if (ObjDriver.InsuranceExpiryDate < nowDate)
                             msg += "Insurance Expired :          " + string.Format("{0:dd/MM/yyyy HH:mm}", ObjDriver.InsuranceExpiryDate) + Environment.NewLine;
                            else
                                msg += "Insurance is Expiring at :          " + string.Format("{0:dd/MM/yyyy HH:mm}", ObjDriver.InsuranceExpiryDate) + Environment.NewLine;


                        }

                     if (ObjDriver.PCODriverExpiryDate != null && (ObjDriver.PCODriverExpiryDate.ToDate() < nowDate || ObjDriver.PCODriverExpiryDate.ToDate()< pickupDateTime.ToDate()))
                        {
                            if (ObjDriver.PCODriverExpiryDate.ToDate() < nowDate)
                                 msg += "PCO Driver Expired :       " + string.Format("{0:dd/MM/yyyy}", ObjDriver.PCODriverExpiryDate) + Environment.NewLine;
                            else
                                msg += "PCO Driver is Expiring at :        " + string.Format("{0:dd/MM/yyyy}", ObjDriver.PCODriverExpiryDate) + Environment.NewLine;


                        }

                     if (ObjDriver.PCOVehicleExpiryDate != null &&  (ObjDriver.PCOVehicleExpiryDate.ToDate() < nowDate || ObjDriver.PCOVehicleExpiryDate.ToDate() < pickupDateTime.ToDate()))
                        {
                           if (ObjDriver.PCOVehicleExpiryDate.ToDate() < nowDate)
                               msg += "PCO Vehicle Expired :     " + string.Format("{0:dd/MM/yyyy}", ObjDriver.PCOVehicleExpiryDate) + Environment.NewLine;
                            else
                               msg += "PCO Vehicle is Expiring at :      " + string.Format("{0:dd/MM/yyyy}", ObjDriver.PCOVehicleExpiryDate) + Environment.NewLine;

                        }

                     if (ObjDriver.DrivingLicenseExpiryDate != null && (ObjDriver.DrivingLicenseExpiryDate.ToDate() < nowDate || ObjDriver.DrivingLicenseExpiryDate.ToDate() < pickupDateTime.ToDate()))
                        {
                            if (ObjDriver.DrivingLicenseExpiryDate.ToDate() < nowDate)
                              msg += "Driving License Expired :  " + string.Format("{0:dd/MM/yyyy}", ObjDriver.DrivingLicenseExpiryDate) + Environment.NewLine;
                            else
                                msg += "Driving License is Expiring at :  " + string.Format("{0:dd/MM/yyyy}", ObjDriver.DrivingLicenseExpiryDate) + Environment.NewLine;

                        }

                     if (ObjDriver.RoadTaxiExpiryDate != null && (ObjDriver.RoadTaxiExpiryDate.ToDate() < nowDate || ObjDriver.RoadTaxiExpiryDate.ToDate() < pickupDateTime.ToDate()))
                        {
                            if (ObjDriver.RoadTaxiExpiryDate.ToDate() < nowDate)
                                msg += "Road Tax Expired :            " + string.Format("{0:dd/MM/yyyy}", ObjDriver.RoadTaxiExpiryDate);
                            else
                                msg += "Road Tax is Expiring at :            " + string.Format("{0:dd/MM/yyyy}", ObjDriver.RoadTaxiExpiryDate);

                        }


                        if (!string.IsNullOrEmpty(msg))
                        {
                            msg = "Cannot Allocate Driver" + Environment.NewLine + msg;
                            rtn = true;

                            ENUtils.ShowMessage(msg);
                        }

                      
                   
                }

            }
            catch (Exception ex)
            {


            }

            return rtn;

        }


       

       
    }
}
