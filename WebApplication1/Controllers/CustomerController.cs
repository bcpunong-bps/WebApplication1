using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext db = new CustomerContext();
        //Get Customer db context

      
        public ActionResult Index()
        {
            ViewBag.Title = "Customer List";
            var list = db.Customers.ToList();
            var model = list.Select(c => new CustomerDTO
            {
               Id = c.Id,
               Name = c.Name

            }).ToList();

            return View(model);
        }

        public ActionResult Add()
        {

            return View();

        }
        /// <summary>
        /// / POST AND GET FOR CREATE CUSTOMER 
        /// Return the Inputted Detail in The Table 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CustomerDTO();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerDTO data)
        {
            var customer = new Customer
            {
                Id = data.Id,
                Name = data.Name

            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer model = new Customer();
            model = db.Customers.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Customer data)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer model = new Customer();
            model = db.Customers.FirstOrDefault(x => x.Id==id);
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(Customer data)
        {
            
            return RedirectToAction("Index");

        }


    }
}