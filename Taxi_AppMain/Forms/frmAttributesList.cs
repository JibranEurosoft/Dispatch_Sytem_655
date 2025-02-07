using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_Model;
using Taxi_BLL;
using DAL;
using Utils;
using Taxi_BLL.Classes;
using Telerik.WinControls.UI;

namespace Taxi_AppMain
{
    public partial class frmAttributesList :Form
    {

        string ColumnName = string.Empty;

        BookingBO obj ;

        public struct Col_BookingAttributesList
        {
            public static string Id = "Id";
            public static string DetailId = "DetailId";
            public static string Name = "Name";
            public static string ShortName = "ShortName";
            public static string Default = "Default";
            public static string MaxQuantity = "MaxQuantity";
            public static string Charges = "Charges";
            public static string Qty = "Qty";
            public static string Price = "Price";
            

        }

        public struct Col_ReturnBookingAttributesList
        {
            public static string Id = "Id";
            public static string DetailId = "DetailId";
            public static string Name = "Name";
            public static string ShortName = "ShortName";
            public static string Default = "Default";
            public static string MaxQuantity = "MaxQuantity";
            public static string Charges = "Charges";
            public static string Qty = "Qty";
            public static string Price = "Price";
            
        }




        public int input_values;
        public frmAttributesList(int values, int journeyTypeId, List<Booking_Attribute> onewaylist, List<Booking_Attribute> returnList)
        {
            // this.input_values = values;

            //InitializeComponent();
            //InitializeConstructor();
            //FormatBookingAttributesListGrid();
            //LoadBookingAttributesListGrid();


            //if ((input_values>0 &&  obj.Current.JourneyTypeId.ToInt()==Enums.JOURNEY_TYPES.RETURN && obj.Current.BookingReturns.Count > 0)
            //    || journeyTypeId==Enums.JOURNEY_TYPES.RETURN)
            //{
            //    grdReturnAttributesList.Visible = true;
            //    grdAttributesList.Size = new Size(433, 224);
            //    FormatReturnBookingAttributesListGrid();
            //    LoadReturnBookingAttributesListGrid();

            //    grdReturnAttributesList.CommandCellClick += GrdReturnAttributesList_CommandCellClick;
            //}

            //grdAttributesList.CommandCellClick += GrdAttributesList_CommandCellClick;












            this.input_values = values;

            InitializeComponent();
            InitializeConstructor();
            FormatBookingAttributesListGrid();

            if (input_values == 0)
            {


                extraChargesOneWaySavedList = onewaylist;
                extraChargesReturnSavedList = returnList;
            }

            LoadBookingAttributesListGrid();


            if ((input_values > 0 && obj.Current.JourneyTypeId.ToInt() == Enums.JOURNEY_TYPES.RETURN && obj.Current.BookingReturns.Count > 0)
                || journeyTypeId == Enums.JOURNEY_TYPES.RETURN)
            {
                grdReturnAttributesList.Visible = true;
                grdAttributesList.Size = new Size(433, 224);
                FormatReturnBookingAttributesListGrid();
                LoadReturnBookingAttributesListGrid();

                grdReturnAttributesList.CommandCellClick += GrdReturnAttributesList_CommandCellClick;
            }

            grdAttributesList.CommandCellClick += GrdAttributesList_CommandCellClick;

        }

        private void GrdReturnAttributesList_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                string name = gridCell.ColumnInfo.Name;

                GridViewRowInfo row = gridCell.RowElement.RowInfo;


                if (name == "btnAdd")
                {
                    if (row.Cells[Col_ReturnBookingAttributesList.Qty].Value == null)
                    {
                        row.Cells[Col_ReturnBookingAttributesList.Qty].Value = 1;
                    }
                    else
                    {
                        if (row.Cells[Col_ReturnBookingAttributesList.MaxQuantity].Value.ToInt() > row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt())
                        {
                            row.Cells[Col_ReturnBookingAttributesList.Qty].Value = row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() + 1;
                            row.Cells[Col_ReturnBookingAttributesList.Price].Value = row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() * row.Cells[Col_BookingAttributesList.Charges].Value.ToDecimal();
                        }

                    }

                }
                else if (name == "btnMinus")
                {
                    if (row.Cells[Col_ReturnBookingAttributesList.Qty].Value != null)
                    {
                        if (row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() > 0)
                        {
                            row.Cells[Col_ReturnBookingAttributesList.Qty].Value = row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() - 1;
                            row.Cells[Col_ReturnBookingAttributesList.Price].Value = row.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() * row.Cells[Col_ReturnBookingAttributesList.Charges].Value.ToDecimal();
                        }
                    }
                    else
                    {
                        row.Cells[Col_ReturnBookingAttributesList.Qty].Value = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void GrdAttributesList_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                string name = gridCell.ColumnInfo.Name;

                GridViewRowInfo row = gridCell.RowElement.RowInfo;
                

                if (name == "btnAdd")
                {
                    if (row.Cells[Col_BookingAttributesList.Qty].Value == null)
                    {
                        row.Cells[Col_BookingAttributesList.Qty].Value = 1;
                    }
                    else
                    {
                        if (row.Cells[Col_BookingAttributesList.MaxQuantity].Value.ToInt() > row.Cells[Col_BookingAttributesList.Qty].Value.ToInt())
                        {
                            row.Cells[Col_BookingAttributesList.Qty].Value = row.Cells[Col_BookingAttributesList.Qty].Value.ToInt() + 1;
                            row.Cells[Col_BookingAttributesList.Price].Value = row.Cells[Col_BookingAttributesList.Qty].Value.ToInt() * row.Cells[Col_BookingAttributesList.Charges].Value.ToDecimal();
                        }
                       
                    }
                    
                }
                else if (name == "btnMinus")
                {
                    if (row.Cells[Col_BookingAttributesList.Qty].Value != null)
                    {
                        if (row.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0)
                        {
                            row.Cells[Col_BookingAttributesList.Qty].Value = row.Cells[Col_BookingAttributesList.Qty].Value.ToInt() - 1;
                            row.Cells[Col_BookingAttributesList.Price].Value = row.Cells[Col_BookingAttributesList.Qty].Value.ToInt() * row.Cells[Col_BookingAttributesList.Charges].Value.ToDecimal();
                        }
                    }
                    else
                    {
                        row.Cells[Col_BookingAttributesList.Qty].Value = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        }

        private void FormatBookingAttributesListGrid()
        {

            grdAttributesList.AllowAutoSizeColumns = true;
            grdAttributesList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAttributesList.AllowAddNewRow = true;
            grdAttributesList.ShowGroupPanel = false;
            grdAttributesList.ShowRowHeaderColumn = false;
        

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = Col_BookingAttributesList.Id;
            col.IsVisible = false;
            grdAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_BookingAttributesList.DetailId;
            col.IsVisible = false;
            grdAttributesList.Columns.Add(col);


            GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
            col1.HeaderText = "Default";
            col1.Name = Col_BookingAttributesList.Default;
            col1.HeaderText = "";
            col1.Width = 50;
            col1.IsVisible = false;
            //col1.ReadOnly = true;
            grdAttributesList.Columns.Add(col1);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Name";
            col.Name = Col_BookingAttributesList.Name;
            col.Width =170;
            col.ReadOnly = true;
            grdAttributesList.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "ShortName";
            col.Name = Col_BookingAttributesList.ShortName;
            col.IsVisible = false;
            // col.ReadOnly = true;
            grdAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Qty";
            col.Name = Col_BookingAttributesList.Qty;
            col.IsVisible = true;
            col.Width = 40;
            col.ReadOnly = true;  
            grdAttributesList.Columns.Add(col);
        

            GridViewCommandColumn col2 = new GridViewCommandColumn();
            col2.UseDefaultText = true;
            col2.Width = 25;
            col2.DefaultText = "+";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            col2.Name = "btnAdd";
            grdAttributesList.Columns.Add(col2);

            col2 = new GridViewCommandColumn();
            col2.UseDefaultText = true;
            col2.Width = 25;
            col2.DefaultText = "-";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            col2.Name = "btnMinus";
            grdAttributesList.Columns.Add(col2);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Charges";
            col.Name = Col_BookingAttributesList.Price;
            col.IsVisible = true;
            col.Width = 50;
            col.ReadOnly = true;
            grdAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_BookingAttributesList.MaxQuantity;
            col.IsVisible = false;
            grdAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_BookingAttributesList.Charges;
            col.IsVisible = false;
            grdAttributesList.Columns.Add(col);

            //grdAttributesList.MasterTemplate.ShowRowHeaderColumn = false;
            //UI.GridFunctions.SetFilter(grdAttributesList);
            //grdAttributesList.AllowEditRow = true;


        }

        private void FormatReturnBookingAttributesListGrid()
        {

            grdReturnAttributesList.AllowAutoSizeColumns = true;
            grdReturnAttributesList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdReturnAttributesList.AllowAddNewRow = true;
            grdReturnAttributesList.ShowGroupPanel = false;
            grdReturnAttributesList.ShowRowHeaderColumn = false;


            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.Name = Col_ReturnBookingAttributesList.Id;
            col.IsVisible = false;
            grdReturnAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_ReturnBookingAttributesList.DetailId;
            col.IsVisible = false;
            grdReturnAttributesList.Columns.Add(col);


            GridViewCheckBoxColumn col1 = new GridViewCheckBoxColumn();
            col1.HeaderText = "Default";
            col1.Name = Col_ReturnBookingAttributesList.Default;
            col1.HeaderText = "";
            col1.Width = 50;
            col1.IsVisible = false;
            //col1.ReadOnly = true;
            grdReturnAttributesList.Columns.Add(col1);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Name";
            col.Name = Col_ReturnBookingAttributesList.Name;
            col.Width = 170;
            col.ReadOnly = true;
            grdReturnAttributesList.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "ShortName";
            col.Name = Col_ReturnBookingAttributesList.ShortName;
            col.IsVisible = false;
            // col.ReadOnly = true;
            grdReturnAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "Qty";
            col.Name = Col_ReturnBookingAttributesList.Qty;
            col.IsVisible = true;
            col.Width = 40;
            col.ReadOnly = true;
            grdReturnAttributesList.Columns.Add(col);


            GridViewCommandColumn col2 = new GridViewCommandColumn();
            col2.UseDefaultText = true;
            col2.Width = 25;
            col2.DefaultText = "+";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            col2.Name = "btnAdd";
            grdReturnAttributesList.Columns.Add(col2);

            col2 = new GridViewCommandColumn();
            col2.UseDefaultText = true;
            col2.Width = 25;
            col2.DefaultText = "-";
            col2.TextAlignment = ContentAlignment.MiddleCenter;
            col2.Name = "btnMinus";
            grdReturnAttributesList.Columns.Add(col2);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Charges";
            col.Name = Col_ReturnBookingAttributesList.Price;
            col.IsVisible = true;
            col.Width = 50;
            col.ReadOnly = true;
            grdReturnAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_ReturnBookingAttributesList.MaxQuantity;
            col.IsVisible = false;
            grdReturnAttributesList.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.Name = Col_ReturnBookingAttributesList.Charges;
            col.IsVisible = false;
            grdReturnAttributesList.Columns.Add(col);

            //grdAttributesList.MasterTemplate.ShowRowHeaderColumn = false;
            //UI.GridFunctions.SetFilter(grdAttributesList);
            //grdAttributesList.AllowEditRow = true;


        }

        private void InitializeConstructor()
        {
            obj = new BookingBO();
           
            this.FormClosed += new FormClosedEventHandler(frmAttribute_FormClosed);
            this.KeyDown += new KeyEventHandler(frmAttribute_KeyDown);
        }

        void frmAttribute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SaveAndClose();
            }
            else if (e.KeyCode == Keys.End)
            {
                SaveAndClose();
            }
        }

        void frmAttribute_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Dispose(true);

          //  GC.Collect();

        }

        private void LoadBookingAttributesListGrid()
        {

            try
            {
           
                using (TaxiDataContext db =new TaxiDataContext())
                {
                    //var list = db.ExecuteQuery<ClsBookingAttributes>("select g.Id, b.Id as DetailId, g.Name, g.ShortName, g.MaxQty, g.ChargesPerQty, b.Qty, b.Price,  g.IsActive , b.AttributeId   from Gen_Attribute g left join  Booking_Attributes b on g.Id = b.AttributeId where g.AttributeCategoryId = 3 and g.isActive = 1").ToList();
                    var list = db.ExecuteQuery<ClsBookingAttributes>("select Id, Name, ShortName, MaxQty, ChargesPerQty , IsActive   from Gen_Attribute where AttributeCategoryId = 3 and IsDefault = 1" ).OrderBy(c=>c.Name).ToList();
                    grdAttributesList.RowCount = list.Count;
                    for (int i = 0; i < list.Count; i++)
                    {
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Id].Value = list[i].Id;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Name].Value = list[i].Name;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.ShortName].Value = list[i].ShortName;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.MaxQuantity].Value = list[i].MaxQty;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Charges].Value = list[i].ChargesPerQty;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Qty].Value = 0;
                        grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Price].Value = 0;

                        
                    }
                }


                if (input_values > 0)
                {

                    obj.GetByPrimaryKey(input_values);


                    var list1 = obj.Current.Booking_Attributes.ToList();


                    for (int i = 0; i < grdAttributesList.Rows.Count; i++)
                    {
                        var obj = list1.FirstOrDefault(c => c.AttributeId == grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Id].Value.ToInt());
                        if (obj != null)
                        {
                            grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Default].Value = true;
                            grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.DetailId].Value = obj.Id;
                            grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Qty].Value = obj.Qty.ToInt();
                            grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Price].Value = obj.Price.ToDecimal();
                        }
                    }

                }
                else
                {

                    if (extraChargesOneWaySavedList != null)
                    {
                        var list1 = this.extraChargesOneWaySavedList.ToList();


                        for (int i = 0; i < grdAttributesList.Rows.Count; i++)
                        {
                            var obj = list1.FirstOrDefault(c => c.AttributeId == grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Id].Value.ToInt());
                            if (obj != null)
                            {
                                grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Default].Value = true;
                                grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.DetailId].Value = obj.Id;
                                grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Qty].Value = obj.Qty.ToInt();
                                grdAttributesList.Rows[i].Cells[Col_BookingAttributesList.Price].Value = obj.Price.ToDecimal();
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void LoadReturnBookingAttributesListGrid()
        {

            try
            {
              //  obj.GetByPrimaryKey(obj.Current.BookingReturns[0].Id);

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    //var list = db.ExecuteQuery<ClsBookingAttributes>("select g.Id, b.Id as DetailId, g.Name, g.ShortName, g.MaxQty, g.ChargesPerQty, b.Qty, b.Price,  g.IsActive , b.AttributeId   from Gen_Attribute g left join  Booking_Attributes b on g.Id = b.AttributeId where g.AttributeCategoryId = 3 and g.isActive = 1").ToList();
                    var list = db.ExecuteQuery<ClsBookingAttributes>("select Id, Name, ShortName, MaxQty, ChargesPerQty , IsActive   from Gen_Attribute where AttributeCategoryId = 3 and IsDefault = 1").OrderBy(c => c.Name).ToList();
                    grdReturnAttributesList.RowCount = list.Count;
                    for (int i = 0; i < list.Count; i++)
                    {
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Id].Value = list[i].Id;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Name].Value = list[i].Name;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.ShortName].Value = list[i].ShortName;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.MaxQuantity].Value = list[i].MaxQty;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Charges].Value = list[i].ChargesPerQty;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Qty].Value = 0;
                        grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Price].Value = 0;


                    }
                }


                if (obj.Current!=null && obj.Current.BookingReturns.Count > 0)
                {

                    var list1 = obj.Current.BookingReturns[0].Booking_Attributes.ToList();


                    for (int i = 0; i < grdReturnAttributesList.Rows.Count; i++)
                    {
                        var obj = list1.FirstOrDefault(c => c.AttributeId == grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Id].Value.ToInt());
                        if (obj != null)
                        {
                            grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Default].Value = true;
                            grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.DetailId].Value = obj.Id;
                            grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Qty].Value = obj.Qty.ToInt();
                            grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Price].Value = obj.Price.ToDecimal();
                        }
                    }
                }
                else
                {

                    if (extraChargesReturnSavedList != null)
                    {
                        var list1 = this.extraChargesReturnSavedList.ToList();


                        for (int i = 0; i < grdReturnAttributesList.Rows.Count; i++)
                        {
                            var obj = list1.FirstOrDefault(c => c.AttributeId == grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Id].Value.ToInt());
                            if (obj != null)
                            {
                                grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Default].Value = true;
                                grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.DetailId].Value = obj.Id;
                                grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Qty].Value = obj.Qty.ToInt();
                                grdReturnAttributesList.Rows[i].Cells[Col_ReturnBookingAttributesList.Price].Value = obj.Price.ToDecimal();
                            }
                        }
                    }

                }



            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);

            }
        }

        public decimal totalSelectedAmount = 0.00m;
        public decimal totalReturnSelectedAmount = 0.00m;

        public List<Booking_Attribute> extraChargesOneWaySavedList = null;
        public List<Booking_Attribute> extraChargesReturnSavedList = null;

        public string selectedAtts="", retselectedAtts = "";
        private void SaveAndClose()
        {
            try
            {
               

                if (obj.PrimaryKeyValue != null)
                {
                


                    string[] skipProperties = { "Gen_Attribute", "Booking" , "Gen_AttributesCategory"};

                    IList<Booking_Attribute> savedList3 = obj.Current.Booking_Attributes;
                    List<Booking_Attribute> listofDetail3 = (from r in grdAttributesList.Rows
                                                          //   where r.Cells[Col_BookingAttributesList.Qty].Value.ToInt()>0
                                                           
                                                             select new Booking_Attribute
                                                             {
                                                                 Id = r.Cells[Col_BookingAttributesList.DetailId].Value.ToInt(),
                                                                 AttributeId = r.Cells[Col_BookingAttributesList.Id].Value.ToInt(),
                                                                 BookingId = input_values,
                                                                 Qty = r.Cells[Col_BookingAttributesList.Qty].Value.ToInt(),
                                                                 Price = r.Cells[Col_BookingAttributesList.Price].Value.ToDecimal(),
                                                             }).ToList();

                  
                    Utils.General.SyncChildCollection(ref savedList3, ref listofDetail3, "Id", skipProperties);


                    //for return use this collection
                    

                    if (grdReturnAttributesList.Visible && obj.Current.BookingReturns.Count > 0)
                    {
                        IList<Booking_Attribute> retsavedList3 = obj.Current.BookingReturns[0].Booking_Attributes;
                        List<Booking_Attribute> RetlistofDetail3 = (from r in grdReturnAttributesList.Rows
                                                                    where r.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() > 0

                                                                    select new Booking_Attribute
                                                                    {
                                                                        Id = r.Cells[Col_ReturnBookingAttributesList.DetailId].Value.ToInt(),
                                                                        AttributeId = r.Cells[Col_ReturnBookingAttributesList.Id].Value.ToInt(),
                                                                        BookingId = obj.Current.BookingReturns[0].Id,
                                                                        Qty = r.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt(),
                                                                        Price = r.Cells[Col_ReturnBookingAttributesList.Price].Value.ToDecimal(),
                                                                    }).ToList();


                        Utils.General.SyncChildCollection(ref retsavedList3, ref RetlistofDetail3, "Id", skipProperties);
                    }
                   

                    obj.Save();

                    selectedAtts = string.Join(Environment.NewLine, grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt()>0).Select(c => c.Cells[Col_BookingAttributesList.Name].Value.ToStr()+"(" + c.Cells[Col_BookingAttributesList.Qty].Value.ToStr() + ") - £"+ c.Cells[Col_BookingAttributesList.Price].Value.ToStr()  ).ToArray<string>());

                    totalSelectedAmount = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Sum(c => c.Cells[Col_BookingAttributesList.Price].Value.ToDecimal()).ToDecimal();

                    input_values = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Count();

                    if (grdReturnAttributesList.Visible)
                    {
                        retselectedAtts = string.Join(Environment.NewLine, grdReturnAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Select(c => c.Cells[Col_BookingAttributesList.Name].Value.ToStr() + "(" + c.Cells[Col_BookingAttributesList.Qty].Value.ToStr() + ") - £" + c.Cells[Col_BookingAttributesList.Price].Value.ToStr()).ToArray<string>());
                        totalReturnSelectedAmount = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Sum(c => c.Cells[Col_BookingAttributesList.Price].Value.ToDecimal()).ToDecimal();


                    }
                    //  input_values = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Count();

                }
                else
                {
                    extraChargesOneWaySavedList = (from r in grdAttributesList.Rows
                                                       //   where r.Cells[Col_BookingAttributesList.Qty].Value.ToInt()>0

                                                   select new Booking_Attribute
                                                   {
                                                       Id = r.Cells[Col_BookingAttributesList.DetailId].Value.ToInt(),
                                                       AttributeId = r.Cells[Col_BookingAttributesList.Id].Value.ToInt(),

                                                       Qty = r.Cells[Col_BookingAttributesList.Qty].Value.ToInt(),
                                                       Price = r.Cells[Col_BookingAttributesList.Price].Value.ToDecimal(),
                                                   }).ToList();



                    selectedAtts = string.Join(Environment.NewLine, grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Select(c => c.Cells[Col_BookingAttributesList.Name].Value.ToStr() + "(" + c.Cells[Col_BookingAttributesList.Qty].Value.ToStr() + ") - £" + c.Cells[Col_BookingAttributesList.Price].Value.ToStr()).ToArray<string>());

                    totalSelectedAmount = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Sum(c => c.Cells[Col_BookingAttributesList.Price].Value.ToDecimal()).ToDecimal();

                    input_values = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Count();

                    if (grdReturnAttributesList.Visible)
                    {
                        retselectedAtts = string.Join(Environment.NewLine, grdReturnAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Select(c => c.Cells[Col_BookingAttributesList.Name].Value.ToStr() + "(" + c.Cells[Col_BookingAttributesList.Qty].Value.ToStr() + ") - £" + c.Cells[Col_BookingAttributesList.Price].Value.ToStr()).ToArray<string>());
                        totalReturnSelectedAmount = grdAttributesList.Rows.Where(r => r.Cells[Col_BookingAttributesList.Qty].Value.ToInt() > 0).Sum(c => c.Cells[Col_BookingAttributesList.Price].Value.ToDecimal()).ToDecimal();

                        extraChargesReturnSavedList = (from r in grdReturnAttributesList.Rows
                                                       where r.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt() > 0

                                                       select new Booking_Attribute
                                                       {
                                                           Id = r.Cells[Col_ReturnBookingAttributesList.DetailId].Value.ToInt(),
                                                           AttributeId = r.Cells[Col_ReturnBookingAttributesList.Id].Value.ToInt(),

                                                           Qty = r.Cells[Col_ReturnBookingAttributesList.Qty].Value.ToInt(),
                                                           Price = r.Cells[Col_ReturnBookingAttributesList.Price].Value.ToDecimal(),
                                                       }).ToList();

                    }
                    



                }


                this.Close();

            }
            catch (Exception ex)
            {
                if (obj.Errors.Count > 0)
                    ENUtils.ShowMessage(obj.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            SaveAndClose();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void grdAttributesList_Click(object sender, EventArgs e)
        {

        }

        private void frmAttributesList_Load(object sender, EventArgs e)
        {

        }
    }
}

public class ClsBookingAttributes
{
    public Int32? Id { get; set; }
    public Int32? DetailId { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public int? MaxQty { get; set; }
    public int? AttributeId { get; set; }
    public decimal? ChargesPerQty { get; set; }
    public int? Qty { get; set; }
    public decimal? Price { get; set; }
    public bool IsActive { get; set; }
    

}
