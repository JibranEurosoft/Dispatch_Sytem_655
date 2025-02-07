namespace Taxi_AppMain
{
    partial class frmPendingDriverDocument
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.ddlAllDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.radbtnGroup = new Telerik.WinControls.UI.RadButton();
            this.btnMultiApproved = new Telerik.WinControls.UI.RadButton();
            this.lblTotalLogins = new System.Windows.Forms.Label();
            this.btnMultiRejected = new Telerik.WinControls.UI.RadButton();
            this.grdLister = new UI.MyGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radbtnGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiRejected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
          //  ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnFind);
            this.radPanel1.Controls.Add(this.ddlAllDriver);
            this.radPanel1.Controls.Add(this.chkAllDriver);
            this.radPanel1.Controls.Add(this.radbtnGroup);
            this.radPanel1.Controls.Add(this.btnMultiApproved);
            this.radPanel1.Controls.Add(this.lblTotalLogins);
            this.radPanel1.Controls.Add(this.btnMultiRejected);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1585, 52);
            this.radPanel1.TabIndex = 110;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFind.Location = new System.Drawing.Point(383, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(73, 24);
            this.btnFind.TabIndex = 118;
            this.btnFind.Tag = "";
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ddlAllDriver
            // 
            this.ddlAllDriver.Enabled = false;
            this.ddlAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAllDriver.Location = new System.Drawing.Point(172, 13);
            this.ddlAllDriver.Name = "ddlAllDriver";
            this.ddlAllDriver.Size = new System.Drawing.Size(205, 26);
            this.ddlAllDriver.TabIndex = 117;
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.BackColor = System.Drawing.Color.Transparent;
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(77, 16);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(88, 23);
            this.chkAllDriver.TabIndex = 116;
            this.chkAllDriver.Text = "All Driver";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // radbtnGroup
            // 
            this.radbtnGroup.Location = new System.Drawing.Point(856, 10);
            this.radbtnGroup.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.radbtnGroup.Name = "radbtnGroup";
            this.radbtnGroup.Size = new System.Drawing.Size(106, 34);
            this.radbtnGroup.TabIndex = 17;
            this.radbtnGroup.Text = "Toggle Group";
            this.radbtnGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radbtnGroup.Visible = false;
            this.radbtnGroup.Click += new System.EventHandler(this.radbtnGroup_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radbtnGroup.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radbtnGroup.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radbtnGroup.GetChildAt(0))).Text = "Toggle Group";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radbtnGroup.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radbtnGroup.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMultiApproved
            // 
            this.btnMultiApproved.Location = new System.Drawing.Point(516, 10);
            this.btnMultiApproved.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnMultiApproved.Name = "btnMultiApproved";
            this.btnMultiApproved.Size = new System.Drawing.Size(160, 34);
            this.btnMultiApproved.TabIndex = 15;
            this.btnMultiApproved.Text = "Approved Selected";
            this.btnMultiApproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMultiApproved.Click += new System.EventHandler(this.btnMultiApproved_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiApproved.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiApproved.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiApproved.GetChildAt(0))).Text = "Approved Selected";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMultiApproved.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMultiApproved.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblTotalLogins
            // 
            this.lblTotalLogins.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTotalLogins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLogins.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalLogins.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLogins.Location = new System.Drawing.Point(1569, 0);
            this.lblTotalLogins.Name = "lblTotalLogins";
            this.lblTotalLogins.Size = new System.Drawing.Size(16, 52);
            this.lblTotalLogins.TabIndex = 2;
            this.lblTotalLogins.Text = "Total Login Drivers : 5";
            this.lblTotalLogins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalLogins.Visible = false;
            // 
            // btnMultiRejected
            // 
            this.btnMultiRejected.Location = new System.Drawing.Point(686, 10);
            this.btnMultiRejected.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnMultiRejected.Name = "btnMultiRejected";
            this.btnMultiRejected.Size = new System.Drawing.Size(160, 34);
            this.btnMultiRejected.TabIndex = 1;
            this.btnMultiRejected.Text = "Rejected Selected";
            this.btnMultiRejected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMultiRejected.Click += new System.EventHandler(this.btnMultiRejected_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiRejected.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiRejected.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMultiRejected.GetChildAt(0))).Text = "Rejected Selected";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMultiRejected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMultiRejected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 90);
            // 
            // grdLister
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1585, 690);
            this.grdLister.TabIndex = 113;
            this.grdLister.Text = "myGridView1";
            // 
            // frmPendingDriverDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 780);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormTitle = "Pending Driver Document";
            this.Name = "frmPendingDriverDocument";
            // 
            // 
            // 
         //   this.RootElement.ApplyShapeToControl = true;
         //   this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Pending Driver Document";
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radbtnGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMultiRejected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnMultiRejected;
        private System.Windows.Forms.Label lblTotalLogins;
        private UI.MyGridView grdLister;
        private Telerik.WinControls.UI.RadButton btnMultiApproved;
        private Telerik.WinControls.UI.RadButton radbtnGroup;
        private Telerik.WinControls.UI.RadDropDownList ddlAllDriver;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadButton btnFind;
    }
}