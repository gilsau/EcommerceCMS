using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceCMS.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCount { get; set; }
        public string SubCats { get; set; }
        public string Logo { get; set; }
        public int ProductCount { get; set; }
    }
}