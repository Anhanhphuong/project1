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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrungNguyenCoffee
{
    public partial class Nhóm : Form
    {
        public Nhóm()
        {
            InitializeComponent();
            ShowCategory();
        }

        private void ShowCategory()
        {
            List<Category> categories = CategoryDAO.Instance.LoadMenuWithCategories();
            foreach (Category category in categories)
            {
                guna2DataGridView1.Rows.Add(category.id, category.Name);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Nhóm_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ADDCate mainForm = new ADDCate();
            mainForm.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            string name = textBox1.Text;
            List<Category> categories = CategoryDAO.Instance.Searchcatebyname(name);
            foreach (Category category in categories)
            {
                guna2DataGridView1.Rows.Add(category.Id, category.Name);
            }

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column3"].Index)
            {
                int cateId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);

                try
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                    CategoryDAO.Instance.DeleteCategory(cateId);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column4"].Index)
            {
                int cateId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);

                UpdateCategory formOrder = new UpdateCategory(cateId);
                formOrder.ShowDialog();

            }
        }
    }
}
