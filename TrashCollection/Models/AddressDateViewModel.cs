using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class AddressDateViewModel
    {
        public List<AddressModels> addresses { get; set; }
        public List<UserAddressJunction> userAddresses { get; set; }
        public List<UserAddressDayJunction> Days { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; }
        public AddressDateViewModel()
        {
            addresses = new List<AddressModels>();
            userAddresses = new List<UserAddressJunction>();
            Days = new List<UserAddressDayJunction>();
            DaysOfWeek = new List<DayOfWeek>();
        }
    }
}