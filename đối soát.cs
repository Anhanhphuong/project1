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
using TrungNguyenCoffee.DAO;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee
{
    public partial class đối_soát : Form
    {
        private int revenueid;
        private string username;
        public đối_soát(int rvid, string username)
        {
            InitializeComponent();
            ShowDetailRevenue();
            this.revenueid = rvid;
            this.username = username;
            label13.Text = username;
            ShowTotalRevenueByCash();
            ShowTotalByCreditCard();
            ShowTotalByGrab();
        }

        private void ShowTotalByGrab()
        {
            
            decimal totalRevenue = RevenueDAO.Instance.TotalbyPayment("Grabfood");
            
            // Hiển thị tổng doanh thu tương ứng lên form
            textBox4.Text = totalRevenue.ToString();
        }

        private void ShowTotalByCreditCard()
        {
           
            decimal totalRevenue = RevenueDAO.Instance.TotalbyPayment("Thẻ ngân hàng");
       
            
            // Hiển thị tổng doanh thu tương ứng lên form
            textBox1.Text = totalRevenue.ToString();

        }

        private void ShowTotalRevenueByCash()
        {

            decimal totalRevenue = RevenueDAO.Instance.TotalbyPayment("Tiền mặt");
            
            // Hiển thị tổng doanh thu tương ứng lên form
            textBox5.Text = totalRevenue.ToString();

        }

        private void ShowDetailRevenue()
        {
            List<Revenu> revenus = RevenueDAO.Instance.GetReveue();

            if (revenus != null && revenus.Count > 0) // Kiểm tra xem danh sách revenus có tồn tại và có phần tử không trước khi truy cập
            {
                // Lấy giá trị của trường checkin từ đối tượng Revenu đầu tiên trong danh sách và gán vào TextBox
                textBox2.Text = revenus[0].Checkin.ToString();
                textBox3.Text = revenus[0].Checkout.ToString();


            }
            else
            {
                // Xử lý trường hợp không có dữ liệu trả về
                textBox2.Text = "No data";
                textBox3.Text = "No data";
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RevenueDAO.Instance.Checkoutrevenue();
            this.Hide(); // Ẩn form hiện tại
            Form1 form1 = new Form1(); // Tạo mới một instance của Form1
            form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
