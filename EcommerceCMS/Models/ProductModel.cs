using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceCMS.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public decimal Wholesale { get; set; }
        public decimal Retail { get; set; }
    }
}