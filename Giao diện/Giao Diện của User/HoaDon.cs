using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User
{
    public partial class HoaDon : DevExpress.XtraEditors.XtraForm
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tile được nhấp!");
            TileGroup tileGroup = new TileGroup();
            tileControl1.Groups.Add(tileGroup); // Thêm nhóm vào TileControl

            TileItem tileItem = new TileItem();
            tileItem.Text = "Hóa Đơn";
            tileItem.AppearanceItem.Normal.BackColor = Color.LightBlue; // Màu nền
            tileItem.AppearanceItem.Normal.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Font chữ
            tileItem.Image = Image.FromFile("hoaDon.png"); // Thêm ảnh (nếu cần)
            tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;

            tileGroup.Items.Add(tileItem); // Thêm TileItem vào TileGroup

            // Gán sự kiện cho TileItem

        }
    }
}