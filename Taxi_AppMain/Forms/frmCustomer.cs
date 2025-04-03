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
using System.Net;
using System.Xml.Linq;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Taxi_AppMain
{
    public partial class frmCustomer : UI.SetupBase
    {
        CustomerBO objMaster;
        bool ISshowNo = false;
        public frmCustomer()
        {
            InitializeComponent();

            chkBlackList.ToggleStateChanged += chkBlackList_ToggleStateChanged;
            InitializeConstructor();

            //foreach (var item in General.GetQueryable<Gen_SubCompany>(null).Select(args => new { args.BackgroundColor, args.CompanyName, args.Id }).ToList())
            //{
            //    ddlSubCompany.Items.Add(new RadCustomListDataItem { Text = item.CompanyName, Value = item.BackgroundColor, Tag = item.Id });
            //}

            //ddlSubCompany.SelectedIndex = 0;

            tabIVRAddresses.Item.Visibility = ElementVisibility.Collapsed;
            radPageView1.SelectedPageChanged += RadPageView1_SelectedPageChanged;
            grdccdetails.CommandCellClick += Grdccdetails_CommandCellClick;
        }
        public frmCustomer(bool IsNewBooking)
        {

            if (IsNewBooking == true)
            {
                ISshowNo = true;
            }
            
            InitializeComponent();

            chkBlackList.ToggleStateChanged += chkBlackList_ToggleStateChanged;
            InitializeConstructor();

            //foreach (var item in General.GetQueryable<Gen_SubCompany>(null).Select(args => new { args.BackgroundColor, args.CompanyName, args.Id }).ToList())
            //{
            //    ddlSubCompany.Items.Add(new RadCustomListDataItem { Text = item.CompanyName, Value = item.BackgroundColor, Tag = item.Id });
            //}

            //ddlSubCompany.SelectedIndex = 0;

            tabIVRAddresses.Item.Visibility = ElementVisibility.Collapsed;
            radPageView1.SelectedPageChanged += RadPageView1_SelectedPageChanged;
            grdccdetails.CommandCellClick += Grdccdetails_CommandCellClick;
        }
        private void Grdccdetails_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;


                if (gridCell.ColumnInfo.Name == "delete")
                {
                    var Id = gridCell.RowInfo.Cells["Id"].Value.ToLong();
                    var customerid = gridCell.RowInfo.Cells["CustomerId"].Value.ToInt();

                    var isdefault = gridCell.RowInfo.Cells["isdefault"].Value.ToBool();



                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        db.ExecuteQuery<int>("delete from customer_ccdetails where id=" + Id);
                        try
                        {

                            var firstid = db.ExecuteQuery<long>("select top 1 id from customer_ccdetails where customerid=" + objMaster.Current.Id).FirstOrDefault();

                            if (firstid != 0 && firstid > 0)
                            {
                                db.ExecuteQuery<int>("update customer_ccdetails set isdefault=1 where id=" + firstid);

                            }
                        }
                        catch
                        { }

                    }

                    gridCell.RowInfo.Delete();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
              if(radPageView1.SelectedPage== tabIVRAddresses)
            {

                if (grdCallerIVRInfo.Tag == null)
                {
                    grdCallerIVRInfo.Tag = "1";
                    PopulateCallerIVRInfo();
                }

            }
        }

        public bool OpenFromBooking = false;


        public frmCustomer(string phoneNumber)
        {
            InitializeComponent();
            this.txtMobileNo.Text = phoneNumber;

            InitializeConstructor();
            
        }

        public struct COLSCallerIVRInfo
        {

            public static string AddressLine = "AddressLine";
            public static string OldAddressLine = "OldAddressLine";
            
        }

        public struct COLSCallerIVRDropOffinfo
        {

            public static string AddressLine = "AddressLine";
            public static string OldAddressLine = "OldAddressLine";

        }

        private void PopulateCallerIVRInfo()
        {

            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {


                    string number = objMaster.Current.MobileNo.ToStr();

                    if (number.Length == 0)
                        number = objMaster.Current.TelephoneNo.ToStr().Trim();


                    if (number.Length > 0)
                    {

                        var list = db.ExecuteQuery<stp_getcallerivrinfo>("exec stp_getcallerivrinfo {0},{1}", number, number).ToList();

                        grdCallerIVRInfo.RowCount = list.Count;

                        GridViewRowInfo row = null;

                        for (int i = 0; i < list.Count; i++)
                        {

                            row = grdCallerIVRInfo.Rows[i];

                            row.Cells[COLSCallerIVRInfo.AddressLine].Value = list[i].AddressLine;
                            row.Cells[COLSCallerIVRInfo.OldAddressLine].Value = list[i].AddressLine;

                        }





                        list = db.ExecuteQuery<stp_getcallerivrinfo>("exec stp_getcallerivrdropoffinfo {0},{1}", number, string.Empty).ToList();



                        if (list.Count(c => c.AddressLine == "AS DIRECTED") > 0)
                            list.RemoveAll(c => c.AddressLine == "AS DIRECTED");

                        grdCallerIVRDropOffInfo.RowCount = list.Count;

                        row = null;

                        for (int i = 0; i < list.Count; i++)
                        {

                            row = grdCallerIVRDropOffInfo.Rows[i];

                            row.Cells[COLSCallerIVRDropOffinfo.AddressLine].Value = list[i].AddressLine;
                            row.Cells[COLSCallerIVRDropOffinfo.OldAddressLine].Value = list[i].AddressLine;

                        }

                    }

                }


            }
            catch
            {

            }

            

            
        }


     
        private void FormatGridCallerIVRInfo()
        {

            if (grdCallerIVRInfo.Columns.Count == 0)
            {

                grdCallerIVRInfo.ShowRowHeaderColumn = false;
                grdCallerIVRInfo.AllowAddNewRow = false;
                grdCallerIVRInfo.ShowGroupPanel = false;

                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.Name = COLSCallerIVRInfo.AddressLine;
                col.HeaderText = "Addresses";
                col.Width = 450;
                col.IsVisible = true;
                grdCallerIVRInfo.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.Name = COLSCallerIVRInfo.OldAddressLine;
                col.IsVisible = false;
                col.Width = 180;
                grdCallerIVRInfo.Columns.Add(col);

                AddUpdateColumn(grdCallerIVRInfo);
                grdCallerIVRInfo.CommandCellClick += GrdCallerIVRDropOffInfo_CommandCellClick;

            }
        }

        private void FormatGridCallerIVRDropOffinfo()
        {
            if (grdCallerIVRDropOffInfo.Columns.Count == 0)
            {


                grdCallerIVRDropOffInfo.ShowRowHeaderColumn = false;
                grdCallerIVRDropOffInfo.AllowAddNewRow = false;
                grdCallerIVRDropOffInfo.ShowGroupPanel = false;

                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.Name = COLSCallerIVRDropOffinfo.AddressLine;
                col.HeaderText = "Addresses";
                col.Width = 450;
                col.IsVisible = true;
                grdCallerIVRDropOffInfo.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.Name = COLSCallerIVRDropOffinfo.OldAddressLine;
                col.IsVisible = false;
                col.Width = 180;
                grdCallerIVRDropOffInfo.Columns.Add(col);

                AddUpdateColumn(grdCallerIVRDropOffInfo);
                grdCallerIVRDropOffInfo.CommandCellClick += GrdCallerIVRDropOffInfo_CommandCellClick;
            }
        }

        private void GrdCallerIVRDropOffInfo_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;


                if (gridCell.ColumnInfo.Name == "btnUpdate")
                {
                     var newaddress=  gridCell.RowInfo.Cells[COLSCallerIVRDropOffinfo.AddressLine].Value.ToStr().Trim();
                    var oldaddress = gridCell.RowInfo.Cells[COLSCallerIVRDropOffinfo.OldAddressLine].Value.ToStr().Trim();
                    string mobileno = objMaster.Current.MobileNo.ToStr().Trim();
                    string tel = objMaster.Current.TelephoneNo.ToStr().Trim();


               

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        if (mobileno.Length > 0)
                        {

                            if (gridCell.GridControl.Name == "grdCallerIVRInfo")
                            {
                                string query = "update customer_history set pickup='" + newaddress + "' where mobileno='" + mobileno + "' and pickup='" + oldaddress + "'";
                                db.ExecuteQuery<int>(query);
                            }
                            else
                            {
                                string query = "update customer_history set destination='" + newaddress + "' where mobileno='" + mobileno + "' and destination='" + oldaddress + "'";
                                db.ExecuteQuery<int>(query);

                            }

                       }
                       else if (tel.Length > 0)
                        {

                            if (gridCell.GridControl.Name == "grdCallerIVRInfo")
                            {
                                string query = "update customer_history set pickup='" + newaddress + "' where telephoneno='" + tel + "' and pickup='" + oldaddress + "'";
                                db.ExecuteQuery<int>(query);
                            }
                            else
                            {
                                string query = "update customer_history set destination='" + newaddress + "' where telephoneno='" + tel + "' and destination='" + oldaddress + "'";
                                db.ExecuteQuery<int>(query);
                            }

                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void InitializeConstructor()
        {

            objMaster = new CustomerBO();
            this.SetProperties((INavigation)objMaster);



            timer1.Tick += new EventHandler(timer1_Tick);

            txtAddress1.ListBoxElement.Width = 400;
            txtAddress2.ListBoxElement.Width = 400;
            FillCombo();
            this.Shown += new EventHandler(frmCustomer_Shown);

            if (AppVars.objPolicyConfiguration != null)
            {

                MapType = AppVars.objPolicyConfiguration.MapType.ToInt();

            }

            

        }


        private void FillCombo()
        {
            ComboFunctions.FillCompanyCombo(ddlAccount);
        }

        //  bool IsExistData = false;


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






                string postCode = General.GetPostCodeMatch(searchTxt.ToUpper());
                if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                    postCode = string.Empty;

                string street = searchTxt;
                if (!string.IsNullOrEmpty(postCode))
                    street = street.ToLower().Replace(postCode.ToLower(), "").Trim();




                res = (from a in AppVars.listOfAddress

                       where (a.AddressLine1.ToLower().Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode))))
                       select a.AddressLine1

                                   ).Take(1000).ToArray<string>();

                //}

                if (res.Count() == 0)
                {


                    string url = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + searchTxt + " UK&sensor=false";
                  //  IsAutoComplete = IsAutoComplete == true ? false : true;

                    wc.CancelAsync();

                    wc = new WebClient();
                    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                    wc.DownloadStringAsync(new Uri(url));


                    return;
                }


                // Zone Working

                //   searchTxt = searchTxt.Substring(0, 3);



                ShowAddresses();
            }
            catch (Exception ex)
            {


            }
    
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

        void frmCustomer_Shown(object sender, EventArgs e)
        {
            txtName.Focus();


            if(OpenFromBooking)
             this.ShowSaveAndNewButton=false;

        }

     
        AutoCompleteTextBox aTxt = null;
        WebClient wc = new WebClient();
        private int _MapType;

        public int MapType
        {
            get { return _MapType; }
            set { _MapType = value; }
        }

        string[] res = null;
        string searchTxt = "";
        void TextBoxElement_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();

          
            if (MapType == Enums.MAP_TYPE.NONE) return;
            try
            {


                aTxt = (AutoCompleteTextBox)sender;

                aTxt.ResetListBox();
                string text = aTxt.Text;
                if (text.Length > 2)
                {

                   

                        if (aTxt.SelectedItem != null && aTxt.SelectedItem == aTxt.Text)
                        {
                            return;
                        }



                            StartAddressTimer(text);
                     
                     


                        if (aTxt.Name == "txtAddress1")
                        {

                            txtAddress2.SendToBack();
                       

                        }
                        else if (aTxt.Name == "txtAddress2")
                        {
                            txtAddress2.BringToFront();
                         
                        }

                        radPanel2.SendToBack();
                  
               
                }
                    else
                    {
                       
                            wc.CancelAsync();
                            aTxt.Values = null;

                        
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
            timer1.Start();

        }

      
        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

            if (e.Cancelled)
            {
                return;
            }


            var xmlElm = XElement.Parse(e.Result);


            res = (from elm in xmlElm.Descendants()

                   // where elm.Name == "description"
                   //&& (elm.Value.ToLower().Contains("united kingdom") || elm.Value.ToLower().Contains("uk"))
                   where elm.Name == "formatted_address"
                   select elm.Value).ToArray<string>();


            ShowAddresses();


            }
            catch
            {


            }
        }

        #region Overridden Methods


        public override void AddNew()
        {
            OnNew();
        }

        public override void OnNew()
        {

            ddlAccount.SelectedValue = null;
            grdccdetails.Rows.Clear();

        }
        private bool BlackAddress = false;
        private bool IsLoadedData;
        public bool WasBlacked;
        public override void Save()
        {
            try
            {
                //if (chkBlackList.Checked == true && txtResion.Text == "")
                //{
                //    ENUtils.ShowMessage("Requried: Resion");
                //}

                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();

                }
                else
                {
                    objMaster.Edit();
                }


             
                objMaster.Current.Name = txtName.Text.Trim();
                objMaster.Current.Email = txtEmail.Text.Trim();
                objMaster.Current.TelephoneNo = txtTelephoneNo.Text.Trim();
                objMaster.Current.MobileNo = txtMobileNo.Text.Trim();
                objMaster.Current.Address1 = txtAddress1.Text.Trim();
                objMaster.Current.Address2 = txtAddress2.Text.Trim();
                objMaster.Current.DoorNo = txtDoorNo.Text.Trim();
            //    objMaster.Current.SubCompanyId = ddlSubCompany.SelectedValue.ToInt();
                objMaster.Current.AccountNo = chkDisableIVR.Checked ? "1" : "0";
                WasBlacked = objMaster.Current.BlackList.ToBool();
                objMaster.Current.BlackList = chkBlackList.Checked.ToBool();
                objMaster.Current.BlackListResion = txtResion.Text.ToString();
                objMaster.Current.TotalCalls = txtTotalCalls.Value.ToInt();



                if (objMaster.Current.LoginPassword.ToStr().Trim().Length == 0)
                {
                    if (btnRemove.Visible && txtCreditCard.Text.Length == 0)
                        objMaster.Current.CreditCardDetails = null;


                }

                objMaster.Current.Priority = numPriority.Value.ToInt();
                objMaster.Current.PreBookPriority = numPreBookPriority.Value.ToInt();

                objMaster.Current.LikesAndDislikes = txtNotes.Text.Trim();

                objMaster.Current.CompanyId = ddlAccount.SelectedValue.ToIntorNull();

                objMaster.Save();

                //      General.RefreshListWithoutSelected<frmCustomersList>("frmCustomersList1");
                // General.RefreshListWithoutSelected<frmBlackCustomersList>("frmBlackCustomersList1");


                try
                {
                    if (txtAddress1.ToStr().Trim().Length > 0 && txtResion.Text.ToStr().Trim().Length > 0 && (chkBlackList.Checked))
                    {
                        if (BlackAddress)
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                if (db.WhiteListAddresses.Count(c => c.CustomerId == objMaster.Current.Id) == 0)
                                {

                                    string query = "INSERT INTO WHITELISTADDRESS(Address,Notes,AddOn,AddBy,AddLog,CustomerId)VALUES('" + txtAddress1.Text.Trim().ToUpper() + "','" + ("BLACKLIST DUE TO: " + txtResion.Text.Trim()) + "',getdate()" + "," + AppVars.LoginObj.LuserId.ToInt() + ",'" + AppVars.LoginObj.UserName.ToStr() + "'," + objMaster.Current.Id + ")";

                                    db.stp_RunProcedure(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        if ((WasBlacked == true && chkBlackList.Checked == false))
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                string query = "delete from whitelistaddress where customerid=" + objMaster.Current.Id;

                                db.stp_RunProcedure(query);


                            }
                        }

                    }
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
            }


        }

        public override void DisplayRecord()
        {
            try
            {
                if (objMaster.Current == null) return;


                txtName.Text = ISshowNo == true? "" : objMaster.Current.Name.ToStr();
                txtEmail.Text = objMaster.Current.Email.ToStr();
                txtTelephoneNo.Text = objMaster.Current.TelephoneNo.ToStr();
                txtMobileNo.Text = ISshowNo == true ? "" : objMaster.Current.MobileNo.ToStr();

              //  ddlSubCompany.SelectedValue = objMaster.Current.SubCompanyId;

                txtAddress1.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtAddress1.Text = objMaster.Current.Address1.ToStr();
                txtAddress1.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                txtAddress2.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtAddress2.Text = objMaster.Current.Address2.ToStr();
                txtAddress2.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                txtDoorNo.Text = objMaster.Current.DoorNo.ToStr();

                chkBlackList.Checked = objMaster.Current.BlackList.ToBool();
             
                txtCreditCard.Text = objMaster.Current.CreditCardDetails.ToStr().Trim();

                numPriority.Value = objMaster.Current.Priority.ToInt();

                numPreBookPriority.Value = objMaster.Current.PreBookPriority.ToInt();

                if (txtCreditCard.Text.Length > 0)
                {

                    try
                    {
                        string[] arr = txtCreditCard.Text.Split(new string[] { "<<<" }, StringSplitOptions.None);
                        txtCreditCard.Text = arr[3] + "," + arr[4];



                       
                    }
                    catch
                    {

                    }

                }



                if (objMaster.Current.LoginPassword.ToStr().Trim().Length > 0)
                {

                    this.FormTitle = "Customer(App)";
                    txtEmail.Enabled = false;
                }
                else
                {
                    if (txtCreditCard.Text.Length > 0 && txtCreditCard.Text.StartsWith("cus")==false)
                    {
                        btnRemove.Visible = true;
                    }
                }
                if (chkBlackList.Checked == false)
                {
                    txtResion.Text = "";
                }
                else
                {
                    txtResion.Text = objMaster.Current.BlackListResion.ToStr();
                }


                chkDisableIVR.Checked = objMaster.Current.AccountNo.ToStr().Trim() == "1";

                txtTotalCalls.Value = objMaster.Current.TotalCalls.ToDecimal();

                txtNotes.Text = objMaster.Current.LikesAndDislikes.ToStr().Trim();

                if (objMaster.Current.ExcludedDriverIds != "" && objMaster.Current.ExcludedDriverIds != null)
                    btnExcludedDrivers.Text = "Excluded Drivers (" + (objMaster.Current.ExcludedDriverIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length).ToStr() + ")";

               

                this.excludedDriverIds = objMaster.Current.ExcludedDriverIds.ToStr().Trim();
                ddlAccount.SelectedValue = objMaster.Current.CompanyId;

                IsLoadedData = true;

                tabIVRAddresses.Item.Visibility = ElementVisibility.Visible;

                FormatGridCallerIVRInfo();
                FormatGridCallerIVRDropOffinfo();


                try
                {
                    grdccdetails.Rows.Clear();
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        
                       var cclist=    db.ExecuteQuery<Customer_CCDetails>("select Id,CustomerId,CCDetails,IsDefault from customer_ccdetails where customerid=" + objMaster.Current.Id);

                        foreach (var item in cclist)
                        {
                            var row= grdccdetails.Rows.AddNew();


                            if (item.CCDetails.ToStr().ToLower().StartsWith("token"))
                            {

                                row.Cells["CardDetails"].Value = (item.CCDetails.Split(new string[] { "<<<" }, StringSplitOptions.RemoveEmptyEntries)[3] + "," + item.CCDetails.Split(new string[] { "<<<" }, StringSplitOptions.RemoveEmptyEntries)[4]).Replace("lastfour|", "**").Trim().Replace("enddate|", " Expiry:") + Environment.NewLine;

                            }
                            else if (item.CCDetails.ToStr().ToStr().StartsWith("KonnectPayToken"))
                            {
                                row.Cells["CardDetails"].Value=(item.CCDetails.Split('|')[1].Remove(item.CCDetails.Split('|')[1].LastIndexOf(','))).Replace("last four :", "**").Trim().Replace("expiry :", " ") + Environment.NewLine;


                            }

                            row.Cells["isdefault"].Value = item.IsDefault.ToBool();
                            row.Cells["Id"].Value = item.Id.ToLong();
                            row.Cells["CustomerId"].Value = item.CustomerId;
                        }

                        if (objMaster.Current.BlackList.ToBool())
                        {
                            if (db.WhiteListAddresses.Count(c => c.CustomerId == objMaster.Current.Id) > 0)
                            {

                                this.FormTitle += " - (Blacklisted with Address)";

                            }
                        }
                    }
                }
                catch
                {

                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void AddUpdateColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();

            col.Name = "btnUpdate";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Update";
            col.Width = 120;
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);


        }

        #endregion

        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text =txtName.Text.ToStr().ToProperCase();
        }

      

        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            General.DisposeForm(this);

            GC.Collect();
        }

        private void chkBlackList_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            BlackList(args.ToggleState);
        }
        private void BlackList(ToggleState toggle)
        {
            if (toggle == ToggleState.On)
            {
                lblResion.Visible = true;
                txtResion.Visible = true;


                chkDisableIVR.Checked = true;
                chkDisableIVR.Enabled = false;

                if (IsLoadedData)
                {
                    if (txtAddress1.ToStr().Trim().Length > 0)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do you want to Blacklist the address as well?", "", MessageBoxButtons.YesNo))
                        {
                            BlackAddress = true;

                        }
                        else
                            BlackAddress = false;
                    }
                }
            }
            else
            {
                BlackAddress = false;
                lblResion.Visible = false;
                txtResion.Visible = false;

                chkDisableIVR.Enabled = true;
            }
        }

      

        public string excludedDriverIds;
        public string excludedDriverNos;
        private void btnExcludedDrivers_Click(object sender, EventArgs e)
        {

            try
            {

                if (objMaster != null)
                {
                    if (objMaster.Current.Id != 0)
                    {
                        string Ids = objMaster.Current.ExcludedDriverIds.ToStr();
                        frmCustomerExcDriversList frm = new frmCustomerExcDriversList(Ids, objMaster.Current.Id);
                        frm.ShowDialog();


                        this.excludedDriverIds= frm.input_Ids;
                        this.excludedDriverNos = frm.input_values;
                        frm.Dispose();


                        objMaster.GetByPrimaryKey(objMaster.Current.Id);

                        DisplayRecord();

                    }

                }
            }
            catch
            {


            }
               
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            txtCreditCard.Text = string.Empty;
        }
    }
}


public class stp_getcallerivrinfo
{
    public string AddressLine { get; set; }
   
}

public class stp_getcallerivrdropoffinfo
{
    public string AddressLine { get; set; }

}
