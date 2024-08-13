namespace WindowsFormsApp1.GUI.SingleForms
{
    partial class SingleParts
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
            this.btnbackhome = new System.Windows.Forms.Button();
            this.btnbuynow = new System.Windows.Forms.Button();
            this.btnaddtolist = new System.Windows.Forms.Button();
            this.lblquntitty = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcarpartdiscription = new System.Windows.Forms.Label();
            this.lblbrandname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imgcarpart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgcarpart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbackhome
            // 
            this.btnbackhome.Location = new System.Drawing.Point(625, 438);
            this.btnbackhome.Name = "btnbackhome";
            this.btnbackhome.Size = new System.Drawing.Size(366, 42);
            this.btnbackhome.TabIndex = 48;
            this.btnbackhome.Text = "Close & Go Back";
            this.btnbackhome.UseVisualStyleBackColor = true;
            this.btnbackhome.Click += new System.EventHandler(this.btnbackhome_Click);
            // 
            // btnbuynow
            // 
            this.btnbuynow.Location = new System.Drawing.Point(811, 385);
            this.btnbuynow.Name = "btnbuynow";
            this.btnbuynow.Size = new System.Drawing.Size(180, 47);
            this.btnbuynow.TabIndex = 47;
            this.btnbuynow.Text = "Buy Now";
            this.btnbuynow.UseVisualStyleBackColor = true;
            // 
            // btnaddtolist
            // 
            this.btnaddtolist.Location = new System.Drawing.Point(625, 385);
            this.btnaddtolist.Name = "btnaddtolist";
            this.btnaddtolist.Size = new System.Drawing.Size(180, 47);
            this.btnaddtolist.TabIndex = 46;
            this.btnaddtolist.Text = "Add to List";
            this.btnaddtolist.UseVisualStyleBackColor = true;
            this.btnaddtolist.Click += new System.EventHandler(this.btnaddtolist_Click);
            // 
            // lblquntitty
            // 
            this.lblquntitty.AutoSize = true;
            this.lblquntitty.Location = new System.Drawing.Point(721, 231);
            this.lblquntitty.Name = "lblquntitty";
            this.lblquntitty.Size = new System.Drawing.Size(89, 13);
            this.lblquntitty.TabIndex = 45;
            this.lblquntitty.Text = "QuantityAvailable";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(668, 202);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(31, 13);
            this.lblprice.TabIndex = 44;
            this.lblprice.Text = "Price";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(670, 176);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(34, 13);
            this.lblname.TabIndex = 42;
            this.lblname.Text = "Make";
            // 
            // lblcarpartdiscription
            // 
            this.lblcarpartdiscription.AutoSize = true;
            this.lblcarpartdiscription.Location = new System.Drawing.Point(690, 263);
            this.lblcarpartdiscription.Name = "lblcarpartdiscription";
            this.lblcarpartdiscription.Size = new System.Drawing.Size(36, 13);
            this.lblcarpartdiscription.TabIndex = 41;
            this.lblcarpartdiscription.Text = "Model";
            this.lblcarpartdiscription.Click += new System.EventHandler(this.lblmodelname_Click);
            // 
            // lblbrandname
            // 
            this.lblbrandname.AutoSize = true;
            this.lblbrandname.Location = new System.Drawing.Point(668, 149);
            this.lblbrandname.Name = "lblbrandname";
            this.lblbrandname.Size = new System.Drawing.Size(35, 13);
            this.lblbrandname.TabIndex = 40;
            this.lblbrandname.Text = "Brand";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(623, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "QuantityAvailable:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(623, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(623, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Discription:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Brand:";
            // 
            // imgcarpart
            // 
            this.imgcarpart.Location = new System.Drawing.Point(25, 74);
            this.imgcarpart.Name = "imgcarpart";
            this.imgcarpart.Size = new System.Drawing.Size(556, 450);
            this.imgcarpart.TabIndex = 33;
            this.imgcarpart.TabStop = false;
            // 
            // SingleParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 599);
            this.Controls.Add(this.btnbackhome);
            this.Controls.Add(this.btnbuynow);
            this.Controls.Add(this.btnaddtolist);
            this.Controls.Add(this.lblquntitty);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblcarpartdiscription);
            this.Controls.Add(this.lblbrandname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgcarpart);
            this.Name = "SingleParts";
            this.Text = "SingleParts";
            ((System.ComponentModel.ISupportInitialize)(this.imgcarpart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbackhome;
        private System.Windows.Forms.Button btnbuynow;
        private System.Windows.Forms.Button btnaddtolist;
        private System.Windows.Forms.Label lblquntitty;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblcarpartdiscription;
        private System.Windows.Forms.Label lblbrandname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgcarpart;
    }
}