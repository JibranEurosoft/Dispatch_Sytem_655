using System;

using System.Data;

using System.Linq;
using System.Windows.Forms;
using Taxi_Model;

using Telerik.WinControls.UI;

using Utils;
namespace Taxi_AppMain
{
    public partial class frmBookingMemberDetail : UI.SetupBase
    {
        public string email = string.Empty;
        public string passengerType = string.Empty;
        public string companyCode = string.Empty;


        public frmBookingMemberDetail(long bookingId, int companyId,string companyName,string Acccompanycode,string passengerType,string bookerEmail)
        {
            InitializeComponent();
            btnExit.Click += BtnExit_Click;
            try
            {
                FillCompanyCode(ddlCompanyCode, companyId);


                if (bookingId > 0)

                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.DeferredLoadingEnabled = true;

                        var obj = db.Booking_MemberDetails.FirstOrDefault(c => c.BookingId == bookingId);


                        if (obj != null)
                        {
                            txtBookedByEmail.Text = obj.BookerEmail.ToStr();
                            ddlPassengerType.Text = obj.EmployeeType.ToStr();
                            ddlCompanyCode.SelectedValue = obj.CompanyCode.ToStr();


                        }


                    }


                }
                else
                {
                    txtBookedByEmail.Text = bookerEmail.ToStr();
                    ddlPassengerType.Text = passengerType.ToStr();
                    ddlCompanyCode.SelectedValue = Acccompanycode.ToStr();


                }


                txtAccountName.Text = companyName;
            }
            catch
            {

            }
        }








        public static void FillCompanyCode(RadDropDownList dropdown, int CompanyId)
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    ComboFunctions.FillCombo
                        (db.Gen_Company_CompanyCodes.Where(c => c.CompanyId == CompanyId)
                        .Select(args => new { args.CompanyCode, args.Id }).ToList(), dropdown, "CompanyCode", "CompanyCode");



                }
            }
            catch
            {

            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            SaveData();

            
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if(ddlCompanyCode.SelectedIndex==-1 && ddlCompanyCode.Items.Count>0 && AppVars.objPolicyConfiguration.PickCompanyAddressOnBooking.ToBool()==false)
            {
                MessageBox.Show("Required : Company Code");
                return;
            }


            SaveData();
        }

        private void SaveData()
        {

            email = txtBookedByEmail.Text;
            passengerType = ddlPassengerType.Text;
            companyCode = ddlCompanyCode.Text;
            this.Close();
        }

    }
        
}
