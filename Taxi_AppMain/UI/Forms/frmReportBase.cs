using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace UI
{
    public partial class frmReportBase : RadForm,IReport
    {

        private string _formTitle;

        public string FormTitle
        {
            get { return _formTitle; }
            set
            {
                _formTitle = value;
                this.pnlHeaderTitle.Text = _formTitle;

            }
        }


        private bool _showHeader = false;

        public bool ShowHeader
        {
            get { return _showHeader; }
            set
            {
                _showHeader = value;

                this.pnlHeaderTitle.Visible = _showHeader;
            }
        }



        public frmReportBase()
        {
            InitializeComponent();
        }

        #region IReport Members

        public virtual void GenerateReport()
        {
         
        }

        public virtual void Preview()
        {
        
        }

        #endregion
    }
}
