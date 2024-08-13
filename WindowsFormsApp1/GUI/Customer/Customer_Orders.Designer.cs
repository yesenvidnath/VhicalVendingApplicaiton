namespace WindowsFormsApp1.Customer
{
    partial class Customer_Orders
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
            this.flporderlist = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flporderlist
            // 
            this.flporderlist.Location = new System.Drawing.Point(12, 121);
            this.flporderlist.Name = "flporderlist";
            this.flporderlist.Size = new System.Drawing.Size(1110, 488);
            this.flporderlist.TabIndex = 0;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 621);
            this.Controls.Add(this.flporderlist);
            this.Name = "Orders";
            this.Text = "Orders";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flporderlist;
    }
}