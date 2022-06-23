using Quanly.Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanly.Controllers
{
    public class TintucController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: Tintuc
        public ActionResult Index()
        {
            var lsttintuc = objQuanlyEntities.tintucs.ToList();
            return View(lsttintuc);
        }
    }
}