namespace WindowsFormsApp1.MainUserControls
{
    partial class VehicleCard
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
            this.lblcarname = new System.Windows.Forms.Label();
            this.lblbrand = new System.Windows.Forms.Label();
            this.lblyear = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.btnaddlist = new System.Windows.Forms.Button();
            this.btnseemore = new System.Windows.Forms.Button();
            this.btnorder = new System.Windows.Forms.Button();
            this.imgbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgbox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcarname
            // 
            this.lblcarname.AutoSize = true;
            this.lblcarname.Location = new System.Drawing.Point(37, 187);
            this.lblcarname.Name = "lblcarname";
            this.lblcarname.Size = new System.Drawing.Size(35, 13);
            this.lblcarname.TabIndex = 1;
            this.lblcarname.Text = "label1";
            // 
            // lblbrand
            // 
            this.lblbrand.AutoSize = true;
            this.lblbrand.Location = new System.Drawing.Point(188, 187);
            this.lblbrand.Name = "lblbrand";
            this.lblbrand.Size = new System.Drawing.Size(35, 13);
            this.lblbrand.TabIndex = 2;
            this.lblbrand.Text = "label2";
            // 
            // lblyear
            // 
            this.lblyear.AutoSize = true;
            this.lblyear.Location = new System.Drawing.Point(37, 236);
            this.lblyear.Name = "lblyear";
            this.lblyear.Size = new System.Drawing.Size(35, 13);
            this.lblyear.TabIndex = 3;
            this.lblyear.Text = "label3";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(188, 236);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(35, 13);
            this.lblprice.TabIndex = 4;
            this.lblprice.Text = "label4";
            // 
            // btnaddlist
            // 
            this.btnaddlist.Location = new System.Drawing.Point(21, 283);
            this.btnaddlist.Name = "btnaddlist";
            this.btnaddlist.Size = new System.Drawing.Size(99, 29);
            this.btnaddlist.TabIndex = 5;
            this.btnaddlist.Text = "Add to List";
            this.btnaddlist.UseVisualStyleBackColor = true;
            this.btnaddlist.Click += new System.EventHandler(this.btnaddlist_Click);
            // 
            // btnseemore
            // 
            this.btnseemore.Location = new System.Drawing.Point(141, 283);
            this.btnseemore.Name = "btnseemore";
            this.btnseemore.Size = new System.Drawing.Size(99, 29);
            this.btnseemore.TabIndex = 6;
            this.btnseemore.Text = "See More";
            this.btnseemore.UseVisualStyleBackColor = true;
            this.btnseemore.Click += new System.EventHandler(this.btnseemore_Click);
            // 
            // btnorder
            // 
            this.btnorder.Location = new System.Drawing.Point(21, 318);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(219, 28);
            this.btnorder.TabIndex = 7;
            this.btnorder.Text = "Order Now";
            this.btnorder.UseVisualStyleBackColor = true;
            this.btnorder.Click += new System.EventHandler(this.btnorder_Click);
            // 
            // imgbox
            // 
            this.imgbox.Location = new System.Drawing.Point(0, 0);
            this.imgbox.Name = "imgbox";
            this.imgbox.Size = new System.Drawing.Size(273, 168);
            this.imgbox.TabIndex = 8;
            this.imgbox.TabStop = false;
            this.imgbox.Click += new System.EventHandler(this.imgbox_Click_1);
            // 
            // VehicleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.imgbox);
            this.Controls.Add(this.btnorder);
            this.Controls.Add(this.btnseemore);
            this.Controls.Add(this.btnaddlist);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblyear);
            this.Controls.Add(this.lblbrand);
            this.Controls.Add(this.lblcarname);
            this.Name = "VehicleCard";
            this.Size = new System.Drawing.Size(273, 371);
            this.Load += new System.EventHandler(this.VehicleCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblcarname;
        private System.Windows.Forms.Label lblbrand;
        private System.Windows.Forms.Label lblyear;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Button btnaddlist;
        private System.Windows.Forms.Button btnseemore;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.PictureBox imgbox;
    }
}
