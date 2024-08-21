namespace WindowsFormsApp1.GUI.MainUserControls
{
    partial class AdminNavBar
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
            this.lblreports = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblmanageorders = new System.Windows.Forms.Label();
            this.lblmanageusers = new System.Windows.Forms.Label();
            this.lblmanageproducts = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAdminUsername = new System.Windows.Forms.Label();
            this.lblAdminRole = new System.Windows.Forms.Label();
            this.lblmanagebrands = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblreports
            // 
            this.lblreports.AutoSize = true;
            this.lblreports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreports.Location = new System.Drawing.Point(779, 19);
            this.lblreports.Name = "lblreports";
            this.lblreports.Size = new System.Drawing.Size(61, 18);
            this.lblreports.TabIndex = 21;
            this.lblreports.Text = "Reports";
            this.lblreports.Click += new System.EventHandler(this.lblreports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(865, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLogout.Size = new System.Drawing.Size(112, 23);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblmanageorders
            // 
            this.lblmanageorders.AutoSize = true;
            this.lblmanageorders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanageorders.Location = new System.Drawing.Point(488, 19);
            this.lblmanageorders.Name = "lblmanageorders";
            this.lblmanageorders.Size = new System.Drawing.Size(111, 18);
            this.lblmanageorders.TabIndex = 19;
            this.lblmanageorders.Text = "Manage Orders";
            this.lblmanageorders.Click += new System.EventHandler(this.lblmanageorders_Click);
            // 
            // lblmanageusers
            // 
            this.lblmanageusers.AutoSize = true;
            this.lblmanageusers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanageusers.Location = new System.Drawing.Point(363, 19);
            this.lblmanageusers.Name = "lblmanageusers";
            this.lblmanageusers.Size = new System.Drawing.Size(105, 18);
            this.lblmanageusers.TabIndex = 18;
            this.lblmanageusers.Text = "Manage Users";
            this.lblmanageusers.Click += new System.EventHandler(this.lblmanageusers_Click);
            // 
            // lblmanageproducts
            // 
            this.lblmanageproducts.AutoSize = true;
            this.lblmanageproducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanageproducts.Location = new System.Drawing.Point(207, 17);
            this.lblmanageproducts.Name = "lblmanageproducts";
            this.lblmanageproducts.Size = new System.Drawing.Size(125, 18);
            this.lblmanageproducts.TabIndex = 17;
            this.lblmanageproducts.Text = "Manage Products";
            this.lblmanageproducts.Click += new System.EventHandler(this.lblmanageproducts_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Group_18__2_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(31, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 40);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblAdminUsername
            // 
            this.lblAdminUsername.AutoSize = true;
            this.lblAdminUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUsername.Location = new System.Drawing.Point(996, 19);
            this.lblAdminUsername.Name = "lblAdminUsername";
            this.lblAdminUsername.Size = new System.Drawing.Size(76, 16);
            this.lblAdminUsername.TabIndex = 13;
            this.lblAdminUsername.Text = "User Name";
            // 
            // lblAdminRole
            // 
            this.lblAdminRole.AutoSize = true;
            this.lblAdminRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRole.Location = new System.Drawing.Point(1104, 19);
            this.lblAdminRole.Name = "lblAdminRole";
            this.lblAdminRole.Size = new System.Drawing.Size(36, 16);
            this.lblAdminRole.TabIndex = 22;
            this.lblAdminRole.Text = "Role";
            // 
            // lblmanagebrands
            // 
            this.lblmanagebrands.AutoSize = true;
            this.lblmanagebrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanagebrands.Location = new System.Drawing.Point(634, 19);
            this.lblmanagebrands.Name = "lblmanagebrands";
            this.lblmanagebrands.Size = new System.Drawing.Size(112, 18);
            this.lblmanagebrands.TabIndex = 23;
            this.lblmanagebrands.Text = "Manage Brands";
            this.lblmanagebrands.Click += new System.EventHandler(this.lblmanagebrands_Click);
            // 
            // AdminNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblmanagebrands);
            this.Controls.Add(this.lblAdminRole);
            this.Controls.Add(this.lblreports);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblmanageorders);
            this.Controls.Add(this.lblmanageusers);
            this.Controls.Add(this.lblmanageproducts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAdminUsername);
            this.Name = "AdminNavBar";
            this.Size = new System.Drawing.Size(1158, 46);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblreports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblmanageorders;
        private System.Windows.Forms.Label lblmanageusers;
        private System.Windows.Forms.Label lblmanageproducts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAdminUsername;
        private System.Windows.Forms.Label lblAdminRole;
        private System.Windows.Forms.Label lblmanagebrands;
    }
}
