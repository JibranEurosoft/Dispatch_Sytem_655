using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Utils;
using System.Drawing;
using System.Windows.Forms;
using Taxi_AppMain.Resources;
namespace UI
{
    public class MyGridView : Telerik.WinControls.UI.RadGridView
    {
        public MyGridView()
            : base()
        {
      
         
        }

      

        private bool IsAttachedCheckInCheckOut=false;

        private bool _EnableCheckInCheckOut=false;

        public bool EnableCheckInCheckOut
        {
            get { return _EnableCheckInCheckOut; }
            set { _EnableCheckInCheckOut = value;

                    if (value && IsAttachedCheckInCheckOut==false)
                    {
                        this.CellDoubleClick += new GridViewCellEventHandler(MyGridView_CellDoubleClick);
                    
                        IsAttachedCheckInCheckOut = true;
                    }
            
                }
        }

     

        private string _PKFieldColumnName="";

        public string PKFieldColumnName
        {
            get { return _PKFieldColumnName; }
            set { _PKFieldColumnName = value; }
        }


        private bool _AutoCellFormatting;

        public bool AutoCellFormatting
        {
            get { return _AutoCellFormatting; }
            set { _AutoCellFormatting = value;

            if (value && HasAutoFormatting==false)
            {
                this.ViewCellFormatting += new CellFormattingEventHandler(MyGridView_ViewCellFormatting);
                HasAutoFormatting = true;
            }
            else
            {
                this.ViewCellFormatting -= new CellFormattingEventHandler(MyGridView_ViewCellFormatting);

                HasAutoFormatting = false;

            }

            this.EnableHotTracking = !value;
            
            
                }
        }



        public void AddEditColumn()
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();


            col.Name = "btnEdit";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Edit";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            this.Columns.Add(col);




        }

        public void AddDeleteColumn()
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.BestFit();

            col.Name = "btnDelete";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Delete";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            this.Columns.Add(col);

        }



        private bool HasAutoFormatting = false;

        void MyGridView_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PKFieldColumnName.Trim()) && e.Row.Cells[PKFieldColumnName] == null) return;

                if (MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL == null)
                {
                    RadMessageBox.Show("Back Object not Defined, (SetProperties Required.");
                    return;
                }

                object value = e.Row.Cells[PKFieldColumnName].Value;

                MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL.GetByPrimaryKey(value);

                //if (MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL.PrimaryKeyValue != null)
                //{
                //    if (MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL.CanCheckIn == false)
                //    {
                //        if (MainMenuForm.MainMenuFrm.objSetupBase.CheckOutForcefully)
                //        {
                //            if (DialogResult.Yes == RadMessageBox.Show("Record is Locked... " + Environment.NewLine +
                //                                "Do you want to Checkout Forcefully ?", "Message", MessageBoxButtons.YesNo))
                //            {

                //                MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL.CheckIn(false);
                //                RadMessageBox.Show("Checkout Successfully...");
                //            }

                //        }
                //        else
                //        {
                //            RadMessageBox.Show("Record is Locked...");
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        //         MainMenuForm.MainMenuFrm.objSetupBase.CanRePopulateList = false;
                //        MainMenuForm.MainMenuFrm.objSetupBase.ObjBLL.CheckIn(true);

                //        if (OnAfterCheckIn != null)
                //            OnAfterCheckIn(this, value);

                    

                //    }
                //}
          //      MainMenuForm.MainMenuFrm.objSetupBase.CanRePopulateList = true;

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
         //       MainMenuForm.MainMenuFrm.objSetupBase.CanRePopulateList = true;

            }

             
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

        private bool _ShowImageOnActionButton=true;

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
                        button.Image = Resource1.edit2;
                    }
                     else if (button.Text == "Delete")
                    {

                        button.Image =  Resource1.delete;
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

    }
}
