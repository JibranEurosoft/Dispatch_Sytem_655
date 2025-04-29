namespace Taxi_AppMain
{
    partial class rptJobRouthPathGoogle
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdLister = new UI.MyGridView();
            this.pnlZoom = new System.Windows.Forms.GroupBox();
            this.btnZoom = new System.Windows.Forms.Button();
            this.chkETA = new Telerik.WinControls.UI.RadCheckBox();
            this.optDestination = new System.Windows.Forms.RadioButton();
            this.optPickup = new System.Windows.Forms.RadioButton();
            this.optDriver = new System.Windows.Forms.RadioButton();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.pnlRouteActions = new System.Windows.Forms.Panel();
            this.chkShowPlots = new System.Windows.Forms.CheckBox();
            this.btnRecordingPlay = new Telerik.WinControls.UI.RadButton();
            this.btnPlayNav = new Telerik.WinControls.UI.RadButton();
            this.btnPauseNav = new Telerik.WinControls.UI.RadButton();
            this.btnStopNav = new Telerik.WinControls.UI.RadButton();
            this.btnEmail = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.chkFullDetails = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.pnlZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkETA)).BeginInit();
            this.pnlRouteActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecordingPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.AutoSizeRows = true;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn10.HeaderText = "Drv";
            gridViewTextBoxColumn10.Name = "Drv";
            gridViewTextBoxColumn10.Width = 60;
            gridViewTextBoxColumn11.HeaderText = "Pickup Point";
            gridViewTextBoxColumn11.Multiline = true;
            gridViewTextBoxColumn11.Name = "Pickup";
            gridViewTextBoxColumn11.Width = 200;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewTextBoxColumn12.HeaderText = "Destination";
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "Destination";
            gridViewTextBoxColumn12.Width = 190;
            gridViewTextBoxColumn12.WrapText = true;
            gridViewTextBoxColumn13.AutoEllipsis = false;
            gridViewTextBoxColumn13.HeaderText = "Accepted";
            gridViewTextBoxColumn13.Multiline = true;
            gridViewTextBoxColumn13.Name = "Accepted";
            gridViewTextBoxColumn13.Width = 115;
            gridViewTextBoxColumn14.HeaderText = "Arrived";
            gridViewTextBoxColumn14.Name = "Arrived";
            gridViewTextBoxColumn14.Width = 115;
            gridViewTextBoxColumn15.HeaderText = "POB";
            gridViewTextBoxColumn15.Name = "POB";
            gridViewTextBoxColumn15.Width = 115;
            gridViewTextBoxColumn16.HeaderText = "STC";
            gridViewTextBoxColumn16.Name = "STC";
            gridViewTextBoxColumn16.Width = 115;
            gridViewTextBoxColumn17.HeaderText = "Cleared";
            gridViewTextBoxColumn17.Name = "Cleared";
            gridViewTextBoxColumn17.Width = 115;
            gridViewTextBoxColumn18.HeaderText = "Miles";
            gridViewTextBoxColumn18.Name = "Miles";
            gridViewTextBoxColumn18.Width = 60;
            this.grdLister.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18});
            this.grdLister.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1092, 93);
            this.grdLister.TabIndex = 117;
            this.grdLister.Text = "myGridView1";
            this.grdLister.Click += new System.EventHandler(this.grdLister_Click);
            // 
            // pnlZoom
            // 
            this.pnlZoom.Controls.Add(this.btnZoom);
            this.pnlZoom.Controls.Add(this.chkETA);
            this.pnlZoom.Controls.Add(this.optDestination);
            this.pnlZoom.Controls.Add(this.optPickup);
            this.pnlZoom.Controls.Add(this.optDriver);
            this.pnlZoom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pnlZoom.Location = new System.Drawing.Point(974, 3);
            this.pnlZoom.Name = "pnlZoom";
            this.pnlZoom.Size = new System.Drawing.Size(123, 93);
            this.pnlZoom.TabIndex = 120;
            this.pnlZoom.TabStop = false;
            // 
            // btnZoom
            // 
            this.btnZoom.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.btnZoom.Image = global::Taxi_AppMain.Properties.Resources.map_icon;
            this.btnZoom.Location = new System.Drawing.Point(70, 25);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(45, 45);
            this.btnZoom.TabIndex = 229;
            this.btnZoom.TabStop = false;
            this.btnZoom.Text = "&Auto Off";
            this.btnZoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // chkETA
            // 
            this.chkETA.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkETA.ForeColor = System.Drawing.Color.Red;
            this.chkETA.Location = new System.Drawing.Point(57, 3);
            this.chkETA.Name = "chkETA";
            this.chkETA.Size = new System.Drawing.Size(41, 16);
            this.chkETA.TabIndex = 228;
            this.chkETA.TabStop = false;
            this.chkETA.Text = "&ETA";
            this.chkETA.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkETA_ToggleStateChanged);
            // 
            // optDestination
            // 
            this.optDestination.AutoSize = true;
            this.optDestination.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optDestination.Location = new System.Drawing.Point(7, 69);
            this.optDestination.Name = "optDestination";
            this.optDestination.Size = new System.Drawing.Size(90, 17);
            this.optDestination.TabIndex = 2;
            this.optDestination.TabStop = true;
            this.optDestination.Text = "Destination";
            this.optDestination.UseVisualStyleBackColor = true;
            // 
            // optPickup
            // 
            this.optPickup.AutoSize = true;
            this.optPickup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optPickup.Location = new System.Drawing.Point(7, 49);
            this.optPickup.Name = "optPickup";
            this.optPickup.Size = new System.Drawing.Size(62, 17);
            this.optPickup.TabIndex = 1;
            this.optPickup.TabStop = true;
            this.optPickup.Text = "Pickup";
            this.optPickup.UseVisualStyleBackColor = true;
            // 
            // optDriver
            // 
            this.optDriver.AutoSize = true;
            this.optDriver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optDriver.Location = new System.Drawing.Point(7, 28);
            this.optDriver.Name = "optDriver";
            this.optDriver.Size = new System.Drawing.Size(60, 17);
            this.optDriver.TabIndex = 0;
            this.optDriver.TabStop = true;
            this.optDriver.Text = "Driver";
            this.optDriver.UseVisualStyleBackColor = true;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 93);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1092, 531);
            this.gMapControl1.TabIndex = 118;
            this.gMapControl1.Zoom = 0D;
            // 
            // pnlRouteActions
            // 
            this.pnlRouteActions.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlRouteActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlRouteActions.Controls.Add(this.chkShowPlots);
            this.pnlRouteActions.Controls.Add(this.btnRecordingPlay);
            this.pnlRouteActions.Controls.Add(this.btnPlayNav);
            this.pnlRouteActions.Controls.Add(this.btnPauseNav);
            this.pnlRouteActions.Controls.Add(this.btnStopNav);
            this.pnlRouteActions.Location = new System.Drawing.Point(972, 105);
            this.pnlRouteActions.Name = "pnlRouteActions";
            this.pnlRouteActions.Size = new System.Drawing.Size(118, 244);
            this.pnlRouteActions.TabIndex = 124;
            this.pnlRouteActions.Visible = false;
            // 
            // chkShowPlots
            // 
            this.chkShowPlots.AutoSize = true;
            this.chkShowPlots.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPlots.Location = new System.Drawing.Point(13, 213);
            this.chkShowPlots.Name = "chkShowPlots";
            this.chkShowPlots.Size = new System.Drawing.Size(96, 18);
            this.chkShowPlots.TabIndex = 127;
            this.chkShowPlots.Text = "Show Plots";
            this.chkShowPlots.UseVisualStyleBackColor = true;
            this.chkShowPlots.CheckedChanged += new System.EventHandler(this.chkShowPlots_CheckedChanged);
            // 
            // btnRecordingPlay
            // 
            this.btnRecordingPlay.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnRecordingPlay.Location = new System.Drawing.Point(2, 161);
            this.btnRecordingPlay.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnRecordingPlay.Name = "btnRecordingPlay";
            this.btnRecordingPlay.Size = new System.Drawing.Size(113, 38);
            this.btnRecordingPlay.TabIndex = 126;
            this.btnRecordingPlay.Text = "Email";
            this.btnRecordingPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecordingPlay.TextWrap = true;
            this.btnRecordingPlay.Click += new System.EventHandler(this.btnRecordingPlay_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecordingPlay.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecordingPlay.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecordingPlay.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecordingPlay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecordingPlay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecordingPlay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlayNav
            // 
            this.btnPlayNav.Image = global::Taxi_AppMain.Properties.Resources.play;
            this.btnPlayNav.Location = new System.Drawing.Point(1, 11);
            this.btnPlayNav.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnPlayNav.Name = "btnPlayNav";
            this.btnPlayNav.Size = new System.Drawing.Size(113, 38);
            this.btnPlayNav.TabIndex = 125;
            this.btnPlayNav.Text = "Play";
            this.btnPlayNav.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlayNav.TextWrap = true;
            this.btnPlayNav.Click += new System.EventHandler(this.btnPlayNav_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPlayNav.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.play;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPlayNav.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPlayNav.GetChildAt(0))).Text = "Play";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPlayNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPlayNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPlayNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPauseNav
            // 
            this.btnPauseNav.Image = global::Taxi_AppMain.Properties.Resources.pause;
            this.btnPauseNav.Location = new System.Drawing.Point(0, 60);
            this.btnPauseNav.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnPauseNav.Name = "btnPauseNav";
            this.btnPauseNav.Size = new System.Drawing.Size(113, 38);
            this.btnPauseNav.TabIndex = 106;
            this.btnPauseNav.Text = "Pause";
            this.btnPauseNav.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPauseNav.TextWrap = true;
            this.btnPauseNav.Click += new System.EventHandler(this.btnPauseNav_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPauseNav.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pause;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPauseNav.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPauseNav.GetChildAt(0))).Text = "Pause";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPauseNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPauseNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPauseNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStopNav
            // 
            this.btnStopNav.Image = global::Taxi_AppMain.Properties.Resources.Stop;
            this.btnStopNav.Location = new System.Drawing.Point(1, 108);
            this.btnStopNav.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnStopNav.Name = "btnStopNav";
            this.btnStopNav.Size = new System.Drawing.Size(113, 38);
            this.btnStopNav.TabIndex = 106;
            this.btnStopNav.Text = "Stop";
            this.btnStopNav.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStopNav.TextWrap = true;
            this.btnStopNav.Click += new System.EventHandler(this.btnStopNav_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnStopNav.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnStopNav.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnStopNav.GetChildAt(0))).Text = "Stop";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnStopNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnStopNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnStopNav.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(1001, 93);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(89, 36);
            this.btnEmail.TabIndex = 119;
            this.btnEmail.Text = "Email";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Visible = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 230;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(0, 624);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1092, 45);
            this.trackBar1.TabIndex = 125;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblStart
            // 
            this.lblStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(2, 656);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(41, 13);
            this.lblStart.TabIndex = 126;
            this.lblStart.Text = "label1";
            // 
            // lblEnd
            // 
            this.lblEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(1044, 656);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(41, 13);
            this.lblEnd.TabIndex = 127;
            this.lblEnd.Text = "label1";
            // 
            // chkFullDetails
            // 
            this.chkFullDetails.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkFullDetails.ForeColor = System.Drawing.Color.Black;
            this.chkFullDetails.Location = new System.Drawing.Point(1005, 7);
            this.chkFullDetails.Name = "chkFullDetails";
            this.chkFullDetails.Size = new System.Drawing.Size(82, 16);
            this.chkFullDetails.TabIndex = 229;
            this.chkFullDetails.TabStop = false;
            this.chkFullDetails.Text = "&Full Details";
            this.chkFullDetails.Visible = false;
            // 
            // rptJobRouthPathGoogle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 669);
            this.Controls.Add(this.chkFullDetails);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pnlZoom);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.pnlRouteActions);
            this.KeyPreview = true;
            this.Name = "rptJobRouthPathGoogle";
            this.ShowIcon = false;
            this.Text = "Job Map";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rptJobRouthPathGoogle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.pnlZoom.ResumeLayout(false);
            this.pnlZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkETA)).EndInit();
            this.pnlRouteActions.ResumeLayout(false);
            this.pnlRouteActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecordingPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.MyGridView grdLister;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.GroupBox pnlZoom;
        private System.Windows.Forms.RadioButton optDestination;
        private System.Windows.Forms.RadioButton optPickup;
        private System.Windows.Forms.RadioButton optDriver;
        private System.Windows.Forms.Panel pnlRouteActions;
        private Telerik.WinControls.UI.RadButton btnPlayNav;
        private Telerik.WinControls.UI.RadButton btnPauseNav;
        private Telerik.WinControls.UI.RadButton btnStopNav;
        private Telerik.WinControls.UI.RadButton btnRecordingPlay;
        private System.Windows.Forms.Timer timer2;
        private Telerik.WinControls.UI.RadCheckBox chkETA;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private Telerik.WinControls.UI.RadCheckBox chkFullDetails;
        private System.Windows.Forms.CheckBox chkShowPlots;
    }
}