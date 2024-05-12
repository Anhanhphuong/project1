using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        public int Getidbynumber(string phone)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetCustomer @phone ", new object[] { phone });
            }
            catch
            {
                return 1;
            }
        }



        public void InsertCustomer(string name, string phone)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertCustom @name , @phone", new object[] { name, phone });
        }

        public void UpdateCustomer(string name, string phone, int score)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UPDATECustomer @name , @phone , @score", new object[] { name, phone, score});
        }
        public List<DTO.Customer> GetListbyid(int id)
        {
            List<Customer> listCustomer = new List<Customer>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DBO.customer WHERE id = " + id);
            foreach (DataRow item in dt.Rows)
            {
                Customer customer = new Customer(item); // Giả sử có lớp Customer
                listCustomer.Add(customer);
            }
            return listCustomer;
        }


        public List<DTO.Customer> GetListCustomer()
        {
            List<Customer> listCustomer = new List<Customer>();
            string query = string.Format("select * from dbo.customer");
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Customer customer = new Customer(item); // Giả sử có lớp Item
                listCustomer.Add(customer);
            }
            return listCustomer;
        }
    }
}
