using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace GreetingMVCApp
{
    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
    public class GreetingController : Controller
    {
        private readonly ITimeService _timeService;

        public GreetingController()
        {
            _timeService = new TimeService();
        }

        public GreetingController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public ViewResult Input()
        {
            var data = new ViewDataDictionary();
            data["FirstName"] = string.Empty;
            data["LastName"] = string.Empty;
            data["ValidationResult"] = new Dictionary<string,string>();
            return new ViewResult(){ViewName = "Input", ViewData = data};
        }
        public ViewResult Greet(string firstName, string lastName)
        {
            var data = new ViewDataDictionary();
            var validator = new NameValidator();
            validator.Validate(firstName, lastName);
            if (validator.HasErrors)
            {
                data["FirstName"] = firstName;
                data["LastName"] = lastName;
                data["ValidationResult"] = validator.ValidationResult;
                 
                return new ViewResult()
                    {
                        ViewName = "Input",
                        ViewData = data
                    };
            }
            var currentTime = _timeService.GetCurrentTime();
            var name = lastName + ", " + firstName;

            if (currentTime.Hour > 6 && currentTime.Hour < 18)
            {
                data["greetMsg"] = "Good Day " + name;
                return new ViewResult()
                {
                    ViewName = "GreetDayView",
                    ViewData = data
                };
            }
            data["greetMsg"] = "Good Night " + name;
            return new ViewResult()
                {
                    ViewName = "GreetNightView",
                    ViewData = data
                };
        }
    
    }
}