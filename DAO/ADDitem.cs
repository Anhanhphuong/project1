using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungNguyenCoffee.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrungNguyenCoffee.DAO
{
    public partial class ADDitem : Form
    {

        public ADDitem()
        {
            InitializeComponent();
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
                
                    //ItemDAO.Instance.UpdateItemImage( imageData); // Cập nhật dữ liệu ảnh cho mục trong cơ sở dữ liệu
                    MessageBox.Show("Thêm món thành công");
                if (MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    ItemDAO.Instance.InsertItem(name, categoryid, price, imageData);
                }

            }
            else
            {
                MessageBox.Show("Không hợp lệ!");
            }
        }
    }
}
