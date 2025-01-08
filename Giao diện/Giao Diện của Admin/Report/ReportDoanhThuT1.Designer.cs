namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_Admin.Report
{
    partial class ReportDoanhThuT1
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
            this.reportThang1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportThang1
            // 
            this.reportThang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportThang1.Location = new System.Drawing.Point(0, 0);
            this.reportThang1.Name = "reportThang1";
            this.reportThang1.ServerReport.BearerToken = null;
            this.reportThang1.Size = new System.Drawing.Size(800, 450);
            this.reportThang1.TabIndex = 0;
            // 
            // ReportDoanhThuT1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportThang1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportDoanhThuT1";
            this.Text = "ReportDoanhThuT1";
            this.Load += new System.EventHandler(this.ReportDoanhThuT1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportThang1;
    }
}