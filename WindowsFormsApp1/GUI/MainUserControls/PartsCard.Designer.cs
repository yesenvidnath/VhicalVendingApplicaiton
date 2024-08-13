namespace WindowsFormsApp1.GUI.MainUserControls
{
    partial class PartsCard
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
            this.imgPart = new System.Windows.Forms.PictureBox();
            this.btnorder = new System.Windows.Forms.Button();
            this.btnseemore = new System.Windows.Forms.Button();
            this.btnaddlist = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantityAvailable = new System.Windows.Forms.Label();
            this.lblbrand = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPart)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPart
            // 
            this.imgPart.Location = new System.Drawing.Point(0, 1);
            this.imgPart.Name = "imgPart";
            this.imgPart.Size = new System.Drawing.Size(273, 168);
            this.imgPart.TabIndex = 16;
            this.imgPart.TabStop = false;
            // 
            // btnorder
            // 
            this.btnorder.Location = new System.Drawing.Point(21, 319);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(219, 28);
            this.btnorder.TabIndex = 15;
            this.btnorder.Text = "Order Now";
            this.btnorder.UseVisualStyleBackColor = true;
            this.btnorder.Click += new System.EventHandler(this.btnorder_Click_1);
            // 
            // btnseemore
            // 
            this.btnseemore.Location = new System.Drawing.Point(141, 284);
            this.btnseemore.Name = "btnseemore";
            this.btnseemore.Size = new System.Drawing.Size(99, 29);
            this.btnseemore.TabIndex = 14;
            this.btnseemore.Text = "See More";
            this.btnseemore.UseVisualStyleBackColor = true;
            this.btnseemore.Click += new System.EventHandler(this.btnseemore_Click_1);
            // 
            // btnaddlist
            // 
            this.btnaddlist.Location = new System.Drawing.Point(21, 284);
            this.btnaddlist.Name = "btnaddlist";
            this.btnaddlist.Size = new System.Drawing.Size(99, 29);
            this.btnaddlist.TabIndex = 13;
            this.btnaddlist.Text = "Add to List";
            this.btnaddlist.UseVisualStyleBackColor = true;
            this.btnaddlist.Click += new System.EventHandler(this.btnaddlist_Click_1);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(188, 237);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 13);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "label4";
            // 
            // lblQuantityAvailable
            // 
            this.lblQuantityAvailable.AutoSize = true;
            this.lblQuantityAvailable.Location = new System.Drawing.Point(37, 237);
            this.lblQuantityAvailable.Name = "lblQuantityAvailable";
            this.lblQuantityAvailable.Size = new System.Drawing.Size(35, 13);
            this.lblQuantityAvailable.TabIndex = 11;
            this.lblQuantityAvailable.Text = "label3";
            // 
            // lblbrand
            // 
            this.lblbrand.AutoSize = true;
            this.lblbrand.Location = new System.Drawing.Point(188, 188);
            this.lblbrand.Name = "lblbrand";
            this.lblbrand.Size = new System.Drawing.Size(35, 13);
            this.lblbrand.TabIndex = 10;
            this.lblbrand.Text = "label2";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(37, 188);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(35, 13);
            this.lblPartName.TabIndex = 9;
            this.lblPartName.Text = "label1";
            // 
            // PartsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgPart);
            this.Controls.Add(this.btnorder);
            this.Controls.Add(this.btnseemore);
            this.Controls.Add(this.btnaddlist);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantityAvailable);
            this.Controls.Add(this.lblbrand);
            this.Controls.Add(this.lblPartName);
            this.Name = "PartsCard";
            this.Size = new System.Drawing.Size(273, 371);
            ((System.ComponentModel.ISupportInitialize)(this.imgPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPart;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Button btnseemore;
        private System.Windows.Forms.Button btnaddlist;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantityAvailable;
        private System.Windows.Forms.Label lblbrand;
        private System.Windows.Forms.Label lblPartName;
    }
}
