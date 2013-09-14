using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EFDemo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyAppContext();

            Database.SetInitializer<MyAppContext>(new DropCreateDatabaseIfModelChanges<MyAppContext>());

            //AddNewEmployeeWithManager(context);

            var employee = context.Employees.Find(1);
            Console.WriteLine(context.Employees.Find(1));
            //var newMgrMgr = new Employee { FirstName = "Chitra", LastName = "K" };
            //employee.Manager.Manager = newMgrMgr;
            //context.SaveChanges();
            Console.WriteLine(employee);
            Console.ReadLine();

            
        }

        private static void AddNewEmployeeWithManager(MyAppContext context)
        {
            var newEmployee = new Employee { FirstName = "Magesh", LastName = "Kuppan" };
            var newManager = new Employee { FirstName = "Rajesh", LastName = "Pandit" };
            newEmployee.Manager = newManager;

            Console.WriteLine("Before persisting");
            Console.WriteLine(newEmployee);
            Console.WriteLine(newManager);
            
            context.Employees.Add(newEmployee);
            context.SaveChanges();

            Console.ReadLine();
            Console.WriteLine("After persisting");
            Console.WriteLine(newEmployee);
            Console.WriteLine(newManager);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int Manager_Id { get; set; }

        public  Employee Manager { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\tManager={4}", Id, FirstName, LastName, string.Empty, string.Empty);
        }
    }

    public class MyAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

}
