using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryAjaxWithMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            return View(DateTime.Now);
        }

        public ActionResult GetJsonTime() { 
            return Json(new { Time = DateTime.Now },JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEmployee()
        {
            var employees = new[] {new Employee{Id = 101, FirstName="Magesh"},new Employee{Id = 102, FirstName="Suresh"}};
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
