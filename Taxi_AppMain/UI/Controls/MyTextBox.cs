using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using System.Drawing;


namespace UI
{
    public class MyTextBox : Telerik.WinControls.UI.RadTextBox,IMyControls
    {
        private string _Caption;

     
        private string _Property;

       
        public MyTextBox()
        {
            base.BackColor = Color.White;

        }

        #region IMyControls Members

        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
            }
        }

       public   string Property
        {
            get
            {
                return this._Property;
            }
            set
            {
                this._Property = value;
            }
        }

       public new string Text
       {
           get
           {
               return base.Text;
           }
           set
           {
               base.Text = value;
           }
       }

        #endregion
    }
}
