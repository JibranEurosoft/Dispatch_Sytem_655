namespace Taxi_AppMain
{
    partial class frmPaymentEscort
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
            this.txtInvoiceTotal = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtInvoiceno = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblDiscount = new Telerik.WinControls.UI.RadLabel();
            this.txtCreditNote = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblCreditNote = new Telerik.WinControls.UI.RadLabel();
            this.txtNotes = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.btnSaveInvoice = new Telerik.WinControls.UI.RadButton();
            this.ddlEscort = new UI.MyDropDownList();
            this.btnPayment = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreditNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEscort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayment)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(705, 189);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(655, 116);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(655, 266);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(655, 340);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(655, 415);
            // 
            // txtInvoiceTotal
            // 
            this.txtInvoiceTotal.DecimalPlaces = 2;
            this.txtInvoiceTotal.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtInvoiceTotal.Location = new System.Drawing.Point(132, 129);
            this.txtInvoiceTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtInvoiceTotal.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.txtInvoiceTotal.Name = "txtInvoiceTotal";
            this.txtInvoiceTotal.ReadOnly = true;
            // 
            // 
            // 
            this.txtInvoiceTotal.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtInvoiceTotal.ShowBorder = true;
            this.txtInvoiceTotal.ShowUpDownButtons = false;
            this.txtInvoiceTotal.Size = new System.Drawing.Size(109, 25);
            this.txtInvoiceTotal.TabIndex = 219;
            this.txtInvoiceTotal.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.txtInvoiceTotal.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.txtInvoiceTotal.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.txtInvoiceTotal.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            // 
            // txtInvoiceno
            // 
            this.txtInvoiceno.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceno.Location = new System.Drawing.Point(132, 53);
            this.txtInvoiceno.Name = "txtInvoiceno";
            this.txtInvoiceno.ReadOnly = true;
            this.txtInvoiceno.Size = new System.Drawing.Size(109, 24);
            this.txtInvoiceno.TabIndex = 218;
            this.txtInvoiceno.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(16, 54);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 22);
            this.radLabel2.TabIndex = 216;
            this.radLabel2.Text = "Invoice No";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.Red;
            this.radLabel3.Location = new System.Drawing.Point(8, 130);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ForeColor = System.Drawing.Color.Red;
            this.radLabel3.Size = new System.Drawing.Size(116, 23);
            this.radLabel3.TabIndex = 217;
            this.radLabel3.Text = "Invoice Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 221;
            this.label1.Text = "Escort";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(381, 54);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(199, 16);
            this.lblMessage.TabIndex = 222;
            this.lblMessage.Text = "No Invoice exists of this Company";
            this.lblMessage.Visible = false;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscount.Location = new System.Drawing.Point(273, 115);
            this.lblDiscount.Name = "lblDiscount";
            // 
            // 
            // 
            this.lblDiscount.RootElement.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscount.Size = new System.Drawing.Size(2, 2);
            this.lblDiscount.TabIndex = 251;
            this.lblDiscount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCreditNote
            // 
            this.txtCreditNote.DecimalPlaces = 2;
            this.txtCreditNote.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNote.Location = new System.Drawing.Point(583, 90);
            this.txtCreditNote.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtCreditNote.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.txtCreditNote.Name = "txtCreditNote";
            this.txtCreditNote.ReadOnly = true;
            // 
            // 
            // 
            this.txtCreditNote.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtCreditNote.ShowBorder = true;
            this.txtCreditNote.Size = new System.Drawing.Size(109, 21);
            this.txtCreditNote.TabIndex = 253;
            this.txtCreditNote.TabStop = false;
            this.txtCreditNote.Visible = false;
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.txtCreditNote.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.txtCreditNote.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblCreditNote
            // 
            this.lblCreditNote.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNote.ForeColor = System.Drawing.Color.Red;
            this.lblCreditNote.Location = new System.Drawing.Point(496, 90);
            this.lblCreditNote.Name = "lblCreditNote";
            // 
            // 
            // 
            this.lblCreditNote.RootElement.ForeColor = System.Drawing.Color.Red;
            this.lblCreditNote.Size = new System.Drawing.Size(85, 22);
            this.lblCreditNote.TabIndex = 252;
            this.lblCreditNote.Text = "Credit Note";
            this.lblCreditNote.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(130, 179);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            // 
            // 
            // 
            this.txtNotes.RootElement.StretchVertically = true;
            this.txtNotes.Size = new System.Drawing.Size(429, 122);
            this.txtNotes.TabIndex = 254;
            this.txtNotes.TabStop = false;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(14, 189);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(110, 22);
            this.radLabel5.TabIndex = 255;
            this.radLabel5.Text = "Payment Notes";
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveInvoice.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveInvoice.Location = new System.Drawing.Point(131, 349);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(140, 56);
            this.btnSaveInvoice.TabIndex = 256;
            this.btnSaveInvoice.Text = "Save Payment";
            this.btnSaveInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Text = "Save Payment";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ddlEscort
            // 
            this.ddlEscort.Caption = null;
            this.ddlEscort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlEscort.Location = new System.Drawing.Point(130, 92);
            this.ddlEscort.Name = "ddlEscort";
            this.ddlEscort.Property = null;
            this.ddlEscort.ShowDownArrow = true;
            this.ddlEscort.Size = new System.Drawing.Size(290, 23);
            this.ddlEscort.TabIndex = 257;
            // 
            // btnPayment
            // 
            this.btnPayment.Image = global::Taxi_AppMain.Properties.Resources.remove;
            this.btnPayment.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPayment.Location = new System.Drawing.Point(384, 349);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(140, 56);
            this.btnPayment.TabIndex = 258;
            this.btnPayment.Text = "Remove Payment";
            this.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPayment.Visible = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPayment.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.remove;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPayment.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPayment.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPayment.GetChildAt(0))).Text = "Remove Payment";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPayment.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPayment.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmPaymentEscort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(574, 425);
            this.ControlBox = true;
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.ddlEscort);
            this.Controls.Add(this.btnSaveInvoice);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtCreditNote);
            this.Controls.Add(this.lblCreditNote);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceTotal);
            this.Controls.Add(this.txtInvoiceno);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormTitle = "Escort Invoice Payment";
            this.Name = "frmPaymentEscort";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Escort Invoice Payment";
            //////this.ThemeName = "ControlDefault";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.radLabel3, 0);
            this.Controls.SetChildIndex(this.radLabel2, 0);
            this.Controls.SetChildIndex(this.txtInvoiceno, 0);
            this.Controls.SetChildIndex(this.txtInvoiceTotal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.lblDiscount, 0);
            this.Controls.SetChildIndex(this.lblCreditNote, 0);
            this.Controls.SetChildIndex(this.txtCreditNote, 0);
            this.Controls.SetChildIndex(this.radLabel5, 0);
            this.Controls.SetChildIndex(this.txtNotes, 0);
            this.Controls.SetChildIndex(this.btnSaveInvoice, 0);
            this.Controls.SetChildIndex(this.ddlEscort, 0);
            this.Controls.SetChildIndex(this.btnPayment, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreditNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEscort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayment)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadSpinEditor txtInvoiceTotal;
        private Telerik.WinControls.UI.RadTextBox txtInvoiceno;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessage;
        private Telerik.WinControls.UI.RadLabel lblDiscount;
        private Telerik.WinControls.UI.RadSpinEditor txtCreditNote;
        private Telerik.WinControls.UI.RadLabel lblCreditNote;
        private Telerik.WinControls.UI.RadTextBox txtNotes;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadButton btnSaveInvoice;
        private UI.MyDropDownList ddlEscort;
        private Telerik.WinControls.UI.RadButton btnPayment;
    }
}
