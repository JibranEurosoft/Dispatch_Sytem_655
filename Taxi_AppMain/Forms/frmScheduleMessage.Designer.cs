namespace Taxi_AppMain
{
    partial class frmScheduleMessage
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
            this.btnSaveClose = new Telerik.WinControls.UI.RadButton();
            this.grdMain = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtptilltime = new UI.MyDatePicker();
            this.dtpFromTime = new UI.MyDatePicker();
            this.dtpToDate = new UI.MyDatePicker();
            this.dtpFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbALAD = new System.Windows.Forms.RadioButton();
            this.rbALD = new System.Windows.Forms.RadioButton();
            this.txtMessage = new UI.AutoCompleteTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtInterval = new System.Windows.Forms.NumericUpDown();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnNew = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(698, 169);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(698, 242);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(605, 0);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(698, 322);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(698, 397);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveClose.Location = new System.Drawing.Point(531, 302);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(72, 56);
            this.btnSaveClose.TabIndex = 112;
            this.btnSaveClose.Text = "Save";
            this.btnSaveClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveClose.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveClose.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveClose.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveClose.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdMain
            // 
            this.grdMain.EnableHotTracking = false;
            this.grdMain.Location = new System.Drawing.Point(9, 365);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.Size = new System.Drawing.Size(870, 267);
            this.grdMain.TabIndex = 113;
            this.grdMain.Text = "Schedule Messages List";
            this.grdMain.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdMain_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "Till Date Time";
            // 
            // dtptilltime
            // 
            this.dtptilltime.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtptilltime.CustomFormat = "HH:mm";
            this.dtptilltime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptilltime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptilltime.Location = new System.Drawing.Point(290, 86);
            this.dtptilltime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtptilltime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtptilltime.Name = "dtptilltime";
            this.dtptilltime.NullDate = new System.DateTime(((long)(0)));
            this.dtptilltime.ShowUpDown = true;
            this.dtptilltime.Size = new System.Drawing.Size(73, 24);
            this.dtptilltime.TabIndex = 122;
            this.dtptilltime.TabStop = false;
            this.dtptilltime.Text = "myDatePicker1";
            this.dtptilltime.Value = new System.DateTime(2014, 10, 21, 0, 0, 0, 0);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpFromTime.CustomFormat = "HH:mm";
            this.dtpFromTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(111, 86);
            this.dtpFromTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(73, 24);
            this.dtpFromTime.TabIndex = 121;
            this.dtpFromTime.TabStop = false;
            this.dtpFromTime.Text = "myDatePicker1";
            this.dtpFromTime.Value = new System.DateTime(2014, 10, 21, 0, 0, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(188, 86);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpToDate.Size = new System.Drawing.Size(102, 24);
            this.dtpToDate.TabIndex = 120;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Text = "myDatePicker1";
            this.dtpToDate.Value = null;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(9, 86);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromDate.Size = new System.Drawing.Size(102, 24);
            this.dtpFromDate.TabIndex = 119;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 118;
            this.label2.Text = "From Date Time";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 126;
            this.label3.Text = "Interval (In Hour)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbALAD);
            this.groupBox1.Controls.Add(this.rbALD);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 58);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For";
            // 
            // rbALAD
            // 
            this.rbALAD.AutoSize = true;
            this.rbALAD.Location = new System.Drawing.Point(196, 23);
            this.rbALAD.Name = "rbALAD";
            this.rbALAD.Size = new System.Drawing.Size(258, 22);
            this.rbALAD.TabIndex = 1;
            this.rbALAD.TabStop = true;
            this.rbALAD.Text = "All Logged In Available Drivers";
            this.rbALAD.UseVisualStyleBackColor = true;
            // 
            // rbALD
            // 
            this.rbALD.AutoSize = true;
            this.rbALD.Location = new System.Drawing.Point(6, 23);
            this.rbALD.Name = "rbALD";
            this.rbALD.Size = new System.Drawing.Size(184, 22);
            this.rbALD.TabIndex = 0;
            this.rbALD.TabStop = true;
            this.rbALD.Text = "All Logged In Drivers";
            this.rbALD.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMessage.DefaultHeight = 0;
            this.txtMessage.DefaultWidth = 0;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtMessage.ForceListBoxToUpdate = false;
            this.txtMessage.FormerValue = "";
            this.txtMessage.Location = new System.Drawing.Point(9, 211);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            // 
            // 
            // 
            this.txtMessage.RootElement.StretchVertically = true;
            this.txtMessage.SelectedItem = null;
            this.txtMessage.Size = new System.Drawing.Size(863, 85);
            this.txtMessage.TabIndex = 238;
            this.txtMessage.TabStop = false;
            this.txtMessage.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtMessage.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMessage.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 237;
            this.label4.Text = "Message";
            // 
            // txtInterval
            // 
            this.txtInterval.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterval.Location = new System.Drawing.Point(371, 86);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(106, 23);
            this.txtInterval.TabIndex = 239;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(9, 44);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 21);
            this.txtID.TabIndex = 240;
            this.txtID.TabStop = false;
            this.txtID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(609, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 56);
            this.btnClose.TabIndex = 241;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Text = "Close";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.Location = new System.Drawing.Point(453, 303);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 56);
            this.btnNew.TabIndex = 242;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).Text = "New";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmScheduleMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 537);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtptilltime);
            this.Controls.Add(this.dtpFromTime);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveClose);
            this.FixedExitButtonOnTopRight = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormTitle = "Schedule Messages";
            this.Name = "frmScheduleMessage";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.Text = "Schedule Messages";
            this.Controls.SetChildIndex(this.btnSaveClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.dtpToDate, 0);
            this.Controls.SetChildIndex(this.dtpFromTime, 0);
            this.Controls.SetChildIndex(this.dtptilltime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtMessage, 0);
            this.Controls.SetChildIndex(this.txtInterval, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.grdMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btnSaveClose;
        private Telerik.WinControls.UI.RadGridView grdMain;
        private System.Windows.Forms.Label label1;
        private UI.MyDatePicker dtptilltime;
        private UI.MyDatePicker dtpFromTime;
        private UI.MyDatePicker dtpToDate;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbALAD;
        private System.Windows.Forms.RadioButton rbALD;
        private UI.AutoCompleteTextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown txtInterval;
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnNew;
    }
}