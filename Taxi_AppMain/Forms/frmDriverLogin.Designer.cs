namespace Taxi_AppMain
{
    partial class frmDriverLogin
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnLogin = new Telerik.WinControls.UI.RadButton();
            this.lablltest = new Telerik.WinControls.UI.RadLabel();
            this.grdDrivers = new Telerik.WinControls.UI.RadGridView();
            this.chkShowLoggedIn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lablltest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Driver(s)";
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.SteelBlue;
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.ForeColor = System.Drawing.Color.White;
            this.radButton1.Location = new System.Drawing.Point(411, 341);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(90, 32);
            this.radButton1.TabIndex = 8;
            this.radButton1.Text = "Cancel";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Cancel";
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Font = new System.Drawing.Font("Arial", 8.25F);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(253, 341);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 32);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnLogin.GetChildAt(0))).Text = "Login";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnLogin.GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnLogin.GetChildAt(0))).Font = new System.Drawing.Font("Arial", 8.25F);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.SteelBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnLogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lablltest
            // 
            this.lablltest.Location = new System.Drawing.Point(10, 148);
            this.lablltest.Name = "lablltest";
            this.lablltest.Size = new System.Drawing.Size(2, 2);
            this.lablltest.TabIndex = 11;
            // 
            // grdDrivers
            // 
            this.grdDrivers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDrivers.Location = new System.Drawing.Point(125, 42);
            // 
            // 
            // 
            this.grdDrivers.MasterTemplate.AllowAddNewRow = false;
            this.grdDrivers.MasterTemplate.AllowDeleteRow = false;
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.Name = "colChk";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewTextBoxColumn1.HeaderText = "Driver";
            gridViewTextBoxColumn1.Name = "colDrv";
            gridViewTextBoxColumn1.Width = 240;
            gridViewComboBoxColumn1.HeaderText = "Vehicle";
            gridViewComboBoxColumn1.Name = "colVeh";
            gridViewComboBoxColumn1.Width = 180;
            gridViewTextBoxColumn2.HeaderText = "column1";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "colId";
            gridViewTextBoxColumn3.HeaderText = "DriverNo";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "DriverNo";
            gridViewTextBoxColumn4.HeaderText = "FleetMasterId";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "FleetMasterId";
            this.grdDrivers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.grdDrivers.MasterTemplate.ShowFilteringRow = false;
            this.grdDrivers.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdDrivers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDrivers.Name = "grdDrivers";
            this.grdDrivers.ShowGroupPanel = false;
            this.grdDrivers.Size = new System.Drawing.Size(470, 283);
            this.grdDrivers.TabIndex = 12;
            this.grdDrivers.Text = "radGridView1";
            this.grdDrivers.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.grdDrivers_CellBeginEdit);
            // 
            // chkShowLoggedIn
            // 
            this.chkShowLoggedIn.AutoSize = true;
            this.chkShowLoggedIn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowLoggedIn.Location = new System.Drawing.Point(4, 7);
            this.chkShowLoggedIn.Name = "chkShowLoggedIn";
            this.chkShowLoggedIn.Size = new System.Drawing.Size(205, 18);
            this.chkShowLoggedIn.TabIndex = 13;
            this.chkShowLoggedIn.Text = "Show Logged In Drivers Only";
            this.chkShowLoggedIn.UseVisualStyleBackColor = true;
            this.chkShowLoggedIn.CheckedChanged += new System.EventHandler(this.chkShowLoggedIn_CheckedChanged);
            // 
            // frmDriverLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(600, 383);
            this.Controls.Add(this.chkShowLoggedIn);
            this.Controls.Add(this.grdDrivers);
            this.Controls.Add(this.lablltest);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmDriverLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver Login";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lablltest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnLogin;
        private Telerik.WinControls.UI.RadLabel lablltest;
        private Telerik.WinControls.UI.RadGridView grdDrivers;
        private System.Windows.Forms.CheckBox chkShowLoggedIn;
    }
}