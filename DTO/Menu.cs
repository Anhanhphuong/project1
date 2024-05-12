using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Menu
    {
        public Menu(string name, int quantity, decimal price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public Menu(DataRow row)
        {
            this.Name = row["name"].ToString();
            this.Quantity = (int)row["quantity"];
            this.Price = Convert.ToDecimal(row["price"]);
        }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
