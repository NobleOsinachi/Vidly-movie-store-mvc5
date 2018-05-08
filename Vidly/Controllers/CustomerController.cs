using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers
{

    [RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            //var customer = new CustomerStoreViewModel(); //Used hardcoded date stored in the viewmodel

            var customers = _dbContext.customers.Include(c => c.MembershipType).ToList(); // Eagerload the membership records

            return View(customers);
        }

        [HttpGet]
        [Route("details")]
        public ActionResult Details(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(204);

            //var customer = new CustomerStoreViewModel();
            var customer = _dbContext.customers.Include(c => c.MembershipType).SingleOrDefault(a => a.id == id);

            if (customer == null)

                return new HttpNotFoundResult();

            return View(customer);
        }

        [HttpGet]
        [Route("new")]
        public ActionResult CustomerForm()
        {
            var membershipType = _dbContext.membershipType.ToList();
            var viewModel = new CustomerViewModel
            {
                membershipType = membershipType
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Save(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            var newEntity =  Mapper.Map<Customers>(model);
            if(newEntity.id == 0)
            {
                _dbContext.customers.Add(newEntity);
            }
            else
            {
                var customerInDb = _dbContext.customers.Single(c => c.id == newEntity.id);

                customerInDb.Name = newEntity.Name;
                customerInDb.BirthDate = newEntity.BirthDate;
                customerInDb.MembershipTypeId = newEntity.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = newEntity.IsSubscribedToNewsletter;

            }

            _dbContext.SaveChanges();

            return RedirectToAction("index", "Customer"); //redirects the user back to the index action of the home controller
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                customer = customer,
                membershipType = _dbContext.membershipType.ToList()
            };

            return View("CustomerForm", viewModel); //returns the customerForm view and the passed model
        }
    }
}