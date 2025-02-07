namespace Taxi_AppMain
{
    partial class frmBookingMemberDetail
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.txtLoginID = new Telerik.WinControls.UI.RadTextBox();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radLabel6 = new System.Windows.Forms.Label();
            this.txtBookedByEmail = new System.Windows.Forms.TextBox();
            this.ddlCompanyCode = new UI.MyDropDownList();
            this.ddlPassengerType = new UI.MyDropDownList();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.txtAccountName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPassengerType)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(598, 270);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(500, 256);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(501, 0);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(682, 271);
            this.btnSaveAndClose.TabIndex = 11;
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(587, 269);
            this.btnSaveAndNew.TabIndex = 12;
            // 
            // txtLoginID
            // 
            this.txtLoginID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginID.Location = new System.Drawing.Point(74, 46);
            this.txtLoginID.MaxLength = 50;
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(205, 21);
            this.txtLoginID.TabIndex = 1;
            this.txtLoginID.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(74, 72);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 21);
            this.txtPassword.TabIndex = 99;
            this.txtPassword.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(82, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 198;
            this.label2.Text = "Company Code";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 197;
            this.label1.Text = "Passenger Type";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(82, 154);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(135, 22);
            this.radLabel6.TabIndex = 196;
            this.radLabel6.Text = "Booker Email";
            // 
            // txtBookedByEmail
            // 
            this.txtBookedByEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookedByEmail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookedByEmail.Location = new System.Drawing.Point(266, 152);
            this.txtBookedByEmail.MaxLength = 100;
            this.txtBookedByEmail.Name = "txtBookedByEmail";
            this.txtBookedByEmail.Size = new System.Drawing.Size(227, 26);
            this.txtBookedByEmail.TabIndex = 195;
            this.txtBookedByEmail.TabStop = false;
            // 
            // ddlCompanyCode
            // 
            this.ddlCompanyCode.Caption = null;
            this.ddlCompanyCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompanyCode.Location = new System.Drawing.Point(266, 113);
            this.ddlCompanyCode.Name = "ddlCompanyCode";
            this.ddlCompanyCode.Property = null;
            this.ddlCompanyCode.ShowDownArrow = true;
            this.ddlCompanyCode.Size = new System.Drawing.Size(227, 26);
            this.ddlCompanyCode.TabIndex = 194;
            // 
            // ddlPassengerType
            // 
            this.ddlPassengerType.Caption = null;
            this.ddlPassengerType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "Student";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem2.Text = "Staff";
            radListDataItem2.TextWrap = true;
            this.ddlPassengerType.Items.Add(radListDataItem1);
            this.ddlPassengerType.Items.Add(radListDataItem2);
            this.ddlPassengerType.Location = new System.Drawing.Point(266, 192);
            this.ddlPassengerType.Name = "ddlPassengerType";
            this.ddlPassengerType.Property = null;
            this.ddlPassengerType.ShowDownArrow = true;
            this.ddlPassengerType.Size = new System.Drawing.Size(227, 26);
            this.ddlPassengerType.TabIndex = 193;
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSaveNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSaveNew.Image = global::Taxi_AppMain.Resources.Resource1.save_Tick;
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveNew.Location = new System.Drawing.Point(473, 257);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(96, 52);
            this.btnSaveNew.TabIndex = 199;
            this.btnSaveNew.Text = "OK";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveNew.UseVisualStyleBackColor = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // txtAccountName
            // 
            this.txtAccountName.AutoSize = true;
            this.txtAccountName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.ForeColor = System.Drawing.Color.Red;
            this.txtAccountName.Location = new System.Drawing.Point(80, 55);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(0, 23);
            this.txtAccountName.TabIndex = 200;
            // 
            // frmBookingMemberDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 332);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.txtBookedByEmail);
            this.Controls.Add(this.ddlCompanyCode);
            this.Controls.Add(this.ddlPassengerType);
            this.FixedExitButtonOnTopRight = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Account Details";
            this.KeyPreview = true;
            this.Name = "frmBookingMemberDetail";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.Text = "Account Details";
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.ddlPassengerType, 0);
            this.Controls.SetChildIndex(this.ddlCompanyCode, 0);
            this.Controls.SetChildIndex(this.txtBookedByEmail, 0);
            this.Controls.SetChildIndex(this.radLabel6, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnSaveNew, 0);
            this.Controls.SetChildIndex(this.txtAccountName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPassengerType)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox txtLoginID;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label radLabel6;
        private System.Windows.Forms.TextBox txtBookedByEmail;
        private UI.MyDropDownList ddlCompanyCode;
        private UI.MyDropDownList ddlPassengerType;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Label txtAccountName;
        //private UI.MyGridView grdMileageSetting;
        //private Telerik.WinControls.UI.RadLabel radLabel34;
        //private Telerik.WinControls.UI.RadButton btnAddMileage;
        //Initialize Mileage Setting Grid
    }
}