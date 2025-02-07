using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace UI.UserControls
{
    public partial class MyAutoCompleteTextBox : UserControl
    {
         private IEnumerable<string> _AutoCompleteDataSource;


      

        public RadTextBox TextBoxElement
        {
            get { return this.txtData; }
            set { this.txtData = value; }
        }

        private RadListControl _ListBoxElement;

        public RadListControl ListBoxElement
            {
                get { return this._ListBoxElement; }
              set { _ListBoxElement = value; }
            }
        
        public new string Text
        {
            get { return txtData.Text; }
            set { txtData.Text = value; }
        }

        public IEnumerable<string> AutoCompleteDataSource
        {
            get { return _AutoCompleteDataSource; }
            set {
                
                 _AutoCompleteDataSource = value;


                 SetAutoCompleteDataSource();
            
                }
        }

        private IQueryable<string> _AutoDataSource;


        public IQueryable<string> AutoDataSource
        {
            get { return _AutoDataSource; }
            set
            {

                _AutoDataSource = value;


                SetAutoDataSource();

            }
        }

        public void SetAutoDataSource()
        {
           
            //if (this.AutoDataSource == null) return;

            try
            {

            //    lst_AutoComplete.Items.Clear();
            ////    lst_AutoComplete.Items.AddRange(this.AutoDataSource.AsEnumerable());
            //    foreach (var item in AutoDataSource)
            //    {
            //        lst_AutoComplete.Items.Add(item);
            //        //lst_AutoComplete.it.Font = f;
            //        //item.ForeColor = Color.FromArgb(21, 66, 139);
            //    }




                //foreach (var item in lst_AutoComplete.Items)
                //{
                   
                //}


                OnSelectData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


    

        public int MaxLength
        {
            get { return txtData.MaxLength; }
            set { txtData.MaxLength = value; }
        }

      
        public MyAutoCompleteTextBox()
        {
            InitializeComponent();
            this.HeightVal = this.Size.Height;
            this.lst_AutoComplete.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(lst_AutoComplete_SelectedIndexChanged);
            this.txtData.MaxLength = 100;
           
            this.lst_AutoComplete.ItemHeight = 22;

            this.ListBoxElement = lst_AutoComplete;
            this.actualWidth = this.Size.Width;
            this.tempWidth = 290;
            this.Leave += new EventHandler(MyAutoCompleteTextBox_Leave);
         
        }

      

        void MyAutoCompleteTextBox_Leave(object sender, EventArgs e)
        {
            lst_AutoComplete.Items.Clear();
            OnSelectData();
        }

       

        void lst_AutoComplete_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string value = lst_AutoComplete.SelectedItem.Text;
          
            lst_AutoComplete.Items.Clear();
            OnSelectData();
            txtData.Text = value;
        }

        private int HeightVal;

        Font f = new Font("Tahoma", 10, FontStyle.Bold);

        private void SetAutoCompleteDataSource()
        {
            if (this.AutoCompleteDataSource == null) return;

            lst_AutoComplete.Items.Clear();
            lst_AutoComplete.Items.AddRange(this.AutoCompleteDataSource);





            foreach (var item in lst_AutoComplete.Items)
            {
                item.Font = f;
                item.ForeColor = Color.FromArgb(21, 66, 139);
            }


            OnSelectData();


        }

       

        private void lst_AutoComplete_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        int actualWidth;
        int tempWidth;
        private void OnSelectData()
        {
            lst_AutoComplete.Visible = lst_AutoComplete.Items.Count > 0;
            if (lst_AutoComplete.Visible)
            {


             
                this.Size = new Size(this.tempWidth, 170);
            }
            else
            {

            
                this.Size = new Size(this.actualWidth, this.HeightVal);
            }

         

        }

        private void lst_AutoComplete_TextChanged(object sender, EventArgs e)
        {

            

        }
    }
}
