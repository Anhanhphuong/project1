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
    public partial class Nv : Form
    {
        public Nv()
        {
            InitializeComponent();
            ShowStaff();
        }

        private void ShowStaff()
        {
            List<Staff> staffs = StaffDAO.Instance.GetListStaff();
            foreach (Staff staff in staffs)
            {
                guna2DataGridView1.Rows.Add(staff.Id, staff.Name, staff.Gender, staff.Phone, staff.Address, staff.Role);
            }

        }

        private void Staff_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column7"].Index)
            {
                int staffId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);

                UpdateStaff formOrder = new UpdateStaff(staffId);
                formOrder.ShowDialog();

            }
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["Column8"].Index)
            {
                int staffId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value);


                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                    StaffDAO.Instance.DeleteStaff(staffId);
                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ADDstaff mainForm = new ADDstaff();
            mainForm.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            string name = textBox1.Text;
            List<Staff> staffs = StaffDAO.Instance.SearchStaffbyname(name);
            foreach (Staff staff in staffs)
            {
                guna2DataGridView1.Rows.Add(staff.Id, staff.Name, staff.Gender, staff.Phone, staff.Address, staff.Role);
            }
        }
    }
}
