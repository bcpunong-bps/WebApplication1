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

            //OrderDTO orderDTO = new OrderDTO
            //{
            //    OrderDesc = orderDTO.OrderDesc,
            //};
            //ViewBag.Title = "Order List";
            //ViewBag.Message = "Welcome";
            //ViewModels mymodels = new ViewModels();

            // ViewBag.Title = "Order List";
            //var list = db.Orders.Include("Customer").ToList();
            // var model = list.Select(o => new OrderDTO
            // {
            //     Id = o.Id,
            //     OrderItemName = o.ItemName,
            //     OrderDesc = o.Description,

            // }).ToList();

            

            var list = db.Orders.ToList();
            var model = list.Select(c => new OrderDTO
            {
                Id = c.Id,
                OrderName = c.OrderName,
                OrderDescription = c.OrderDescription,
                CustomerId = c.CustomerId
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

            ViewData["Id"] = new SelectList(customerModel, "Id", "Name");

            //SelectList CustomerList = new SelectList(customerModel, "CustId", "CustName");
            //ViewData["CustId"] = CustomerList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDTO orderDTO,CustomerDTO customerDTO)
        {
            var Order = new Order
            {
                Id = orderDTO.Id,
                OrderName = orderDTO.OrderName,
                OrderDescription = orderDTO.OrderDescription,
                CustomerId = customerDTO.Id
            };
            
            db.Orders.Add(Order);

            db.SaveChanges();

            return RedirectToAction("Index");

            //var customers = db.Customers.ToList();
            //var customerModel = customers.Select(c => new CustomerDTO
            //{
            //    Id = c.Id,
            //    Name = c.Name
            //}).ToList();
            //var info = db.Customers.ToList();
            //var customers = db.Customers.ToList();
            //var customerModel = customers.Select(c => new CustomerDTO
            //{
            //    Id = c.Id,
            //    Name = c.Name
            //}).ToList();
            //ViewData["Name"] = new SelectList(customerModel, "Id", "Name");


            //var list = db.Customers.Contains(customer);
            //var order = new Order
            //{
            //    Id = data.Id,
            //    OrderName = data.OrderName,
            //    OrderDescription = data.OrderDescription,
            //    //data.CustomerId = CustomerId,
            //    CustomerId = data.CustomerId,

            //};

            ////ViewData["Name"] = new SelectList(customerModel, "Id", "Name");
            //db.Orders.Add(order);
            //db.SaveChanges();
            //return RedirectToAction("Index");
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