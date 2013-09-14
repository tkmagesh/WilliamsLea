using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WilliamsCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var calculator = new ServiceProxies.CalculatorClient();
            for (int i = 0; i < 20; i++)
            {
                calculator.Add(100+i, 80-i);
            }
            Console.ReadLine();
        }
    }
}
