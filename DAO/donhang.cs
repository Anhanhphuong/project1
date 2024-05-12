using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrungNguyenCoffee.DAO
{
    public partial class donhang : Form
    {
        public donhang()
        {
            InitializeComponent();

            
        }
      


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID của hóa đơn từ cột cụ thể (ví dụ: cột 0)
                int tableId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Bàn"].Value);
                string username = guna2DataGridView1.Rows[e.RowIndex].Cells["Ca làm"].Value.ToString();


                // Mở form khác tương ứng với hóa đơn được chọn
                FormOrder formOrderDetails = new FormOrder(tableId, username);
                formOrderDetails.Show();
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID của hóa đơn từ cột cụ thể (ví dụ: cột 0)
                int rvid = Convert.ToInt32(guna2DataGridView2.Rows[e.RowIndex].Cells[" "].Value);
                string username = guna2DataGridView2.Rows[e.RowIndex].Cells["Ca làm"].Value.ToString();
                // Mở form khác tương ứng với hóa đơn được chọn
                đối_soát formOrderDetails = new đối_soát(rvid, username);
                formOrderDetails.Show();
            }
        }

        private void donhang_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = OrderDAO.Instance.GetCheckin();
            guna2DataGridView2.DataSource = RevenueDAO.Instance.GetCheckinrevenue();
        }
    }
}
