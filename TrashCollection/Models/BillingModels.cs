using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class BillingModels
    {
    }
    public class Account
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public double Balance { get; set; }
    }
    public class Transactions
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double? Payment { get; set; }
        public double? Charges { get; set; }
        public double Balance { get; set; }
        public Account Account { get; set; }

    }


}