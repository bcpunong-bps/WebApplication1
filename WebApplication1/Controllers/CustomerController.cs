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

        [HandleError]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            return View();
        
        }

        //public ActionResult Create()
        //{
        //    CustomerDTO model = new CustomerDTO();
          
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult Create(CustomerDTO data)
        {

            //try
            //{
                var customer = new Customer
                {
                    CustId = data.CustId,
                    CustName = data.CustName
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new HandleErrorInfo(ex, "Customer Details", "Create"));
            //}
            //return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer model = new Customer();
            model = db.Customers.FirstOrDefault(x => x.CustId == id);
            return View(model);
        }




    }
}