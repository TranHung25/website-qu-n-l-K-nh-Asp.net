using Quanly.Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanly.Controllers
{
    public class KinhCanController : Controller
    {
        QuanlyEntities objQuanlyEntities = new QuanlyEntities();
        // GET: KinhCan
        public ActionResult Index()
        {
            var lstsanpham = objQuanlyEntities.sanphams.ToList();
            return View(lstsanpham);
        }
    }
}