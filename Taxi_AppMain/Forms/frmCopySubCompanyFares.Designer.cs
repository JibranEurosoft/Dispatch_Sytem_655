﻿namespace Taxi_AppMain
{
    partial class frmCopySubCompanyFares
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPercentage = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optOnlyFixedFares = new Telerik.WinControls.UI.RadRadioButton();
            this.optOnlyMileage = new Telerik.WinControls.UI.RadRadioButton();
            this.optOnlyPlottoPlot = new Telerik.WinControls.UI.RadRadioButton();
            this.optApplyAll = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtnAdd = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtnSubtract = new Telerik.WinControls.UI.RadRadioButton();
            this.lblPercent = new Telerik.WinControls.UI.RadLabel();
            this.numPercent = new Telerik.WinControls.UI.RadSpinEditor();
            this.grdCompany = new UI.MyGridView();
            this.chkAllCompany = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyfares = new Telerik.WinControls.UI.RadButton();
            this.lblExportingStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlPercentage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyFixedFares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyPlottoPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optApplyAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany.MasterTemplate)).BeginInit();
            this.grdCompany.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyfares)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlPercentage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 62);
            this.panel1.TabIndex = 106;
            // 
            // pnlPercentage
            // 
            this.pnlPercentage.Controls.Add(this.panel3);
            this.pnlPercentage.Controls.Add(this.rbtnAdd);
            this.pnlPercentage.Controls.Add(this.rbtnSubtract);
            this.pnlPercentage.Controls.Add(this.lblPercent);
            this.pnlPercentage.Controls.Add(this.numPercent);
            this.pnlPercentage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPercentage.Location = new System.Drawing.Point(0, 0);
            this.pnlPercentage.Name = "pnlPercentage";
            this.pnlPercentage.Size = new System.Drawing.Size(423, 59);
            this.pnlPercentage.TabIndex = 71;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.optOnlyFixedFares);
            this.panel3.Controls.Add(this.optOnlyMileage);
            this.panel3.Controls.Add(this.optOnlyPlottoPlot);
            this.panel3.Controls.Add(this.optApplyAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 27);
            this.panel3.TabIndex = 70;
            // 
            // optOnlyFixedFares
            // 
            this.optOnlyFixedFares.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOnlyFixedFares.Location = new System.Drawing.Point(308, 4);
            this.optOnlyFixedFares.Name = "optOnlyFixedFares";
            this.optOnlyFixedFares.Size = new System.Drawing.Size(117, 18);
            this.optOnlyFixedFares.TabIndex = 73;
            this.optOnlyFixedFares.Text = "Only Fixed Fares";
            // 
            // optOnlyMileage
            // 
            this.optOnlyMileage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOnlyMileage.Location = new System.Drawing.Point(202, 4);
            this.optOnlyMileage.Name = "optOnlyMileage";
            this.optOnlyMileage.Size = new System.Drawing.Size(99, 18);
            this.optOnlyMileage.TabIndex = 72;
            this.optOnlyMileage.Text = "Only Mileage";
            // 
            // optOnlyPlottoPlot
            // 
            this.optOnlyPlottoPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOnlyPlottoPlot.Location = new System.Drawing.Point(81, 4);
            this.optOnlyPlottoPlot.Name = "optOnlyPlottoPlot";
            this.optOnlyPlottoPlot.Size = new System.Drawing.Size(116, 18);
            this.optOnlyPlottoPlot.TabIndex = 71;
            this.optOnlyPlottoPlot.Text = "Only Plot to Plot";
            // 
            // optApplyAll
            // 
            this.optApplyAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optApplyAll.Location = new System.Drawing.Point(4, 4);
            this.optApplyAll.Name = "optApplyAll";
            this.optApplyAll.Size = new System.Drawing.Size(74, 18);
            this.optApplyAll.TabIndex = 70;
            this.optApplyAll.Text = "Apply All";
            this.optApplyAll.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAdd.Location = new System.Drawing.Point(4, 7);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(43, 18);
            this.rbtnAdd.TabIndex = 65;
            this.rbtnAdd.Text = "Add";
            this.rbtnAdd.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbtnSubtract
            // 
            this.rbtnSubtract.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSubtract.Location = new System.Drawing.Point(82, 7);
            this.rbtnSubtract.Name = "rbtnSubtract";
            this.rbtnSubtract.Size = new System.Drawing.Size(75, 18);
            this.rbtnSubtract.TabIndex = 66;
            this.rbtnSubtract.Text = "Subtract";
            // 
            // lblPercent
            // 
            this.lblPercent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(164, 8);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(48, 18);
            this.lblPercent.TabIndex = 68;
            this.lblPercent.Text = "Percent";
            // 
            // numPercent
            // 
            this.numPercent.DecimalPlaces = 2;
            this.numPercent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPercent.Location = new System.Drawing.Point(233, 5);
            this.numPercent.Name = "numPercent";
            // 
            // 
            // 
            this.numPercent.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numPercent.ShowBorder = true;
            this.numPercent.Size = new System.Drawing.Size(81, 21);
            this.numPercent.TabIndex = 67;
            this.numPercent.TabStop = false;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numPercent.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numPercent.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numPercent.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdCompany
            // 
            this.grdCompany.AutoCellFormatting = false;
            this.grdCompany.Controls.Add(this.chkAllCompany);
            this.grdCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCompany.EnableCheckInCheckOut = true;
            this.grdCompany.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdCompany.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdCompany.Location = new System.Drawing.Point(0, 100);
            // 
            // grdCompany
            // 
            this.grdCompany.MasterTemplate.AllowAddNewRow = false;
            this.grdCompany.Name = "grdCompany";
            this.grdCompany.PKFieldColumnName = "";
            this.grdCompany.ShowGroupPanel = false;
            this.grdCompany.ShowImageOnActionButton = true;
            this.grdCompany.Size = new System.Drawing.Size(423, 351);
            this.grdCompany.TabIndex = 107;
            this.grdCompany.Text = "myGridView1";
            // 
            // chkAllCompany
            // 
            this.chkAllCompany.AutoSize = true;
            this.chkAllCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllCompany.Location = new System.Drawing.Point(24, 6);
            this.chkAllCompany.Name = "chkAllCompany";
            this.chkAllCompany.Size = new System.Drawing.Size(43, 20);
            this.chkAllCompany.TabIndex = 110;
            this.chkAllCompany.Text = "All";
            this.chkAllCompany.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCopyfares);
            this.panel2.Controls.Add(this.lblExportingStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 451);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 55);
            this.panel2.TabIndex = 108;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnClose.Location = new System.Drawing.Point(209, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 49);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Text = "Close";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 54;
            // 
            // btnCopyfares
            // 
            this.btnCopyfares.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnCopyfares.Location = new System.Drawing.Point(60, 3);
            this.btnCopyfares.Name = "btnCopyfares";
            this.btnCopyfares.Size = new System.Drawing.Size(113, 49);
            this.btnCopyfares.TabIndex = 53;
            this.btnCopyfares.Text = "Copy Fares";
            this.btnCopyfares.Click += new System.EventHandler(this.btnCopyfares_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCopyfares.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCopyfares.GetChildAt(0))).Text = "Copy Fares";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnCopyfares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnCopyfares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblExportingStatus
            // 
            this.lblExportingStatus.AutoSize = true;
            this.lblExportingStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportingStatus.Location = new System.Drawing.Point(606, 20);
            this.lblExportingStatus.Name = "lblExportingStatus";
            this.lblExportingStatus.Size = new System.Drawing.Size(0, 16);
            this.lblExportingStatus.TabIndex = 52;
            // 
            // frmCopySubCompanyFares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 506);
            this.ControlBox = true;
            this.Controls.Add(this.grdCompany);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Copy Fares for Sub Company";
            this.Name = "frmCopySubCompanyFares";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Copy Fares for Sub Company";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grdCompany, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlPercentage.ResumeLayout(false);
            this.pnlPercentage.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyFixedFares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optOnlyPlottoPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optApplyAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
            this.grdCompany.ResumeLayout(false);
            this.grdCompany.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyfares)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UI.MyGridView grdCompany;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblExportingStatus;
        private Telerik.WinControls.UI.RadButton btnCopyfares;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnClose;
        private System.Windows.Forms.Panel pnlPercentage;
        private Telerik.WinControls.UI.RadRadioButton rbtnAdd;
        private Telerik.WinControls.UI.RadRadioButton rbtnSubtract;
        private Telerik.WinControls.UI.RadLabel lblPercent;
        private Telerik.WinControls.UI.RadSpinEditor numPercent;
        private System.Windows.Forms.CheckBox chkAllCompany;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadRadioButton optApplyAll;
        private Telerik.WinControls.UI.RadRadioButton optOnlyPlottoPlot;
        private Telerik.WinControls.UI.RadRadioButton optOnlyFixedFares;
        private Telerik.WinControls.UI.RadRadioButton optOnlyMileage;
    }
}