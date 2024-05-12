using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class DiscountDAO
    {
        private static DiscountDAO instance;
        public static DiscountDAO Instance
        {
            get { if (instance == null) instance = new  (); return DiscountDAO.instance; }
            private set { DiscountDAO.instance = value; }
        }

        private DiscountDAO() { }

        public List<Discount> GetlistDiscount()
        {
            List<Discount> discounts = new List<Discount>();
            string query = "SELECT * FROM dbo.discount";
            DataTable dt=DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Discount discount = new Discount(item);
                discounts.Add(discount);
            }
            return discounts;
        }
    }
}
