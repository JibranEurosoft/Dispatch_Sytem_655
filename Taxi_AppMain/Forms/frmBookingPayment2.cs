using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
//using ThePaymentGateway.PaymentSystem;
//using ThePaymentGateway.Common;
using Utils;
using System.Net;
using Taxi_Model;
using System.Web;
using Taxi_AppMain.Forms;
using Taxi_BLL;
using DAL;

using System.IO;

using Taxi_AppMain.Classes;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using StripePayment;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Diagnostics;

namespace Taxi_AppMain
{
    public partial class frmBookingPayment2 : UI.SetupBase
    {
        public decimal NetFares = 0.00m;
        public decimal TotalAmount = 0.00m;

        public string cardTokenDetails = string.Empty;
        public  string TransactionID = string.Empty;
        BookingBO objMaster;
        bool IsSave = false;
        int? ID = 0;
        frmBooking frm = new frmBooking();

        private List<Gen_SysPolicy_PaymentDetail> _ObjMerchantInfo;

        public List<Gen_SysPolicy_PaymentDetail> ObjMerchantInfo
        {
            get { return _ObjMerchantInfo; }
            set { _ObjMerchantInfo = value; }
        }

        private Booking_Payment _ObjPayment;

        public Booking_Payment ObjPayment
        {
            get { return _ObjPayment; }
            set { _ObjPayment = value; }
        }

     

        


        private string _PickedEmail;

        public string PickedEmail
        {
            get { return _PickedEmail; }
            set { _PickedEmail = value; }
        }



        decimal onewayAmount;
        decimal returnAmount;

          public  string customerName;
        public  string customerTel;
       public  string customerMobile;
        public string customerEmail;

        public decimal otherCharges;

        public frmBookingPayment2(Booking_Payment obj, List<Gen_SysPolicy_PaymentDetail> listofMerchant, decimal amount, decimal returnBookingAmount,int journeyTypeId, string BookingNO, int? BookingID, string cardToken,frmBooking2 frmp)
        {
            ID = BookingID;
            cardTokenDetails = cardToken.ToStr();
            InitializeComponent();

            lblBookingID.Text = BookingNO;
            this.ObjPayment = obj;
            this.ObjMerchantInfo = listofMerchant;


            this.parentBooking = frmp;

            objMaster = new BookingBO();

            objMaster.GetByPrimaryKey(BookingID);


            this.SetProperties((INavigation)objMaster);

            txtAmount.Enabled = false;
            numSurchargePercent.Enabled = false;

            if (objPaymentColumns == null)
            {
                objPaymentColumns = General.GetObject<Gen_PaymentColumnSetting>(c => c.Id != 0);

            }

          

            if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN && AppVars.objPolicyConfiguration.BookingFormType.ToInt()==2)
            {
                chkIncludeReturnBooking.Visible = true;


                chkIncludeReturnBooking.ToggleStateChanged += ChkIncludeReturnBooking_ToggleStateChanged;

                //if (objMaster.Current != null && objMaster.Current.BookingReturns.Count > 0 && objMaster.Current.BookingReturns[0].PaymentTypeId.ToInt() == Enums.PAYMENT_TYPES.CREDIT_CARD)
                   
                //{
                //    onewayAmount = amount;
                //    returnAmount = returnBookingAmount;
                //    amount = onewayAmount + returnAmount;
                //    chkIncludeReturnBooking.Checked = false;
                //}

            }

            if (objPaymentColumns != null)
            {

                if (objPaymentColumns.ShowTip.ToBool() == false)
                {
                    numTipAmount.Visible = false;
                    radLabel17.Visible = false;
                    radLabel12.Visible = false;
                }


                if (objMaster.Current != null)
                {

                    if (objPaymentColumns.ChargesType.ToInt() == Enums.PAYMENT_CHARGESTYPE.CHARGESTYPE1)
                    {
                        amount = objMaster.Current.FareRate.ToDecimal() + objMaster.Current.MeetAndGreetCharges.ToDecimal() + objMaster.Current.CongtionCharges.ToDecimal();


                        if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
                        {
                            if (objMaster.Current.BookingReturns.Count > 0)
                            {
                                //returnAmount = objMaster.Current.BookingReturns[0].FareRate.ToDecimal() + objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal();
                                returnAmount = objMaster.Current.BookingReturns[0].FareRate.ToDecimal() + objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal() + objMaster.Current.ExtraDropCharges.ToDecimal();

                            }

                        }

                        if (objMaster.Current.CompanyId != null)
                        {
                            amount = objMaster.Current.CompanyPrice.ToDecimal() + objMaster.Current.WaitingCharges.ToDecimal() + objMaster.Current.ParkingCharges.ToDecimal();


                            if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
                            {
                                if (objMaster.Current.BookingReturns.Count > 0)
                                {
                                    returnAmount = objMaster.Current.BookingReturns[0].CompanyPrice.ToDecimal() + objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal();


                                }

                            }
                        }

                    }
                    else if (objPaymentColumns.ChargesType.ToInt() == Enums.PAYMENT_CHARGESTYPE.CHARGESTYPE2)
                    {


                       

                        //if(amount)
                        //amount = objMaster.Current.FareRate.ToDecimal() + objMaster.Current.MeetAndGreetCharges.ToDecimal() + objMaster.Current.CongtionCharges.ToDecimal()
                        //    +objMaster.Current.ExtraDropCharges.ToDecimal()+objMaster.Current.ServiceCharges.ToDecimal();


                         

                        if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
                        {
                            if (objMaster.Current.BookingReturns.Count > 0)
                            {
                                //returnAmount = objMaster.Current.BookingReturns[0].FareRate.ToDecimal() + objMaster.Current.BookingReturns[0].ServiceCharges.ToDecimal()+ objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal();
                                returnAmount = objMaster.Current.BookingReturns[0].FareRate.ToDecimal() + objMaster.Current.BookingReturns[0].ServiceCharges.ToDecimal() + objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal() + objMaster.Current.ExtraDropCharges.ToDecimal();

                            }

                        }

                        if (objMaster.Current.CompanyId != null)
                        {
                            //amount = objMaster.Current.CompanyPrice.ToDecimal() + objMaster.Current.WaitingCharges.ToDecimal() + objMaster.Current.ParkingCharges.ToDecimal()
                            //     + objMaster.Current.ExtraDropCharges.ToDecimal() + objMaster.Current.ServiceCharges.ToDecimal(); 

                            if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
                            {
                                if (objMaster.Current.BookingReturns.Count > 0)
                                {
                                    returnAmount = objMaster.Current.BookingReturns[0].CompanyPrice.ToDecimal() + objMaster.Current.BookingReturns[0].WaitingCharges.ToDecimal() + objMaster.Current.BookingReturns[0].ParkingCharges.ToDecimal();


                                }

                            }
                        }
                    }
                    else if (objPaymentColumns.ChargesType.ToInt() == Enums.PAYMENT_CHARGESTYPE.CHARGESTYPE3)
                    {

                        amount = objMaster.Current.FareRate.ToDecimal() + objMaster.Current.MeetAndGreetCharges.ToDecimal() + objMaster.Current.CongtionCharges.ToDecimal();

                        if (journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
                        {
                            if (objMaster.Current.BookingReturns.Count > 0)
                            {
                                returnAmount = objMaster.Current.BookingReturns[0].FareRate.ToDecimal() + objMaster.Current.BookingReturns[0].MeetAndGreetCharges.ToDecimal() + objMaster.Current.BookingReturns[0].CongtionCharges.ToDecimal();


                            }

                        }
                    }
                    else if (objPaymentColumns.ChargesType.ToInt() == Enums.PAYMENT_CHARGESTYPE.CHARGESTYPE4)
                    {
                        amount = objMaster.Current.FareRate.ToDecimal();
                        chkIncludeAirportCharges.Visible = true;
                        if (AppVars.objPolicyConfiguration.SendBookingCompletionEmail.ToBool())
                        {

                            if (objMaster.Current.FromLocTypeId.ToInt() == Enums.LOCATION_TYPES.AIRPORT && objMaster.Current.FromLocId != null)
                            {
                                numAirportPickUp.Value = General.GetObject<Gen_SysPolicy_AirportPickupCharge>(c => c.AirportId == objMaster.Current.FromLocId.ToInt()).DefaultIfEmpty().Charges.ToDecimal();
                            }

                            if (objMaster.Current.ToLocTypeId.ToInt() == Enums.LOCATION_TYPES.AIRPORT && objMaster.Current.ToLocId != null)
                            {
                                numAirportDropOf.Value = General.GetObject<Gen_SysPolicy_AirportDropOffCharge>(c => c.AirportId == objMaster.Current.ToLocId.ToInt()).DefaultIfEmpty().Charges.ToDecimal();
                            }
                        }

                    }
                }
                else
                {

                    returnAmount = returnBookingAmount;
                }

            }


            txtAmount.Value = amount.ToDecimal();

            if(onewayAmount==0 && chkIncludeReturnBooking.Checked==false)
            onewayAmount = txtAmount.Value;
            lblSurcharge.Visible = true;
            lblSurcharge2.Visible = true;
            lblSurcharge3.Visible = true;
            numSurchargeAmount.Visible = true;
            numSurchargePercent.Visible = true;


            SetChargesLimit();

            //   numSurchargePercent.Enabled = false;
            numSurchargePercent.Value = 0.00m;

            UpdateSurcharge();


            ComboFunctions.FillDispatchAvailablePaymentGatewayCombo(ddlGateway,c=>c.PaymentGatewayId!=9);
            ComboFunctions.FillCreditCardCombo(ddlCardType);

            ddlGateway.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlGateway_SelectedIndexChanged);
            ddlGateway.SelectedValueChanged += new EventHandler(ddlGateway_SelectedValueChanged);

            this.chkIncludeAirportCharges.ToggleStateChanged += new StateChangedEventHandler(chkIncludeAirportCharges_ToggleStateChanged);
            SetDefaultPaymentGateway();

            txtAmount.SpinElement.TextChanged += new EventHandler(SpinElement_TextChanged);
            numSurchargePercent.SpinElement.TextChanged += new EventHandler(SpinElement_TextChanged);
            numTipAmount.SpinElement.TextChanged += new EventHandler(SpinElement_TextChanged);
            CalculateTotal();

            this.Shown += new EventHandler(frmBookingPayment2_Shown);


            if (obj.PaymentGatewayId != null)
                ddlGateway.SelectedValue = obj.PaymentGatewayId;



            if(AppVars.objPolicyConfiguration.SendDirectBookingConfirmationEmail.ToBool())
            {
              
                    lblNameOnCard.Visible = true;
                    lblReceiptEmail.Visible = true;
                    txtNameOnCard.Visible = true;
                    txtEmailReceipt.Visible = true;
                    txtNameOnCard.Text = objMaster.Current.CustomerName.ToStr();
                    txtEmailReceipt.Text = objMaster.Current.CustomerEmail.ToStr().Trim();
                
            }
            if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO && cardTokenDetails.ToStr().Trim().Length > 0)
            {
                try
                {

                    string[] arr = cardTokenDetails.Split(new string[] { "<<<" }, StringSplitOptions.None);

                    txtCardNumber.Text = "PRE-AUTHORISED CARD - " + arr[3].Split('|')[1].ToStr();
                    txtCardNumber.Tag = cardTokenDetails;

                    txtCardNumber.Enabled = false;
                    dtpExpiryDate.Enabled = false;
                    txtCV2.Enabled = false;
                    txtCV2.Text = "xxx";
                    CheckReceiptId();
                }
                catch
                {

                }
            }


        }

        private void UpdateSurcharge()
        {

            if (AppVars.objPolicyConfiguration.CreditCardChargesType.ToInt() == 1)
            {


                if (chargesLimit != null && chargesLimit.Count() >= 3 && txtAmount.Value > chargesLimit[0].ToDecimal())
                {


                    if (chargesLimit[1].ToInt() == 1)
                    {

                        numSurchargePercent.Value = 0;
                        numSurchargeAmount.Value = chargesLimit[2].ToDecimal();
                       
                    }
                    else if (chargesLimit[1].ToInt() == 2)
                    {
                        //     numSurchargePercent.Enabled = true;
                        numSurchargePercent.Value = chargesLimit[2].ToDecimal();
                        CalculateTotal();
                    }
                }
                else
                {
                    numSurchargePercent.Value = 0;
                    numSurchargeAmount.Value = AppVars.objPolicyConfiguration.CreditCardExtraCharges.ToDecimal();
                }




            }
            else if (AppVars.objPolicyConfiguration.CreditCardChargesType.ToInt() == 2)
            {
                if (chargesLimit != null && chargesLimit.Count() >= 3 && txtAmount.Value > chargesLimit[0].ToDecimal())
                {


                    if (chargesLimit[1].ToInt() == 1)
                    {
                        numSurchargePercent.Value = 0;
                        numSurchargeAmount.Value = chargesLimit[2].ToDecimal();
                    }
                    else if (chargesLimit[1].ToInt() == 2)
                    {
                        //    numSurchargePercent.Enabled = true;
                        numSurchargePercent.Value = chargesLimit[2].ToDecimal();
                        CalculateTotal();
                    }
                }
                else
                {
                    //   numSurchargePercent.Enabled = true;
                    numSurchargePercent.Value = AppVars.objPolicyConfiguration.CreditCardExtraCharges.ToDecimal();
                    CalculateTotal();
                }


            }

        }

        private void ChkIncludeReturnBooking_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
             if(args.ToggleState== Telerik.WinControls.Enumerations.ToggleState.On)
            {
                txtAmount.Value = onewayAmount + returnAmount;

            }

             else
            {
                txtAmount.Value = onewayAmount ;
            }
        }

        private void SetChargesLimit()
        {
            if (chargesLimit == null)
            {
                string charges = AppVars.objPolicyConfiguration.CreditCardExtraChargesLimits.ToStr().Trim();



                if (charges.Length > 0)
                {
                    chargesLimit = charges.Split(new char[] { '|' });
                }
            }

        }

        Gen_PaymentColumnSetting objPaymentColumns = null;

        void ddlGateway_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnRegisterCard.Visible = false;
                if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.ATLANTE_CONNECTPAY || ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO)
                {
                    pnlBilling.Visible = false;
                  //  this.Size = new Size(630, this.Size.Height);
                    lblNameOnCard.Visible = false;
                    txtNameOnCard.Visible = false;

                    lblStartDate.Visible = false;
                    dtpStartDate.Visible = false;

                    if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO)
                        btnRegisterCardBySMS.Visible = true;
                }
                else
                {
                    pnlBilling.Visible = true;
                 //   this.Size = new Size(965, this.Size.Height);
                    lblNameOnCard.Visible = true;
                    txtNameOnCard.Visible = true;
                }


                if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.PAYPAL)
                {
                    //   ObjMerchantInfo[0].PaymentGatewayId = Enums.PAYMENT_GATEWAY.PAYPAL;
                    chkSendEmailtoCustomer.Checked = true;
                    chkSendEmailtoCustomer.Visible = true;

                    ddlCardType.Enabled = false;
                    txtCardNumber.Enabled = false;
                    dtpExpiryDate.Enabled = false;
                    dtpStartDate.Enabled = false;
                    txtCV2.Enabled = false;
                    radButton1.Enabled = false;

                    lblNameOnCard.Text = "Name :";
                }
                else
                {
                    chkSendEmailtoCustomer.Checked = true;
                    chkSendEmailtoCustomer.Visible = false;
                    lblNameOnCard.Text = "Name On Card :";


                    ddlCardType.Enabled = true;
                    txtCardNumber.Enabled = true;
                    dtpExpiryDate.Enabled = true;
                    dtpStartDate.Enabled = true;
                    txtCV2.Enabled = true;
                    radButton1.Enabled = true;

                    if (objMaster != null && objMaster.Current != null)
                    {
                        txtNameOnCard.Text = objMaster.Current.CustomerName.ToStr().Trim();
                    }


                    if (ddlGateway.SelectedValue.ToInt() == 10)
                    {
                        btnSave.Visible = false;

                    }

                    // ObjMerchantInfo[0].PaymentGatewayId = ddlGateway.SelectedValue.ToInt();

                }

                radButton1.Visible = ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO;

                if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO)
                {

                    txtCardNumber.Enabled = false;
                    dtpExpiryDate.Enabled = false;

                    txtCV2.Enabled = false;



                    btnSendJudoPaymentLink.Visible = true;
                    btnSendJudoPaymentLink.Enabled = true;
                    PaymentGatewaySettings objpaymentSettings = null;


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        try
                        {
                            objpaymentSettings = db.ExecuteQuery<PaymentGatewaySettings>("select * from PaymentGatewaySettings where paymentgatewayId=6").FirstOrDefault();
                        }
                        catch
                        {

                        }

                    }

                    if (objpaymentSettings != null)
                    {
                        if (objpaymentSettings != null)
                        {
                            btnpreauthsms.Visible = objpaymentSettings.ShowPreAuthBySMS.ToBool();
                            btnRegisterCardBySMS.Visible = objpaymentSettings.ShowRegisterBySMS.ToBool();


                            btnSendJudoPaymentLink.Items[0].Visibility = objpaymentSettings.ShowPayBySMS.ToBool() ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
                            btnSendJudoPaymentLink.Items[1].Visibility = objpaymentSettings.ShowPayByEmail.ToBool() ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

                            if (btnSendJudoPaymentLink.Items[0].Visibility == Telerik.WinControls.ElementVisibility.Collapsed && btnSendJudoPaymentLink.Items[1].Visibility == Telerik.WinControls.ElementVisibility.Collapsed)
                                btnSendJudoPaymentLink.Visible = false;

                        }
                    }
                }
                //KonnectPay
                if (ddlGateway.SelectedValue.ToInt() == 15)
                {
                    btnsendpaymentlink.Visible = false;
                    btnProcess.Visible = false;
                    if (!string.IsNullOrEmpty(objMaster?.Current?.CustomerCreditCardDetails) && objMaster?.Current?.CustomerCreditCardDetails.ToStr().StartsWith("pi_") == true)
                    {
                        btnsendpaymentlink.Visible = false;


                        rdoPreAuthKP.Visible = true;
                        rdoPreAuthKP.Checked = true;
                        rdoPreAuthKP.BringToFront();
                        rdoPreAuthKP.Enabled = false;
                        rdoPayByLink.Enabled = false;
                        rdoDirectKP.Enabled = false;
                        BtnPreAuthKP.Visible = false;
                        rdoPayByCard.Visible = false;
                        btnRegisterCardKP.Visible = false;
                        btnPaymentWithExisting.Visible = false;
                        btnSendRegisterCardLinkKP.Visible = false;

                        radGroupBoxKP.Visible = true;
                        radGroupBoxKP.BringToFront();
                    }
                    else
                    {
                        btnsendpaymentlink.Visible = false;
                        btnRegisterCardKP.Visible = true;
                        btnPaymentWithExisting.Visible = true;
                        rdoPayByCard.Visible = true;

                        ddlGateway.Enabled = true;
                        rdoPreAuthKP.Enabled = true;
                        rdoPayByLink.Enabled = true;
                        rdoDirectKP.Enabled = true;
                        btnProcess.Visible = false;
                        RenderKOnnectPay(ddlGateway.SelectedValue.ToInt());
                        CheckIfCardIsRegisteredKP();
                    }

                }
                else
                {
                    radGroupBoxKP.Visible = false;
                }

            }
            catch (Exception ex)
            {


            }
        }

        void chkIncludeAirportCharges_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (chkIncludeAirportCharges.Checked)
                {
                    lblAirportDropOf.Visible = true;
                    lblAirportPickUp.Visible = true;
                    numAirportDropOf.Visible = true;
                    numAirportPickUp.Visible = true;
                    radLabel1.Visible = true;
                    radLabel5.Visible = true;
                    numTotalCharges.Value += numAirportPickUp.Value.ToDecimal();
                    numTotalCharges.Value += numAirportDropOf.Value.ToDecimal();
                }
                else
                {
                    lblAirportDropOf.Visible = false;
                    lblAirportPickUp.Visible = false;
                    numAirportDropOf.Visible = false;
                    numAirportPickUp.Visible = false;
                    radLabel1.Visible = false;
                    radLabel5.Visible = false;
                    CalculateTotal();
                }
            }
            catch (Exception ex)
            { }
        }

        void frmBookingPayment2_Shown(object sender, EventArgs e)
        {
            ddlCardType.Focus();
        }



        void SpinElement_TextChanged(object sender, EventArgs e)
        {
            UpdateSurcharge();
            CalculateTotal();


        }

        private void CalculateTotal()
        {


            if (numSurchargePercent.Value > 0)
            {
                numSurchargeAmount.Value = (txtAmount.Value * numSurchargePercent.Value) / 100;
            }

            numTotalCharges.Value = txtAmount.Value + numSurchargeAmount.Value + numTipAmount.Value;

        }




        void ddlGateway_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {


                //if (ddlGateway.SelectedValue.ToInt() == 5)
                //{
                //    pnlBilling.Visible = false;
                //    this.Size = new Size(630, this.Size.Height);
                //    lblNameOnCard.Visible = false;
                //    txtNameOnCard.Visible = false;

                //    lblStartDate.Visible = false;
                //    dtpStartDate.Visible = false;

                //}
                //else
                //{
                //    pnlBilling.Visible = true;
                //    this.Size = new Size(965, this.Size.Height);
                //    lblNameOnCard.Visible = true;
                //    txtNameOnCard.Visible = true;
                //}

            }
            catch (Exception ex)
            {


            }

        }

        private Booking_Payment pickedPaymentObj = null;


        //private void PickCreditCardDetails()
        //{
        //    try
        //    {

        //        string mobileNo = "";
        //        string phoneNo = "";
        //        string email = "";
        //        if (objMaster.Current != null)
        //        {




        //             mobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
        //             phoneNo = objMaster.Current.CustomerPhoneNo.ToStr().Trim();
        //             email = objMaster.Current.CustomerEmail.ToStr().Trim();
        //        }
        //        else
        //        {
        //            mobileNo = customerMobile;
        //            phoneNo = customerTel;
        //            email = customerEmail;


        //        }

        //            using (TaxiDataContext db = new TaxiDataContext())
        //            {
        //                Customer objCust = null;

        //                db.DeferredLoadingEnabled = true;


        //                if (objCust == null && mobileNo.Length > 0)
        //                {
        //                    objCust = db.Customers.Where(c => c.MobileNo == mobileNo 
        //                    && (c.CreditCardDetails!=null && c.CreditCardDetails!="")).FirstOrDefault();

        //                }

        //                if (objCust == null && phoneNo.Length > 0)
        //                {
        //                    objCust = db.Customers.Where(c => c.TelephoneNo == phoneNo
        //                       && (c.CreditCardDetails != null && c.CreditCardDetails != "")).FirstOrDefault();

        //                }


        //                if (objCust == null && email.Length > 0)
        //                {
        //                    objCust = db.Customers.Where(c => c.Email == email
        //                       && (c.CreditCardDetails != null && c.CreditCardDetails != "")).FirstOrDefault();

        //                }


        //                if(objCust!=null)
        //                {
        //                    if (objCust.CreditCardDetails.ToStr().Length>0)
        //                    {
        //                        cardTokenDetails = objCust.CreditCardDetails.ToStr().Trim();

        //                        string[] arr = cardTokenDetails.Split(new string[]{ "<<<"},StringSplitOptions.None);

        //                        txtCardNumber.Text = "PRE-AUTHORISED CARD - " + arr[3].Split('|')[1].ToStr();
        //                        txtCardNumber.Enabled = false;
        //                        dtpExpiryDate.Enabled = false;
        //                        txtCV2.Enabled = false;
        //                        txtCV2.Text = "xxx";
        //                        btnProcessLater.Visible = true;
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Card details not found");

        //                    }

        //                }
        //                else
        //                {

        //                    MessageBox.Show("Card details not found");
        //                }
        //            }

        //    }
        //    catch (Exception ex)
        //    {


        //    }

        //}
        private void PickCreditCardDetails()
        {
            try
            {

                string mobileNo = "";
                string phoneNo = "";
                string email = "";
                if (objMaster.Current != null)
                {




                    mobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                    phoneNo = objMaster.Current.CustomerPhoneNo.ToStr().Trim();
                    email = objMaster.Current.CustomerEmail.ToStr().Trim();
                }
                else
                {
                    mobileNo = customerMobile;
                    phoneNo = customerTel;
                    email = customerEmail;


                }

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    Customer objCust = null;

                    db.DeferredLoadingEnabled = true;


                    if (objCust == null && mobileNo.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.MobileNo == mobileNo
                        && (c.CreditCardDetails != null && c.CreditCardDetails != "")).FirstOrDefault();

                    }

                    if (objCust == null && phoneNo.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.TelephoneNo == phoneNo
                           && (c.CreditCardDetails != null && c.CreditCardDetails != "")).FirstOrDefault();

                    }


                    if (objCust == null && email.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.Email == email
                           && (c.CreditCardDetails != null && c.CreditCardDetails != "")).FirstOrDefault();

                    }



                    if (objCust == null)
                    {
                        var Ids = db.Customers.Where(c => (email.Length > 0 && c.Email == email) || (mobileNo.Length > 0 && c.MobileNo == mobileNo) || (phoneNo.Length > 0 && c.TelephoneNo == phoneNo))

                            .Select(c => c.Id).ToArray<int>();


                        if (Ids.Count() > 0)
                        {
                            string str = "(" + string.Join(",", Ids) + ")";


                            var custIds = db.ExecuteQuery<int>("select CustomerId from  CUSTOMER_ccdetails where customerId in " + str).Distinct().ToList();


                            if (custIds.Count == 0)
                                objCust = null;
                            else
                            {
                                foreach (var item in custIds)
                                {
                                    objCust = db.Customers.FirstOrDefault(c => c.Id == item);

                                    if (objCust != null)
                                        break;

                                }
                            }
                        }

                    }



                    if (objCust != null)
                    {
                        if (objCust.CreditCardDetails.ToStr().Length > 0)
                        {
                            var ccList = db.ExecuteQuery<ClsCCDetails>("select RecordId=Id,CCDetails,IsDefault from  CUSTOMER_ccdetails where customerId=" + objCust.Id).ToList();
                            cardTokenDetails = objCust.CreditCardDetails.ToStr().Trim();

                            if (ccList.Count > 1)
                            {
                                PickCardDetails frm = new PickCardDetails(ccList);
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.ShowDialog();


                                frm.Dispose();


                                if (frm.SelectedCard.ToStr().Trim().Length > 0)
                                {
                                    cardTokenDetails = frm.SelectedCard.ToStr().Trim();


                                }
                            }
                         






                            //   cardTokenDetails = objCust.CreditCardDetails.ToStr().Trim();

                            string[] arr = cardTokenDetails.Split(new string[] { "<<<" }, StringSplitOptions.None);

                            txtCardNumber.Text = "PRE-AUTHORISED CARD - " + arr[3].Split('|')[1].ToStr();
                            txtCardNumber.Tag = cardTokenDetails.ToStr().Trim();
                            txtCardNumber.Enabled = false;
                            dtpExpiryDate.Enabled = false;
                            txtCV2.Enabled = false;
                            txtCV2.Text = "xxx";
                            btnProcessLater.Visible = true;
                            CheckReceiptId();


                        }
                        else
                        {
                            MessageBox.Show("Card details not found");

                        }

                    }
                    else
                    {

                        MessageBox.Show("Card details not found");
                    }
                }

            }
            catch (Exception ex)
            {


            }

        }


        private void PickData()
        {

            if (pickedPaymentObj != null)
            {
                txtAddress.Text = pickedPaymentObj.Address.ToStr().Trim();
                txtCardNumber.Text = pickedPaymentObj.CardNumber.ToStr().Trim();
                txtCity.Text = pickedPaymentObj.City.ToStr().Trim();
                txtCV2.Text = pickedPaymentObj.CV2.ToStr().Trim();
                txtEmail.Text = pickedPaymentObj.Email.ToStr().Trim();
                PickedEmail = txtEmail.Text.Trim();

                txtNameOnCard.Text = pickedPaymentObj.NameOnCard.ToStr().Trim();
                txtPostCode.Text = pickedPaymentObj.PostCode.ToStr().Trim();
                dtpExpiryDate.Value = pickedPaymentObj.CardExpiryDate.Value.ToDateorNull();
                dtpStartDate.Value = pickedPaymentObj.CardStartDate.Value.ToDateorNull();
                ddlCardType.SelectedValue = pickedPaymentObj.CreditCardTypeId.ToIntorNull();


            }

        }


        private void SetDefaultPaymentGateway()
        {
            try
            {
                if (this.ObjMerchantInfo.Count > 0)
                {

                    if (ObjMerchantInfo.Count == 1)
                    {
                        ddlGateway.SelectedValue = ObjMerchantInfo[0].PaymentGatewayId;
                        ddlGateway.Enabled = false;

                    }
                    else
                    {


                        if(ObjMerchantInfo.Count(c=>c.PaymentGatewayId==13)>0)
                            ddlGateway.SelectedValue = ObjMerchantInfo.FirstOrDefault(c => c.PaymentGatewayId==13).DefaultIfEmpty().PaymentGatewayId;
                        else
                        ddlGateway.SelectedValue = ObjMerchantInfo.FirstOrDefault(c => c.EnableMobileIntegration == null || c.EnableMobileIntegration == false).DefaultIfEmpty().PaymentGatewayId;



                        if (ddlGateway.SelectedValue == null)
                            ddlGateway.SelectedValue = ObjMerchantInfo[0].PaymentGatewayId;


                    }



                }
            }
            catch
            {


            }


        }

        string[] chargesLimit = null;

        private void frmBookingPayment_Load(object sender, EventArgs e)
        {
            try
            {

                if (otherCharges > 0)
                    txtAmount.Enabled = false;

                if (ddlGateway.SelectedValue.ToInt() == 15)
                {
                    if (!string.IsNullOrEmpty(objMaster?.Current?.CustomerCreditCardDetails) && objMaster?.Current?.CustomerCreditCardDetails.ToStr().StartsWith("pi_") == true && !objMaster.Current.CustomerCreditCardDetails.ToStr().Trim().Contains("secret_"))
                    {
                        btnProcess.Visible = true;
                        btnProcess.BringToFront();

                        rdoPreAuthKP.Visible = true;
                        rdoPreAuthKP.Checked = true;
                        rdoPreAuthKP.BringToFront();
                        rdoPreAuthKP.Enabled = false;
                        rdoPayByLink.Enabled = false;
                        BtnPreAuthKP.Visible = false;
                        ddlGateway.Enabled = false;
                        radGroupBoxKP.Visible = true;
                        radGroupBoxKP.BringToFront();

                    }
                    else
                    {
                        ddlGateway.Enabled = true;
                        rdoPreAuthKP.Enabled = true;
                        rdoPayByLink.Enabled = true;
                        btnProcess.Visible = false;
                        RenderKOnnectPay(ddlGateway.SelectedValue.ToInt());
                    }
                }
                else
                {

                    if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.STRIPE)
                {

                    Gen_SysPolicy_PaymentDetail objdata = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());

                    if (objdata != null)
                    {
                        if (objdata.ApiCertificate.ToStr() == "1" || objdata.ApiCertificate.ToStr() == "2")
                        {

                            if (objMaster.Current.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || objMaster.Current.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || objMaster.Current.BookingStatusId == Enums.BOOKINGSTATUS.CANCELLED)
                            {
                                pnlBilling.Visible = false;
                                btnProcess.Visible = true;
                                //btnProcessLater.Visible = false;
                                btnsendpaymentlink.Visible = false;
                                btnsendpaymentlink.BringToFront();
                                radGroupBox2.Visible = false;
                                chkIncludeReturnBooking.Visible = false;

                            }
                            else
                            {

                                pnlBilling.Visible = false;
                                btnProcess.Visible = false;
                                btnProcessLater.Visible = false;
                                btnsendpaymentlink.Visible = true;
                                btnsendpaymentlink.BringToFront();
                                radGroupBox2.Visible = false;

                            }
                        }


                    }
                }

                if (this.ObjPayment != null && ObjPayment.Id != 0)
                {
                    if (!string.IsNullOrEmpty(ObjPayment.AuthCode))
                    {
                        SetSuccess();
                        lblStatus.Text = ObjPayment.AuthCode.ToStr();

                        btnProcess.Enabled = false;
                        btnSave.Enabled = false;
                    }


                    if (!string.IsNullOrEmpty(ObjPayment.AuthCode) || ObjPayment.NetFares.ToDecimal() > 0)
                    {

                        txtAmount.Value = ObjPayment.NetFares.ToDecimal();
                        numSurchargePercent.Value = ObjPayment.SurchargePercent.ToDecimal();
                        numSurchargeAmount.Value = ObjPayment.SurchargeAmount.ToDecimal();
                        numTipAmount.Value = ObjPayment.TipAmount.ToDecimal();
                        numTotalCharges.Value = ObjPayment.TotalAmount.ToDecimal();
                    }


                    ddlCardType.SelectedValue = ObjPayment.CreditCardTypeId.ToInt();
                    txtNameOnCard.Text = ObjPayment.NameOnCard.ToStr();

                    if (txtCardNumber.Enabled)
                    {
                        txtCardNumber.Text = ObjPayment.CardNumber.ToStr();
                        dtpExpiryDate.Value = ObjPayment.CardExpiryDate;
                        txtCV2.Text = ObjPayment.CV2.ToStr();

                    }
                    dtpStartDate.Value = ObjPayment.CardStartDate;


                    txtAddress.Text = ObjPayment.Address.ToStr();
                    txtEmail.Text = ObjPayment.Email.ToStr();
                    txtCity.Text = ObjPayment.City.ToStr();
                    txtPostCode.Text = ObjPayment.PostCode.ToStr();

                    if (ObjPayment.PaymentGatewayId == 1)
                        lblStatus.Text = ObjPayment.AuthCode.ToStr();

                    //else
                    //    lblStatus.Text = ObjPayment.Status.ToStr();



                    if (ObjPayment.NameOnCard == null || ObjPayment.CardNumber == null)
                    {
                        PickData();

                    }

                    string bookingEmail = objMaster.Current.CustomerEmail.ToStr();

                    if (string.IsNullOrEmpty(txtEmail.Text) || (!string.IsNullOrEmpty(bookingEmail) && PickedEmail != bookingEmail))
                    {

                        txtEmail.Text = bookingEmail;
                    }
                }
                else
                {

                    if (objMaster.PrimaryKeyValue != null)
                    {

                        string bookingEmail = objMaster.Current.CustomerEmail.ToStr();

                        if (string.IsNullOrEmpty(txtEmail.Text) || (!string.IsNullOrEmpty(bookingEmail) && PickedEmail != bookingEmail))
                        {

                            txtEmail.Text = bookingEmail;
                        }
                    }
                }


                if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.JUDO)
                {
                    txtCardNumber.Enabled = false;
                    dtpExpiryDate.Enabled = false;

                    txtCV2.Enabled = false;
                    btnSendJudoPaymentLink.Visible = true;
                    btnSendJudoPaymentLink.Enabled = true;
                    PaymentGatewaySettings objpaymentSettings = null;


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        try
                        {
                            objpaymentSettings = db.ExecuteQuery<PaymentGatewaySettings>("select * from PaymentGatewaySettings where paymentgatewayId=6").FirstOrDefault();
                        }
                        catch
                        {

                        }

                    }

                    if (objpaymentSettings != null)
                    {
                        if (objpaymentSettings != null)
                        {
                            btnpreauthsms.Visible = objpaymentSettings.ShowPreAuthBySMS.ToBool();
                            btnRegisterCardBySMS.Visible = objpaymentSettings.ShowRegisterBySMS.ToBool();


                            btnSendJudoPaymentLink.Items[0].Visibility = objpaymentSettings.ShowPayBySMS.ToBool() ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
                            btnSendJudoPaymentLink.Items[1].Visibility = objpaymentSettings.ShowPayByEmail.ToBool() ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

                            if (btnSendJudoPaymentLink.Items[0].Visibility == Telerik.WinControls.ElementVisibility.Collapsed && btnSendJudoPaymentLink.Items[1].Visibility == Telerik.WinControls.ElementVisibility.Collapsed)
                                btnSendJudoPaymentLink.Visible = false;

                        }
                    }

                }
            }
            }
            catch (Exception ex)
            {



            }

        }
        public void CheckIfCardIsRegisteredKP()
        {

            List<ClsCCDetails> ccList = new List<ClsCCDetails>();
            int CustomerID = 0;// Convert.ToInt32(objMaster?.Current?.CustomerId);
            Customer Customerobj = null;
            if (objMaster.Current == null)
            {
                long bookingId = objMaster.Current.Id;
                objMaster.GetByPrimaryKey(bookingId);
            }
            if(CustomerID <= 0) 
            {
                Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr() && c.CreditCardDetails!=null && c.CreditCardDetails!="");
                CustomerID = Convert.ToInt32(Customerobj?.Id);
            }

        
            //  if (CustomerID > 0 && ((objMaster?.Current?.Customer?.CreditCardDetails.ToStr().Length > 0 && objMaster.Current.Customer.CreditCardDetails.ToStr().ToLower().StartsWith("cus_")) || (Customerobj?.CreditCardDetails.ToStr().Length > 0 && Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus_"))))
            if (CustomerID > 0 && (Customerobj?.CreditCardDetails.ToStr().Length > 0 && Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus_")))
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    ccList = db.ExecuteQuery<ClsCCDetails>("select RecordId=Id,CCDetails,IsDefault from Customer_CCDetails where customerId=" + CustomerID).ToList();

                }
                if (ccList.Count > 0)
                {

                    TxtAlreadyRegisteredCardKP.Text = "Card is registered for this customer!";
                }
            }



        }
        public void RenderKOnnectPay(int ddlGateway)
        {
            if (ddlGateway == 15)
            {
               // chkIncludeReturnBooking.Checked = false;
                Gen_SysPolicy_PaymentDetail _ObjMerchantInfo = ObjMerchantInfo.Where(a => a.PaymentGatewayId == 15).FirstOrDefault();
                if (_ObjMerchantInfo != null)
                {
                    rdoPreAuthKP.Visible = false;
                    rdoPayByLink.Visible = false;
                    rdoDirectKP.Visible = false;
                    rdoPayByCard.Visible = false;
                    btnRegisterCardKP.Visible = false;
                    btnPaymentWithExisting.Visible = false;

                    string PaymentOptions = _ObjMerchantInfo.MerchantPassword;
                    if (!string.IsNullOrEmpty(PaymentOptions))
                    {
                        var DispatchOpt = PaymentOptions.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
                        if (DispatchOpt.ToStr().Length > 0)
                        {
                            var OptArr = DispatchOpt[1].Split(',');
                            if (OptArr.ToStr().Length > 0)
                            {
                                radGroupBoxKP.Visible = true;
                                foreach (string opt in OptArr)
                                {

                                    if (opt.ToLower().Trim() == "preauthorize" || opt.ToLower().Trim() == "pre authorize")
                                    {
                                        rdoPreAuthKP.Visible = true;
                                        rdoPreAuthKP.Checked = true;
                                        rdoPreAuthKP.BringToFront();
                                        BtnPreAuthKP.Visible = true;
                                        BtnPreAuthKP.BringToFront();


                                    }
                                    else if (opt.ToLower().Trim() == "paybylink" || opt.ToLower().Contains("pay by link"))
                                    {

                                        rdoPayByLink.Visible = true;
                                        rdoPayByLink.BringToFront();

                                        if (!PaymentOptions.ToLower().Contains("pre authorize") && !PaymentOptions.ToLower().Contains("preauthorize"))
                                        {
                                            rdoPayByLink.Checked = true;
                                            BtnPayByLinkKP.Visible = true;
                                            BtnPayByLinkKP.BringToFront();

                                        }
                                    }
                                    else if (opt.ToLower().Trim() == "paynow" || opt.ToLower().Contains("pay now"))
                                    {
                                        rdoDirectKP.Visible = true;
                                        rdoDirectKP.BringToFront();
                                    }
                                    else if (opt.ToLower().Trim() == "paywithcard" || opt.ToLower().Contains("pay with card"))
                                    {
                                        rdoPayByCard.Visible = true;
                                        rdoPayByCard.BringToFront();
                                    }

                                }
                            }
                        }
                    }
                }

            }

        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {
            CloseForms();
        }

        private void CloseForms()
        {

            frm.Close();
            this.Close();

        }

        public string paymentInstructions = "";

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                lblStatus.Text = string.Empty;
                lblStatus.Size = new System.Drawing.Size(lblStatus.Width, 248);
             //   lblResponse.Visible = false;

                //  string authCode = string.Empty;
                DateTime? expiryDate = dtpExpiryDate.Value;
                DateTime? startDate = dtpStartDate.Value;

                string nameOnCard = txtNameOnCard.Text.Trim();
                string cardTypeName = ddlCardType.Text.Trim().ToUpper();
                string cardNumber = txtCardNumber.Text.Trim();

                //  string orderDesc = txtOrderDesc.Text.Trim();

                string cv2 = txtCV2.Text.Trim();

                decimal amount = txtAmount.Text.ToDecimal();

                int? cardTypeId = ddlCardType.SelectedValue.ToIntorNull();

                string email = txtEmail.Text.Trim();

                //     string address = txtAddress.Text.Trim();
                //     string city = txtCity.Text.Trim();

                //     string postcode = txtPostCode.Text.Trim();

                string firstName = string.Empty;
                string lastName = string.Empty;


                if (nameOnCard.WordCount() > 1)
                {
                    firstName = nameOnCard.Split(' ')[0].ToStr();
                    lastName = nameOnCard.Split(' ')[1].ToStr();
                }



                string status = string.Empty;

                string errorMsg = string.Empty;


                if (ddlGateway.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Please select a Payment Gateway");
                    return;

                }


                int ddlGatewayId = ddlGateway.SelectedValue.ToInt();

                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGatewayId);


                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return;
                }



                if (ddlGateway.SelectedValue.ToInt() != Enums.PAYMENT_GATEWAY.ATLANTE_CONNECTPAY)
                {

                    if (txtNameOnCard.Visible)
                    {
                        if (string.IsNullOrEmpty(nameOnCard))
                        {
                            errorMsg += "Required : Name On Card" + Environment.NewLine;
                        }
                    }

                    //if (ddlCardType.SelectedValue.ToIntorNull() == null && chkSendEmailtoCustomer.Checked == false)
                    //{
                    //    errorMsg += "Required : Name On Card" + Environment.NewLine;

                    //}

                    //if (string.IsNullOrEmpty(cardNumber) && chkSendEmailtoCustomer.Checked == false)
                    //{
                    //    errorMsg += "Required : Card Type" + Environment.NewLine;
                    //}

                }

                if (string.IsNullOrEmpty(cv2) && chkSendEmailtoCustomer.Checked == false)
                {
                    errorMsg += "Required : CV2" + Environment.NewLine;
                }

                if (expiryDate == null && chkSendEmailtoCustomer.Checked == false)
                {
                    errorMsg += "Required : Expiry Date" + Environment.NewLine;
                }

                //if (dtpStartDate.Visible && startDate == null && chkSendEmailtoCustomer.Checked == false)
                //{
                //    errorMsg += "Required : Start Date" + Environment.NewLine;
                //}




                //if (dtpStartDate.Visible == true && startDate != null && expiryDate != null && expiryDate < startDate && chkSendEmailtoCustomer.Checked == false)
                //{
                //    errorMsg += "Required : Start Date cannot be greater than Expiry Date" + Environment.NewLine;
                //}


                if (!string.IsNullOrEmpty(errorMsg))
                {
                    ENUtils.ShowMessage(errorMsg);
                    return;

                }


                btnSave.Enabled = true;



                if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.CARDSAVE)
                {

                 
                }
                else if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.PAYPAL)
                {
                    string Address = txtAddress.Text.ToStr().Trim();
                    string PostCode = txtPostCode.Text.ToStr().Trim();
                    string City = txtCity.Text.ToStr().Trim();
                    string Email = txtEmail.Text.ToStr().Trim();
                    string Error = string.Empty;
                    if (string.IsNullOrEmpty(Address))
                    {
                        Error = "Required : Address";
                    }
                    if (string.IsNullOrEmpty(PostCode))
                    {
                        if (string.IsNullOrEmpty(Error))
                        {
                            Error = "Required : Post Code";
                        }
                        else
                        {
                            Error += Environment.NewLine + "Required : Post Code";
                        }
                    }
                    if (string.IsNullOrEmpty(City))
                    {
                        if (string.IsNullOrEmpty(Error))
                        {
                            Error = "Required : City";
                        }
                        else
                        {
                            Error += Environment.NewLine + "Required : City";
                        }
                    }
                    if (string.IsNullOrEmpty(Email))
                    {
                        if (string.IsNullOrEmpty(Error))
                        {
                            Error = "Required : Email";
                        }
                        else
                        {
                            Error += Environment.NewLine + "Required : Email";
                        }
                    }
                    if (!string.IsNullOrEmpty(Error))
                    {
                        ENUtils.ShowMessage(Error);
                        return;
                    }





                    string PaypalID = obj.PaypalID.ToStr();


                    int check = string.IsNullOrEmpty(obj.ApiCertificate) ? 2 : obj.ApiCertificate.ToInt();

                    //

                    string SubComapnyName = AppVars.objSubCompany.CompanyName;
                    StringBuilder sb = new StringBuilder();
                    decimal fares = numTotalCharges.Value.ToDecimal();
                    //  decimal parkingCharges = obj.CongtionCharges.ToDecimal();
                    //if (objMaster.Current.CompanyId != null)
                    //{
                    //    fares = objMaster.Current.CompanyPrice.ToDecimal();
                    //    //   parkingCharges = obj.ParkingCharges.ToDecimal();


                    //}


                    decimal total = 0.00m;


                    total = fares;

                    sb.Append("<html><head></head>");
                    // sb.Append("<style> table { table-layout:fixed;}table td { width: 100%;  overflow: hidden;  text-overflow: ellipsis;}</style>");
                    sb.Append("<body>");
                    sb.Append("<table style= width: 100%;\"font-family:Arial;font-size:14px;color:#222;line-height:20px;border-collapse:collapse;border:1px solid #e5e5e5;\" cellpadding=\"5\" cellspacing=\"5\" border=\"0\" >");



                    sb.Append("<tr>");
                    sb.Append("<td style=\"text-align:left;\">");
                    //  sb.Append("");
                    sb.Append("<img src='http://images.paypal.com/en_US/i/logo/paypal_logo.gif'/>");
                    sb.Append("</td>");
                    sb.Append("</tr>");


                    sb.Append("<tr>");
                    sb.Append("<td style=\"text-align:center;\" colspan=\"2\">");
                    sb.Append("<img src='" + AppVars.objSubCompany.CompanyLogoOnlinePath.ToStr().Trim() + "' />"); // pinkapplelogo
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td colspan=\"2\">");
                    //sb.Append("If you wish to book a return or onward journey please always call office.Don't book " +
                    //         "with Driver directly as it is illegal and not covered by insurance.");
                    //sb.Append("</td>");

                    //sb.Append("</tr>");
                    //
                    sb.Append("<tr>");
                    sb.Append("<td style=\"text-align:center;\">");
                    //  sb.Append("");
                    sb.Append("<b>*** This is an automated Email *** </b>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    //  sb.Append("");
                    sb.Append("Hello,");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("You have received this email on behalf of (" + SubComapnyName + "), who has set up a payment of " + string.Format("{0:f2}", total) + " GBP for you to complete. <br/> This payment can be completed by clicking the link below.");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("The reference for this transaction is: " + SubComapnyName);
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Please click on the following link to complete this payment: ");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    //
                    string businesspaypalid = PaypalID;
                    string redirect = "";
                    if (check == 1)
                    {
                        redirect += "https://www.sandbox.paypal.com/us/cgi-bin/webscr?cmd=_xclick&business=" + businesspaypalid;
                    }
                    else
                    {
                        redirect += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + businesspaypalid;
                    }


                    redirect += "&item_name=Booking";
                    redirect += "&amount=" + Math.Round(numTotalCharges.Value, 2);
                    redirect += "&item_number=" + objMaster.Current.BookingNo.ToStr();
                    redirect += "&amp;currency_code=GBP";
                    redirect += "&first_name=" + firstName;
                    redirect += "&last_name=" + lastName;
                    redirect += "&address1=" + txtAddress.Text;
                    redirect += "&email=" + txtEmail.Text;
                    redirect += "&city=" + txtCity.Text;
                    redirect += "&night_phone_a=12345";
                    redirect += "&night_phone_b=00";
                    redirect += "&night_phone_c=12345";
                    redirect += "&zip=" + txtPostCode.Text;
                    redirect += "&state=" + txtPostCode.Text;
                    redirect += "&country=london";
                    sb.Append("<tr>");
                    sb.Append("<td><p style='width:50%;'>");
                    sb.Append("<a href='" + redirect + "'>" + redirect + "</a>");
                    sb.Append("</p></td>");
                    sb.Append("</tr>");
                    //

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("You will be directed to a payment form which will be pre populated with the transaction details. We will notify the merchant when the payment has been completed.");

                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("The full details of this payment are:");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");

                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Amount: " + string.Format("{0:f2}", total) + " GBP");

                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Reference: " + objMaster.Current.BookingNo);

                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Description: " + objMaster.Current.BookingNo + " , Pickup at: " + string.Format("{0:dd/MM/yyyy HH:mm}", objMaster.Current.PickupDateTime));
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Thank you,");

                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");

                    sb.Append(" </body></html>");

                    //

                    //string businesspaypalid = PaypalID;
                    //string redirect = "";
                    //if (check == 1)
                    //{
                    //    redirect += "https://www.sandbox.paypal.com/us/cgi-bin/webscr?cmd=_xclick&business=" + businesspaypalid;
                    //}
                    //else
                    //{
                    //    redirect += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + businesspaypalid;
                    //}


                    //redirect += "&item_name=Booking";
                    //redirect += "&amount=" + Math.Round(numTotalCharges.Value, 2);
                    //redirect += "&item_number=1";
                    //redirect += "&currency_code=GBP";
                    //redirect += "&first_name=" + firstName;
                    //redirect += "&last_name=" + lastName;
                    //redirect += "&address1=" + txtAddress.Text;
                    //redirect += "&email=" + txtEmail.Text;
                    //redirect += "&city=" + txtCity.Text;
                    //redirect += "&night_phone_a=12345";
                    //redirect += "&night_phone_b=00";
                    //redirect += "&night_phone_c=12345";
                    //redirect += "&zip=" + txtPostCode.Text;
                    //redirect += "&state=" + txtPostCode.Text;
                    //redirect += "&country=london";

                    if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.PAYPAL && chkSendEmailtoCustomer.Checked)
                    {
                        string smtpHost = string.Empty;
                        string userName = string.Empty;
                        string pwd = string.Empty;
                        string port = string.Empty;
                        bool enableSSL = false;
                        Gen_SubCompany objSubCompany = AppVars.objSubCompany;

                        if (objSubCompany != null && !string.IsNullOrEmpty(objSubCompany.SmtpHost.ToStr().Trim()))
                        {
                            smtpHost = objSubCompany.SmtpHost.ToStr().Trim();
                            userName = objSubCompany.SmtpUserName.ToStr().Trim();
                            pwd = objSubCompany.SmtpPassword.ToStr().Trim();
                            port = objSubCompany.SmtpPort.ToStr().Trim();
                            enableSSL = objSubCompany.SmtpHasSSL.ToBool();
                        }

                        using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
                        {
                            msg.To.Add(txtEmail.Text.ToStr().Trim());
                            msg.From = new System.Net.Mail.MailAddress(userName, AppVars.objSubCompany.CompanyName.ToStr());
                            // msg.Subject = "Make payment with Paypal for booking Ref # " + objMaster.Current.BookingNo+ " PickUp Date Time: " +string.Format("{0:dd/MM/yyyy HH:mm}", objMaster.Current.PickupDateTime);
                            msg.Subject = "PayPal payment request from " + SubComapnyName + " .Please make payment to " + SubComapnyName + " via Paypal for booking Ref# " + objMaster.Current.BookingNo + " PickUp Date Time: " + string.Format("{0:dd/MM/yyyy HH:mm}", objMaster.Current.PickupDateTime) + ".";


                            //msg.Body = redirect;
                            msg.Body = sb.ToStr();

                            //   msg.BodyEncoding = System.Text.Encoding.UTF8;
                            msg.IsBodyHtml = true;



                            //    msg.Priority = System.Net.Mail.MailPriority.High;
                            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpHost, Convert.ToInt32(port));
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential(userName, pwd);
                            client.Port = Convert.ToInt32(port);
                            client.Host = smtpHost;
                            client.EnableSsl = enableSSL;


                            ServicePointManager.ServerCertificateValidationCallback =
                                delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                         System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                                { return true; };


                            client.Send(msg);

                            General.SaveSentEmail(msg.Body, msg.Subject, txtEmail.Text.ToStr().Trim());

                        }

                        Save();

                        RadDesktopAlert alert = new RadDesktopAlert();
                        alert.CaptionText = "Email sent successfully";
                        alert.ContentText = "Paypal Link";
                        alert.ContentImage = Resources.Resource1.email;
                        alert.Show();

                        if (this.IsSave)
                        {

                            Close();
                        }
                        else
                            return;
                    }
                    else
                    {
                        frmPaypalPayment Pay = new frmPaypalPayment(redirect.ToStr());
                        Pay.Show();
                    }

                }


                else if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.WORLDPAY)
                {
                    ENUtils.ShowMessage("After Payment Process You Need To save Customer data!");
                    // Live instId = 316579

                    string redirect = "https://select.worldpay.com/wcc/purchase?";



                    redirect += "instId=" + obj.PaypalID.ToStr();
                    redirect += "&cartId=" + objMaster.Current.BookingNo.ToStr();
                    redirect += "&amount=" + numTotalCharges.Value;
                    redirect += "&currency=GBP";
                    redirect += "&desc=" + objMaster.Current.BookingNo.ToStr();
                    redirect += "&name=" + this.objMaster.Current.CustomerName.ToStr();
                    redirect += "&address1=" + txtAddress.Text.ToUpper().Trim();
                    redirect += "&town=" + txtCity.Text.Trim();
                    redirect += "&postcode=" + txtPostCode.Text.Trim();
                    redirect += "&cardtype=Visa";

                    redirect += "&country=GB";
                    redirect += "&email=" + txtEmail.Text;




                    frmPaypalPayment Pay = new frmPaypalPayment(redirect.ToStr());
                    Pay.Show();
                }
                else if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.BARCLAY)
                {
                    ENUtils.ShowMessage("After Payment Process You Need To save Customer data!");

                    string redirect = obj.ApplicationId.ToStr() + "?";

                    redirect += "PSPID=" + obj.PaypalID.ToStr();
                    redirect += "&ORDERID=" + objMaster.Current.BookingNo.ToStr();
                    redirect += "&AMOUNT=" + numTotalCharges.Value;
                    redirect += "&CURRENCY=GBP";
                    redirect += "&LANGUAGE=en_US";
                    redirect += "&CN=" + nameOnCard;
                    redirect += "&EMAIL=" + txtEmail.Text;


                    frmPaypalPayment Pay = new frmPaypalPayment(redirect.ToStr());
                    Pay.Show();

                }
                //else if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.ATLANTE_CONNECTPAY)
                //{
                //    try
                //    {


                //        Taxi_AppMain.ClsPaymentGatewayRequest.CardDetailsEx objCard = new Taxi_AppMain.ClsPaymentGatewayRequest.CardDetailsEx();
                //        objCard.amount = Convert.ToDouble(numTotalCharges.Value);
                //        objCard.cardNumber = cardNumber;
                //        objCard.expiryMonth = dtpExpiryDate.Value.Value.Month.ToStr();
                //        objCard.expiryYear = dtpExpiryDate.Value.Value.Year.ToStr();
                //        objCard.cv2 = cv2;
                //        objCard.signature = obj.ApplicationId.ToStr();
                //        objCard.paymentgateway = "Adlante";
                //        objCard.merchantid = obj.MerchantID.ToStr();
                //        objCard.merchantpassword = obj.MerchantPassword.ToStr();
                //        // objCard.responselog = true;
                //        string json = Newtonsoft.Json.JsonConvert.SerializeObject(objCard);

                //        ClsPaymentGatewayRequest cls = new ClsPaymentGatewayRequest();

                //        var response = cls.MakePayment("MakePaymentByGatewayDispatch", json, "softeuroconnskey");

                //        if (response.Contains("{"))
                //        {


                //            Taxi_AppMain.ClsPaymentGatewayRequest.ClsPaymentGatewayResponse objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Taxi_AppMain.ClsPaymentGatewayRequest.ClsPaymentGatewayResponse>(response);


                //            if (objResponse != null)
                //            {




                //                if (objResponse.success)
                //                {


                //                    txtAmount.Enabled = false;
                //                    numSurchargePercent.Enabled = false;

                //                    lblResponse.Visible = true;



                //                    lblStatus.Text = "AuthCode:" + objResponse.AuthCode;
                //                    TransactionID = lblStatus.Text;
                //                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + objCard.amount + Environment.NewLine + "Auth Code: " + objResponse.AuthCode.ToStr();


                //                    try
                //                    {
                //                        responseLog = lblStatus.Text + " (Payment From Dispatch)";
                //                        lblResponse.Text = responseLog;


                //                        //if (optFirst.Checked)
                //                        //    PaymentFor = 1;
                //                        //else if (optReturnOnly.Checked)
                //                        //    PaymentFor = 2;
                //                        //else if (optBothJourneys.Checked)
                //                        //    PaymentFor = 3;

                //                    }
                //                    catch
                //                    {


                //                    }

                //                    //  responseLog = objResponse.Message + Environment.NewLine + "AuthCode:" + objResponse.AuthCode + Environment.NewLine + "Amount:" + objCard.amount;
                //                    Save();
                //                    //  responseLog = string.Empty;
                //                }
                //                else
                //                {
                //                    responseLog = "";
                //                    lblStatus.Text = objResponse.Message.ToStr();


                //                }
                //            }
                //        }
                //        else
                //        {
                //            lblStatus.Text = "";

                //        }


                //    }
                //    catch (Exception ex)
                //    {
                //        lblStatus.Text = "exception" + ex.ToString();
                //    }
                //}
                else if (ddlGateway.SelectedValue.ToInt() == Enums.PAYMENT_GATEWAY.STRIPE)
                {
                    try
                    {
                        string response = string.Empty;


                        //if(System.Diagnostics.Debugger.IsAttached)
                        //    obj.ApiUsername= "aaghakhan310@gmail.com";


                        if (obj.ApplicationId.ToStr().Length > 0)
                        {


                            if (obj.ApiCertificate.ToStr() == "1")
                            {
                                string json = string.Empty;
                                try
                                {

                                    decimal total = numTotalCharges.Value;

                                    Stripe3DS st = new Stripe3DS();
                                    int amount2 = Math.Round((total * 100), 0).ToInt();


                                    st.Amount = amount2.ToInt();

                                    st.Description = "Booking Ref : " + objMaster.Current.BookingNo.ToStr();
                                    st.Currency = "GBP";
                                    st.APIkey = obj.ApplicationId.ToStr();
                                    st.APISecret = obj.PaypalID.ToStr();
                                    st.BookingId = objMaster.Current.Id.ToStr();
                                    st.MobileNo = "";
                                    st.Email = "";
                                    st.paymentIntentId = objMaster.Current.CustomerCreditCardDetails.ToStr();
                                    st.status = objMaster.Current.CompanyCreditCardDetails.ToStr();


                                    json = Newtonsoft.Json.JsonConvert.SerializeObject(st);


                                    using (var client = new HttpClient())
                                    {
                                        var BASE_URL = "https://api-eurosofttech.co.uk/StripePayment-api/";
                                        client.BaseAddress = new Uri(BASE_URL);
                                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                                        var postTask = client.PostAsync(BASE_URL + "PaymentProcess?data=" + json, null).Result;
                                        response = postTask.Content.ReadAsStringAsync().Result;
                                        //  var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                                        st = new JavaScriptSerializer().Deserialize<Stripe3DS>(response);

                                    }



                                    if (st.IsSuccess)
                                    {


                                        lblResponse.ForeColor = Color.Green;
                                        lblResponse.Visible = true;
                                        txtAmount.Enabled = false;
                                        numSurchargePercent.Enabled = false;


                                        lblStatus.Text = "AuthCode:" + st.paymentIntentId.ToStr();
                                        TransactionID = lblStatus.Text;


                                        responseLog = "Auth Code:" + st.paymentIntentId.ToStr() + Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", numTotalCharges.Value);

                                        paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", numTotalCharges.Value) + Environment.NewLine + "TransactionID: " + st.paymentIntentId.ToStr();


                                        try
                                        {
                                            lblResponse.Text = Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", numTotalCharges.Value);

                                            responseLog += " (Payment From Dispatch)";



                                        }
                                        catch
                                        {


                                        }

                                        Save();
                                        responseLog = string.Empty;
                                        Close();
                                    }
                                    else
                                    {
                                        SetFailure();
                                        responseLog = "";
                                        lblStatus.Text = st.Message.ToStr();



                                    }


                                }
                                catch (Exception ex)
                                {
                                    SetFailure();
                                    responseLog = "";
                                    lblStatus.Text = ex.Message;
                                }

                            }

                            else
                            {
                                ClsStripeRequest.CardDetailsEx objCard = new ClsStripeRequest.CardDetailsEx();
                                objCard.amount = Convert.ToInt32(numTotalCharges.Value) * 100;
                                objCard.RecieptemailAddress = obj.ApplicationId;
                                //"reciept@eurosofttech.co.uk";
                                objCard.customerEmailAddress = customerEmail.ToStr();
                                objCard.currency = "gbp";
                                objCard.cardNumber = cardNumber;
                                objCard.expiryMonth = dtpExpiryDate.Value.Value.Month.ToStr();
                                objCard.expiryYear = dtpExpiryDate.Value.Value.Year.ToStr();
                                objCard.cv2 = cv2;
                                objCard.merchantid = obj.PaypalID;
                                //  "sk_test_51Hf0xFDMZa2vEGS69WRAcWNotl6M1UdTmK8K3LFFoqXGjGLjo1fsb3Fx6MX8B83mTMt0vUEt3X9WoqiRLZdXdjal00ni00E4zE";




                                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objCard);

                                using (WebClient webClient = new WebClient())
                                {

                                    webClient.Proxy = null;
                                    response = webClient.DownloadString("http://eurosofttech-api.co.uk/StripeDirectPaymentAPI/api/gateway/MakePaymentByGatewayDispatch?json=" + json);

                                }
                            }
                            //    response = new WebClient().DownloadString("http://eurosofttech-api.co.uk/StripeDirectPaymentAPI/api/gateway/MakePaymentByGatewayDispatch?json=" + json);
                        }
                        else
                        {

                            Taxi_AppMain.ClsPaymentGatewayRequest.CardDetailsEx objCard = new Taxi_AppMain.ClsPaymentGatewayRequest.CardDetailsEx();
                            objCard.amount = Convert.ToDouble(numTotalCharges.Value);
                            objCard.cardNumber = cardNumber;
                            objCard.expiryMonth = dtpExpiryDate.Value.Value.Month.ToStr();
                            objCard.expiryYear = dtpExpiryDate.Value.Value.Year.ToStr();
                            objCard.cv2 = cv2;
                            objCard.signature = obj.PaypalID;
                            objCard.paymentgateway = "Stripe";


                            string json = Newtonsoft.Json.JsonConvert.SerializeObject(objCard);

                            ClsPaymentGatewayRequest cls = new ClsPaymentGatewayRequest();
                            response = cls.MakePayment("MakePaymentByGatewayDispatch", json, "softeuroconnskey");
                        }
                        if (response.Contains("{"))
                        {
                            Taxi_AppMain.ClsPaymentGatewayRequest.ClsPaymentGatewayResponse objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Taxi_AppMain.ClsPaymentGatewayRequest.ClsPaymentGatewayResponse>(response);


                            if (objResponse != null)
                            {



                                lblResponse.Text = objResponse.Message;
                                if (objResponse.success)
                                {
                                    lblResponse.ForeColor = Color.Green;
                                    lblResponse.Visible = true;
                                    txtAmount.Enabled = false;
                                    numSurchargePercent.Enabled = false;


                                    lblStatus.Text = "AuthCode:" + objResponse.AuthCode;
                                    TransactionID = lblStatus.Text;


                                    responseLog = objResponse.Message + Environment.NewLine + "Auth Code:" + objResponse.AuthCode + Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", numTotalCharges.Value);

                                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", numTotalCharges.Value) + Environment.NewLine + "Auth Code: " + objResponse.AuthCode.ToStr();


                                    try
                                    {
                                        //  responseLog = lblStatus.Text + " (Payment From Dispatch)";
                                        lblResponse.Text = objResponse.Message + Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", numTotalCharges.Value);

                                        responseLog += " (Payment From Dispatch)";



                                    }
                                    catch
                                    {


                                    }

                                    Save();
                                    responseLog = string.Empty;
                                }
                                else
                                {
                                    lblResponse.ForeColor = Color.Red;

                                }


                            }
                        }
                        else
                        {
                            lblResponse.Text = response;

                        }



                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "exception" + ex.ToString();
                    }
                }
                else if (obj.PaymentGatewayId.ToInt() == Enums.PAYMENT_GATEWAY.JUDO)
                {
                  


                        if(  txtCardNumber.Text.ToStr().ToUpper().StartsWith("PRE-AUTHORISED CARD"))
                        {
                            cardTokenDetails = txtCardNumber.Tag.ToStr();

                        }

                        if (cardTokenDetails.ToStr().Trim().Length > 0)
                        {
                          string res=   JudoPay(false, true);
                        

                            if ((res.ToStr().ToLower().StartsWith("success")))
                            {
                                SetSuccess();
                                lblResponse.Visible = false;



                                string[] details = null;

                                if(res.Contains(":"))
                                details= res.Split(':');


                                if (details != null)
                                    lblStatus.Text = details[0].ToStr() + ":" + details[1].ToStr();
                                else
                                    lblStatus.Text = res;


                            // lblStatus.Text = "AuthCode:" + objResponse.AuthCode;
                            try
                            {
                                TransactionID = lblStatus.Text;
                                responseLog = res.ToStr().Replace(" ", "").Trim() + " (Payment From Dispatch)";
                                lblResponse.Text = responseLog;

                                if (details != null)
                                {
                                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", details[2].ToStr()) + Environment.NewLine + details[1].ToStr();
                                    responseLog = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", details[2].ToStr()) + Environment.NewLine +"ReceiptID: "+ details[1].ToStr()+Environment.NewLine+"Last Four: "+ details[3].ToStr()+Environment.NewLine+ "(Payment From Dispatch)";
                                }
                                else
                                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + res;

                            }
                            catch
                            {


                            }
                                

                                btnProcess.Enabled = false;
                                btnProcessLater.Visible = false;
                                Save();
                               
                            }
                            else
                            {
                                SetFailure();
                                responseLog = "";
                                lblStatus.Text = res;


                            }
                        }
                        else
                        {



                            string paymentlink = JudoPay(false).ToStr().Trim();
                            paymentlink = paymentlink.Replace("\"", "").Trim();
                            if (paymentlink.StartsWith("true:"))
                            {

                                paymentlink = paymentlink.Replace("true:", "").ToStr().Trim();
                                string transactionId = string.Empty;
                                frmPaypalPayment Pay = new frmPaypalPayment(paymentlink.ToStr());
                                Pay.ShowDialog();


                                transactionId = Pay.TransactionId.ToStr().Trim();                        
                               

                                Pay.Dispose();

                                if (transactionId.Length > 0 && TransactionID.ToStr().ToLower().Contains("failed:") == false)
                                    transactionId = "success:" + transactionId;

                                if ((transactionId.ToStr().ToLower().StartsWith("success")))
                                {
                                    SetSuccess();
                                    lblResponse.Visible = false;



                                    string[] details = transactionId.Split(':');


                                    lblStatus.Text = details[0].ToStr() + ":" + details[1].ToStr();

                                    // lblStatus.Text = "AuthCode:" + objResponse.AuthCode;
                                    try
                                    {
                                        TransactionID = lblStatus.Text;
                                        responseLog = transactionId.ToStr().Replace(" ", "").Trim() + " (Payment From Dispatch)";
                                        lblResponse.Text = responseLog;
                                        paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", details[2].ToStr()) + Environment.NewLine + details[1].ToStr();

                                    }
                                    catch
                                    {


                                    }


                                    btnProcess.Enabled = false;
                                    btnProcessLater.Visible = false;
                                    Save();
                                    //  responseLog = string.Empty;
                                }
                                else
                                {
                                    SetFailure();
                                    responseLog = "";
                                    lblStatus.Text = transactionId;


                                }

                            }
                        }


                  
               

                }
                else if (ddlGateway.SelectedValue.ToInt() == 9) // SUMUP
                {

                    try
                    {

                      
                        SumupPaymentRequest obje = new SumupPaymentRequest();
                        obje.PaymentGatewayId = 9;
                        obje.RequestMode = "Live";
                        obje.GateWayCredentials.ClientID = obj.MerchantID;
                        obje.GateWayCredentials.ClientSecret = obj.MerchantPassword;
            
                        obje.CheckoutsData.JobId = objMaster.Current.Id.ToInt();
                        obje.CheckoutsData.amount = numTotalCharges.Value;
                        obje.CheckoutsData.currency = "GBP";
                        obje.CheckoutsData.pay_to_email = txtEmail.Text;
                        obje.CheckoutsData.description = "Payment for booking ref:"+ objMaster.Current.BookingNo.ToStr();

                        obje.PaymentData.payment_type = "card";
                        obje.PaymentData.card = new card { cvv = txtCV2.Text.Trim(), expiry_month = string.Format("{0:MM}", dtpExpiryDate.Value.ToDate()), expiry_year = string.Format("{0:yy}", dtpExpiryDate.Value.ToDate()), number = txtCardNumber.Text.Trim(), name = txtNameOnCard.Text.Trim() };

                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(obje);

                        PaymentGatewayResponse<SummupCardPaymentResponse> PaymentResponse = MakePaymentBuSumup(json);

                        if (PaymentResponse.ResponseData != null && PaymentResponse.ResponseData.Transaction_Id != null)
                        {
                            lblStatus.Text = PaymentResponse.ResponseData.Transaction_Id;
                        }

                        if (PaymentResponse.ResponseText.ToStr() == "PAID")
                        {




                            SetSuccess();
                            lblResponse.Visible = false;

                            lblStatus.Text = "authcode:" + PaymentResponse.ResponseData.Transaction_Id;
                       

                            try
                            {
                                TransactionID = lblStatus.Text;
                                responseLog = lblStatus.Text + " (Payment From Dispatch)";
                                lblResponse.Text = responseLog;
                                paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", numTotalCharges.Value) + Environment.NewLine + lblStatus.Text.Trim();

                            }
                            catch
                            {


                            }
                            Save();

                        }
                        else
                        {
                            SetFailure();
                            responseLog = "";
                            lblStatus.Text = "Payment Failed";


                        }
                    }
                    catch(Exception ex)
                    {
                        SetFailure();
                        responseLog = "";
                        lblStatus.Text = ex.Message;


                    }

                }

                else if (ddlGateway.SelectedValue.ToInt() == 10)
				{
					//ENUtils.ShowMessage("After Payment Process You Need To save Customer data!");
					// Live instId = 316579

					//string redirect = fillInfotest(); //test
					string redirect = fillInfo(obj); //live

					frmPaypalPayment Pay = new frmPaypalPayment(redirect.ToStr());					
					Pay.Show();
				}


                else if (ddlGateway.SelectedValue.ToInt() ==11) // HIPPS PAYMENT
                {

                    try
                    {

                        string orderNo = string.Empty;
                        orderNo = Guid.NewGuid().ToStr();
                     
                        
                        HipPayments h = new HipPayments();

                        h.cardnumber = cardNumber;
                        h.exp_month = string.Format("{0:MM}", expiryDate);
                        h.exp_year = string.Format("{0:yy}", expiryDate);
                        h.cvc = cv2;
                        h.CustomerName = customerName;
                        h.CustomerEmail = customerEmail;


                        if(h.CustomerEmail.ToStr().Trim()==string.Empty)
                        {
                            if (txtEmail.Text.Trim().Length == 0)
                            {

                                MessageBox.Show("Required : Email");
                                txtEmail.Focus();
                                return;
                            }
                            else
                                h.CustomerEmail = txtEmail.Text;


                        }

                        h.amount = (Convert.ToInt32(amount) * 100);
                        h.purchase_currency = "GBP";
                        h.merchant_order_id = orderNo;//Guid.NewGuid().ToString();//txt_merchant_order_id.Text.ToString();
                        h.privateKey = obj.PaypalID.ToStr().Trim();
                        var response = h.Payment(obj.ApiCertificate.ToStr()=="1"?true:false);




                        try
                        {

                           

                            HipPaymentResponse objCls = Newtonsoft.Json.JsonConvert.DeserializeObject<HipPaymentResponse>(response);

                            if (webBrowser1 == null)
                                webBrowser1 = new Gecko.GeckoWebBrowser();

                            webBrowser1.Navigate(objCls.preflight.redirect_user_to_url);
                            OrderID = objCls.order_id;
                            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted1;


                            if ((objCls.status.ToStr().ToLower() == "successful"))
                            {
                                SetSuccess();
                                lblResponse.Visible = false;

                               // lblStatus.Text ="Payment successfull"+Environment.NewLine+ objCls.order_id.ToStr().Trim();


                                 lblStatus.Text = "AuthCode:" + objCls.order_id.ToStr().Trim();
                                try
                                {
                                    TransactionID = objCls.order_id;
                                    responseLog = objCls.order_id.ToStr().Replace(" ", "").Trim() + " (Payment From Dispatch)";
                                    lblResponse.Text = responseLog;
                                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + objCls.amount_formatted+ Environment.NewLine +"AuthCode: "+ objCls.order_id.ToStr().Replace(" ", "").Trim();

                                }
                                catch
                                {


                                }
                              
                                btnProcess.Enabled = false;
                                btnProcessLater.Visible = false;
                                Save();
                               
                            }
                            else
                            {
                                SetFailure();
                                responseLog = "";
                                lblStatus.Text = objCls.status.ToStr() + Environment.NewLine +objCls.decline_reason.ToStr();


                            }
                        }
                        catch
                        {
                            lblStatus.Text = "Payment Failed." + Environment.NewLine + "Please check the card details";
                            SetFailure();
                        }

                        //if (PaymentResponse.ResponseData != null && PaymentResponse.ResponseData.Transaction_Id != null)
                        //{
                        //    lblStatus.Text = PaymentResponse.ResponseData.Transaction_Id;
                        //}

                        //if (response..ResponseText.ToStr() == "PAID")
                        //{




                        //    SetSuccess();
                        //    lblResponse.Visible = false;

                        //    lblStatus.Text = "authcode:" + PaymentResponse.ResponseData.Transaction_Id;


                        //    try
                        //    {
                        //        TransactionID = lblStatus.Text;
                        //        responseLog = lblStatus.Text + " (Payment From Dispatch)";
                        //        lblResponse.Text = responseLog;
                        //        paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", numTotalCharges.Value) + Environment.NewLine + lblStatus.Text.Trim();

                        //    }
                        //    catch
                        //    {


                        //    }
                        //    Save();

                        //}
                        //else
                        //{
                        //    SetFailure();
                        //    responseLog = "";
                        //    lblStatus.Text = "Payment Failed";


                        //}
                    }
                    catch (Exception ex)
                    {
                        SetFailure();
                        responseLog = "";
                        lblStatus.Text = ex.Message;


                    }

                }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }

        }

        private void WebBrowser1_DocumentCompleted1(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            HipPayments h = new HipPayments();
            if (e.Uri == webBrowser1.Document.Url)
            {
                if (e.Uri == new Uri("https://www.securesuite.co.uk/barclays/tdsecure/intro.jsp"))
                {
                    string data = h.GetPaymentStatus(OrderID);
                }


            }
        }

      

        string OrderID = string.Empty;
      
        Gecko.GeckoWebBrowser webBrowser1;

        public PaymentGatewayResponse<SummupCardPaymentResponse> MakePaymentBuSumup(string paymentJson)
        {
            try
            {
                PaymentGatewayResponse<SummupCardPaymentResponse> responseData = new PaymentGatewayResponse<SummupCardPaymentResponse>();
                string url = "https://www.eurosofttech-api.co.uk/paymentgateway/api/gateway/MakePayment";
                string actiontype = "POST";

                using (WebClient client = new WebClient())
                {
                    client.Proxy = null;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string result = Convert.ToString(client.UploadString(url, actiontype, paymentJson));

                    responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentGatewayResponse<SummupCardPaymentResponse>>(result);

                }


                return responseData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string fillInfo(Gen_SysPolicy_PaymentDetail obj)
		{

			CardStreamSettings cardStreamSettings = new CardStreamSettings();
			cardStreamSettings.merchantId = obj.PaypalID.ToStr();
			cardStreamSettings.action = "SALE";
			cardStreamSettings.transType = 1;
			cardStreamSettings.uniqueIdentifier = Guid.NewGuid().ToString();
			cardStreamSettings.currencyCode = 826;
			cardStreamSettings.amount = Math.Round(numTotalCharges.Value.ToDecimal(),2); // VISA
			cardStreamSettings.orderRef = objMaster.Current.Id.ToStr() + "|" + objMaster.Current.BookingNo.ToStr();
			cardStreamSettings.cardNumber = txtCardNumber.Text; // VISA
			cardStreamSettings.cardExpiryMM = dtpExpiryDate.Value.Value.Month.ToStr();
			cardStreamSettings.cardExpiryYY = dtpExpiryDate.Value.Value.ToString("yy");
			cardStreamSettings.cardCVV = txtCV2.Text;
			cardStreamSettings.customerName = this.objMaster.Current.CustomerName.ToStr(); // VISA
			cardStreamSettings.customerEmail = txtEmail.Text;
			cardStreamSettings.customerPhone = objMaster.Current.CustomerMobileNo;
			cardStreamSettings.customerAddress = txtAddress.Text.ToUpper().Trim();
			cardStreamSettings.countryCode = 826;
			cardStreamSettings.customerPostcode = txtPostCode.Text.Trim();

			JavaScriptSerializer cc = new JavaScriptSerializer();
			string data = Cryptography.Encrypt(cc.Serialize(cardStreamSettings), "softeuroconnskey", true);
			var url = "https://eurosofttech-api.co.uk/cardstream/Default.aspx?data=" + HttpUtility.UrlEncode(data);

			return url;

		}

		private string fillInfotest()
		{
			CardStreamSettings cardStreamSettings = new CardStreamSettings();
			cardStreamSettings.merchantId = "100001";
			cardStreamSettings.action = "SALE";
			cardStreamSettings.transType = 1;
			cardStreamSettings.uniqueIdentifier = Guid.NewGuid().ToString();
			cardStreamSettings.currencyCode = 826;
			cardStreamSettings.amount = 1202; // VISA
			cardStreamSettings.orderRef = objMaster.Current.Id.ToStr() + "|" + objMaster.Current.BookingNo.ToStr();
			cardStreamSettings.cardNumber = "4012010000000000009"; // VISA
			cardStreamSettings.cardExpiryMM = "12";
			cardStreamSettings.cardExpiryYY = "19";
			cardStreamSettings.cardCVV = "332";
			cardStreamSettings.customerName = "CardStream"; // VISA
			cardStreamSettings.customerEmail = "solutions@cardstream.com";
			cardStreamSettings.customerPhone = "+44(0)8450099575";
			cardStreamSettings.customerAddress = "31 Test Card Street";
			cardStreamSettings.countryCode = 826;
			cardStreamSettings.customerPostcode = "1TEST8";

			JavaScriptSerializer cc = new JavaScriptSerializer();
			string data = Cryptography.Encrypt(cc.Serialize(cardStreamSettings), "softeuroconnskey", true);
			var url = "http://88.208.220.41/cardstream/Default.aspx?data=" + HttpUtility.UrlEncode(data);

			return url;

		}

        private bool IsProcessed = false;

		public string responseLog = string.Empty;

        public override void Save()
        {
            try
            {
                if (EmailReceipt == false)
                {
                    if (AppVars.objPolicyConfiguration.SendDirectBookingConfirmationEmail.ToBool())
                    {
                       

                            if (DialogResult.Yes == MessageBox.Show("Do you want to Send Email Receipt?"))
                            {
                                if (txtEmailReceipt.Text.Trim().Length == 0 && txtNameOnCard.Text.Trim().Length == 0)
                                {
                                    MessageBox.Show("Required : Email and Name On Card");
                                    return;

                                }



                            }
                       
                    }
                }



                if (objMaster.PrimaryKeyValue == null)
                {
                    ObjPayment = new Booking_Payment();
                    ObjPayment.NameOnCard = txtNameOnCard.Text.Trim();
                    ObjPayment.CardNumber = txtCardNumber.Text.Trim();
                    ObjPayment.CardExpiryDate = dtpExpiryDate.Value.ToDateorNull();


                    if (dtpStartDate.Visible)
                    {
                        ObjPayment.CardStartDate = dtpStartDate.Value.ToDateorNull();
                    }
                    else
                    {
                        ObjPayment.CardStartDate = dtpExpiryDate.Value.ToDateorNull();

                    }

                    ObjPayment.CV2 = txtCV2.Text.ToString();
                    ObjPayment.CreditCardTypeId = ddlCardType.SelectedValue.ToIntorNull();

                    //Customer Detail

                    ObjPayment.Status = "Paid";
                    // objMaster.Current.BookingPayment.OrderDescription = txtOrderDesc.Text.Trim();
                    ObjPayment.Address = txtAddress.Text.Trim();
                    ObjPayment.City = txtCity.Text.Trim();
                    ObjPayment.PostCode = txtPostCode.Text.Trim();
                    ObjPayment.Email = txtEmail.Text.Trim();


                    if (lblStatus.Text.ToStr().ToLower().Contains("authcode:"))
                    {
                        string PI = lblStatus.Text.ToStr().Contains("authcode:") ? lblStatus.Text.ToStr().Replace("authcode:", "").Trim() : "";
                        if (string.IsNullOrEmpty(PI))
                        {
                            PI = lblStatus.Text.ToStr().Contains("AuthCode:") ? lblStatus.Text.ToStr().Replace("AuthCode:", "").Trim() : "";
                        }
                        ObjPayment.AuthCode = PI;
                    }
                    // ObjPayment.AuthCode = lblStatus.Text.ToStr().ToLower().Contains("authcode:") ? lblStatus.Text.ToStr().ToLower().Replace("authcode:", "").Trim() : "";

                    if (lblStatus.Text.ToStr().ToLower().Contains("success:"))
                        ObjPayment.AuthCode = lblStatus.Text.ToStr().Contains("success:") ? lblStatus.Text.ToStr().Replace("success:", "").Trim() : "";


                    //  ObjPayment.AuthCode = lblStatus.Text.ToStr().ToLower().Contains("authcode:") ? lblStatus.Text.ToStr().ToLower().Replace("authcode:", "").Trim() : "";
                    ObjPayment.PaymentGatewayId = ddlGateway.SelectedValue.ToIntorNull();

                    ObjPayment.NetFares = txtAmount.Value;
                    NetFares = txtAmount.Value;
                    ObjPayment.SurchargePercent = numSurchargePercent.Value;
                    ObjPayment.SurchargeAmount = numSurchargeAmount.Value;
                    ObjPayment.TipAmount = numTipAmount.Value;
                    ObjPayment.TotalAmount = numTotalCharges.Value;
                    TotalAmount = numTotalCharges.Value;




                  //  objMaster.Current.PaymentComments = objMaster.Current.PaymentComments.ToStr().Trim().Length > 0 ? Environment.NewLine + "AUTH CODE :" + objMaster.Current.BookingPayment.AuthCode.ToStr() : objMaster.Current.BookingPayment.AuthCode.ToStr();



                    //if (responseLog.ToStr().Trim().Length > 0)
                    //{
                    //    objMaster.Current.Booking_Logs.Add(new Booking_Log { BookingId = objMaster.Current.Id, User = AppVars.LoginObj.LoginName, AfterUpdate = responseLog, UpdateDate = DateTime.Now });
                    //}
                }
                else
                {

                    objMaster.PrimaryKeyValue = ID;
                    if (objMaster.PrimaryKeyValue == null)
                    {
                        objMaster.New();
                    }
                    else
                    {
                        objMaster.Edit();
                    }

                    //card Detail

                    if(objMaster.Current.BookingPayment==null)
                    {
                        objMaster.Current.BookingPayment = new Booking_Payment();
                    }

                    objMaster.Current.BookingPayment.NameOnCard = txtNameOnCard.Text.Trim();
                    objMaster.Current.BookingPayment.CardNumber = txtCardNumber.Text.Trim();
                    objMaster.Current.BookingPayment.CardExpiryDate = dtpExpiryDate.Value.ToDateorNull();


                    if (dtpStartDate.Visible)
                    {
                        objMaster.Current.BookingPayment.CardStartDate = dtpStartDate.Value.ToDateorNull();
                    }
                    else
                    {
                        objMaster.Current.BookingPayment.CardStartDate = dtpExpiryDate.Value.ToDateorNull();

                    }

                    objMaster.Current.BookingPayment.CV2 = txtCV2.Text.ToString();
                    objMaster.Current.BookingPayment.CreditCardTypeId = ddlCardType.SelectedValue.ToIntorNull();

                    //Customer Detail
                    objMaster.Current.BookingPayment.BookingId = ID.ToInt();
                    objMaster.Current.BookingPayment.Status = "Paid";
                    // objMaster.Current.BookingPayment.OrderDescription = txtOrderDesc.Text.Trim();
                    objMaster.Current.BookingPayment.Address = txtAddress.Text.Trim();
                    objMaster.Current.BookingPayment.City = txtCity.Text.Trim();
                    objMaster.Current.BookingPayment.PostCode = txtPostCode.Text.Trim();
                    objMaster.Current.BookingPayment.Email = txtEmail.Text.Trim();

                    // objMaster.Current.BookingPayment.AuthCode = lblStatus.Text.ToStr().ToLower().Contains("authcode:") ? lblStatus.Text.ToStr().ToLower().Replace("authcode:", "").Trim() : "";
                    if (lblStatus.Text.ToStr().ToLower().Contains("authcode:"))
                    {
                        string PI = lblStatus.Text.ToStr().Contains("authcode:") ? lblStatus.Text.ToStr().Replace("authcode:", "").Trim() : "";
                        if (string.IsNullOrEmpty(PI))
                        {
                            PI = lblStatus.Text.ToStr().Contains("AuthCode:") ? lblStatus.Text.ToStr().Replace("AuthCode:", "").Trim() : "";
                        }
                        objMaster.Current.BookingPayment.AuthCode = PI;
                    }


                    if (lblStatus.Text.ToStr().ToLower().Contains("success:"))
                    objMaster.Current.BookingPayment.AuthCode = lblStatus.Text.ToStr().ToLower().Contains("success:") ? lblStatus.Text.ToStr().ToLower().Replace("success:", "").Trim() : "";




                    objMaster.Current.BookingPayment.CardStartDate = DateTime.Now;

                    objMaster.Current.BookingPayment.PaymentGatewayId = ddlGateway.SelectedValue.ToIntorNull();

                    objMaster.Current.BookingPayment.NetFares = txtAmount.Value;
                    NetFares = txtAmount.Value;
                    objMaster.Current.BookingPayment.SurchargePercent = numSurchargePercent.Value;
                    objMaster.Current.BookingPayment.SurchargeAmount = numSurchargeAmount.Value;
                    objMaster.Current.BookingPayment.TipAmount = numTipAmount.Value;
                    objMaster.Current.BookingPayment.TotalAmount = numTotalCharges.Value;
                    TotalAmount = numTotalCharges.Value;



                  if(ddlGateway.SelectedValue.ToInt()==Enums.PAYMENT_GATEWAY.STRIPE && objMaster.Current.CompanyCreditCardDetails.ToStr().Trim().Length>0)
                    {
                        objMaster.Current.PaymentComments = objMaster.Current.PaymentComments.ToStr().Trim().Length > 0 ? Environment.NewLine + "TransactionID :" + objMaster.Current.BookingPayment.AuthCode.ToStr() : objMaster.Current.BookingPayment.AuthCode.ToStr();

                    }
                    else
                    objMaster.Current.PaymentComments = objMaster.Current.PaymentComments.ToStr().Trim().Length > 0 ? Environment.NewLine + "AUTH CODE :" + objMaster.Current.BookingPayment.AuthCode.ToStr() : objMaster.Current.BookingPayment.AuthCode.ToStr();



                    if (responseLog.ToStr().Trim().Length > 0)
                    {

                       if(IsProcessed == false)
                        objMaster.Current.Booking_Logs.Add(new Booking_Log { BookingId = objMaster.Current.Id, User = AppVars.LoginObj.LoginName, AfterUpdate = responseLog, UpdateDate = DateTime.Now });


                        if (objMaster.Current.BookingPayment.AuthCode.ToStr().Trim().Length > 0)
                            IsProcessed = true;

                      
                    }

                    objMaster.Save();


                    if (EmailReceipt == false)
                    {

                        if (AppVars.objPolicyConfiguration.SendDirectBookingConfirmationEmail.ToBool())
                        {




                            EmailReceipt = true;
                            SendReceipt();

                        }


                    }

                }

                IsSave = true;

            }
            catch (Exception ex)
            {
                IsSave = false;
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
            }
        }


        private void CheckReceiptId()
        {

            if (txtCardNumber.Tag.ToStr().Trim().Length > 0)
            {

                if (txtCardNumber.Tag.ToStr().Trim().ToLower().Contains("receiptid"))
                {



                    errorProvider1.Icon = Resources.Resource1.verified2;
                    errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    errorProvider1.SetError(txtCardNumber, "");


                }
                else
                {

                    errorProvider1.Icon = Resources.Resource1.warning;
                    errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    errorProvider1.SetError(txtCardNumber, "This card is not registered with SCA Standard");
                }


            }


        }


        private void SendReceipt()
        {
            try
            {

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var list = db.Vu_BookingDetails.Where(c => c.Id == objMaster.Current.Id || c.MasterJobId == objMaster.Current.Id).ToList();
                    UM_Form_Template objReport = General.GetObject<UM_Form_Template>(c => c.UM_Form.FormName == "rptfrmJobDetails" && c.IsDefault == true);
                    rptfrmJobDetails frm = null;
                    rptfrmJobDetails2 frm2 = null;
                    rptfrmJobDetails3 frm3 = null;
                    rptfrmJobDetails4 frm4 = null;
                    if (objReport != null)
                    {
                        switch (objReport.TemplateValue)
                        {
                            case "rptfrmJobDetails":
                                frm = new rptfrmJobDetails();
                                frm.DataSource = list;
                                frm.GenerateReport();
                                frm.SendEmail(objMaster.Current.BookingNo, txtEmailReceipt.Text);

                                frm.Dispose();
                                GC.Collect();
                                break;


                            case "rptfrmJobDetails2":
                                frm2 = new rptfrmJobDetails2();
                                frm2.DataSource = list;
                                frm2.GenerateReport();
                                frm2.SendEmail(objMaster.Current.BookingNo, txtEmailReceipt.Text);

                                frm2.Dispose();
                                GC.Collect();
                                break;
                            case "rptfrmJobDetails3":
                                frm3 = new rptfrmJobDetails3();
                                frm3.DataSource = list;
                                frm3.GenerateReport();
                                frm3.SendEmail(objMaster.Current.BookingNo, txtEmailReceipt.Text);

                                frm3.Dispose();
                                GC.Collect();
                                break;


                            case "rptfrmJobDetails4":
                                frm4 = new rptfrmJobDetails4();
                                frm4.DataSource = list;
                                frm4.GenerateReport();
                                frm4.SendEmail(objMaster.Current.BookingNo, txtEmailReceipt.Text);

                                frm4.Dispose();
                                GC.Collect();
                                break;

                        }
                    }










                }




            }
            catch
            {

            }
        }


            

        private bool EmailReceipt;
        
        public override void AddNew()
        {
            OnNew();
        }

        public override void OnNew()
        {

        }







        private void SetFailure()
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Font = new Font("Tahoma", 10, FontStyle.Bold);

        }


        private void SetSuccess()
        {

            lblStatus.ForeColor = Color.Green;
            lblStatus.Font = new Font("Tahoma", 12, FontStyle.Bold);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (IsSave == true)
            {
                CloseForms();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            PickCreditCardDetails();
           
        }

        private void chkSendEmailtoCustomer_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkSendEmailtoCustomer.Checked)
            {
                ddlCardType.Enabled = false;
                txtCardNumber.Enabled = false;
                dtpExpiryDate.Enabled = false;
                dtpStartDate.Enabled = false;
                txtCV2.Enabled = false;
                radButton1.Enabled = false;
            }
            else
            {
                ddlCardType.Enabled = true;
                txtCardNumber.Enabled = true;
                dtpExpiryDate.Enabled = true;
                dtpStartDate.Enabled = true;
                txtCV2.Enabled = true;
                radButton1.Enabled = true;

            }
        }

        //private void btnRegisterCard_Click(object sender, EventArgs e)
        //{

        //    try
        //    {


        //        string name = this.customerName.ToStr().Trim();
        //        string mobileNo = "";
        //        string phoneNo = "";
        //        string email = "";
        //        if (objMaster.Current != null)
        //        {




        //            mobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
        //            phoneNo = objMaster.Current.CustomerPhoneNo.ToStr().Trim();
        //            email = objMaster.Current.CustomerEmail.ToStr().Trim();
        //        }
        //        else
        //        {
        //            mobileNo = customerMobile;
        //            phoneNo = customerTel;
        //            email = customerEmail;


        //        }


        //        if (mobileNo.Length==0 && phoneNo.Length==0)
        //        {
        //            MessageBox.Show("Required : Customer Contact No");
        //            return;

        //        }
        //        if(txtCardNumber.Text.ToUpper().Contains("PRE-AUTHORISED CARD"))
        //        {
        //            MessageBox.Show("Card already registered");
        //            return;

        //        }
        //        using (TaxiDataContext db = new TaxiDataContext())
        //        {
        //            Customer objCust = null;

        //            db.DeferredLoadingEnabled = true;


        //            if (objCust == null && mobileNo.Length > 0)
        //            {
        //                objCust = db.Customers.Where(c => c.MobileNo == mobileNo
        //                ).FirstOrDefault();

        //            }

        //            if (objCust == null && phoneNo.Length > 0)
        //            {
        //                objCust = db.Customers.Where(c => c.TelephoneNo == phoneNo
        //                  ).FirstOrDefault();

        //            }


        //            if (objCust == null && email.Length > 0)
        //            {
        //                objCust = db.Customers.Where(c => c.Email == email
        //                   ).FirstOrDefault();

        //            }



        //            var objJudo = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == 6);

        //            string url = "http://shadowcars.co.uk/api/jobs/Judo_RegisterCard?jsonString={0}";
        //            Taxi_AppMain_Judo.JudoProperties obj = new Taxi_AppMain_Judo.JudoProperties();
        //            obj.Acc_SecretKey = objJudo.MerchantID.ToStr();
        //            obj.Acc_Token = objJudo.MerchantPassword.ToStr();
        //            obj.judoId = objJudo.PaypalID;
        //            obj.cardNumber = txtCardNumber.Text.Replace(" ", "").Trim();
        //            obj.currency = "GBP";
        //            obj.cv2 = txtCV2.Text.Trim();
        //            obj.expiryDate = string.Format("{0:MM}", dtpExpiryDate.Value.ToDate()) + "/" + string.Format("{0:yy}", dtpExpiryDate.Value.ToDate()); // 1220
        //            obj.yourConsumerReference = Guid.NewGuid().ToString();
        //            obj.yourPaymentReference = Guid.NewGuid().ToString();
        //            obj.amount = 1.00;
        //            // serialize into json string
        //            var json = JsonConvert.SerializeObject(obj);
        //            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(url, json));
        //            httpWebRequest.ContentType = "application/json";
        //            httpWebRequest.Method = "GET";
        //            httpWebRequest.Proxy = null;
        //            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //            {
        //                var result = streamReader.ReadToEnd();
        //                ClsCardToken cmr = JsonConvert.DeserializeObject<ClsCardToken>(result);
        //                if (cmr != null)
        //                {
        //                    if (cmr.Result.ToStr().ToLower()=="success" && cmr.CardDetails.CardToken != string.Empty)
        //                    {

        //                        MessageBox.Show("Card registered successfully!");



        //                        if(objCust==null)
        //                        {
        //                            objCust = new Customer();
        //                            objCust.Name = name;

        //                            if (objCust.Name.ToStr().Length == 0)
        //                                objCust.Name = "PASSENGER";

        //                            objCust.MobileNo = mobileNo;
        //                            objCust.TelephoneNo = customerTel;
        //                            objCust.Email = email;

        //                        }
        //                        objCust.CreditCardDetails = "Token|" + cmr.CardDetails.CardToken.ToStr() +
        //                                                    "<<<consumer|" + cmr.Consumer.YourConsumerReference.ToStr() +
        //                                                    "<<<consumertoken|" + cmr.Consumer.ConsumerToken.ToStr() +
        //                                                    "<<<lastfour|" + cmr.CardDetails.CardLastfour.ToStr() +
        //                                                    "<<<enddate|" + cmr.CardDetails.EndDate.ToStr();

        //                        cardTokenDetails = objCust.CreditCardDetails.ToStr();


        //                        if (objCust.Id == 0)
        //                        {
        //                            db.Customers.InsertOnSubmit(objCust);


        //                        }
        //                        db.SubmitChanges();


        //                        if ( cardTokenDetails.ToStr().Trim().Length > 0)
        //                        {
        //                            txtCardNumber.Text = "PRE-AUTHORISED CARD - "+ cmr.CardDetails.CardLastfour.ToStr();
        //                            txtCardNumber.Enabled = false;
        //                            dtpExpiryDate.Enabled = false;
        //                            txtCV2.Enabled = false;
        //                            txtCV2.Text = "xxx";
        //                            btnProcessLater.Visible = true;
        //                        }

        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Registration Failed!"+Environment.NewLine+ cmr.Message.ToStr());
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Invalid card details");
        //                }
        //            }
        //        }

        //    }
        //    catch
        //    {


        //    }
        //}

        private void btnRegisterCard_Click(object sender, EventArgs e)
        {

            try
            {


                string name = this.customerName.ToStr().Trim();
                string mobileNo = "";
                string phoneNo = "";
                string email = "";
                if (objMaster.Current != null)
                {




                    mobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                    phoneNo = objMaster.Current.CustomerPhoneNo.ToStr().Trim();
                    email = objMaster.Current.CustomerEmail.ToStr().Trim();
                }
                else
                {
                    mobileNo = customerMobile;
                    phoneNo = customerTel;
                    email = customerEmail;


                }


                if (mobileNo.Length == 0 && phoneNo.Length == 0)
                {
                    MessageBox.Show("Required : Customer Contact No");
                    return;

                }
                if (txtCardNumber.Text.ToUpper().Contains("PRE-AUTHORISED CARD"))
                {
                    MessageBox.Show("Card already registered");
                    return;

                }
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    Customer objCust = null;

                    db.DeferredLoadingEnabled = true;


                    if (objCust == null && mobileNo.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.MobileNo == mobileNo
                        ).FirstOrDefault();

                    }

                    if (objCust == null && phoneNo.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.TelephoneNo == phoneNo
                          ).FirstOrDefault();

                    }


                    if (objCust == null && email.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.Email == email
                           ).FirstOrDefault();

                    }



                    var objJudo = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == 6);

                    string url = "http://shadowcars.co.uk/api/jobs/Judo_RegisterCard?jsonString={0}";
                    Taxi_AppMain_Judo.JudoProperties obj = new Taxi_AppMain_Judo.JudoProperties();
                    obj.Acc_SecretKey = objJudo.MerchantID.ToStr();
                    obj.Acc_Token = objJudo.MerchantPassword.ToStr();
                    obj.judoId = objJudo.PaypalID;
                    obj.cardNumber = txtCardNumber.Text.Replace(" ", "").Trim();
                    obj.currency = "GBP";
                    obj.cv2 = txtCV2.Text.Trim();
                    obj.expiryDate = string.Format("{0:MM}", dtpExpiryDate.Value.ToDate()) + "/" + string.Format("{0:yy}", dtpExpiryDate.Value.ToDate()); // 1220
                    obj.yourConsumerReference = Guid.NewGuid().ToString();
                    obj.yourPaymentReference = Guid.NewGuid().ToString();
                    obj.amount = 1.00;
                    // serialize into json string
                    var json = JsonConvert.SerializeObject(obj);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(url, json));
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "GET";
                    httpWebRequest.Proxy = null;
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        ClsCardToken cmr = JsonConvert.DeserializeObject<ClsCardToken>(result);
                        if (cmr != null)
                        {
                            if (cmr.Result.ToStr().ToLower() == "success" && cmr.CardDetails.CardToken != string.Empty)
                            {

                                MessageBox.Show("Card registered successfully!");



                                bool IsNewCard = true;

                                if (objCust == null)
                                {
                                    objCust = new Customer();
                                    objCust.Name = name;

                                    if (objCust.Name.ToStr().Length == 0)
                                        objCust.Name = "PASSENGER";

                                    objCust.MobileNo = mobileNo;
                                    objCust.TelephoneNo = customerTel;
                                    objCust.Email = email;

                                }

                                if (objCust.CreditCardDetails.ToStr().Trim().Length > 0)
                                    IsNewCard = false;


                                objCust.CreditCardDetails = "Token|" + cmr.CardDetails.CardToken.ToStr() +
                                                            "<<<consumer|" + cmr.Consumer.YourConsumerReference.ToStr() +
                                                            "<<<consumertoken|" + cmr.Consumer.ConsumerToken.ToStr() +
                                                            "<<<lastfour|" + cmr.CardDetails.CardLastfour.ToStr() +
                                                            "<<<enddate|" + cmr.CardDetails.EndDate.ToStr();

                                cardTokenDetails = objCust.CreditCardDetails.ToStr();


                                if (objCust.Id == 0)
                                {
                                    db.Customers.InsertOnSubmit(objCust);


                                }
                                db.SubmitChanges();


                                if (cardTokenDetails.ToStr().Trim().Length > 0)
                                {
                                    txtCardNumber.Text = "PRE-AUTHORISED CARD - " + cmr.CardDetails.CardLastfour.ToStr();
                                    txtCardNumber.Tag = cardTokenDetails;
                                    txtCardNumber.Enabled = false;
                                    dtpExpiryDate.Enabled = false;
                                    txtCV2.Enabled = false;
                                    txtCV2.Text = "xxx";
                                    btnProcessLater.Visible = true;
                                }
                                else
                                    txtCardNumber.Tag = null;


                                try
                                {



                                    string query = "insert into customer_ccdetails (customerId,CCDetails,AddOn,AddBy,IsDefault) values(" + objCust.Id + ",'" + objCust.CreditCardDetails + "',getdate(),'" + AppVars.LoginObj.UserName.ToStr() + "'," + IsNewCard + ")";

                                    //
                                    db.ExecuteQuery<int>(query);
                                }
                                catch
                                {


                                }

                            }
                            else
                            {
                                MessageBox.Show("Registration Failed!" + Environment.NewLine + cmr.Message.ToStr());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid card details");
                        }
                    }
                }

            }
            catch
            {


            }
        }


        private void btnProcessLater_Click(object sender, EventArgs e)
        {


            try
            {
                if(cardTokenDetails.ToStr().Length==0)
                {
                    MessageBox.Show("Required : Card token details");
                    return;
                }



                if (objMaster.Current == null)
                {



                }
                else
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.ExecuteQuery<int>("update booking set customercreditcarddetails='" + cardTokenDetails + "' where id=" + objMaster.Current.Id);

                        if (objMaster.Current.JourneyTypeId.ToInt() == 2 && objMaster.Current.BookingReturns.Count > 0)
                        {
                            db.ExecuteQuery<int>("update booking set customercreditcarddetails='" + cardTokenDetails + "' where id=" + objMaster.Current.BookingReturns[0].Id);


                        }

                    }
                }


                Close();

            }
            catch
            {


            }
        }

        private void btnClearDetails_Click(object sender, EventArgs e)
        {
           


            txtCardNumber.Text = string.Empty;
            txtCV2.Text = string.Empty;
            txtCardNumber.Tag = null;
            cardTokenDetails = string.Empty;


            if (ddlGateway.SelectedValue.ToInt() != Enums.PAYMENT_GATEWAY.JUDO)
            {
                txtCardNumber.Enabled = true;
                dtpExpiryDate.Enabled = true;
                txtCV2.Enabled = true;
            }

        }

        public bool isemailsent;
        public bool isstripepaid;

        private void btnsendpaymentlink_Click(object sender, EventArgs e)
        {
            try
            {
                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());


                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return;
                }
                else
                {
                    if(objMaster.Current.CustomerMobileNo.ToStr().Trim().Length==0)
                    {
                        ENUtils.ShowMessage("Required : Mobile No");
                        return;
                    }
                }
                
                // live mount cars with increased amount
                Stripe3DS st = new Stripe3DS();
                st.OneWayAmount = onewayAmount;
                st.ReturnAmount = returnAmount;
                st.PickupDateTime = objMaster.Current.PickupDateTime;
                st.ReturnPickupDateTime = objMaster.Current.ReturnPickupDateTime;
                st.ActualAmount = numTotalCharges.Value;
                int amount = numTotalCharges.Value.ToInt();
                double increasedAmount = amount + Convert.ToDouble(((Convert.ToDouble(amount) * 20) / 100));
                st.Amount = (increasedAmount * 100).ToInt();

                 st.Currency = "GBP";
                st.APIkey = obj.ApplicationId.ToStr();
                st.APISecret = obj.PaypalID.ToStr();
                st.BookingId = objMaster.Current.Id.ToStr();
                st.OperatorName = AppVars.LoginObj.UserName.ToStr();
                st.MobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                st.Email = objMaster.Current.CustomerEmail.ToStr().Trim();

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                if (obj.ApiCertificate.ToStr() == "2")
                {
                    st.Description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount +" GBP";

                    st.Amount = (numTotalCharges.Value * 100).ToInt();
                    st.PreAuthUrl = "";
                    st.UpdatePaymentURL = baseUrl;
                    st.SendPayByLink(new JavaScriptSerializer().Serialize(st));
                  
                }
                else
                {

                    st.Description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " - " + increasedAmount.ToStr() + " GBP";

                    st.UpdatePaymentURL = baseUrl + "/api/Supplier/AuthStripePayment";
                    st.PreAuthUrl = st.GetAuthorizeToken();

                    // without increased amount for city cabs
                    //Stripe3DS st = new Stripe3DS();
                    //decimal amount = numTotalCharges.Value.ToDecimal();
                    ////     double increasedAmount = amount + Convert.ToDouble(((Convert.ToDouble(amount) * 20) / 100));
                    //// st.Amount = (increasedAmount * 100).ToInt();
                    //st.Amount = (amount * 100).ToInt();
                    //st.Description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount  + " GBP";
                    //st.Currency = "GBP";
                    //st.APIkey = obj.ApplicationId.ToStr();
                    //st.APISecret = obj.PaypalID.ToStr();
                    //st.BookingId = objMaster.Current.Id.ToStr();
                    //st.OperatorName = AppVars.LoginObj.UserName.ToStr();
                    //st.MobileNo = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                    //st.Email = objMaster.Current.CustomerEmail.ToStr().Trim();
                    //string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                    //st.UpdatePaymentURL = baseUrl + "/api/Supplier/AuthStripePayment";
                    //st.PreAuthUrl = st.GetAuthorizeToken();



                    st.SendPreAuthLink(new JavaScriptSerializer().Serialize(st));
                }
                isemailsent = true;




                Close();

            }
            catch(Exception ex)
            {


            }

        }

        string mobileNo = string.Empty;

        private void btnRegisterCardBySMS_Click(object sender, EventArgs e)
        {
            try
            {


                if (parentBooking.GetMobileNo().Length==0 && txtMobileNo.Text.Trim().Length==0)
                {

                    ENUtils.ShowMessage("Required : Mobile No");
                    radLabel10.Visible = true;
                    txtMobileNo.Visible = true;
                    txtMobileNo.Focus();
                    return ;
                }

                if (parentBooking != null)
                {

           


                    bool issaved = parentBooking.Savefrompayment(txtMobileNo.Text.Trim());


                    if (issaved == false)
                    {
                        return;

                    }
                    else
                    {
                      objMaster=    parentBooking.GetBookingObject();



                    }
                }


                string result = JudoPay(true).ToStr();

                if (result.Contains("success"))
                {


                    isemailsent = true;

                    RadDesktopAlert desktopAlert = new Telerik.WinControls.UI.RadDesktopAlert();
                    desktopAlert.CaptionText = "SMS sent successfully!";
                    desktopAlert.ContentText = "Card Registration";
                    desktopAlert.ContentImage = Resources.Resource1.message;
                    desktopAlert.SoundToPlay = System.Media.SystemSounds.Asterisk;
                    desktopAlert.PlaySound = true;
                    desktopAlert.FixedSize = new Size(300, 120);
                    desktopAlert.Show();


                    Close();
                }
                else
                {

                    if (result.Contains(":") == false)
                        MessageBox.Show("Failure sending SMS");
                    else
                    {

                        MessageBox.Show(result.Split(':')[1].ToStr());

                    }

                }

            }
            catch (Exception ex)
            {


            }
        }




        private frmBooking2 parentBooking = null;


        private string JudoPay(bool IsRegisterCard, bool DirectProcessFromToken = false, bool SendPreAuthLink = false, bool SendPaymentLink = false)
        {

            Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());


            if (obj == null)
            {
                ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                return "";
            }
            //else
            //{
              

            //}


           


            JudopayPayment st = new JudopayPayment();



            st.Amount = numTotalCharges.Value;
            st.Currency = "GBP";
           
            st.IsRegisterCard = IsRegisterCard;
            st.UserName = AppVars.LoginObj.UserName.ToStr();
            

            st.CustomerNumber =parentBooking.GetMobileNo();
            st.CustomerEmail = parentBooking.GetEmail();
            st.SendType = this.sendType;

            if (st.SendType == 2)
                st.CustomerEmail = txtEmail.Text.Trim();

            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

            st.SubCompanyName = parentBooking.GetSubCompanyName();
            //string refNo = st.CustomerNumber;

            //if (objMaster.Current != null)
            //{
            //    refNo = objMaster.Current.BookingNo.ToStr();
            //    st.BookingId = objMaster.Current.Id;
            //}
            //else
            //{

            //        refNo = parentBooking.GetUniqueRef();


            //}

            //st.Description = AppVars.objSubCompany.CompanyName.ToStr() + " | " +refNo;
            //st.BookingNo = refNo;


            string refNo = st.CustomerNumber;

            if (objMaster.Current != null)
            {
                refNo = objMaster.Current.BookingNo.ToStr();
                st.BookingId = objMaster.Current.Id;
            }
            else
            {

                refNo = parentBooking.GetUniqueRef();

            }


            string name = st.SubCompanyName.ToStr().Trim();



            st.Description = name + " | " + refNo;
            st.BookingNo = refNo;


            st.UpdateUrl = baseUrl;


            st.OneWayAmount = onewayAmount;
            st.ReturnAmount = 0;

            if (chkIncludeReturnBooking.Checked)
            {

                st.ReturnAmount = returnAmount;

            }

            if (chkIncludeReturnBooking.Checked && objMaster.Current != null && objMaster.Current.BookingReturns.Count > 0)
            {
                st.ReturnBookingId = objMaster.Current.BookingReturns[0].Id;
                st.ReturnBookingNo = objMaster.Current.BookingReturns[0].BookingNo.ToStr().Trim();

            }

            st.CardToken = txtCardNumber.Tag.ToStr();


            if (objMaster.Current != null)
            {
                st.PickupDateTime = objMaster.Current.PickupDateTime;
                st.ReturnPickupDateTime = objMaster.Current.ReturnPickupDateTime;
            }


            if (SendPreAuthLink || SendPaymentLink)
            {
                if (chkIncludeReturnBooking.Checked && objMaster.Current != null && objMaster.Current.BookingReturns.Count > 0)
                {
                    st.ReturnBookingId = objMaster.Current.BookingReturns[0].Id;
                    st.ReturnBookingNo = objMaster.Current.BookingReturns[0].BookingNo.ToStr().Trim();

                    st.PickupDateTime = objMaster.Current.PickupDateTime;
                    st.ReturnPickupDateTime = objMaster.Current.ReturnPickupDateTime;
                }

                st.CardToken = txtCardNumber.Tag.ToStr();
                

                if (SendPaymentLink)
                    return st.SendToJudoPay(new JavaScriptSerializer().Serialize(st));
                else
                    return st.SendToJudoPreAuth(new JavaScriptSerializer().Serialize(st));
            }
            else
            {

                if (DirectProcessFromToken)
                {
                    st.ResponseInJson = true;
                    st.CardToken = txtCardNumber.Tag.ToStr();
                    return st.ProcessByTokenToJudoPay(new JavaScriptSerializer().Serialize(st));
                }
                else
                {

                    if (IsRegisterCard || SendPaymentLink)
                        return st.SendToJudoPay(new JavaScriptSerializer().Serialize(st));
                    else
                        return st.GetToJudoPay(new JavaScriptSerializer().Serialize(st));


                }
            }
        }



        private void SendJudoPaymentLink(int sendviaType)
        {
            try
            {
                this.sendType = sendviaType;



                if (parentBooking != null)
                {




                    bool issaved = parentBooking.Savefrompayment(txtMobileNo.Text.Trim(), true, chkIncludeReturnBooking.Checked);


                    if (issaved == false)
                    {
                        return;

                    }
                    else
                    {
                        objMaster = parentBooking.GetBookingObject();



                    }
                }


                string result = JudoPay(false, false, false, true).ToStr();

                if (result.Contains("success"))
                {


                    isemailsent = true;

                    RadDesktopAlert desktopAlert = new Telerik.WinControls.UI.RadDesktopAlert();
                    desktopAlert.CaptionText = "SMS sent successfully!";
                    desktopAlert.ContentText = "Card Payment";
                    desktopAlert.ContentImage = Resources.Resource1.message;
                    desktopAlert.FixedSize = new Size(300, 120);
                    desktopAlert.Show();


                    Close();
                }
                else
                {

                    if (result.Contains(":") == false)
                        MessageBox.Show("Failure sending SMS");
                    else
                    {

                        MessageBox.Show(result.Split(':')[1].ToStr());

                    }

                }

                sendType = 1;

            }
            catch (Exception ex)
            {


            }
        }
        int sendType = 0;

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if (parentBooking.GetEmail().Length == 0 && txtEmail.Text.Trim().Length == 0)
            {

                ENUtils.ShowMessage("Required : Email");
                radLabel9.Visible = true;
                txtEmail.Visible = true;
                txtEmail.Focus();
                return;
            }
            else if (parentBooking.GetEmail().Length > 0 && txtEmail.Text.Trim().Length == 0)
            {

                ENUtils.ShowMessage("Please verify the email address");

                txtEmail.Text = parentBooking.GetEmail();

                radLabel9.Visible = true;
                txtEmail.Visible = true;
                txtEmail.Focus();
                return;
            }


            SendJudoPaymentLink(2);
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {

            if (parentBooking.GetMobileNo().Length == 0 && txtMobileNo.Text.Trim().Length == 0)
            {

                ENUtils.ShowMessage("Required : Mobile No");
                radLabel10.Visible = true;
                txtMobileNo.Visible = true;
                txtMobileNo.Focus();
                return;
            }
            SendJudoPaymentLink(1);
        }

        private void btnpreauthsms_Click(object sender, EventArgs e)
        {
            try
            {


                if (parentBooking.GetMobileNo().Length == 0 && txtMobileNo.Text.Trim().Length == 0)
                {

                    ENUtils.ShowMessage("Required : Mobile No");
                    radLabel10.Visible = true;
                    txtMobileNo.Visible = true;
                    txtMobileNo.Focus();
                    return;
                }

                if (parentBooking != null)
                {




                    bool issaved = parentBooking.Savefrompayment(txtMobileNo.Text.Trim(), true, chkIncludeReturnBooking.Checked);


                    if (issaved == false)
                    {
                        return;

                    }
                    else
                    {
                        objMaster = parentBooking.GetBookingObject();



                    }
                }

                sendType = 1;
                string result = JudoPay(true, false, true).ToStr();

                if (result.Contains("success"))
                {


                    isemailsent = true;

                    RadDesktopAlert desktopAlert = new Telerik.WinControls.UI.RadDesktopAlert();
                    desktopAlert.CaptionText = "SMS sent successfully!";
                    desktopAlert.ContentText = "PreAuth Registration";
                    desktopAlert.ContentImage = Resources.Resource1.message;
                    desktopAlert.SoundToPlay = System.Media.SystemSounds.Asterisk;
                    desktopAlert.PlaySound = true;
                    desktopAlert.FixedSize = new Size(300, 120);
                    desktopAlert.Show();


                    Close();
                }
                else if (result.Contains("directsuccess"))
                {
                    isemailsent = true;
                    Close();
                }
                else
                {

                    if (result.Contains(":") == false)
                        MessageBox.Show("Failure sending SMS");
                    else
                    {

                        MessageBox.Show(result.Split(':')[1].ToStr());

                    }

                }

            }
            catch (Exception ex)
            {


            }
        }

        #region KonnectPay


        private CustomerCardDetails GetCardTokenKP(int? CustomerId)
        {
            CustomerCardDetails CCDetail = new CustomerCardDetails();
            try
            {
                ClsCCDetails CardDetails = new ClsCCDetails();
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    CardDetails = db.ExecuteQuery<ClsCCDetails>("select RecordId=Id,CCDetails,IsDefault from  Customer_CCDetails where customerId=" + CustomerId.ToInt()).LastOrDefault();

                }

                if (CardDetails != null && !string.IsNullOrEmpty(CardDetails.CCDetails) && CardDetails.CCDetails.ToLower().Contains("konnectpaytoken"))
                {
                    var CCDetails = CardDetails.CCDetails.Split('|');
                    string Token = CCDetails[0];
                    if (!string.IsNullOrEmpty(Token)) { CCDetail.CustomerCardToken = Token.Replace("KonnectPayToken:", "").Trim(); }
                    if (!string.IsNullOrEmpty(CCDetails[1]))
                    {
                        var CardInfo = CCDetails[1].Split(',');
                        if (CardInfo != null)
                        {
                            if (CardInfo[0] != null && CardInfo[0].ToLower().Contains("last four"))
                            {
                                CCDetail.Lastfour = CardInfo[0].Replace("last four", "");
                                CCDetail.Lastfour = CCDetail.Lastfour.Replace(":", "").Trim();
                            }
                            if (CardInfo[1] != null && CardInfo[1].ToLower().Contains("expiry"))
                            {
                                CCDetail.expiry = CardInfo[1].Replace("expiry", "");
                                CCDetail.expiry = CCDetail.expiry.Replace(":", "").Trim();


                            }
                            if (CardInfo[2] != null && CardInfo[2].ToLower().Contains("cardtype"))
                            {
                                CCDetail.cardType = CardInfo[2].Replace("cardType", "");
                                CCDetail.cardType = CCDetail.cardType.Replace(":", "").Trim();
                            }


                        }
                    }
                }

            }
            catch
            {

            }

            return CCDetail;
        }


        string CustomerCardTokenKP = string.Empty;


        private string RenderSelectedCardInfo(string CardDetails)
        {
            bool IsCardSelected = false;
            string Lastfour = string.Empty;
            string expiry = string.Empty;
            string cardType = string.Empty;
            string CustomerCardToken = string.Empty;

            if (CardDetails != null && CardDetails.ToLower().Contains("konnectpaytoken"))
            {
                var CCDetails = CardDetails.Split('|');
                string cardToken = CCDetails[0];
                if (!string.IsNullOrEmpty(cardToken)) { CustomerCardToken = cardToken.Replace("KonnectPayToken:", "").Trim(); }
                if (!string.IsNullOrEmpty(CCDetails[1]))
                {
                    var CardInfo = CCDetails[1].Split(',');
                    if (CardInfo != null)
                    {
                        if (CardInfo[0] != null && CardInfo[0].ToLower().Contains("last four"))
                        {
                            Lastfour = CardInfo[0].Replace("last four", "");
                            Lastfour = Lastfour.Replace(":", "").Trim();
                            txtCardNumberKP.Text = "****" + Lastfour;

                            lblCardNumberKP.Visible = true;
                            txtCardNumberKP.Visible = true;

                            lblCardNumberKP.BringToFront();
                            txtCardNumberKP.BringToFront();

                            IsCardSelected = true;

                        }
                        if (CardInfo[1] != null && CardInfo[1].ToLower().Contains("expiry"))
                        {
                            expiry = CardInfo[1].Replace("expiry", "");
                            expiry = expiry.Replace(":", "").Trim();
                            TxtExpiryKP.Text = expiry;

                            lblExpiryKP.Visible = true;
                            TxtExpiryKP.Visible = true;
                            lblExpiryKP.BringToFront();
                            TxtExpiryKP.BringToFront();

                        }
                        if (CardInfo[2] != null && CardInfo[2].ToLower().Contains("cardtype"))
                        {
                            cardType = CardInfo[2].Replace("cardType", "");
                            cardType = cardType.Replace(":", "").Trim();
                            txtCardTypeKP.Text = cardType;

                            lblCardTypeKP.Visible = true;
                            txtCardTypeKP.Visible = true;

                            lblCardTypeKP.BringToFront();
                            txtCardTypeKP.BringToFront();

                        }

                        if (IsCardSelected)
                        {
                            btnPRocessPaymentWithCardKP.Visible = true;
                            btnPRocessPaymentWithCardKP.BringToFront();

                        }


                    }
                }
            }
            return CustomerCardToken;
        }

        private string RegisterCardKP()
        {
            string resp = "false";
            try
            {

                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());
                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return resp = "false";
                }
                int CustID = 0;// Convert.ToInt32(objMaster?.Current?.CustomerId);
               
                Customer Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr());

                if (Customerobj == null)
                {
                    ENUtils.ShowMessage("No data found against this Customer!");
                    return resp = "false";
                }
                else
                {

                    if (string.IsNullOrEmpty(Customerobj?.Name) || string.IsNullOrEmpty(Customerobj?.MobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No and Customer Name");
                        return resp = "false";
                    }
                }
                if (CustID == 0) { CustID = Customerobj.Id; }
                btnRegisterCardKP.Enabled = false;
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                string StripeCustomerID = string.Empty;
                if (Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus"))
                {
                    StripeCustomerID = Customerobj.CreditCardDetails.ToStr();

                }
                RegisterCardDto SpDTO = new RegisterCardDto();

                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                // SpDTO.description = " Registering Card ";
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.customerName = Customerobj?.Name.Trim() + "/" + CustID.ToString();
                SpDTO.email = Customerobj?.Email.Trim();
                SpDTO.phoneNumber = Customerobj?.MobileNo.Trim();
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.paymentUpdateWebhook = "";
                SpDTO.UpdatePaymentURL = baseUrl;
                SpDTO.PreAuthUrl = "";
                SpDTO.customerId = StripeCustomerID ?? "";

                string sendResponse = SpDTO.RegisterCard(new JavaScriptSerializer().Serialize(SpDTO));

                if (!string.IsNullOrEmpty(sendResponse))
                {
                    Process.Start(sendResponse);

                    string Registerurl = sendResponse.Trim('"');
                    Registerurl = Registerurl.Replace("\\", "").Trim();

                    btnRegisterCardKP.Enabled = true;
                    return resp = "true";
                }
                else
                {
                    ENUtils.ShowMessage("Error in Processing register card please try later!");
                    btnRegisterCardKP.Enabled = true;
                    return resp = "false";

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage("Error in Processing register card please try later!");
                btnRegisterCardKP.Enabled = true;
                resp = "false";
            }
            return resp;


        }

        private string CheckIfCustomerIsRegister(int CustomerID)
        {
            string CustomerCardToken = string.Empty;
            using (TaxiDataContext db = new TaxiDataContext())
            {
                var ccList = db.ExecuteQuery<ClsCCDetails>("select RecordId=Id,CCDetails,IsDefault from  CUSTOMER_ccdetails where customerId=" + CustomerID + "and IsDefault=1;").ToList();
                if (ccList != null && ccList.Count >= 1)
                {
                    var CardDetails = ccList[0].CCDetails;
                    if (CardDetails != null && CardDetails.ToLower().Contains("konnectpaytoken"))
                    {
                        var CCDetails = CardDetails.Split('|');
                        string cardToken = CCDetails[0];
                        if (!string.IsNullOrEmpty(cardToken)) { CustomerCardToken = cardToken.Replace("KonnectPayToken:", "").Trim(); }

                    }
                }
            }
            return CustomerCardToken;


        }

        private string ProcessPaymentWithRegisterCustomer(string CustomerCardToken, bool isAuthorized)
        {
            string ProcessPayment = string.Empty;
            try
            {

                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());
                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return ProcessPayment;
                }
                else
                {

                    if (string.IsNullOrEmpty(objMaster?.Current?.CustomerEmail) && string.IsNullOrEmpty(objMaster?.Current?.CustomerMobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No or Email");
                        return ProcessPayment;
                    }
                }

                decimal amount = numTotalCharges.Value.ToDecimal();
                if (amount <= 0)
                {
                    ENUtils.ShowMessage("Booking Amount must be greater than 0!");
                    return "false";

                }

                string StripeCustomerId = string.Empty;
                //if (objMaster?.Current?.Customer?.CreditCardDetails.ToStr().Length > 0)
                //{
                // StripeCustomerId = objMaster?.Current?.Customer?.CreditCardDetails;
                //}
                //else
                //{
                    Customer Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr() && c.CreditCardDetails!=null && c.CreditCardDetails!="");
                    StripeCustomerId = Customerobj?.CreditCardDetails?.ToStr();
                //}
                if (!StripeCustomerId.ToStr().ToLower().StartsWith("cus"))
                {
                    StripeCustomerId = "";
                }

                btnPRocessPaymentWithCardKP.Enabled = false;
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                StripePaymentRequestDto SpDTO = new StripePaymentRequestDto();
                SpDTO.isAuthorized = isAuthorized;
                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.applicationFee = 0;
                SpDTO.otherCharges = 0;
                SpDTO.bookingId = objMaster.Current.Id;
                SpDTO.bookingRef = objMaster.Current.BookingNo;
                SpDTO.amount = (numTotalCharges.Value * 100).ToInt();
                SpDTO.displayAmount = numTotalCharges.Value;
                SpDTO.currency = "GBP";
                SpDTO.description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                if (SpDTO.description.ToStr().Length > 150)
                {
                    SpDTO.description = AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                }
                SpDTO.paymentMethodId = CustomerCardToken;
                SpDTO.customerId = StripeCustomerId;// objMaster?.Current?.Customer?.CreditCardDetails;
                SpDTO.customerName = objMaster.Current.CustomerName.ToStr().Trim();
                SpDTO.email = objMaster.Current.CustomerEmail.ToStr().Trim();
                SpDTO.phoneNumber = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                SpDTO.lastfour = "";
                SpDTO.expiry = "";
                SpDTO.cardtype = "";
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.verificationWebhook = "";
                SpDTO.paymentUpdateWebhook = "";
                SpDTO.ReturnAmount = returnAmount;
                SpDTO.UpdatePaymentURL = "";
                SpDTO.OperatorName = AppVars.LoginObj.UserName.ToStr();
                SpDTO.PreAuthUrl = "";
                SpDTO.PayByDispatch = "0";

                ProcessPayment = SpDTO.ProcessPaymentWithRegisterCustomer(new JavaScriptSerializer().Serialize(SpDTO));
                if (ProcessPayment.Contains("true"))
                {
                    var payResp = ProcessPayment.ToStr().Split('|');
                    if (payResp.Length <= 1)
                    {
                        ENUtils.ShowMessage("Payment Failed!");
                        btnPRocessPaymentWithCardKP.Enabled = true;
                        return "Payment Failed";
                    }

                    string PI = payResp[1].ToStr();
                    if (!string.IsNullOrEmpty(PI) && PI.Contains('"'))
                    {
                        PI = PI.Replace("\"", "");

                    }
                    objMaster.Current.IsQuotedPrice = true;
                    objMaster.Current.PaymentTypeId = Enums.PAYMENT_TYPES.CREDIT_CARD_PAID;
                    lblResponse.ForeColor = Color.Green;
                    lblResponse.Visible = true;
                    txtAmount.Enabled = false;
                    numSurchargePercent.Enabled = false;


                    lblStatus.Text = "AuthCode:" + PI.ToStr();
                    TransactionID = lblStatus.Text;


                    responseLog = "Auth Code:" + PI.ToStr() + Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", amount);

                    paymentInstructions = "Date: " + string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) + Environment.NewLine + "Total: " + string.Format("{0:##0.##}", numTotalCharges.Value) + Environment.NewLine + "TransactionID: " + PI.ToStr();


                    try
                    {
                        lblResponse.Text = Environment.NewLine + "Amount:" + string.Format("{0:##0.##}", numTotalCharges.Value);

                        responseLog += " (Payment From Dispatch)";

                    }
                    catch
                    {


                    }

                    Save();
                    responseLog = string.Empty;
                    Close();

                    // ENUtils.ShowMessage("Payment successfully Capture against this booking!");

                }
                else
                {
                    ENUtils.ShowMessage(ProcessPayment);

                }
                btnPRocessPaymentWithCardKP.Enabled = true;


            }
            catch (Exception ex)
            {

                btnPRocessPaymentWithCardKP.Enabled = true;

            }
            return ProcessPayment;

        }

        private string SendRegisterCardLinkKP()
        {
            string resp = "false";
            try
            {

                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());
                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return resp = "false";
                }
                int CustID = 0;// Convert.ToInt32(objMaster?.Current?.CustomerId);
                Customer Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr());

                if (Customerobj == null)
                {
                    ENUtils.ShowMessage("No data found against this Customer!");
                    return resp = "false";
                }
                else
                {

                    if (string.IsNullOrEmpty(Customerobj?.Name) || string.IsNullOrEmpty(Customerobj?.MobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No and Customer Name");
                        return resp = "false";
                    }
                }
                if (CustID == 0) { CustID = Customerobj.Id; }
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                string StripeCustomerID = string.Empty;
                if (Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus"))
                {
                    StripeCustomerID = Customerobj.CreditCardDetails.ToStr();
                }
                RegisterCardDto SpDTO = new RegisterCardDto();

                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                // SpDTO.description = " Registering Card ";
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.customerName = Customerobj?.Name.Trim() + "/" + CustID.ToString();
                SpDTO.email = objMaster?.Current?.CustomerEmail;
                SpDTO.phoneNumber = Customerobj?.MobileNo.Trim();
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.paymentUpdateWebhook = "";
                SpDTO.UpdatePaymentURL = baseUrl;
                SpDTO.PreAuthUrl = "";
                SpDTO.customerId = StripeCustomerID ?? "";
                SpDTO.sendLinkToCustomer = true;
                SpDTO.DBCustomerID = CustID;
                string sendResponse = SpDTO.RegisterCard(new JavaScriptSerializer().Serialize(SpDTO));
                if (!string.IsNullOrEmpty(sendResponse) && sendResponse.Contains("true"))
                {
                    MessageBox.Show("Register Card link sent to customer!");
                }
                else
                {
                    MessageBox.Show("Error in sending Register card link to customer!");
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage("Error in Sending register card please try later!");
                resp = "false";
            }
            return resp;

        }

        private void ProcessDirectPaymentKP()
        {
            try
            {

                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());


                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return;
                }
                else
                {

                    if (string.IsNullOrEmpty(objMaster?.Current?.CustomerEmail) && string.IsNullOrEmpty(objMaster?.Current?.CustomerMobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No or Email");
                        return;
                    }
                }


                decimal amount = numTotalCharges.Value.ToDecimal();
                if (amount <= 0)
                {
                    ENUtils.ShowMessage("Booking Amount must be greater than 0!");
                    return;

                }
                btnDirectPAymentKP.Enabled = false;
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                string CustomerStripeID = "";
                CustomerCardDetails CardDetails = null;
                //if (objMaster?.Current?.Customer?.CreditCardDetails.ToStr().Length > 0)
                //{
                //    CustomerStripeID = objMaster?.Current?.Customer?.CreditCardDetails;
                //    CardDetails = GetCardTokenKP(objMaster?.Current.CustomerId);
                //}
                //else
                //{
                    Customer Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr() && c.CreditCardDetails!=null && c.CreditCardDetails!="");
                if (Customerobj != null)
                {
                    CustomerStripeID = Customerobj?.CreditCardDetails?.ToStr();
                    CardDetails = GetCardTokenKP(Customerobj?.Id);
                }
                //}
                //if (!string.IsNullOrEmpty(objMaster?.Current?.Customer?.CreditCardDetails))
                //{
                //    CustomerStripeID = objMaster.Current.Customer.CreditCardDetails;
                //    CardDetails = GetCardTokenKP(objMaster?.Current.CustomerId);
                //}
                if (!CustomerStripeID.ToStr().ToLower().StartsWith("cus"))
                {
                    CustomerStripeID = "";
                }
                StripePaymentRequestDto SpDTO = new StripePaymentRequestDto();
                SpDTO.isAuthorized = false;
                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.applicationFee = 0;
                SpDTO.otherCharges = 0;
                SpDTO.bookingId = objMaster?.Current?.Id ?? 0;
                SpDTO.bookingRef = objMaster?.Current?.BookingNo ?? "";
                SpDTO.amount = (numTotalCharges.Value * 100).ToInt();
                SpDTO.displayAmount = numTotalCharges.Value;
                SpDTO.currency = "GBP";
                SpDTO.description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                if (SpDTO.description.ToStr().Length > 150)
                {
                    SpDTO.description = AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                }

                SpDTO.paymentMethodId = CardDetails?.CustomerCardToken ?? "";
                SpDTO.customerId = CustomerStripeID;
                SpDTO.customerName = objMaster.Current.CustomerName.ToStr().Trim();
                SpDTO.email = objMaster.Current.CustomerEmail.ToStr().Trim();
                SpDTO.phoneNumber = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                SpDTO.lastfour = CardDetails?.Lastfour ?? "";
                SpDTO.expiry = CardDetails?.expiry ?? ""; ;
                SpDTO.cardtype = CardDetails?.cardType ?? "";
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.verificationWebhook = "";
                SpDTO.paymentUpdateWebhook = baseUrl;
                SpDTO.ReturnAmount = returnAmount;
                SpDTO.UpdatePaymentURL = baseUrl;
                SpDTO.OperatorName = AppVars.LoginObj.UserName.ToStr();
                SpDTO.PreAuthUrl = "";
                SpDTO.PayByDispatch = "1";
                //string sendResponse = SpDTO.SendPayByLinkKP(new JavaScriptSerializer().Serialize(SpDTO));
                string sendResponse = "";
                if (chkIncludeReturnBooking.Checked)
                {
                    sendResponse = SpDTO.SendPayByLinkKPReturn(new JavaScriptSerializer().Serialize(SpDTO));
                }
                else
                {
                    sendResponse = SpDTO.SendPayByLinkKP(new JavaScriptSerializer().Serialize(SpDTO));

                }

                isemailsent = true;
                BtnPayByLinkKP.Enabled = true;
                if (!string.IsNullOrEmpty(sendResponse))
                {
                    Process.Start(sendResponse);
                    btnDirectPAymentKP.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error in Processing Payment!");
                    btnDirectPAymentKP.Enabled = true;
                }


            }
            catch (Exception ex)
            {

            }


        }

        private void BtnPayByLinkKP_Click(object sender, EventArgs e)
        {
            try
            {
                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());


                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return;
                }
                else
                {

                    if (string.IsNullOrEmpty(objMaster?.Current?.CustomerEmail) && string.IsNullOrEmpty(objMaster?.Current?.CustomerMobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No or Email");
                        return;
                    }
                }


                decimal amount = numTotalCharges.Value.ToDecimal();
                if (amount <= 0)
                {
                    ENUtils.ShowMessage("Booking Amount must be greater than 0!");
                    return;

                }
                BtnPayByLinkKP.Enabled = false;
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                string CustomerStripeID = "";
                CustomerCardDetails CardDetails = null;

                //if (!string.IsNullOrEmpty(objMaster?.Current?.Customer?.CreditCardDetails))
                //{
                //    CustomerStripeID = objMaster.Current.Customer.CreditCardDetails;
                //    CardDetails = GetCardTokenKP(objMaster?.Current.CustomerId);
                //}
                //if (objMaster?.Current?.Customer?.CreditCardDetails.ToStr().Length > 0)
                //{
                //    CustomerStripeID = objMaster?.Current?.Customer?.CreditCardDetails;
                //    CardDetails = GetCardTokenKP(objMaster?.Current.CustomerId);
                //}
                //else
                //{
                    Customer Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr() && c.CreditCardDetails!=null && c.CreditCardDetails!="");
                if (Customerobj != null)
                {
                    CustomerStripeID = Customerobj?.CreditCardDetails?.ToStr();
                    CardDetails = GetCardTokenKP(Customerobj?.Id);
                }
                //}
                if (!CustomerStripeID.ToStr().ToLower().StartsWith("cus"))
                {
                    CustomerStripeID = "";
                }

                StripePaymentRequestDto SpDTO = new StripePaymentRequestDto();
                SpDTO.isAuthorized = false;
                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.applicationFee = 0;
                SpDTO.otherCharges = 0;
                SpDTO.bookingId = objMaster?.Current?.Id ?? 0;
                SpDTO.bookingRef = objMaster?.Current?.BookingNo ?? "";
                SpDTO.amount = (numTotalCharges.Value * 100).ToInt();
                SpDTO.displayAmount = numTotalCharges.Value;
                SpDTO.currency = "GBP";
                SpDTO.description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                if (SpDTO.description.ToStr().Length > 150)
                {
                    SpDTO.description = AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                }

                SpDTO.paymentMethodId = CardDetails?.CustomerCardToken ?? "";
                SpDTO.customerId = CustomerStripeID;
                SpDTO.customerName = objMaster.Current.CustomerName.ToStr().Trim();
                SpDTO.email = objMaster.Current.CustomerEmail.ToStr().Trim();
                SpDTO.phoneNumber = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                SpDTO.lastfour = CardDetails?.Lastfour ?? "";
                SpDTO.expiry = CardDetails?.expiry ?? ""; ;
                SpDTO.cardtype = CardDetails?.cardType ?? "";
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.verificationWebhook = "";
                SpDTO.paymentUpdateWebhook = baseUrl;
                SpDTO.ReturnAmount = returnAmount;
                SpDTO.UpdatePaymentURL = baseUrl;
                SpDTO.OperatorName = AppVars.LoginObj.UserName.ToStr();
                SpDTO.PreAuthUrl = "";
                SpDTO.PayByDispatch = "0";
                string sendResponse = "";
                if (chkIncludeReturnBooking.Checked)
                {
                   sendResponse = SpDTO.SendPayByLinkKPReturn(new JavaScriptSerializer().Serialize(SpDTO));
                }
                else
                {
                    sendResponse = SpDTO.SendPayByLinkKP(new JavaScriptSerializer().Serialize(SpDTO));

                }

                isemailsent = true;
                BtnPayByLinkKP.Enabled = true;
                if (!string.IsNullOrEmpty(sendResponse) && sendResponse.Contains("true"))
                {
                    MessageBox.Show("Payment link sent to customer!");
                }
                else
                {
                    MessageBox.Show("Error in sending Payment link to customer!");
                }

                this.Close();

            }
            catch (Exception ex)
            {
                BtnPayByLinkKP.Enabled = true;

            }
        }

        private void rdoPayByLink_CheckedChanged(object sender, EventArgs e)
        {
            CustomerCardTokenKP = string.Empty;
            btnRegisterCardKP.Visible = false;
            btnPaymentWithExisting.Visible = false;
            btnSendRegisterCardLinkKP.Visible = false;
            BtnPreAuthKP.Visible = false;
            btnDirectPAymentKP.Visible = false;


            BtnPayByLinkKP.Visible = true;
            BtnPayByLinkKP.BringToFront();

            lblCardNumberKP.Visible = false;
            txtCardNumberKP.Visible = false;
            lblExpiryKP.Visible = false;
            TxtExpiryKP.Visible = false;
            btnPRocessPaymentWithCardKP.Visible = false;
            lblCardTypeKP.Visible = false;
            txtCardTypeKP.Visible = false;
        }

        private void rdoPreAuthKP_CheckedChanged(object sender, EventArgs e)
        {
            CustomerCardTokenKP = string.Empty;
            btnRegisterCardKP.Visible = false;
            btnPaymentWithExisting.Visible = false;
            btnSendRegisterCardLinkKP.Visible = false;

            btnDirectPAymentKP.Visible = false;

            BtnPayByLinkKP.Visible = false;

            BtnPreAuthKP.Visible = true;
            BtnPreAuthKP.BringToFront();

            double amount = Convert.ToDouble(numTotalCharges.Value);

            lblCardNumberKP.Visible = false;
            txtCardNumberKP.Visible = false;
            lblExpiryKP.Visible = false;
            TxtExpiryKP.Visible = false;
            btnPRocessPaymentWithCardKP.Visible = false;
          
            lblCardTypeKP.Visible = false;
            txtCardTypeKP.Visible = false;
        }

        private void rdoDirectKP_CheckedChanged(object sender, EventArgs e)
        {

            btnDirectPAymentKP.Visible = true;
            btnDirectPAymentKP.BringToFront();
            CustomerCardTokenKP = string.Empty;
            btnRegisterCardKP.Visible = false;
            btnPaymentWithExisting.Visible = false;
            btnSendRegisterCardLinkKP.Visible = false;

            BtnPreAuthKP.Visible = false;


            BtnPayByLinkKP.Visible = false;


            lblCardNumberKP.Visible = false;
            txtCardNumberKP.Visible = false;
            lblExpiryKP.Visible = false;
            TxtExpiryKP.Visible = false;
            btnPRocessPaymentWithCardKP.Visible = false;

            lblCardTypeKP.Visible = false;
            txtCardTypeKP.Visible = false;
        }

        private void rdoPayByCard_CheckedChanged(object sender, EventArgs e)
        {
            BtnPreAuthKP.Visible = false;
            BtnPayByLinkKP.Visible = false;
            btnDirectPAymentKP.Visible = false;

            btnRegisterCardKP.Visible = true;
            btnPaymentWithExisting.Visible = true;
            btnSendRegisterCardLinkKP.Visible = true;

            btnRegisterCardKP.BringToFront();
            btnPaymentWithExisting.BringToFront();
            btnSendRegisterCardLinkKP.BringToFront();
        }

        private void BtnPreAuthKP_Click(object sender, EventArgs e)
        {
            try
            {
                BtnPreAuthKP.Enabled = true;
                Gen_SysPolicy_PaymentDetail obj = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == ddlGateway.SelectedValue.ToInt());


                if (obj == null)
                {
                    ENUtils.ShowMessage("Payment Gateway Configuration is not defined in Settings!");
                    return;
                }
                else
                {

                    if (string.IsNullOrEmpty(objMaster?.Current?.CustomerEmail) && string.IsNullOrEmpty(objMaster?.Current?.CustomerMobileNo))
                    {
                        ENUtils.ShowMessage("Required : Mobile No or Email");
                        return;
                    }
                }

                decimal amount = numTotalCharges.Value.ToDecimal();
                if (amount <= 0)
                {
                    ENUtils.ShowMessage("Booking Amount must be greater than 0!");
                    return;

                }
                // double IncAmount = Convert.ToDouble(TxtExtraChargKP.Value);
                // double increasedAmount = amount + Convert.ToDouble(((Convert.ToDouble(amount) * IncAmount) / 100));
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                StripePaymentRequestDto SpDTO = new StripePaymentRequestDto();
                SpDTO.isAuthorized = true;
                SpDTO.key = "";
                SpDTO.secret = "";
                SpDTO.countryId = obj.ApplicationId.ToInt();
                SpDTO.connectedAccountId = obj.PaypalID.Trim();
                SpDTO.applicationFee = 0;
                SpDTO.otherCharges = 0;
                SpDTO.bookingId = objMaster.Current.Id;
                SpDTO.bookingRef = objMaster.Current.BookingNo;
                SpDTO.amount = (numTotalCharges.Value * 100).ToInt();
                SpDTO.displayAmount = numTotalCharges.Value;
                SpDTO.currency = "GBP";
                SpDTO.description = AppVars.objSubCompany.CompanyName.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                if (SpDTO.description.ToStr().Length > 150)
                {
                    SpDTO.description = AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + " | " + objMaster.Current.BookingNo.ToStr() + " | " + "Fares : " + amount + " GBP";
                }

                SpDTO.paymentMethodId = "";
                SpDTO.customerId = "";
                SpDTO.customerName = objMaster.Current.CustomerName.ToStr().Trim();
                SpDTO.email = objMaster.Current.CustomerEmail.ToStr().Trim();
                SpDTO.phoneNumber = objMaster.Current.CustomerMobileNo.ToStr().Trim();
                SpDTO.lastfour = "";
                SpDTO.expiry = "";
                SpDTO.cardtype = "";
                SpDTO.companyName = AppVars.objSubCompany.CompanyName.ToStr();
                SpDTO.defaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                SpDTO.location = "UK";// AppVars.objSubCompany.DefaultCounty;
                SpDTO.verificationWebhook = "";
                SpDTO.paymentUpdateWebhook = baseUrl;
                SpDTO.ReturnAmount = returnAmount;
                SpDTO.UpdatePaymentURL = baseUrl;
                SpDTO.OperatorName = AppVars.LoginObj.UserName.ToStr();
                SpDTO.PreAuthUrl = "";// SpDTO.GetAuthorizeTokenKP(SpDTO);
                SpDTO.PayByDispatch = "0";

                string sendResponse = SpDTO.SendPreAuthLinkKP(new JavaScriptSerializer().Serialize(SpDTO));
                BtnPreAuthKP.Enabled = false;
                isemailsent = true;
                if (!string.IsNullOrEmpty(sendResponse) && sendResponse.Contains("true"))
                {
                    MessageBox.Show("Authorization link sent to customer!");
                }
                else
                {
                    MessageBox.Show("Error in sending Authorization link to customer!");
                }

                Close();

            }
            catch (Exception ex)
            {
                BtnPreAuthKP.Enabled = false;


            }
        }

        private void btnRegisterCardKP_Click(object sender, EventArgs e)
        {
            RegisterCardKP();
        }

        private void btnPaymentWithExisting_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerCardTokenKP = string.Empty;
                List<ClsCCDetails> ccList = new List<ClsCCDetails>();
                Customer Customerobj = null;
                int CustomerID = 0;// Convert.ToInt32(objMaster?.Current?.CustomerId);
                if (objMaster.Current != null)
                {
                    long bookingId = objMaster.Current.Id;
                    objMaster.GetByPrimaryKey(bookingId);
                }
                if (CustomerID <= 0)
                {
                    Customerobj = General.GetObject<Customer>(c => c.MobileNo == objMaster.Current.CustomerMobileNo.ToStr() && c.CreditCardDetails != null && c.CreditCardDetails.StartsWith("cus_"));
                    CustomerID = Convert.ToInt32(Customerobj?.Id);
                }
                // if (CustomerID > 0 && ((objMaster?.Current?.Customer?.CreditCardDetails.ToStr().Length > 0 && objMaster.Current.Customer.CreditCardDetails.ToStr().ToLower().StartsWith("cus_")) || (Customerobj?.CreditCardDetails.ToStr().Length > 0 && Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus_") ) ))
                if (CustomerID > 0 && (Customerobj?.CreditCardDetails.ToStr().Length > 0 && Customerobj.CreditCardDetails.ToStr().ToLower().StartsWith("cus_")))
                {
                        using (TaxiDataContext db = new TaxiDataContext())
                    {
                        ccList = db.ExecuteQuery<ClsCCDetails>("select RecordId=Id,CCDetails,IsDefault from Customer_CCDetails where customerId=" + CustomerID).ToList();

                    }
                    if (ccList.Count > 1)
                    {
                        PickCardDetailsKP frm = new PickCardDetailsKP(ccList);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();


                        frm.Dispose();


                        if (frm.SelectedCard.ToStr().Trim().Length > 0)
                        {
                            cardTokenDetails = frm.SelectedCard.ToStr().Trim();
                            CustomerCardTokenKP = RenderSelectedCardInfo(cardTokenDetails);

                        }
                    }
                    else if (ccList.Count == 1)
                    {

                        if (ccList != null && ccList.Count >= 1)
                        {
                            var CardDetails = ccList[0].CCDetails;
                            CustomerCardTokenKP = RenderSelectedCardInfo(CardDetails);
                        }
                    }
                    else
                    {
                        ENUtils.ShowMessage("No Card found!");
                        btnPRocessPaymentWithCardKP.Visible = false;


                    }
                }
                else
                {
                    ENUtils.ShowMessage("No Card found!");
                    btnPRocessPaymentWithCardKP.Visible = false;

                }
            }
            catch
            {

            }
        }

        private void btnPRocessPaymentWithCardKP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerCardTokenKP) && CustomerCardTokenKP.ToLower().Contains("pm"))
            {
                if (!string.IsNullOrEmpty(CustomerCardTokenKP))
                {

                    ProcessPaymentWithRegisterCustomer(CustomerCardTokenKP, false);

                }
                else
                {
                    ENUtils.ShowMessage("Customer is not registered on stripe!");
                }
            }
        }

        private void btnSendRegisterCardLinkKP_Click(object sender, EventArgs e)
        {
            SendRegisterCardLinkKP();
        }

        private void btnDirectPAymentKP_Click(object sender, EventArgs e)
        {
            ProcessDirectPaymentKP();
        }

        #endregion
    }


    #region JUDO REGISTER CARD
    public class ClsCardDetails
    {
        public string CardLastfour { get; set; }
        public string EndDate { get; set; }
        public string CardToken { get; set; }
        public int CardType { get; set; }
        public string CardScheme { get; set; }
        public string CardFunding { get; set; }
        public string CardCategory { get; set; }
        public string CardCountry { get; set; }
        public string Bank { get; set; }
    }
    public class ClsConsumer
    {
        public string ConsumerToken { get; set; }
        public string YourConsumerReference { get; set; }
    }
  
    public class ClsCardToken
    {
        public long ReceiptId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public int JudoId { get; set; }
        public string MerchantName { get; set; }
        public string AppearsOnStatementAs { get; set; }
        public double OriginalAmount { get; set; }
        public string YourPaymentReference { get; set; }
        public double NetAmount { get; set; }
        public double AmountCollected { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public ClsCardDetails CardDetails { get; set; }
        public ClsConsumer Consumer { get; set; }
       
    }
    public class CustomerCardDetails
    {
        public long Id { get; set; }
        public string CustomerCardToken { get; set; }
        public string Lastfour { get; set; }
        public string expiry { get; set; }
        public string cardType { get; set; }
        public bool IsDefault { get; set; }
    }
    public class ClsCCDetails
    {


        //
        public bool? IsDefault { get; set; }


        public long RecordId { get; set; }



        public string CCDetails { get; set; }



    }


    public class Customer_CCDetails
    {


        //
        public long Id { get; set; }


        public int CustomerId { get; set; }



        public string CCDetails { get; set; }

        public bool? IsDefault { get; set; }



    }

    #endregion

}
