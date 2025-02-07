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

namespace Taxi_AppMain
{


    public partial class frmVehicleTypeList : UI.SetupBase
    {
        VehicleTypeBO objMaster;


        public frmVehicleTypeList()
        {
            InitializeComponent();

            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new VehicleTypeBO();

            this.SetProperties((INavigation)objMaster);

            grdLister.ShowRowHeaderColumn = false;
            this.Shown += new EventHandler(frmVehicleTypeList_Shown);


            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;
            grdLister.ShowRowHeaderColumn = false;


            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);


            if (AppVars.AppTheme != "ControlDefault")
            {
                grdLister.ForeColor = Color.White;

            }
            else
                grdLister.ViewCellFormatting += MyGridView_ViewCellFormatting;
        }

        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);

        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);


        private Color _HeaderRowBackColor = Color.SteelBlue;

        public Color HeaderRowBackColor
        {
            get { return _HeaderRowBackColor; }
            set { _HeaderRowBackColor = value; }
        }


        private Color _HeaderRowBorderColor = Color.DarkSlateBlue;

        public Color HeaderRowBorderColor
        {
            get { return _HeaderRowBorderColor; }
            set { _HeaderRowBorderColor = value; }
        }

        private bool _ShowImageOnActionButton = true;

        public bool ShowImageOnActionButton
        {
            get { return _ShowImageOnActionButton; }
            set { _ShowImageOnActionButton = value; }
        }
        RadButtonElement button = null;
        void MyGridView_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {

            if (e.CellElement is GridHeaderCellElement)
            {
                //    e.CellElement
                e.CellElement.BorderColor = _HeaderRowBorderColor;
                e.CellElement.BorderColor2 = _HeaderRowBorderColor;
                e.CellElement.BorderColor3 = _HeaderRowBorderColor;
                e.CellElement.BorderColor4 = _HeaderRowBorderColor;


                // e.CellElement.DrawBorder = false;
                e.CellElement.BackColor = _HeaderRowBackColor;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.Font = newFont;
                e.CellElement.ForeColor = Color.White;
                e.CellElement.DrawFill = true;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

            }

            else if (e.CellElement is GridDataCellElement)
            {
                if (ShowImageOnActionButton && e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    // This is how we get the RadButtonElement instance from the cell
                    button = (RadButtonElement)e.CellElement.Children[0];


                    if (button.Text == "Edit")
                    {
                        // button.Image = Resource1.edit2;
                    }
                    else if (button.Text == "Delete")
                    {

                        // button.Image =  Resource1.delete;
                    }
                }

                e.CellElement.ToolTipText = e.CellElement.Text;

                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                e.CellElement.ForeColor = Color.Black;

                e.CellElement.Font = oldFont;

                if (e.CellElement.RowElement.IsSelected == true)
                {

                    e.CellElement.RowElement.NumberOfColors = 1;
                    e.CellElement.RowElement.BackColor = Color.DeepSkyBlue;

                    //   e.CellElement.RowElement.ForeColor = Color.White;


                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color.DeepSkyBlue;

                    e.CellElement.ForeColor = Color.White;

                    e.CellElement.Font = newFont;


                }

                else
                {
                    e.CellElement.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.All);

                }

            }


        }


        private void LoadVehicleTypeList()
        {


            using (TaxiDataContext db = new TaxiDataContext())
            {

                var list1 = db.Fleet_VehicleTypes.Select(args => new { args.Id, args.VehicleType, args.NoofPassengers, args.NoofLuggages, args.AttributeValues, args.OrderNo }).ToList();

                var query = (from a in list1
                             orderby a.OrderNo

                             select new
                             {
                                 Id = a.Id,
                                 Vehicle = a.VehicleType,
                                 Passengers = a.NoofPassengers,
                                 Luggages = a.NoofLuggages,
                                 //   HandLuggages = a.NoofHandLuggages,
                                 Attributes = a.AttributeValues != null && a.AttributeValues != "" ? string.Join(",", list1.Where(c => a.AttributeValues.Contains("," + c.Id + ",")).Select(c => c.VehicleType).ToArray<string>()) : ""
                                 // StartRateUpToMiles = a.StartRateValidMiles,

                             });




                grdLister.DataSource = query.ToList();
            }

        }




        void frmVehicleTypeList_Shown(object sender, EventArgs e)
        {
            try
            {
                this.InitializeForm("frmVehicleType");
            }
            catch
            {


            }

            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            grdLister.AllowAutoSizeColumns = true;

            LoadVehicleTypeList();

            AddColumn("btnEdit", "Edit");

            //if (this.CanDelete)
            //{
            AddColumn("btnDelete", "Delete");

            grdLister.Columns["btnDelete"].Width = 80;

            //}


            UI.GridFunctions.SetFilter(grdLister);

            grdLister.Columns["btnEdit"].Width = 80;


            //  grdLister.Columns["StartRateUpToMiles"].HeaderText = "No of Miles for Start Rate";


            grdLister.Columns["Id"].IsVisible = false;


            grdLister.Columns["Attributes"].Width = 500;









        }


        public void AddColumn(string name, string text)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();


            col.Name = name;
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = text;
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grdLister.Columns.Add(col);




        }



        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ViewDetailForm();
        }

        private void ViewDetailForm()
        {

            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {
                ShowVehicleForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
            }
        }


        private void ShowVehicleForm(int id)
        {


            frmVehicleType frm = new frmVehicleType();
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


                objMaster = new VehicleTypeBO();

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


        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            RadGridView grid = gridCell.GridControl;
            if (gridCell.ColumnInfo.Name == "btnDelete")
            {

                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Vehicle ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {
                    grid.CurrentRow.Delete();
                }
            }
            else if (gridCell.ColumnInfo.Name == "ColEdit")
            {
                ViewDetailForm();


            }

        }





        public override void RefreshData()
        {
            PopulateData();
        }



        public override void PopulateData()
        {

            LoadVehicleTypeList();

        }

        private void btnVehicleOrder_Click(object sender, EventArgs e)
        {
            frmVehicleOrder frmvehicle = new frmVehicleOrder();
            frmvehicle.Show();
        }








    }
}

