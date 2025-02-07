using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi_BLL;
using Taxi_Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Taxi_AppMain
{
    public partial class frmGridViewDisplaySettings :  UI.SetupBase
    {
        List<UM_Form_UserDefinedSetting> hiddenColumnsList = null;
        List<UM_Form_UserDefinedSetting> listofSearchTabSettings = null;
        TaxiDataContext db = new TaxiDataContext();
        private int PreBookingDefaultDays;
     
        public frmGridViewDisplaySettings()
        {
            InitializeComponent();
            this.grdview.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdview_ViewCellFormatting);
        }
        public void load()
        {
            try
            {


                hiddenColumnsList = General.GetQueryable<UM_Form_UserDefinedSetting>(c => c.UM_Form.Id == 20 && (c.IsVisible == false || c.GridColMoveTo != null)).ToList();

                listofSearchTabSettings = hiddenColumnsList.Where(c => c.FormTab == "search").ToList();

                hiddenColumnsList.RemoveAll(c => c.FormTab == "search");
                // Today's Booking Grid Hide Columns
               

                hiddenColumnsList = hiddenColumnsList.OrderBy(c => c.GridColMoveTo).ToList();

                for (int i = 0; i < hiddenColumnsList.Count; i++)
                {



                    if (grdview.Columns[hiddenColumnsList[i].GridColumnName] != null)
                    {


                        grdview.Columns[hiddenColumnsList[i].GridColumnName].IsVisible = Convert.ToBoolean(hiddenColumnsList[i].IsVisible);


                        if (hiddenColumnsList[i].GridColMoveTo != null && Convert.ToBoolean(hiddenColumnsList[i].IsVisible))
                        {
                            grdview.Columns.Move(grdview.Columns[hiddenColumnsList[i].GridColumnName].Index, Convert.ToInt32(hiddenColumnsList[i].GridColMoveTo.ToString()));
                        }
                    }

                }













                grdview.ColumnChooser.StartPosition = FormStartPosition.CenterScreen;
               


                for (int a = 0; a < grdview.ColumnCount; a++)
                {


                    if (grdview.Columns[a].Name.EndsWith("Id")
                        || grdview.Columns[a].Name.EndsWith("Color") ||
                        grdview.Columns[a].Name.EndsWith("Color1")
                        || grdview.Columns[a].Name == "BookingDateTime" ||
                        grdview.Columns[a].Name == "GoingTo" ||
                        grdview.Columns[a].Name == "ToPostCode" ||
                        grdview.Columns[a].Name == "IsAutoDespatch" ||
                        grdview.Columns[a].Name == "HasNotes" ||
                        grdview.Columns[a].Name == "IsConfirmedDriver" ||
                        grdview.Columns[a].Name == "BabySeats" ||
                        grdview.Columns[a].Name == "MileageFromBase" ||
                        grdview.Columns[a].Name == "IsBidding" ||
                        grdview.Columns[a].Name == "DeadMileage" ||
                        grdview.Columns[a].Name == "Due" ||
                        grdview.Columns[a].Name == "NoofLuggages" ||
                        grdview.Columns[a].Name == "Vias" ||
                        grdview.Columns[a].Name == "MobileNo" ||
                        grdview.Columns[a].Name == "FromPostCode" ||
                        grdview.Columns[a].Name == "Pickup" ||
                        grdview.Columns[a].Name == "PrePickupDate" ||
                        grdview.Columns[a].Name == "TelephoneNo"
                        ||
                        grdview.Columns[a].Name == "PlotHour"
                        ||
                        grdview.Columns[a].Name == "PickupDateTemp"
                        ||
                        grdview.Columns[a].Name == "MilesFromBase")
                    {

                        string colname = grdview.Columns[a].Name;

                        hideColums(colname);

                        // grdview.ColumnChooser.Columns[grdview.Columns[a].Index].VisibleInColumnChooser = false;
                    }
                    else
                    { grdview.Columns[a].BestFit(); }
                   
                }

              

            }
            catch (Exception ex)
            { }
        }
        public void hideColums(string colname)
        {
            //string colname = grdview.Columns[a].Name;

            grdview.Columns[colname].IsVisible = false;
            grdview.Columns[colname].VisibleInColumnChooser = false;
        }
        private void frmDailogDashboardColumnChooser_Load(object sender, EventArgs e)
        {
            PopulateData();
            load();
            //grdview.ContextMenuStrip.Items.IndexOfKey
            for (int i = 0; i < grdview.ContextMenuStrip.Items.Count; i++)
            {
                
                if (i != grdview.ContextMenuStrip.Items.IndexOfKey("Column Chooser") ||
                    i != grdview.ContextMenuStrip.Items.IndexOfKey("Hide Column"))
                {
                    grdview.ContextMenuStrip.Items.RemoveAt(i);
                }

            }


        }
        public bool IsColVisibily { get; set; }
        public void AddUserForm()
        {
            UM_Form_UserDefinedSetting u = new UM_Form_UserDefinedSetting();


            int newcol = 0;
            //db.UM_Form_UserDefinedSettings.InsertOnSubmit(u);
            //db.UM_Form_UserDefinedSettings.Context.SubmitChanges();
            GridDataCellElement gv = grdview.CurrentCell;
            for (int i = 0; i < grdview.ColumnCount; i++)
            {
                // int id = Convert.ToInt32(grdview.Rows[i].Cells[0].Value.ToString());
                int id = hiddenColumnsList[i].Id;
                newcol = grdview.Columns[i].Index;
                u.FormId = 20;
                u.GridColMoveTo = newcol;
                u.GridColumnName = grdview.Columns[newcol].Name;
                u.IsVisible = grdview.Columns[newcol].IsVisible;
                 u.HeaderText = grdview.Columns[newcol].HeaderText;
                //u.GridColWidth = grdview.Columns[newcol].Width;
                //db.UM_Form_UserDefinedSettings.InsertOnSubmit(u);

                // db.UM_Form_UserDefinedSettings.Context.SubmitChanges();
               // db.UM_Form_UserDefinedSettings.Context.
                db.UM_Form_UserDefinedSettings.Context.ExecuteCommand("exec stp_UM_Form_UserDefinedSettings  @id="+id+",@FormId=20,@GridColumnName='" + u.GridColumnName + "',@IsVisible="+ u.IsVisible + ",@Colwidth=0,@ColMoveto="+ u.GridColMoveTo + ",@FormTab=null,@DisplaySettings=null,@HeaderText='"+ u.HeaderText + "'");


                // db.UM_Form_UserDefinedSettings.Context.ExecuteQuery<UM_Form_UserDefinedSetting>(" Update UM_Form_UserDefinedSettings set [GridColumnName]='"+ u.GridColumnName + "',[IsVisible]='" + u.IsVisible + "',[GridColWidth]="+ u.GridColWidth + ",[GridColMoveTo]="+ u.GridColMoveTo + ",[HeaderText]='"+ u.HeaderText + "' where FormId=20");

            }





        }
        public override void PopulateData()
        {
            try
            {
                int DaysInTodayBooking = Convert.ToInt32(AppVars.objPolicyConfiguration.DaysInTodayBooking);
                int   BookingHours = Convert.ToInt32(AppVars.objPolicyConfiguration.DaysInTodayBooking);
                this.PreBookingDefaultDays = Convert.ToInt32(AppVars.objPolicyConfiguration.HourControllerReport);
                DateTime? dt = DateTime.Now;
                DateTime recentDays = dt.Value.AddDays(-1);

                DateTime prebookingdays = dt.Value.AddDays(PreBookingDefaultDays).Date;
                DateTime dtNow = DateTime.Now;
                // live

               


                var query = db.stp_GetBookingsData(recentDays, prebookingdays, AppVars.DefaultBookingSubCompanyId, BookingHours).ToList();




                int val = grdview.TableElement.VScrollBar.Value;
                DateTime Hours = DateTime.Now.Date.AddHours(BookingHours);
                if (BookingHours > 0)
                {



                    grdview.DataSource = query.Where(a => (a.PickupDateTemp >= recentDays && a.PickupDateTemp <= Hours)
                        && (a.StatusId == Enums.BOOKINGSTATUS.WAITING || a.StatusId == Enums.BOOKINGSTATUS.PENDING
                           || a.StatusId == Enums.BOOKINGSTATUS.NOTACCEPTED || a.StatusId == Enums.BOOKINGSTATUS.REJECTED
                           || a.StatusId == Enums.BOOKINGSTATUS.ONHOLD || a.StatusId == Enums.BOOKINGSTATUS.BID
                           || a.StatusId == Enums.BOOKINGSTATUS.PENDING_START
                                           || a.StatusId == Enums.BOOKINGSTATUS.NOSHOW || a.StatusId == Enums.BOOKINGSTATUS.FOJ))
                                           .OrderBy(c => c.Lead).ToList();

                }
                else
                {


                    grdview.DataSource = query.Where(a => (a.PickupDateTemp >= recentDays && a.PickupDateTemp.Value.Date <= dt.Value.AddDays(DaysInTodayBooking))
                              && (a.StatusId == Enums.BOOKINGSTATUS.WAITING || a.StatusId == Enums.BOOKINGSTATUS.PENDING || a.StatusId == Enums.BOOKINGSTATUS.NOTACCEPTED || a.StatusId == Enums.BOOKINGSTATUS.REJECTED
                                 || a.StatusId == Enums.BOOKINGSTATUS.NOSHOW || a.StatusId == Enums.BOOKINGSTATUS.ONHOLD || a.StatusId == Enums.BOOKINGSTATUS.BID
                                  || a.StatusId == Enums.BOOKINGSTATUS.PENDING_START || a.StatusId == Enums.BOOKINGSTATUS.FOJ))
                                  .OrderBy(c => c.Lead).ToList();


                }


                
                //   grdview.CurrentRow = grdview.Rows.FirstOrDefault(c => c.Index == rowIndex);


              


                // PreBooking


                
            }
            catch (Exception ex)
            {
                //   ENUtils.ShowMessage(ex.Message);

            }

        }
        private Color _HeaderRowBorderColor = Color.SteelBlue;
        Font oldFont = new Font("Arial", 10, FontStyle.Bold);
        Font newFont = new Font("Arial", 10, FontStyle.Bold);
        Font bigFont = new Font("Arial", 12, FontStyle.Bold);

        private Color _HeaderRowBackColor = Color.SteelBlue;
        List<string> lst = new List<string> ();
        public Color HeaderRowBackColor
        {
            get { return _HeaderRowBackColor; }
            set { _HeaderRowBackColor = value; }
        }
        public int SelectedColIndex { get; set; }
        public string SelectedColName { get; set; }

        private void grdview_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try
            {
                if (e.CellElement is GridHeaderCellElement)
                {
                    if (AppVars.AppTheme == "ControlDefault")
                    {
                        //    e.CellElement
                        DefaultBgColor(e);

                    }
                    if (IsSelectedCol)
                    {
                        if (e.CellElement.ColumnIndex == grdview.Columns.IndexOf(SelectedColName))
                        {
                            e.CellElement.ForeColor = Color.Silver;
                            e.CellElement.BackColor = Color.Black;
                            e.CellElement.GradientStyle = GradientStyles.Solid;
                            e.CellElement.DrawBorder = false;
                            e.CellElement.DrawFill = true;
                        }
                        else
                        {
                            DefaultBgColor(e);
                            //e.CellElement.ResetValue(LightVisualElement.BackColorProperty);
                            //e.CellElement.ResetValue(LightVisualElement.ForeColorProperty);
                            //e.CellElement.ResetValue(LightVisualElement.DrawBorderProperty);
                            //e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
                            //e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
                        }
                    }

                }
            }
            catch (Exception)
            { }
        }

        private void DefaultBgColor(CellFormattingEventArgs e)
        {
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
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

           


            
            // newcol = newcol + 1;




            //var index = grdview.Columns.ToList();
            //    var lstcol= index.Where(c =>  c.IsVisible=true  ).ToList();
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    if (SelectedColName == lst[i].ToString())
            //    {
                    int newcol = grdview.Columns.IndexOf(SelectedColName);
                    int neworder = (newcol + 1);

            while (grdview.Columns[neworder].IsVisible == false)
            {
                neworder = (neworder + 1);
            }
            grdview.Columns.Move(newcol, neworder);
            lblcol.Text = "Index: " + newcol + " Name: " + SelectedColName;

            //    }

            //}












        }

        private void radButton1_Click(object sender, EventArgs e)
        {



            int newcol = grdview.Columns.IndexOf(SelectedColName);
            int neworder = (newcol - 1);
            while (grdview.Columns[neworder].IsVisible==false)
            {
                neworder = (neworder - 1);
            }
            grdview.Columns.Move(newcol, neworder);


            lblcol.Text = "Index: " + newcol + " Name: " + SelectedColName;



        }

        private void grdview_ViewColumnsChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {



            
        }

        private void btnSaveOn_Click(object sender, EventArgs e)
        {
            AddUserForm();

        }

        private void grdview_CurrentColumnChanged(object sender, CurrentColumnChangedEventArgs e)
        {
            
        }

        private void grdview_ViewCellFormatting_1(object sender, CellFormattingEventArgs e)
        {

        }

        private void grdview_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            //MessageBox.Show(e.Column.Name);

            //if (this.grdview.CurrentColumn.Name == "Select")
            //{
            //    e.Cancel = true;
            //}
        }
        public bool IsSelectedCol { get; set; }
        private void grdview_CellClick(object sender, GridViewCellEventArgs e)
        {
            this.grdview.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdview_ViewCellFormatting);
            IsSelectedCol = true;
            SelectedColIndex = e.Column.Index;
            SelectedColName = e.Column.Name;

           
            //MessageBox.Show(e.Column.Name);
        }

        private void btn_ColumnChooser_Click(object sender, EventArgs e)
        {
            if (grdview.ColumnChooser.Visible==false)
            {
                grdview.ColumnChooser.Visible = true;
                //btn_ColumnChooser.Text = "Hide Column Chooser";
            }
            else if (grdview.ColumnChooser.Visible == true)
            {
                //btn_ColumnChooser.Text = "Show Column Chooser";
                grdview.ColumnChooser.Visible = false;
            }
        }

        private void grdview_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            if (e.CellElement.ColumnInfo.IsCurrent)
            {

                e.CellElement.BackColor = Color.White;
                e.CellElement.ForeColor = Color.Black;
                e.CellElement.DrawFill = true;
                return;


            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }

        private void grdview_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            for (int i = 0; i < e.ContextMenu.Items.Count; i++)
            {
                if (e.ContextMenu.Items[i].Text == "Column Chooser" || e.ContextMenu.Items[i].Text == "Hide Column")
                {
                    // hide the Conditional Formatting option from the header row context menu
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    // hide the separator below the CF option
                   // e.ContextMenu.Items[i + 1].Visibility = Telerik.WinControls.ElementVisibility.Visible;
                }
                else
                {  // hide the Conditional Formatting option from the header row context menu
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    // hide the separator below the CF option
                   // e.ContextMenu.Items[i + 1].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
            }
        }
    }
}
