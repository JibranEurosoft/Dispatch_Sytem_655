using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using UI;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using System.Xml.Linq;

namespace Taxi_AppMain
{
    public partial class frmAddNewWhiteListAddress : UI.SetupBase
    {
        WhiteListAddressBO objMaster;
        private int _MapType;

        public int MapType
        {
            get { return _MapType; }
            set { _MapType = value; }
        }

        public frmAddNewWhiteListAddress()
        {
            InitializeComponent();

            objMaster = new WhiteListAddressBO();

            this.SetProperties((INavigation)objMaster);
            //787, 430
            txtAddress.ListBoxElement.Width = 500;
            txtAddress.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtAddress.DefaultHeight = 230;
            timer1.Tick += new EventHandler(timer1_Tick);
            txtAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
            txtAddress.KeyPress += new KeyPressEventHandler(txtAddress_KeyPress);
            if (AppVars.objPolicyConfiguration != null)
            {

                MapType = AppVars.objPolicyConfiguration.MapType.ToInt();
            }
        }

        public frmAddNewWhiteListAddress(string address)
        {
            InitializeComponent();

            objMaster = new WhiteListAddressBO();

            this.SetProperties((INavigation)objMaster);
            //787, 430
            txtAddress.ListBoxElement.Width = 500;
            txtAddress.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtAddress.DefaultHeight = 230;
            timer1.Tick += new EventHandler(timer1_Tick);

            txtAddress.Text = address;

            txtAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
            txtAddress.KeyPress += new KeyPressEventHandler(txtAddress_KeyPress);
            if (AppVars.objPolicyConfiguration != null)
            {

                MapType = AppVars.objPolicyConfiguration.MapType.ToInt();
            }



        }

        #region TextChanged
        string[] res = null;
        string searchTxt = "";




        AutoCompleteTextBox aTxt = null;

        void TextBoxElement_TextChanged(object sender, EventArgs e)
        {


            try
            {

                // IsKeyword = false;

                InitializeTimer();
                timer1.Stop();

                aTxt = (AutoCompleteTextBox)sender;
                aTxt.ResetListBox();

                //if (aTxt.Name == "txtFromAddress")
                //    txtToAddress.SendToBack();

                //else if (aTxt.Name == "txtToAddress")
                //    txtToAddress.BringToFront();



                if (AppVars.objPolicyConfiguration.EnablePOI.ToBool())
                {

                    InitializeSearchPOIWorker();

                    if (POIWorker.IsBusy)
                    {
                        POIWorker.CancelAsync();

                        POIWorker.Dispose();
                        POIWorker = null;
                        GC.Collect();
                        InitializeSearchPOIWorker();

                    }


                    AddressTextChangePOI();
                }
                else
                {

                    AddressTextChangeWOPOI();
                }

            }
            catch (Exception ex)
            {

            }
        }

        BackgroundWorker POIWorker = null;
        private void InitializeSearchPOIWorker()
        {
            if (POIWorker == null)
            {
                POIWorker = new BackgroundWorker();
                POIWorker.WorkerSupportsCancellation = true;
                POIWorker.DoWork += new DoWorkEventHandler(POIWorker_DoWork);
                POIWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(POIWorker_RunWorkerCompleted);
            }



        }

        void POIWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null || e.Cancelled || (sender as BackgroundWorker) == null)
                return;

            try
            {


                ShowAddressesPOI((string[])e.Result);

            }
            catch
            {


            }
        }

        //void POIWorker_DoWork(object sender, DoWorkEventArgs e)
        //{


        //    string searchValue = e.Argument.ToStr();
        //    try
        //    {
        //        if (POIWorker == null)
        //        {
        //            e.Cancel = true;
        //            return;


        //        }

        //        //   Console.WriteLine("Start work : " + searchValue);

        //        string postCode = General.GetPostCodeMatchOpt(searchValue);

        //        string doorNo = string.Empty;
        //        string place = string.Empty;

        //        if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
        //            postCode = string.Empty;

        //        string street = searchValue;

        //        if (postCode.Length > 0)
        //        {
        //            street = street.Replace(postCode, "").Trim();
        //        }


        //        if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchValue.IndexOf(postCode) < searchValue.IndexOf(street))
        //        {
        //            street = "";
        //            postCode = searchTxt;
        //        }


        //        if (street.Length > 0)
        //        {

        //            if (char.IsNumber(street[0]))
        //            {

        //                for (int i = 0; i <= 3; i++)
        //                {
        //                    if (char.IsNumber(street[i]) || (doorNo.Length > 0 && doorNo.Length == i && char.IsLetter(street[i])))
        //                        doorNo += street[i];
        //                    else
        //                        break;
        //                }
        //            }
        //        }


        //        if (street.EndsWith("#"))
        //        {
        //            street = street.Replace("#", "").Trim();
        //            place = "p=";
        //        }

        //        if (doorNo.Length > 0 && place.Length == 0)
        //        {
        //            street = street.Replace(doorNo, "").Trim();


        //        }


        //        if (postCode.Length == 0 && street.Length < 3)
        //        {
        //            e.Cancel = true;
        //            return;

        //        }


        //        if (street.Length > 1 || postCode.Length > 0)
        //        {
        //            if (postCode.Length > 0)
        //            {
        //                if (doorNo.Length > 0 && postCode == General.GetPostCodeMatch(postCode))
        //                {
        //                    doorNo = string.Empty;
        //                }

        //            }

        //            if (postCode.Length >= 5 && postCode.Contains(" ") == false)
        //            {
        //                string resultPostCode = AppVars.listOfAddress.FirstOrDefault(a => a.PostalCode.Strip(' ') == postCode).DefaultIfEmpty().PostalCode.ToStr().Trim();


        //                if (resultPostCode.Length >= 5 && resultPostCode.Contains(" "))
        //                {
        //                    postCode = resultPostCode;

        //                }

        //            }


        //            if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
        //            {
        //                e.Cancel = true;
        //                return;
        //            }



        //            using (TaxiDataContext db = new TaxiDataContext())
        //            {
        //                e.Result = db.stp_GetByRoadLevelData(postCode, doorNo, street, place).Select(c => c.AddressLine1).ToArray<string>();

        //            }

        //            if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
        //            {
        //                e.Cancel = true;
        //                return;
        //            }




        //            //   Console.WriteLine("end work : " + searchValue);

        //        }
        //    }
        //    catch
        //    {
        //        //     Console.WriteLine("Start work catch: " + searchValue);

        //    }
        //}


        void POIWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            string searchValue = e.Argument.ToStr();
            try
            {
                if (POIWorker == null)
                {
                    e.Cancel = true;
                    return;


                }


                //
                string postCode = General.GetPostCodeMatchOpt(searchValue);

                string doorNo = string.Empty;
                string place = string.Empty;




                if (postCode.Length == 0 && searchValue.Trim().Contains(" ") && searchValue.Trim().Contains(".") == false && searchValue.Trim().Contains("#") == false
                  && searchValue[0].ToStr().IsAlpha() && searchValue.Split(new char[] { ' ' }).Any(c => c.IsAlpha() == false))
                //    && (searchValue.Trim().Substring(0, searchValue.Trim().IndexOf(' ')).ToStr().IsAlpha() == false || searchValue.Trim().Substring(searchValue.Trim().IndexOf(' ') + 1)[0].ToStr().IsAlpha()))
                {
                    var arrData = searchValue.Split(new char[] { ' ' });



                    if (arrData.Count() == 2)
                    {
                        postCode = General.GetPostCodeMatchOpt(arrData.FirstOrDefault(c => c.IsAlpha() == false));

                    }
                    else if (arrData.Count() > 2)
                    {

                        if (arrData[1][0].ToStr().IsNumeric())
                            postCode = General.GetPostCodeMatchOpt((arrData.FirstOrDefault(c => c.IsAlpha() == false) + " " + arrData[1]).Trim());
                        else if (arrData[1].ToStr().IsAlpha() == false && arrData[2].ToStr().IsAlpha() == false)
                            postCode = General.GetPostCodeMatchOpt((arrData.FirstOrDefault(c => c.IsAlpha() == false) + " " + arrData[2]).Trim());
                        else
                            postCode = General.GetPostCodeMatchOpt(arrData.FirstOrDefault(c => c.IsAlpha() == false));
                    }


                }

                if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                    postCode = string.Empty;

                string street = searchValue;

                if (postCode.Length > 0)
                {
                    street = street.Replace(postCode, "").Trim();
                }


                if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchValue.IndexOf(postCode) < searchValue.IndexOf(street))
                {
                    street = "";
                    postCode = searchTxt;
                }


                if (street.Length > 0)
                {

                    if (char.IsNumber(street[0]))
                    {

                        for (int i = 0; i <= 3; i++)
                        {

                            try
                            {
                                if (char.IsNumber(street[i]) || (doorNo.Length > 0 && doorNo.Length == i && char.IsLetter(street[i])))
                                    doorNo += street[i];
                                else
                                    break;
                            }
                            catch
                            {


                            }
                        }
                    }
                }


                if (street.Contains("#"))
                {
                    street = street.Replace("#", "").Trim();
                    place = "p=";
                }

                if (doorNo.Length > 0 && place.Length == 0)
                {
                    street = street.Replace(doorNo, "").Trim();


                }


                if (postCode.Length == 0 && street.Length < 3)
                {
                    e.Cancel = true;
                    return;

                }


                if (street.Length > 1 || postCode.Length > 0)
                {
                    if (postCode.Length > 0)
                    {
                        if (doorNo.Length > 0 && postCode == General.GetPostCodeMatch(postCode))
                        {
                            doorNo = string.Empty;
                        }

                    }

                    if (postCode.Length >= 5 && postCode.Contains(" ") == false)
                    {
                        string resultPostCode = AppVars.listOfAddress.FirstOrDefault(a => a.PostalCode.Strip(' ') == postCode).DefaultIfEmpty().PostalCode.ToStr().Trim();


                        if (resultPostCode.Length >= 5 && resultPostCode.Contains(" "))
                        {
                            postCode = resultPostCode;

                        }

                    }


                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }






                    //if (text.Contains(" ") && text.Length < 13 && text.WordCount() == 2 && text.Remove(text.IndexOf(' ')).Trim().Length <= 3 && text.Strip(' ').IsAlpha()==false
                    //    && (AppVars.keyLocations.Contains(text.Split(new char[] { ' ' })[0])))
                    //{
                    //  aTxt.ListBoxElement.Items.Clear();
                    if (searchValue.Contains(" ") && searchValue.Length < 20 && searchValue.WordCount() == 2 && searchValue.Contains(".") == false && searchValue.Strip(' ').IsAlpha() == false)
                    {

                        string[] arr = searchValue.Split(new char[] { ' ' });

                        if (arr.Count() == 2)
                        {
                            if (arr[0].IsAlpha())
                            {
                                string pcode = General.GetPostCodeMatch(arr[1].ToStr().ToUpper());

                                if (pcode.ToStr().Length > 0)
                                {
                                    e.Result = (from a in General.GetQueryable<Gen_Location>(c => (c.Gen_LocationType.ShortCutKey == arr[0]) && c.PostCode.StartsWith(pcode))
                                                select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                                    if (e.Result != null && (e.Result as string[]).Count() == 0)
                                        e.Result = null;

                                }
                            }
                        }

                    }



                    if (e.Result == null)
                    {

                        if (doorNo.Length > 0 && street.Strip(' ').IsAlpha() == false)
                        {
                            postCode = General.GetPostCodeMatch(street);
                            if (postCode.Length > 0)
                            {

                                street = street.Replace(postCode, "").Trim();
                            }
                        }
                        else if (postCode.Length > 0 && street.Length == 0 && postCode.Count(c => c == ' ') > 1)
                        {
                            string originalPostCode = postCode;
                            postCode = postCode.Substring(0, postCode.LastIndexOf(' '));

                            doorNo = originalPostCode.Replace(postCode, "").ToStr().Trim();
                        }
                        else if (street.Length > 3 && street.Contains(' ') && street.IsAlpha() == false && doorNo.Length == 0)
                        {


                            for (int i = 0; i < street.Length; i++)
                            {
                                if (Char.IsDigit(street[i]))
                                {
                                    if (i > 0 && street[i - 1] == ' ')
                                    {

                                        doorNo += street[i];
                                    }
                                    else if (i == 0)
                                    {
                                        doorNo += street[i];
                                    }
                                    else if (doorNo.Length > 0)
                                    {
                                        doorNo += street[i];

                                    }


                                }

                            }


                            if (doorNo.Length > 0)
                                street = street.Replace(doorNo, "").Trim();
                        }
                        else if (postCode.Length > 0 && postCode.Contains(" ") == false && street.Length == 0 && doorNo.Length == 0 && place.Length == 0)
                        {
                            //    IF LENGTH IS 5
                            //THEN
                            //E11AA=> IF 3RD CHARACTER IS NUMERIC THEN E1 1AA


                            //IF LENGTH IS 6
                            //THEN
                            //HA20DU=> IF 4TH CHARACTER IS NUMERIC THEN HA2 0DU

                            //IF LENGTH IS 7
                            //THEN 
                            //WC1A1AB=> IF 5TH CHARACTER IS NUMERIC THEN WC1A 1AB



                            if (postCode.Length == 5)
                            {
                                if (postCode[2].ToStr().IsNumeric())
                                {
                                    postCode = postCode.Insert(2, " ");

                                }

                            }
                            else if (postCode.Length == 6)
                            {
                                if (postCode[3].ToStr().IsNumeric())
                                {
                                    postCode = postCode.Insert(3, " ");

                                }

                            }
                            else if (postCode.Length == 7)
                            {
                                if (postCode[4].ToStr().IsNumeric())
                                {
                                    postCode = postCode.Insert(4, " ");

                                }

                            }
                        }


                        //using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Cryptography.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString(), "softeuroconnskey", true)))
                        //{
                        //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                        //    cmd.Connection = conn;
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.CommandText = "stp_GetByRoadLevelData";
                        //    cmd.Parameters.AddWithValue("@PostCode", postCode);
                        //    cmd.Parameters.AddWithValue("@doorno", doorNo);
                        //    cmd.Parameters.AddWithValue("@street", street);
                        //    cmd.Parameters.AddWithValue("@place", place);
                        //    conn.Open();
                        //    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                        //    while (reader.Read())
                        //    {


                        //    }
                        //    conn.Close();
                        //}

                        using (TaxiDataContext db = new TaxiDataContext())
                        {

                            if (postCode.Length > 0 && postCode.Contains(" ") == false && doorNo.Length == 0 && street.Length > 0 && place.Length == 0)
                            {
                                e.Result = db.stp_GetByRoadAndPostCodeLevelData(postCode, doorNo, street, place).Select(c => c.AddressLine1).ToArray<string>();

                            }
                            else if (place.Length > 0)
                            {
                                if (postCode.Length == 0)
                                {

                                    postCode = General.GetPostCodeMatch(street);
                                }


                                if (street.Length > 0 && postCode.Length == 0 && doorNo.Length == 0)
                                {
                                    string query = string.Empty;

                                    if (searchValue.Trim().EndsWith("#") == false && street.Contains(" ") && street.WordCount() >= 2)
                                    {

                                        string street2 = searchValue.Split(new char[] { '#' })[1].Trim();


                                        street = street.Replace(street2, "").Trim();

                                        query = string.Format("   SELECT  TOP 100  "

                                           + " AddressLine = dd.Data +' '  +md.substreet+ ' '+ md.Street + ' ' +md.PostCode  "

                                          + " FROM PAFDb.dbo.DetailData dd "

                                          + "  INNER JOIN PAFDb.dbo.MainData md ON md.PostCode = dd.PostCode  "

                                          + "    INNER JOIN PAFDb.dbo.Localization l ON l.PostCodeId = md.PostCodeId    "

                                        + "     WHERE (dd.Data LIKE '%{0}%' ) AND ((md.Street like '{1}%' or md.SubStreet like    '{1}%' or md.Town like '{1}%' or md.Locality like '{1}%')   )  "


                                          + "   ORDER BY l.Id  ", street, street2);

                                    }
                                    //if (searchValue.EndsWith("#") == false && street.Contains(" ") && searchValue.WordCount() >= 2)
                                    //{

                                    //    string street2 = searchValue.Split(new char[] { '#' })[1].Trim();


                                    //    street = street.Replace(street2, "").Trim();

                                    //    query = string.Format("   SELECT  TOP 100  "

                                    //       + " AddressLine = dd.Data +' '  +md.substreet+ ' '+ md.Street + ' ' +md.PostCode  "

                                    //      + " FROM PAFDb.dbo.DetailData dd "

                                    //      + "  INNER JOIN PAFDb.dbo.MainData md ON md.PostCode = dd.PostCode  "

                                    //      + "    INNER JOIN PAFDb.dbo.Localization l ON l.PostCodeId = md.PostCodeId    "

                                    //    + "     WHERE (dd.Data LIKE '%{0}%' ) AND ((md.Street like '{1}%' or md.SubStreet like    '{1}%')   )  "


                                    //      + "   ORDER BY l.Id  ", street, street2);

                                    //}
                                    else
                                    {


                                        query = string.Format("SELECT TOP 100     "

                                                                 + "AddressLine = dd.Data + ' ' + md.Street + ' ' + md.PostCode "

                                                                 + "FROM "

                                                                 + "PAFDb.dbo.Localization l "

                                                                 + " INNER JOIN PAFDb.dbo.MainData md ON md.PostCodeId = l.PostCodeId"

                                                                 + " INNER JOIN PAFDb.dbo.DetailData dd ON md.PostCode = dd.PostCode"

                                                                 + " WHERE Data LIKE  '%{0}%' order by l.id     ", street);


                                    }

                                    e.Result = db.ExecuteQuery<string>(query).ToArray<string>();


                                }
                                else if (street.Length > 0 && postCode.Length > 0)
                                {

                                    if (postCode.Length > 0)
                                    {
                                        street = street.Replace(postCode, "").TrimEnd();

                                    }

                                    if (doorNo.Length > 0)
                                    {
                                        street = street.Replace(doorNo, "").TrimStart();

                                    }


                                    if (doorNo.Length > 0)
                                    {


                                        string query = string.Format("   SELECT  TOP 100  "

                                             + " AddressLine = dd.Data +' '  +md.substreet+ ' '+ md.Street + ' ' +md.PostCode  "

                                            + " FROM PAFDb.dbo.DetailData dd "

                                            + "  INNER JOIN PAFDb.dbo.MainData md ON md.PostCode = dd.PostCode and md.PostCode like '{0} %'  "

                                            + "    INNER JOIN PAFDb.dbo.Localization l ON l.PostCodeId = md.PostCodeId    "

                                           + "    WHERE dd.Data LIKE '%{1}%' OR ((md.Street like '{1}%' or md.SubStreet like    '{1}%')   and dd.Data like +'% {2}%')   "

                                            + "   ORDER BY l.Id  ", postCode, street, doorNo);

                                        //  + "OPTION(QUERYTRACEON 8649)  ",

                                        e.Result = db.ExecuteQuery<string>(query).ToArray<string>();
                                    }
                                    else
                                    {

                                        string query = string.Format("   SELECT  TOP 100  "

                                            + " AddressLine = dd.Data +' '  +md.substreet+ ' '+ md.Street + ' ' +md.PostCode  "

                                           + " FROM PAFDb.dbo.DetailData dd "

                                           + "  INNER JOIN PAFDb.dbo.MainData md ON md.PostCode = dd.PostCode and md.PostCode like '{0} %'  "

                                           + "    INNER JOIN PAFDb.dbo.Localization l ON l.PostCodeId = md.PostCodeId    "

                                          + "    WHERE dd.Data LIKE '%{1}%' OR ((md.Street like '{1}%' or md.SubStreet like    '{1}%')   )   "

                                           + "   ORDER BY l.Id  ", postCode, street);

                                        //  + "OPTION(QUERYTRACEON 8649)  ",

                                        e.Result = db.ExecuteQuery<string>(query).ToArray<string>();


                                    }


                                    //e.Result = db.stp_getroadleveldatabyplacenameandpostcode(street,postCode,doorNo).Select(c => c.AddressLine).ToArray<string>();

                                }
                                else
                                {


                                    string street2 = street.Replace(doorNo, "").TrimStart();



                                    string query = string.Format("   SELECT  TOP 100  "

                                         + " AddressLine = dd.Data +' '  +md.substreet+ ' '+ md.Street + ' ' +md.PostCode  "

                                        + " FROM PAFDb.dbo.DetailData dd "

                                        + "  INNER JOIN PAFDb.dbo.MainData md ON md.PostCode = dd.PostCode  "

                                        + "    INNER JOIN PAFDb.dbo.Localization l ON l.PostCodeId = md.PostCodeId    "

                                      + "     WHERE (dd.Data LIKE '%{0}%' ) OR ((md.Street like '{1}%' or md.SubStreet like    '{1}%')   )  "


                                        + "   ORDER BY l.Id  ", street, street2);

                                    //  + "OPTION(QUERYTRACEON 8649)  ",

                                    e.Result = db.ExecuteQuery<string>(query).ToArray<string>();



                                }
                            }
                            else
                            {

                                e.Result = db.stp_GetByRoadLevelData(postCode, doorNo, street, place).Select(c => c.AddressLine1).ToArray<string>();
                            }


                        }
                    }

                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }






                }


                //



            }
            catch (Exception ex)
            {
              //  AddExcepLog("POIWORKER_DOWORK : " + ex.Message);
                //     Console.WriteLine("Start work catch: " + searchValue);

            }
        }



        private void AddressTextChangeWOPOI()
        {
            string text = aTxt.Text;
            string doorNo = string.Empty;

            if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool())
            {
                if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower())
                {
                    aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                    aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();


                    if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
                    {

                        aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
                    }

                    aTxt.SelectedItem = aTxt.Text.Trim();
                    aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                    //    }               

                }

            }

            if (text.Length > 2 && text.EndsWith(".") == false && text.EndsWith(",") == false)
            {

                if (aTxt.SelectedItem == null || (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() != aTxt.Text.ToLower()))
                {


                    for (int i = 0; i <= 2; i++)
                    {
                        if (char.IsNumber(text[i]))
                            doorNo += text[i];
                        else
                            break;

                    }
                    text = text.Remove(text.IndexOf(doorNo), doorNo.Length).TrimStart(new char[] { ' ' });
                }
            }



            if (text.Length > 1 && text != "BASX")
            {
                if (text.EndsWith("   "))
                {
                    //if (aTxt.Name == "txtFromAddress")
                    //{
                    //    FocusOnPickupPlot();
                    //}
                    //else if (aTxt.Name == "txtToAddress")
                    //{
                    //    FocusOnDropOffPlot();
                    //}

                    return;

                }

                else if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
                {
                    aTxt.ListBoxElement.Items.Clear();

                    aTxt.ResetListBox();

                    string locName = aTxt.SelectedItem.ToLower();
                    int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
                    if (commaIndex != -1)
                    {
                        locName = locName.Remove(commaIndex);
                    }


                    string formerValue = aTxt.FormerValue.ToLower().Trim();

                    int? loctypeId = 0;
                    Gen_Location loc = null;
                    if (AppVars.keyLocations.Contains(formerValue) || aTxt.FormerValue.EndsWith("  ")
                    || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 3 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                    {


                        if (aTxt.FormerValue.EndsWith("  ") || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 2 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                        {
                            loc = General.GetObject<Gen_Location>(c => c.LocationName.ToLower() == locName);
                        }
                        else
                            loc = General.GetObject<Gen_Location>(c => c.ShortCutKey == formerValue && c.LocationName.ToLower() == locName);

                        if (loc != null)
                        {
                            loctypeId = loc.LocationTypeId;
                        }
                    }

                    if (loctypeId != 0)
                    {

                        if (aTxt.Name == "txtFromAddress")
                        {



                            if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.Text.Trim();
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                                //if (aTxt.Name == "txtFromAddress")
                                //{
                                //    SetPickupZone(aTxt.Text);

                                //    UpdateAutoCalculateFares();
                                //}


                            }


                        }
                        else if (aTxt.Name == "txtToAddress")
                        {


                            if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.Text.Trim();
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                                //  SetDropOffZone(aTxt.Text);
                                //  UpdateAutoCalculateFares();


                            }




                        }
                    }
                    else if (aTxt.Text.Contains('.'))
                    {

                        //   RemoveNumbering(doorNo);


                    }
                    else if (!string.IsNullOrEmpty(doorNo))
                    {
                        aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        aTxt.Text = doorNo + " " + aTxt.Text;
                        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                    }
                    //else
                    //{
                    //    if (aTxt.Name == "txtFromAddress")
                    //    {


                    //        SetPickupZone(aTxt.SelectedItem);


                    //    }

                    //    else if (aTxt.Name == "txtToAddress")
                    //    {
                    //        SetDropOffZone(aTxt.SelectedItem);


                    //    }

                    //    if (aTxt.SelectedItem.ToStr().Trim() != string.Empty)
                    //    {
                    //        UpdateAutoCalculateFares();

                    //    }


                    //}

                    aTxt.FormerValue = string.Empty;


                    return;
                }



                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    //   CancelWebClientAsync();
                    // wc.CancelAsync();
                    aTxt.Values = null;

                }
                text = text.ToLower();

                if (AppVars.keyLocations.Contains(text) || (text.Length <= 4 && (text.EndsWith("  ") || (text[1] == ' ' || (text.Length > 2 && char.IsLetter(text[1]) && text[2] == ' ' && text.Trim().WordCount() == 2))))
                   || (text.Length < 13 && text.WordCount() == 2 && text.Remove(text.IndexOf(' ')).Trim().Length <= 3 && text.Strip(' ').IsAlpha()))
                {


                    aTxt.ListBoxElement.Items.Clear();


                    string[] res = null;

                    if (text.EndsWith("  "))
                    {

                        text = text.Trim();

                        res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.StartsWith(text))
                               select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                ).ToArray<string>();


                    }
                    else
                    {
                        if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                        {
                            string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                            string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                        c.LocationName.ToLower().Contains(locName))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                        }
                        else
                        {


                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                       ).ToArray<string>();
                        }
                    }


                    if (res.Count() > 0)
                    {



                        var finalList = (from a in AppVars.zonesList
                                         from b in res
                                         where b.Contains(a)
                                         select b).ToArray<string>();


                        if (finalList.Count() > 0)
                            finalList = finalList.Union(res).ToArray<string>();

                        else
                            finalList = res;


                        aTxt.ListBoxElement.Items.AddRange(finalList);


                        aTxt.ShowListBox();
                    }


                    if (aTxt.Text != aTxt.FormerValue)
                    {
                        aTxt.FormerValue = aTxt.Text;
                    }
                }


                if (MapType == Enums.MAP_TYPE.NONE) return;

                StartAddressTimer(text);

            }
            else if (text.Length > 0)
            {
                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    //   CancelWebClientAsync();
                    // wc.CancelAsync();
                    aTxt.Values = null;

                }
                text = text.ToLower();

                if (AppVars.keyLocations.Contains(text))
                {

                    aTxt.ListBoxElement.Items.Clear();


                    string[] res = null;

                    if (text.EndsWith("  "))
                    {

                        text = text.Trim();

                        res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
                               select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                ).ToArray<string>();


                    }
                    else
                    {
                        if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                        {
                            string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                            string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                        c.LocationName.ToLower().Contains(locName))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                        }
                        else
                        {


                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                       ).ToArray<string>();
                        }
                    }


                    if (res.Count() > 0)
                    {



                        var finalList = (from a in AppVars.zonesList
                                         from b in res
                                         where b.Contains(a)
                                         select b).ToArray<string>();


                        if (finalList.Count() > 0)
                            finalList = finalList.Union(res).ToArray<string>();

                        else
                            finalList = res;


                        aTxt.ListBoxElement.Items.AddRange(finalList);

                        if (text == "." && finalList.Count() == 1)
                        {
                            aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                            aTxt.Text = finalList[0];
                            aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                        }
                        else
                        {

                            aTxt.ShowListBox();
                        }
                    }


                    if (aTxt.Text != aTxt.FormerValue)
                    {
                        aTxt.FormerValue = aTxt.Text;
                    }




                    StartAddressTimer(text);
                }


            }
            else
            {
                if (MapType == Enums.MAP_TYPE.NONE) return;
                aTxt.ResetListBox();
                //  aTxt.ListBoxElement.Visible = false;
                aTxt.ListBoxElement.Items.Clear();

                //   CancelWebClientAsync();
                //  wc.CancelAsync();
                aTxt.Values = null;

            }



        }

        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (aTxt == null)
                {

                    timer1.Stop();
                    return;
                }

                timer1.Stop();

                searchTxt = searchTxt.ToUpper();


                if (AppVars.objPolicyConfiguration.EnablePOI.ToBool())
                {

                    if (POIWorker.IsBusy)
                        POIWorker.CancelAsync();



                    POIWorker.RunWorkerAsync(searchTxt);
                }
                else
                {

                    PerformAddressChangeTimerWOPOI();
                }


            }
            catch (Exception ex)
            {


            }

        }


        private void StartAddressTimer(string text)
        {
            text = text.ToLower();
            searchTxt = text;
            InitializeTimer();
            timer1.Start();
        }

        private void InitializeTimer()
        {
            if (this.timer1 == null)
            {
                this.timer1 = new System.Windows.Forms.Timer();
                this.timer1.Tick += timer1_Tick;
                this.timer1.Interval = 500;
            }

        }








        //private void AddressTextChangePOI()
        //{
        //    string text = aTxt.Text;
        //    string doorNo = string.Empty;

        //    if (aTxt.SelectedItem != null && aTxt.ListBoxElement.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower()
        //       && aTxt.Text.Length > 0)
        //    {
        //        aTxt.TextChanged -= TextBoxElement_TextChanged;
        //        //  aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
        //        aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();

        //        if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
        //        {
        //            aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
        //        }

        //        aTxt.SelectedItem = aTxt.Text.Trim();
        //        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
        //    }




        //    for (int i = 0; i <= 2; i++)
        //    {
        //        if (char.IsNumber(text[i]))
        //            doorNo += text[i];
        //        else
        //            break;
        //    }





        //    if (text.Length > 1 && text != "BASX")
        //    {
        //        if (text.EndsWith("   "))
        //        {
        //            //if (aTxt.Name == "txtFromAddress")
        //            //{
        //            //    FocusOnPickupPlot();
        //            //}
        //            //else if (aTxt.Name == "txtToAddress")
        //            //{
        //            //    FocusOnDropOffPlot();
        //            //}
        //            //return;
        //        }


        //        else if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
        //        {
        //            aTxt.ListBoxElement.Items.Clear();
        //            aTxt.ResetListBox();

        //            string locName = aTxt.SelectedItem.ToLower();
        //            int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
        //            if (commaIndex != -1)
        //            {
        //                locName = locName.Remove(commaIndex);
        //            }


        //            string formerValue = aTxt.FormerValue.ToLower().Trim();





        //            //else if (!string.IsNullOrEmpty(doorNo))
        //            //{
        //            //    aTxt.TextChanged -= TextBoxElement_TextChanged;
        //            //    aTxt.Text = aTxt.Text;
        //            //    aTxt.TextChanged += TextBoxElement_TextChanged;
        //            //}
        //            //else
        //            //{
        //            //    if (aTxt.Name == "txtFromAddress")
        //            //    {
        //            //        SetPickupZone(aTxt.SelectedItem);
        //            //    }

        //            //    else if (aTxt.Name == "txtToAddress")
        //            //    {
        //            //        SetDropOffZone(aTxt.SelectedItem);

        //            //    }

        //            //    if (aTxt.SelectedItem.ToStr().Trim() != string.Empty)
        //            //    {
        //            //        UpdateAutoCalculateFares();
        //            //    }
        //            //}

        //            aTxt.FormerValue = string.Empty;
        //            return;
        //        }

        //        if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
        //        {

        //            aTxt.Values = null;

        //        }

        //        text = text.ToLower();




        //        if (MapType == Enums.MAP_TYPE.NONE) return;

        //        StartAddressTimer(text);

        //    }
        //    else if (text.Length > 0)
        //    {
        //        if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
        //        {

        //            aTxt.Values = null;

        //        }
        //        text = text.ToLower();

        //        if (AppVars.keyLocations.Contains(text))
        //        {

        //            aTxt.ListBoxElement.Items.Clear();


        //            string[] res = null;

        //            if (text.EndsWith("  "))
        //            {

        //                text = text.Trim();

        //                res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
        //                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
        //                        ).ToArray<string>();


        //            }
        //            else
        //            {
        //                if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
        //                {
        //                    string shortcut = text.Remove(text.IndexOf(' ')).Trim();

        //                    string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

        //                    res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
        //                                c.LocationName.ToLower().Contains(locName))
        //                           select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
        //                              ).ToArray<string>();

        //                }
        //                else
        //                {


        //                    res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
        //                           select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
        //                               ).ToArray<string>();
        //                }
        //            }


        //            if (res.Count() > 0)
        //            {
        //                //  IsKeyword = true;


        //                var finalList = (from a in AppVars.zonesList
        //                                 from b in res
        //                                 where b.Contains(a)
        //                                 select b).ToArray<string>();


        //                if (finalList.Count() > 0)
        //                    finalList = finalList.Union(res).ToArray<string>();

        //                else
        //                    finalList = res;


        //                aTxt.ListBoxElement.Items.AddRange(finalList);

        //                if (text == "." && finalList.Count() == 1)
        //                {
        //                    aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
        //                    aTxt.Text = finalList[0];
        //                    aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

        //                }
        //                else
        //                {

        //                    aTxt.ShowListBox();
        //                }
        //            }


        //            if (aTxt.Text != aTxt.FormerValue)
        //            {
        //                aTxt.FormerValue = aTxt.Text;
        //            }

        //            StartAddressTimer(text);
        //        }


        //    }
        //    else
        //    {
        //        //if (MapType == Enums.MAP_TYPE.NONE)
        //        //    return;
        //        aTxt.ResetListBox();
        //        aTxt.ListBoxElement.Items.Clear();
        //        aTxt.Values = null;

        //    }



        //}





        private void AddressTextChangePOI()
        {
            try
            {
                string text = aTxt.Text;
                string doorNo = string.Empty;





                if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower()
                   && aTxt.Text.Length > 0)
                //&& aTxt.Text[0].ToStr().IsNumeric() )
                {
                    if (aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim().Length > 0)
                    {
                        aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();

                        if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
                        {
                            aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
                        }

                        aTxt.SelectedItem = aTxt.Text.Trim();
                        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                    }
                }




                for (int i = 0; i <= 2; i++)
                {
                    if (char.IsNumber(text[i]))
                        doorNo += text[i];
                    else
                        break;
                }





                if (text.Length > 1 && text != "BASX")
                {



                    if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
                    {
                        aTxt.ListBoxElement.Items.Clear();
                        aTxt.ResetListBox();

                        string locName = aTxt.SelectedItem.ToLower();
                        int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
                        if (commaIndex != -1)
                        {
                            locName = locName.Remove(commaIndex);
                        }


                        string formerValue = aTxt.FormerValue.ToLower().Trim();

                        int? loctypeId = 0;
                        Gen_Location loc = null;
                        if (AppVars.keyLocations.Contains(formerValue) || aTxt.FormerValue.EndsWith("  ")
                        || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 3 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                        {
                            if (aTxt.FormerValue.EndsWith("  ") || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 2 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                            {
                                string shortkey = aTxt.FormerValue.ToStr().Trim().Contains(" ") ? aTxt.FormerValue.Substring(0, aTxt.FormerValue.IndexOf(' ')) : "";


                               

                                // loc = General.GetObject<Gen_Location>(c => c.LocationName.ToLower() == locName && (shortkey == string.Empty || c.ShortCutKey.StartsWith(shortkey)));
                            }
                            else
                            {
                                if (locName.IsAlpha() == false)
                                {
                                    string postcode = General.GetPostCodeMatch(locName.ToUpper());

                                    if (postcode.Length > 0)
                                    {
                                        postcode = postcode.ToLower();
                                        string street = locName.Replace(postcode, "").Trim();


                                        if (street.EndsWith(","))
                                        {
                                            street = street.Substring(0, street.LastIndexOf(",") - 1).ToLower();


                                        }

                                   
                                        // loc = General.GetObject<Gen_Location>(c => c.LocationName.ToLower() == street && c.PostCode.ToLower() == postcode);

                                    }
                                  



                                }
                              


                            }
                            if (loc != null)
                            {
                                loctypeId = loc.LocationTypeId;
                            }
                        }
                        else
                        {

                            if (locName.IsAlpha() == false)
                            {
                                string postcode = General.GetPostCodeMatch(locName.ToUpper());

                                if (postcode.Length > 0)
                                {
                                    postcode = postcode.ToLower();
                                    string street = locName.Replace(postcode, "").Trim();


                                    if (street.EndsWith(","))
                                    {
                                        street = street.Substring(0, street.LastIndexOf(",") - 1).ToLower();


                                    }



                                }
                             



                            }
                           
                           

                        }



                        if (loctypeId == 0)
                        {
                            loctypeId = Enums.LOCATION_TYPES.ADDRESS;

                        }

                        if (loctypeId != 0)
                        {



                            // ddlFromLocType.SelectedValue = loctypeId;

                            if (aTxt.SelectedItem.ToStr().Length > 0)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                //   aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.Text.Trim();
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);


                                aTxt.SelectedItem = "";

                            }




                        }

                        else if (!string.IsNullOrEmpty(doorNo))
                        {
                            aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                            aTxt.Text = aTxt.Text;
                            aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);



                        }


                        aTxt.FormerValue = string.Empty;
                        return;
                    }

                    if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                    {

                        aTxt.Values = null;

                    }

                    text = text.ToLower();

                    if (AppVars.keyLocations.Contains(text) || (text.Length <= 4 && (text.EndsWith("  ") || (text[1] == ' ' || (text.Length > 2 && char.IsLetter(text[1]) && text[2] == ' ' && text.Trim().WordCount() == 2))))
                       || (text.Length < 13 && text.WordCount() == 2 && text.Remove(text.IndexOf(' ')).Trim().Length <= 3 && text.Strip(' ').IsAlpha()))
                    {


                        aTxt.ListBoxElement.Items.Clear();


                        string[] res = null;

                        if (text.EndsWith("  "))
                        {

                            text = text.Trim();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.StartsWith(text))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                    ).ToArray<string>();


                        }
                        else
                        {
                            if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                            {
                                string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                                string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                                res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                            c.LocationName.ToLower().Contains(locName))
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                          ).ToArray<string>();

                            }
                            else
                            {

                                using (TaxiDataContext db = new TaxiDataContext())
                                {

                                    db.DeferredLoadingEnabled = false;
                                    db.CommandTimeout = 5;

                                    res = (from a in db.Gen_Locations.Where(c => c.ShortCutKey == text)
                                           select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                         ).ToArray<string>();

                                    //res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                    //       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                    //      ).ToArray<string>();

                                }



                            }
                        }


                        if (res.Count() > 0)
                        {
                            //  IsKeyword = true;


                            var finalList = (from a in AppVars.zonesList
                                             from b in res
                                             where b.Contains(a)
                                             select b).ToArray<string>();


                            if (finalList.Count() > 0)
                                finalList = finalList.Union(res).ToArray<string>();

                            else
                                finalList = res;


                            aTxt.ListBoxElement.Items.AddRange(finalList);

                            aTxt.ShowListBox();
                            return;
                        }


                        if (aTxt.Text != aTxt.FormerValue)
                        {
                            aTxt.FormerValue = aTxt.Text;
                        }
                    }


                    if (MapType == Enums.MAP_TYPE.NONE) return;

                    StartAddressTimer(text);

                }
                else if (text.Length > 0)
                {
                    if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                    {

                        aTxt.Values = null;

                    }
                    text = text.ToLower();

                    if (AppVars.keyLocations.Contains(text))
                    {

                        aTxt.ListBoxElement.Items.Clear();


                        string[] res = null;

                        if (text.EndsWith("  "))
                        {

                            text = text.Trim();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                    ).ToArray<string>();


                        }
                        else
                        {
                            if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                            {
                                string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                                string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                                res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                            c.LocationName.ToLower().Contains(locName))
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                          ).ToArray<string>();

                            }
                            else
                            {


                                res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                           ).ToArray<string>();
                            }
                        }


                        if (res.Count() > 0)
                        {
                            //    IsKeyword = true;
                            //

                            var finalList = (from a in AppVars.zonesList
                                             from b in res
                                             where b.Contains(a)
                                             select b).ToArray<string>();


                            if (finalList.Count() > 0)
                                finalList = finalList.Union(res).ToArray<string>();

                            else
                                finalList = res;


                            aTxt.ListBoxElement.Items.AddRange(finalList);

                            if (text == "." && finalList.Count() == 1)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = finalList[0];
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                            }
                            else
                            {

                                aTxt.ShowListBox();
                            }
                        }


                        if (aTxt.Text != aTxt.FormerValue)
                        {
                            aTxt.FormerValue = aTxt.Text;
                        }

                        StartAddressTimer(text);
                    }


                }
                else
                {
                    //if (MapType == Enums.MAP_TYPE.NONE)
                    //    return;
                    aTxt.ResetListBox();
                    aTxt.ListBoxElement.Items.Clear();
                    aTxt.Values = null;

                }


            }
            catch
            {


            }
        }




        //private void ShowAddressesPOI(string[] resValue)
        //{
        //    int sno = 1;

        //    // var finalList = resValue;



        //    var finalList = (from a in AppVars.zonesList
        //                     from b in resValue
        //                     where b.Contains(a) && (b.Substring(b.IndexOf(a), a.Length) == a && (b.IndexOf(a) - 1) >= 0 && b[b.IndexOf(a) - 1] == ' ' && GeneralBLL.GetHalfPostCodeMatch(b) == a)

        //                     select b).ToArray<string>();


        //    if (finalList.Count() > 0)
        //    {
        //        finalList = finalList.Union(resValue).ToArray<string>();

        //    }
        //    else
        //        finalList = resValue;



        //    if (finalList.Count() < 10)
        //    {
        //        finalList = finalList.Select(args => (sno++) + ". " + args).ToArray();
        //    }


        //    aTxt.ListBoxElement.Items.Clear();
        //    aTxt.ListBoxElement.Items.AddRange(finalList);


        //    if (aTxt.ListBoxElement.Items.Count == 0)
        //        aTxt.ResetListBox();
        //    else
        //    {


        //        aTxt.ShowListBox();


        //    }

        //    if (searchTxt != aTxt.FormerValue.ToLower())
        //    {
        //        aTxt.FormerValue = aTxt.Text;

        //    }
        //}




        private void ShowAddressesPOI(string[] resValue)
        {
            int sno = 1;

           

            try
            {






                //

                var finalList = (from a in AppVars.zonesList
                                 from b in resValue
                                 where b.Contains(a) && (b.Substring(b.IndexOf(a), a.Length) == a && (b.IndexOf(a) - 1) >= 0 && b[b.IndexOf(a) - 1] == ' ' && GeneralBLL.GetHalfPostCodeMatch(b) == a)

                                 select b).ToArray<string>();


                if (finalList.Count() > 0)
                {



                    finalList = finalList.Union(resValue).ToArray<string>();


                    var finalList2 = (from a in resValue
                                      where General.GetPostCodeMatch(a).Length == 0
                                      select a).ToArray<string>();


                    finalList = finalList2.Union(finalList).ToArray<string>();

                }
                else
                {
                    finalList = resValue;

                    var finalList2 = (from a in resValue
                                      where General.GetPostCodeMatch(a).Length == 0
                                      select a).ToArray<string>();


                    finalList = finalList2.Union(finalList).ToArray<string>();
                }




                if (AppVars.objPolicyConfiguration.RecentAddressesFrequency.ToInt() > 0)
                {
                    try
                    {
                        searchTxt = searchTxt.Replace("#", "").Trim();


                        string serch = "<add>" + searchTxt;
                        string[] list = null;
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.CommandTimeout = 6;

                            list = db.Gen_RecentAddresses
                           .Where(c => c.AddressLine1.Contains(serch))
                           .OrderByDescending(c => c.SearchedOn).Take(50)
                           .Distinct().Select(c => c.AddressLine1.Replace("&", "AND")).ToArray<string>();
                        }


                        if (list != null && list.Count() > 0)
                        {





                            list = (from a in XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\"?><adds>" + String.Join(" ", list) + "</adds>").Element("adds").Nodes()
                                    where (a as XElement).Value.StartsWith(searchTxt)
                                    select (a as XElement).Value).Distinct().ToArray<string>();


                            if (finalList != null)
                            {

                                finalList = list.Union(finalList).ToArray<string>();
                            }
                            else
                            {

                                finalList = list;
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                       


                    }
                }


                if (finalList.Count() < 10)
                {
                    finalList = finalList.Select(args => (sno++) + ". " + args).ToArray();
                }


                aTxt.ListBoxElement.Items.Clear();
                aTxt.ListBoxElement.Items.AddRange(finalList);
                //



                if (aTxt.ListBoxElement.Items.Count == 0)
                    aTxt.ResetListBox();
                else
                {


                    aTxt.ShowListBox();


                }

                if (searchTxt != aTxt.FormerValue.ToLower())
                {
                    aTxt.FormerValue = aTxt.Text;

                }
            }
            catch (Exception ex)
            {
               


            }
        }


        private void PerformAddressChangeTimerWOPOI()
        {

            string postCode = General.GetPostCodeMatch(searchTxt);
            string fullPostCode = postCode;


            if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                postCode = string.Empty;


            string street = searchTxt;



            int IsAsc = 0;
            if (!string.IsNullOrEmpty(postCode))
            {
                street = street.Replace(postCode, "").Trim();

                if (postCode.Contains(' ') == false)
                {
                    if (postCode.Length == 3 && Char.IsNumber(postCode[2]))
                    {

                        IsAsc = 1;
                    }
                    else if (postCode.Length == 2 && Char.IsNumber(postCode[1]))
                    {

                        IsAsc = 1;
                    }
                    else if (postCode.Length > 3 && Char.IsNumber(postCode[3]))
                    {

                        IsAsc = 2;
                    }


                }

            }


            if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchTxt.IndexOf(postCode) < searchTxt.IndexOf(street))
            {
                street = "";
                postCode = searchTxt;
            }


            if (IsAsc == 1)
            {



                if (!string.IsNullOrEmpty(street))
                {


                    res = (from a in AppVars.listOfAddress

                           where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                           orderby a.PostalCode

                           select a.AddressLine1

                                   ).Take(1000).ToArray<string>();

                }
                else
                {

                    res = (from a in AppVars.listOfAddress

                           where a.PostalCode.StartsWith(postCode)

                           orderby a.PostalCode

                           select a.AddressLine1

                         ).Take(600).ToArray<string>();
                }

            }
            else if (IsAsc == 2)
            {


                res = (from a in AppVars.listOfAddress

                       where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                       orderby a.PostalCode descending

                       select a.AddressLine1

                               ).Take(500).ToArray<string>();


                if (street.Contains(' ') && res.Count() == 0)
                {

                    string[] vals = street.Split(' ');
                    int valCnt = vals.Count();

                    res = (from a in AppVars.listOfAddress

                           where (vals.Count(c => a.AddressLine1.Contains(c)) == valCnt)

                           select a.AddressLine1

                         ).Take(30).ToArray<string>();


                }


            }
            else
            {

                if (postCode.Contains(' '))
                {

                    res = null;

                    if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool()
                        && AppVars.zonesList.Count() > 0
                        && fullPostCode.Length > 0)
                    {

                        fullPostCode = General.GetPostCodeMatch(fullPostCode);

                        if (fullPostCode.Length > 0 && searchTxt.Trim() == fullPostCode)
                        {


                            string[] res1 = (from a in AppVars.listOfAddress

                                             where a.PostalCode == postCode

                                             select a.AddressLine1

                                       ).Take(1).ToArray<string>();





                            res = (from a in new TaxiDataContext().stp_GetRoadLevelData(fullPostCode)
                                   select a.AddressLine1).ToArray<string>();


                            res = res1.Union(res).Distinct().ToArray<string>();


                        }


                        if (res.Count() == 0)
                        {
                            res = (from a in AppVars.listOfAddress

                                   where a.PostalCode.StartsWith(postCode)

                                   orderby a.PostalCode

                                   select a.AddressLine1

                                  ).Take(100).ToArray<string>();


                        }




                    }
                    else
                    {

                        res = (from a in AppVars.listOfAddress

                               where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode))))

                               select a.AddressLine1

                                  ).Take(500).ToArray<string>();
                    }
                }
                else
                {


                    if (street.Length == 3 && street.IsAlpha() && !string.IsNullOrEmpty(AppVars.objPolicyConfiguration.CountyString))
                    {


                        string[] areas = AppVars.objPolicyConfiguration.CountyString.Split(',');

                        string last = street[2].ToStr();
                        street = street.Remove(2);

                        res = (from b in AppVars.listOfAddress.Where(a => areas.Any(c => a.AddressLine1.Contains(c)) && a.AddressLine1.Split(' ').Count() > 5)
                               //  let x = (areas.Any(c => b.Address.Contains(c)) ? b.Address.Split(' ') : null)
                               let x = b.AddressLine1.Split(' ')
                               where

                                  (

                               (x.ElementAt(0).StartsWith(street) && x.ElementAt(1).StartsWith(last))
                            || (x.ElementAt(0).StartsWith(street) && areas.Contains(x.ElementAt(2)) == false && x.ElementAt(2).StartsWith(last))
                                )

                               select b.AddressLine1

                                  ).Take(200).ToArray<string>();



                    }
                    else
                    {


                        if (street.WordCount() == 1 && street.ContainsNoSpaces())
                        {
                            //  street = street + " ";




                            if (AppVars.zonesList.Count() == 0)
                            {
                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.StartsWith(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))
                                       select a.AddressLine1

                                ).Take(500).ToArray<string>();
                            }
                            else
                            {
                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.StartsWith(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))
                                       select a.AddressLine1

                               ).Take(100).ToArray<string>();

                            }


                            if (AppVars.zonesList.Count() > 0)
                            {

                                string[] res2 = (from a in AppVars.listOfAddress

                                                 where (a.AddressLine1.StartsWith(street))
                                                 && AppVars.zonesList.Count(c => a.PostalCode.StartsWith(c)) > 0
                                                 select a.AddressLine1

                                    ).Take(200).ToArray<string>();

                                res = res2.Union(res).Distinct().ToArray<string>();


                            }










                        }
                        else
                        {



                            if (AppVars.zonesList.Count() > 0)
                            {




                                if (postCode.Length == 0)
                                {

                                    res = (from a in AppVars.listOfAddress


                                           where

                                           (a.AddressLine1.StartsWith(street))
                                           select a.AddressLine1

                                       ).Take(500).ToArray<string>();
                                }
                                else
                                {
                                    res = (from a in AppVars.listOfAddress


                                           where

                                           ((a.AddressLine1.StartsWith(street))
                                        && ((a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                                           select a.AddressLine1

                                      ).Take(500).ToArray<string>();


                                }


                                res = res.Union((from a in AppVars.listOfAddress


                                                 where

                                                 (a.AddressLine1.Contains(street)
                                                 && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))




                                                 select a.AddressLine1

                                   ).Take(2000)
                                     ).Distinct().ToArray<string>();




                            }
                            else
                            {

                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))



                                       select a.AddressLine1

                                    ).Take(1000).ToArray<string>();
                            }

                        }






                    }



                    if (street.Contains(' ') && res.Count() == 0)
                    {



                        string[] vals = street.Split(' ');
                        int valCnt = vals.Count();


                        res = (from a in AppVars.listOfAddress

                               where (vals.Count(c => a.AddressLine1.Contains(c)) == valCnt)



                               select a.AddressLine1

                             ).Take(30).ToArray<string>();


                    }



                }



            }

            ShowAddresses();

        }

        private void ShowAddresses()
        {

            var finalList = (from a in AppVars.zonesList
                             from b in res
                             where b.Contains(a)

                             select b).ToArray<string>();


            if (finalList.Count() > 0)
                finalList = finalList.Union(res).ToArray<string>();

            else
                finalList = res;


            aTxt.ListBoxElement.Items.Clear();
            aTxt.ListBoxElement.Items.AddRange(finalList);


            if (aTxt.ListBoxElement.Items.Count == 0)
                aTxt.ResetListBox();
            else
                aTxt.ShowListBox();



        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4'
                    || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7'
                    || e.KeyChar == '8' || e.KeyChar == '9')
                {




                    AutoCompleteTextBox txtData = (AutoCompleteTextBox)sender;
                    if (txtData.Text.StartsWith("W1"))
                        return;



                    if (txtData.Text.Length > 4 && txtData.ListBoxElement.Visible == true && txtData.ListBoxElement.Items.Count < 10)
                    {
                        string idx = e.KeyChar.ToStr();

                        txtData.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        string item = txtData.ListBoxElement.Items[idx.ToInt() - 1].ToStr();

                        string doorNo = string.Empty;
                        for (int i = 0; i <= 2; i++)
                        {
                            if (char.IsNumber(txtData.FormerValue[i]))
                                doorNo += txtData.FormerValue[i];
                            else
                                break;

                        }


                        if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool())
                        {
                            txtData.Text = (item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }
                        else
                        {

                            txtData.Text = (doorNo + " " + item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }


                        //if (txtData.Name == "txtFromAddress")
                        //{
                        //    SetPickupZone(txtData.Text);
                        //    FocusOnFromDoor();
                        //}
                        //else if (txtData.Name == "txtToAddress")
                        //{
                        //    SetDropOffZone(txtData.Text);
                        //    FocusOnToDoor();
                        //}
                        //else if (txtData.Name == "txtViaAddress")
                        //{
                        //    txtData.ResetListBox();
                        //    AddViaPoint();

                        //}
                        txtData.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                        e.Handled = true;

                        aTxt.ResetListBox();
                        aTxt.ListBoxElement.Items.Clear();


                        //   UpdateAutoCalculateFares();
                        //   txtViaAddress.Focus();
                    }



                }
            }
            catch (Exception ex)
            {


            }
        }


        #endregion
        //


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public override void Save()
        {
            try
            {

                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                    objMaster.Current.AddOn = DateTime.Now;
                    objMaster.Current.AddBy = AppVars.LoginObj.LuserId.ToIntorNull();
                    objMaster.Current.AddLog = AppVars.LoginObj.UserName.ToStr();
                }
                else
                {
                    objMaster.Edit();
                    objMaster.Current.EditOn = DateTime.Now;
                    objMaster.Current.EditBy = AppVars.LoginObj.LuserId.ToIntorNull();
                    objMaster.Current.EditLog = AppVars.LoginObj.UserName.ToStr();
                }
                objMaster.Current.Address = txtAddress.Text.Trim();
                objMaster.Current.Notes = txtNotes.Text.Trim();
                objMaster.Save();
                
                General.RefreshListWithoutSelectedOnRefreshData<frmWhiteListAddressList>("frmWhiteListAddressList1");
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

        private void Clear()
        {
            objMaster.Clear();
            txtNotes.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAddress.Focus();
        }
        public override void DisplayRecord()
        {
            try
            {

                if (objMaster.Current == null) return;




                txtNotes.Text = objMaster.Current.Notes;
                txtAddress.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtAddress.Text = objMaster.Current.Address.ToStr();
                txtAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void frmAddNewAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GC.Collect();
                this.Close();
            }
        }

        private void frmAddNewAddress_Load(object sender, EventArgs e)
        {

        }
    }
}
