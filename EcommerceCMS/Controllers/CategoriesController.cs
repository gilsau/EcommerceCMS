using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceCMS.Data;
using EcommerceCMS.Models;

namespace EcommerceCMS.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(CategoriesPostModel model)
        {
            EcommerceCMSEntities db = new EcommerceCMSEntities();

            //category source
            if (model.CategorySource == 1) //Websites
            {
                ViewBag.Websites = db.Websites.ToList();
            }
            else if (model.CategorySource == 2) //Suppliers
            {
                ViewBag.Suppliers = db.Suppliers.ToList();
            }

            //get categories
            if (model.WebsiteId > 0)
            {
                ViewBag.Categories = CategoryRepo.GetCategoriesFromWebsite(model.WebsiteId, model.ParentCategoryId);
            }
            else if (model.SupplierId > 0) {
                ViewBag.Categories = CategoryRepo.GetCategoriesFromSupplier(model.SupplierId);
            }
            
            //get products
            if (model.WebsiteId > 0 && model.CategoryId > 0)
            {
                ViewBag.Products = ProductRepo.GetProductsFromWebsiteCategory(model.WebsiteId, model.CategoryId);
            }
            else if (model.SupplierId > 0 && model.CategoryId > 0)
            {
                ViewBag.Products = ProductRepo.GetProductsFromSupplierCategory(model.SupplierId, model.CategoryId);
            }
            
            return View();
        }
    }
}