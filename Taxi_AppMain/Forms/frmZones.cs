using System;

using System.Windows.Forms;

using Taxi_BLL;
using DAL;
using Utils;
using Telerik.WinControls.UI;
using Taxi_Model;
using System.Data.Linq;
using System.Linq;

namespace Taxi_AppMain
{
    public partial class frmZones : UI.SetupBase
    {
        public struct COLS
        {
            public static string Id = "Id";
            public static string MasterId = "MasterId";
            public static string Area = "Area";

            public static string PostCode = "PostCode";



        }


        ZoneBO objMaster;
        public frmZones()
        {
            InitializeComponent();
         
            objMaster = new ZoneBO();
            this.SetProperties((INavigation)objMaster);
        
            this.FormClosing += new FormClosingEventHandler(frmZones_FormClosing);
      
           this.Shown += new EventHandler(frmZones_Shown);


           ComboFunctions.FillZoneTypes(ddlType);

            RadListDataItem item = new RadListDataItem();
            item.Text = "Inner";
            item.Value = 1;


            ddlKind.Items.Add(item);

            item = new RadListDataItem();
            item.Text = "Outer";
            item.Value = 2;
            item.Selected = true;
            ddlKind.Items.Add(item);

        }

        void frmZones_FormClosing(object sender, FormClosingEventArgs e)
        {
            General.RefreshListWithoutSelected<frmZonesList>("frmZonesList1");
        }

        void frmZones_Shown(object sender, EventArgs e)
        {
            txtZoneName.Focus();


            try
            {

                FormatDriverAttributesGrid();
                LoadVehicleAttributesGrid();
                //S,BC,SALO 
                if (objMaster.Current != null && objMaster.Current.Id > 0)
                {
                    string[] attributeValuesArr = objMaster.Current.Description.ToStr().Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in attributeValuesArr)
                    {
                        var attrRow = grdDriverAttributes.Rows.FirstOrDefault(c => c.Cells[Col_DriverAttributes.ShortName].Value.ToStr().ToLower().Trim() == item.ToLower().Trim());

                        if (attrRow != null)
                        {
                            attrRow.Cells[Col_DriverAttributes.Default].Value = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void FormatDriverAttributesGrid()
        {


            grdDriverAttributes.AllowAddNewRow = false;
            //   grdDetails.AllowEditRow = false;
            //grdVehicleAttributes.AutoCellFormatting = true;
            grdDriverAttributes.ShowGroupPanel = false;

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = Col_DriverAttributes.Id;
            col.IsVisible = false;
            grdDriverAttributes.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_DriverAttributes.DetailId;
            col.IsVisible = false;
            grdDriverAttributes.Columns.Add(col);


            GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
            col1.HeaderText = "Default";
            col1.Name = Col_DriverAttributes.Default;
            col1.HeaderText = "";
            col1.Width = 60;
            //col1.ReadOnly = true;
            grdDriverAttributes.Columns.Add(col1);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "ShortName";
            col.Name = Col_DriverAttributes.ShortName;
            col.IsVisible = false;

            // col.ReadOnly = true;
            grdDriverAttributes.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Name";
            col.Name = Col_DriverAttributes.Name;
            col.Width = 180;
            // col.ReadOnly = true;
            grdDriverAttributes.Columns.Add(col);




            grdDriverAttributes.MasterTemplate.ShowRowHeaderColumn = false;

            UI.GridFunctions.SetFilter(grdDriverAttributes);

            grdDriverAttributes.AllowEditRow = true;

            //DetailGridButton();

        }


        private void LoadVehicleAttributesGrid()
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var list = db.Gen_Attributes.Where(c => (c.AttributeCategoryId == null || c.AttributeCategoryId == 1)).OrderBy(c => c.Name).ToList();

                    foreach (var item in list)
                    {


                        var row = grdDriverAttributes.Rows.AddNew();


                        row.Cells[Col_DriverAttributes.Id].Value = item.Id;
                        row.Cells[Col_DriverAttributes.Default].Value = item.IsDefault;
                        row.Cells[Col_DriverAttributes.Name].Value = item.Name + "[" + item.ShortName + "]";
                        row.Cells[Col_DriverAttributes.ShortName].Value = item.ShortName;
                    }


                }

            }

            catch (Exception ex)
            {

            }
        }

        public struct Col_DriverAttributes
        {
            public static string Id = "Id";
            public static string DetailId = "DetailId";


            public static string Name = "Name";
            public static string ShortName = "ShortName";
            public static string Default = "Default";
        }




        #region Overridden Methods




        public override void DisplayRecord()
        {
            if (objMaster.Current == null) return;

            txtZoneName.Text = objMaster.Current.ZoneName;
           // txtDescription.Text = objMaster.Current.Description;
            txtShortName.Text = objMaster.Current.ShortName.ToStr();
            ddlType.SelectedValue = objMaster.Current.ZoneTypeId;
            chkBase.Checked = objMaster.Current.IsBase.ToBool();
          
            ddlKind.SelectedValue = objMaster.Current.PlotKind;

           chkPrice.Checked = objMaster.Current.DisableDriverRank.ToBool();
            chkEnableAuto.Checked= objMaster.Current.EnableAutoDespatch.ToBool();
            chkEnableBidding.Checked= objMaster.Current.EnableBidding.ToBool();
            chkOutofTown.Checked= objMaster.Current.BlockDropOff.ToBool();


            numPriority.Value = objMaster.Current.Priority.ToInt();
            numPreBookPriority.Value = objMaster.Current.PreBookPriority.ToInt();
        }




        public override void Save()
        {
        

            try
            {
       


                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                }
                else
                {
                    objMaster.Edit();
                }

                objMaster.Current.ZoneName = txtZoneName.Text.Trim();
               

                objMaster.Current.IsBase = chkBase.Checked;
               
                objMaster.Current.ShortName = txtShortName.Text.Trim();
                objMaster.Current.ZoneTypeId = ddlType.SelectedValue.ToIntorNull();

                objMaster.Current.PlotKind = ddlKind.SelectedValue.ToIntorNull();

                objMaster.Current.DisableDriverRank = chkPrice.Checked;
                objMaster.Current.EnableAutoDespatch = chkEnableAuto.Checked;
                objMaster.Current.EnableBidding = chkEnableBidding.Checked;
                objMaster.Current.BlockDropOff = chkOutofTown.Checked;
                objMaster.Current.Priority = numPriority.Value.ToInt();
                objMaster.Current.PreBookPriority = numPreBookPriority.Value.ToInt();


                if (grdDriverAttributes != null)
                {

                    try
                    {
                        objMaster.Current.Description = string.Join(",", grdDriverAttributes.Rows.Where(c => c.Cells[Col_DriverAttributes.Default].Value.ToBool() == true).Select(c => c.Cells[Col_DriverAttributes.ShortName].Value.ToStr()).ToArray<string>());

                        if (objMaster.Current.Description.ToStr().Trim().Length > 0)
                        {

                            objMaster.Current.Description = "," + objMaster.Current.Description.ToStr() + ",";
                        }

                    }
                    catch
                    {

                    }



                }


                objMaster.Save();

                General.LoadZoneList();

         
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

        

        public override void  AddNew()
        {
         	 OnNew();
        }

        public override void  OnNew()
        {
 	     
            txtZoneName.Focus();
            chkOutofTown.Checked = false;

            chkPrice.Checked = false;
            txtShortName.Text = string.Empty;
            txtZoneName.Text = string.Empty;

        }

        #endregion

   

     
        private void frmZones_FormClosed(object sender, FormClosedEventArgs e)
        {
         

            General.DisposeForm(this);
        }

      
      
        
    }



}
