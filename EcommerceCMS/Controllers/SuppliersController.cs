using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceCMS.Data;

namespace EcommerceCMS.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            EcommerceCMSEntities db = new EcommerceCMSEntities();
            List<Supplier> suppliers = db.Suppliers.ToList();
            return View(suppliers);
        }
    }
}