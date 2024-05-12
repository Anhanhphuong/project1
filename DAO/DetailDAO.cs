using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DAO
{
    public class DetailDAO
    {
        private static DetailDAO instance;
        public static DetailDAO Instance
        {
            get { if (instance == null) instance = new DetailDAO(); return DetailDAO.instance; }
            private set { DetailDAO.instance = value; }
        }

        private DetailDAO() { }

        public List<DTO.Detail> GetListDetail(int id)
        {
            List<DTO.Detail> details = new List<DTO.Detail>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT*FROM dbo.detail WHERE order_id=" + id);
            foreach (DataRow item in dt.Rows)
            {
                DTO.Detail detail = new DTO.Detail(item);
                details.Add(detail);
            }
            return details;
        }
        public void InsertDetail(int id  ,int itemID)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertDetail @order_id , @item_id", new object[] { id , itemID });

        }
        public void InsertDetailcus(int id, int quantity, int itemID)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertCustomDetail @order_id , @quantity , @item_id", new object[] { id, quantity, itemID });

        }
        public void DeleteDetail( int itemID )
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteDetail @item_id", new object[] { itemID });

        }

    }
}
