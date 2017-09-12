using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Support()
        {
            return View();
        }
        public ActionResult Work()
        { 
            var username = User.Identity.GetUserName();
            var user = (from data in context.Users where data.UserName == username select data).First();
            EmployeeWorkViewModel model = new EmployeeWorkViewModel();
            DateTime today = DateTime.Now;
            model.Today = today.DayOfWeek.ToString();
            model.Tomorrow = GetTomorrow(model.Today);
            model.Zip = (from data in context.WorkZip.Include("ZipCode") where data.User.Id == user.Id select data).FirstOrDefault();
            if(model.Zip!= null)
            {
                var TodayTrash = (from data in context.UserAddressDay.Include("UserAddress").Include("UserAddress.Address").Include("UserAddress.Address.City").Include("UserAddress.Address.Zip").Include("UserAddress.Address.City.State").Include("UserAddress.User") where data.Day.DayPrefix == model.Today && data.UserAddress.Address.Zip.zip == model.Zip.ZipCode.zip && data.UserAddress.IsActive select data.UserAddress).ToList();
                foreach(var item in TodayTrash)
                {
                    model.TodayTrash.Add((from data in context.UserAddresses.Include("Address").Include("User") where data.ID == item.ID select data).First());
                }
                var TomorrowTrash = (from data in context.UserAddressDay.Include("UserAddress").Include("UserAddress.Address").Include("UserAddress.Address.City").Include("UserAddress.Address.Zip").Include("UserAddress.Address.City.State").Include("UserAddress.User") where data.Day.DayPrefix == model.Tomorrow && data.UserAddress.Address.Zip.zip == model.Zip.ZipCode.zip select data.UserAddress).ToList();
                foreach (var item in TomorrowTrash)
                {
                    model.TomorrowTrash.Add((from data in context.UserAddresses.Include("Address").Include("User") where data.ID == item.ID select data).First());
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult SelectZipCode( )
        {
            EmployeeZipJunction model = new EmployeeZipJunction();
            return View(model);
        }
        [HttpPost]
        public ActionResult SelectZipCode(EmployeeZipJunction model)
        {
            var username = User.Identity.GetUserName();
            var user = (from data in context.Users where data.UserName == username select data).First();
            model.User = user;
            model.ZipCode = GetZip(model);
            var currentZipJunction = (from data in context.WorkZip.Include("ZipCode") where data.User.Id == user.Id select data).FirstOrDefault();
            if(currentZipJunction == null)
            {
                context.WorkZip.Add(model);
                context.SaveChanges();
            }
            else
            {
                currentZipJunction.ZipCode = model.ZipCode;
                context.SaveChanges();
            }
            return RedirectToAction("Work", "Employee");
        }

        private ZipCode GetZip(EmployeeZipJunction model)
        {
            var matchedZip = (from data in context.Zip where data.zip == model.ZipCode.zip select data).FirstOrDefault();
            if(matchedZip != null)
            {
                return matchedZip;
            }
            else
            {
                context.Zip.Add(model.ZipCode);
                context.SaveChanges();
                var currentZip = (from data in context.Zip where data.zip == model.ZipCode.zip select data).First();
                return currentZip;
            }
        }

        private string GetTomorrow(string day)
        {
            switch (day)
            {
                case "Sunday":
                    return "Monday";
                case "Monday":
                    return "Tuesday";
                case "Tuesday":
                    return "Wednesday";
                case "Wednesday":
                    return "Thursday";
                case "Thursday":
                    return "Friday";
                case "Friday":
                    return "Saturday";
                default:
                    return "Sunday";
            }
        }
    }
}