using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        private StaffDAO() { }
        public List<Staff> GetListStaff()
        {
            List<Staff> staffs = new List<Staff>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT*FROM dbo.staff");
            foreach (DataRow dr in data.Rows)
            {
                Staff staff = new Staff(dr);
                staffs.Add(staff);
            }

            return staffs;
        }

        public List<Staff> SearchStaffbyname(string name)
        {
            List<Staff> staffs = new List<Staff>();
            string query = string.Format("SELECT * FROM DBO.staff WHERE name like N'%{0}%'", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow staffRow in dt.Rows)
            {
                Staff staff = new Staff(staffRow); // Giả sử có lớp Category

                staffs.Add(staff);
            }

            return staffs;
        }
        public void InsertStaff(string name, string gender, string phone, string address, string role)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertStaff @name , @gender , @phone , @address , @role", new object[] { name, gender, phone, address, role });
        }
        public void UpdateStaff(int id, string name, string gender, string phone, string address, string role)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateStaff @staffid , @name , @gender , @phone , @address , @role", new object[] { id, name, gender, phone, address, role });
        }
        public void DeleteStaff(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteStaff @staffid", new object[] { id });

        }
    }
}
