using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungNguyenCoffee.DAO;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee
{
    public partial class UpdateCategory : Form
    {
        private int cateid;
        public UpdateCategory(int cateid)
        {
            InitializeComponent();
            this.cateid = cateid;
            label1.Text = "SỬA TÊN NHÓM MÓN #" + cateid.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            
           
            if (MessageBox.Show("Cập nhật thông tin nhóm món thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                CategoryDAO.Instance.UpdateCategory(cateid, name);
                this.Hide();
            }
        }
    }
}
