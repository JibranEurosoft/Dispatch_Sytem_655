namespace Taxi_AppMain
{
    partial class frmDriverPDAMessage
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
            this.txtMsg = new UI.AutoCompleteTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.lblStatus = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.grdMessage = new Telerik.WinControls.UI.RadGridView();
            this.btnNew = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(598, 178);
            this.btnSaveOn.Size = new System.Drawing.Size(97, 56);
            this.btnSaveOn.Visible = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(393, 164);
            this.btnExit.Size = new System.Drawing.Size(103, 56);
            this.btnExit.Visible = true;
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.DefaultHeight = 120;
            this.txtMsg.DefaultWidth = 0;
            this.txtMsg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.ForceListBoxToUpdate = false;
            this.txtMsg.FormerValue = "";
            this.txtMsg.Location = new System.Drawing.Point(81, 57);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            // 
            // 
            // 
            this.txtMsg.RootElement.StretchVertically = true;
            this.txtMsg.SelectedItem = null;
            this.txtMsg.Size = new System.Drawing.Size(498, 87);
            this.txtMsg.TabIndex = 106;
            this.txtMsg.TabStop = false;
            this.txtMsg.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtMsg.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMsg.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMsg.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMsg.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtMsg.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(13, 57);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(68, 18);
            this.radLabel6.TabIndex = 107;
            this.radLabel6.Text = "Message: ";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel6.GetChildAt(0))).Text = "Message: ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radLabel6.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radLabel6.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(16, 283);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(11, 18);
            this.lblStatus.TabIndex = 107;
            this.lblStatus.Text = "-";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(256, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 56);
            this.btnSave.TabIndex = 109;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdMessage
            // 
            this.grdMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdMessage.EnableHotTracking = false;
            this.grdMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdMessage.Location = new System.Drawing.Point(0, 230);
            // 
            // grdMessage
            // 
            this.grdMessage.MasterTemplate.AllowAddNewRow = false;
            this.grdMessage.MasterTemplate.AllowDeleteRow = false;
            this.grdMessage.MasterTemplate.AllowEditRow = false;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.ShowGroupPanel = false;
            this.grdMessage.Size = new System.Drawing.Size(591, 250);
            this.grdMessage.TabIndex = 111;
            this.grdMessage.Text = "radGridView1";
            this.grdMessage.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.grdMessage_CommandCellClick);
            this.grdMessage.Click += new System.EventHandler(this.grdMessage_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.Location = new System.Drawing.Point(117, 164);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(104, 56);
            this.btnNew.TabIndex = 112;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).Text = "New";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmDriverPDAMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 480);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grdMessage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.txtMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.FormTitle = "Driver PDA Message";
            this.KeyPreview = true;
            this.Name = "frmDriverPDAMessage";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Driver PDA Message";
            this.Load += new System.EventHandler(this.frmDriverPDAMessage_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.txtMsg, 0);
            this.Controls.SetChildIndex(this.radLabel6, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.grdMessage, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.AutoCompleteTextBox txtMsg;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel lblStatus;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGridView grdMessage;
        private Telerik.WinControls.UI.RadButton btnNew;
    }
}