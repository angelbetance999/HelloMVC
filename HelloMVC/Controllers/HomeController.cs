﻿using HelloMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Customer> customers;

        public HomeController()
        {
            customers = cache["customers"] as List<Customer>;
            if (customers == null)
            {
                customers = new List<Customer>();
            }

        }

        public void SaveCache()
        {
            cache["customers"] = customers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ls_message = "This is my first Web App in C#";
            ViewBag.ls_message2 = "Second change to Controller and View.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            } else
            {
                return View(customer);
            }
        }

        public ActionResult AddCustomer() 
        {
            return View();
        }

        [HttpPost] 
        public ActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();

            return RedirectToAction("CustomerList");
        }

        public ActionResult EditCustomer(string id) 
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer, string id)
        {
            var customerToEdit = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customerToEdit.Name = customer.Name;
                customerToEdit.Phone = customer.Phone;
                SaveCache();
                return RedirectToAction("CustomerList");
            }
        }

        public ActionResult DeleteCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult ConfirmDeleteCustomer(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customers.Remove(customer);
                return RedirectToAction("CustomerList");
            }
        }

        public ActionResult CustomerList() 
        {
            return View(customers);
        }
    }
}