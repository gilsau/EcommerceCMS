using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceCMS.Data;

namespace EcommerceCMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EcommerceCMSEntities db = new EcommerceCMSEntities();

            Dictionary<string, int> counts = new Dictionary<string, int>();
            counts.Add("sources", db.SupplierSources.Count());
            counts.Add("suppliers", db.Suppliers.Count());
            counts.Add("websites", db.Websites.Count());
            counts.Add("categories_web", CategoryRepo.GetCategoriesFromWebsite(0, 0).Count);
            counts.Add("categories_supp", CategoryRepo.GetCategoriesFromSupplier(0).Count);
            counts.Add("products", 0);

            return View(counts);
        }
    }
}