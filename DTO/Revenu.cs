using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungNguyenCoffee.DTO
{
    public class Revenu
    {
        public Revenu(int id, DateTime? checkin, DateTime? checkout, int userid, int state)
        {
            this.Id = id;           
            this.Checkin = checkin;
            this.Checkout = checkout;
            this.Userid = userid;
            this.State = state;
            
        }

        public Revenu(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Checkin = (DateTime?)row["Checkin"];
            var dateCheckoutTemp = row["Checkout"];
            if (dateCheckoutTemp.ToString() != "")
            {
                this.Checkout = (DateTime?)dateCheckoutTemp;
            }
            this.Userid = (int)row["user_id"];
            this.State = (int)row["state"];

        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int userid;
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private DateTime? checkin;
        public DateTime? Checkin
        {
            get { return checkin; }
            set { checkin = value; }
        }
        private DateTime? checkout;
        public DateTime? Checkout
        {
            get { return checkout; }
            set { checkout = value; }
        }


        private int state;
        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
