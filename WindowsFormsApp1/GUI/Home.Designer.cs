namespace WindowsFormsApp1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.flpproducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flpbrands = new System.Windows.Forms.FlowLayoutPanel();
            this.btnfiltercars = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btncarparts = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnall = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // flpproducts
            // 
            this.flpproducts.AutoScroll = true;
            this.flpproducts.Location = new System.Drawing.Point(49, 207);
            this.flpproducts.Name = "flpproducts";
            this.flpproducts.Size = new System.Drawing.Size(1163, 472);
            this.flpproducts.TabIndex = 0;
            this.flpproducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flpproducts_Paint_1);
            // 
            // flpbrands
            // 
            this.flpbrands.AutoScroll = true;
            this.flpbrands.Location = new System.Drawing.Point(49, 148);
            this.flpbrands.Name = "flpbrands";
            this.flpbrands.Size = new System.Drawing.Size(1163, 53);
            this.flpbrands.TabIndex = 2;
            this.flpbrands.Paint += new System.Windows.Forms.PaintEventHandler(this.flpbrands_Paint);
            // 
            // btnfiltercars
            // 
            this.btnfiltercars.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnfiltercars.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnfiltercars.Image = ((System.Drawing.Image)(resources.GetObject("btnfiltercars.Image")));
            this.btnfiltercars.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnfiltercars.ImageRotate = 0F;
            this.btnfiltercars.Location = new System.Drawing.Point(413, 72);
            this.btnfiltercars.Name = "btnfiltercars";
            this.btnfiltercars.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnfiltercars.Size = new System.Drawing.Size(143, 57);
            this.btnfiltercars.TabIndex = 3;
            this.btnfiltercars.Click += new System.EventHandler(this.btnfiltercars_Click_1);
            // 
            // btncarparts
            // 
            this.btncarparts.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btncarparts.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btncarparts.Image = ((System.Drawing.Image)(resources.GetObject("btncarparts.Image")));
            this.btncarparts.ImageOffset = new System.Drawing.Point(0, 0);
            this.btncarparts.ImageRotate = 0F;
            this.btncarparts.Location = new System.Drawing.Point(562, 72);
            this.btncarparts.Name = "btncarparts";
            this.btncarparts.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btncarparts.Size = new System.Drawing.Size(143, 57);
            this.btncarparts.TabIndex = 4;
            this.btncarparts.Click += new System.EventHandler(this.btncarparts_Click_1);
            // 
            // btnall
            // 
            this.btnall.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnall.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnall.Image = ((System.Drawing.Image)(resources.GetObject("btnall.Image")));
            this.btnall.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnall.ImageRotate = 0F;
            this.btnall.Location = new System.Drawing.Point(711, 72);
            this.btnall.Name = "btnall";
            this.btnall.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnall.Size = new System.Drawing.Size(143, 57);
            this.btnall.TabIndex = 5;
            this.btnall.Click += new System.EventHandler(this.btnall_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 691);
            this.Controls.Add(this.btnall);
            this.Controls.Add(this.btncarparts);
            this.Controls.Add(this.btnfiltercars);
            this.Controls.Add(this.flpbrands);
            this.Controls.Add(this.flpproducts);
            this.Name = "Home";
            this.Text = "A";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpproducts;
        private System.Windows.Forms.FlowLayoutPanel flpbrands;
        private Guna.UI2.WinForms.Guna2ImageButton btnfiltercars;
        private Guna.UI2.WinForms.Guna2ImageButton btncarparts;
        private Guna.UI2.WinForms.Guna2ImageButton btnall;
    }
}