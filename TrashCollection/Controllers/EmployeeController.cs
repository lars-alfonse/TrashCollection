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
            if(model.Zip != null)
            {
                model.TodayTrash = (from data in context.UserAddressDay.Include("UserAddress.Address").Include("UserAddress.Address.City").Include("UserAddress.Address.Zip").Include("UserAddress.Address.City.State").Include("UserAddress.User") where data.Day.DayPrefix == model.Today && data.UserAddress.Address.Zip.zip == model.Zip.ZipCode.zip && data.UserAddress.IsActive select data.UserAddress).ToList();
                model.TomorrowTrash = (from data in context.UserAddressDay.Include("UserAddress.Address").Include("UserAddress.Address.City").Include("UserAddress.Address.Zip").Include("UserAddress.Address.City.State").Include("UserAddress.User") where data.Day.DayPrefix == model.Tomorrow && data.UserAddress.Address.Zip.zip == model.Zip.ZipCode.zip select data.UserAddress).ToList();
            }
            return View(model);
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