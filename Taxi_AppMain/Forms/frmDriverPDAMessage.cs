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
using Taxi_BLL.Classes;

namespace Taxi_AppMain
{
    public partial class frmDriverPDAMessage : UI.SetupBase
    {
       

        DriverPDAMessageBO objMaster;

        public frmDriverPDAMessage()
        {
            InitializeComponent();

            objMaster = new DriverPDAMessageBO();   
            this.SetProperties((INavigation)objMaster);

            FormatMessageGrid();
            LoadMessageGrid();

        }

        public struct COLS
        {
            public static string ID = "ID";
            public static string MESSAGE = "MESSAGE";
          
        }

        public void FormatMessageGrid()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();

            col.Name = COLS.ID;
            col.IsVisible = false;
            //col.ReadOnly = false;
            grdMessage.Columns.Add(col);
           
            col = new GridViewTextBoxColumn();
            col.Name = COLS.MESSAGE;
            col.HeaderText = "MESSAGE";
            col.Width = 450;
            //col.ReadOnly = false;
            grdMessage.Columns.Add(col);


            if (this.CanDelete)
            {

                AddCommandColumn("btnDelete", "Delete", 70);
              
            }

            UI.GridFunctions.SetFilter(grdMessage);
        }

        private void AddCommandColumn(string name, string headerText, int width)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = width;

            col.UseDefaultText = true;
            col.DefaultText = headerText;
            col.Name = name;
            grdMessage.Columns.Add(col);

        }

        private void LoadMessageGrid()
        {

            var list = from a in General.GetQueryable<DriverPDAMessage>(null)
                            
                        select new
                        {
                            Id = a.Id,
                            Message = a.Message                        
                        };
            grdMessage.Rows.Clear();
            //grdMessage.DataSource = query.ToList();
            GridViewRowInfo row = null;
            foreach (var item in list)
            {
                row = grdMessage.Rows.AddNew();
                row.Cells[COLS.ID].Value = item.Id;
                row.Cells[COLS.MESSAGE].Value = item.Message;
             
            }

        }

        public void Save()
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
                
                objMaster.Current.Message = txtMsg.Text.ToStr();

                objMaster.Save();
                //objMaster.GetByPrimaryKey(objMaster.PrimaryKeyValue);
                LoadMessageGrid();
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


        private void frmDriverPDAMessage_Load(object sender, EventArgs e)
        {
           
          
        }

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMsg.Text == string.Empty)
            {
                return;
            }
            Save();
            
        }

        private void grdMessage_Click(object sender, EventArgs e)
        {
            if (grdMessage.CurrentRow == null) return;

            objMaster.GetByPrimaryKey(grdMessage.CurrentRow.Cells[COLS.ID].Value.ToInt());
            if (objMaster.Current != null)
            {
                txtMsg.Text = objMaster.Current.Message.ToStr();
            }
        }

        //public override void Delete()
        //{
        //    try
        //    {
        //        if (objMaster.Current == null) return;

        //        objMaster.Delete(objMaster.Current);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (objMaster.Errors.Count > 0)
        //            ENUtils.ShowMessage(objMaster.ShowErrors());
        //        else
        //        {
        //            ENUtils.ShowMessage(ex.Message);

        //        }
        //    }
        //}

        private void grdMessage_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            RadGridView grid = gridCell.GridControl;
            if (gridCell.ColumnInfo.Name == "btnDelete")
            {

                //if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a user ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                //{
                    grid.CurrentRow.Delete();
                objMaster.Delete(objMaster.Current);
                OnNew();
                // }
            }
        }

        private void OnNew()
        {
            txtMsg.Text = string.Empty;
            objMaster.PrimaryKeyValue = null;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OnNew();
        }
    }
}
