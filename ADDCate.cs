using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungNguyenCoffee.DAO;

namespace TrungNguyenCoffee
{
    public partial class ADDCate : Form
    {
        public ADDCate()
        {
            InitializeComponent();
            textBox1.Text = "NHẬP NHÓM MÓN MỚI";
            textBox1.ForeColor = System.Drawing.Color.Gray;

            textBox1.Enter += (sender, e) =>
            {
                if (textBox1.Text == "NHẬP NHÓM MÓN MỚI")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = System.Drawing.Color.White;
                }
            };

            textBox1.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "NHẬP NHÓM MÓN MỚI";
                    textBox1.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void ADDCate_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            CategoryDAO.Instance.InsertCategory(name);
            MessageBox.Show("Thêm nhóm món thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
