namespace WindowsFormsApp1
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpwd = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnregister = new System.Windows.Forms.Button();
            this.imgfixed = new System.Windows.Forms.PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgfixed)).BeginInit();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(95, 254);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(343, 33);
            this.txtusername.TabIndex = 0;
            this.txtusername.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(95, 330);
            this.txtpwd.Multiline = true;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(343, 33);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(92, 229);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(63, 13);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "User Name ";
            // 
            // lblpwd
            // 
            this.lblpwd.AutoSize = true;
            this.lblpwd.Location = new System.Drawing.Point(95, 311);
            this.lblpwd.Name = "lblpwd";
            this.lblpwd.Size = new System.Drawing.Size(53, 13);
            this.lblpwd.TabIndex = 3;
            this.lblpwd.Text = "Password";
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(95, 399);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(167, 41);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Login Now";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnregister
            // 
            this.btnregister.Location = new System.Drawing.Point(271, 399);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(167, 41);
            this.btnregister.TabIndex = 5;
            this.btnregister.Text = "Register";
            this.btnregister.UseVisualStyleBackColor = true;
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // imgfixed
            // 
            this.imgfixed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgfixed.Image = ((System.Drawing.Image)(resources.GetObject("imgfixed.Image")));
            this.imgfixed.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgfixed.InitialImage")));
            this.imgfixed.Location = new System.Drawing.Point(140, 33);
            this.imgfixed.Name = "imgfixed";
            this.imgfixed.Size = new System.Drawing.Size(272, 171);
            this.imgfixed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgfixed.TabIndex = 6;
            this.imgfixed.TabStop = false;
            this.imgfixed.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(192, 465);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "guna2Button1";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 522);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.imgfixed);
            this.Controls.Add(this.btnregister);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.lblpwd);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtusername);
            this.Name = "login";
            this.RightToLeftLayout = true;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgfixed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpwd;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnregister;
        private System.Windows.Forms.PictureBox imgfixed;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}

