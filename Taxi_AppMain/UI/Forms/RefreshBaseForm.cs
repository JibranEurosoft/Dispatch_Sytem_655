using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using DAL;
using System.Collections;

namespace UI.Forms
{
    public partial class RefreshBaseForm : Form
    {
        public RefreshBaseForm()
        {
            InitializeComponent();
        }

         RadGridView _Grid;

        public RadGridView Grid
        {
            get { return _Grid; }
            set { _Grid = value; }
        }

      
        SqlCommand command = null;
        DataSet myDataSet = null;

      


      

       


        protected void SetRefreshingProperties(SqlCommand cmd, RadGridView grid,bool AllowDelete)
          
        {

            command = cmd;

            this.Grid = grid;
            this.Grid.Font = new Font("Tahoma", 10, FontStyle.Regular); 

            if (myDataSet == null)
                myDataSet = new DataSet();

            PopulateData(null);

            if(AllowDelete)
                UI.GridFunctions.AddDeleteColumn(this.Grid);

        }
    

        protected virtual bool OnDisposeForm()
       {
           return false;

       }


        delegate void UIDelegate(SqlNotificationEventArgs info);
        public void dependency_OnChange(object sender, SqlNotificationEventArgs e)
       
        {
            try
            {
            //    if (OnDisposeForm() == false)
            //    {

                    // if (CanRePopulateList == false) return;
                    UIDelegate uidel = new UIDelegate(PopulateData);
                    if (this.InvokeRequired && this.Disposing == false)
                    {
                        this.Invoke(uidel, e);
                    }

                    SqlDependency dependency = (SqlDependency)sender;
                    dependency.OnChange -= dependency_OnChange;
                //}
            }
            catch
            {


            }
        }

      
      
        public virtual void PopulateData(SqlNotificationEventArgs info)
        {
          
            if (command == null || myDataSet == null) return;

           // GridViewRowInfo row = new GridViewRowInfo();
            int index =Grid.CurrentRow==null ?-1: Grid.CurrentRow.Index;

            myDataSet = new DataSet();
       //     myDataSet.Clear();
            command.Notification = null;
            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                adapter.Fill(myDataSet, "A");
                this.Grid.DataSource = myDataSet;
                this.Grid.DataMember = "A";
            }


            GridFunctions.SetFilter(this.Grid);
            this.Grid.AllowAutoSizeColumns = true;
            this.Grid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            this.Grid.ShowNoDataText = false;
            if (Grid.Columns["ColDelete"] != null)
                Grid.Columns["ColDelete"].Width = 40;

            Grid.CurrentRow = Grid.Rows.FirstOrDefault(c => c.Index == index);


        }

        private bool _CanRePopulateList = true;

        public bool CanRePopulateList
        {
            get { return _CanRePopulateList; }
            set { _CanRePopulateList = value; }
        }
    }
}
