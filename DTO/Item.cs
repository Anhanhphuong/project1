using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Item
    {
        public Item(int id, string name, decimal price, int categoryId, byte[] image, bool state)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.CategoryId = categoryId;
            this.Image = image;
            this.State = state;
        }

        public Item(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = Convert.ToDecimal(row["price"]);
            this.CategoryId = (int)row["category_id"];
            this.Image = (byte[])row["item_image"];
            this.State = (bool)row["state"];
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int categoryId;
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

       

        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        private bool state;
        public bool State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
