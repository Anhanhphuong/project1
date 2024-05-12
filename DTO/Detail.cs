using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Detail
    {
        public Detail(int id, int orderID, int itemid, int quantity, decimal price)
        {
            this.Id = id;
            this.OrderID = orderID;
            this.Itemid = itemid;
            this.Quantity = quantity;
          

        }

        public Detail(DataRow row)
        {
            this.Id = (int)row["id"];
            this.OrderID = (int)row["order_id"];
            this.Itemid = (int)row["item_id"];
            this.Quantity = (int)row["quantity"];
            
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        private int itemid;
        public int Itemid
        {
            get { return itemid; }
            set { itemid = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        

    }
}
