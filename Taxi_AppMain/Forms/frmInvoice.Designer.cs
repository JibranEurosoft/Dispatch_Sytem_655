using System.Windows.Forms;

namespace Taxi_AppMain
{
    partial class frmInvoice
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.btnCreditNote = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.chkAutoContinue = new Telerik.WinControls.UI.RadCheckBox();
            this.btnAddNewInvoice = new Telerik.WinControls.UI.RadButton();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblOrderNo = new Telerik.WinControls.UI.RadLabel();
            this.dtpDueDate = new UI.MyDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlAccountType = new Telerik.WinControls.UI.RadDropDownList();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnExportToExcel2 = new Telerik.WinControls.UI.RadSplitButton();
            this.radMenuExportToExcel = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuExportBooking = new Telerik.WinControls.UI.RadMenuItem();
            this.btnExportExcel = new Telerik.WinControls.UI.RadButton();
            this.radLabel27 = new Telerik.WinControls.UI.RadLabel();
            this.lblSplitBy = new Telerik.WinControls.UI.RadLabel();
            this.ddlSplitBy = new Telerik.WinControls.UI.RadDropDownList();
            this.btnSaveInvoice = new Telerik.WinControls.UI.RadButton();
            this.btnSendEmail = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.chkDepartmentWise = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlDepartment = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlCompany = new Taxi_AppMain.SuggestComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpInvoiceDate = new UI.MyDatePicker();
            this.txtInvoiceNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlOrderNo = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.f = new Telerik.WinControls.UI.RadPanel();
            this.chkAllFromDate = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlPickType = new Telerik.WinControls.UI.RadDropDownList();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.lblExtras = new System.Windows.Forms.Label();
            this.numExtras = new System.Windows.Forms.Label();
            this.lblAdminfee = new System.Windows.Forms.Label();
            this.txtAdminFee = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.Label();
            this.lblNet = new System.Windows.Forms.Label();
            this.txtNet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.txtInvoiceAmount = new System.Windows.Forms.Label();
            this.grdLister = new UI.MyGridView();
            this.contextMenuCreditNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCreditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel27)).BeginInit();
            this.radLabel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSplitBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSplitBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInvoiceDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).BeginInit();
            this.f.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPickType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.contextMenuCreditNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(422, 113);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveOn.Size = new System.Drawing.Size(118, 69);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(1021, 170);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAndClose.Size = new System.Drawing.Size(118, 69);
            // 
            // radPanel5
            // 
            this.radPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel5.Controls.Add(this.btnCreditNote);
            this.radPanel5.Controls.Add(this.txtNotes);
            this.radPanel5.Controls.Add(this.radLabel5);
            this.radPanel5.Controls.Add(this.chkAutoContinue);
            this.radPanel5.Controls.Add(this.btnAddNewInvoice);
            this.radPanel5.Controls.Add(this.ddlSubCompany);
            this.radPanel5.Controls.Add(this.label6);
            this.radPanel5.Controls.Add(this.txtOrderNo);
            this.radPanel5.Controls.Add(this.lblOrderNo);
            this.radPanel5.Controls.Add(this.dtpDueDate);
            this.radPanel5.Controls.Add(this.label4);
            this.radPanel5.Controls.Add(this.ddlAccountType);
            this.radPanel5.Controls.Add(this.radPanel1);
            this.radPanel5.Controls.Add(this.chkDepartmentWise);
            this.radPanel5.Controls.Add(this.ddlDepartment);
            this.radPanel5.Controls.Add(this.ddlCompany);
            this.radPanel5.Controls.Add(this.label2);
            this.radPanel5.Controls.Add(this.radLabel3);
            this.radPanel5.Controls.Add(this.dtpInvoiceDate);
            this.radPanel5.Controls.Add(this.txtInvoiceNo);
            this.radPanel5.Controls.Add(this.radLabel1);
            this.radPanel5.Controls.Add(this.label7);
            this.radPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel5.Location = new System.Drawing.Point(0, 38);
            this.radPanel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(1332, 273);
            this.radPanel5.TabIndex = 106;
            // 
            // btnCreditNote
            // 
            this.btnCreditNote.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreditNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditNote.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnCreditNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreditNote.Location = new System.Drawing.Point(0, 0);
            this.btnCreditNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreditNote.Name = "btnCreditNote";
            this.btnCreditNote.Size = new System.Drawing.Size(211, 47);
            this.btnCreditNote.TabIndex = 113;
            this.btnCreditNote.Text = "Credit Note";
            this.btnCreditNote.UseVisualStyleBackColor = false;
            this.btnCreditNote.Visible = false;
            this.btnCreditNote.Click += new System.EventHandler(this.btnCreditNote_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(181, 199);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.MaxLength = 2000;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtNotes.Size = new System.Drawing.Size(590, 66);
            this.txtNotes.TabIndex = 545;
            this.txtNotes.Text = "";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(14, 201);
            this.radLabel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(46, 22);
            this.radLabel5.TabIndex = 112;
            this.radLabel5.Text = "Notes";
            // 
            // chkAutoContinue
            // 
            this.chkAutoContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoContinue.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoContinue.Location = new System.Drawing.Point(958, 1);
            this.chkAutoContinue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAutoContinue.Name = "chkAutoContinue";
            this.chkAutoContinue.Size = new System.Drawing.Size(118, 22);
            this.chkAutoContinue.TabIndex = 110;
            this.chkAutoContinue.Text = "Auto Continue";
            this.chkAutoContinue.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAutoContinue.Visible = false;
            this.chkAutoContinue.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAutoContinue_ToggleStateChanged);
            // 
            // btnAddNewInvoice
            // 
            this.btnAddNewInvoice.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAddNewInvoice.Location = new System.Drawing.Point(1121, 0);
            this.btnAddNewInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNewInvoice.Name = "btnAddNewInvoice";
            this.btnAddNewInvoice.Size = new System.Drawing.Size(211, 34);
            this.btnAddNewInvoice.TabIndex = 108;
            this.btnAddNewInvoice.Text = "Create New Invoice";
            this.btnAddNewInvoice.Click += new System.EventHandler(this.btnAddNewInvoice_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewInvoice.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewInvoice.GetChildAt(0))).Text = "Create New Invoice";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddNewInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddNewInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddNewInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(181, 165);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            // 
            // 
            // 
            this.ddlSubCompany.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.ddlSubCompany.Size = new System.Drawing.Size(287, 24);
            this.ddlSubCompany.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 106;
            this.label6.Text = "SubCompany";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(642, 95);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderNo.MaxLength = 50;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(129, 24);
            this.txtOrderNo.TabIndex = 104;
            this.txtOrderNo.TabStop = false;
            this.txtOrderNo.Visible = false;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.Location = new System.Drawing.Point(506, 96);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(70, 22);
            this.lblOrderNo.TabIndex = 105;
            this.lblOrderNo.Text = "Order No";
            this.lblOrderNo.Visible = false;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(642, 132);
            this.dtpDueDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Size = new System.Drawing.Size(129, 24);
            this.dtpDueDate.TabIndex = 103;
            this.dtpDueDate.TabStop = false;
            this.dtpDueDate.Text = "21/09/2011";
            this.dtpDueDate.Value = new System.DateTime(2011, 9, 21, 2, 48, 22, 638);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(506, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 102;
            this.label4.Text = "Due Date";
            // 
            // ddlAccountType
            // 
            this.ddlAccountType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAccountType.Location = new System.Drawing.Point(377, 54);
            this.ddlAccountType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlAccountType.Name = "ddlAccountType";
            this.ddlAccountType.Size = new System.Drawing.Size(91, 24);
            this.ddlAccountType.TabIndex = 101;
            this.ddlAccountType.Visible = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnExportToExcel2);
            this.radPanel1.Controls.Add(this.btnExportExcel);
            this.radPanel1.Controls.Add(this.radLabel27);
            this.radPanel1.Controls.Add(this.btnSaveInvoice);
            this.radPanel1.Controls.Add(this.btnSendEmail);
            this.radPanel1.Controls.Add(this.btnPrint);
            this.radPanel1.Controls.Add(this.btnExportPDF);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanel1.Location = new System.Drawing.Point(821, 47);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(511, 226);
            this.radPanel1.TabIndex = 97;
            // 
            // btnExportToExcel2
            // 
            this.btnExportToExcel2.Enabled = false;
            this.btnExportToExcel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel2.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportToExcel2.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportToExcel2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuExportToExcel,
            this.radMenuExportBooking});
            this.btnExportToExcel2.Location = new System.Drawing.Point(348, 123);
            this.btnExportToExcel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToExcel2.Name = "btnExportToExcel2";
            this.btnExportToExcel2.Size = new System.Drawing.Size(146, 69);
            this.btnExportToExcel2.TabIndex = 204;
            this.btnExportToExcel2.Text = "Export";
            this.btnExportToExcel2.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportToExcel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportToExcel2.Visible = false;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).Text = "Export";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnExportToExcel2.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnExportToExcel2.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.ActionButtonElement)(this.btnExportToExcel2.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnExportToExcel2.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radMenuExportToExcel
            // 
            this.radMenuExportToExcel.Name = "radMenuExportToExcel";
            this.radMenuExportToExcel.Text = "Export Invoice";
            this.radMenuExportToExcel.Click += new System.EventHandler(this.radMenuExportToExcel_Click);
            // 
            // radMenuExportBooking
            // 
            this.radMenuExportBooking.Name = "radMenuExportBooking";
            this.radMenuExportBooking.Text = "Export Bookings";
            this.radMenuExportBooking.Click += new System.EventHandler(this.radMenuExportBooking_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(348, 112);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(146, 80);
            this.btnExportExcel.TabIndex = 98;
            this.btnExportExcel.Text = "Export To Excel";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Text = "Export To Excel";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel27
            // 
            this.radLabel27.AutoSize = false;
            this.radLabel27.BackColor = System.Drawing.Color.Navy;
            this.radLabel27.Controls.Add(this.lblSplitBy);
            this.radLabel27.Controls.Add(this.ddlSplitBy);
            this.radLabel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel27.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.radLabel27.ForeColor = System.Drawing.Color.White;
            this.radLabel27.Location = new System.Drawing.Point(0, 0);
            this.radLabel27.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel27.Name = "radLabel27";
            this.radLabel27.Size = new System.Drawing.Size(511, 23);
            this.radLabel27.TabIndex = 97;
            this.radLabel27.Text = "Actions";
            // 
            // lblSplitBy
            // 
            this.lblSplitBy.Location = new System.Drawing.Point(230, -1);
            this.lblSplitBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSplitBy.Name = "lblSplitBy";
            this.lblSplitBy.Size = new System.Drawing.Size(49, 18);
            this.lblSplitBy.TabIndex = 109;
            this.lblSplitBy.Text = "Split By :";
            this.lblSplitBy.Visible = false;
            // 
            // ddlSplitBy
            // 
            radListDataItem6.Selected = true;
            radListDataItem6.Text = "None";
            radListDataItem7.Text = "Split By Department";
            radListDataItem8.Text = "Split By Order No";
            this.ddlSplitBy.Items.Add(radListDataItem6);
            this.ddlSplitBy.Items.Add(radListDataItem7);
            this.ddlSplitBy.Items.Add(radListDataItem8);
            this.ddlSplitBy.Location = new System.Drawing.Point(323, 0);
            this.ddlSplitBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSplitBy.Name = "ddlSplitBy";
            this.ddlSplitBy.Size = new System.Drawing.Size(170, 20);
            this.ddlSplitBy.TabIndex = 108;
            this.ddlSplitBy.Text = "None";
            this.ddlSplitBy.Visible = false;
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveInvoice.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveInvoice.Location = new System.Drawing.Point(29, 123);
            this.btnSaveInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(118, 69);
            this.btnSaveInvoice.TabIndex = 89;
            this.btnSaveInvoice.Text = "Save";
            this.btnSaveInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnSendEmail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendEmail.Location = new System.Drawing.Point(190, 26);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(133, 69);
            this.btnSendEmail.TabIndex = 96;
            this.btnSendEmail.Text = "Email";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(20, 26);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 69);
            this.btnPrint.TabIndex = 85;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "PRINT";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.Enabled = false;
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(360, 26);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(133, 69);
            this.btnExportPDF.TabIndex = 86;
            this.btnExportPDF.Text = "Export To PDF";
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Text = "Export To PDF";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDepartmentWise
            // 
            this.chkDepartmentWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDepartmentWise.Location = new System.Drawing.Point(14, 134);
            this.chkDepartmentWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDepartmentWise.Name = "chkDepartmentWise";
            this.chkDepartmentWise.Size = new System.Drawing.Size(124, 22);
            this.chkDepartmentWise.TabIndex = 90;
            this.chkDepartmentWise.Text = "By Department";
            this.chkDepartmentWise.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.chkDepartmentWise_ToggleStateChanging);
            // 
            // ddlDepartment
            // 
            this.ddlDepartment.Enabled = false;
            this.ddlDepartment.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDepartment.Location = new System.Drawing.Point(181, 129);
            this.ddlDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDepartment.Name = "ddlDepartment";
            this.ddlDepartment.Size = new System.Drawing.Size(288, 24);
            this.ddlDepartment.TabIndex = 88;
            // 
            // ddlCompany
            // 
            this.ddlCompany.FilterRule = null;
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(181, 94);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.PropertySelector = null;
            this.ddlCompany.Size = new System.Drawing.Size(287, 26);
            this.ddlCompany.SuggestBoxHeight = 50;
            this.ddlCompany.SuggestListOrderRule = null;
            this.ddlCompany.TabIndex = 84;
            this.ddlCompany.SelectedValueChanged += new System.EventHandler(this.ddlCompany_SelectedValueChanged);
            this.ddlCompany.SizeChanged += new System.EventHandler(this.ddlCompany_SizeChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Account";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(506, 55);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(93, 22);
            this.radLabel3.TabIndex = 81;
            this.radLabel3.Text = "Invoice Date";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(642, 54);
            this.dtpInvoiceDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpInvoiceDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpInvoiceDate.Size = new System.Drawing.Size(129, 24);
            this.dtpInvoiceDate.TabIndex = 82;
            this.dtpInvoiceDate.TabStop = false;
            this.dtpInvoiceDate.Text = "21/09/2011";
            this.dtpInvoiceDate.Value = new System.DateTime(2011, 9, 21, 2, 48, 22, 638);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(181, 54);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(150, 24);
            this.txtInvoiceNo.TabIndex = 76;
            this.txtInvoiceNo.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(14, 55);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(80, 22);
            this.radLabel1.TabIndex = 77;
            this.radLabel1.Text = "Invoice No";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1332, 47);
            this.label7.TabIndex = 109;
            this.label7.Text = "Account Invoice";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlOrderNo
            // 
            this.ddlOrderNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlOrderNo.Location = new System.Drawing.Point(104, 34);
            this.ddlOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlOrderNo.Name = "ddlOrderNo";
            this.ddlOrderNo.Size = new System.Drawing.Size(157, 24);
            this.ddlOrderNo.TabIndex = 105;
            this.ddlOrderNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 104;
            this.label5.Text = "Order No";
            this.label5.Visible = false;
            // 
            // f
            // 
            this.f.BackColor = System.Drawing.Color.AntiqueWhite;
            this.f.Controls.Add(this.chkAllFromDate);
            this.f.Controls.Add(this.ddlOrderNo);
            this.f.Controls.Add(this.ddlPickType);
            this.f.Controls.Add(this.label5);
            this.f.Controls.Add(this.radButton1);
            this.f.Controls.Add(this.dtpTillDate);
            this.f.Controls.Add(this.radLabel2);
            this.f.Controls.Add(this.dtpFromDate);
            this.f.Controls.Add(this.radLabel4);
            this.f.Controls.Add(this.radLabel14);
            this.f.Dock = System.Windows.Forms.DockStyle.Top;
            this.f.Location = new System.Drawing.Point(0, 311);
            this.f.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(1332, 70);
            this.f.TabIndex = 107;
            // 
            // chkAllFromDate
            // 
            this.chkAllFromDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllFromDate.Location = new System.Drawing.Point(465, 37);
            this.chkAllFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllFromDate.Name = "chkAllFromDate";
            this.chkAllFromDate.Size = new System.Drawing.Size(41, 22);
            this.chkAllFromDate.TabIndex = 106;
            this.chkAllFromDate.Text = "All";
            this.chkAllFromDate.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllFromDate.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllFromDate_ToggleStateChanged);
            // 
            // ddlPickType
            // 
            this.ddlPickType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Selected = true;
            radListDataItem1.Text = "Pickup Date";
            radListDataItem2.Text = "Booking Date";
            this.ddlPickType.Items.Add(radListDataItem1);
            this.ddlPickType.Items.Add(radListDataItem2);
            this.ddlPickType.Location = new System.Drawing.Point(273, 34);
            this.ddlPickType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlPickType.Name = "ddlPickType";
            this.ddlPickType.Size = new System.Drawing.Size(132, 24);
            this.ddlPickType.TabIndex = 89;
            this.ddlPickType.Text = "Pickup Date";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(1058, 32);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(147, 37);
            this.radButton1.TabIndex = 86;
            this.radButton1.Text = "Pick Booking";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Click += new System.EventHandler(this.btnPickBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Pick Booking";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(876, 34);
            this.dtpTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(133, 24);
            this.dtpTillDate.TabIndex = 61;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Value = null;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(791, 37);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(68, 22);
            this.radLabel2.TabIndex = 60;
            this.radLabel2.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(621, 34);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(133, 24);
            this.dtpFromDate.TabIndex = 59;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(512, 37);
            this.radLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(89, 22);
            this.radLabel4.TabIndex = 58;
            this.radLabel4.Text = "From Date";
            // 
            // radLabel14
            // 
            this.radLabel14.AutoSize = false;
            this.radLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.radLabel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(0, 0);
            this.radLabel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(1332, 27);
            this.radLabel14.TabIndex = 57;
            this.radLabel14.Text = "Charges Details";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radPanel3);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 782);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1332, 178);
            this.radPanel2.TabIndex = 108;
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel3.Controls.Add(this.lblExtras);
            this.radPanel3.Controls.Add(this.numExtras);
            this.radPanel3.Controls.Add(this.lblAdminfee);
            this.radPanel3.Controls.Add(this.txtAdminFee);
            this.radPanel3.Controls.Add(this.lblVat);
            this.radPanel3.Controls.Add(this.txtVat);
            this.radPanel3.Controls.Add(this.lblNet);
            this.radPanel3.Controls.Add(this.txtNet);
            this.radPanel3.Controls.Add(this.label1);
            this.radPanel3.Controls.Add(this.radPanel4);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanel3.Location = new System.Drawing.Point(919, 0);
            this.radPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(413, 178);
            this.radPanel3.TabIndex = 4;
            // 
            // lblExtras
            // 
            this.lblExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtras.AutoSize = true;
            this.lblExtras.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblExtras.Location = new System.Drawing.Point(2, 71);
            this.lblExtras.Name = "lblExtras";
            this.lblExtras.Size = new System.Drawing.Size(144, 17);
            this.lblExtras.TabIndex = 11;
            this.lblExtras.Text = "Total Parking/Extra";
            this.lblExtras.Visible = false;
            // 
            // numExtras
            // 
            this.numExtras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numExtras.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numExtras.Location = new System.Drawing.Point(173, 69);
            this.numExtras.Name = "numExtras";
            this.numExtras.Size = new System.Drawing.Size(215, 28);
            this.numExtras.TabIndex = 10;
            this.numExtras.Visible = false;
            // 
            // lblAdminfee
            // 
            this.lblAdminfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminfee.AutoSize = true;
            this.lblAdminfee.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdminfee.Location = new System.Drawing.Point(54, 105);
            this.lblAdminfee.Name = "lblAdminfee";
            this.lblAdminfee.Size = new System.Drawing.Size(85, 18);
            this.lblAdminfee.TabIndex = 9;
            this.lblAdminfee.Text = "Admin Fee";
            this.lblAdminfee.Visible = false;
            // 
            // txtAdminFee
            // 
            this.txtAdminFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminFee.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminFee.Location = new System.Drawing.Point(173, 101);
            this.txtAdminFee.Name = "txtAdminFee";
            this.txtAdminFee.Size = new System.Drawing.Size(215, 28);
            this.txtAdminFee.TabIndex = 8;
            this.txtAdminFee.Visible = false;
            // 
            // lblVat
            // 
            this.lblVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblVat.Location = new System.Drawing.Point(111, 39);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(37, 18);
            this.lblVat.TabIndex = 7;
            this.lblVat.Text = "VAT";
            this.lblVat.Visible = false;
            // 
            // txtVat
            // 
            this.txtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVat.Location = new System.Drawing.Point(173, 37);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(215, 28);
            this.txtVat.TabIndex = 6;
            this.txtVat.Visible = false;
            // 
            // lblNet
            // 
            this.lblNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNet.AutoSize = true;
            this.lblNet.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(24, 10);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(111, 18);
            this.lblNet.TabIndex = 5;
            this.lblNet.Text = "Total Charges";
            this.lblNet.Visible = false;
            // 
            // txtNet
            // 
            this.txtNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNet.Location = new System.Drawing.Point(173, 6);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(215, 28);
            this.txtNet.TabIndex = 4;
            this.txtNet.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(30, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grand Total";
            // 
            // radPanel4
            // 
            this.radPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel4.Controls.Add(this.txtInvoiceAmount);
            this.radPanel4.Location = new System.Drawing.Point(173, 132);
            this.radPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(216, 43);
            this.radPanel4.TabIndex = 3;
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceAmount.ForeColor = System.Drawing.Color.Red;
            this.txtInvoiceAmount.Location = new System.Drawing.Point(2, 7);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(201, 28);
            this.txtInvoiceAmount.TabIndex = 0;
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 381);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1332, 401);
            this.grdLister.TabIndex = 109;
            this.grdLister.Text = "myGridView1";
            // 
            // contextMenuCreditNote
            // 
            this.contextMenuCreditNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCreditNote});
            this.contextMenuCreditNote.Name = "contextMenuCreditNote";
            this.contextMenuCreditNote.Size = new System.Drawing.Size(172, 26);
            // 
            // deleteCreditNote
            // 
            this.deleteCreditNote.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.deleteCreditNote.Name = "deleteCreditNote";
            this.deleteCreditNote.Size = new System.Drawing.Size(171, 22);
            this.deleteCreditNote.Text = "Delete Credit Note";
            this.deleteCreditNote.Click += new System.EventHandler(this.deleteCreditNote_Click);
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 960);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.f);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel5);
            this.FormTitle = "Account Invoice";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmInvoice";
            this.ShowSaveAndCloseButton = true;
            this.Text = "Account Invoice";
            this.Shown += new System.EventHandler(this.frmInvoice_Shown);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.radPanel5, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.f, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel27)).EndInit();
            this.radLabel27.ResumeLayout(false);
            this.radLabel27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSplitBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSplitBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInvoiceDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).EndInit();
            this.f.ResumeLayout(false);
            this.f.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPickType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.contextMenuCreditNote.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpInvoiceDate;
        private Telerik.WinControls.UI.RadTextBox txtInvoiceNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private SuggestComboBox ddlCompany;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadPanel f;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private UI.MyGridView grdLister;
        private Telerik.WinControls.UI.RadGridView radGridView2;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private System.Windows.Forms.Label txtInvoiceAmount;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadDropDownList ddlDepartment;
        private Telerik.WinControls.UI.RadButton btnSaveInvoice;
        private Telerik.WinControls.UI.RadCheckBox chkDepartmentWise;
        private Telerik.WinControls.UI.RadButton btnSendEmail;
        private Telerik.WinControls.UI.RadDropDownList ddlPickType;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel27;
        private Telerik.WinControls.UI.RadDropDownList ddlAccountType;
        private System.Windows.Forms.Label label4;
        private UI.MyDatePicker dtpDueDate;
        private Telerik.WinControls.UI.RadButton btnExportExcel;
        private Telerik.WinControls.UI.RadDropDownList ddlOrderNo;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTextBox txtOrderNo;
        private Telerik.WinControls.UI.RadLabel lblOrderNo;
        private Telerik.WinControls.UI.RadDropDownList ddlSplitBy;
        private Telerik.WinControls.UI.RadLabel lblSplitBy;
        private Telerik.WinControls.UI.RadButton btnAddNewInvoice;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadCheckBox chkAutoContinue;
        private Telerik.WinControls.UI.RadCheckBox chkAllFromDate;
        private  System.Windows.Forms.RichTextBox txtNotes;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Button btnCreditNote;
        private ContextMenuStrip contextMenuCreditNote;
        private ToolStripMenuItem deleteCreditNote;
        private Telerik.WinControls.UI.RadSplitButton btnExportToExcel2;
        private Telerik.WinControls.UI.RadMenuItem radMenuExportToExcel;
        private Telerik.WinControls.UI.RadMenuItem radMenuExportBooking;
        private SaveFileDialog saveFileDialog2;
        private Label lblAdminfee;
        private Label txtAdminFee;
        private Label lblVat;
        private Label txtVat;
        private Label lblNet;
        private Label txtNet;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private Label label6;
        private Label lblExtras;
        private Label numExtras;
    }
}