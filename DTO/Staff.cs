using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Staff
    {
        private Staff(int id, string name, string gender, string phone, string address, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.Role = role;
        }
        public Staff(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Gender = row["gender"].ToString();
            this.Phone = row["phone"].ToString();
            this.Address = row["address"].ToString();
            this.Role = row["role"].ToString();
        }
        public string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
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
