namespace Taxi_AppMain
{
    partial class frmCompanyInvoiceList
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
            this.grdLister = new UI.MyGridView();
            this.chkAll = new Telerik.WinControls.UI.RadCheckBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnVatCalculator = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlAccountType = new Telerik.WinControls.UI.RadDropDownList();
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.dtpToDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.optDefault = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.OPTDESC = new System.Windows.Forms.RadioButton();
            this.OPTASC = new System.Windows.Forms.RadioButton();
            this.btnSageExport = new Telerik.WinControls.UI.RadButton();
            this.btnPrintSelected = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.grdLister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVatCalculator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSageExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = true;
            this.grdLister.Controls.Add(this.chkAll);
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 104);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1386, 900);
            this.grdLister.TabIndex = 113;
            this.grdLister.Text = "myGridView1";
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.White;
            this.chkAll.Location = new System.Drawing.Point(4, 3);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(38, 19);
            this.chkAll.TabIndex = 111;
            this.chkAll.Text = "All";
            this.chkAll.Visible = false;
            this.chkAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAll_ToggleStateChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.btnVatCalculator);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.ddlAccountType);
            this.radPanel1.Controls.Add(this.btnEmail);
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Controls.Add(this.btnFind);
            this.radPanel1.Controls.Add(this.dtpToDate);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.dtpFromDate);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.optDefault);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.OPTDESC);
            this.radPanel1.Controls.Add(this.OPTASC);
            this.radPanel1.Controls.Add(this.btnSageExport);
            this.radPanel1.Controls.Add(this.btnPrintSelected);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1386, 66);
            this.radPanel1.TabIndex = 112;
            // 
            // btnVatCalculator
            // 
            this.btnVatCalculator.Location = new System.Drawing.Point(100, 14);
            this.btnVatCalculator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVatCalculator.Name = "btnVatCalculator";
            this.btnVatCalculator.Size = new System.Drawing.Size(85, 39);
            this.btnVatCalculator.TabIndex = 30;
            this.btnVatCalculator.Tag = "";
            this.btnVatCalculator.Text = "VAT Calculator";
            this.btnVatCalculator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVatCalculator.Visible = false;
            this.btnVatCalculator.Click += new System.EventHandler(this.btnVatCalculator_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVatCalculator.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVatCalculator.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVatCalculator.GetChildAt(0))).Text = "VAT Calculator";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnVatCalculator.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnVatCalculator.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnVatCalculator.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(316, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 103;
            this.label2.Text = "Account Type";
            // 
            // ddlAccountType
            // 
            this.ddlAccountType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAccountType.Location = new System.Drawing.Point(419, 37);
            this.ddlAccountType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlAccountType.Name = "ddlAccountType";
            this.ddlAccountType.Size = new System.Drawing.Size(93, 24);
            this.ddlAccountType.TabIndex = 102;
            this.ddlAccountType.Enter += new System.EventHandler(this.ddlAccountType_Enter);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.SMS_Message;
            this.btnEmail.Location = new System.Drawing.Point(1134, 27);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(115, 36);
            this.btnEmail.TabIndex = 37;
            this.btnEmail.Tag = "";
            this.btnEmail.Text = "Email Invoices";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.Visible = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.SMS_Message;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Email Invoices";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radButton1
            // 
            this.radButton1.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.radButton1.Location = new System.Drawing.Point(976, 30);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(90, 34);
            this.radButton1.TabIndex = 36;
            this.radButton1.Tag = "";
            this.radButton1.Text = "Clear Filter";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Clear Filter";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFind.Location = new System.Drawing.Point(896, 30);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(69, 34);
            this.btnFind.TabIndex = 35;
            this.btnFind.Tag = "";
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(782, 39);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Size = new System.Drawing.Size(104, 21);
            this.dtpToDate.TabIndex = 34;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(722, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(602, 39);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(113, 21);
            this.dtpFromDate.TabIndex = 32;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "From Date";
            // 
            // optDefault
            // 
            this.optDefault.AutoSize = true;
            this.optDefault.Checked = true;
            this.optDefault.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDefault.Location = new System.Drawing.Point(389, 7);
            this.optDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDefault.Name = "optDefault";
            this.optDefault.Size = new System.Drawing.Size(70, 18);
            this.optDefault.TabIndex = 29;
            this.optDefault.TabStop = true;
            this.optDefault.Tag = "0";
            this.optDefault.Text = "Default";
            this.optDefault.UseVisualStyleBackColor = true;
            this.optDefault.CheckedChanged += new System.EventHandler(this.OPTDESC_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Sort by";
            // 
            // OPTDESC
            // 
            this.OPTDESC.AutoSize = true;
            this.OPTDESC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTDESC.Location = new System.Drawing.Point(592, 7);
            this.OPTDESC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTDESC.Name = "OPTDESC";
            this.OPTDESC.Size = new System.Drawing.Size(95, 18);
            this.OPTDESC.TabIndex = 27;
            this.OPTDESC.TabStop = true;
            this.OPTDESC.Tag = "2";
            this.OPTDESC.Text = "Descending";
            this.OPTDESC.UseVisualStyleBackColor = true;
            this.OPTDESC.CheckedChanged += new System.EventHandler(this.OPTDESC_CheckedChanged);
            // 
            // OPTASC
            // 
            this.OPTASC.AutoSize = true;
            this.OPTASC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTASC.Location = new System.Drawing.Point(481, 7);
            this.OPTASC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTASC.Name = "OPTASC";
            this.OPTASC.Size = new System.Drawing.Size(88, 18);
            this.OPTASC.TabIndex = 26;
            this.OPTASC.TabStop = true;
            this.OPTASC.Tag = "1";
            this.OPTASC.Text = "Ascending";
            this.OPTASC.UseVisualStyleBackColor = true;
            this.OPTASC.CheckedChanged += new System.EventHandler(this.OPTDESC_CheckedChanged);
            // 
            // btnSageExport
            // 
            this.btnSageExport.Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            this.btnSageExport.Location = new System.Drawing.Point(11, 14);
            this.btnSageExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSageExport.Name = "btnSageExport";
            this.btnSageExport.Size = new System.Drawing.Size(76, 38);
            this.btnSageExport.TabIndex = 25;
            this.btnSageExport.Tag = "";
            this.btnSageExport.Text = "Sage";
            this.btnSageExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSageExport.Click += new System.EventHandler(this.btnSageExport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSageExport.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSageExport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSageExport.GetChildAt(0))).Text = "Sage";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSageExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSageExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSageExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSelected.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintSelected.Location = new System.Drawing.Point(1267, 27);
            this.btnPrintSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(100, 36);
            this.btnPrintSelected.TabIndex = 24;
            this.btnPrintSelected.Tag = "";
            this.btnPrintSelected.Text = "Print Invoices";
            this.btnPrintSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Text = "Print Invoices";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCompanyInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 1004);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormTitle = "Account Invoice List";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCompanyInvoiceList";
            this.ShowHeader = true;
            this.Text = "Account Invoice List";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.grdLister.ResumeLayout(false);
            this.grdLister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVatCalculator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSageExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.MyGridView grdLister;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnPrintSelected;
        private Telerik.WinControls.UI.RadButton btnSageExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton OPTDESC;
        private System.Windows.Forms.RadioButton OPTASC;
        private System.Windows.Forms.RadioButton optDefault;
        private Telerik.WinControls.UI.RadButton btnVatCalculator;
        private Telerik.WinControls.UI.RadDateTimePicker dtpToDate;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadCheckBox chkAll;
        private Telerik.WinControls.UI.RadButton btnEmail;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList ddlAccountType;
    }
}