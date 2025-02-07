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
    public partial class frmWhiteListAddressList : UI.SetupBase
    {
        WhiteListAddressBO objMaster;
        public frmWhiteListAddressList()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmLocationList_Load);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new WhiteListAddressBO();

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
      

        private void AddCommandColumn()
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 100;

            col.UseDefaultText = true;
            col.DefaultText = "Edit";
            col.Name = "btnEdit";
            grdLister.Columns.Add(col);



            col = new GridViewCommandColumn();
            col.Width = 100;

            col.UseDefaultText = true;
            col.DefaultText = "Delete";
            col.Name = "btnDelete";
            grdLister.Columns.Add(col);

        }
        void frmLocationList_Shown(object sender, EventArgs e)
        {

            //grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;


            LoadZonesList();

            AddCommandColumn();
         
            grdLister.Columns["Id"].IsVisible = false;
           
            grdLister.Columns["Address"].Width = 300;

            grdLister.Columns["AddBy"].Width = 100;
            grdLister.Columns["AddOn"].Width = 140;
            grdLister.Columns["AddBy"].HeaderText = "Add By";
            grdLister.Columns["AddOn"].HeaderText = "Add On";
            (grdLister.Columns["AddOn"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
            (grdLister.Columns["AddOn"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";
            grdLister.Columns["Notes"].Width = 300;

           

            UI.GridFunctions.SetFilter(grdLister);




        }


        private void LoadZonesList()
        {


           



            var query = (from a in General.GetQueryable<WhiteListAddress>(null)
                         select new
                         {
                             a.Id,
                             a.Address,
                             a.Notes,
                             AddBy=a.AddLog,
                             AddOn=a.AddOn
                         }).ToList(); ;



            grdLister.DataSource = query.ToList();
            // this.SetRefreshingProperties(AppVars.BLData.GetCommand(query), grdLister, false);



        }

        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name.ToLower() == "btndelete")
            {



                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Address ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
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


            frmAddNewWhiteListAddress frm = new frmAddNewWhiteListAddress();
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

                objMaster = new WhiteListAddressBO();

                try
                {

                    objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());

                    if (objMaster.Current != null)
                    {
                        int id = objMaster.Current.Id;
                        // string zoneName = objMaster.Current.ZoneName;
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
            frmAddNewWhiteListAddress frm = new frmAddNewWhiteListAddress();
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




    }
}

