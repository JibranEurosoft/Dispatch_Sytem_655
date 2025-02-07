namespace Taxi_AppMain
{
    partial class frmEscortList
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdLister = new UI.MyGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnPendingApproval = new System.Windows.Forms.Button();
            this.btnAddNewCompany = new System.Windows.Forms.Button();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.btnExport = new Telerik.WinControls.UI.RadButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnShowAllCompanies = new Telerik.WinControls.UI.RadButton();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.ddlColumns = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = true;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 80);
            this.grdLister.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1209, 880);
            this.grdLister.TabIndex = 113;
            this.grdLister.Text = "myGridView1";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1209, 42);
            this.radPanel1.TabIndex = 112;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel2.Controls.Add(this.btnPendingApproval);
            this.radPanel2.Controls.Add(this.btnAddNewCompany);
            this.radPanel2.Controls.Add(this.radProgressBar1);
            this.radPanel2.Controls.Add(this.btnExport);
            this.radPanel2.Controls.Add(this.lblTotal);
            this.radPanel2.Controls.Add(this.btnShowAllCompanies);
            this.radPanel2.Controls.Add(this.btnFind);
            this.radPanel2.Controls.Add(this.txtSearch);
            this.radPanel2.Controls.Add(this.ddlColumns);
            this.radPanel2.Controls.Add(this.label1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1209, 42);
            this.radPanel2.TabIndex = 107;
            // 
            // btnPendingApproval
            // 
            this.btnPendingApproval.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingApproval.ForeColor = System.Drawing.Color.Black;
            this.btnPendingApproval.Location = new System.Drawing.Point(909, 2);
            this.btnPendingApproval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPendingApproval.Name = "btnPendingApproval";
            this.btnPendingApproval.Size = new System.Drawing.Size(215, 36);
            this.btnPendingApproval.TabIndex = 8;
            this.btnPendingApproval.Text = "Pending Approval";
            this.btnPendingApproval.UseVisualStyleBackColor = true;
            this.btnPendingApproval.Visible = false;
            this.btnPendingApproval.Click += new System.EventHandler(this.btnPendingApproval_Click);
            // 
            // btnAddNewCompany
            // 
            this.btnAddNewCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.btnAddNewCompany.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddNewCompany.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAddNewCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCompany.Location = new System.Drawing.Point(1074, 0);
            this.btnAddNewCompany.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewCompany.Name = "btnAddNewCompany";
            this.btnAddNewCompany.Size = new System.Drawing.Size(135, 42);
            this.btnAddNewCompany.TabIndex = 7;
            this.btnAddNewCompany.Text = "Add New Escort";
            this.btnAddNewCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCompany.UseVisualStyleBackColor = false;
            this.btnAddNewCompany.Click += new System.EventHandler(this.btnAddNewCompany_Click);
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Location = new System.Drawing.Point(727, 5);
            this.radProgressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.Size = new System.Drawing.Size(175, 32);
            this.radProgressBar1.TabIndex = 1;
            this.radProgressBar1.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            this.btnExport.Location = new System.Drawing.Point(596, 5);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(123, 30);
            this.btnExport.TabIndex = 6;
            this.btnExport.Tag = "";
            this.btnExport.Text = "Export To Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Text = "Export To Excel";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1093, 0);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 41);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total Companies : 5";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.Visible = false;
            // 
            // btnShowAllCompanies
            // 
            this.btnShowAllCompanies.Image = global::Taxi_AppMain.Properties.Resources.select;
            this.btnShowAllCompanies.Location = new System.Drawing.Point(454, 6);
            this.btnShowAllCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowAllCompanies.Name = "btnShowAllCompanies";
            this.btnShowAllCompanies.Size = new System.Drawing.Size(134, 30);
            this.btnShowAllCompanies.TabIndex = 4;
            this.btnShowAllCompanies.Tag = "";
            this.btnShowAllCompanies.Text = "Show All Escort";
            this.btnShowAllCompanies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAllCompanies.Click += new System.EventHandler(this.btnShowAllCompanies_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllCompanies.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.select;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllCompanies.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllCompanies.GetChildAt(0))).Text = "Show All Escort";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllCompanies.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllCompanies.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllCompanies.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFind.Location = new System.Drawing.Point(380, 6);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(69, 30);
            this.btnFind.TabIndex = 3;
            this.btnFind.Tag = "";
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFind.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(80, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(153, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TabStop = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ddlColumns
            // 
            this.ddlColumns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlColumns.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlColumns.Location = new System.Drawing.Point(241, 7);
            this.ddlColumns.Margin = new System.Windows.Forms.Padding(4);
            this.ddlColumns.Name = "ddlColumns";
            this.ddlColumns.Size = new System.Drawing.Size(132, 21);
            this.ddlColumns.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmEscortList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 960);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormTitle = "Escort List";
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEscortList";
            this.ShowHeader = true;
            this.Text = "Escort  List";
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.MyGridView grdLister;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadButton btnExport;
        private System.Windows.Forms.Label lblTotal;
        private Telerik.WinControls.UI.RadButton btnShowAllCompanies;
        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadDropDownList ddlColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewCompany;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPendingApproval;
    }
}