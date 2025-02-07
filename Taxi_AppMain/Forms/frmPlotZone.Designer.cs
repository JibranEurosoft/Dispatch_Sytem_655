namespace Taxi_AppMain
{
    partial class frmPlotZone
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnMoveDownZone = new Telerik.WinControls.UI.RadButton();
            this.btnMoveUp = new Telerik.WinControls.UI.RadButton();
            this.lstZones = new Telerik.WinControls.UI.RadListControl();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveDownZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstZones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(545, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Size = new System.Drawing.Size(90, 47);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(481, 305);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAndClose.Size = new System.Drawing.Size(113, 69);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.btnMoveDownZone);
            this.radGroupBox1.Controls.Add(this.btnMoveUp);
            this.radGroupBox1.Controls.Add(this.lstZones);
            this.radGroupBox1.HeaderText = "Zones Order";
            this.radGroupBox1.Location = new System.Drawing.Point(1, 60);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            this.radGroupBox1.Size = new System.Drawing.Size(633, 446);
            this.radGroupBox1.TabIndex = 106;
            this.radGroupBox1.Text = "Zones Order";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMoveDownZone
            // 
            this.btnMoveDownZone.Image = global::Taxi_AppMain.Properties.Resources.lc_movedown;
            this.btnMoveDownZone.Location = new System.Drawing.Point(430, 130);
            this.btnMoveDownZone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveDownZone.Name = "btnMoveDownZone";
            this.btnMoveDownZone.Size = new System.Drawing.Size(168, 34);
            this.btnMoveDownZone.TabIndex = 2;
            this.btnMoveDownZone.Text = "Move Down";
            this.btnMoveDownZone.Click += new System.EventHandler(this.btnMoveDownZone_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMoveDownZone.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_movedown;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMoveDownZone.GetChildAt(0))).Text = "Move Down";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveDownZone.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveDownZone.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveDownZone.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            this.btnMoveUp.Location = new System.Drawing.Point(430, 65);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(168, 34);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMoveUp.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMoveUp.GetChildAt(0))).Text = "Move Up";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveUp.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveUp.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMoveUp.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstZones
            // 
            this.lstZones.Location = new System.Drawing.Point(16, 30);
            this.lstZones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstZones.Name = "lstZones";
            this.lstZones.Size = new System.Drawing.Size(391, 400);
            this.lstZones.TabIndex = 0;
            this.lstZones.Text = "radListControl1";
            // 
            // radButton1
            // 
            this.radButton1.Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            this.radButton1.Location = new System.Drawing.Point(430, 23);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(168, 34);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "Move to Top";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Move to Top";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPlotZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 521);
            this.Controls.Add(this.radGroupBox1);
            this.FixedExitButtonOnTopRight = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Plot Zone";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPlotZone";
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.ShowSaveAndCloseButton = true;
            this.Text = "Zone Ordering";
            this.Controls.SetChildIndex(this.radGroupBox1, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveDownZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstZones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadListControl lstZones;
        private Telerik.WinControls.UI.RadButton btnMoveUp;
        private Telerik.WinControls.UI.RadButton btnMoveDownZone;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}