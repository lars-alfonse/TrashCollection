using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class EmployeeZipJunction
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public ZipCode ZipCode { get; set; }
    }
}