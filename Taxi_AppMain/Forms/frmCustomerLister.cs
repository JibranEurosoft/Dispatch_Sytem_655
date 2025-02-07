using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Collections;
using Telerik.WinControls.UI;
using System.Linq;
using Utils;
using Telerik.WinControls.Enumerations;
using UI;
using Taxi_BLL;
using Taxi_Model;
using CheckBoxInHeader;
using System.Threading;

namespace Taxi_AppMain
{
    public partial class frmCustomerLister : Telerik.WinControls.UI.RadForm
    {
        List<CurrentCustomer> objCustomer = new List<CurrentCustomer>();

        private List<object[]> _listofData;

        public List<object[]> ListofData
        {
            get { return _listofData; }
            set { _listofData = value; }
        }

                   
       private const string COLCheckBox = "COL_ChECKBOX";
        
        public struct COLS
        {
            public static string Id = "Id";
            public static string Name = "Name";
            public static string MobileNo = "MobileNo";
           
        }
       

        public frmCustomerLister()
        {
            InitializeComponent();
            LoadGrid();
            fillcombo();

            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now.ToDate();

            this.ListofData = new List<object[]>();
            this.txtPostCode.KeyDown += new KeyEventHandler(txtPostCode_KeyDown);
            this.txtNoofDays.KeyDown += new KeyEventHandler(txtNoofDays_KeyDown);
            this.txtNoofBooking.KeyDown += new KeyEventHandler(txtNoofBooking_KeyDown);
            txtNoofBooking.KeyPress += new KeyPressEventHandler(txtNoofBooking_KeyPress);
            txtNoofDays.KeyPress += new KeyPressEventHandler(txtNoofDays_KeyPress);

            EndRange.Maximum = grdLister.Rows.Count();
            if (grdLister.Rows.Count() == 0)
            {
                StartRange.Maximum = grdLister.Rows.Count();
            }
            else
            {
                StartRange.Maximum = grdLister.Rows.Count() - 1;
            }
           

        }

        void txtNoofDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }

        void txtNoofBooking_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }

        private void fillcombo()
        {
            using (TaxiDataContext db = new TaxiDataContext())
            {
                var zonesList = db.GetTable<Gen_Zone>().Where(c => c.MinLatitude != null).OrderBy(c => c.OrderNo).Select(args => new { args.Id, ZoneName = args.OrderNo + ". " + args.ZoneName }).ToList();

                FillPlotCombo(ddlZones, zonesList);
            }
        }

        private void FillPlotCombo(MyDropDownList ddlZones, object zonesList)
        {
            ddlZones.DisplayMember = "ZoneName";
            ddlZones.ValueMember = "Id";
            
            ddlZones.DataSource = zonesList;
            
            ddlZones.DropDownStyle = RadDropDownStyle.DropDown;

            ddlZones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            ddlZones.AutoCompleteDataSource = AutoCompleteSource.ListItems;

            ddlZones.SelectedIndex = -1;
        }

        void txtNoofBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listNoofBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 3, string.IsNullOrEmpty(txtNoofDays.Text)
                 ? (int?)null : Convert.ToInt32(txtNoofDays.Text), txtPostCode.Text, txtNoofBooking.Text
              , ddlZones.SelectedValue.ToInt(), dtpFromDate.Value.ToDate(), dtpToDate.Value.ToDate()).ToList();

                grdLister.DataSource = listNoofBooking;

                for (int i = 0; i < listNoofBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }

                chkSelectAll.Checked = true;
            }
        }

        void txtNoofDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listNoofDays = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 2, string.IsNullOrEmpty(txtNoofDays.Text)
                ? (int?)null : Convert.ToInt32(txtNoofDays.Text), txtPostCode.Text, txtNoofBooking.Text
                 , ddlZones.SelectedValue.ToInt(), dtpFromDate.Value.ToDate(), dtpToDate.Value.ToDate()).ToList();

                grdLister.DataSource = listNoofDays;

                for (int i = 0; i < listNoofDays.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }

                chkSelectAll.Checked = true;
            }
        }

        void txtPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //       var listpostcode = new Taxi_Model.TaxiDataContext().stp_CustomerDetail(1, string.IsNullOrEmpty(txtNoofDays.Text)
                //  ? (int?)null : Convert.ToInt32(txtNoofDays.Text), txtPostCode.Text, txtNoofBooking.Text
                //, ddlZones.SelectedValue.ToInt(), dtpFromDate.Value.ToDate(), dtpToDate.Value.ToDate()).ToList();

                int NoofBooking = 0;
                int NoofDays = 0;

                int zoneId = ddlZones.SelectedValue.ToInt();

                if (txtNoofDays.Text.Trim().Length == 0 || txtNoofDays.Text.ToStr().IsNumeric())
                    NoofDays = 0;

                if (txtNoofBooking.Text.Trim().Length==0 || txtNoofBooking.Text.ToStr().IsNumeric())
                    NoofBooking = txtNoofBooking.Text.ToInt();



                var listpostcode = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}",1, NoofDays, txtPostCode.Text, NoofBooking
       , zoneId, dtpFromDate.Value.ToDate(), dtpToDate.Value.ToDate()).ToList();

                grdLister.DataSource = listpostcode;

                for (int i = 0; i < listpostcode.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }

                chkSelectAll.Checked = true;       
            }
        }

       
        public void GetCustomerDetail()
        {
            try
            {

                
                var listBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}",10, 1, "", 0, 0, DateTime.Now, DateTime.Now).ToList();

                grdLister.DataSource = listBooking;

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }
               
                lblTotalRecods.Text =  "Records Found : " + grdLister.Rows.Count();

            //var list = (from a in AppVars.BLData.GetQueryable<Customer>(c => (c.MobileNo != null) && (c.MobileNo != string.Empty) && (c.MobileNo.Length >= 10))
            //            group a by a.MobileNo into g

            //            select new

            //            {
            //                Id = g.FirstOrDefault().Id,
            //                Name = g.FirstOrDefault().Name,
            //                MobileNo = g.FirstOrDefault().MobileNo,

            //            }).Distinct().ToList();

            //grdLister.DataSource = list;

            //for (int i = 0; i < list.Count; i++)
            //{
            //    grdLister.Rows[i].Cells[0].Value = true;
            //}
            chkSelectAll.Checked = true;


            EndRange.Maximum = grdLister.Rows.Count;
            EndRange.Value = grdLister.Rows.Count;

            if (grdLister.Rows.Count() == 0)
            {
                StartRange.Maximum = grdLister.Rows.Count();
            }
            else
            {
                StartRange.Maximum = grdLister.Rows.Count() - 1;
            }
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }
        }

        public void LoadGrid()
        {
            try
            {
                
                GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
                col1.Width = 30;
                col1.AutoSizeMode = BestFitColumnMode.None;
                col1.HeaderText = "";
                col1.Name = "Check";

                grdLister.Columns.Add(col1);
            
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = "Id";
            col.FieldName = "Id";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = "Name";
            col.FieldName = "Name";
            col.HeaderText = "Name";
            col.ReadOnly = true;
            col.Width = 200;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = "MobileNo";
            col.FieldName = "MobileNo";
            col.ReadOnly = true;
            col.Width = 200;
            col.HeaderText = "Mobile No";
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = "Address1";
            col.FieldName = "Address1";
            col.ReadOnly = true;
            col.Width = 400;
            col.HeaderText = "Address";
            grdLister.Columns.Add(col);
                
            GetCustomerDetail();
                   
            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }
        
        }
               
               
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);

        private void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
               
                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                    
                e.CellElement.BackColor = Color.SteelBlue;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.Font = newFont;
                e.CellElement.ForeColor = Color.White;
                e.CellElement.DrawFill = true;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

            }                   

        }

        
        private void frmLister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
            }
        }

        private void grdLister_Click(object sender, EventArgs e)
        {

        }
      
    
        private void btnGetCustomerDetail_Click(object sender, EventArgs e)
        {
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            try
            {

           
            ListofData.Clear();
            object[] obj;

            GridViewRowInfo row = null;


            int startRange = StartRange.Value.ToInt();
            int endRange = EndRange.Value.ToInt();

            for (int z = startRange; z < endRange; z++)
            {
                row = grdLister.Rows[z];

                if (row.Cells[0].Value.ToBool() == true)
                { 
                obj = new object[grdLister.Columns.Count - 1];

                for (int i = 1; i < row.Cells.Count; i++)
                {
                    obj[i - 1] = row.Cells[i].Value;
                }

                ListofData.Add(obj);
                }
            }

            //foreach (GridViewRowInfo row in grdLister.Rows[0].Where(c => c.Cells[0].Value.ToBool()))
            //{
            //    obj = new object[grdLister.Columns.Count - 1];

            //    for (int i = 1; i < row.Cells.Count; i++)
            //    {
            //        obj[i - 1] = row.Cells[i].Value;
            //    }

            //    ListofData.Add(obj);

            //}

               this.Close();
            }

            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }

        
        //private void chkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkAll.IsChecked == true)
        //    {
        //        chkBookingWise.Checked = false;
        //        chkDateTimeWise.Checked = false;
        //        chkDateWise.Checked = false;
        //        chkAreaWise.Checked = false;
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //        txtNoofBooking.Visible = false;
        //        txtNoofDays.Visible = false;
        //        lblNoofBooking.Visible = false;
        //        lblnoofDays.Visible = false;
        //        lblFromDate.Visible = false;
        //        lblToDate.Visible = false;
        //        dtpFromDate.Visible = false;
        //        dtpToDate.Visible = false;
        //        chkAppUsers.Checked = false;
        //        GetCustomerDetail();
        //    }
           
            
        //}

        //private void chkAreaWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkAreaWise.Checked == true)
        //    {
        //        chkDateTimeWise.Checked = false;
        //        chkDateWise.Checked = false;
        //        chkBookingWise.Checked = false;
        //        chkZones.Checked = false;
        //        chkPostCode.Checked = true;
        //        chkPostCode.Visible = true;
        //        chkZones.Visible = true;
        //        chkInclude.Visible = true;
        //        chkNotInPeriod.Visible = true;
        //        chkInclude.Checked = true;
        //        chkNotInclude.Visible = true;
        //        chkAppUsers.Checked = false;
        //        lblNoofBooking.Visible = false;
        //        lblnoofDays.Visible = false;
        //        txtNoofBooking.Visible = false;
        //        txtNoofDays.Visible = false;
        //        txtPostCode.Visible = true;
        //        chkAll.IsChecked = false;
        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;

        //        txtNoofDays.Text = string.Empty;
        //        txtNoofBooking.Text = string.Empty;

        //    }
        //    else 
        //    {
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //    }
        //}

        //private void chkDateWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{

        //    if (chkDateWise.Checked == true)
        //    {
        //        chkAll.Checked = false;
        //        chkAreaWise.Checked = false;
        //        chkBookingWise.Checked = false;
        //        chkDateTimeWise.Checked = false;
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //        lblNoofBooking.Visible = false;
        //        txtNoofBooking.Visible = false;
        //        lblFromDate.Visible = false;
        //        lblToDate.Visible = false;
        //        dtpFromDate.Visible = false;
        //        dtpToDate.Visible = false;
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;
        //        chkAppUsers.Checked = false;
        //        lblnoofDays.Visible = true;
        //        txtNoofDays.Visible = true;

        //        txtPostCode.Text = string.Empty;
        //        txtNoofBooking.Text = string.Empty;

        //    }
        //    else
        //    {
        //        lblnoofDays.Visible = false;
        //        txtNoofDays.Visible = false;
        //    }
        //}

        //private void chkBookingWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkBookingWise.Checked == true)
        //    {
        //        chkAll.IsChecked = false;
        //        chkAreaWise.Checked = false;
        //        chkDateWise.Checked = false;
        //        chkDateTimeWise.Checked = false;
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //        txtNoofDays.Visible = false;
        //        lblnoofDays.Visible = false;
        //        chkAppUsers.Checked = false;

        //        lblFromDate.Visible = false;
        //        lblToDate.Visible = false;
        //        dtpFromDate.Visible = false;
        //        dtpToDate.Visible = false;

        //        lblNoofBooking.Visible = true;
        //        txtNoofBooking.Visible = true;

        //        txtNoofDays.Text = string.Empty;
        //        txtPostCode.Text = string.Empty;
                              
               
        //    }
        //    else
        //    {
        //        lblNoofBooking.Visible = false;
        //        txtNoofBooking.Visible = false;
        //    }
        //}

        //private void chkPostCode_CheckedChanged(object sender, EventArgs e)
        //{
        //     if (chkPostCode.Checked == true)
        //     {
        //         chkZones.Checked = false;
        //         txtPostCode.Visible = true;
        //         ddlZones.Visible = false;
        //     }
        //}

        //private void chkZones_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkZones.Checked == true)
        //    {
        //        chkPostCode.Checked = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = true;
        //        txtPostCode.Text = string.Empty;
        //    }
        //}

        private void chkSelectAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkSelectAll.Checked == true)
            {
                if (grdLister.Rows.Count > 0)
                {
                    for (int i = 0; i < grdLister.Rows.Count; i++)
                    {
                        grdLister.Rows[i].Cells["Check"].Value = true;//..CurrentCell.Value;
                    }
                }
            }
            else if (chkSelectAll.Checked == false)
            {
                if (grdLister.Rows.Count > 0)
                {
                    for (int i = 0; i < grdLister.Rows.Count; i++)
                    {
                        grdLister.Rows[i].Cells["Check"].Value = false;//..CurrentCell.Value;

                    }
                }
            }
        }

        private void btnGetCustomerDetail_Click_1(object sender, EventArgs e)
        {
            try
            {

    
            int? NoofDays = string.IsNullOrEmpty(txtNoofDays.Text)
             ? (int?)null : Convert.ToInt32(txtNoofDays.Text);

            int? NoofBooking = string.IsNullOrEmpty(txtNoofBooking.Text)
              ? (int?)null : Convert.ToInt32(txtNoofBooking.Text);


            DateTime? FromDate = dtpFromDate.Value.ToDate();
            DateTime? ToDate = dtpToDate.Value.ToDate();

            if (ToDate < FromDate)
            {
                ENUtils.ShowMessage("To Date must be greater than From Date");
                return;
            }



            if(FromDate!=null && ToDate!=null)
                {

                    ToDate = ToDate + new TimeSpan(23, 59, 59);

                }

                int zoneId = ddlZones.SelectedValue.ToInt();

                if (NoofDays == null)
                    NoofDays = 0;

                if (NoofBooking == null)
                    NoofBooking = 0;
               

            if (txtPostCode.Visible == true)
            {

                  
                if (chkInclude.Checked == true)
                {
                        
                    var  listInclude = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 1, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();
                   grdLister.DataSource = listInclude;

                   for (int i = 0; i < listInclude.Count; i++)
                   {
                       grdLister.Rows[i].Cells[0].Value = true;
                   }
                
                }
                else
                {
                 var  listNotInclude = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 7, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();
                 grdLister.DataSource = listNotInclude;
                 
                 for (int i = 0; i < listNotInclude.Count; i++)
                 {
                     grdLister.Rows[i].Cells[0].Value = true;
                 }
                
                }

            }
            else if (ddlZones.Visible == true)
            {
                if (chkInclude.Checked == true)
                {
                    var listZoneInclude = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 4, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();

                    grdLister.DataSource = listZoneInclude;

                    for (int i = 0; i < listZoneInclude.Count; i++)
                    {
                        grdLister.Rows[i].Cells[0].Value = true;
                    }
                }
                else
                {
                    var listZoneNotInclude = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 8, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();

                    grdLister.DataSource = listZoneNotInclude;

                    for (int i = 0; i < listZoneNotInclude.Count; i++)
                    {
                        grdLister.Rows[i].Cells[0].Value = true;
                    }
                }
                
            }
            else if (txtNoofDays.Visible == true)
            {
                var listNoofDays = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 2, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate,ToDate).ToList();

                grdLister.DataSource = listNoofDays;

                for (int i = 0; i < listNoofDays.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }
                
            }
            else if (txtNoofBooking.Visible == true)
            {
                var listBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 3, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate,ToDate).ToList();

                grdLister.DataSource = listBooking;

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }         
                
            }
            else if (chkPeriod.Checked == true)
            {
                var listBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 6, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();

                grdLister.DataSource = listBooking;

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }
               
            }
            else if (chkAppUsers.IsChecked == true)
            {
                var listBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 9, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();

                grdLister.DataSource = listBooking;

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }

            }
            else if (chkNotInPeriod.Checked == true)
            {
                var listBooking = new Taxi_Model.TaxiDataContext().ExecuteQuery<stp_CustomerDetailResult>("exec stp_CustomerDetail {0},{1},{2},{3},{4},{5},{6}", 5, NoofDays, txtPostCode.Text, NoofBooking, zoneId, FromDate, ToDate).ToList();

                grdLister.DataSource = listBooking;

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[0].Value = true;
                }

            }
           
            lblTotalRecods.Text = "Records Found : " + grdLister.Rows.Count();

            EndRange.Maximum = grdLister.Rows.Count();
            EndRange.Value = grdLister.Rows.Count;

            if (grdLister.Rows.Count() == 0)
            {
                StartRange.Maximum = grdLister.Rows.Count();
            }
            else
            {
                StartRange.Maximum = grdLister.Rows.Count() - 1;
            }
               

            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }
        }

        //private void chkPeriod_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkPeriod.Checked == true)
        //    {
        //        chkNotInPeriod.Checked = false;
        //        lblFromDate.Visible = true;
        //        lblToDate.Visible = true;
        //        dtpFromDate.Visible = true;
        //        dtpToDate.Visible = true;
        //    }
           
        //}

        //private void chkNotInPeriod_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkNotInPeriod.Checked == true)
        //    {
        //       chkPeriod.Checked = false;
        //       lblFromDate.Visible = true;
        //       lblToDate.Visible = true;
        //       dtpFromDate.Visible = true;
        //       dtpToDate.Visible = true;
                               
        //    }
           
        //}

        //private void chkInclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkInclude.Checked == true)
        //    {
        //        chkNotInclude.Checked = false;
        //    }
        //    else
        //    {
        //        chkNotInclude.Checked = true;
        //    }
        //}

        //private void chkNotInclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkNotInclude.Checked == true)
        //    {
        //        chkInclude.Checked = false;
        //    }
        //    else
        //    {
        //        chkInclude.Checked = true;
        //    }
        //}

        //private void chkDateTimeWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkDateTimeWise.Checked == true)
        //    {
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;

        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //        txtNoofBooking.Visible = false;
        //        txtNoofDays.Visible = false;

        //        lblnoofDays.Visible = false;
        //        lblNoofBooking.Visible = false;

        //        chkAll.Checked = false;
        //        chkAreaWise.Checked = false;
        //        chkBookingWise.Checked = false;
        //        chkDateWise.Checked = false;
        //        chkNotInPeriod.Checked = false;
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkAppUsers.Checked = false;

        //        lblFromDate.Visible = true;
        //        lblToDate.Visible = true;
        //        dtpFromDate.Visible = true;
        //        dtpToDate.Visible = true;
        //        chkPeriod.Visible = true;
        //        chkNotInPeriod.Visible = true;
        //        chkPeriod.Checked = true;


        //        txtNoofDays.Text = string.Empty;
        //        txtPostCode.Text = string.Empty;
        //        txtNoofBooking.Text = string.Empty;

        //    }
        //    else
        //    {

        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;


        //        lblFromDate.Visible = false;
        //        lblToDate.Visible = false;
        //        dtpFromDate.Visible = false;
        //        dtpToDate.Visible = false;

        //    }
        //}

        //private void chkAppUsers_ToggleStateChanged(object sender, StateChangedEventArgs args)
        //{
        //    if (chkAppUsers.Checked == true)
        //    {
        //        chkAll.IsChecked = false;
        //        chkAreaWise.Checked = false;
        //        chkDateWise.Checked = false;
        //        chkInclude.Visible = false;
        //        chkNotInclude.Visible = false;
        //        chkPeriod.Visible = false;
        //        chkNotInPeriod.Visible = false;
        //        chkPostCode.Visible = false;
        //        chkZones.Visible = false;
        //        txtPostCode.Visible = false;
        //        ddlZones.Visible = false;
        //        txtNoofDays.Visible = false;
        //        lblnoofDays.Visible = false;
        //        chkDateTimeWise.Checked = false;
        //        lblFromDate.Visible = false;
        //        lblToDate.Visible = false;
        //        dtpFromDate.Visible = false;
        //        dtpToDate.Visible = false;
        //        chkBookingWise.Checked = false;

        //        lblNoofBooking.Visible = false;
        //        txtNoofBooking.Visible = false;

        //        txtNoofDays.Text = string.Empty;
        //        txtPostCode.Text = string.Empty;

        //    }

        //}

        private void chkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAll.IsChecked == true)
            {
                //chkBookingWise.Checked = false;
                //chkDateTimeWise.Checked = false;
                //chkDateWise.Checked = false;
                //chkAreaWise.Checked = false;
                chkPostCode.Visible = false;
                chkZones.Visible = false;
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = false;
                txtNoofBooking.Visible = false;
                txtNoofDays.Visible = false;
                lblNoofBooking.Visible = false;
                lblnoofDays.Visible = false;
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;
                txtPostCode.Text = string.Empty;
                //chkAppUsers.Checked = false;
                GetCustomerDetail();
                //Thread threadInput = new Thread();
                //threadInput.Start();
                
               
            }
        }

        private void chkAreaWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAreaWise.IsChecked == true)
            {
                //chkDateTimeWise.Checked = false;
                //chkDateWise.Checked = false;
                //chkBookingWise.Checked = false;
                chkZones.Checked = false;
                chkPostCode.Checked = true;
                chkPostCode.Visible = true;
                chkZones.Visible = true;
                chkInclude.Visible = true;
                chkNotInPeriod.Visible = true;
                chkInclude.Checked = true;
                chkNotInclude.Visible = true;
                //chkAppUsers.Checked = false;
                lblNoofBooking.Visible = false;
                lblnoofDays.Visible = false;
                txtNoofBooking.Visible = false;
                txtNoofDays.Visible = false;
                txtPostCode.Visible = true;
                chkAll.IsChecked = false;
                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;
                txtPostCode.Text = string.Empty;
                txtNoofDays.Text = string.Empty;
                txtNoofBooking.Text = string.Empty;

            }
            else
            {
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                chkPostCode.Visible = false;
                chkZones.Visible = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = false;
            }
        }

        private void chkDateWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkDateWise.IsChecked == true)
            {
                //chkAll.Checked = false;
                //chkAreaWise.Checked = false;
                //chkBookingWise.Checked = false;
                //chkDateTimeWise.Checked = false;
                chkPostCode.Visible = false;
                chkZones.Visible = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = false;
                lblNoofBooking.Visible = false;
                txtNoofBooking.Visible = false;
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;
                //chkAppUsers.Checked = false;
                lblnoofDays.Visible = true;
                txtNoofDays.Visible = true;

                txtPostCode.Text = string.Empty;
                txtNoofBooking.Text = string.Empty;

            }
            else
            {
                lblnoofDays.Visible = false;
                txtNoofDays.Visible = false;
            }
        }

        private void chkBookingWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkBookingWise.IsChecked == true)
            {
                //chkAll.IsChecked = false;
                //chkAreaWise.Checked = false;
                //chkDateWise.Checked = false;
                //chkDateTimeWise.Checked = false;
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;
                chkPostCode.Visible = false;
                chkZones.Visible = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = false;
                txtNoofDays.Visible = false;
                lblnoofDays.Visible = false;
                //chkAppUsers.Checked = false;

                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;

                lblNoofBooking.Visible = true;
                txtNoofBooking.Visible = true;

                txtNoofDays.Text = string.Empty;
                txtPostCode.Text = string.Empty;


            }
            else
            {
                lblNoofBooking.Visible = false;
                txtNoofBooking.Visible = false;
            }
        }

        private void chkDateTimeWise_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkDateTimeWise.IsChecked == true)
            {
                chkPostCode.Visible = false;
                chkZones.Visible = false;

                txtPostCode.Visible = false;
                ddlZones.Visible = false;
                txtNoofBooking.Visible = false;
                txtNoofDays.Visible = false;

                lblnoofDays.Visible = false;
                lblNoofBooking.Visible = false;

                //chkAll.Checked = false;
                //chkAreaWise.Checked = false;
                //chkBookingWise.Checked = false;
                //chkDateWise.Checked = false;
                chkNotInPeriod.Checked = false;
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                //chkAppUsers.Checked = false;

                lblFromDate.Visible = true;
                lblToDate.Visible = true;
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true;
                chkPeriod.Visible = true;
                chkNotInPeriod.Visible = true;
                chkPeriod.Checked = true;


                txtNoofDays.Text = string.Empty;
                txtPostCode.Text = string.Empty;
                txtNoofBooking.Text = string.Empty;

            }
            else
            {

                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;


                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;

            }
        }

        private void chkAppUsers_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAppUsers.IsChecked == true)
            {
                //chkAll.IsChecked = false;
                //chkAreaWise.Checked = false;
                //chkDateWise.Checked = false;
                chkInclude.Visible = false;
                chkNotInclude.Visible = false;
                chkPeriod.Visible = false;
                chkNotInPeriod.Visible = false;
                chkPostCode.Visible = false;
                chkZones.Visible = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = false;
                txtNoofDays.Visible = false;
                lblnoofDays.Visible = false;
                chkPeriod.Checked = false;
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;
                chkNotInPeriod.Checked = false;

                lblNoofBooking.Visible = false;
                txtNoofBooking.Visible = false;

                txtNoofBooking.Text = string.Empty;
                txtNoofDays.Text = string.Empty;
                txtPostCode.Text = string.Empty;

            }
        }


        private void chkInclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkInclude.Checked == true)
            {
                chkNotInclude.Checked = false;
            }
            else
            {
                chkNotInclude.Checked = true;
            }
        }

        private void chkNotInclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkNotInclude.Checked == true)
            {
                chkInclude.Checked = false;
            }
            else
            {
                chkInclude.Checked = true;
            }
        }

        private void chkPeriod_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkPeriod.Checked == true)
            {
                chkNotInPeriod.Checked = false;
                lblFromDate.Visible = true;
                lblToDate.Visible = true;
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true;
            }
        }

        private void chkNotInPeriod_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkNotInPeriod.Checked == true)
            {
                chkPeriod.Checked = false;
                lblFromDate.Visible = true;
                lblToDate.Visible = true;
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true;

            }
        }

        private void chkZones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZones.Checked == true)
            {
                chkPostCode.Checked = false;
                txtPostCode.Visible = false;
                ddlZones.Visible = true;
                txtPostCode.Text = string.Empty;
            }
        }

        private void chkPostCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPostCode.Checked == true)
            {
                chkZones.Checked = false;
                txtPostCode.Visible = true;
                ddlZones.Visible = false;
            }
        }

      


      

      

      
    
    }


}
class CurrentCustomer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MobileNo { get; set; }
    public int BookingStatusId { get; set; }
    //BookingStatusId
}