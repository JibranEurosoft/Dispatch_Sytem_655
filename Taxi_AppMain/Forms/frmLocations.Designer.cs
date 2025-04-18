﻿namespace Taxi_AppMain
{
    partial class frmLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocations));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDriverAttributes = new Telerik.WinControls.UI.RadGridView();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtLng = new Telerik.WinControls.UI.RadTextBox();
            this.txtLat = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtShortCutKey = new Telerik.WinControls.UI.RadTextBox();
            this.chkShortKey = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.numExtraChrgs = new Telerik.WinControls.UI.RadSpinEditor();
            this.ddlZone = new UI.MyDropDownList();
            this.ddlLocationType = new UI.MyDropDownList();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPostCode = new Telerik.WinControls.UI.RadTextBox();
            this.txtLocName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortCutKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLocationType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(446, 273);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnOnNew.Image")));
            this.btnOnNew.Location = new System.Drawing.Point(510, 402);
            this.btnOnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOnNew.Size = new System.Drawing.Size(92, 56);
            this.btnOnNew.TabIndex = 7;
            this.btnOnNew.Text = "Add New Location";
            this.btnOnNew.TextWrap = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.btnExit.Location = new System.Drawing.Point(772, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(736, 402);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(624, 402);
            this.btnSaveAndNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAndNew.TabIndex = 6;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.grdDriverAttributes);
            this.radPanel1.Controls.Add(this.btnSearch);
            this.radPanel1.Controls.Add(this.txtLng);
            this.radPanel1.Controls.Add(this.txtLat);
            this.radPanel1.Controls.Add(this.radLabel8);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.txtShortCutKey);
            this.radPanel1.Controls.Add(this.chkShortKey);
            this.radPanel1.Controls.Add(this.radLabel17);
            this.radPanel1.Controls.Add(this.numExtraChrgs);
            this.radPanel1.Controls.Add(this.ddlZone);
            this.radPanel1.Controls.Add(this.ddlLocationType);
            this.radPanel1.Controls.Add(this.txtAddress);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.txtPostCode);
            this.radPanel1.Controls.Add(this.txtLocName);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Location = new System.Drawing.Point(6, 43);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(839, 517);
            this.radPanel1.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 20);
            this.label1.TabIndex = 157;
            this.label1.Text = "Attributes";
            this.label1.Visible = false;
            // 
            // grdDriverAttributes
            // 
            this.grdDriverAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDriverAttributes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDriverAttributes.Location = new System.Drawing.Point(15, 251);
            this.grdDriverAttributes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverAttributes.MasterTemplate.AllowAddNewRow = false;
            this.grdDriverAttributes.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDriverAttributes.Name = "grdDriverAttributes";
            this.grdDriverAttributes.ShowGroupPanel = false;
            this.grdDriverAttributes.Size = new System.Drawing.Size(426, 255);
            this.grdDriverAttributes.TabIndex = 156;
            this.grdDriverAttributes.Text = "Attributes";
            this.grdDriverAttributes.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(542, 190);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 30);
            this.btnSearch.TabIndex = 155;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtLng
            // 
            this.txtLng.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLng.Location = new System.Drawing.Point(381, 193);
            this.txtLng.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLng.MaxLength = 100;
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(136, 21);
            this.txtLng.TabIndex = 154;
            this.txtLng.TabStop = false;
            // 
            // txtLat
            // 
            this.txtLat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLat.Location = new System.Drawing.Point(134, 193);
            this.txtLat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLat.MaxLength = 100;
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(136, 21);
            this.txtLat.TabIndex = 153;
            this.txtLat.TabStop = false;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(286, 196);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(60, 18);
            this.radLabel8.TabIndex = 152;
            this.radLabel8.Text = "Longitude";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(13, 196);
            this.radLabel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(50, 18);
            this.radLabel6.TabIndex = 151;
            this.radLabel6.Text = "Latitude";
            // 
            // txtShortCutKey
            // 
            this.txtShortCutKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortCutKey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortCutKey.Location = new System.Drawing.Point(604, 30);
            this.txtShortCutKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtShortCutKey.MaxLength = 20;
            this.txtShortCutKey.Name = "txtShortCutKey";
            this.txtShortCutKey.Size = new System.Drawing.Size(101, 21);
            this.txtShortCutKey.TabIndex = 148;
            this.txtShortCutKey.TabStop = false;
            // 
            // chkShortKey
            // 
            this.chkShortKey.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkShortKey.Location = new System.Drawing.Point(493, 31);
            this.chkShortKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShortKey.Name = "chkShortKey";
            this.chkShortKey.Size = new System.Drawing.Size(90, 18);
            this.chkShortKey.TabIndex = 147;
            this.chkShortKey.Text = "Shortcut Key";
            this.chkShortKey.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkShortKey_ToggleStateChanged);
            // 
            // radLabel17
            // 
            this.radLabel17.BackColor = System.Drawing.Color.Transparent;
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.ForeColor = System.Drawing.Color.Black;
            this.radLabel17.Location = new System.Drawing.Point(524, 124);
            this.radLabel17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(95, 19);
            this.radLabel17.TabIndex = 146;
            this.radLabel17.Text = "Extra Charge £";
            this.radLabel17.Visible = false;
            // 
            // numExtraChrgs
            // 
            this.numExtraChrgs.DecimalPlaces = 2;
            this.numExtraChrgs.EnableKeyMap = true;
            this.numExtraChrgs.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.numExtraChrgs.InterceptArrowKeys = false;
            this.numExtraChrgs.Location = new System.Drawing.Point(645, 122);
            this.numExtraChrgs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numExtraChrgs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numExtraChrgs.Name = "numExtraChrgs";
            // 
            // 
            // 
            this.numExtraChrgs.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numExtraChrgs.ShowUpDownButtons = false;
            this.numExtraChrgs.Size = new System.Drawing.Size(84, 22);
            this.numExtraChrgs.TabIndex = 145;
            this.numExtraChrgs.TabStop = false;
            this.numExtraChrgs.Visible = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numExtraChrgs.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numExtraChrgs.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ddlZone
            // 
            this.ddlZone.Caption = null;
            this.ddlZone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlZone.Location = new System.Drawing.Point(133, 164);
            this.ddlZone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlZone.Name = "ddlZone";
            this.ddlZone.Property = null;
            this.ddlZone.ShowDownArrow = true;
            this.ddlZone.Size = new System.Drawing.Size(232, 20);
            this.ddlZone.TabIndex = 5;
            // 
            // ddlLocationType
            // 
            this.ddlLocationType.Caption = null;
            this.ddlLocationType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlLocationType.Location = new System.Drawing.Point(133, 25);
            this.ddlLocationType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlLocationType.Name = "ddlLocationType";
            this.ddlLocationType.Property = null;
            this.ddlLocationType.ShowDownArrow = true;
            this.ddlLocationType.Size = new System.Drawing.Size(232, 20);
            this.ddlLocationType.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = false;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(133, 95);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(324, 62);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TabStop = false;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(13, 97);
            this.radLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(53, 19);
            this.radLabel4.TabIndex = 28;
            this.radLabel4.Text = "Address";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(13, 60);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(99, 18);
            this.radLabel1.TabIndex = 17;
            this.radLabel1.Text = "Location Name";
            // 
            // txtPostCode
            // 
            this.txtPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPostCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.Location = new System.Drawing.Point(604, 95);
            this.txtPostCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPostCode.MaxLength = 20;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(101, 21);
            this.txtPostCode.TabIndex = 4;
            this.txtPostCode.TabStop = false;
            // 
            // txtLocName
            // 
            this.txtLocName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocName.Location = new System.Drawing.Point(133, 59);
            this.txtLocName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLocName.MaxLength = 100;
            this.txtLocName.Name = "txtLocName";
            this.txtLocName.Size = new System.Drawing.Size(324, 21);
            this.txtLocName.TabIndex = 1;
            this.txtLocName.TabStop = false;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(524, 96);
            this.radLabel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(66, 19);
            this.radLabel5.TabIndex = 25;
            this.radLabel5.Text = "Post Code";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(13, 167);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(34, 18);
            this.radLabel2.TabIndex = 19;
            this.radLabel2.Text = "Zone";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(13, 27);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(93, 18);
            this.radLabel3.TabIndex = 21;
            this.radLabel3.Text = "Location Type";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 565);
            this.Controls.Add(this.radPanel1);
            this.FixedExitButtonOnTopRight = true;
            this.FormTitle = "Location";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLocations";
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.ShowSaveAndCloseButton = true;
            this.ShowSaveAndNewButton = true;
            this.Text = "Locations";
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortCutKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLocationType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtPostCode;
        private Telerik.WinControls.UI.RadTextBox txtLocName;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDropDownList ddlLocationType;
        private UI.MyDropDownList ddlZone;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadSpinEditor numExtraChrgs;
        private Telerik.WinControls.UI.RadTextBox txtShortCutKey;
        private Telerik.WinControls.UI.RadCheckBox chkShortKey;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txtLng;
        private Telerik.WinControls.UI.RadTextBox txtLat;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView grdDriverAttributes;
    }
}