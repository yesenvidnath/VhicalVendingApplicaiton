namespace WindowsFormsApp1
{
    partial class Home
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
            this.flpproducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flpbrands = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpproducts
            // 
            this.flpproducts.AutoScroll = true;
            this.flpproducts.Location = new System.Drawing.Point(49, 207);
            this.flpproducts.Name = "flpproducts";
            this.flpproducts.Size = new System.Drawing.Size(1163, 472);
            this.flpproducts.TabIndex = 0;
            this.flpproducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flpproducts_Paint_1);
            // 
            // flpbrands
            // 
            this.flpbrands.AutoScroll = true;
            this.flpbrands.Location = new System.Drawing.Point(49, 148);
            this.flpbrands.Name = "flpbrands";
            this.flpbrands.Size = new System.Drawing.Size(1163, 53);
            this.flpbrands.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 691);
            this.Controls.Add(this.flpbrands);
            this.Controls.Add(this.flpproducts);
            this.Name = "Home";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpproducts;
        private System.Windows.Forms.FlowLayoutPanel flpbrands;
    }
}