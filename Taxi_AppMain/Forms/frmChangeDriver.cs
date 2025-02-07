using System;


using System.Windows.Forms;
using Taxi_BLL;
using Utils;
using Taxi_Model;


namespace Taxi_AppMain
{
    public partial class frmChangeDriver : Form
    {
        BookingBO ObjMaster;
        int IsOpenFrom = 0;
        long allocatedJobId = 0;
     
        public frmChangeDriver(long ID,int openFrom)
        {
            InitializeComponent();
            ObjMaster = new BookingBO();
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

     

        private void Save()
        {
            try
            {
                int defaultAllocationLimit = AppVars.objPolicyConfiguration.AllocateDrvPreExistJobLimit.ToInt();
                int? driverId = ddl_Driver.SelectedValue.ToIntorNull();
                int? oldDriverId = null;
                string oldDriverNo = string.Empty;
                long jobId = 0;
              
                DateTime? pickupDateAndTime=ObjMaster.Current.PickupDateTime.ToDateTimeorNull();


              
                if(driverId==null)
                {
                    MessageBox.Show("Please select a driver");
                    ddl_Driver.Focus();
                    return;

                }

            



               
                    if (ObjMaster.Current != null)
                    {
                       


                            //if ((driverId != null && ObjMaster.Current.DriverId == null) || (driverId!=null && ObjMaster.Current.DriverId!=null && driverId!=ObjMaster.Current.DriverId))
                            //{

                            //   if  (IsDriverDocumentExpired(driverId.ToInt()))
                            //       return;

                            //}


                            if ( ObjMaster.Current.DriverId != null)
                                oldDriverNo = ObjMaster.Current.Fleet_Driver.DriverNo.ToStr();


                            if (ObjMaster.Current.DriverId != null)
                                oldDriverId = ObjMaster.Current.DriverId;


                            ObjMaster.CheckDataValidation = false;

                            ObjMaster.Edit();

                            ObjMaster.Current.DriverId = driverId;





                          
                          


                            jobId = ObjMaster.Current.Id;
                            allocatedJobId = jobId;

                            ObjMaster.CheckCustomerValidation = false;
                            ObjMaster.DisableUpdateReturnJob = true;

                            ObjMaster.Save();


                           

                            this.Close();


                         

                            string Msg = string.Empty;



                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                            db.Booking_Logs.InsertOnSubmit(new Booking_Log { BookingId=ObjMaster.Current.Id, User=AppVars.LoginObj.UserName, BeforeUpdate="Driver : "+ oldDriverNo , AfterUpdate="Driver : " +ObjMaster.Current.Fleet_Driver.DefaultIfEmpty().DriverNo , UpdateDate=DateTime.Now});

                        db.SubmitChanges();

                             

                            }




                           

                           
                          


                       
                       


                    }
             
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
            }

            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }

        }



      

       

       
    }
}
