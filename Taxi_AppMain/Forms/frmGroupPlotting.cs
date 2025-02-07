using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using UI;
using Taxi_BLL;

using Taxi_Model;
using Telerik.WinControls;
using Utils;
using Telerik.WinControls.UI;

namespace Taxi_AppMain
{
    public partial class frmGroupPlotting : SetupBase
    {
        public struct COLS_GROUP
        {
            public static string Id = "Id";
            public static string GroupName = "GroupName";
            public static string ShortName = "ShortName";
            public static string Plots = "Plots";
    


        }

        GroupPlottingBO objMaster;

        public frmGroupPlotting()
        {
            InitializeComponent();
            objMaster=new GroupPlottingBO();
            objMaster.SearchConditions = c => c.Id > 0;
            grdGroupPlotting.MasterTemplate.ShowRowHeaderColumn = false;

            this.SetProperties((INavigation)objMaster);


            grdGroupPlotting.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdGroupPlotting.AllowAddNewRow = false;
            grdGroupPlotting.ShowRowHeaderColumn = false;
            grdGroupPlotting.ShowGroupPanel = false;


            grdGroupPlotting.TableElement.AlternatingRowColor = Color.AliceBlue;

            FillCombos();
            FormatZonesGrid();
            FormatGroupGrid();
            grdGroupPlotting.RowsChanging += new GridViewCollectionChangingEventHandler(grdUsers_RowsChanging);
            grdGroupPlotting.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
           
            OnNew();
        }

       


        private void AddCommandColumn(string name, string headerText, int width)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = width;

            col.UseDefaultText = true;
            col.DefaultText = headerText;
            col.Name = name;
            grdGroupPlotting.Columns.Add(col);

        }
        public struct COLS
        {
            public static string Id = "Id";
            public static string ZoneId = "ZoneId";
            public static string Check = "Check";
            public static string Plots = "Plots";
        }
        public void FormatZonesGrid()
        {


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS.Id;
            col.IsVisible = false;
            //col.ReadOnly = false;
            grdZonesList.Columns.Add(col);

            GridViewCheckBoxColumn cbcol = new GridViewCheckBoxColumn();
            cbcol.Name = COLS.Check;
            cbcol.Width = 80;
            cbcol.ReadOnly = false;
            grdZonesList.Columns.Add(cbcol);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.ZoneId;
            col.IsVisible = false;
            grdZonesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS.Plots;
            col.HeaderText = "Plots";
            col.ReadOnly = true;
            col.Width = 400;
            grdZonesList.Columns.Add(col);

            grdZonesList.EnableFiltering = true;
            grdZonesList.AllowAddNewRow = false;
            grdZonesList.ShowGroupPanel = false;
        }

        public void FormatGroupGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = COLS_GROUP.Id;
            col.IsVisible = false;
            //col.ReadOnly = false;
            grdGroupPlotting.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = COLS_GROUP.GroupName;
            col.HeaderText = "Group Name";
            col.Width = 80;
            grdGroupPlotting.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_GROUP.ShortName;
            col.HeaderText = "Short Name";
            col.Width = 80;
            grdGroupPlotting.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.Name = COLS_GROUP.Plots;
            col.HeaderText = "Plots";
            col.Width = 290;
            grdGroupPlotting.Columns.Add(col);       

        }

        private void LoadGroupGrid()
        {

            GridViewRowInfo row = null;
            grdGroupPlotting.Rows.Clear();
            foreach (var item in General.GetQueryable<Gen_ZoneGroup>(null))
            {
                var list = General.GetQueryable<Gen_ZoneGroup_Detail>(c => c.ZoneGroupId == item.Id).ToList();
                string val = string.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    val += string.Join(",", General.GetQueryable<Gen_Zone>(c => c.Id == list[i].ZoneId).Select(c => c.ShortName)) + ",";
                }
                val = val.Trim(',');

                row = grdGroupPlotting.Rows.AddNew();

                row.Cells[COLS_GROUP.Id].Value = item.Id;
                row.Cells[COLS_GROUP.GroupName].Value = item.GroupName.ToString();
                row.Cells[COLS_GROUP.ShortName].Value = item.ShortName.ToString();
                row.Cells[COLS_GROUP.Plots].Value = val;
            }


        }

        private void LoadZoneGrid()
        {

            using (TaxiDataContext db = new TaxiDataContext())
            {
                List<ClsZonesGroup> list = db.ExecuteQuery<ClsZonesGroup>("exec stp_GetZonesGroup").ToList();

                grdZonesList.Rows.Clear();

                grdZonesList.RowCount = list.Count;

                for (int i = 0; i < list.Count; i++)
                {
                    //grdZonesList.Rows[i].Cells[COLS.Id].Value = list[i].Id;
                    grdZonesList.Rows[i].Cells[COLS.ZoneId].Value = list[i].ZoneId;
                    grdZonesList.Rows[i].Cells[COLS.Plots].Value = list[i].ZoneName;
                    //grdZonesList.Rows[i].Cells[COLS.Check].Value = false;
                }

            }


        }

        
        private void grid_CommandCellClick(object sender, EventArgs e)
        {
           
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;

            if (gridCell.ColumnInfo.Name == "btnDelete")
            {
                int id = gridCell.RowInfo.Cells[COLS_GROUP.Id].Value.ToInt();

                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a group ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {
                    if (id > 0)
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            Gen_ZoneGroup objGroup = db.Gen_ZoneGroups.FirstOrDefault(c => c.Id == id);
                            db.Gen_ZoneGroups.DeleteOnSubmit(objGroup);
                            db.SubmitChanges();

                            gridCell.RowInfo.Delete();
                        }

                    }
                }


            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {

           
            LoadZoneGrid();
            LoadGroupGrid();


                if (this.CanDelete)
            {

                AddCommandColumn("btnDelete", "Delete", 70);
              //  grdUsers.AddDeleteColumn();
            }

            UI.GridFunctions.SetFilter(grdGroupPlotting);


           
        }

        void grdUsers_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
           

           
        }

        public override void  RefreshData()
        {
            PopulateData();
        }

        public override void PopulateData()
        {

            LoadGroupGrid();


        }


       

        private void FillCombos()
        {
            

            

        }




        #region Overriden Methods
       

        public override void DisplayRecord()
        {


        }

        public override void AddNew()
        {
            OnNew();
            
        }


        public override void OnNew()
        {

            objMaster.Clear();
            objMaster.PrimaryKeyValue = null;
            txtGroupName.Text = string.Empty;
            txtShortName.Text = string.Empty;

            LoadZoneGrid();
           

        }
     

        public override void Save()
        {
         
            try
            {

                if (grdZonesList.Rows.Where(c=>c.Cells[COLS.Check].Value.ToBool() == true).Count() == 0)
                {
                    MessageBox.Show("Please select atleast 1 plot.");
                    return;
                }

                if (objMaster.PrimaryKeyValue == null)
                {
                   

                    objMaster.New();
                                  
            
                }
                else
                {
                    int Id = grdGroupPlotting.CurrentRow.Cells[COLS.Id].Value.ToInt();
                    //booking.GetByPrimaryKey(grdBookings.CurrentRow.Cells[COLS.ID].Value.ToLong());
                    objMaster = new GroupPlottingBO();
                    objMaster.GetByPrimaryKey(Id);
                    objMaster.Edit();
                    

                }

                objMaster.Current.GroupName = txtGroupName.Text;
                objMaster.Current.ShortName = txtShortName.Text;
             


                    string[] skipProperties = { "Gen_ZoneGroup" };
                    IList<Gen_ZoneGroup_Detail> savedList = objMaster.Current.Gen_ZoneGroup_Details;
                    List<Gen_ZoneGroup_Detail> savedExtension = (from saved in grdZonesList.Rows
                                                                 where saved.Cells[COLS.Check].Value.ToBool() == true
                                                                 select new Gen_ZoneGroup_Detail
                                                             
                                                             {
                                                                 Id = saved.Cells[COLS.Id].Value.ToLong(),
                                                                 ZoneGroupId = objMaster.PrimaryKeyValue.ToInt(),
                                                                 ZoneId = saved.Cells[COLS.ZoneId].Value.ToInt(),
                                                                
                                                             }).ToList();
                    Utils.General.SyncChildCollection(ref savedList, ref savedExtension, "Id", skipProperties);
                
                
                objMaster.Save();
                objMaster.GetByPrimaryKey(objMaster.PrimaryKeyValue);
                LoadZoneGrid();
                PopulateData();
                OnNew();

             

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.ExecuteQuery<int>("delete from Gen_ZoneGroup_Details where zonegroupId is null ");

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


        public override void Delete()
        {
            try
            {
                if (objMaster.Current == null) return;

                objMaster.GetByPrimaryKey(grdGroupPlotting.CurrentRow.Cells[COLS_GROUP.Id].Value.ToInt());
                objMaster.Delete(objMaster.Current);

                LoadZoneGrid();
                LoadGroupGrid();
                OnNew();
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


        #endregion




        private void grdUsers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (grdGroupPlotting.CurrentRow == null) return;

            string groupName = grdGroupPlotting.CurrentRow.Cells[COLS_GROUP.GroupName].Value.ToString();
            string shortName = grdGroupPlotting.CurrentRow.Cells[COLS_GROUP.ShortName].Value.ToString();

            txtGroupName.Text = groupName;
            txtShortName.Text = shortName;

            LoadZoneGrid();

            var list = General.GetQueryable<Gen_ZoneGroup_Detail>(c => c.ZoneGroupId == grdGroupPlotting.CurrentRow.Cells[COLS_GROUP.Id].Value.ToInt()).ToList();

            int cnt = 0;
            foreach (var item in list)
            {
                var Zonelist = General.GetQueryable<Gen_Zone>(c => c.Id == item.ZoneId).ToList().FirstOrDefault();

                string ZoneName = Zonelist.OrderNo + ". " + Zonelist.ZoneName + "[" + Zonelist.ShortName + "]"; 

                var row2 = grdZonesList.Rows.NewRow();
                row2.Cells[COLS.Id].Value = item.Id;
                row2.Cells[COLS.Check].Value = true;
                row2.Cells[COLS.Plots].Value = ZoneName;
                row2.Cells[COLS.ZoneId].Value = item.ZoneId;
                grdZonesList.Rows.Insert(cnt, row2);
                    cnt++;
            }
      
   

            objMaster.GetByPrimaryKey(grdGroupPlotting.CurrentRow.Cells[COLS_GROUP.Id].Value.ToInt());
            DisplayRecord();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
            

            }
        }

     

        private void frmUsers_Shown(object sender, EventArgs e)
        {
           
            this.txtGroupName.Focus();

          
        }

        
       



      


    }
}

public class ClsZonesGroup
{
   
    public int ZoneId;
    public string ZoneName;
}
