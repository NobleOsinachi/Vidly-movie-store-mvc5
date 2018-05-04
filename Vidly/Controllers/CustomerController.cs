using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var customer = new Customers();

            return View(customer.customers);
        }

        public ActionResult Details(int id)
        {
            Customers customer = new Customers();
            var customerId = customer.customers.FirstOrDefault(a => a.id == id);

            if (customerId == null)

                return new HttpNotFoundResult();

            return Content(customerId.name);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}