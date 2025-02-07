using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmAlertShowFares : Form
    {
        private long FareMasterId;

        private int SUBCOMPANYID;
        private int? COMPANYID,FROMZONEID,TOZONEID;
        private int VEHICLETYPEID;
        private decimal DRIVERFARE,ACCOUNTFARE,AGENTCOMM,AGENTCHARGE;
        private string FROMADDRESS, TOADDRESS;
        public frmAlertShowFares(int subcompanyId, int? companyId,int vehicleTypeId,decimal driverfare
            ,decimal accountfare,decimal agentcomm,decimal agentcharge,int? fromzoneid,int? tozoneid,string fromaddress,string toaddress)
        {
            InitializeComponent();
            SUBCOMPANYID = subcompanyId;
            COMPANYID = companyId;
            VEHICLETYPEID = vehicleTypeId;
            DRIVERFARE = driverfare;
            ACCOUNTFARE = accountfare;
            AGENTCOMM = agentcomm;
            AGENTCHARGE = agentcharge;
            FROMZONEID = fromzoneid;
            TOZONEID = tozoneid;
            FROMADDRESS = fromaddress;
            TOADDRESS = toaddress;


            this.Load += new EventHandler(frmCustomMessageBox_Load);

        }

        private long FAREDETAILID;

        void frmCustomMessageBox_Load(object sender, EventArgs e)
        {
            try
            {
                ComboFunctions.FillLocationTypeCombo(ddlFromLocType, c => c.Id == 8 || c.Id == 100);
                ComboFunctions.FillLocationTypeCombo(ddlToLocType, c => c.Id == 8 || c.Id == 100);



                ddlFromLocType.SelectedValue = 8;
                ddlToLocType.SelectedValue = 8;

                using (Taxi_Model.TaxiDataContext db = new Taxi_Model.TaxiDataContext())
                {

                    var Id = db.Fares.Where(c => c.VehicleTypeId == VEHICLETYPEID && (COMPANYID == null || c.CompanyId == COMPANYID)
                                            && c.SubCompanyId == SUBCOMPANYID)
                                            .Select(c => c.Id).FirstOrDefault().ToInt();


                    FareMasterId = Id;
                    if (Id==0)
                    {
                        Taxi_BLL.FareBO objMaster = new Taxi_BLL.FareBO();
                        objMaster.New();
                        objMaster.Current.VehicleTypeId = VEHICLETYPEID;
                        objMaster.Current.CompanyId = COMPANYID;
                        if (objMaster.Current.CompanyId.ToInt() > 0)
                            objMaster.Current.IsCompanyWise = true;

                        objMaster.Current.SubCompanyId = SUBCOMPANYID;
                        objMaster.Save();

                        FareMasterId = objMaster.Current.Id;

                    }
                    else
                    {
                        Taxi_Model.Fare_ChargesDetail obj = null;


                        string frompostcode = General.GetPostCodeMatch(FROMADDRESS);
                        string topostcode = General.GetPostCodeMatch(TOADDRESS);




                       

                        if(frompostcode.Length>0 && topostcode.Length>0)
                          obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && c.FromAddress == frompostcode && c.ToAddress == topostcode);



                        if (obj==null)
                        {

                            try
                            {
                             
                                

                                if (frompostcode.Length > 0 && TOZONEID!=null)
                                    obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && c.FromAddress == frompostcode && (c.ToZoneId!=null && c.ToZoneId ==TOZONEID));
                            }
                            catch
                            {

                            }


                            try
                            {


                                if (obj == null)
                                {
                                    if (frompostcode.Length > 0 && frompostcode.Contains(" ") && TOZONEID != null)
                                        obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && c.FromAddress == frompostcode.Split(' ')[0] && (c.ToZoneId != null && c.ToZoneId == TOZONEID));

                                }
                            }
                            catch
                            {

                            }




                            try
                            {


                                if (obj == null)
                                {

                                    if (topostcode.Length > 0 && FROMZONEID != null)
                                        obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && (c.FromZoneId != null && c.FromZoneId == FROMZONEID) && c.ToAddress == topostcode);

                                }
                            }
                            catch
                            {

                            }


                            try
                            {
                                if (obj == null)
                                {


                                    if (topostcode.Length > 0 && topostcode.Contains(" ") && FROMZONEID != null)
                                        obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && (c.FromZoneId != null && c.FromZoneId == FROMZONEID) && c.ToAddress == topostcode.Split(' ')[0]);
                                }


                            }
                            catch
                            {

                            }




















                            try
                            {
                                frompostcode = frompostcode.Split(' ')[0];
                                topostcode = topostcode.Split(' ')[0];

                                if (obj == null)
                                {
                                    if (frompostcode.Length > 0 && topostcode.Length > 0)
                                        obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && c.FromAddress == frompostcode && c.ToAddress == topostcode);
                                }


                            }
                            catch
                            {

                            }


                            if(obj==null && FROMZONEID!=null && TOZONEID!=null)
                                obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.FareId == FareMasterId && c.FromZoneId!=null && c.FromZoneId == FROMZONEID && c.ToZoneId!=null && c.ToZoneId == TOZONEID);




                        }


                        if (obj != null)
                        {
                            FAREDETAILID = obj.Id;

                            ddlFromLocType.Enabled = false;
                            ddlToLocType.Enabled = false;
                            ddlFromLocType.SelectedValue = obj.OriginLocationTypeId;
                            ddlToLocType.SelectedValue = obj.DestinationLocationTypeId;
                        }
                    }



                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void CloseForm()
        {

            Close();
            Dispose(true);
        }

      
        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {

                if(ddlFromLocType.SelectedValue.ToInt()==Taxi_BLL.Enums.LOCATION_TYPES.POSTCODE && General.GetPostCodeMatch(FROMADDRESS).Length==0)
                {
                    MessageBox.Show("Pickup Address does not contain [POSTCODE]");
                    return;
                }

                if (ddlFromLocType.SelectedValue.ToInt() == 100 && FROMZONEID.ToInt()==0)
                {
                    MessageBox.Show("Pickup Address does not contain [PLOT]");
                    return;
                }




                if (ddlToLocType.SelectedValue.ToInt() == Taxi_BLL.Enums.LOCATION_TYPES.POSTCODE && General.GetPostCodeMatch(TOADDRESS).Length == 0)
                {
                    MessageBox.Show("DropOff Address does not contain [POSTCODE]");
                    return;
                }

                if (ddlToLocType.SelectedValue.ToInt() == 100 && TOZONEID.ToInt()==0)
                {
                    MessageBox.Show("DropOff Address does not contain [PLOT]");
                    return;
                }

                using (Taxi_Model.TaxiDataContext db = new Taxi_Model.TaxiDataContext())
                {

                    if (FareMasterId > 0)
                    {
                        Taxi_Model.Fare_ChargesDetail obj = null;

                        if (FAREDETAILID > 0)
                        {
                            obj = db.Fare_ChargesDetails.FirstOrDefault(c => c.Id == FAREDETAILID);

                        }
                        else
                        {
                            obj = new Taxi_Model.Fare_ChargesDetail();
                            obj.FareId = FareMasterId.ToInt();
                        }

                        if (obj != null)
                        {
                            try
                            {
                                if (FAREDETAILID==0)
                                {
                                    obj.FromAddress = General.GetPostCodeMatch(FROMADDRESS);
                                    obj.ToAddress = General.GetPostCodeMatch(TOADDRESS);
                                }
                            }
                            catch
                            {

                            }
                            if (ddlFromLocType.SelectedValue.ToInt() == 100 && FROMZONEID!=null)
                            {
                                obj.FromZoneId = FROMZONEID;
                                obj.OriginLocationTypeId = 100;

                            }
                            else
                                obj.OriginLocationTypeId = 8;


                            if (ddlToLocType.SelectedValue.ToInt() == 100 && TOZONEID!=null)
                            {
                               
                                obj.ToZoneId = TOZONEID;
                                obj.DestinationLocationTypeId = 100;

                            }
                            else
                                obj.DestinationLocationTypeId = 8;

                            obj.Rate = DRIVERFARE;
                            obj.CompanyRate = ACCOUNTFARE;
                            obj.PeakTimeRate = AGENTCOMM;
                            obj.OffPeakTimeRate = AGENTCHARGE;



                        }

                        if (obj.Id == 0)
                            db.Fare_ChargesDetails.InsertOnSubmit(obj);

                        db.SubmitChanges();



                    }


                }

                CloseForm();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

         
          
           
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
           
            CloseForm();
        }
    }
}
