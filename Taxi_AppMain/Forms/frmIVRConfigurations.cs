using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DAL;
using Taxi_Model;
using System.Linq.Expressions;
using Utils;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using UI;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Data.Linq;
using System.Text.RegularExpressions;
using Taxi_BLL;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Microsoft.Reporting.WinForms;
using Taxi_AppMain.Classes;
using System.Xml;
using System.Data;
using System.Net;
using Microsoft.Win32;
using System.Net.Sockets;
using DotNetCoords;

using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using Newtonsoft.Json;

//using System.Web.Script.Serialization;


//using System;

//using System.Data;
//using System.Drawing;
//using System.Linq;

//using System.Windows.Forms;
//using Taxi_Model;

//using DAL;
//using Utils;
//using Telerik.WinControls.UI;

//using Taxi_BLL.Classes;
//using Telerik.WinControls;


namespace Taxi_AppMain
{
    public partial class frmIVRConfigurations: UI.SetupBase
    
       
    {
        //public struct Col_Configration
        //{
        //    public static string ID = "Id";


        //    public static string NAME = "Name";
        //    public static string SHORTNAME = "ShortName";
        //    public static string Default = "Default";

        //}

        //AttributesBO ObjMaster;

        //public class ConfigrationModel
        //{
        //    //public string response { get; set; }
        //    //public string message { get; set; }
        //    //public string status { get; set; }

        //    public int status { get; set; }
        //    public string IVRNumbers { get; set; }
        //    public bool CalculateFares { get; set; }
        //    public bool ReleaseMode { get; set; }
        //}

        public class ResponseData
        {
            public bool HasError { get; set; }
            public string Message { get; set; }
            public DataObject Data { get; set; }
        }

        public class DataObject
        {
            public int Status { get; set; }
            public string IVRNumbers { get; set; }
            public bool CalculateFares { get; set; }
            public bool ReleaseMode { get; set; }
            public string CompanyName { get; set; }
            public string DefaultClientId { get; set; }
            public string cloudUrl { get; set; }
            public string conn { get; set; }
        }

        public class ResponseObject
        {
            public object ContentEncoding { get; set; }
            public object ContentType { get; set; }
            public ResponseData Data { get; set; }
            public int JsonRequestBehavior { get; set; }
            public object MaxJsonLength { get; set; }
            public object RecursionLimit { get; set; }
        }


        public frmIVRConfigurations()
        {
            InitializeComponent();
            InitializeConstructor();
            //grdConfigration.CurrentRow = null;
            //txtAtrributeName.Focus();
            //txtNoPickupRestrictionMins.Focus();
            rdoIVREnabled.Focus();

        }



        private void InitializeConstructor()
        {

            //ObjMaster = new AttributesBO();
            //this.SetProperties((INavigation)ObjMaster);
            this.InitializeForm(this.Name);
            this.Shown += new EventHandler(frmIVRConfigurations_Shown);
            this.FormClosed += new FormClosedEventHandler(frmIVRConfigurations_FormClosed);
            //txtShortCutKey.Enabled = false;
            //txtShortCutKey.Text = "";
            this.KeyDown += new KeyEventHandler(frmIVRConfigurations_KeyDown);

            //ObjMaster.SearchConditions = c => c.Id > 0;
            //grdConfigration.MasterTemplate.ShowRowHeaderColumn = false;
            //grdConfigration.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            //grdConfigration.AllowAddNewRow = false;
            //grdConfigration.ShowRowHeaderColumn = false;
            //grdConfigration.ShowGroupPanel = false;


            //grdConfigration.TableElement.AlternatingRowColor = Color.AliceBlue;
            //grdConfigration.RowsChanging += new GridViewCollectionChangingEventHandler(grdConfigration_RowsChanging);
            //grdConfigration.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            //OnNew();
            //txtAtrributeName.Focus();
            this.Load += new EventHandler(frmIVRConfigurations_Load);
            //txtNoPickupRestrictionMins.Value = 0;
            //txtFrom.Value = 0;
            //txtTill.Value = 0;

            

        }

        void frmIVRConfigurations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        void frmIVRConfigurations_Shown(object sender, EventArgs e)
        {
            //grdConfigration.CurrentRow = null;
            //txtAtrributeName.Focus();
            
        }
        void frmIVRConfigurations_FormClosed(object sender, FormClosedEventArgs e)
        {            
            //this.Dispose(true);
            //GC.Collect();
        }

        //private void LoadConfigrationGrid()
        //{
        //    var query = (from a in General.GetQueryable<Gen_Attribute>(c=>c.AttributeCategoryId == 3).OrderBy(c=>c.Name)
        //                 select new
        //                 {
        //                     Id = a.Id,
        //                     Name = a.Name + " [" + a.ShortName + "]",
        //                     ShortName = a.ShortName,
        //                     Default = a.IsDefault,                              
        //                 }).OrderBy(c => c.Name);
        //    grdConfigration.DataSource = query.ToList();

        //}

        private void frmIVRConfigurations_Load(object sender, EventArgs e)
        {
            //LoadConfigrationGrid();
            //grdConfigration.Columns[Col_Configration.ID].IsVisible = false;
            //grdConfigration.Columns[Col_Configration.NAME].Width = 300;
            //grdConfigration.Columns[Col_Configration.SHORTNAME].Width = 250;
            //grdConfigration.Columns[Col_Configration.SHORTNAME].IsVisible = false;
            //grdConfigration.Columns[Col_Configration.Default].IsVisible = false;

            //if (this.CanDelete)
            //{
            //    AddCommandColumn("btnDelete", "Delete", 70);
            //    //  grdUsers.AddDeleteColumn();
            //}

            //UI.GridFunctions.SetFilter(grdConfigration);
            //txtAtrributeName.Focus();
            DisplayRecord();
        }

        //private void AddCommandColumn(string name, string headerText, int width)
        //{
        //    GridViewCommandColumn col = new GridViewCommandColumn();
        //    col.Width = width;

        //    col.UseDefaultText = true;
        //    col.DefaultText = headerText;
        //    col.Name = name;
        //    grdConfigration.Columns.Add(col);
        //    txtAtrributeName.Focus();

        //}

        //private void grdConfigration_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        //{
        //    if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
        //    {

        //        if (this.CanDelete == false)
        //        {
        //            // ENUtils.ShowMessage("Permission Denied");
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            if (grdConfigration.CurrentRow == null)
        //                return;
        //            AttributesBO objMaster = new AttributesBO();

        //            try
        //            {
        //                objMaster.GetByPrimaryKey(grdConfigration.CurrentRow.Cells["Id"].Value.ToInt());
        //                if (objMaster.Current != null)
        //                {
        //                   // string Name = objMaster.Current.Name.ToStr();
        //                   // string ShortName = objMaster.Current.ShortName.ToStr();
        //                   // bool IsDefaultCheck = Convert.ToBoolean(ObjMaster.Current.IsDefault);

        //                    objMaster.Delete(objMaster.Current);

        //                    OnNew();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                if (objMaster.Errors.Count > 0)
        //                    ENUtils.ShowMessage(objMaster.ShowErrors());
        //                else
        //                {
        //                    ENUtils.ShowMessage(ex.Message);
        //                }
        //                e.Cancel = true;
        //            }
        //        }

        //    }
        //}

        //private void grid_CommandCellClick(object sender, EventArgs e)
        //{
        //    GridCommandCellElement gridCell = (GridCommandCellElement)sender;
        //    RadGridView grid = gridCell.GridControl;
        //    if (gridCell.ColumnInfo.Name == "btnDelete")
        //    {

        //        if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a user ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
        //        {
        //            grid.CurrentRow.Delete();
        //            grid.Refresh();
        //            txtAtrributeName.Text = "";
        //            txtShortName.Text = "";
        //            chkActiveManual.Checked = false;
        
        //            txtAtrributeName.Focus();
        //        }
        //    }

        //}

        //private void grdConfigration_CellDoubleClick(object sender, GridViewCellEventArgs e)
        //{
        //    if (grdConfigration.CurrentRow == null) return;


        //    ObjMaster.GetByPrimaryKey(grdConfigration.CurrentRow.Cells[Col_Configration.ID].Value);
        //    DisplayRecord();

        //}




        #region Overridden Methods

        public override void DisplayRecord()
        {
            

            rdoIVRDisabled.Checked = false;
            rdoIVREnabled.Checked = false;
            

            GetConfigrationData();
            //OnNew();
        }

        public override void AddNew()
        {
           OnNew();
        }

        public override void OnNew()
        {

            try
            {
                //grdConfigration.CurrentRow = null;
                //ObjMaster.New();
                //chkIsActive.Checked = true;
                //chkActiveManual.Checked = true;
                //txtAtrributeName.Text = string.Empty;
                //txtShortName.Text = string.Empty;
                //numCharges.Value = 0.00m;
                //numMaxQty.Value = 0.00m;
                
            }
            catch
            {


            }
        
        }

        public override void Save()
        {
            try
            {

                //if (ObjMaster.PrimaryKeyValue == null)
                //{
                //    ObjMaster.New();
                //}
                //else
                //{
                //    ObjMaster.Edit();
                //}

                //ObjMaster.Current.Name = txtAtrributeName.Text.Trim();
                //ObjMaster.Current.ShortName = txtShortName.Text.Trim();
                //ObjMaster.Current.MaxQty = numMaxQty.Value.ToInt();
                //ObjMaster.Current.ChargesPerQty = numCharges.Value;
                //ObjMaster.Current.AttributeCategoryId = 3;
                //if (chkActiveManual.Checked == true)
                //{
                //    ObjMaster.Current.IsDefault = chkActiveManual.Checked;
                //}
                //else 
                //{
                //    ObjMaster.Current.IsDefault = false;
                //}
                //if (chkIsActive.Checked == true)
                //{
                //    ObjMaster.Current.IsActive = chkIsActive.Checked;
                //}
                //else
                //{
                //    ObjMaster.Current.IsActive = false;
                //}
                //ObjMaster.Save();

                //PopulateData();
                //OnNew();

                //grdConfigration.CurrentRow = null;
                //txtAtrributeName.Focus();



               

            }
            catch (Exception ex)
            {
                //if (ObjMaster.Errors.Count > 0)
                //    ENUtils.ShowMessage(ObjMaster.ShowErrors());
                //else
                //{
                    ENUtils.ShowMessage(ex.Message);

                //}
            }
        }

        public override void PopulateData()
        {
            //LoadConfigrationGrid();
        }


        #endregion

        private void btnOnNew_Click(object sender, EventArgs e)
        {
            //txtAtrributeName.Text = "";
            //txtShortName.Text = "";
            //numMaxQty.Value = 0;
            //numCharges.Value = 0;
            //grdConfigration.Refresh();
            //grdConfigration.CurrentRow = null;
            //txtAtrributeName.Focus();
            //chkActiveManual.Checked = false;

            //ChkCallOffice.Checked = false;
            //chkRingBack.Checked = false;
            //chkAccountCharges.Checked = false;
            //chkAutoSTC.Checked = false;
            //chkSMSInbox.Checked = false;

            //txtNoPickupRestrictionMins.Value = 0;
            //rdoIVREnabled.Checked = true;
            //rdoIVRDisabled.Checked = false;

            //chkEnableHotDeskCallerId.Checked = false;
            //txtFrom.Value = 0;
            //txtTill.Value = 0;

            rdoIVRDisabled.Checked = false;
            rdoIVREnabled.Checked = false;
            GetConfigrationData();

        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            //ChkCallOffice.Checked = false;
            //chkRingBack.Checked = false;
            //chkAccountCharges.Checked = false;
            //chkAutoSTC.Checked = false;
            //chkSMSInbox.Checked = false;

            //txtNoPickupRestrictionMins.Text = "";
            //rdoGreen.Checked = true;
            //rdoPurple.Checked = false;

            //chkEnableHotDeskCallerId.Checked = false;
            //txtFrom.Text = "";
            //txtTill.Text = "";

            this.Dispose(true);
            GC.Collect();

        }



        private void btnSaveAPI_Click(object sender, EventArgs e)
        {
            
            try
            {
              

                int vStatus = 0;
                if (rdoIVREnabled.Checked == true)
                {
                    vStatus = 1;
                }
                else
                {
                    vStatus = 0;
                }

                string conn = Cryptography.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToStr(), "tcloudX@@!", true);
                conn = Cryptography.Encrypt(conn, "softeuroconnskey", true);
                string cloudUrl = Cryptography.Encrypt(System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr(), "tcloudX!", true);


                ResponseObject ConfMod = new ResponseObject();
                // Initialize the ConfMod.Data property with a new instance of DataObject
                ConfMod.Data = new ResponseData();
                ConfMod.Data.Data = new DataObject();

                ConfMod.Data.Data.IVRNumbers = txtIVRNumbers.Text.ToString();
                ConfMod.Data.Data.CalculateFares = chkCalculateFares.Checked.ToBool();
                ConfMod.Data.Data.ReleaseMode = chkReleaseMode.Checked.ToBool();
                ConfMod.Data.Data.Status = vStatus.ToInt();

                ConfMod.Data.Data.CompanyName= AppVars.objSubCompany.CompanyName;
                ConfMod.Data.Data.DefaultClientId = AppVars.objPolicyConfiguration.DefaultClientId;
                ConfMod.Data.Data.cloudUrl = cloudUrl;
                ConfMod.Data.Data.conn  = conn;

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(ConfMod);
                string URL = "";
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl+ "/api/Supplier/SaveIVRConfigration?mesg=" + json;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = HttpWebRequest.Create(URL);
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;

                WebResponse response = request.GetResponse();

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    //string rtn = sr.ReadToEnd();
                    //ResponseObject ConfMod = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>(rtn.ToStr());

                    //if (ConfMod != null)
                    //{
                    //    string IVRNumbers = ConfMod.Data.Data.IVRNumbers.ToString();
                    //    bool CalculateFares = ConfMod.Data.Data.CalculateFares.ToBool();
                    //    bool ReleaseMode = ConfMod.Data.Data.ReleaseMode.ToBool();
                    //    int status = ConfMod.Data.Data.Status.ToInt();


                    //    txtIVRNumbers.Text = IVRNumbers;
                    //    chkCalculateFares.Checked = CalculateFares;
                    //    chkReleaseMode.Checked = ReleaseMode;
                    //    if (status == 1)
                    //    {
                    //        rdoIVRDisabled.Checked = false;
                    //        rdoIVREnabled.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        rdoIVREnabled.Checked = false;
                    //        rdoIVRDisabled.Checked = true;
                    //    }
                    //}
                }










                this.Dispose(true);
                GC.Collect();
            }
            catch (Exception ex)
            {
            }
            
        }


        private void GetConfigrationData()
        {

            try
            {
                //string URL = "";


                //string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                ////URL = "http://localhost/DemoNadeem/api/supplier/GetConfigration";

                //URL = "http://localhost/DemoNadeem/api/Supplier/GetIVRConfigration?policyConfiguration=" + AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + "";
                //WebRequest request = HttpWebRequest.Create(URL);
                ////request.Headers.Add("policyConfiguration", AppVars.objPolicyConfiguration.DefaultClientId.ToStr());

                //System.Net.WebRequest.DefaultWebProxy = null;
                //request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                //WebResponse response = request.GetResponse();

                //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                //{
                //    //string rtn = sr.ReadToEnd();
                //    string rtn = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<string>(sr.ReadToEnd());
                //    ConfigrationModel ConfMod = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigrationModel>(rtn.ToStr());

                //    if (ConfMod != null)
                //    {
                //        string responseData = ConfMod.response.ToString();
                //        string message = ConfMod.message.ToString();
                //        string status = ConfMod.status.ToString();



                //        //ChkCallOffice.Checked = ConfMod.CallOffice.ToBool();
                //        //chkRingBack.Checked= ConfMod.RingBack.ToBool();
                //        //chkAccountCharges.Checked = ConfMod.AccountCharges.ToBool();
                //        //chkAutoSTC.Checked = ConfMod.chkAutoSTC.ToBool();
                //        //chkSMSInbox.Checked = ConfMod.chkSMSInbox.ToBool();
                //        //txtNoPickupRestrictionMins.Value = ConfMod.NoPickupRestrictionMins.ToInt();
                //        //rdoIVREnabled.Checked = ConfMod.Green.ToBool();
                //        //rdoIVRDisabled.Checked = ConfMod.Purple.ToBool();
                //        //chkEnableHotDeskCallerId.Checked = ConfMod.EnableHotDeskCallerId.ToBool();
                //        //txtFrom.Value = ConfMod.From.ToInt();
                //        //txtTill.Value = ConfMod.Till.ToInt();
                //    }
                //}



                //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                //{
                //    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                //    string rtn = reader.ReadToEnd();
                //}

                //this.Dispose(true);
                //GC.Collect();


                //string URL = "";
                //string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                //URL = "https://emeraldtel.co.uk/include.php?value=wallboardlogs&client=TeamVoIP&password=Nh7hFCnF&method=GetIVRStatus";

                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //WebRequest request = HttpWebRequest.Create(URL);
                //request.Proxy = System.Net.WebRequest.DefaultWebProxy;

                //WebResponse response = request.GetResponse();

                //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                //{
                //    string rtn = sr.ReadToEnd();
                //    ConfigrationModel ConfMod = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigrationModel>(rtn.ToStr());

                //    if (ConfMod != null)
                //    {
                //        string responseData = ConfMod.response.ToString();
                //        string message = ConfMod.message.ToString();
                //        int status = ConfMod.status.ToInt();

                //        if (status==1)
                //        {
                //            rdoIVRDisabled.Checked = false;
                //            rdoIVREnabled.Checked = true;
                //        }
                //        else
                //        {
                //            rdoIVREnabled.Checked = false;
                //            rdoIVRDisabled.Checked = true;                            
                //        }
                //    }
                //}


                ////----------------------------------

                //IVRInfo ivr = IVRCaller.GetIVRInfo(new IVRInfo { ClientId = AppVars.objPolicyConfiguration.DefaultClientId.ToStr() });

                //if (ivr != null)
                //{
                //    txtIVRNumbers.Text = ivr.IVRNumbers.ToStr().Trim();
                //    chkCalculateFares.Checked = ivr.CalculateFares;
                //    chkCalculateFares.Tag = ivr.CalculateFares;
                //    chkCalculateFares.Visible = true;

                //    chkReleaseMode.Checked = ivr.ReleaseMode;
                //    chkReleaseMode.Tag = ivr.ReleaseMode;
                //    chkReleaseMode.Visible = true;
                //    txtIVRNumbers.Tag = txtIVRNumbers.Text;
                //    txtIVRNumbers.Enabled = true;

                //}

                //---------------------------------






                string URL = "";
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
              
                URL = baseUrl +"/api/Supplier/GetIVRConfigration?policyConfiguration=" + AppVars.objPolicyConfiguration.DefaultClientId.ToStr() + "";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = HttpWebRequest.Create(URL);
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;

                WebResponse response = request.GetResponse();

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string rtn = sr.ReadToEnd();
                    ResponseObject ConfMod = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>(rtn.ToStr());
                    
                    if (ConfMod != null)
                    {
                        string IVRNumbers = ConfMod.Data.Data.IVRNumbers.ToString();
                        bool CalculateFares = ConfMod.Data.Data.CalculateFares.ToBool();
                        bool ReleaseMode = ConfMod.Data.Data.ReleaseMode.ToBool();
                        int status = ConfMod.Data.Data.Status.ToInt();
                        

                        txtIVRNumbers.Text = IVRNumbers;
                        chkCalculateFares.Checked = CalculateFares;
                        chkReleaseMode.Checked = ReleaseMode;
                        if (status == 1)
                        {
                            rdoIVRDisabled.Checked = false;
                            rdoIVREnabled.Checked = true;
                        }
                        else
                        {
                            rdoIVREnabled.Checked = false;
                            rdoIVRDisabled.Checked = true;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string URL = "";

        //    ConfigrationModel ConfMod = new ConfigrationModel();
        //    var json = new {
        //    CallOffice=ChkCallOffice.Checked,            
        //    RingBack=chkRingBack.Checked,
        //    AccountCharges=chkAccountCharges.Checked,
        //    AutoSTC=chkAutoSTC.Checked,
        //    SMSInbox=chkSMSInbox.Checked,
        //    NoPickupRestrictionMins=txtNoPickupRestrictionMins.Value,
        //    Green= rdoGreen.Checked,
        //    Purple=rdoPurple.Checked,
        //    EnableHotDeskCallerId=chkEnableHotDeskCallerId.Checked,
        //    From=txtFrom.Value,
        //    Till=txtTill.Value
        //};
        //JavaScriptSerializer js = new JavaScriptSerializer();
        //string jsonData = js.Serialize(json);

        //}
    }
}
