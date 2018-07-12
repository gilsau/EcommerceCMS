using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceCMS.Data;
using EcommerceCMS.Models;

namespace EcommerceCMS.Controllers
{
    public class SuppSourceController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            EcommerceCMSEntities db = new EcommerceCMSEntities();
            List<SupplierSource> webs = db.SupplierSources.ToList();
            return View(webs);
        }

        [HttpGet]
        public JsonResult GetFileInfo(int id)
        {


            return Json("");
        }
    }