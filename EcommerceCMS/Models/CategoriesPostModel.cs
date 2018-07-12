using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceCMS.Models
{
    public class CategoriesPostModel
    {
        public int CategorySource { get; set; }
        public int WebsiteId { get; set; }
        public int SupplierId { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BreadCrumbs { get; set; }
    }
}