using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrungNguyenCoffee.DTO
{
    public class Order
    {
        public Order(int id, DateTime? dateCheckin, DateTime? dateCheckout, int userid, int status, int customerId)
        {
            this.Id = id;
            this.Userid = userid;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = dateCheckout;
            this.Status = status;
            this.CustomerId = customerId;
        }

        public Order(DataRow row)
        {
            this.Id = (int)row["id"];
           
            this.DateCheckin = (DateTime?)row["DateCheckin"];
            var dateCheckoutTemp = row["DateCheckout"];
            if (dateCheckoutTemp.ToString() != "") 
            {
                this.DateCheckout = (DateTime?)dateCheckoutTemp;
            }

            this.Userid = (int)row["user_id"];           
           this.Status= (int)row["status"];
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
        private DateTime? dateCheckin;
        public DateTime? DateCheckin
        {
            get { return dateCheckin; }
            set { dateCheckin = value; }
        }
        private DateTime? dateCheckout;
        public DateTime? DateCheckout
        {
            get { return dateCheckout; }
            set { dateCheckout = value; }
        }


        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

    }
}
