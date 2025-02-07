namespace Taxi_AppMain
{
    partial class frmAddAllDriverRentExpenses3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdDriverRent = new UI.MyGridView();
            this.cbAllCompany = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.label6 = new System.Windows.Forms.Label();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnDeleteGenerated = new Telerik.WinControls.UI.RadButton();
            this.btnViewPrint = new Telerik.WinControls.UI.RadButton();
            this.btnPrintAll = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnSendEmail = new Telerik.WinControls.UI.RadButton();
            this.btnExits = new Telerik.WinControls.UI.RadButton();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnDisplayRent = new Telerik.WinControls.UI.RadButton();
            this.lblTillDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpTillDate = new UI.MyDatePicker();
            this.dtpFromDate = new UI.MyDatePicker();
            this.chkCarryForwardBalance = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverRent.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteGenerated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisplayRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(800, 615);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(950, 635);
            this.btnOnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(654, 602);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(512, 635);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(698, 505);
            this.btnSaveAndNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkCarryForwardBalance);
            this.panel1.Controls.Add(this.grdDriverRent);
            this.panel1.Controls.Add(this.cbAllCompany);
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 693);
            this.panel1.TabIndex = 0;
            // 
            // grdDriverRent
            // 
            this.grdDriverRent.AutoCellFormatting = false;
            this.grdDriverRent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDriverRent.EnableCheckInCheckOut = false;
            this.grdDriverRent.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdDriverRent.HeaderRowBorderColor = System.Drawing.Color.MidnightBlue;
            this.grdDriverRent.Location = new System.Drawing.Point(0, 20);
            this.grdDriverRent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverRent.MasterTemplate.AllowAddNewRow = false;
            this.grdDriverRent.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDriverRent.Name = "grdDriverRent";
            this.grdDriverRent.PKFieldColumnName = "";
            this.grdDriverRent.ShowGroupPanel = false;
            this.grdDriverRent.ShowImageOnActionButton = true;
            this.grdDriverRent.Size = new System.Drawing.Size(931, 673);
            this.grdDriverRent.TabIndex = 115;
            this.grdDriverRent.Text = "myGridView1";
            this.grdDriverRent.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdCompany_CellDoubleClick);
            // 
            // cbAllCompany
            // 
            this.cbAllCompany.AutoSize = true;
            this.cbAllCompany.Checked = true;
            this.cbAllCompany.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAllCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllCompany.Location = new System.Drawing.Point(0, 0);
            this.cbAllCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAllCompany.Name = "cbAllCompany";
            this.cbAllCompany.Size = new System.Drawing.Size(931, 20);
            this.cbAllCompany.TabIndex = 0;
            this.cbAllCompany.Text = "Select All";
            this.cbAllCompany.UseVisualStyleBackColor = true;
            this.cbAllCompany.CheckedChanged += new System.EventHandler(this.cbAllCompany_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.ddlSubCompany);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.radGroupBox2);
            this.panel2.Controls.Add(this.radGroupBox1);
            this.panel2.Location = new System.Drawing.Point(937, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 689);
            this.panel2.TabIndex = 106;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(181, 304);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            // 
            // 
            // 
            this.ddlSubCompany.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.ddlSubCompany.Size = new System.Drawing.Size(231, 24);
            this.ddlSubCompany.TabIndex = 109;
            this.ddlSubCompany.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 18);
            this.label6.TabIndex = 108;
            this.label6.Text = "Company Header";
            this.label6.Visible = false;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnDeleteGenerated);
            this.radGroupBox2.Controls.Add(this.btnViewPrint);
            this.radGroupBox2.Controls.Add(this.btnPrintAll);
            this.radGroupBox2.Controls.Add(this.label1);
            this.radGroupBox2.Controls.Add(this.txtSubject);
            this.radGroupBox2.Controls.Add(this.btnSendEmail);
            this.radGroupBox2.Controls.Add(this.btnExits);
            this.radGroupBox2.Controls.Add(this.btnGenerate);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.radGroupBox2.HeaderText = "Info";
            this.radGroupBox2.Location = new System.Drawing.Point(14, 337);
            this.radGroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            this.radGroupBox2.Size = new System.Drawing.Size(405, 348);
            this.radGroupBox2.TabIndex = 107;
            this.radGroupBox2.Text = "Info";
            // 
            // btnDeleteGenerated
            // 
            this.btnDeleteGenerated.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGenerated.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.btnDeleteGenerated.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteGenerated.Location = new System.Drawing.Point(269, 25);
            this.btnDeleteGenerated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteGenerated.Name = "btnDeleteGenerated";
            this.btnDeleteGenerated.Size = new System.Drawing.Size(128, 96);
            this.btnDeleteGenerated.TabIndex = 119;
            this.btnDeleteGenerated.Text = "Delete Generated Rent";
            this.btnDeleteGenerated.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteGenerated.TextWrap = true;
            this.btnDeleteGenerated.Visible = false;
            this.btnDeleteGenerated.Click += new System.EventHandler(this.btnDeleteGenerated_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteGenerated.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteGenerated.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteGenerated.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteGenerated.GetChildAt(0))).Text = "Delete Generated Rent";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteGenerated.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteGenerated.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteGenerated.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteGenerated.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewPrint
            // 
            this.btnViewPrint.Enabled = false;
            this.btnViewPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnViewPrint.Location = new System.Drawing.Point(19, 207);
            this.btnViewPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewPrint.Name = "btnViewPrint";
            this.btnViewPrint.Size = new System.Drawing.Size(174, 57);
            this.btnViewPrint.TabIndex = 118;
            this.btnViewPrint.Text = "View Print";
            this.btnViewPrint.Click += new System.EventHandler(this.btnViewPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewPrint.GetChildAt(0))).Text = "View Print";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Enabled = false;
            this.btnPrintAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAll.Location = new System.Drawing.Point(252, 340);
            this.btnPrintAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(138, 57);
            this.btnPrintAll.TabIndex = 115;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.Visible = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintAll.GetChildAt(0))).Text = "Print All";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Email Subject";
            this.label1.Visible = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(131, 128);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(257, 26);
            this.txtSubject.TabIndex = 113;
            this.txtSubject.Visible = false;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Location = new System.Drawing.Point(52, 340);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(138, 57);
            this.btnSendEmail.TabIndex = 110;
            this.btnSendEmail.Text = "Send Email ";
            this.btnSendEmail.Visible = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnEmailInvoices_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Text = "Send Email ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExits
            // 
            this.btnExits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExits.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExits.Location = new System.Drawing.Point(265, 207);
            this.btnExits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExits.Name = "btnExits";
            this.btnExits.Size = new System.Drawing.Size(125, 57);
            this.btnExits.TabIndex = 106;
            this.btnExits.Text = "Exit";
            this.btnExits.Click += new System.EventHandler(this.btnExits_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExits.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExits.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExits.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExits.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExits.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(34, 28);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(156, 78);
            this.btnGenerate.TabIndex = 105;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).Text = "Generate";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGenerate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGenerate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGenerate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnClear);
            this.radGroupBox1.Controls.Add(this.btnDisplayRent);
            this.radGroupBox1.Controls.Add(this.lblTillDate);
            this.radGroupBox1.Controls.Add(this.lblFromDate);
            this.radGroupBox1.Controls.Add(this.dtpTillDate);
            this.radGroupBox1.Controls.Add(this.dtpFromDate);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.radGroupBox1.HeaderText = "Period";
            this.radGroupBox1.Location = new System.Drawing.Point(14, 48);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            this.radGroupBox1.Size = new System.Drawing.Size(405, 245);
            this.radGroupBox1.TabIndex = 106;
            this.radGroupBox1.Text = "Period";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(232, 161);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 57);
            this.btnClear.TabIndex = 107;
            this.btnClear.Text = "Clear/Reset";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = "Clear/Reset";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDisplayRent
            // 
            this.btnDisplayRent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayRent.Location = new System.Drawing.Point(34, 161);
            this.btnDisplayRent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplayRent.Name = "btnDisplayRent";
            this.btnDisplayRent.Size = new System.Drawing.Size(156, 57);
            this.btnDisplayRent.TabIndex = 106;
            this.btnDisplayRent.Text = "Display Rent";
            this.btnDisplayRent.Click += new System.EventHandler(this.btnDisplayRent_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDisplayRent.GetChildAt(0))).Text = "Display Rent";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDisplayRent.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDisplayRent.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDisplayRent.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTillDate
            // 
            this.lblTillDate.AutoSize = true;
            this.lblTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTillDate.ForeColor = System.Drawing.Color.Black;
            this.lblTillDate.Location = new System.Drawing.Point(51, 102);
            this.lblTillDate.Name = "lblTillDate";
            this.lblTillDate.Size = new System.Drawing.Size(71, 18);
            this.lblTillDate.TabIndex = 87;
            this.lblTillDate.Text = "Till Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.Location = new System.Drawing.Point(51, 57);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(85, 18);
            this.lblFromDate.TabIndex = 86;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(184, 102);
            this.dtpTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(163, 24);
            this.dtpTillDate.TabIndex = 85;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Value = null;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(184, 48);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(163, 24);
            this.dtpFromDate.TabIndex = 84;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // chkCarryForwardBalance
            // 
            this.chkCarryForwardBalance.AutoSize = true;
            this.chkCarryForwardBalance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCarryForwardBalance.ForeColor = System.Drawing.Color.Red;
            this.chkCarryForwardBalance.Location = new System.Drawing.Point(780, -2);
            this.chkCarryForwardBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCarryForwardBalance.Name = "chkCarryForwardBalance";
            this.chkCarryForwardBalance.Size = new System.Drawing.Size(148, 22);
            this.chkCarryForwardBalance.TabIndex = 124;
            this.chkCarryForwardBalance.Text = "C/F Old Balance";
            this.chkCarryForwardBalance.UseVisualStyleBackColor = true;
            this.chkCarryForwardBalance.Visible = false;
            this.chkCarryForwardBalance.CheckedChanged += new System.EventHandler(this.chkCarryForwardBalance_CheckedChanged);
            // 
            // frmAddAllDriverRentExpenses3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 737);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormTitle = "Add All Driver Rent Expenses";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAddAllDriverRentExpenses3";
            this.ShowHeader = true;
            this.Text = "Add All Driver Rent Expenses";
            this.Load += new System.EventHandler(this.frmCompanyInvoice_Load);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverRent.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverRent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteGenerated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDisplayRent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private System.Windows.Forms.CheckBox cbAllCompany;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private UI.MyDatePicker dtpFromDate;
        private UI.MyDatePicker dtpTillDate;
        private System.Windows.Forms.Label lblTillDate;
        private System.Windows.Forms.Label lblFromDate;
        private Telerik.WinControls.UI.RadButton btnExits;
        private UI.MyGridView grdDriverRent;
        private Telerik.WinControls.UI.RadButton btnSendEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private Telerik.WinControls.UI.RadButton btnDisplayRent;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnPrintAll;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton btnViewPrint;
        private Telerik.WinControls.UI.RadButton btnDeleteGenerated;
        private System.Windows.Forms.CheckBox chkCarryForwardBalance;
    }
}