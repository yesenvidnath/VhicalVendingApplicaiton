namespace WindowsFormsApp1.MainUserControls
{
    partial class BrandsList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgbrand = new System.Windows.Forms.PictureBox();
            this.lblbrandname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgbrand)).BeginInit();
            this.SuspendLayout();
            // 
            // imgbrand
            // 
            this.imgbrand.Location = new System.Drawing.Point(0, 0);
            this.imgbrand.Name = "imgbrand";
            this.imgbrand.Size = new System.Drawing.Size(129, 70);
            this.imgbrand.TabIndex = 0;
            this.imgbrand.TabStop = false;
            // 
            // lblbrandname
            // 
            this.lblbrandname.AutoSize = true;
            this.lblbrandname.Location = new System.Drawing.Point(155, 27);
            this.lblbrandname.Name = "lblbrandname";
            this.lblbrandname.Size = new System.Drawing.Size(35, 13);
            this.lblbrandname.TabIndex = 1;
            this.lblbrandname.Text = "label1";
            // 
            // BrandsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblbrandname);
            this.Controls.Add(this.imgbrand);
            this.Name = "BrandsList";
            this.Size = new System.Drawing.Size(239, 70);
            this.Load += new System.EventHandler(this.BrandsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgbrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgbrand;
        private System.Windows.Forms.Label lblbrandname;
    }
}
