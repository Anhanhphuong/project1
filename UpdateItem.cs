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
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee
{
    public partial class UpdateItem : Form
    {
        private int itemid;
        public UpdateItem(int itemid)
        {
            InitializeComponent();
            this.itemid = itemid;
            label4.Text= "CẬP NHẬT THÔNG TIN MÓN #" + itemid.ToString();
            LoadCategory();
        }
        private void LoadCategory()
        {
            List<Category> categories = CategoryDAO.Instance.LoadMenuWithCategories();
            guna2ComboBox1.DataSource = categories;
            guna2ComboBox1.DisplayMember = "Name";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox2.Image = Image.FromFile(filePath);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int categoryid = (guna2ComboBox1.SelectedItem as Category).Id;
            decimal price = Convert.ToDecimal(textBox3.Text.Replace(",", ""));
            string name = textBox2.Text;
            if (pictureBox2.Image != null)
            {
                byte[] imageData;
                using (var ms = new System.IO.MemoryStream())
                {
                    pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }
                
                if (MessageBox.Show("Cập nhật thông tin món thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    ItemDAO.Instance.UpdateItem(itemid, name, categoryid, price, imageData);
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
                this.Hide();
            }
        }
    }
}
