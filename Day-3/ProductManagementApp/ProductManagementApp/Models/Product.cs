using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagementApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(1,100)]
        public decimal Price { get; set; }

        public Product()
        {
            Id = -1;
        }
    }
}