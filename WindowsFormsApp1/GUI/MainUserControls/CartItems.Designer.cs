namespace WindowsFormsApp1.GUI.MainUserControls
{
    partial class CartItems
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
            this.itemimg = new System.Windows.Forms.PictureBox();
            this.lblitemname = new System.Windows.Forms.Label();
            this.lblquntitty = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.btnremoveitem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemimg)).BeginInit();
            this.SuspendLayout();
            // 
            // itemimg
            // 
            this.itemimg.Location = new System.Drawing.Point(3, 3);
            this.itemimg.Name = "itemimg";
            this.itemimg.Size = new System.Drawing.Size(110, 61);
            this.itemimg.TabIndex = 0;
            this.itemimg.TabStop = false;
            // 
            // lblitemname
            // 
            this.lblitemname.AutoSize = true;
            this.lblitemname.Location = new System.Drawing.Point(125, 19);
            this.lblitemname.Name = "lblitemname";
            this.lblitemname.Size = new System.Drawing.Size(35, 13);
            this.lblitemname.TabIndex = 1;
            this.lblitemname.Text = "label1";
            // 
            // lblquntitty
            // 
            this.lblquntitty.AutoSize = true;
            this.lblquntitty.Location = new System.Drawing.Point(166, 29);
            this.lblquntitty.Name = "lblquntitty";
            this.lblquntitty.Size = new System.Drawing.Size(35, 13);
            this.lblquntitty.TabIndex = 3;
            this.lblquntitty.Text = "label1";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(125, 41);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(35, 13);
            this.lblprice.TabIndex = 4;
            this.lblprice.Text = "label1";
            // 
            // btnremoveitem
            // 
            this.btnremoveitem.Location = new System.Drawing.Point(224, 23);
            this.btnremoveitem.Name = "btnremoveitem";
            this.btnremoveitem.Size = new System.Drawing.Size(57, 25);
            this.btnremoveitem.TabIndex = 5;
            this.btnremoveitem.Text = "Remove";
            this.btnremoveitem.UseVisualStyleBackColor = true;
            // 
            // CartItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnremoveitem);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblquntitty);
            this.Controls.Add(this.lblitemname);
            this.Controls.Add(this.itemimg);
            this.Name = "CartItems";
            this.Size = new System.Drawing.Size(288, 67);
            ((System.ComponentModel.ISupportInitialize)(this.itemimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox itemimg;
        private System.Windows.Forms.Label lblitemname;
        private System.Windows.Forms.Label lblquntitty;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Button btnremoveitem;
    }
}
