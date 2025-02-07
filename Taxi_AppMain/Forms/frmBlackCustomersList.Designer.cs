namespace Taxi_AppMain
{
    partial class frmBlackCustomersList
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.btnExport = new Telerik.WinControls.UI.RadButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkAll = new System.Windows.Forms.RadioButton();
            this.chkByAddress = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.grdLister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.chkAll);
            this.radPanel1.Controls.Add(this.radProgressBar1);
            this.radPanel1.Controls.Add(this.btnExport);
            this.radPanel1.Controls.Add(this.chkByAddress);
            this.radPanel1.Controls.Add(this.lblTotal);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1188, 42);
            this.radPanel1.TabIndex = 106;
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Location = new System.Drawing.Point(769, 5);
            this.radProgressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.Size = new System.Drawing.Size(175, 32);
            this.radProgressBar1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            this.btnExport.Location = new System.Drawing.Point(602, 5);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(161, 30);
            this.btnExport.TabIndex = 6;
            this.btnExport.Tag = "";
            this.btnExport.Text = "Export To Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Text = "Export To Excel";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(915, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(273, 42);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total Customer(s) : 5";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdLister
            // 
            this.grdLister.Controls.Add(this.radGridView1);
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableHotTracking = false;
            this.grdLister.Location = new System.Drawing.Point(0, 80);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdLister.Name = "grdLister";
            this.grdLister.Size = new System.Drawing.Size(1188, 873);
            this.grdLister.TabIndex = 107;
            this.grdLister.Text = "myGridView1";
            this.grdLister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdLister_MouseDown);
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(665, 47);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(280, 185);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel Files (.xls)|*.xls|Advanced Excel Files (.xlsx)|*.xlsx";
            this.saveFileDialog1.FilterIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(17, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(46, 22);
            this.chkAll.TabIndex = 9;
            this.chkAll.TabStop = true;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkByAddress
            // 
            this.chkByAddress.AutoSize = true;
            this.chkByAddress.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkByAddress.Location = new System.Drawing.Point(95, 10);
            this.chkByAddress.Name = "chkByAddress";
            this.chkByAddress.Size = new System.Drawing.Size(210, 22);
            this.chkByAddress.TabIndex = 10;
            this.chkByAddress.Text = "Blacklisted with Address";
            this.chkByAddress.UseVisualStyleBackColor = true;
            // 
            // frmBlackCustomersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 953);
            this.ControlBox = true;
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Black List Customers";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBlackCustomersList";
            this.ShowHeader = true;
            this.Text = "Black List Customers";
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.grdLister.ResumeLayout(false);
            this.grdLister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private System.Windows.Forms.Label lblTotal;
        private Telerik.WinControls.UI.RadButton btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.RadioButton chkAll;
        private System.Windows.Forms.RadioButton chkByAddress;
    }
}