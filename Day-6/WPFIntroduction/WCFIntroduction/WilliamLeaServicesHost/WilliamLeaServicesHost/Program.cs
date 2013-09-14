using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WilliamLeaServicesHost
{

    [ServiceBehavior]
    public class Calculator : ICalculator
    {
        [OperationBehavior]
        public void Add(int number1, int number2) {
            Console.WriteLine("Adding {0} and {1} results in {2}",number1,number2,number1 + number2);
        }

        [OperationBehavior]
        public void Subtract(int number1, int number2)
        {
            Console.WriteLine("Subtracting {1} from {0} results in {2}", number1, number2, number1 - number2);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Calculator), new Uri[]{});
            host.Opened += (s,a) =>{
                Console.WriteLine("Service started.. press ENTER to shutdown");
                Console.ReadLine();
            };
            host.Closed += (s, a) =>
            {
                Console.WriteLine("Service shutdown..");
                Console.ReadLine();
            };
            host.Open();
        }
    }
}
