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
    public partial class BillDetail : Form
    {
        public BillDetail(int orderId)
        {
            InitializeComponent();
            ShowBill(orderId);
            guna2DataGridView1.ReadOnly = true;
        }

        private void BillDetail_Load(object sender, EventArgs e)
        {

        }
        private void ShowBill(int id)
        {
            

            guna2DataGridView1.DataSource = OrderDAO.Instance.GetListDetail(id);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
