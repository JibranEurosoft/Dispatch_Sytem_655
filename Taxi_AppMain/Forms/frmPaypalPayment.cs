using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Gecko;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public partial class frmPaypalPayment : Form
    {
       
        public frmPaypalPayment()
        {
            InitializeComponent();
            
        }
        public frmPaypalPayment(string Address)
        {
            InitializeComponent();
            try
           {
             //   Xpcom.Initialize("Firefox");
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            //  this.webBrowser1.ScriptErrorsSuppressed = true;

            ShowPaymentForm(Address);
        }



        private  void ShowPaymentForm(string Address)
        {
            try
            {
                if (this.webBrowser1 == null)
                {
                    this.webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser(Address);
                    this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.webBrowser1.Location = new System.Drawing.Point(0, 0);
                    this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
                    this.webBrowser1.Name = "webBrowser1";
                    this.webBrowser1.Size = new System.Drawing.Size(977, 832);
                    this.webBrowser1.TabIndex = 117;
                    this.webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
                  
                    this.Controls.Add(this.webBrowser1);
                }
                else
                this.webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser(Address);
            }
            catch(Exception ex)
            { }
            //webBrowser1.Navigate(Address.ToString());
        }


        public string TransactionId = string.Empty;

        private void WebBrowser1_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            try
            {
                if (e.Frame.IsMain)
                {
                    //e.Frame.ViewSource();
                    e.Frame.GetSourceAsync().ContinueWith(taskHtml =>
                    {
                        var html = taskHtml.Result;

                        if(html.ToStr().Contains("value=\"Success\""))
                        {

                            html =html.Substring(html.IndexOf("\"ReceiptId\" value="));
                            html = html.Substring(0,html.IndexOf(">"));
                            string[] data=     html.Split('=');

                            TransactionId = data[1].Replace("\"", "").Trim();


                        

                            if(TransactionId.ToStr().Contains(":")==false)
                            {
                                TransactionId =  General.GetTransactionDetails(TransactionId.ToLong());

                                TransactionId = TransactionId.Replace("\"", "").Trim();


                            }


                        }
                       
                    });
                }


                

            }
            catch(Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TransactionId.ToStr().Trim().Length > 0)
            {
                timer1.Stop();
                Close();


            }
        }
    }
}
