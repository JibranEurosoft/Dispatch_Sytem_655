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
using Taxi_AppMain.Classes;


namespace Taxi_AppMain
{
    public partial class frmZonesList  : UI.SetupBase
    {
         ZoneBO objMaster;



         public frmZonesList()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmLocationList_Load);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
             grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
             objMaster = new ZoneBO();
           
            this.SetProperties((INavigation)objMaster);

            grdLister.ShowRowHeaderColumn = false;
            this.Shown += new EventHandler(frmLocationList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            grdLister.CellFormatting += new CellFormattingEventHandler(grdLister_CellFormatting);

        }

         Font f = new Font("Tahoma", 10, FontStyle.Bold);

         void grdLister_CellFormatting(object sender, CellFormattingEventArgs e)
         {
             try
             {

                 if (e.Column != null && e.Row != null && e.Row.Cells["Id"].Value != null)
                 {
                     if (e.Column.Name == "ZoneName" && e.Row.Cells["IsBase"].Value.ToBool())
                     {
                         e.CellElement.Font = f;
                         e.CellElement.RowElement.BackColor = Color.LightYellow;
                         e.CellElement.RowElement.NumberOfColors = 1;

                     }
                 }
             }
             catch
             {


             }

         }

         void frmLocationList_Shown(object sender, EventArgs e)
         {

             grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;


             try
             {

                 this.InitializeForm("frmZones");

             }
             catch
             {


             }
           
             LoadZonesList();

            grdLister.AddEditColumn();

             if (this.CanDelete)
             {
                 grdLister.AddDeleteColumn();
                 grdLister.Columns["btnDelete"].Width = 70;
             }


             grdLister.Columns["Id"].IsVisible = false;
             grdLister.Columns["IsBase"].IsVisible = false;

             grdLister.Columns["ZoneName"].HeaderText = "Zone Name";
             grdLister.Columns["ZoneName"].Width = 270;

            grdLister.Columns["ShortName"].HeaderText = "Short Name";
            grdLister.Columns["ShortName"].Width = 270;

            grdLister.Columns["outoftown"].HeaderText = "Out Of Town";
            grdLister.Columns["AutoDespatch"].HeaderText = "Auto Despatch";
            grdLister.Columns["JobDue"].HeaderText = "Job Due";
            ( grdLister.Columns["JobDue"] as GridViewDateTimeColumn).CustomFormat = "HH:mm";
            (grdLister.Columns["JobDue"] as GridViewDateTimeColumn).FormatString = "{0:HH:mm}";

            // grdLister.Columns["PostCodes"].Width = 500;

            grdLister.Columns["btnEdit"].Width = 70;

             grdLister.Columns["Sno"].Width = 40;


             UI.GridFunctions.SetFilter(grdLister);


           

         }

         private void LoadZonesList()
         {

            int position = grdLister.TableElement.VScrollBar.Value;
            long RowIndex = grdLister.CurrentRow != null ? grdLister.CurrentRow.Cells["Id"].Value.ToLong() : -1;
            if (chkOutOfTown.Checked == true)
            {
                var data1 = General.GetQueryable<Gen_Zone>(c => c.ZoneName != "SIN BIN" && c.OrderNo != null && c.ZoneName != "OnBreak" &&  (c.BlockDropOff!=null && c.BlockDropOff == true)).OrderBy(c => c.OrderNo).AsEnumerable();
                var ad = grdLister.Rows.Where(c => c.Cells[""].Value.ToBool() == true);

                var query = (from a in data1


                             select new
                             {
                                 Id = a.Id,
                                 Sno = a.OrderNo,
                                 ZoneName = a.ZoneName,
                                 // PostCodes = a.PostCode,
                                 ShortName = a.ShortName,
                                 JobDue = ((a.JobDueTime != null) ? a.JobDueTime : Convert.ToDateTime("00:00")),
                                 outoftown = ((a.BlockDropOff != null && a.BlockDropOff ==true) ? "Yes" : "No"),
                                 AutoDespatch = ((a.EnableAutoDespatch != false && a.EnableAutoDespatch != null) ? "Yes" : "No"),
                                 Bidding = ((a.BiddingRadius != 0 && a.BiddingRadius != null) ? "Yes" : "No"),
                                 IsBase = a.IsBase

                             }).ToList();

                grdLister.DataSource = query;
            }
            else
            {
                var data1 = General.GetQueryable<Gen_Zone>(c => c.ZoneName != "SIN BIN" && c.OrderNo != null && c.ZoneName != "OnBreak").OrderBy(c => c.OrderNo).AsEnumerable();


                var query = (from a in data1



                             select new
                             {
                                 Id = a.Id,
                                 Sno = a.OrderNo,
                                 ZoneName = a.ZoneName,
                                 // PostCodes = a.PostCode,
                                 ShortName = a.ShortName,
                                 JobDue = ((a.JobDueTime != null) ? a.JobDueTime : Convert.ToDateTime("00:00")),
                                 outoftown = ((a.BlockDropOff != null && a.BlockDropOff == true) ? "Yes" : "No"),
                                 AutoDespatch = ((a.EnableAutoDespatch != false && a.EnableAutoDespatch != null) ? "Yes" : "No"),
                                 Bidding = ((a.BiddingRadius != 0 && a.BiddingRadius != null) ? "Yes" : "No"),
                                 IsBase = a.IsBase

                             }).ToList();

                grdLister.DataSource = query;

            }

            if (grdLister.TableElement.VScrollBar.Maximum >= position)
            {
                grdLister.TableElement.VScrollBar.Value = position;
            }
            if (RowIndex > 0)
            {
                grdLister.CurrentRow = grdLister.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == RowIndex);
            }

            // this.SetRefreshingProperties(AppVars.BLData.GetCommand(query), grdLister, false);

            lblTotalRecords.Text = "Total Record(s) :" + grdLister.Rows.Count;

        }

        private void grid_CommandCellClick(object sender, EventArgs e)
         {
             GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            //if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            //{
            //   if (AppVars.listUserRights.Count(c => c.functionId == "DELETE ALL ZONES") > 0)
            //   {
            //       using (TaxiDataContext db = new TaxiDataContext())
            //        {                
            //           //if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Zone ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
            //           //{
            //           //    int Del = db.ExecuteQuery<int>("exec stp_DeleteZones {0}", grdLister.CurrentRow.Cells["Id"].Value.ToInt()).ToInt();

            //           //    RadGridView grid = gridCell.GridControl;
            //           //    grid.CurrentRow.Delete();

            //           //}
            //           07886024134
            //       }

            //   }

            //}
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Zone ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
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
                 ShowZoneForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
             }
             else
             {
                 ENUtils.ShowMessage("Please select a record");
             }
         }


         private void ShowZoneForm(int id)
         {


             frmZones frm = new frmZones();
            frm.OnDisplayRecord(id);

            frm.ControlBox = true;
            frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm.MaximizeBox = false;
            frm.ShowDialog();     

         }


         void Grid_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
         {
             if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
             {

                objMaster = new ZoneBO();

                try
                {

                    objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());

                    if (objMaster.Current != null)
                    {
                        int id = objMaster.Current.Id;
                        string zoneName = objMaster.Current.ZoneName;
                        objMaster.Delete(objMaster.Current);
                        
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
                    e.Cancel = true;

                }

            }
         }



        

       

        public override void RefreshData()
        {
            PopulateData();
        }

       

        public override void PopulateData()
        {

            LoadZonesList();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAddZone_Click(object sender, EventArgs e)
        {
            ShowZoneForm();
        }

        private void ShowZoneForm()
        {
            frmZones frm = new frmZones();
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.MaximizeBox = false;
            frm.ControlBox = true;
            frm.ShowIcon = false;
            frm.ShowDialog();
        }

        private void btnDrawPlot_Click(object sender, EventArgs e)
        {
          //  General.ShowDrawZoneForm(0);
        }

        private void btnDrawEditZone_Click(object sender, EventArgs e)
        {
            //if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            //{

            //    General.ShowDrawZoneForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
            //}
        }

        private void chkOutOfTown_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            LoadZonesList();     

        }
    }
}

