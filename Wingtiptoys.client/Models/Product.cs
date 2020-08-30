using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wingtiptoys.client.Models
{

    public class Product
    {
        [Display(Name = "Product_ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Unit Price")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Category ID")]
        public int? CategoryId { get; set; }
    }
}
