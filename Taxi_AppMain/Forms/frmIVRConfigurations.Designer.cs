namespace Taxi_AppMain
{
    partial class frmIVRConfigurations
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
            this.rdoIVRDisabled = new System.Windows.Forms.RadioButton();
            this.rdoIVREnabled = new System.Windows.Forms.RadioButton();
            this.btnSaveAPI = new Telerik.WinControls.UI.RadButton();
            this.lblIVR = new System.Windows.Forms.Label();
            this.chkReleaseMode = new Telerik.WinControls.UI.RadCheckBox();
            this.chkCalculateFares = new Telerik.WinControls.UI.RadCheckBox();
            this.lblIVRNumbers = new Telerik.WinControls.UI.RadLabel();
            this.txtIVRNumbers = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReleaseMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalculateFares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVRNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVRNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(824, 830);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(636, 830);
            this.btnOnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOnNew.Click += new System.EventHandler(this.btnOnNew_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(686, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExit.Size = new System.Drawing.Size(90, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(537, 830);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(724, 830);
            this.btnSaveAndNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // rdoIVRDisabled
            // 
            this.rdoIVRDisabled.AutoSize = true;
            this.rdoIVRDisabled.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIVRDisabled.Location = new System.Drawing.Point(298, 97);
            this.rdoIVRDisabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoIVRDisabled.Name = "rdoIVRDisabled";
            this.rdoIVRDisabled.Size = new System.Drawing.Size(74, 37);
            this.rdoIVRDisabled.TabIndex = 1;
            this.rdoIVRDisabled.TabStop = true;
            this.rdoIVRDisabled.Text = "Off";
            this.rdoIVRDisabled.UseVisualStyleBackColor = true;
            // 
            // rdoIVREnabled
            // 
            this.rdoIVREnabled.AutoSize = true;
            this.rdoIVREnabled.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIVREnabled.Location = new System.Drawing.Point(194, 97);
            this.rdoIVREnabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoIVREnabled.Name = "rdoIVREnabled";
            this.rdoIVREnabled.Size = new System.Drawing.Size(71, 37);
            this.rdoIVREnabled.TabIndex = 0;
            this.rdoIVREnabled.TabStop = true;
            this.rdoIVREnabled.Text = "On";
            this.rdoIVREnabled.UseVisualStyleBackColor = true;
            // 
            // btnSaveAPI
            // 
            this.btnSaveAPI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveAPI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveAPI.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveAPI.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveAPI.Location = new System.Drawing.Point(622, 427);
            this.btnSaveAPI.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveAPI.Name = "btnSaveAPI";
            this.btnSaveAPI.Size = new System.Drawing.Size(115, 69);
            this.btnSaveAPI.TabIndex = 228;
            this.btnSaveAPI.Text = "Save && Close";
            this.btnSaveAPI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAPI.Click += new System.EventHandler(this.btnSaveAPI_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAPI.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAPI.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAPI.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveAPI.GetChildAt(0))).Text = "Save && Close";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAPI.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAPI.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveAPI.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIVR
            // 
            this.lblIVR.AutoSize = true;
            this.lblIVR.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVR.Location = new System.Drawing.Point(36, 99);
            this.lblIVR.Name = "lblIVR";
            this.lblIVR.Size = new System.Drawing.Size(66, 33);
            this.lblIVR.TabIndex = 229;
            this.lblIVR.Text = "IVR";
            // 
            // chkReleaseMode
            // 
            this.chkReleaseMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReleaseMode.Location = new System.Drawing.Point(194, 351);
            this.chkReleaseMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkReleaseMode.Name = "chkReleaseMode";
            this.chkReleaseMode.Size = new System.Drawing.Size(15, 15);
            this.chkReleaseMode.TabIndex = 233;
            // 
            // chkCalculateFares
            // 
            this.chkCalculateFares.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalculateFares.Location = new System.Drawing.Point(194, 298);
            this.chkCalculateFares.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCalculateFares.Name = "chkCalculateFares";
            this.chkCalculateFares.Size = new System.Drawing.Size(15, 15);
            this.chkCalculateFares.TabIndex = 232;
            // 
            // lblIVRNumbers
            // 
            this.lblIVRNumbers.BackColor = System.Drawing.Color.Transparent;
            this.lblIVRNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVRNumbers.Location = new System.Drawing.Point(36, 193);
            this.lblIVRNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblIVRNumbers.Name = "lblIVRNumbers";
            this.lblIVRNumbers.Size = new System.Drawing.Size(114, 21);
            this.lblIVRNumbers.TabIndex = 230;
            this.lblIVRNumbers.Text = "IVR Number(s)";
            // 
            // txtIVRNumbers
            // 
            this.txtIVRNumbers.AutoSize = false;
            this.txtIVRNumbers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVRNumbers.Location = new System.Drawing.Point(194, 193);
            this.txtIVRNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIVRNumbers.Multiline = true;
            this.txtIVRNumbers.Name = "txtIVRNumbers";
            this.txtIVRNumbers.Size = new System.Drawing.Size(544, 82);
            this.txtIVRNumbers.TabIndex = 231;
            this.txtIVRNumbers.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 229;
            this.label1.Text = "Calculate Fares";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 229;
            this.label2.Text = "Release Mode";
            // 
            // frmIVRConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(779, 509);
            this.Controls.Add(this.chkReleaseMode);
            this.Controls.Add(this.chkCalculateFares);
            this.Controls.Add(this.lblIVRNumbers);
            this.Controls.Add(this.txtIVRNumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIVR);
            this.Controls.Add(this.rdoIVREnabled);
            this.Controls.Add(this.rdoIVRDisabled);
            this.Controls.Add(this.btnSaveAPI);
            this.FixedExitButtonOnTopRight = true;
            this.FormTitle = "IVR Configuration";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmIVRConfigurations";
            this.ShowAddNewButton = true;
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.ShowSaveAndCloseButton = true;
            this.ShowSaveAndNewButton = true;
            this.Text = "IVR Configration";
            this.Load += new System.EventHandler(this.frmIVRConfigurations_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnSaveAPI, 0);
            this.Controls.SetChildIndex(this.rdoIVRDisabled, 0);
            this.Controls.SetChildIndex(this.rdoIVREnabled, 0);
            this.Controls.SetChildIndex(this.lblIVR, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtIVRNumbers, 0);
            this.Controls.SetChildIndex(this.lblIVRNumbers, 0);
            this.Controls.SetChildIndex(this.chkCalculateFares, 0);
            this.Controls.SetChildIndex(this.chkReleaseMode, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReleaseMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalculateFares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVRNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVRNumbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdoIVRDisabled;
        private System.Windows.Forms.RadioButton rdoIVREnabled;
        private Telerik.WinControls.UI.RadButton btnSaveAPI;
        private System.Windows.Forms.Label lblIVR;
        private Telerik.WinControls.UI.RadCheckBox chkReleaseMode;
        private Telerik.WinControls.UI.RadCheckBox chkCalculateFares;
        private Telerik.WinControls.UI.RadLabel lblIVRNumbers;
        private Telerik.WinControls.UI.RadTextBox txtIVRNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
