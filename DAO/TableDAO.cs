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
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> TableList = new List<Table>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GetTableLists");
            foreach (DataRow dr in dt.Rows)
            {
                Table table = new Table(dr);
                TableList.Add(table);
            }
            return TableList;
        }

       

    }
}
