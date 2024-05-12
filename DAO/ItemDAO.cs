using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class ItemDAO
    {
        private static ItemDAO instance;

        public static ItemDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ItemDAO();
                return ItemDAO.instance;
            }
            private set
            {
                ItemDAO.instance = value;
            }
        }

        // Hàm tạo riêng tư (private) để ngăn chặn việc tạo thể hiện từ bên ngoài
        private ItemDAO() { }


        public List<Item> GetItemIdByCategory(int categoryId)
        {
            List<Item> items = new List<Item>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.item WHERE category_id =" + categoryId);
            foreach (DataRow dr in dt.Rows)
            {
                Item item = new Item(dr); // Giả sử có lớp Item
                items.Add(item);
            }
            return items;

        }

        public List<Item> GetItemId()
        {
            List<Item> items = new List<Item>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.item ");
            foreach (DataRow dr in dt.Rows)
            {
                Item item = new Item(dr); // Giả sử có lớp Item
                items.Add(item);
            }
            return items;

        }

        public int GetidByname(string name)
        {
            string query = string.Format("select id from dbo.item where name = N'{0}'", name);
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 1;
            }

        }
        public void InsertItem(string name, int categoryId, decimal price , byte[] image)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertItem @name , @categoryId , @price , @image", new object[] { name , categoryId, price , image});
        }

        public List<Item> SearchItembyname(string name)
        {
            List<Item> items = new List<Item>();
            string query = string.Format("SELECT * FROM DBO.item WHERE name like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow dt in data.Rows)
            {
                Item item = new Item(dt); // Giả sử có lớp Category

                items.Add(item);
            }

            return items;
        }

        public void DeleteItem(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteItem @itemid", new object[] { id });

        }

        public void UpdateItem(int id, string name, int categoryId, decimal price, byte[] image)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateItem @itemId , @name , @categoryId , @price , @image", new object[] { id, name, categoryId, price, image });
        }

    }
}
