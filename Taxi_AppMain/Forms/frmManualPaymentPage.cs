using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Taxi_BLL;

namespace Taxi_AppMain.Forms
{
    public partial class frmManualPaymentPage : Taxi_AppMain.Forms.BaseForm
    {
        public string inputValue = "";
        public long JobId;
        public int PaymentTypeId;
        public string TransactionId;
        public frmManualPaymentPage(string message,long jbId)
        {
            InitializeComponent();
            this.Load += FrmManualPaymentPage_Load;

            this.inputValue = message;
            this.JobId = jbId;
        }

        private void FrmManualPaymentPage_Load(object sender, EventArgs e)
        {
            var arr = this.inputValue.Split('|');


            txtHeading.Text = arr[1].ToStr();
           



            btnSave.Tag = 1;

        }

        private void OPTCard_CheckedChanged(object sender, EventArgs e)
        {
            if (OPTCard.Checked)
            {
                btnSave.Text = "Process the Payment";

                btnSave.Tag = 1;
            }
        }

        private void OptCash_CheckedChanged(object sender, EventArgs e)
        {
            if (OPTCard.Checked)
            {
                btnSave.Text = "Clear as CASH";

                btnSave.Tag = 2;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
               
            if(btnSave.Tag.ToInt()==2)
            {
                this.PaymentTypeId = 1;


            }
           else  if (btnSave.Tag.ToInt() == 1)
            {
                this.PaymentTypeId = Enums.PAYMENT_TYPES.CREDIT_CARD;


            }
        }
    }
}
