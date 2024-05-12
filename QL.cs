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

namespace TrungNguyenCoffee
{
    public partial class QL : Form
    {
        public QL()
        {
            InitializeComponent();
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
            guna2Panel2.Controls.Add(ChildForm);
            guna2Panel2.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }
        private void QL_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Món());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Nhóm());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Nv());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report());
        }
    }
}
