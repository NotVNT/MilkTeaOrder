using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderMillTeaProgram.Giao_diện.Giao_Diện_của_User.All_form_TS
{
    public partial class TSSocolaMin : Form
    {
        private const int BasePrice = 25000;

        public object Inner { get; private set; }

        public TSSocolaMin()
        {
            InitializeComponent();
            LoadFormData();
            InitializeEvents();
        }

        private void LoadFormData()
        {
            // Load Topping options
            clbTopping.Items.Add("Hạt thủy tinh (+3.000 vnd)");
            clbTopping.Items.Add("Phô mai jelly (+4.000 vnd)");
            clbTopping.Items.Add("Trân châu đường đen (+3.000 vnd)");
            clbTopping.Items.Add("Thạch đào (+2.000 vnd)");
            clbTopping.Items.Add("Thạch dừa (+2.000 vnd)");
            clbTopping.Items.Add("Pudding dưa lưới (+5.000 vnd)");

            // Load Size options
            clbSize.Items.Add("S");
            clbSize.Items.Add("M (+7.000 vnd)");
            clbSize.Items.Add("L (+15.000 vnd)");

            // Load Sugar level options
            clbDuong.Items.Add("0% Đường");
            clbDuong.Items.Add("30% Đường");
            clbDuong.Items.Add("50% Đường");
            clbDuong.Items.Add("70% Đường");
            clbDuong.Items.Add("100% Đường");

            // Load Ice level options
            clbDa.Items.Add("0% Đá");
            clbDa.Items.Add("30% Đá");
            clbDa.Items.Add("50% Đá");
            clbDa.Items.Add("70% Đá");
            clbDa.Items.Add("100% Đá");

            // Set default values
            lbBasePrice.Text = $"Tổng giá: {BasePrice:N0} VNĐ";
            numericQuantity.Value = 1;
        }

        private void InitializeEvents()
        {
            clbTopping.ItemCheck += (s, e) => BeginInvoke((Action)UpdateTotalPrice);
            clbSize.ItemCheck += (s, e) => BeginInvoke((Action)UpdateTotalPrice);
            clbSize.ItemCheck += SingleSelectionCheck;
            clbDuong.ItemCheck += SingleSelectionCheck;
            clbDa.ItemCheck += SingleSelectionCheck;
            numericQuantity.ValueChanged += (s, e) => UpdateTotalPrice();
            btnDatMon.Click += PlaceOrder;
            btnExit.Click += BtnExit_Click;
        }

        private void UpdateTotalPrice()
        {
            int totalPrice = BasePrice;

            // Add topping prices
            foreach (int index in clbTopping.CheckedIndices)
            {
                string selectedItem = clbTopping.Items[index].ToString();
                totalPrice += GetPriceFromText(selectedItem);
            }

            // Add size price
            foreach (int index in clbSize.CheckedIndices)
            {
                string selectedItem = clbSize.Items[index].ToString();
                totalPrice += GetPriceFromText(selectedItem);
            }

            // Multiply by quantity
            totalPrice *= (int)numericQuantity.Value;

            // Update total price label
            lbBasePrice.Text = $"Tổng giá: {totalPrice:N0} VNĐ";
        }

        private int GetPriceFromText(string text)
        {
            string[] parts = text.Split('+');
            if (parts.Length > 1)
            {
                string pricePart = parts[1].Replace("vnd", "").Trim().Replace(".", "");
                if (int.TryParse(pricePart, out int price))
                {
                    return price;
                }
            }
            return 0;
        }

        private void SingleSelectionCheck(object sender, ItemCheckEventArgs e)
        {
            if (sender is CheckedListBox listBox)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    foreach (int index in listBox.CheckedIndices)
                    {
                        if (index != e.Index)
                        {
                            listBox.SetItemCheckState(index, CheckState.Unchecked);
                        }
                    }
                }
            }
        }

        private void PlaceOrder(object sender, EventArgs e)
        {
            MessageBox.Show("Đặt món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}