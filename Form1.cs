using Microsoft.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TrungNguyenCoffee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            #region
            txtUsername.Text = "TÊN ĐĂNG NHẬP";
            txtUsername.ForeColor = System.Drawing.Color.Gray;

            txtUsername.Enter += (sender, e) =>
            {
                if (txtUsername.Text == "TÊN ĐĂNG NHẬP")
                {
                    txtUsername.Text = "";
                    txtUsername.ForeColor = System.Drawing.Color.White;
                }
            };

            txtUsername.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Text = "TÊN ĐĂNG NHẬP";
                    txtUsername.ForeColor = System.Drawing.Color.Gray;
                }
            };
            txtPassword.Text = "MẬT KHẨU";
            txtPassword.ForeColor = System.Drawing.Color.Gray;

            txtPassword.Enter += (sender, e) =>
            {
                if (txtPassword.Text == "MẬT KHẨU")
                {
                    txtPassword.Text = "";
                    txtPassword.ForeColor = System.Drawing.Color.White;
                }
            };

            txtPassword.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.Text = "MẬT KHẨU";
                    txtPassword.ForeColor = System.Drawing.Color.Gray;
                }
            };
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = (char)42;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.ToUpper();
            string password = txtPassword.Text;
            if (Login(username, password))
            {

                FormTable mainForm = new FormTable(username);
                this.Hide(); // Hide the login form (Form1)
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool Login(string username, string password)
        {
            return UserDAO.Instance.Login(username, password);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho textbox xử lý phím Enter

                // Di chuyển focus tới textbox khác (ở đây là txtPassword)
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn không cho textbox xử lý phím Enter

                // Kích hoạt sự kiện Click của button (ở đây là guna2Button1)
                guna2Button1.PerformClick();
            }
        }
    }
}
