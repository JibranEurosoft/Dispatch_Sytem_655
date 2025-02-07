namespace UI
{
    partial class SetupBase
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
            this.pnlHeaderTitle = new Telerik.WinControls.UI.RadPanel();
            this.btnOnNew = new Telerik.WinControls.UI.RadButton();
            this.btnSaveOn = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnSaveAndClose = new Telerik.WinControls.UI.RadButton();
            this.btnSaveAndNew = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeaderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderTitle
            // 
            this.pnlHeaderTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.pnlHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderTitle.Name = "pnlHeaderTitle";
            this.pnlHeaderTitle.Size = new System.Drawing.Size(1050, 38);
            this.pnlHeaderTitle.TabIndex = 16;
            this.pnlHeaderTitle.Text = "Form Title";
            this.pnlHeaderTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHeaderTitle.Visible = false;
            // 
            // btnOnNew
            // 
            this.btnOnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnNew.Image = global::Taxi_AppMain.Properties.Resources.AddBig;
            this.btnOnNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOnNew.Location = new System.Drawing.Point(518, 548);
            this.btnOnNew.Name = "btnOnNew";
            this.btnOnNew.Size = new System.Drawing.Size(70, 56);
            this.btnOnNew.TabIndex = 102;
            this.btnOnNew.Text = "New";
            this.btnOnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOnNew.Visible = false;
            this.btnOnNew.Click += new System.EventHandler(this.btnOnNew_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnOnNew.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.AddBig;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnOnNew.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnOnNew.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnOnNew.GetChildAt(0))).Text = "New";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnOnNew.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnOnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnOnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnOnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOn.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveOn.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveOn.Location = new System.Drawing.Point(607, 548);
            this.btnSaveOn.Name = "btnSaveOn";
            this.btnSaveOn.Size = new System.Drawing.Size(70, 56);
            this.btnSaveOn.TabIndex = 101;
            this.btnSaveOn.Text = "Save";
            this.btnSaveOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveOn.Visible = false;
            this.btnSaveOn.Click += new System.EventHandler(this.btnSaveOn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveOn.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveOn.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveOn.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveOn.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveOn.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveOn.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveOn.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveOn.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.Location = new System.Drawing.Point(226, 548);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 56);
            this.btnExit.TabIndex = 103;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveAndClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveAndClose.Location = new System.Drawing.Point(315, 548);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(79, 56);
            this.btnSaveAndClose.TabIndex = 104;
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Visible = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndClose.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndClose.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndClose.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndClose.GetChildAt(0))).Text = "Save && Close";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveAndClose.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveAndNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveAndNew.Location = new System.Drawing.Point(422, 548);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(79, 56);
            this.btnSaveAndNew.TabIndex = 105;
            this.btnSaveAndNew.Text = "Save && New";
            this.btnSaveAndNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndNew.Visible = false;
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSaveAndNew_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndNew.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndNew.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndNew.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAndNew.GetChildAt(0))).Text = "Save && New";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveAndNew.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAndNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupBase
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1050, 896);
            this.ControlBox = false;
            this.Controls.Add(this.pnlHeaderTitle);
            this.Controls.Add(this.btnOnNew);
            this.Controls.Add(this.btnSaveOn);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnSaveAndNew);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeaderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadButton btnSaveOn;
        public Telerik.WinControls.UI.RadButton btnOnNew;
        public Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadPanel pnlHeaderTitle;
        public Telerik.WinControls.UI.RadButton btnSaveAndClose;
        public Telerik.WinControls.UI.RadButton btnSaveAndNew;



    }
}