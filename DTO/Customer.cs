using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Customer
    {
        public Customer(int id, string name, string phone, int score)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Score = score;
        }
        public Customer(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Phone = row["number"].ToString();
            this.Score = (int)row["score"];
        }
        public int id;
        public int Id

        {
            get { return id; }
            set { id = value; }
        }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public int score;
        public int Score

        {
            get { return score; }
            set { score = value; }
        }
    }
}
