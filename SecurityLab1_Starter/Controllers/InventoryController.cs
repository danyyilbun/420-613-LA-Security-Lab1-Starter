using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers {
    
    public class InventoryController : Controller
    {

        [Authorize]
        // GET: Inventory
        public ActionResult Index()
        {
            //throw new Exception();
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {

            LogingUtil lg = new LogingUtil();
            lg.logToText(filterContext);
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Error");
            // OR
            filterContext.Result = new ViewResult {
                ViewName = "~/Views/Error/Index.cshtml"
            };
        }
       

    }
}