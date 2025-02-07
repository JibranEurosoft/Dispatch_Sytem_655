namespace Taxi_AppMain
{
    partial class frmRefundJob
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDespatchHeading = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefund = new Telerik.WinControls.UI.RadButton();
            this.txtCustomerMobNo = new System.Windows.Forms.Label();
            this.txtDriverMobNo = new System.Windows.Forms.Label();
            this.lblSmsError1 = new System.Windows.Forms.Label();
            this.lblSMSError2 = new System.Windows.Forms.Label();
            this.numRefundAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBookingRef = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChargeDetails = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefundAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDespatchHeading
            // 
            this.lblDespatchHeading.BackColor = System.Drawing.Color.LightYellow;
            this.lblDespatchHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDespatchHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespatchHeading.ForeColor = System.Drawing.Color.Black;
            this.lblDespatchHeading.Location = new System.Drawing.Point(0, 0);
            this.lblDespatchHeading.Name = "lblDespatchHeading";
            this.lblDespatchHeading.Size = new System.Drawing.Size(384, 27);
            this.lblDespatchHeading.TabIndex = 0;
            this.lblDespatchHeading.Text = "Refund ";
            this.lblDespatchHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(162, 246);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(130, 41);
            this.btnRefund.TabIndex = 5;
            this.btnRefund.Text = "Refund";
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRefund.GetChildAt(0))).Text = "Refund";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRefund.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRefund.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRefund.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerMobNo
            // 
            this.txtCustomerMobNo.AutoSize = true;
            this.txtCustomerMobNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerMobNo.Location = new System.Drawing.Point(229, 163);
            this.txtCustomerMobNo.Name = "txtCustomerMobNo";
            this.txtCustomerMobNo.Size = new System.Drawing.Size(0, 14);
            this.txtCustomerMobNo.TabIndex = 9;
            this.txtCustomerMobNo.Visible = false;
            // 
            // txtDriverMobNo
            // 
            this.txtDriverMobNo.AutoSize = true;
            this.txtDriverMobNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverMobNo.Location = new System.Drawing.Point(229, 187);
            this.txtDriverMobNo.Name = "txtDriverMobNo";
            this.txtDriverMobNo.Size = new System.Drawing.Size(0, 14);
            this.txtDriverMobNo.TabIndex = 10;
            this.txtDriverMobNo.Visible = false;
            // 
            // lblSmsError1
            // 
            this.lblSmsError1.AutoSize = true;
            this.lblSmsError1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmsError1.ForeColor = System.Drawing.Color.DeepPink;
            this.lblSmsError1.Location = new System.Drawing.Point(16, 49);
            this.lblSmsError1.Name = "lblSmsError1";
            this.lblSmsError1.Size = new System.Drawing.Size(0, 14);
            this.lblSmsError1.TabIndex = 11;
            this.lblSmsError1.Visible = false;
            // 
            // lblSMSError2
            // 
            this.lblSMSError2.AutoSize = true;
            this.lblSMSError2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSError2.ForeColor = System.Drawing.Color.DeepPink;
            this.lblSMSError2.Location = new System.Drawing.Point(16, 49);
            this.lblSMSError2.Name = "lblSMSError2";
            this.lblSMSError2.Size = new System.Drawing.Size(0, 14);
            this.lblSMSError2.TabIndex = 12;
            this.lblSMSError2.Visible = false;
            // 
            // numRefundAmount
            // 
            this.numRefundAmount.DecimalPlaces = 2;
            this.numRefundAmount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRefundAmount.ForeColor = System.Drawing.Color.Red;
            this.numRefundAmount.InterceptArrowKeys = false;
            this.numRefundAmount.Location = new System.Drawing.Point(162, 103);
            this.numRefundAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numRefundAmount.Name = "numRefundAmount";
            this.numRefundAmount.Size = new System.Drawing.Size(65, 26);
            this.numRefundAmount.TabIndex = 13;
            this.numRefundAmount.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Booking Ref#";
            // 
            // lblBookingRef
            // 
            this.lblBookingRef.AutoSize = true;
            this.lblBookingRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRef.Location = new System.Drawing.Point(104, 49);
            this.lblBookingRef.Name = "lblBookingRef";
            this.lblBookingRef.Size = new System.Drawing.Size(0, 16);
            this.lblBookingRef.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "charged  Amount";
            // 
            // lblChargeDetails
            // 
            this.lblChargeDetails.AutoSize = true;
            this.lblChargeDetails.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargeDetails.Location = new System.Drawing.Point(126, 71);
            this.lblChargeDetails.Name = "lblChargeDetails";
            this.lblChargeDetails.Size = new System.Drawing.Size(0, 16);
            this.lblChargeDetails.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Refund  Amount";
            // 
            // frmRefundJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblChargeDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBookingRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRefundAmount);
            this.Controls.Add(this.lblSMSError2);
            this.Controls.Add(this.lblSmsError1);
            this.Controls.Add(this.txtDriverMobNo);
            this.Controls.Add(this.txtCustomerMobNo);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDespatchHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRefundJob";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Refund Amount";
            ((System.ComponentModel.ISupportInitialize)(this.btnRefund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefundAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDespatchHeading;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton btnRefund;
        private System.Windows.Forms.Label txtCustomerMobNo;
        private System.Windows.Forms.Label txtDriverMobNo;
        private System.Windows.Forms.Label lblSmsError1;
        private System.Windows.Forms.Label lblSMSError2;

        private Telerik.WinControls.UI.RadLabel lblNearestDrv;
        private System.Windows.Forms.DataGridView grdNearestDrv;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverId;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
        private System.Windows.Forms.DataGridViewButtonColumn btnDespatchJob;
        private System.Windows.Forms.NumericUpDown numRefundAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBookingRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChargeDetails;
        private System.Windows.Forms.Label label4;
    }
}