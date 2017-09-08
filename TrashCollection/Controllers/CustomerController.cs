using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Billing()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAddress()
        {
            AddressModels model = new AddressModels();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAddress(AddressModels model)
        {
            UserAddressJunction junction = new UserAddressJunction();
            var username = User.Identity.GetUserName();
            var user = (from data in context.Users where data.UserName == username select data).First();
            context.Address.Add(model);
            context.SaveChanges();
            junction.Address = (from data in context.Address where data.addressLine == model.addressLine && data.CitiesID == model.CitiesID && data.ZipCodeID == model.ZipCodeID select data).First();
            junction.User = user;
            context.UserAddresses.Add(junction);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        private AddressModels GetAddress(AddressModels model)
        {
            var addresses = (from data in context.Address where data.addressLine == model.addressLine && data.CitiesID == model.CitiesID && data.ZipCodeID == model.ZipCodeID select data).ToList();
            if (addresses.Count > 0)
            {
                return (from data in context.Address where data.addressLine == model.addressLine && data.CitiesID == model.CitiesID && data.ZipCodeID == model.ZipCodeID select data).First();
            }
            else
            {

            }
        }
    }
}