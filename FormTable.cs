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
    public partial class FormTable : Form
    {
        private int UserId;
        private Panel currentPanel;
        private string username;
        public FormTable(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadTable();

            this.username = username;
        }



        private Form CurrentFormChild;
        private void OpenChildForm(Form ChildForm)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(ChildForm);
            guna2Panel3.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }
        private void LoadTable()
        {
            flowLayoutPanel1.Controls.Clear();

            List<Table> TableList = TableDAO.Instance.LoadTableList();
            foreach (Table table in TableList)
            {
                Guna2Button button = new Guna2Button();
                button.Text = table.Name;
                button.Size = new System.Drawing.Size(120, 120);
                button.BorderRadius = 10;
                button.BorderThickness = 1;
                button.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
                button.Margin = new Padding(25);
                button.Tag = table;
                button.Click += button_Click;
                flowLayoutPanel1.Controls.Add(button);

                switch (table.Status)
                {
                    case "0":
                        button.ForeColor = System.Drawing.Color.Gray;
                        button.BorderColor = System.Drawing.Color.Gray;
                        button.FillColor = System.Drawing.Color.White;
                        break;
                    case "1":
                        button.ForeColor = System.Drawing.Color.White;
                        button.BorderColor = System.Drawing.Color.White;
                        button.FillColor = System.Drawing.Color.FromArgb(222, 135, 119);
                        break;
                }
            }
        }

        private void button_Click(object? sender, EventArgs e)
        {
            string username = textBox1.Text;

            int tableId = ((sender as Guna2Button).Tag as Table).Id;
            FormOrder formOrder = new FormOrder(tableId, username);
            this.Hide();
            formOrder.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new donhang());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadTable();
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
                this.Show();
                this.BringToFront();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QL());
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            textBox1.Text = username;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
