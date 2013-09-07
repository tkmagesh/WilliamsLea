using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreetMVCApp.Models;

namespace GreetMVCApp.Controllers
{
    public class GreetingController : Controller
    {
     
        [HttpGet]
        public ViewResult Greet()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Greet(NameInput nameInput)
        {
            if (this.ModelState.IsValid)
            {
                return View("GreetOutput", new GreetOutput
                    {
                        FirstName = nameInput.FirstName,
                        LastName = nameInput.LastName,
                        GreetMessage = "Hi " + nameInput.FirstName + " " + nameInput.LastName
                    });
            }
            return View(nameInput);
        }

    }
}
