using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class AddressModels
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Address")]
        public string addressLine { get; set; }
        [Display(Name = "City")]
        public int CitiesID { get; set; }
        public int ZipCodeID { get; set; }

        public Cities City { get; set; }
        public ZipCode Zip { get; set; }

    }
    public class Cities
    {
        [Key]
        public int CitiesID { get; set; }
        [Display(Name = "City")]
        public string name { get; set; }
        public int StatesID { get; set; }
        public States State { get; set; }

    }
    public class States
    {
        [Key]
        public int StatesID { get; set; }
        [Display(Name = "State")]
        public string Name { get; set; }
        public string abbreviation { get; set; }
    }
    public class ZipCode
    {
        [Key]
        public int ZipCodeID { get; set; }
        [Display(Name = "Zip")]
        public int zip { get; set; }
    }
}