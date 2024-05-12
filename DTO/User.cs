using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class User
    {
        private User(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public User(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["username"].ToString();
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
