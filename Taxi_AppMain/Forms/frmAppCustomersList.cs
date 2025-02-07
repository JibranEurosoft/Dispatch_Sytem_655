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
    public partial class frmAppCustomersList : UI.SetupBase
    {
         CustomerBO objMaster;
         int pageSize = 0;



         public frmAppCustomersList()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmCustomersList_Load);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
             grdLister.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(Grid_RowsChanging);
            objMaster = new CustomerBO();
           
            this.SetProperties((INavigation)objMaster);
           

         
            grdLister.ShowRowHeaderColumn = false;
            this.Shown += new EventHandler(frmCustomersList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);

            grdLister.ShowGroupPanel = false;
            pageSize = AppVars.objPolicyConfiguration.ListingPagingSize.ToInt();


            if (AppVars.AppTheme == "ControlDefault")
            {

                grdLister.CellFormatting += new CellFormattingEventHandler(grdLister_CellFormatting);

            }
            else
            {
                grdLister.ForeColor = Color.White;

            }

        }
        
         void frmCustomersList_Shown(object sender, EventArgs e)
         {
             this.InitializeForm("frmCustomer");

             grdLister.AllowAutoSizeColumns = true;
             grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

          //   ddlColumns.Text = "Name";

             PopulateData();
             AddCreateBookingColumn(grdLister);

             AddEditColumn(grdLister);

             if (this.CanDelete)
             {
                 AddDeleteColumn(grdLister);
             }


             grdLister.Columns["Id"].IsVisible = false;
             grdLister.Columns["Doorno"].IsVisible = false;

             grdLister.Columns["Address"].Width = 320;
             grdLister.Columns["Name"].Width = 70;           
             grdLister.Columns["Phone"].Width = 60;
             grdLister.Columns["MobileNo"].Width = 60;

           

             UI.GridFunctions.SetFilter(grdLister);
          

             if (AppVars.listUserRights.Count(c => c.formName == "frmCustomersList" && c.functionId == "EXPORT LIST") == 0)
             {
                 btnExport.Visible = false;
                 radProgressBar1.Visible = false;
             }


         }


         private void AddCreateBookingColumn(RadGridView grid)
         {
             GridViewCommandColumn col = new GridViewCommandColumn();
             col.Width = 80;

             col.Name = "btnCreateBooking";
             col.UseDefaultText = true;
             col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
             col.DefaultText = "Create Booking";
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



         private void grid_CommandCellClick(object sender, EventArgs e)
         {
             GridCommandCellElement gridCell = (GridCommandCellElement)sender;
             RadGridView grid = gridCell.GridControl;
             if (gridCell.ColumnInfo.Name == "ColDelete")
             {


                 if (gridCell.RowInfo != null)
                 {

                     if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Customer ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                     {
                         gridCell.RowInfo.Delete();
                  //       grid.CurrentRow.Delete();
                     }
                 }
             }
             else if (gridCell.ColumnInfo.Name == "ColEdit")
             {
                 ViewDetailForm();
             }
             else if (gridCell.ColumnInfo.Name.ToLower() == "btncreatebooking")
             {
                 GridViewRowInfo row = grid.CurrentRow;
                 if (row != null && row is GridViewRowInfo)
                 {
                     
                     if (gridCell.ColumnInfo.Name.ToLower() == "btncreatebooking")
                     {
                         string phone = row.Cells["Phone"].Value.ToStr().Trim(); 
                         string mobileNo= row.Cells["MobileNo"].Value.ToStr().Trim();
                         string email = row.Cells["Email"].Value.ToStr().Trim();

                         General.ShowBookingForm(0, false, row.Cells["Name"].Value.ToStr(), phone,mobileNo,
                                                          row.Cells["DoorNo"].Value.ToStr(), row.Cells["Address"].Value.ToStr(), email);
                     }
                 }

             }
         }


         void frmCustomersList_Load(object sender, EventArgs e)
         {


            if (AppVars.ShowAllBookings.ToBool())
            {
                ddlSubCompany.Visible = true;
                foreach (var item in General.GetQueryable<Gen_SubCompany>(null).Select(args => new {  args.CompanyName, args.Id }).ToList())
                {
                    ddlSubCompany.Items.Add(new RadCustomListDataItem { Text = item.CompanyName, Value = item.Id, Tag = item.Id, Font = new Font("Tahoma", 10, FontStyle.Bold), ForeColor = Color.Black });
                }

                if (ddlSubCompany.Items.Count == 1)
                    ddlSubCompany.Visible = false;
                else
                {
                    ddlSubCompany.Items.Insert(0, new RadCustomListDataItem { Text = "Show All Data", Value = 0, Font = new Font("Tahoma", 10, FontStyle.Bold), ForeColor = Color.Black });
                    ddlSubCompany.SelectedIndex = 0;
                    //  ddlSubCompany.DropDownStyle = RadDropDownStyle.DropDownList;
                    ddlSubCompany.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(ddlSubCompany_SelectedIndexChanged);
                }
            }
        }


        void ddlSubCompany_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            PopulateData();
        }


        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
         {
             ViewDetailForm();
         }

         private void ViewDetailForm()
         {

             if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
             {
                 ShowCustomerForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
             }
             else
             {
                 ENUtils.ShowMessage("Please select a record");
             }
         }


         private void ShowCustomerForm(int id)
         {


            frmCustomer frm = new frmCustomer();
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

                
                     objMaster = new CustomerBO();

                     try
                     {

                         objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
                         objMaster.Delete(objMaster.Current);


                         PopulateData();
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


         Font f = new Font("Tahoma", 10, FontStyle.Bold);
         private void grdLister_CellFormatting(object sender, CellFormattingEventArgs e)
         {
            try
            {
                if (e.Column != null && e.Row != null && e.Row.Cells["Id"].Value != null)
                {
                    if (e.Column.Name == "Name")
                    {
                        e.CellElement.Font = f;

                    }



                }
            }
            catch
            {

            }

         }

        
        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);
        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);



       

        public override void RefreshData()
        {
            PopulateData();
        }

       

        public override void PopulateData()
        {
            try
            {
             


                int subCompanyId = ddlSubCompany.SelectedValue.ToInt();


                using (TaxiDataContext db = new TaxiDataContext())
                {
                    IEnumerable<Customer> data1 = null;


                    if (subCompanyId == 0)
                        data1 = db.ExecuteQuery<Customer>("select * from customer where loginpassword is not null and loginpassword!=''").ToList();
                    else
                    {
                        try
                        {
                            data1 = db.ExecuteQuery<Customer>("select * from customer where (loginpassword is not null and loginpassword!='') and subcompanyId=" + subCompanyId).ToList();
                        }
                        catch
                        {
                            data1 = db.ExecuteQuery<Customer>("select * from customer where loginpassword is not null and loginpassword!=''").ToList();
                        }
                    }


                    var query =( from a in data1
                                 orderby a.Name

                                select new
                                {
                                    Id = a.Id,
                                    Name = a.Name,
                                    Phone = a.TelephoneNo,
                                    MobileNo = a.MobileNo,
                                    Address = a.DoorNo.ToStr() != string.Empty ? a.DoorNo + " - " + a.Address1 : a.Address1,
                                    Doorno = a.DoorNo,
                                    Email = a.Email

                                }).ToList();


                    this.grdLister.TableElement.BeginUpdate();

                
                        grdLister.DataSource = query.ToList();

                    this.grdLister.TableElement.EndUpdate();



                    lblTotal.Text = "Total Customers : " + grdLister.Rows.Count.ToStr();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


      

       
     

      //  RadGridViewExcelExporter exporter=null;
        private void btnExport_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (DialogResult.OK == saveFileDialog1.ShowDialog())
            //    {




            //        int subCompanyId = ddlSubCompany.SelectedValue.ToInt();


            //        using (TaxiDataContext db = new TaxiDataContext())
            //        {
            //            IEnumerable<Customer> data1 = null;


            //            if (subCompanyId == 0)
            //                data1 = db.ExecuteQuery<Customer>("select * from customer where loginpassword is not null and loginpassword!=''").ToList();
            //            else
            //            {
            //                try
            //                {
            //                    data1 = db.ExecuteQuery<Customer>("select * from customer where (loginpassword is not null and loginpassword!='') and subcompanyId=" + subCompanyId).ToList();
            //                }
            //                catch
            //                {
            //                    data1 = db.ExecuteQuery<Customer>("select * from customer where loginpassword is not null and loginpassword!=''").ToList();
            //                }


            //            }

            //            var query = (from a in data1
            //                         orderby a.Name

            //                         select new
            //                         {
            //                             Name = a.Name,
            //                             Phone = a.TelephoneNo,
            //                             MobileNo = a.MobileNo,
            //                             Address = a.Address1,

            //                         }).ToList();


            //            radGridView1.DataSource = query;


            //            exporter = new RadGridViewExcelExporter();
            //            BackgroundWorker worker = new BackgroundWorker();
            //            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            //            worker.RunWorkerAsync(saveFileDialog1.FileName);
            //            exporter.Progress += new ProgressHandler(exportProgress);

            //            this.btnExport.Enabled = false;
            //        }
            //    }

            //}
            //catch
            //{


            //}
        }

        //void  worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    exporter.Export(this.radGridView1, (String)e.Argument, "Customer List");  
        //}

        
    
    
 
    
    //Update the progress bar with the export progress    
    private void exportProgress(object sender, ProgressEventArgs e) 
    {     
        // Call InvokeRequired to check if thread needs marshalling, to access properly the UI thread.
        if (this.InvokeRequired)
        {
            this.Invoke(new EventHandler(
            delegate
            {
                if (e.ProgressValue <= 100)
                {
                    radProgressBar1.Value1 = e.ProgressValue;
                }
                else
                {
                    radProgressBar1.Value1 = 100;
                }
            }));
        }
        else
        {
            if (e.ProgressValue <= 100)
            {
                radProgressBar1.Value1 = e.ProgressValue;
            }
            else
            {
                radProgressBar1.Value1 = 100;
            }
        }     
   }     
    // when the worker finishes the export, we can do some post processing   
    private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
    {          
            this.btnExport.Enabled = true;    
            this.radProgressBar1.Value1 = 0;     
            //   RadMessageBox.SetThemeName(this.grdLister.ThemeName);   
            //RadMessageBox.Show("The data in the grid was exported successfully.", "Export to Excel");  
            ENUtils.ShowMessage("Export successfully.");  
    }

    private void grdLister_MouseDown(object sender, MouseEventArgs e)
    {
        try
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                Clipboard.Clear();
                if (this.grdLister.CurrentCell != null && this.grdLister.CurrentCell.Value.ToStr().Trim().Length > 0)
                {

                    Clipboard.SetText(this.grdLister.CurrentCell.Value.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }




    }
}

