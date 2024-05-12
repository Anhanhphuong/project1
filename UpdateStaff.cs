using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungNguyenCoffee.DAO;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee
{
    public partial class UpdateStaff : Form
    {
        private int staffid;
        public UpdateStaff(int staffid)
        {
            InitializeComponent();
            this.staffid = staffid;
            label6.Text = "NV #" + staffid.ToString();
            InitializeComponent();
            // Thêm các giá trị vào ComboBox
            guna2ComboBox1.Items.Add("Nam");
            guna2ComboBox1.Items.Add("Nữ");

            // Chọn mặc định giá trị đầu tiên (Nam)
            guna2ComboBox1.SelectedIndex = 0;

            guna2ComboBox2.Items.Add("Quản lý");
            guna2ComboBox2.Items.Add("Nhân viên thu ngân");
            guna2ComboBox2.Items.Add("Nhân viên phục vụ");

            // Chọn mặc định giá trị đầu tiên (Nam)
            guna2ComboBox2.SelectedIndex = 0;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string gender = guna2ComboBox1.SelectedItem.ToString();
            string phone = textBox2.Text;
            string address = textBox3.Text;
            string role = guna2ComboBox2.SelectedItem.ToString();
               
            if (MessageBox.Show("Cập nhật thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                StaffDAO.Instance.UpdateStaff(staffid, name, gender, phone, address, role);
                this.Hide();
            }
        }
    }
}
