using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Discount
    {
        private Discount(int id, string name, int score)
        {
            this.Id = id;
            this.Name = name;
            this.Score = score;
        }
        public Discount(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Score = (int)row["score"];
        }
        public int score;
        public int Score

        {
            get { return score; }
            set { score = value; }
        }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int id;
        public int Id

        {
            get { return id; }
            set { id = value; }
        }
    }
}
