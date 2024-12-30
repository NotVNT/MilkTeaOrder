namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS
{
    partial class TraDaoCamSa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraDaoCamSa));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbBasePrice = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddGioHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDatMon = new System.Windows.Forms.Button();
            this.clbDa = new System.Windows.Forms.CheckedListBox();
            this.clbDuong = new System.Windows.Forms.CheckedListBox();
            this.clbSize = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clbTopping = new System.Windows.Forms.CheckedListBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::OrderMillTeaProgram.Properties.Resources.tradaocamsa__1_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbBasePrice
            // 
            this.lbBasePrice.AutoSize = true;
            this.lbBasePrice.Location = new System.Drawing.Point(25, 403);
            this.lbBasePrice.Name = "lbBasePrice";
            this.lbBasePrice.Size = new System.Drawing.Size(28, 16);
            this.lbBasePrice.TabIndex = 24;
            this.lbBasePrice.Text = "Giá";
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
            this.btnExit.FillColor = System.Drawing.Color.Silver;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(927, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnExit.Size = new System.Drawing.Size(32, 38);
            this.btnExit.TabIndex = 23;
            this.btnExit.UseTransparentBackground = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(28, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 330);
            this.panel1.TabIndex = 21;
            // 
            // btnAddGioHang
            // 
            this.btnAddGioHang.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddGioHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddGioHang.Location = new System.Drawing.Point(311, 558);
            this.btnAddGioHang.Name = "btnAddGioHang";
            this.btnAddGioHang.Size = new System.Drawing.Size(139, 87);
            this.btnAddGioHang.TabIndex = 16;
            this.btnAddGioHang.Text = "Thêm vào giỏ hàng";
            this.btnAddGioHang.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnAddGioHang);
            this.panel2.Controls.Add(this.btnDatMon);
            this.panel2.Controls.Add(this.clbDa);
            this.panel2.Controls.Add(this.clbDuong);
            this.panel2.Controls.Add(this.clbSize);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.clbTopping);
            this.panel2.Controls.Add(this.txtNote);
            this.panel2.Controls.Add(this.numericQuantity);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(315, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 656);
            this.panel2.TabIndex = 22;
            // 
            // btnDatMon
            // 
            this.btnDatMon.BackColor = System.Drawing.SystemColors.Control;
            this.btnDatMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDatMon.Location = new System.Drawing.Point(456, 558);
            this.btnDatMon.Name = "btnDatMon";
            this.btnDatMon.Size = new System.Drawing.Size(124, 87);
            this.btnDatMon.TabIndex = 15;
            this.btnDatMon.Text = "Đặt món";
            this.btnDatMon.UseVisualStyleBackColor = false;
            // 
            // clbDa
            // 
            this.clbDa.FormattingEnabled = true;
            this.clbDa.Location = new System.Drawing.Point(26, 435);
            this.clbDa.Name = "clbDa";
            this.clbDa.Size = new System.Drawing.Size(162, 72);
            this.clbDa.TabIndex = 14;
            // 
            // clbDuong
            // 
            this.clbDuong.FormattingEnabled = true;
            this.clbDuong.Location = new System.Drawing.Point(26, 341);
            this.clbDuong.Name = "clbDuong";
            this.clbDuong.Size = new System.Drawing.Size(162, 72);
            this.clbDuong.TabIndex = 13;
            // 
            // clbSize
            // 
            this.clbSize.FormattingEnabled = true;
            this.clbSize.Location = new System.Drawing.Point(26, 243);
            this.clbSize.Name = "clbSize";
            this.clbSize.Size = new System.Drawing.Size(162, 72);
            this.clbSize.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(24, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Size";
            // 
            // clbTopping
            // 
            this.clbTopping.FormattingEnabled = true;
            this.clbTopping.Location = new System.Drawing.Point(26, 128);
            this.clbTopping.Name = "clbTopping";
            this.clbTopping.Size = new System.Drawing.Size(255, 89);
            this.clbTopping.TabIndex = 10;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(26, 533);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(210, 22);
            this.txtNote.TabIndex = 9;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Location = new System.Drawing.Point(26, 581);
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(120, 22);
            this.numericQuantity.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(22, 558);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số lượng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(22, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ghi chú ( không bắt buộc)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(24, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chọn mức đá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(24, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chọn mức đường";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Topping";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thông Tin Oder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trà Đào Cam Sả";
            // 
            // TraDaoCamSa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 709);
            this.Controls.Add(this.lbBasePrice);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TraDaoCamSa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraDaoCamSa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbBasePrice;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddGioHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDatMon;
        private System.Windows.Forms.CheckedListBox clbDa;
        private System.Windows.Forms.CheckedListBox clbDuong;
        private System.Windows.Forms.CheckedListBox clbSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbTopping;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}