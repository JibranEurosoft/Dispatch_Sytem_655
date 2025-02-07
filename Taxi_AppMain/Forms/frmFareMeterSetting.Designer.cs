namespace Taxi_AppMain
{
    partial class frmFareMeterSetting
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel113 = new Telerik.WinControls.UI.RadLabel();
            this.ddlFareMeterType = new Telerik.WinControls.UI.RadDropDownList();
            this.pnlMeterDetails = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdBookingFeeRange = new Telerik.WinControls.UI.RadGridView();
            this.chkChangePlotOnAsDirected = new Telerik.WinControls.UI.RadCheckBox();
            this.chkRemoveExtraCharges = new Telerik.WinControls.UI.RadCheckBox();
            this.spnExtraChargesPerQty = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.chkShowParkingCharges = new Telerik.WinControls.UI.RadCheckBox();
            this.chkShowBookingFee = new Telerik.WinControls.UI.RadCheckBox();
            this.chkShowExtraCharges = new Telerik.WinControls.UI.RadCheckBox();
            this.chkEnablePeakOffPeakWiseFares = new Telerik.WinControls.UI.RadCheckBox();
            this.spnMeterRoundedValue = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblFareValue = new Telerik.WinControls.UI.RadLabel();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.grdFareMeterSetting = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFareMeterType)).BeginInit();
            this.pnlMeterDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeRange.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePlotOnAsDirected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveExtraCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnExtraChargesPerQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowParkingCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowBookingFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExtraCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnablePeakOffPeakWiseFares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMeterRoundedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFareValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFareMeterSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFareMeterSetting.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radLabel113);
            this.panel1.Controls.Add(this.ddlFareMeterType);
            this.panel1.Controls.Add(this.pnlMeterDetails);
            this.panel1.Controls.Add(this.btnExit1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.grdFareMeterSetting);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1447, 784);
            this.panel1.TabIndex = 138;
            // 
            // radLabel113
            // 
            this.radLabel113.BackColor = System.Drawing.Color.Transparent;
            this.radLabel113.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel113.ForeColor = System.Drawing.Color.Black;
            this.radLabel113.Location = new System.Drawing.Point(19, 7);
            this.radLabel113.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel113.Name = "radLabel113";
            this.radLabel113.Size = new System.Drawing.Size(133, 22);
            this.radLabel113.TabIndex = 157;
            this.radLabel113.Text = "Fare Meter Type";
            // 
            // ddlFareMeterType
            // 
            this.ddlFareMeterType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlFareMeterType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFareMeterType.Location = new System.Drawing.Point(195, 4);
            this.ddlFareMeterType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlFareMeterType.Name = "ddlFareMeterType";
            this.ddlFareMeterType.Size = new System.Drawing.Size(258, 24);
            this.ddlFareMeterType.TabIndex = 158;
            // 
            // pnlMeterDetails
            // 
            this.pnlMeterDetails.Controls.Add(this.groupBox1);
            this.pnlMeterDetails.Controls.Add(this.chkChangePlotOnAsDirected);
            this.pnlMeterDetails.Controls.Add(this.chkRemoveExtraCharges);
            this.pnlMeterDetails.Controls.Add(this.spnExtraChargesPerQty);
            this.pnlMeterDetails.Controls.Add(this.radLabel1);
            this.pnlMeterDetails.Controls.Add(this.chkShowParkingCharges);
            this.pnlMeterDetails.Controls.Add(this.chkShowBookingFee);
            this.pnlMeterDetails.Controls.Add(this.chkShowExtraCharges);
            this.pnlMeterDetails.Controls.Add(this.chkEnablePeakOffPeakWiseFares);
            this.pnlMeterDetails.Controls.Add(this.spnMeterRoundedValue);
            this.pnlMeterDetails.Controls.Add(this.lblFareValue);
            this.pnlMeterDetails.Location = new System.Drawing.Point(8, 30);
            this.pnlMeterDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMeterDetails.Name = "pnlMeterDetails";
            this.pnlMeterDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMeterDetails.Size = new System.Drawing.Size(1284, 204);
            this.pnlMeterDetails.TabIndex = 0;
            this.pnlMeterDetails.TabStop = false;
            this.pnlMeterDetails.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdBookingFeeRange);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(611, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(465, 182);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking Fee Range";
            // 
            // grdBookingFeeRange
            // 
            this.grdBookingFeeRange.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBookingFeeRange.Location = new System.Drawing.Point(7, 23);
            this.grdBookingFeeRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdBookingFeeRange.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.grdBookingFeeRange.MasterTemplate.AllowAddNewRow = false;
            this.grdBookingFeeRange.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdBookingFeeRange.Name = "grdBookingFeeRange";
            this.grdBookingFeeRange.ShowGroupPanel = false;
            this.grdBookingFeeRange.Size = new System.Drawing.Size(453, 151);
            this.grdBookingFeeRange.TabIndex = 148;
            this.grdBookingFeeRange.Text = "radGridView2";
            // 
            // chkChangePlotOnAsDirected
            // 
            this.chkChangePlotOnAsDirected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChangePlotOnAsDirected.Location = new System.Drawing.Point(2, 36);
            this.chkChangePlotOnAsDirected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkChangePlotOnAsDirected.Name = "chkChangePlotOnAsDirected";
            this.chkChangePlotOnAsDirected.Size = new System.Drawing.Size(215, 21);
            this.chkChangePlotOnAsDirected.TabIndex = 168;
            this.chkChangePlotOnAsDirected.Text = "Change Plot On As Directed";
            // 
            // chkRemoveExtraCharges
            // 
            this.chkRemoveExtraCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemoveExtraCharges.Location = new System.Drawing.Point(2, 100);
            this.chkRemoveExtraCharges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRemoveExtraCharges.Name = "chkRemoveExtraCharges";
            this.chkRemoveExtraCharges.Size = new System.Drawing.Size(182, 21);
            this.chkRemoveExtraCharges.TabIndex = 167;
            this.chkRemoveExtraCharges.Text = "Remove Extra Charges";
            // 
            // spnExtraChargesPerQty
            // 
            this.spnExtraChargesPerQty.DecimalPlaces = 2;
            this.spnExtraChargesPerQty.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnExtraChargesPerQty.Location = new System.Drawing.Point(225, 133);
            this.spnExtraChargesPerQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spnExtraChargesPerQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spnExtraChargesPerQty.Name = "spnExtraChargesPerQty";
            // 
            // 
            // 
            this.spnExtraChargesPerQty.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.spnExtraChargesPerQty.RootElement.StretchVertically = true;
            this.spnExtraChargesPerQty.Size = new System.Drawing.Size(73, 26);
            this.spnExtraChargesPerQty.TabIndex = 166;
            this.spnExtraChargesPerQty.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(2, 133);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(158, 22);
            this.radLabel1.TabIndex = 165;
            this.radLabel1.Text = "Extra Charges Per Qty";
            // 
            // chkShowParkingCharges
            // 
            this.chkShowParkingCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowParkingCharges.Location = new System.Drawing.Point(318, 68);
            this.chkShowParkingCharges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowParkingCharges.Name = "chkShowParkingCharges";
            this.chkShowParkingCharges.Size = new System.Drawing.Size(179, 21);
            this.chkShowParkingCharges.TabIndex = 162;
            this.chkShowParkingCharges.Text = "Show Parking Charges";
            // 
            // chkShowBookingFee
            // 
            this.chkShowBookingFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowBookingFee.Location = new System.Drawing.Point(318, 37);
            this.chkShowBookingFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowBookingFee.Name = "chkShowBookingFee";
            this.chkShowBookingFee.Size = new System.Drawing.Size(151, 21);
            this.chkShowBookingFee.TabIndex = 164;
            this.chkShowBookingFee.Text = "Show Booking Fee";
            // 
            // chkShowExtraCharges
            // 
            this.chkShowExtraCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowExtraCharges.Location = new System.Drawing.Point(2, 66);
            this.chkShowExtraCharges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowExtraCharges.Name = "chkShowExtraCharges";
            this.chkShowExtraCharges.Size = new System.Drawing.Size(163, 21);
            this.chkShowExtraCharges.TabIndex = 163;
            this.chkShowExtraCharges.Text = "Show Extra Charges";
            // 
            // chkEnablePeakOffPeakWiseFares
            // 
            this.chkEnablePeakOffPeakWiseFares.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnablePeakOffPeakWiseFares.Location = new System.Drawing.Point(730, 5);
            this.chkEnablePeakOffPeakWiseFares.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnablePeakOffPeakWiseFares.Name = "chkEnablePeakOffPeakWiseFares";
            this.chkEnablePeakOffPeakWiseFares.Size = new System.Drawing.Size(213, 21);
            this.chkEnablePeakOffPeakWiseFares.TabIndex = 161;
            this.chkEnablePeakOffPeakWiseFares.Text = "Enable Peak OffPeak Fares";
            this.chkEnablePeakOffPeakWiseFares.Visible = false;
            // 
            // spnMeterRoundedValue
            // 
            this.spnMeterRoundedValue.DecimalPlaces = 1;
            this.spnMeterRoundedValue.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnMeterRoundedValue.Location = new System.Drawing.Point(1216, 12);
            this.spnMeterRoundedValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spnMeterRoundedValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spnMeterRoundedValue.Name = "spnMeterRoundedValue";
            // 
            // 
            // 
            this.spnMeterRoundedValue.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.spnMeterRoundedValue.RootElement.StretchVertically = true;
            this.spnMeterRoundedValue.Size = new System.Drawing.Size(73, 26);
            this.spnMeterRoundedValue.TabIndex = 160;
            this.spnMeterRoundedValue.TabStop = false;
            this.spnMeterRoundedValue.Visible = false;
            // 
            // lblFareValue
            // 
            this.lblFareValue.BackColor = System.Drawing.Color.Transparent;
            this.lblFareValue.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFareValue.ForeColor = System.Drawing.Color.Black;
            this.lblFareValue.Location = new System.Drawing.Point(990, 5);
            this.lblFareValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFareValue.Name = "lblFareValue";
            this.lblFareValue.Size = new System.Drawing.Size(163, 22);
            this.lblFareValue.TabIndex = 159;
            this.lblFareValue.Text = "Fare Rounded Value";
            this.lblFareValue.Visible = false;
            // 
            // btnExit1
            // 
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.Location = new System.Drawing.Point(698, 677);
            this.btnExit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(108, 54);
            this.btnExit1.TabIndex = 146;
            this.btnExit1.Text = "Exit";
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSave.Location = new System.Drawing.Point(506, 677);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 54);
            this.btnSave.TabIndex = 145;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdFareMeterSetting
            // 
            this.grdFareMeterSetting.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFareMeterSetting.Location = new System.Drawing.Point(6, 236);
            this.grdFareMeterSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdFareMeterSetting.MasterTemplate.AllowAddNewRow = false;
            this.grdFareMeterSetting.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdFareMeterSetting.Name = "grdFareMeterSetting";
            this.grdFareMeterSetting.ShowGroupPanel = false;
            this.grdFareMeterSetting.Size = new System.Drawing.Size(1437, 427);
            this.grdFareMeterSetting.TabIndex = 144;
            this.grdFareMeterSetting.Text = "radGridView2";
            this.grdFareMeterSetting.Click += new System.EventHandler(this.grdFareMeterSetting_Click);
            // 
            // frmFareMeterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 823);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Fare Meter Settings";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFareMeterSetting";
            this.ShowHeader = true;
            this.Text = "Fare Meter Settings";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFareMeterType)).EndInit();
            this.pnlMeterDetails.ResumeLayout(false);
            this.pnlMeterDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeRange.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePlotOnAsDirected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveExtraCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnExtraChargesPerQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowParkingCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowBookingFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExtraCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnablePeakOffPeakWiseFares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMeterRoundedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFareValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFareMeterSetting.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFareMeterSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGridView grdFareMeterSetting;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.GroupBox pnlMeterDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView grdBookingFeeRange;
        private Telerik.WinControls.UI.RadCheckBox chkChangePlotOnAsDirected;
        private Telerik.WinControls.UI.RadCheckBox chkRemoveExtraCharges;
        private Telerik.WinControls.UI.RadSpinEditor spnExtraChargesPerQty;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadCheckBox chkShowParkingCharges;
        private Telerik.WinControls.UI.RadCheckBox chkShowBookingFee;
        private Telerik.WinControls.UI.RadCheckBox chkShowExtraCharges;
        private Telerik.WinControls.UI.RadCheckBox chkEnablePeakOffPeakWiseFares;
        private Telerik.WinControls.UI.RadSpinEditor spnMeterRoundedValue;
        private Telerik.WinControls.UI.RadLabel lblFareValue;
        private Telerik.WinControls.UI.RadLabel radLabel113;
        private Telerik.WinControls.UI.RadDropDownList ddlFareMeterType;
    }
}