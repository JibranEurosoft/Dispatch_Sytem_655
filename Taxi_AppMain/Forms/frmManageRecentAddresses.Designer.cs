namespace Taxi_AppMain
{
    partial class frmManageRecentAddresses
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAddresses = new Telerik.WinControls.UI.RadButton();
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearAddresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radButton1);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClearAddresses);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 145);
            this.panel1.TabIndex = 106;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(904, 95);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(108, 47);
            this.radButton1.TabIndex = 15;
            this.radButton1.Tag = "";
            this.radButton1.Text = "Clear Invalid Addresses";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.TextWrap = true;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Clear Invalid Addresses";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.AliceBlue;
            this.btnsearch.Image = global::Taxi_AppMain.Properties.Resources.glossary_toolbar_find;
            this.btnsearch.Location = new System.Drawing.Point(529, 6);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 37);
            this.btnsearch.TabIndex = 14;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(158, 14);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(343, 26);
            this.txtsearch.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search Keyword";
            // 
            // btnClearAddresses
            // 
            this.btnClearAddresses.Location = new System.Drawing.Point(807, 3);
            this.btnClearAddresses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearAddresses.Name = "btnClearAddresses";
            this.btnClearAddresses.Size = new System.Drawing.Size(205, 47);
            this.btnClearAddresses.TabIndex = 11;
            this.btnClearAddresses.Tag = "";
            this.btnClearAddresses.Text = "Clear All Recent Addresses";
            this.btnClearAddresses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAddresses.Click += new System.EventHandler(this.btnClearAddresses_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClearAddresses.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClearAddresses.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClearAddresses.GetChildAt(0))).Text = "Clear All Recent Addresses";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClearAddresses.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClearAddresses.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClearAddresses.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Location = new System.Drawing.Point(0, 183);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdLister.Name = "grdLister";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.Size = new System.Drawing.Size(1025, 763);
            this.grdLister.TabIndex = 112;
            this.grdLister.Text = "myGridView1";
            // 
            // frmManageRecentAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 946);
            this.ControlBox = true;
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Manage Recent Addresses";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManageRecentAddresses";
            this.ShowHeader = true;
            this.Text = "Manage Recent Addresses";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearAddresses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private Telerik.WinControls.UI.RadButton btnClearAddresses;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}