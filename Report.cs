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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            LoadListcheckout(guna2DateTimePicker1.Value, guna2DateTimePicker2.Value);
            LoadDatetimepicker();
            guna2DataGridView1.DataSource = CustomerDAO.Instance.GetListCustomer();
        }
        private void LoadDatetimepicker()
        {
            DateTime today = DateTime.Now;
            guna2DateTimePicker1.Value = today.Date;
            guna2DateTimePicker2.Value = guna2DateTimePicker1.Value.AddDays(1).AddSeconds(-1);
        }

        private void LoadListcheckout(DateTime dateCheckin, DateTime dateCheckout)
        {

            guna2DataGridView2.DataSource = OrderDAO.Instance.GetCheckout(dateCheckin, dateCheckout);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID của hóa đơn từ cột cụ thể (ví dụ: cột 0)
                int orderId = Convert.ToInt32(guna2DataGridView2.Rows[e.RowIndex].Cells["ID"].Value);

                // Mở form khác tương ứng với hóa đơn được chọn
                BillDetail formOrderDetails = new BillDetail(orderId);
                formOrderDetails.Show();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadListcheckout(guna2DateTimePicker2.Value, guna2DateTimePicker1.Value);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
