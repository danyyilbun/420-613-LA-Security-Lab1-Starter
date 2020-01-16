using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
          
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;


            //Log the error!!
            if (System.IO.File.Exists(@"log.txt"))
            {
                using (StreamWriter w = System.IO.File.AppendText(@"../../log.txt"))
                {
                    Log(filterContext.Exception.ToString(), w);
                }

    
            }
            else
            {
                using (FileStream fs = System.IO.File.Create(@"../../log.txt"))
                {

                    using (StreamReader r = System.IO.File.OpenText(@"../../log.txt"))
                    {
                        DumpLog(r);
                        //Redirect or return a view, but not both.
                        filterContext.Result = RedirectToAction("Index", "Error");
                        // OR
                        filterContext.Result = new ViewResult
                        {
                            ViewName = "~/Views/Error/Index.cshtml"
                        };
                    }
                }
            }

        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

    }
}