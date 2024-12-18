namespace OrderMillTeaProgram.Giao_diện_của_User
{
    partial class DashboardAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardAdmin));
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sidebarclick = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.menuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTraSua = new System.Windows.Forms.Button();
            this.btnTrangMieng = new System.Windows.Forms.Button();
            this.btnAnVat = new System.Windows.Forms.Button();
            this.btnQLDT = new System.Windows.Forms.Button();
            this.btnQLTK = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnDonhang = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarclick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.btnDashboard);
            this.sidebar.Controls.Add(this.menuContainer);
            this.sidebar.Controls.Add(this.btnQLDT);
            this.sidebar.Controls.Add(this.btnQLTK);
            this.sidebar.Controls.Add(this.btnKho);
            this.sidebar.Controls.Add(this.btnDonhang);
            this.sidebar.Controls.Add(this.btnThongBao);
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(220, 1080);
            this.sidebar.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.sidebarclick);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 183);
            this.panel3.TabIndex = 0;
            // 
            // sidebarclick
            // 
            this.sidebarclick.Image = ((System.Drawing.Image)(resources.GetObject("sidebarclick.Image")));
            this.sidebarclick.Location = new System.Drawing.Point(3, 3);
            this.sidebarclick.Name = "sidebarclick";
            this.sidebarclick.Size = new System.Drawing.Size(37, 38);
            this.sidebarclick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidebarclick.TabIndex = 2;
            this.sidebarclick.TabStop = false;
            this.sidebarclick.Click += new System.EventHandler(this.sidebarclick_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(76, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(61, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(155, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 192);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(217, 46);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "      Bảng điều khiển";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuContainer.Controls.Add(this.btnDanhMuc);
            this.menuContainer.Controls.Add(this.btnTraSua);
            this.menuContainer.Controls.Add(this.btnTrangMieng);
            this.menuContainer.Controls.Add(this.btnAnVat);
            this.menuContainer.Location = new System.Drawing.Point(3, 244);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(217, 46);
            this.menuContainer.TabIndex = 6;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhMuc.Image")));
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(0);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(217, 46);
            this.btnDanhMuc.TabIndex = 2;
            this.btnDanhMuc.Text = "Danh Mục";
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTraSua
            // 
            this.btnTraSua.BackColor = System.Drawing.Color.LightGray;
            this.btnTraSua.FlatAppearance.BorderSize = 0;
            this.btnTraSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSua.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTraSua.Image = ((System.Drawing.Image)(resources.GetObject("btnTraSua.Image")));
            this.btnTraSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraSua.Location = new System.Drawing.Point(0, 46);
            this.btnTraSua.Margin = new System.Windows.Forms.Padding(0);
            this.btnTraSua.Name = "btnTraSua";
            this.btnTraSua.Size = new System.Drawing.Size(217, 46);
            this.btnTraSua.TabIndex = 3;
            this.btnTraSua.Text = "Trà Sữa";
            this.btnTraSua.UseVisualStyleBackColor = false;
            this.btnTraSua.Click += new System.EventHandler(this.btnTraSua_Click);
            // 
            // btnTrangMieng
            // 
            this.btnTrangMieng.BackColor = System.Drawing.Color.LightGray;
            this.btnTrangMieng.FlatAppearance.BorderSize = 0;
            this.btnTrangMieng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangMieng.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangMieng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTrangMieng.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangMieng.Image")));
            this.btnTrangMieng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangMieng.Location = new System.Drawing.Point(0, 92);
            this.btnTrangMieng.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrangMieng.Name = "btnTrangMieng";
            this.btnTrangMieng.Size = new System.Drawing.Size(217, 46);
            this.btnTrangMieng.TabIndex = 7;
            this.btnTrangMieng.Text = "Tráng Miệng";
            this.btnTrangMieng.UseVisualStyleBackColor = false;
            // 
            // btnAnVat
            // 
            this.btnAnVat.BackColor = System.Drawing.Color.LightGray;
            this.btnAnVat.FlatAppearance.BorderSize = 0;
            this.btnAnVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnVat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnAnVat.Image = ((System.Drawing.Image)(resources.GetObject("btnAnVat.Image")));
            this.btnAnVat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnVat.Location = new System.Drawing.Point(0, 138);
            this.btnAnVat.Margin = new System.Windows.Forms.Padding(0);
            this.btnAnVat.Name = "btnAnVat";
            this.btnAnVat.Size = new System.Drawing.Size(217, 46);
            this.btnAnVat.TabIndex = 8;
            this.btnAnVat.Text = "Ăn Vặt";
            this.btnAnVat.UseVisualStyleBackColor = false;
            // 
            // btnQLDT
            // 
            this.btnQLDT.FlatAppearance.BorderSize = 0;
            this.btnQLDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnQLDT.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDT.Image")));
            this.btnQLDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDT.Location = new System.Drawing.Point(0, 293);
            this.btnQLDT.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLDT.Name = "btnQLDT";
            this.btnQLDT.Size = new System.Drawing.Size(220, 46);
            this.btnQLDT.TabIndex = 7;
            this.btnQLDT.Text = "          Quản Lý Doanh Thu";
            this.btnQLDT.UseVisualStyleBackColor = true;
            // 
            // btnQLTK
            // 
            this.btnQLTK.FlatAppearance.BorderSize = 0;
            this.btnQLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnQLTK.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTK.Image")));
            this.btnQLTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTK.Location = new System.Drawing.Point(3, 342);
            this.btnQLTK.Name = "btnQLTK";
            this.btnQLTK.Size = new System.Drawing.Size(217, 46);
            this.btnQLTK.TabIndex = 8;
            this.btnQLTK.Text = "        Quản Lý Tài Khoản";
            this.btnQLTK.UseVisualStyleBackColor = true;
            this.btnQLTK.Click += new System.EventHandler(this.btnQLTK_Click);
            // 
            // btnKho
            // 
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnKho.Image = ((System.Drawing.Image)(resources.GetObject("btnKho.Image")));
            this.btnKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.Location = new System.Drawing.Point(3, 394);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(217, 46);
            this.btnKho.TabIndex = 9;
            this.btnKho.Text = "Kho";
            this.btnKho.UseVisualStyleBackColor = true;
            // 
            // btnDonhang
            // 
            this.btnDonhang.FlatAppearance.BorderSize = 0;
            this.btnDonhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonhang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonhang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDonhang.Image = ((System.Drawing.Image)(resources.GetObject("btnDonhang.Image")));
            this.btnDonhang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonhang.Location = new System.Drawing.Point(3, 446);
            this.btnDonhang.Name = "btnDonhang";
            this.btnDonhang.Size = new System.Drawing.Size(217, 46);
            this.btnDonhang.TabIndex = 10;
            this.btnDonhang.Text = "Đơn Hàng";
            this.btnDonhang.UseVisualStyleBackColor = true;
            // 
            // btnThongBao
            // 
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnThongBao.Image = ((System.Drawing.Image)(resources.GetObject("btnThongBao.Image")));
            this.btnThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongBao.Location = new System.Drawing.Point(3, 498);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(217, 46);
            this.btnThongBao.TabIndex = 11;
            this.btnThongBao.Text = "Thông Báo";
            this.btnThongBao.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 550);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(217, 46);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "     LogOut";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "DashboardAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardAdmin";
            this.sidebar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarclick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.FlowLayoutPanel menuContainer;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTraSua;
        private System.Windows.Forms.Button btnTrangMieng;
        private System.Windows.Forms.Button btnAnVat;
        private System.Windows.Forms.Button btnQLDT;
        private System.Windows.Forms.Button btnQLTK;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnDonhang;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox sidebarclick;
        private System.Windows.Forms.Timer sidebarTransition;
    }
}