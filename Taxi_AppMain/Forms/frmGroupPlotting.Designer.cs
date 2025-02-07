namespace Taxi_AppMain
{
    partial class frmGroupPlotting
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtGroupName = new Telerik.WinControls.UI.RadTextBox();
            this.txtShortName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdZonesList = new Telerik.WinControls.UI.RadGridView();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.grdGroupPlotting = new Telerik.WinControls.UI.RadGridView();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZonesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZonesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupPlotting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupPlotting.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(518, 49);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(438, 49);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(598, 49);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(14, 18);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 18);
            this.radLabel1.TabIndex = 17;
            this.radLabel1.Text = "Group Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(138, 18);
            this.txtGroupName.MaxLength = 100;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(242, 21);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.TabStop = false;
            // 
            // txtShortName
            // 
            this.txtShortName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortName.Location = new System.Drawing.Point(138, 46);
            this.txtShortName.MaxLength = 50;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(242, 21);
            this.txtShortName.TabIndex = 2;
            this.txtShortName.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(14, 46);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 18);
            this.radLabel2.TabIndex = 19;
            this.radLabel2.Text = "Short Name";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radGroupBox1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 38);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1106, 391);
            this.radPanel2.TabIndex = 43;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.Controls.Add(this.grdZonesList);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtGroupName);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.txtShortName);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBox1.Size = new System.Drawing.Size(1106, 385);
            this.radGroupBox1.TabIndex = 44;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Standard;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.LightSteelBlue;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdZonesList
            // 
            this.grdZonesList.EnableHotTracking = false;
            this.grdZonesList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdZonesList.Location = new System.Drawing.Point(3, 96);
            // 
            // grdZonesList
            // 
            this.grdZonesList.MasterTemplate.AllowAddNewRow = false;
            this.grdZonesList.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.grdZonesList.MasterTemplate.AllowDeleteRow = false;
            this.grdZonesList.MasterTemplate.ShowColumnHeaders = false;
            this.grdZonesList.Name = "grdZonesList";
            this.grdZonesList.ShowGroupPanel = false;
            this.grdZonesList.Size = new System.Drawing.Size(608, 276);
            this.grdZonesList.TabIndex = 45;
            this.grdZonesList.Text = "radGridView1";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.grdGroupPlotting);
            this.radPanel3.Controls.Add(this.radLabel9);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.Location = new System.Drawing.Point(0, 429);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1106, 288);
            this.radPanel3.TabIndex = 44;
            // 
            // grdGroupPlotting
            // 
            this.grdGroupPlotting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGroupPlotting.EnableHotTracking = false;
            this.grdGroupPlotting.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdGroupPlotting.Location = new System.Drawing.Point(0, 21);
            // 
            // grdGroupPlotting
            // 
            this.grdGroupPlotting.MasterTemplate.AllowAddNewRow = false;
            this.grdGroupPlotting.MasterTemplate.AllowDeleteRow = false;
            this.grdGroupPlotting.MasterTemplate.AllowEditRow = false;
            this.grdGroupPlotting.Name = "grdGroupPlotting";
            this.grdGroupPlotting.ShowGroupPanel = false;
            this.grdGroupPlotting.Size = new System.Drawing.Size(1106, 267);
            this.grdGroupPlotting.TabIndex = 1;
            this.grdGroupPlotting.Text = "radGridView1";
            this.grdGroupPlotting.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdUsers_CellDoubleClick);
            // 
            // radLabel9
            // 
            this.radLabel9.AutoSize = false;
            this.radLabel9.BackColor = System.Drawing.Color.DodgerBlue;
            this.radLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.ForeColor = System.Drawing.Color.White;
            this.radLabel9.Location = new System.Drawing.Point(0, 0);
            this.radLabel9.Name = "radLabel9";
            // 
            // 
            // 
            this.radLabel9.RootElement.ForeColor = System.Drawing.Color.White;
            this.radLabel9.Size = new System.Drawing.Size(1106, 21);
            this.radLabel9.TabIndex = 0;
            this.radLabel9.Text = "Plot Group List";
            this.radLabel9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmGroupPlotting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 717);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radPanel2);
            this.FormTitle = "Plot Groups";
            this.Name = "frmGroupPlotting";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowAddNewButton = true;
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.ShowSaveButton = true;
            this.Text = "Plot Groups";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.Shown += new System.EventHandler(this.frmUsers_Shown);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.radPanel3, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZonesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZonesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupPlotting.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupPlotting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtGroupName;
        private Telerik.WinControls.UI.RadTextBox txtShortName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadGridView grdGroupPlotting;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdZonesList;
    }
}