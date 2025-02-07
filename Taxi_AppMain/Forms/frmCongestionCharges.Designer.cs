namespace Taxi_AppMain
{
    partial class frmCongestionCharges
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdCongestionCharges = new UI.MyGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlFromDay = new System.Windows.Forms.ComboBox();
            this.ddlTillDay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCongestionCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCongestionCharges.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(598, 54);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 477);
            this.tabControl1.TabIndex = 106;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdCongestionCharges);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Congestion Charges";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdCongestionCharges
            // 
            this.grdCongestionCharges.AutoCellFormatting = false;
            this.grdCongestionCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCongestionCharges.EnableCheckInCheckOut = false;
            this.grdCongestionCharges.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdCongestionCharges.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdCongestionCharges.Location = new System.Drawing.Point(3, 3);
            this.grdCongestionCharges.Name = "grdCongestionCharges";
            this.grdCongestionCharges.PKFieldColumnName = "";
            this.grdCongestionCharges.ShowImageOnActionButton = true;
            this.grdCongestionCharges.Size = new System.Drawing.Size(897, 445);
            this.grdCongestionCharges.TabIndex = 2;
            this.grdCongestionCharges.Text = "radGridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 514);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 83);
            this.panel1.TabIndex = 107;
            // 
            // btnExit1
            // 
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.Location = new System.Drawing.Point(338, 11);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(109, 60);
            this.btnExit1.TabIndex = 221;
            this.btnExit1.Text = "Exit";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            this.btnSave.Location = new System.Drawing.Point(193, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 60);
            this.btnSave.TabIndex = 220;
            this.btnSave.Text = "Save";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(411, 52);
            this.dtpTillDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(156, 24);
            this.dtpTillDate.TabIndex = 210;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Text = "myDatePicker2";
            this.dtpTillDate.Value = null;
            this.dtpTillDate.Visible = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(363, 54);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(27, 22);
            this.radLabel3.TabIndex = 209;
            this.radLabel3.Text = "Till";
            this.radLabel3.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(179, 52);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(158, 24);
            this.dtpFromDate.TabIndex = 208;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            this.dtpFromDate.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(105, 54);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 22);
            this.radLabel2.TabIndex = 207;
            this.radLabel2.Text = "From";
            this.radLabel2.Visible = false;
            // 
            // ddlFromDay
            // 
            this.ddlFromDay.FormattingEnabled = true;
            this.ddlFromDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.ddlFromDay.Location = new System.Drawing.Point(179, 78);
            this.ddlFromDay.Name = "ddlFromDay";
            this.ddlFromDay.Size = new System.Drawing.Size(138, 21);
            this.ddlFromDay.TabIndex = 215;
            this.ddlFromDay.Visible = false;
            // 
            // ddlTillDay
            // 
            this.ddlTillDay.FormattingEnabled = true;
            this.ddlTillDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.ddlTillDay.Location = new System.Drawing.Point(411, 78);
            this.ddlTillDay.Name = "ddlTillDay";
            this.ddlTillDay.Size = new System.Drawing.Size(138, 21);
            this.ddlTillDay.TabIndex = 216;
            this.ddlTillDay.Visible = false;
            // 
            // frmCongestionCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 597);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpTillDate);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlFromDay);
            this.Controls.Add(this.ddlTillDay);
            this.FormTitle = "Congestion Charges";
            this.Name = "frmCongestionCharges";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Congestion Charges";
            this.Controls.SetChildIndex(this.ddlTillDay, 0);
            this.Controls.SetChildIndex(this.ddlFromDay, 0);
            this.Controls.SetChildIndex(this.radLabel2, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.radLabel3, 0);
            this.Controls.SetChildIndex(this.dtpTillDate, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCongestionCharges.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCongestionCharges)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private UI.MyGridView grdCongestionCharges;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ComboBox ddlFromDay;
        private System.Windows.Forms.ComboBox ddlTillDay;
    }
}