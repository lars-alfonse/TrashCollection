using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class UserAddressJunction
    {
        public int ID { get; set; }
        public int ApplictionUserID { get; set; }
        public int AddressModelID { get; set; }
        public bool IsActive { get; set; }

        public ApplicationUser User { get; set; }
        public AddressModels Address { get; set; }
    }
}