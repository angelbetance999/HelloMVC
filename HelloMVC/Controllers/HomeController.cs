using HelloMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult ViewCustomer(Customer postedCustomer)
        {
            Customer customer = new Customer();

            customer.Id = Guid.NewGuid().ToString();
            customer.Name = postedCustomer.Name;
            customer.Phone = postedCustomer.Phone;

            return View(customer);
        }

        public ActionResult AddCustomer() 
        {
            return View();
        }

        public ActionResult CustomerList() 
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Angel Mendoza - Movil", Phone = "(915) 603-2052" });
            customers.Add(new Customer() { Name = "Angel Mendoza - Work",  Phone = "(915) 600-1116" });

            return View(customers);
        }
    }
}