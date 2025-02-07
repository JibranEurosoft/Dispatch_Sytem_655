namespace Taxi_AppMain
{
    partial class frmGridViewDisplaySettings
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
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcol = new System.Windows.Forms.Label();
            this.btn_Save = new Telerik.WinControls.UI.RadButton();
            this.grdview = new Telerik.WinControls.UI.RadGridView();
            this.btn_ColumnChooser = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ColumnChooser)).BeginInit();
            this.panel1.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(982, 72);
            this.btnSaveOn.Size = new System.Drawing.Size(10, 56);
            this.btnSaveOn.Click += new System.EventHandler(this.btnSaveOn_Click);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(922, 145);
            this.btnOnNew.Size = new System.Drawing.Size(70, 25);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(904, 0);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(922, 338);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(922, 413);
            // 
            // btnEmail
            // 
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.resultset_next;
            this.btnEmail.Location = new System.Drawing.Point(163, 51);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(142, 38);
            this.btnEmail.TabIndex = 106;
            this.btnEmail.Tag = "";
            this.btnEmail.Text = "Move To Right";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.resultset_next;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Move To Right";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // radButton1
            // 
            this.radButton1.Image = global::Taxi_AppMain.Properties.Resources.previous_resultset;
            this.radButton1.Location = new System.Drawing.Point(20, 51);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(137, 38);
            this.radButton1.TabIndex = 106;
            this.radButton1.Tag = "";
            this.radButton1.Text = "Move To Left ";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.previous_resultset;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Move To Left ";
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 107;
            this.label1.Text = "Grid Move To <<  Left Right  >>";
            this.label1.Visible = false;
            // 
            // lblcol
            // 
            this.lblcol.AutoSize = true;
            this.lblcol.Location = new System.Drawing.Point(302, 32);
            this.lblcol.Name = "lblcol";
            this.lblcol.Size = new System.Drawing.Size(194, 16);
            this.lblcol.TabIndex = 107;
            this.lblcol.Text = "Grid Move To <<  Left Right  >>";
            this.lblcol.Visible = false;
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            this.btn_Save.Location = new System.Drawing.Point(569, 49);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(180, 38);
            this.btn_Save.TabIndex = 106;
            this.btn_Save.Tag = "";
            this.btn_Save.Text = "Save Settings";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.Click += new System.EventHandler(this.btnSaveOn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_Save.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_Save.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_Save.GetChildAt(0))).Text = "Save Settings";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_Save.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_Save.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_Save.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_Save.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // grdview
            // 
            this.grdview.AutoScroll = true;
            this.grdview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grdview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdview.EnableHotTracking = false;
            this.grdview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdview.Location = new System.Drawing.Point(0, 138);
            this.grdview.Name = "grdview";
            this.grdview.ReadOnly = true;
            this.grdview.ShowGroupPanel = false;
            this.grdview.Size = new System.Drawing.Size(1552, 637);
            this.grdview.TabIndex = 108;
            this.grdview.Text = "myGridView1";
            this.grdview.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdview_CellFormatting);
            this.grdview.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.grdview_CellBeginEdit);
            this.grdview.CurrentColumnChanged += new Telerik.WinControls.UI.CurrentColumnChangedEventHandler(this.grdview_CurrentColumnChanged);
            this.grdview.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdview_CellClick);
            this.grdview.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.grdview_ContextMenuOpening);
            // 
            // btn_ColumnChooser
            // 
            this.btn_ColumnChooser.Image = global::Taxi_AppMain.Properties.Resources.View_Booking;
            this.btn_ColumnChooser.Location = new System.Drawing.Point(791, 49);
            this.btn_ColumnChooser.Name = "btn_ColumnChooser";
            this.btn_ColumnChooser.Size = new System.Drawing.Size(180, 38);
            this.btn_ColumnChooser.TabIndex = 106;
            this.btn_ColumnChooser.Tag = "";
            this.btn_ColumnChooser.Text = "Column Chooser";
            this.btn_ColumnChooser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ColumnChooser.Click += new System.EventHandler(this.btn_ColumnChooser_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_ColumnChooser.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.View_Booking;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_ColumnChooser.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_ColumnChooser.GetChildAt(0))).Text = "Column Chooser";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btn_ColumnChooser.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_ColumnChooser.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_ColumnChooser.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_ColumnChooser.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_ColumnChooser);
            this.panel1.Controls.Add(this.radButton1);
            this.panel1.Controls.Add(this.lblcol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1552, 100);
            this.panel1.TabIndex = 109;
            // 
            // frmGridViewDisplaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 775);
            this.ControlBox = true;
            this.Controls.Add(this.grdview);
            this.Controls.Add(this.panel1);
            this.FixedExitButtonOnTopRight = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.FormTitle = "Dashboard Grid Column Sellector";
            this.KeyPreview = true;
            this.MinimizeBox = true;
            this.Name = "frmGridViewDisplaySettings";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "frmDailogDashboardColumnChooser";
            this.Load += new System.EventHandler(this.frmDailogDashboardColumnChooser_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdview, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ColumnChooser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnEmail;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcol;
        private Telerik.WinControls.UI.RadButton btn_Save;
        private Telerik.WinControls.UI.RadGridView grdview;
        private Telerik.WinControls.UI.RadButton btn_ColumnChooser;
        private System.Windows.Forms.Panel panel1;
    }
}