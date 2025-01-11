using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    partial class QLTK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLTK));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.dgvQLTK = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtTimTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnDelete = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnRead = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cmbChucVu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTK)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.lblDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1680, 51);
            this.panel1.TabIndex = 3;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(12, 9);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(175, 25);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Quản Lý Tài Khoản";
            // 
            // dgvQLTK
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvQLTK.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQLTK.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQLTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQLTK.ColumnHeadersHeight = 30;
            this.dgvQLTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.hoTenDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.sDTDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4});
            this.dgvQLTK.DataSource = this.userInfoBindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQLTK.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQLTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQLTK.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQLTK.Location = new System.Drawing.Point(0, 103);
            this.dgvQLTK.Name = "dgvQLTK";
            this.dgvQLTK.ReadOnly = true;
            this.dgvQLTK.RowHeadersVisible = false;
            this.dgvQLTK.Size = new System.Drawing.Size(1680, 977);
            this.dgvQLTK.TabIndex = 0;
            this.dgvQLTK.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQLTK.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvQLTK.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvQLTK.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvQLTK.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvQLTK.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvQLTK.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQLTK.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvQLTK.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQLTK.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQLTK.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQLTK.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQLTK.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvQLTK.ThemeStyle.ReadOnly = true;
            this.dgvQLTK.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvQLTK.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQLTK.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQLTK.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQLTK.ThemeStyle.RowsStyle.Height = 22;
            this.dgvQLTK.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvQLTK.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvQLTK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQLTK_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.txtTimTen);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1680, 52);
            this.panel3.TabIndex = 7;
            // 
            // btnsearch
            // 
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.Location = new System.Drawing.Point(517, 4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(50, 44);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.UseVisualStyleBackColor = true;
            // 
            // txtTimTen
            // 
            this.txtTimTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimTen.DefaultText = "";
            this.txtTimTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimTen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTimTen.ForeColor = System.Drawing.Color.Black;
            this.txtTimTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimTen.Location = new System.Drawing.Point(5, 6);
            this.txtTimTen.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.PasswordChar = '\0';
            this.txtTimTen.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTimTen.PlaceholderText = "Tìm kiếm tên";
            this.txtTimTen.SelectedText = "";
            this.txtTimTen.Size = new System.Drawing.Size(504, 42);
            this.txtTimTen.TabIndex = 0;
            this.txtTimTen.TextChanged += new System.EventHandler(this.TxtTimTen_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.cmbChucVu);
            this.panel2.Controls.Add(this.btnRead);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtHoTen);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMatKhau);
            this.panel2.Controls.Add(this.txtTenTaiKhoan);
            this.panel2.Controls.Add(this.lblChucVu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 863);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1680, 217);
            this.panel2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1581, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 44);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1525, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 44);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Tài Khoản";
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenTaiKhoan.DefaultText = "";
            this.txtTenTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenTaiKhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenTaiKhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTaiKhoan.ForeColor = System.Drawing.Color.Black;
            this.txtTenTaiKhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(178, 17);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.PasswordChar = '\0';
            this.txtTenTaiKhoan.PlaceholderText = "";
            this.txtTenTaiKhoan.SelectedText = "";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(353, 41);
            this.txtTenTaiKhoan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1217, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(634, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ Tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(569, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số Điện Thoại";
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVu.Location = new System.Drawing.Point(1191, 84);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(89, 23);
            this.lblChucVu.TabIndex = 0;
            this.lblChucVu.Text = "Chức Vụ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTen.DefaultText = "";
            this.txtHoTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHoTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHoTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTen.Location = new System.Drawing.Point(718, 17);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PasswordChar = '\0';
            this.txtHoTen.PlaceholderText = "";
            this.txtHoTen.SelectedText = "";
            this.txtHoTen.Size = new System.Drawing.Size(353, 41);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(1286, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(353, 41);
            this.txtEmail.TabIndex = 3;
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Location = new System.Drawing.Point(718, 75);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PasswordChar = '\0';
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(353, 41);
            this.txtSDT.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(216)))), ((int)(((byte)(84)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(165, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAdd.Size = new System.Drawing.Size(104, 88);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(17)))), ((int)(((byte)(38)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1308, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDelete.Size = new System.Drawing.Size(104, 88);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(939, 126);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnUpdate.Size = new System.Drawing.Size(104, 88);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            // 
            // btnRead
            // 
            this.btnRead.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRead.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRead.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRead.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRead.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.btnRead.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnRead.ForeColor = System.Drawing.Color.White;
            this.btnRead.Location = new System.Drawing.Point(551, 126);
            this.btnRead.Name = "btnRead";
            this.btnRead.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnRead.Size = new System.Drawing.Size(104, 88);
            this.btnRead.TabIndex = 10;
            this.btnRead.Text = "Read";
            // 
            // cmbChucVu
            // 
            this.cmbChucVu.BackColor = System.Drawing.Color.Transparent;
            this.cmbChucVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChucVu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChucVu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChucVu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbChucVu.ItemHeight = 30;
            this.cmbChucVu.Items.AddRange(new object[] {
            "Người dùng",
            "Nhân Viên",
            "Quản Lý"});
            this.cmbChucVu.Location = new System.Drawing.Point(1286, 80);
            this.cmbChucVu.Name = "cmbChucVu";
            this.cmbChucVu.Size = new System.Drawing.Size(353, 36);
            this.cmbChucVu.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhau.DefaultText = "";
            this.txtMatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ForeColor = System.Drawing.Color.Black;
            this.txtMatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Location = new System.Drawing.Point(178, 66);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '\0';
            this.txtMatKhau.PlaceholderText = "";
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.Size = new System.Drawing.Size(353, 41);
            this.txtMatKhau.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // hoTenDataGridViewTextBoxColumn
            // 
            this.hoTenDataGridViewTextBoxColumn.DataPropertyName = "HoTen";
            this.hoTenDataGridViewTextBoxColumn.HeaderText = "Họ Tên";
            this.hoTenDataGridViewTextBoxColumn.Name = "hoTenDataGridViewTextBoxColumn";
            this.hoTenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn3.HeaderText = "Email";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // sDTDataGridViewTextBoxColumn
            // 
            this.sDTDataGridViewTextBoxColumn.DataPropertyName = "SDT";
            this.sDTDataGridViewTextBoxColumn.HeaderText = "Số Điện Thoại";
            this.sDTDataGridViewTextBoxColumn.Name = "sDTDataGridViewTextBoxColumn";
            this.sDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Role";
            this.dataGridViewTextBoxColumn4.HeaderText = "Chức Vụ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // userInfoBindingSource1
            // 
            this.userInfoBindingSource1.DataSource = typeof(OrderMillTeaProgram.Database.UserInfo);
            // 
            // userInfoBindingSource
            // 
            this.userInfoBindingSource.DataSource = typeof(OrderMillTeaProgram.Database.UserInfo);
            // 
            // QLTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 1080);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvQLTK);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLTK";
            this.ShowIcon = false;
            this.Text = "BangDieuKhien";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QLTK_FormClosed);
            this.Load += new System.EventHandler(this.QLTK_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTK)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        public override bool Equals(object obj)
        {
            return obj is QLTK qLTK &&
                   EqualityComparer<DataGridViewTextBoxColumn>.Default.Equals(userNameDataGridViewTextBoxColumn, qLTK.userNameDataGridViewTextBoxColumn);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDashboard;
        private Guna.UI2.WinForms.Guna2DataGridView dgvQLTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;

        public QLTK(DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn)
        {
            this.userNameDataGridViewTextBoxColumn = userNameDataGridViewTextBoxColumn;
        }

        public QLTK(IContainer components, Panel panel1, Label lblDashboard, Guna2DataGridView dgvQLTK, DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn, DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn, DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn, DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn, BindingSource userInfoBindingSource, Panel panel3, Panel panel2, Guna2TextBox txtTimTen, Button btnsearch, Button button2, Button button1, Label label1, Label label2, Label label3, Guna2TextBox txtTenTaiKhoan, Label lblChucVu, Label label4, Guna2TextBox txtSDT, Guna2TextBox txtEmail, Guna2TextBox txtHoTen, Guna2CircleButton btnAdd, Guna2CircleButton btnUpdate, Guna2CircleButton btnDelete, Guna2CircleButton btnRead, Guna2ComboBox cmbChucVu, Guna2TextBox txtMatKhau, Label label5, DataGridViewTextBoxColumn dataGridViewTextBoxColumn1, BindingSource userInfoBindingSource1, DataGridViewTextBoxColumn userName, DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn, DataGridViewTextBoxColumn dataGridViewTextBoxColumn3, DataGridViewTextBoxColumn sDTDataGridViewTextBoxColumn, DataGridViewTextBoxColumn dataGridViewTextBoxColumn4)
        {
            this.components = components;
            this.panel1 = panel1;
            this.lblDashboard = lblDashboard;
            this.dgvQLTK = dgvQLTK;
            this.userNameDataGridViewTextBoxColumn = userNameDataGridViewTextBoxColumn;
            this.passwordDataGridViewTextBoxColumn = passwordDataGridViewTextBoxColumn;
            this.emailDataGridViewTextBoxColumn = emailDataGridViewTextBoxColumn;
            this.roleDataGridViewTextBoxColumn = roleDataGridViewTextBoxColumn;
            this.userInfoBindingSource = userInfoBindingSource;
            this.panel3 = panel3;
            this.panel2 = panel2;
            this.txtTimTen = txtTimTen;
            this.btnsearch = btnsearch;
            this.button2 = button2;
            this.button1 = button1;
            this.label1 = label1;
            this.label2 = label2;
            this.label3 = label3;
            this.txtTenTaiKhoan = txtTenTaiKhoan;
            this.lblChucVu = lblChucVu;
            this.label4 = label4;
            this.txtSDT = txtSDT;
            this.txtEmail = txtEmail;
            this.txtHoTen = txtHoTen;
            this.btnAdd = btnAdd;
            this.btnUpdate = btnUpdate;
            this.btnDelete = btnDelete;
            this.btnRead = btnRead;
            this.cmbChucVu = cmbChucVu;
            this.txtMatKhau = txtMatKhau;
            this.label5 = label5;
            this.dataGridViewTextBoxColumn1 = dataGridViewTextBoxColumn1;
            this.userInfoBindingSource1 = userInfoBindingSource1;
            UserName = userName;
            this.hoTenDataGridViewTextBoxColumn = hoTenDataGridViewTextBoxColumn;
            this.dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn3;
            this.sDTDataGridViewTextBoxColumn = sDTDataGridViewTextBoxColumn;
            this.dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn4;
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userInfoBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtTimTen;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTenTaiKhoan;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private Guna.UI2.WinForms.Guna2CircleButton btnAdd;
        private Guna.UI2.WinForms.Guna2CircleButton btnUpdate;
        private Guna.UI2.WinForms.Guna2CircleButton btnDelete;
        private Guna.UI2.WinForms.Guna2CircleButton btnRead;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChucVu;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource userInfoBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        [System.Obsolete]
        public override int GetHashCode()
        {
            int hashCode = 991298384;
            hashCode = hashCode * -1521134295 + CanRaiseEvents.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<EventHandlerList>.Default.GetHashCode(Events);
            hashCode = hashCode * -1521134295 + EqualityComparer<ISite>.Default.GetHashCode(Site);
            hashCode = hashCode * -1521134295 + EqualityComparer<IContainer>.Default.GetHashCode(Container);
            hashCode = hashCode * -1521134295 + DesignMode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<AccessibleObject>.Default.GetHashCode(AccessibilityObject);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccessibleDefaultActionDescription);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccessibleDescription);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccessibleName);
            hashCode = hashCode * -1521134295 + AccessibleRole.GetHashCode();
            hashCode = hashCode * -1521134295 + AllowDrop.GetHashCode();
            hashCode = hashCode * -1521134295 + Anchor.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoSize.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScrollOffset.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<LayoutEngine>.Default.GetHashCode(LayoutEngine);
            hashCode = hashCode * -1521134295 + BackColor.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Image>.Default.GetHashCode(BackgroundImage);
            hashCode = hashCode * -1521134295 + BackgroundImageLayout.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<BindingContext>.Default.GetHashCode(BindingContext);
            hashCode = hashCode * -1521134295 + Bottom.GetHashCode();
            hashCode = hashCode * -1521134295 + Bounds.GetHashCode();
            hashCode = hashCode * -1521134295 + CanFocus.GetHashCode();
            hashCode = hashCode * -1521134295 + CanRaiseEvents.GetHashCode();
            hashCode = hashCode * -1521134295 + CanSelect.GetHashCode();
            hashCode = hashCode * -1521134295 + Capture.GetHashCode();
            hashCode = hashCode * -1521134295 + CausesValidation.GetHashCode();
            hashCode = hashCode * -1521134295 + ClientRectangle.GetHashCode();
            hashCode = hashCode * -1521134295 + ClientSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CompanyName);
            hashCode = hashCode * -1521134295 + ContainsFocus.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ContextMenu>.Default.GetHashCode(ContextMenu);
            hashCode = hashCode * -1521134295 + EqualityComparer<ContextMenuStrip>.Default.GetHashCode(ContextMenuStrip);
            hashCode = hashCode * -1521134295 + EqualityComparer<Control.ControlCollection>.Default.GetHashCode(Controls);
            hashCode = hashCode * -1521134295 + Created.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CreateParams>.Default.GetHashCode(CreateParams);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cursor>.Default.GetHashCode(Cursor);
            hashCode = hashCode * -1521134295 + EqualityComparer<ControlBindingsCollection>.Default.GetHashCode(DataBindings);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cursor>.Default.GetHashCode(DefaultCursor);
            hashCode = hashCode * -1521134295 + DefaultMargin.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultMaximumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultMinimumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultPadding.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultSize.GetHashCode();
            hashCode = hashCode * -1521134295 + DeviceDpi.GetHashCode();
            hashCode = hashCode * -1521134295 + DisplayRectangle.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDisposed.GetHashCode();
            hashCode = hashCode * -1521134295 + Disposing.GetHashCode();
            hashCode = hashCode * -1521134295 + Dock.GetHashCode();
            hashCode = hashCode * -1521134295 + DoubleBuffered.GetHashCode();
            hashCode = hashCode * -1521134295 + Enabled.GetHashCode();
            hashCode = hashCode * -1521134295 + Focused.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Font>.Default.GetHashCode(Font);
            hashCode = hashCode * -1521134295 + FontHeight.GetHashCode();
            hashCode = hashCode * -1521134295 + ForeColor.GetHashCode();
            hashCode = hashCode * -1521134295 + Handle.GetHashCode();
            hashCode = hashCode * -1521134295 + HasChildren.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + IsHandleCreated.GetHashCode();
            hashCode = hashCode * -1521134295 + InvokeRequired.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAccessible.GetHashCode();
            hashCode = hashCode * -1521134295 + IsMirrored.GetHashCode();
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Location.GetHashCode();
            hashCode = hashCode * -1521134295 + Margin.GetHashCode();
            hashCode = hashCode * -1521134295 + MaximumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + MinimumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Control>.Default.GetHashCode(Parent);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductVersion);
            hashCode = hashCode * -1521134295 + RecreatingHandle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Region>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + RenderRightToLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + ResizeRedraw.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + RightToLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + ScaleChildren.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ISite>.Default.GetHashCode(Site);
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + TabIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + TabStop.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Tag);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + Top.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Control>.Default.GetHashCode(TopLevelControl);
            hashCode = hashCode * -1521134295 + ShowKeyboardCues.GetHashCode();
            hashCode = hashCode * -1521134295 + ShowFocusCues.GetHashCode();
            hashCode = hashCode * -1521134295 + UseWaitCursor.GetHashCode();
            hashCode = hashCode * -1521134295 + Visible.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindowTarget>.Default.GetHashCode(WindowTarget);
            hashCode = hashCode * -1521134295 + PreferredSize.GetHashCode();
            hashCode = hashCode * -1521134295 + Padding.GetHashCode();
            hashCode = hashCode * -1521134295 + CanEnableIme.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultImeMode.GetHashCode();
            hashCode = hashCode * -1521134295 + ImeMode.GetHashCode();
            hashCode = hashCode * -1521134295 + ImeModeBase.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScroll.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScrollMargin.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScrollPosition.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScrollMinSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CreateParams>.Default.GetHashCode(CreateParams);
            hashCode = hashCode * -1521134295 + DisplayRectangle.GetHashCode();
            hashCode = hashCode * -1521134295 + HScroll.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<HScrollProperties>.Default.GetHashCode(HorizontalScroll);
            hashCode = hashCode * -1521134295 + VScroll.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<VScrollProperties>.Default.GetHashCode(VerticalScroll);
            hashCode = hashCode * -1521134295 + EqualityComparer<DockPaddingEdges>.Default.GetHashCode(DockPadding);
            hashCode = hashCode * -1521134295 + AutoScaleDimensions.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScaleFactor.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScaleMode.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoValidate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<BindingContext>.Default.GetHashCode(BindingContext);
            hashCode = hashCode * -1521134295 + CanEnableIme.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Control>.Default.GetHashCode(ActiveControl);
            hashCode = hashCode * -1521134295 + EqualityComparer<CreateParams>.Default.GetHashCode(CreateParams);
            hashCode = hashCode * -1521134295 + CurrentAutoScaleDimensions.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Form>.Default.GetHashCode(ParentForm);
            hashCode = hashCode * -1521134295 + EqualityComparer<IButtonControl>.Default.GetHashCode(AcceptButton);
            hashCode = hashCode * -1521134295 + EqualityComparer<Form>.Default.GetHashCode(ActiveMdiChild);
            hashCode = hashCode * -1521134295 + AllowTransparency.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScale.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScaleBaseSize.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoScroll.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoSize.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoSizeMode.GetHashCode();
            hashCode = hashCode * -1521134295 + AutoValidate.GetHashCode();
            hashCode = hashCode * -1521134295 + BackColor.GetHashCode();
            hashCode = hashCode * -1521134295 + FormBorderStyle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IButtonControl>.Default.GetHashCode(CancelButton);
            hashCode = hashCode * -1521134295 + ClientSize.GetHashCode();
            hashCode = hashCode * -1521134295 + ControlBox.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<CreateParams>.Default.GetHashCode(CreateParams);
            hashCode = hashCode * -1521134295 + DefaultImeMode.GetHashCode();
            hashCode = hashCode * -1521134295 + DefaultSize.GetHashCode();
            hashCode = hashCode * -1521134295 + DesktopBounds.GetHashCode();
            hashCode = hashCode * -1521134295 + DesktopLocation.GetHashCode();
            hashCode = hashCode * -1521134295 + DialogResult.GetHashCode();
            hashCode = hashCode * -1521134295 + HelpButton.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Icon>.Default.GetHashCode(Icon);
            hashCode = hashCode * -1521134295 + IsMdiChild.GetHashCode();
            hashCode = hashCode * -1521134295 + IsMdiContainer.GetHashCode();
            hashCode = hashCode * -1521134295 + IsRestrictedWindow.GetHashCode();
            hashCode = hashCode * -1521134295 + KeyPreview.GetHashCode();
            hashCode = hashCode * -1521134295 + Location.GetHashCode();
            hashCode = hashCode * -1521134295 + MaximizedBounds.GetHashCode();
            hashCode = hashCode * -1521134295 + MaximumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<MenuStrip>.Default.GetHashCode(MainMenuStrip);
            hashCode = hashCode * -1521134295 + Margin.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<MainMenu>.Default.GetHashCode(Menu);
            hashCode = hashCode * -1521134295 + MinimumSize.GetHashCode();
            hashCode = hashCode * -1521134295 + MaximizeBox.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Form[]>.Default.GetHashCode(MdiChildren);
            hashCode = hashCode * -1521134295 + EqualityComparer<Form>.Default.GetHashCode(MdiParent);
            hashCode = hashCode * -1521134295 + EqualityComparer<MainMenu>.Default.GetHashCode(MergedMenu);
            hashCode = hashCode * -1521134295 + MinimizeBox.GetHashCode();
            hashCode = hashCode * -1521134295 + Modal.GetHashCode();
            hashCode = hashCode * -1521134295 + Opacity.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Form[]>.Default.GetHashCode(OwnedForms);
            hashCode = hashCode * -1521134295 + EqualityComparer<Form>.Default.GetHashCode(Owner);
            hashCode = hashCode * -1521134295 + RestoreBounds.GetHashCode();
            hashCode = hashCode * -1521134295 + RightToLeftLayout.GetHashCode();
            hashCode = hashCode * -1521134295 + ShowInTaskbar.GetHashCode();
            hashCode = hashCode * -1521134295 + ShowIcon.GetHashCode();
            hashCode = hashCode * -1521134295 + ShowWithoutActivation.GetHashCode();
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + SizeGripStyle.GetHashCode();
            hashCode = hashCode * -1521134295 + StartPosition.GetHashCode();
            hashCode = hashCode * -1521134295 + TabIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + TabStop.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + TopLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + TopMost.GetHashCode();
            hashCode = hashCode * -1521134295 + TransparencyKey.GetHashCode();
            hashCode = hashCode * -1521134295 + WindowState.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IContainer>.Default.GetHashCode(components);
            hashCode = hashCode * -1521134295 + EqualityComparer<Panel>.Default.GetHashCode(panel1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(lblDashboard);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2DataGridView>.Default.GetHashCode(dgvQLTK);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(userNameDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(passwordDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(emailDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(roleDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<BindingSource>.Default.GetHashCode(userInfoBindingSource);
            hashCode = hashCode * -1521134295 + EqualityComparer<Panel>.Default.GetHashCode(panel3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Panel>.Default.GetHashCode(panel2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtTimTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<Button>.Default.GetHashCode(btnsearch);
            hashCode = hashCode * -1521134295 + EqualityComparer<Button>.Default.GetHashCode(button2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Button>.Default.GetHashCode(button1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(label1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(label2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(label3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtTenTaiKhoan);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(lblChucVu);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(label4);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtSDT);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtEmail);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtHoTen);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2CircleButton>.Default.GetHashCode(btnAdd);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2CircleButton>.Default.GetHashCode(btnUpdate);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2CircleButton>.Default.GetHashCode(btnDelete);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2CircleButton>.Default.GetHashCode(btnRead);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2ComboBox>.Default.GetHashCode(cmbChucVu);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guna2TextBox>.Default.GetHashCode(txtMatKhau);
            hashCode = hashCode * -1521134295 + EqualityComparer<Label>.Default.GetHashCode(label5);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(dataGridViewTextBoxColumn1);
            hashCode = hashCode * -1521134295 + EqualityComparer<BindingSource>.Default.GetHashCode(userInfoBindingSource1);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(hoTenDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(dataGridViewTextBoxColumn3);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(sDTDataGridViewTextBoxColumn);
            hashCode = hashCode * -1521134295 + EqualityComparer<DataGridViewTextBoxColumn>.Default.GetHashCode(dataGridViewTextBoxColumn4);
            return hashCode;
        }
    }
}