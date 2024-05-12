using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return OrderDAO.instance; }
            private set { OrderDAO.instance = value; }
        }

        private OrderDAO() { }
        public int GetOrderbyTableID(int id)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DBO.orders WHERE table_id=" + id + " AND status = 0");

            if (dt.Rows.Count > 0)
            {
                DTO.Order order = new DTO.Order(dt.Rows[0]);
                return order.Id; // Return the ID property of the Order object
            }

            return -1;
        }
        public void InsertBill(int id , int userid)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @table_id , @useid ", new object[] {id , userid } );
        }
        public int GetMaxOrderid()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.orders");
            }
            catch 
            { 
                return 1; 
            }
        }
        
        public DataTable GetCheckin()
        {
           return DataProvider.Instance.ExecuteQuery("EXEC USP_GetOrderCheckin ", new object[] {  });
        }

        public DataTable GetCheckout(DateTime? dateCheckin, DateTime? dateCheckout)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetOrderByDate @dateCheckin , @dateCheckout ", new object[] { dateCheckin, dateCheckout });
        }
        public void Checkout(int id, decimal totalPrice, string payment)
        {
            // Sử dụng tham số để tránh lỗi Injection SQL và đảm bảo chuỗi Unicode được xử lý đúng
            string query = $"UPDATE dbo.orders SET DateCheckout = GETDATE(), status = 1, TotalPrice = {totalPrice}, payment = N'{payment}' WHERE id = {id}";

            // Gọi phương thức ExecuteNonQuery của DataProvider để thực thi truy vấn
            DataProvider.Instance.ExecuteNonQuery(query);


        }
        public void Checkin(int id, decimal totalPrice)
        {
            string query = "UPDATE dbo.orders SET TotalPrice = " + totalPrice + " WHERE id= " + id;
            DataProvider.Instance.ExecuteNonQuery(query);


        }

        public DataTable GetListDetail(int id)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListDt @orderid ", new object[] { id });
        }


    }
}
