using System;

using System.Linq;
using System.Windows.Forms;
using System.IO;


using System.Data;

using Taxi_Model;
using Utils;
using System.Threading;


using System.Diagnostics;
using DotNetCoords;
using System.Collections.Generic;

namespace Taxi_AppMain
{
 

    static class Program
    {
        public static string[] onrestartArgs = null;
        public static DataSet dtCombos = null;
        private static DateTime? lastExceptionOn = null;

        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b8";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static ClsLic objLic = new ClsLic();


     


       public static void FillCombos()
        {

            try
            {
                if (Program.dtCombos == null || Program.dtCombos.Tables.Count==0)
                {
                    Program.dtCombos = new DataSet();
                    using (System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(Cryptography.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToStr(), "tcloudX@@!", true)))
                    {

                        sqlconn.Open();

                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                        {

                            cmd.Connection = sqlconn;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "stp_fillbookingcombos";

                            using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                            {

                                da.Fill(Program.dtCombos);
                            }

                        }

                    }

                }
            }
            catch
            {

            }
        }



        //public class ClsSample
        //{
        //    public string From;
        //    public string To;
        //    public string Vehicle_Type;
        //    public decimal? Driver;
        //    public decimal? C_Fare;
        //    public decimal? H_Fee;
        //    public decimal? A_Fee;
        //    public decimal? Total;
        //    public string FileName;


        //}
        //public static DotNetCoords.LatLng GetCentroid(List<Gen_Zone_PolyVertice> poly)
        //{
        //    double? accumulatedArea = 0.0f;
        //    double? centerX = 0.0f;
        //    double? centerY = 0.0f;
        //    for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
        //    {
        //        double? temp = poly[i].Latitude * poly[j].Longitude - poly[j].Latitude * poly[i].Longitude;
        //        accumulatedArea += temp;
        //        centerX += (poly[i].Latitude + poly[j].Latitude) * temp;
        //        centerY += (poly[i].Longitude + poly[j].Longitude) * temp;
        //    }
        //    //if (Math.Abs(accumulatedArea) < 1E-7f)
        //    //    return null;  // Avoid division by zero
        //    accumulatedArea *= 3f;
        //    //   return new  LatLng(Convert.ToDouble ( centerX / accumulatedArea), Convert.ToDouble(centerY / accumulatedArea));
        //    try
        //    {
        //        return new LatLng(Convert.ToDouble(centerX / accumulatedArea), Convert.ToDouble(centerY / accumulatedArea));
        //    }
        //    catch
        //    {
                
        //        return new LatLng(0.00, 0.00);
        //    }
        //}

        //    public class clsdata
        //{

        //    public string PostCode;
        //    public string Data;
        //}

        //public class clsdatA1
        //{

        //    public string PostCode;
        //    public double Latitude;
        //    public double Longitude;
        //}

        [STAThread]
        static void Main(string[] args)
        {

            //using (TaxiDataContext db = new TaxiDataContext())
            //{
            //    string conn= db.Connection.ConnectionString;
            //    string ids = "";
            //    int wrong = 0;
            //    foreach (var item in db.Customers.ToList())
            //    {
                   

            //        string postcode =General.GetPostCodeMatch(item.Address1.ToStr().ToUpper());
                   
            //        if(postcode.Length==0 || postcode.Contains(" ") == false)
            //        {
            //            ids += item.Id + ",";
            //            wrong++;
            //        }
                   


            //    }


            //    if(ids.Length>0)
            //    {
            //        ids = ids.TrimEnd(new char[] { ',' });

            //        db.ExecuteQuery<int>("update customer set address1='XXX'  where id in(" + ids + ")");

            //    }


            //}

            //string dayname = DateTime.Now.DayOfWeek.ToStr();

            //int day = DateTime.Now.DayOfWeek.ToInt();
            //int day2 = DateTime.Now.ToDate().AddDays(-3).DayOfWeek.ToInt();
            //using (TaxiDataContext db = new TaxiDataContext())
            //{

            //    foreach (var item in db.Gen_RecentAddresses)
            //    {


            //        db.ExecuteQuery<string>("exec stp_savegeneraladdress {0}", item.AddressLine1);

            //    }



            //}

            //   var data=    General.GetVTRACKMileage();



            if (args != null && args.Count() > 0)
                onrestartArgs = args;



            int allowInstances = 1;

            try
            {
                allowInstances = System.Configuration.ConfigurationManager.AppSettings["allowinstances"].ToInt();
            }
            catch
            {

            }

            //if (Debugger.IsAttached)
            //{

            //    using (TaxiDataContext db = new TaxiDataContext("Data Source=5.9.156.40,52565; Initial Catalog=KentishTransportLtd;User ID =ken321; Password=ken321!; Trusted_Connection=false;"))
            //    {






            //        try
            //        {
            //            var listA = db.ExecuteQuery<clsdatA1>("select * from missingpostcodes").ToList();


            //            var list = db.ExecuteQuery<clsdata>("select Postcode,Data from missingpostcodes_detaildata").ToList();

            //            foreach (var item in listA)
            //            {

            //                string postcode = item.PostCode.ToUpper();
            //                int cnt = db.ExecuteQuery<int>("select count(*) from kentishtransportltd_pafdb.dbo.maindata where postcode='" + postcode + "'").FirstOrDefault();



            //                if (cnt == 0)
            //                {


            //                    int recordcnter = 0;

            //                    var postcodelist = list.Where(c => c.PostCode == postcode).ToList();

            //                    foreach (var item2 in postcodelist)
            //                    {



            //                        string data = item2.Data.ToUpper();

            //                        string street = data;

            //                        var arr = street.Split(' ');

            //                        string doorno = arr[0].ToStr();

            //                        if (doorno.IsNumeric())
            //                            street = street.Replace(doorno, "").Trim();


            //                        if(postcode=="TN24 0XX")
            //                        {

            //                        }


            //                        var data2 = listA.FirstOrDefault(c => c.PostCode == postcode);

            //                        if (recordcnter == 0)
            //                        {
            //                            if (postcodelist.Where(c => c.Data.ToUpper().Replace(c.Data.ToUpper().Split(' ')[0], "").Trim() == street).Count() == postcodelist.Count)
            //                            {
            //                                street = street.Replace(",", " ").Trim().ToUpper().Replace("  ", " ").Trim();


            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.maindata(POSTCODE,STREET,LATITUDE,LONGITUDE,POSTCODEID,town,substreet,locality)VALUES('" + postcode + "','" + street + "'," + data2.Latitude + "," + data2.Longitude + ",105,'"+""+"','"+""+"','"+""+"')");
            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.detaildata(POSTCODE,Postcodetype,data)VALUES('" + postcode + "','" + "R" + "','" + doorno + "')");

            //                            }
            //                            else
            //                            {
            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.maindata(POSTCODE,STREET,LATITUDE,LONGITUDE,POSTCODEID,town,substreet,locality)VALUES('" + postcode + "','" + "" + "'," + data2.Latitude + "," + data2.Longitude + ",105,'" + "" + "','" + "" + "','" + "" + "')");

            //                                street = street.Replace(",", " ").Trim().ToUpper().Replace("  ", " ").Trim();

            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.detaildata(POSTCODE,Postcodetype,data)VALUES('" + postcode + "','" + "R" + "','" + street + "')");

            //                            }




            //                        }
            //                        else
            //                        {

            //                            street = street.Replace(",", " ").Trim().ToUpper().Replace("  ", " ").Trim();

            //                            int cnt2 = db.ExecuteQuery<int>("select count(*) from kentishtransportltd_pafdb.dbo.maindata where postcode='" + postcode + "' and len('"+street+"')=0").FirstOrDefault();

            //                            if (cnt2 > 0)
            //                            {


            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.detaildata(POSTCODE,Postcodetype,data)VALUES('" + postcode + "','" + "R" + "','" + street + "')");
            //                            }
            //                            else
            //                            {
            //                                db.ExecuteQuery<int>("INSERT INTO kentishtransportltd_pafdb.dbo.detaildata(POSTCODE,Postcodetype,data)VALUES('" + postcode + "','" + "R" + "','" + doorno + "')");

            //                            }

            //                        }

            //                        recordcnter++;


            //                    }
            //                }
            //                else
            //                {

            //                }

            //            }


            //        }
            //        catch (Exception ex)
            //        {

            //        }


            //    }
            //}

            //            using (TaxiDataContext db = new TaxiDataContext())
            //            {
            //                 var files=System.IO.File.ReadAllLines(Application.StartupPath + "\\SaveBooking.txt");
            //                var data= db.Bookings.Where(c => c.JourneyTypeId == 2 && (c.BookingStatusId == 1 || c.BookingStatusId==17));
            //                string s = "";
            //                foreach (var item in data)
            //                {
            //                    if(files.Count(c=>c.Contains(item.Id.ToStr()))>0)
            //                    {
            //                        s += item.Id.ToStr() + "," + (item.Id.ToLong()+1) + ",";
            //;                        if (item.FromDoorNo.ToStr().Trim().Length == 0 ||
            //                            (item.SpecialRequirements.ToStr().Trim().Length > 0 && item.BookingReturns[0].SpecialRequirements.ToStr().Trim().Length == 0))
            //                        {

            //                        }
            //}

            //                    }


            //                }




            //using (TaxiDataContext db = new TaxiDataContext())
            //{
            //    AppVars.objPolicyConfiguration = new Gen_SysPolicy_Configuration();

            //    int startCounter = 0;
            //    var listofvehicles = db.Fleet_VehicleTypes.ToList();
            //    var listofaccounts = db.Gen_Companies.ToList();
            //    var zonelist = db.Gen_Zones.ToList();
            //    var addresses = db.Gen_Company_Addresses.ToList();
            //    var list2 = db.ExecuteQuery<ClsSample>("SELECT *  FROM sample2 where isupdated is null").ToList();
            //    foreach (var item in db.ExecuteQuery<ClsSample>("SELECT DISTINCT Vehicle_Type,FILENAME  FROM sample2 order by filename").ToList())
            //    {

            //        int VEHICLETYPEID = listofvehicles.FirstOrDefault(c => c.VehicleType.ToUpper() == item.Vehicle_Type.ToUpper()).DefaultIfEmpty().Id.ToInt();
            //        int COMPANYID = listofaccounts.FirstOrDefault(c => c.CompanyName.ToUpper() == item.FileName.ToUpper()).DefaultIfEmpty().Id.ToInt();

            //        if (VEHICLETYPEID > 0 && COMPANYID > 0)
            //        {


            //            var Id = db.Fares.Where(c => c.VehicleTypeId == VEHICLETYPEID && c.CompanyId == COMPANYID
            //                                 && c.SubCompanyId == 1)
            //                                 .Select(c => c.Id).FirstOrDefault().ToInt();



            //            if (Id == 0)
            //            {
            //                Taxi_BLL.FareBO objMaster = new Taxi_BLL.FareBO();
            //                objMaster.New();
            //                objMaster.Current.VehicleTypeId = VEHICLETYPEID;
            //                objMaster.Current.CompanyId = COMPANYID;
            //                objMaster.Current.SubCompanyId = 1;
            //                objMaster.Save();



            //            }
            //            else
            //            {

            //                foreach (var item2 in list2.Where(c => c.Vehicle_Type == item.Vehicle_Type && c.FileName.ToUpper() == item.FileName.ToUpper()).ToList())
            //                {

            //                    Fare_ChargesDetail c = new Fare_ChargesDetail();
            //                    c.FareId = Id;
            //                    c.Rate = item2.Driver.ToDecimal();
            //                    c.CompanyRate = item2.C_Fare.ToDecimal();

            //                    if (c.CompanyRate.ToDecimal() == 0)
            //                        c.CompanyRate = c.Rate;

            //                    c.PeakTimeRate = item2.H_Fee.ToDecimal();
            //                    c.OffPeakTimeRate = item2.A_Fee.ToDecimal();


            //                    int fromzoneid = zonelist.FirstOrDefault(a => a.ZoneName == item2.From || a.ShortName == item2.From || a.ZoneName.ToUpper().Contains(item2.From.ToUpper())).DefaultIfEmpty().Id.ToInt();



            //                    int tozoneid = zonelist.FirstOrDefault(a => a.ZoneName == item2.To || a.ShortName == item2.To || a.ZoneName.ToUpper().Contains(item2.To.ToUpper())).DefaultIfEmpty().Id.ToInt();

            //                    string fromaddress = addresses.Where(a => a.CompanyId == COMPANYID).FirstOrDefault().Address.ToStr().ToUpper();
            //                    string toaddress = addresses.Where(a => a.CompanyId == COMPANYID).FirstOrDefault().Address.ToStr().ToUpper();


            //                    if (fromzoneid == 0 && tozoneid == 0)
            //                        continue;

            //                    if (fromzoneid > 0)
            //                    {
            //                        c.OriginLocationTypeId = 100;
            //                        c.FromZoneId = fromzoneid;
            //                        c.FromAddress = item2.From;

            //                    }
            //                    else
            //                    {
            //                        c.OriginLocationTypeId = 8;
            //                        c.FromAddress = General.GetPostCodeMatch(fromaddress);

            //                    }

            //                    if (tozoneid > 0)
            //                    {
            //                        c.DestinationLocationTypeId = 100;
            //                        c.ToZoneId = tozoneid;
            //                        c.ToAddress = item2.To;

            //                    }
            //                    else
            //                    {
            //                        c.DestinationLocationTypeId = 8;
            //                        c.ToAddress = General.GetPostCodeMatch(toaddress);

            //                    }

            //                    db.Fare_ChargesDetails.InsertOnSubmit(c);
            //                    db.SubmitChanges();

            //                    db.ExecuteQuery<int>("update [sample2] set isupdated=1 where [from]='" + item2.From + "' and [to]='" + item2.To + "' and filename='" + item2.FileName + "' and vehicle_type='" + item2.Vehicle_Type + "'");

            //                }

            //            }

            //        }
            //        else
            //        {

            //        }

            //        startCounter++;


            //    }


            //}




            //if (Debugger.IsAttached)
            //{

            //    using (TaxiDataContext db = new TaxiDataContext())
            //    {





            //        try
            //        {
            //            var listA = db.Customer_Histories.Where(c => c.MobileNo.Contains(",")).ToList();
            //            int cnt = 1;
            //            string s ="";
            //            foreach (var item in listA)
            //            {
            //                cnt++;

            //                try
            //                {
            //                    var arr = item.MobileNo.Split(',');


            //                    if (arr[0].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[0];
            //                    }
            //                    else if (arr[1].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[1];

            //                    }
            //                    else if (arr[2].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[2];
            //                    }
            //                    else if (arr[3].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[3];
            //                    }
            //                    else if (arr[4].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[4];
            //                    }
            //                    else if (arr[5].StartsWith("0"))
            //                    {
            //                        item.MobileNo = arr[5];
            //                    }

            //                    s += "update customer_history set mobileno='" + item.MobileNo + "' where id=" + item.Id + ";";

            //                    //if (cnt >= 30000)
            //                    //    break;
            //                }
            //                catch(Exception ex)
            //                {

            //                }

            //            }

            //            db.ExecuteQuery<int>(s);

            //            //foreach (var item in listA)
            //            //{

            //            //    if (db.Gen_Locations.Count(c => c.LocationName == item.ZoneName) == 0)
            //            //    {

            //            //        Taxi_BLL.LocationBO obj = new Taxi_BLL.LocationBO();
            //            //        try
            //            //        {
            //            //            obj.New();

            //            //            obj.Current.LocationName = item.ZoneName.ToStr().ToUpper().Trim();
            //            //            obj.Current.Address = item.ZoneName.ToStr().ToUpper().Trim();
            //            //            obj.Current.FullLocationName = item.ZoneName.ToStr().ToUpper().Trim();
            //            //            obj.Current.LocationTypeId = 7;
            //            //            obj.Current.PostCode = "";
            //            //            obj.Current.ZoneId = item.Id;

            //            //            var coord = GetCentroid(item.Gen_Zone_PolyVertices.ToList());

            //            //            if (coord != null && coord.Latitude != 0)
            //            //            {

            //            //                obj.Current.Latitude = coord.Latitude;
            //            //                obj.Current.Longitude = coord.Longitude;
            //            //            }


            //            //            obj.Save();

            //            //        }
            //            //        catch (Exception ex)
            //            //        {

            //            //        }

            //            //    }

            //            //}


            //        }
            //        catch (Exception ex)
            //        {

            //        }


            //    }
            //}


            //if (Debugger.IsAttached)
            //{

            //    using (TaxiDataContext db = new TaxiDataContext())
            //    {






            //        try
            //        {
            //            var listA = db.Fleet_Driver_Locations.Where(c => c.ZoneId == null  ).OrderBy(c=>c.PlotDate).ToList();



            //            foreach (var item in listA)
            //            {



                           
            //                var zoneId = General.GetZoneIdTest(item.Latitude+","+item.Longitude);


            //                if (zoneId != null)
            //                {
            //                    item.ZoneId = zoneId;

            //                    db.SubmitChanges();

            //                }
            //            }


            //        }
            //        catch (Exception ex)
            //        {

            //        }


            //    }
            //}




            // uPDATE ZONE ORDER NO FROM ZONE NAME
            //if (Debugger.IsAttached)
            //{

            //    using (TaxiDataContext db = new TaxiDataContext("Data Source=5.9.156.40,52565;Initial Catalog=ArrowTransportHWLtd;User ID=ath321;Password=ath321!;Trusted_Connection=False;"))
            //    {






            //        try
            //        {
            //            var listA = db.Gen_Zones.Where(c => c.MaxLatitude != null).ToList();



            //            foreach (var item in listA)
            //            {

            //                try
            //                {
            //                    int orderno = item.ZoneName.Split(' ')[0].ToInt();


            //                    item.OrderNo = orderno;
            //                    db.SubmitChanges();
            //                }
            //                catch
            //                {

            //                }
            //            }


            //        }
            //        catch (Exception ex)
            //        {

            //        }


            //    }
            //}




            if (allowInstances > 1)
                {
                    allowInstances++;
                    if (args == null || args.Count() == 0)
                    {
                        int cnt = Process.GetProcesses().Where(c => c.ProcessName.ToLower() == "taxi_appmain").Count();

                        if (allowInstances == cnt)
                        {
                            Environment.Exit(0);
                            return;
                        }

                    }
                    else
                    {

                        if (args != null && args.Count() > 0)
                        {
                            int cnt = Process.GetProcesses().Where(c => c.ProcessName.ToLower() == "taxi_appmain").Count();

                            if (allowInstances == cnt)
                            {
                                Environment.Exit(0);
                                return;
                            }



                        }

                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);



                    try
                    {




                        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

                        frmSplashScreen frmS = new frmSplashScreen();
                        frmS.ShowInTaskbar = false;
                        frmS.StartPosition = FormStartPosition.CenterScreen;
                        frmS.ShowDialog();

                        clientName = frmS.clientName;
                        throwMsg = frmS.Tag.ToStr();


                        if (frmS.IsVerified.ToBool())
                        {
                            if (string.IsNullOrEmpty(clientName.ToStr()))
                            {
                                throw new Exception(throwMsg);
                            }



                            StartApp();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(throwMsg.ToStr().Trim()))
                            {
                                Application.Run(new frmLicenseKey());
                            }
                            else
                            {
                                throw new Exception(throwMsg);

                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        ENUtils.ShowMessage(ex.Message);
                        new TaxiDataContext().stp_AddLog(ex.Message + ",Target : " + ex.TargetSite + ",Source : " + ex.Source + ",Stack Trace :" + ex.StackTrace, "Program", "");

                    }

                    finally
                    {


                        Process.GetCurrentProcess().Kill();


                    }


                }
                else
                {

                    using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
                    {
                        if (args == null || args.Count() == 0)
                        {

                            if (!mutex.WaitOne(0, false))
                            {

                                Environment.Exit(0);
                                return;
                            }
                        }
                        else
                        {

                            if (args != null && args.Count() > 0)
                            {


                                foreach (var item in Process.GetProcesses().Where(c => c.ProcessName.ToLower() == "taxi_appmain"))
                                {

                                    if (item.Id != Process.GetCurrentProcess().Id)
                                    {

                                        item.Kill();

                                        item.Close();

                                    }
                                }




                            }

                        }

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);


                        try
                        {


                            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

                            frmSplashScreen frmS = new frmSplashScreen();
                            frmS.ShowInTaskbar = false;
                            frmS.StartPosition = FormStartPosition.CenterScreen;
                            frmS.ShowDialog();

                            clientName = frmS.clientName;
                            throwMsg = frmS.Tag.ToStr();


                            if (frmS.IsVerified.ToBool() || Debugger.IsAttached)
                            {
                                if (string.IsNullOrEmpty(clientName.ToStr()))
                                {
                                    throw new Exception(throwMsg);
                                }



                                StartApp();
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(throwMsg.ToStr().Trim()))
                                {
                                    Application.Run(new frmLicenseKey());
                                }
                                else
                                {
                                    throw new Exception(throwMsg);

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            ENUtils.ShowMessage(ex.Message);
                            new TaxiDataContext().stp_AddLog(ex.Message + ",Target : " + ex.TargetSite + ",Source : " + ex.Source + ",Stack Trace :" + ex.StackTrace, "Program", "");

                        }

                        finally
                        {


                            Process.GetCurrentProcess().Kill();


                        }

                    }
                }
        }





        public static DotNetCoords.LatLng GetCentroid(List<Gen_Zone_PolyVertice> poly)
        {
            double? accumulatedArea = 0.0f;
            double? centerX = 0.0f;
            double? centerY = 0.0f;

            for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                double? temp = poly[i].Latitude * poly[j].Longitude - poly[j].Latitude * poly[i].Longitude;
                accumulatedArea += temp;
                centerX += (poly[i].Latitude + poly[j].Latitude) * temp;
                centerY += (poly[i].Longitude + poly[j].Longitude) * temp;
            }

            //if (Math.Abs(accumulatedArea) < 1E-7f)
            //    return null;  // Avoid division by zero

            accumulatedArea *= 3f;
            //   return new  LatLng(Convert.ToDouble ( centerX / accumulatedArea), Convert.ToDouble(centerY / accumulatedArea));

            try
            {
                return new LatLng(Convert.ToDouble(centerX / accumulatedArea), Convert.ToDouble(centerY / accumulatedArea));


            }
            catch
            {

              


                return new LatLng(0.00, 0.00);


            }
        }



        /// <summary>
        /// Finds the MAC address of the first operation NIC found.
        /// </summary>
        /// <returns>The MAC address.</returns>
        public static string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }


        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {

            try
            {
                if (lastExceptionOn == null || DateTime.Now.AddMinutes(-2) > lastExceptionOn)
                {

                    lastExceptionOn = DateTime.Now;
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                      

                        if (e.Exception.StackTrace.Contains("Telerik.WinControls.Layouts.ContextLayoutManager.LayoutQueue.GetTopMost"))
                        {
                           db.stp_AddLog("Program Restarted:"+e.Exception.Message + ",Target : " + e.Exception.TargetSite + ",Source : " + e.Exception.Source + ",Stack Trace :" + e.Exception.StackTrace, Environment.MachineName, "");

                            ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard")).RestartProgram();
                        }
                        else
                            db.stp_AddLog(e.Exception.Message + ",Target : " + e.Exception.TargetSite + ",Source : " + e.Exception.Source + ",Stack Trace :" + e.Exception.StackTrace, Environment.MachineName, "");

                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        static string clientName = string.Empty;
        static string throwMsg = string.Empty;
        private static bool VerifyLicense()
        {

            bool verify = false;

            try
            {
                throwMsg = string.Empty;

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    clientName = db.Gen_SysPolicy_Configurations.Select(c => c.DefaultClientId).FirstOrDefault();
                }

                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\SysData.dll")
                    && Cryptography.Decrypt(File.ReadAllText(System.Windows.Forms.Application.StartupPath + "\\SysData.dll"), (clientName + "!@#"), true).Equals((clientName)))
                {


                    verify = true;
                    AppVars.LicenseChecked = true;
                }

                else
                {


                    try
                    {

                        if (clientName.ToStr().Trim().Length == 0)
                        {
                            throwMsg = "Authentication Failed...";

                        }
                        else
                        {





                            verify = General.VerifyLicense(clientName);

                            if (verify == false)
                            {
                                if (objLic.Reason.ToStr().Trim().ToLower().Contains("could not be resolved"))
                                {
                                    throwMsg = "Authentication Failed...";
                                }
                                else
                                {
                                    throwMsg = objLic.Reason.ToStr();
                                }
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        throwMsg = ex.Message.ToStr();

                    }





                    //using (LicDataContextDataContext db = new LicDataContextDataContext())
                    //{


                    //    stp_SysPolicyAuthResult objClient = db.stp_SysPolicyAuth(clientName).FirstOrDefault();

                    //    if (objClient != null)
                    //    {

                    //        if (objClient.ScriptType.ToStr().ToLower() == "valid")
                    //        {
                    //            verify = true;
                    //        }

                    //        AppVars.LicenseExpiryDate = "License will Expire on " + string.Format("{0:dd/MMM/yyyy HH:mm}", objClient.LastCondition.ToDateTimeorNull());
                    //    }
                    //    else
                    //    {

                    //        MessageBox.Show("Authentication Failed...");

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                throwMsg = ex.Message.ToStr();

                //if (ex.Message.ToLower().StartsWith("a network-related") && string.IsNullOrEmpty(clientName))
                //    verify = true;


                //else if (ex.Message.ToLower().Contains("invalid column"))
                //{
                //    MessageBox.Show(ex.Message);
                //    verify = true;

                //}
                //else
                //    verify = VerifySystemLicense();

                //  return true;
            }


            return verify;
        }

     


        public static void StartApp()
        {

            try
            {

                if (onrestartArgs == null)
                    Application.Run(new frmLogin());
                else
                    Application.Run(new frmLogin(onrestartArgs));


            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }

        }




    }
}
