using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi_AppMain.Classes;
using Taxi_Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmAutoDispatchSettings : UI.SetupBase
    {
        public frmAutoDispatchSettings()
        {
            InitializeComponent();
            LoadGrid();
            //btnAdd.Click += BtnAdd_Click;
           // ComboFunctions.FillBookingTypesCombo(ddlBookingType);
            grdLister.CommandCellClick += grid_CommandCellClick;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //GridViewRowInfo row = null;
                //var list = grdLister.Rows.Where(c => c.Cells[COLS_.BookingType].Value.ToString() == ddlBookingType.Text).Count();

                //if (list == 0)
                //{
                //    row = grdLister.Rows.AddNew();
                //    row.Cells[COLS_.BookingType].Value = ddlBookingType.Text;
                //    row.Cells[COLS_.Radius].Value = numRadius.Value;
                //}
                
                
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

              
                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.Name = COLS_.Id;
                col.ReadOnly = true;
                col.IsVisible = false;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.Name = COLS_.BookingType;
                col.ReadOnly = true;
                col.HeaderText = "Booking Type";
                col.Width = 100;
                grdLister.Columns.Add(col);


              

                GridViewDecimalColumn  cold = new GridViewDecimalColumn();
                cold.Name = COLS_.Radius;
                cold.ReadOnly = false;
                cold.HeaderText = "Radius";
                cold.DecimalPlaces = 2;
                cold.TextAlignment = ContentAlignment.MiddleRight;
                cold.Width = 100;
                grdLister.Columns.Add(cold);

                grdLister.AddDeleteColumn();
                grdLister.Columns["btnDelete"].Width = 70;

                UI.GridFunctions.SetFilter(grdLister);                          

                grdLister.AllowEditRow = true;
                grdLister.AllowAutoSizeColumns = true;
                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdLister.ShowGroupPanel = false;
                grdLister.ShowFilteringRow = false;

                grdLister.ShowRowHeaderColumn = false;

                grdLister.CurrentRow = null;

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var result = db.ExecuteQuery<ClsBookingTypes>(@"exec stp_GetBookingTypes").ToList();

                    GridViewRowInfo row = null;
                   
                    if (result.Count > 0)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            row = grdLister.Rows.AddNew();
                            row.Cells[COLS_.Id].Value = result[i].Id;
                            row.Cells[COLS_.BookingType].Value = result[i].BookingTypeName;
                           // row.Cells[COLS_.Radius].Value = numRadius.Value;
                        }
                        
                    }
                    else
                    {
                        lblHeadingNearest.Visible = false;
                        grdLister.Visible = false;


                    }

                }


            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
            }

        }

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {
                
                    RadGridView grid = gridCell.GridControl;
                    grid.CurrentRow.Delete();                
            }

        }


        public struct COLS_
        {
            public static string Id = "Id";
            public static string BookingType = "BookingType";
            public static string BookingTypeId = "BookingTypeId";
            public static string Radius = "Radius";
          
        }

        public void PopulateDataMode()
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var result = db.ExecuteQuery<Mode>(@"exec stp_ModeList").ToList();
                    ddlMode.DataSource = result;

                }
            }
            catch (Exception ex) 
            {
            
            }
        }

        private void frmAutoDispatchSettings_Load(object sender, EventArgs e)
        {
            lblRadious.Visible = false;
            NearestDriverRadious.Value = 0;
            NearestDriverRadious.Visible = false;

            int selectedMode = 0;
            using (TaxiDataContext db = new TaxiDataContext())
            {
                selectedMode = db.ExecuteQuery<int>("select AutoDespatchDriverCategoryPriority from gen_syspolicy_configurations").FirstOrDefault();
            }
            if (selectedMode > 0)
            {
                ddlMode.SelectedValue = selectedMode;
                if (selectedMode == 1)
                {
                    ddlMode.SelectedIndex = 0;
                }
                if (selectedMode == 2)
                {
                    ddlMode.SelectedIndex = 1;
                }
                if (selectedMode == 3)
                {
                    ddlMode.SelectedIndex = 2;
                }
            }
        }

        

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        int modeid = 0;
        int id = 0;
       
        private void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    //numRadius.Value = 0.00m;
                    //ddlBookingType.SelectedIndex = -1;

                    string modetype = ddlMode.Text;
                   
                    if (modetype=="Normal")
                    {
                        modeid = 1;

                    }

                    if (modetype == "Quite")
                    {
                        modeid = 2;

                    }
                    if (modetype == "Busy")
                    {
                        modeid = 3;

                    }

                     var AutoDispatchSetting = db.ExecuteQuery<AutoDispatchSetting>("SELECT * FROM autodispatchsettings where autodispatchmodetype=" + modeid).FirstOrDefault();

                    if (AutoDispatchSetting != null)
                    {
                      
                        lblRadious.Visible = true;
                        id = AutoDispatchSetting.Id;
                        
                        chkAutoAllocateSTC.Checked = AutoDispatchSetting.AutoAllocateSTC.ToBool();
                        chkTopstdJobPlot.Checked = AutoDispatchSetting.TopStandingInQueue.ToBool();
                        chkTopstdJobBackPlot.Checked = AutoDispatchSetting.TopStandingInQueueBackupPlot.ToBool();
                        chkNearestDriver.Checked = AutoDispatchSetting.NearestDriver.ToBool();
                        NearestDriverRadious.Value = AutoDispatchSetting.NearestDriverRadius.ToDecimal();
                        chkbinding.Checked = AutoDispatchSetting.EnableBid.ToBool();
                        if (chkNearestDriver.Checked)
                        {
                            NearestDriverRadious.Visible = true;
                            lblRadious.Visible = true;
                        }
                        else
                        {
                            NearestDriverRadious.Visible = false;
                            lblRadious.Visible = false;
                        }

                        if (AutoDispatchSetting.OtherData.ToStr().Trim().Length>0)
                        {
                            var list = JsonConvert.DeserializeObject<List<ClsAutoDespatch>>(AutoDispatchSetting.OtherData);              

                            for (int i = 0; i < grdLister.Rows.Count; i++)
                            {
                                //  grdLister.Rows.AddNew();

                                var data=  list.FirstOrDefault(c => c.BookingType == grdLister.Rows[i].Cells[COLS_.Id].Value.ToInt());
                              
                                if(data!=null)
                                        grdLister.Rows[i].Cells[COLS_.Radius].Value = data.Radius.ToDecimal();
                                  
                                    
                               
                           
                            }

                        }
                        else
                        {
                            grdLister.Rows.ToList().ForEach(c => c.Cells[COLS_.Radius].Value = 0);
                        }
                    }
                    else 
                    {
                        chkAutoAllocateSTC.Checked = false;
                        chkTopstdJobPlot.Checked = false;
                        chkTopstdJobBackPlot.Checked = false;
                        chkNearestDriver.Checked = false;
                        NearestDriverRadious.Value = 0.00m;
                        chkbinding.Checked = false;
                        if (chkNearestDriver.Checked)
                        {
                            NearestDriverRadious.Visible = true;
                            lblRadious.Visible = true;
                        }
                        else
                        {
                            NearestDriverRadious.Visible = false;
                            lblRadious.Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }


        }

        private void btnUpdateSettings_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    List<ClsAutoDespatch> obj = new List<ClsAutoDespatch>();
                    string JSONString = string.Empty;

                    if (grdLister.RowCount > 0)
                    {
                        for (int i = 0; i < grdLister.RowCount; i++)
                        {
                            if (grdLister.Rows[i].Cells[COLS_.Radius].Value.ToDecimal() > 0)
                            {
                                ClsAutoDespatch o = new ClsAutoDespatch();
                                o.BookingType = grdLister.Rows[i].Cells[COLS_.Id].Value.ToInt();
                                o.Radius = grdLister.Rows[i].Cells[COLS_.Radius].Value.ToDecimal();
                                obj.Add(o);
                            }
                        }

                        if(obj.Count>0)
                        JSONString = JsonConvert.SerializeObject(obj);
                    }
                   
                   var result = db.ExecuteQuery<AutoDispatchSetting>(@"exec stp_InsertAutoDispatchSettings {0},{1},{2},{3},{4},{5},{6},{7},{8}",
                            id,
                            modeid,
                            chkTopstdJobPlot.Checked,
                            chkTopstdJobBackPlot.Checked,
                            chkNearestDriver.Checked,
                            Convert.ToDecimal(NearestDriverRadious.Value),
                            chkAutoAllocateSTC.Checked,
                            chkbinding.Checked,
                            JSONString
                            );


                  
                    
                }


                int mode = ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard")).selectedAutoMode;

                General.UpdateAutoDispatchMode(mode, "modify|");

                ENUtils.ShowMessage("Saved Successfully!");

            }
            catch (Exception ex)
            {

            }

        }

        private void chkNearestDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNearestDriver.Checked)
            {
                NearestDriverRadious.Visible = true;
                lblRadious.Visible = true;
            }
            else
            {
                NearestDriverRadious.Visible = false;
                lblRadious.Visible = false;
            }


        }

        private void pnlSettings_Enter(object sender, EventArgs e)
        {

        }
    }
}


public class ClsAutoDespatch
{
    public int BookingType;
    public decimal? Radius;
    public string OtherData;
}


public class ClsBookingTypes
{
    public int Id;
    public string BookingTypeName;

}
