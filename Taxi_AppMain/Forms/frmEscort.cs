using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using Utils;
using Taxi_Model;
using DAL;
using UI;
using System.Net;
using System.Xml.Linq;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using System.IO;
using Taxi_AppMain.Forms;

namespace Taxi_AppMain
{
    public partial class frmEscort : UI.SetupBase
    {
        Gen_EscortBO objMaster;
        public struct COL_DOCUMENT
        {
            public static string ID = "ID";
            public static string MASTERID = "MASTERID";

            public static string EXPIRYDATE = "ExpiryDate";

            public static string DOCUMENTTITLEID = "DOCUMENTTITLEID";

            public static string DOCUMENTTITLE = "Document Title";
            public static string FILENAME = "File Name";

            public static string FROMFULLPATH = "FULLPATH";

            public static string FULLPATH = "FULLPATH";
            public static string BADGENUMBER = "BADGENUMBER";
            public static string IssueDate = "IssueDate";
            public static string Note = "Note";

            public static string IsCompleted = "IsCompleted";

        }

        public struct COL_ROUTEHISTORY
        {
            public static string ID = "ID";
            public static string ESCORTID = "ESCORTID";
            public static string ASSIGNEDDATE = "ASSIGNEDDATE";
            public static string ENDDATE = "ENDDATE";
            public static string NOTEBOX = "NOTEBOX";

        }

        public struct COL_INCIDENTLOG
        {
            public static string ID = "ID";
            public static string ESCORTID = "ESCORTID";
            public static string DATE = "Date";
            public static string INCIDENTREPORT = "INCIDENTREPORT";
            public static string NATUREOFINCIDENT = "NATUREOFINCIDENT";

        }

        private int _MapType;

        private bool _IsActive;
        public int MapType
        {
            get { return _MapType; }
            set { _MapType = value; }
        }

        private void FillDBSType()
        {
            ddlDBSType.Items.Clear();
            ddlDBSType.Items.Add("Enhanced");
            ddlDBSType.Items.Add("Standard");
            ComboFunctions.FillEscortTrainingDocumentTypeCombo(ddlTrainingType);
        }

        public frmEscort()
        {
          

            InitializeComponent();
            InitializeConstructor();
            FormatDocumentsGrid();
            FormatLicenseDetailDocumentsGrid();
            FormatIncidentLogGrid();
            FormatRouteHistoryGrid();
            txtAddress1.ListBoxElement.Width = 500;
            txtAddress1.ListBoxElement.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtAddress1.DefaultHeight = 250;

            dtpInductionDate.Value = DateTime.Now.ToDate();

            txtAddress1.TextChanged += new EventHandler(TextBoxElement_TextChanged);
            txtAddress1.KeyPress += new KeyPressEventHandler(txtAddress_KeyPress);
            this.btnPreview.Click+=new EventHandler(btnPreview_Click);
            this.btnClear.Click+=new EventHandler(btnClear_Click);
            this.btnAddTraning.Click += new EventHandler(btnAddTraning_Click);
            this.grdDocuments.CellBeginEdit += new GridViewCellCancelEventHandler(grdDocuments_CellBeginEdit);
            this.btnClearIncident.Click += new EventHandler(btnClearIncident_Click);
            this.btnAddRoute.Click += new EventHandler(btnAddRoute_Click);
            this.btnNewRoute.Click += new EventHandler(btnNewRoute_Click);
            FillDBSType();
        
           //this.Text = "Escort";
          
        }

        private void AddRoute()
        {
            try
            {
                string Error = "";
                int TraningTypeId = ddlTrainingType.SelectedValue.ToInt();
                DateTime? dtpAssignedTime = dtpAssignedDate.Value.ToDateorNull();
                DateTime? dtpEndTime = dtpEndDate.Value.ToDateorNull();
                string NotesBox = txtNoteBox.Text.Trim();
                              
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

               
                GridViewRowInfo row;
                row = grdRouteHistory.Rows.AddNew();

                row.Cells[COL_ROUTEHISTORY.ASSIGNEDDATE].Value = dtpAssignedTime;
                row.Cells[COL_ROUTEHISTORY.ENDDATE].Value = dtpEndTime;
                row.Cells[COL_ROUTEHISTORY.NOTEBOX].Value = NotesBox;

                txtNoteBox.Text = string.Empty;
                dtpAssignedDate.Value = null;
                dtpEndDate.Value = null;
               

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        void btnNewRoute_Click(object sender, EventArgs e)
        {
            txtNoteBox.Text = string.Empty;
            dtpAssignedDate.Value = null;
            dtpEndDate.Value = null;
        }

        void btnAddRoute_Click(object sender, EventArgs e)
        {
            AddRoute();
        }

        void btnClearIncident_Click(object sender, EventArgs e)
        {
            grd_IncidentLog.CurrentRow = null;
            ClearDocument("");
            txt_NatureOfIncident.Text = string.Empty;
            dp_IncidentLog.Value = null;
            dp_IncidentLog.Focus();
        }

        void grdDocuments_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column != null && e.Column.HeaderText == "End Date")
            {
                e.Row.Cells[COL_DOCUMENT.IsCompleted].ReadOnly = false;

            }
        }

        void btnAddTraning_Click(object sender, EventArgs e)
        {
            AddTraning();
        }
        private void AddTraning()
        {
            try
            {
                string Error = "";
                int TraningTypeId = ddlTrainingType.SelectedValue.ToInt();
                DateTime? dtTraningStart = dtpTrainingStartDate.Value.ToDateorNull();
                DateTime? dtTraningEnd = dtpTrainingEndDate.Value.ToDateorNull();
                string TraningNotes = txtTraningNotes.Text.Trim();
                string TrainingType = ddlTrainingType.Text;


                //  rowNote.Cells[COL_DOCUMENT.MASTERID].Value = objAvail.EscortId;

                if (TraningTypeId == 0)
                {
                    Error = "Required : Training Type";
                }
                if (dtTraningStart == null)
                {
                    if (!string.IsNullOrEmpty(Error))
                    {
                        Error += Environment.NewLine + "Required : Training Start Date";
                    }
                    else
                    {
                        Error = "Required : Training Start Date";
                    }
                }



                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }

                if (grdDocuments.Rows.Count(c => c.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == TraningTypeId && c.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull() == null
                                                            ) > 0)
                {
                    ENUtils.ShowMessage("Previous " + TrainingType + " is not completed");

                    return;

                }
                GridViewRowInfo row;
                row = grdDocuments.Rows.AddNew();

                row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value = TraningTypeId;
                row.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value = TrainingType;
                row.Cells[COL_DOCUMENT.IssueDate].Value = dtTraningStart;
                row.Cells[COL_DOCUMENT.EXPIRYDATE].Value = dtTraningEnd;
                row.Cells[COL_DOCUMENT.Note].Value = TraningNotes;
                if (dtTraningEnd == null)
                {
                    row.Cells[COL_DOCUMENT.IsCompleted].ReadOnly = true;
                }
                else
                {
                    row.Cells[COL_DOCUMENT.IsCompleted].ReadOnly = false;
                }

                ddlTrainingType.SelectedValue = null;
                dtpTrainingEndDate.Value = null;
                dtpTrainingStartDate.Value = null;
                txtTraningNotes.Text = "";
                ddlTrainingType.Focus();

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }
        //private void AddTraning()
        //{
        //    try
            
        //    {
        //        string Error = "";
        //        int TraningTypeId = ddlTrainingType.SelectedValue.ToInt();
        //        DateTime ?  dtTraningStart=dtpTrainingStartDate.Value.ToDateorNull();
        //        DateTime? dtTraningEnd = dtpTrainingEndDate.Value.ToDateorNull();
        //        string TraningNotes = txtTraningNotes.Text.Trim();
        //        string TrainingType= ddlTrainingType.Text;


        //        //  rowNote.Cells[COL_DOCUMENT.MASTERID].Value = objAvail.EscortId;

        //        if (TraningTypeId == 0)
        //        {
        //            Error = "Required : Training Type";
        //        }
        //        if (dtTraningStart == null)
        //        {
        //            if (!string.IsNullOrEmpty(Error))
        //            {
        //                Error += Environment.NewLine + "Required : Training Start Date";
        //            }
        //            else
        //            {
        //                Error = "Required : Training Start Date";
        //            }
        //        }
             

                
        //        if (!string.IsNullOrEmpty(Error))
        //        {
        //            ENUtils.ShowMessage(Error);
        //            return;
        //        }

        //        if (grdDocuments.Rows.Count(c =>c.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == TraningTypeId && c.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull() == null
        //                                                    ) > 0)
        //        {
        //            ENUtils.ShowMessage("Previous "+TrainingType+ " is not completed");
                   
        //            return;

        //        }
        //        GridViewRowInfo row;
        //            row = grdDocuments.Rows.AddNew();

        //            row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value = TraningTypeId;
        //            row.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value = TrainingType;
        //            row.Cells[COL_DOCUMENT.IssueDate].Value = dtTraningStart;
        //            row.Cells[COL_DOCUMENT.EXPIRYDATE].Value = dtTraningEnd;
        //            row.Cells[COL_DOCUMENT.Note].Value = TraningNotes;
        //            ddlTrainingType.SelectedValue = null;
        //            dtpTrainingEndDate.Value = null;
        //            dtpTrainingStartDate.Value = null;
        //            txtTraningNotes.Text = "";
        //            ddlTrainingType.Focus();

        //    }
        //    catch (Exception ex)
        //    {
        //        ENUtils.ShowMessage(ex.Message);
        //    }
        //}

        private void FormatDocumentsGrid()
        {
            grdDocuments.AllowAutoSizeColumns = true;
            grdDocuments.AllowAddNewRow = false;
            this.grdDocuments.AllowCellContextMenu = false;
            grdDocuments.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;


            grdDocuments.CommandCellClick += new CommandCellClickEventHandler(grdDocuments_CommandCellClick);


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.ID;
            grdDocuments.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.MASTERID;
            grdDocuments.Columns.Add(col);

            //IsCompleted
            GridViewCheckBoxColumn cbcol=new GridViewCheckBoxColumn ();
            cbcol.Name=COL_DOCUMENT.IsCompleted;
            cbcol.Width=50;
            cbcol.HeaderText="Completed";
            grdDocuments.Columns.Add(cbcol);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.FULLPATH;
            grdDocuments.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.DOCUMENTTITLEID;
            grdDocuments.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Training Type";
            col.Width = 100;
            col.ReadOnly = true;
            col.Name = COL_DOCUMENT.DOCUMENTTITLE;
            grdDocuments.Columns.Add(col);

            GridViewDateTimeColumn colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "Start Date";
            colDate.Name = COL_DOCUMENT.IssueDate;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy";
            colDate.FormatString = "{0:dd/MM/yyyy}";
            colDate.Width = 50;
            colDate.ReadOnly = false;
            grdDocuments.Columns.Add(colDate);

            colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "End Date";
            colDate.Name = COL_DOCUMENT.EXPIRYDATE;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy";
            colDate.FormatString = "{0:dd/MM/yyyy}";
            colDate.Width = 50;
            colDate.ReadOnly = false;
            grdDocuments.Columns.Add(colDate);

           

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Badge #";
            col.Width = 60;
            col.IsVisible = false;
            col.ReadOnly = true;
            col.Name = COL_DOCUMENT.BADGENUMBER;
            grdDocuments.Columns.Add(col);


          

            col = new GridViewTextBoxColumn();
            col.HeaderText = COL_DOCUMENT.FILENAME;
            col.Width = 70;
            col.ReadOnly = true;
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.FILENAME;
            grdDocuments.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Note";
            col.Width = 180;
            col.ReadOnly = false;
            col.Name = COL_DOCUMENT.Note;
            grdDocuments.Columns.Add(col);

            GridViewCommandColumn col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 30;
            col2.UseDefaultText = true;
            col2.DefaultText = "Delete";
            col2.Name = "btnDelete";
            grdDocuments.Columns.Add(col2);

            //col2.HeaderText = "";
            //col2.Width = 30;
            //col2.UseDefaultText = true;
            //col2.DefaultText = "Clear";
            //col2.Name = "Clear";
            //grdDocuments.Columns.Add(col2);



            //col2 = new GridViewCommandColumn();
            //col2.HeaderText = "";
            //col2.Width = 40;
            //col2.UseDefaultText = true;
            //col2.DefaultText = "Browse";
            //col2.Name = "Load";
            //grdDocuments.Columns.Add(col2);

            //col2 = new GridViewCommandColumn();
            //col2.HeaderText = "";
            //col2.Width = 30;
            //col2.UseDefaultText = true;
            //col2.DefaultText = "View";
            //col2.Name = "View";
            //grdDocuments.Columns.Add(col2);


            //OnNewDocuments();


            grdDocuments.AllowEditRow = true;

        }

        private void FormatRouteHistoryGrid()
        {
            grdRouteHistory.AllowAutoSizeColumns = true;
            grdRouteHistory.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            grdRouteHistory.CommandCellClick += new CommandCellClickEventHandler(grdRouteHistory_CommandCellClick);
            grdRouteHistory.CellDoubleClick += new GridViewCellEventHandler(grdRouteHistory_CellDoubleClick);
            grdRouteHistory.ViewCellFormatting += new CellFormattingEventHandler(grdRouteHistory_ViewCellFormatting);
            //grdDocuments.CommandCellClick += new CommandCellClickEventHandler(grdDocuments_CommandCellClick);

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_ROUTEHISTORY.ID;
            grdRouteHistory.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_ROUTEHISTORY.ESCORTID;
            grdRouteHistory.Columns.Add(col);

            GridViewDateTimeColumn colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "Assigned Date";
            colDate.Name = COL_ROUTEHISTORY.ASSIGNEDDATE;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy";
            colDate.FormatString = "{0:dd/MM/yyyy}";
            colDate.Width = 40;
            col.ReadOnly = false;
            grdRouteHistory.Columns.Add(colDate);

            colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "End Date";
            colDate.Name = COL_ROUTEHISTORY.ENDDATE;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy";
            colDate.FormatString = "{0:dd/MM/yyyy}";
            colDate.Width = 40;
            col.ReadOnly = false;
            grdRouteHistory.Columns.Add(colDate);

            col = new GridViewTextBoxColumn();
            col.HeaderText = COL_ROUTEHISTORY.NOTEBOX;
            col.Width = 100;
            col.ReadOnly = false;
            col.Name = COL_ROUTEHISTORY.NOTEBOX;
            grdRouteHistory.Columns.Add(col);

            GridViewCommandColumn  col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 40;
            col2.UseDefaultText = true;
            col2.DefaultText = "Delete";
            col2.Name = "ColDelete";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            grdRouteHistory.Columns.Add(col2);
                   
        }

        void grdRouteHistory_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridDataCellElement)
            {


                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    // This is how we get the RadButtonElement instance from the cell
                    button = (RadButtonElement)e.CellElement.Children[0];
                    if (button.Text == "Delete")
                    {
                        button.TextAlignment = ContentAlignment.MiddleCenter;
                        button.Image = Resources.Resource1.delete;

                    }
                }
            }
        }

        void grdRouteHistory_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //if (grdRouteHistory.CurrentRow != null && grdRouteHistory.CurrentRow is GridViewDataRowInfo)
            //{
            //    GridViewRowInfo row = grdRouteHistory.CurrentRow;
            //    dtpAssignedDate.Value = row.Cells[COL_ROUTEHISTORY.ASSIGNEDDATE].Value.ToDateorNull();
            //    dtpEndDate.Value = row.Cells[COL_ROUTEHISTORY.ENDDATE].Value.ToDateorNull();
            //    txtNoteBox.Text = row.Cells[COL_ROUTEHISTORY.NOTEBOX].Value.ToStr();
            //}
        }

        void grdRouteHistory_CommandCellClick(object sender, EventArgs e)
        {
            string colName = grdRouteHistory.CurrentColumn.Name;
            GridViewRowInfo row = grdRouteHistory.CurrentRow;

            if (colName == "Edit")
            {
                ClearDocument(row);
            }
            else if (colName == "View")
            {
                ViewDocumentIncidentLog(row);

            }
            else if (colName == "ColDelete")
            {
                grdRouteHistory.CurrentRow.Delete();
                grdRouteHistory.CurrentRow = null;
            }
        }

        private void PopulateRouteHistoryDetails()
        {
            grdRouteHistory.Rows.Clear();

            if (objMaster != null)
            {
                GridViewRowInfo row = null;


                foreach (var item in General.GetQueryable<Gen_Escort_RouteHistory>(c => c.EscortId == objMaster.Current.Id))
                {
                    row = grdRouteHistory.Rows.AddNew();

                    row.Cells[COL_ROUTEHISTORY.ID].Value = item.Id;
                    row.Cells[COL_ROUTEHISTORY.ESCORTID].Value = item.EscortId;
                     row.Cells[COL_ROUTEHISTORY.ASSIGNEDDATE].Value = item.AssignedDate.ToDateTimeorNull();
                     row.Cells[COL_ROUTEHISTORY.ENDDATE].Value = item.EndDate.ToDateTimeorNull();
                     row.Cells[COL_ROUTEHISTORY.NOTEBOX].Value = item.NoteBox;

                }
            }
           
        }

        private void FormatIncidentLogGrid()
        {
            grd_IncidentLog.AllowAutoSizeColumns = true;
            grd_IncidentLog.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            grd_IncidentLog.CommandCellClick+=new CommandCellClickEventHandler(grd_IncidentLog_CommandCellClick);
            grd_IncidentLog.CellDoubleClick += new GridViewCellEventHandler(grd_IncidentLog_CellDoubleClick);
            grd_IncidentLog.ViewCellFormatting += new CellFormattingEventHandler(grd_IncidentLog_ViewCellFormatting);
            //grdDocuments.CommandCellClick += new CommandCellClickEventHandler(grdDocuments_CommandCellClick);


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_INCIDENTLOG.ID;
            grd_IncidentLog.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_INCIDENTLOG.ESCORTID;
            grd_IncidentLog.Columns.Add(col);


            GridViewDateTimeColumn colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "Date";
            colDate.Name = COL_INCIDENTLOG.DATE;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy";
            colDate.FormatString = "{0:dd/MM/yyyy}";
            colDate.Width = 40;
            col.ReadOnly = false;
            grd_IncidentLog.Columns.Add(colDate);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Incident Report";
            col.Width = 100;
            col.ReadOnly = false;
            col.Name = COL_INCIDENTLOG.INCIDENTREPORT;
            grd_IncidentLog.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Nature Of Incident";
            col.Width = 150;
            col.ReadOnly = false;
            col.Name = COL_INCIDENTLOG.NATUREOFINCIDENT;
            grd_IncidentLog.Columns.Add(col);

            GridViewCommandColumn col2 = new GridViewCommandColumn();
            ////col2.HeaderText = "";
            col2.Width = 30;
            col2.UseDefaultText = true;
            col2.DefaultText = "Edit";
            col2.Name = "Edit";
            col2.IsVisible = false;
            grd_IncidentLog.Columns.Add(col2);

            col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 40;
            col2.UseDefaultText = true;
            col2.DefaultText = "View";
            col2.Name = "View";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            grd_IncidentLog.Columns.Add(col2);



            col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 40;
            col2.UseDefaultText = true;
            col2.DefaultText = "Delete";
            col2.Name = "ColDelete";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            grd_IncidentLog.Columns.Add(col2);

            //UI.GridFunctions.AddDeleteColumn(grd_IncidentLog);
            //grd_IncidentLog.Columns["ColDelete"].Width = 40;

           

            UI.GridFunctions.SetFilter(grd_IncidentLog);


            //grd_IncidentLog.AllowEditRow = true;

        }
        RadButtonElement button = null;
        void grd_IncidentLog_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridDataCellElement)
            {

                
                if (e.CellElement.ColumnInfo is GridViewCommandColumn)
                {
                    // This is how we get the RadButtonElement instance from the cell
                    button = (RadButtonElement)e.CellElement.Children[0];
                    if (button.Text == "Delete")
                    {
                        button.TextAlignment = ContentAlignment.MiddleCenter;
                        button.Image = Resources.Resource1.delete;

                    }
                }
            }
        }

        void grd_IncidentLog_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (grd_IncidentLog.CurrentRow != null && grd_IncidentLog.CurrentRow is GridViewDataRowInfo)
            {
                GridViewRowInfo row = grd_IncidentLog.CurrentRow;
                dp_IncidentLog.Value = row.Cells[COL_INCIDENTLOG.DATE].Value.ToDateorNull();
                txtIncidentLogDocPath.Text = row.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value.ToStr();
                txt_NatureOfIncident.Text = row.Cells[COL_INCIDENTLOG.NATUREOFINCIDENT].Value.ToStr();
            }
            
        }

        private void EditIncident(string Path,string NatureofInci)
        {
           
        }

       
        private void InitializeConstructor()
        {

            objMaster = new Gen_EscortBO();
            this.SetProperties((INavigation)objMaster);



            timer1.Tick += new EventHandler(timer1_Tick);

            txtAddress1.ListBoxElement.Width = 400;
            //txtAddress2.ListBoxElement.Width = 400;

            this.Shown += new EventHandler(frmCustomer_Shown);            
        }

        void frmCustomer_Shown(object sender, EventArgs e)
        {
            txtEscortName.Focus();
          
        }

        #region Overridden Methods


        public override void AddNew()
        {
            OnNew();
        }

        public override void OnNew()
        {
            objMaster.Clear();
            txtEscortNo.Text = "";
            txtEscortName.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtAddress1.Text = "";
            pic_Escort.Image = null;
            pic_Passport.Image = null;
            dtp_DateOfBirth.Value = null;
            dtp_EndDate.Value = null;
            dtp_StartDate.Value = null;
            grdDocuments.Rows.Clear();
            txt_Surname.Text = "";
            OnNewDocuments();
            txtEscortName.Focus();
            dp_IncidentLog.Value = null;
            txtIncidentLogDocPath.Text = "";
            txt_NatureOfIncident.Text = "";
            txtDBSNote.Text = "";
            dtpDBSExpiryDate.Value = null;
            dtpDBSIssueDate.Value = null;
            txtDBSNumber.Text = "";
            txtFilePath.Text = "";
            txtSortCode.Text ="";
            txtAccountNo.Text = "";
            txtAccountTitle.Text = "";
            txtBank.Text = "";
            txtCompanyNumber.Text = "";
            txtVATNumber.Text = "";
            txtIBAN.Text = "";
            txtBLC.Text = "";
            ddlDBSType.SelectedIndex = -1;
            txtPathProofofAddress.Text = "";
            chkAutoSMS.Checked = false;
            numAutoSMSDays.Value = 0;
            grd_IncidentLog.Rows.Clear();
        }

        private void ViewDocument(string path)
        {

            string fullDirectoryPath = "";
            DirectoryInfo di = null;


            try
            {

                if (path.ToStr() != string.Empty)
                {
                    fullDirectoryPath = path.ToStr();

                    if (File.Exists(fullDirectoryPath))
                    {

                        di = new DirectoryInfo(fullDirectoryPath);

                        System.Diagnostics.Process.Start(di.FullName);
                    }
                    else
                    {
                        if (fullDirectoryPath.ToStr().StartsWith("http:"))
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

        private void FormatLicenseDetailDocumentsGrid()
        {
            grdLicenseDetail.AllowAutoSizeColumns = true;
            grdLicenseDetail.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;


            grdLicenseDetail.CommandCellClick += new CommandCellClickEventHandler(grdLicenseDetail_CommandCellClick);


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.ID;
            grdLicenseDetail.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.MASTERID;
            grdLicenseDetail.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.FULLPATH;
            grdLicenseDetail.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COL_DOCUMENT.DOCUMENTTITLEID;
            grdLicenseDetail.Columns.Add(col);

            GridViewDateTimeColumn colDate = new GridViewDateTimeColumn();
            colDate.HeaderText = "Expiry Date";
            colDate.Name = COL_DOCUMENT.EXPIRYDATE;
            // colDate.Format = DateTimePickerFormat.Custom;
            colDate.CustomFormat = "dd/MM/yyyy HH:mm";
            colDate.FormatString = "{0:dd/MM/yyyy HH:mm}";
            colDate.Width = 105;
            col.ReadOnly = false;
            grdLicenseDetail.Columns.Add(colDate);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COL_DOCUMENT.DOCUMENTTITLE;
            col.Width = 75;
            col.ReadOnly = true;
            col.Name = COL_DOCUMENT.DOCUMENTTITLE;
            grdLicenseDetail.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COL_DOCUMENT.FILENAME;
            col.Width = 50;
            col.ReadOnly = true;
            col.Name = COL_DOCUMENT.FILENAME;
            grdLicenseDetail.Columns.Add(col);


            GridViewCommandColumn col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 30;
            col2.UseDefaultText = true;
            col2.DefaultText = "Clear";
            col2.Name = "Clear";
            grdLicenseDetail.Columns.Add(col2);



            col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 40;
            col2.UseDefaultText = true;
            col2.DefaultText = "Browse";
            col2.Name = "Browse";
            grdLicenseDetail.Columns.Add(col2);

            col2 = new GridViewCommandColumn();
            col2.HeaderText = "";
            col2.Width = 30;
            col2.UseDefaultText = true;
            col2.DefaultText = "View";
            col2.Name = "View";
            grdLicenseDetail.Columns.Add(col2);


            OnNewDocumentsLicenseDetails();


            grdLicenseDetail.AllowEditRow = true;

        }

        private void LoadDocumentOnCloud(GridViewRowInfo row)
        {
            this.openFileDialog1.Filter = "Documents (All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {


                string fileName = openFileDialog1.SafeFileName;
                string filePath = openFileDialog1.FileName;


                string fileNamePrefix = txtEscortNo.Text.Trim();
                if (fileNamePrefix.Contains(" "))
                    fileNamePrefix = fileNamePrefix.Split(' ')[0];

                fileNamePrefix = fileNamePrefix + "_" + string.Format("{0:ddmmyyyyhhmmss}", DateTime.Now) + "_" + fileName;

                General.payload res = General.UploadEscortFile(fileNamePrefix, filePath);

                if (res.message.ToStr().ToUpper() == "SUCCESS")
                {
                    row.Cells[COL_DOCUMENT.FULLPATH].Value = res.filePath.ToStr().Trim().Replace("\"", "");
                    row.Cells[COL_DOCUMENT.FILENAME].Value = fileName;

                }
                else
                    MessageBox.Show(res.message);

            }



        }

        void grdLicenseDetail_CommandCellClick(object sender, EventArgs e)
        {
            string colName = grdLicenseDetail.CurrentColumn.Name;
            GridViewRowInfo row = grdLicenseDetail.CurrentRow;
            if (colName == "Clear")
            {
                ClearDocument(row);

            }
            else if (colName == "Browse")
            {
                if (
                  AppVars.listUserRights.Count(c => c.functionId == "UPLOAD DOCUMENT ON CLOUD") > 0)
                    LoadDocumentOnCloud(row);
                else
                    LoadDocument(row);
                //  LoadDocument(row);

            }
            else if (colName == "View")
            {
                ViewDocument(row);

            }
        }

        private void OnNewDocumentsLicenseDetails()
        {
            grdLicenseDetail.Rows.Clear();


            GridViewRowInfo row = null;

            foreach (var item in General.GetQueryable<Gen_Syspolicy_EscortDocumentList>(c => c.IsVisible == true))
            {
                row = grdLicenseDetail.Rows.AddNew();

                row.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value = item.DocumentName.ToStr();
                row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value = item.Id;

            }
        }

        string fullDirectoryPath = string.Empty;
        public bool Save()
        {

            bool rtn = true;

            if (txtPinCode.Text.Trim().Length > 0)
            {


                try
                {

                    int id = objMaster.PrimaryKeyValue.ToInt();
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        long cnt = 0;

                        if (id > 0)
                            cnt = db.ExecuteQuery<long>("select Id from gen_escort where pincode='" + txtPinCode.Text.Trim() + "' and id!=" + id).FirstOrDefault();
                        else
                            cnt = db.ExecuteQuery<long>("select Id from gen_escort where pincode='" + txtPinCode.Text.Trim() + "'").FirstOrDefault();


                        if (cnt > 0)
                        {
                            MessageBox.Show("This Pin Code is already used on other escort profile");
                            return false;


                        }


                    }
                }
                catch
                { }

            }

            try
            {
                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                    objMaster.Current.AddBy = AppVars.LoginObj.LuserId.ToInt();
                    objMaster.Current.AddLog = AppVars.LoginObj.UserName.ToStr();
                    objMaster.Current.AddOn = DateTime.Now.ToDateTime();
                }
                else
                {
                    objMaster.Edit();
                    objMaster.Current.EditBy = AppVars.LoginObj.LuserId.ToInt();
                    objMaster.Current.EditLog = AppVars.LoginObj.UserName.ToStr();
                    objMaster.Current.EditOn = DateTime.Now.ToDateTime();

                }

                objMaster.Current.EscortNo=txtEscortNo.Text.Trim();
                objMaster.Current.EscortName = txtEscortName.Text.Trim();
                objMaster.Current.Surname = txt_Surname.Text.Trim();
                objMaster.Current.DateOfBirth = dtp_DateOfBirth.Value.ToDateorNull();
                objMaster.Current.EmailAddress = txtEmail.Text.Trim();
                objMaster.Current.TelephoneNo = txtTelephoneNo.Text.Trim();
                objMaster.Current.NI = txtNi.Text.Trim();
                objMaster.Current.RouteNo = txtRouteNo.Text.Trim();
                objMaster.Current.MobileNo = txtMobileNo.Text.Trim();
                objMaster.Current.AddressLine1 = txtAddress1.Text.Trim();
                objMaster.Current.StartDate = dtp_StartDate.Value.ToDateorNull();
                objMaster.Current.EndDate = dtp_EndDate.Value.ToDateorNull();
                objMaster.Current.ProofofAddress = txtPathProofofAddress.Text.Trim();

                /////Bank Details
                if (objMaster.Current.Gen_Escort_BankDetails == null)
                    objMaster.Current.Gen_Escort_BankDetails = new Gen_Escort_BankDetail();

               
                objMaster.Current.Gen_Escort_BankDetails.SortCode = txtSortCode.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.AccountNo = txtAccountNo.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.AccountTitle = txtAccountTitle.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.BankName = txtBank.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.CompanyNumber = txtCompanyNumber.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.CompanyVatNumber = txtVATNumber.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.IbanNumber = txtIBAN.Text.Trim();
                objMaster.Current.Gen_Escort_BankDetails.BlcNumber = txtBLC.Text.Trim();


                foreach (var row in grdLicenseDetail.Rows)
                {
                    if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.BuccalTraining)
                    {
                        objMaster.Current.BuccalTraining = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateTimeorNull();

                    }
                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.DBSCheck)
                    {
                        objMaster.Current.DBSCheck = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }
                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.FirstAidTraining)
                    {
                        objMaster.Current.FirstAIDTraining = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }
                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.OtherTraining)
                    {
                        objMaster.Current.OtherTraining = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }


                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.PassportBiometric)
                    {
                        objMaster.Current.PassportBiometric = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }


                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.PATSTraining)
                    {
                        objMaster.Current.PATSTraining = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }

                    else if (row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt() == ESCORT_DOCUMENTS.SafeguardingTraining)
                    {
                        objMaster.Current.SafeguardTraining = row.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull();

                    }


                }

                ///////////////
                if (objMaster.Current.Gen_Escort_Images.Count == 0)
                {
                    objMaster.Current.Gen_Escort_Images.Add(new Gen_Escort_Image());
                    if (pic_Escort.Image != null)
                    {
                        objMaster.Current.Gen_Escort_Images[0].Photo = General.imageToByteArray(pic_Escort.Image);
                    }
                    else
                    {
                        objMaster.Current.Gen_Escort_Images[0].Photo = null;
                    }
                    if (pic_Passport.Image != null)
                    {
                        objMaster.Current.Gen_Escort_Images[0].Passport = General.imageToByteArray(pic_Passport.Image);
                    }
                    else
                    {
                        objMaster.Current.Gen_Escort_Images[0].Passport = null;
                    }
                }
                else 
                {
                    if (pic_Escort.Image != null)
                    {
                        objMaster.Current.Gen_Escort_Images[0].Photo = General.imageToByteArray(pic_Escort.Image);
                    }
                    else
                    {
                        objMaster.Current.Gen_Escort_Images[0].Photo = null;
                    }
                    if (pic_Passport.Image != null)
                    {
                        objMaster.Current.Gen_Escort_Images[0].Passport = General.imageToByteArray(pic_Passport.Image);
                    }
                    else
                    {
                        objMaster.Current.Gen_Escort_Images[0].Passport = null;
                    }
                }

              

                if (objMaster.Current.Gen_Escort_DBSChecks == null)
                    objMaster.Current.Gen_Escort_DBSChecks = new Gen_Escort_DBSCheck();


                objMaster.Current.Gen_Escort_DBSChecks.DBSType = ddlDBSType.Text.Trim(); //txt_SIM_IMEI.Text.Trim();
                objMaster.Current.Gen_Escort_DBSChecks.FilePath = txtFilePath.Text.Trim();
                objMaster.Current.Gen_Escort_DBSChecks.DBSNumber = txtDBSNumber.Text.Trim();
                objMaster.Current.Gen_Escort_DBSChecks.DBSIssueDate = dtpDBSIssueDate.Value.ToDateorNull();
                objMaster.Current.Gen_Escort_DBSChecks.DBSExpiryDate = dtpDBSExpiryDate.Value.ToDateorNull();
                objMaster.Current.Gen_Escort_DBSChecks.DBSNote = txtDBSNote.Text.Trim();
                objMaster.Current.Gen_Escort_DBSChecks.AutoSMS = true; //chkAutoSMS.Checked.ToBool();
                objMaster.Current.Gen_Escort_DBSChecks.AutoSMSDays = 2;// numAutoSMSDays.Value.ToInt();



                if (objMaster.Current.Gen_Escort_Details == null)
                    objMaster.Current.Gen_Escort_Details = new Gen_Escort_Detail();

                objMaster.Current.Gen_Escort_Details.CompanyName = txtCompanyName.Text.Trim(); //txt_SIM_IMEI.Text.Trim();
                objMaster.Current.Gen_Escort_Details.CompanyAddress = txtCompanyAddress.Text.Trim();
                objMaster.Current.Gen_Escort_Details.CompanyTelephoneNo = txtCompanyTelNo.Text.Trim();
                objMaster.Current.Gen_Escort_Details.EmailAddress = txtCompanyEmail.Text.Trim();
                objMaster.Current.Gen_Escort_Details.InductionDate = dtpInductionDate.Value.ToDateorNull();

                if (rdYes.IsChecked == true)
                {
                    objMaster.Current.Gen_Escort_Details.IsInduction = true;
                }
                else
                {
                    objMaster.Current.Gen_Escort_Details.IsInduction = false;
                }


                bool uploadOnCloud = AppVars.listUserRights.Count(c => c.functionId == "UPLOAD DOCUMENT ON CLOUD") > 0 ? true : false;


                string[] skipProperties = { "Gen_Escort"};
                IList<Gen_Escort_Training> savedList = objMaster.Current.Gen_Escort_Trainings;
                List<Gen_Escort_Training> listofDetail = (from r in grdDocuments.Rows
                                                            //where r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr()!=string.Empty
                                                          select new Gen_Escort_Training
                                                            {
                                                                Id = r.Cells[COL_DOCUMENT.ID].Value.ToLong(),
                                                                EscortId = r.Cells[COL_DOCUMENT.MASTERID].Value.ToInt(),
                                                                DocumentId = r.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToIntorNull(),
                                                                DocumentName = r.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value.ToStr(),
                                                                ExpiryDate = r.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull(),
                                                                FileName = r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr(),
                                                               FilePath = fullDirectoryPath + "\\" + r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr(),
                                                            
                                                              BadgeNumber = r.Cells[COL_DOCUMENT.BADGENUMBER].Value.ToStr(),
                                                                IssueDate = r.Cells[COL_DOCUMENT.IssueDate].Value.ToDateorNull(),
                                                                Note = r.Cells[COL_DOCUMENT.Note].Value.ToStr(),
                                                                IsCompleted= r.Cells[COL_DOCUMENT.IsCompleted].Value.ToBool(),
                                                            }).ToList();


               

                Utils.General.SyncChildCollection(ref savedList, ref listofDetail, "Id", skipProperties);

                IList<Gen_Escort_Document> savedListx = objMaster.Current.Gen_Escort_Documents;
                List<Gen_Escort_Document> listofDetailx = (from r in grdLicenseDetail.Rows
                                                           
                                                            select new Gen_Escort_Document
                                                            {
                                                                Id = r.Cells[COL_DOCUMENT.ID].Value.ToLong(),
                                                                EscortId = r.Cells[COL_DOCUMENT.MASTERID].Value.ToInt(),
                                                                DocumentId = r.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToIntorNull(),
                                                                DocumentName = r.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value.ToStr(),
                                                                ExpiryDate = r.Cells[COL_DOCUMENT.EXPIRYDATE].Value.ToDateorNull(),
                                                                FileName = r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr(),
                                                                // FilePath = fullDirectoryPath + "\\" + r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr()
                                                                FilePath = uploadOnCloud ? r.Cells[COL_DOCUMENT.FULLPATH].Value.ToStr() : fullDirectoryPath + "\\" + r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr(),

                                                            }).ToList();

                Utils.General.SyncChildCollection(ref savedListx, ref listofDetailx, "Id", skipProperties);


                IList<Gen_Escort_RouteHistory> savedListRoute = objMaster.Current.Gen_Escort_RouteHistories;
                List<Gen_Escort_RouteHistory> listofDetailRoute = (from r in grdRouteHistory.Rows

                                                               select new Gen_Escort_RouteHistory
                                                           {
                                                               Id = r.Cells[COL_ROUTEHISTORY.ID].Value.ToLong(),
                                                               EscortId = r.Cells[COL_ROUTEHISTORY.ESCORTID].Value.ToInt(),
                                                               AssignedDate = r.Cells[COL_ROUTEHISTORY.ASSIGNEDDATE].Value.ToDateorNull(),
                                                               EndDate = r.Cells[COL_ROUTEHISTORY.ENDDATE].Value.ToDateorNull(),
                                                               NoteBox = r.Cells[COL_ROUTEHISTORY.NOTEBOX].Value.ToStr(),
                                                               

                                                           }).ToList();

                Utils.General.SyncChildCollection(ref savedListRoute, ref listofDetailRoute, "Id", skipProperties);


                IList<Gen_Escort_IncidentLog> savedList1 = objMaster.Current.Gen_Escort_IncidentLogs;
                List<Gen_Escort_IncidentLog> listofDetail1 = (from r in grd_IncidentLog.Rows
                                                          //where r.Cells[COL_DOCUMENT.FILENAME].Value.ToStr()!=string.Empty
                                                              select new Gen_Escort_IncidentLog
                                                          {
                                                              Id = r.Cells[COL_INCIDENTLOG.ID].Value.ToLong(),
                                                              EscortId = r.Cells[COL_INCIDENTLOG.ESCORTID].Value.ToInt(),
                                                              Upload = r.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value.ToStr(),
                                                              NatureofIncident = r.Cells[COL_INCIDENTLOG.NATUREOFINCIDENT].Value.ToStr(),
                                                              Date = r.Cells[COL_INCIDENTLOG.DATE].Value.ToDateorNull(),
                                                              
                                                          }).ToList();

                Utils.General.SyncChildCollection(ref savedList1, ref listofDetail1, "Id", skipProperties);



                objMaster.Save();

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        db.ExecuteQuery<int>("update gen_escort set pincode='" + txtPinCode.Text.Trim() + "' where id=" + objMaster.Current.Id);
                        db.ExecuteQuery<int>("update gen_escort set IsActive='" + _IsActive + "' where id=" + objMaster.Current.Id);
                        txtPinCode.Text = string.Empty;
                        chkActive.Checked = false;
                    }
                }
                catch
                {


                }
                General.RefreshListWithoutSelected<frmEscortList>("frmEscortList1");
               
               


              
            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }

                rtn = false;
            }

            return rtn;

        }


        public struct ESCORT_DOCUMENTS
        {
            public static int DBSCheck = 1;
            public static int PassportBiometric = 2;
            public static int SafeguardingTraining = 3;
            public static int PATSTraining = 4;
            public static int BuccalTraining = 5;
            public static int FirstAidTraining = 6;
            public static int OtherTraining = 7;


        }

        public override void DisplayRecord()
        {
            try
            {
                if (objMaster.Current == null) return;

                txtEscortNo.Text = objMaster.Current.EscortNo.ToStr();
                txtEscortName.Text = objMaster.Current.EscortName.ToStr();
                txt_Surname.Text = objMaster.Current.Surname.ToStr();
                dtp_DateOfBirth.Value = objMaster.Current.DateOfBirth;
                txtEmail.Text = objMaster.Current.EmailAddress.ToStr();
                txtTelephoneNo.Text = objMaster.Current.TelephoneNo.ToStr();
                txtMobileNo.Text = objMaster.Current.MobileNo.ToStr();
                txtNi.Text = objMaster.Current.NI.ToStr();
                txtRouteNo.Text = objMaster.Current.RouteNo.ToStr();
                txtPathProofofAddress.Text= objMaster.Current.ProofofAddress  ;
                txtAddress1.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtAddress1.Text = objMaster.Current.AddressLine1.ToStr();
                txtAddress1.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                /////Bank Details
                if(objMaster.Current.Gen_Escort_BankDetails != null)
                {
                txtSortCode.Text = objMaster.Current.Gen_Escort_BankDetails.SortCode.ToStr();
                txtAccountNo.Text = objMaster.Current.Gen_Escort_BankDetails.AccountNo.ToStr();
                txtAccountTitle.Text = objMaster.Current.Gen_Escort_BankDetails.AccountTitle.ToStr();
                txtBank.Text = objMaster.Current.Gen_Escort_BankDetails.BankName.ToStr();
                txtCompanyNumber.Text = objMaster.Current.Gen_Escort_BankDetails.CompanyNumber.ToStr().Trim();
                txtVATNumber.Text = objMaster.Current.Gen_Escort_BankDetails.CompanyVatNumber.ToStr().Trim();
                txtBLC.Text = objMaster.Current.Gen_Escort_BankDetails.BlcNumber.ToStr().Trim();
                txtIBAN.Text = objMaster.Current.Gen_Escort_BankDetails.IbanNumber.ToStr().Trim();
                }
                ///////////////

                dtp_StartDate.Value = objMaster.Current.StartDate;
                dtp_EndDate.Value = objMaster.Current.EndDate;
                //

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        this._IsActive = (bool)db.ExecuteQuery<bool>("select IsActive from gen_escort where id=" + objMaster.Current.Id).First();
                        if (_IsActive)
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
                        }
                    }
                }
                catch
                {


                }

                if (objMaster.Current.Gen_Escort_Images.Count > 0)
                {
                    if (objMaster.Current.Gen_Escort_Images[0].Photo != null && objMaster.Current.Gen_Escort_Images[0].Photo.Length > 0)
                        pic_Escort.Image = General.byteArrayToImage(objMaster.Current.Gen_Escort_Images[0].Photo.ToArray());
                    else
                        pic_Escort.Image = null;


                    if (objMaster.Current.Gen_Escort_Images[0].Passport != null && objMaster.Current.Gen_Escort_Images[0].Passport.Length > 0)
                        pic_Passport.Image = General.byteArrayToImage(objMaster.Current.Gen_Escort_Images[0].Passport.ToArray());
                    else
                        pic_Passport.Image = null;
                }

                grd_IncidentLog.Rows.Clear();
                GridViewRowInfo row = null;
                foreach (var objAvail in objMaster.Current.Gen_Escort_IncidentLogs)
                {
                    row = grd_IncidentLog.Rows.AddNew();
                    row.Cells[COL_INCIDENTLOG.ID].Value = objAvail.Id;
                    row.Cells[COL_INCIDENTLOG.ESCORTID].Value = objAvail.EscortId;

                    row.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value = objAvail.Upload;
                    row.Cells[COL_INCIDENTLOG.NATUREOFINCIDENT].Value = objAvail.NatureofIncident;
                    row.Cells[COL_INCIDENTLOG.DATE].Value = objAvail.Date;

                }
                grd_IncidentLog.CurrentRow = null;
                if (objMaster.Current.Gen_Escort_DBSChecks != null)
                {
                    ddlDBSType.Text = objMaster.Current.Gen_Escort_DBSChecks.DBSType; //txt_SIM_IMEI.Text.Trim();
                    txtFilePath.Text = objMaster.Current.Gen_Escort_DBSChecks.FilePath;
                    txtDBSNumber.Text = objMaster.Current.Gen_Escort_DBSChecks.DBSNumber;
                    dtpDBSIssueDate.Value = objMaster.Current.Gen_Escort_DBSChecks.DBSIssueDate;
                    dtpDBSExpiryDate.Value = objMaster.Current.Gen_Escort_DBSChecks.DBSExpiryDate;
                    txtDBSNote.Text = objMaster.Current.Gen_Escort_DBSChecks.DBSNote;
                    chkAutoSMS.Checked = objMaster.Current.Gen_Escort_DBSChecks.AutoSMS.ToBool();
                    numAutoSMSDays.Value = objMaster.Current.Gen_Escort_DBSChecks.AutoSMSDays.ToInt();
                }


                if (objMaster.Current.Gen_Escort_Details != null)
                {
                    txtCompanyName.Text = objMaster.Current.Gen_Escort_Details.CompanyName;
                    txtCompanyEmail.Text = objMaster.Current.Gen_Escort_Details.EmailAddress;
                    txtCompanyAddress.Text = objMaster.Current.Gen_Escort_Details.CompanyAddress;
                    txtCompanyTelNo.Text = objMaster.Current.Gen_Escort_Details.CompanyTelephoneNo;                    
                    dtpInductionDate.Value = objMaster.Current.Gen_Escort_Details.InductionDate.Value;

                    if (objMaster.Current.Gen_Escort_Details.IsInduction.ToBool())
                    {
                        rdYes.IsChecked = true;
                    }
                    else
                    {
                        rdYes.IsChecked = false;
                    }
                }


                if (objMaster.Current.Gen_Escort_RouteHistories.Count > 0)
                {
                    grdRouteHistory.Rows.Clear();
                    GridViewRowInfo rowNote = null;
                    foreach (var objRoute in objMaster.Current.Gen_Escort_RouteHistories)
                    {
                        rowNote = grdRouteHistory.Rows.AddNew();
                        rowNote.Cells[COL_ROUTEHISTORY.ID].Value = objRoute.Id;
                        rowNote.Cells[COL_ROUTEHISTORY.ESCORTID].Value = objRoute.EscortId;

                        rowNote.Cells[COL_ROUTEHISTORY.ASSIGNEDDATE].Value = objRoute.AssignedDate.ToDateorNull(); ;
                        rowNote.Cells[COL_ROUTEHISTORY.ENDDATE].Value = objRoute.EndDate.ToDateorNull(); 
                        rowNote.Cells[COL_ROUTEHISTORY.NOTEBOX].Value = objRoute.NoteBox.ToStr().Trim();
                    }
                }

                if (objMaster.Current.Gen_Escort_Trainings.Count > 0)
                {
                    grdDocuments.Rows.Clear();
                    GridViewRowInfo rowNote = null;
                    foreach (var objAvail in objMaster.Current.Gen_Escort_Trainings)
                    {
                        rowNote = grdDocuments.Rows.AddNew();
                        rowNote.Cells[COL_DOCUMENT.ID].Value = objAvail.Id;
                        rowNote.Cells[COL_DOCUMENT.MASTERID].Value = objAvail.EscortId;

                        rowNote.Cells[COL_DOCUMENT.FILENAME].Value = objAvail.FileName;
                        rowNote.Cells[COL_DOCUMENT.FULLPATH].Value = objAvail.FilePath;

                        rowNote.Cells[COL_DOCUMENT.BADGENUMBER].Value = objAvail.BadgeNumber.ToStr().Trim();
                        rowNote.Cells[COL_DOCUMENT.IssueDate].Value = objAvail.IssueDate.ToDateorNull();
                        rowNote.Cells[COL_DOCUMENT.Note].Value = objAvail.Note;
                        rowNote.Cells[COL_DOCUMENT.EXPIRYDATE].Value = objAvail.ExpiryDate.ToDateorNull();

                        rowNote.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value = objAvail.DocumentId;
                        rowNote.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value = objAvail.DocumentName;
                        rowNote.Cells[COL_DOCUMENT.IsCompleted].Value = objAvail.IsCompleted.ToBool();
                        if (objAvail.ExpiryDate == null)
                        {
                            rowNote.Cells[COL_DOCUMENT.IsCompleted].ReadOnly = true;
                        }
                        else
                        {
                            rowNote.Cells[COL_DOCUMENT.IsCompleted].ReadOnly = false;

                        }
                    }
                }

                int titleId = 0;
                DateTime? dtExpiry = null;


                Gen_Escort_Document doc = null;
                foreach (GridViewRowInfo Grow in grdLicenseDetail.Rows)
                {

                    titleId = Grow.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value.ToInt();
                    if (titleId == ESCORT_DOCUMENTS.BuccalTraining)
                    {
                        dtExpiry = objMaster.Current.BuccalTraining;

                    }
                    else if (titleId == ESCORT_DOCUMENTS.DBSCheck)
                    {
                        dtExpiry = objMaster.Current.DBSCheck;

                    }
                    else if (titleId == ESCORT_DOCUMENTS.FirstAidTraining)
                    {
                        dtExpiry = objMaster.Current.FirstAIDTraining;

                    }

                    else if (titleId == ESCORT_DOCUMENTS.OtherTraining)
                    {
                        dtExpiry = objMaster.Current.OtherTraining;

                    }

                    else if (titleId == ESCORT_DOCUMENTS.PassportBiometric)
                    {
                        dtExpiry = objMaster.Current.PassportBiometric;

                    }

                    else if (titleId == ESCORT_DOCUMENTS.PATSTraining)
                    {
                        dtExpiry = objMaster.Current.PATSTraining;

                    }


                    else if (titleId == ESCORT_DOCUMENTS.SafeguardingTraining)
                    {
                        dtExpiry = objMaster.Current.SafeguardTraining;

                    }

                    Grow.Cells[COL_DOCUMENT.EXPIRYDATE].Value = dtExpiry;


                    doc = objMaster.Current.Gen_Escort_Documents.FirstOrDefault(c => c.DocumentId == titleId);

                    if (doc != null)
                    {


                        Grow.Cells[COL_DOCUMENT.ID].Value = doc.Id;
                        Grow.Cells[COL_DOCUMENT.MASTERID].Value = doc.EscortId;

                        Grow.Cells[COL_DOCUMENT.FILENAME].Value = doc.FileName;
                        Grow.Cells[COL_DOCUMENT.FULLPATH].Value = doc.FilePath;

                       
                    }
                }

                PopulateRouteHistoryDetails();
                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        txtPinCode.Text = db.ExecuteQuery<string>("select pincode from gen_escort where id=" + objMaster.Current.Id).FirstOrDefault();

                    }
                }
                catch
                {


                }
            }



            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

       

        #endregion

        //private void txtName_Validated(object sender, EventArgs e)
        //{
        //    txtEscortName.Text =txtEscortName.Text.ToStr().ToProperCase();
        //}

        void grd_IncidentLog_CommandCellClick(object sender, EventArgs e)
        {
            
            string colName = grd_IncidentLog.CurrentColumn.Name;
            GridViewRowInfo row = grd_IncidentLog.CurrentRow;

            if (colName == "Edit")
            {
                ClearDocument(row);
            }
            else if (colName == "View")
            {
                ViewDocumentIncidentLog(row);

            }
            else if (colName == "ColDelete")
            {
                grd_IncidentLog.CurrentRow.Delete();
                grd_IncidentLog.CurrentRow = null;
            }
            //
        }

        void grdDocuments_CommandCellClick(object sender, EventArgs e)
        {
            string colName = grdDocuments.CurrentColumn.Name;
            GridViewRowInfo row = grdDocuments.CurrentRow;
            if (colName == "btnDelete")
            {
                grdDocuments.CurrentRow.Delete();
            }
            //if (colName == "Clear")
            //{
            //    ClearDocument(row);

            //}
            //else if (colName == "Load")
            //{
            //    LoadDocument(row);

            //}
            //else if (colName == "View")
            //{
            //    ViewDocument(row);

            //}

        }


        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            General.DisposeForm(this);

            GC.Collect();
        }

    
        private void btnSaveNew_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           
        }

        private void btnSaveClose_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
        }

        private void btnsaveclose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                OnNew();
            }
        }


        private void ClearDocument(string path)
        {

            txtIncidentLogDocPath.Text = string.Empty;
            //  row.Cells[COL_DOCUMENT.EXPIRYDATE].Value = null;
        }

        private void ClearDocument(GridViewRowInfo row)
        {

            row.Cells[COL_DOCUMENT.FILENAME].Value = "";
            //  row.Cells[COL_DOCUMENT.EXPIRYDATE].Value = null;
        }

        private void LoadDocument(GridViewRowInfo row)
        {
            this.openFileDialog1.Filter = "Documents (All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {

                row.Cells[COL_DOCUMENT.FILENAME].Value = openFileDialog1.SafeFileName;
                row.Cells[COL_DOCUMENT.FULLPATH].Value = openFileDialog1.FileName;
            }



        }

        private void LoadDocument(string path)
        {
            this.openFileDialog1.Filter = "Documents (All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                txtIncidentLogDocPath.Text = openFileDialog1.FileName;


            }



        }

        private void ViewDocument(GridViewRowInfo row)
        {

            string fullDirectoryPath = "";
            DirectoryInfo di = null;


            try
            {

                if (row.Cells[COL_DOCUMENT.FULLPATH].Value.ToStr() != string.Empty)
                {
                    fullDirectoryPath = row.Cells[COL_DOCUMENT.FULLPATH].Value.ToStr();

                    if (File.Exists(fullDirectoryPath))
                    {

                        di = new DirectoryInfo(fullDirectoryPath);

                        System.Diagnostics.Process.Start(di.FullName);
                    }
                    else
                    {
                        if (fullDirectoryPath.ToStr().StartsWith("http:"))
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

        private void ViewDocumentIncidentLog(GridViewRowInfo row)
        {

            string fullDirectoryPath = "";
            DirectoryInfo di = null;


            try
            {

                if (row.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value.ToStr() != string.Empty)
                {
                    fullDirectoryPath = row.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value.ToStr();

                    if (File.Exists(fullDirectoryPath))
                    {

                        di = new DirectoryInfo(fullDirectoryPath);

                        System.Diagnostics.Process.Start(di.FullName);
                    }
                    else
                    {
                        if (fullDirectoryPath.ToStr().StartsWith("http:"))
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

       
        private void OnNewDocuments()
        {
            grdDocuments.Rows.Clear();


            //GridViewRowInfo row = null;

            //foreach (var item in General.GetQueryable<Gen_Syspolicy_EscortTrainingList>(c => c.IsVisible == true))
            //{
            //    row = grdDocuments.Rows.AddNew();

            //    row.Cells[COL_DOCUMENT.DOCUMENTTITLE].Value = item.DocumentName.ToStr();
            //    row.Cells[COL_DOCUMENT.DOCUMENTTITLEID].Value = item.Id;

            //}



          

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                pic_Escort.Image = Image.FromFile(openFileDialog1.FileName);



            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (pic_Escort.Image != null)
            {
                frmPreview frm = new frmPreview();
                frm.ImageFile = pic_Escort.Image;
                frm.Show();
            }
            else
            {
                ENUtils.ShowMessage("No Image found!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pic_Escort.Image = null;
        }

        private void btn_LoadPassport_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {

                pic_Passport.Image = Image.FromFile(openFileDialog1.FileName);



            }

        }

        private void btn_PreviewPassport_Click(object sender, EventArgs e)
        {
            if (pic_Passport.Image != null)
            {
            frmPreview frm = new frmPreview();
            frm.ImageFile = pic_Passport.Image;
            frm.Show();
            }
            else
            {
                ENUtils.ShowMessage("No Image found!");
            }
        }

        private void btn_ClearPassport_Click(object sender, EventArgs e)
        {
            this.pic_Passport.Image = null;
        }

        AutoCompleteTextBox aTxt = null;
        BackgroundWorker POIWorker = null;
        string searchTxt = "";
        string[] res = null;
       
        private void InitializeSearchPOIWorker()
        {
            if (POIWorker == null)
            {
                POIWorker = new BackgroundWorker();
                POIWorker.WorkerSupportsCancellation = true;
                POIWorker.DoWork += new DoWorkEventHandler(POIWorker_DoWork);
                POIWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(POIWorker_RunWorkerCompleted);
            }



        }
        void TextBoxElement_TextChanged(object sender, EventArgs e)
        {


            try
            {

                // IsKeyword = false;

                InitializeTimer();
                timer1.Stop();

                aTxt = (AutoCompleteTextBox)sender;
                aTxt.ResetListBox();

                //if (aTxt.Name == "txtFromAddress")
                //    txtToAddress.SendToBack();

                //else if (aTxt.Name == "txtToAddress")
                //    txtToAddress.BringToFront();



                if (AppVars.objPolicyConfiguration.EnablePOI.ToBool())
                {

                    InitializeSearchPOIWorker();

                    if (POIWorker.IsBusy)
                    {
                        POIWorker.CancelAsync();

                        POIWorker.Dispose();
                        POIWorker = null;
                        GC.Collect();
                        InitializeSearchPOIWorker();

                    }


                    AddressTextChangePOI();
                }
                else
                {

                    AddressTextChangeWOPOI();
                }
            }
            catch (Exception ex)
            {

            }
        }
        void POIWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null || e.Cancelled || (sender as BackgroundWorker) == null)
                return;

            try
            {


                ShowAddressesPOI((string[])e.Result);

            }
            catch
            {


            }
        }

        void POIWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            string searchValue = e.Argument.ToStr();
            try
            {
                if (POIWorker == null)
                {
                    e.Cancel = true;
                    return;


                }

                //   Console.WriteLine("Start work : " + searchValue);

                string postCode = General.GetPostCodeMatchOpt(searchValue);

                string doorNo = string.Empty;
                string place = string.Empty;

                if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                    postCode = string.Empty;

                string street = searchValue;

                if (postCode.Length > 0)
                {
                    street = street.Replace(postCode, "").Trim();
                }


                if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchValue.IndexOf(postCode) < searchValue.IndexOf(street))
                {
                    street = "";
                    postCode = searchTxt;
                }


                if (street.Length > 0)
                {

                    if (char.IsNumber(street[0]))
                    {

                        for (int i = 0; i <= 3; i++)
                        {
                            if (char.IsNumber(street[i]) || (doorNo.Length > 0 && doorNo.Length == i && char.IsLetter(street[i])))
                                doorNo += street[i];
                            else
                                break;
                        }
                    }
                }


                if (street.EndsWith("#"))
                {
                    street = street.Replace("#", "").Trim();
                    place = "p=";
                }

                if (doorNo.Length > 0 && place.Length == 0)
                {
                    street = street.Replace(doorNo, "").Trim();


                }


                if (postCode.Length == 0 && street.Length < 3)
                {
                    e.Cancel = true;
                    return;

                }


                if (street.Length > 1 || postCode.Length > 0)
                {
                    if (postCode.Length > 0)
                    {
                        if (doorNo.Length > 0 && postCode == General.GetPostCodeMatch(postCode))
                        {
                            doorNo = string.Empty;
                        }

                    }

                    if (postCode.Length >= 5 && postCode.Contains(" ") == false)
                    {
                        string resultPostCode = AppVars.listOfAddress.FirstOrDefault(a => a.PostalCode.Strip(' ') == postCode).DefaultIfEmpty().PostalCode.ToStr().Trim();


                        if (resultPostCode.Length >= 5 && resultPostCode.Contains(" "))
                        {
                            postCode = resultPostCode;

                        }

                    }


                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }



                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        e.Result = db.stp_GetByRoadLevelData(postCode, doorNo, street, place).Select(c => c.AddressLine1).ToArray<string>();

                    }

                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }




                    //   Console.WriteLine("end work : " + searchValue);

                }
            }
            catch
            {
                //     Console.WriteLine("Start work catch: " + searchValue);

            }
        }

        private void AddressTextChangeWOPOI()
        {
            string text = aTxt.Text;
            string doorNo = string.Empty;

            if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool())
            {
                if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower())
                {
                    aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                    aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();


                    if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
                    {

                        aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
                    }

                    aTxt.SelectedItem = aTxt.Text.Trim();
                    aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                    //    }               

                }

            }

            if (text.Length > 2 && text.EndsWith(".") == false && text.EndsWith(",") == false)
            {

                if (aTxt.SelectedItem == null || (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() != aTxt.Text.ToLower()))
                {


                    for (int i = 0; i <= 2; i++)
                    {
                        if (char.IsNumber(text[i]))
                            doorNo += text[i];
                        else
                            break;

                    }
                    text = text.Remove(text.IndexOf(doorNo), doorNo.Length).TrimStart(new char[] { ' ' });
                }
            }



            if (text.Length > 1 && text != "BASX")
            {
                if (text.EndsWith("   "))
                {
                    //if (aTxt.Name == "txtFromAddress")
                    //{
                    //    FocusOnPickupPlot();
                    //}
                    //else if (aTxt.Name == "txtToAddress")
                    //{
                    //    FocusOnDropOffPlot();
                    //}

                    return;

                }

                else if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
                {
                    aTxt.ListBoxElement.Items.Clear();

                    aTxt.ResetListBox();

                    string locName = aTxt.SelectedItem.ToLower();
                    int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
                    if (commaIndex != -1)
                    {
                        locName = locName.Remove(commaIndex);
                    }


                    string formerValue = aTxt.FormerValue.ToLower().Trim();

                    int? loctypeId = 0;
                    Gen_Location loc = null;
                    if (AppVars.keyLocations.Contains(formerValue) || aTxt.FormerValue.EndsWith("  ")
                    || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 3 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                    {


                        if (aTxt.FormerValue.EndsWith("  ") || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 2 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                        {
                            loc = General.GetObject<Gen_Location>(c => c.LocationName.ToLower() == locName);
                        }
                        else
                            loc = General.GetObject<Gen_Location>(c => c.ShortCutKey == formerValue && c.LocationName.ToLower() == locName);

                        if (loc != null)
                        {
                            loctypeId = loc.LocationTypeId;
                        }
                    }

                    if (loctypeId != 0)
                    {

                        if (aTxt.Name == "txtFromAddress")
                        {



                            if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.Text.Trim();
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                                //if (aTxt.Name == "txtFromAddress")
                                //{
                                //    SetPickupZone(aTxt.Text);

                                //    UpdateAutoCalculateFares();
                                //}


                            }


                        }
                        else if (aTxt.Name == "txtToAddress")
                        {


                            if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                aTxt.Text = aTxt.Text.Trim();
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                                //  SetDropOffZone(aTxt.Text);
                                //  UpdateAutoCalculateFares();


                            }




                        }
                    }
                    else if (aTxt.Text.Contains('.'))
                    {

                        //   RemoveNumbering(doorNo);


                    }
                    else if (!string.IsNullOrEmpty(doorNo))
                    {
                        aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        aTxt.Text = doorNo + " " + aTxt.Text;
                        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                    }
                    //else
                    //{
                    //    if (aTxt.Name == "txtFromAddress")
                    //    {


                    //        SetPickupZone(aTxt.SelectedItem);


                    //    }

                    //    else if (aTxt.Name == "txtToAddress")
                    //    {
                    //        SetDropOffZone(aTxt.SelectedItem);


                    //    }

                    //    if (aTxt.SelectedItem.ToStr().Trim() != string.Empty)
                    //    {
                    //        UpdateAutoCalculateFares();

                    //    }


                    //}

                    aTxt.FormerValue = string.Empty;


                    return;
                }



                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    //   CancelWebClientAsync();
                    // wc.CancelAsync();
                    aTxt.Values = null;

                }
                text = text.ToLower();

                if (AppVars.keyLocations.Contains(text) || (text.Length <= 4 && (text.EndsWith("  ") || (text[1] == ' ' || (text.Length > 2 && char.IsLetter(text[1]) && text[2] == ' ' && text.Trim().WordCount() == 2))))
                   || (text.Length < 13 && text.WordCount() == 2 && text.Remove(text.IndexOf(' ')).Trim().Length <= 3 && text.Strip(' ').IsAlpha()))
                {


                    aTxt.ListBoxElement.Items.Clear();


                    string[] res = null;

                    if (text.EndsWith("  "))
                    {

                        text = text.Trim();

                        res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.StartsWith(text))
                               select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                ).ToArray<string>();


                    }
                    else
                    {
                        if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                        {
                            string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                            string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                        c.LocationName.ToLower().Contains(locName))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                        }
                        else
                        {


                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                       ).ToArray<string>();
                        }
                    }


                    if (res.Count() > 0)
                    {



                        var finalList = (from a in AppVars.zonesList
                                         from b in res
                                         where b.Contains(a)
                                         select b).ToArray<string>();


                        if (finalList.Count() > 0)
                            finalList = finalList.Union(res).ToArray<string>();

                        else
                            finalList = res;


                        aTxt.ListBoxElement.Items.AddRange(finalList);


                        aTxt.ShowListBox();
                    }


                    if (aTxt.Text != aTxt.FormerValue)
                    {
                        aTxt.FormerValue = aTxt.Text;
                    }
                }


                if (MapType == Enums.MAP_TYPE.NONE) return;

                StartAddressTimer(text);

            }
            else if (text.Length > 0)
            {
                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    //   CancelWebClientAsync();
                    // wc.CancelAsync();
                    aTxt.Values = null;

                }
                text = text.ToLower();

                if (AppVars.keyLocations.Contains(text))
                {

                    aTxt.ListBoxElement.Items.Clear();


                    string[] res = null;

                    if (text.EndsWith("  "))
                    {

                        text = text.Trim();

                        res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
                               select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                ).ToArray<string>();


                    }
                    else
                    {
                        if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                        {
                            string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                            string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                        c.LocationName.ToLower().Contains(locName))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                        }
                        else
                        {


                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                       ).ToArray<string>();
                        }
                    }


                    if (res.Count() > 0)
                    {



                        var finalList = (from a in AppVars.zonesList
                                         from b in res
                                         where b.Contains(a)
                                         select b).ToArray<string>();


                        if (finalList.Count() > 0)
                            finalList = finalList.Union(res).ToArray<string>();

                        else
                            finalList = res;


                        aTxt.ListBoxElement.Items.AddRange(finalList);

                        if (text == "." && finalList.Count() == 1)
                        {
                            aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                            aTxt.Text = finalList[0];
                            aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                        }
                        else
                        {

                            aTxt.ShowListBox();
                        }
                    }


                    if (aTxt.Text != aTxt.FormerValue)
                    {
                        aTxt.FormerValue = aTxt.Text;
                    }




                    StartAddressTimer(text);
                }


            }
            else
            {
                if (MapType == Enums.MAP_TYPE.NONE) return;
                aTxt.ResetListBox();
                //  aTxt.ListBoxElement.Visible = false;
                aTxt.ListBoxElement.Items.Clear();

                //   CancelWebClientAsync();
                //  wc.CancelAsync();
                aTxt.Values = null;

            }



        }

        private void StartAddressTimer(string text)
        {
            text = text.ToLower();
            searchTxt = text;
            InitializeTimer();
            timer1.Start();
        }

        private void InitializeTimer()
        {
            if (this.timer1 == null)
            {
                this.timer1 = new System.Windows.Forms.Timer();
                this.timer1.Tick += timer1_Tick;
                this.timer1.Interval = 500;
            }

        }

        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (aTxt == null)
                {

                    timer1.Stop();
                    return;
                }

                timer1.Stop();

                searchTxt = searchTxt.ToUpper();


                if (AppVars.objPolicyConfiguration.EnablePOI.ToBool())
                {

                    if (POIWorker.IsBusy)
                        POIWorker.CancelAsync();



                    POIWorker.RunWorkerAsync(searchTxt);
                }
                else
                {

                    PerformAddressChangeTimerWOPOI();
                }


            }
            catch (Exception ex)
            {


            }

        }

        private void AddressTextChangePOI()
        {
            string text = aTxt.Text;
            string doorNo = string.Empty;

            if (aTxt.SelectedItem != null && aTxt.ListBoxElement.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower()
               && aTxt.Text.Length > 0)
            {
                aTxt.TextChanged -= TextBoxElement_TextChanged;
                //  aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();

                if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
                {
                    aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
                }

                aTxt.SelectedItem = aTxt.Text.Trim();
                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
            }




            for (int i = 0; i <= 2; i++)
            {
                if (char.IsNumber(text[i]))
                    doorNo += text[i];
                else
                    break;
            }





            if (text.Length > 1 && text != "BASX")
            {
                if (text.EndsWith("   "))
                {
                    //if (aTxt.Name == "txtFromAddress")
                    //{
                    //    FocusOnPickupPlot();
                    //}
                    //else if (aTxt.Name == "txtToAddress")
                    //{
                    //    FocusOnDropOffPlot();
                    //}
                    //return;
                }


                else if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
                {
                    aTxt.ListBoxElement.Items.Clear();
                    aTxt.ResetListBox();

                    string locName = aTxt.SelectedItem.ToLower();
                    int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
                    if (commaIndex != -1)
                    {
                        locName = locName.Remove(commaIndex);
                    }


                    string formerValue = aTxt.FormerValue.ToLower().Trim();





                    //else if (!string.IsNullOrEmpty(doorNo))
                    //{
                    //    aTxt.TextChanged -= TextBoxElement_TextChanged;
                    //    aTxt.Text = aTxt.Text;
                    //    aTxt.TextChanged += TextBoxElement_TextChanged;
                    //}
                    //else
                    //{
                    //    if (aTxt.Name == "txtFromAddress")
                    //    {
                    //        SetPickupZone(aTxt.SelectedItem);
                    //    }

                    //    else if (aTxt.Name == "txtToAddress")
                    //    {
                    //        SetDropOffZone(aTxt.SelectedItem);

                    //    }

                    //    if (aTxt.SelectedItem.ToStr().Trim() != string.Empty)
                    //    {
                    //        UpdateAutoCalculateFares();
                    //    }
                    //}

                    aTxt.FormerValue = string.Empty;
                    return;
                }

                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    aTxt.Values = null;

                }

                text = text.ToLower();




                if (MapType == Enums.MAP_TYPE.NONE) return;

                StartAddressTimer(text);

            }
            else if (text.Length > 0)
            {
                if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                {

                    aTxt.Values = null;

                }
                text = text.ToLower();

                if (AppVars.keyLocations.Contains(text))
                {

                    aTxt.ListBoxElement.Items.Clear();


                    string[] res = null;

                    if (text.EndsWith("  "))
                    {

                        text = text.Trim();

                        res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
                               select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                ).ToArray<string>();


                    }
                    else
                    {
                        if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                        {
                            string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                            string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                        c.LocationName.ToLower().Contains(locName))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                      ).ToArray<string>();

                        }
                        else
                        {


                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                       ).ToArray<string>();
                        }
                    }


                    if (res.Count() > 0)
                    {
                        //  IsKeyword = true;


                        var finalList = (from a in AppVars.zonesList
                                         from b in res
                                         where b.Contains(a)
                                         select b).ToArray<string>();


                        if (finalList.Count() > 0)
                            finalList = finalList.Union(res).ToArray<string>();

                        else
                            finalList = res;


                        aTxt.ListBoxElement.Items.AddRange(finalList);

                        if (text == "." && finalList.Count() == 1)
                        {
                            aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                            aTxt.Text = finalList[0];
                            aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                        }
                        else
                        {

                            aTxt.ShowListBox();
                        }
                    }


                    if (aTxt.Text != aTxt.FormerValue)
                    {
                        aTxt.FormerValue = aTxt.Text;
                    }

                    StartAddressTimer(text);
                }


            }
            else
            {
                //if (MapType == Enums.MAP_TYPE.NONE)
                //    return;
                aTxt.ResetListBox();
                aTxt.ListBoxElement.Items.Clear();
                aTxt.Values = null;

            }



        }

        private void ShowAddressesPOI(string[] resValue)
        {
            int sno = 1;

            // var finalList = resValue;



            var finalList = (from a in AppVars.zonesList
                             from b in resValue
                             where b.Contains(a) && (b.Substring(b.IndexOf(a), a.Length) == a && (b.IndexOf(a) - 1) >= 0 && b[b.IndexOf(a) - 1] == ' ' && GeneralBLL.GetHalfPostCodeMatch(b) == a)

                             select b).ToArray<string>();


            if (finalList.Count() > 0)
            {
                finalList = finalList.Union(resValue).ToArray<string>();

            }
            else
                finalList = resValue;



            if (finalList.Count() < 10)
            {
                finalList = finalList.Select(args => (sno++) + ". " + args).ToArray();
            }


            aTxt.ListBoxElement.Items.Clear();
            aTxt.ListBoxElement.Items.AddRange(finalList);


            if (aTxt.ListBoxElement.Items.Count == 0)
                aTxt.ResetListBox();
            else
            {


                aTxt.ShowListBox();


            }

            if (searchTxt != aTxt.FormerValue.ToLower())
            {
                aTxt.FormerValue = aTxt.Text;

            }
        }

        private void PerformAddressChangeTimerWOPOI()
        {

            string postCode = General.GetPostCodeMatch(searchTxt);
            string fullPostCode = postCode;


            if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                postCode = string.Empty;


            string street = searchTxt;



            int IsAsc = 0;
            if (!string.IsNullOrEmpty(postCode))
            {
                street = street.Replace(postCode, "").Trim();

                if (postCode.Contains(' ') == false)
                {
                    if (postCode.Length == 3 && Char.IsNumber(postCode[2]))
                    {

                        IsAsc = 1;
                    }
                    else if (postCode.Length == 2 && Char.IsNumber(postCode[1]))
                    {

                        IsAsc = 1;
                    }
                    else if (postCode.Length > 3 && Char.IsNumber(postCode[3]))
                    {

                        IsAsc = 2;
                    }


                }

            }


            if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchTxt.IndexOf(postCode) < searchTxt.IndexOf(street))
            {
                street = "";
                postCode = searchTxt;
            }


            if (IsAsc == 1)
            {



                if (!string.IsNullOrEmpty(street))
                {


                    res = (from a in AppVars.listOfAddress

                           where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                           orderby a.PostalCode

                           select a.AddressLine1

                                   ).Take(1000).ToArray<string>();

                }
                else
                {

                    res = (from a in AppVars.listOfAddress

                           where a.PostalCode.StartsWith(postCode)

                           orderby a.PostalCode

                           select a.AddressLine1

                         ).Take(600).ToArray<string>();
                }

            }
            else if (IsAsc == 2)
            {


                res = (from a in AppVars.listOfAddress

                       where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                       orderby a.PostalCode descending

                       select a.AddressLine1

                               ).Take(500).ToArray<string>();


                if (street.Contains(' ') && res.Count() == 0)
                {

                    string[] vals = street.Split(' ');
                    int valCnt = vals.Count();

                    res = (from a in AppVars.listOfAddress

                           where (vals.Count(c => a.AddressLine1.Contains(c)) == valCnt)

                           select a.AddressLine1

                         ).Take(30).ToArray<string>();


                }


            }
            else
            {

                if (postCode.Contains(' '))
                {

                    res = null;

                    if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool()
                        && AppVars.zonesList.Count() > 0
                        && fullPostCode.Length > 0)
                    {

                        fullPostCode = General.GetPostCodeMatch(fullPostCode);

                        if (fullPostCode.Length > 0 && searchTxt.Trim() == fullPostCode)
                        {


                            string[] res1 = (from a in AppVars.listOfAddress

                                             where a.PostalCode == postCode

                                             select a.AddressLine1

                                       ).Take(1).ToArray<string>();





                            res = (from a in new TaxiDataContext().stp_GetRoadLevelData(fullPostCode)
                                   select a.AddressLine1).ToArray<string>();


                            res = res1.Union(res).Distinct().ToArray<string>();


                        }


                        if (res.Count() == 0)
                        {
                            res = (from a in AppVars.listOfAddress

                                   where a.PostalCode.StartsWith(postCode)

                                   orderby a.PostalCode

                                   select a.AddressLine1

                                  ).Take(100).ToArray<string>();


                        }




                    }
                    else
                    {

                        res = (from a in AppVars.listOfAddress

                               where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode))))

                               select a.AddressLine1

                                  ).Take(500).ToArray<string>();
                    }
                }
                else
                {


                    if (street.Length == 3 && street.IsAlpha() && !string.IsNullOrEmpty(AppVars.objPolicyConfiguration.CountyString))
                    {


                        string[] areas = AppVars.objPolicyConfiguration.CountyString.Split(',');

                        string last = street[2].ToStr();
                        street = street.Remove(2);

                        res = (from b in AppVars.listOfAddress.Where(a => areas.Any(c => a.AddressLine1.Contains(c)) && a.AddressLine1.Split(' ').Count() > 5)
                               //  let x = (areas.Any(c => b.Address.Contains(c)) ? b.Address.Split(' ') : null)
                               let x = b.AddressLine1.Split(' ')
                               where

                                  (

                               (x.ElementAt(0).StartsWith(street) && x.ElementAt(1).StartsWith(last))
                            || (x.ElementAt(0).StartsWith(street) && areas.Contains(x.ElementAt(2)) == false && x.ElementAt(2).StartsWith(last))
                                )

                               select b.AddressLine1

                                  ).Take(200).ToArray<string>();



                    }
                    else
                    {


                        if (street.WordCount() == 1 && street.ContainsNoSpaces())
                        {
                            //  street = street + " ";




                            if (AppVars.zonesList.Count() == 0)
                            {
                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.StartsWith(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))
                                       select a.AddressLine1

                                ).Take(500).ToArray<string>();
                            }
                            else
                            {
                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.StartsWith(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))
                                       select a.AddressLine1

                               ).Take(100).ToArray<string>();

                            }


                            if (AppVars.zonesList.Count() > 0)
                            {

                                string[] res2 = (from a in AppVars.listOfAddress

                                                 where (a.AddressLine1.StartsWith(street))
                                                 && AppVars.zonesList.Count(c => a.PostalCode.StartsWith(c)) > 0
                                                 select a.AddressLine1

                                    ).Take(200).ToArray<string>();

                                res = res2.Union(res).Distinct().ToArray<string>();


                            }










                        }
                        else
                        {



                            if (AppVars.zonesList.Count() > 0)
                            {




                                if (postCode.Length == 0)
                                {

                                    res = (from a in AppVars.listOfAddress


                                           where

                                           (a.AddressLine1.StartsWith(street))
                                           select a.AddressLine1

                                       ).Take(500).ToArray<string>();
                                }
                                else
                                {
                                    res = (from a in AppVars.listOfAddress


                                           where

                                           ((a.AddressLine1.StartsWith(street))
                                        && ((a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))

                                           select a.AddressLine1

                                      ).Take(500).ToArray<string>();


                                }


                                res = res.Union((from a in AppVars.listOfAddress


                                                 where

                                                 (a.AddressLine1.Contains(street)
                                                 && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))




                                                 select a.AddressLine1

                                   ).Take(2000)
                                     ).Distinct().ToArray<string>();




                            }
                            else
                            {

                                res = (from a in AppVars.listOfAddress

                                       where (a.AddressLine1.Contains(street) && ((postCode == string.Empty || a.PostalCode.StartsWith(postCode) || a.PostalCode.Strip(' ').StartsWith(postCode))))



                                       select a.AddressLine1

                                    ).Take(1000).ToArray<string>();
                            }

                        }






                    }



                    if (street.Contains(' ') && res.Count() == 0)
                    {



                        string[] vals = street.Split(' ');
                        int valCnt = vals.Count();


                        res = (from a in AppVars.listOfAddress

                               where (vals.Count(c => a.AddressLine1.Contains(c)) == valCnt)



                               select a.AddressLine1

                             ).Take(30).ToArray<string>();


                    }



                }



            }

            ShowAddresses();

        }

        private void ShowAddresses()
        {

            var finalList = (from a in AppVars.zonesList
                             from b in res
                             where b.Contains(a)

                             select b).ToArray<string>();


            if (finalList.Count() > 0)
                finalList = finalList.Union(res).ToArray<string>();

            else
                finalList = res;


            aTxt.ListBoxElement.Items.Clear();
            aTxt.ListBoxElement.Items.AddRange(finalList);


            if (aTxt.ListBoxElement.Items.Count == 0)
                aTxt.ResetListBox();
            else
                aTxt.ShowListBox();



        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4'
                    || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7'
                    || e.KeyChar == '8' || e.KeyChar == '9')
                {




                    AutoCompleteTextBox txtData = (AutoCompleteTextBox)sender;
                    if (txtData.Text.StartsWith("W1"))
                        return;



                    if (txtData.Text.Length > 4 && txtData.ListBoxElement.Visible == true && txtData.ListBoxElement.Items.Count < 10)
                    {
                        string idx = e.KeyChar.ToStr();

                        txtData.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        string item = txtData.ListBoxElement.Items[idx.ToInt() - 1].ToStr();

                        string doorNo = string.Empty;
                        for (int i = 0; i <= 2; i++)
                        {
                            if (char.IsNumber(txtData.FormerValue[i]))
                                doorNo += txtData.FormerValue[i];
                            else
                                break;

                        }


                        if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool())
                        {
                            txtData.Text = (item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }
                        else
                        {

                            txtData.Text = (doorNo + " " + item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }


                        //if (txtData.Name == "txtFromAddress")
                        //{
                        //    SetPickupZone(txtData.Text);
                        //    FocusOnFromDoor();
                        //}
                        //else if (txtData.Name == "txtToAddress")
                        //{
                        //    SetDropOffZone(txtData.Text);
                        //    FocusOnToDoor();
                        //}
                        //else if (txtData.Name == "txtViaAddress")
                        //{
                        //    txtData.ResetListBox();
                        //    AddViaPoint();

                        //}
                        txtData.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                        e.Handled = true;

                        aTxt.ResetListBox();
                        aTxt.ListBoxElement.Items.Clear();


                        //   UpdateAutoCalculateFares();
                        //   txtViaAddress.Focus();
                    }



                }
            }
            catch (Exception ex)
            {


            }
        }

        private void btn_IncidentBrowse_Click(object sender, EventArgs e)
        {
            LoadDocument("");

        }

        private void btn_IncidentView_Click(object sender, EventArgs e)
        {
            ViewDocument(txtIncidentLogDocPath.Text.Trim());

        }

        private void btn_IncidentClear_Click(object sender, EventArgs e)
        {
            ClearDocument("");

        }

        private void btnDBSBrowse_Click(object sender, EventArgs e)
        {
            LoadDBSFile("");
        }

        private void btnDBSView_Click(object sender, EventArgs e)
        {
            ViewDocument(txtFilePath.Text.Trim());
        }

        private void btnDBSClear_Click(object sender, EventArgs e)
        {
            ClearDBSFile("");
        }

        private void ClearDBSFile(string p)
        {
            txtFilePath.Text = "";
        }

        private void LoadDBSFile(string path)
        {
            this.openFileDialog1.Filter = "Documents (All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void chkAutoSMS_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {

                numAutoSMSDays.Enabled = true;
            }
            else
            {
                numAutoSMSDays.Value = 0;
                numAutoSMSDays.Enabled = false;
            }

        }

        private void chkActive_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                _IsActive = true;
            }
            else
            {
                _IsActive = false;
            }

        }

        private void btnBrowseProofofAddress_Click(object sender, EventArgs e)
        {
            LoadProofofAddress("");
        }

        private void btnViewProofofAddress_Click(object sender, EventArgs e)
        {
            ViewDocument(txtPathProofofAddress.Text.Trim());
        }

        private void btnClearProofofAddress_Click(object sender, EventArgs e)
        {
            ClearProofofAddress("");
        }

        private void LoadProofofAddress(string path)
        {
            this.openFileDialog1.Filter = "Documents (All files (*.*)|*.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                txtPathProofofAddress.Text = openFileDialog1.FileName;
            }
        }

        private void ClearProofofAddress(string path)
        {

            txtPathProofofAddress.Text = string.Empty;
            
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = "";
                DateTime ? dtIncident=dp_IncidentLog.Value.ToDateorNull();
                string NatureOfIncident=txt_NatureOfIncident.Text.Trim();
                if(dtIncident==null)
                {
                Error="Required : Incident Date";
                }
                if(string.IsNullOrEmpty(NatureOfIncident))
                {
                                    if(string.IsNullOrEmpty(Error))
                                    {
                                        Error = "Required : Nature of Incident";
                                    }
                                    else
                                    {
                                        Error +=Environment.NewLine+ "Required : Nature of Incident";
                                    }
                }
                if (!string.IsNullOrEmpty(Error))
                {
                    ENUtils.ShowMessage(Error);
                    return;
                }
                GridViewRowInfo row;
                    if (grd_IncidentLog.CurrentRow != null)
                        row = grd_IncidentLog.CurrentRow;
                    else
                        row = grd_IncidentLog.Rows.AddNew();

                    row.Cells[COL_INCIDENTLOG.DATE].Value = dp_IncidentLog.Value.ToDateorNull();
                    row.Cells[COL_INCIDENTLOG.INCIDENTREPORT].Value = txtIncidentLogDocPath.Text.Trim();
                    row.Cells[COL_INCIDENTLOG.NATUREOFINCIDENT].Value = txt_NatureOfIncident.Text.Trim();

                    dp_IncidentLog.Value = null;
                    txtIncidentLogDocPath.Text = "";
                    txt_NatureOfIncident.Text = "";
                    grd_IncidentLog.CurrentRow = null;
               

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

      
      

    }
}
