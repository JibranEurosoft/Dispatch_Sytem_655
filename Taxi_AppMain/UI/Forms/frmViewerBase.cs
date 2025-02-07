using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI;
using DAL;
using Utils;
using Telerik.WinControls.UI;
using System.IO;
using System.Xml;
using Microsoft.Reporting.WinForms;
using Telerik.WinControls;

namespace UI
{
    public partial class frmViewerBase : UI.frmReportBase
    {
        public  ReportDataSource _DataSource;

        public ReportDataSource DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private string _ReportName;

        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value; }
        }

        public frmViewerBase()
        {
            InitializeComponent();
        }

        private void rptfrmViewer_Load(object sender, EventArgs e)
        {

         //   AppVars.frmReportViewer = this;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
         

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.GenerateReport();
        }

     

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public virtual void GenerateReport()
        {
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string reportType=optExcel.ToggleState== Telerik.WinControls.Enumerations.ToggleState.On
                                  ?"Excel":"Pdf";

            string toEmail=txtTo.Text.Trim();
            if (toEmail == string.Empty)
            {
                RadMessageBox.Show("Required : To Email");
                return;
            }

            if (toEmail.IsValidEmailAddress() == false)
            {
                RadMessageBox.Show("To Email is not in a correct format");
                return;
            }


            try
            {
                SendEmail(reportType, toEmail, txtSubject.Text.Trim(), txtMessage.Text.Trim());

                txtMessage.Text = string.Empty;
                txtSubject.Text = string.Empty;
                txtTo.Text = string.Empty;
            }
            catch(Exception ex)
            {

               
            }
        }        protected virtual void SendEmail(string reportType,string toEmail,string subject,string messageBody)        {        }
    }
}
