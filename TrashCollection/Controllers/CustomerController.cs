﻿using Microsoft.AspNet.Identity;
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
            junction.Address = GetAddress(model);
            junction.User = user;
            var existingJunction = (from data in context.UserAddresses where data.Address.ID == junction.Address.ID && data.User.Id == junction.User.Id select data).ToList();
            if (existingJunction.Count > 0)
            {
                context.UserAddresses.Add(existingJunction[0]);
                context.SaveChanges();
            }
            else
            {
                context.UserAddresses.Add(junction);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Customer");
        }
        private AddressModels GetAddress(AddressModels model)
        {
            model.City = GetCity(model);
            model.Zip = GetZip(model);
            var addresses = (from data in context.Address where data.addressLine == model.addressLine && data.City.name == model.City.name && data.Zip.zip == model.Zip.zip select data).ToList();
            if (addresses.Count > 0)
            {
                return (from data in context.Address where data.addressLine == model.addressLine && data.City.name == model.City.name && data.Zip.zip == model.Zip.zip select data).First();
            }
            else
            {
                context.Address.Add(model);
                context.SaveChanges();
                return (from data in context.Address where data.addressLine == model.addressLine && data.City.name == model.City.name && data.Zip.zip == model.Zip.zip select data).First();

            }
        }

        private ZipCode GetZip(AddressModels model)
        {
            var Zips = (from data in context.Zip where data.zip == model.Zip.zip select data).ToList();
            if (Zips.Count > 0)
            {
                return (from data in context.Zip where data.zip == model.Zip.zip select data).First();
            }
            else
            {
                context.Zip.Add(model.Zip);
                context.SaveChanges();
                return (from data in context.Zip where data.zip == model.Zip.zip select data).First();
            }
        }

        private Cities GetCity(AddressModels model)
        {
            model.City.State = GetState(model);
            var cities = (from data in context.City where data.name == model.City.name && data.State.Name == model.City.State.Name select data).ToList();
            if (cities.Count > 0)
            {
                return (from data in context.City where data.name == model.City.name && data.State.Name == model.City.State.Name select data).First();
            }
            else
            {
                context.City.Add(model.City);
                context.SaveChanges();
                return (from data in context.City where data.name == model.City.name && data.State.Name == model.City.State.Name select data).First();
            }
        }

        private States GetState(AddressModels model)
        {
            var States = (from data in context.State where data.Name.ToLower() == model.City.State.Name.ToLower() select data).ToList();
            if (States.Count > 0)
            {
                return (from data in context.State where data.Name.ToLower() == model.City.State.Name.ToLower() select data).First();
            }
            else
            {
                return model.City.State;
            }
        }
    }
}