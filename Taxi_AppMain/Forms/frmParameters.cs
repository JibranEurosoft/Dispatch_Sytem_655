using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Taxi_Model;
using Taxi_BLL;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.IO;
using Taxi_AppMain.Classes;
using Microsoft.Reporting.WinForms;
namespace Taxi_AppMain
{
    public partial class frmParameters : UI.SetupBase
    {
        public struct COLS
        {
            public static string Id = "Id";
            public static string LocationType = "LocationType";
            public static string ShortCutKey = "ShortCutKey";
            public static string ShortKey = "ShortKey";
        }
        public frmParameters()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frmLocationTypes_FormClosed);
        }

        public class ClsAppSettings
        {
            public int Id;
            public string Module;
            public string SetKey;
            public string SetVal;
            public string description;
          
       

        }

        void frmLocationTypes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        public void LoadLocations()
        {
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = "Id";
            grdLocationTypes.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = "Policy";
            col.ReadOnly = true;
            col.HeaderText = "Name";
            grdLocationTypes.Columns.Add(col);

           GridViewCheckBoxColumn  colc = new GridViewCheckBoxColumn();
            colc.Name = "Value";
            colc.ReadOnly = false;
            colc.HeaderText = "";
            grdLocationTypes.Columns.Add(colc);


            using (TaxiDataContext db = new TaxiDataContext())
            {
                try
                {
                    List<ClsAppSettings> query = null;

                    try
                    {
                        query = db.ExecuteQuery<ClsAppSettings>("select *  from appsettings where isvisible is null or isvisible=1").ToList();
                    }
                    catch
                    {
                        query = db.ExecuteQuery<ClsAppSettings>("select *  from appsettings ").ToList();

                    }

                    grdLocationTypes.RowCount = query.Count;
                    for (int i = 0; i < query.Count; i++)
                    {
                        grdLocationTypes.Rows[i].Cells[COLS.Id].Value = query[i].Id;
                        grdLocationTypes.Rows[i].Cells["Policy"].Value = query[i].description;
                        grdLocationTypes.Rows[i].Cells["Value"].Value = query[i].SetVal;

                    }



                    grdLocationTypes.Columns["Policy"].Width = 200;

                    grdLocationTypes.Columns["Value"].Width = 100;

                    grdLocationTypes.Columns["Id"].IsVisible = false;

                }
                catch(Exception ex)
                {

                }
            }

         
        }

      
        

        private void frmLocationTypes_Load(object sender, EventArgs e)
        {
            LoadLocations();
        }

       

        private void btnSaveCloseLocationType_Click(object sender, EventArgs e)
        {
            try
            {
              
                
                using (Taxi_Model.TaxiDataContext objTaxiDataContext = new TaxiDataContext())
                {

                    foreach (var item in grdLocationTypes.Rows)
                    {
                        int Id = item.Cells["Id"].Value.ToInt();

                        objTaxiDataContext.ExecuteQuery<int>("update appsettings set SetVal='" + item.Cells["Value"].Value.ToBool().ToStr().ToLower() + "' where id=" + Id);



                    }



                }

                Close();
            }
            catch (Exception ex)
            {


            }
        }
    }
}
