namespace WindowsFormsApp1.GUI
{
    partial class CustomerCart
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
            this.flpcartitems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnproceedtocheckout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpcartitems
            // 
            this.flpcartitems.Location = new System.Drawing.Point(371, 83);
            this.flpcartitems.Name = "flpcartitems";
            this.flpcartitems.Size = new System.Drawing.Size(400, 447);
            this.flpcartitems.TabIndex = 0;
            // 
            // btnproceedtocheckout
            // 
            this.btnproceedtocheckout.Location = new System.Drawing.Point(807, 83);
            this.btnproceedtocheckout.Name = "btnproceedtocheckout";
            this.btnproceedtocheckout.Size = new System.Drawing.Size(242, 48);
            this.btnproceedtocheckout.TabIndex = 1;
            this.btnproceedtocheckout.Text = "Proceed to Order All";
            this.btnproceedtocheckout.UseVisualStyleBackColor = true;
            this.btnproceedtocheckout.Click += new System.EventHandler(this.btnproceedtocheckout_Click);
            // 
            // CustomerCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 546);
            this.Controls.Add(this.btnproceedtocheckout);
            this.Controls.Add(this.flpcartitems);
            this.Name = "CustomerCart";
            this.Text = "Cart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpcartitems;
        private System.Windows.Forms.Button btnproceedtocheckout;
    }
}