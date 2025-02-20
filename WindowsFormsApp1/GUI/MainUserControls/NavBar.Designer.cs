﻿namespace WindowsFormsApp1.MainUserControls
{
    partial class NavBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavBar));
            this.lblloggedusername = new System.Windows.Forms.Label();
            this.lblcartitemcount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picboxcart = new System.Windows.Forms.PictureBox();
            this.imguserimg = new System.Windows.Forms.PictureBox();
            this.lblhome = new System.Windows.Forms.Label();
            this.lblsettings = new System.Windows.Forms.Label();
            this.lblorders = new System.Windows.Forms.Label();
            this.btnloginlogout = new System.Windows.Forms.Button();
            this.lblCartdisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxcart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imguserimg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblloggedusername
            // 
            this.lblloggedusername.AutoSize = true;
            this.lblloggedusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloggedusername.Location = new System.Drawing.Point(863, 17);
            this.lblloggedusername.Name = "lblloggedusername";
            this.lblloggedusername.Size = new System.Drawing.Size(76, 16);
            this.lblloggedusername.TabIndex = 1;
            this.lblloggedusername.Text = "User Name";
            // 
            // lblcartitemcount
            // 
            this.lblcartitemcount.AutoSize = true;
            this.lblcartitemcount.Location = new System.Drawing.Point(1083, 3);
            this.lblcartitemcount.Name = "lblcartitemcount";
            this.lblcartitemcount.Size = new System.Drawing.Size(13, 13);
            this.lblcartitemcount.TabIndex = 4;
            this.lblcartitemcount.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Group_18__2_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 40);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // picboxcart
            // 
            this.picboxcart.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._9111199_cart_icon;
            this.picboxcart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picboxcart.Location = new System.Drawing.Point(1057, 8);
            this.picboxcart.Name = "picboxcart";
            this.picboxcart.Size = new System.Drawing.Size(33, 32);
            this.picboxcart.TabIndex = 3;
            this.picboxcart.TabStop = false;
            // 
            // imguserimg
            // 
            this.imguserimg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imguserimg.BackgroundImage")));
            this.imguserimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imguserimg.ImageLocation = "";
            this.imguserimg.InitialImage = ((System.Drawing.Image)(resources.GetObject("imguserimg.InitialImage")));
            this.imguserimg.Location = new System.Drawing.Point(1118, 3);
            this.imguserimg.Name = "imguserimg";
            this.imguserimg.Size = new System.Drawing.Size(40, 40);
            this.imguserimg.TabIndex = 0;
            this.imguserimg.TabStop = false;
            // 
            // lblhome
            // 
            this.lblhome.AutoSize = true;
            this.lblhome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhome.Location = new System.Drawing.Point(310, 15);
            this.lblhome.Name = "lblhome";
            this.lblhome.Size = new System.Drawing.Size(49, 18);
            this.lblhome.TabIndex = 6;
            this.lblhome.Text = "Home";
            // 
            // lblsettings
            // 
            this.lblsettings.AutoSize = true;
            this.lblsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsettings.Location = new System.Drawing.Point(420, 15);
            this.lblsettings.Name = "lblsettings";
            this.lblsettings.Size = new System.Drawing.Size(61, 18);
            this.lblsettings.TabIndex = 7;
            this.lblsettings.Text = "Settings";
            // 
            // lblorders
            // 
            this.lblorders.AutoSize = true;
            this.lblorders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblorders.Location = new System.Drawing.Point(516, 15);
            this.lblorders.Name = "lblorders";
            this.lblorders.Size = new System.Drawing.Size(54, 18);
            this.lblorders.TabIndex = 9;
            this.lblorders.Text = "Orders";
            // 
            // btnloginlogout
            // 
            this.btnloginlogout.Location = new System.Drawing.Point(735, 14);
            this.btnloginlogout.Name = "btnloginlogout";
            this.btnloginlogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnloginlogout.Size = new System.Drawing.Size(112, 23);
            this.btnloginlogout.TabIndex = 11;
            this.btnloginlogout.UseVisualStyleBackColor = true;
            this.btnloginlogout.Click += new System.EventHandler(this.btnloginlogout_Click);
            // 
            // lblCartdisplay
            // 
            this.lblCartdisplay.AutoSize = true;
            this.lblCartdisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartdisplay.Location = new System.Drawing.Point(608, 15);
            this.lblCartdisplay.Name = "lblCartdisplay";
            this.lblCartdisplay.Size = new System.Drawing.Size(56, 18);
            this.lblCartdisplay.TabIndex = 12;
            this.lblCartdisplay.Text = "MyCart";
            this.lblCartdisplay.Click += new System.EventHandler(this.lblCartdisplay_Click);
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCartdisplay);
            this.Controls.Add(this.btnloginlogout);
            this.Controls.Add(this.lblorders);
            this.Controls.Add(this.lblsettings);
            this.Controls.Add(this.lblhome);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblcartitemcount);
            this.Controls.Add(this.picboxcart);
            this.Controls.Add(this.lblloggedusername);
            this.Controls.Add(this.imguserimg);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(1158, 46);
            this.Load += new System.EventHandler(this.NavBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxcart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imguserimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imguserimg;
        private System.Windows.Forms.Label lblloggedusername;
        private System.Windows.Forms.PictureBox picboxcart;
        private System.Windows.Forms.Label lblcartitemcount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblhome;
        private System.Windows.Forms.Label lblsettings;
        private System.Windows.Forms.Label lblorders;
        private System.Windows.Forms.Button btnloginlogout;
        private System.Windows.Forms.Label lblCartdisplay;
    }
}
