using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Taxi_Model;
using Utils;
using CheckBoxInHeader;
using System.Net.Sockets;
using System.Net;
using Telerik.WinControls.Enumerations;
using System.Threading;
using System.ComponentModel;
using UI;
using Taxi_AppMain.Classes;
using DAL;
using System.IO;

namespace Taxi_AppMain
{
    public partial class frmPendingDriverDocument : UI.SetupBase
    {
        DriverBO objMaster;
        public bool isGroup = true;
        public frmPendingDriverDocument()
        {
            InitializeComponent();

       
            //this.radGridView1.CreateCell += new GridViewCreateCellEventHandler(radGridView1_CreateCell);  //second approach
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            
            this.grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
            //              grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);

            this.grdLister.EnableFiltering = true; 
            grdLister.ShowRowHeaderColumn = false;
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdLister.AutoCellFormatting = true;
            
            //this.grdLister.ValueChanged += new EventHandler(grdLister_ValueChanged);
            //grdLister.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            //this.Shown += new EventHandler(frmDriversList_Shown);

            this.Shown += new EventHandler(frmPendingDriverDocumentList_Shown);

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);

            chkGroup(true);

        }

        Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);
        Font newFont = new Font("Tahoma", 10, FontStyle.Bold);

        private Color _HeaderRowBackColor = Color.SteelBlue;

        public Color HeaderRowBackColor
        {
            get { return _HeaderRowBackColor; }
            set { _HeaderRowBackColor = value; }
        }

        public struct col_PDD
        {            
            //public static string Check = "Check";
            public static string Id = "Id";
            public static string DriverId = "DriverId";
            public static string DriverNo = "DriverNo";
            public static string DriverName = "DriverName";
            public static string DocumentName = "DocumentName";
            public static string FileName = "FileName";
            public static string FilePath = "FilePath";
            public static string ExpiryDate = "ExpiryDate";
            public static string BadgeNumber = "BadgeNumber";
            public static string Status = "Status";
        }

        private Color _HeaderRowBorderColor = Color.DarkSlateBlue;

        public Color HeaderRowBorderColor
        {
            get { return _HeaderRowBorderColor; }
            set { _HeaderRowBorderColor = value; }
        }

        RadButtonElement button = null;
        string cellValue = string.Empty;


        //void grdLister_ValueChanged(object sender, EventArgs e)
        //{
        //    //bool valueState = false;
        //    //StateChangedEventArgs args;

        //    //if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
        //    //{
        //    //    valueState = true;
        //    //}
        //    //RadCheckBoxEditor editor = sender as RadCheckBoxEditor;
        //    if (this.grdLister.ChildRows != null)
        //    {
        //        //foreach (GridViewRowInfo row in this.grdLister.ChildRowsCurrentRow.ChildRows)
                  
        //        foreach (GridViewRowInfo row in this.grdLister.ChildRows)
        //        {
        //                //grdLister.ChildRows.rows.Items[0].GroupRow.IsSelected = true;
        //            row.IsSelected = true;
        //        }

        //    }
        //}



        void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {

            //this.radGridView1.CurrentRow.ViewInfo.ParentRow
            

            if (e.CellElement is GridHeaderCellElement )
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

            else if (e.CellElement is GridFilterCellElement)
            {
                e.CellElement.Font = oldFont;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.White;
                e.CellElement.RowElement.BackColor = Color.White;
                e.CellElement.RowElement.NumberOfColors = 1;

                e.CellElement.BorderColor = Color.DarkSlateBlue;
                e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;
            }

            else if (e.CellElement is GridDataCellElement)
            {


                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    // This is how we get the RadButtonElement instance from the cell
                    button = (RadButtonElement)e.CellElement.Children[0];

                    if (e.Column.Name == "Approved")
                    {
                        //e.Column.AllowGroup = true;
                        button.Image = Resources.Resource1.save_Tick;
                    }

                    if (e.Column.Name == "Rejected")
                    {

                        button.Image = Resources.Resource1.delete;

                    }

                    if (e.Column.Name == "View")
                    {

                        button.Image = Resources.Resource1.pic_Search;

                    }

                }

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

                    e.CellElement.NumberOfColors = 1;
                    e.CellElement.BackColor = Color.DeepSkyBlue;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.Font = newFont;

                }


                else
                {
                    e.CellElement.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.TwoWayBindingLocal);
                }


            }
            //new
            if (e.CellElement is GridFilterCellElement && e.CellElement.ColumnInfo.Name == "Select")
            {

                e.CellElement.Children.Clear();                

            }

           

        }


        //private void grid_CommandCellClick(object sender, EventArgs e)
        //{
        //    GridCommandCellElement gridCell = (GridCommandCellElement)sender;
        //    if (gridCell.ColumnInfo.Name.ToLower() == "btnlogout")
        //    {



        //        if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to logout this Driver ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
        //        {


        //            RadGridView grid = gridCell.GridControl;
        //            if( Logout(grid.CurrentRow.Cells["Id"].Value.ToLong(),grid.CurrentRow.Cells["DriverId"].Value.ToIntorNull()))
        //            {

        //                General.AddUserLog("Driver {" + grid.CurrentRow.Cells["DriverNo"].Value.ToStr() + "} manually logout by Controller", 3);
        //            }
        //            PopulateData();

        //            General.BroadCastRefresh(RefreshTypes.REFRESH_DASHBOARD_DRIVER);

        //        }
        //    }
           
        //}

        void ColumnSetting()
        {
            if (grdLister.Columns.Count > 2)
            {
                grdLister.AllowEditRow = true;
                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["DriverId"].IsVisible = false;

                grdLister.Columns["DriverNo"].HeaderText = "Driver No";
                grdLister.Columns["DriverNo"].Name = "DriverNo";
                grdLister.Columns["DriverNo"].Width = 400;
                grdLister.Columns["DriverNo"].IsVisible = true;
                grdLister.Columns["DriverNo"].ReadOnly = true;

                grdLister.Columns["DriverName"].HeaderText = "Driver Name";
                grdLister.Columns["DriverName"].Name = "DriverName";
                grdLister.Columns["DriverName"].Width = 400;
                grdLister.Columns["DriverName"].IsVisible = false;
                grdLister.Columns["DriverName"].ReadOnly = true;

                grdLister.Columns["DocumentName"].HeaderText = "Document Name";
                grdLister.Columns["DocumentName"].Name = "DocumentName";
                grdLister.Columns["DocumentName"].Width = 400;
                grdLister.Columns["DocumentName"].IsVisible = true;
                grdLister.Columns["DocumentName"].ReadOnly = true;


                grdLister.Columns["FileName"].HeaderText = "File Name";
                grdLister.Columns["FileName"].Name = "FileName";
                grdLister.Columns["FileName"].Width = 300;
                grdLister.Columns["FileName"].IsVisible = false;
                grdLister.Columns["FileName"].ReadOnly = true;


                grdLister.Columns["FilePath"].HeaderText = "FilePath";
                grdLister.Columns["FilePath"].Name = "FilePath";
                grdLister.Columns["FilePath"].Width = 300;
                grdLister.Columns["FilePath"].IsVisible = false;
                grdLister.Columns["FilePath"].ReadOnly = true;


                (grdLister.Columns["ExpiryDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
                (grdLister.Columns["ExpiryDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";
                grdLister.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                grdLister.Columns["ExpiryDate"].Name = "ExpiryDate";
                grdLister.Columns["ExpiryDate"].Width = 200;
                grdLister.Columns["ExpiryDate"].ReadOnly = true;


                //grdLister.Columns["Address"].Width = 200;
                grdLister.Columns["BadgeNumber"].HeaderText = "Badge Number";
                grdLister.Columns["BadgeNumber"].Name = "BadgeNumber";
                grdLister.Columns["BadgeNumber"].Width = 200;
                grdLister.Columns["BadgeNumber"].IsVisible = true;
                grdLister.Columns["BadgeNumber"].ReadOnly = true;


                grdLister.Columns["Status"].HeaderText = "Status";
                grdLister.Columns["Status"].Name = "Status";
                grdLister.Columns["Status"].Width = 200;
                grdLister.Columns["Status"].IsVisible = true;
                grdLister.Columns["Status"].ReadOnly = true;


                GridViewCommandColumn col2 = new GridViewCommandColumn();
                col2.HeaderText = "";
                col2.Width = 100;
                col2.UseDefaultText = true;
                col2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                col2.DefaultText = "View";                
                col2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                //col2.TextImageRelation = TextImageRelation.Overlay;
                col2.Name = "View";
                grdLister.Columns.Add(col2);

                GridViewCommandColumn col4 = new GridViewCommandColumn();
                col4 = new GridViewCommandColumn();
                col4.HeaderText = "";
                col4.Width = 100;
                col4.UseDefaultText = true;
                col4.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                col4.DefaultText = "Approved";
                col4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                col4.Name = "Approved";
                grdLister.Columns.Add(col4);


                GridViewCommandColumn col3 = new GridViewCommandColumn();
                col3.HeaderText = "";
                col3.Width = 100;
                col3.UseDefaultText = true;
                col3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
                col3.DefaultText = "Rejected";                
                col3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                col3.Name = "Rejected";               
                grdLister.Columns.Add(col3);
                
            }
        }
        void frmPendingDriverDocumentList_Shown(object sender, EventArgs e)
        {
            try
            {
                this.InitializeForm("frmPendingDriverDocument");
            }
            catch
            {


            }

            grdLister.AllowAutoSizeColumns = true;
            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;
            grdLister.EnableHotTracking = false;
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;
            grdLister.AllowEditRow = true;


            //General.AddCheckBoxColumn("chkLogout", grdLister);
            this.AddCheckColumn();
            //ddlColumns.Items.Add("All");
            //ddlColumns.Items.Add("Pending");
            //ddlColumns.Items.Add("Approved");
            //ddlColumns.Items.Add("Rejected");            
            //ddlColumns.SelectedIndex = 0;

            //this.AddCheckColumn();
            //ddlColumnsName.Items.Add("DriverNo");
            //ddlColumnsName.Items.Add("DriverName");
            //ddlColumnsName.Items.Add("DocumentName");
            //ddlColumnsName.Items.Add("BadgeNumber");
            //ddlColumnsName.SelectedIndex = 0;            

            PopulateData();
            //if (grdLister.Columns.Count > 2)
            //{
            //    grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            //    //ColumnSetting();
            //}

            //AddLogoutColumn(grdLister);


            ////start adil 21/05/13
            //ddlColumns.Items.AddRange(grdLister.Columns.Where(c => c.Name != "Id" && c.Name != "btnEdit" && c.Name != "btnDelete" && c.Name != "DriverId" && c.Name != "btnLogout" && c.Name != "LoginDateTime" && c.Name!="Select")
            //                            .Select(c => c.Name));


            // End of lines
        }

        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            string colName = grdLister.CurrentColumn.Name;
            GridViewRowInfo row = grdLister.CurrentRow;
            
            if (colName == "Approved")
            {
                
                //var RowIndex = grdLister.CurrentRow.Index;
                //var ColIndex = grdLister.CurrentColumn;
                updateStatusRow(row, "Approved");
                grdLister.CurrentRow.Cells["status"].Value = "Approved";                
                PopulateData();
                //this.grdLister.Rows[RowIndex].IsCurrent = true;
                //this.grdLister.Rows[RowIndex].IsSelected = true;
                
            }
            else if (colName == "Rejected")
            {   
                //var RowIndex = grdLister.CurrentRow.Index;
                //var ColIndex = grdLister.CurrentColumn;
                updateStatusRow(row, "Rejected");
                grdLister.CurrentRow.Cells["status"].Value = "Rejected";                
                PopulateData();
                //this.grdLister.Rows[RowIndex].IsCurrent = true;
                //this.grdLister.Rows[RowIndex].IsSelected = true;
                
            }
            else if (colName == "View")
            {
                ViewDocument(row);

            }
        }

        void updateStatusRow(GridViewRowInfo item,string parStatus)
        {
            using (TaxiDataContext db = new TaxiDataContext())
            {
                //db.ExecuteQuery<int>("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5},{6}", );

               //    AppVars.LoginObj.UserName
                db.ExecuteCommand("update Pending_Driver_Document set status='" + parStatus + "' where id={0} and DriverId={1}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt());

                if (parStatus== "Approved")
                {
                    db.ExecuteCommand("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt(), "", "", AppVars.LoginObj.UserName, 2);
                }
                else if (parStatus == "Rejected")
                {
                    db.ExecuteCommand("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt(), "", "", AppVars.LoginObj.UserName, 3);
                }


                //item.Cells["status"].Value = parStatus;                

                //this.Shown += new EventHandler(frmPendingDriverDocumentList_Shown);
                //PopulateData();
            }        
        }

        private void ViewDocument(GridViewRowInfo row)
        {

            string fullDirectoryPath = "";
            DirectoryInfo di = null;


            try
            {
                //grdLister.Columns["FileName"].HeaderText = true;
                //grdLister.Columns["FilePath"].HeaderText = "FilePath";

                if (row.Cells["FilePath"].Value.ToStr() != string.Empty)
                {
                    fullDirectoryPath = row.Cells["FilePath"].Value.ToStr(); //+ row.Cells["FileName"].Value.ToStr();
                    if (File.Exists(fullDirectoryPath))
                    {
                        di = new DirectoryInfo(fullDirectoryPath);
                        System.Diagnostics.Process.Start(di.FullName);
                    }
                    else
                    {
                        if (fullDirectoryPath.ToStr().StartsWith("http:") || fullDirectoryPath.ToStr().StartsWith("https:"))
                        {
                            System.Diagnostics.Process.Start(fullDirectoryPath.ToStr().Trim());
                        }
                        else
                        {
                            throw new Exception("File not found");
                        }

                    }


                }
                else
                {
                    ENUtils.ShowMessage("Please select a Document");
                    return;

                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }



        //private void AddLogoutColumn(RadGridView grid)
        //{
        //    GridViewCommandColumn col = new GridViewCommandColumn();
        //    col.BestFit();
        //    col.Width = 70;
        //    col.Name = "btnLogout";
        //    col.UseDefaultText = true;
        //    col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
        //    col.DefaultText = "Log out";
        //    col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

        //    grid.Columns.Add(col);

        //}


        //private bool Logout(long id, int? driverId)
        //{
        //    bool rtn = false;
        //    try
        //    {

        //        DriverQueueBO objMaster = new DriverQueueBO();
        //        objMaster.GetByPrimaryKey(id);

        //        if (objMaster.Current != null)
        //        {
        //            objMaster.Current.LogoutDateTime = DateTime.Now;
        //            objMaster.Current.Status = false;

        //            objMaster.Save();

        //            rtn = true;

        //            if (objMaster.Current.Fleet_Driver.HasPDA.ToBool())
        //            {


        //                new Thread(delegate()
        //                {
        //                    General.SendMessageToPDA("request force logout=" + objMaster.Current.Fleet_Driver.DriverNo + "=" + driverId);
        //                }).Start();

        //              //  SendMessage("request force logout=" + objMaster.Current.Fleet_Driver.DriverNo);

        //            }
        //        }               



        //    }
        //    catch (Exception ex)
        //    {
        //        //ENUtils.ShowMessage(ex.Message);


        //    }


        //        return rtn;


        //}

        private void SendMessage(string msg)
        {
            try
            {
                if (!string.IsNullOrEmpty(AppVars.objPolicyConfiguration.ListenerIP.ToStr()))
                {

                    byte[] data = Encoding.UTF8.GetBytes(msg);

                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(new IPEndPoint(IPAddress.Parse(AppVars.objPolicyConfiguration.ListenerIP.ToStr()), 1101));
                    tcpClient.SendTimeout = 3000;
                    tcpClient.ReceiveTimeout = 3000;
                    tcpClient.GetStream().Write(data, 0, data.Length);

                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {


            }
        }


       


        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ViewDetailForm();
        }

        private void ViewDetailForm()
        {

            if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {
                //ShowDriverForm(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
            }
            else
            {
                ENUtils.ShowMessage("Please select a record");
            }
        }


        private void ShowDriverForm(int id)
        {


            frmDriver frm = new frmDriver();
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

                //if (this.CanDelete == false)
                //{
                //    ENUtils.ShowMessage("Permission Denied");
                //    e.Cancel = true;
                //}
                //else
                //{
                    objMaster = new DriverBO();

                    try
                    {

                        //objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
                        //objMaster.Delete(objMaster.Current);


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
                //}

            }
        }



        Font f = new Font("Tahoma", 10, FontStyle.Bold);
        Color clr = Color.Yellow;
        private void grdLister_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column != null && e.Row != null && e.Row.Cells["Id"].Value != null)
            {
                if (e.Column.Name == "Name")
                {
                    e.CellElement.Font = f;

                }


            }
        }

        
       


        public override void RefreshData()
        {
            PopulateData();
        }

        public override void PopulateData()
        {
            //Start lines adil 21/5/13
            //string searchTxt = txtSearch.Text.ToLower().Trim();
            string searchTxt = "";
            string col = "";
            string col1 = "All";
            string colName = "";
            if (ddlAllDriver.Text=="Select" || ddlAllDriver.Text=="")
            {
                chkAllDriver.Checked = true;
                ddlAllDriver.Text = "";
            }

            if (chkAllDriver.Checked != true)
            {
                searchTxt = "";
                //col = ddlAllDriver.Text;
                string[] words = ddlAllDriver.Text.Split('-');
                col1 = words[0].Trim();
                colName = "DriverNo";
                searchTxt = "DriverNo";
            }


            string ConSearch = "";

            if (searchTxt != "")
            { 
                if (colName == "DriverNo")
                {
                    //ConSearch = "And  DriverNo='"+ searchTxt + "'" ;
                    ConSearch = col1;
                }

                if (colName == "DriverName")
                {
                    ConSearch = "And  DriverName='" + searchTxt + "'";
                }

                if (colName == "DocumentName")
                {
                    ConSearch = "And  DocumentName='" + searchTxt + "'";
                }

                if (colName == "BadgeNumber")
                {
                    ConSearch = "And  BadgeNumber='" + searchTxt + "'";
                }
            }
            
            using (TaxiDataContext db = new TaxiDataContext())
            {
                List<ClsPending_Driver_Document> list1 = null;
                //var query = (from a in db.GetTable<Fleet_DriverQueueList>()
                //if (col!="All")
                //{ 
                 
                 //list1 = db.ExecuteQuery<ClsPending_Driver_Document>("select Pending_Driver_Document.Id, DriverId ,DriverName, DriverNo, DocumentName,FileName, FilePath, ExpiryDate, BadgeNumber, Status from Pending_Driver_Document inner join Fleet_Driver on Pending_Driver_Document.DriverId=Fleet_Driver.Id Where DriverNo='" + col + "'" + ConSearch).ToList();

                 //list1 = db.ExecuteQuery<ClsPending_Driver_Document>("exec stp_updatedocumentstatus {0}", col).ToList();

                //}
                //if (col == "All")
                //{
                    if (ConSearch=="")
                    {
                        //list1 = db.ExecuteQuery<ClsPending_Driver_Document>("select Pending_Driver_Document.Id, DriverId ,DriverName, DriverNo, DocumentName,FileName, FilePath, ExpiryDate, BadgeNumber, Status from Pending_Driver_Document inner join Fleet_Driver on Pending_Driver_Document.DriverId=Fleet_Driver.Id").ToList();
                        list1 = db.ExecuteQuery<ClsPending_Driver_Document>("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", 0, 0, "", "", "", 0).ToList();
                    }
                    else
                    {
                        //list1 = db.ExecuteQuery<ClsPending_Driver_Document>("select Pending_Driver_Document.Id, DriverId ,DriverName, DriverNo, DocumentName,FileName, FilePath, ExpiryDate, BadgeNumber, Status from Pending_Driver_Document inner join Fleet_Driver on Pending_Driver_Document.DriverId=Fleet_Driver.Id where " + ConSearch.Replace("And","")).ToList();
                        //list1 = db.ExecuteQuery<ClsPending_Driver_Document>("exec stp_updatedocumentstatus {0}", ConSearch).ToList();
                        list1 = db.ExecuteQuery<ClsPending_Driver_Document>("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", 0, 0, col1, "", "", 1).ToList();
                    }
                //}

                    var query = (from a in list1
                                     //where
                                     //    ((a.DriverNo.ToLower().Contains(searchTxt.ToLower()) || searchTxt == string.Empty))
                                     //        || ((a.DriverNo.ToLower().Contains(searchTxt.ToLower()) || searchTxt == string.Empty))
                                     //        || ((a.DocumentName.ToLower().Contains(searchTxt.ToLower()) || searchTxt == string.Empty))                                     


                                     ////DriverNo =a.DriverNo.Trim(),
                             select new
                             {
                                Id=a.Id,
                                DriverId = a.DriverId,
                                DriverName = a.DriverName,                                
                                DriverNo = a.DriverNo.Trim() + " - " + a.DriverName.Trim(),
                                DocumentName = a.DocumentName,
                                FileName=a.FileName,
                                FilePath=a.FilePath,
                                ExpiryDate = a.ExpiryDate,                                                                
                                BadgeNumber = a.BadgeNumber,
                                Status = a.Status
                             }).ToList().OrderBy(item => item.DriverNo, new NaturalSortComparer<string>());

                //DriverId = a.DriverId,
                //DocumentId = a.DocumentId,
                //FileName = a.FileName,
                //FilePath = a.FilePath,

                if (list1.Count() == 0)
                {
                    //grdLister.Rows.Clear(); 
                    grdLister.DataSource = query;
                    grdLister.Columns.Clear();                    
                    FormatTempletGrid();
                    AddCheckColumn();
                    chkGroup(true);
                }
                else                    
                {
                    grdLister.Columns.Clear();
                    grdLister.DataSource = query;
                    ColumnSetting();                    
                    AddCheckColumn();
                    chkGroup(true);                    
                    //FormatTempletGrid();
                }
            }

            //lblTotalLogins.Text = "Total Driver(s) Document : " + grdLister.Rows.Count.ToStr();


        }

        private void FormatTempletGrid()
        {
            
            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            //col.IsVisible = true;
            //col.HeaderText = "";
            //col.Width = 100;
            //col.Name = col_PDD.Check;
            //grdLister.Columns.Add(col);


            //col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Id";
            col.Name = col_PDD.Id;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "DriverId";
            col.Name = col_PDD.DriverId;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.HeaderText = "Driver No";
            col.Width = 400;
            col.ReadOnly = true;
            col.Name = col_PDD.DriverNo;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "Driver Name";
            col.Name = col_PDD.DriverName;
            col.Width = 400;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.HeaderText = "Document Name";
            col.Name = col_PDD.DocumentName;
            col.ReadOnly = true;
            col.Width = 400;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "File Name";
            col.Name = col_PDD.FileName;            
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.HeaderText = "File Path";
            col.Name = col_PDD.FilePath;
            col.ReadOnly = true;
            grdLister.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.HeaderText = "Expiry Date";
            col.Name = col_PDD.ExpiryDate;
            col.ReadOnly = true;
            col.Width = 200;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.HeaderText = "Badge Number";
            col.ReadOnly = true;
            col.Name = col_PDD.BadgeNumber;
            col.Width = 200;
            grdLister.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = true;
            col.ReadOnly = true;
            col.HeaderText = "Status";
            col.Name = col_PDD.Status;
            col.Width = 200;
            grdLister.Columns.Add(col);

            GridViewCommandColumn col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 100;
            col2.UseDefaultText = true;
            col2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col2.DefaultText = "View";
            col2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            col2.TextImageRelation = TextImageRelation.Overlay;
            col2.Name = "View";
            grdLister.Columns.Add(col2);

            GridViewCommandColumn col4 = new GridViewCommandColumn();
            col4 = new GridViewCommandColumn();
            col4.HeaderText = "";
            col4.Width = 100;
            col4.UseDefaultText = true;
            col4.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col4.DefaultText = "Approved";
            col4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            col4.Name = "Approved";
            grdLister.Columns.Add(col4);


            GridViewCommandColumn col3 = new GridViewCommandColumn();
            col3.HeaderText = "";
            col3.Width = 100;
            col3.UseDefaultText = true;
            col3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col3.DefaultText = "Rejected";
            col3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            col3.Name = "Rejected";
            grdLister.Columns.Add(col3);
        }

        //private void btnMultiLogout_Click(object sender, EventArgs e)
        //{
        //    var selectedRows = grdLister.Rows.Where(c => c.Cells["Select"].Value.ToBool());

        //     if (selectedRows.Count() > 0)
        //     {
        //         foreach (var item in selectedRows)
        //         {

        //             Logout(item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToIntorNull());

        //         }

        //        //General.AddUserLog("Driver(s) {" +string.Join(",",selectedRows.Select(c=>c.Cells["DriverNo"].Value.ToStr())) + "} manually logout by Controller", 3);


        //        PopulateData();

        //         //General.BroadCastRefresh(RefreshTypes.REFRESH_DASHBOARD_DRIVER);

        //     }
        //}

        private void AddCheckColumn()
        {
            CustomCheckBoxColumn1 checkColumn = new CustomCheckBoxColumn1();
            checkColumn.Name = "Select";
            //checkColumn.HeaderText = "All";
            this.grdLister.Columns.Insert(0, checkColumn);
        }

        //void grdLister_CreateCell(object sender, GridViewCreateCellEventArgs e)
        //{

        //    if (e.CellType == typeof(GridHeaderCellElement) && e.Column.HeaderText == "All")
        //    {
        //        e.CellType = typeof(CheckBoxHeaderCell);
        //    }
        //    if (e.CellType == typeof(GridGroupContentCellElement))
        //    {
        //        GridGroupHeaderItemsContainer customCell = new GridGroupHeaderItemsContainer();
        //        //CustomGroupHeaderCell customCell = new CustomGroupHeaderCell(e.Column, e.Row);
        //        customCell.MeCheckChanged += new EventHandler(customCell_MeCheckChanged);
        //        e.CellElement = customCell;
        //    }
        //}
        public class CustomCheckBoxColumn1 : GridViewCheckBoxColumn
        {
            public override Type GetCellType(GridViewRowInfo row)
            {
                if (row is GridViewTableHeaderRowInfo)
                {
                    return typeof(CheckBoxHeaderCell);
                }
                return base.GetCellType(row);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            this.Shown += new EventHandler(frmPendingDriverDocumentList_Shown);
            PopulateData();            
            //ColumnSetting();
        }

        private void btnShowAllCompanies_Click(object sender, EventArgs e)
        {
            //txtSearch.Text = string.Empty;
            //ddlColumns.SelectedIndex = 0;
            //ddlColumnsName.SelectedIndex = 0;

            PopulateData();

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Shown += new EventHandler(frmPendingDriverDocumentList_Shown);
                PopulateData();
            }
        }


        private void btnMultiApproved_Click(object sender, EventArgs e)
        {
            var selectedRows = grdLister.Rows.Where(c => c.Cells["Select"].Value.ToBool());

            if (selectedRows.Count() > 0)
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    foreach (var item in selectedRows)
                    {
                        //Logout(item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToIntorNull());

                        //db.ExecuteCommand("update Pending_Driver_Document set status='Approved' where id='" + item.Cells["Id"].Value.ToLong() + "'");
                        //db.ExecuteCommand("update Pending_Driver_Document set status='Approved' where id={0} and DriverId={1}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt());

                        db.ExecuteCommand("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt(), "", "", "", 2);
                    }
                }
                //General.AddUserLog("Driver(s) {" + string.Join(",", selectedRows.Select(c => c.Cells["DriverNo"].Value.ToStr())) + "} manually logout by Controller", 3);
                PopulateData();
                //General.BroadCastRefresh(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
            }
        }

        void grdLister_ViewRowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Group != null && e.RowElement.RowInfo.Group.IsExpanded == false)
            {
                e.RowElement.RowInfo.Group.Expand();

            }
        }



        private void btnMultiRejected_Click(object sender, EventArgs e)
        {
            var selectedRows = grdLister.Rows.Where(c => c.Cells["Select"].Value.ToBool());

            if (selectedRows.Count() > 0)
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    foreach (var item in selectedRows)
                    {                        
                        //db.ExecuteCommand("update Pending_Driver_Document set status='Rejected' where id='{0}' and DriverId='{1}' ", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt());
                        //db.ExecuteCommand("update Pending_Driver_Document set status='Rejected' where id={0} and DriverId={1} ", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt());
                        db.ExecuteCommand("exec stp_updatedocumentstatus {0},{1},{2},{3},{4},{5}", item.Cells["Id"].Value.ToLong(), item.Cells["DriverId"].Value.ToInt(), "", "", "", 3);

                    }
                }
                //General.AddUserLog("Driver(s) {" + string.Join(",", selectedRows.Select(c => c.Cells["DriverNo"].Value.ToStr())) + "} manually logout by Controller", 3);

                this.Shown += new EventHandler(frmPendingDriverDocumentList_Shown);
                PopulateData();
                
                //General.BroadCastRefresh(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
            }
        }

        private void radbtnGroup_Click(object sender, EventArgs e)
        {
            chkGroup(isGroup);
        }

       
        private void chkGroup(Boolean isGroup)
        {            
            if (isGroup == true)
            {
                grdLister.ViewRowFormatting += new RowFormattingEventHandler(grdLister_ViewRowFormatting);
                grdLister.GroupDescriptors.Expression = "DriverNo";
                grdLister.GroupDescriptors.Expression = "DriverNo";
                isGroup = false;
            }
            else
            {
                grdLister.ViewRowFormatting += new RowFormattingEventHandler(grdLister_ViewRowFormatting);
                grdLister.GroupDescriptors.Expression = "";
                grdLister.GroupDescriptors.Expression = "";
                isGroup = true;
            }
        }

        private void chkAllDriver_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                ddlAllDriver.SelectedValue = null;
                ddlAllDriver.Enabled = false;
                //ddlAllDriver.SelectedValue = 0;
            }

            else
            {
                if (ddlAllDriver.DataSource == null)
                {
                    //ComboFunctions.FillDriverCombo(ddlAllDriver);
                    ComboFunctions.FillDriverNoCombo(ddlAllDriver);
                }
                ddlAllDriver.Enabled = true;
            }
        }
    }
}


