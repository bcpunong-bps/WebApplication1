﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {


        [HandleError]
        public ActionResult Index()
        {
            return View();
        
        }

        public ActionResult Add()
        {
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }
    }
}