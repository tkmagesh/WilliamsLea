using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace NorthwindApp
{
    public partial class Order {
        public void Add(Order_Detail detail) {
            var currentOrderValue =  this.Order_Details.Sum(od => od.UnitPrice * od.Quantity);
            var detailValue = detail.Quantity * detail.UnitPrice;
            if ((currentOrderValue + detailValue) > 400)
                throw new Exception("Too many items in the order");
            this.Order_Details.Add(detail);

        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {
                var result = context.Database.SqlQuery<Product>("sp_getproducts");
                foreach (var p in result)
                {
                    Console.WriteLine(p.ProductName);
                }
                Console.ReadLine();
                //Add a new entity


                //Refering to the entity in another entity


                var productToDelete = new Product { ProductID = 100 };
                context.Products.Attach(productToDelete);
                context.Products.Remove(productToDelete);
                context.SaveChanges();
                Console.ReadLine();
            }
        }
    }
}
