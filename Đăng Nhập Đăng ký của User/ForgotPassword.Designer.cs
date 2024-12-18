namespace OrderMillTeaProgram
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            this.frmForgotPass = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEmailDaDangKy = new System.Windows.Forms.Label();
            this.btnTieptuc = new Guna.UI2.WinForms.Guna2Button();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTextLogo = new System.Windows.Forms.Label();
            this.logobox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            this.frmForgotPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).BeginInit();
            this.SuspendLayout();
            // 
            // frmForgotPass
            // 
            this.frmForgotPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.frmForgotPass.BackColor = System.Drawing.Color.White;
            this.frmForgotPass.Controls.Add(this.lblEmailDaDangKy);
            this.frmForgotPass.Controls.Add(this.btnTieptuc);
            this.frmForgotPass.Controls.Add(this.txtEmail);
            this.frmForgotPass.Controls.Add(this.lblEmail);
            this.frmForgotPass.Controls.Add(this.lblTextLogo);
            this.frmForgotPass.Controls.Add(this.logobox);
            this.frmForgotPass.Controls.Add(this.btnExit);
            this.frmForgotPass.Location = new System.Drawing.Point(507, -2);
            this.frmForgotPass.Name = "frmForgotPass";
            this.frmForgotPass.Size = new System.Drawing.Size(926, 1564);
            this.frmForgotPass.TabIndex = 0;
            // 
            // lblEmailDaDangKy
            // 
            this.lblEmailDaDangKy.AutoSize = true;
            this.lblEmailDaDangKy.BackColor = System.Drawing.Color.White;
            this.lblEmailDaDangKy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailDaDangKy.ForeColor = System.Drawing.Color.White;
            this.lblEmailDaDangKy.Location = new System.Drawing.Point(204, 300);
            this.lblEmailDaDangKy.Name = "lblEmailDaDangKy";
            this.lblEmailDaDangKy.Size = new System.Drawing.Size(110, 14);
            this.lblEmailDaDangKy.TabIndex = 6;
            this.lblEmailDaDangKy.Text = "Email không hợp lệ";
            // 
            // btnTieptuc
            // 
            this.btnTieptuc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTieptuc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTieptuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTieptuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTieptuc.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTieptuc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTieptuc.ForeColor = System.Drawing.Color.White;
            this.btnTieptuc.Location = new System.Drawing.Point(205, 317);
            this.btnTieptuc.Name = "btnTieptuc";
            this.btnTieptuc.Size = new System.Drawing.Size(430, 45);
            this.btnTieptuc.TabIndex = 5;
            this.btnTieptuc.Text = "Tiếp tục";
            this.btnTieptuc.Click += new System.EventHandler(this.btnTieptuc_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderThickness = 2;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(205, 258);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Nhập email ";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(430, 39);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(203, 239);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 16);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // lblTextLogo
            // 
            this.lblTextLogo.AutoSize = true;
            this.lblTextLogo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextLogo.Location = new System.Drawing.Point(201, 154);
            this.lblTextLogo.Name = "lblTextLogo";
            this.lblTextLogo.Size = new System.Drawing.Size(308, 32);
            this.lblTextLogo.TabIndex = 2;
            this.lblTextLogo.Text = "Cập nhật mật khẩu mới";
            // 
            // logobox
            // 
            this.logobox.FillColor = System.Drawing.Color.Transparent;
            this.logobox.Image = ((System.Drawing.Image)(resources.GetObject("logobox.Image")));
            this.logobox.ImageRotate = 0F;
            this.logobox.Location = new System.Drawing.Point(175, 52);
            this.logobox.Name = "logobox";
            this.logobox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.logobox.Size = new System.Drawing.Size(132, 119);
            this.logobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logobox.TabIndex = 1;
            this.logobox.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(899, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnExit.Size = new System.Drawing.Size(24, 31);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseTransparentBackground = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1556, 769);
            this.Controls.Add(this.frmForgotPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmForgotPass.ResumeLayout(false);
            this.frmForgotPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel frmForgotPass;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private Guna.UI2.WinForms.Guna2CirclePictureBox logobox;
        private System.Windows.Forms.Label lblTextLogo;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2Button btnTieptuc;
        private System.Windows.Forms.Label lblEmailDaDangKy;
    }
}

