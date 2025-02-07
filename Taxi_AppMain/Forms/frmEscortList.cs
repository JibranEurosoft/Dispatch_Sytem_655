using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls;
using Telerik.Data;

namespace Taxi_AppMain
{
    public partial class frmEscortList : UI.SetupBase
    {
        Gen_EscortBO objMaster=null;
      //  int pageSize = 0;

        int DBSCheck = 0;
        int BuccalTraining = 0;
        int FirstAIDTraining = 0;
        int PATSTraining = 0;
        int SafeguardTraining = 0;
        int PassportBiometric = 0;
        int OtherTraining = 0;

        public frmEscortList()
        {
            try
            {
                InitializeComponent();
                this.Load += new EventHandler(frmCompanyList_Load);
              //  LoadCompanyList();
                //skip = 0;
                //txtSearch.Text = string.Empty;
               // PopulateData();

                grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
                grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
                objMaster = new Gen_EscortBO();

                this.SetProperties((INavigation)objMaster);
                grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);

                grdLister.ShowRowHeaderColumn = false;
                //this.Shown += new EventHandler(frmCompanyList_Shown);


                //PopulateData();
                //---- adil
                grdLister.ShowGroupPanel = false;
              //  pageSize = AppVars.objPolicyConfiguration.ListingPagingSize.ToInt();

                //grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

               

            }
            catch (Exception ex)
            {
                //ex.Message
                ENUtils.ShowMessage(ex.Message);
            }

        }




        private void AddCreateCompanyColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 80;

            col.Name = "btnCreateCompany";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Add New Escort";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }

        private void BindProperties()
        {

        }

        public static void AddEditColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();


            col.Name = "ColEdit";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Edit";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);


        }

        private void AddDeleteColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();

            col.Name = "ColDelete";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Delete";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }


        public override void RefreshData()
        {
            PopulateData();
            UpdatePendingApprovalValue();
        }

        //----- adil  14/5/13
        public override void PopulateData()
        {

            try
            {
                string searchTxt = txtSearch.Text.ToLower().Trim();
                string col = ddlColumns.Text.Trim().ToLower();

                bool col_no = false;
                bool col_name = false;
                bool col_email = false;
                bool col_address = false;
                bool col_telephone = false;
                bool col_mobile = false;
                bool col_routeno = false;
                //bool col_contactname = false;

                if (col == string.Empty || searchTxt.Length==0)
                {
                    col_name = true;
                }


                if (col == "routeno")
                {
                    col_routeno = true;
                }


                if (col == "escortno")
                {
                    col_no = true;
                }

                if (col == "escortname")
                {
                    col_name = true;
                }
                
                else if (col == "email")
                {
                    col_email = true;
                }

                else if (col == "address")
                {
                    col_address = true;
                }
                else if (col == "telephone")
                {
                    col_telephone = true;
                }
                else if (col == "mobile")
                {
                    col_mobile = true;
                }
                


                if (searchTxt.Length < 3)
                    searchTxt = string.Empty;



                var data1 = General.GetQueryable<Gen_Escort>(null).OrderBy(c => c.EscortName);

                //int cnt = data1.Count();
                //if (skip + pageSize > cnt && cnt - pageSize > 0)
                //    skip = cnt - pageSize;
                //else if (cnt <= pageSize)
                //    skip = 0;

                var query = from a in data1.AsEnumerable()

                            where
                                 (col_no && (a.EscortNo.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                               ||  (col_name && (a.EscortName.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                || (col_email && (a.EmailAddress.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                || (col_address && (a.AddressLine1.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                || (col_telephone && (a.TelephoneNo.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                || (col_mobile && (a.MobileNo.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                  || (col_routeno && (a.RouteNo.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                            // || (col_contactname && (a.ContactName.ToStr().ToLower().Contains(searchTxt) || searchTxt == string.Empty) && (a.HasEscort == true))

                            select new
                            {
                                Id = a.Id,
                                EscortName = a.EscortName,
                                //AccountType = a.AccountType.AccountTypeName,
                                RouteNo = a.RouteNo,
                                EscortNo = a.EscortNo,
                                Address = a.AddressLine1,
                                Email = a.EmailAddress,
                                Telephone = a.TelephoneNo,
                                Mobile = a.MobileNo,
                                DBSCheck = a.DBSCheck,
                                BuccalTraining = a.BuccalTraining,
                                FirstAIDTraining = a.FirstAIDTraining,
                                PATSTraining = a.PATSTraining,
                                SafeguardTraining = a.SafeguardTraining,
                                OtherTraining = a.OtherTraining,
                                PassportBiometric = a.PassportBiometric,

                                //Address = a.Address.ToStr() != string.Empty ? a.Address + " - " + a.Address1 : a.Address1,
                            };

                

                // this.grdLister.TableElement.BeginUpdate();

                //  if (excludeSkip == false)
                //        grdLister.DataSource = query.Skip(skip).Take(pageSize).ToList();
                //    else
                grdLister.DataSource = query.ToList();

                //    this.grdLister.TableElement.EndUpdate();

                //     lblTotal.Text = "Total Companies : " + cnt.ToStr();

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }
        List<Gen_Syspolicy_EscortDocumentList> listofDocs = new List<Gen_Syspolicy_EscortDocumentList>();

        void frmCompanyList_Load(object sender, EventArgs e)
        {
            try
            {
                //this.InitializeForm("frmEscortList");
                // adil
                LoadCompanyList();
                PopulateData();
                UpdatePendingApprovalValue();

                listofDocs = General.GetQueryable<Gen_Syspolicy_EscortDocumentList>(null).ToList();

                grdLister.Columns["Id"].IsVisible = false;

                grdLister.Columns["RouteNo"].Width = 80;
                grdLister.Columns["RouteNo"].HeaderText = "Route No";

                grdLister.Columns["EscortNo"].Width = 90;
                grdLister.Columns["EscortNo"].HeaderText = "Escort No";

                grdLister.Columns["EscortName"].Width = 160;
                grdLister.Columns["EscortName"].HeaderText = "Escort Name";

                grdLister.Columns["DBSCheck"].HeaderText = "DBS Check";
                grdLister.Columns["BuccalTraining"].HeaderText = "Buccal Training";
                grdLister.Columns["FirstAIDTraining"].HeaderText = "First AID ";
                grdLister.Columns["PATSTraining"].HeaderText = "PATS Training";
                grdLister.Columns["SafeguardTraining"].HeaderText = "Safeguard Training";            
                grdLister.Columns["PassportBiometric"].HeaderText = "Passport Biometric";
                grdLister.Columns["OtherTraining"].HeaderText = "Other Training";

                //grdLister.Columns["AccountType"].Width = 80;
                //grdLister.Columns["AccountType"].HeaderText = "Account Type";


                grdLister.Columns["Email"].Width = 160;
                grdLister.Columns["Address"].Width = 200;

                grdLister.Columns["Telephone"].Width = 140;
                grdLister.Columns["Mobile"].Width = 100;
                //grdLister.Columns["ContactName"].Width = 140;
                //grdLister.Columns["ContactName"].HeaderText = "Contact Name";
                grdLister.Columns["Telephone"].IsVisible = false;
                grdLister.Columns["Address"].IsVisible = false;
                grdLister.Columns["Email"].IsVisible = false;

                grdLister.AddEditColumn();

                //if (this.CanDelete)
                //{
                    grdLister.AddDeleteColumn();
                //}

                ddlColumns.Items.AddRange(grdLister.Columns.Where(c => c.Name != "Id" && c.Name != "btnEdit" && c.Name != "btnDelete" && c.Name != "btnCreateCompany")
                                          .Select(c => c.Name));

                ddlColumns.SelectedIndex = 0;


                grdLister.Columns["DBSCheck"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["BuccalTraining"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["FirstAIDTraining"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["PATSTraining"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["SafeguardTraining"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["PassportBiometric"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["PassportBiometric"].FormatString = "{0:dd/MM/yyyy}";
                grdLister.Columns["OtherTraining"].FormatString = "{0:dd/MM/yyyy}";
                             

                DBSCheck = listofDocs.FirstOrDefault(c => c.Id == 1).DefaultIfEmpty().ExpiryDays.ToInt();
                PassportBiometric = listofDocs.FirstOrDefault(c => c.Id == 2).DefaultIfEmpty().ExpiryDays.ToInt();
                SafeguardTraining = listofDocs.FirstOrDefault(c => c.Id == 3).DefaultIfEmpty().ExpiryDays.ToInt();
                PATSTraining = listofDocs.FirstOrDefault(c => c.Id == 4).DefaultIfEmpty().ExpiryDays.ToInt();
                BuccalTraining = listofDocs.FirstOrDefault(c => c.Id == 5).DefaultIfEmpty().ExpiryDays.ToInt();
                FirstAIDTraining = listofDocs.FirstOrDefault(c => c.Id == 6).DefaultIfEmpty().ExpiryDays.ToInt();
                OtherTraining = listofDocs.FirstOrDefault(c => c.Id == 7).DefaultIfEmpty().ExpiryDays.ToInt();

                timer1.Start();
            }
            catch (Exception ex)
            {


            }

        }

        private void LoadCompanyList()
        {


            grdLister.AllowAutoSizeColumns = true;
            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;


            var data1 = General.GetQueryable<Gen_Escort>(null).OrderBy(c => c.EscortName);


            var query = from a in data1


                        select new
                        {
                            Id = a.Id,
                            RouteNo = a.RouteNo,
                            EscortNo = a.EscortNo,
                            EscortName = a.EscortName,
                            Address = a.AddressLine1,
                            Email = a.EmailAddress,
                            Telephone = a.TelephoneNo,
                            Mobile = a.MobileNo,
                            DBSCheck = a.DBSCheck,
                            BuccalTraining = a.BuccalTraining,
                            FirstAIDTraining = a.FirstAIDTraining,
                            PATSTraining = a.PATSTraining,
                            SafeguardTraining = a.SafeguardTraining,                          
                            PassportBiometric = a.PassportBiometric,
                            OtherTraining = a.OtherTraining,
                        };


            grdLister.DataSource = query.ToList();


           

            // this.SetRefreshingProperties(AppVars.BLData.GetCommand(query), grdLister, false);

            //grdLister.Columns["ColDelete"].Width = 70;


        }

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Company ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {


                    RadGridView grid = gridCell.GridControl;
                    grid.CurrentRow.Delete();
                }
            }
            else if (gridCell.ColumnInfo.Name.ToLower() == "btnedit")
            {
                ViewDetailForm();


            }
        }



        void frmLocationList_Load(object sender, EventArgs e)
        {
        }

        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ViewDetailForm();
        }

        private void ViewDetailForm()
        {

            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {

                //frmEscortList frm = new frmEscortList(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
                //frm.ShowDialog();
                ShowEscortForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
            }
        }


        private void ShowEscortForm(int id)
        {
            StopTimer();

            frmEscort frm = new frmEscort();
            frm.OnDisplayRecord(id);

            frm.ControlBox = true;
            frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm.MaximizeBox = false;
            frm.ShowDialog();

            StartTimer();

        }


        void Grid_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {

              //  objMaster = new Gen_EscortBO();
                this.SetProperties((INavigation)objMaster);


                try
                {


                    objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
                    objMaster.Delete(objMaster.Current);


                }
                catch (Exception ex)
                {
                    if (objMaster.Errors.Count > 0)
                        ENUtils.ShowMessage(objMaster.ShowErrors());
                    else
                    {
                        ENUtils.ShowMessage(ex.Message);

                    }
                    e.Cancel = true;

                }


            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            skip = 0;
            PopulateData();
        }

        private void btnShowAllCompanies_Click(object sender, EventArgs e)
        {
            skip = 0;
            txtSearch.Text = string.Empty;
            PopulateData();
        }


        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                PopulateData();

            }
        }

        private void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            frmEscort frm = new frmEscort();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.Show();

        }

        private void StopTimer()
        {
            timer1.Stop();

        }

        private void StartTimer()
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.Columns.Count == 0) return;


                DateTime dtNow = DateTime.Now.ToDate();

                if ((AppVars.frmMDI.ActiveControl != null && AppVars.frmMDI.ActiveControl.Name.Equals("frmEscortList1") == true))
                {

                    foreach (var item in grdLister.Rows)
                    {

                        if (item.Cells["DBSCheck"].Value.ToDate() < dtNow)
                        {
                            item.Cells["DBSCheck"].Style.BackColor = Color.Pink;
                            item.Cells["DBSCheck"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["DBSCheck"].Value.ToDate() < dtNow.AddDays(DBSCheck))
                        {

                            if (item.Cells["DBSCheck"].Style.BackColor == Color.White)
                            {

                                item.Cells["DBSCheck"].Style.BackColor = Color.Yellow;
                            }
                            else
                            {

                                item.Cells["DBSCheck"].Style.BackColor = Color.White;
                            }

                            item.Cells["DBSCheck"].Style.CustomizeFill = true;

                        }




                        if (item.Cells["BuccalTraining"].Value.ToDate() < dtNow)
                        {
                            item.Cells["BuccalTraining"].Style.BackColor = Color.Pink;
                            item.Cells["BuccalTraining"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["BuccalTraining"].Value.ToDate() < dtNow.AddDays(BuccalTraining))
                        {

                            if (item.Cells["BuccalTraining"].Style.BackColor == Color.White)
                            {

                                item.Cells["BuccalTraining"].Style.BackColor = Color.Lavender;
                            }
                            else
                            {

                                item.Cells["BuccalTraining"].Style.BackColor = Color.White;
                            }

                            item.Cells["BuccalTraining"].Style.CustomizeFill = true;

                        }




                        if (item.Cells["FirstAIDTraining"].Value.ToDate() < dtNow)
                        {
                            item.Cells["FirstAIDTraining"].Style.BackColor = Color.Pink;
                            item.Cells["FirstAIDTraining"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["FirstAIDTraining"].Value.ToDate() < dtNow.AddDays(FirstAIDTraining))
                        {

                            if (item.Cells["FirstAIDTraining"].Style.BackColor == Color.White)
                            {

                                item.Cells["FirstAIDTraining"].Style.BackColor = Color.Lavender;
                            }
                            else
                            {

                                item.Cells["FirstAIDTraining"].Style.BackColor = Color.White;
                            }

                            item.Cells["FirstAIDTraining"].Style.CustomizeFill = true;

                        }



                        if (item.Cells["PATSTraining"].Value.ToDate() < dtNow)
                        {
                            item.Cells["PATSTraining"].Style.BackColor = Color.Pink;
                            item.Cells["PATSTraining"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["PATSTraining"].Value.ToDate() < dtNow.AddDays(PATSTraining))
                        {

                            if (item.Cells["PATSTraining"].Style.BackColor == Color.White)
                            {

                                item.Cells["PATSTraining"].Style.BackColor = Color.PaleGoldenrod;
                            }
                            else
                            {

                                item.Cells["PATSTraining"].Style.BackColor = Color.White;
                            }

                            item.Cells["PATSTraining"].Style.CustomizeFill = true;

                        }



                        if (item.Cells["SafeguardTraining"].Value.ToDate() < dtNow)
                        {
                            item.Cells["SafeguardTraining"].Style.BackColor = Color.Pink;
                            item.Cells["SafeguardTraining"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["SafeguardTraining"].Value.ToDate() < dtNow.AddDays(SafeguardTraining))
                        {

                            if (item.Cells["SafeguardTraining"].Style.BackColor == Color.White)
                            {

                                item.Cells["SafeguardTraining"].Style.BackColor = Color.Orange;
                            }
                            else
                            {

                                item.Cells["SafeguardTraining"].Style.BackColor = Color.White;
                            }

                            item.Cells["SafeguardTraining"].Style.CustomizeFill = true;

                        }



                        if (item.Cells["PassportBiometric"].Value.ToDate() < dtNow)
                        {
                            item.Cells["PassportBiometric"].Style.BackColor = Color.Pink;
                            item.Cells["PassportBiometric"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["PassportBiometric"].Value.ToDate() < dtNow.AddDays(PassportBiometric))
                        {

                            if (item.Cells["PassportBiometric"].Style.BackColor == Color.White)
                            {

                                item.Cells["PassportBiometric"].Style.BackColor = Color.Gainsboro;
                            }
                            else
                            {

                                item.Cells["PassportBiometric"].Style.BackColor = Color.White;
                            }

                            item.Cells["PassportBiometric"].Style.CustomizeFill = true;

                        }



                        if (item.Cells["OtherTraining"].Value.ToDateTime() < DateTime.Now)
                        {
                            item.Cells["OtherTraining"].Style.BackColor = Color.Pink;
                            item.Cells["OtherTraining"].Style.CustomizeFill = true;

                        }
                        else if (item.Cells["OtherTraining"].Value.ToDateTime() < DateTime.Now.AddDays(OtherTraining))
                        {

                            if (item.Cells["OtherTraining"].Style.BackColor == Color.White)
                            {

                                item.Cells["OtherTraining"].Style.BackColor = Color.LightBlue;
                            }
                            else
                            {

                                item.Cells["OtherTraining"].Style.BackColor = Color.White;
                            }

                            item.Cells["OtherTraining"].Style.CustomizeFill = true;

                        }





                    }




                }
            }
            catch (Exception ex)
            {


            }
        }

        private void btnPendingApproval_Click(object sender, EventArgs e)
        {
            try
            {
                //frmDriverInfo frm = new frmDriverInfo();
                //frm.ShowDialog();

                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcesses().FirstOrDefault(c => c.ProcessName.Contains("DriverForUs"));

                if (proc != null)
                {
                    proc.Kill();
                    proc.CloseMainWindow();
                    proc.Close();
                }

                string conn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToStr().Replace(" ", "**");
                conn = "frmEscortInfo" + " " + conn;



                System.Diagnostics.Process pp = new System.Diagnostics.Process();
                pp.StartInfo.FileName = Application.StartupPath + "/DriverForUs/DriverForUs.exe";
                pp.StartInfo.Arguments = conn;
                pp.Start();
                pp.WaitForExit();

                General.RefreshListWithoutSelectedOnRefreshData<frmEscortList>("frmEscortList1");
                UpdatePendingApprovalValue();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePendingApprovalValue()
        {
            try
            {
                if (AppVars.listUserRights.Count(c => c.functionId == "SHOW PENDING APPROVAL ESCORTS") > 0)
                {
                    btnPendingApproval.Visible = true;

                    int cnt = new TaxiDataContext().ExecuteQuery<int>("exec stp_GetAllEscortApprovals {0}", "Pending").Count();

                    btnPendingApproval.Text = "Pending Approval(" + cnt + ")";
                    btnPendingApproval.Tag = cnt;
                    if (cnt > 0)
                    {
                        btnPendingApproval.BackColor = Color.OrangeRed;

                    }
                }
            }
            catch
            {

            }
        }

    }
}

