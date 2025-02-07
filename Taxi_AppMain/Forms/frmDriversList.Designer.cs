namespace Taxi_AppMain
{
    partial class frmDriversList
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
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPendingApproval = new System.Windows.Forms.Button();
            this.btnExpiredDrivers = new Telerik.WinControls.UI.RadButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnExpiredDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Location = new System.Drawing.Point(0, 80);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdLister.Name = "grdLister";
            this.grdLister.Size = new System.Drawing.Size(1412, 924);
            this.grdLister.TabIndex = 109;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.lblTotal);
            this.radPanel1.Controls.Add(this.btnPendingApproval);
            this.radPanel1.Controls.Add(this.btnExpiredDrivers);
            this.radPanel1.Controls.Add(this.label11);
            this.radPanel1.Controls.Add(this.label12);
            this.radPanel1.Controls.Add(this.label9);
            this.radPanel1.Controls.Add(this.label10);
            this.radPanel1.Controls.Add(this.label7);
            this.radPanel1.Controls.Add(this.label8);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1412, 42);
            this.radPanel1.TabIndex = 108;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(1211, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(201, 42);
            this.lblTotal.TabIndex = 162;
            this.lblTotal.Text = "Total Driver(s) : 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPendingApproval
            // 
            this.btnPendingApproval.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingApproval.ForeColor = System.Drawing.Color.Black;
            this.btnPendingApproval.Location = new System.Drawing.Point(1179, 2);
            this.btnPendingApproval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPendingApproval.Name = "btnPendingApproval";
            this.btnPendingApproval.Size = new System.Drawing.Size(206, 36);
            this.btnPendingApproval.TabIndex = 1;
            this.btnPendingApproval.Text = "Pending Approval";
            this.btnPendingApproval.UseVisualStyleBackColor = true;
            this.btnPendingApproval.Visible = false;
            this.btnPendingApproval.Click += new System.EventHandler(this.btnPendingApproval_Click);
            // 
            // btnExpiredDrivers
            // 
            this.btnExpiredDrivers.Image = global::Taxi_AppMain.Properties.Resources.icon1;
            this.btnExpiredDrivers.Location = new System.Drawing.Point(1048, 4);
            this.btnExpiredDrivers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExpiredDrivers.Name = "btnExpiredDrivers";
            this.btnExpiredDrivers.Size = new System.Drawing.Size(118, 34);
            this.btnExpiredDrivers.TabIndex = 12;
            this.btnExpiredDrivers.Text = "    Expired Drivers";
            this.btnExpiredDrivers.Click += new System.EventHandler(this.btnExpiredDrivers_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExpiredDrivers.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExpiredDrivers.GetChildAt(0))).Text = "    Expired Drivers";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExpiredDrivers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExpiredDrivers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExpiredDrivers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(934, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "License Expiry";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(894, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(204, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "Road Tax Expiry";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Lavender;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(163, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(749, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "PCO Driver Expiry";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(708, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(563, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Insurance Expiry";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(523, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "PCO Vehicle Expiry";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Orange;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(322, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "MOT Expiry";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmDriversList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 1004);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.radPanel1);
            this.FormTitle = "Drivers List";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDriversList";
            this.ShowHeader = true;
            this.Text = "Drivers List";
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
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
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpiredDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdLister;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Telerik.WinControls.UI.RadButton btnExpiredDrivers;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPendingApproval;
    }
}