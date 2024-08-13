namespace WindowsFormsApp1.GUI.MainUserControls
{
    partial class OrdersCard
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
            this.lblorderid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblorderdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltotamount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblorderstatus = new System.Windows.Forms.Label();
            this.btncancelorder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblorderid
            // 
            this.lblorderid.AutoSize = true;
            this.lblorderid.Location = new System.Drawing.Point(82, 33);
            this.lblorderid.Name = "lblorderid";
            this.lblorderid.Size = new System.Drawing.Size(35, 13);
            this.lblorderid.TabIndex = 0;
            this.lblorderid.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ordered Date: ";
            // 
            // lblorderdate
            // 
            this.lblorderdate.AutoSize = true;
            this.lblorderdate.Location = new System.Drawing.Point(290, 33);
            this.lblorderdate.Name = "lblorderdate";
            this.lblorderdate.Size = new System.Drawing.Size(35, 13);
            this.lblorderdate.TabIndex = 2;
            this.lblorderdate.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(103, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Amount:";
            // 
            // lbltotamount
            // 
            this.lbltotamount.AutoSize = true;
            this.lbltotamount.Location = new System.Drawing.Point(188, 74);
            this.lbltotamount.Name = "lbltotamount";
            this.lbltotamount.Size = new System.Drawing.Size(35, 13);
            this.lbltotamount.TabIndex = 4;
            this.lbltotamount.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(107, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order Status:";
            // 
            // lblorderstatus
            // 
            this.lblorderstatus.AutoSize = true;
            this.lblorderstatus.Location = new System.Drawing.Point(188, 113);
            this.lblorderstatus.Name = "lblorderstatus";
            this.lblorderstatus.Size = new System.Drawing.Size(35, 13);
            this.lblorderstatus.TabIndex = 6;
            this.lblorderstatus.Text = "label1";
            // 
            // btncancelorder
            // 
            this.btncancelorder.Location = new System.Drawing.Point(53, 139);
            this.btncancelorder.Name = "btncancelorder";
            this.btncancelorder.Size = new System.Drawing.Size(249, 33);
            this.btncancelorder.TabIndex = 8;
            this.btncancelorder.Text = "Cancel Order";
            this.btncancelorder.UseVisualStyleBackColor = true;
            // 
            // OrdersCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.btncancelorder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblorderstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltotamount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblorderdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblorderid);
            this.Name = "OrdersCard";
            this.Size = new System.Drawing.Size(347, 191);
            this.Load += new System.EventHandler(this.OrdersCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblorderdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltotamount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblorderstatus;
        private System.Windows.Forms.Button btncancelorder;
    }
}
