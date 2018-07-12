using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EcommerceCMS.Data;

namespace EcommerceCMS.Controllers
{
    public class SitesController : Controller
    {
        // GET: Sites
        public ActionResult Index()
        {
            EcommerceCMSEntities db = new EcommerceCMSEntities();
            List<Website> webs = db.Websites.ToList();
            return View(webs);
        }
    }
}