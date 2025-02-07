namespace Taxi_AppMain.Forms
{
    partial class frmManualPaymentPage
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
            this.OPTCard = new System.Windows.Forms.RadioButton();
            this.OptCash = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHeading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OPTCard
            // 
            this.OPTCard.AutoSize = true;
            this.OPTCard.Checked = true;
            this.OPTCard.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTCard.Location = new System.Drawing.Point(22, 62);
            this.OPTCard.Name = "OPTCard";
            this.OPTCard.Size = new System.Drawing.Size(397, 27);
            this.OPTCard.TabIndex = 0;
            this.OPTCard.TabStop = true;
            this.OPTCard.Text = "Do you want to Process the Payment ?";
            this.OPTCard.UseVisualStyleBackColor = true;
            this.OPTCard.CheckedChanged += new System.EventHandler(this.OPTCard_CheckedChanged);
            // 
            // OptCash
            // 
            this.OptCash.AutoSize = true;
            this.OptCash.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptCash.Location = new System.Drawing.Point(21, 116);
            this.OptCash.Name = "OptCash";
            this.OptCash.Size = new System.Drawing.Size(407, 27);
            this.OptCash.TabIndex = 1;
            this.OptCash.TabStop = true;
            this.OptCash.Text = "Do you want to clear the Job as CASH ?";
            this.OptCash.UseVisualStyleBackColor = true;
            this.OptCash.CheckedChanged += new System.EventHandler(this.OptCash_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(164, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(215, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Process the Payment";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHeading
            // 
            this.txtHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHeading.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeading.ForeColor = System.Drawing.Color.Red;
            this.txtHeading.Location = new System.Drawing.Point(0, 0);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.Size = new System.Drawing.Size(532, 31);
            this.txtHeading.TabIndex = 3;
            this.txtHeading.Text = "label1";
            this.txtHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmManualPaymentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(532, 228);
            this.Controls.Add(this.txtHeading);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.OptCash);
            this.Controls.Add(this.OPTCard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManualPaymentPage";
            this.ShowIcon = false;
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton OPTCard;
        private System.Windows.Forms.RadioButton OptCash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label txtHeading;
    }
}
