using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Utils;
namespace UI
{
   public class MyDatePicker : Telerik.WinControls.UI.RadDateTimePicker
    {
       public MyDatePicker()
       {

   
        //   this.Format = DateTimePickerFormat.Custom;
           this.Validated += new EventHandler(MyDatePicker_Validated);
           this.KeyDown += new KeyEventHandler(MyDatePicker_KeyDown);
           this.Opening += new CancelEventHandler(MyDatePicker_Opening);
            //this.DateTimePickerElement.TextBoxElement.MaskType = MaskType.DateTime;
        }

       void MyDatePicker_Opening(object sender, CancelEventArgs e)
       {
            if (base.Value.Year <= 1753 && Value==null)
           {
                this.DateTimePickerElement.Calendar.FocusedDate = new DateTime(DateTime.Now.Year, 1, 1);


            }
        }

       void MyDatePicker_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.F2)
           {
               this.Value = DateTime.Now;

           }
           else if (base.Value.Year <= 1753)
           {
                if (this.Value == null)
                {
                    if (this.DateTimePickerElement.Value.Value.Year == 1753)
                        this.Value = new DateTime(DateTime.Now.Year, 1, 1);
                    else
                        this.Value = this.DateTimePickerElement.Value;

                }

           }
        
       }

       void MyDatePicker_Validated(object sender, EventArgs e)
       {
           try
           {
                if (this.DateTimePickerElement.Value.Value.Date != new DateTime().Date)
                {
                    if (this.DateTimePickerElement.Value.Value.Year==1753)
                        this.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day);
                    else
                    this.Value = this.DateTimePickerElement.Value;


                }

           }
           catch
           {


           }
       }

        private  DateTime? _Value;

        public new DateTime? Value
        {

           
            get {
                if ( base.Value.Year <= 1753 && base.Value.TimeOfDay==TimeSpan.Zero)
                {
                  //  base.Value = new DateTime(DateTime.Now.Year, 1, 1);

                    return null;
                }
                 

                else
                    return _Value;
            
                }
            set
            {
                _Value = value;
                //if (value == null)
                //    base.Value = new DateTime();
              
              
                //else
                   base.Value=Convert.ToDateTime(value);
            
            }
        
    
        } 

    }
}
