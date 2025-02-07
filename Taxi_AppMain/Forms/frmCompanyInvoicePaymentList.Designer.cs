namespace Taxi_AppMain
{
    partial class frmCompanyInvoicePaymentList
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.grdLister = new UI.MyGridView();
            this.optDefault = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.OPTDESC = new System.Windows.Forms.RadioButton();
            this.OPTASC = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.optDefault);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.OPTDESC);
            this.radPanel1.Controls.Add(this.OPTASC);
            this.radPanel1.Controls.Add(this.lblInvoiceTotal);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1169, 42);
            this.radPanel1.TabIndex = 112;
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.ForeColor = System.Drawing.Color.Red;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(12, 8);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(143, 23);
            this.lblInvoiceTotal.TabIndex = 1;
            this.lblInvoiceTotal.Text = "Invoice Total:";
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 80);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.EnableFiltering = true;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1169, 715);
            this.grdLister.TabIndex = 114;
            this.grdLister.Text = "myGridView1";
            // 
            // optDefault
            // 
            this.optDefault.AutoSize = true;
            this.optDefault.Checked = true;
            this.optDefault.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDefault.Location = new System.Drawing.Point(517, 11);
            this.optDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDefault.Name = "optDefault";
            this.optDefault.Size = new System.Drawing.Size(70, 18);
            this.optDefault.TabIndex = 33;
            this.optDefault.TabStop = true;
            this.optDefault.Tag = "0";
            this.optDefault.Text = "Default";
            this.optDefault.UseVisualStyleBackColor = true;
            this.optDefault.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(444, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Sort by";
            // 
            // OPTDESC
            // 
            this.OPTDESC.AutoSize = true;
            this.OPTDESC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTDESC.Location = new System.Drawing.Point(720, 11);
            this.OPTDESC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTDESC.Name = "OPTDESC";
            this.OPTDESC.Size = new System.Drawing.Size(95, 18);
            this.OPTDESC.TabIndex = 31;
            this.OPTDESC.TabStop = true;
            this.OPTDESC.Tag = "2";
            this.OPTDESC.Text = "Descending";
            this.OPTDESC.UseVisualStyleBackColor = true;
            this.OPTDESC.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // OPTASC
            // 
            this.OPTASC.AutoSize = true;
            this.OPTASC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTASC.Location = new System.Drawing.Point(609, 11);
            this.OPTASC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTASC.Name = "OPTASC";
            this.OPTASC.Size = new System.Drawing.Size(88, 18);
            this.OPTASC.TabIndex = 30;
            this.OPTASC.TabStop = true;
            this.OPTASC.Tag = "1";
            this.OPTASC.Text = "Ascending";
            this.OPTASC.UseVisualStyleBackColor = true;
            this.OPTASC.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // frmCompanyInvoicePaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 795);
            this.ControlBox = true;
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Invoice payment List";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCompanyInvoicePaymentList";
            this.ShowHeader = true;
            this.Text = "Invoice payment List";
            this.Load += new System.EventHandler(this.frmCompanyInvoicePaymentList_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private UI.MyGridView grdLister;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.RadioButton optDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton OPTDESC;
        private System.Windows.Forms.RadioButton OPTASC;
    }
}