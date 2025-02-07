namespace Taxi_AppMain.Forms
{
    partial class BaseForm
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
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
       //     ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 228);
            this.ControlBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "BaseForm";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.Text = "frmAll";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAll_KeyDown);
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}