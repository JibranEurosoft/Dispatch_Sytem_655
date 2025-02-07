namespace Taxi_AppMain
{
    partial class CallerIdPopup
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
            this.lblPopuptext = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdBookings = new Telerik.WinControls.UI.RadGridView();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.pnlBottom = new Telerik.WinControls.UI.RadPanel();
            this.lblNoFares = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.lblUsed = new System.Windows.Forms.Label();
            this.btnNewBooking = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRecentBookings = new System.Windows.Forms.Button();
            this.lblBlackListReason = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.Label();
            this.txtDoorNo = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings.MasterTemplate)).BeginInit();
            this.grdBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopuptext
            // 
            this.lblPopuptext.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblPopuptext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPopuptext.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPopuptext.Font = new System.Drawing.Font("Tahoma", 17F, System.Drawing.FontStyle.Bold);
            this.lblPopuptext.ForeColor = System.Drawing.Color.Black;
            this.lblPopuptext.Location = new System.Drawing.Point(0, 0);
            this.lblPopuptext.Name = "lblPopuptext";
            this.lblPopuptext.Size = new System.Drawing.Size(747, 34);
            this.lblPopuptext.TabIndex = 0;
            this.lblPopuptext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Gold;
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Controls.Add(this.panel1);
            this.pnlGrid.Controls.Add(this.pnlBottom);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 34);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(747, 358);
            this.pnlGrid.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "History";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdBookings);
            this.panel1.Controls.Add(this.lblNotes);
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 281);
            this.panel1.TabIndex = 10;
            // 
            // grdBookings
            // 
            this.grdBookings.Controls.Add(this.lblLoading);
            this.grdBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBookings.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grdBookings.MasterTemplate.AllowAddNewRow = false;
            this.grdBookings.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdBookings.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdBookings.Name = "grdBookings";
            this.grdBookings.ShowGroupPanel = false;
            this.grdBookings.Size = new System.Drawing.Size(741, 246);
            this.grdBookings.TabIndex = 8;
            this.grdBookings.Text = "radGridView1";
            this.grdBookings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdBookings_KeyDown);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoading.Location = new System.Drawing.Point(281, 118);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(225, 29);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Loading History...";
            // 
            // lblNotes
            // 
            this.lblNotes.BackColor = System.Drawing.Color.LightYellow;
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.Green;
            this.lblNotes.Location = new System.Drawing.Point(0, 246);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(741, 35);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlBottom.Controls.Add(this.lblNoFares);
            this.pnlBottom.Controls.Add(this.lblCancelled);
            this.pnlBottom.Controls.Add(this.lblUsed);
            this.pnlBottom.Controls.Add(this.btnNewBooking);
            this.pnlBottom.Controls.Add(this.btnSelect);
            this.pnlBottom.Controls.Add(this.btnRecentBookings);
            this.pnlBottom.Controls.Add(this.lblBlackListReason);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 317);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(747, 41);
            this.pnlBottom.TabIndex = 8;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlBottom.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlBottom.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlBottom.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlBottom.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlBottom.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            // 
            // lblNoFares
            // 
            this.lblNoFares.AutoSize = true;
            this.lblNoFares.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFares.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNoFares.Location = new System.Drawing.Point(214, 9);
            this.lblNoFares.Name = "lblNoFares";
            this.lblNoFares.Size = new System.Drawing.Size(123, 21);
            this.lblNoFares.TabIndex = 6;
            this.lblNoFares.Text = "No Pickup : 9";
            this.lblNoFares.Visible = false;
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(92, 9);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(119, 21);
            this.lblCancelled.TabIndex = 5;
            this.lblCancelled.Text = "Cancelled : 9";
            this.lblCancelled.Visible = false;
            // 
            // lblUsed
            // 
            this.lblUsed.AutoSize = true;
            this.lblUsed.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsed.ForeColor = System.Drawing.Color.Green;
            this.lblUsed.Location = new System.Drawing.Point(-3, 9);
            this.lblUsed.Name = "lblUsed";
            this.lblUsed.Size = new System.Drawing.Size(80, 21);
            this.lblUsed.TabIndex = 4;
            this.lblUsed.Text = "Used : 9";
            this.lblUsed.Visible = false;
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.BackColor = System.Drawing.Color.AliceBlue;
            this.btnNewBooking.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBooking.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnNewBooking.Location = new System.Drawing.Point(629, 6);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(115, 30);
            this.btnNewBooking.TabIndex = 3;
            this.btnNewBooking.TabStop = false;
            this.btnNewBooking.Text = "New Booking";
            this.btnNewBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewBooking.UseVisualStyleBackColor = false;
            this.btnNewBooking.Click += new System.EventHandler(this.btnNewBooking_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSelect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = global::Taxi_AppMain.Properties.Resources.paste;
            this.btnSelect.Location = new System.Drawing.Point(503, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(115, 30);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRecentBookings
            // 
            this.btnRecentBookings.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRecentBookings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecentBookings.Image = global::Taxi_AppMain.Properties.Resources.booking_24x24;
            this.btnRecentBookings.Location = new System.Drawing.Point(341, 6);
            this.btnRecentBookings.Name = "btnRecentBookings";
            this.btnRecentBookings.Size = new System.Drawing.Size(151, 30);
            this.btnRecentBookings.TabIndex = 8;
            this.btnRecentBookings.TabStop = false;
            this.btnRecentBookings.Text = "Waiting Bookings";
            this.btnRecentBookings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecentBookings.UseVisualStyleBackColor = false;
            this.btnRecentBookings.Click += new System.EventHandler(this.btnRecentBookings_Click);
            // 
            // lblBlackListReason
            // 
            this.lblBlackListReason.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackListReason.ForeColor = System.Drawing.Color.Red;
            this.lblBlackListReason.Location = new System.Drawing.Point(0, 2);
            this.lblBlackListReason.Name = "lblBlackListReason";
            this.lblBlackListReason.Size = new System.Drawing.Size(747, 37);
            this.lblBlackListReason.TabIndex = 7;
            this.lblBlackListReason.Text = "Black List Reason :";
            this.lblBlackListReason.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pictureBox1.Image = global::Taxi_AppMain.Properties.Resources.ringing;
            this.pictureBox1.Location = new System.Drawing.Point(699, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 28);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(410, 15);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(0, 16);
            this.txtAddress.TabIndex = 2;
            // 
            // txtDoorNo
            // 
            this.txtDoorNo.AutoSize = true;
            this.txtDoorNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtDoorNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoorNo.Location = new System.Drawing.Point(412, 2);
            this.txtDoorNo.Name = "txtDoorNo";
            this.txtDoorNo.Size = new System.Drawing.Size(0, 13);
            this.txtDoorNo.TabIndex = 10;
            // 
            // CallerIdPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(747, 392);
            this.Controls.Add(this.txtDoorNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPopuptext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CallerIdPopup";
            this.ShowIcon = false;
            this.Text = "Call";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CallerIdPopup_KeyDown);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings)).EndInit();
            this.grdBookings.ResumeLayout(false);
            this.grdBookings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


      

      


        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnNewBooking;
        public System.Windows.Forms.Label lblPopuptext;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label txtAddress;
        public System.Windows.Forms.Label txtDoorNo;
        public Telerik.WinControls.UI.RadPanel pnlBottom;
        private Telerik.WinControls.UI.RadGridView grdBookings;
        private System.Windows.Forms.Label lblNoFares;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Label lblUsed;
        private System.Windows.Forms.Label lblBlackListReason;
        private System.Windows.Forms.Button btnTrackDriver;
        private System.Windows.Forms.Label lblCurrJobDetails;
        private System.Windows.Forms.Label lblCurrJobHeading;
        private System.Windows.Forms.Button btnRecentBookings;
        private System.Windows.Forms.Label lblWaitingBookings;
        private Telerik.WinControls.UI.RadGridView grdWaitingBookings;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblETA;
        private System.Windows.Forms.CheckBox chkShowETA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label label1;
    }
}