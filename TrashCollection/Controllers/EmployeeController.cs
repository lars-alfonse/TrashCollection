using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollection.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
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
            DateTime today = DateTime.Now;
            string day = today.DayOfWeek.ToString();
            string tomorrow = GetTomorrow(day);
            return View();
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