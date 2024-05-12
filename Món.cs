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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TrungNguyenCoffee
{
    public partial class Món : Form
    {
        public Món()
        {
            InitializeComponent();
            ShowItem();
            Showitembyname();
        }

        private void Showitembyname()
        {

           
        }

        private void ShowItem()
        {
            List<Item> items = ItemDAO.Instance.GetItemId();
            foreach (Item item in items)
            {
                guna2DataGridView1.Rows.Add(item.Id, item.Name, item.Price, item.CategoryId);
            }
        }

        private void Món_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ADDitem mainForm = new ADDitem();
            mainForm.ShowDialog();
            this.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column6"].Index)
            {
                int itemId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);
                try
                {
                    ItemDAO.Instance.DeleteItem(itemId);
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);

                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column5"].Index)
            {
                int itemId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);

                UpdateItem formOrder = new UpdateItem(itemId);
                formOrder.ShowDialog();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            string name = textBox1.Text;
            List<Item> items = ItemDAO.Instance.SearchItembyname(name);
            foreach (Item item in items)
            {
                guna2DataGridView1.Rows.Add(item.Id, item.Name, item.Price, item.CategoryId);
            }
        }
    }
}
