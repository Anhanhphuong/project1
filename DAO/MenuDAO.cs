using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class MenuDAO
    {
            private static MenuDAO instance;
            public static MenuDAO Instance
            {
                get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
                private set { MenuDAO.instance = value; }
            }

            private MenuDAO() { }
        public List<DTO.Menu> GetListMenubyTable(int id)
        {
            List<Menu> ListMenu = new List<Menu>();
            string query = "select i.name, d.quantity,i.price from dbo.detail as d, dbo.orders as o, dbo.item as i where d.order_id = o.id and d.item_id=i.id and o.status =0 and o.table_id=" + id;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Menu menu = new Menu(item); // Giả sử có lớp Item
                ListMenu.Add(menu);
            }
            return ListMenu;
        }

        
    }
}
