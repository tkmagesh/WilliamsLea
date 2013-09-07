using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagementApp.Intrastructure;
using ProductManagementApp.Models;

namespace ProductManagementApp.Controllers
{
    
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        private ProductRepository repository;
        public ProductsController()
        {
            repository = new ProductRepository();
            if (!repository.GetAllProducts().Any())
            {
                repository.Add(new Product() {Name = "Pen", Price = 10});
                repository.Add(new Product() { Name = "Pencil", Price = 2 });
                repository.Add(new Product() { Name = "Marker", Price = 25 });
            }
        }
        [Log]
        [HandleError(ExceptionType = typeof(CustomException), View = "Sorry")]
        public ActionResult Index()
        {
            return View(repository.GetAllProducts());
        }


        [HttpGet]
        public ViewResult Add()
        {
            return View(new Product());

        }

        
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);
                this.TempData["something"] = "nothing";
                return RedirectToAction("Index");
            }
            return View(product);

        }
    }

    public class CustomException : Exception
    {
    }

    public class LogAttribute : ActionFilterAttribute
    {
        private DateTime startTime, endTime;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            startTime = DateTime.Now;
            Debug.WriteLine(filterContext.RouteData.Values["controller"] + " " +
                            filterContext.ActionDescriptor.ActionName + " started at " + DateTime.Now.ToLongTimeString());
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            endTime = DateTime.Now;
            Debug.WriteLine(filterContext.RouteData.Values["controller"] + " " +
                            filterContext.ActionDescriptor.ActionName + " started at " + DateTime.Now.ToLongTimeString());
            Debug.WriteLine("Time take to complete the action is " + (endTime - startTime).Milliseconds.ToString() + "millisecods");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            Debug.WriteLine(filterContext.Result);
        }
    }
    
}
