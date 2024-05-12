using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormOrder : Form
    {
        private string connectionString = @"Data Source=LAPTOP-S7TLI0E9;Initial Catalog=Cf;Integrated Security=True;Trust Server Certificate=True";
        private int tableId;

        private string username;
        public FormOrder(int tableId, string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.tableId = tableId;

            this.username = username;
            label3.Text = username;
            LoadCategory();
            ShowBill(tableId);
            LoadDiscount();
            List<Customer> customers = CustomerDAO.Instance.GetListCustomer();
            comboBox1.DataSource = customers;
            comboBox1.DisplayMember = "Phone";
           
            #region
            textBox2.Text = "Currently serving # " + tableId.ToString();
            textBox3.Text = "TÊN KHÁCH HÀNG";
            textBox3.ForeColor = System.Drawing.Color.Gray;

            textBox3.Enter += (sender, e) =>
            {
                if (textBox3.Text == "TÊN KHÁCH HÀNG")
                {
                    textBox3.Text = "";
                    textBox3.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                }
            };

            textBox3.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    textBox3.Text = "TÊN KHÁCH HÀNG";
                    textBox3.ForeColor = System.Drawing.Color.Gray;
                }
            };
            textBox4.Text = "SỐ ĐIỆN THOẠI";
            textBox4.ForeColor = System.Drawing.Color.Gray;

            textBox4.Enter += (sender, e) =>
            {
                if (textBox4.Text == "SỐ ĐIỆN THOẠI")
                {
                    textBox4.Text = "";
                    textBox4.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                }
            };

            textBox4.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    textBox4.Text = "SỐ ĐIỆN THOẠI";
                    textBox4.ForeColor = System.Drawing.Color.Gray;
                }
            };
            textBox5.Text = "ĐIỂM TÍCH LŨY";
            textBox5.ForeColor = System.Drawing.Color.Gray;

            textBox5.Enter += (sender, e) =>
            {
                if (textBox5.Text == "ĐIỂM TÍCH LŨY")
                {
                    textBox5.Text = "";
                    textBox5.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                }
            };

            textBox5.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    textBox5.Text = "ĐIỂM TÍCH LŨY";
                    textBox5.ForeColor = System.Drawing.Color.Gray;
                }
            };

        }

        private void LoadDiscount()
        {


        }
        #endregion
        #region
        private void LoadCategory()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Category> categories = CategoryDAO.Instance.LoadMenuWithCategories();
            foreach (Category category in categories)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = category.Name.ToUpper();
                btn.Size = new System.Drawing.Size(240, 80);
                btn.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                btn.BorderThickness = 1;
                btn.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
                btn.FillColor = System.Drawing.Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                btn.Click += Btn_Click;
                btn.Tag = category;
                btn.Margin = new Padding(5);
                flowLayoutPanel1.Controls.Add(btn);
                if (category.Id == 1)
                {
                    ShowMenu(category.Id);
                    btn.FillColor = System.Drawing.Color.FromArgb(103, 74, 64);
                    btn.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void ShowMenu(int id)
        {

            flowLayoutPanel2.Controls.Clear();
            List<Item> items = ItemDAO.Instance.GetItemIdByCategory(id);

            foreach (Item item in items)
            {
                Guna2TileButton bt = new Guna2TileButton();
                bt.Text = item.Name.ToUpper() + "\n" + item.Price;
                bt.TextAlign = HorizontalAlignment.Center;
                bt.Size = new System.Drawing.Size(220, 320);
                bt.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                bt.BorderRadius = 5;
                bt.BorderThickness = 2;
                bt.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
                bt.BorderThickness = 1;



                bt.ImageSize = new Size(150, 150);

                bt.FillColor = System.Drawing.Color.White;
                bt.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular);
                bt.Tag = item;

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "SELECT item_image FROM dbo.item WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, cn);
                    command.Parameters.AddWithValue("@id", item.Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["item_image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["item_image"];
                                MemoryStream ms = new MemoryStream(imageData);
                                bt.Image = new Bitmap(ms);
                            }
                            else
                            {
                                // Xử lý trường hợp nếu giá trị là NULL (ImageData không có dữ liệu)
                                // Ví dụ: hiển thị một hình ảnh mặc định hoặc bỏ qua nếu không có dữ liệu
                            }
                        }
                    }
                }
                bt.Click += Bt_Click;
                // Thêm sự kiện Double Click cho nút bt
                bt.DoubleClick += Bt_DoubleClick;

                flowLayoutPanel2.Controls.Add(bt);
            }
        }

        private void Bt_DoubleClick(object sender, EventArgs e)
        {

            int userid = UserDAO.Instance.Getidbyname(username);
            int orderID = OrderDAO.Instance.GetOrderbyTableID(tableId);
            int quantity = (int)(guna2NumericUpDown2.Value);
            // Tiếp tục xử lý với orderID
            int itemid = ((sender as Guna2Button).Tag as DTO.Item).Id;

            if (orderID == -1)
            {
                OrderDAO.Instance.InsertBill(tableId, userid);
                DetailDAO.Instance.InsertDetailcus(OrderDAO.Instance.GetMaxOrderid(), quantity, itemid);

            }
            else
            {
                DetailDAO.Instance.InsertDetailcus(orderID, quantity, itemid);
            }
            ShowBill(tableId);
            decimal totalPrice = Convert.ToDecimal(textBox6.Text.Replace(",", ""));
            OrderDAO.Instance.Checkin(orderID, totalPrice);
        }

        private void Bt_Click(object sender, EventArgs e)
        {

            int userid = UserDAO.Instance.Getidbyname(username);
            int orderID = OrderDAO.Instance.GetOrderbyTableID(tableId);

            // Tiếp tục xử lý với orderID
            int itemid = ((sender as Guna2Button).Tag as DTO.Item).Id;

            if (orderID == -1)
            {
                OrderDAO.Instance.InsertBill(tableId, userid);
                DetailDAO.Instance.InsertDetail(OrderDAO.Instance.GetMaxOrderid(), itemid);

            }
            else
            {
                DetailDAO.Instance.InsertDetail(orderID, itemid);
            }
            ShowBill(tableId);
            decimal totalPrice = Convert.ToDecimal(textBox6.Text.Replace(",", ""));
            OrderDAO.Instance.Checkin(orderID, totalPrice);


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            clickedButton.ForeColor = System.Drawing.Color.White;
            clickedButton.FillColor = System.Drawing.Color.FromArgb(103, 74, 64);

            // Lặp qua tất cả các nút khác trong flowLayoutPanel1 để đặt màu về màu mặc định
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button button && button != clickedButton)
                {
                    button.ForeColor = System.Drawing.Color.FromArgb(103, 74, 64);
                    button.FillColor = System.Drawing.Color.White;

                }
            }
            int CategoryId = ((sender as Guna2Button).Tag as DTO.Category).Id;
            ShowMenu(CategoryId);
        }
        #endregion
        #region



        private void ShowBill(int id)
        {
            guna2DataGridView1.Rows.Clear(); // Xóa tất cả các hàng hiện có trong DataGridView

            List<DTO.Menu> ListDetail = MenuDAO.Instance.GetListMenubyTable(id);
            decimal totalPrice = 0; // Khởi tạo biến tổng tiền
            decimal totalDiscount = 0;
            decimal discount = guna2NumericUpDown1.Value;
            decimal newtotal = 0;
            foreach (DTO.Menu item in ListDetail)
            {
                // Thêm một hàng mới vào DataGridView
                guna2DataGridView1.Rows.Add(item.Name, item.Price.ToString("#,##0.##"), item.Quantity);

                // Tính toán tổng tiền bằng cách cộng dồn giá tiền của mỗi sản phẩm
                totalPrice += item.Price * item.Quantity;
                totalDiscount = totalPrice * discount / 100;
                newtotal = totalPrice - totalDiscount;
            }

            // Hiển thị tổng tiền lên TextBox
            textBox1.Text = totalPrice.ToString("#,##0.##");
            textBox7.Text = totalDiscount.ToString("#,##0.##");
            textBox6.Text = newtotal.ToString("#,##0.##");




        }



        #endregion
        private void FormOrder_Load(object sender, EventArgs e)
        {

        }





        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column4"].Index)
            {

                string itemName = guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                int itemId = ItemDAO.Instance.GetidByname(itemName);
                DetailDAO.Instance.DeleteDetail(itemId);
                // Xác định dòng được chọn và xóa nó
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                    ShowBill(tableId);
                    int orderID = OrderDAO.Instance.GetOrderbyTableID(tableId);
                    decimal totalPrice = Convert.ToDecimal(textBox6.Text.Replace(",", ""));
                    OrderDAO.Instance.Checkin(orderID, totalPrice);


                }


            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int userid = UserDAO.Instance.Getidbyname(username);
            int orderid = OrderDAO.Instance.GetOrderbyTableID(tableId);
            decimal newtotal = Convert.ToDecimal(textBox6.Text.Replace(",", ""));
            int score = (int)(newtotal / 10000 - guna2NumericUpDown1.Value * 5);
            string phone = textBox4.Text;
            string name = textBox3.Text;
            bool paymentSelected = false;
            if (checkBox1.Checked)
            {

                // Lấy giá trị văn bản từ ô đánh dấu 1 nếu nó đã được chọn
                string payment = checkBox1.Text;
                paymentSelected = true;
                if (orderid != -1)
                {
                    decimal totalCash = RevenueDAO.Instance.TotalbyPayment("Tiền mặt");
                    RevenueDAO.Instance.UpdateCash(totalCash);
                    OrderDAO.Instance.Checkout(orderid, newtotal, payment);
                    CustomerDAO.Instance.UpdateCustomer(name, phone, score);
                    RevenueDAO.Instance.InsertRevenue(newtotal, userid, payment);
                    ShowBill(tableId);
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Sử dụng giá trị văn bản đã lấy được
            }

            if (checkBox2.Checked)
            {
                // Lấy giá trị văn bản từ ô đánh dấu 2 nếu nó đã được chọn
                string payment = checkBox2.Text;
                paymentSelected = true;
                if (orderid != -1)
                {                  
                    decimal totalCard = RevenueDAO.Instance.TotalbyPayment("Thẻ ngân hàng");
                    RevenueDAO.Instance.UpdateCard(totalCard);
                    OrderDAO.Instance.Checkout(orderid, newtotal, payment);
                    CustomerDAO.Instance.UpdateCustomer(name, phone, score);
                    RevenueDAO.Instance.InsertRevenue(newtotal, userid, payment);
                    ShowBill(tableId);
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Sử dụng giá trị văn bản đã lấy được
            }

            if (checkBox3.Checked)
            {
                // Lấy giá trị văn bản từ ô đánh dấu 3 nếu nó đã được chọn
                string payment = checkBox3.Text;
                paymentSelected = true;
                if (orderid != -1)
                {
                    decimal totalGrab = RevenueDAO.Instance.TotalbyPayment("Grabfood");
                    RevenueDAO.Instance.UpdateGrab(totalGrab);
                    OrderDAO.Instance.Checkout(orderid, newtotal, payment);
                    CustomerDAO.Instance.UpdateCustomer(name, phone, score);
                    RevenueDAO.Instance.InsertRevenue(newtotal, userid, payment);
                    ShowBill(tableId);
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Sử dụng giá trị văn bản đã lấy được
            }
            if (!paymentSelected)
            {
                // Hiển thị thông báo nếu không có ô nào được chọn
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }






        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }




        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho textbox xử lý phím Enter

                // Kích hoạt sự kiện Click của button (ở đây là guna2Button1)
                guna2ImageButton4.PerformClick();
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            string phone = textBox4.Text;
            string name = textBox3.Text;
            
                CustomerDAO.Instance.InsertCustomer(name, phone);
            

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            FormTable formtable = new FormTable(username);
            this.Hide();
            formtable.ShowDialog();
        }

        private void giảmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2NumericUpDown1.Value = 10;
            ShowBill(tableId);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void giảm20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2NumericUpDown1.Value = 20;
            ShowBill(tableId);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int customerid = (comboBox1.SelectedItem as Customer).Id;
                List<DTO.Customer> ListCustomer = CustomerDAO.Instance.GetListbyid(customerid);

                // Lấy thông tin của khách hàng đầu tiên trong danh sách (giả sử là chỉ có một khách hàng)
                DTO.Customer firstCustomer = ListCustomer[0];

                // Hiển thị thông tin khách hàng
                textBox3.Text = firstCustomer.Name;
                textBox4.Text = firstCustomer.Phone;
                textBox5.Text = firstCustomer.Score.ToString();
            }

            else
            {
                // Thông báo nếu không tìm thấy khách hàng
                MessageBox.Show("Không tìm thấy thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
