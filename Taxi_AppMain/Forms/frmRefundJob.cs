using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Utils;
using Taxi_Model;
using Telerik.WinControls;
using Taxi_BLL;
using System.Threading;
using System.Diagnostics;
using System.IO;
using DotNetCoords;
using System.Xml;
using System.Web.Script.Serialization;

namespace Taxi_AppMain
{
    public partial class frmRefundJob : Form
    {


        private long _JobId;

        public long JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }


        public frmRefundJob(long bookingId)
        {
            
            InitializeComponent();
            this.Load += new EventHandler(frmRefundJob_Load);
            this.JobId = bookingId;
            RenderBookingDetails();

        }


        Booking objBooking = null;
        delegate void UIDel();

        void frmRefundJob_Load(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception ex)
            {


            }
        }


        private void RenderBookingDetails() 
        {
            //numRefundAmount.Visible = false;
            try
            {
                long bookingId = this.JobId;
                Booking BookingObj = null;
                if (bookingId > 0)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        BookingObj = db.Bookings.Where(c => c.Id == bookingId).FirstOrDefault();
                        if (BookingObj != null)
                        {
                            lblBookingRef.Text = BookingObj.BookingNo.ToStr();
                            if (BookingObj?.BookingPayment.TotalAmount > 0)
                            {
                                lblChargeDetails.Text = BookingObj?.BookingPayment.TotalAmount.ToStr();
                                numRefundAmount.Value= Convert.ToDecimal(BookingObj?.BookingPayment.TotalAmount);
                            }
                            else
                            {
                                lblChargeDetails.Text = BookingObj.TotalCharges.ToStr();
                                numRefundAmount.Value = Convert.ToDecimal(BookingObj.TotalCharges);
                            }
                        }
                    }
                   

                }
            }
            catch (Exception ex) 
            {
            }
        
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {

            ProcessRefund();

        }


        private void ProcessRefund()
        {

            long bookingId = this.JobId;
            Booking BookingObj = null;
            decimal ChargedAmmount = 0;

            decimal RefundAmount =  numRefundAmount.Value.ToDecimal();
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    BookingObj = db.Bookings.Where(c => c.Id == bookingId).FirstOrDefault();

                    if (BookingObj.BookingPayment.TotalAmount.ToStr().Length > 0  && BookingObj.BookingPayment.TotalAmount > 0) { ChargedAmmount = BookingObj.BookingPayment.TotalAmount.ToDecimal(); }
                    else { ChargedAmmount = BookingObj.TotalCharges.ToDecimal(); }

                }
                if(BookingObj == null) 
                {
                    ENUtils.ShowMessage("Booking Details is missing!");
                    return;
                }


                if (RefundAmount > ChargedAmmount)
                {
                    ENUtils.ShowMessage("Refund Amount is greater than charged amount!");
                    return;
                }
                if (RefundAmount <= 0)
                {
                    RefundAmount = ChargedAmmount;
                }

                RefundPaymentDto SpDTO = new RefundPaymentDto();

                SpDTO.bookingId = bookingId;
            
                SpDTO.description = "Refund Payment | " + AppVars.objSubCompany.CompanyName.ToStr() + " | " + BookingObj.BookingNo.ToStr() + " | " + "Fares : " + RefundAmount + " GBP";
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";
                SpDTO.amount = (RefundAmount * 100).ToInt(); 
                string sendResponse = SpDTO.RefundPayment(new JavaScriptSerializer().Serialize(SpDTO));


                if (!string.IsNullOrEmpty(sendResponse))
                {
                    ENUtils.ShowMessage(sendResponse.ToStr());
                }

                Close();

            }
            catch (Exception ex)
            {


            }




        }












        private void RefreshBookingList()
        {

            if (Application.OpenForms.OfType<Form>().Count(c => c.Name == "frmBookingsList") > 0)
            {
                (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingsList") as frmBookingsList).SetRefreshWhenActive("");
            }

            // General.RefreshListWithoutSelected<frmBookingsList>("frmBookingsList1");


        }
















    }
}
