using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return instance; }
            private set { instance = value; }
        }

        private UserDAO() { }
        public bool Login(string username, string password) 
        {
            string query = "USP_Login @username , @password ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username,password});
            return result.Rows.Count > 0;
        }

        public List<User> GetListuser()
        {
            List<User> users = new List<User>();

            // Sử dụng DataProvider để thực hiện truy vấn và lấy kết quả dưới dạng DataTable
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_Getlistuser");

            foreach (DataRow dr in data.Rows)
            {
                User user = new User(dr); // Giả sử có lớp Category

                users.Add(user);
            }

            return users;
        }

        public int Getidbyname(string username)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetAccount @username ", new object[] { username });
            }
            catch
            {
                return 1;
            }
        }
    }
}
