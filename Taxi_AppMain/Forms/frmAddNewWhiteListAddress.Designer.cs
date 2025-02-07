namespace Taxi_AppMain
{
    partial class frmAddNewWhiteListAddress
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
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.txtNotes = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtAddress = new UI.AutoCompleteTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(792, 234);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(810, 340);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(703, 234);
            // 
            // btnExit1
            // 
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit1.Location = new System.Drawing.Point(401, 344);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(124, 59);
            this.btnExit1.TabIndex = 6;
            this.btnExit1.Text = "Exit";
            this.btnExit1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtNotes
            // 
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(255, 193);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            // 
            // 
            // 
            this.txtNotes.RootElement.StretchVertically = true;
            this.txtNotes.Size = new System.Drawing.Size(270, 93);
            this.txtNotes.TabIndex = 2;
            this.txtNotes.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(174, 155);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(60, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Address";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "Address";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(174, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 59);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(174, 193);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(41, 19);
            this.radLabel4.TabIndex = 106;
            this.radLabel4.Text = "Notes";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.DefaultHeight = 120;
            this.txtAddress.DefaultWidth = 0;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForceListBoxToUpdate = false;
            this.txtAddress.FormerValue = "";
            this.txtAddress.Location = new System.Drawing.Point(255, 145);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            // 
            // 
            // 
            this.txtAddress.RootElement.StretchVertically = true;
            this.txtAddress.SelectedItem = null;
            this.txtAddress.Size = new System.Drawing.Size(270, 42);
            this.txtAddress.TabIndex = 107;
            this.txtAddress.TabStop = false;
            this.txtAddress.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtAddress.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // frmAddNewWhiteListAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 419);
            this.ControlBox = true;
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnExit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Add New White List Address";
            this.KeyPreview = true;
            this.Name = "frmAddNewWhiteListAddress";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Add New White List Address";
            this.Load += new System.EventHandler(this.frmAddNewAddress_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddNewAddress_KeyDown);
            this.Controls.SetChildIndex(this.btnExit1, 0);
            this.Controls.SetChildIndex(this.radLabel1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtNotes, 0);
            this.Controls.SetChildIndex(this.radLabel4, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private Telerik.WinControls.UI.RadTextBox txtNotes;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.Timer timer1;
        private UI.AutoCompleteTextBox txtAddress;
    }
}