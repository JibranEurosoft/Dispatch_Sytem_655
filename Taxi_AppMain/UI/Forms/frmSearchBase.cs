using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using DAL;
using System.Collections;
using Utils;

namespace UI
{
    public partial class frmSearchBase : SetupBase
    {
        private string _Criteria;

        public string Criteria
        {
            get { return _Criteria; }
            set { _Criteria = value; }
        }
        private RadGridView _Grid;

        public RadGridView Grid
        {
            get { return this.grdLister.Grid; }
            set { this.grdLister.Grid = value; }
        }

        private string _SearchTitle;

        public string SearchTitle
        {
            get { return this.grdLister.Header.Text; }
            set { this.grdLister.Header.Text = value; }
        }

        private string _SearchString;

        public string SearchString
        {
            get { return this._SearchString; }
            set { this._SearchString = value; }
        }


        public frmSearchBase()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSearchBase_Load);
           
        }

        void Grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
          //  throw new NotImplementedException();
        }

        void frmSearchBase_Load(object sender, EventArgs e)
        {
            this.Grid.CellDoubleClick += new GridViewCellEventHandler(Grid_CellDoubleClick);
            this.grdLister.Header.ForeColor = Color.Gainsboro;
            this.grdLister.Header.BackColor = Color.SteelBlue;
            this.grdLister.Header.Font = new Font("Tahoma", 12, FontStyle.Bold);

            this.grdLister.Header.Height = 20;
            this.grdLister.Header.TextAlignment = ContentAlignment.MiddleLeft;


            this.Grid.AllowAutoSizeColumns = true;
            this.Grid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;


            FormatControlsTags();
        }


       

        private void btnExport_Click(object sender, EventArgs e)
        {
       
            ExportToExcel();
        }


        protected void BindDataSource(IQueryable datasource)
        {
            this.grdLister.Grid.DataSource = datasource;
            GridFunctions.SetFilter(this.grdLister.Grid);


        }

        private void ExportToExcel()
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {

                var excelML = new Telerik.WinControls.UI.Export.ExportToExcelML(this.Grid);
                excelML.RunExport(this.Grid, saveFileDialog1.FileName, Telerik.WinControls.UI.Export.ExcelMaxRows._1048576, false);
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetFields();
            BeforeSearch();

           
            Search();
            SaveSearch();
        }


        protected virtual void Search()
        {


        }


        protected virtual void BeforeSearch()
        {


        }

        protected void SetFields()
        {
            StringBuilder whereClause = new StringBuilder();
            StringBuilder searchStr = new StringBuilder();
            MyTextBox txt;
            MyDropDownList ddl;
            foreach (Control c in this.Controls[1].Controls.OfType<IMyControls>().Where(c=>!string.IsNullOrEmpty(c.Property) && !(string.IsNullOrEmpty(c.Text))))
            {
                if (whereClause.Length > 0)
                    whereClause.AppendFormat(" && ");

                if (searchStr.Length > 0)
                    searchStr.AppendFormat(" And ");

                if (c is MyTextBox)
                {
                    txt =(MyTextBox) c;
                    whereClause.AppendFormat(txt.Property.ToStr() + ".ToString() = \"{0}\"",txt.Text.Trim().ToLower());
                    searchStr.Append(txt.Caption + " = " + txt.Text);
                }

                else if (c is MyDropDownList)
                {
                    ddl=(MyDropDownList) c;
                    whereClause.AppendFormat(ddl.Property.ToStr() + ".ToString() = \"{0}\"", ddl.SelectedValue);
                    searchStr.Append(ddl.Caption + " = " + ddl.Text);
                }
            }

            this.Criteria= whereClause.ToString();
            this.SearchString = searchStr.ToString();
        }



        protected virtual void ViewSearches()
        {


        }

        protected virtual void SaveSearch()
        {


        }

        protected virtual void FormatControlsTags()
        {



        }

        private void btnSaveSearch_Click(object sender, EventArgs e)
        {
            SaveSearch();
        }

        private void btnViewSearches_Click(object sender, EventArgs e)
        {
            ViewSearches();
        }


    }
}
