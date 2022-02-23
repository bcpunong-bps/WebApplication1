using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        CustomerContext db = new CustomerContext();

        [HandleError]
        public ActionResult Index()
        {
            ViewBag.Title = "Order List";
            var list = db.Orders.Include("Customer").ToList();
            var model = list.Select(o => new Order
            {
                Id = o.Id,
                ItemName = o.ItemName,
                Description = o.Description,
                //Customer = o.Customer
            }).ToList();

            return View(model);

        }

        public ActionResult Add()
        {
            return View();

        }


        [HttpGet]
        public ActionResult Create()
        {
            //var model = new OrderDTO();

            //return View(model);
            var customers = db.Customers.ToList();
            var customerModel = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            SelectList CustomerList = new SelectList(customerModel, "CustId", "CustName");
            ViewData["CustId"] = CustomerList;
            return View();
        }

        public ActionResult Create(OrderDTO data)
        {
            var order = new Order
            {
                Id = data.Id,
                ItemName = data.orderItemName,
                Description = data.orderDesc,
                CustomerId = data.CustId,
            };
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //===================== EDITE UPDATE ========================//
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Order model = new Order();
            model = db.Orders.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Order data)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Orders.FirstOrDefault(x => x.Id == data.Id);
                db.Entry(entity).CurrentValues.SetValues(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return View();
        }


        // =========================== Delete=================//

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Order model = new Order();
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(Order data)
        {
            return RedirectToAction("Index");
        }

    }
}