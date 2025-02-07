namespace Taxi_AppMain
{
    partial class frmAttributesList
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
            this.btnSave = new System.Windows.Forms.Button();
            this.radButton1 = new System.Windows.Forms.Button();
            this.grdAttributesList = new Telerik.WinControls.UI.RadGridView();
            this.grdReturnAttributesList = new Telerik.WinControls.UI.RadGridView();
            this.lblReturn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttributesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttributesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnAttributesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnAttributesList.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(439, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 37);
            this.btnSave.TabIndex = 282;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(439, 111);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(128, 37);
            this.radButton1.TabIndex = 283;
            this.radButton1.Text = "Close";
            this.radButton1.UseVisualStyleBackColor = false;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // grdAttributesList
            // 
            this.grdAttributesList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAttributesList.Location = new System.Drawing.Point(0, 4);
            this.grdAttributesList.Name = "grdAttributesList";
            this.grdAttributesList.Size = new System.Drawing.Size(433, 465);
            this.grdAttributesList.TabIndex = 286;
            this.grdAttributesList.Text = "radGridView1";
            this.grdAttributesList.Click += new System.EventHandler(this.grdAttributesList_Click);
            // 
            // grdReturnAttributesList
            // 
            this.grdReturnAttributesList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdReturnAttributesList.Location = new System.Drawing.Point(0, 258);
            this.grdReturnAttributesList.Name = "grdReturnAttributesList";
            this.grdReturnAttributesList.Size = new System.Drawing.Size(433, 211);
            this.grdReturnAttributesList.TabIndex = 287;
            this.grdReturnAttributesList.Text = "radGridView1";
            this.grdReturnAttributesList.Visible = false;
            // 
            // lblReturn
            // 
            this.lblReturn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(4, 235);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(429, 23);
            this.lblReturn.TabIndex = 288;
            this.lblReturn.Text = "Return Details";
            this.lblReturn.Visible = false;
            // 
            // frmAttributesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(574, 472);
            this.ControlBox = false;
            this.Controls.Add(this.grdAttributesList);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.grdReturnAttributesList);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttributesList";
            this.ShowIcon = false;
            this.Text = "Extra Charges";
            this.Load += new System.EventHandler(this.frmAttributesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAttributesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttributesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnAttributesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReturnAttributesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button radButton1;
        private System.Windows.Forms.DataGridViewButtonColumn btnAdd;
        private Telerik.WinControls.UI.RadGridView grdAttributesList;
        private Telerik.WinControls.UI.RadGridView grdReturnAttributesList;
        private System.Windows.Forms.Label lblReturn;
    }
}
