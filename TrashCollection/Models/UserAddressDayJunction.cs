using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class UserAddressDayJunction
    {
        public int Id { get; set; }
        public UserAddressJunction UserAddress { get; set; }
        public DayOfWeek Day { get; set; }
    }
}