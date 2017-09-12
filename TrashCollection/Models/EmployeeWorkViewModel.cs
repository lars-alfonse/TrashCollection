using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class EmployeeWorkViewModel
    {
        public EmployeeZipJunction Zip { get; set; }
        public List<UserAddressJunction> TodayTrash { get; set; }
        public List<UserAddressJunction> TomorrowTrash { get; set; }
        public string Today { get; set; }
        public string Tommorrow { get; set; }
        public EmployeeWorkViewModel()
        {
            TodayTrash = new List<UserAddressJunction>();
            TomorrowTrash = new List<UserAddressJunction>();
        }
    }
}