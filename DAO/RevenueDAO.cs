using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class RevenueDAO
    {
        private static RevenueDAO instance;
        public static RevenueDAO Instance
        {
            get { if (instance == null) instance = new RevenueDAO(); return RevenueDAO.instance; }
            private set { RevenueDAO.instance = value; }
        }



        private RevenueDAO() { }
        public void InsertRevenue(decimal totalprice, int userid, string payment)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateRevenue @totalprice , @useid , @paymentMethod ", new object[] { totalprice, userid, payment });
        }

        public DataTable GetCheckinrevenue()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListRevenue ", new object[] { });
        }

        public decimal TotalbyPayment(string payment)
        {
            string query = string.Format("SELECT SUM(o.TotalPrice) AS TotalRevenue FROM dbo.orders AS o WHERE o.payment = N'{0}'", payment);
            DataTable revenueTable = DataProvider.Instance.ExecuteQuery(query);

            decimal totalRevenue = 0;

            if (revenueTable.Rows.Count > 0 && revenueTable.Rows[0]["TotalRevenue"] != DBNull.Value)
            {
                totalRevenue = Convert.ToDecimal(revenueTable.Rows[0]["TotalRevenue"]);
            }

            return totalRevenue;
        }


        public List<Revenu> GetReveue()
        {
            List<Revenu> Revenue = new List<Revenu>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DBO.revenue WHERE state = 0");
            foreach (DataRow item in dt.Rows)
            {
                Revenu revenue = new Revenu(item); // Giả sử có lớp Item
                Revenue.Add(revenue);
            }
            return Revenue;

        }

        public void Checkoutrevenue()
        {
            // Sử dụng tham số để tránh lỗi Injection SQL và đảm bảo chuỗi Unicode được xử lý đúng
            string query = "UPDATE dbo.revenue SET state = 1";

            // Gọi phương thức ExecuteNonQuery của DataProvider để thực thi truy vấn
            DataProvider.Instance.ExecuteNonQuery(query);


        }
        public void UpdatePayment(decimal cash, decimal card , decimal grab)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdatePayment @cash , @card , @grab ", new object[] { cash, card, grab });
        }

        public void UpdateCash(decimal cash)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateCash @cash ", new object[] { cash });
        }

        public void UpdateCard(decimal card)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateCard @card ", new object[] { card });
        }
        public void UpdateGrab(decimal grab)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateGrab @grab ", new object[] { grab });
        }
    }
}
