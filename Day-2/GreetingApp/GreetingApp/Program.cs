using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            var userName = Console.ReadLine();
            var timeService = new TimeService();
            var greeter = new Greeter(timeService);
            Console.WriteLine(greeter.Greet(userName));
            Console.ReadLine();
        }
    }

    public class Greeter
    {
        private readonly ITimeService _timeService;

        public Greeter(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string Greet(string userName)
        {
            var currentTime = _timeService.GetCurrentTime();
            if (currentTime.Hour > 6 && currentTime.Hour < 18)
            {
                return string.Format("Good Day {0}", userName);
            }
            return string.Format("Good Night {0}", userName);
        }
    }

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




}
