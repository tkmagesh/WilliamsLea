using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductManagementApp.Controllers;
using ProductManagementApp.Models;

namespace ProductManagementApp.Intrastructure
{
    public class ProductRepository
    {
        private List<Product> _list;

        public ProductRepository()
        {
            if (HttpContext.Current.Session["products"] == null)
                HttpContext.Current.Session["products"] = new List<Product>();
            _list = (List<Product>) HttpContext.Current.Session["products"];
        }
        public int Add(Product product)
        {
            var newId = (_list.Any() ? _list.Max(p => p.Id) : 0) + 1;
            product.Id = newId;
            _list.Add(product);
            HttpContext.Current.Session["products"] = _list;
            return newId;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _list;
        } 
    }
}