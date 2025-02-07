using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Microsoft.Reporting.WinForms;

namespace UI
{
    public  class GeneralFunctions
    {

        public static void ClearAllFields(Form form)
        {
            string empty=string.Empty;

            var list=form.Controls.OfType<RadTextBox>().ToList();

            var conts = form.Controls;
            var c = conts[0];
        
            foreach (Control control in list)
            {

                control.Text = empty;
                control.Tag = null;
                
            }


        }


        //public static void ViewReport(string reportEmbeddedResourceName,object dataSource)
        //{
        //    ReportDataSource ds = new ReportDataSource("abc", dataSource);

        //    AppVars.frmReportViewer._DataSource = ds;
        //    AppVars.frmReportViewer.ReportName = reportEmbeddedResourceName;

        //    AppVars.frmReportViewer.GenerateReport();
        //}
    }
}
